Imports System.Data.OleDb
Imports System.Net
Imports System.Reflection
Imports Newtonsoft.Json
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Text
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports Telerik.WinControls.Data
Imports System.ComponentModel
Imports Telerik.WinControls.UI.Map.Bing
Imports Telerik.WinControls.UI.Map
Imports Telerik.Charting

Public Class FrmImpianto

    Private idImpianto As String
    Private bListaCaricata As Boolean
    Private ws As New webServices
    Private schedaImpianto As Threading.Tasks.Task(Of parmGetSchedaImpianto)

    Dim vals As New List(Of parmTabelle)
    Dim myLista As New List(Of parmTabelle)
    Dim azione As String
    Dim azioneVisiteAsset As String
    Dim azioneAsset As String

    Dim statoCaricaCategorie As Boolean
    Dim statoCaricaEntiCollaud As Boolean
    Dim statoCaricaEntiIspettivi As Boolean
    Dim statoCaricaCostruttori As Boolean
    Dim statoCaricaStrade As Boolean
    Dim statoCaricaTipoImpianto As Boolean
    Dim statoCaricaTipoImp As Boolean
    Dim statoCaricaReperib As Boolean
    Dim statoCaricaCallCenter As Boolean

    Private smartLabelsController As SmartLabelsController

    Public Sub New(codImpianto As String, ByVal inAzione As String, Optional ByVal ElencoCentri As String = "", Optional ByVal inUser As String = "", Optional ByVal inRuolo As String = "", Optional ByVal inUserAS As String = "", Optional ByVal modifica As Boolean = True, Optional ByVal testo As String = "")
        InitializeComponent()
        WireEvents()

        idImpianto = codImpianto
        azione = inAzione

        'ruolo = inRuolo
        'user = inUser
        'userAS = inUserAS
        'gElencoCentri = ElencoCentri
    End Sub

    Private Sub FrmImpianto_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            cmdOkSearchCli.ThemeName = "buttonDFT"
            cmdOkSearchLoc.ThemeName = "buttonDFT"
            cmdConferma.ThemeName = "buttonBLU"
            cmdSalvaTpVis.ThemeName = "buttonBLU"
            cmdSalvaPianA.ThemeName = "buttonDFT"
            cmdAnnulla.ThemeName = "buttonDFT"
            cmdAnnPianA.ThemeName = "buttonDFT"
            cmdAnnullaAss.ThemeName = "buttonDFT"
            cmdConfermaAss.ThemeName = "buttonDFT"

            wbG.AssociatedControl = Me
            wbG.StartWaiting()
            wbG.Visible = True

            t1.Enabled = True

            Dim stripElement As RadPageViewStripElement = DirectCast(Me.RPcontainer.ViewElement, RadPageViewStripElement)
            stripElement.StripButtons = StripViewButtons.None
            Dim stripElementDett As RadPageViewStripElement = DirectCast(Me.pageDett.ViewElement, RadPageViewStripElement)
            stripElementDett.StripButtons = StripViewButtons.None

            'Me.gant.GanttViewElement.GraphicalViewElement.TimelineRange = TimeRange.Year
            ''Me.gant.GanttViewElement.GraphicalViewElement.OnePixelTime = New TimeSpan(0, 60, 0)
            'Me.gant.GanttViewElement.GraphicalViewElement.OnePixelTime = New TimeSpan(0, 300, 0)
            'Me.test_gantt()

            Me.chartFatturato.Title = "OFFERTE EMESSE"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Protected Sub WireEvents()
        AddHandler grid.ViewCellFormatting, AddressOf gridFatt_ViewCellFormatting
        AddHandler grid.ViewRowFormatting, AddressOf gridFatt_ViewRowFormatting
        AddHandler grid.CellFormatting, AddressOf gridFatt_CellFormatting
        AddHandler grid.ContextMenuOpening, AddressOf gridFatt_ContextMenuOpening
        AddHandler grid.GroupSummaryEvaluate, AddressOf grid_GroupSummaryEvaluate
        AddHandler grid.EditorRequired, AddressOf grid_EditorRequired

        AddHandler gridAsset.ContextMenuOpening, AddressOf gridFatt_ContextMenuOpening
        AddHandler gridAsset.ViewCellFormatting, AddressOf gridFatt_ViewCellFormatting
        AddHandler gridAsset.CellFormatting, AddressOf gridFatt_CellFormatting
        AddHandler gridAsset.ViewRowFormatting, AddressOf gridFatt_ViewRowFormatting
        AddHandler gridAsset.CurrentRowChanged, AddressOf gridAsset_CurrentRowChanged

        AddHandler gridTecAsset.ViewCellFormatting, AddressOf gridFatt_ViewCellFormatting
        AddHandler gridTecAsset.ViewRowFormatting, AddressOf gridFatt_ViewRowFormatting
        AddHandler gridTecAsset.CellFormatting, AddressOf gridFatt_CellFormatting
        AddHandler gridTecAsset.ContextMenuOpening, AddressOf gridFatt_ContextMenuOpening
        AddHandler gridTecAsset.GroupSummaryEvaluate, AddressOf grid_GroupSummaryEvaluate

        AddHandler gridTpVis.CurrentRowChanged, AddressOf gridTpVis_CurrentRowChanged

        AddHandler Me.gant.GanttViewElement.ItemEditing, AddressOf GanttViewElement_ItemEditing
        AddHandler Me.gant.TextViewItemFormatting, AddressOf radGanttView_TextViewItemFormatting
        AddHandler Me.gant.TextViewCellFormatting, AddressOf radGanttView_TextViewCellFormatting


    End Sub


    'Private Sub FrmImpianto_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    Try
    '        cmdOkSearchCli.ThemeName = "buttonDFT"
    '        cmdOkSearchLoc.ThemeName = "buttonDFT"
    '        cmdConferma.ThemeName = "buttonBLU"
    '        cmdAnnulla.ThemeName = "buttonDFT"

    '        Dim stripElement As RadPageViewStripElement = DirectCast(Me.RPcontainer.ViewElement, RadPageViewStripElement)
    '        stripElement.StripButtons = StripViewButtons.None
    '        Dim stripElementDett As RadPageViewStripElement = DirectCast(Me.pageDett.ViewElement, RadPageViewStripElement)
    '        stripElementDett.StripButtons = StripViewButtons.None

    '    Catch ex As Exception
    '        MsgBox(ex.Message, vbCritical, "Load")
    '    End Try

    'End Sub

    Private Sub FrmImpianto_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try

            Me.gestisci_campi_form()

            If azione = "NUOVO" Then
                Me.azzera_campi_form()
                Me.carica_dati_liste()
            Else
                Me.async_carica_scheda_impianto()
            End If

            AddHandler cmbCategoriaImp.SelectedValueChanged, AddressOf cmbCategoriaImp_SelectedValueChanged

        Catch ex As Exception
            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False

            wbA.AssociatedControl = Nothing
            wbA.StopWaiting()
            wbA.Visible = False

            wbAT.AssociatedControl = Nothing
            wbAT.StopWaiting()
            wbAT.Visible = False

            wbG.AssociatedControl = Nothing
            wbG.StopWaiting()
            wbG.Visible = False

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
                    txtCodice.ReadOnly = True
                    'cmbTipoImpianto.ReadOnly = True
                    cmbTipoImp.ReadOnly = True
                    cmbCategoriaImp.ReadOnly = True
                    For Each pag As RadPageViewPage In RPcontainer.Pages
                        pag.Item.Visibility = ElementVisibility.Visible
                    Next
            End Select
        Catch ex As Exception

        End Try
    End Sub


    Private Sub carica_dati_liste()
        Try

            carica_combo_categorie()
            carica_combo_enti_ispettivi()
            carica_combo_enti_collaudatori()
            carica_combo_costruttori()
            carica_combo_strade()
            carica_combo_TipoImpianto()
            carica_combo_TipoImp()
            carica_combo_reperibilita()
            carica_combo_callCenter()
            carica_liste_elementi_dati_tecnici()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub carica_dati_form(dati As parmGetSchedaImpianto)
        Try
            txtCodice.Text = dati.AICIM
            txtCodCliente.Text = dati.AICLI
            txtIndirizzo.Text = dati.AIIND
            txtCap.Text = Format(Val(dati.AICAP), "00000")
            txtCodAmm.Text = dati.AIAMM
            txtProv.Text = dati.AISPR
            'cmbStrada.SelectedValue = dati.AISTR
            'cmbCategoriaImp.SelectedValue = dati.AICCI
            'cmbTipoImpianto.SelectedValue = dati.AICTI
            'cmbTipoImp.SelectedValue = dati.AIFLL
            txtDesCli.Text = dati.DESCLI
            txtDesAmm.Text = dati.DESAMM
            txtlocalita.Text = dati.AILOC
            'carica_griglia_dati_Tecnici(dati.datiTecnici)
            async_carica_griglia_asset_impianto()
            async_carica_griglia_documenti(dati.AICIM, "")
            async_carica_gantt_manutenzioni(dati.AICIM)
            async_carica_grafico_manutenzioni(dati.AICIM)
            async_carica_grafico_buoni(dati.AICIM)
            async_carica_grafico_canoni(dati.AICIM)
            async_carica_grafico_fatturato(dati.AICIM, "")
            async_carica_grafico_chiamate(dati.AICIM)
            'MAPPA
            ''''SetupProviders()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub azzera_campi_form()
        Try
            txtCodice.Text = ""
            txtCodCliente.Text = ""
            txtIndirizzo.Text = ""
            txtCap.Text = ""
            txtCodAmm.Text = ""
            txtDesCli.Text = ""
            txtDesAmm.Text = ""
            txtlocalita.Text = ""
            txtZonaRep.Text = ""
            txtGestore.Text = ""
            txtTelesoccorso.Text = ""
            txtMatricola.Text = ""
            txtScala.Text = ""
            txtEdificio.Text = ""
            txtInterno.Text = ""
            txtDataNomina.Text = Nothing

            cmbTecnico.SelectedIndex = -1
            cmbZonaCentro.SelectedIndex = -1
            cmbStrada.SelectedIndex = -1
            cmbCategoriaImp.SelectedIndex = -1
            cmbTipoImpianto.SelectedIndex = -1
            cmbTipoImp.SelectedIndex = -1
            cmbReperib.SelectedIndex = -1
            cmbCallCenter.SelectedIndex = -1
            cmbEnteColl.SelectedIndex = -1
            cmbEnteIsp.SelectedIndex = -1
            cmbCostruttore.SelectedIndex = -1
            cmbZona.SelectedIndex = -1

            chkLineaNsCarico.Checked = CheckState.Unchecked
            chkTag.Checked = CheckState.Unchecked

        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub carica_combo_categorie()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("CCI", "")
            Await elementi

            Me.cmbCategoriaImp.DataSource = elementi.Result
            Me.cmbCategoriaImp.DisplayMember = "desElem"
            Me.cmbCategoriaImp.ValueMember = "codElem"
            Me.cmbCategoriaImp.SelectedIndex = -1

            If azione = "MODIFICA" Then
                cmbCategoriaImp.SelectedValue = schedaImpianto.Result.AICCI
            End If

            statoCaricaCategorie = True

        Catch ex As Exception
            statoCaricaCategorie = True
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_strade()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("STR", "")
            Await elementi

            Me.cmbStrada.DataSource = elementi.Result
            Me.cmbStrada.DisplayMember = "desElem"
            Me.cmbStrada.ValueMember = "codElem"
            Me.cmbStrada.SelectedIndex = -1

            If azione = "MODIFICA" Then
                cmbStrada.SelectedValue = schedaImpianto.Result.AISTR
            End If

            statoCaricaStrade = True
        Catch ex As Exception
            statoCaricaStrade = True
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_enti_ispettivi()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("CEC", "")
            Await elementi

            Me.cmbEnteIsp.DataSource = elementi.Result
            Me.cmbEnteIsp.DisplayMember = "desElem"
            Me.cmbEnteIsp.ValueMember = "codElem"
            Me.cmbEnteIsp.SelectedIndex = -1

            statoCaricaEntiIspettivi = True

        Catch ex As Exception
            statoCaricaEntiIspettivi = True
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_enti_collaudatori()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("CEC", "")
            Await elementi

            Me.cmbEnteColl.DataSource = elementi.Result
            Me.cmbEnteColl.DisplayMember = "desElem"
            Me.cmbEnteColl.ValueMember = "codElem"
            Me.cmbEnteColl.SelectedIndex = -1

            statoCaricaEntiCollaud = True

        Catch ex As Exception
            statoCaricaEntiCollaud = True
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_costruttori()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("CCO", "")
            Await elementi

            Me.cmbCostruttore.DataSource = elementi.Result
            Me.cmbCostruttore.DisplayMember = "desElem"
            Me.cmbCostruttore.ValueMember = "codElem"
            Me.cmbCostruttore.SelectedIndex = -1

            statoCaricaCostruttori = True

        Catch ex As Exception
            statoCaricaCostruttori = True
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_TipoImpianto()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("CTI", "")
            Await elementi

            Me.cmbTipoImpianto.DataSource = elementi.Result
            Me.cmbTipoImpianto.DisplayMember = "desElem"
            Me.cmbTipoImpianto.ValueMember = "codElem"
            Me.cmbTipoImpianto.SelectedIndex = -1

            If azione = "MODIFICA" Then
                cmbTipoImpianto.SelectedValue = schedaImpianto.Result.AICTI
            End If

            statoCaricaTipoImpianto = True

        Catch ex As Exception
            statoCaricaTipoImpianto = True
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_TipoImp()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("TIM", "")
            Await elementi

            Me.cmbTipoImp.DataSource = elementi.Result
            Me.cmbTipoImp.DisplayMember = "desElem"
            Me.cmbTipoImp.ValueMember = "codElem"
            Me.cmbTipoImp.SelectedIndex = -1

            If azione = "MODIFICA" Then
                cmbTipoImp.SelectedValue = schedaImpianto.Result.AIFLL
            End If

            statoCaricaTipoImp = True

        Catch ex As Exception
            statoCaricaTipoImp = True
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_callCenter()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("CLL", "")
            Await elementi

            Me.cmbCallCenter.DataSource = elementi.Result
            Me.cmbCallCenter.DisplayMember = "desElem"
            Me.cmbCallCenter.ValueMember = "codElem"
            Me.cmbCallCenter.SelectedIndex = -1

            statoCaricaCallCenter = True

        Catch ex As Exception
            statoCaricaCallCenter = True
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
    Private Async Sub carica_combo_comuniIT()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmComuni())
            elementi = ws.getDatiTabellaComuniIT("", txtlocalita.Text)
            Await elementi

            Me.cmbLoc.Columns.Clear()
            cmbLoc.MultiColumnComboBoxElement.DropDownAnimationEnabled = False

            Me.cmbLoc.AutoSizeDropDownToBestFit = True
            Dim multiColumnComboElement As RadMultiColumnComboBoxElement = Me.cmbLoc.MultiColumnComboBoxElement
            multiColumnComboElement.DropDownSizingMode = SizingMode.UpDownAndRightBottom
            multiColumnComboElement.DropDownMinSize = New Size(420, 300)
            multiColumnComboElement.EditorControl.MasterTemplate.AutoGenerateColumns = False

            Dim column = New GridViewTextBoxColumn("localita")
            column.HeaderText = "Località"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("prov")
            column.HeaderText = "PROV"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("cap")
            column.HeaderText = "CAP"
            multiColumnComboElement.Columns.Add(column)

            Me.cmbLoc.DisplayMember = "localita"
            Me.cmbLoc.ValueMember = "localita"
            Me.cmbLoc.DataSource = elementi.Result

            Me.cmbLoc.AutoFilter = True
            Dim compositeFilter As New CompositeFilterDescriptor()
            Dim loc As New FilterDescriptor("localita", FilterOperator.Contains, "")
            Dim cap As New FilterDescriptor("CAP", FilterOperator.Contains, "")
            'Dim prov As New FilterDescriptor("PROV", FilterOperator.Contains, "")

            compositeFilter.FilterDescriptors.Add(loc)
            compositeFilter.FilterDescriptors.Add(cap)
            'compositeFilter.FilterDescriptors.Add(prov)

            compositeFilter.LogicalOperator = FilterLogicalOperator.[Or]
            Me.cmbLoc.EditorControl.FilterDescriptors.Add(compositeFilter)

            Me.cmbLoc.SelectedIndex = -1

            cmbLoc.Visible = True
            txtlocalita.Visible = False
            cmbLoc.Focus()
            cmbLoc.MultiColumnComboBoxElement.ShowPopup()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_clienti()
        Try
            Dim elementi As Threading.Tasks.Task(Of elencoClienti())
            elementi = ws.getDatiTabellaClienti("", txtCodCliente.Text)
            Await elementi

            Me.cmbClienti.Columns.Clear()
            cmbClienti.MultiColumnComboBoxElement.DropDownAnimationEnabled = False

            Me.cmbClienti.AutoSizeDropDownToBestFit = True
            Dim multiColumnComboElement As RadMultiColumnComboBoxElement = Me.cmbClienti.MultiColumnComboBoxElement
            multiColumnComboElement.DropDownSizingMode = SizingMode.UpDownAndRightBottom
            multiColumnComboElement.DropDownMinSize = New Size(420, 300)
            multiColumnComboElement.EditorControl.MasterTemplate.AutoGenerateColumns = False

            Dim column = New GridViewTextBoxColumn("CDCLI")
            column.HeaderText = "Cd. Cliente"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("RASCL")
            column.HeaderText = "Ragione Sociale"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("INDCL")
            column.HeaderText = "Indirizzo"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("CDFIS")
            column.HeaderText = "Codice Fiscale"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("CPAIV")
            column.HeaderText = "Partita Iva"
            multiColumnComboElement.Columns.Add(column)


            Me.cmbClienti.DisplayMember = "RASCL"
            Me.cmbClienti.ValueMember = "CDCLI"
            Me.cmbClienti.DataSource = elementi.Result

            Me.cmbClienti.AutoFilter = True
            Dim compositeFilter As New CompositeFilterDescriptor()
            Dim rascl As New FilterDescriptor("RASCL", FilterOperator.Contains, "")
            Dim cdcli As New FilterDescriptor("CDCLI", FilterOperator.Contains, "")
            Dim cpaiv As New FilterDescriptor("CPAIV", FilterOperator.Contains, "")
            Dim cdfis As New FilterDescriptor("CDFIS", FilterOperator.Contains, "")
            Dim indcl As New FilterDescriptor("INDCL", FilterOperator.Contains, "")

            compositeFilter.FilterDescriptors.Add(rascl)
            compositeFilter.FilterDescriptors.Add(cdcli)
            compositeFilter.FilterDescriptors.Add(cdfis)
            compositeFilter.FilterDescriptors.Add(cpaiv)
            compositeFilter.FilterDescriptors.Add(indcl)

            compositeFilter.LogicalOperator = FilterLogicalOperator.[Or]
            Me.cmbClienti.EditorControl.FilterDescriptors.Add(compositeFilter)

            Me.cmbClienti.SelectedIndex = -1

            cmbClienti.Visible = True
            txtCodCliente.Visible = False
            cmbClienti.Focus()
            cmbClienti.MultiColumnComboBoxElement.ShowPopup()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub


    Private Async Sub carica_combo_reperibilita()
        Try
            Dim elementi As Threading.Tasks.Task(Of elencoReperibilita())
            elementi = ws.getTabellaReperibilita("", "")
            Await elementi

            Me.cmbReperib.Columns.Clear()
            cmbReperib.MultiColumnComboBoxElement.DropDownAnimationEnabled = False

            Me.cmbReperib.AutoSizeDropDownToBestFit = True
            Dim multiColumnComboElement As RadMultiColumnComboBoxElement = Me.cmbReperib.MultiColumnComboBoxElement
            multiColumnComboElement.DropDownSizingMode = SizingMode.UpDownAndRightBottom
            multiColumnComboElement.DropDownMinSize = New Size(420, 300)
            multiColumnComboElement.EditorControl.MasterTemplate.AutoGenerateColumns = False

            Dim column = New GridViewTextBoxColumn("RPCCE")
            column.HeaderText = "Centro"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("RPZON")
            column.HeaderText = "Zona"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("RPTF1")
            column.HeaderText = "Num Tel. 1"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("RPTF2")
            column.HeaderText = "Num. Tel. 2"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("RPTF3")
            column.HeaderText = "Num. Tel. 3"
            multiColumnComboElement.Columns.Add(column)

            Me.cmbReperib.DisplayMember = "RPCCE"
            Me.cmbReperib.ValueMember = "RPCCE"
            Me.cmbReperib.DataSource = elementi.Result

            Me.cmbReperib.AutoFilter = True
            Dim compositeFilter As New CompositeFilterDescriptor()
            Dim rpcce As New FilterDescriptor("RPCCE", FilterOperator.Contains, "")
            Dim rpzon As New FilterDescriptor("RPZON", FilterOperator.Contains, "")
            Dim rptf1 As New FilterDescriptor("RPTF1", FilterOperator.Contains, "")
            Dim rptf2 As New FilterDescriptor("RPTF2", FilterOperator.Contains, "")
            Dim rptf3 As New FilterDescriptor("RPTF3", FilterOperator.Contains, "")

            compositeFilter.FilterDescriptors.Add(rpcce)
            compositeFilter.FilterDescriptors.Add(rpzon)
            compositeFilter.FilterDescriptors.Add(rptf1)
            compositeFilter.FilterDescriptors.Add(rptf2)
            compositeFilter.FilterDescriptors.Add(rptf3)

            compositeFilter.LogicalOperator = FilterLogicalOperator.[Or]
            Me.cmbReperib.EditorControl.FilterDescriptors.Add(compositeFilter)

            Me.cmbReperib.SelectedIndex = -1

            cmbReperib.Focus()
            'cmbReperib.MultiColumnComboBoxElement.ShowPopup()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub carica_griglia_datiTecnici_assets(elelncoDatiTecniciAssets() As datiTecnici)
        Try

            gridTecAsset.DataSource = elelncoDatiTecniciAssets
            Me.HeaderText_ColumnGriglia_datiTecniciAsset(gridTecAsset)
            Me.HeaderText_Column_Griglia_datiTecniciAsset_width(gridTecAsset)

            Me.gridTecAsset.GroupDescriptors.Clear()
            Dim descriptor As New GroupDescriptor()
            descriptor.GroupNames.Add("DESGRUPPO", ListSortDirection.Ascending)
            Me.gridTecAsset.GroupDescriptors.Add(descriptor)

            Me.gridTecAsset.MasterTemplate.ShowFilteringRow = False
            Me.gridTecAsset.MasterTemplate.AutoExpandGroups = True

            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)

        End Try

    End Sub

    Private Async Sub carica_combo_tipi_visite(codCat As String, Optional cdimp As String = "", Optional cdasset As String = "")
        Try
            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoManutDefault))
            elementi = ws.getManutenzioniDefault(cdimp, codCat, cdasset)
            Await elementi

            Me.cmbTipiVis.Columns.Clear()
            cmbTipiVis.MultiColumnComboBoxElement.DropDownAnimationEnabled = False

            Me.cmbTipiVis.AutoSizeDropDownToBestFit = True
            Dim multiColumnComboElement As RadMultiColumnComboBoxElement = Me.cmbTipiVis.MultiColumnComboBoxElement
            multiColumnComboElement.DropDownSizingMode = SizingMode.UpDownAndRightBottom
            multiColumnComboElement.DropDownMinSize = New Size(420, 300)
            multiColumnComboElement.EditorControl.MasterTemplate.AutoGenerateColumns = False

            Dim column = New GridViewTextBoxColumn("CodiceVisita")
            column.HeaderText = "Cd. Visita"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("DescrVisita")
            column.HeaderText = "Descrizione"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("FlagVisCiclica")
            column.HeaderText = "Ciclica"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("flagVisOrdinaria")
            column.HeaderText = "Ord."
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("flagVisSemestrale")
            column.HeaderText = "Sem."
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("flagVisStagionale")
            column.HeaderText = "Stag."
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("flagVisOblig")
            column.HeaderText = "Obl."
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("flagUltimaDataVisita")
            column.HeaderText = "dt.Vis."
            multiColumnComboElement.Columns.Add(column)

            Me.cmbTipiVis.DisplayMember = "DescrVisita"
            Me.cmbTipiVis.ValueMember = "CodiceVisita"
            Me.cmbTipiVis.DataSource = elementi.Result

            Me.cmbTipiVis.AutoFilter = True
            Dim compositeFilter As New CompositeFilterDescriptor()
            Dim rascl As New FilterDescriptor("CodiceVisita", FilterOperator.Contains, "")
            Dim cdcli As New FilterDescriptor("DEscrVisita", FilterOperator.Contains, "")

            compositeFilter.FilterDescriptors.Add(rascl)
            compositeFilter.FilterDescriptors.Add(cdcli)

            compositeFilter.LogicalOperator = FilterLogicalOperator.[Or]
            Me.cmbTipiVis.EditorControl.FilterDescriptors.Add(compositeFilter)

            Me.cmbTipiVis.SelectedIndex = -1

            carica_dati_visite_asset(azioneVisiteAsset)

            'cmbTipiVis.Focus()
            'cmbClienti.MultiColumnComboBoxElement.ShowPopup()

            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False

        Catch ex As Exception
            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False

            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_Assets(codCat)
        Try
            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            Dim elementi As Threading.Tasks.Task(Of elencoAssetsImpianto())
            elementi = ws.carica_lista_assets(codCat)
            Await elementi

            Me.cmbAssets.Columns.Clear()
            cmbAssets.MultiColumnComboBoxElement.DropDownAnimationEnabled = False

            Me.cmbAssets.AutoSizeDropDownToBestFit = True
            Dim multiColumnComboElement As RadMultiColumnComboBoxElement = Me.cmbAssets.MultiColumnComboBoxElement
            multiColumnComboElement.DropDownSizingMode = SizingMode.UpDownAndRightBottom
            multiColumnComboElement.DropDownMinSize = New Size(420, 300)
            multiColumnComboElement.EditorControl.MasterTemplate.AutoGenerateColumns = False

            Dim column = New GridViewTextBoxColumn("CHID")
            column.HeaderText = "ID"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("CHDESCR")
            column.HeaderText = "Descrizione"
            multiColumnComboElement.Columns.Add(column)

            Me.cmbAssets.DisplayMember = "CHDESCR"
            Me.cmbAssets.ValueMember = "CHID"
            Me.cmbAssets.DataSource = elementi.Result

            Me.cmbAssets.AutoFilter = True
            Dim compositeFilter As New CompositeFilterDescriptor()
            Dim id As New FilterDescriptor("CHID", FilterOperator.Contains, "")
            Dim descr As New FilterDescriptor("CHDESCR", FilterOperator.Contains, "")

            compositeFilter.FilterDescriptors.Add(id)
            compositeFilter.FilterDescriptors.Add(descr)

            compositeFilter.LogicalOperator = FilterLogicalOperator.[Or]
            Me.cmbAssets.EditorControl.FilterDescriptors.Add(compositeFilter)

            Me.cmbAssets.SelectedIndex = -1

            'cmbAssets.Focus()
            'cmbClienti.MultiColumnComboBoxElement.ShowPopup()

            carica_dati_asset(azioneAsset)

            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False

        Catch ex As Exception
            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False

            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub cmdOkSearchCli_Click(sender As Object, e As EventArgs) Handles cmdOkSearchCli.Click
        Try
            If txtCodCliente.Text.Trim.Length >= 3 Then
                Me.carica_combo_clienti()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbClienti_LostFocus(sender As Object, e As EventArgs) Handles cmbClienti.LostFocus
        seleziona_cliente()
    End Sub

    Private Sub seleziona_cliente()
        Try
            If cmbClienti.Visible = False Then
                Exit Sub
            End If

            If cmbClienti.SelectedIndex >= 0 Then
                Dim value As Object = cmbClienti.EditorControl.Rows(cmbClienti.SelectedIndex).Cells("RASCL").Value
                txtCodCliente.Text = cmbClienti.SelectedValue.ToString
                txtDesCli.Text = value.ToString
            Else
                txtCodCliente.Text = ""
                txtDesCli.Text = ""
            End If

            cmbClienti.Visible = False
            txtCodCliente.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbClienti_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbClienti.SelectedValueChanged
        seleziona_cliente()
    End Sub

    Private Sub seleziona_reperibilita()
        Try

            If cmbReperib.SelectedIndex >= 0 Then
                Dim value As Object = cmbReperib.EditorControl.Rows(cmbReperib.SelectedIndex).Cells("RPZON").Value
                txtZonaRep.Text = value
            Else
                txtZonaRep.Text = ""
            End If

        Catch ex As Exception
            txtZonaRep.Text = ""
        End Try
    End Sub

    Private Sub cmbReperib_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbReperib.SelectedValueChanged
        seleziona_reperibilita()
    End Sub

    Private Sub cmbTipoImp_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoImp.SelectedValueChanged

    End Sub


    Private Sub cmdOkSearchLoc_Click(sender As Object, e As EventArgs) Handles cmdOkSearchLoc.Click
        Try
            If txtlocalita.Text.Trim.Length >= 3 Then
                Me.carica_combo_comuniIT()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub seleziona_localita()
        Try
            If cmbLoc.Visible = False Then
                Exit Sub
            End If

            If cmbLoc.SelectedIndex >= 0 Then
                Dim value As Object = cmbLoc.EditorControl.Rows(cmbLoc.SelectedIndex).Cells("LOCALITA").Value
                Dim PRV As Object = cmbLoc.EditorControl.Rows(cmbLoc.SelectedIndex).Cells("PROV").Value
                Dim CAP As Object = cmbLoc.EditorControl.Rows(cmbLoc.SelectedIndex).Cells("CAP").Value
                txtlocalita.Text = cmbLoc.SelectedValue.ToString
                txtCap.Text = CAP.ToString
                txtProv.Text = PRV.ToString
            Else
                txtlocalita.Text = ""
                txtCap.Text = ""
                txtProv.Text = ""
            End If

            cmbLoc.Visible = False
            txtlocalita.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub async_carica_griglia_asset_impianto()
        Try

            'wbG.AssociatedControl = Me
            'wbG.StartWaiting()
            'wbG.Visible = True

            Dim elementi As Threading.Tasks.Task(Of elencoAssetsImpianto())
            elementi = ws.carica_assets_impianto(idImpianto)
            Await elementi

            carica_griglia_assets_impianto(elementi.Result)

            'wbG.StopWaiting()
            'wbG.AssociatedControl = Nothing
            'wbG.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            'wbA.StopWaiting()
            'wbA.AssociatedControl = Nothing
            'wbA.Visible = False

            'wbG.AssociatedControl = Nothing
            'wbG.StopWaiting()
            'wbG.Visible = False

        End Try
    End Sub

    Private Async Sub async_carica_griglia_DatiTecnici_asset_impianto(IdAsset As String, CodImp As String)
        Try
            wbAT.AssociatedControl = gridTecAsset
            wbAT.StartWaiting()
            wbAT.Visible = True

            Dim elementi As Threading.Tasks.Task(Of datiTecnici())
            elementi = ws.getDatiTecniciAsset(IdAsset, CodImp)
            Await elementi

            carica_griglia_datiTecnici_assets(elementi.Result)

            wbAT.StopWaiting()
            wbAT.AssociatedControl = Nothing
            wbAT.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            wbAT.StopWaiting()
            wbAT.AssociatedControl = Nothing
            wbAT.Visible = False
        End Try
    End Sub

    Private Sub carica_griglia_assets_impianto(elencoAssets() As elencoAssetsImpianto)
        Try

            gridAsset.DataSource = elencoAssets
            Me.HeaderText_ColumnGriglia_assets()
            Me.HeaderText_Column_Griglia_assets_width()

            Me.gridAsset.MasterTemplate.ShowFilteringRow = False
            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)

        End Try

    End Sub

    Private Sub carica_griglia_dati_Tecnici(dati As List(Of datiTecnici))
        Try

            grid.DataSource = dati
            Me.HeaderText_ColumnGriglia(grid)
            Me.HeaderText_Column_Griglia_width(grid)

            Me.grid.GroupDescriptors.Clear()
            Dim descriptor As New GroupDescriptor()
            descriptor.GroupNames.Add("DESGRUPPO", ListSortDirection.Ascending)
            Me.grid.GroupDescriptors.Add(descriptor)

            Me.grid.MasterTemplate.ShowFilteringRow = False
            Me.grid.MasterTemplate.AutoExpandGroups = True
            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)

        End Try

    End Sub

    Private Async Sub async_carica_scheda_impianto()
        Try
            wb.AssociatedControl = grid
            wb.StartWaiting()
            wb.Visible = True

            txtCodice.ReadOnly = True
            cmbTipoImp.ReadOnly = True

            schedaImpianto = ws.getSchedaImpianto(idImpianto)
            Await schedaImpianto
            Me.carica_dati_liste()
            carica_dati_form(schedaImpianto.Result)


            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False
        End Try
    End Sub

    Private Async Sub async_carica_griglia_datitecnici_impianto(codImp As String, codCat As String)
        Try
            wb.AssociatedControl = grid
            wb.StartWaiting()
            wb.Visible = True

            Dim elementi As Threading.Tasks.Task(Of List(Of datiTecnici))
            elementi = ws.getDatiTecniciImpianto(codImp, codCat)
            Await elementi

            carica_griglia_dati_Tecnici(elementi.Result)

            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False
        End Try
    End Sub

    Private Async Sub async_carica_griglia_tipi_visite(codImp As String, codCat As String)
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoManutDefault))
            elementi = ws.getManutenzioniDefault(codImp, codCat)
            Await elementi

            Me.carica_griglia_tipi_visite(elementi.Result)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Async Sub async_carica_griglia_tipi_visite_asset(codImp As String, codCat As String, codAss As String)
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoManutDefault))
            elementi = ws.getManutenzioniDefault(codImp, codCat, codAss)
            Await elementi

            Me.carica_griglia_tipi_visiteAsset(elementi.Result)


        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Async Sub async_carica_griglia_tasks(codVis As String, codCat As String)
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoTasksVisita))
            elementi = ws.getElencoTasks(codCat, codVis)
            Await elementi

            Me.carica_griglia_tasks(elementi.Result)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Async Sub async_carica_gantt_manutenzioni(codImp As String)
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoManutenzioni))
            elementi = ws.getManutenzioniElenco(codImp)
            Await elementi

            Me.carica_gantt_visite(elementi.Result)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Async Sub async_carica_grafico_manutenzioni(codImp As String, Optional livello As Integer = 0)
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of statManutenzioni))
            elementi = ws.getStatManutenzioni(codImp)
            Await elementi

            Me.crea_grafico_visite(elementi.Result, livello)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Async Sub async_carica_grafico_buoni(codImp As String, Optional livello As Integer = 0)
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of statBuoniImpianto))
            elementi = ws.getStatBuoniImpianto(codImp)
            Await elementi

            Me.create_grafico_buoni(elementi.Result, livello)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Async Sub async_carica_grafico_canoni(codImp As String, Optional livello As Integer = 0)
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of statCanoniImpianto))
            elementi = ws.getStatCanoniImpianto(codImp)
            Await elementi

            Me.create_grafico_canoni(elementi.Result, livello)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Async Sub async_carica_grafico_fatturato(codImp As String, anno As String, Optional livello As Integer = 0)
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of statFatturatoImpianto))
            elementi = ws.getStatFatturatoImpianto(codImp, anno)
            Await elementi

            Me.create_grafico_fatturato(elementi.Result, livello)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Async Sub async_carica_grafico_chiamate(codImp As String, Optional livello As Integer = 0)
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of statChiamateImpianto))
            elementi = ws.getStatChiamateImpianto(codImp)
            Await elementi

            Me.create_grafico_chiamate(elementi.Result, livello)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Async Sub async_carica_grafico_manutenzioni_anno(codImp As String, anno As String, Optional livello As Integer = 0)
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of statManutenzioni))
            elementi = ws.getStatManutenzioni(codImp, anno)
            Await elementi

            Me.crea_grafico_visite(elementi.Result, livello)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Async Sub async_carica_griglia_documenti(codImp As String, anno As String)
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoDocumenti))
            elementi = ws.getDocumentiImpianto(codImp, anno)
            Await elementi

            Me.carica_griglia_documenti(elementi.Result)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub carica_gantt_visite(dati As List(Of elencoManutenzioni))
        Try
            Me.carica_gantt_manutenzioni(dati)
        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)

        End Try

    End Sub

    Private Sub carica_griglia_tipi_visite(dati As List(Of elencoManutDefault))
        Try

            gridTpVis.DataSource = dati
            Me.HeaderText_ColumnGriglia_tipiVisite()
            Me.HeaderText_Column_Griglia_tipiVisite_width()
            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)

        End Try

    End Sub

    Private Sub carica_griglia_tipi_visiteAsset(dati As List(Of elencoManutDefault))
        Try

            gridPianAsset.DataSource = dati
            Me.HeaderText_ColumnGriglia_tipiVisiteAsset()
            Me.HeaderText_Column_Griglia_tipiVisiteAsset_width()
            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)

        End Try

    End Sub

    Private Sub carica_griglia_tasks(dati As List(Of elencoTasksVisita))
        Try

            GridTask.DataSource = dati
            Me.HeaderText_ColumnGriglia_tasks()
            Me.HeaderText_Column_Griglia_tasks_width()
            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)

        End Try

    End Sub

    Private Sub carica_griglia_documenti(dati As List(Of elencoDocumenti))
        Try

            gridDoc.DataSource = dati
            Me.HeaderText_ColumnGriglia_documenti(gridDoc)
            'Me.HeaderText_Column_Griglia_tipiVisite_width()
            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)

        End Try

    End Sub

    Private Sub HeaderText_ColumnGriglia(griglia As RadGridView)
        Try
            griglia.Columns("CDGRUPPO").HeaderText = "Cod.Gruppo"
            griglia.Columns("DESGRUPPO").HeaderText = "Des.Gruppo"
            griglia.Columns("CODVOCE").HeaderText = "Cod.Voce"
            griglia.Columns("DESVOCE").HeaderText = "Voce"
            griglia.Columns("UNMIS").HeaderText = "U.M."
            griglia.Columns("VALORE").HeaderText = "Valore"

            griglia.Columns("UNMIS").TextAlignment = ContentAlignment.MiddleCenter

            griglia.Columns("CDGRUPPO").IsVisible = False
            griglia.Columns("CODVOCE").IsVisible = False
            griglia.Columns("CODICE_LISTA").IsVisible = False

            griglia.Columns("CDGRUPPO").ReadOnly = True
            griglia.Columns("DESGRUPPO").ReadOnly = True
            griglia.Columns("CODVOCE").ReadOnly = True
            griglia.Columns("DESVOCE").ReadOnly = True
            griglia.Columns("UNMIS").ReadOnly = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_Griglia_width(griglia As RadGridView)
        Try
            griglia.Columns("DESVOCE").Width = 280
            griglia.Columns("UNMIS").Width = 70
            griglia.Columns("VALORE").Width = 100

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia_datiTecniciAsset(griglia As RadGridView)
        Try
            griglia.Columns("CDGRUPPO").HeaderText = "Cod.Gruppo"
            griglia.Columns("DESGRUPPO").HeaderText = "Des.Gruppo"
            griglia.Columns("CODVOCE").HeaderText = "Cod.Voce"
            griglia.Columns("DESVOCE").HeaderText = "Voce"
            griglia.Columns("UNMIS").HeaderText = "U.M."
            griglia.Columns("VALORE").HeaderText = "Valore"

            griglia.Columns("UNMIS").TextAlignment = ContentAlignment.MiddleCenter

            griglia.Columns("CDGRUPPO").IsVisible = False
            griglia.Columns("CODVOCE").IsVisible = False
            griglia.Columns("CODICE_LISTA").IsVisible = False

            griglia.Columns("CDGRUPPO").ReadOnly = True
            griglia.Columns("DESGRUPPO").ReadOnly = True
            griglia.Columns("CODVOCE").ReadOnly = True
            griglia.Columns("DESVOCE").ReadOnly = True
            griglia.Columns("UNMIS").ReadOnly = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_Griglia_datiTecniciAsset_width(griglia As RadGridView)
        Try
            griglia.Columns("DESVOCE").Width = 250
            griglia.Columns("UNMIS").Width = 70
            griglia.Columns("VALORE").Width = 150

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia_assets()
        Try

            Me.gridAsset.Columns("CHID").HeaderText = "Id"
            Me.gridAsset.Columns("CHDESCR").HeaderText = "Descrizione Asset"
            Me.gridAsset.Columns("NUMCHL").HeaderText = "N. Assets"
            Me.gridAsset.Columns("FLAGPIANIFICA").HeaderText = "Pianifica"

            Me.gridAsset.Columns("NUMCHL").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridAsset.Columns("CHID").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridAsset.Columns("CHDESCR").TextAlignment = ContentAlignment.MiddleLeft
            Me.gridAsset.Columns("FLAGPIANIFICA").TextAlignment = ContentAlignment.MiddleCenter

            Me.gridAsset.Columns("CHCDCAT").IsVisible = False
            Me.gridAsset.Columns("CDIMP").IsVisible = False
            Me.gridAsset.Columns("CODCATASSET").IsVisible = False
            Me.gridAsset.Columns("DESCRCAT").IsVisible = False
            Me.gridAsset.Columns("DESCRMACROCAT").IsVisible = False

            Me.gridAsset.Columns("FLAGPIANIFICA").ReadOnly = True
            Me.gridAsset.Columns("CHDESCR").ReadOnly = True
            Me.gridAsset.Columns("NUMCHL").ReadOnly = True
            Me.gridAsset.Columns("CHID").ReadOnly = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_Griglia_assets_width()
        Try
            'Me.gridAsset.Columns("img").Width = 50
            Me.gridAsset.Columns("CHDESCR").Width = 220
            Me.gridAsset.Columns("NUMCHL").Width = 90
            Me.gridAsset.Columns("CHID").Width = 80
            Me.gridAsset.Columns("FLAGPIANIFICA").Width = 100

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia_tipiVisite()
        Try
            For i As Integer = 0 To gridTpVis.Columns.Count - 1
                gridTpVis.Columns(i).IsVisible = False
            Next

            gridTpVis.Columns("CodiceVisita").HeaderText = "Codice"
            gridTpVis.Columns("DescrVisita").HeaderText = "Descrizione"
            gridTpVis.Columns("Frequenza").HeaderText = "GG Freq."

            gridTpVis.Columns("CodiceVisita").TextAlignment = ContentAlignment.MiddleCenter
            gridTpVis.Columns("Frequenza").TextAlignment = ContentAlignment.MiddleCenter

            gridTpVis.Columns("CodiceVisita").IsVisible = True
            gridTpVis.Columns("DescrVisita").IsVisible = True
            gridTpVis.Columns("Frequenza").IsVisible = True

            gridTpVis.Columns("CodiceVisita").ReadOnly = True
            gridTpVis.Columns("DescrVisita").ReadOnly = True
            gridTpVis.Columns("Frequenza").ReadOnly = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_Griglia_tipiVisite_width()
        Try
            gridTpVis.Columns("CodiceVisita").Width = 90
            gridTpVis.Columns("DescrVisita").Width = 150
            gridTpVis.Columns("Frequenza").Width = 100

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia_tipiVisiteAsset()
        Try
            For i As Integer = 0 To gridPianAsset.Columns.Count - 1
                gridPianAsset.Columns(i).IsVisible = False
                gridPianAsset.Columns(i).ReadOnly = True
            Next

            gridPianAsset.Columns("CodiceVisita").HeaderText = "Codice"
            gridPianAsset.Columns("DescrVisita").HeaderText = "Descrizione"
            gridPianAsset.Columns("Frequenza").HeaderText = "GG Freq."

            gridPianAsset.Columns("CodiceVisita").TextAlignment = ContentAlignment.MiddleCenter
            gridPianAsset.Columns("Frequenza").TextAlignment = ContentAlignment.MiddleCenter

            gridPianAsset.Columns("CodiceVisita").IsVisible = True
            gridPianAsset.Columns("DescrVisita").IsVisible = True
            gridPianAsset.Columns("Frequenza").IsVisible = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_Griglia_tipiVisiteAsset_width()
        Try
            gridPianAsset.Columns("CodiceVisita").Width = 90
            gridPianAsset.Columns("DescrVisita").Width = 150
            gridPianAsset.Columns("Frequenza").Width = 100

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub
    Private Sub HeaderText_ColumnGriglia_tasks()
        Try
            For i As Integer = 0 To GridTask.Columns.Count - 1
                GridTask.Columns(i).IsVisible = False
                GridTask.Columns(i).ReadOnly = True
            Next

            GridTask.Columns("IdTask").HeaderText = "Id"
            GridTask.Columns("DesTask").HeaderText = "Descrizione"

            GridTask.Columns("IdTask").TextAlignment = ContentAlignment.MiddleCenter

            GridTask.Columns("IdTask").IsVisible = True
            GridTask.Columns("DesTask").IsVisible = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_Griglia_tasks_width()
        Try
            GridTask.Columns("IdTask").Width = 70
            GridTask.Columns("DesTask").Width = 250
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
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

            griglia.Columns("annodoc").TextAlignment = ContentAlignment.MiddleCenter
            griglia.Columns("numdoc").TextAlignment = ContentAlignment.MiddleCenter
            griglia.Columns("datadoc").TextAlignment = ContentAlignment.MiddleCenter
            griglia.Columns("centro").TextAlignment = ContentAlignment.MiddleCenter
            griglia.Columns("CodiceCliente").TextAlignment = ContentAlignment.MiddleCenter

            griglia.Columns("AnnoDocInt").IsVisible = False
            griglia.Columns("NumDocInt").IsVisible = False
            griglia.Columns("EDOC_DB").IsVisible = False

            For i = 0 To griglia.Columns.Count - 1
                griglia.Columns(i).ReadOnly = True
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub crea_griglia_assets()
        Try

            Me.gridAsset.BeginEdit()
            'Me.gridasset.EnableFiltering = True
            'Me.gridAsset.MasterTemplate.ShowHeaderCellButtons = True
            Me.gridAsset.MasterTemplate.ShowFilteringRow = False
            Me.gridAsset.AllowAddNewRow = False
            Me.gridAsset.AutoGenerateColumns = False
            Me.gridAsset.EnableGrouping = False

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

            Dim colCHID As New GridViewDecimalColumn
            colCHID.Name = "CHID"
            colCHID.DataType = GetType(Integer)
            colCHID.FieldName = "CHID"

            Dim colCHDESCR As New GridViewDecimalColumn
            colCHDESCR.Name = "CHDESCR"
            colCHDESCR.DataType = GetType(String)
            colCHDESCR.FieldName = "CHDESCR"

            Dim colNUMCHL As New GridViewDecimalColumn
            colNUMCHL.Name = "NUMCHL"
            colNUMCHL.DataType = GetType(Integer)
            colNUMCHL.FieldName = "NUMCHL"

            Dim colCHCDCAT As New GridViewTextBoxColumn
            colCHCDCAT.Name = "CHCDCAT"
            colCHCDCAT.DataType = GetType(String)
            colCHCDCAT.FieldName = "CHCDCAT"

            Dim colCDIMP As New GridViewDecimalColumn
            colCDIMP.Name = "CDIMP"
            colCDIMP.DataType = GetType(Integer)
            colCDIMP.FieldName = "CDIMP"

            Dim colCODCATASSET As New GridViewDecimalColumn
            colCODCATASSET.Name = "CODCATASSET"
            colCODCATASSET.DataType = GetType(String)
            colCODCATASSET.FieldName = "CODCATASSET"

            Dim colFLPIANIFICA As New GridViewTextBoxColumn
            colFLPIANIFICA.Name = "FLAGPIANIFICA"
            colFLPIANIFICA.DataType = GetType(String)
            colFLPIANIFICA.FieldName = "FLAGPIANIFICA"

            gridAsset.MasterTemplate.Columns.Add(commandColumn)
            'gridasset.MasterTemplate.Columns.Add(checkBoxColumn)
            gridAsset.MasterTemplate.Columns.Add(colCHID)
            gridAsset.MasterTemplate.Columns.Add(colCHDESCR)
            gridAsset.MasterTemplate.Columns.Add(colNUMCHL)
            gridAsset.MasterTemplate.Columns.Add(colCHCDCAT)
            gridAsset.MasterTemplate.Columns.Add(colCDIMP)
            gridAsset.MasterTemplate.Columns.Add(colCODCATASSET)
            gridAsset.MasterTemplate.Columns.Add(colFLPIANIFICA)

            'AddHandler gridasset.CommandCellClick, AddressOf grid_CommandCellClick

            gridAsset.TableElement.SearchHighlightColor = Color.LimeGreen

            'Me.gridasset.Columns("Check").AllowFiltering = False
            'Me.gridasset.Columns("Mod").AllowFiltering = False

            Me.gridAsset.EndEdit()

            'gridasset.AllowSearchRow = True
            'gridasset.MasterView.SummaryRows(0).PinPosition = PinnedRowPosition.Bottom


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Crea griglia assets")
        End Try
    End Sub

    Private Sub cmbLoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbLoc.SelectedValueChanged
        seleziona_localita()
    End Sub

    Private Sub cmbLoc_LostFocus(sender As Object, e As EventArgs) Handles cmbLoc.LostFocus
        seleziona_localita()
    End Sub


    Private Function seleziona_lista(cod_lista As String) As List(Of parmTabelle)
        Dim lista As New List(Of parmTabelle)
        Dim eleEmpty As New parmTabelle
        eleEmpty.codElem = ""
        eleEmpty.desElem = ""
        lista.Add(eleEmpty)

        Try

            For i As Integer = 0 To vals.Count - 1
                If vals(i).codElem = cod_lista Then
                    Dim elem As New parmTabelle
                    elem.codElem = vals(i).codElem
                    elem.desElem = vals(i).desElem
                    lista.Add(elem)
                End If
            Next i

            Return lista
        Catch ex As Exception
            Return lista
        End Try

    End Function
    Private Async Sub carica_liste_elementi_dati_tecnici(Optional cod_lista As String = "")
        Try
            vals.Clear()
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiListe(cod_lista, "")
            Await elementi
            For i As Integer = 0 To elementi.Result.Count - 1
                vals.Add(elementi.Result(i))
            Next i

        Catch ex As Exception
            vals.Clear()
        End Try
    End Sub

    Private Sub cmdInsDett_Click(sender As Object, e As EventArgs) Handles cmdInsDett.Click
        Dim frm As New FrmImpiantoAssets

        'frm.categoria = cmbCategoriaImp.SelectedValue
        'frm.ShowDialog()
        'If frm.rtnAsset.CHID <> 0 Then
        'Me.saveAssetImpianto(idImpianto, frm.rtnAsset.CHID, "NUOVO")

        '''''''''''Dim row = gridAsset.CurrentRow
        ''''''''''Dim rowInfo = New GridViewDataRowInfo(Me.gridAsset.MasterView)
        ''''''''''rowInfo.Cells("CHID").Value = frm.rtnAsset.CHID
        ''''''''''rowInfo.Cells("CHDESCR").Value = frm.rtnAsset.CHDESCR
        ''''''''''rowInfo.Cells("NUMCHL").Value = 1
        ''''''''''rowInfo.Cells("CHCDCAT").Value = frm.rtnAsset.CHCDCAT
        ''''''''''rowInfo.Cells("CDIMP").Value = idImpianto
        ''''''''''rowInfo.Cells("CODCATASSET").Value = frm.rtnAsset.CodCatAsset

        '''''''''''Dim index = gridAsset.Rows.IndexOf(row)
        ''''''''''gridAsset.Rows.Add(rowInfo)


        'Dim chid As String = frm.rtnAsset.CHID
        'End If

        Try
            azioneAsset = "NUOVO"
            abilita_elementi(True, "ASSETS")
            carica_combo_Assets(cmbCategoriaImp.SelectedItem.Value)
            carica_dati_asset(azioneAsset)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub cmbCategoriaImp_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbCategoriaImp.SelectedIndex >= 0 Then
                async_carica_griglia_datitecnici_impianto(txtCodice.Text, cmbCategoriaImp.SelectedValue)
                async_carica_griglia_tipi_visite(txtCodice.Text, cmbCategoriaImp.SelectedValue)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function controlli_form() As Boolean
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            If cmbTipoImp.SelectedIndex = -1 Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Selezionare il tipo impianto", "Anagrafica impianti", MessageBoxButtons.OK, RadMessageIcon.Error)
                cmbTipoImp.Focus()
                Return False
            End If

            If cmbStrada.SelectedIndex = -1 Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Selezionare la strada", "Anagrafica impianti", MessageBoxButtons.OK, RadMessageIcon.Error)
                cmbStrada.Focus()
                Return False
            End If

            If txtIndirizzo.Text.Trim.Length = 0 Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Indicare l'indirizzo", "Anagrafica impianti", MessageBoxButtons.OK, RadMessageIcon.Error)
                txtIndirizzo.Focus()
                Return False
            End If

            If Val(txtCap.Value) = 0 Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Indicare il C.A.P.", "Anagrafica impianti", MessageBoxButtons.OK, RadMessageIcon.Error)
                txtCap.Focus()
                Return False
            End If

            If txtProv.Text.Trim.Length = 0 Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Indicare la Provincia", "Anagrafica impianti", MessageBoxButtons.OK, RadMessageIcon.Error)
                txtProv.Focus()
                Return False
            End If

            If txtCodCliente.Text.Trim.Length = 0 Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Selezionare il Cliente", "Anagrafica impianti", MessageBoxButtons.OK, RadMessageIcon.Error)
                txtCodCliente.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Telerik.WinControls.RadMessageBox.Show(Me, ex.Message, "Anagrafica impianti", MessageBoxButtons.OK, RadMessageIcon.Error)
            Return False
        End Try
    End Function

    Private Async Sub SaveSchedaImpianto()
        Try
            Dim test As String
            Dim client As New Http.HttpClient

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim scheda As New parmGetSchedaImpianto
            scheda = Me.move_val_to_file

            Dim postContent = jss.Serialize(scheda)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = My.Settings.urlWS & "/api/impianti/saveScheda/postSchedaImpianto" '& "?paramList=1234"
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmEntry", postContent)

            Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)

            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

            Dim sStatusCode As String = postResponse.StatusCode.ToString

            If sStatusCode.ToUpper <> "OK" Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio non effettuato. " & vbCrLf & "Causa: " & postResponse.ToString, "Anagrafica impianti", MessageBoxButtons.OK, RadMessageIcon.Info)
            Else
                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio effettuato", "Anagrafica impianti", MessageBoxButtons.OK, RadMessageIcon.Info)
            End If

        Catch EX As Exception

        End Try


    End Sub

    Private Async Sub SaveParametriVisitaAsset(codimp As String, codAsset As String, codCat As String, azione As String, id As Integer)
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            Dim test As String
            Dim client As New Http.HttpClient

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim scheda As New parmPostParVisAsset

            scheda = Me.move_val_to_file_visiteAsset(codAsset, codimp, azione, id)

            Dim postContent = jss.Serialize(scheda)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = My.Settings.urlWS & "/api/visite/saveParametriVisiteAsset/saveParametriVisiteAsset"
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmEntry", postContent)

            Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)

            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

            Dim sStatusCode As String = postResponse.StatusCode.ToString

            If sStatusCode.ToUpper <> "OK" Then

                Dim msg As String = postResponse.Headers.GetValues("Error").FirstOrDefault()

                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio non effettuato. " & vbCrLf & "Causa: " & msg, "Visite asset", MessageBoxButtons.OK, RadMessageIcon.Info)
            Else
                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio effettuato", "Visite asset", MessageBoxButtons.OK, RadMessageIcon.Info)
            End If

            Me.async_carica_griglia_tipi_visite_asset(codimp, codCat, codAsset)
        Catch EX As Exception

        End Try


    End Sub

    Private Async Sub SaveParametriVisitaImpianto(codimp As String, codAsset As String, codCat As String, azione As String, id As Integer)
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            Dim test As String
            Dim client As New Http.HttpClient

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim scheda As New parmPostParVisAsset

            scheda = Me.move_val_to_file_visiteImpianto(codAsset, codimp, azione, id)

            Dim postContent = jss.Serialize(scheda)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = My.Settings.urlWS & "/api/visite/saveParametriVisiteAsset/saveParametriVisiteAsset"
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmEntry", postContent)

            Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)

            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

            Dim sStatusCode As String = postResponse.StatusCode.ToString

            If sStatusCode.ToUpper <> "OK" Then

                Dim msg As String = postResponse.Headers.GetValues("Error").FirstOrDefault()

                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio non effettuato. " & vbCrLf & "Causa: " & msg, "Visite impianto", MessageBoxButtons.OK, RadMessageIcon.Info)
            Else
                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio effettuato", "Visite impianto", MessageBoxButtons.OK, RadMessageIcon.Info)
            End If

            Me.async_carica_griglia_tipi_visite(codimp, codCat)
        Catch EX As Exception

        End Try


    End Sub

    Private Async Sub saveAssetImpianto(codImp As String, codAsset As String, nrAssets As Integer, azione As String)
        Try
            Dim test As String
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            Dim parms As New parmPostAssets
            parms.azione = azione
            parms.CHDESCR = ""
            parms.CHCDCAT = ""
            parms.CodCatAsset = ""
            parms.NUMASSETS = nrAssets
            parms.CODIMP = codImp
            parms.CHID = codAsset

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

            'Dim scI As New parmGetSchedaImpianto
            'scI = Newtonsoft.Json.JsonConvert.DeserializeObject(Of parmPostAssets)(parms)
            Dim postContent = jss.Serialize(parms)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = "https://localhost:44323/api/impianti/saveAsset/postAsset" & "?paramList=1234"
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("parmEntry", postContent)

            Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)

            'abilita_elementi(False)

            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

            async_carica_griglia_asset_impianto()

        Catch EX As Exception
            wbA.StopWaiting()
            wbA.AssociatedControl = Nothing
            wbA.Visible = False
            MsgBox(EX.Message, vbCritical)
        End Try


    End Sub
    Private Function move_val_to_file() As parmGetSchedaImpianto
        Dim sc As New parmGetSchedaImpianto
        Try
            sc.ATX13 = ""
            If azione = "NUOVO" Then
                sc.AICIM = "0"
            Else
                sc.AICIM = txtCodice.Text
            End If
            sc.AIAMM = txtCodAmm.Text
            sc.AICAP = txtCap.Text
            sc.AICLI = txtCodCliente.Text
            sc.AIIND = txtIndirizzo.Text
            sc.AILOC = txtlocalita.Text
            sc.AISTR = cmbStrada.SelectedValue
            sc.AISPR = txtProv.Text
            If cmbCategoriaImp.SelectedIndex >= 0 Then
                sc.AICCI = cmbCategoriaImp.SelectedValue
            Else
                sc.AICCI = ""
            End If
            If cmbTipoImpianto.SelectedIndex >= 0 Then
                sc.AICTI = cmbTipoImpianto.SelectedValue
            Else
                sc.AICTI = ""
            End If

            sc.AIFLL = cmbTipoImp.SelectedValue
            sc.AINTS = txtTelesoccorso.Text.Trim
            sc.AIGES = txtGestore.Text.Trim

            If cmbReperib.SelectedIndex >= 0 Then
                sc.AICCER = cmbReperib.SelectedValue
                sc.AIZONR = txtZonaRep.Text
            Else
                sc.AICCER = ""
                sc.AIZONR = ""
            End If

            If cmbCallCenter.SelectedIndex >= 0 Then
                sc.AICLLC = cmbCallCenter.SelectedValue
            Else
                sc.AICLLC = ""
            End If

            If cmbZona.SelectedIndex >= 0 Then
                sc.AIZON = cmbZona.SelectedValue
            Else
                sc.AIZON = ""
            End If

            If chkLineaNsCarico.Checked = CheckState.Checked Then
                sc.AILIC = "S"
            Else
                sc.AILIC = "N"
            End If
            sc.AICIN = ""
            sc.AIRIF = ""
            sc.AISTA = ""

            If IsDate(txtDataNomina.Text) Then
                sc.AIDNA = txtDataNomina.Text
            Else
                sc.AIDNA = "01/01/1900"
            End If

            Return sc

        Catch ex As Exception
            Return sc
        End Try
    End Function

    Private Function move_val_to_file_visiteAsset(codAss As String, codimp As String, azione As String, id As Integer) As parmPostParVisAsset
        Dim sc As New parmPostParVisAsset
        Try
            sc.azione = azione
            sc.CodiceAsset = codAss
            sc.CodiceImpianto = codimp
            sc.CodiceVisita = cmbTipiVis.SelectedValue
            sc.Frequenza = txtFreqA.Value
            sc.ggSturtup = txtGGstartupA.Value
            sc.PeriodoIniz = txtPerIniA.Value
            sc.PeriodoFin = txtPerFinA.Value
            sc.id = id
            sc.flagUltimaDataVisita = IIf(chkUltVisA.Checked = True, "S", "N")
            Return sc
        Catch ex As Exception
            Return sc
        End Try
    End Function

    Private Function move_val_to_file_visiteImpianto(codAss As String, codimp As String, azione As String, id As Integer) As parmPostParVisAsset
        Dim sc As New parmPostParVisAsset
        Try
            sc.azione = azione
            sc.CodiceAsset = codAss
            sc.CodiceImpianto = codimp
            sc.CodiceVisita = lbltpVisitaImp.Text
            sc.Frequenza = txtVisFrequenza.Value
            sc.ggSturtup = txtVisGGstartup.Value
            sc.PeriodoIniz = txtVisPeriodoIni.Value
            sc.PeriodoFin = txtVisPeriodoFin.Value
            If chkUltimaVisEff.Checked = True Then
                sc.flagUltimaDataVisita = "S"
            Else
                sc.flagUltimaDataVisita = "N"
            End If
            sc.id = id
            Return sc
        Catch ex As Exception
            Return sc
        End Try
    End Function

#Region "******* EVENTI GRIGLIE *******************"
    Private Sub gridAsset_CurrentRowChanged(sender As Object, e As CurrentRowChangedEventArgs)
        Try
            If Not IsNothing(e.CurrentRow.Cells("CHID")) Then
                async_carica_griglia_DatiTecnici_asset_impianto(e.CurrentRow.Cells("CHID").Value, idImpianto)
                Me.async_carica_griglia_tipi_visite_asset(idImpianto, e.CurrentRow.Cells("CHCDCAT").Value, e.CurrentRow.Cells("CHID").Value.ToString)
            End If

            If e.CurrentRow.Cells("FLAGPIANIFICA").Value = "N" Then
                cmdBarPianAsset.Enabled = False
            Else
                cmdBarPianAsset.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridFatt_ViewCellFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs)
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
            'e.CellElement.Font = newFontH

            If TypeOf e.CellElement.RowInfo Is GridViewGroupRowInfo Then
                e.CellElement.Font = newFont
                e.CellElement.DrawFill = True

                If e.CellElement.RowInfo.Group.GroupDescriptor IsNot Nothing Then
                    e.CellElement.BackColor = Color.Gainsboro   'Color.FromArgb(246, 246, 246)
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
                If grid.FilterDescriptors.Expression.ToString.ToUpper.Contains(e.CellElement.ColumnInfo.Name) Then
                    e.CellElement.BackColor = Color.FromArgb(233, 255, 1)
                    e.CellElement.ForeColor = Color.FromArgb(30, 123, 169)
                Else
                    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                    e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                    'e.CellElement.BackColor = Color.FromArgb(230, 230, 230)
                    'e.CellElement.ForeColor = Color.Black
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub gridFatt_ViewRowFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.RowFormattingEventArgs)

        Try
            If TypeOf e.RowElement Is GridSummaryRowElement Then
                If e.RowElement.RowInfo.Group Is Nothing Then
                    e.RowElement.RowInfo.PinPosition = PinnedRowPosition.Bottom
                Else
                    e.RowElement.RowInfo.PinPosition = PinnedRowPosition.None
                End If
                'e.RowElement.RowInfo.Height = 35
            ElseIf TypeOf e.RowElement Is GridGroupHeaderRowElement Then
                e.RowElement.RowInfo.Height = 30
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
    Private Sub gridFatt_CellFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs)

        Try

            If e.CellElement.ColumnInfo.Name.ToUpper = "CHECK" Then
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                e.CellElement.ResetValue(LightVisualElement.TextImageRelationProperty, ValueResetFlags.Local)
                e.CellElement.ResetValue(LightVisualElement.ImageAlignmentProperty, ValueResetFlags.Local)
                e.CellElement.Image = Nothing

            ElseIf e.CellElement.ColumnInfo.Name.ToUpper = "IMG" Then
                e.CellElement.ForeColor = e.CellElement.BackColor
                e.CellElement.Image = My.Resources.camera_24
                e.CellElement.ImageAlignment = ContentAlignment.MiddleCenter
                e.CellElement.TextImageRelation = TextImageRelation.ImageBeforeText
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

    Private Sub gridFatt_ContextMenuOpening(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.ContextMenuOpeningEventArgs)
        e.Cancel = True
    End Sub

    Private Sub grid_EditorRequired(ByVal sender As Object, ByVal e As EditorRequiredEventArgs)
        If grid.CurrentColumn.Name.ToUpper = "VALORE" Then
            If Not IsNothing(grid.CurrentRow.Cells("CODICE_LISTA").Value) AndAlso
                grid.CurrentRow.Cells("CODICE_LISTA").Value <> "" Then

                Dim combo As New RadDropDownListEditor()
                combo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList

                CType((combo.EditorElement), RadDropDownListEditorElement).ValueMember = "desElem"
                CType((combo.EditorElement), RadDropDownListEditorElement).DisplayMember = "desElem"
                CType((combo.EditorElement), RadDropDownListEditorElement).DataSource = seleziona_lista(grid.CurrentRow.Cells("CODICE_LISTA").Value)
                'combo.SelectedValue = grid.CurrentCell.Value
                e.Editor = combo

            End If
        End If

    End Sub

    Private Sub grid_GroupSummaryEvaluate(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GroupSummaryEvaluationEventArgs)
        Try
            'If e.SummaryItem.Name = "DDESCL" Then
            Dim desRiga As String = ""

            If e.SummaryItem.Name = "DESGRUPPO" Then
                'Dim totale As Double = 0
                For Each row As GridViewRowInfo In e.Group
                    If Not row Is Nothing Then
                        desRiga = Trim(e.Value.ToString)
                        Exit For
                    End If
                Next

                'e.FormatString = [String].Format("{1}{0}{2}", "", e.Value.ToString & Space(45 - e.Value.ToString.Length), Format(totale, "#,##0.00"))
                e.FormatString = [String].Format("{0}", desRiga)

            ElseIf TypeOf e.Context Is GridViewSummaryRowInfo Then
                'If e.SummaryItem.Name = "NUMDOC" Then
                'ElseIf e.SummaryItem.Name = "AICIM" Then
                '    e.FormatString = "{0:#,##0}"
                'ElseIf e.SummaryItem.Name = "DATADOC" Then
                '    e.FormatString = "{0:dd-MM-yyyy}"

                'Else
                '    e.FormatString = "{0:#,##0.00}"
                'End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub
#End Region

#Region "*******GESTIONE MAPPA**************"
    Private Sub SetupProviders()

        Dim bingProvider As New BingRestMapProvider()
        bingProvider.Culture = System.Threading.Thread.CurrentThread.CurrentCulture
        bingProvider.UseSession = True
        bingProvider.BingKey = "M7cKnoZAkxXJfWmSmG1o~OW026RPkaCVxgId3XwFHlw~Ajqw6RAH74XHObo0LyLh8g2ksrotP7XYzFrAJzOGQhVurSWWd_Q10F1qmU8jWT4e" 'My.Resources.BingKey
        bingProvider.ImagerySet = ImagerySet.CanvasGray

        AddHandler bingProvider.InitializationComplete,
            Sub(sender As Object, e As EventArgs)
                Me.map.Zoom(6)
                Me.map.MapElement.SearchBarElement.Search(cmbStrada.SelectedText & " " & txtIndirizzo.Text & ", " & txtlocalita.Text)
            End Sub

        Me.map.MapElement.Providers.Add(bingProvider)
        Me.map.MapElement.SearchBarElement.SearchProvider = bingProvider

        Dim easternLayer As New MapLayer("Pins")
        Me.map.Layers.Add(easternLayer)

        AddHandler bingProvider.SearchCompleted, AddressOf BingProvider_SearchCompleted
        AddHandler bingProvider.SearchError, AddressOf BingProvider_SearchError
    End Sub

    Private Sub BingProvider_SearchCompleted(ByVal sender As Object, ByVal e As SearchCompletedEventArgs)
        Dim allPoints As New RectangleG(Double.MinValue, Double.MaxValue, Double.MaxValue, Double.MinValue)
        Me.map.Layers("Pins").Clear()

        For Each location As Location In e.Locations
            Dim point As New PointG(location.Point.Coordinates(0), location.Point.Coordinates(1))
            Dim pin As New MapPin(point)
            pin.BackColor = Color.FromArgb(11, 195, 197)
            pin.ToolTipText = location.Address.FormattedAddress
            Me.map.MapElement.Layers("Pins").Add(pin)
            Me.map.Zoom(6)

            Dim callout As New MapCallout(pin)
            callout.Text = location.Name
            Me.map.MapElement.Layers("Pins").Add(callout)

            allPoints.North = Math.Max(allPoints.North, point.Latitude)
            allPoints.South = Math.Min(allPoints.South, point.Latitude)
            allPoints.West = Math.Min(allPoints.West, point.Longitude)
            allPoints.East = Math.Max(allPoints.East, point.Longitude)
        Next location

        If e.Locations.Length <> 0 Then
            If e.Locations.Length = 1 Then
                Me.map.Zoom(Me.map.MapElement.ZoomLevel + 10)
                Me.map.BringIntoView(New PointG(e.Locations(0).Point.Coordinates(0), e.Locations(0).Point.Coordinates(1)))

            Else
                Me.map.MapElement.BringIntoView(allPoints)
                Me.map.Zoom(Me.map.MapElement.ZoomLevel - 1)
            End If
        Else
            RadMessageBox.Show("Nessun risultato trovato")
        End If
    End Sub

    Private Sub BingProvider_SearchError(ByVal sender As Object, ByVal e As SearchErrorEventArgs)
        'RadMessageBox.ThemeName = Me.CurrentThemeName
        RadMessageBox.Show(e.Error.Message)
    End Sub

    Private Sub SetupLayer()
        Dim pinsLayer As New MapLayer("Pins")
        Me.MAP.Layers.Add(pinsLayer)
    End Sub

    Private Sub cmdConferma_Click(sender As Object, e As EventArgs) Handles cmdConferma.Click
        If controlli_form() = True Then
            SaveSchedaImpianto()
        End If
    End Sub

    Private Sub cmdAnnulla_Click(sender As Object, e As EventArgs) Handles cmdAnnulla.Click
        Me.Close()
    End Sub

    Private Sub t1_Tick(sender As Object, e As EventArgs) Handles t1.Tick
        Try
            If statoCaricaCategorie = True And statoCaricaEntiCollaud = True And
             statoCaricaEntiIspettivi = True And statoCaricaCostruttori = True And
             statoCaricaStrade = True And statoCaricaTipoImpianto = True And
             statoCaricaTipoImp = True And
             statoCaricaCallCenter = True Then

                wbG.AssociatedControl = Nothing
                wbG.StopWaiting()
                wbG.Visible = False

                t1.Enabled = False

            End If

        Catch ex As Exception

            wbG.AssociatedControl = Nothing
            wbG.StopWaiting()
            wbG.Visible = False
            t1.Enabled = False
        End Try
    End Sub

    Private Sub gridTpVis_CurrentRowChanged(sender As Object, e As CurrentRowChangedEventArgs)
        Try
            If Not IsNothing(e.CurrentRow.Cells("CodiceVisita")) Then
                lblTipoVisita.Text = e.CurrentRow.Cells("DescrVisita").Value
                ToolWinTasks.Text = "TASKS " & e.CurrentRow.Cells("DescrVisita").Value
                lblId.Text = e.CurrentRow.Cells("id").Value
                lbltpVisitaImp.Text = e.CurrentRow.Cells("CodiceVisita").Value

                If e.CurrentRow.Cells("flagUltimaDataVisita").Value = "S" Then
                    chkUltimaVisEff.Checked = True
                Else
                    chkUltimaVisEff.Checked = False
                End If

                If e.CurrentRow.Cells("flagVisOrdinaria").Value = "S" OrElse
                    e.CurrentRow.Cells("flagVisSemestrale").Value = "S" OrElse
                    e.CurrentRow.Cells("flagVisBiennale").Value = "S" Then
                    txtVisFrequenza.Enabled = True
                    txtVisGGstartup.Enabled = False
                    txtVisPeriodoFin.Enabled = False
                    txtVisPeriodoIni.Enabled = False
                    txtVisFrequenza.Value = e.CurrentRow.Cells("frequenza").Value

                ElseIf e.CurrentRow.Cells("flagVisStagionale").Value = "S" Then
                    txtVisFrequenza.Enabled = False
                    txtVisGGstartup.Enabled = False
                    txtVisPeriodoFin.Enabled = True
                    txtVisPeriodoIni.Enabled = True
                    txtVisPeriodoIni.Value = e.CurrentRow.Cells("PeriodoIniz").Value
                    txtVisPeriodoFin.Value = e.CurrentRow.Cells("PeriodoFin").Value

                ElseIf e.CurrentRow.Cells("flagVisCiclica").Value = "S" Then
                    txtVisFrequenza.Enabled = True
                    txtVisGGstartup.Enabled = True
                    txtVisPeriodoFin.Enabled = False
                    txtVisPeriodoIni.Enabled = False
                    txtVisGGstartup.Value = e.CurrentRow.Cells("ggSturtup").Value
                    txtVisFrequenza.Value = e.CurrentRow.Cells("frequenza").Value
                End If

                Me.async_carica_griglia_tasks(e.CurrentRow.Cells("CodiceVisita").Value, "0010")
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub gantt_SelectedItemChanged(ByVal sender As Object, ByVal e As GanttViewSelectedItemChangedEventArgs) Handles gant.SelectedItemChanged
        Try
            Dim dateToScroll = e.Item.Start
            Me.gant.GanttViewElement.GraphicalViewElement.TimelineStart = New DateTime(Year(dateToScroll), 1, 1)
            Me.gant.GanttViewElement.GraphicalViewElement.ScrollTo(dateToScroll)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub carica_gantt_manutenzioni(dati As List(Of elencoManutenzioni))
        Try
            Me.gant.GanttViewElement.GraphicalViewElement.TimelineRange = TimeRange.Year
            'Me.gant.GanttViewElement.GraphicalViewElement.OnePixelTime = New TimeSpan(0, 60, 0)
            Me.gant.GanttViewElement.GraphicalViewElement.OnePixelTime = New TimeSpan(0, 300, 0)

            Dim titleColumn As New GanttViewTextViewColumn("Title")
            Dim startColumn As New GanttViewTextViewColumn("Start")
            Dim endColumn As New GanttViewTextViewColumn("End")
            Dim dtEffetCol As New GanttViewTextViewColumn("dtEffett")
            Dim nrBollCol As New GanttViewTextViewColumn("NrBoll")
            Dim aaBollCol As New GanttViewTextViewColumn("AnnoBoll")
            Dim firmaCol As New GanttViewTextViewColumn("Firma")
            Dim NoteCol As New GanttViewTextViewColumn("Note")

            titleColumn.HeaderText = "Tipo Visita"
            startColumn.HeaderText = "Data Inizio"
            endColumn.HeaderText = "Data Fine"
            dtEffetCol.HeaderText = "Data effett."
            nrBollCol.HeaderText = "Nr. Boll."
            firmaCol.HeaderText = "Firmato"
            NoteCol.HeaderText = "Note visita"
            aaBollCol.HeaderText = "Anno"

            Me.gant.GanttViewElement.Columns.Add(titleColumn)
            Me.gant.GanttViewElement.Columns.Add(startColumn)
            Me.gant.GanttViewElement.Columns.Add(endColumn)
            Me.gant.GanttViewElement.Columns.Add(dtEffetCol)
            Me.gant.GanttViewElement.Columns.Add(nrBollCol)
            Me.gant.GanttViewElement.Columns.Add(aaBollCol)
            Me.gant.GanttViewElement.Columns.Add(firmaCol)
            Me.gant.GanttViewElement.Columns.Add(NoteCol)

            gant.Columns("Start").FormatString = "{0:dd/MM/yyyy}"
            gant.Columns("End").FormatString = "{0:dd/MM/yyyy}"
            gant.Columns("Start").FormatString = "{0:dd/MM/yyyy}"
            gant.Columns("DtEffett").FormatString = "{0:dd/MM/yyyy}"
            gant.Columns("NrBoll").Width = 65
            gant.Columns("AnnoBoll").Width = 60
            gant.Columns("Firma").Width = 65
            gant.Columns("Title").Width = 200
            gant.Columns("End").Width = 75
            gant.Columns("Start").Width = 77

            Me.gant.GanttViewElement.GraphicalViewElement.TimelineStart = New DateTime(1990, 1, 1)
            Me.gant.GanttViewElement.GraphicalViewElement.TimelineEnd = New DateTime(2030, 12, 31)

            Me.gant.GanttViewElement.GraphicalViewElement.AutomaticTimelineTimeRange = True
            Me.gant.GanttViewElement.GraphicalViewElement.TimelineRange = TimeRange.Year
            Me.SetupTrackbar()

            Dim dateToScroll = New DateTime(Now.Year, 1, 1)
            Me.gant.GanttViewElement.GraphicalViewElement.TimelineStart = New DateTime(Year(dateToScroll), 1, 1)
            Me.gant.GanttViewElement.GraphicalViewElement.ScrollTo(dateToScroll)

            Dim appTipoVis As String = ""
            Dim tipoVis As String = ""
            Dim appAnno As String = ""
            Dim annoVis As String = ""
            Dim id As Integer = 1

            Dim itemGruppo As New GanttViewDataItem()

            For i As Integer = 0 To dati.Count - 1
                tipoVis = dati(i).tipoVisita
                annoVis = Year(dati(i).dataInizio)

                If appTipoVis <> tipoVis OrElse appAnno <> annoVis Then
                    If appTipoVis <> "" And appAnno <> "" Then
                        Me.gant.Items.Add(itemGruppo)
                        itemGruppo = New GanttViewDataItem()
                        id = 1
                    End If

                    itemGruppo.Start = New DateTime(Year(dati(i).dataInizio), 1, 1)
                    itemGruppo.[End] = New DateTime(Year(dati(i).dataInizio), 12, 31)
                    itemGruppo.Title = dati(i).DescrMan & " " & annoVis

                    appTipoVis = dati(i).tipoVisita
                    appAnno = Year(dati(i).dataInizio)

                End If

                Dim itemVis As New liftGanttViewDataItem()
                itemVis.Start = CDate(dati(i).dataInizio)
                itemVis.[End] = CDate(dati(i).dataFine)
                itemVis.Title = dati(i).tipoVisita & " - " & id
                itemVis.DtEffett = CDate(dati(i).dataEffett)
                itemVis.nrBoll = dati(i).numBoll
                itemVis.AnnoBoll = dati(i).annoBoll

                itemGruppo.Items.Add(itemVis)
                id = id + 1
            Next

            'If appTipoVis <> tipoVis Then
            Me.gant.Items.Add(itemGruppo)
            'End If

            Me.gant.Ratio = 0.3
            'Me.gant.GanttViewElement.Items(gant.GanttViewElement.Items.Count - 1).Selected = True
        Catch ex As Exception

        End Try
    End Sub
    Sub test_gantt()
        Try
            AddHandler Me.gant.GanttViewElement.ItemEditing, AddressOf GanttViewElement_ItemEditing
            AddHandler Me.gant.TextViewItemFormatting, AddressOf radGanttView_TextViewItemFormatting

            Dim titleColumn As New GanttViewTextViewColumn("Title")
            Dim startColumn As New GanttViewTextViewColumn("Start")
            Dim endColumn As New GanttViewTextViewColumn("End")
            Dim dtEffetCol As New GanttViewTextViewColumn("dtEffett")
            Dim nrBollCol As New GanttViewTextViewColumn("NrBoll")
            Dim firmaCol As New GanttViewTextViewColumn("Firma")
            Dim NoteCol As New GanttViewTextViewColumn("Note")

            titleColumn.HeaderText = "Tipo Visita"
            startColumn.HeaderText = "Data Inizio"
            endColumn.HeaderText = "Data Fine"
            dtEffetCol.HeaderText = "Data effett."
            nrBollCol.HeaderText = "Nr. Boll."
            firmaCol.HeaderText = "Firmato"
            NoteCol.HeaderText = "Note visita"

            Me.gant.GanttViewElement.Columns.Add(titleColumn)
            Me.gant.GanttViewElement.Columns.Add(startColumn)
            Me.gant.GanttViewElement.Columns.Add(endColumn)
            Me.gant.GanttViewElement.Columns.Add(dtEffetCol)
            Me.gant.GanttViewElement.Columns.Add(nrBollCol)
            Me.gant.GanttViewElement.Columns.Add(firmaCol)
            Me.gant.GanttViewElement.Columns.Add(NoteCol)

            gant.Columns("Start").FormatString = "{0:dd/MM/yyyy}"
            gant.Columns("End").FormatString = "{0:dd/MM/yyyy}"
            gant.Columns("Start").FormatString = "{0:dd/MM/yyyy}"
            gant.Columns("DtEffett").FormatString = "{0:dd/MM/yyyy}"

            Me.gant.GanttViewElement.GraphicalViewElement.TimelineStart = New DateTime(1990, 1, 1)
            Me.gant.GanttViewElement.GraphicalViewElement.TimelineEnd = New DateTime(2030, 12, 31)

            Me.gant.GanttViewElement.GraphicalViewElement.AutomaticTimelineTimeRange = True

            Me.gant.GanttViewElement.GraphicalViewElement.TimelineRange = TimeRange.Year
            Me.SetupTrackbar()

            Dim dateToScroll = New DateTime(2020, 1, 1)
            Me.gant.GanttViewElement.GraphicalViewElement.TimelineStart = New DateTime(Year(dateToScroll), 1, 1)
            Me.gant.GanttViewElement.GraphicalViewElement.ScrollTo(dateToScroll)

            'setup data items
            Dim item1 As New GanttViewDataItem()
            item1.Start = New DateTime(2020, 1, 1)
            item1.[End] = New DateTime(2020, 12, 31)
            item1.Progress = 30D
            item1.Title = "VISITE SEMESTRALI"
            Dim subitem11 As New GanttViewDataItem()
            subitem11.Start = New DateTime(2020, 3, 1)
            subitem11.[End] = New DateTime(2020, 3, 27)
            subitem11.Progress = 10D
            subitem11.Title = "SEM - 1"
            Dim subitem12 As New GanttViewDataItem()
            subitem12.Start = New DateTime(2020, 9, 1)
            subitem12.[End] = New DateTime(2020, 9, 27)
            subitem12.Progress = 20D
            subitem12.Title = "SEM - 2"
            'add subitems
            item1.Items.Add(subitem11)
            item1.Items.Add(subitem12)
            Me.gant.Items.Add(item1)
            Dim item2 As New GanttViewDataItem()
            item2.Start = New DateTime(2020, 1, 1)
            item2.[End] = New DateTime(2020, 12, 31)
            item2.Progress = 40D
            item2.Title = "VISITE ORDINARIE"
            Dim subitem21 As New GanttViewDataItem()
            subitem21.Start = New DateTime(2020, 3, 1)
            subitem21.[End] = New DateTime(2020, 3, 27)
            subitem21.Progress = 10D
            subitem21.Title = "ORD - 1"
            Dim subitem22 As New GanttViewDataItem()
            subitem22.Start = New DateTime(2020, 11, 13)
            subitem22.[End] = New DateTime(2020, 11, 18)
            subitem22.Progress = 30
            subitem22.Title = "ORD - 2"
            Dim subitem23 As New GanttViewDataItem()
            subitem23.Start = New DateTime(2020, 12, 18)
            subitem23.[End] = New DateTime(2020, 12, 19)
            subitem23.Title = "ORD - 3"
            'add subitems
            item2.Items.Add(subitem21)
            item2.Items.Add(subitem22)
            item2.Items.Add(subitem23)
            Me.gant.Items.Add(item2)
            'add links between items
            Dim link1 As New GanttViewLinkDataItem()
            link1.StartItem = subitem11
            link1.EndItem = subitem12
            link1.LinkType = TasksLinkType.FinishToStart
            Me.gant.Links.Add(link1)
            Dim link2 As New GanttViewLinkDataItem()
            link2.StartItem = subitem21
            link2.EndItem = subitem22
            link2.LinkType = TasksLinkType.StartToStart
            Me.gant.Links.Add(link2)
            Dim link3 As New GanttViewLinkDataItem()
            link3.StartItem = subitem22
            link3.EndItem = subitem23
            link3.LinkType = TasksLinkType.FinishToStart
            Me.gant.Links.Add(link3)

            'Me.gant.GanttViewElement.GraphicalViewElement.OnePixelTime = New TimeSpan(5, 0, 0, 0)
            Me.gant.Ratio = 0.3

            'this.radGanttView1.GanttViewElement.TextViewElement.Visibility =
            'Telerik.WinControls.ElementVisibility.Collapsed;
            'this.radGanttView1.Ratio = 0;



        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetupTrackbar()
        AddHandler Me.track.ValueChanged, AddressOf radTrackBarZoom_ValueChanged

        Me.track.LargeTickFrequency = 200
        Me.track.SmallTickFrequency = 20
        Me.track.Minimum = 0
        Me.track.Maximum = 1100
        Me.track.Value = 300

    End Sub

    Private Sub radTrackBarZoom_ValueChanged(sender As Object, e As EventArgs)
        Try

            Dim value As Double = 51 + 0.005 * Math.Pow(Me.track.Value, 2.0)
            Console.WriteLine(String.Format("{0} - {1}", Me.track.Value, value))

            Dim time As New TimeSpan(0, CInt(Math.Truncate(value)), 0)

            Me.gant.GanttViewElement.GraphicalViewElement.OnePixelTime = time
        Catch ex As Exception

        End Try
    End Sub

    Private Sub radGanttView_TextViewItemFormatting(sender As Object, e As GanttViewTextViewItemFormattingEventArgs)
        Try


            If (e.Item.Items.Count > 0) Then
                e.ItemElement.TextAlignment = HorizontalAlignment.Center
                e.ItemElement.DrawFill = True
                e.ItemElement.BackColor = Color.FromArgb(230, 230, 230)
                e.ItemElement.ForeColor = Color.Black
                e.ItemElement.GradientStyle = GradientStyles.Solid
                'ElseIf (e.Item.Start <> e.Item.End) Then
                '    e.ItemElement.DrawFill = True
                '    e.ItemElement.BackColor = Color.Yellow
                '    e.ItemElement.GradientStyle = GradientStyles.Solid
            Else
                e.ItemElement.ResetValue(LightVisualElement.DrawBorderProperty, ValueResetFlags.Local)
                e.ItemElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                e.ItemElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub radGanttView_TextViewCellFormatting(sender As Object, e As GanttViewTextViewCellFormattingEventArgs)
        Try

            If e.Column.Name = "Title" OrElse e.Column.Name = "Note" Then
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft
            Else
                e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub GanttViewElement_ItemEditing(sender As Object, e As GanttViewItemEditingEventArgs)
        e.Cancel = True
    End Sub

    Private Sub crea_grafico_visite(dati As List(Of statManutenzioni), Optional livello As Integer = 0)
        Try
            Me.chartVis.Series.Clear()
            Me.chartVis.Axes.Clear()

            Dim barSeries As New Telerik.WinControls.UI.BarSeries("Statistiche", "Visite")
            Dim barSeries2 As New Telerik.WinControls.UI.BarSeries("Statistiche", "Visite")

            Dim drillControler As New DrillDownController()
            Me.chartVis.Controllers.Add(drillControler)

            'Me.chart1.Series.AddRange(barSeries, barSeries2)

            barSeries.Name = "Q1"
            barSeries2.Name = "Q2"
            barSeries.LegendTitle = "Prevntivate"
            barSeries2.LegendTitle = "Effettuate"

            For i As Integer = 0 To dati.Count - 1
                Dim preventivate As Integer = dati(i).preventivate
                Dim effettuate As Integer = dati(i).effettuate
                Dim categoria As String
                Dim anno As Integer = dati(i).anno
                Dim tipoVis As String = dati(i).tipoVisita
                If livello = 0 Then
                    categoria = anno
                Else
                    categoria = tipoVis
                End If

                barSeries.DataPoints.Add(New CategoricalDataPoint(preventivate, categoria))
                barSeries2.DataPoints.Add(New CategoricalDataPoint(effettuate, categoria))
            Next

            Me.chartVis.Series.Add(barSeries)
            Me.chartVis.Series.Add(barSeries2)

            chartVis.Views.AddNew("Dettaglio")

            Dim categoricalAxis As CategoricalAxis = TryCast(chartVis.Axes(0), CategoricalAxis)
            categoricalAxis.PlotMode = AxisPlotMode.OnTicksPadded
            categoricalAxis.LabelFitMode = AxisLabelFitMode.Rotate
            categoricalAxis.LabelRotationAngle = 310
            categoricalAxis.Font = New Font("Verdana", 6.0F, FontStyle.Regular)
            Dim verticalAxis As LinearAxis = TryCast(chartVis.Axes(1), LinearAxis)
            verticalAxis.ForeColor = Color.Green
            verticalAxis.LabelInterval = 2
            'verticalAxis.LabelFormat = "{0:c}"
            If livello = 0 Then
                chartVis.Area.View.Palette = KnownPalette.Fluent
            Else
                chartVis.Area.View.Palette = KnownPalette.Summer
            End If

            Me.chartVis.ShowTitle = True
            Me.chartVis.ShowLegend = True
            'Me.chart1.ChartElement.LegendElement.StackElement.Orientation = Orientation.Horizontal
            'Me.chart1.LegendTitle = "Lege"
            Me.chartVis.ChartElement.LegendElement.Alignment = ContentAlignment.TopCenter

        Catch ex As Exception

        End Try
    End Sub
    Private Sub chartVis_Drill(sender As Object, e As DrillEventArgs) Handles chartVis.Drill
        Try
            If e.Level > 1 Then
                e.Cancel = True
            End If

            Dim anno As String = ""
            e.View.Series.Clear()
            e.View.Axes.Clear()

            Select Case e.Level
                Case 0
                    async_carica_grafico_manutenzioni(txtCodice.Text, e.Level)
                Case 1
                    If e.SelectedPoint IsNot Nothing Then
                        Dim cc As New CategoricalDataPoint
                        cc = e.SelectedPoint
                        anno = cc.Category
                        async_carica_grafico_manutenzioni_anno(txtCodice.Text, anno, e.Level)
                    End If

            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chartFatturato_Drill(sender As Object, e As DrillEventArgs) Handles chartFatturato.Drill
        Try
            If e.Level > 1 Then
                e.Cancel = True
            End If

            Dim anno As String = ""
            e.View.Series.Clear()
            e.View.Axes.Clear()

            Select Case e.Level
                Case 0
                    async_carica_grafico_fatturato(txtCodice.Text, e.Level)
                Case 1
                    If e.SelectedPoint IsNot Nothing Then
                        Dim cc As New CategoricalDataPoint
                        cc = e.SelectedPoint
                        anno = cc.Category
                        async_carica_grafico_fatturato(txtCodice.Text, anno, e.Level)
                    End If

            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub create_grafico_buoni(dati As List(Of statBuoniImpianto), Optional livello As Integer = 0)
        Try
            chartBuoni.Area.View.Palette = KnownPalette.Lilac
            Me.chartBuoni.AreaType = ChartAreaType.Pie
            Dim series As New DonutSeries()


            Me.smartLabelsController = New SmartLabelsController()
            'Me.smartLabelsController.Strategy.DistanceToLabel = 0
            Me.chartBuoni.Controllers.Add(Me.smartLabelsController)
            For Each controller As ChartViewController In Me.chartBuoni.Controllers
                Dim control As SmartLabelsController = TryCast(controller, SmartLabelsController)

                If control IsNot Nothing Then
                    control.Strategy.DistanceToLabel = -40
                    Me.chartBuoni.View.PerformRefresh(Me.chartBuoni.View, False)
                End If
            Next controller

            Me.chartBuoni.Title = "BUONI EMESSI"
            Me.chartBuoni.ShowTitle = True
            Me.chartBuoni.ChartElement.TitleElement.TextAlignment = ContentAlignment.MiddleCenter
            Me.chartBuoni.ChartElement.TitleElement.BackColor = Color.SteelBlue
            'Me.chartBuoni.ChartElement.TitleElement.ForeColor = Color.White

            For i As Integer = 0 To dati.Count - 1
                Dim anno As Integer = dati(i).anno
                'series.DataPoints.Add(New PieDataPoint(dati(i).nr_buoni, dati(i).anno) With {.Label = dati(i).anno})

                Dim point As New PieDataPoint(dati(i).nr_buoni, dati(i).anno.ToString())
                point.Label = dati(i).anno.ToString
                series.DataPoints.Add(point)
            Next

            series.ShowLabels = True
            series.DrawLinesToLabels = True
            series.SyncLinesToLabelsColor = True
            Me.chartBuoni.Series.Add(series)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub create_grafico_canoni(dati As List(Of statCanoniImpianto), Optional livello As Integer = 0)
        Try
            chartCanoni.Area.View.Palette = KnownPalette.Summer
            Me.chartCanoni.AreaType = ChartAreaType.Pie
            Dim series As New PieSeries()

            Me.smartLabelsController = New SmartLabelsController()
            'Me.smartLabelsController.Strategy.DistanceToLabel = 0
            Me.chartCanoni.Controllers.Add(Me.smartLabelsController)
            For Each controller As ChartViewController In Me.chartCanoni.Controllers
                Dim control As SmartLabelsController = TryCast(controller, SmartLabelsController)

                If control IsNot Nothing Then
                    control.Strategy.DistanceToLabel = -40
                    Me.chartCanoni.View.PerformRefresh(Me.chartCanoni.View, False)
                End If
            Next controller

            Me.chartCanoni.Title = "CANONI EMESSI"
            Me.chartCanoni.ShowTitle = True
            Me.chartCanoni.ChartElement.TitleElement.TextAlignment = ContentAlignment.MiddleCenter
            Me.chartCanoni.ChartElement.TitleElement.BackColor = Color.SteelBlue
            'Me.chartCanoni.ChartElement.TitleElement.ForeColor = Color.White

            For i As Integer = 0 To dati.Count - 1
                Dim anno As Integer = dati(i).anno
                'series.DataPoints.Add(New PieDataPoint(dati(i).nr_buoni, dati(i).anno) With {.Label = dati(i).anno})

                Dim point As New PieDataPoint(dati(i).importo, dati(i).anno.ToString())
                point.Label = dati(i).anno.ToString
                series.DataPoints.Add(point)
            Next

            series.ShowLabels = True
            series.DrawLinesToLabels = True
            series.SyncLinesToLabelsColor = True
            Me.chartCanoni.Series.Add(series)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub create_grafico_fatturato(dati As List(Of statFatturatoImpianto), Optional livello As Integer = 0)
        Try
            chartFatturato.Area.View.Palette = KnownPalette.Summer
            Me.chartFatturato.AreaType = ChartAreaType.Pie
            Dim series As New PieSeries()

            Dim drillControler As New DrillDownController()
            Me.chartFatturato.Controllers.Add(drillControler)

            Me.smartLabelsController = New SmartLabelsController()
            'Me.smartLabelsController.Strategy.DistanceToLabel = 0
            Me.chartFatturato.Controllers.Add(Me.smartLabelsController)
            For Each controller As ChartViewController In Me.chartFatturato.Controllers
                Dim control As SmartLabelsController = TryCast(controller, SmartLabelsController)

                If control IsNot Nothing Then
                    control.Strategy.DistanceToLabel = -40
                    Me.chartFatturato.View.PerformRefresh(Me.chartFatturato.View, False)
                End If
            Next controller

            Me.chartFatturato.Title = "FATTURATO"
            Me.chartFatturato.ShowTitle = True
            Me.chartFatturato.ChartElement.TitleElement.TextAlignment = ContentAlignment.MiddleCenter
            Me.chartFatturato.ChartElement.TitleElement.BackColor = Color.SteelBlue
            'Me.chartCanoni.ChartElement.TitleElement.ForeColor = Color.White

            For i As Integer = 0 To dati.Count - 1
                Dim valore As String

                If livello = 0 Then
                    valore = dati(i).anno
                Else
                    valore = dati(i).tipoFatt
                End If

                Dim point As New PieDataPoint(dati(i).importo, valore)
                point.Label = valore
                series.DataPoints.Add(point)
            Next

            series.ShowLabels = True
            series.DrawLinesToLabels = True
            series.SyncLinesToLabelsColor = True
            Me.chartFatturato.Series.Add(series)

            chartFatturato.Controllers.Add(New ChartSelectionController())
            chartFatturato.SelectionMode = ChartSelectionMode.SingleDataPoint

        Catch ex As Exception

        End Try

    End Sub

    Private Sub chartFatturato_SelectedPointChanged(ByVal sender As Object, ByVal e As ChartViewSelectedPointChangedEventArgs) Handles chartFatturato.SelectedPointChanged
        Dim areaType As ChartAreaType = Me.chartFatturato.AreaType

        If areaType <> ChartAreaType.Polar Then
            Me.chartFatturato.Series.Clear()

            Select Case areaType
                Case ChartAreaType.Cartesian

                Case ChartAreaType.Funnel

                Case ChartAreaType.Pie
                    Dim pieDataPoint As PieDataPoint = TryCast(e.NewSelectedPoint, PieDataPoint)
                    Dim valore = pieDataPoint.LegendTitle
                    async_carica_grafico_fatturato(txtCodice.Text, valore, 1)

            End Select
        End If
    End Sub

    Private Sub chartFatturato_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles chartFatturato.MouseDown
        Dim grid As RadChartView = CType(sender, RadChartView)
        Dim backBtn As DrillBackSingleButton = TryCast(grid.ElementTree.GetElementAtPoint(e.Location), DrillBackSingleButton)

        If backBtn IsNot Nothing Then
            Dim areaType As ChartAreaType = Me.chartFatturato.AreaType

            If areaType <> ChartAreaType.Pie Then
                Me.chartFatturato.Series.Clear()

                Select Case areaType
                    Case ChartAreaType.Cartesian
                        'Me.InitPieSeries()
                        'Me.radChartView1.AreaType = ChartAreaType.Pie
                        'Me.radChartView1.Series.Add(Me.pieSeries)
                    Case ChartAreaType.Funnel
                        'Me.InitBarSeries()
                        'Me.radChartView1.AreaType = ChartAreaType.Cartesian
                        'Me.radChartView1.Series.Add(BarSeries)
                    Case ChartAreaType.Polar
                        'Me.InitFunnelSeries()
                        'Me.radChartView1.AreaType = ChartAreaType.Funnel
                        'Me.radChartView1.Series.Add(FunnelSeries)
                End Select
            End If

            Return
        End If

        Dim homeBtn As DrillBackHomeButton = TryCast(grid.ElementTree.GetElementAtPoint(e.Location), DrillBackHomeButton)

        If homeBtn IsNot Nothing Then
            Me.chartFatturato.Series.Clear()
            async_carica_grafico_fatturato(txtCodice.Text, "", 0)

        End If
    End Sub

    Private Sub create_grafico_chiamate(dati As List(Of statChiamateImpianto), Optional livello As Integer = 0)
        Try
            chartChiamate.Area.View.Palette = KnownPalette.Fluent


            Me.chartChiamate.Title = "INTERVENTI SU CHIAMATA"
            Me.chartChiamate.ShowTitle = True
            Me.chartChiamate.ChartElement.TitleElement.TextAlignment = ContentAlignment.MiddleCenter
            Me.chartChiamate.ChartElement.TitleElement.BackColor = Color.SteelBlue
            'Me.chartCanoni.ChartElement.TitleElement.ForeColor = Color.White

            Me.chartChiamate.Series.Clear()
            Me.chartChiamate.Axes.Clear()

            'Dim drillControler As New DrillDownController()
            'Me.chartChiamate.Controllers.Add(drillControler)

            'Me.chart1.Series.AddRange(barSeries, barSeries2)


            For i As Integer = 0 To dati.Count - 1
                Dim barSeries As New Telerik.WinControls.UI.BarSeries("Interventi", "Chiamate")
                barSeries.Name = dati(i).anno
                barSeries.LegendTitle = dati(i).anno

                Dim chiamate As Integer = dati(i).nr_chiamate
                Dim categoria As String
                Dim anno As Integer = dati(i).anno
                Dim tipoVis As String = ""
                If livello = 0 Then
                    categoria = anno
                Else
                    categoria = tipoVis
                End If

                BarSeries.DataPoints.Add(New CategoricalDataPoint(chiamate, categoria))
                Me.chartChiamate.Series.Add(barSeries)
            Next


            chartChiamate.Views.AddNew("Dettaglio")

            Dim categoricalAxis As CategoricalAxis = TryCast(chartChiamate.Axes(0), CategoricalAxis)
            categoricalAxis.PlotMode = AxisPlotMode.OnTicksPadded
            categoricalAxis.LabelFitMode = AxisLabelFitMode.Rotate
            categoricalAxis.LabelRotationAngle = 310
            categoricalAxis.Font = New Font("Verdana", 6.0F, FontStyle.Regular)
            Dim verticalAxis As LinearAxis = TryCast(chartVis.Axes(1), LinearAxis)
            verticalAxis.ForeColor = Color.Green
            verticalAxis.LabelInterval = 2
            'verticalAxis.LabelFormat = "{0:c}"
            If livello = 0 Then
                chartChiamate.Area.View.Palette = KnownPalette.Fluent
            Else
                chartChiamate.Area.View.Palette = KnownPalette.Summer
            End If

            Me.chartChiamate.ShowTitle = True
            Me.chartChiamate.ShowLegend = True
            'Me.chart1.ChartElement.LegendElement.StackElement.Orientation = Orientation.Horizontal
            'Me.chart1.LegendTitle = "Lege"
            Me.chartChiamate.ChartElement.LegendElement.Alignment = ContentAlignment.TopCenter

        Catch ex As Exception

        End Try

    End Sub

    Private Sub carica_dati_visite_asset(azione As String)
        Try
            Select Case azione
                Case Is = "NUOVO"
                    txtGGstartupA.Value = 0
                    txtPerFinA.Text = ""
                    txtPerIniA.Text = ""
                    txtFreqA.Value = 0
                    'txtDescr.Text = ""
                    cmbTipiVis.SelectedIndex = -1

                Case Is = "MODIFICA"
                    If gridAsset.Rows.Count > 0 Then
                        'txtCodice.Text = gridAsset.CurrentRow.Cells("CHID").Value
                        'txtDescr.Text = gridAsset.CurrentRow.Cells("CHDESCR").Value
                        'cmbMacroCat.SelectedValue = gridAsset.CurrentRow.Cells("CHCDCAT").Value
                        Try
                            cmbTipiVis.SelectedValue = gridPianAsset.CurrentRow.Cells("CODICEVISITA").Value
                            txtFreqA.Value = gridPianAsset.CurrentRow.Cells("FREQUENZA").Value

                            If gridPianAsset.CurrentRow.Cells("FlagUltimaDataVisita").Value = "S" Then
                                chkUltVisA.Checked = True
                            Else
                                chkUltVisA.Checked = False
                            End If
                        Catch ex As Exception

                        End Try

                    End If

            End Select


        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub carica_dati_asset(azione As String)
        Try
            Select Case azione
                Case Is = "NUOVO"
                    txtNumAssets.Value = 0
                    cmbAssets.SelectedIndex = -1

                Case Is = "MODIFICA"
                    If gridAsset.Rows.Count > 0 Then
                        'txtCodice.Text = gridAsset.CurrentRow.Cells("CHID").Value
                        txtNumAssets.Value = gridAsset.CurrentRow.Cells("NUMCHL").Value
                        cmbAssets.SelectedValue = gridAsset.CurrentRow.Cells("CHID").Value
                        'cmbCategoria.SelectedValue = gridAsset.CurrentRow.Cells("CODCATASSET").Value
                    End If

            End Select


        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub abilita_elementi(abilita As Boolean, tipo As String)
        Try
            If tipo = "PARAMASSET" Then
                cmdBarPianAsset.Enabled = Not abilita
                cmdBarAssets.Enabled = Not abilita
                'cmdInsPianA.Enabled = Not abilita
                'cmdDelPianA.Enabled = Not abilita
                'cmdModPianA.Enabled = Not abilita
                gridPianAsset.Enabled = Not abilita
                gridAsset.Enabled = Not abilita
                gridTecAsset.Enabled = Not abilita
                pnlDati.Visible = abilita
                If azioneVisiteAsset = "MODIFICA" Then
                    cmbTipiVis.Enabled = False
                Else
                    cmbTipiVis.Enabled = True
                End If
            ElseIf tipo = "ASSETS" Then
                'cmdInsDett.Enabled = Not abilita
                'cmdModDett.Enabled = Not abilita

                cmdBarPianAsset.Enabled = Not abilita
                cmdBarAssets.Enabled = Not abilita
                gridPianAsset.Enabled = Not abilita
                gridAsset.Enabled = Not abilita
                gridTecAsset.Enabled = Not abilita
                pnlAsset.Visible = abilita
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdInsPianA_Click(sender As Object, e As EventArgs) Handles cmdInsPianA.Click
        Try
            If gridAsset.Rows.Count = 0 Then Exit Sub
            azioneVisiteAsset = "NUOVO"

            abilita_elementi(True, "PARAMASSET")
            carica_combo_tipi_visite(cmbCategoriaImp.SelectedItem.Value)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdModPianA_Click(sender As Object, e As EventArgs) Handles cmdModPianA.Click
        Try
            If gridAsset.Rows.Count = 0 Then Exit Sub
            azioneVisiteAsset = "MODIFICA"
            Dim impianto As String = idImpianto
            Dim asset As String = gridAsset.CurrentRow.Cells("CHID").Value

            abilita_elementi(True, "PARAMASSET")
            carica_combo_tipi_visite(cmbCategoriaImp.SelectedItem.Value, impianto, asset)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdAnnPianA_Click(sender As Object, e As EventArgs) Handles cmdAnnPianA.Click
        abilita_elementi(False, "PARAMASSET")
    End Sub

    Private Sub cmdSalvaPianA_Click(sender As Object, e As EventArgs) Handles cmdSalvaPianA.Click
        Dim cdimp As String
        Dim cdasset As String
        Dim cdcat As String
        Dim id As Integer
        Dim flPian As String

        ''''Dim rowInfo = New GridViewDataRowInfo(Me.gridPianAsset.MasterView)
        ''''rowInfo.Cells("ID").Value = gridAsset.CurrentRow.Cells("CHID").Value
        ''''rowInfo.Cells("CodiceVisita").Value = cmbTipiVis.SelectedValue
        ''''rowInfo.Cells("DescrVisita").Value = cmbTipiVis.Text
        ''''rowInfo.Cells("Frequenza").Value = txtFreqA.Value
        ''''rowInfo.Cells("GGSTURTUP").Value = txtGGstartupA.Value
        '''''rowInfo.Cells("CODCATASSET").Value = frm.rtnAsset.CodCatAsset

        '''''Dim index = gridAsset.Rows.IndexOf(row)
        ''''gridPianAsset.Rows.Add(rowInfo)

        cdimp = txtCodice.Text
        cdasset = gridAsset.CurrentRow.Cells("CHID").Value
        cdcat = cmbCategoriaImp.SelectedValue
        If azioneVisiteAsset <> "NUOVO" Then
            id = gridPianAsset.CurrentRow.Cells("ID").Value
        End If
        Me.SaveParametriVisitaAsset(cdimp, cdasset, cdcat, azioneVisiteAsset, id)
        abilita_elementi(False, "PARAMASSET")
    End Sub

    Private Sub cmdConfermaAss_Click(sender As Object, e As EventArgs) Handles cmdConfermaAss.Click
        Try
            Dim cdimp As String
            Dim cdasset As String
            Dim nrass As Integer

            cdimp = txtCodice.Text
            cdasset = cmbAssets.SelectedValue
            nrass = txtNumAssets.Value

            Me.saveAssetImpianto(cdimp, cdasset, nrass, azioneAsset)
            abilita_elementi(False, "ASSETS")
            'Me.async_carica_griglia_asset_impianto()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub cmdModDett_Click(sender As Object, e As EventArgs) Handles cmdModDett.Click
        Try
            azioneAsset = "MODIFICA"
            abilita_elementi(True, "ASSETS")
            carica_combo_Assets(cmbCategoriaImp.SelectedItem.Value)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub cmdAnnullaAss_Click(sender As Object, e As EventArgs) Handles cmdAnnullaAss.Click
        abilita_elementi(False, "ASSETS")
    End Sub

    Private Sub cmdSalvaTpVis_Click(sender As Object, e As EventArgs) Handles cmdSalvaTpVis.Click
        Dim cdimp As String
        Dim cdasset As String
        Dim cdcat As String
        Dim id As Integer
        Dim azione As String

        cdimp = txtCodice.Text
        cdasset = "0"
        cdcat = cmbCategoriaImp.SelectedValue
        id = CInt(lblId.Text)
        If id = 0 Then
            azione = "NUOVO"
        Else
            azione = "MODIFICA"
        End If
        Me.SaveParametriVisitaImpianto(cdimp, cdasset, cdcat, azione, id)

    End Sub

    Private Sub cmbTipiVis_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipiVis.SelectedValueChanged
        abilita_campi_visite_asset()
    End Sub

    Private Sub abilita_campi_visite_asset()
        Try

            If cmbTipiVis.EditorControl.Rows(cmbTipiVis.SelectedIndex).Cells("flagVisOrdinaria").Value = "S" OrElse
                    cmbTipiVis.EditorControl.Rows(cmbTipiVis.SelectedIndex).Cells("flagVisSemestrale").Value = "S" OrElse
                    cmbTipiVis.EditorControl.Rows(cmbTipiVis.SelectedIndex).Cells("flagVisBiennale").Value = "S" Then
                txtFreqA.Enabled = True
                txtGGstartupA.Enabled = False
                txtPerFinA.Enabled = False
                txtPerIniA.Enabled = False

            ElseIf cmbTipiVis.EditorControl.Rows(cmbTipiVis.SelectedIndex).Cells("flagVisStagionale").Value Then
                txtFreqA.Enabled = False
                txtGGstartupA.Enabled = False
                txtPerFinA.Enabled = True
                txtPerIniA.Enabled = True

            ElseIf cmbTipiVis.EditorControl.Rows(cmbTipiVis.SelectedIndex).Cells("flagVisCiclica").Value Then
                txtFreqA.Enabled = True
                txtGGstartupA.Enabled = True
                txtPerFinA.Enabled = False
                txtPerIniA.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub




    Private Sub gridDoc_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles gridDoc.CellDoubleClick
        Try
            Dim sUrl As String = "http://srvedoc/images.asmx"

            Dim cl As New wsEdoc(sUrl, "RM400", "servizio")
            'cl.retrive_documento_EDOC("999", "TipoDocumento=Fatture Attive")
            cl.retrive_documento_EDOC("999", "TipoDocumento=014&ND=1&DD=09/01/2020")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdEliminaRiga_Click(sender As Object, e As EventArgs) Handles cmdEliminaRiga.Click
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            Dim cdimp As String
            Dim cdasset As String
            Dim nrass As Integer

            If gridAsset.Rows.Count = 0 Then Exit Sub

            Dim ds As DialogResult = Telerik.WinControls.RadMessageBox.Show(Me, "Eliminare l'asset ?", "Asset impianto", MessageBoxButtons.YesNo, RadMessageIcon.Question)

            If ds.ToString = "No" Then
                Exit Sub
            End If

            azioneAsset = "ELIMINA"
            cdimp = txtCodice.Text
            cdasset = gridAsset.CurrentRow.Cells("CHID").Value

            Me.saveAssetImpianto(cdimp, cdasset, 0, azioneAsset)
            'Me.async_carica_griglia_asset_impianto()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
End Class
