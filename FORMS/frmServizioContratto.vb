Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class FrmServizioContratto

    Private ws As New webServices

    Dim statoCaricaTipoFatturazione As Boolean
    Dim statoCaricaRivalutazione As Boolean
    Dim statoCaricaFreqFatt As Boolean


    Private idContratto As String
    Private idServizio As String

    Dim azione As String
    Dim formInCaricamento As Boolean
    Private schedaServizio As elencoServiziContratto

    Public Sub New(codContratto As String, codServizio As String, ByVal inAzione As String, Optional ByVal ElencoCentri As String = "", Optional ByVal inUser As String = "", Optional ByVal inRuolo As String = "", Optional ByVal inUserAS As String = "", Optional ByVal modifica As Boolean = True, Optional ByVal testo As String = "")
        InitializeComponent()
        'WireEvents()

        idContratto = codContratto
        idServizio = codServizio

        azione = inAzione

        'ruolo = inRuolo
        'user = inUser
        'userAS = inUserAS
        'gElencoCentri = ElencoCentri
    End Sub
    Private Sub FrmServizioContratto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonDFT.tssp")
        ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonBLU.tssp")
        ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonRED.tssp")

        cmdConferma.ThemeName = "buttonBLU"
        cmdAnnulla.ThemeName = "buttonDFT"
        cmdOkSearchIva.ThemeName = "buttonDFT"
        cmdOkSearchSer.ThemeName = "buttonDFT"

        wb.AssociatedControl = Me
        wb.StartWaiting()
        wb.Visible = True

        t1.Enabled = True
        formInCaricamento = True

    End Sub

    Private Sub FrmImpianto_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            'Me.gestisci_campi_form()

            If azione = "NUOVO" Then
                'Me.azzera_campi_form()
                Me.carica_dati_liste()
            Else
                Me.async_carica_servizio_contratto(idContratto, idServizio)
            End If

        Catch ex As Exception
            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False
        End Try

    End Sub
    Private Sub carica_dati_liste()
        Try
            Dim valRivalut As String = ""
            Dim valFreqFatt As String = ""

            If azione = "MODIFICA" Then
                valRivalut = schedaServizio.C1CTR
                valFreqFatt = schedaServizio.C1FFA
            End If

            carica_combo_tabelle("TRC", cmbRivalut, valRivalut)
            carica_combo_tabelle("FREQ", cmbFreqFatt, valFreqFatt)

        Catch ex As Exception

        End Try
    End Sub
    Private Async Sub carica_combo_tabelle(codTab As String, combo As RadDropDownList, valoreIniziale As String)
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella(codTab, "")
            Await elementi

            combo.DataSource = elementi.Result
            combo.DisplayMember = "desElem"
            combo.ValueMember = "codElem"
            combo.SelectedIndex = -1

            If azione = "MODIFICA" Then
                combo.SelectedValue = valoreIniziale
            End If

            Select Case codTab

                Case "TRC"
                    statoCaricaRivalutazione = True
                Case "FREQ"
                    statoCaricaFreqFatt = True

            End Select

        Catch ex As Exception
            statoCaricaTipoFatturazione = True
            statoCaricaRivalutazione = True
            statoCaricaFreqFatt = True
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub t1_Tick(sender As Object, e As EventArgs) Handles t1.Tick
        Try
            If statoCaricaRivalutazione = True And
                statoCaricaFreqFatt = True Then

                wb.AssociatedControl = Nothing
                wb.StopWaiting()
                wb.Visible = False

                t1.Enabled = False
                formInCaricamento = False

            End If

        Catch ex As Exception

            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False
            t1.Enabled = False
        End Try
    End Sub

    Private Async Sub async_carica_servizio_contratto(codContratto As String, codServizio As String)

        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoServiziContratto))
            elementi = ws.getElencoServiziContratto(codContratto, codServizio)
            Await elementi

            schedaServizio = elementi.Result.Item(0)
            carica_dati_form()
            Me.carica_dati_liste()

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub

    Private Sub carica_dati_form()
        Try
            txtCanone.Text = schedaServizio.C1CAN
            txtCodSer.Text = schedaServizio.C1SER
            'txtDesSer.Text = dati.RASCL
            txtIva.Text = schedaServizio.C1CIV

            If schedaServizio.C1TFA = "A" Then
                chkFatAnticipata.IsChecked = True
            Else
                chkFattPostecipata.IsChecked = True
            End If

            Me.carica_elemento_tabella("IVA", schedaServizio.C1CIV)
            Me.carica_elemento_tabella("SER", schedaServizio.C1SER)
        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub carica_elemento_tabella(codTab As String, valoreIniziale As String)
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella(codTab, valoreIniziale)
            Await elementi

            Dim valori() As parmTabelle = elementi.Result


            Select Case codTab
                Case "IVA"
                    If valori.Count > 0 Then
                        txtIva.Text = valori(0).codElem
                        txtDesIva.Text = valori(0).desElem
                    Else
                        txtIva.Text = ""
                        txtDesIva.Text = ""
                    End If

                Case "SER"
                    If valori.Count > 0 Then
                        txtDesSer.Text = valori(0).desElem
                    Else
                        txtDesSer.Text = ""
                    End If
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub cmdOkSearchIva_Click(sender As Object, e As EventArgs) Handles cmdOkSearchIva.Click
        Try
            Dim frm As New FrmRicercaTabelle("IVA")
            frm.CodiceOut = ""
            frm.DescrOut = ""
            frm.ShowDialog()
            txtIva.Text = frm.CodiceOut
            txtDesIva.Text = frm.DescrOut
        Catch ex As Exception
            txtIva.Text = ""
            txtDesIva.Text = ""
        End Try
    End Sub

    Private Sub cmdOkSearchSer_Click(sender As Object, e As EventArgs) Handles cmdOkSearchSer.Click
        Try
            Dim frm As New FrmRicercaTabelle("SER")
            frm.CodiceOut = ""
            frm.DescrOut = ""
            frm.ShowDialog()
            txtCodSer.Text = frm.CodiceOut
            txtDesSer.Text = frm.DescrOut
        Catch ex As Exception
            txtCodSer.Text = ""
            txtDesSer.Text = ""
        End Try
    End Sub
End Class
