Imports System.Net
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class FrmContratto
    Private ws As New webServices

    Dim statoCaricaTipoContratti As Boolean
    Dim statoCaricaTipoPrestazione As Boolean
    Dim statoCaricaTipoFatturazione As Boolean
    Dim statoCaricaRivalutazione As Boolean
    Dim statoCaricaTipoManutenzione As Boolean
    Dim statoCaricaCliente9516 As Boolean
    Dim statoCaricaModPag As Boolean
    Dim statoCaricaFreqFatt As Boolean
    Dim statoCaricaSoc As Boolean
    Dim statoCaricaAgenti As Boolean
    Dim statoTipologiaCliente As Boolean

    Private idContratto As String
    Dim azione As String
    Dim formInCaricamento As Boolean
    Private schedaContratto As Threading.Tasks.Task(Of elencoListaContratti)

    Private strip As RadPageViewStripElement

    Public Sub New(codContratto As String, ByVal inAzione As String, Optional ByVal ElencoCentri As String = "", Optional ByVal inUser As String = "", Optional ByVal inRuolo As String = "", Optional ByVal inUserAS As String = "", Optional ByVal modifica As Boolean = True, Optional ByVal testo As String = "")
        InitializeComponent()
        WireEvents()

        idContratto = codContratto
        azione = inAzione

        'ruolo = inRuolo
        'user = inUser
        'userAS = inUserAS
        'gElencoCentri = ElencoCentri
    End Sub

    Private Sub FrmContratto_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonDFT.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonBLU.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonRED.tssp")

            cmdOkSearchCli.ThemeName = "buttonDFT"
            cmdOkSearchCliGes.ThemeName = "buttonDFT"
            cmdConferma.ThemeName = "buttonBLU"
            cmdAnnulla.ThemeName = "buttonDFT"
            cmdOkSearchIva.ThemeName = "buttonDFT"

            Me.strip = TryCast(Me.RPcontainer.ViewElement, RadPageViewStripElement)
            Me.strip.StripButtons = StripViewButtons.None

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            t1.Enabled = True
            formInCaricamento = True
            Me.crea_griglia_impianti_contratto()
            Me.crea_griglia_servizi_contratto()
            Me.crea_griglia_rate_contratto()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub FrmImpianto_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try

            Me.gestisci_campi_form()

            If azione = "NUOVO" Then
                Me.azzera_campi_form()
                Me.carica_dati_liste()
            Else
                Me.async_carica_scheda_contratto()
            End If

            'AddHandler cmbCategoriaImp.SelectedValueChanged, AddressOf cmbCategoriaImp_SelectedValueChanged

        Catch ex As Exception
            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False
        End Try

    End Sub

    Private Async Sub async_carica_scheda_contratto()
        Try
            'If formInCaricamento = False Then
            '    wb.AssociatedControl = grid
            '    wb.StartWaiting()
            '    wb.Visible = True
            'End If

            txtCodice.ReadOnly = True

            schedaContratto = ws.getSchedaContratto(idContratto)
            Await schedaContratto
            Me.carica_dati_liste()
            carica_dati_form(schedaContratto.Result)

            async_carica_griglia_impianti_contratto(schedaContratto.Result.CTNRC)
            async_carica_griglia_servizi_contratto(schedaContratto.Result.CTNRC)
            async_carica_griglia_rate_contratto(schedaContratto.Result.CTNRC)

            If formInCaricamento = False Then
                wb.AssociatedControl = Nothing
                wb.StopWaiting()
                wb.Visible = False
            End If

        Catch ex As Exception
            If formInCaricamento = False Then
                wb.AssociatedControl = Nothing
                wb.StopWaiting()
                wb.Visible = False
            End If

            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub

    Protected Sub WireEvents()
        AddHandler GridImpianti.ViewCellFormatting, AddressOf grid_ViewCellFormatting
        AddHandler GridImpianti.ViewRowFormatting, AddressOf grid_ViewRowFormatting
        AddHandler GridImpianti.CellFormatting, AddressOf grid_CellFormatting
        AddHandler GridImpianti.ContextMenuOpening, AddressOf grid_ContextMenuOpening
        AddHandler GridImpianti.ValueChanging, AddressOf grid_ValueChanging

        AddHandler gridServizi.ViewCellFormatting, AddressOf grid_ViewCellFormatting
        AddHandler gridServizi.ViewRowFormatting, AddressOf grid_ViewRowFormatting
        AddHandler gridServizi.CellFormatting, AddressOf grid_CellFormatting
        AddHandler gridServizi.ContextMenuOpening, AddressOf grid_ContextMenuOpening
        AddHandler gridServizi.ValueChanging, AddressOf grid_ValueChanging

        AddHandler gridRate.ViewCellFormatting, AddressOf grid_ViewCellFormatting
        AddHandler gridRate.ViewRowFormatting, AddressOf grid_ViewRowFormatting
        AddHandler gridRate.CellFormatting, AddressOf grid_CellFormatting
        AddHandler gridRate.ContextMenuOpening, AddressOf grid_ContextMenuOpening
        AddHandler gridRate.ValueChanging, AddressOf grid_ValueChanging
    End Sub

    Private Sub carica_dati_liste()
        Try
            Dim valTipoContratto As String = ""
            Dim valPrestazione As String = ""
            Dim valTipoFatt As String = ""
            Dim valRivalut As String = ""
            Dim valPianoManut As String = ""
            Dim val9516 As String = ""
            Dim valModPag As String = ""
            Dim valFreqFatt As String = ""
            Dim valSocieta As String = ""
            Dim valCodAge As String = ""
            Dim valCodTipologiaCliente As String = ""

            If azione = "MODIFICA" Then
                valTipoContratto = schedaContratto.Result.CTTCO
                valPrestazione = schedaContratto.Result.CTTPM
                valPianoManut = schedaContratto.Result.CTCPM
                valRivalut = schedaContratto.Result.CTCTR
                val9516 = schedaContratto.Result.CTP95
                valTipoFatt = schedaContratto.Result.CTTFT
                valModPag = schedaContratto.Result.CTCMP
                valFreqFatt = schedaContratto.Result.CTFFA
                valSocieta = schedaContratto.Result.CTSOC
                valCodAge = schedaContratto.Result.CTAGE
                valCodTipologiaCliente = schedaContratto.Result.CTTPC
            End If

            carica_combo_tabelle("SOC", cmbSocieta, valSocieta)
            carica_combo_tabelle("TPC", cmbTipoContratto, valTipoContratto)
            carica_combo_tabelle("TMA", cmbPrestazioni, valPrestazione)
            carica_combo_tabelle("TFA", cmbTipoFatt, valTipoFatt)
            carica_combo_tabelle("TRC", cmbRivalut, valRivalut)
            carica_combo_tabelle("PMA", cmbPianoManut, valPianoManut)
            carica_combo_tabelle("P95", cmb9516, val9516)
            carica_combo_tabelle("PAG", cmbModPag, valModPag)
            carica_combo_tabelle("FREQ", cmbFreqFatt, valFreqFatt)
            carica_combo_tabelle("CVE", cmbTipologiaCliente, valCodTipologiaCliente)

            carica_combo_agenti(valCodAge)

            'carica_combo_enti_ispettivi()
            'carica_combo_enti_collaudatori()
            'carica_combo_costruttori()
            'carica_combo_strade()
            'carica_combo_TipoImpianto()
            'carica_combo_TipoImp()
            'carica_combo_reperibilita()
            'carica_combo_callCenter()
            'carica_liste_elementi_dati_tecnici()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub gestisci_campi_form()
        Try
            Select Case azione
                Case "NUOVO"
                    txtCodice.ReadOnly = True
                    For Each pag As RadPageViewPage In RPcontainer.Pages
                        If pag.TabIndex <> 0 Then
                            pag.Item.Visibility = ElementVisibility.Collapsed
                        End If
                    Next

                Case "MODIFICA"
                    Me.blocca_campi()

                    For Each pag As RadPageViewPage In RPcontainer.Pages
                        'If pag.TabIndex = 4 Then
                        '    pag.Item.Visibility = ElementVisibility.Collapsed
                        'Else
                        pag.Item.Visibility = ElementVisibility.Visible
                        'End If

                    Next
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub blocca_campi()
        Try
            cmbSocieta.ReadOnly = True
            txtCodice.ReadOnly = True
            cmbTipoContratto.ReadOnly = True
            chkRagrServizi.ReadOnly = True
            chkRateAtipico.ReadOnly = True
            chkRinnovoTacito.ReadOnly = True
            chkReperib.ReadOnly = True
            chkAtipico.ReadOnly = True
            chkTipico.ReadOnly = True
            txtCodCliente.ReadOnly = True
            txtCodGestore.ReadOnly = True
            txtDtIniDecor.ReadOnly = True
            txtDtFinDecor.ReadOnly = True
            txtDtIniFatt.ReadOnly = True
            txtDtIniPrestaz.ReadOnly = True
            cmbFreqFatt.ReadOnly = True
            cmbTipoFatt.ReadOnly = True
            cmb9516.ReadOnly = True
            txtIva.ReadOnly = True
            txtCommessa.ReadOnly = True
            chkFatAnticipata.ReadOnly = True
            chkFattPostecipata.ReadOnly = True
            'cmbTipologiaCliente.ReadOnly = True
            cmbPianoManut.ReadOnly = True
            cmbPrestazioni.ReadOnly = True
            txtCanone.ReadOnly = True
            txtDataConvalida.ReadOnly = True
            cmbAgente.ReadOnly = True

            cmdOkSearchCli.Enabled = False
            cmdOkSearchCliGes.Enabled = False
            cmdOkSearchIva.Enabled = False

        Catch ex As Exception

        End Try
    End Sub
    Private Sub carica_dati_form(dati As elencoListaContratti)
        Try
            txtCodice.Text = Format(Val(dati.CTNRC), "0000000")
            txtCodCliente.Text = dati.CTCLI
            'txtIndirizzo.Text = dati.AIIND
            'txtCap.Text = Format(Val(dati.AICAP), "00000")
            'txtCodAmm.Text = dati.AIAMM
            'txtProv.Text = dati.AISPR

            txtDesCli.Text = dati.RASCL
            'txtDesAmm.Text = dati.DESAMM
            'txtlocalita.Text = dati.AILOC

            If dati.CTRIF = "S" Then
                chkRagrImpianti.Checked = True
            Else
                chkRagrImpianti.Checked = False
            End If

            If dati.CTRSF = "S" Then
                chkRagrServizi.Checked = True
            Else
                chkRagrServizi.Checked = False
            End If

            If dati.CTRTA = "S" Then
                chkRinnovoTacito.Checked = True
            Else
                chkRinnovoTacito.Checked = False
            End If

            If dati.CTFCO = "S" Then
                chkConvalida.Checked = True
            Else
                chkConvalida.Checked = False
            End If

            If dati.CTTFA = "A" Then
                chkFatAnticipata.IsChecked = True
            Else
                chkFattPostecipata.IsChecked = True
            End If

            If dati.CTATI = "S" Then
                chkAtipico.IsChecked = True
            Else
                chkTipico.IsChecked = True
            End If

            If dati.CTREP = "S" Then
                chkReperib.IsChecked = True
            Else
                chkReperib.IsChecked = False
            End If

            If dati.CTGRA = "S" Then
                chkRateAtipico.IsChecked = True
            Else
                chkRateAtipico.IsChecked = False
            End If

            txtDataConvalida.Text = dati.CTDTC
            txtDtIniDecor.Text = dati.CTDTD
            txtDtIniPrestaz.Text = dati.CTDTE
            txtDtFinDecor.Text = dati.CTDTS
            txtDtIniFatt.Text = dati.CTDIF
            txtCanone.Text = dati.CTCAAE
            txtCodGestore.Text = dati.CTCLG
            txtModelloCtr.Text = dati.CTMCO
            txtIva.Text = dati.CTCIV
            txtCommessa.Text = dati.CTCOM
            Dim aamm = Format(Val(dati.CTDCO), "0000")
            txtAA.Text = aamm.Substring(0, 2)
            txtMM.Text = aamm.Substring(2, 2)

            Me.carica_elemento_tabella("IVA", dati.CTCIV)

            'async_carica_griglia_asset_impianto()
            'async_carica_griglia_documenti(dati.AICIM, "", dati.AICLI)
            'async_carica_gantt_manutenzioni(dati.AICIM)
            'async_carica_grafico_manutenzioni(dati.AICIM)
            'async_carica_grafico_buoni(dati.AICIM)
            'async_carica_grafico_canoni(dati.AICIM)
            'async_carica_grafico_fatturato(dati.AICIM, "")
            'async_carica_grafico_chiamate(dati.AICIM)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub azzera_campi_form()
        Try
            'txtCodice.Text = ""
            'txtCodCliente.Text = ""
            'txtIndirizzo.Text = ""
            'txtCap.Text = ""
            'txtCodAmm.Text = ""
            'txtDesCli.Text = ""
            'txtDesAmm.Text = ""
            'txtlocalita.Text = ""
            'txtZonaRep.Text = ""
            'txtGestore.Text = ""
            'txtTelesoccorso.Text = ""
            'txtMatricola.Text = ""
            'txtScala.Text = ""
            'txtEdificio.Text = ""
            'txtInterno.Text = ""
            'txtDataNomina.Text = Nothing

            'cmbTecnico.SelectedIndex = -1
            'cmbZonaCentro.SelectedIndex = -1
            'cmbStrada.SelectedIndex = -1
            'cmbCategoriaImp.SelectedIndex = -1
            'cmbTipoContratto.SelectedIndex = -1
            'cmbTipoImp.SelectedIndex = -1
            'cmbReperib.SelectedIndex = -1
            'cmbCallCenter.SelectedIndex = -1
            'cmbEnteColl.SelectedIndex = -1
            'cmbEnteIsp.SelectedIndex = -1
            'cmbCostruttore.SelectedIndex = -1
            'cmbZona.SelectedIndex = -1

            'chkLineaNsCarico.Checked = CheckState.Unchecked
            'chkTag.Checked = CheckState.Unchecked

        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub carica_combo_agenti(codAgente As String)
        Try
            Dim elementi As Threading.Tasks.Task(Of List(Of elencoAgenti))
            elementi = ws.getElencoAgenti(codAgente, "")
            Await elementi

            Me.cmbAgente.DataSource = elementi.Result
            Me.cmbAgente.DisplayMember = "RASCL"
            Me.cmbAgente.ValueMember = "CDAGE"
            Me.cmbAgente.SelectedIndex = -1

            If azione = "MODIFICA" Then
                cmbAgente.SelectedValue = codAgente
            End If

            statoCaricaAgenti = True

        Catch ex As Exception
            statoCaricaAgenti = True
            MsgBox(ex.Message, vbCritical)
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
                Case "TPC"
                    statoCaricaTipoContratti = True
                Case "TMA"
                    statoCaricaTipoPrestazione = True
                Case "TFA"
                    statoCaricaTipoFatturazione = True
                Case "TRC"
                    statoCaricaRivalutazione = True
                Case "PMA"
                    statoCaricaTipoManutenzione = True
                Case "P95"
                    statoCaricaCliente9516 = True
                Case "PAG"
                    statoCaricaModPag = True
                Case "FREQ"
                    statoCaricaFreqFatt = True
                Case "SOC"
                    statoCaricaSoc = True
                Case "CVE"
                    statoTipologiaCliente = True
            End Select

        Catch ex As Exception
            statoCaricaTipoContratti = True
            statoCaricaTipoPrestazione = True
            statoCaricaTipoFatturazione = True
            statoCaricaRivalutazione = True
            statoCaricaTipoManutenzione = True
            statoCaricaCliente9516 = True
            statoCaricaModPag = True
            statoCaricaFreqFatt = True
            statoCaricaSoc = True
            statoTipologiaCliente = True

            MsgBox(ex.Message, vbCritical)
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
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub t1_Tick(sender As Object, e As EventArgs) Handles t1.Tick
        Try
            If statoCaricaTipoContratti = True And
                statoCaricaTipoContratti = True And
                statoCaricaTipoPrestazione = True And
                statoCaricaTipoFatturazione = True And
                statoCaricaRivalutazione = True And
                statoCaricaTipoManutenzione = True And
                statoCaricaCliente9516 = True And
                statoCaricaModPag = True And
                statoCaricaFreqFatt = True And
                statoCaricaSoc = True And statoCaricaAgenti = True And
                statoTipologiaCliente = True Then

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

    Private Sub cmdOkSearchCli_Click(sender As Object, e As EventArgs) Handles cmdOkSearchCli.Click
        Try
            Dim frm As New FrmRicercaTabelle("CLIENTI")
            frm.CodiceOut = ""
            frm.DescrOut = ""
            frm.ShowDialog()
            txtCodCliente.Text = frm.CodiceOut
            txtDesCli.Text = frm.DescrOut
        Catch ex As Exception
            txtCodCliente.Text = ""
            txtDesCli.Text = ""
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

    Private Async Sub async_carica_griglia_impianti_contratto(codContratto As String)

        Try
            If formInCaricamento = False Then
                wb.AssociatedControl = GridImpianti
                wb.StartWaiting()
                wb.Visible = True
            End If

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoImpiantiServiziContratto))
            elementi = ws.getElencoImpiantiContratto(codContratto)
            Await elementi

            carica_griglia_impianti_contratto(elementi.Result)
            If formInCaricamento = False Then
                wb.AssociatedControl = Nothing
                wb.StopWaiting()
                wb.Visible = False
            End If

        Catch ex As Exception
            If formInCaricamento = False Then
                wb.AssociatedControl = Nothing
                wb.StopWaiting()
                wb.Visible = False
            End If

            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub

    Private Async Sub async_carica_griglia_servizi_contratto(codContratto As String)

        Try
            If formInCaricamento = False Then
                wb.AssociatedControl = gridServizi
                wb.StartWaiting()
                wb.Visible = True
            End If

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoServiziContratto))
            elementi = ws.getElencoServiziContratto(codContratto, "")
            Await elementi

            carica_griglia_servizi_contratto(elementi.Result)
            If formInCaricamento = False Then
                wb.AssociatedControl = Nothing
                wb.StopWaiting()
                wb.Visible = False
            End If

        Catch ex As Exception
            If formInCaricamento = False Then
                wb.AssociatedControl = Nothing
                wb.StopWaiting()
                wb.Visible = False
            End If

            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub

    Private Async Sub async_carica_griglia_rate_contratto(codContratto As String)

        Try
            If formInCaricamento = False Then
                wb.AssociatedControl = gridRate
                wb.StartWaiting()
                wb.Visible = True
            End If

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoRateContratto))
            elementi = ws.getRateContratto(codContratto)
            Await elementi

            carica_griglia_rate_contratto(elementi.Result)
            If formInCaricamento = False Then
                wb.AssociatedControl = Nothing
                wb.StopWaiting()
                wb.Visible = False
            End If

        Catch ex As Exception
            If formInCaricamento = False Then
                wb.AssociatedControl = Nothing
                wb.StopWaiting()
                wb.Visible = False
            End If

            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub


    Private Sub carica_griglia_impianti_contratto(dati As List(Of elencoImpiantiServiziContratto))
        Try

            GridImpianti.DataSource = dati
            HeaderText_ColumnGriglia_impianti()
            Me.HeaderText_Column_GrigliaImpianti_width()

            Me.GridImpianti.MasterTemplate.ShowFilteringRow = False

            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
        End Try

    End Sub

    Private Sub carica_griglia_servizi_contratto(dati As List(Of elencoServiziContratto))
        Try

            gridServizi.DataSource = dati
            HeaderText_ColumnGriglia_Servizi()
            Me.HeaderText_Column_GrigliaServizi_width()

            Me.gridServizi.MasterTemplate.ShowFilteringRow = False

            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
        End Try

    End Sub

    Private Sub carica_griglia_rate_contratto(dati As List(Of elencoRateContratto))
        Try

            gridRate.DataSource = dati
            HeaderText_ColumnGriglia_Rate()
            Me.HeaderText_Column_GrigliaRate_width()

            Me.gridRate.MasterTemplate.ShowFilteringRow = False

            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
        End Try

    End Sub

    Private Sub crea_griglia_impianti_contratto()
        Try
            Me.LoadSummaryCanoni()

            Me.GridImpianti.BeginEdit()
            'Me.gridImpianti.EnableFiltering = True
            'Me.gridImpianti.MasterTemplate.ShowHeaderCellButtons = True
            Me.GridImpianti.MasterTemplate.ShowFilteringRow = False
            Me.GridImpianti.AllowAddNewRow = False
            Me.GridImpianti.AutoGenerateColumns = False
            Me.GridImpianti.EnableGrouping = False

            Dim commandColumn As New GridViewTextBoxColumn
            commandColumn.Name = "Img"
            commandColumn.DataType = GetType(String)
            commandColumn.HeaderText = ""
            commandColumn.ReadOnly = True
            commandColumn.Width = 50
            commandColumn.IsPinned = True
            ''----------------------------------------------------------------

            ''checkbox colum -------------------------------------------------
            'Dim checkBoxColumn As New GridViewCheckBoxColumn()
            'checkBoxColumn.DataType = GetType(Integer)
            'checkBoxColumn.Name = "CHECK"
            'checkBoxColumn.FieldName = "CHECK"
            'checkBoxColumn.HeaderText = " "
            'checkBoxColumn.Width = 50
            'checkBoxColumn.IsPinned = True
            'checkBoxColumn.EditMode = EditMode.OnValueChange
            ''checkBoxColumn.Checked = False
            'checkBoxColumn.EnableHeaderCheckBox = True
            ''----------------------------------------------------------------


            Dim colCodImpianto As New GridViewTextBoxColumn
            colCodImpianto.Name = "CDIMP"
            colCodImpianto.DataType = GetType(String)
            colCodImpianto.FieldName = "CDIMP"

            Dim colCodContratto As New GridViewTextBoxColumn
            colCodContratto.Name = "CDNRC"
            colCodContratto.DataType = GetType(String)
            colCodContratto.FieldName = "CDNRC"

            Dim colCDIMCE As New GridViewDecimalColumn
            colCDIMCE.Name = "CDIMCE"
            colCDIMCE.DataType = GetType(Double)
            colCDIMCE.FieldName = "CDIMCE"

            Dim colCDFSO As New GridViewTextBoxColumn
            colCDFSO.Name = "CDFSO"
            colCDFSO.DataType = GetType(String)
            colCDFSO.FieldName = "CDFSO"

            Dim colCDDSO As New GridViewDateTimeColumn
            colCDDSO.Name = "CDDSO"
            colCDDSO.DataType = GetType(Date)
            colCDDSO.FieldName = "CDDSO"

            Dim colCDFEU As New GridViewTextBoxColumn
            colCDFEU.Name = "CDFEU"
            colCDFEU.DataType = GetType(String)
            colCDFEU.FieldName = "CDFEU"

            Dim colCDSER As New GridViewTextBoxColumn
            colCDSER.Name = "CDSER"
            colCDSER.DataType = GetType(String)
            colCDSER.FieldName = "CDSER"

            Dim colCDSES As New GridViewTextBoxColumn
            colCDSES.Name = "CDSES"
            colCDSES.DataType = GetType(String)
            colCDSES.FieldName = "CDSES"

            Dim colCDCTL As New GridViewTextBoxColumn
            colCDCTL.Name = "CDCTL"
            colCDCTL.DataType = GetType(String)
            colCDCTL.FieldName = "CDCTL"

            Dim colCDFAF As New GridViewTextBoxColumn
            colCDFAF.Name = "CDFAF"
            colCDFAF.DataType = GetType(String)
            colCDFAF.FieldName = "CDFAF"

            Dim colCDCOM As New GridViewTextBoxColumn
            colCDCOM.Name = "CDCOM"
            colCDCOM.DataType = GetType(String)
            colCDCOM.FieldName = "CDCOM"

            Dim colCDDCO As New GridViewTextBoxColumn
            colCDDCO.Name = "CDDCO"
            colCDDCO.DataType = GetType(String)
            colCDDCO.FieldName = "CDDCO"

            Dim colCDVOL As New GridViewTextBoxColumn
            colCDVOL.Name = "CDVOL"
            colCDVOL.DataType = GetType(String)
            colCDVOL.FieldName = "CDVOL"

            Dim colDESSER As New GridViewTextBoxColumn
            colDESSER.Name = "DESSER"
            colDESSER.DataType = GetType(String)
            colDESSER.FieldName = "DESSER"

            'gridImpianti.MasterTemplate.Columns.Add(commandColumn)
            'gridImpianti.MasterTemplate.Columns.Add(checkBoxColumn)
            GridImpianti.MasterTemplate.Columns.Add(colCodImpianto)
            GridImpianti.MasterTemplate.Columns.Add(colCDSER)
            GridImpianti.MasterTemplate.Columns.Add(colDESSER)
            GridImpianti.MasterTemplate.Columns.Add(colCDIMCE)
            GridImpianti.MasterTemplate.Columns.Add(colCDSES)
            GridImpianti.MasterTemplate.Columns.Add(colCDCTL)
            GridImpianti.MasterTemplate.Columns.Add(colCDCOM)
            GridImpianti.MasterTemplate.Columns.Add(colCDDCO)
            GridImpianti.MasterTemplate.Columns.Add(colCDVOL)
            GridImpianti.MasterTemplate.Columns.Add(colCDFSO)
            GridImpianti.MasterTemplate.Columns.Add(colCDDSO)
            GridImpianti.MasterTemplate.Columns.Add(colCDFAF)
            GridImpianti.MasterTemplate.Columns.Add(colCodContratto)

            'AddHandler gridImpianti.CommandCellClick, AddressOf grid_CommandCellClick

            GridImpianti.TableElement.SearchHighlightColor = Color.LimeGreen

            'Me.gridImpianti.Columns("Check").AllowFiltering = False
            'Me.gridImpianti.Columns("Mod").AllowFiltering = False

            Me.GridImpianti.EndEdit()

            'gridImpianti.AllowSearchRow = True
            'gridImpianti.MasterView.SummaryRows(0).PinPosition = PinnedRowPosition.Bottom


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Crea griglia impianti")
        End Try
    End Sub

    Private Sub crea_griglia_servizi_contratto()
        Try
            Me.LoadSummaryCanoniServizi()

            Me.gridServizi.BeginEdit()
            'Me.gridservizi.EnableFiltering = True
            'Me.gridservizi.MasterTemplate.ShowHeaderCellButtons = True
            Me.gridServizi.MasterTemplate.ShowFilteringRow = False
            Me.gridServizi.AllowAddNewRow = False
            Me.gridServizi.AutoGenerateColumns = False
            Me.gridServizi.EnableGrouping = False

            Dim commandColumn As New GridViewTextBoxColumn
            commandColumn.Name = "Img"
            commandColumn.DataType = GetType(String)
            commandColumn.HeaderText = ""
            commandColumn.ReadOnly = True
            commandColumn.Width = 50
            commandColumn.IsPinned = True
            ''----------------------------------------------------------------

            ''checkbox colum -------------------------------------------------
            'Dim checkBoxColumn As New GridViewCheckBoxColumn()
            'checkBoxColumn.DataType = GetType(Integer)
            'checkBoxColumn.Name = "CHECK"
            'checkBoxColumn.FieldName = "CHECK"
            'checkBoxColumn.HeaderText = " "
            'checkBoxColumn.Width = 50
            'checkBoxColumn.IsPinned = True
            'checkBoxColumn.EditMode = EditMode.OnValueChange
            ''checkBoxColumn.Checked = False
            'checkBoxColumn.EnableHeaderCheckBox = True
            ''----------------------------------------------------------------

            Dim colCodContratto As New GridViewTextBoxColumn
            colCodContratto.Name = "C1NRC"
            colCodContratto.DataType = GetType(String)
            colCodContratto.FieldName = "C1NRC"

            Dim colCDIMCE As New GridViewDecimalColumn
            colCDIMCE.Name = "C1CAN"
            colCDIMCE.DataType = GetType(Double)
            colCDIMCE.FieldName = "C1CAN"

            Dim colC1CIV As New GridViewTextBoxColumn
            colC1CIV.Name = "C1CIV"
            colC1CIV.DataType = GetType(String)
            colC1CIV.FieldName = "C1CIV"

            Dim colC1TFA As New GridViewTextBoxColumn
            colC1TFA.Name = "C1TFA"
            colC1TFA.DataType = GetType(String)
            colC1TFA.FieldName = "C1TFA"

            Dim colCDSER As New GridViewTextBoxColumn
            colCDSER.Name = "C1SER"
            colCDSER.DataType = GetType(String)
            colCDSER.FieldName = "C1SER"

            Dim colC1FFA As New GridViewTextBoxColumn
            colC1FFA.Name = "C1FFA"
            colC1FFA.DataType = GetType(String)
            colC1FFA.FieldName = "C1FFA"

            Dim colC1CTR As New GridViewTextBoxColumn
            colC1CTR.Name = "C1CTR"
            colC1CTR.DataType = GetType(String)
            colC1CTR.FieldName = "C1CTR"

            Dim colC1CTL As New GridViewTextBoxColumn
            colC1CTL.Name = "C1CTL"
            colC1CTL.DataType = GetType(String)
            colC1CTL.FieldName = "C1CTL"

            Dim colC1FAF As New GridViewTextBoxColumn
            colC1FAF.Name = "C1FAF"
            colC1FAF.DataType = GetType(String)
            colC1FAF.FieldName = "C1FAF"

            Dim colC1SOC As New GridViewTextBoxColumn
            colC1SOC.Name = "C1SOC"
            colC1SOC.DataType = GetType(String)
            colC1SOC.FieldName = "C1SOC"

            Dim colDESSER As New GridViewTextBoxColumn
            colDESSER.Name = "DESSER"
            colDESSER.DataType = GetType(String)
            colDESSER.FieldName = "DESSER"

            'gridservizi.MasterTemplate.Columns.Add(commandColumn)
            'gridservizi.MasterTemplate.Columns.Add(checkBoxColumn)
            gridServizi.MasterTemplate.Columns.Add(colC1SOC)
            gridServizi.MasterTemplate.Columns.Add(colCDSER)
            gridServizi.MasterTemplate.Columns.Add(colDESSER)
            gridServizi.MasterTemplate.Columns.Add(colCDIMCE)
            gridServizi.MasterTemplate.Columns.Add(colC1CIV)
            gridServizi.MasterTemplate.Columns.Add(colC1FFA)
            gridServizi.MasterTemplate.Columns.Add(colC1CTL)
            gridServizi.MasterTemplate.Columns.Add(colC1CTR)
            gridServizi.MasterTemplate.Columns.Add(colC1FAF)
            gridServizi.MasterTemplate.Columns.Add(colC1TFA)
            gridServizi.MasterTemplate.Columns.Add(colCodContratto)

            'AddHandler gridservizi.CommandCellClick, AddressOf grid_CommandCellClick

            gridServizi.TableElement.SearchHighlightColor = Color.LimeGreen

            'Me.gridservizi.Columns("Check").AllowFiltering = False
            'Me.gridservizi.Columns("Mod").AllowFiltering = False

            Me.gridServizi.EndEdit()

            'gridservizi.AllowSearchRow = True
            'gridservizi.MasterView.SummaryRows(0).PinPosition = PinnedRowPosition.Bottom


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Crea griglia servizi")
        End Try
    End Sub

    Private Sub crea_griglia_rate_contratto()
        Try
            Me.LoadSummaryRate()

            Me.gridRate.BeginEdit()
            'Me.gridrate.EnableFiltering = True
            'Me.gridrate.MasterTemplate.ShowHeaderCellButtons = True
            Me.gridRate.MasterTemplate.ShowFilteringRow = False
            Me.gridRate.AllowAddNewRow = False
            Me.gridRate.AutoGenerateColumns = False
            Me.gridRate.EnableGrouping = False

            Dim commandColumn As New GridViewTextBoxColumn
            commandColumn.Name = "Img"
            commandColumn.DataType = GetType(String)
            commandColumn.HeaderText = ""
            commandColumn.ReadOnly = True
            commandColumn.Width = 50
            commandColumn.IsPinned = True
            ''----------------------------------------------------------------

            ''checkbox colum -------------------------------------------------
            'Dim checkBoxColumn As New GridViewCheckBoxColumn()
            'checkBoxColumn.DataType = GetType(Integer)
            'checkBoxColumn.Name = "CHECK"
            'checkBoxColumn.FieldName = "CHECK"
            'checkBoxColumn.HeaderText = " "
            'checkBoxColumn.Width = 50
            'checkBoxColumn.IsPinned = True
            'checkBoxColumn.EditMode = EditMode.OnValueChange
            ''checkBoxColumn.Checked = False
            'checkBoxColumn.EnableHeaderCheckBox = True
            ''----------------------------------------------------------------


            Dim colCodContratto As New GridViewTextBoxColumn
            colCodContratto.Name = "CDNRC"
            colCodContratto.DataType = GetType(String)
            colCodContratto.FieldName = "CDNRC"

            Dim colCMPRG As New GridViewDecimalColumn
            colCMPRG.Name = "CMPRG"
            colCMPRG.DataType = GetType(Integer)
            colCMPRG.FieldName = "CMPRG"

            Dim colCMCAAE As New GridViewDecimalColumn
            colCMCAAE.Name = "CMCAAE"
            colCMCAAE.DataType = GetType(Double)
            colCMCAAE.FieldName = "CMCAAE"

            Dim colCMDTF As New GridViewDateTimeColumn
            colCMDTF.Name = "CMDTF"
            colCMDTF.DataType = GetType(Date)
            colCMDTF.FieldName = "CMDTF"

            Dim colCMCIV As New GridViewTextBoxColumn
            colCMCIV.Name = "CMCIV"
            colCMCIV.DataType = GetType(String)
            colCMCIV.FieldName = "CMCIV"

            Dim colCMIMP As New GridViewTextBoxColumn
            colCMIMP.Name = ""
            colCMIMP.DataType = GetType(String)
            colCMIMP.FieldName = "CMIMP"

            Dim colCMSES As New GridViewTextBoxColumn
            colCMSES.Name = "CMSES"
            colCMSES.DataType = GetType(String)
            colCMSES.FieldName = "CMSES"

            Dim colCMSER As New GridViewTextBoxColumn
            colCMSER.Name = "CMSER"
            colCMSER.DataType = GetType(String)
            colCMSER.FieldName = "CMSER"

            Dim colCMFSO As New GridViewTextBoxColumn
            colCMFSO.Name = "CMFSO"
            colCMFSO.DataType = GetType(String)
            colCMFSO.FieldName = "CMFSO"

            Dim colCMFFA As New GridViewTextBoxColumn
            colCMFFA.Name = "CMFFA"
            colCMFFA.DataType = GetType(String)
            colCMFFA.FieldName = "CMFFA"

            Dim colCMSOC As New GridViewTextBoxColumn
            colCMSOC.Name = "CMSOC"
            colCMSOC.DataType = GetType(String)
            colCMSOC.FieldName = "CMSOC"

            Dim colCMCCE As New GridViewTextBoxColumn
            colCMCCE.Name = "CMCCE"
            colCMCCE.DataType = GetType(String)
            colCMCCE.FieldName = "CMCCE"


            Dim colCDVOL As New GridViewTextBoxColumn
            colCDVOL.Name = "CMVOL"
            colCDVOL.DataType = GetType(String)
            colCDVOL.FieldName = "CMVOL"

            Dim colCMCLI As New GridViewTextBoxColumn
            colCMCLI.Name = "CMCLI"
            colCMCLI.DataType = GetType(String)
            colCMCLI.FieldName = "CMCLI"


            Dim colCMTST As New GridViewTextBoxColumn
            colCMTST.Name = "CMTST"
            colCMTST.DataType = GetType(String)
            colCMTST.FieldName = "CMTST"

            Dim colDESSER As New GridViewTextBoxColumn
            colDESSER.Name = "DESSER"
            colDESSER.DataType = GetType(String)
            colDESSER.FieldName = "DESSER"

            'gridrate.MasterTemplate.Columns.Add(commandColumn)
            'gridrate.MasterTemplate.Columns.Add(checkBoxColumn)
            gridRate.MasterTemplate.Columns.Add(colCMPRG)
            gridRate.MasterTemplate.Columns.Add(colCMDTF)
            gridRate.MasterTemplate.Columns.Add(colCMCAAE)
            gridRate.MasterTemplate.Columns.Add(colCMCIV)
            gridRate.MasterTemplate.Columns.Add(colCMIMP)
            gridRate.MasterTemplate.Columns.Add(colCMSER)
            gridRate.MasterTemplate.Columns.Add(colCMFFA)
            gridRate.MasterTemplate.Columns.Add(colDESSER)
            gridRate.MasterTemplate.Columns.Add(colCMSES)
            gridRate.MasterTemplate.Columns.Add(colCMFSO)
            gridRate.MasterTemplate.Columns.Add(colCDVOL)
            gridRate.MasterTemplate.Columns.Add(colCMSOC)
            gridRate.MasterTemplate.Columns.Add(colCMCCE)
            gridRate.MasterTemplate.Columns.Add(colCMCLI)
            gridRate.MasterTemplate.Columns.Add(colCMTST)

            'AddHandler gridrate.CommandCellClick, AddressOf grid_CommandCellClick

            gridRate.TableElement.SearchHighlightColor = Color.LimeGreen

            'Me.gridrate.Columns("Check").AllowFiltering = False
            'Me.gridrate.Columns("Mod").AllowFiltering = False

            Me.gridRate.EndEdit()

            'gridrate.AllowSearchRow = True
            'gridrate.MasterView.SummaryRows(0).PinPosition = PinnedRowPosition.Bottom


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Crea griglia impianti")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia_impianti()
        Try

            Me.GridImpianti.Columns("CDIMP").HeaderText = "Impianto"
            Me.GridImpianti.Columns("CDNRC").HeaderText = "Contratto"
            Me.GridImpianti.Columns("DESSER").HeaderText = "Descrizione Servizio"
            Me.GridImpianti.Columns("CDSER").HeaderText = "Cod. Servizio"
            Me.GridImpianti.Columns("CDCOM").HeaderText = "Commessa"
            Me.GridImpianti.Columns("CDVOL").HeaderText = "Vol."
            Me.GridImpianti.Columns("CDSES").HeaderText = "Soc. Esec."
            Me.GridImpianti.Columns("CDCTL").HeaderText = "95/16"
            Me.GridImpianti.Columns("CDIMCE").HeaderText = "Importo Canone"
            Me.GridImpianti.Columns("CDFSO").HeaderText = "S/D"
            Me.GridImpianti.Columns("CDDSO").HeaderText = "Data sosp."

            Me.GridImpianti.Columns("CDIMP").TextAlignment = ContentAlignment.MiddleCenter
            Me.GridImpianti.Columns("CDNRC").TextAlignment = ContentAlignment.MiddleCenter
            Me.GridImpianti.Columns("DESSER").TextAlignment = ContentAlignment.MiddleLeft
            Me.GridImpianti.Columns("CDSER").TextAlignment = ContentAlignment.MiddleCenter
            Me.GridImpianti.Columns("CDSES").TextAlignment = ContentAlignment.MiddleCenter
            Me.GridImpianti.Columns("CDCTL").TextAlignment = ContentAlignment.MiddleCenter
            Me.GridImpianti.Columns("CDFSO").TextAlignment = ContentAlignment.MiddleCenter

            'Me.GridImpianti.Columns("CDNRC").IsVisible = False
            'Me.GridImpianti.Columns("CDIMP").IsVisible = False
            'Me.GridImpianti.Columns("NUMCHL").IsVisible = False
            'Me.GridImpianti.Columns("CODCATASSET").IsVisible = False

            For Each col In Me.GridImpianti.Columns
                col.ReadOnly = True
                col.IsVisible = False
            Next

            Me.GridImpianti.Columns("CDIMP").IsVisible = True
            Me.GridImpianti.Columns("DESSER").IsVisible = True
            Me.GridImpianti.Columns("CDSER").IsVisible = True
            Me.GridImpianti.Columns("CDCOM").IsVisible = True
            Me.GridImpianti.Columns("CDVOL").IsVisible = True
            Me.GridImpianti.Columns("CDSES").IsVisible = True
            Me.GridImpianti.Columns("CDCTL").IsVisible = True
            Me.GridImpianti.Columns("CDIMCE").IsVisible = True
            Me.GridImpianti.Columns("CDFSO").IsVisible = True
            Me.GridImpianti.Columns("CDDSO").IsVisible = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_GrigliaImpianti_width()
        Try
            'Me.gridImpianti.Columns("img").Width = 50
            Me.GridImpianti.Columns("CDIMP").Width = 80
            Me.GridImpianti.Columns("DESSER").Width = 350
            Me.GridImpianti.Columns("CDSER").Width = 80
            Me.GridImpianti.Columns("CDCOM").Width = 150
            Me.GridImpianti.Columns("CDVOL").Width = 60
            Me.GridImpianti.Columns("CDFSO").Width = 50
            Me.GridImpianti.Columns("CDSES").Width = 80
            Me.GridImpianti.Columns("CDCTL").Width = 80
            Me.GridImpianti.Columns("CDIMCE").Width = 130
            Me.GridImpianti.Columns("CDDSO").Width = 90

            Me.GridImpianti.Columns("CDIMCE").FormatString = "{0:#,##0.00}"
            Me.GridImpianti.Columns("CDDSO").FormatString = "{0:dd/MM/yyyy}"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia_Servizi()
        Try

            Me.gridServizi.Columns("C1NRC").HeaderText = "Contratto"
            Me.gridServizi.Columns("DESSER").HeaderText = "Descrizione Servizio"
            Me.gridServizi.Columns("C1SER").HeaderText = "Cod. Servizio"
            Me.gridServizi.Columns("C1SOC").HeaderText = "Società"
            Me.gridServizi.Columns("C1TFA").HeaderText = "Tp. Fatt."
            Me.gridServizi.Columns("C1CIV").HeaderText = "Cd. Iva"
            Me.gridServizi.Columns("C1CTL").HeaderText = "95/16"
            Me.gridServizi.Columns("C1CAN").HeaderText = "Importo Canone"
            Me.gridServizi.Columns("C1FFA").HeaderText = "Freq."
            Me.gridServizi.Columns("C1CTR").HeaderText = "Tp. Riv."

            Me.gridServizi.Columns("C1SER").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridServizi.Columns("C1SOC").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridServizi.Columns("DESSER").TextAlignment = ContentAlignment.MiddleLeft
            Me.gridServizi.Columns("C1TFA").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridServizi.Columns("C1CIV").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridServizi.Columns("C1FFA").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridServizi.Columns("C1CTR").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridServizi.Columns("C1CTL").TextAlignment = ContentAlignment.MiddleCenter

            For Each col In Me.gridServizi.Columns
                col.ReadOnly = True
                col.IsVisible = False
            Next

            Me.gridServizi.Columns("C1SER").IsVisible = True
            Me.gridServizi.Columns("DESSER").IsVisible = True
            Me.gridServizi.Columns("C1SOC").IsVisible = True
            Me.gridServizi.Columns("C1TFA").IsVisible = True
            Me.gridServizi.Columns("C1CIV").IsVisible = True
            Me.gridServizi.Columns("C1CAN").IsVisible = True
            Me.gridServizi.Columns("C1FFA").IsVisible = True
            Me.gridServizi.Columns("C1CTR").IsVisible = True
            Me.gridServizi.Columns("C1CTL").IsVisible = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "LIFT.NET")
        End Try
    End Sub

    Private Sub HeaderText_Column_GrigliaServizi_width()
        Try
            Me.gridServizi.Columns("C1SER").Width = 80
            Me.gridServizi.Columns("DESSER").Width = 350
            Me.gridServizi.Columns("C1SOC").Width = 80
            Me.gridServizi.Columns("C1TFA").Width = 80
            Me.gridServizi.Columns("C1CIV").Width = 80
            Me.gridServizi.Columns("C1CAN").Width = 100
            Me.gridServizi.Columns("C1FFA").Width = 80
            Me.gridServizi.Columns("C1CTR").Width = 80
            Me.gridServizi.Columns("C1CTL").Width = 80

            Me.gridServizi.Columns("C1CAN").FormatString = "{0:#,##0.00}"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "LIFT.NET")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia_rate()
        Try

            Me.gridRate.Columns("CMPRG").HeaderText = "Progr."
            Me.gridRate.Columns("CMDTF").HeaderText = "Scadenza"
            Me.gridRate.Columns("CMCAAE").HeaderText = "Importo"
            Me.gridRate.Columns("CMCIV").HeaderText = "Cd. Iva"
            Me.gridRate.Columns("CMIMP").HeaderText = "Impianto"
            Me.gridRate.Columns("CMFSO").HeaderText = "Fl. Sosp."
            Me.gridRate.Columns("CMFFA").HeaderText = "Fatt."
            Me.gridRate.Columns("CMSOC").HeaderText = "Cd. Soc."
            Me.gridRate.Columns("CMCCE").HeaderText = "Centro"
            Me.gridRate.Columns("CMCLI").HeaderText = "Cd. Cli."
            Me.gridRate.Columns("CMTST").HeaderText = "Tp. Sta."
            Me.gridRate.Columns("CMSER").HeaderText = "Cd. Serv."
            Me.gridRate.Columns("CMSES").HeaderText = "Soc. Esec."
            Me.gridRate.Columns("CMVOL").HeaderText = "Fl. Vol."
            Me.gridRate.Columns("DESSER").HeaderText = "Descrizione Servizio"

            Me.gridRate.Columns("CMPRG").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridRate.Columns("CMDTF").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridRate.Columns("DESSER").TextAlignment = ContentAlignment.MiddleLeft
            Me.gridRate.Columns("CMCIV").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridRate.Columns("CMIMP").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridRate.Columns("CMFSO").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridRate.Columns("CMFFA").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridRate.Columns("CMSOC").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridRate.Columns("CMCCE").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridRate.Columns("CMCLI").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridRate.Columns("CMTST").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridRate.Columns("CMSER").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridRate.Columns("CMSES").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridRate.Columns("CMVOL").TextAlignment = ContentAlignment.MiddleCenter

            For Each col In Me.gridRate.Columns
                col.ReadOnly = True
                'col.IsVisible = False
            Next

            'Me.gridRate.Columns("CDIMP").IsVisible = True
            'Me.gridRate.Columns("DESSER").IsVisible = True
            'Me.gridRate.Columns("CDSER").IsVisible = True
            'Me.gridRate.Columns("CDCOM").IsVisible = True
            'Me.gridRate.Columns("CDVOL").IsVisible = True
            'Me.gridRate.Columns("CDSES").IsVisible = True
            'Me.gridRate.Columns("CDCTL").IsVisible = True
            'Me.gridRate.Columns("CDIMCE").IsVisible = True
            'Me.gridRate.Columns("CDFSO").IsVisible = True
            'Me.gridRate.Columns("CDDSO").IsVisible = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_GrigliaRate_width()
        Try

            Me.gridRate.Columns("CMPRG").Width = 60
            Me.gridRate.Columns("DESSER").Width = 350
            Me.gridRate.Columns("CMDTF").Width = 80
            Me.gridRate.Columns("CMCAAE").Width = 100
            Me.gridRate.Columns("CMCIV").Width = 60
            Me.gridRate.Columns("CMIMP").Width = 80
            Me.gridRate.Columns("CMFSO").Width = 50
            Me.gridRate.Columns("CMFFA").Width = 50
            Me.gridRate.Columns("CMSOC").Width = 50
            Me.gridRate.Columns("CMCCE").Width = 60
            Me.gridRate.Columns("CMCLI").Width = 80
            Me.gridRate.Columns("CMTST").Width = 50
            Me.gridRate.Columns("CMSER").Width = 60
            Me.gridRate.Columns("CMSES").Width = 50
            Me.gridRate.Columns("CMVOL").Width = 50

            Me.gridRate.Columns("CMCAAE").FormatString = "{0:#,##0.00}"
            Me.gridRate.Columns("CMDTF").FormatString = "{0:dd/MM/yyyy}"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "LIFT.NET")
        End Try
    End Sub


    Private Sub LoadSummaryCanoni()
        Try

            Me.GridImpianti.MasterTemplate.SummaryRowsBottom.Clear()
            Dim item1 As New GridViewSummaryRowItem()
            item1.Add(New GridViewSummaryItem("CDIMCE", "{0:#,##0.00}", GridAggregateFunction.Sum))

            Me.GridImpianti.MasterTemplate.SummaryRowsBottom.Add(item1)

            GridImpianti.MasterTemplate.ShowTotals = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "LIFT.NET")
        End Try

    End Sub

    Private Sub LoadSummaryCanoniServizi()
        Try

            Me.gridServizi.MasterTemplate.SummaryRowsBottom.Clear()
            Dim item1 As New GridViewSummaryRowItem()
            item1.Add(New GridViewSummaryItem("C1CAN", "{0:#,##0.00}", GridAggregateFunction.Sum))

            Me.gridServizi.MasterTemplate.SummaryRowsBottom.Add(item1)

            gridServizi.MasterTemplate.ShowTotals = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try

    End Sub

    Private Sub LoadSummaryRate()
        Try

            Me.gridRate.MasterTemplate.SummaryRowsBottom.Clear()
            Dim item1 As New GridViewSummaryRowItem()
            item1.Add(New GridViewSummaryItem("CMCAAE", "{0:#,##0.00}", GridAggregateFunction.Sum))

            Me.gridRate.MasterTemplate.SummaryRowsBottom.Add(item1)

            gridRate.MasterTemplate.ShowTotals = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "LIFT.NET")
        End Try

    End Sub

    Private Sub grid_GroupSummaryEvaluate(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GroupSummaryEvaluationEventArgs)
        Try
            'If e.SummaryItem.Name = "DDESCL" Then
            Dim desRiga As String = ""

            If e.SummaryItem.Name = "???????" Then
                'Dim totale As Double = 0
                For Each row As GridViewRowInfo In e.Group
                    If Not row Is Nothing Then
                        'desRiga = Trim(e.Value.ToString) & " - " & row.Cells("XDSCA").Value
                        Exit For
                    End If
                Next

                'e.FormatString = [String].Format("{1}{0}{2}", "", e.Value.ToString & Space(45 - e.Value.ToString.Length), Format(totale, "#,##0.00"))
                e.FormatString = [String].Format("{0}", desRiga)

            ElseIf TypeOf e.Context Is GridViewSummaryRowInfo Then
                If e.SummaryItem.Name = "CDNRC" Then
                ElseIf e.SummaryItem.Name = "CDIMCE" Then
                    e.FormatString = "{0:#,##0}"
                ElseIf e.SummaryItem.Name = "DATADOC" Then
                    e.FormatString = "{0:dd-MM-yyyy}"

                Else
                    e.FormatString = "{0:#,##0.00}"
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub grid_ViewCellFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs)
        Try
            Dim newFont = New System.Drawing.Font("Verdana", 8.0F, FontStyle.Bold)
            Dim newFontSum = New System.Drawing.Font("Segoue UI", 9.0F, FontStyle.Bold)
            Dim newFontH = New System.Drawing.Font("Segoue UI", 10.0F, FontStyle.Regular)
            Dim newFontGH = New System.Drawing.Font("Segoue UI", 10.5F, FontStyle.Regular)

            Dim headerCell As GridHeaderCellElement = TryCast(e.CellElement, GridHeaderCellElement)
            If headerCell IsNot Nothing Then
                'If e.Column.Name = "CBPL" Or e.Column.Name = "CBPDR" Or _
                'e.Column.Name = "CBATIP" Or e.Column.Name = "CBCTRAT" Or _
                'e.Column.Name = "CBCTRVO" Or e.Column.Name = "CBCTRDI" Then
                'headerCell.FilterButton.Image = Nothing

            Else
                'e.CellElement.ResetValue(LightVisualElement., ValueResetFlags.Local)
            End If

            'End If
            'e.Row.Height = 30
            e.CellElement.Font = newFontH

            If TypeOf e.CellElement.RowInfo Is GridViewGroupRowInfo Then
                e.CellElement.Font = newFont
                e.CellElement.DrawFill = True

                If e.CellElement.RowInfo.Group.GroupDescriptor IsNot Nothing Then
                    e.CellElement.BackColor = Color.FromArgb(246, 246, 246) '(206, 215, 101)
                    'e.CellElement.ForeColor = Color.FromArgb(100, 119, 130)
                    e.CellElement.Font = newFontGH
                    e.CellElement.TextAlignment = ContentAlignment.MiddleLeft
                    e.CellElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid
                    'e.CellElement.DrawBorder = False
                Else
                    e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                    'e.CellElement.DrawBorder = True
                End If
            ElseIf TypeOf e.CellElement.RowInfo Is GridViewDataRowInfo Then
                'If e.Column.Name = "XTIMPC" Or e.Column.Name = "XTIMSC" Or e.Column.Name = "XTIMTC" Or e.Column.Name = "XDOCC" Then
                '    e.CellElement.BackColor = Color.FromArgb(217, 227, 232)
                'Else
                '    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                'End If

            ElseIf TypeOf e.CellElement.RowInfo Is GridViewSummaryRowInfo Then
                If TypeOf e.CellElement Is GridSummaryCellElement AndAlso e.Row.Group Is Nothing Then
                    e.CellElement.Font = newFontSum
                    e.CellElement.DrawFill = True
                    e.CellElement.BackColor = Color.FromArgb(222, 223, 227)
                    e.CellElement.ForeColor = Color.Black
                    e.CellElement.GradientStyle = GradientStyles.Solid
                    e.CellElement.DrawBorder = False
                    'e.Row.Height = 16
                ElseIf TypeOf e.CellElement Is GridSummaryCellElement AndAlso e.Row.Group IsNot Nothing Then
                    e.CellElement.DrawFill = True
                    e.CellElement.BackColor = Color.FromArgb(239, 239, 239)
                    'e.CellElement.ForeColor = Color.FromArgb(100, 119, 130)
                    e.CellElement.ForeColor = Color.Black
                    e.CellElement.TextAlignment = ContentAlignment.MiddleRight
                    e.CellElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid
                    e.CellElement.DrawBorder = False
                Else
                    e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                    'e.CellElement.DrawBorder = True
                End If

                If e.CellElement.ColumnInfo.Name = "NUMDOC" Then
                    e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
                Else
                    e.CellElement.TextAlignment = ContentAlignment.MiddleRight
                End If

            ElseIf e.CellElement.ViewTemplate.Parent IsNot Nothing Then
                e.CellElement.BackColor = Color.Bisque

            ElseIf TypeOf e.CellElement Is GridHeaderCellElement Then
                e.CellElement.Font = newFontH
                e.CellElement.TextWrap = True
                e.CellElement.ClipDrawing = True
                'e.Row.Height = 50
                If GridImpianti.FilterDescriptors.Expression.ToString.ToUpper.Contains(e.CellElement.ColumnInfo.Name) Then
                    e.CellElement.BackColor = Color.FromArgb(233, 255, 1)
                    e.CellElement.ForeColor = Color.FromArgb(30, 123, 169)
                Else
                    e.CellElement.BackColor = Color.FromArgb(227, 227, 227)
                    e.CellElement.ForeColor = Color.Black
                End If
            End If


            'Dim filterCell As GridFilterCellElement = TryCast(e.CellElement, GridFilterCellElement)


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub grid_ViewRowFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.RowFormattingEventArgs)

        Try
            If TypeOf e.RowElement Is GridSummaryRowElement Then
                If e.RowElement.RowInfo.Group Is Nothing Then
                    e.RowElement.RowInfo.PinPosition = PinnedRowPosition.Bottom
                Else
                    e.RowElement.RowInfo.PinPosition = PinnedRowPosition.None
                End If
                'e.RowElement.RowInfo.Height = 35
            ElseIf TypeOf e.RowElement Is GridDataRowElement Then
                'e.RowElement.RowInfo.Height = 35
            ElseIf TypeOf e.RowElement Is GridTableHeaderRowElement Then
                e.RowElement.RowInfo.Height = 45
            Else
                'e.RowElement.RowInfo.Height = 30
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
    Private Sub grid_CellFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs)

        Try

            If e.CellElement.ColumnInfo.Name.ToUpper = "CHECK" Then
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                e.CellElement.ResetValue(LightVisualElement.TextImageRelationProperty, ValueResetFlags.Local)
                e.CellElement.ResetValue(LightVisualElement.ImageAlignmentProperty, ValueResetFlags.Local)
                e.CellElement.Image = Nothing


            ElseIf e.CellElement.ColumnInfo.Name.ToUpper = "IMG" Then
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                e.CellElement.ResetValue(LightVisualElement.TextImageRelationProperty, ValueResetFlags.Local)
                e.CellElement.ResetValue(LightVisualElement.ImageAlignmentProperty, ValueResetFlags.Local)
                e.CellElement.Image = Nothing

            Else
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                e.CellElement.ResetValue(LightVisualElement.TextImageRelationProperty, ValueResetFlags.Local)
                e.CellElement.ResetValue(LightVisualElement.ImageAlignmentProperty, ValueResetFlags.Local)
                e.CellElement.Image = Nothing
            End If



            If TypeOf e.CellElement Is GridCommandCellElement Then
                Dim commandCell = TryCast(e.CellElement, GridCommandCellElement)
                commandCell.CommandButton.ButtonFillElement.NumberOfColors = 1
                'commandCell.CommandButton.ButtonFillElement.ForeColor = Color.Blue
                commandCell.CommandButton.ButtonFillElement.BackColor = Color.FromArgb(239, 239, 239)
                commandCell.CommandButton.ImageAlignment = ContentAlignment.MiddleCenter
                commandCell.CommandButton.ShowBorder = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub grid_ValueChanging(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.ValueChangingEventArgs)
        Try
            If TypeOf sender Is GridViewCellInfo Then
                Dim Row As GridViewCellInfo = sender
                Dim lastRow As GridViewRowInfo = Row.RowInfo

                If Row.ColumnInfo.Name = "CHECK" Then
                    Dim cell As GridViewCellInfo = lastRow.Cells("CHECK")


                    If cell.ColumnInfo.GetType().Equals(GetType(GridViewCheckBoxColumn)) Then

                        'If (Not Convert.IsDBNull(lastRow.Cells("FLAGSMISTATO").Value) _
                        '	AndAlso lastRow.Cells("FLAGSMISTATO").Value = "S") And
                        '	(Not Convert.IsDBNull(lastRow.Cells("FLAGIMPORTATO").Value) _
                        '	AndAlso lastRow.Cells("FLAGIMPORTATO").Value <> "S") And
                        '	Not Convert.IsDBNull(lastRow.Cells("CODICECENTRO").Value) And
                        '	  lastRow.Cells("CODICECENTRO").Value = "C00" Then
                        '	e.Cancel = False

                        'ElseIf (Not Convert.IsDBNull(lastRow.Cells("FLAGSMISTATO").Value) _
                        '	AndAlso lastRow.Cells("FLAGSMISTATO").Value = "S") OrElse
                        '	(Convert.IsDBNull(lastRow.Cells("CODICECENTRO").Value) _
                        '	OrElse lastRow.Cells("CODICECENTRO").Value.ToString.Trim = "") _
                        '	OrElse (lastRow.Cells("FLAGSCARTO").Value = "X" And lastRow.Cells("FLAGDECORRTERM").Value = 0) _
                        '	OrElse (lastRow.Cells("FLAGSCARTO").Value = "S") _
                        '	OrElse (lastRow.Cells("CODSOCIETA").Value.ToString.Trim = "") Then

                        '	e.Cancel = True

                        'End If

                    End If

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub grid_ContextMenuOpening(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.ContextMenuOpeningEventArgs)
        e.Cancel = True
    End Sub

    Private Sub grid_FilterPopupRequired(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.FilterPopupRequiredEventArgs)
        Try

            Telerik.WinControls.RadMessageBox.SetThemeName("Office2013Light")

            Dim popup As RadListFilterPopup = TryCast(e.FilterPopup, RadListFilterPopup)
            If popup IsNot Nothing Then


                If e.Column.Name.ToUpper = "CHECK" OrElse e.Column.Name.ToUpper = "MOD" Then
                    popup.AutoSize = False
                    RadMessageBox.Show(Me, "Filtro non disponibile", "Filtri", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    popup.Size = New Size(popup.Width, 0)
                    popup.SizingGrip.Visibility = ElementVisibility.Collapsed
                    'popup.Visible = False
                    'popup.Width = 0
                Else
                    popup.SizingGrip.Visibility = ElementVisibility.Visible
                    popup.Size = New Size(popup.Width, 250)
                    'popup.AutoSize = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub grid_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles gridServizi.CellDoubleClick
        Try
            If e.Column.Name.ToUpper = "C1SER" Then
                Dim rowInfo As GridViewRowInfo = e.Row

                If Not IsNothing(rowInfo) Then
                    Dim idCtr As String = rowInfo.Cells("C1NRC").Value
                    Dim idSer As String = rowInfo.Cells("C1SER").Value
                    Dim frm As New FrmServizioContratto(idCtr, idSer, "MODIFICA")
                    frm.ShowDialog()
                    async_carica_griglia_servizi_contratto(idContratto)
                Else
                    RadMessageBox.Show("Nessun dato da visualizzare.", "Servizi", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdInserisci_Click(sender As Object, e As EventArgs) Handles cmdInserisci.Click
        Try

            Dim frm As New FrmServizioContratto(idContratto, "", "NUOVO")
            frm.ShowDialog()
            async_carica_griglia_servizi_contratto(idContratto)
        Catch ex As Exception

        End Try
    End Sub
End Class

