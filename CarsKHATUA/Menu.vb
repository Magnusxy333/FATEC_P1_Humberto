Public Class Menu
    ' BOTÃO: Cadastramento
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1SDA.Click
        Cadastro.Show() ' Abre a tela de cadastro
        Me.Hide()
    End Sub

    ' BOTÃO: Estoque (Movimentação)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Consultar.Show() ' Abre a tela de listagem
        Me.Hide()
    End Sub

    ' BOTÃO: Consulta de Itens
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Estoque.Show() ' Abre a tela que fizemos com Entrada/Saída
        Me.Hide()
    End Sub

    ' Adicionado para fechar todo o sistema quando o Menu for fechado
    Private Sub Menu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Vendas.Show() ' Abre a tela que fizemos com Entrada/Saída
        Me.Hide()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class