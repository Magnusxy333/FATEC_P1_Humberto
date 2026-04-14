Imports System.Data

Module Module1
    ' Variáveis públicas
    Public diretorio As String = ""
    Public db As ADODB.Connection = Nothing  ' Inicializa como Nothing
    Public rs As ADODB.Recordset = Nothing
    Public sql As String = ""
    Public cont As Integer = 0
    Public id_editar As Integer = -1

    Sub Connecta_banco()
        Try
            ' Cria nova conexão se necessário
            If db Is Nothing Then
                db = New ADODB.Connection()
            End If

            ' Fecha se estiver aberta
            If db.State = 1 Then
                db.Close()
            End If

            ' Tenta conectar - AJUSTE A SENHA SE NECESSÁRIO
            db.Open("Provider=SQLOLEDB;Data Source=LAB5-09;Initial Catalog=produtos_db;Integrated Security=SSPI;")

            ' Se chegou aqui, conectou!
            ' MsgBox("Conectado com sucesso!")

        Catch ex As Exception
            ' Tenta com driver alternativo
            Try
                db.Open("Provider=SQLOLEDB;Data Source=LAB5-09;Initial Catalog=produtos_db;Integrated Security=SSPI;")
            Catch ex2 As Exception
                MsgBox("ERRO AO CONECTAR: " & ex2.Message & vbCrLf &
                       "Verifique se o MySQL está rodando e as credenciais estão corretas!",
                       MsgBoxStyle.Critical)
                db = Nothing
            End Try
        End Try
    End Sub

    Sub Carregar_dados()
        Try
            If db Is Nothing OrElse db.State <> 1 Then
                Connecta_banco()
            End If

            sql = "SELECT id_produto, desc_produto, categoria_prod, marca_produto, qnt_dis_prod, preco_venda, preco_custo FROM tb_cadastro_prod ORDER BY desc_produto ASC"
            rs = db.Execute(sql)

            With Consultar.dgv_dados
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
            MsgBox("Erro ao Carregar dados: " & ex.Message)
        End Try
    End Sub

    Sub Carregar_tipo()
        Try
            Consultar.cmd_campo.Items.Clear()
            With Consultar.cmd_campo.Items
                .Add("DESCRIÇÃO")
                .Add("CATEGORIA")
                .Add("MARCA")
            End With
            Consultar.cmd_campo.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Erro ao Carregar tipos: " & ex.Message)
        End Try
    End Sub
End Module