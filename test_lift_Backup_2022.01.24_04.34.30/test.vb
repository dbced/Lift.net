Imports LiftCore

Public Class Test
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frm As New FrmAccordo("2", "MODIFICA")
        frm.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim frm As New FrmAccordo("", "NUOVO")
        frm.ShowDialog()
    End Sub

    Private Sub Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
