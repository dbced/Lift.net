Imports LiftCore
Imports Telerik.WinControls.UI
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FRM As New RadForm
        Dim frmi As New FrmImpiantiElenco(FRM, "*", "ADMIN", "ADMI", "SISINFOMA")
        frmi.Show()
    End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Dim frm As New FrmContratto
    '    frm.ShowDialog()
    'End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim FRM As New RadForm
        Dim frmi As New FrmAmministratoriElenco(FRM, "*", "ADMIN", "ADMI", "SISINFOMA")
        frmi.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim FRM As New RadForm
        Dim frmi As New frmSchedulerManBeta("", "*", "ADMIN", "ADMI", "SISINFOMA")
        frmi.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim FRM As New RadForm
        Dim frmi As New FrmContrattiElenco(FRM, "*", "ADMIN", "ADMI", "SISINFOMA")
        frmi.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frm As New FrmAccordo("2", "MODIFICA")
        frm.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim frm As New FrmAccordo("", "NUOVO")
        frm.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim frm As New FrmChiamate("")
        frm.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim FRM As New RadForm
        Dim frmi As New FrmOffertaElenco(FRM, "*", "ADMIN", "ADMI", "SISINFOMA")
        frmi.Show()

    End Sub
End Class
