Imports System.Globalization
Imports System.Threading
Imports Telerik.WinControls
Imports Telerik.WinControls.UI


Imports System.IO
Imports Telerik.Windows.Documents.Spreadsheet.FormatProviders
Imports Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx
Imports Telerik.Windows.Documents.Spreadsheet.FormatProviders.TextBased.Csv
Imports Telerik.Windows.Documents.Spreadsheet.Model
Imports Telerik.Windows.Documents.Spreadsheet.Utilities
Imports System.Data.OleDb
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Text

Public Class frmSchedulerManBeta
    Private ws As New webServices
    Dim statoCaricaScheduler As Boolean
    Dim statoCaricaSoc As Boolean
    Dim statoCaricaCentri As Boolean
    Dim statoRicerca As Boolean
    Dim statoCaricaSquadre As Boolean

    Private varCodImp As String
    Private varID As String
    Private varDesImp As String
    Private varTipoImp As String
    Private varTipoVis As String
    Private varDataIni As String
    Private varDataFin As String
    Private varDataEff As String
    Private varSoc As String
    Private varCentro As String
    Private varNote As String

    Private gElencoCentri As String = ""
    Private radPrintDocument1 As RadPrintDocument

    Public Sub New(ByVal inAzione As String, Optional ByVal ElencoCentri As String = "", Optional ByVal inUser As String = "", Optional ByVal inRuolo As String = "", Optional ByVal inUserAS As String = "", Optional ByVal modifica As Boolean = True, Optional ByVal testo As String = "")
        InitializeComponent()
        WireEvents()

        Me.radPrintDocument1 = New RadPrintDocument()
        Me.radPrintDocument1.AssociatedObject = Me.gant


        'idImpianto = codImpianto
        'azione = inAzione

        'ruolo = inRuolo
        'user = inUser
        'userAS = inUserAS
        gElencoCentri = ElencoCentri
    End Sub

    Protected Sub WireEvents()
        AddHandler Me.gant.GanttViewElement.ItemEditing, AddressOf GanttViewElement_ItemEditing
        AddHandler Me.gant.TextViewItemFormatting, AddressOf radGanttView_TextViewItemFormatting
        AddHandler Me.gant.TextViewCellFormatting, AddressOf radGanttView_TextViewCellFormatting


        '--------------------------------------------------------
        AddHandler Me.gant.GraphicalViewItemFormatting, AddressOf CustomRadGanttView_GraphicalViewItemFormatting
        AddHandler Me.gant.TimelineItemFormatting, AddressOf CustomRadGanttView_TimelineItemFormatting

    End Sub

    Private Sub FrmImpianto_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonDFT.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonBLU.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonRED.tssp")

            cmdFiltro.ThemeName = "buttonDFT"

            'cmdSalvaTpVis.ThemeName = "buttonBLU"
            'cmdSalvaPianA.ThemeName = "buttonDFT"
            'cmdAnnulla.ThemeName = "buttonDFT"
            'cmdAnnPianA.ThemeName = "buttonDFT"
            'cmdAnnullaAss.ThemeName = "buttonDFT"
            'cmdConfermaAss.ThemeName = "buttonDFT"
            'cmdContratto.ThemeName = "buttonDFT"

            statoCaricaScheduler = False

            wbG.AssociatedControl = Me
            wbG.StartWaiting()
            wbG.Visible = True

            t1.Enabled = True

            'formInCaricamento = True

            'Dim stripElement As RadPageViewStripElement = DirectCast(Me.RPcontainer.ViewElement, RadPageViewStripElement)
            'stripElement.StripButtons = StripViewButtons.None
            'Dim stripElementDett As RadPageViewStripElement = DirectCast(Me.pageDett.ViewElement, RadPageViewStripElement)
            'stripElementDett.StripButtons = StripViewButtons.None

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub


    Private Sub FrmImpianto_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Me.carica_combo_soc()
            Me.carica_combo_centro()
            Me.carica_combo_squadre()

        Catch ex As Exception
            wbG.AssociatedControl = Nothing
            wbG.StopWaiting()
            wbG.Visible = False

        End Try
    End Sub

    Private Sub t1_Tick(sender As Object, e As EventArgs) Handles t1.Tick
        Try


            If (statoCaricaSoc = True And statoCaricaCentri = True And statoCaricaSquadre = True) OrElse
                (statoRicerca = True And statoCaricaScheduler = True) Then

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

    Private Async Sub carica_combo_centro()
        Try
            Dim filtro As String = ""

            If gElencoCentri <> "*" Then
                filtro = filtro & "  TCCEN IN (" & gElencoCentri & ")"
            End If

            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("CENTRI", "", filtro)
            Await elementi

            Me.cmbCentro.DataSource = elementi.Result
            Me.cmbCentro.DisplayMember = "codElem"
            Me.cmbCentro.ValueMember = "codElem"
            Me.cmbCentro.SelectedIndex = -1

            statoCaricaCentri = True

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_soc()
        Try
            Dim filtro As String = ""


            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("SOC", "", filtro)
            Await elementi

            Me.cmbSoc.DataSource = elementi.Result
            Me.cmbSoc.DisplayMember = "desElem"
            Me.cmbSoc.ValueMember = "codElem"
            Me.cmbSoc.SelectedIndex = -1

            statoCaricaSoc = True

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_squadre()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("SQUADRE", "")
            Await elementi

            Me.cmbSquadre.DataSource = elementi.Result
            Me.cmbSquadre.DisplayMember = "desElem"
            Me.cmbSquadre.ValueMember = "codElem"
            Me.cmbSquadre.SelectedIndex = -1

            statoCaricaSquadre = True

        Catch ex As Exception
            statoCaricaSquadre = True
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Function controlli_form() As Boolean
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            If cmbSoc.SelectedIndex < 0 And cmbCentro.SelectedIndex < 0 Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Selezionare Società e Centro", "Ricerca", MessageBoxButtons.OK, RadMessageIcon.Error)
                Return False
            End If

            Return True
        Catch ex As Exception
            Telerik.WinControls.RadMessageBox.Show(Me, ex.Message, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return False
        End Try

    End Function
    Private Sub carica_dati_form()
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            Dim codSoc As String
            Dim codimp As String
            Dim codCen As String
            Dim codcli As String
            Dim Matricola As String
            Dim Descrizione As String
            Dim IdSquadra As String
            Dim dataIni As String
            Dim dataFine As String

            codSoc = cmbSoc.SelectedValue
            codCen = cmbCentro.SelectedValue
            codimp = txtImpianto.Text
            codcli = txtCodCliente.Text
            Matricola = txtMatricola.Text.Trim
            dataIni = IIf(IsDate(txtDataDal.Value), txtDataDal.Value, "")
            dataFine = IIf(IsDate(txtDataAl.Value), txtDataAl.Value, "")
            Descrizione = txtDescr.Text.Trim
            IdSquadra = cmbSquadre.SelectedValue

            async_carica_gantt_manutenzioni(codimp, codSoc, codCen, codcli, Matricola, dataIni, dataFine, Descrizione, IdSquadra)
        Catch ex As Exception
            Telerik.WinControls.RadMessageBox.Show(Me, ex.Message, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Async Sub async_carica_gantt_manutenzioni(codImp As String, codSoc As String, codCen As String, codCli As String,
                                                      Optional Matricola As String = "", Optional DataIni As String = "",
                                                      Optional DataFine As String = "", Optional Descr As String = "",
                                                      Optional IdSquadra As String = "")
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoManutenzioni))
            elementi = ws.getManutenzioniElenco(codImp, codSoc, codCen, codCli, Matricola, DataIni, DataFine, Descr,, IdSquadra)
            Await elementi

            Me.carica_gantt_visite(elementi.Result)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub carica_gantt_visite(dati As List(Of elencoManutenzioni))
        Try
            Me.carica_gantt_manutenzioni(dati)
            statoCaricaScheduler = True
        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
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
                Dim valore As String = e.Item(Me.gant.Columns.Item(4)).ToString
                Dim StatoVis As String = e.Item(Me.gant.Columns.Item(13)).ToString
                If valore.Contains("N") OrElse StatoVis.Contains("R") Then
                    If valore.Contains("N") Then
                        e.ItemElement.DrawFill = True
                        e.ItemElement.BackColor = Color.FromArgb(240, 230, 140)
                        e.ItemElement.GradientStyle = GradientStyles.Solid
                    Else
                        e.ItemElement.ResetValue(LightVisualElement.DrawBorderProperty, ValueResetFlags.Local)
                        e.ItemElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                        e.ItemElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local)
                    End If

                    If StatoVis.Contains("R") Then
                        e.ItemElement.ForeColor = Color.ForestGreen
                    Else
                        e.ItemElement.ForeColor = Color.Black
                    End If

                Else
                    e.ItemElement.ResetValue(LightVisualElement.DrawBorderProperty, ValueResetFlags.Local)
                    e.ItemElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                    e.ItemElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local)
                    e.ItemElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                End If
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

    Private Sub gant_GraphicalViewItemFormatting(sender As Object, e As GanttViewGraphicalViewItemFormattingEventArgs) Handles gant.GraphicalViewItemFormatting
        Try
            e.ItemElement.TaskElement.Text = e.Item.Tag
        Catch ex As Exception
        End Try
    End Sub

    Private Sub gantt_SelectedItemChanged(ByVal sender As Object, ByVal e As GanttViewSelectedItemChangedEventArgs) Handles gant.SelectedItemChanged
        Try
            If e.Item.Level = 1 Then Exit Sub

            Dim dateToScroll = e.Item.Start

            Me.gant.GanttViewElement.GraphicalViewElement.TimelineStart = New DateTime(Year(dateToScroll), 1, 1)
            Me.gant.GanttViewElement.GraphicalViewElement.ScrollTo(dateToScroll)

            Dim column = Me.gant.CurrentColumn

            For Each col In Me.gant.Columns
                Dim gItem As New GanttViewDataItem
                gItem = DirectCast(e.Item, GanttViewDataItem)

                Dim valore As String = ""
                If Not IsNothing(gItem(col)) Then
                    valore = gItem(col).ToString
                End If

                Select Case (col.Name.ToUpper)

                    Case "CODIMPIANTO"
                        varCodImp = valore

                    Case "DESIMPIANTO"
                        varTipoVis = e.Item.Tag

                    Case "TITLE"
                        varDesImp = valore

                    Case "START"
                        varDataIni = valore

                    Case "END"
                        varDataFin = valore

                    Case "DTEFFETT"
                        varDataEff = valore

                    Case "TIPOIMPIANTO"
                        varTipoImp = valore

                    Case "ID"
                        varID = valore

                    Case "CDSOC"
                        varSoc = valore

                    Case "CENTRO"
                        varCentro = valore

                    Case "NOTE"
                        varNote = valore

                End Select


            Next

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub CustomRadGanttView_TimelineItemFormatting(sender As Object, e As GanttViewTimelineItemFormattingEventArgs)
        Try



            Dim tlDate As DateTime
            Dim element As LightVisualElement

            Dim dateTimeFormats As DateTimeFormatInfo
            dateTimeFormats = New CultureInfo("it-IT").DateTimeFormat
            Thread.CurrentThread.CurrentCulture = New CultureInfo("it-IT")
            dateTimeFormats.FirstDayOfWeek = DayOfWeek.Monday

            For i As Integer = 0 To e.ItemElement.Children(1).Children.Count - 1
                tlDate = e.ItemElement.Data.Start.AddDays(i)
                element = TryCast(e.ItemElement.Children(1).Children(i), LightVisualElement)
                If element IsNot Nothing Then
                    'Dim nome As String = WeekdayName(Weekday(tlDate, FirstDayOfWeek.Monday))

                    Dim thisCulture As Globalization.CultureInfo = Globalization.CultureInfo.CurrentCulture
                    Dim dayOfWeek As DayOfWeek = thisCulture.Calendar.GetDayOfWeek(tlDate)
                    Dim nome As String = thisCulture.DateTimeFormat.GetDayName(dayOfWeek)

                    'element.Text = tlDate.Day & vbLf & tlDate.DayOfWeek.ToString().Substring(0, 2)
                    element.Text = tlDate.Day & vbLf & nome.Substring(0, 3)
                    element.Font = New Font("Arial", 7.5F)
                    If nome.Substring(0, 3) = "dom" Or nome.Substring(0, 3) = "sab" Then
                        element.DrawFill = True
                        element.BackColor = Color.FromArgb(255, 108, 108)
                        element.ForeColor = Color.White
                        element.GradientStyle = GradientStyles.Solid
                        'element.BackColor = Color.Coral
                    Else
                        element.ResetValue(LightVisualElement.DrawBorderProperty, ValueResetFlags.Local)
                        element.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                        element.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                        element.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local)
                    End If
                End If
            Next
        Catch ex As Exception
            Telerik.WinControls.RadMessageBox.Show(Me, ex.Message, "Gestione visite", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub


    Private Sub CustomRadGanttView_GraphicalViewItemFormatting(sender As Object, e As GanttViewGraphicalViewItemFormattingEventArgs)
        e.ItemElement.DrawFill = False
    End Sub


    Private Sub carica_gantt_manutenzioni(dati As List(Of elencoManutenzioni))
        Try
            'Me.gant.GanttViewElement.GraphicalViewElement.TimelineRange = TimeRange.Day 'TimeRange.Year
            'Me.gant.GanttViewElement.GraphicalViewElement.OnePixelTime = New TimeSpan(0, 60, 0)

            'Me.gant.GanttViewElement.GraphicalViewElement.OnePixelTime = New TimeSpan(0, 50, 0)


            Me.gant.Columns.Clear()
            Me.gant.Items.Clear()

            '----------------------------------------------------------------
            Me.gant.EnableCustomPainting = True
            '----------------------------------------------------------------

            Dim CodiceColumn As New GanttViewTextViewColumn("CodImpianto")
            Dim DesColumn As New GanttViewTextViewColumn("DesImpianto")
            Dim titleColumn As New GanttViewTextViewColumn("Title")
            Dim startColumn As New GanttViewTextViewColumn("Start")
            Dim endColumn As New GanttViewTextViewColumn("End")
            Dim TipoImpiantoCol As New GanttViewTextViewColumn("tipoImpianto")
            Dim dtEffetCol As New GanttViewTextViewColumn("dtEffett")
            Dim nrBollCol As New GanttViewTextViewColumn("NrBoll")
            Dim aaBollCol As New GanttViewTextViewColumn("AnnoBoll")
            Dim firmaCol As New GanttViewTextViewColumn("Firma")
            Dim NoteCol As New GanttViewTextViewColumn("Note")
            Dim IDCol As New GanttViewTextViewColumn("ID")
            Dim CdSocCol As New GanttViewTextViewColumn("CdSoc")
            Dim CentroCol As New GanttViewTextViewColumn("Centro")
            Dim Squadra As New GanttViewTextViewColumn("Squadra")
            Dim flagDiurno As New GanttViewTextViewColumn("FlagDiurno")
            Dim flagStato As New GanttViewTextViewColumn("FlagStato")

            CodiceColumn.HeaderText = "Cod. Imp."
            DesColumn.HeaderText = "Tipo Visita"
            titleColumn.HeaderText = "Impianto"
            startColumn.HeaderText = "Data Inizio"
            endColumn.HeaderText = "Data Fine"
            dtEffetCol.HeaderText = "Data effett."
            nrBollCol.HeaderText = "Nr. Boll."
            firmaCol.HeaderText = "Firmato"
            NoteCol.HeaderText = "Note"
            aaBollCol.HeaderText = "Anno"
            TipoImpiantoCol.HeaderText = "Tipologia"
            IDCol.HeaderText = "ID"
            CdSocCol.HeaderText = "Soc."
            CentroCol.HeaderText = "Cen."
            flagDiurno.HeaderText = "D/N"
            Squadra.HeaderText = "Squadra"
            flagStato.HeaderText = "Stato Rec"

            Me.gant.GanttViewElement.Columns.Add(titleColumn)
            Me.gant.GanttViewElement.Columns.Add(CodiceColumn)
            Me.gant.GanttViewElement.Columns.Add(DesColumn)
            Me.gant.GanttViewElement.Columns.Add(TipoImpiantoCol)
            Me.gant.GanttViewElement.Columns.Add(flagDiurno)
            Me.gant.GanttViewElement.Columns.Add(startColumn)
            Me.gant.GanttViewElement.Columns.Add(endColumn)
            Me.gant.GanttViewElement.Columns.Add(dtEffetCol)
            Me.gant.GanttViewElement.Columns.Add(Squadra)

            Me.gant.GanttViewElement.Columns.Add(IDCol)
            Me.gant.GanttViewElement.Columns.Add(CdSocCol)
            Me.gant.GanttViewElement.Columns.Add(CentroCol)
            Me.gant.GanttViewElement.Columns.Add(NoteCol)
            Me.gant.GanttViewElement.Columns.Add(flagStato)

            'Me.gant.GanttViewElement.Columns.Add(nrBollCol)
            'Me.gant.GanttViewElement.Columns.Add(aaBollCol)
            'Me.gant.GanttViewElement.Columns.Add(firmaCol)
            'Me.gant.GanttViewElement.Columns.Add(NoteCol)

            gant.Columns("Start").FormatString = "{0:dd/MM/yyyy}" ' "{0:dd/MM/yyyy HH:mm}"
            gant.Columns("End").FormatString = "{0:dd/MM/yyyy}"
            gant.Columns("DtEffett").FormatString = "{0:dd/MM/yyyy}"

            gant.Columns("CodImpianto").Width = 80
            gant.Columns("DesImpianto").Width = 100
            gant.Columns("tipoImpianto").Width = 100
            gant.Columns("Title").Width = 200
            gant.Columns("End").Width = 100
            gant.Columns("Start").Width = 100
            gant.Columns("dtEffett").Width = 100
            gant.Columns("ID").Width = 40
            gant.Columns("CDSoc").Width = 40
            gant.Columns("Centro").Width = 40
            gant.Columns("Note").Width = 150
            gant.Columns("Squadra").Width = 150
            gant.Columns("FlagDiurno").Width = 50

            gant.Columns("Centro").Visible = False
            gant.Columns("CDSoc").Visible = False
            gant.Columns("ID").Visible = False
            gant.Columns("FlagStato").Visible = False

            'gant.Columns("NrBoll").Width = 65
            'gant.Columns("AnnoBoll").Width = 60
            'gant.Columns("Firma").Width = 65

            Me.gant.GanttViewElement.GraphicalViewElement.TimelineStart = New DateTime(2020, 1, 1)
            Me.gant.GanttViewElement.GraphicalViewElement.TimelineEnd = New DateTime(2020, 12, 31)


            'Me.gant.GanttViewElement.GraphicalViewElement.SpecialDates.Add(New DateTime(2020, 12, 25))
            'DirectCast(Me.gant.GanttViewElement.GraphicalViewElement, CustomGanttViewGraphicalViewElement).SpecialDates.Add(New DateTime(2020, 12, 26))

            Me.gant.GanttViewElement.GraphicalViewElement.AutomaticTimelineTimeRange = True
            Me.gant.GanttViewElement.GraphicalViewElement.TimelineRange = TimeRange.Week 'TimeRange.Month 'TimeRange.Year
            'Me.SetupTrackbar()

            Dim dateToScroll = New DateTime(Now.Year, 1, 1)
            Me.gant.GanttViewElement.GraphicalViewElement.TimelineStart = New DateTime(Year(dateToScroll), 1, 1)
            Me.gant.GanttViewElement.GraphicalViewElement.ScrollTo(dateToScroll)

            Dim appTipoVis As String = ""
            Dim tipoVis As String = ""
            Dim appAnno As String = ""
            Dim annoVis As String = ""
            Dim id As Integer = 1
            Dim codimp As String = ""
            Dim appCodImp As String = ""

            Dim itemGruppo As New GanttViewDataItem()
            itemGruppo.Start = New DateTime(2020, 1, 1)
            itemGruppo.[End] = New DateTime(2023, 12, 31)
            itemGruppo.Title = "PIANIFICAZIONE IMPIANTI"

            For i As Integer = 0 To dati.Count - 1
                tipoVis = dati(i).tipoVisita
                annoVis = Year(dati(i).dataInizio)
                codimp = dati(i).CodImpianto

                '---- GESTIONE GRUPPO GANTT -----------------
                'If appCodImp <> codimp Then
                '    If appCodImp <> "" Then
                '        Me.gant.Items.Add(itemGruppo)
                '        itemGruppo = New GanttViewDataItem()
                '        id = 1
                '    End If

                'itemGruppo.Start = New DateTime(Year(dati(i).dataInizio), 1, 1)
                'itemGruppo.[End] = New DateTime(Year(dati(i).dataInizio), 12, 31)
                'itemGruppo.Title = dati(i).descrImpianto.ToUpper

                '    appTipoVis = dati(i).tipoVisita
                '    appAnno = Year(dati(i).dataInizio)
                '    appCodImp = dati(i).CodImpianto
                'End If
                '---------------------------------------------


                Dim itemVis As New liftGanttViewDataItem()

                'Dim o As Integer = Hour(dati(i).dataInizioTS)
                'Dim m As Integer = Minute(dati(i).dataInizioTS)
                'Dim s As Integer = Second(dati(i).dataInizioTS)
                'Dim aa As Integer = Year(dati(i).dataInizioTS)
                'Dim dd As Integer = DateTime.Parse(dati(i).dataInizioTS).Day
                'Dim mm As Integer = Month(dati(i).dataInizioTS)
                'itemVis.Start = New DateTime(aa, mm, dd, o, m, s)

                'o = Hour(dati(i).dataFineTS)
                'm = Minute(dati(i).dataFineTS)
                's = Second(dati(i).dataFineTS)
                'aa = Year(dati(i).dataFineTS)
                'dd = DateTime.Parse(dati(i).dataFineTS).Day
                'mm = Month(dati(i).dataFineTS)
                'itemVis.[End] = New DateTime(aa, mm, dd, o, m, s)

                itemVis.Start = CDate(dati(i).dataInizio & " 00:00:00")
                itemVis.[End] = CDate(dati(i).dataFine & " 23:00:00")

                itemVis.Title = dati(i).descrImpianto
                If IsDate(dati(i).dataEffettTS) Then
                    'itemVis.dtEffett = CDate(dati(i).dataEffettTS)
                    itemVis.dtEffett = CDate(dati(i).dataEffett)
                Else
                    itemVis.dtEffett = Nothing
                End If
                'itemVis.NrBoll = dati(i).numBoll
                'itemVis.AnnoBoll = dati(i).annoBoll
                itemVis.tipoImpianto = dati(i).TipoImpianto
                itemVis.CodImpianto = dati(i).CodImpianto
                itemVis.DesImpianto = dati(i).DescrMan
                itemVis.Tag = dati(i).cdabbrev
                itemVis.ID = dati(i).id
                itemVis.CdSoc = dati(i).codSocieta
                itemVis.Centro = dati(i).CodCentro
                itemVis.Note = dati(i).note
                itemVis.Squadra = dati(i).des_squadra
                itemVis.IdSquadra = dati(i).idsquadra
                itemVis.FlagDiurno = dati(i).flagDiurnoNotturno
                itemVis.FlagStato = dati(i).flagStatoVisita

                'Me.gant.Items.Add(itemGruppo)

                itemGruppo.Items.Add(itemVis)
                id = id + 1
            Next

            'If appTipoVis <> tipoVis Then
            Me.gant.Items.Add(itemGruppo)
            'End If

            Me.gant.Ratio = 0.3
            'Me.gant.GanttViewElement.Items(gant.GanttViewElement.Items.Count - 1).Selected = True
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub cmdInserisci_Click(sender As Object, e As EventArgs) Handles cmdInserisci.Click
        Try
            Dim frm As New FrmGestVisitaBeta
            frm.iniAzione = "INSERISCI"
            frm.iniCentro = "E14"
            frm.iniSoc = "MT"

            frm.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdBModifica_Click(sender As Object, e As EventArgs) Handles cmdBModifica.Click
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            If varCodImp = "" Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Nessuna visita selezionata", "Gestione visite", MessageBoxButtons.OK, RadMessageIcon.Error)
                Exit Sub
            End If
            Dim frm As New FrmGestVisitaBeta
            'Dim codice As String = Me.gant.GanttViewElement.SelectedItem
            frm.iniData = varDataIni
            frm.iniDatafine = varDataFin
            frm.iniDataChi = varDataEff
            frm.iniCodice = varCodImp
            frm.iniTipoVisita = varTipoVis
            frm.iniID = varID
            frm.iniAzione = "MODIFICA"
            frm.iniSoc = varSoc
            frm.iniCentro = varCentro
            frm.iniNote = varNote
            frm.ShowDialog()

        Catch ex As Exception
            Telerik.WinControls.RadMessageBox.Show(Me, ex.Message, "Gestione visite", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub gant_DoubleClick(sender As Object, e As EventArgs) Handles gant.DoubleClick
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdFiltro_Click(sender As Object, e As EventArgs) Handles cmdFiltro.Click
        Try
            If controlli_form() = False Then
                Exit Sub
            End If

            statoRicerca = True
            statoCaricaScheduler = False
            wbG.AssociatedControl = Me
            wbG.StartWaiting()
            wbG.Visible = True

            t1.Enabled = True

            Me.carica_dati_form()
        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub salva_dati(azione As String)
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            wbG.AssociatedControl = Me
            wbG.StartWaiting()
            wbG.Visible = True

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            Dim parms As New elencoManutenzioni

            parms.id = Val(varID)


            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

            Dim postContent = jss.Serialize(parms)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = "https://localhost:44323/api/visite/saveVisitaBeta1/postSaveVisitaBeta1"
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("parmVisita", postContent)
            client.DefaultRequestHeaders.Add("parmAzione", azione)

            Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)

            wbG.StopWaiting()
            wbG.AssociatedControl = Nothing
            wbG.Visible = False

            Dim sStatusCode As String = postResponse.StatusCode.ToString

            If sStatusCode.ToUpper <> "OK" Then
                Dim msg As String = postResponse.Headers.GetValues("Error").FirstOrDefault()

                Telerik.WinControls.RadMessageBox.Show(Me, "Operazione non effettuata. " & vbCrLf & "Causa: " & msg, azione, MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Telerik.WinControls.RadMessageBox.Show(Me, "Operazione effettuata", azione, MessageBoxButtons.OK, RadMessageIcon.Info)
            End If

        Catch EX As Exception
            wbG.StopWaiting()
            wbG.AssociatedControl = Nothing
            wbG.Visible = False
            Telerik.WinControls.RadMessageBox.Show(Me, "Errore", "Errore", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Sub cmdBStampaElenco_Click(sender As Object, e As EventArgs) Handles cmdBStampaElenco.Click
        Me.gant.PrintPreview(Me.radPrintDocument1)
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

    Private Sub xmdExportExcel_Click(sender As Object, e As EventArgs) Handles xmdExportExcel.Click



        Try
            WorkbookFormatProvidersManager.RegisterFormatProvider(New XlsxFormatProvider())

            Me.prova()
            Exit Sub

            Dim workbook As Workbook = New Workbook()
            workbook.Sheets.Add(SheetType.Worksheet)
            Dim worksheet As Worksheet = workbook.ActiveWorksheet
            'Me.PrepareInvoiceDocument(worksheet, gridView.RowCount)
            Dim currentRow As Integer = 1

            For i = 0 To 10
                worksheet.Cells(currentRow, 1).SetValue("val " & i)
                worksheet.Cells(currentRow, 2).SetValue("val " & i)
                worksheet.Cells(currentRow, 3).SetValue("val " & i)
                worksheet.Cells(currentRow, 4).SetValue("val " & i)
                currentRow += 1
            Next


            Dim fileName As String = "c: \temp\SampleFile.xlsx"
            Dim formatProvider As IWorkbookFormatProvider = GetFormatProvider("Xlsx")


            Dim dialog As SaveFileDialog = New SaveFileDialog()
            dialog.Filter = String.Format("{0} files|*{1}|All files (*.*)|*.*", "xlsx", formatProvider.SupportedExtensions.First())
            dialog.FileName = "SpreadDocumentsGeneration"

            If dialog.ShowDialog() = DialogResult.OK Then

                Try
                    Using stream As Stream = dialog.OpenFile()
                        formatProvider.Export(workbook, stream)
                    End Using

                Catch ex As IOException
                    MessageBox.Show(ex.Message, "Error")
                End Try
            End If

            'colonne 


        Catch ex As Exception

        End Try

    End Sub

    Private Shared Function GetFormatProvider(ByVal extension As String) As IWorkbookFormatProvider
        Dim formatProvider As IWorkbookFormatProvider

        Select Case extension
            Case "Xlsx"
                formatProvider = WorkbookFormatProvidersManager.GetProviderByName("XlsxFormatProvider")
            Case "Csv"
                formatProvider = WorkbookFormatProvidersManager.GetProviderByName("CsvFormatProvider")
                TryCast(formatProvider, CsvFormatProvider).Settings.HasHeaderRow = True
            Case "Txt"
                formatProvider = WorkbookFormatProvidersManager.GetProviderByName("TxtFormatProvider")
            Case Else
                formatProvider = Nothing
        End Select

        Return formatProvider
    End Function


    Private Sub prova()

        Dim workbook As Telerik.Windows.Documents.Spreadsheet.Model.Workbook = New Telerik.Windows.Documents.Spreadsheet.Model.Workbook()
        workbook.Worksheets.Add()

        Dim worksheet As Worksheet = workbook.ActiveWorksheet
        Dim currentRow As Integer = 1


        Dim dd As Date
        dd = CDate("24/01/2020")


        'Dim thisCulture As Globalization.CultureInfo = Globalization.CultureInfo.CurrentCulture
        'Dim dOfWeek As DayOfWeek = thisCulture.Calendar.GetDayOfWeek(dd)
        'Dim nome As String = thisCulture.DateTimeFormat.GetDayName(dOfWeek)

        'Settimana dell'anno 
        'Dim culture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
        'Dim intWeek As Integer = culture.Calendar.GetWeekOfYear(dd, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)

        Dim conn As New OleDbConnection(My.Settings.cnAS400)
        conn.Open()

        Dim sSql As String = ""
        sSql = "select min(week_iso(sdtini)) minW, min(year(sdtini)) minY, max(week_iso(sdtini)) maxW, max(year(sdtini)) maxY "
        sSql = sSql & "from lift_net.animpman "
        sSql = sSql & "where scdsoc = 'MT' and scdcen = 'E14' and sdtini between '2020-01-01' and '2020-12-31' "

        Dim cmd As New OleDbCommand(sSql, conn)
        Dim reader As OleDbDataReader = cmd.ExecuteReader()

        Dim yearIni As Integer = 0
        Dim yearFin As Integer = 0

        Dim weekIni As Integer = 0
        Dim weekFin As Integer = 0

        While reader.Read
            weekIni = reader("minW")
            weekFin = reader("maxW")
            yearIni = reader("minY")
            yearFin = reader("maxY")
        End While

        reader.Close()

        If yearIni = 0 Then
            Exit Sub
        End If

        sSql = "SELECT SID, AISTR, AIIND, SCDSOC, SCDCEN, SCDIMP, SDTINI, SDTFIN, SDTEFF, STPMAN, AIMAT, "
        sSql = sSql & "SNRBOLL, SAABOLL, SFLFIRMA, SFLMANU, SFLSCAM, SDTBOLL, SDTGEN, "
        sSql = sSql & "SDTMAN, SDTCHI, SDTUPD, SUTECHI, VDESCR, SUBSTR(CCI.XDTAB, 1, 25) AS DESCCI, STSINI, STSFIN, STSEFF, SNOTE, VCDABR, "
        sSql = sSql & "SIDSQU, SFLNDI, SQU.QDESCR "
        sSql = sSql & "FROM LIFT_NET.ANIMPMAN LEFT JOIN LIFT_NET.TBTIPIMAN ON STPMAN = VCDMAN "
        sSql = sSql & "LEFT JOIN LIFT_NET.ANIMP00F ON AICIM = SCDIMP "
        sSql = sSql & "LEFT JOIN LIFT_DAT.TABEL00F CCI ON CCI.XCDEL = AICCI And CCI.XCDTB = 'CCI' "
        sSql = sSql & "LEFT JOIN LIFT_NET.TBSQUADRE SQU ON SQU.QID= SIDSQU "
        sSql = sSql & "where scdsoc = 'MT' and scdcen = 'E14' and sdtini between '2020-01-01' and '2020-12-31' "
        sSql = sSql & "order by sdtini "

        cmd.CommandText = sSql
        reader = cmd.ExecuteReader

        If reader.HasRows = False Then
            Exit Sub
        End If


        Dim purple As ThemableColor = ThemableColor.FromArgb(255, 119, 136, 153)
        Dim darkBlue As ThemableColor = ThemableColor.FromArgb(255, 44, 62, 80)

        Dim darkBlueBorders As CellBorders = New CellBorders(
            New CellBorder(CellBorderStyle.Thin, darkBlue),   '// Left border 
            New CellBorder(CellBorderStyle.Thin, darkBlue),   '// Top border 
            New CellBorder(CellBorderStyle.Thin, darkBlue),   '// Right border 
            New CellBorder(CellBorderStyle.Thin, darkBlue),   '// Bottom border 
            New CellBorder(CellBorderStyle.Thin, purple),       '// Inside horizontal border 
            New CellBorder(CellBorderStyle.Thin, purple),       '// Inside vertical border 
            New CellBorder(CellBorderStyle.None, darkBlue),     '// Diagonal up border 
            New CellBorder(CellBorderStyle.None, darkBlue))    '// Diagonal down border 

        Dim iDayOfYear As Integer
        iDayOfYear = dd.DayOfYear


        'Ciclo per anni
        '......
        'Ciclo per le settimane dell'anno che sto analizzando
        currentRow = 0

        'carico le date
        worksheet.Cells(0, 0).SetValue("DESCRIZIONE")
        worksheet.Cells(0, 1).SetValue("MATRICOLA")
        worksheet.Cells(0, 2).SetValue("TIPO IMPIANTO")
        worksheet.Cells(0, 3).SetValue("DATA")
        worksheet.Cells(0, 4).SetValue("D/N")
        worksheet.Cells(0, 5).SetValue("SQUADRA")

        Dim ColumnSel As ColumnSelection

        Dim C1T As CellIndex = New CellIndex(0, 0)
        Dim C2T As CellIndex = New CellIndex(2, 0)
        ColumnSel = worksheet.Columns(0, 0)
        ColumnSel.SetBorders(darkBlueBorders)
        worksheet.Cells(C1T, C2T).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
        worksheet.Cells(C1T, C2T).SetVerticalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadVerticalAlignment.Center)
        worksheet.Cells(C1T, C2T).Merge()


        C1T = New CellIndex(0, 1)
        C2T = New CellIndex(2, 1)
        ColumnSel = worksheet.Columns(1, 1)
        ColumnSel.SetBorders(darkBlueBorders)
        worksheet.Cells(C1T, C2T).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
        worksheet.Cells(C1T, C2T).SetVerticalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadVerticalAlignment.Center)
        worksheet.Cells(C1T, C2T).Merge()


        C1T = New CellIndex(0, 2)
        C2T = New CellIndex(2, 2)
        ColumnSel = worksheet.Columns(2, 2)
        ColumnSel.SetBorders(darkBlueBorders)
        worksheet.Cells(C1T, C2T).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
        worksheet.Cells(C1T, C2T).SetVerticalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadVerticalAlignment.Center)
        worksheet.Cells(C1T, C2T).Merge()



        C1T = New CellIndex(0, 3)
        C2T = New CellIndex(2, 3)
        ColumnSel = worksheet.Columns(3, 3)
        ColumnSel.SetBorders(darkBlueBorders)
        worksheet.Cells(C1T, C2T).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
        worksheet.Cells(C1T, C2T).SetVerticalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadVerticalAlignment.Center)
        worksheet.Cells(C1T, C2T).Merge()


        C1T = New CellIndex(0, 4)
        C2T = New CellIndex(2, 4)
        ColumnSel = worksheet.Columns(4, 4)
        ColumnSel.SetBorders(darkBlueBorders)
        worksheet.Cells(C1T, C2T).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
        worksheet.Cells(C1T, C2T).SetVerticalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadVerticalAlignment.Center)
        worksheet.Cells(C1T, C2T).Merge()


        C1T = New CellIndex(0, 5)
        C2T = New CellIndex(2, 5)
        ColumnSel = worksheet.Columns(5, 5)
        ColumnSel.SetBorders(darkBlueBorders)
        worksheet.Cells(C1T, C2T).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
        worksheet.Cells(C1T, C2T).SetVerticalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadVerticalAlignment.Center)
        worksheet.Cells(C1T, C2T).Merge()


        Dim colini As Integer = 6
        Dim colfin As Integer = 6


        For i As Integer = weekIni To weekFin
            'Dim dt As Date = DateAdd("ww", i, "01/01/2020")
            Dim weekStart As DateTime = GetWeekStartDate(i, 2020)
            Dim fine As Boolean = False
            Dim culture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture

            Dim Firstday As DateTime = weekStart
            Dim Endaday As DateTime = Firstday.AddDays(6)

            Dim dt As Date = Firstday
            fine = False

            colfin = colini

            '---------- Testata Gantt -------------------------
            While fine = False
                Dim nWeek As Integer = culture.Calendar.GetWeekOfYear(dt, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
                Dim dOfWeek As DayOfWeek = culture.Calendar.GetDayOfWeek(dt)
                Dim giorno As String = culture.DateTimeFormat.GetDayName(dOfWeek)

                If dt > Endaday Then
                    fine = True
                Else
                    worksheet.Cells(currentRow, colfin).SetValue("W" & nWeek & " " & Format(dt, "MMM-yyyy"))
                    worksheet.Cells(currentRow + 1, colfin).SetValue(dt.Day)
                    worksheet.Cells(currentRow + 2, colfin).SetValue(giorno.Substring(0, 3))

                    ColumnSel = worksheet.Columns(colfin, colfin)
                    If giorno.Substring(0, 3) = "dom" Or giorno.Substring(0, 3) = "sab" Then
                        Dim solidPatternFill As PatternFill = PatternFill.CreateSolidFill(ThemableColor.FromArgb(255, 220, 220, 220))
                        ColumnSel.SetFill(solidPatternFill)
                    Else
                        Dim solidPatternStandard As PatternFill = PatternFill.CreateSolidFill(ThemableColor.FromArgb(255, 221, 235, 247))
                        ColumnSel.SetFill(solidPatternStandard)
                    End If
                    ColumnSel.SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)

                    dt = DateAdd("d", 1, dt)
                    colfin = colfin + 1
                End If
            End While
            '----------------------------------------------------

            Dim C1Cell As CellIndex = New CellIndex(currentRow, colini)
            Dim C2Cell As CellIndex = New CellIndex(currentRow, colfin - 1)

            worksheet.Cells(C1Cell, C2Cell).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
            worksheet.Cells(C1Cell, C2Cell).Merge()

            ColumnSel = worksheet.Columns(colini, colfin - 1)
            ColumnSel.AutoFitWidth()
            ColumnSel.SetBorders(darkBlueBorders)

            colini = colfin

        Next

        C1T = New CellIndex(0, 0)
        C2T = New CellIndex(2, colfin - 1)
        worksheet.Cells(C1T, C2T).SetBorders(darkBlueBorders)


        'caricamento delle date da DB
        Dim rigaIniDate As Integer = 3
        Dim ColIniDate As Integer = 6
        Dim arrayDate() As String
        ReDim arrayDate(4)




        'arrayDate(0) = "20/01/2020"
        'arrayDate(1) = "08/02/2020"
        'arrayDate(2) = "07/03/2020"
        'arrayDate(3) = "13/04/2020"

        Dim dataInizioGantt As DateTime = GetWeekStartDate(weekIni, 2020)
        Try

            While reader.Read
                Dim ggDiff As Integer = DateDiff("d", dataInizioGantt, CDate(reader("sdtini")), vbMonday)
                Dim colD As Integer = ColIniDate + ggDiff
                'reader("AISTR").ToString.Trim & " " & reader("AIIND").ToString.Trim
                worksheet.Cells(rigaIniDate, 0).SetValue(reader("AISTR").ToString.Trim & " " & reader("AIIND").ToString.Trim)
                worksheet.Cells(rigaIniDate, 1).SetValue(reader("AIMAT"))
                worksheet.Cells(rigaIniDate, 2).SetValue(reader("DESCCI"))
                worksheet.Cells(rigaIniDate, 3).SetValue(reader("sdtini"))
                worksheet.Cells(rigaIniDate, 4).SetValue(reader("SFLNDI"))

                If reader("SFLNDI") = "N" Then
                    Dim solidPatternStandard As PatternFill = PatternFill.CreateSolidFill(ThemableColor.FromArgb(255, 240, 230, 140))
                    Dim C1Cell As CellIndex = New CellIndex(rigaIniDate, 2)
                    Dim C2Cell As CellIndex = New CellIndex(rigaIniDate, 5)
                    worksheet.Cells(C1Cell, C2Cell).SetFill(solidPatternStandard)
                End If


                If IsDBNull(reader("QDESCR")) = False Then
                    worksheet.Cells(rigaIniDate, 5).SetValue(reader("QDESCR"))
                End If

                worksheet.Cells(rigaIniDate, colD).SetValue(reader("VCDABR"))
                If reader("VCDABR") = "VT" Then
                    Dim solidPatternStandard As PatternFill = PatternFill.CreateSolidFill(ThemableColor.FromArgb(255, 255, 199, 206))
                    worksheet.Cells(rigaIniDate, colD).SetFill(solidPatternStandard)
                    worksheet.Cells(rigaIniDate, colD).SetForeColor(ThemableColor.FromArgb(255, 158, 27, 27))
                End If
                ' & nWeek & " " & Format(dt, "MMM-yyyy")
                rigaIniDate = rigaIniDate + 1
            End While

        Catch ex As Exception

        End Try

        ColumnSel = worksheet.Columns(0, 5)
        ColumnSel.AutoFitWidth()

        reader.Close()
        cmd.Dispose()

        conn.Close()
        conn.Dispose()

        Dim fileName As String = "c:\temp\SampleFile.xlsx"
        Dim formatProvider As IWorkbookFormatProvider = New Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx.XlsxFormatProvider
        Try
            Using output As Stream = New FileStream(fileName, FileMode.Create)
                formatProvider.Export(workbook, output)
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function GetWeekStartDate(weekNumber As Integer, year As Integer) As Date
        Dim startDate As New DateTime(year, 1, 1)
        Dim weekDate As DateTime = DateAdd(DateInterval.WeekOfYear, weekNumber - 1, startDate)
        Return DateAdd(DateInterval.Day, (-weekDate.DayOfWeek) + 1, weekDate)
    End Function

    Private Sub test()
        Dim dateFrom As New DateTime(2020, 1, 1)
        Dim dateTo As New DateTime(2020, 1, 30)
        ' Difference in days, hours, and minutes.
        'NumberOfWeeks(oldDate, newDate)
        Dim Span As TimeSpan = dateTo.Subtract(dateFrom)
        If Span.Days <= 7 Then
            If dateFrom.DayOfWeek > dateTo.DayOfWeek Then

            End If

        End If

        Dim Days As Integer = Span.Days - 7 + CInt(dateFrom.DayOfWeek)
        Dim WeekCount As Integer = 1
        Dim DayCount As Integer = 0
        WeekCount = 1
        While DayCount < Days
            DayCount = DayCount + 7
            WeekCount = WeekCount + 1
        End While
    End Sub

    Private Sub cmdBAnnulla_Click(sender As Object, e As EventArgs) Handles cmdBAnnulla.Click
        salva_dati("ELIMINA")
    End Sub

    'Public Overrides Function GetTimelineBottomElementText(item As GanttViewTimelineDataItem, index As Integer) As String
    '    If item.Range <> TimeRange.[Custom] Then
    '        Return MyBase.GetTimelineBottomElementText(item, index)
    '    End If
    '    Dim format As String = "{0:yyyy}"
    '    Return String.Format(System.Threading.Thread.CurrentThread.CurrentCulture, format, New DateTime(item.Start.Year + index, 1, 1))
    'End Function

End Class
