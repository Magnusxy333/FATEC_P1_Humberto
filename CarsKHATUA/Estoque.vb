Imports System.Data

Public Class Estoque

    ' Variável global para identificar qual peça foi clicada na tabela
    Dim id_peca_selecionada As String = ""

    Private Sub Estoque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' 1. Configurações visuais da Grid
            dgv_estoqueDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv_estoqueDados.MultiSelect = False
            dgv_estoqueDados.ReadOnly = True

            ' Certifique-se de que os nomes das colunas correspondam aos adicionados pelo DataTable
            ' Para evitar duplicação, podemos limpar as colunas ou ajustar a lógica.

            ' 2. Conecta e carrega os dados iniciais
            Connecta_banco()
            Carregar_dados_estoque()

            ' 3. Configura o ComboBox de filtro
            cmd_campo.Items.Clear()
            cmd_campo.Items.Add("desc_produto")
            cmd_campo.Items.Add("id_produto")
            cmd_campo.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Erro ao iniciar formulário: " & ex.Message)
        End Try
    End Sub

    ' --- 1. LÓGICA DE BUSCA E CARREGAMENTO ---

    Private Sub txt_buscar_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        Try
            Connecta_banco()
            ' Filtra os produtos na tabela tb_cadastro_prod conforme o usuário digita
            sql = "SELECT p.id_produto, p.desc_produto, p.qnt_dis_prod, " &
                  "(SELECT MAX(data_movimentacao) FROM tb_movimentacoes m WHERE m.id_produto = p.id_produto) AS ultima_mov " &
                  "FROM tb_cadastro_prod p " &
                  "WHERE p." & cmd_campo.Text & " LIKE '" & txt_buscar.Text & "%'"
            rs = db.Execute(sql)
            PreencherGrid()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Carregar_dados_estoque()
        Try
            Connecta_banco()
            ' Busca todos os itens cadastrados
            sql = "SELECT p.id_produto, p.desc_produto, p.qnt_dis_prod, " &
                  "(SELECT MAX(data_movimentacao) FROM tb_movimentacoes m WHERE m.id_produto = p.id_produto) AS ultima_mov " &
                  "FROM tb_cadastro_prod p ORDER BY p.desc_produto ASC"
            rs = db.Execute(sql)
            PreencherGrid()
        Catch ex As Exception
            MsgBox("Erro ao carregar dados do banco: " & ex.Message)
        End Try
    End Sub

    ' Função vital: Transforma os dados do Banco (RS) em uma Tabela Visual (DataTable)
    Private Sub PreencherGrid()
        Try
            Dim dt As New DataTable
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("Produto", GetType(String))
            dt.Columns.Add("Qtd Atual", GetType(Integer))
            dt.Columns.Add("Última Movimentação", GetType(String))

            If rs IsNot Nothing Then
                Do While Not rs.EOF
                    Dim dataMovStr As String = "-"
                    Dim ultimaMov = rs.Fields("ultima_mov").Value
                    If ultimaMov IsNot DBNull.Value AndAlso ultimaMov IsNot Nothing Then
                        dataMovStr = Convert.ToDateTime(ultimaMov).ToString("dd/MM/yyyy HH:mm:ss")
                    End If

                    dt.Rows.Add(rs.Fields("id_produto").Value,
                                rs.Fields("desc_produto").Value,
                                rs.Fields("qnt_dis_prod").Value,
                                dataMovStr)
                    rs.MoveNext()
                Loop
            End If

            dgv_estoqueDados.DataSource = dt

            ' Algumas vezes o DataSource reseta a exibição das imagens nos ImageColumns
            ' Forçar atribuição das imagens diretamente nas células das colunas de botões:
            For Each row As DataGridViewRow In dgv_estoqueDados.Rows
                If btn_entrada.Image IsNot Nothing Then
                    row.Cells("btn_entrada").Value = btn_entrada.Image
                End If
                If btn_saida.Image IsNot Nothing Then
                    row.Cells("btn_saida").Value = btn_saida.Image
                End If
            Next

        Catch ex As Exception
            MsgBox("Erro ao processar tabela: " & ex.Message)
        End Try
    End Sub

    ' --- 2. SELEÇÃO DE ITEM ---

    ' Evento para forçar o desenho das imagens nas colunas não acopladas aos dados
    Private Sub dgv_estoqueDados_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv_estoqueDados.CellFormatting
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                Dim colName As String = dgv_estoqueDados.Columns(e.ColumnIndex).Name
                If colName = "btn_entrada" AndAlso btn_entrada.Image IsNot Nothing Then
                    e.Value = btn_entrada.Image
                    e.FormattingApplied = True
                ElseIf colName = "btn_saida" AndAlso btn_saida.Image IsNot Nothing Then
                    e.Value = btn_saida.Image
                    e.FormattingApplied = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_estoqueDados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_estoqueDados.CellClick
        Try
            ' Verifica se o usuário clicou em uma linha válida (não no cabeçalho)
            If e.RowIndex >= 0 Then
                ' Busca pelo nome da coluna ao invés do índice fixo para evitar pegar as colunas de botões
                Dim cellValueId = dgv_estoqueDados.Rows(e.RowIndex).Cells("ID").Value
                Dim cellValueName = dgv_estoqueDados.Rows(e.RowIndex).Cells("Produto").Value

                If cellValueId IsNot Nothing AndAlso Not DBNull.Value.Equals(cellValueId) Then
                    ' Pega o ID
                    id_peca_selecionada = cellValueId.ToString()
                    ' Mostra o nome da peça no título da janela para confirmar a seleção
                    Me.Text = "Movimentar: " & If(cellValueName IsNot Nothing, cellValueName.ToString(), "Desconhecido")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_estoqueDados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_estoqueDados.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                ' Identifica se clicou nos botões de imagem
                Dim colName As String = dgv_estoqueDados.Columns(e.ColumnIndex).Name

                If colName = "btn_entrada" Then
                    ProcessarMovimentacao("+", dgv_estoqueDados.Rows(e.RowIndex))
                ElseIf colName = "btn_saida" Then
                    ProcessarMovimentacao("-", dgv_estoqueDados.Rows(e.RowIndex))
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' --- 3. LÓGICA DOS BOTÕES (AÇÕES) ---

    Private Sub ProcessarMovimentacao(operacao As String, row As DataGridViewRow)
        Try
            ' Busca o ID da linha atual (assumindo que a coluna ID seja gerada após os botões, ex: índice 2, ou pelo nome "ID")
            Dim idVal = row.Cells("ID").Value
            If idVal Is Nothing OrElse DBNull.Value.Equals(idVal) Then
                Exit Sub
            End If
            Dim id_peca As String = idVal.ToString()

            ' Validação: Quantidade deve ser válida
            Dim input As String = InputBox("Informe a quantidade para movimentar:", "Quantidade", "1")
            If String.IsNullOrWhiteSpace(input) Then Exit Sub

            Dim quantidade As Integer = Val(input)
            If quantidade <= 0 Then
                MsgBox("Informe uma quantidade maior que zero!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ' Validação: Se for saída, não pode tirar mais do que tem
            If operacao = "-" Then
                Dim qtdDisponivel As Integer = Convert.ToInt32(row.Cells("Qtd Atual").Value)
                If quantidade > qtdDisponivel Then
                    MsgBox("Saldo insuficiente! Você só possui " & qtdDisponivel & " unidades.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            Connecta_banco()

            ' A) Atualiza o estoque na tabela de produtos
            sql = "UPDATE tb_cadastro_prod SET qnt_dis_prod = qnt_dis_prod " & operacao & " " & quantidade &
                  " WHERE id_produto = " & id_peca
            db.Execute(sql)

            ' B) Grava o Log na tabela de movimentações (Rastreabilidade)
            Dim tipoStr As String = If(operacao = "+", "ENTRADA", "SAIDA")
            sql = "INSERT INTO tb_movimentacoes (id_produto, tipo_operacao, quantidade, data_movimentacao) " &
                  "VALUES (" & id_peca & ", '" & tipoStr & "', " & quantidade & ", GETDATE())"
            db.Execute(sql)

            MsgBox("Movimentação de " & tipoStr & " realizada!", MsgBoxStyle.Information)

            ' Limpa tudo para a próxima operação
            id_peca_selecionada = ""
            Me.Text = "Gerenciamento de Estoque"
            Carregar_dados_estoque() ' Atualiza a grid para mostrar o novo saldo

        Catch ex As Exception
            MsgBox("Erro ao processar movimentação: " & ex.Message)
        End Try
    End Sub

    Private Sub ConsultaDeProdutoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeProdutoToolStripMenuItem.Click
        Try
            Consultar.Show()
            Me.Hide()
        Catch ex As Exception
            MsgBox("Erro ao abrir consulta: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CadastroDeProdutoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CadastroDeProdutoToolStripMenuItem.Click
        Try
            ' IMPORTANTE: Reseta o ID para -1 ANTES de abrir o formulário
            id_editar = -1

            ' Cria uma NOVA instância do Form1 para garantir que está limpo
            Dim frmCadastro As New Cadastro()
            frmCadastro.ShowDialog()

            ' Atualiza a grid após fechar (caso algo tenha sido cadastrado com impacto na tela de estoque)
            Carregar_dados_estoque()
        Catch ex As Exception
            MsgBox("Erro ao abrir cadastro: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub VendasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VendasToolStripMenuItem.Click
        Vendas.Show()
        Me.Hide()
    End Sub

    ' Fechar a aplicação quando a aba Estoque for fechada (ao clicar no X)
    Private Sub Estoque_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not Me.Modal Then
            Application.Exit()
        End If
    End Sub
End Class