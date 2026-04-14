Imports System.Data

Public Class Vendas
    Dim id_peca_selecionada As String = ""

    Private Sub Vendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgv_vendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv_vendas.MultiSelect = False
            dgv_vendas.ReadOnly = True
            dgv_vendas.AllowUserToAddRows = False

            Connecta_banco()
            Carregar_dados_vendas()

            ToolStripComboBox1.Items.Clear()
            ToolStripComboBox1.Items.Add("id_produto")
            ToolStripComboBox1.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Erro ao iniciar tela: " & ex.Message)
        End Try
    End Sub

    ' 1. BUSCA E LISTAGEM (Ajustado para somar a coluna 'quantidade')
    Private Sub txt_buscar_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox1.TextChanged
        Try
            Connecta_banco()
            Dim busca As String = ToolStripTextBox1.Text.Replace("'", "''")

            ' Verifica se algo foi selecionado no filtro
            Dim campoFiltro As String = ToolStripComboBox1.Text
            If String.IsNullOrWhiteSpace(campoFiltro) Then
                campoFiltro = "desc_produto" ' Valor padrão seguro
            End If

            ' Mudamos SUM(vendidos) para SUM(quantidade) de acordo com seu banco
            sql = "SELECT p.id_produto, p.desc_produto, p.qnt_dis_prod, p.preco_venda, " &
                  "(SELECT COALESCE(SUM(v.quantidade), 0) FROM tb_vendas v WHERE v.id_produto = p.id_produto) AS vendidos_total " &
                  "FROM tb_cadastro_prod p " &
                  "WHERE p." & campoFiltro & " LIKE '%" & busca & "%'"
            rs = db.Execute(sql)
            PreencherGridVendas()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Carregar_dados_vendas()
        Try
            Connecta_banco()
            ' Mudamos SUM(vendidos) para SUM(quantidade) de acordo com seu banco
            sql = "SELECT p.id_produto, p.desc_produto, p.qnt_dis_prod, p.preco_venda, " &
                  "(SELECT COALESCE(SUM(v.quantidade), 0) FROM tb_vendas v WHERE v.id_produto = p.id_produto) AS vendidos_total " &
                  "FROM tb_cadastro_prod p ORDER BY p.desc_produto ASC"
            rs = db.Execute(sql)
            PreencherGridVendas()
        Catch ex As Exception
            MsgBox("Erro ao carregar: " & ex.Message)
        End Try
    End Sub

    Private Sub PreencherGridVendas()
        Try
            Dim dt As New DataTable
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("Produto", GetType(String))
            dt.Columns.Add("Estoque", GetType(Integer))
            dt.Columns.Add("Preço Unit.", GetType(String))
            dt.Columns.Add("Vendidos", GetType(Integer))

            If rs IsNot Nothing Then
                Do While Not rs.EOF
                    dt.Rows.Add(rs.Fields("id_produto").Value,
                                rs.Fields("desc_produto").Value,
                                rs.Fields("qnt_dis_prod").Value,
                                FormatCurrency(rs.Fields("preco_venda").Value),
                                rs.Fields("vendidos_total").Value)
                    rs.MoveNext()
                Loop
            End If
            dgv_vendas.DataSource = dt

            For Each row As DataGridViewRow In dgv_vendas.Rows
                If btn_entrada.Image IsNot Nothing Then
                    row.Cells("btn_entrada").Value = btn_entrada.Image
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    ' 2. EXECUÇÃO DA VENDA (Nomes de colunas batendo com o Workbench)
    Private Sub ExecutarVenda(row As DataGridViewRow)
        Try
            Dim id_peca As String = row.Cells("ID").Value.ToString()
            Dim nome_peca As String = row.Cells("Produto").Value.ToString()

            ' Limpa o R$ para converter o preço
            Dim precoStr As String = row.Cells("Preço Unit.").Value.ToString().Replace("R$", "").Trim()
            Dim preco As Double = CDbl(precoStr)

            Dim input As String = InputBox("Vender: " & nome_peca & vbCrLf & "Quantidade:", "Venda", "1")
            If String.IsNullOrWhiteSpace(input) Then Exit Sub

            Dim quantidade As Integer = Val(input)
            Dim qtdEstoque As Integer = Convert.ToInt32(row.Cells("Estoque").Value)

            If quantidade <= 0 Or quantidade > qtdEstoque Then
                MsgBox("Quantidade inválida ou estoque insuficiente!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Connecta_banco()

            ' A) Baixa no Estoque (tb_cadastro_prod)
            sql = "UPDATE tb_cadastro_prod SET qnt_dis_prod = qnt_dis_prod - " & quantidade & " WHERE id_produto = " & id_peca
            db.Execute(sql)

            ' B) Histórico Geral (tb_movimentacoes)
            sql = "INSERT INTO tb_movimentacoes (id_produto, tipo_operacao, quantidade, data_movimentacao) " &
            "VALUES (" & id_peca & ", 'VENDA', " & quantidade & ", GETDATE())"
            db.Execute(sql)

            ' C) Tabela Específica de Vendas (tb_vendas)
            ' Ajustado para: id_produto, quantidade, valor_unitario (de acordo com seu print)
            Dim precoSql As String = preco.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)

            sql = "INSERT INTO tb_vendas (id_produto, quantidade, valor_unitario, data_venda) " &
            "VALUES (" & id_peca & ", " & quantidade & ", " & precoSql & ", GETDATE())"
            db.Execute(sql)

            MsgBox("Venda de " & nome_peca & " finalizada!", MsgBoxStyle.Information)
            Carregar_dados_vendas()

        Catch ex As Exception
            MsgBox("Erro ao processar venda: " & ex.Message)
        End Try
    End Sub

    Private Sub dgv_vendas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_vendas.CellContentClick
        If e.RowIndex >= 0 Then
            Dim colName As String = dgv_vendas.Columns(e.ColumnIndex).Name
            If colName = "btn_entrada" Then
                ExecutarVenda(dgv_vendas.Rows(e.RowIndex))
            End If
        End If
    End Sub

    ' --- 3. MENU DE NAVEGAÇÃO ---

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Cadastro.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Consultar.Show()
        Me.Hide()
    End Sub

    Private Sub EstoqueDeProdutosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstoqueDeProdutosToolStripMenuItem.Click
        Estoque.Show()
        Me.Hide()
    End Sub

    ' Adicionado para fechar todo o sistema quando a tela de Vendas for fechada se Vendas não for modal
    Private Sub Vendas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not Me.Modal Then
            Application.Exit()
        End If
    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox1.Click

    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox1.Click

    End Sub
End Class