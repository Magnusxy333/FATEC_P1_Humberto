Public Class Consultar

    Private Sub Consultar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Carrega os dados na grid assim que a página é aberta
            Carregar_dados()
        Catch ex As Exception
            MsgBox("Erro ao carregar dados: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CadastroDeProdutoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CadastroDeProdutoToolStripMenuItem.Click
        Try
            ' IMPORTANTE: Reseta o ID para -1 ANTES de abrir o formulário
            id_editar = -1

            ' Cria uma NOVA instância do Form1 para garantir que está limpo
            Dim frmCadastro As New Cadastro()
            frmCadastro.ShowDialog()

            ' Atualiza a grid após fechar
            Carregar_dados()
        Catch ex As Exception
            MsgBox("Erro ao abrir cadastro: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgv_dados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_dados.CellContentClick
        Try
            If e.RowIndex < 0 Then Exit Sub

            ' Botão EDITAR
            If dgv_dados.Columns(e.ColumnIndex).Name = "btn_editar" Then
                ' Define o ID para edição
                id_editar = Convert.ToInt32(dgv_dados.Rows(e.RowIndex).Cells("id_produto").Value)

                ' Cria uma NOVA instância do Form1 para edição
                Dim frmEdicao As New Cadastro()
                frmEdicao.ShowDialog()

                ' RESETA O ID NOVAMENTE APÓS FECHAR A EDIÇÃO
                id_editar = -1

                ' Atualiza a grid
                Carregar_dados()
            End If

            ' Botão EXCLUIR
            If dgv_dados.Columns(e.ColumnIndex).Name = "btn_excluir" Then
                Dim id As Integer = Convert.ToInt32(dgv_dados.Rows(e.RowIndex).Cells("id_produto").Value)
                Dim nome As String = dgv_dados.Rows(e.RowIndex).Cells("desc_produto").Value.ToString()

                If MsgBox($"Deseja realmente excluir o produto: {nome}?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMAÇÃO") = MsgBoxResult.Yes Then
                    Connecta_banco()

                    ' Primeiro remove os registros dependentes para não dar erro de Chave Estrangeira
                    db.Execute($"DELETE FROM tb_vendas WHERE id_produto = {id}")
                    db.Execute($"DELETE FROM tb_movimentacoes WHERE id_produto = {id}")

                    ' Depois remove o produto
                    sql = $"DELETE FROM tb_cadastro_prod WHERE id_produto = {id}"
                    db.Execute(sql)

                    MsgBox("Produto excluído com sucesso!", MsgBoxStyle.Information)
                    Carregar_dados()
                End If
            End If

        Catch ex As Exception
            MsgBox("Erro: " & ex.Message)
        End Try
    End Sub

    Private Sub txt_buscar_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        Try
            Dim busca As String = txt_buscar.Text.Replace("'", "''")
            Dim campo As String = "desc_produto"

            Select Case cmd_campo.Text
                Case "DESCRIÇÃO"
                    campo = "desc_produto"
                Case "CATEGORIA"
                    campo = "categoria_prod"
                Case "MARCA"
                    campo = "marca_produto"
            End Select

            sql = $"SELECT id_produto, desc_produto, categoria_prod, marca_produto, qnt_dis_prod, preco_venda, preco_custo FROM tb_cadastro_prod WHERE {campo} LIKE '%{busca}%' ORDER BY desc_produto ASC"

            If db Is Nothing OrElse db.State <> 1 Then
                Connecta_banco()
            End If

            rs = db.Execute(sql)

            With dgv_dados
                .Rows.Clear()
                Do While Not rs.EOF
                    Dim v_custo As Double = Val(rs.Fields("preco_custo").Value & "")
                    Dim v_venda As Double = Val(rs.Fields("preco_venda").Value & "")
                    Dim v_margem As String = "0,00%"

                    If v_venda > 0 Then
                        v_margem = FormatNumber(((v_venda - v_custo) / v_venda) * 100, 2) & "%"
                    End If

                    .Rows.Add(
                        rs.Fields("id_produto").Value,
                        rs.Fields("desc_produto").Value & "",
                        rs.Fields("categoria_prod").Value & "",
                        rs.Fields("marca_produto").Value & "",
                        Val(rs.Fields("qnt_dis_prod").Value & ""),
                        FormatCurrency(v_venda),
                        v_margem,
                        Nothing,
                        Nothing
                    )
                    rs.MoveNext()
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro na pesquisa: " & ex.Message)
        End Try
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub EstoqueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstoqueToolStripMenuItem.Click
        Try
            Estoque.Show()
            Me.Hide()
        Catch ex As Exception
            MsgBox("Erro ao abrir estoque: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub VendasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VendasToolStripMenuItem.Click
        Vendas.Show()
        Me.Hide()
    End Sub

    ' Fechar a aplicação quando a aba Consultar for fechada (ao clicar no X)
    Private Sub Consultar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not Me.Modal Then
            Application.Exit()
        End If
    End Sub
End Class