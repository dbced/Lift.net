Imports System.ComponentModel
Imports System.Globalization
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class FrmExpGantt
    Public sAnno As String
    Public sMese As String
    Public sSett As String

    Public visiteChiuse As Boolean

    Private ut As New utility

    Public Sub New(ByVal anno As String, ByVal mese As String, tpModal As String)
        InitializeComponent()
        sAnno = anno
        sMese = mese

        If tpModal = "GENERA" Then
            chkChiuse.Visible = False
            cmbSettimana.Visible = False
            cmdConferma.Text = "Conferma"
            lblSett.Visible = False
        End If

    End Sub

    Private Sub FrmExpGantt_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonDFT.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonBLU.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonRED.tssp")

            cmdAnnulla.ThemeName = "buttonDFT"
            cmdConferma.ThemeName = "buttonRED"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdAnnulla_Click(sender As Object, e As EventArgs) Handles cmdAnnulla.Click
        sAnno = ""
        sMese = ""
        sSett = ""

        Me.Close()
    End Sub

    Private Sub cmdConferma_Click(sender As Object, e As EventArgs) Handles cmdConferma.Click
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        If cmbAnno.SelectedIndex < 0 Then
            Telerik.WinControls.RadMessageBox.Show(Me, "selezionare l'anno di riferimento.", "Errre", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            cmbAnno.Focus()
            Exit Sub
        End If

        If cmbMese.SelectedIndex < 0 Then
            Telerik.WinControls.RadMessageBox.Show(Me, "Selezionare il mese di riferimento.", "Errre", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            cmbMese.Focus()
            Exit Sub
        End If

        sMese = cmbMese.SelectedValue
        sAnno = cmbAnno.Text

        If cmbSettimana.SelectedIndex >= 0 Then
            sSett = cmbSettimana.SelectedValue
        End If

        visiteChiuse = chkChiuse.Checked
        Me.Close()
    End Sub

    Private Sub carica_mesi()
        Dim sMese As String
        Try
            cmbMese.Items.Clear()
            For i = 1 To 12
                Dim dataItem As New RadListDataItem()

                Select Case i
                    Case 1
                        sMese = "GENNAIO"
                    Case 2
                        sMese = "FEBBRAIO"
                    Case 3
                        sMese = "MARZO"
                    Case 4
                        sMese = "APRILE"
                    Case 5
                        sMese = "MAGGIO"
                    Case 6
                        sMese = "GIUGNO"
                    Case 7
                        sMese = "LUGLIO"
                    Case 8
                        sMese = "AGOSTO"
                    Case 9
                        sMese = "SETTEMBRE"
                    Case 10
                        sMese = "OTTOBRE"
                    Case 11
                        sMese = "NOVEMBRE"
                    Case 12
                        sMese = "DICEMBRE"
                End Select

                dataItem.Text = sMese
                dataItem.Value = i.ToString
                Me.cmbMese.Items.Add(dataItem)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub carica_settimane(mese As Integer, anno As Integer)
        Try
            cmbSettimana.Items.Clear()
            Dim dataini = "01/" & Format(mese, "00") & "/" & anno
            Dim datafin = DateAdd(DateInterval.Month, 1, CDate(dataini))
            datafin = DateAdd(DateInterval.Day, -1, CDate(datafin))


            Dim weekIni As Integer = ut.GetWeekOfYear(CDate(dataini))
            Dim weekFin As Integer = ut.GetWeekOfYear(CDate(datafin))

            For i = weekIni To weekFin
                Dim dataItem As New RadListDataItem()
                dataItem.Text = "WEEK " & i
                dataItem.Value = i
                Me.cmbSettimana.Items.Add(dataItem)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmExpGantt_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub cmbMese_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles cmbMese.SelectedIndexChanged
        Try
            If Not IsNothing(cmbMese.SelectedItem.Value) Then
                Dim mese As Integer = cmbMese.SelectedItem.Value
                Dim anno As Integer = Val(cmbAnno.Text)
                carica_settimane(mese, anno)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMese_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMese.SelectedValueChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmExpGantt_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Me.carica_mesi()
            cmbMese.SelectedValue = sMese

            cmbAnno.Text = sAnno

            Me.carica_settimane(Val(sMese), Val(sAnno))
        Catch ex As Exception

        End Try
    End Sub
End Class
