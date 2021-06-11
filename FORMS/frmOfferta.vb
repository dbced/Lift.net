Imports System.IO
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class FrmOfferta
    Private Centro As String
    Private Soc As String
    Private Anno As Integer
    Private Id As Integer
    Private Progressivo As Integer
    Private Codimp As String

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
        'Me.RichiediCodici()

        ' WireEvents()
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

    Private Sub SelezionaValoreCombo(combo As RadDropDownList, valore As String)
        For Each el As RadListDataItem In combo.Items

        Next
    End Sub

    Private Async Sub RichiediOfferta(par)
        Dim off As Threading.Tasks.Task(Of Offerta)
        off = ws.getOffertaDettagliata(par)
        Await off
        Offerta = off.Result
        If Offerta.Err Is Nothing Then
            RichiediCodici()
            Me.VisualizzaOfferta()
            grdVociGrafiche.Refresh()

        Else
            MessageBox.Show($"Dettaglio Errore: {vbCrLf}Messaggio: {Offerta.Err.Messaggio} {vbCrLf}StackTrace: {Offerta.Err.Stack}", "Errore Offerta")
            Me.Close()
        End If
    End Sub

    Private Sub CaricaDati()
        CaricaCombo("PAG", cmbModPagamento)
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
        If e.CurrentRow.Index >= 0 Then
            For Each dett In Offerta.Dettaglio
                If dett.F1ORD = e.CurrentRow.Cells("F1ORD").Value Then
                    dettaglio = dett
                End If
            Next
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
            txmValoreMaggiorazione.Mask = "c2"
            txmValoreMaggiorazione.Value = x
        Else
            Dim x As Integer = txmValoreMaggiorazione.Value / 100
            txmValoreMaggiorazione.Mask = "p0"
            txmValoreMaggiorazione.Value = x
        End If
    End Sub

    Private Sub tsTipoVariazione_ValueChanged(sender As Object, e As EventArgs) Handles tsTipoVariazione.ValueChanged
        If tsTipoVariazione.Value Then
            txmValoreVariazione.Mask = "c2"
        Else
            txmValoreVariazione.Mask = "p0"
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
        'Offerta.Dettaglio.Remove()


        'grdVoci.Rows.
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

    End Sub

    Private Async Sub AnteprimaOfferta(par)
        Dim pdf As Threading.Tasks.Task(Of File)
        pdf = ws.getPrevOfferta(Offerta)
        Await pdf
        Dim x As File = pdf.Result
        If Offerta.Err Is Nothing Then
            'Mostra File
        Else
            MessageBox.Show($"Dettaglio Errore: {vbCrLf}Messaggio: {Offerta.Err.Messaggio} {vbCrLf}StackTrace: {Offerta.Err.Stack}", "Errore Offerta")
            Me.Close()
        End If
    End Sub
End Class
