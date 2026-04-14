Imports System.Text.RegularExpressions

Public Class Cadastro

    Private imgPadrao As Image

    Public Sub New()
        ' Esta chamada é exigida pelo designer.
        InitializeComponent()
        ' Adicione qualquer inicialização após a chamada InitializeComponent().

        ' Armazena a imagem do designer para uso como padrão
        If foto_prod_pic.Image IsNot Nothing Then
            imgPadrao = foto_prod_pic.Image.Clone()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Se for novo cadastro (id_editar = -1), limpa tudo
        If id_editar = -1 Then
            desc_produto_text.Text = ""
            qnt_dis_prod_text.Text = ""
            preco_cust_text.Text = ""
            preco_venda_text.Text = ""
            categoria_produto_cmd.SelectedIndex = -1
            marca_produto_cmd.SelectedIndex = -1
            data_lote_date.Value = DateTime.Now
            diretorio = ""  ' IMPORTANTE: diretorio vazio para não salvar imagem default

            ' Carrega a imagem default SOMENTE PARA EXIBIÇÃO
            CarregarImagemDefault()
        End If

        Try
            ' Verifica e inicializa a conexão
            If db Is Nothing Then
                Connecta_banco()
            End If

            Carregar_tipo()
            Carregar_dados()

            ' Se for edição, carrega os dados
            If id_editar <> -1 Then
                Carregar_Dados_Edicao()
            End If
        Catch ex As Exception
            MsgBox("Erro ao carregar formulário: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' Método para carregar a imagem default (apenas para exibição)
    Private Sub CarregarImagemDefault()
        Try
            ' Carrega a imagem armazenada que veio do designer
            If imgPadrao IsNot Nothing Then
                foto_prod_pic.Image = imgPadrao
            Else
                Dim bmp As New Bitmap(foto_prod_pic.Width, foto_prod_pic.Height)
                Using g As Graphics = Graphics.FromImage(bmp)
                    g.Clear(Color.FromArgb(240, 240, 240))
                    g.DrawString("Sem Foto",
                                New Font("Segoe UI", 12, FontStyle.Bold),
                                Brushes.Gray,
                                New PointF((foto_prod_pic.Width - 80) / 2, (foto_prod_pic.Height - 20) / 2))
                End Using
                foto_prod_pic.Image = bmp
            End If
            foto_prod_pic.SizeMode = PictureBoxSizeMode.StretchImage
        Catch ex As Exception
            foto_prod_pic.Image = Nothing
        End Try
    End Sub

    Sub Carregar_Dados_Edicao()
        Try
            ' Verifica conexão
            If db Is Nothing OrElse db.State <> 1 Then
                Connecta_banco()
            End If

            sql = $"SELECT * FROM tb_cadastro_prod WHERE id_produto = {id_editar}"
            rs = db.Execute(sql)

            If Not rs.EOF Then
                desc_produto_text.Text = rs.Fields("desc_produto").Value & ""
                qnt_dis_prod_text.Text = rs.Fields("qnt_dis_prod").Value & ""
                categoria_produto_cmd.Text = rs.Fields("categoria_prod").Value & ""
                marca_produto_cmd.Text = rs.Fields("marca_produto").Value & ""
                preco_cust_text.Text = Convert.ToDouble(rs.Fields("preco_custo").Value).ToString("F2")
                preco_venda_text.Text = Convert.ToDouble(rs.Fields("preco_venda").Value).ToString("F2")

                Try
                    data_lote_date.Value = Convert.ToDateTime(rs.Fields("data_lote").Value)
                Catch
                    data_lote_date.Value = DateTime.Now
                End Try

                ' CARREGA A FOTO SALVA (se existir)
                Dim caminho As String = rs.Fields("foto_prod").Value & ""

                If Not String.IsNullOrEmpty(caminho) AndAlso IO.File.Exists(caminho) Then
                    Try
                        ' Carrega a foto salva
                        foto_prod_pic.Load(caminho)
                        diretorio = caminho
                    Catch
                        ' Se não conseguir carregar a foto, mostra imagem default
                        CarregarImagemDefault()
                        diretorio = ""
                    End Try
                Else
                    ' Se não tem foto salva, mostra imagem default
                    CarregarImagemDefault()
                    diretorio = ""
                End If

                foto_prod_pic.SizeMode = PictureBoxSizeMode.StretchImage

                ' Calcula a margem após carregar os dados
                Calcular_Margem()
            End If
        Catch ex As Exception
            MsgBox("Erro ao carregar dados: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub Calcular_Margem()
        Try
            Dim custo As Double = 0
            Dim venda As Double = 0

            Dim textoCusto As String = preco_cust_text.Text.Replace(".", ",")
            Dim textoVenda As String = preco_venda_text.Text.Replace(".", ",")

            If Double.TryParse(textoCusto, custo) AndAlso Double.TryParse(textoVenda, venda) Then
                If venda > 0 Then
                    Dim margem As Double = ((venda - custo) / venda) * 100
                    'lbl_margem.Text = FormatNumber(margem, 2)

                    If margem < 0 Then
                        'lbl_margem.ForeColor = Color.Red
                    Else
                        'lbl_margem.ForeColor = Color.Green
                    End If
                Else
                    'lbl_margem.Text = "0,00"
                    'lbl_margem.ForeColor = Color.Black
                End If
            Else
                'lbl_margem.Text = "0,00"
                'lbl_margem.ForeColor = Color.Black
            End If
        Catch ex As Exception
            'lbl_margem.Text = "0,00"
            'lbl_margem.ForeColor = Color.Black
        End Try
    End Sub

    Private Sub preco_cust_text_TextChanged(sender As Object, e As EventArgs) Handles preco_cust_text.TextChanged
        Calcular_Margem()
    End Sub

    Private Sub preco_venda_text_TextChanged(sender As Object, e As EventArgs) Handles preco_venda_text.TextChanged
        Calcular_Margem()
    End Sub

    ' --- BOTÃO GRAVAR ---
    Private Sub bnt_gravar_Click(sender As Object, e As EventArgs) Handles bnt_gravar.Click
        Try
            ' VALIDAÇÕES
            If String.IsNullOrWhiteSpace(desc_produto_text.Text) Then
                MsgBox("Digite a descrição do produto!", MsgBoxStyle.Exclamation)
                desc_produto_text.Focus()
                Exit Sub
            End If

            ' VERIFICAÇÃO DA CONEXÃO
            If db Is Nothing Then
                MsgBox("Inicializando conexão com o banco de dados...", MsgBoxStyle.Information)
                Connecta_banco()

                If db Is Nothing Then
                    MsgBox("Falha crítica: Não foi possível conectar ao banco de dados!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            ' Verifica se a conexão está aberta
            If db.State <> 1 Then
                MsgBox("Reconectando ao banco de dados...", MsgBoxStyle.Information)
                Try
                    db.Open()
                Catch
                    Connecta_banco()
                End Try

                If db.State <> 1 Then
                    MsgBox("Não foi possível reconectar ao banco de dados!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            ' PREPARA OS DADOS
            Dim data_mysql As String = data_lote_date.Value.ToString("yyyy-MM-dd")

            ' Converte valores decimais
            Dim v_custo As String = preco_cust_text.Text.Trim().Replace(",", ".")
            Dim v_venda As String = preco_venda_text.Text.Trim().Replace(",", ".")

            ' Remove caracteres inválidos
            v_custo = Regex.Replace(v_custo, "[^0-9.-]", "")
            v_venda = Regex.Replace(v_venda, "[^0-9.-]", "")

            ' Valores padrão
            If String.IsNullOrEmpty(v_custo) Then v_custo = "0"
            If String.IsNullOrEmpty(v_venda) Then v_venda = "0"

            ' Escapa aspas simples
            Dim desc As String = desc_produto_text.Text.Replace("'", "''")
            Dim qnt As String = qnt_dis_prod_text.Text.Replace("'", "''")
            Dim marca As String = marca_produto_cmd.Text.Replace("'", "''")
            Dim categoria As String = categoria_produto_cmd.Text.Replace("'", "''")

            ' IMPORTANTE: Só salva a foto se o usuário selecionou uma imagem
            Dim foto As String = ""
            If Not String.IsNullOrEmpty(diretorio) Then
                ' Verifica se o arquivo existe e não é uma imagem gerada
                If IO.File.Exists(diretorio) Then
                    foto = diretorio.Replace("\", "\\")
                End If
            End If

            ' MONTA A QUERY
            If id_editar = -1 Then
                ' INSERT - para novo cadastro
                sql = $"INSERT INTO tb_cadastro_prod (desc_produto, qnt_dis_prod, data_lote, preco_custo, preco_venda, marca_produto, categoria_prod, foto_prod) " &
                      $"VALUES ('{desc}', '{qnt}', '{data_mysql}', '{v_custo}', '{v_venda}', '{marca}', '{categoria}', '{foto}')"
            Else
                ' UPDATE - para edição
                sql = $"UPDATE tb_cadastro_prod SET " &
                      $"desc_produto='{desc}', " &
                      $"qnt_dis_prod='{qnt}', " &
                      $"data_lote='{data_mysql}', " &
                      $"preco_custo='{v_custo}', " &
                      $"preco_venda='{v_venda}', " &
                      $"marca_produto='{marca}', " &
                      $"categoria_prod='{categoria}', " &
                      $"foto_prod='{foto}' " &
                      $"WHERE id_produto = {id_editar}"
            End If

            ' EXECUTA
            db.Execute(sql)

            MsgBox("Produto salvo com sucesso!", MsgBoxStyle.Information)

            ' Verifica se o Consultar já está aberto
            Dim consultaAberta As Boolean = False
            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is Consultar AndAlso frm.Visible Then
                    consultaAberta = True
                    Exit For
                End If
            Next

            ' Se não estiver aberta, abre a tela de Consulta Geral
            If Not consultaAberta Then
                Consultar.Show()
            End If

            ' Limpa e fecha
            id_editar = -1
            Me.Close()

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message & vbCrLf & vbCrLf & "SQL: " & sql, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub foto_prod_pic_Click(sender As Object, e As EventArgs) Handles foto_prod_pic.Click
        Try
            Using ofd As New OpenFileDialog()
                ofd.Title = "Selecione uma Foto"
                ofd.Filter = "Imagens|*.jpg;*.png;*.jpeg;*.bmp"
                ofd.FilterIndex = 1

                If ofd.ShowDialog() = DialogResult.OK Then
                    diretorio = ofd.FileName
                    foto_prod_pic.Load(diretorio)
                    foto_prod_pic.SizeMode = PictureBoxSizeMode.StretchImage
                End If
            End Using
        Catch ex As Exception
            MsgBox("Erro ao carregar imagem: " & ex.Message, MsgBoxStyle.Exclamation)
            ' Se der erro, volta para imagem default mas NÃO salva o diretorio
            CarregarImagemDefault()
            diretorio = ""
        End Try
    End Sub

    ' Evento para garantir limpeza ao fechar o formulário
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        id_editar = -1
        ' Se o formulário foi aberto usando Show() em vez de ShowDialog(), e não tem outro form principal ativo, o sistema deve fechar

        Dim temAberto As Boolean = False
        For Each frm As Form In Application.OpenForms
            If frm IsNot Me AndAlso frm.Visible Then
                temAberto = True
                Exit For
            End If
        Next

        If Not Me.Modal AndAlso Not temAberto Then
            Application.Exit()
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs)

    End Sub
End Class