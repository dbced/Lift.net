Public Class FrmContratto
    Private Sub FrmContratto_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            cmdOkSearchCli.ThemeName = "buttonDFT"
            cmdOkSearchCliGes.ThemeName = "buttonDFT"
            cmdConferma.ThemeName = "buttonBLU"
            cmdAnnulla.ThemeName = "buttonDFT"

        Catch ex As Exception

        End Try

    End Sub
End Class
