Imports System.Net
Imports System.Text
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json
Imports Telerik.WinControls
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI

Public Class FrmAccordo
    Dim statoCaricaTipoContratto As Boolean
    Dim statoCaricaPrestazioni As Boolean
    Dim statoCaricaTipoFatturazione As Boolean
    Dim statoCaricaModPag As Boolean
    Dim statoCaricaTipoAppalto As Boolean
    Dim statoCaricaSoc As Boolean
    Dim statoCaricaProvenienza As Boolean

    Dim azione As String
    Dim formInCaricamento As Boolean

    Private idAccordo As String
    Private schedaContratto As Threading.Tasks.Task(Of elencoAccordi)

    Private strip As RadPageViewStripElement
    Private ws As New webServices

    Public Sub New(ByVal id As String, ByVal inAzione As String, Optional ByVal ElencoCentri As String = "", Optional ByVal inUser As String = "", Optional ByVal inRuolo As String = "", Optional ByVal inUserAS As String = "", Optional ByVal modifica As Boolean = True, Optional ByVal testo As String = "")
        InitializeComponent()
        WireEvents()
        idAccordo = id
        azione = inAzione
        'ruolo = inRuolo
        'user = inUser
        'userAS = inUserAS
        'gElencoCentri = ElencoCentri
    End Sub

    Protected Sub WireEvents()
        AddHandler gridContratti.ViewCellFormatting, AddressOf grid_ViewCellFormatting
        AddHandler gridContratti.ViewRowFormatting, AddressOf grid_ViewRowFormatting
        AddHandler gridContratti.CellFormatting, AddressOf grid_CellFormatting
        AddHandler gridContratti.ContextMenuOpening, AddressOf grid_ContextMenuOpening
        AddHandler gridContratti.ValueChanging, AddressOf grid_ValueChanging
        AddHandler gridContratti.CellDoubleClick, AddressOf grid_CellDoubleClick

        AddHandler gridProroghe.ViewCellFormatting, AddressOf grid_ViewCellFormatting
        AddHandler gridProroghe.ViewRowFormatting, AddressOf grid_ViewRowFormatting
        AddHandler gridProroghe.CellFormatting, AddressOf grid_CellFormatting
        AddHandler gridProroghe.ContextMenuOpening, AddressOf grid_ContextMenuOpening
        AddHandler gridProroghe.ValueChanging, AddressOf grid_ValueChanging
        AddHandler gridProroghe.CellDoubleClick, AddressOf grid_CellDoubleClick

        AddHandler gridDoc.ViewCellFormatting, AddressOf grid_ViewCellFormatting
        AddHandler gridDoc.ViewRowFormatting, AddressOf grid_ViewRowFormatting
        AddHandler gridDoc.CellFormatting, AddressOf grid_CellFormatting
        AddHandler gridDoc.ContextMenuOpening, AddressOf grid_ContextMenuOpening
        AddHandler gridDoc.ValueChanging, AddressOf grid_ValueChanging
        AddHandler gridDoc.GroupSummaryEvaluate, AddressOf grid_GroupSummaryEvaluate
    End Sub

    Private Sub FrmAccordo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonDFT.tssp")
        ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonBLU.tssp")
        ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonRED.tssp")

        cmdOkSearchCli.ThemeName = "buttonDFT"
        cmdAnnulla.ThemeName = "buttonDFT"
        cmdConferma.ThemeName = "buttonBLU"

        wb.AssociatedControl = Me
        wb.StartWaiting()
        wb.Visible = True

        t1.Enabled = True
        formInCaricamento = True
        Me.crea_Griglia_Contratti()
        Me.crea_Griglia_proroghe()
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

    Private Sub gestisci_campi_form()
        Try
            Select Case azione
                Case "NUOVO"
                    txtID.ReadOnly = True
                    For Each pag As RadPageViewPage In RPcontainer.Pages
                        If pag.TabIndex <> 0 Then
                            pag.Item.Visibility = ElementVisibility.Collapsed
                        End If
                    Next

                Case "MODIFICA"
                    txtID.ReadOnly = True
                    cmbTipoContratto.Enabled = False
                    cmbSocieta.ReadOnly = True
                    cmdOkSearchCli.Enabled = False
                    txtCodCliente.ReadOnly = True
                    groupTipoAccordo.Enabled = False

                    For Each pag As RadPageViewPage In RPcontainer.Pages
                        '    If pag.TabIndex = 4 Then
                        '        pag.Item.Visibility = ElementVisibility.Collapsed
                        '    Else
                        pag.Item.Visibility = ElementVisibility.Visible
                        'End If
                    Next
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub t1_Tick(sender As Object, e As EventArgs) Handles t1.Tick
        Try
            If statoCaricaTipoContratto = True And
                statoCaricaPrestazioni = True And
                statoCaricaTipoFatturazione = True And
                statoCaricaTipoFatturazione = True And
                statoCaricaModPag = True And
                statoCaricaTipoAppalto = True And
                statoCaricaSoc = True And statoCaricaProvenienza = True Then

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

    Private Sub azzera_campi_form()
        Try
            txtID.Text = ""
            txtCodCliente.Text = ""
            txtDesCli.Text = ""
            txtOggetto.Text = ""
            txtImporto.Text = "0,00"
            txtRitenuta.Text = ""
            txtCommessa.Text = ""
            txtCIG.Text = ""
            txtCUP.Text = ""
            txtDtFinDecor.Text = ""
            txtDtIniDecor.Text = ""
            txtIdAccordoCliente.Text = ""
            cmbModPag.SelectedIndex = -1
            cmbProvenienza.SelectedIndex = -1
            cmbSocieta.SelectedIndex = -1
            listTipoAppalto.Items.Clear()
            listPrestazioni.Items.Clear()

            cmbTipoFatt.SelectedIndex = -1
            cmbTipoContratto.SelectedIndex = -1

            chkIvaRitenuta.Checked = CheckState.Unchecked

        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub async_carica_scheda_contratto()
        Try

            txtID.ReadOnly = True

            schedaContratto = ws.getAccordo(idAccordo)
            Await schedaContratto
            Me.carica_dati_liste()
            carica_dati_form(schedaContratto.Result)

            async_carica_griglia_contratti(idAccordo, "", "A")
            async_carica_griglia_contratti(idAccordo, "", "P,V")
            async_carica_griglia_documenti("", "", "", "", idAccordo)

            'async_carica_griglia_servizi_contratto(schedaContratto.Result.CTNRC)
            'async_carica_griglia_rate_contratto(schedaContratto.Result.CTNRC)

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

    Private Sub carica_dati_liste()
        Try
            Dim valTipoContratto As String = ""
            Dim valTipoAccordo As String = ""
            Dim valTipoFatt As String = ""
            Dim valProvenienzaAccordo As String = ""
            Dim valPianoManut As String = ""
            Dim val9516 As String = ""
            Dim valModPag As String = ""
            Dim valFreqFatt As String = ""
            Dim valSocieta As String = ""
            Dim valCodAge As String = ""
            Dim valCodTipologiaCliente As String = ""

            If azione = "MODIFICA" Then
                valTipoAccordo = schedaContratto.Result.CDCLS
                valProvenienzaAccordo = schedaContratto.Result.CDPRV
                valTipoFatt = schedaContratto.Result.CDTPFAT
                valModPag = schedaContratto.Result.CDPAG
                valSocieta = schedaContratto.Result.CDSOC
                valTipoContratto = schedaContratto.Result.TIPOCTR
            End If

            carica_combo_tabelle("SOC", cmbSocieta, valSocieta)
            carica_combo_tabelle("TFA", cmbTipoFatt, valTipoFatt)
            carica_combo_tabelle("PAC", cmbProvenienza, valProvenienzaAccordo)
            'carica_combo_tabelle("TAP", cmbTipoAppalto, valTipoAccordo)
            carica_combo_tipi_tabelle_colonne("TPC", cmbTipoContratto, valTipoContratto)
            carica_combo_tipi_tabelle_colonne("PAG", cmbModPag, valModPag)
            carica_liste("PRS", listPrestazioni)
            carica_liste("TAP", listTipoAppalto)

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
                Case "TFA"
                    statoCaricaTipoFatturazione = True
                Case "SOC"
                    statoCaricaSoc = True
                Case "PAC"
                    statoCaricaProvenienza = True
                Case "TPC"
                    statoCaricaTipoContratto = True
                Case "PAG"
                    statoCaricaModPag = True
                Case "PRS"
                    statoCaricaPrestazioni = True
            End Select

        Catch ex As Exception

            statoCaricaTipoFatturazione = True
            statoCaricaModPag = True
            statoCaricaSoc = True
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Async Sub carica_combo_tipi_tabelle_colonne(codTab As String, combo As RadMultiColumnComboBox, valoreIniziale As String)

        Try

            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella(codTab, "")
            Await elementi


            combo.Columns.Clear()
            combo.MultiColumnComboBoxElement.DropDownAnimationEnabled = False

            combo.AutoSizeDropDownToBestFit = True
            Dim multiColumnComboElement As RadMultiColumnComboBoxElement = combo.MultiColumnComboBoxElement
            multiColumnComboElement.DropDownSizingMode = SizingMode.UpDownAndRightBottom
            multiColumnComboElement.DropDownMinSize = New Size(420, 300)
            multiColumnComboElement.EditorControl.MasterTemplate.AutoGenerateColumns = False

            Dim column = New GridViewTextBoxColumn("CodElem")
            column.HeaderText = "Codice"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("DesElem")
            column.HeaderText = "Descrizione"
            multiColumnComboElement.Columns.Add(column)


            combo.DisplayMember = "DesElem"
            combo.ValueMember = "codElem"
            combo.DataSource = elementi.Result

            combo.AutoFilter = True
            Dim compositeFilter As New CompositeFilterDescriptor()
            Dim codElem As New FilterDescriptor("codElem", FilterOperator.Contains, "")
            Dim desElem As New FilterDescriptor("desElem", FilterOperator.Contains, "")

            compositeFilter.FilterDescriptors.Add(codElem)
            compositeFilter.FilterDescriptors.Add(desElem)

            compositeFilter.LogicalOperator = FilterLogicalOperator.[Or]
            combo.EditorControl.FilterDescriptors.Add(compositeFilter)

            combo.SelectedIndex = -1
            combo.SelectedValue = valoreIniziale

            Select Case codTab
                Case "TAP"
                    statoCaricaTipoAppalto = True
                Case "TPC"
                    statoCaricaTipoContratto = True
                Case "PAG"
                    statoCaricaModPag = True
            End Select

        Catch ex As Exception


            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_liste(codTab As String, lista As RadListView)
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella(codTab, "")
            Await elementi

            lista.DataSource = elementi.Result

            lista.DisplayMember = "DesElem"
            lista.ValueMember = "CodElem"

            If lista.Items.Count > 0 Then
                lista.Columns(0).HeaderText = "CODICE"
                lista.Columns(1).HeaderText = "DESCRIZIONE"
                lista.Columns(0).Width = 120
                lista.Columns(1).Width = 240
            End If

            If codTab = "PRS" Then
                If Not IsNothing(schedaContratto) Then
                    For i As Integer = 0 To schedaContratto.Result.listaPrestazioni.Count - 1
                        For j As Integer = 0 To listPrestazioni.Items.Count - 1
                            If schedaContratto.Result.listaPrestazioni(i).cdPrestazione = listPrestazioni.Items(j).Value Then
                                listPrestazioni.Items(j).CheckState = Telerik.WinControls.Enumerations.ToggleState.On
                            End If
                        Next j
                    Next i
                End If

                statoCaricaPrestazioni = True

            ElseIf codTab = "TAP" Then
                If Not IsNothing(schedaContratto) Then
                    For i As Integer = 0 To schedaContratto.Result.listaTipoApplato.Count - 1
                        For j As Integer = 0 To listTipoAppalto.Items.Count - 1
                            If schedaContratto.Result.listaTipoApplato(i).cdAppalto = listTipoAppalto.Items(j).Value Then
                                listTipoAppalto.Items(j).CheckState = Telerik.WinControls.Enumerations.ToggleState.On
                            End If
                        Next j
                    Next i
                End If

                statoCaricaTipoAppalto = True
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub carica_dati_form(dati As elencoAccordi)
        Try
            txtID.Text = dati.ID
            txtCodCliente.Text = dati.CDSTIP
            txtDesCli.Text = dati.RASCL

            If dati.FLRTIVA = "S" Then
                chkIvaRitenuta.Checked = True
            Else
                chkIvaRitenuta.Checked = False
            End If

            If dati.TIPOACC = "QUAD" Then
                chkAccordoQuadro.IsChecked = True
            Else
                chkConvenzione.IsChecked = True
            End If

            txtDtIniDecor.Text = dati.DTINIZ
            txtDtFinDecor.Text = dati.DTFINE
            txtOggetto.Text = dati.DESCR
            txtImporto.Text = dati.IMPORTO
            txtRitenuta.Text = dati.PERCRT
            txtIdAccordoCliente.Text = dati.IDACCLI
            txtCommessa.Text = dati.CDCOM
            txtCIG.Text = dati.CIG
            txtCUP.Text = dati.CUP

        Catch ex As Exception

        End Try
    End Sub


    Private Sub crea_Griglia_Contratti()
        Try
            Me.gridContratti.BeginEdit()
            Me.gridContratti.MasterTemplate.ShowFilteringRow = False
            Me.gridContratti.AllowAddNewRow = False
            Me.gridContratti.AutoGenerateColumns = False
            Me.gridContratti.EnableGrouping = False

            Dim commandColumn As New GridViewTextBoxColumn
            commandColumn.Name = "Mod"
            commandColumn.DataType = GetType(String)
            commandColumn.HeaderText = ""
            commandColumn.ReadOnly = True
            commandColumn.Width = 35
            commandColumn.IsPinned = True
            ''----------------------------------------------------------------

            ''checkbox colum -------------------------------------------------
            'Dim checkBoxColumn As New gridcontrattiViewCheckBoxColumn()
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

            Dim colCTNRC As New GridViewTextBoxColumn
            colCTNRC.Name = "CTNRC"
            colCTNRC.DataType = GetType(String)
            colCTNRC.FieldName = "CTNRC"

            Dim colCTSOC As New GridViewTextBoxColumn
            colCTSOC.Name = "CTSOC"
            colCTSOC.DataType = GetType(String)
            colCTSOC.FieldName = "CTSOC"

            Dim colCTDTD As New GridViewDateTimeColumn
            colCTDTD.Name = "CTDTD"
            colCTDTD.DataType = GetType(Date)
            colCTDTD.FieldName = "CTDTD"

            Dim colCTDTS As New GridViewDateTimeColumn
            colCTDTS.Name = "CTDTS"
            colCTDTS.DataType = GetType(Date)
            colCTDTS.FieldName = "CTDTS"

            Dim colCTCLI As New GridViewTextBoxColumn
            colCTCLI.Name = "CTCLI"
            colCTCLI.DataType = GetType(String)
            colCTCLI.FieldName = "CTCLI"

            Dim colCTNIM As New GridViewDecimalColumn
            colCTNIM.Name = "CTNIM"
            colCTNIM.DataType = GetType(Integer)
            colCTNIM.FieldName = "CTNIM"

            Dim colRASCL As New GridViewTextBoxColumn
            colRASCL.Name = "RASCL"
            colRASCL.DataType = GetType(String)
            colRASCL.FieldName = "RASCL"

            Dim colCTCAAE As New GridViewDecimalColumn
            colCTCAAE.Name = "CTCAAE"
            colCTCAAE.DataType = GetType(Double)
            colCTCAAE.FieldName = "CTCAAE"

            'gridContratti.MasterTemplate.Columns.Add(commandColumn)
            'gridcontratti.MasterTemplate.Columns.Add(checkBoxColumn)

            gridContratti.MasterTemplate.Columns.Add(colCTSOC)
            gridContratti.MasterTemplate.Columns.Add(colCTNRC)
            gridContratti.MasterTemplate.Columns.Add(colCTDTD)
            gridContratti.MasterTemplate.Columns.Add(colCTDTS)
            gridContratti.MasterTemplate.Columns.Add(colCTCAAE)
            gridContratti.MasterTemplate.Columns.Add(colCTNIM)
            gridContratti.MasterTemplate.Columns.Add(colCTCLI)
            gridContratti.MasterTemplate.Columns.Add(colRASCL)

            'AddHandler gridcontratti.CommandCellClick, AddressOf gridcontratti_CommandCellClick

            gridContratti.TableElement.SearchHighlightColor = Color.LimeGreen

            'Me.gridcontratti.Columns("Check").AllowFiltering = False
            'Me.gridcontratti.Columns("Mod").AllowFiltering = False

            Me.gridContratti.EndEdit()

            gridContratti.AllowSearchRow = False
            'gridcontratti.MasterView.SummaryRows(0).PinPosition = PinnedRowPosition.Bottom

            'Me.HeaderText_ColumnContratti()
            'Me.HeaderText_Column_Contratti_width()

            'caricamento totali griglia

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub crea_Griglia_proroghe()
        Try
            Me.gridProroghe.BeginEdit()
            Me.gridProroghe.MasterTemplate.ShowFilteringRow = False
            Me.gridProroghe.AllowAddNewRow = False
            Me.gridProroghe.AutoGenerateColumns = False
            Me.gridProroghe.EnableGrouping = False


            Dim colCTNRC As New GridViewTextBoxColumn
            colCTNRC.Name = "CTNRC"
            colCTNRC.DataType = GetType(String)
            colCTNRC.FieldName = "CTNRC"

            Dim colCTSOC As New GridViewTextBoxColumn
            colCTSOC.Name = "CTSOC"
            colCTSOC.DataType = GetType(String)
            colCTSOC.FieldName = "CTSOC"

            Dim colCTDTD As New GridViewDateTimeColumn
            colCTDTD.Name = "CTDTD"
            colCTDTD.DataType = GetType(Date)
            colCTDTD.FieldName = "CTDTD"

            Dim colCTDTS As New GridViewDateTimeColumn
            colCTDTS.Name = "CTDTS"
            colCTDTS.DataType = GetType(Date)
            colCTDTS.FieldName = "CTDTS"

            Dim colCTCLI As New GridViewTextBoxColumn
            colCTCLI.Name = "CTCLI"
            colCTCLI.DataType = GetType(String)
            colCTCLI.FieldName = "CTCLI"

            Dim colCTNIM As New GridViewDecimalColumn
            colCTNIM.Name = "CTNIM"
            colCTNIM.DataType = GetType(Integer)
            colCTNIM.FieldName = "CTNIM"

            Dim colRASCL As New GridViewTextBoxColumn
            colRASCL.Name = "RASCL"
            colRASCL.DataType = GetType(String)
            colRASCL.FieldName = "RASCL"

            Dim colTipoCtr As New GridViewTextBoxColumn
            colTipoCtr.Name = "DESTPCTR"
            colTipoCtr.DataType = GetType(String)
            colTipoCtr.FieldName = "DESTPCTR"

            Dim colCtrTS As New GridViewTextBoxColumn
            colCtrTS.Name = "CTNRCTS"
            colCtrTS.DataType = GetType(String)
            colCtrTS.FieldName = "CTNRCTS"

            Dim colIDACC As New GridViewTextBoxColumn
            colIDACC.Name = "IDACCORDO"
            colIDACC.DataType = GetType(String)
            colIDACC.FieldName = "IDACCORDO"

            Dim colCTCAAE As New GridViewDecimalColumn
            colCTCAAE.Name = "CTCAAE"
            colCTCAAE.DataType = GetType(Double)
            colCTCAAE.FieldName = "CTCAAE"

            gridProroghe.MasterTemplate.Columns.Add(colCTSOC)
            gridProroghe.MasterTemplate.Columns.Add(colCtrTS)
            gridProroghe.MasterTemplate.Columns.Add(colTipoCtr)
            gridProroghe.MasterTemplate.Columns.Add(colCTNRC)
            gridProroghe.MasterTemplate.Columns.Add(colCTDTD)
            gridProroghe.MasterTemplate.Columns.Add(colCTDTS)
            gridProroghe.MasterTemplate.Columns.Add(colCTCAAE)
            gridProroghe.MasterTemplate.Columns.Add(colCTNIM)
            gridProroghe.MasterTemplate.Columns.Add(colCTCLI)
            gridProroghe.MasterTemplate.Columns.Add(colRASCL)

            gridProroghe.TableElement.SearchHighlightColor = Color.LimeGreen

            Me.gridProroghe.EndEdit()

            gridProroghe.AllowSearchRow = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnContratti()
        Try
            Me.gridContratti.Columns("CTSOC").HeaderText = "Soc."
            Me.gridContratti.Columns("CTNRC").HeaderText = "Contratto"
            Me.gridContratti.Columns("CTDTD").HeaderText = "Decorrenza"
            Me.gridContratti.Columns("CTDTS").HeaderText = "Scadenza"
            Me.gridContratti.Columns("CTNIM").HeaderText = "N. Impianti"
            Me.gridContratti.Columns("CTCLI").HeaderText = "Cod. Cliente"
            Me.gridContratti.Columns("RASCL").HeaderText = "Ragione Sociale"
            Me.gridContratti.Columns("CTCAAE").HeaderText = "Importo"

            Me.gridContratti.Columns("CTSOC").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridContratti.Columns("CTNRC").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridContratti.Columns("CTDTD").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridContratti.Columns("CTDTS").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridContratti.Columns("CTNIM").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridContratti.Columns("CTCLI").TextAlignment = ContentAlignment.MiddleCenter


            Me.gridContratti.Columns("CTSOC").ReadOnly = True
            Me.gridContratti.Columns("CTNRC").ReadOnly = True
            Me.gridContratti.Columns("CTDTD").ReadOnly = True
            Me.gridContratti.Columns("CTDTS").ReadOnly = True
            Me.gridContratti.Columns("CTNIM").ReadOnly = True
            Me.gridContratti.Columns("CTCLI").ReadOnly = True
            Me.gridContratti.Columns("RASCL").ReadOnly = True
            Me.gridContratti.Columns("CTCAAE").ReadOnly = True

            Me.gridContratti.Columns("CTDTD").FormatString = "{0:dd/MM/yyyy}"
            Me.gridContratti.Columns("CTDTS").FormatString = "{0:dd/MM/yyyy}"

            Me.gridContratti.Columns("CTCAAE").FormatString = "{0:#,##0.00}"


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_Contratti_width()
        Try
            Me.gridContratti.Columns("CTSOC").Width = 80
            Me.gridContratti.Columns("CTNRC").Width = 90
            Me.gridContratti.Columns("CTDTD").Width = 100
            Me.gridContratti.Columns("CTDTS").Width = 100
            Me.gridContratti.Columns("CTNIM").Width = 80
            Me.gridContratti.Columns("CTCLI").Width = 120
            Me.gridContratti.Columns("RASCL").Width = 350
            Me.gridContratti.Columns("CTCAAE").Width = 100

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnProroghe()
        Try
            Me.gridProroghe.Columns("CTSOC").HeaderText = "Soc."
            Me.gridProroghe.Columns("CTNRC").HeaderText = "Contratto"
            Me.gridProroghe.Columns("CTDTD").HeaderText = "Decorrenza"
            Me.gridProroghe.Columns("CTDTS").HeaderText = "Scadenza"
            Me.gridProroghe.Columns("CTNIM").HeaderText = "N. Impianti"
            Me.gridProroghe.Columns("CTCLI").HeaderText = "Cod. Cliente"
            Me.gridProroghe.Columns("RASCL").HeaderText = "Ragione Sociale"
            Me.gridProroghe.Columns("CTNRCTS").HeaderText = "Ctr. Princ."
            Me.gridProroghe.Columns("DESTPCTR").HeaderText = "Tipologia"
            Me.gridProroghe.Columns("CTCAAE").HeaderText = "Importo"

            Me.gridProroghe.Columns("CTSOC").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridProroghe.Columns("CTNRC").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridProroghe.Columns("CTDTD").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridProroghe.Columns("CTDTS").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridProroghe.Columns("CTNIM").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridProroghe.Columns("CTCLI").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridProroghe.Columns("CTNRCTS").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridProroghe.Columns("DESTPCTR").TextAlignment = ContentAlignment.MiddleCenter

            Me.gridProroghe.Columns("CTSOC").ReadOnly = True
            Me.gridProroghe.Columns("CTNRC").ReadOnly = True
            Me.gridProroghe.Columns("CTDTD").ReadOnly = True
            Me.gridProroghe.Columns("CTDTS").ReadOnly = True
            Me.gridProroghe.Columns("CTNIM").ReadOnly = True
            Me.gridProroghe.Columns("CTCLI").ReadOnly = True
            Me.gridProroghe.Columns("RASCL").ReadOnly = True
            Me.gridProroghe.Columns("CTNRCTS").ReadOnly = True
            Me.gridProroghe.Columns("DESTPCTR").ReadOnly = True
            Me.gridProroghe.Columns("CTCAAE").ReadOnly = True

            Me.gridProroghe.Columns("CTDTD").FormatString = "{0:dd/MM/yyyy}"
            Me.gridProroghe.Columns("CTDTS").FormatString = "{0:dd/MM/yyyy}"

            Me.gridProroghe.Columns("CTCAAE").FormatString = "{0:#,##0.00}"

            'Me.gridProroghe.Columns("IMPOSTA").FormatString = "{0:#,##0.00}"


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_proroghe_width()
        Try
            Me.gridProroghe.Columns("CTSOC").Width = 80
            Me.gridProroghe.Columns("CTNRC").Width = 90
            Me.gridProroghe.Columns("CTDTD").Width = 100
            Me.gridProroghe.Columns("CTDTS").Width = 100
            Me.gridProroghe.Columns("CTNIM").Width = 80
            Me.gridProroghe.Columns("CTCLI").Width = 120
            Me.gridProroghe.Columns("RASCL").Width = 350
            Me.gridProroghe.Columns("CTNRCTS").Width = 90
            Me.gridProroghe.Columns("DESTPCTR").Width = 150
            Me.gridProroghe.Columns("CTCAAE").Width = 100
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Async Sub async_carica_griglia_contratti(idaccordo As String, codContratto As String, tipoContratto As String)

        Try
            If formInCaricamento = False Then
                wb.AssociatedControl = gridContratti
                wb.StartWaiting()
                wb.Visible = True
            End If

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoListaContratti))
            elementi = ws.getListaContrattiApplicativi(idaccordo, codContratto, tipoContratto)
            Await elementi

            Select Case tipoContratto
                Case "A"
                    carica_griglia_impianti_contratto(elementi.Result)
                Case Else
                    carica_griglia_proroghe_varianti(elementi.Result)

            End Select


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

    Private Async Sub async_carica_griglia_documenti(codImp As String, anno As String, cliente As String, contratto As String, accordo As String)
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoDocumenti))
            elementi = ws.getDocumentiImpianto(codImp, anno, cliente, accordo, contratto)
            Await elementi

            Me.carica_griglia_documenti(elementi.Result)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub carica_griglia_proroghe_varianti(dati As List(Of elencoListaContratti))
        Try
            gridProroghe.DataSource = dati
            HeaderText_ColumnProroghe()
            HeaderText_Column_proroghe_width()
            Me.gridProroghe.MasterTemplate.ShowFilteringRow = False
            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
        End Try

    End Sub

    Private Sub carica_griglia_impianti_contratto(dati As List(Of elencoListaContratti))
        Try
            gridContratti.DataSource = dati
            HeaderText_ColumnContratti()
            HeaderText_Column_Contratti_width()
            Me.gridContratti.MasterTemplate.ShowFilteringRow = False
            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
        End Try

    End Sub

    Private Sub carica_griglia_documenti(dati As List(Of elencoDocumenti))
        Try

            Me.LoadSummaryPartite()

            gridDoc.DataSource = dati
            Me.HeaderText_ColumnGriglia_documenti(gridDoc)
            'Me.HeaderText_Column_Griglia_tipiVisite_width()
            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

            gridDoc.MasterView.SummaryRows(0).PinPosition = PinnedRowPosition.Bottom
            Me.gridDoc.MasterTemplate.AutoExpandGroups = True

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)

        End Try

    End Sub

    Private Sub HeaderText_ColumnGriglia_documenti(griglia As RadGridView)
        Try
            griglia.Columns("CodiceCliente").HeaderText = "Cod.Cliente"
            griglia.Columns("AnnoDoc").HeaderText = "Anno Doc."
            griglia.Columns("NumDoc").HeaderText = "Num. Doc."
            griglia.Columns("DataDoc").HeaderText = "Data Doc."
            griglia.Columns("Importo").HeaderText = "Importo"
            griglia.Columns("Indirizzo").HeaderText = "Indirizzo"
            griglia.Columns("RagioneSociale").HeaderText = "Ragione Sociale"
            griglia.Columns("Centro").HeaderText = "Centro"
            griglia.Columns("cig").HeaderText = "CIG"
            griglia.Columns("dtnrc").HeaderText = "Contratto"

            griglia.Columns("annodoc").TextAlignment = ContentAlignment.MiddleCenter
            griglia.Columns("numdoc").TextAlignment = ContentAlignment.MiddleCenter
            griglia.Columns("datadoc").TextAlignment = ContentAlignment.MiddleCenter
            griglia.Columns("centro").TextAlignment = ContentAlignment.MiddleCenter
            griglia.Columns("CodiceCliente").TextAlignment = ContentAlignment.MiddleCenter
            griglia.Columns("dtnrc").TextAlignment = ContentAlignment.MiddleCenter
            griglia.Columns("cig").TextAlignment = ContentAlignment.MiddleCenter

            griglia.Columns("AnnoDocInt").IsVisible = False
            griglia.Columns("NumDocInt").IsVisible = False
            griglia.Columns("EDOC_DB").IsVisible = False

            For i = 0 To griglia.Columns.Count - 1
                griglia.Columns(i).ReadOnly = True
            Next

            griglia.Columns("DATADOC").FormatString = "{0:dd/MM/yyyy}"
            griglia.Columns("Importo").FormatString = "{0:#,##0.00}"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub grid_GroupSummaryEvaluate(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GroupSummaryEvaluationEventArgs)
        Try
            'If e.SummaryItem.Name = "DDESCL" Then
            Dim desRiga As String = ""

            If e.SummaryItem.Name.ToUpper = "DTNRC" Then
                'Dim totale As Double = 0
                For Each row As GridViewRowInfo In e.Group
                    If Not row Is Nothing Then
                        desRiga = "contratto n. " & Trim(e.Value.ToString) & " - " & row.Cells("RagioneSociale").Value
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

    Private Sub LoadSummaryPartite()
        Try
            Me.gridDoc.GroupDescriptors.Clear()
            Me.gridDoc.GroupDescriptors.Add(New GridGroupByExpression("DTNRC Group By DTNRC"))

            Dim item1 As New GridViewSummaryRowItem()
            item1.Add(New GridViewSummaryItem("Importo", "{0:F2}", GridAggregateFunction.Sum))

            Me.gridDoc.MasterTemplate.SummaryRowsBottom.Add(item1)
            gridDoc.MasterTemplate.ShowTotals = True

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
                    e.CellElement.ForeColor = Color.FromArgb(100, 119, 130)
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
                e.Row.Height = 50
                If gridContratti.FilterDescriptors.Expression.ToString.ToUpper.Contains(e.CellElement.ColumnInfo.Name) Then
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

    Private Sub grid_CellDoubleClick(sender As Object, e As GridViewCellEventArgs)
        Try
            If e.Column.Name.ToUpper = "CTNRC" Then
                Dim rowInfo As GridViewRowInfo = e.Row

                If Not IsNothing(rowInfo) Then
                    Dim id As String = rowInfo.Cells("CTNRC").Value
                    Dim frm As New FrmContratto(id, "MODIFICA")
                    frm.ShowDialog()
                Else
                    RadMessageBox.Show("Nessun dato da visualizzare.", "Contratto", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridDoc_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles gridDoc.CellDoubleClick
        Try
            If gridDoc.Rows.Count = 0 Then Exit Sub
            Dim sUrl As String

            Dim dbEdoc As String = gridDoc.CurrentRow.Cells("edoc_db").Value
            Dim ndoc As String = gridDoc.CurrentRow.Cells("numdoc").Value
            Dim dtdoc As String = gridDoc.CurrentRow.Cells("datadoc").Value

            Dim cl As New wsEdoc()

            Dim id As String = cl.retrive_documento_EDOC(dbEdoc, "TipoDocumento=014&ND=" & ndoc & "&DD=" & dtdoc)
            If id <> "" Then
                sUrl = "https://srvedoc/EditDocument.aspx?DOC=" & id & "&BD=" & dbEdoc
                Process.Start(sUrl)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdInserisci_Click(sender As Object, e As EventArgs) Handles cmdInserisci.Click
        Try
            Dim frm As New FrmContratto("0", "NUOVO")
            frm.ShowDialog()
        Catch ex As Exception

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

    Private Async Sub SaveAccordo(scheda As elencoAccordi)
        Try
            Dim test As String
            Dim client As New Http.HttpClient

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

            Dim microsoftDateFormatSettings As JsonSerializerSettings = New JsonSerializerSettings With {
                                .DateFormatHandling = DateFormatHandling.MicrosoftDateFormat}



            Dim postContent = JsonConvert.SerializeObject(scheda, microsoftDateFormatSettings)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = My.Settings.urlWS & "/api/Contratti/saveAccordo/postSaveAccordo" '& "?paramList=1234"
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmEntry", postContent)

            Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)



            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

            Dim sStatusCode As String = postResponse.StatusCode.ToString

            If sStatusCode <> "OK" Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio non effettuato. " & vbCrLf & "Causa: " & postResponse.ToString, "Anagrafica impianti", MessageBoxButtons.OK, RadMessageIcon.Info)
            Else
                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio effettuato", "Anagrafica impianti", MessageBoxButtons.OK, RadMessageIcon.Info)
                'idAccordo = sStatusCode
                If postResponse.IsSuccessStatusCode Then
                    Dim S As String = Await postResponse.Content.ReadAsStringAsync()
                    idAccordo = Newtonsoft.Json.JsonConvert.DeserializeObject(Of String)(S)
                    If azione = "NUOVO" Then
                        If idAccordo <> "" Then
                            azione = "MODIFICA"
                            txtID.Text = idAccordo
                            Me.gestisci_campi_form()
                        End If

                    End If
                End If

            End If

        Catch EX As Exception

        End Try
    End Sub

    Private Function move_val_to_file() As elencoAccordi
        Dim sc As New elencoAccordi
        Try

            If azione = "NUOVO" Then
                sc.ID = "0"
            Else
                sc.ID = txtID.Text
            End If

            sc.TIPOACC = ""

            If chkAccordoQuadro.IsChecked = True Then
                sc.TIPOACC = "QUAD"
            End If

            If chkConvenzione.IsChecked = True Then
                sc.TIPOACC = "CONV"
            End If

            If cmbProvenienza.SelectedIndex >= 0 Then
                sc.CDPRV = cmbProvenienza.SelectedValue
            Else
                sc.CDPRV = ""
            End If

            If IsDate(txtDtIniDecor.Text) Then
                Dim aa As Integer = Year(txtDtIniDecor.Value)
                Dim dd As Integer = DateTime.Parse(txtDtIniDecor.Value).Day
                Dim mm As Integer = Month(txtDtIniDecor.Value)
                sc.DTINIZ = New DateTime(aa, mm, dd)
            End If


            'sc.DTINIZ = Format(CDate(txtDtIniDecor.Text), "yyyy-MM-dd")
            If IsDate(txtDtFinDecor.Text) Then
                sc.DTFINE = txtDtFinDecor.Text
            End If

            sc.CDSTIP = txtCodCliente.Text
            sc.DESCR = txtOggetto.Text

            If cmbSocieta.SelectedIndex >= 0 Then
                sc.CDSOC = cmbSocieta.SelectedValue
            Else
                sc.CDSOC = ""
            End If
            sc.CDCLI = ""
            sc.FLRNPRG = "N"
            sc.FLRNTAC = "N"
            sc.NOTE = ""
            sc.CIG = txtCIG.Text
            sc.CUP = txtCUP.Text
            sc.CDCLS = ""
            sc.NRIMP = Val(txtNrImpianti.Text)
            sc.CDCOM = txtCommessa.Text

            If cmbTipoFatt.SelectedIndex >= 0 Then
                sc.CDTPFAT = cmbTipoFatt.SelectedValue
            Else
                sc.CDTPFAT = ""
            End If

            If cmbModPag.SelectedIndex >= 0 Then
                sc.CDPAG = cmbModPag.SelectedValue
            Else
                sc.CDPAG = ""
            End If

            If IsNumeric(txtRitenuta.Text) Then
                sc.PERCRT = txtRitenuta.Text
            Else
                sc.PERCRT = 0
            End If

            If chkIvaRitenuta.Checked = True Then
                sc.FLRTIVA = "S"
            Else
                sc.FLRTIVA = "N"
            End If

            sc.IMPORTO = txtImporto.Text

            If cmbTipoContratto.SelectedIndex >= 0 Then
                sc.TIPOCTR = cmbTipoContratto.SelectedValue
            Else
                sc.TIPOCTR = ""
            End If

            sc.IDACCLI = ""

            Dim lista As New List(Of TipologiaAppalto)
            For j As Integer = 0 To listTipoAppalto.Items.Count - 1
                If listTipoAppalto.Items(j).CheckState = Telerik.WinControls.Enumerations.ToggleState.On Then
                    Dim elemento As New TipologiaAppalto
                    elemento.cdAppalto = listTipoAppalto.Items(j).Value
                    lista.Add(elemento)
                End If
            Next j

            sc.listaTipoApplato = lista

            Dim listaprs As New List(Of prestazioniAccordo)
            For j As Integer = 0 To listPrestazioni.Items.Count - 1
                If listPrestazioni.Items(j).CheckState = Telerik.WinControls.Enumerations.ToggleState.On Then
                    Dim elemento As New prestazioniAccordo
                    elemento.cdPrestazione = listPrestazioni.Items(j).Value
                    listaprs.Add(elemento)
                End If
            Next j

            sc.listaPrestazioni = listaprs

            Return sc

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub cmdConferma_Click(sender As Object, e As EventArgs) Handles cmdConferma.Click
        If controlli_form() = True Then
            Me.start_saveData(azione)

        End If
    End Sub

    Private Async Sub start_saveData(azione As String)
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            Dim scheda As New elencoAccordi
            scheda = Me.move_val_to_file
            If Not IsNothing(scheda) Then
                Dim response As String = Await controlla_dati(scheda, azione)
                If response.Contains("Errore:") Then
                    Telerik.WinControls.RadMessageBox.Show(Me, "Errori riscontrati: " & vbCrLf & response, "Gestione accordo", MessageBoxButtons.OK, RadMessageIcon.Error)

                ElseIf response = "OK" Then
                    Me.SaveAccordo(scheda)
                    'Me.Close()
                Else
                    Dim dr As DialogResult = RadMessageBox.Show(response & vbCrLf & "Continuare?", "Gestione accordo", MessageBoxButtons.YesNo, RadMessageIcon.Question)
                    If dr = DialogResult.No Then
                        Exit Sub
                    Else
                        Me.SaveAccordo(scheda)
                        'Me.Close()
                    End If
                End If
            Else
                Telerik.WinControls.RadMessageBox.Show(Me, "Errori riscontrati in fase di assegnazione dati scheda accordo ", "Gestione accordo", MessageBoxButtons.OK, RadMessageIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function controlli_form() As Boolean
        Try
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function



    Private Async Function controlla_dati(accordo As elencoAccordi, azione As String) As Threading.Tasks.Task(Of String)
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            Dim client As New Http.HttpClient
            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

            Dim postContent = jss.Serialize(accordo)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = My.Settings.urlWS & "api/Contratti/controlloAccordoLiv1/controlloAccordoLiv1"
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("parmAccordo", postContent)
            client.DefaultRequestHeaders.Add("parmAzione", azione)

            Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)


            Dim sStatusCode As String = postResponse.StatusCode.ToString

            If sStatusCode.ToUpper <> "OK" Then
                Dim msg As String = postResponse.Headers.GetValues("Error").FirstOrDefault()
                Return msg.Replace("%0d%0a", vbCrLf)
            Else
                Return "OK"
            End If

        Catch EX As Exception
            Return "Errore: " & EX.Message
        End Try

    End Function

End Class

