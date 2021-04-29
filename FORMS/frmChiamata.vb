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
Imports Telerik.WinControls.UI.Data

Public Class FrmChiamate

    Private ws As New webServices
    Private wsVisirun As New wsVisiRun
    Private BGWorkDett As BackgroundWorker

    Private posTec As Threading.Tasks.Task(Of List(Of elencoTecnici))
    Private TecniciCentro As Threading.Tasks.Task(Of List(Of elencoTecnici))
    Private schedaImpianto As Threading.Tasks.Task(Of parmGetSchedaImpianto)

    Private statoCaricaSoc As Boolean
    Private statoCaricaCen As Boolean
    Private statoCaricaTecnico As Boolean
    Private statoCaricaListaStati As Boolean
    Private statoCaricaStatiChiamata As Boolean
    Private statoCaricaMotivi As Boolean


    Private formInCaricamento As Boolean
    Private grigliaCreata As Boolean

    Private gRicercaAss As Boolean
    Private gRicercaLav As Boolean
    Private gRicercaSos As Boolean
    Private gRicercaChi As Boolean

    Private azione As String
    Private batchCaricaMappa As String
    Private gElencoCentri As String

    Private gDataApe As String
    Private gOraApe As String
    Private gDataAss As String
    Private gOraAss As String
    Private gDataLav As String
    Private gOraLav As String
    Private gDataSos As String
    Private gOraSos As String
    Private gDataChi As String
    Private gOraChi As String

    Public Sub New(ByVal inAzione As String, Optional ByVal ElencoCentri As String = "", Optional ByVal inUser As String = "", Optional ByVal inRuolo As String = "", Optional ByVal inUserAS As String = "", Optional ByVal modifica As Boolean = True, Optional ByVal testo As String = "")
        InitializeComponent()
        WireEvents()

        'azione = inAzione

        'ruolo = inRuolo
        'user = inUser
        'userAS = inUserAS
        'gElencoCentri = ElencoCentri

        gElencoCentri = "'C20'"

    End Sub

    Protected Sub WireEvents()
        AddHandler grid.ViewCellFormatting, AddressOf grid_ViewCellFormatting
        AddHandler grid.ViewRowFormatting, AddressOf grid_ViewRowFormatting
        AddHandler grid.CellFormatting, AddressOf grid_CellFormatting
        AddHandler grid.ContextMenuOpening, AddressOf grid_ContextMenuOpening
        AddHandler grid.ValueChanging, AddressOf grid_ValueChanging
        AddHandler grid.CellDoubleClick, AddressOf grid_CellDoubleClick

        Dim service As DragDropService = Me.dockGen.GetService(Of DragDropService)()
        AddHandler service.Starting, AddressOf OnDragDropService_Starting

    End Sub

    Private Sub OnDragDropService_Starting(ByVal sender As Object, ByVal e As StateServiceStartingEventArgs)
        Try
            Dim context As Control = TryCast(e.Context, Control)
            If context Is Nothing Then
                Return
            End If

            e.Cancel = True  'Telerik.WinControls.Enumerations.ToggleState.Off

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Chiamate")
        End Try


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

            Me.CommandBarStripE1.OverflowButton.Visibility = ElementVisibility.Hidden
            Me.cmdBarStripE1mappa.OverflowButton.Visibility = ElementVisibility.Hidden
            Me.dockGen.ActiveWindow = DocWinElenco

            grigliaCreata = False

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            t1.Enabled = True
            formInCaricamento = True
            Me.inizializza_background()

            cmdAnnulla.Enabled = False
            cmdConferma.Enabled = False
            groupImpianto.Enabled = False
            groupChiamata.Enabled = False
            groupInfo.Enabled = False
            cmdBcaricaTecnici.Enabled = False
            cmdBCaricaLimit.Enabled = False

            lblVisAssegnate.Cursor = Cursors.Hand
            lblVisLav.Cursor = Cursors.Hand
            lblVisSos.Cursor = Cursors.Hand
            lblVisChi.Cursor = Cursors.Hand

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
                Case "MAPPA"
                    crea_mappa_impianto()

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
            Dim frm As New FrmImpiantiElenco(Me, gElencoCentri, "", "", "", "RICERCA")
            'frm.CodiceOut = ""
            'frm.DescrOut = ""
            frm.ShowDialog()
            TxtCodice.Text = frm.AICIM
            txtIndirizzo.Text = frm.AISTR & " " & frm.AIIND
            txtLocalita.Text = frm.AILOC
            txtCap.Text = frm.AICAP
            txtProv.Text = frm.AISPR
            cmbSocieta.SelectedValue = frm.AISOC
            cmbCentri.SelectedValue = frm.AICEN

            frm.Dispose()

            Me.carica_scheda_impianto(frm.AICIM)
            'Me.crea_mappa_impianto()

            batchCaricaMappa = "MAPPA"
            If Not BGWorkDett.IsBusy Then
                BGWorkDett.RunWorkerAsync()
            End If

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

    Private Async Sub carica_scheda_impianto(idImpianto As String)
        Try
            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            schedaImpianto = ws.getSchedaImpianto(idImpianto)
            Await schedaImpianto

            txtTipoImp.Text = schedaImpianto.Result.DESCCI

            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False

        Catch ex As Exception
            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False
        End Try
    End Sub

    Private Async Sub carica_elemento_tabella(codTab As String, valoreIniziale As String)
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella(codTab, valoreIniziale)
            Await elementi

            Dim valori() As parmTabelle = elementi.Result

            Select Case codTab
                Case "CCI"
                    If valori.Count > 0 Then
                        'txtIva.Text = valori(0).codElem
                        'txtDesIva.Text = valori(0).desElem
                    Else
                        'txtIva.Text = ""
                        'txtDesIva.Text = ""
                    End If
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub crea_griglia_chiamate()
        Try
            Me.LoadSummaryChiamate()

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

            If grigliaCreata = False Then
                Me.crea_griglia_chiamate()
            End If

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

            If grid.Rows.Count = 0 Then
                cmdAnnulla.Enabled = False
                cmdConferma.Enabled = False
                groupImpianto.Enabled = False
                groupChiamata.Enabled = False
                groupInfo.Enabled = False
                cmdBcaricaTecnici.Enabled = False
                cmdBCaricaLimit.Enabled = False
            End If
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
            Me.grid.Columns("A7CODIMP").FormatString = "{0:0000000}"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub carica_dati_liste()
        Try
            Dim filtro_soc As String = ""

            If gElencoCentri <> "" And gElencoCentri <> "*" Then
                filtro_soc = " TRIM(XCDEL) IN (SELECT CDSOC FROM " & My.Settings.LibLift & ".RELCENSOC WHERE CDCEN IN (" & gElencoCentri & "))"
            End If
            carica_combo_tabelle("SOC", cmbSocieta, "", filtro_soc)
            carica_combo_tabelle("SCH", cmbStatoChiamata, "")
            carica_combo_tabelle("MCH", cmbMotivo, "")
            Dim filtro_centri As String = ""
            If gElencoCentri <> "" Then
                filtro_centri = " TCCEN IN (" & gElencoCentri & ")"
            End If
            carica_combo_tipi_tabelle_colonne("CENTRI", cmbCentri, "", filtro_centri)
            carica_liste("SCH", lista_Stati)
        Catch ex As Exception

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


            statoCaricaListaStati = True


        Catch ex As Exception
            statoCaricaListaStati = True
        End Try
    End Sub

    Private Async Sub carica_combo_tabelle(codTab As String, combo As RadDropDownList, valoreIniziale As String, Optional filtro As String = "")
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella(codTab, "", filtro)
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
                Case "SCH"
                    statoCaricaStatiChiamata = True
                Case "MCH"
                    statoCaricaMotivi = True
            End Select

        Catch ex As Exception
            statoCaricaSoc = True
            statoCaricaCen = True
            statoCaricaStatiChiamata = True
            statoCaricaMotivi = True

            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub
    Private Async Sub carica_combo_tipi_tabelle_colonne(codTab As String, combo As RadMultiColumnComboBox, valoreIniziale As String, Optional filtro As String = "")

        Try

            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella(codTab, "", filtro)
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

            column = New GridViewTextBoxColumn("ATIME")
            column.HeaderText = "IMEI"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("ATINV")
            column.HeaderText = "Tp. Invio"
            multiColumnComboElement.Columns.Add(column)

            cmbTecnico.DisplayMember = "ATRAG"
            cmbTecnico.ValueMember = "ATCOD"
            cmbTecnico.DataSource = elementi.Result

            cmbTecnico.AutoFilter = True
            Dim compositeFilter As New CompositeFilterDescriptor()
            Dim codElem As New FilterDescriptor("ATCOD", FilterOperator.Contains, "")
            Dim desElem As New FilterDescriptor("ATRAG", FilterOperator.Contains, "")
            Dim targa As New FilterDescriptor("ATARGA", FilterOperator.Contains, "")
            Dim imei As New FilterDescriptor("ATIME", FilterOperator.Contains, "")
            Dim tpinv As New FilterDescriptor("ATINV", FilterOperator.Contains, "")

            compositeFilter.FilterDescriptors.Add(codElem)
            compositeFilter.FilterDescriptors.Add(desElem)
            compositeFilter.FilterDescriptors.Add(targa)
            compositeFilter.FilterDescriptors.Add(imei)
            compositeFilter.FilterDescriptors.Add(tpinv)

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

    Private Sub LoadSummaryChiamate()
        Try

            Me.grid.MasterTemplate.SummaryRowsBottom.Clear()
            Dim item1 As New GridViewSummaryRowItem()
            item1.Add(New GridViewSummaryItem("A7CODIMP", "{0:#,##0}", GridAggregateFunction.Count))

            Me.grid.MasterTemplate.SummaryRowsBottom.Add(item1)

            grid.MasterTemplate.ShowTotals = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "LIFT.NET")
        End Try

    End Sub

    Private Sub cmdConferma_Click(sender As Object, e As EventArgs) Handles cmdConferma.Click
        'If controlli_form() = True Then
        Me.start_saveData(azione)
        'End If

    End Sub


    Private Sub cmdAnnulla_Click(sender As Object, e As EventArgs) Handles cmdAnnulla.Click
        Try
            Me.azzera_campi()
            Me.carica_dati_form()

            'Dim testEndpoint As New ServiceModel.EndpointAddress("http://www.visirun.com/public/Server.php?wsdl")
            'Dim binding As BasicHttpBinding = New BasicHttpBinding()
            ''binding.TextEncoding = ""
            'Dim ff As New ws_visirun.PortClient(binding, testEndpoint)
            'Dim respons As String = ff.getNearestVehicles("c6d89eb6248838efdbfd7dbcfdd264e6", "", 40.84474, 14.25691, "", "5000")

            'Dim X As String = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub start_saveData(azione As String)
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            Dim scheda As New elencoChiamate
            scheda = Me.move_val_to_file

            If Not IsNothing(scheda) Then
                Dim response As String = Await controlla_dati(scheda, azione)
                If response.Contains("Errore:") Then
                    Telerik.WinControls.RadMessageBox.Show(Me, "Errori riscontrati: " & vbCrLf & response, "Gestione Chiamata", MessageBoxButtons.OK, RadMessageIcon.Error)

                ElseIf response = "OK" Then
                    Me.SaveChiamata(scheda)
                    'Me.Close()
                Else
                    Dim dr As DialogResult = RadMessageBox.Show(response & vbCrLf & "Continuare?", "Gestione Chiamata", MessageBoxButtons.YesNo, RadMessageIcon.Question)
                    If dr = DialogResult.No Then
                        Exit Sub
                    Else
                        Me.SaveChiamata(scheda)
                        'Me.Close()

                    End If
                End If

            Else
                    Telerik.WinControls.RadMessageBox.Show(Me, "Errori riscontrati in fase di assegnazione dati chiamata ", "Gestione chiamata", MessageBoxButtons.OK, RadMessageIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function move_val_to_file() As elencoChiamate
        Dim sc As New elencoChiamate
        Dim DataStato As String = ""

        Try

            If azione = "NUOVO" Then
                sc.A7IDCHIA = 0
            Else
                sc.A7IDCHIA = Val(txtID.Text)

            End If

            If cmbSocieta.SelectedIndex >= 0 Then
                sc.A7SOCMDB = cmbSocieta.SelectedValue
            Else
                sc.A7SOCMDB = ""
            End If

            If cmbCentri.SelectedIndex >= 0 Then
                sc.A7CENMDB = cmbCentri.SelectedValue
            Else
                sc.A7CENMDB = ""
            End If

            sc.A7CODIMP = Val(TxtCodice.Text)
            sc.A7CHIMAN = txtChiamante.Text
            sc.A7TELCHIAM = txtRecapito.Text
            sc.A7MOTIVO = txtMotivo.Text
            sc.A7RISCON = txtRiscontro.Text

            If cmbTecnico.SelectedIndex >= 0 Then
                sc.A7CODTEC = cmbTecnico.SelectedValue
            Else
                sc.A7CODTEC = ""
            End If

            sc.A7STATOC = ""

            If optAPE.IsChecked = True Then
                sc.A7STATOC = "AP"
            ElseIf optASS.IsChecked = True Then
                sc.A7STATOC = "AS"
            ElseIf optLAV.IsChecked = True Then
                sc.A7STATOC = "LA"
            ElseIf optSOS.IsChecked = True Then
                sc.A7STATOC = "SO"
            ElseIf optCHI.IsChecked = True Then
                sc.A7STATOC = "CH"
            End If


            'If cmbStatoChiamata.SelectedIndex >= 0 Then
            '    sc.A7STATOC = cmbStatoChiamata.SelectedValue
            'Else
            '    sc.A7STATOC = ""
            'End If

            If IsDate(txtDataStato.Text) Then

                Select Case sc.A7STATOC
                    Case "AP"
                        sc.A7TSAPER = txtDataStato.Text
                        sc.A7ORAAP = txtOraStato.Text
                    Case "AS"
                        sc.A7TSASSE = txtDataStato.Text
                        sc.A7ORAAS = txtOraStato.Text
                    Case "LA"
                        sc.A7TSLAVO = txtDataStato.Text
                        sc.A7ORALA = txtOraStato.Text
                    Case "SO"
                        sc.A7TSSOSP = txtDataStato.Text
                        sc.A7ORASO = txtOraStato.Text
                    Case "CH"
                        sc.A7TSCHIU = txtDataStato.Text
                        sc.A7ORACH = txtOraStato.Text
                End Select

            End If

            If chkReperib.Checked = True Then
                sc.A7REPERIB = "1"
            Else
                sc.A7REPERIB = "0"
            End If

            ''''sc.A7CRITICIT = reader("A7CRITICIT")

            If chkIntrappolamento.Checked = True Then
                sc.A7FLINTRAP = "1"
            Else
                sc.A7FLINTRAP = "0"
            End If

            If chkOre13.Checked = True Then
                sc.A7FLORE13 = "1"
            Else
                sc.A7FLORE13 = "0"
            End If

            If chkImpiantoFermo.Checked = True Then
                sc.A7FLIMPFER = "1"
            Else
                sc.A7FLIMPFER = "0"
            End If

            sc.A7CRITICIT = "0"

            sc.A7IDITECS = 0
            sc.A7IDEVSTAT = 0
            sc.A7IMEI = ""
            sc.A7INTER = "CHI"
            sc.A7DTINI = Now.Date
            sc.A7DTFIN = Now.Date

            If cmbTecnico.SelectedIndex >= 0 Then
                Dim value As Object = cmbTecnico.EditorControl.Rows(cmbTecnico.SelectedIndex).Cells("ATIME").Value
                If Not IsNothing(value) Then
                    sc.A7IMEI = value.ToString
                End If
            End If

            Return sc

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Async Function controlla_dati(chiamata As elencoChiamate, azione As String) As Threading.Tasks.Task(Of String)
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            Dim client As New Http.HttpClient
            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

            Dim postContent = jss.Serialize(chiamata)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = My.Settings.urlWS & "api/Chiamate/controlloChiamateLiv1/controlloChiamateLiv1"
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("parmScheda", postContent)
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
    Private Async Sub SaveChiamata(scheda As elencoChiamate)
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

            Dim postUrl = My.Settings.urlWS & "/api/Chiamate/saveChiamata/saveChiamata"
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmEntry", postContent)

            Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)

            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

            Dim sStatusCode As String = postResponse.StatusCode.ToString

            If sStatusCode <> "OK" Then
                Dim S As String = Await postResponse.Content.ReadAsStringAsync()
                Dim id As String = Newtonsoft.Json.JsonConvert.DeserializeObject(Of String)(S)
                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio non effettuato. " & vbCrLf & "Causa: " & id, "Chiamate", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio effettuato", "Chiamate", MessageBoxButtons.OK, RadMessageIcon.Info)
                'idAccordo = sStatusCode
                If postResponse.IsSuccessStatusCode Then
                    Dim S As String = Await postResponse.Content.ReadAsStringAsync()
                    Dim id As String = Newtonsoft.Json.JsonConvert.DeserializeObject(Of String)(S)
                    If azione = "NUOVO" Then
                        If id <> "" Then
                            'azione = "MODIFICA"
                            'txtID.Text = id
                            Me.azzera_campi()
                        End If
                    Else
                        Me.refresh_data()
                        'cmdFiltro.PerformClick()
                    End If
                End If

            End If

        Catch EX As Exception

        End Try
    End Sub

    Private Sub refresh_data()
        Try
            If gRicercaAss = True Then
                Me.fast_filter_chiamate("AS", "", "")
            ElseIf gRicercaLav = False Then
                Me.fast_filter_chiamate("LA", "", "")
            ElseIf gRicercaSos = False Then
                Me.fast_filter_chiamate("SO", "", "")
            ElseIf gRicercaChi = False Then
                Me.fast_filter_chiamate("CH", Now.Date.ToString, Now.Date.ToString)
            Else
                cmdFiltro.PerformClick()
            End If

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

            ElseIf e.CellElement.ColumnInfo.Name.ToUpper = "A7TSCHIU" Then
                If Not IsNothing(e.CellElement.Text) AndAlso e.CellElement.Text <> "" Then

                    If Year(CDate(e.CellElement.Text)) = 1 Then
                        e.CellElement.ForeColor = e.CellElement.BackColor
                    Else
                        e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                    End If
                End If
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

    Private Sub grid_CellDoubleClick(sender As Object, e As GridViewCellEventArgs)
        Try
            If e.Column.Name.ToUpper = "A7CODIMP" Then
                Dim rowInfo As GridViewRowInfo = e.Row

                If Not IsNothing(rowInfo) Then
                    Dim id As String = rowInfo.Cells("A7CODIMP").Value
                    Dim frm As New FrmImpianto(id, "MODIFICA")
                    frm.ShowDialog()
                Else
                    RadMessageBox.Show("Nessun dato da visualizzare.", "Impianto", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmChiamate_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Me.carica_dati_liste()
            'Me.async_carica_dashBoard_chiamate("'C20'")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub t1_Tick(sender As Object, e As EventArgs) Handles t1.Tick
        Try
            If statoCaricaSoc = True And statoCaricaListaStati = True And statoCaricaStatiChiamata = True Then

                wb.AssociatedControl = Nothing
                wb.StopWaiting()
                wb.Visible = False

                t1.Enabled = False
                formInCaricamento = False

                t1Dash.Enabled = True

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

            If grid.Rows.Count = 0 Then
                Exit Sub
            End If

            statoCaricaTecnico = True

            txtID.Text = grid.CurrentRow.Cells("A7IDCHIA").Value
            txtIdWeb.Text = grid.CurrentRow.Cells("A7IDITECS").Value
            TxtCodice.Text = grid.CurrentRow.Cells("A7CODIMP").Value
            txtIndirizzo.Text = grid.CurrentRow.Cells("AIIND").Value
            txtLocalita.Text = grid.CurrentRow.Cells("AILOC").Value
            txtProv.Text = grid.CurrentRow.Cells("AISPR").Value

            cmbCentri.SelectedValue = grid.CurrentRow.Cells("A7CENMDB").Value
            cmbSocieta.SelectedValue = grid.CurrentRow.Cells("A7SOCMDB").Value
            cmbStatoChiamata.SelectedValue = grid.CurrentRow.Cells("A7STATOC").Value

            txtChiamante.Text = grid.CurrentRow.Cells("A7CHIMAN").Value
            txtMotivo.Text = grid.CurrentRow.Cells("A7MOTIVO").Value
            txtRecapito.Text = grid.CurrentRow.Cells("A7TELCHIAM").Value
            txtCap.Text = grid.CurrentRow.Cells("AICAP").Value
            txtRiscontro.Text = grid.CurrentRow.Cells("A7RISCON").Value

            txtDataAssegn.Text = grid.CurrentRow.Cells("A7TSAPER").Value
            txtOraAss.Text = grid.CurrentRow.Cells("A7ORAAP").Value

            gDataApe = grid.CurrentRow.Cells("A7TSAPER").Value.ToString
            gDataAss = grid.CurrentRow.Cells("A7TSASSE").Value.ToString
            gDataLav = grid.CurrentRow.Cells("A7TSLAVO").Value.ToString
            gDataSos = grid.CurrentRow.Cells("A7TSSOSP").Value.ToString
            gDataChi = grid.CurrentRow.Cells("A7TSCHIU").Value.ToString

            gOraApe = grid.CurrentRow.Cells("A7ORAAP").Value.ToString
            gOraAss = grid.CurrentRow.Cells("A7ORAAS").Value.ToString
            gOraLav = grid.CurrentRow.Cells("A7ORALA").Value.ToString
            gOraSos = grid.CurrentRow.Cells("A7ORASO").Value.ToString
            gOraChi = grid.CurrentRow.Cells("A7ORACH").Value.ToString

            Select Case grid.CurrentRow.Cells("A7STATOC").Value
                Case "AP"
                    txtDataStato.Text = grid.CurrentRow.Cells("A7TSAPER").Value
                    txtOraStato.Text = grid.CurrentRow.Cells("A7ORAAP").Value

                    optAPE.Enabled = True
                    optASS.Enabled = True
                    optLAV.Enabled = False
                    optSOS.Enabled = False
                    optCHI.Enabled = True
                    optAPE.IsChecked = True

                Case "AS"
                    txtDataStato.Text = grid.CurrentRow.Cells("A7TSASSE").Value
                    txtOraStato.Text = grid.CurrentRow.Cells("A7ORAAS").Value

                    optAPE.Enabled = False
                    optLAV.Enabled = False
                    optSOS.Enabled = False
                    optCHI.Enabled = True
                    optASS.Enabled = True
                    optASS.IsChecked = True

                Case "SO"
                    txtDataStato.Text = grid.CurrentRow.Cells("A7TSSOSP").Value
                    txtOraStato.Text = grid.CurrentRow.Cells("A7ORASO").Value

                    optASS.Enabled = False
                    optAPE.Enabled = False
                    optCHI.Enabled = True
                    optSOS.Enabled = True
                    optSOS.IsChecked = True

                Case "LA"
                    txtDataStato.Text = grid.CurrentRow.Cells("A7TSLAVO").Value
                    txtOraStato.Text = grid.CurrentRow.Cells("A7ORALA").Value

                    optASS.Enabled = False
                    optAPE.Enabled = False
                    optCHI.Enabled = True

                    optLAV.Enabled = True
                    optLAV.IsChecked = True

                Case "CH"
                    txtDataStato.Text = grid.CurrentRow.Cells("A7TSCHIU").Value
                    txtOraStato.Text = grid.CurrentRow.Cells("A7ORACH").Value

                    optASS.Enabled = False
                    optAPE.Enabled = False
                    optLAV.Enabled = False
                    optSOS.Enabled = False
                    optCHI.Enabled = True
                    optCHI.IsChecked = True

                Case Else
                    optASS.Enabled = False
                    optAPE.Enabled = False
                    optLAV.Enabled = False
                    optSOS.Enabled = False
                    optCHI.Enabled = False
                    txtDataStato.Text = "__/__/____"
                    txtOraStato.Text = ""

            End Select

            listStati.Items.Clear()

            If Not gDataApe.Contains("0001") Then
                Dim descriptionItemAP As New DescriptionTextListDataItem()
                descriptionItemAP.Text = "APERTA"
                descriptionItemAP.Image = My.Resources.SEGR
                descriptionItemAP.DescriptionText = grid.CurrentRow.Cells("A7TSAPER").Value & " " & grid.CurrentRow.Cells("A7ORAAP").Value
                Me.listStati.Items.Add(descriptionItemAP)
            End If


            If Not gDataAss.Contains("0001") Then
                Dim descriptionItemAS As New DescriptionTextListDataItem()
                descriptionItemAS.Text = "ASSEGNATA"
                descriptionItemAS.Image = My.Resources.ASS
                descriptionItemAS.DescriptionText = grid.CurrentRow.Cells("A7TSASSE").Value & " " & grid.CurrentRow.Cells("A7ORAAS").Value
                Me.listStati.Items.Add(descriptionItemAS)
            End If

            If Not gDataLav.Contains("0001") Then
                Dim descriptionItemLA As New DescriptionTextListDataItem()
                descriptionItemLA.Text = "IN LAVORAZIONE"
                descriptionItemLA.Image = My.Resources.LAV
                descriptionItemLA.DescriptionText = grid.CurrentRow.Cells("A7TSLAVO").Value & " " & grid.CurrentRow.Cells("A7ORALA").Value
                Me.listStati.Items.Add(descriptionItemLA)
            End If

            If Not gDataSos.Contains("0001") Then
                Dim descriptionItemSO As New DescriptionTextListDataItem()
                If grid.CurrentRow.Cells("A7FLIMPFER").Value = "S" Then
                    descriptionItemSO.Text = "SOSPESA IMPIANTO FERMO"
                    descriptionItemSO.Image = My.Resources.SOF
                Else
                    descriptionItemSO.Text = "SOSPESA"
                    descriptionItemSO.Image = My.Resources.SOS
                End If

                descriptionItemSO.DescriptionText = grid.CurrentRow.Cells("A7TSSOSP").Value & " " & grid.CurrentRow.Cells("A7ORASO").Value
                Me.listStati.Items.Add(descriptionItemSO)
            End If

            If Not gDataChi.Contains("0001") Then
                Dim descriptionItemCH As New DescriptionTextListDataItem()
                descriptionItemCH.Text = "CHIUSA"
                descriptionItemCH.Image = My.Resources.CHI
                descriptionItemCH.DescriptionText = grid.CurrentRow.Cells("A7TSCHIU").Value & " " & grid.CurrentRow.Cells("A7TSCHIU").Value
                Me.listStati.Items.Add(descriptionItemCH)
            End If



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

            statoCaricaTecnico = False
            Me.carica_combo_tecnici(grid.CurrentRow.Cells("A7CENMDB").Value, grid.CurrentRow.Cells("A7CODTEC").Value)

            'Me.crea_mappa_impianto()
            batchCaricaMappa = "MAPPA"
            If Not BGWorkDett.IsBusy Then
                BGWorkDett.RunWorkerAsync()
            End If

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

                        'retriveCoord(result, slat, slon)

                        'Me.map.Layers.Remove(Me.map.Layers(tec.ATARGA))

                        Dim location As PointG = MapTileSystemHelper.PixelXYToLatLong(Val(lat), Val(lng), map.MapElement.ZoomLevel)
                        location.Latitude = Val(lat)
                        location.Longitude = Val(lng)


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
        Try
            Dim args As MouseEventArgs = TryCast(e, MouseEventArgs)

            If IsNothing(Me.map.Layers("Callout")) Then
                Exit Sub
            End If
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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdFiltro_Click(sender As Object, e As EventArgs) Handles cmdFiltro.Click
        Try
            Dim parms As New parmsRicChiamate
            Dim listSoc As New List(Of lista_societa)
            Dim listCentri As New List(Of lista_centri)
            Dim listStati As New List(Of parmTabelle)
            Dim codImpianto As String = ""

            Dim array_soc As String
            Dim array_cen As String

            Dim soc As New lista_societa
            Dim cen As New lista_centri

            Me.azzera_campi()

            gRicercaAss = False
            gRicercaLav = False
            gRicercaSos = False
            gRicercaChi = False

            If grigliaCreata = False Then
                Me.crea_griglia_chiamate()
            End If

            soc.societa = txtCodSocRic.Text
            cen.Centro = txtCodCentroRic.Text
            parms.parmCodCli = txtCodClienteRic.Text
            parms.parmCodImpianto = txtCodImpRic.Text

            If IsDate(txtAperturaDal.Text) Then
                parms.parmDataAperturaDa = txtAperturaDal.Text
            End If

            If IsDate(txtAperturaAl.Text) Then
                parms.parmDataAperturaA = txtAperturaAl.Text
            End If

            parms.parmTecnico = txtCodTecRic.Text

            listSoc.Add(soc)
            listCentri.Add(cen)

            parms.parmSoc = listSoc
            parms.parmCentro = listCentri

            Dim lista As New List(Of parmTabelle)
            For j As Integer = 0 To lista_Stati.Items.Count - 1
                If lista_Stati.Items(j).CheckState = Telerik.WinControls.Enumerations.ToggleState.On Then
                    Dim elemento As New parmTabelle
                    elemento.codElem = lista_Stati.Items(j).Value
                    lista.Add(elemento)
                End If
            Next j

            parms.parmStati = lista

            Me.async_carica_griglia_chiamate(parms)
            Me.dockGen.ActiveWindow = DocWinElenco

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

            Dim filtro_soc As String = ""

            If gElencoCentri <> "" And gElencoCentri <> "*" Then
                filtro_soc = " TRIM(XCDEL) IN (SELECT CDSOC FROM " & My.Settings.LibLift & ".RELCENSOC WHERE CDCEN IN (" & gElencoCentri & "))"
            End If
            frm.parmFiltro = filtro_soc
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

            If gElencoCentri <> "" And gElencoCentri <> "*" Then
                frm.parmFiltro = " TCCEN IN (" & gElencoCentri & ")"
            Else
                frm.parmFiltro = ""
            End If

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

            If gElencoCentri <> "" And gElencoCentri <> "*" Then
                frm.parmFiltro = " RTCCE IN (" & gElencoCentri & ")"
            Else
                frm.parmFiltro = ""
            End If

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
            listStati.Items.Clear()
            cmbSocieta.SelectedIndex = -1
            cmbCentri.SelectedIndex = -1
            cmbTecnico.SelectedIndex = -1
            cmbStatoChiamata.SelectedIndex = -1
            optASS.IsChecked = False
            optAPE.IsChecked = False
            optLAV.IsChecked = False
            optSOS.IsChecked = False
            optCHI.IsChecked = False

            gDataApe = ""
            gOraApe = ""
            gDataAss = ""
            gOraAss = ""
            gDataLav = ""
            gOraLav = ""
            gDataSos = ""
            gOraSos = ""
            gDataChi = ""
            gOraChi = ""

            cmbMotivo.SelectedIndex = -1
            TxtCodice.Text = ""
            txtID.Text = ""
            txtIdWeb.Text = "0"
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
            txtRiscontro.Text = ""
            txtRecapito.Text = ""
            txtTipoImp.Text = ""
            chkImpiantoFermo.Checked = False
            chkIntrappolamento.Checked = False
            chkReperib.Checked = False
            Me.map.Layers.Clear()
            statoCaricaTecnico = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdInserisci_Click(sender As Object, e As EventArgs) Handles cmdInserisci.Click
        Try
            azione = "NUOVO"
            Me.azzera_campi()
            Me.cmdConferma.Enabled = True
            Me.cmdAnnulla.Enabled = True
            groupImpianto.Enabled = True
            groupChiamata.Enabled = True
            groupInfo.Enabled = True
            cmbSocieta.Enabled = True
            cmbCentri.Enabled = True
            Me.map.Visible = False
            Me.cmbStatoChiamata.SelectedValue = "AP"
            optAPE.IsChecked = True
            optASS.Enabled = True
            optAPE.Enabled = True
            optLAV.Enabled = False
            optSOS.Enabled = False
            optCHI.Enabled = False

            txtDataStato.Text = Now.Date
            txtOraStato.Text = Format(DateTime.Now, "HH:mm")
            txtDataStato.Enabled = True
            txtOraStato.Enabled = True
            txtRiscontro.ReadOnly = True

            cmbSocieta.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCentri_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCentri.SelectedValueChanged
        Try
            If statoCaricaTecnico = False Then
                Dim centro = cmbCentri.SelectedValue
                carica_combo_tecnici(centro, "")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdModChiam_Click(sender As Object, e As EventArgs) Handles cmdModChiam.Click
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")
        Try
            If grid.Rows.Count = 0 Then
                Exit Sub
            End If

            If grid.CurrentRow.Cells("A7STATOC").Value = "CH" Then
                'RadMessageBox.Show("Impossibile modificare una chiamata chiusa", "Modifica", MessageBoxButtons.OK, RadMessageIcon.Error)
                'Exit Sub
                cmbTecnico.Enabled = False
                cmbStatoChiamata.Enabled = False
                txtDataStato.Enabled = False
                txtOraStato.Enabled = False
            Else
                cmdBCaricaLimit.Enabled = True
                cmdBcaricaTecnici.Enabled = True
                groupImpianto.Enabled = True
                cmbSocieta.Enabled = True
                cmbCentri.Enabled = True
            End If

            Me.cmdConferma.Enabled = True
            Me.cmdAnnulla.Enabled = True
            groupChiamata.Enabled = True
            groupInfo.Enabled = True
            Me.map.Visible = True
            azione = "MODIFICA"

            Me.carica_scheda_impianto(grid.CurrentRow.Cells("A7CODIMP").Value)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdSearchImp_Click(sender As Object, e As EventArgs) Handles cmdSearchImp.Click
        Try
            Dim frm As New FrmImpiantiElenco(Me, "", "", "", "", "RICERCA")
            'frm.CodiceOut = ""
            'frm.DescrOut = ""
            frm.ShowDialog()
            txtCodImpRic.Text = frm.AICIM
            txtDesImpRic.Text = frm.AISTR & " " & frm.AIIND
            frm.Dispose()

        Catch ex As Exception
            txtCodImpRic.Text = ""
            txtDesImpRic.Text = ""
        End Try
    End Sub

    Private Sub cmbStatoChiamata_SelectedIndexChanging(sender As Object, e As PositionChangingCancelEventArgs) Handles cmbStatoChiamata.SelectedIndexChanging
        Try
            Dim stato As String = cmbStatoChiamata.Items(e.Position).Value
            If azione = "NUOVO" AndAlso stato <> "AP" AndAlso stato <> "AS" Then
                e.Cancel = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub async_carica_dashBoard_chiamate(Centri)
        Try
            wb1.AssociatedControl = SplitDash1
            wb1.StartWaiting()
            wb1.Visible = True

            wb2.AssociatedControl = SplitDash2
            wb2.StartWaiting()
            wb2.Visible = True

            wb3.AssociatedControl = SplitDash3
            wb3.StartWaiting()
            wb3.Visible = True

            wb4.AssociatedControl = SplitDash4
            wb4.StartWaiting()
            wb4.Visible = True

            Dim elementi As Threading.Tasks.Task(Of List(Of statChiamateImpianto))
            elementi = ws.getStatChiamateImpianto("", "", "S", Centri)
            Await elementi

            lblChiamateChiuse.Text = "CHIAMATE CHIUSE - " & Now.Date

            If elementi.Result.Count > 0 Then
                lblNrAss.Text = elementi.Result.Item(0).nr_chiamate_ass
                lblNrLav.Text = elementi.Result.Item(0).nr_chiamate_lav
                lblNrSos.Text = elementi.Result.Item(0).nr_chiamate_sos
                lblNrChi.Text = elementi.Result.Item(0).nr_chiamate_chi
                lblImpiantiFermi.Text = "IMPIANTI FERMI - " & elementi.Result.Item(0).nr_chiamate_sos_ferme
            Else
                lblNrAss.Text = "0"
                lblNrLav.Text = "0"
                lblNrSos.Text = "0"
                lblImpiantiFermi.Text = "IMPIANTI FERMI - 0"
                lblNrChi.Text = "0"
            End If
            wb1.AssociatedControl = Nothing
            wb1.StopWaiting()
            wb1.Visible = False

            wb2.AssociatedControl = Nothing
            wb2.StopWaiting()
            wb2.Visible = False

            wb3.AssociatedControl = Nothing
            wb3.StopWaiting()
            wb3.Visible = False

            wb4.AssociatedControl = Nothing
            wb4.StopWaiting()
            wb4.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Dim ws As New webServices
        Dim item As RadListDataItem
        listStati.Items.Clear()

        'Dim descriptionItem2 As New DescriptionTextListDataItem()
        'descriptionItem2.Text = "Sample test"
        'descriptionItem2.Image = My.Resources.camera_24
        'descriptionItem2.DescriptionText = "description sample"
        'Me.RadListControl1.Items.Add(descriptionItem2)

        'Me.RadListControl1.ItemHeight = 40

        'Dim descriptionItem As New DescriptionTextListDataItem()
        'descriptionItem.Text = "Chicken wings"
        ''descriptionItem.Image = My.Resources.chicken_wings
        'descriptionItem.DescriptionText = "some description"
        'Me.listStati.Items.Add(descriptionItem)
        'Dim dataItem As New RadListDataItem()
        'dataItem.Text = "Chicken toast"
        ''dataItem.Image = My.Resources.chicken_toast
        'Me.listStati.Items.Add(dataItem)

        'For i As Integer = 0 To 9
        '    item = New DescriptionTextListDataItem()
        '    item.Text = "TEXT " & i
        '    'item.Image = imageList1.Images(i)

        '    CType(item, DescriptionTextListDataItem).DescriptionText = "sub text " & i

        '    listStati.Items.Add(item)
        'Next i


        Exit Sub
        ws.getElencoChiamateMyFleet("119856", "C20", "DC", "CHI", "S")
            Exit Sub



    End Sub

    Private Sub radListBoxDemo_VisualItemFormatting(ByVal sender As Object, ByVal args As VisualItemFormattingEventArgs)
        'Dim descItem As DescriptionTextListVisualItem = TryCast(args.VisualItem, DescriptionTextListVisualItem)
        'If descItem IsNot Nothing Then
        '    descItem.Separator.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
        'End If
    End Sub

    Private Sub t1Dash_Tick(sender As Object, e As EventArgs) Handles t1Dash.Tick
        Try
            Me.async_carica_dashBoard_chiamate(gElencoCentri)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub optCHI_ToggleStateChanged(sender As Object, args As StateChangedEventArgs) Handles optCHI.ToggleStateChanged
        Try
            If optCHI.IsChecked = True Then
                If Not IsDate(gDataChi) Or gDataChi.Contains("0001") Then
                    txtDataStato.Text = Now.Date
                    txtOraStato.Text = Format(Now, "HH:mm")
                    txtDataStato.ReadOnly = False
                    txtOraStato.ReadOnly = False
                Else
                    txtDataStato.Text = gDataChi
                    txtOraStato.Text = gOraChi
                    txtDataStato.ReadOnly = True
                    txtOraStato.ReadOnly = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub optAPE_ToggleStateChanged(sender As Object, args As StateChangedEventArgs) Handles optAPE.ToggleStateChanged
        Try
            If optAPE.IsChecked = True Then
                If Not IsDate(gDataApe) Or gDataApe.Contains("0001") Then
                    txtDataStato.Text = Now.Date
                    txtOraStato.Text = Format(Now, "HH:mm")
                    txtDataStato.ReadOnly = False
                    txtOraStato.ReadOnly = False
                Else
                    txtDataStato.Text = gDataApe
                    txtOraStato.Text = gOraApe
                    txtDataStato.ReadOnly = True
                    txtOraStato.ReadOnly = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub optASS_ToggleStateChanged(sender As Object, args As StateChangedEventArgs) Handles optASS.ToggleStateChanged
        Try
            If optASS.IsChecked = True Then
                If Not IsDate(gDataAss) Or gDataAss.Contains("0001") Then
                    txtDataStato.Text = Now.Date
                    txtOraStato.Text = Format(Now, "HH:mm")
                    txtDataStato.ReadOnly = False
                    txtOraStato.ReadOnly = False
                Else
                    txtDataStato.Text = gDataAss
                    txtOraStato.Text = gOraAss
                    txtDataStato.ReadOnly = True
                    txtOraStato.ReadOnly = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub optLAV_ToggleStateChanged(sender As Object, args As StateChangedEventArgs) Handles optLAV.ToggleStateChanged
        Try
            If optLAV.IsChecked = True Then
                If Not IsDate(gDataLav) Or gDataLav.Contains("0001") Then
                    txtDataStato.Text = Now.Date
                    txtOraStato.Text = Format(Now, "HH:mm")
                    txtDataStato.ReadOnly = False
                    txtOraStato.ReadOnly = False
                Else
                    txtDataStato.Text = gDataLav
                    txtOraStato.Text = gOraLav
                    txtDataStato.ReadOnly = True
                    txtOraStato.ReadOnly = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub optSOS_ToggleStateChanged(sender As Object, args As StateChangedEventArgs) Handles optSOS.ToggleStateChanged
        Try
            If optSOS.IsChecked = True Then
                If Not IsDate(gDataSos) Or gDataSos.Contains("0001") Then
                    txtDataStato.Text = Now.Date
                    txtOraStato.Text = Format(Now, "HH:mm")
                    txtDataStato.ReadOnly = False
                    txtOraStato.ReadOnly = False
                Else
                    txtDataStato.Text = gDataSos
                    txtOraStato.Text = gOraSos
                    txtDataStato.ReadOnly = True
                    txtOraStato.ReadOnly = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbTecnico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTecnico.SelectedIndexChanged
        Try
            imgTel.Image = Nothing

            If cmbTecnico.SelectedIndex >= 0 Then

                Dim atinv As Object = cmbTecnico.EditorControl.Rows(cmbTecnico.SelectedIndex).Cells("ATINV").Value

                If Not atinv Is Nothing Then
                    Select Case atinv.ToString
                        Case "C"
                            imgTel.Image = My.Resources.Cell_ok
                        Case "V"
                            imgTel.Image = My.Resources.Cell_so
                        Case "S"
                            imgTel.Image = My.Resources.Cell_no
                        Case Else
                            imgTel.Image = My.Resources.Cell_no
                    End Select

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "RECUBE")
        End Try
    End Sub

    Private Sub lblVisAssegnate_Click(sender As Object, e As EventArgs) Handles lblVisAssegnate.Click
        Try

            gRicercaAss = True
            gRicercaLav = False
            gRicercaSos = False
            gRicercaChi = False

            Me.fast_filter_chiamate("AS", "", "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fast_filter_chiamate(stato As String, dataInizio As String, datafine As String)
        Try
            Dim listCentri As New List(Of lista_centri)
            Dim listSoc As New List(Of lista_societa)

            Dim parms As New parmsRicChiamate

            If IsDate(dataInizio) Then
                parms.parmDataChiusuraDa = dataInizio
            End If

            If IsDate(datafine) Then
                parms.parmDataChiusruraA = datafine
            End If

            Dim soc As New lista_societa
            soc.societa = ""
            listSoc.Add(soc)
            parms.parmSoc = listSoc

            Dim cen() As String
            If gElencoCentri <> "*" Then
                cen = gElencoCentri.Replace("'", "").Split(",")
                For i As Integer = 0 To cen.Count - 1
                    Dim lstcen As New lista_centri
                    lstcen.Centro = cen(i)
                    listCentri.Add(lstcen)
                Next

                parms.parmCentro = listCentri
            End If

            parms.parmCodCli = ""
            parms.parmCodImpianto = ""
            parms.parmTecnico = ""


            Dim lista As New List(Of parmTabelle)
            Dim elemento As New parmTabelle
            elemento.codElem = stato
            lista.Add(elemento)

            parms.parmStati = lista

            Me.async_carica_griglia_chiamate(parms)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub lblVisLav_Click(sender As Object, e As EventArgs) Handles lblVisLav.Click
        Try
            gRicercaAss = False
            gRicercaLav = True
            gRicercaSos = False
            gRicercaChi = False
            Me.fast_filter_chiamate("LA", "", "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblVisSos_Click(sender As Object, e As EventArgs) Handles lblVisSos.Click
        Try
            gRicercaAss = False
            gRicercaLav = False
            gRicercaSos = True
            gRicercaChi = False
            Me.fast_filter_chiamate("SO", "", "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblVisChi_Click(sender As Object, e As EventArgs) Handles lblVisChi.Click
        Try
            gRicercaAss = False
            gRicercaLav = False
            gRicercaSos = False
            gRicercaChi = True
            Me.fast_filter_chiamate("CH", Now.Date.ToString, Now.Date.ToString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButton2_Click(sender As Object, e As EventArgs) Handles RadButton2.Click
        Try
            Dim sizeInfo As SplitPanelSizeInfo

            sizeInfo = Me.DocContainerUp.SplitPanels(1).SizeInfo
            'sizeInfo.MinimumSize = New Size(0, 0)
            'sizeInfo.MaximumSize = New Size(0, 0)
            'sizeInfo.AbsoluteSize = New Size(0, 0)

            'Me.DocumentContainer2.Splitters(0).Fixed = True

            'Dim window As ToolWindow = Me.ToolWinChiamata

            'Dim strip As DockTabStrip = DirectCast(window.TabStrip, DockTabStrip)
            'strip.SizeInfo.AbsoluteSize = New System.Drawing.Size(100, strip.SizeInfo.AbsoluteSize.Height)

            'DocumentTabStrip4.Visible = False

            Dim strip As TabStripPanel = TryCast(Me.ToolWinChiamata.TabStrip, TabStripPanel)
            strip.SizeInfo.AbsoluteSize = New Size(0, 0)
            Dim strip2 As TabStripPanel = TryCast(Me.ToolWinMap.TabStrip, TabStripPanel)
            strip2.SizeInfo.AbsoluteSize = New Size(0, 0)
            Dim strip3 As TabStripPanel = TryCast(Me.DocTabStripMappa, TabStripPanel)
            strip3.SizeInfo.AbsoluteSize = New Size(0, 0)


        Catch ex As Exception

        End Try
    End Sub
End Class
