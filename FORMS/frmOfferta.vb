Imports System.IO
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.PdfViewer
Imports Telerik.WinControls.Data
Imports System.ComponentModel

Public Class FrmOfferta
    Private Centro As String
    Private Soc As String
    Private Anno As Integer
    Private Id As Integer
    Private Progressivo As Integer
    Private Codimp As String
    Private Diz As Dizionario
    Private ws As New webServices
    Private Offerta As Offerta

    Public Sub New(parms As parmsOfferte)
        InitializeComponent()
        Centro = parms.parmCen.Last.Centro
        Soc = parms.parmSoc.Last.societa
        Anno = parms.parmAnnoOff
        Id = parms.parmIdOfferta
        Me.CaricaDati()
        Me.RichiediOfferta(parms)
    End Sub

    Private Sub VisualizzaOfferta()
        If Offerta IsNot Nothing Then
            With Offerta
                lbId.Text = $"Id : { .B1IDOFF }"
                lbNumero.Text = $"Numero : { .B1PROGR}/{ .B1AAOFF}"
                'lbAnno.Text = $"Anno : { .B1AAOFF }"
                lbData.Text = $"Data : { .B1DTOFF.ToShortDateString  }"
                lbBuono.Text = $"Buono : { .B1IDBUO }"
                'lbStato.Text = $"Stato : { .B1STATOFF }"
                txtCodImp.Text = $"{ .B1CODIMP.ToString.PadLeft(7, "0")}"
                txtCodOrigine.Text = $"{ .B1CODORIG}"
                txtCodIva.Text = $"{ .B1CODIVA}"
                txtCodCommessa.Text = $"{ .B1CODCOMM}"
                txtCodSocEsec.Text = $"{ .B1SOCESEC }"
                txtAccontoValore.Text = $"{ .B1ANTICVAL}"
                txtAccontoPercentuale.Text = $"{ .B1ANTICPER }"
                txtTotaleImponibile.Text = $"{ .B1TOTDOC }"
                'txtCodiceCliente.Text = $"{ .Cliente.CDCLI }"
                'txtCliente.Text = $"{ .Cliente.RASCL }"
                'txtTipManutenzione.Text = $"{ .Contratto.CTTPM }"
                txtCodAge.Text = $"{ .B1CODAGE}"
                txtCodiceCtr.Text = $"{ .Contratto.CTNRC}"
                txtCodiceCliente.Text = $"{ .Cliente.CDCLI}"
                txtCliente.Text = $"{Trim(.Cliente.RASCL)}"
                If .Contratto.CTATI = "A" Then
                    Ctati.Text = "Atipico"
                    Ctati.ForeColor = Color.Red
                Else
                    Ctati.Text = "Tipico"
                    Ctati.ForeColor = Color.Green
                End If
                cmbModPagamento.SelectedValue = .B1CODPAG.ToString
                cmbDizionario.SelectedValue = .B1CODDIZ.ToString

                If .B1FLPASSAS Then ckDetrazFiscale.Checked = True
                If .B1FLRITACC Then ckRitAcc.Checked = True
                If .B1FLBENSIG Then ckBenSign.Checked = True
                If .B1FLSUPBAR Then ckBarrArchit.Checked = True
                Select Case .B1FLGSCOFI
                    Case "S"
                        ckScontoFatt.Checked = True
                        txtPercScontoFatt.Value = .B1PERCSCON
                        If .B1FLGONERI = "S" Then
                            ckOneriInclusi.Checked = True
                            txtPercOneri.Value = .B1PERCONER
                        End If
                    Case "I"
                        ckScontoFatt.Checked = True
                        txtPercScontoFatt.Value = .B1PERCSCON
                        ckFinanz.Checked = True
                        txtPercFin.Value = .B1PERCFIN
                        If .B1FLGONERI = "S" Then
                            ckOneriInclusi.Checked = True
                            txtPercOneri.Value = .B1PERCONER
                        End If
                    Case "F"
                        ckFinanz.Checked = True
                        txtPercFin.Value = .B1PERCFIN
                End Select
                grdVoci.DataSource = .Dettaglio
                grdVociGrafiche.DataSource = .Dettaglio
                If .Dettaglio.Count > 0 Then
                    grdVoci.CurrentRow = grdVoci.Rows.First
                    grdVociGrafiche.CurrentRow = grdVociGrafiche.Rows.First
                End If
            End With
        End If
    End Sub

    Private Async Sub CaricaDizionario(cod As String)
        Dim dizzy As Threading.Tasks.Task(Of Dizionario)
        Dim par As New parmsDizionario
        par.parmCodDiz = cod
        dizzy = ws.getDizionario(par)
        Await dizzy
        If Not IsNothing(dizzy.Result) Then
            Diz = dizzy.Result
        End If
    End Sub

    Private Sub SelezionaValoreCombo(combo As RadDropDownList, valore As String)
        For Each el As RadListDataItem In combo.Items
            'TODO
        Next
    End Sub

    Private Async Sub RichiediOfferta(par)
        Dim off As Threading.Tasks.Task(Of Offerta)
        off = ws.getOffertaDettagliata(par)
        Await off
        Offerta = off.Result
        If Offerta.Err Is Nothing Then
            Me.CaricaDizionario(Offerta.B1CODDIZ)
            RichiediCodici()
            Me.VisualizzaOfferta()
            'grdVociGrafiche.Refresh()
            'menu
        Else
            MessageBox.Show($"Dettaglio Errore: {vbCrLf}Messaggio: {Offerta.Err.Messaggio} {vbCrLf}StackTrace: {Offerta.Err.Stack}", "Errore Offerta")
            Me.Close()
        End If
    End Sub

    Private Sub CaricaDati()
        CaricaCombo("PAG", cmbModPagamento)
        CaricaComboFont()
    End Sub

    Private Sub CaricaComboFont()
        Me.cmbSizeFont.Items.Add("08")
        Me.cmbSizeFont.Items.Add("09")
        Me.cmbSizeFont.Items.Add("10")
        Me.cmbSizeFont.Items.Add("11")
        Me.cmbSizeFont.Items.Add("12")
        Me.cmbSizeFont.Items.Add("14")
        Me.cmbSizeFont.Items.Add("16")
        Me.cmbSizeFont.Items.Add("18")
        Me.cmbSizeFont.Items.Add("20")
        Me.cmbSizeFont.Items.Add("22")
        Me.cmbSizeFont.Items.Add("24")
        Me.cmbSizeFont.Items.Add("26")
        Me.cmbSizeFont.Items.Add("28")
        Me.cmbSizeFont.Items.Add("38")
        Me.cmbSizeFont.Items.Add("48")
        Me.cmbSizeFont.Items.Add("72")
    End Sub

    Private Async Sub CaricaCombo(tab As String, combo As RadDropDownList, Optional codice As String = "", Optional filtro As String = "")
        Dim elementi As Threading.Tasks.Task(Of parmTabelle())
        elementi = ws.getDatiTabella(tab, codice, filtro)
        Await elementi
        If Not IsNothing(elementi.Result) Then
            For Each x In elementi.Result
                'combo.Items.Add(New RadListDataItem(x.desElem, x.codElem))
                combo.DropDownListElement.Items.Add(New RadListDataItem(x.desElem, x.codElem)) 'Items.Add(New RadListDataItem(x.desElem, x.codElem))
            Next
        End If
        If combo.Items.Count = 1 Then
            combo.SelectedIndex = 0
        Else
            combo.DisplayMember = "text"
            combo.ValueMember = "value"
        End If
    End Sub

    Private Async Sub richiediTabella(tab As String, codice As String, campo As Object, Optional param As String = "")
        Dim elementi As Threading.Tasks.Task(Of parmTabelle())
        elementi = ws.getDatiTabella(tab)
        Await elementi
        For Each x In elementi.Result
            If x.codElem = codice Then campo.text = $"{param}{x.desElem}"
        Next
    End Sub

    Private Sub RichiediCodici()
        If Offerta IsNot Nothing Then
            richiediTabella("TMA", Offerta.Contratto.CTTPM, txtTipManutenzione)
            richiediTabella("ORG", Offerta.B1CODORIG, txtOrigine)
            richiediTabella("IVA", Offerta.B1CODIVA, txtIva)
            richiediTabella("AGENTI", Offerta.B1CODAGE, txtAgente)
            richiediTabella("RELSOC", Offerta.B1SOCESEC, txtSocEsecutrice)
            richiediTabella("OFFSTATO", Offerta.B1STATOFF, lbStato, "Stato : ")
            CaricaCombo("DIZ", cmbDizionario, Offerta.B1CODDIZ)
        End If
    End Sub

    Private Sub grdVoci_CurrentRowChanged(sender As Object, e As CurrentRowChangedEventArgs) Handles grdVoci.CurrentRowChanged
        Dim dettaglio As New OffertaDett
        If TypeOf e.CurrentRow Is GridViewDataRowInfo AndAlso e.CurrentRow.Index >= 0 Then
            For Each dett In Offerta.Dettaglio
                If dett.F1ORD = e.CurrentRow.Cells("F1ORD").Value Then
                    dettaglio = dett
                End If
            Next
            If e.CurrentRow.Index = 0 Then
                cmdVoceUp.Enabled = False
                cmdVoceDown.Enabled = True
            ElseIf (e.CurrentRow.Index + 1) = grdVoci.Rows.Count Then
                cmdVoceDown.Enabled = False
                cmdVoceUp.Enabled = True
            Else
                cmdVoceDown.Enabled = True
                cmdVoceUp.Enabled = True
            End If
            MostraDettaglio(dettaglio)
        Else
            MostraDettaglio()
        End If

    End Sub

    Private Sub MostraDettaglio(Optional dett As OffertaDett = Nothing)
        If dett IsNot Nothing Then
            grpDetVoce.Enabled = True
            With dett
                txtDescrizioneBreve.Text = .F1DESCRBRV
                txtDescrizioneCompleta.Text = .F1DESCR
                If .F1TPMAGG.ToUpper = "P" Then
                    tsTipoMaggiorazione.Value = False
                    txmValoreMaggiorazione.Value = .F1MAGGIOR / 100
                ElseIf .F1TPMAGG.ToUpper = "I" Then
                    tsTipoMaggiorazione.Value = True
                    txmValoreMaggiorazione.Value = .F1MAGGIOR
                End If
                tsStampaQuantita.Value = .F1FLSTQTA
                txtQuantita.Text = .F1QTA
                txtUnitaMisura.Text = .F1UNMIS
                If .F1VARSGN = "+" Then
                    tsSegnoVariazione.Value = True
                ElseIf .F1VARSGN = "-" Then
                    tsSegnoVariazione.Value = False
                End If
                If .F1VARTIPO.ToUpper.Substring(0, 1) = "P" Then
                    tsTipoVariazione.Value = False
                ElseIf .F1VARTIPO.ToUpper.Substring(0, 1) = "I" Then
                    tsTipoVariazione.Value = True
                End If
                txmValoreVariazione.Value = .F1VARIAZ
                txtOre.Text = .F1NRORE
                txtCostoMat.Value = .F1COSTOMAT
                txtCodIvaVoce.Text = .F1CODIVA
                richiediTabella("IVA", .F1CODIVA, txtIvaVoce)
                txmImponibileVoce.Value = .F1IMPVOC
            End With
        Else
            grpDetVoce.Enabled = False
        End If
    End Sub

    Private Sub FrmOfferta_Load(sender As Object, e As EventArgs) Handles Me.Load
        CommandBarStripElement1.OverflowButton.Visibility = ElementVisibility.Hidden
        'CmdBarStripLog1.OverflowButton.Visibility = ElementVisibility.Hidden
    End Sub

    Private Sub tsTipoMaggiorazione_ValueChanged(sender As Object, e As EventArgs) Handles tsTipoMaggiorazione.ValueChanged
        If tsTipoMaggiorazione.Value Then
            Dim x As Integer = txmValoreMaggiorazione.Value * 100
            txmValoreMaggiorazione.Mask = "C2"
            txmValoreMaggiorazione.Value = x
        Else
            Dim x As Integer = txmValoreMaggiorazione.Value / 100
            txmValoreMaggiorazione.Mask = "P0"
            txmValoreMaggiorazione.Value = x
        End If
    End Sub

    Private Sub tsTipoVariazione_ValueChanged(sender As Object, e As EventArgs) Handles tsTipoVariazione.ValueChanged
        If tsTipoVariazione.Value Then
            txmValoreVariazione.Mask = "C2"
        Else
            txmValoreVariazione.Mask = "P0"
        End If
    End Sub

    Private Sub txtboxNum_TextChanged(sender As Object, e As EventArgs) Handles txtCodImp.TextChanged
        Dim el As RadTextBox = sender
        If IsNumeric(el.Text) Then
            el.ForeColor = Color.Black
        Else
            el.ForeColor = Color.Red
        End If
    End Sub

    Private Async Sub Carica_Impianto(codice As String)
        Dim imp As Threading.Tasks.Task(Of List(Of elencoImpianti))
        imp = ws.getListaImpianti(New List(Of societa), New List(Of centri), codice, "")
        Await imp
        If imp.Result.Count <> 1 Then
            MsgBox("Errore durante il recupero dei dati impianto, il codice risulta essere associato a più impianti in anagrafica.")
        Else
            Offerta.Impianto = imp.Result.First
            If Offerta.Err Is Nothing Then
                RichiediCodici()
                Me.VisualizzaOfferta()
            Else
                MessageBox.Show($"Dettaglio Errore: {vbCrLf}Messaggio: {Offerta.Err.Messaggio} {vbCrLf}StackTrace: {Offerta.Err.Stack}", "Errore Offerta")
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtboxNum_LostFocus(sender As Object, e As EventArgs) Handles txtCodImp.LostFocus
        Dim el As RadTextBox = sender
        If el.ForeColor = Color.Black Or el.Text = "" Then
            Carica_Impianto(el.Text)
        Else
            MsgBox("Inserire un valore corretto")
            el.Focus()
        End If
    End Sub

    Private Sub EliminaVoce_Click(sender As Object, e As EventArgs) Handles EliminaVoce.Click
        cmdAnnullaVoce.Visible = False
        cmdConfermaVoce.Visible = False
        If TypeOf grdVoci.CurrentRow Is GridViewDataRowInfo AndAlso grdVoci.CurrentRow.Index >= 0 Then
            Dim offdet As OffertaDett = grdVoci.SelectedRows.First.DataBoundItem
            If Not IsNothing(offdet.Operazione) Then
                offdet.Operazione = "D"
                MsgBox("Voce Eliminata")
            End If
        End If
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

    End Sub

    Private Async Sub AnteprimaOfferta()
        Dim pdf As Threading.Tasks.Task(Of String)
        pdf = ws.getPrevOfferta(Offerta)
        Await pdf
        Dim x As String = pdf.Result
        Dim tempfile As String = Path.GetTempPath + "OffPreview.pdf"
        If Offerta.Err Is Nothing Then
            Dim tool As New utility
            tool.DecodeFile64_chilkat(x, tempfile)
            Try
                Dim view As New frmPDFPreview(tempfile)
                view.ShowDialog()
            Catch e As Exception
                Debug.Print(e.Message)
            End Try
        Else
            MessageBox.Show($"Dettaglio Errore: {vbCrLf}Messaggio: {Offerta.Err.Messaggio} {vbCrLf}StackTrace: {Offerta.Err.Stack}", "Errore Offerta")
            Me.Close()
        End If
    End Sub

    Private Sub cmdShowPreview_Click(sender As Object, e As EventArgs) Handles cmdShowPreview.Click
        AnteprimaOfferta()
    End Sub

    Private Sub cmdAnnullaVoce_Click(sender As Object, e As EventArgs) Handles cmdAnnullaVoce.Click
        Dim dettaglio As New OffertaDett
        If grdVoci.CurrentRow.Index >= 0 Then
            For Each dett In Offerta.Dettaglio
                If dett.F1IDRIGA = grdVoci.CurrentRow.Cells("F1IDRIGA").Value Then
                    dettaglio = dett
                End If
            Next
            MostraDettaglio(dettaglio)
        Else
            MostraDettaglio()
        End If
    End Sub

    Private Sub cmdConfermaVoce_Click(sender As Object, e As EventArgs) Handles cmdConfermaVoce.Click
        Dim offdet As OffertaDett = grdVoci.SelectedRows.First.DataBoundItem
        offdet.Operazione = "U"
        SalvaDettaglio(offdet)
        grdVoci.MasterTemplate.Refresh()
    End Sub

    Public Sub SalvaDettaglio(dett As OffertaDett)
        With dett
            .F1DESCRBRV = txtDescrizioneBreve.Text
            .F1DESCR = txtDescrizioneCompleta.Text
            If tsTipoMaggiorazione.Value Then
                .F1TPMAGG = "I"
                .F1MAGGIOR = txmValoreMaggiorazione.Value
            Else
                .F1TPMAGG = "P"
                .F1MAGGIOR = txmValoreMaggiorazione.Value * 100
            End If
            .F1FLSTQTA = tsStampaQuantita.Value
            .F1QTA = txtQuantita.Text
            .F1UNMIS = txtUnitaMisura.Text

            If tsSegnoVariazione.Value Then
                .F1VARSGN = "+"
            Else
                .F1VARSGN = "-"
            End If

            If tsTipoVariazione.Value Then
                .F1VARTIPO = "I"
            Else
                .F1VARTIPO = "P"
            End If

            .F1VARIAZ = txmValoreVariazione.Value
            .F1NRORE = txtOre.Text
            .F1COSTOMAT = txtCostoMat.Value
            .F1CODIVA = txtCodIvaVoce.Text
            .F1IMPVOC = txmImponibileVoce.Value
            .F1CODIVA = txtCodIvaVoce.Text
            'richiediTabella("IVA", .F1CODIVA, txtIvaVoce)
        End With
    End Sub

    Private Sub txtCodIvaVoce_Validated(sender As Object, e As EventArgs) Handles txtCodIvaVoce.Validated
        richiediTabella("IVA", txtCodIvaVoce.Text, txtIvaVoce)
    End Sub

    Private Sub cmdInserisciVoce_Click(sender As Object, e As EventArgs) Handles cmdInserisciVoce.Click
        Dim sin, voc, sott As String
        Dim x As New FrmDizionario(Diz)
        x.StartPosition = FormStartPosition.CenterScreen
        x.ShowDialog()
        sin = x.txtSin.Text
        voc = x.txtVoc.Text
        sott = x.txtSot.Text
        x.Dispose()
    End Sub

    Private Sub cmdCaricaTabelleIva_Click(sender As Object, e As EventArgs) Handles cmdCaricaTabelleIva.Click
        Try
            Dim frm As New FrmRicercaTabelle("IVA")
            frm.CodiceOut = ""
            frm.DescrOut = ""
            frm.ShowDialog()
            txtCodIva.Text = frm.CodiceOut
            txtIva.Text = frm.DescrOut
        Catch ex As Exception
            txtCodIva.Text = ""
            txtIva.Text = ""
        End Try
    End Sub

    Private Sub cmdModificaVoce_Click(sender As Object, e As EventArgs) Handles cmdModificaVoce.Click
        cmdAnnullaVoce.Visible = True
        cmdConfermaVoce.Visible = True
        Dim offdet As OffertaDett = grdVoci.SelectedRows.First.DataBoundItem
        If offdet.Operazione = "D" Then
            MsgBox("Voce Eliminata")
        End If
    End Sub

    Private Sub grdVoci_ViewRowFormatting(sender As Object, e As RowFormattingEventArgs) Handles grdVoci.ViewRowFormatting

        If TypeOf e.RowElement.RowInfo Is GridViewDataRowInfo AndAlso e.RowElement.RowInfo.Index >= 0 Then
            Select Case e.RowElement.RowInfo.Cells("Operazione").Value
                Case "U"
                    e.RowElement.BackColor = Color.LightYellow
                    e.RowElement.Font = New Font(e.RowElement.Font, Font.Style.Regular)
                Case "D"
                    e.RowElement.BackColor = Color.White
                    e.RowElement.Font = New Font(e.RowElement.Font, Font.Style.Strikeout)
                Case Else
                    e.RowElement.BackColor = Color.White
                    e.RowElement.Font = New Font(e.RowElement.Font, Font.Style.Regular)
            End Select
        End If
    End Sub

    Private Sub cmdVoceUp_Click(sender As Object, e As EventArgs) Handles cmdVoceUp.Click
        Dim dett, det_prec As OffertaDett
        dett = grdVoci.CurrentRow.DataBoundItem
        det_prec = grdVoci.Rows(grdVoci.CurrentRow.Index - 1).DataBoundItem
        Dim temp As Integer
        temp = dett.F1ORD
        dett.F1ORD = det_prec.F1ORD
        det_prec.F1ORD = dett.F1ORD
        dett.Operazione = "U"
        det_prec.Operazione = "U"
        grdVoci.MasterTemplate.Refresh()
    End Sub

    Private Sub cmdVoceDown_Click(sender As Object, e As EventArgs) Handles cmdVoceDown.Click
        Dim dett, det_suc As OffertaDett
        dett = grdVoci.CurrentRow.DataBoundItem
        det_suc = grdVoci.Rows(grdVoci.CurrentRow.Index + 1).DataBoundItem
        Dim temp As Integer
        temp = dett.F1ORD
        dett.F1ORD = det_suc.F1ORD
        det_suc.F1ORD = dett.F1ORD
        dett.Operazione = "U"
        det_suc.Operazione = "U"
        grdVoci.MasterTemplate.Refresh()
    End Sub
End Class
