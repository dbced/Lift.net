Imports Telerik.WinControls.UI.Map
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
Imports Telerik.Charting
Imports Telerik.WinControls.Primitives
Imports Telerik.WinControls.UI.Docking
Imports LiftCore.ws_visirun
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Xml
Imports System.IO


Public Class FrmChiamate

    Private ws As New webServices
    Private wsVisirun As New wsVisiRun
    Private BGWorkDett As BackgroundWorker

    Private posTec As Threading.Tasks.Task(Of List(Of elencoTecnici))
    Private TecniciCentro As Threading.Tasks.Task(Of List(Of elencoTecnici))

    Dim statoCaricaSoc As Boolean
    Dim statoCaricaCen As Boolean
    Dim statoCaricaTecnico As Boolean

    Dim formInCaricamento As Boolean
    Dim grigliaCreata As Boolean
    Dim azione As String
    Dim batchCaricaMappa As String


    Public Sub New(ByVal inAzione As String, Optional ByVal ElencoCentri As String = "", Optional ByVal inUser As String = "", Optional ByVal inRuolo As String = "", Optional ByVal inUserAS As String = "", Optional ByVal modifica As Boolean = True, Optional ByVal testo As String = "")
        InitializeComponent()
        WireEvents()

        'azione = inAzione

        'ruolo = inRuolo
        'user = inUser
        'userAS = inUserAS
        'gElencoCentri = ElencoCentri
    End Sub

    Protected Sub WireEvents()
        AddHandler grid.ViewCellFormatting, AddressOf grid_ViewCellFormatting
        AddHandler grid.ViewRowFormatting, AddressOf grid_ViewRowFormatting
        AddHandler grid.CellFormatting, AddressOf grid_CellFormatting
        AddHandler grid.ContextMenuOpening, AddressOf grid_ContextMenuOpening
        AddHandler grid.ValueChanging, AddressOf grid_ValueChanging
    End Sub

    Private Sub inizializza_background()
        Try

            BGWorkDett = New BackgroundWorker()
            AddHandler BGWorkDett.DoWork, AddressOf BGWorkDett_DoWork
            AddHandler BGWorkDett.RunWorkerCompleted, AddressOf BGWorkDett_RunWorkerCompleted

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmChiamate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonDFT.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonBLU.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonRED.tssp")

            cmdConferma.ThemeName = "buttonBLU"
            cmdAnnulla.ThemeName = "buttonDFT"
            cmdOkSearchImp.ThemeName = "buttonDFT"
            cmdSearchImp.ThemeName = "buttonDFT"
            cmdSearchCen.ThemeName = "buttonDFT"
            cmdSearchSoc.ThemeName = "buttonDFT"
            cmdSearchCli.ThemeName = "buttonDFT"
            cmdSearchTec.ThemeName = "buttonDFT"


            cmdFiltro.ThemeName = "buttonDFT"


            grigliaCreata = False

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            t1.Enabled = True
            formInCaricamento = True
            Me.inizializza_background()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BGWorkDett_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Try
            'dtFattDett = CreateDataSource_dett(Codice_Distinta, Codice_Documento)
            Select Case batchCaricaMappa
                Case "TECNICI"
                    crea_posizioni_tecnici(posTec)
                Case "AREA"
                    crea_posizioni_tecnici_vicino_impianto()
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BGWorkDett_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        Try

            Me.map.Zoom(13)

            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False

        Catch

        End Try

    End Sub

    Private Sub cmdOkSearchImp_Click(sender As Object, e As EventArgs) Handles cmdOkSearchImp.Click
        Try
            Dim frm As New FrmImpiantiElenco(Me, "", "", "", "", "RICERCA")
            'frm.CodiceOut = ""
            'frm.DescrOut = ""
            frm.ShowDialog()
            TxtCodice.Text = frm.AICIM
            txtIndirizzo.Text = frm.AISTR & " " & frm.AIIND
            txtLocalita.Text = frm.AILOC
            txtCap.Text = frm.AICAP
            txtProv.Text = frm.AISPR
            frm.Dispose()

            Me.crea_mappa_impianto()
            Me.map.Visible = True
            cmdBCaricaLimit.Enabled = True
            cmdBcaricaTecnici.Enabled = True

        Catch ex As Exception
            TxtCodice.Text = ""
            txtIndirizzo.Text = ""
            txtLocalita.Text = ""
            txtCap.Text = ""
            txtProv.Text = ""
        End Try
    End Sub

    Private Sub crea_griglia_chiamate()
        Try
            'Me.LoadSummaryCanoni()

            Me.grid.BeginEdit()
            'Me.gridImpianti.EnableFiltering = True
            'Me.gridImpianti.MasterTemplate.ShowHeaderCellButtons = True
            Me.grid.MasterTemplate.ShowFilteringRow = False
            Me.grid.AllowAddNewRow = False
            Me.grid.AutoGenerateColumns = False
            Me.grid.EnableGrouping = False

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
            Dim colA7SOCMDB As New GridViewTextBoxColumn
            Dim colA7CENMDB As New GridViewTextBoxColumn
            Dim colA7IDCHIA As New GridViewTextBoxColumn
            Dim colA7CODIMP As New GridViewTextBoxColumn
            Dim colA7CHIMAN As New GridViewTextBoxColumn
            Dim colA7TELCHIAM As New GridViewTextBoxColumn
            Dim colA7MOTIVO As New GridViewTextBoxColumn
            Dim colA7CODTEC As New GridViewTextBoxColumn
            Dim colA7TSAPER As New GridViewTextBoxColumn
            Dim colA7TSASSE As New GridViewTextBoxColumn
            Dim colA7TSSOSP As New GridViewTextBoxColumn
            Dim colA7TSCHIU As New GridViewTextBoxColumn
            Dim colA7STATOC As New GridViewTextBoxColumn
            Dim colA7RISCON As New GridViewTextBoxColumn
            Dim colA7ORAAP As New GridViewTextBoxColumn
            Dim colA7ORAAS As New GridViewTextBoxColumn
            Dim colA7ORASO As New GridViewTextBoxColumn
            Dim colA7ORACH As New GridViewTextBoxColumn
            Dim colA7TSLAVO As New GridViewTextBoxColumn
            Dim colA7ORALA As New GridViewTextBoxColumn
            Dim colA7REPERIB As New GridViewTextBoxColumn
            Dim colA7CRITICIT As New GridViewTextBoxColumn
            Dim colA7FLINTRAP As New GridViewTextBoxColumn
            Dim colA7FLORE13 As New GridViewTextBoxColumn
            Dim colA7IDITECS As New GridViewTextBoxColumn
            Dim colA7IDEVSTAT As New GridViewTextBoxColumn
            Dim colAILOC As New GridViewTextBoxColumn
            Dim colAIIND As New GridViewTextBoxColumn
            Dim colAISPR As New GridViewTextBoxColumn
            Dim colATRAG As New GridViewTextBoxColumn
            Dim colAICAP As New GridViewTextBoxColumn
            Dim colA7FLIMPFER As New GridViewTextBoxColumn

            colA7SOCMDB.Name = "A7SOCMDB"
            colA7CENMDB.Name = "A7CENMDB"
            colA7IDCHIA.Name = "A7IDCHIA"
            colA7CODIMP.Name = "A7CODIMP"
            colA7CHIMAN.Name = "A7CHIMAN"
            colA7TELCHIAM.Name = "A7TELCHIAM"
            colA7MOTIVO.Name = "A7MOTIVO"
            colA7CODTEC.Name = "A7CODTEC"
            colA7TSAPER.Name = "A7TSAPER"
            colA7TSASSE.Name = "A7TSASSE"
            colA7TSSOSP.Name = "A7TSSOSP"
            colA7TSCHIU.Name = "A7TSCHIU"
            colA7STATOC.Name = "A7STATOC"
            colA7RISCON.Name = "A7RISCON"
            colA7ORAAP.Name = "A7ORAAP"
            colA7ORAAS.Name = "A7ORAAS"
            colA7ORASO.Name = "A7ORASO"
            colA7ORACH.Name = "A7ORACH"
            colA7TSLAVO.Name = "A7TSLAVO"
            colA7ORALA.Name = "A7ORALA"
            colA7REPERIB.Name = "A7REPERIB"
            colA7CRITICIT.Name = "A7CRITICIT"
            colA7FLINTRAP.Name = "A7FLINTRAP"
            colA7FLORE13.Name = "A7FLORE13"
            colA7IDITECS.Name = "A7IDITECS"
            colA7IDEVSTAT.Name = "A7IDEVSTAT"
            colAILOC.Name = "AILOC"
            colAIIND.Name = "AIIND"
            colAISPR.Name = "AISPR"
            colATRAG.Name = "ATRAG"
            colAICAP.Name = "AICAP"
            colA7FLIMPFER.Name = "A7FLIMPFER"

            colA7SOCMDB.DataType = GetType(String)
            colA7CENMDB.DataType = GetType(String)
            colA7IDCHIA.DataType = GetType(Long)
            colA7CODIMP.DataType = GetType(Long)
            colA7CHIMAN.DataType = GetType(String)
            colA7TELCHIAM.DataType = GetType(String)
            colA7MOTIVO.DataType = GetType(String)
            colA7CODTEC.DataType = GetType(String)
            colA7TSAPER.DataType = GetType(Date)
            colA7TSASSE.DataType = GetType(Date)
            colA7TSSOSP.DataType = GetType(Date)
            colA7TSCHIU.DataType = GetType(Date)
            colA7STATOC.DataType = GetType(String)
            colA7RISCON.DataType = GetType(String)
            colA7ORAAP.DataType = GetType(String)
            colA7ORAAS.DataType = GetType(String)
            colA7ORASO.DataType = GetType(String)
            colA7ORACH.DataType = GetType(String)
            colA7TSLAVO.DataType = GetType(Date)
            colA7ORALA.DataType = GetType(String)
            colA7REPERIB.DataType = GetType(String)
            colA7CRITICIT.DataType = GetType(String)
            colA7FLINTRAP.DataType = GetType(String)
            colA7FLORE13.DataType = GetType(String)
            colA7IDITECS.DataType = GetType(Long)
            colA7IDEVSTAT.DataType = GetType(Long)
            colAILOC.DataType = GetType(String)
            colAIIND.DataType = GetType(String)
            colAISPR.DataType = GetType(String)
            colATRAG.DataType = GetType(String)
            colAICAP.DataType = GetType(String)
            colA7FLIMPFER.DataType = GetType(String)

            colA7SOCMDB.FieldName = "A7SOCMDB"
            colA7CENMDB.FieldName = "A7CENMDB"
            colA7IDCHIA.FieldName = "A7IDCHIA"
            colA7CODIMP.FieldName = "A7CODIMP"
            colA7CHIMAN.FieldName = "A7CHIMAN"
            colA7TELCHIAM.FieldName = "A7TELCHIAM"
            colA7MOTIVO.FieldName = "A7MOTIVO"
            colA7CODTEC.FieldName = "A7CODTEC"
            colA7TSAPER.FieldName = "A7TSAPER"
            colA7TSASSE.FieldName = "A7TSASSE"
            colA7TSSOSP.FieldName = "A7TSSOSP"
            colA7TSCHIU.FieldName = "A7TSCHIU"
            colA7STATOC.FieldName = "A7STATOC"
            colA7RISCON.FieldName = "A7RISCON"
            colA7ORAAP.FieldName = "A7ORAAP"
            colA7ORAAS.FieldName = "A7ORAAS"
            colA7ORASO.FieldName = "A7ORASO"
            colA7ORACH.FieldName = "A7ORACH"
            colA7TSLAVO.FieldName = "A7TSLAVO"
            colA7ORALA.FieldName = "A7ORALA"
            colA7REPERIB.FieldName = "A7REPERIB"
            colA7CRITICIT.FieldName = "A7CRITICIT"
            colA7FLINTRAP.FieldName = "A7FLINTRAP"
            colA7FLORE13.FieldName = "A7FLORE13"
            colA7IDITECS.FieldName = "A7IDITECS"
            colA7IDEVSTAT.FieldName = "A7IDEVSTAT"
            colAILOC.FieldName = "AILOC"
            colAIIND.FieldName = "AIIND"
            colAISPR.FieldName = "AISPR"
            colATRAG.FieldName = "ATRAG"
            colAICAP.FieldName = "AICAP"
            colA7FLIMPFER.FieldName = "A7FLIMPFER"

            grid.MasterTemplate.Columns.Add(colA7SOCMDB)
            grid.MasterTemplate.Columns.Add(colA7CENMDB)
            grid.MasterTemplate.Columns.Add(colA7IDCHIA)
            grid.MasterTemplate.Columns.Add(colA7CODIMP)
            grid.MasterTemplate.Columns.Add(colAIIND)
            grid.MasterTemplate.Columns.Add(colA7MOTIVO)
            grid.MasterTemplate.Columns.Add(colA7CHIMAN)
            grid.MasterTemplate.Columns.Add(colA7CODTEC)
            grid.MasterTemplate.Columns.Add(colATRAG)
            grid.MasterTemplate.Columns.Add(colA7TSAPER)
            grid.MasterTemplate.Columns.Add(colA7TSASSE)
            grid.MasterTemplate.Columns.Add(colA7TSSOSP)
            grid.MasterTemplate.Columns.Add(colA7TSCHIU)
            grid.MasterTemplate.Columns.Add(colA7STATOC)
            grid.MasterTemplate.Columns.Add(colA7TELCHIAM)
            grid.MasterTemplate.Columns.Add(colA7RISCON)
            grid.MasterTemplate.Columns.Add(colA7ORAAP)
            grid.MasterTemplate.Columns.Add(colA7ORAAS)
            grid.MasterTemplate.Columns.Add(colA7ORASO)
            grid.MasterTemplate.Columns.Add(colA7ORACH)
            grid.MasterTemplate.Columns.Add(colA7TSLAVO)
            grid.MasterTemplate.Columns.Add(colA7ORALA)
            grid.MasterTemplate.Columns.Add(colA7REPERIB)
            grid.MasterTemplate.Columns.Add(colA7CRITICIT)
            grid.MasterTemplate.Columns.Add(colA7FLINTRAP)
            grid.MasterTemplate.Columns.Add(colA7FLORE13)
            grid.MasterTemplate.Columns.Add(colA7IDITECS)
            grid.MasterTemplate.Columns.Add(colA7IDEVSTAT)
            grid.MasterTemplate.Columns.Add(colAILOC)
            grid.MasterTemplate.Columns.Add(colAISPR)
            grid.MasterTemplate.Columns.Add(colAICAP)
            grid.MasterTemplate.Columns.Add(colA7FLIMPFER)

            grid.TableElement.SearchHighlightColor = Color.LimeGreen

            Me.grid.EndEdit()
            grigliaCreata = True

            'gridImpianti.AllowSearchRow = True
            'grid.MasterView.SummaryRows(0).PinPosition = PinnedRowPosition.Bottom

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Crea griglia chiamate")
        End Try
    End Sub
    Private Async Sub async_carica_griglia_chiamate(parms As parmsRicChiamate)

        Try
            If formInCaricamento = False Then
                wb.AssociatedControl = Me
                wb.StartWaiting()
                wb.Visible = True
            End If

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoChiamate))
            elementi = ws.getElencoChiamate(parms)
            Await elementi

            carica_griglia_chiamate(elementi.Result)

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

    Private Sub carica_griglia_chiamate(dati As List(Of elencoChiamate))
        Try

            grid.DataSource = dati
            Me.HeaderText_ColumnGriglia_chiamate()
            Me.HeaderText_Column_Grigliachiamate_width()

            Me.grid.MasterTemplate.ShowFilteringRow = False

            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
        End Try

    End Sub

    Private Sub HeaderText_ColumnGriglia_chiamate()
        Try

            Me.grid.Columns("A7SOCMDB").HeaderText = "Soc"
            Me.grid.Columns("A7CENMDB").HeaderText = "Centro"
            Me.grid.Columns("A7IDCHIA").HeaderText = "ID"
            Me.grid.Columns("A7CODIMP").HeaderText = "Cod. Impianto"
            Me.grid.Columns("AIIND").HeaderText = "Indirizzo"
            Me.grid.Columns("A7CHIMAN").HeaderText = "Chiamante"
            Me.grid.Columns("A7TELCHIAM").HeaderText = "Telefono"
            Me.grid.Columns("A7MOTIVO").HeaderText = "Motivo"
            Me.grid.Columns("ATRAG").HeaderText = "Tecnico"
            Me.grid.Columns("A7TSAPER").HeaderText = "Apertura"
            Me.grid.Columns("A7TSASSE").HeaderText = "Assegnaz."
            Me.grid.Columns("A7TSSOSP").HeaderText = "Sospesa"
            Me.grid.Columns("A7TSCHIU").HeaderText = "Chiusa"
            Me.grid.Columns("A7STATOC").HeaderText = "Stato"

            Me.grid.Columns("A7SOCMDB").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("A7CENMDB").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("A7IDCHIA").TextAlignment = ContentAlignment.MiddleLeft
            Me.grid.Columns("A7CODIMP").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("A7CODTEC").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("A7STATOC").TextAlignment = ContentAlignment.MiddleCenter

            For Each col In Me.grid.Columns
                col.ReadOnly = True
                col.IsVisible = False
            Next

            Me.grid.Columns("A7SOCMDB").IsVisible = True
            Me.grid.Columns("A7CENMDB").IsVisible = True
            'Me.grid.Columns("A7IDCHIA").IsVisible = True
            Me.grid.Columns("A7CODIMP").IsVisible = True
            Me.grid.Columns("AIIND").IsVisible = True
            'Me.grid.Columns("A7CHIMAN").IsVisible = True
            'Me.grid.Columns("A7TELCHIAM").IsVisible = True
            Me.grid.Columns("A7MOTIVO").IsVisible = True
            Me.grid.Columns("ATRAG").IsVisible = True
            Me.grid.Columns("A7TSAPER").IsVisible = True
            'Me.grid.Columns("A7TSASSE").IsVisible = True
            'Me.grid.Columns("A7TSSOSP").IsVisible = True
            Me.grid.Columns("A7TSCHIU").IsVisible = True
            Me.grid.Columns("A7STATOC").IsVisible = True


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_Grigliachiamate_width()
        Try

            Me.grid.Columns("A7SOCMDB").Width = 30
            Me.grid.Columns("A7IDCHIA").Width = 60
            Me.grid.Columns("A7CENMDB").Width = 50
            Me.grid.Columns("A7CODIMP").Width = 60
            Me.grid.Columns("A7CHIMAN").Width = 150
            Me.grid.Columns("A7MOTIVO").Width = 150
            Me.grid.Columns("A7TELCHIAM").Width = 80
            Me.grid.Columns("ATRAG").Width = 150
            Me.grid.Columns("A7TSAPER").Width = 70
            Me.grid.Columns("A7TSASSE").Width = 70
            Me.grid.Columns("A7TSSOSP").Width = 70
            Me.grid.Columns("A7TSCHIU").Width = 70
            Me.grid.Columns("A7STATOC").Width = 40
            Me.grid.Columns("AIIND").Width = 220

            Me.grid.Columns("A7TSAPER").FormatString = "{0:dd/MM/yyyy}"
            Me.grid.Columns("A7TSASSE").FormatString = "{0:dd/MM/yyyy}"
            Me.grid.Columns("A7TSSOSP").FormatString = "{0:dd/MM/yyyy}"
            Me.grid.Columns("A7TSCHIU").FormatString = "{0:dd/MM/yyyy}"
            Me.grid.Columns("A7STATOC").FormatString = "{0:dd/MM/yyyy}"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub carica_dati_liste()
        Try
            carica_combo_tabelle("SOC", cmbSocieta, "")
            carica_combo_tipi_tabelle_colonne("CENTRI", cmbCentri, "")
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
                Case "SOC"
                    statoCaricaSoc = True

            End Select

        Catch ex As Exception
            statoCaricaSoc = True
            statoCaricaCen = True

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
                Case "CEN"
                    statoCaricaCen = True

            End Select

        Catch ex As Exception
            statoCaricaSoc = True
            statoCaricaCen = True
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_tecnici(codCen As String, valoreIniziale As String)
        Try
            If formInCaricamento = False Then
                wb.AssociatedControl = Me
                wb.StartWaiting()
                wb.Visible = True
            End If

            Dim filtro As String = "RTCCE IN ('" & codCen & "')"

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoTecnici))
            elementi = ws.getElencoTecnici("", "", filtro)
            Await elementi

            TecniciCentro = elementi

            cmbTecnico.Columns.Clear()
            cmbTecnico.MultiColumnComboBoxElement.DropDownAnimationEnabled = False

            cmbTecnico.AutoSizeDropDownToBestFit = True
            Dim multiColumnComboElement As RadMultiColumnComboBoxElement = cmbTecnico.MultiColumnComboBoxElement
            multiColumnComboElement.DropDownSizingMode = SizingMode.UpDownAndRightBottom
            multiColumnComboElement.DropDownMinSize = New Size(420, 300)
            multiColumnComboElement.EditorControl.MasterTemplate.AutoGenerateColumns = False

            Dim column = New GridViewTextBoxColumn("ATCOD")
            column.HeaderText = "Codice"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("ATRAG")
            column.HeaderText = "Descrizione"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("ATARGA")
            column.HeaderText = "Targa"
            multiColumnComboElement.Columns.Add(column)

            cmbTecnico.DisplayMember = "ATRAG"
            cmbTecnico.ValueMember = "ATCOD"
            cmbTecnico.DataSource = elementi.Result

            cmbTecnico.AutoFilter = True
            Dim compositeFilter As New CompositeFilterDescriptor()
            Dim codElem As New FilterDescriptor("ATCOD", FilterOperator.Contains, "")
            Dim desElem As New FilterDescriptor("ATRAG", FilterOperator.Contains, "")
            Dim targa As New FilterDescriptor("ATARGA", FilterOperator.Contains, "")

            compositeFilter.FilterDescriptors.Add(codElem)
            compositeFilter.FilterDescriptors.Add(desElem)
            compositeFilter.FilterDescriptors.Add(targa)

            compositeFilter.LogicalOperator = FilterLogicalOperator.[Or]
            cmbTecnico.EditorControl.FilterDescriptors.Add(compositeFilter)

            cmbTecnico.SelectedIndex = -1
            cmbTecnico.SelectedValue = valoreIniziale

            statoCaricaTecnico = True

            If formInCaricamento = False Then
                wb.AssociatedControl = Nothing
                wb.StopWaiting()
                wb.Visible = False
            End If

        Catch ex As Exception
            statoCaricaSoc = True
            statoCaricaCen = True

            If formInCaricamento = False Then
                wb.AssociatedControl = Nothing
                wb.StopWaiting()
                wb.Visible = False
            End If

            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub cmdConferma_Click(sender As Object, e As EventArgs) Handles cmdConferma.Click
        Me.crea_mappa_impianto()
    End Sub


    Private Sub cmdAnnulla_Click(sender As Object, e As EventArgs) Handles cmdAnnulla.Click
        Try




            Dim testEndpoint As New ServiceModel.EndpointAddress("http://www.visirun.com/public/Server.php?wsdl")
            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            'binding.TextEncoding = ""
            Dim ff As New ws_visirun.PortClient(binding, testEndpoint)
            Dim respons As String = ff.getNearestVehicles("c6d89eb6248838efdbfd7dbcfdd264e6", "", 40.84474, 14.25691, "", "5000")

            Dim X As String = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grid_ViewCellFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs)
        Try
            Dim newFont = New System.Drawing.Font("Segoue UI", 8.0F, FontStyle.Bold)
            Dim newFontSum = New System.Drawing.Font("Segoue UI", 8.0F, FontStyle.Bold)
            Dim newFontH = New System.Drawing.Font("Segoue UI", 8.0F, FontStyle.Regular)
            Dim newFontGH = New System.Drawing.Font("Segoue UI", 8.0F, FontStyle.Regular)

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
                If grid.FilterDescriptors.Expression.ToString.ToUpper.Contains(e.CellElement.ColumnInfo.Name) Then
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

            Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

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

    Private Sub FrmChiamate_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Me.carica_dati_liste()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub t1_Tick(sender As Object, e As EventArgs) Handles t1.Tick
        Try
            If statoCaricaSoc = True Then

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

    Private Sub carica_dati_form()
        Try
            cmdAnnulla.Enabled = False
            cmdConferma.Enabled = False
            groupImpianto.Enabled = False
            groupChiamata.Enabled = False
            groupInfo.Enabled = False
            cmdBcaricaTecnici.Enabled = False
            cmdBCaricaLimit.Enabled = False
            Me.map.Visible = True

            TxtCodice.Text = grid.CurrentRow.Cells("A7CODIMP").Value
            txtIndirizzo.Text = grid.CurrentRow.Cells("AIIND").Value
            txtLocalita.Text = grid.CurrentRow.Cells("AILOC").Value
            txtProv.Text = grid.CurrentRow.Cells("AISPR").Value
            cmbCentri.SelectedValue = grid.CurrentRow.Cells("A7CENMDB").Value
            cmbSocieta.SelectedValue = grid.CurrentRow.Cells("A7SOCMDB").Value
            txtChiamante.Text = grid.CurrentRow.Cells("A7CHIMAN").Value
            txtMotivo.Text = grid.CurrentRow.Cells("A7MOTIVO").Value
            txtRecapito.Text = grid.CurrentRow.Cells("A7TELCHIAM").Value
            txtCap.Text = grid.CurrentRow.Cells("AICAP").Value

            If grid.CurrentRow.Cells("A7FLIMPFER").Value = "S" Then
                chkImpiantoFermo.Checked = True
            Else
                chkImpiantoFermo.Checked = False
            End If

            If grid.CurrentRow.Cells("A7FLINTRAP").Value = "S" Then
                chkIntrappolamento.Checked = True
            Else
                chkIntrappolamento.Checked = False
            End If

            If grid.CurrentRow.Cells("A7REPERIB").Value = "S" Then
                chkReperib.Checked = True
            Else
                chkReperib.Checked = False
            End If

            cmbCentri.Enabled = False
            cmbSocieta.Enabled = False

            Me.carica_combo_tecnici(grid.CurrentRow.Cells("A7CENMDB").Value, grid.CurrentRow.Cells("A7CODTEC").Value)

            Me.crea_mappa_impianto()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub crea_mappa_impianto()
        Try
            Me.map.Layers.Clear()

            Dim bingProvider As New BingRestMapProvider()
            bingProvider.Culture = System.Threading.Thread.CurrentThread.CurrentCulture
            bingProvider.UseSession = True
            bingProvider.BingKey = "M7cKnoZAkxXJfWmSmG1o~OW026RPkaCVxgId3XwFHlw~Ajqw6RAH74XHObo0LyLh8g2ksrotP7XYzFrAJzOGQhVurSWWd_Q10F1qmU8jWT4e" 'My.Resources.BingKey
            bingProvider.ImagerySet = ImagerySet.CanvasLight

            AddHandler bingProvider.InitializationComplete,
                Sub(sender As Object, e As EventArgs)
                    'Me.map.Zoom(6)
                    Me.map.MapElement.SearchBarElement.Search(txtIndirizzo.Text & ", " & txtCap.Text & " " & txtLocalita.Text)
                End Sub

            Me.map.MapElement.Providers.Add(bingProvider)
            Me.map.MapElement.SearchBarElement.SearchProvider = bingProvider
            Me.map.ShowNavigationBar = False

            Dim easternLayer As New MapLayer("Pins")
            Me.map.Layers.Add(easternLayer)
            Dim calloutLayer As New MapLayer("Callout")
            Me.map.Layers.Add(calloutLayer)

            AddHandler bingProvider.SearchCompleted, AddressOf BingProvider_SearchCompleted
            AddHandler bingProvider.SearchError, AddressOf BingProvider_SearchError
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BingProvider_SearchCompleted(ByVal sender As Object, ByVal e As SearchCompletedEventArgs)
        Dim allPoints As New RectangleG(Double.MinValue, Double.MaxValue, Double.MaxValue, Double.MinValue)
        Me.map.Layers("Pins").Clear()

        For Each location As Location In e.Locations
            Dim point As New PointG(location.Point.Coordinates(0), location.Point.Coordinates(1))
            Dim pin As New MapPin(point)
            pin.BackColor = Color.FromArgb(237, 23, 75)
            pin.ToolTipText = location.Address.FormattedAddress
            Me.map.MapElement.Layers("Pins").Add(pin)
            'Me.map.Zoom(6)

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
                Me.map.Zoom(16)
                Me.map.BringIntoView(New PointG(e.Locations(0).Point.Coordinates(0), e.Locations(0).Point.Coordinates(1)))

            Else
                Me.map.MapElement.BringIntoView(allPoints)
                Me.map.Zoom(5)
            End If
        Else
            RadMessageBox.Show("Nessun risultato trovato")
        End If
    End Sub

    Private Sub BingProvider_SearchError(ByVal sender As Object, ByVal e As SearchErrorEventArgs)
        'RadMessageBox.ThemeName = Me.CurrentThemeName
        RadMessageBox.Show(e.Error.Message)
    End Sub

    Private Function GetBestView() As RectangleG
        Dim northEast = New PointG(-9999, -9999)
        Dim southWest = New PointG(9999, 9999)

        Try

            Dim points As List(Of PointG) = New List(Of PointG)()

            For Each element As MapVisualElement In Me.map.MapElement.Layers("Pins").Overlays
                Dim pin As MapPin = TryCast(element, MapPin)

                If pin Is Nothing Then
                    Continue For
                End If

                northEast = New PointG(Math.Max(northEast.Latitude, pin.Location.Latitude), Math.Max(northEast.Longitude, pin.Location.Longitude))
                southWest = New PointG(Math.Min(southWest.Latitude, pin.Location.Latitude), Math.Min(southWest.Longitude, pin.Location.Longitude))

            Next

            Dim rect As RectangleG = New RectangleG(northEast.Latitude, southWest.Longitude, southWest.Latitude, northEast.Longitude)

            Return rect
        Catch ex As Exception
            Dim rect As RectangleG = New RectangleG(northEast.Latitude, southWest.Longitude, southWest.Latitude, northEast.Longitude)
            Return rect
        End Try

    End Function

    Private Sub SetupLayer()
        Dim pinsLayer As New MapLayer("Pins")
        Me.map.Layers.Add(pinsLayer)
    End Sub



    Private Async Sub carica_autisti_mappa(centro As String)
        Try
            wb.AssociatedControl = map
            wb.StartWaiting()
            wb.Visible = True

            Dim filtro As String = "RTCCE IN ('" & centro & "')"

            'Dim elementi As Threading.Tasks.Task(Of List(Of elencoTecnici))
            If Not IsNothing(posTec) Then
                posTec.Result.Clear()
            End If
            posTec = ws.getElencoTecnici("", "", filtro)
            Await posTec

            If Not BGWorkDett.IsBusy Then
                BGWorkDett.RunWorkerAsync()
            End If

        Catch ex As Exception
            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub crea_posizioni_tecnici(elementi As Threading.Tasks.Task(Of List(Of elencoTecnici)))
        Try


            For i = 0 To elementi.Result.Count - 1
                If elementi.Result.Item(i).ATARGA <> "" Then

                    System.Threading.Thread.Sleep(1100)
                    Dim soapresult As String = wsVisiRun.visrun_getCurrentPosition(elementi.Result.Item(i).ATARGA)

                    Dim slat As String = ""
                    Dim slon As String = ""

                    retriveCoord(soapresult, slat, slon)

                    Dim location As PointG = MapTileSystemHelper.PixelXYToLatLong(Val(slat), Val(slon), map.MapElement.ZoomLevel)
                    location.Latitude = Val(slat)
                    location.Longitude = Val(slon)

                    If Not IsNothing(Me.map.Layers(elementi.Result.Item(i).ATARGA)) Then
                        Me.map.Layers.Remove(Me.map.Layers(elementi.Result.Item(i).ATARGA))
                    End If

                    Dim nflLayer As New MapLayer(elementi.Result.Item(i).ATARGA)
                    Me.map.Layers.Add(nflLayer)

                    Dim element As New MapPin(location)
                    element.Text = String.Format("{0}" & vbCrLf & "{1}", elementi.Result.Item(i).ATRAG, elementi.Result.Item(i).ATARGA)
                    element.BackColor = Color.FromArgb(37, 160, 218)
                    element.Tag = elementi.Result.Item(i).ATRAG
                    Me.map.Layers(elementi.Result.Item(i).ATARGA).Add(element)
                    'Dim callout As New MapCallout(element)
                    'callout.Text = targhe(i)
                    'Me.map.MapElement.Layers(targhe(i)).Add(callout)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub crea_posizioni_tecnici_vicino_impianto(elementi As Threading.Tasks.Task(Of List(Of elencoTecnici)), soapResult As String)
        Try

            Dim targa As String = "", lat As String = "", lng As String = ""

            'rimuovo i layer delle targhe
            For i As Integer = 0 To elementi.Result.Count - 1
                Me.map.Layers.Remove(Me.map.Layers(elementi.Result.Item(i).ATARGA))
            Next

            Dim doc3 = XDocument.Parse(soapResult)
            Dim x As String = doc3.Root.Elements.Count

            For y = 0 To doc3.Root.Elements.Count
                'Console.Write(y)
                Console.Write(doc3.Root.Value)
                Dim doc2 = XDocument.Parse(doc3.Root.Value)

                Dim docVeicoli As XmlDocument = New XmlDocument()
                docVeicoli.LoadXml(doc2.ToString)
                Dim nodes As XmlNodeList = docVeicoli.DocumentElement.SelectNodes("/getNearestVehicleResponse/getNearestVehicleResponseElement")

                For Each node As XmlNode In nodes
                    For Each nodeC As XmlNode In node.ChildNodes
                        Select Case nodeC.Name.ToLower
                            Case "vehiclename"
                                targa = nodeC.InnerText
                            Case "lat"
                                lat = nodeC.InnerText
                            Case "lon"
                                lng = nodeC.InnerText

                        End Select

                    Next

                    Dim tec As Object = elementi.Result.Find(Function(c As elencoTecnici) c.ATARGA = targa)


                    If Not IsNothing(tec) Then

                        System.Threading.Thread.Sleep(1100)
                        Dim result As String = wsVisiRun.visrun_getCurrentPosition(targa)

                        Dim slat As String = ""
                        Dim slon As String = ""

                        retriveCoord(result, slat, slon)

                        'Me.map.Layers.Remove(Me.map.Layers(tec.ATARGA))

                        Dim location As PointG = MapTileSystemHelper.PixelXYToLatLong(Val(slat), Val(slon), map.MapElement.ZoomLevel)
                        location.Latitude = Val(slat)
                        location.Longitude = Val(slon)


                        Dim nflLayer As New MapLayer(tec.ATARGA)
                        Me.map.Layers.Add(nflLayer)

                        Dim element As New MapPin(location)
                        element.Text = String.Format("{0}" & vbCrLf & "{1}", tec.ATRAG, tec.ATARGA)
                        element.BackColor = Color.FromArgb(37, 160, 218)
                        element.Tag = tec.ATRAG
                        Me.map.Layers(tec.ATARGA).Add(element)
                        'Dim callout As New MapCallout(element)
                        'callout.Text = targhe(i)
                        'Me.map.MapElement.Layers(targhe(i)).Add(callout)
                    End If

                Next


            Next


                'For Each node As XmlNode In nodes
                '    targa = node.SelectSingleNode("vehicleName").InnerText
                '    lat = node.SelectSingleNode("lat").InnerText
                '    lng = node.SelectSingleNode("lon").InnerText
                '    elementi.Result.Find(Function(c As elencoTecnici) c.ATARGA = targa)
                'Next


                For i = 0 To elementi.Result.Count - 1
                'elementi.Result.Find(Function(c As elencoTecnici) c.ATARGA = targa)


                'If elementi.Result.Item(i).ATARGA <> "" Then



                '    If Not IsNothing(Me.map.Layers(elementi.Result.Item(i).ATARGA)) Then
                '        Me.map.Layers.Remove(Me.map.Layers(elementi.Result.Item(i).ATARGA))
                '    End If

                '    Dim nflLayer As New MapLayer(elementi.Result.Item(i).ATARGA)
                '    Me.map.Layers.Add(nflLayer)

                '    Dim element As New MapPin(location)
                '    element.Text = String.Format("{0}" & vbCrLf & "{1}", elementi.Result.Item(i).ATRAG, elementi.Result.Item(i).ATARGA)
                '    element.BackColor = Color.FromArgb(37, 160, 218)
                '    element.Tag = elementi.Result.Item(i).ATRAG
                '    Me.map.Layers(elementi.Result.Item(i).ATARGA).Add(element)
                '    'Dim callout As New MapCallout(element)
                '    'callout.Text = targhe(i)
                '    'Me.map.MapElement.Layers(targhe(i)).Add(callout)
                'End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub crea_posizioni_tecnici_vicino_impianto()
        Try


            For Each element As MapVisualElement In Me.map.MapElement.Layers("Pins").Overlays
                Dim pin As MapPin = TryCast(element, MapPin)

                If pin Is Nothing Then
                    Continue For
                End If

                Dim soapresult As String = wsVisiRun.visrun_getNearestVehicles(pin.Location.Latitude.ToString, pin.Location.Longitude.ToString, "3000", "")
                Me.crea_posizioni_tecnici_vicino_impianto(TecniciCentro, soapresult)


                'northEast = New PointG(Math.Max(northEast.Latitude, pin.Location.Latitude), Math.Max(northEast.Longitude, pin.Location.Longitude))
                'southWest = New PointG(Math.Min(southWest.Latitude, pin.Location.Latitude), Math.Min(southWest.Longitude, pin.Location.Longitude))

            Next




            'Dim slat As String = ""
            '        Dim slon As String = ""

            '        retriveCoord(soapresult, slat, slon)

            '        Dim location As PointG = MapTileSystemHelper.PixelXYToLatLong(Val(slat), Val(slon), map.MapElement.ZoomLevel)
            '        location.Latitude = Val(slat)
            '        location.Longitude = Val(slon)

            '        If Not IsNothing(Me.map.Layers(elementi.Result.Item(i).ATARGA)) Then
            '            Me.map.Layers.Remove(Me.map.Layers(elementi.Result.Item(i).ATARGA))
            '        End If

            '        Dim nflLayer As New MapLayer(elementi.Result.Item(i).ATARGA)
            '        Me.map.Layers.Add(nflLayer)

            '        Dim element As New MapPin(location)
            '        element.Text = String.Format("{0}" & vbCrLf & "{1}", elementi.Result.Item(i).ATRAG, elementi.Result.Item(i).ATARGA)
            '        element.BackColor = Color.FromArgb(37, 160, 218)
            '        element.Tag = elementi.Result.Item(i).ATRAG
            '        Me.map.Layers(elementi.Result.Item(i).ATARGA).Add(element)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub retriveCoord(soapResult As String, ByRef lat As String, ByRef lon As String)
        Try

            Dim doc3 = XDocument.Parse(soapResult)
            Dim x As String = doc3.Root.Elements.Count

            For y = 0 To doc3.Root.Elements.Count
                Console.Write(y)
                Console.Write(doc3.Root.Value)
                Dim doc2 = XDocument.Parse(doc3.Root.Value)


                Dim sr As New System.IO.StringReader(doc3.Root.Value)
                Dim doc As New Xml.XmlDocument
                doc.Load(sr)
                Dim reader As New Xml.XmlNodeReader(doc)
                While reader.Read()
                    Select Case reader.NodeType
                        Case Xml.XmlNodeType.Element
                            If reader.Name = "lat" Then
                                lat = reader.ReadInnerXml()
                            End If

                            If reader.Name = "lon" Then
                                lon = reader.ReadInnerXml()
                            End If

                    End Select
                End While

            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub map_Click(ByVal sender As Object, ByVal e As EventArgs) Handles map.Click
        Dim args As MouseEventArgs = TryCast(e, MouseEventArgs)
        Me.map.Layers("Callout").Clear()

        Dim point As New PointL(args.X - Me.map.MapElement.PanOffset.Width, args.Y - Me.map.MapElement.PanOffset.Height)
        Dim pin As MapPin = TryCast(Me.map.Layers.HitTest(point), MapPin)

        If pin IsNot Nothing Then

            Dim callout As New MapCallout(pin)
            'callout.Font = Me.calloutFont
            callout.ForeColor = Color.FromArgb(68, 68, 68)
            'callout.Image = CType(My.Resources.ResourceManager.GetObject(pin.Layer.Name & amp; teamInfo.Name.Replace(" ", "")), Bitmap) 
            callout.Text = String.Format("{0} {1}" & vbLf & "{2}" & vbLf & "{3}", "", pin.Tag, " ", pin.Layer.Name)
            Me.map.Layers("Callout").Add(callout)

            Return
        End If

        Dim item As MapLegendItemElement = Me.map.ElementTree.GetElementAtPoint(Of MapLegendItemElement)(args.Location)

        If item IsNot Nothing Then
            Me.map.Layers(item.TextElement.Text).IsVisible = Me.map.Layers(item.TextElement.Text).IsVisible Xor True
            item.Enabled = Me.map.Layers(item.TextElement.Text).IsVisible
        End If
    End Sub

    Private Sub cmdFiltro_Click(sender As Object, e As EventArgs) Handles cmdFiltro.Click
        Try
            Dim parms As New parmsRicChiamate
            Dim listSoc As New List(Of lista_societa)
            Dim listCentri As New List(Of lista_centri)
            Dim codImpianto As String = ""

            Dim soc As New lista_societa
            Dim cen As New lista_centri

            If grigliaCreata = False Then
                Me.crea_griglia_chiamate()
            End If

            soc.societa = txtCodSocRic.Text
            cen.Centro = txtCodCentroRic.Text

            listSoc.Add(soc)
            listCentri.Add(cen)

            parms.parmSoc = listSoc
            parms.parmCentro = listCentri
            parms.parmCodImpianto = codImpianto

            Me.async_carica_griglia_chiamate(parms)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grid_CurrentRowChanged(sender As Object, e As CurrentRowChangedEventArgs) Handles grid.CurrentRowChanged
        Try
            Me.carica_dati_form()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPosTecnici_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmdSearchSoc_Click(sender As Object, e As EventArgs) Handles cmdSearchSoc.Click
        Try
            Dim frm As New FrmRicercaTabelle("SOC")
            frm.CodiceOut = ""
            frm.DescrOut = ""
            frm.ShowDialog()
            txtCodSocRic.Text = frm.CodiceOut
            txtDesSocRic.Text = frm.DescrOut
        Catch ex As Exception
            txtCodSocRic.Text = ""
            txtDesSocRic.Text = ""
        End Try
    End Sub

    Private Sub cmdSearchCen_Click(sender As Object, e As EventArgs) Handles cmdSearchCen.Click
        Try
            Dim frm As New FrmRicercaTabelle("CENTRI")
            frm.CodiceOut = ""
            frm.DescrOut = ""
            frm.parmFiltro = ""
            frm.ShowDialog()
            txtCodCentroRic.Text = frm.CodiceOut
            txtDesCentroRic.Text = frm.DescrOut
        Catch ex As Exception
            txtCodCentroRic.Text = ""
            txtDesCentroRic.Text = ""
        End Try
    End Sub

    Private Sub cmdSearchTec_Click(sender As Object, e As EventArgs) Handles cmdSearchTec.Click
        Try
            Dim frm As New FrmRicercaTabelle("TECNICI")
            frm.CodiceOut = ""
            frm.DescrOut = ""
            frm.ShowDialog()
            txtCodTecRic.Text = frm.CodiceOut
            txtDesTecRic.Text = frm.DescrOut
        Catch ex As Exception
            txtCodTecRic.Text = ""
            txtDesTecRic.Text = ""
        End Try
    End Sub

    Private Sub cmdBFocusImp_Click(sender As Object, e As EventArgs) Handles cmdBFocusImp.Click
        Try
            Me.map.BringIntoView(GetBestView())
            Me.map.Zoom(16)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdBFocusTec_Click(sender As Object, e As EventArgs) Handles cmdBFocusTec.Click
        Try
            Me.map.Zoom(13)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdBcaricaTecnici_Click(sender As Object, e As EventArgs) Handles cmdBcaricaTecnici.Click
        Try
            batchCaricaMappa = "TECNICI"
            Dim centro As String = cmbCentri.SelectedValue
            carica_autisti_mappa(centro)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdBCaricaLimit_Click(sender As Object, e As EventArgs) Handles cmdBCaricaLimit.Click
        Try

            wb.AssociatedControl = map
            wb.StartWaiting()
            wb.Visible = True
            batchCaricaMappa = "AREA"

            If Not BGWorkDett.IsBusy Then
                BGWorkDett.RunWorkerAsync()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub azzera_campi()
        Try
            cmbSocieta.SelectedIndex = -1
            cmbCentri.SelectedIndex = -1
            cmbTecnico.SelectedIndex = -1
            cmbStatoChiamata.SelectedIndex = -1
            cmbMotivo.SelectedIndex = -1
            TxtCodice.Text = ""
            txtCap.Text = ""
            txtChiamante.Text = ""
            txtDataAssegn.Clear()
            txtDataStato.Clear()
            txtOraAss.Text = ""
            txtOraStato.Text = ""
            txtProv.Text = ""
            txtIndirizzo.Text = ""
            txtLocalita.Text = ""
            txtMotivo.Text = ""
            txtRecapito.Text = ""
            txtTipoImp.Text = ""
            chkImpiantoFermo.Checked = False
            chkIntrappolamento.Checked = False
            chkReperib.Checked = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdInserisci_Click(sender As Object, e As EventArgs) Handles cmdInserisci.Click
        Try
            Me.azzera_campi()
            Me.cmdConferma.Enabled = True
            Me.cmdAnnulla.Enabled = True
            groupImpianto.Enabled = True
            groupChiamata.Enabled = True
            groupInfo.Enabled = True
            cmbSocieta.Enabled = True
            cmbCentri.Enabled = True
            Me.map.Visible = False

            Me.map.Layers.Clear()

            cmbSocieta.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCentri_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCentri.SelectedValueChanged
        Try
            Dim centro = cmbCentri.SelectedValue
            carica_combo_tecnici(centro, "")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdModChiam_Click(sender As Object, e As EventArgs) Handles cmdModChiam.Click
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")
        Try
            If grid.CurrentRow.Cells("A7STATOC").Value = "CH" Then
                RadMessageBox.Show("Impossibile modificare una chiamata chiusa", "Modifica", MessageBoxButtons.OK, RadMessageIcon.Error)
                Exit Sub
            End If

            Me.cmdConferma.Enabled = True
            Me.cmdAnnulla.Enabled = True
            cmdBCaricaLimit.Enabled = True
            cmdBcaricaTecnici.Enabled = True
            groupImpianto.Enabled = True
            groupChiamata.Enabled = True
            groupInfo.Enabled = True
            cmbSocieta.Enabled = True
            cmbCentri.Enabled = True
            Me.map.Visible = True

        Catch ex As Exception

        End Try
    End Sub
End Class
