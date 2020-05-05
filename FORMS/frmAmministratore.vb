Public Class FrmAmministratore
    Private Sub cmdInsDett_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmdModDett_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmdEliminaRiga_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FrmAmministratore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmdConferma.ThemeName = "buttonBLU"
            cmdAnnulla.ThemeName = "buttonDFT"
            cmdOkSearchLoc.ThemeName = "buttonDFT"

        Catch ex As Exception

        End Try
    End Sub
End Class
