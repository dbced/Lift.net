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
Imports Telerik.WinControls.UI.Export
Imports Telerik.Windows.Documents.Media

Public Class frmSchedulerManBeta
    Private ws As New webServices
    Dim statoCaricaScheduler As Boolean
    Dim statoCaricaSoc As Boolean
    Dim statoCaricaCentri As Boolean
    Dim statoRicerca As Boolean
    Dim statoExport As Boolean
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

    Private ut As New utility

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

            CommandBarStripE1.OverflowButton.Visibility = ElementVisibility.Hidden
            CmdBarStripLog1.OverflowButton.Visibility = ElementVisibility.Hidden

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
            statoCaricaScheduler = False

            wbG.AssociatedControl = Me
            wbG.StartWaiting()
            wbG.Visible = True

            t1.Enabled = True

            Me.crea_griglia_errori()

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

            If (statoCaricaSoc = True And statoCaricaCentri = True And statoCaricaSquadre = True And statoRicerca = False) OrElse
                (statoRicerca = True And statoCaricaScheduler = True) OrElse statoExport = True Then

                wbG.AssociatedControl = Nothing
                wbG.StopWaiting()
                wbG.Visible = False

                t1.Enabled = False
                statoExport = False
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
            Dim flErrate As String
            Dim flChiuse As String

            codSoc = cmbSoc.SelectedValue
            codCen = cmbCentro.SelectedValue
            codimp = txtImpianto.Text
            codcli = txtCodCliente.Text
            Matricola = txtMatricola.Text.Trim
            dataIni = IIf(IsDate(txtDataDal.Value), txtDataDal.Value, "")
            dataFine = IIf(IsDate(txtDataAl.Value), txtDataAl.Value, "")
            Descrizione = txtDescr.Text.Trim
            IdSquadra = cmbSquadre.SelectedValue
            flErrate = IIf(chkErrate.Checked = True, "S", "")
            flChiuse = IIf(chkEffett.Checked = True, "S", "")

            async_carica_gantt_manutenzioni(codimp, codSoc, codCen, codcli, Matricola, dataIni, dataFine, Descrizione, IdSquadra, flErrate, flChiuse)

            async_carica_griglia_errori("USER", "VISITE")
        Catch ex As Exception
            Telerik.WinControls.RadMessageBox.Show(Me, ex.Message, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Async Sub async_carica_gantt_manutenzioni(codImp As String, codSoc As String, codCen As String, codCli As String,
                                                      Optional Matricola As String = "", Optional DataIni As String = "",
                                                      Optional DataFine As String = "", Optional Descr As String = "",
                                                      Optional IdSquadra As String = "",
                                                      Optional flErrate As String = "", Optional flChiuse As String = "")
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoManutenzioni))
            elementi = ws.getManutenzioniElenco(codImp, codSoc, codCen, codCli, Matricola, DataIni, DataFine, Descr,, IdSquadra,,, flErrate, flChiuse)
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

    Private Async Sub async_carica_griglia_errori(utente As String, tipo As String, Optional dataDa As String = "", Optional dataA As String = "")
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoLogs))
            elementi = ws.getElencoLogVisite(utente, tipo, dataDa, dataA)
            Await elementi

            Me.carica_griglia_errori(elementi.Result)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub carica_griglia_errori(dati As List(Of elencoLogs))
        Try

            gridLog.DataSource = dati
            Me.HeaderText_ColumnGriglia_errori(gridLog)
            Me.HeaderText_ColumnGriglia_width()
            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)

        End Try

    End Sub

    Private Sub HeaderText_ColumnGriglia_errori(griglia As RadGridView)
        Try
            griglia.Columns("DataLog").HeaderText = "Data Log"
            griglia.Columns("DescrLog").HeaderText = "Descrizione anomalia"
            griglia.Columns("LivelloLog").HeaderText = "Liv"

            griglia.Columns("DataLog").TextAlignment = ContentAlignment.MiddleCenter
            griglia.Columns("LivelloLog").TextAlignment = ContentAlignment.MiddleCenter

            griglia.Columns("LivelloLog").IsVisible = True
            griglia.Columns("UtenteLog").IsVisible = False
            griglia.Columns("TipoLog").IsVisible = False
            griglia.Columns("idLog").IsVisible = False

            For i = 0 To griglia.Columns.Count - 1
                griglia.Columns(i).ReadOnly = True
            Next

            griglia.Columns("DataLog").FormatString = "{0:dd/MM/yyyy}"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Errore")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia_width()
        Try
            'Me.gridLog.Columns("DescrLog").Width = 800
            '
            Me.gridLog.Columns("img").Width = 30
            Me.gridLog.Columns("img").MinWidth = 30
            Me.gridLog.Columns("img").MaxWidth = 30
            Me.gridLog.Columns("dataLog").Width = 80
            Me.gridLog.Columns("LivelloLog").Width = 30
            Me.gridLog.Columns("descrLog").Width = 1000

            'Me.gridLog.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub crea_griglia_errori()
        Try

            Me.gridLog.BeginEdit()
            Me.gridLog.EnableFiltering = True
            Me.gridLog.MasterTemplate.ShowHeaderCellButtons = True
            Me.gridLog.MasterTemplate.ShowFilteringRow = False
            Me.gridLog.AllowAddNewRow = False
            Me.gridLog.AutoGenerateColumns = False
            Me.gridLog.EnableGrouping = False

            Dim commandColumn As New GridViewTextBoxColumn
            commandColumn.Name = "Mod"
            commandColumn.DataType = GetType(String)
            commandColumn.HeaderText = "Mod"
            commandColumn.ReadOnly = True
            commandColumn.Width = 50
            commandColumn.IsPinned = True
            ''----------------------------------------------------------------

            Dim colImg As New GridViewImageColumn
            colImg.Name = "img"
            colImg.DataType = GetType(System.Drawing.Image)
            colImg.IsPinned = True

            Dim colIdLog As New GridViewDecimalColumn
            colIdLog.Name = "idLog"
            colIdLog.DataType = GetType(Integer)
            colIdLog.FieldName = "idLog"

            Dim colUtente As New GridViewTextBoxColumn
            colUtente.Name = "UtenteLog"
            colUtente.DataType = GetType(String)
            colUtente.FieldName = "UtenteLog"

            Dim colDataLog As New GridViewDateTimeColumn
            colDataLog.Name = "DataLog"
            colDataLog.DataType = GetType(Date)
            colDataLog.FieldName = "DataLog"

            Dim coldESCR As New GridViewTextBoxColumn
            coldESCR.Name = "descrLog"
            coldESCR.DataType = GetType(String)
            coldESCR.FieldName = "descrLog"

            Dim colTipo As New GridViewTextBoxColumn
            colTipo.Name = "tipoLog"
            colTipo.DataType = GetType(String)
            colTipo.FieldName = "tipoLog"

            Dim colLivello As New GridViewDecimalColumn
            colLivello.Name = "LivelloLog"
            colLivello.DataType = GetType(Integer)
            colLivello.FieldName = "LivelloLog"

            'gridlog.MasterTemplate.Columns.Add(commandColumn)
            gridLog.MasterTemplate.Columns.Add(colImg)
            gridLog.MasterTemplate.Columns.Add(colIdLog)
            gridLog.MasterTemplate.Columns.Add(colLivello)
            gridLog.MasterTemplate.Columns.Add(colUtente)
            gridLog.MasterTemplate.Columns.Add(colDataLog)
            gridLog.MasterTemplate.Columns.Add(coldESCR)
            gridLog.MasterTemplate.Columns.Add(colTipo)


            gridLog.Columns("LivelloLog").IsVisible = True
            gridLog.Columns("UtenteLog").IsVisible = False
            gridLog.Columns("TipoLog").IsVisible = False
            gridLog.Columns("idLog").IsVisible = False


            gridLog.TableElement.SearchHighlightColor = Color.LimeGreen

            'Me.gridlog.Columns("Check").AllowFiltering = False
            'Me.gridlog.Columns("Mod").AllowFiltering = False


            Me.gridLog.EndEdit()

            gridLog.AllowSearchRow = True
            'gridlog.MasterView.SummaryRows(0).PinPosition = PinnedRowPosition.Bottom

            'Me.HeaderText_ColumnFatture()
            'Me.HeaderText_Column_Fatture_width()



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub gridLog_ContextMenuOpening(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.ContextMenuOpeningEventArgs) Handles gridLog.ContextMenuOpening
        e.Cancel = True
    End Sub

    Private Sub gridLog_CellFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles gridLog.CellFormatting
        Try
            If e.CellElement.ColumnInfo.Name.ToUpper = "IMG" Then

                If Not IsNothing(e.CellElement.RowInfo.Cells("LivelloLog").Value) Then
                    Select Case e.CellElement.RowInfo.Cells("LivelloLog").Value.ToString

                        Case Is = "1"
                            e.CellElement.ForeColor = e.CellElement.BackColor
                            e.CellElement.Image = My.Resources.info

                            e.CellElement.ImageAlignment = ContentAlignment.MiddleCenter
                            e.CellElement.TextImageRelation = TextImageRelation.ImageBeforeText

                        Case Is = "2"
                            e.CellElement.ForeColor = e.CellElement.BackColor
                            e.CellElement.Image = My.Resources.alert

                            e.CellElement.ImageAlignment = ContentAlignment.MiddleCenter
                            e.CellElement.TextImageRelation = TextImageRelation.ImageBeforeText

                        Case Is = "3"
                            e.CellElement.ForeColor = e.CellElement.BackColor
                            e.CellElement.Image = My.Resources._error

                            e.CellElement.ImageAlignment = ContentAlignment.MiddleCenter
                            e.CellElement.TextImageRelation = TextImageRelation.ImageBeforeText

                        Case Else
                            e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                            e.CellElement.Image = Nothing
                    End Select

                Else
                    e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                    e.CellElement.Image = Nothing
                End If

            Else
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                e.CellElement.Image = Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub gridLog_ViewRowFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.RowFormattingEventArgs) Handles gridLog.ViewRowFormatting

        Try
            If TypeOf e.RowElement Is GridSummaryRowElement Then
                If e.RowElement.RowInfo.Group Is Nothing Then
                    e.RowElement.RowInfo.PinPosition = PinnedRowPosition.Bottom
                Else
                    e.RowElement.RowInfo.PinPosition = PinnedRowPosition.None
                End If
                e.RowElement.RowInfo.Height = 30
            ElseIf TypeOf e.RowElement Is GridDataRowElement Then
                e.RowElement.RowInfo.Height = 30
            ElseIf TypeOf e.RowElement Is GridTableHeaderRowElement Then
                e.RowElement.RowInfo.Height = 45
            Else
                e.RowElement.RowInfo.Height = 30
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
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
                Dim StatoVis As String = e.Item(Me.gant.Columns.Item(15)).ToString
                Dim codimp As String = e.Item(Me.gant.Columns.Item(1)).ToString
                If codimp = "1009039" Then
                    Debug.Print("ok")
                End If
                If StatoVis.Contains("2") OrElse StatoVis.Contains("3") Then
                    e.ItemElement.DrawFill = True
                    If StatoVis.Contains("2") Then
                        'e.ItemElement.BackColor = Color.FromArgb(245, 212, 144)
                        e.ItemElement.ForeColor = Color.FromArgb(197, 45, 45)
                        e.ItemElement.Font = New Font(e.ItemElement.Font, FontStyle.Bold)
                    ElseIf StatoVis.Contains("3") Then
                        'e.ItemElement.BackColor = Color.FromArgb(220, 151, 157)
                        e.ItemElement.ForeColor = Color.FromArgb(197, 45, 45)
                        e.ItemElement.Font = New Font(e.ItemElement.Font, FontStyle.Bold)
                    Else
                        e.ItemElement.ResetValue(LightVisualElement.DrawBorderProperty, ValueResetFlags.Local)
                        e.ItemElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                        e.ItemElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local)
                        e.ItemElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                        e.ItemElement.ResetValue(LightVisualElement.FontProperty, ValueResetFlags.Local)
                    End If

                    e.ItemElement.GradientStyle = GradientStyles.Solid

                ElseIf StatoVis.Contains("R") Then
                    e.ItemElement.DrawFill = True
                    e.ItemElement.BackColor = Color.FromArgb(173, 216, 230)
                    e.ItemElement.GradientStyle = GradientStyles.Solid
                    e.ItemElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                    e.ItemElement.ResetValue(LightVisualElement.FontProperty, ValueResetFlags.Local)
                Else
                    e.ItemElement.ResetValue(LightVisualElement.DrawBorderProperty, ValueResetFlags.Local)
                    e.ItemElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                    e.ItemElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local)
                    e.ItemElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                    e.ItemElement.ResetValue(LightVisualElement.FontProperty, ValueResetFlags.Local)
                End If

                If valore.Contains("N") And Not StatoVis.Contains("R") Then
                    e.ItemElement.DrawFill = True
                    e.ItemElement.BackColor = Color.FromArgb(238, 232, 170)
                    e.ItemElement.GradientStyle = GradientStyles.Solid

                    If Not StatoVis.Contains("2") AndAlso Not StatoVis.Contains("3") Then
                        e.ItemElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                        e.ItemElement.ResetValue(LightVisualElement.FontProperty, ValueResetFlags.Local)
                    End If

                Else
                    e.ItemElement.ResetValue(LightVisualElement.DrawBorderProperty, ValueResetFlags.Local)
                    e.ItemElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                    e.ItemElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local)
                    If Not StatoVis.Contains("2") AndAlso Not StatoVis.Contains("3") Then
                        e.ItemElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                        e.ItemElement.ResetValue(LightVisualElement.FontProperty, ValueResetFlags.Local)
                    End If
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
            Dim valore As String = ""
            Dim Errore As String = ""

            For Each col In Me.gant.Columns
                Dim gItem As New GanttViewDataItem
                gItem = DirectCast(e.Item, GanttViewDataItem)

                If Not IsNothing(gItem(col)) Then
                    Select Case (col.Name.ToUpper)
                        Case "DTEFFETT"
                            valore = gItem(col).ToString
                            If valore.Contains("01/01/0001") Then
                                valore = ""
                            End If
                        Case "FLAGSTATO"
                            Errore = gItem(col).ToString

                    End Select

                End If
            Next

            'If (e.Item.Title.StartsWith("Select")) Then

            If (IsDate(valore)) Then
                e.ItemElement.TaskElement.BackColor = Color.FromArgb(154, 205, 50)
            ElseIf e.Item.Tag = "VT" Then
                e.ItemElement.TaskElement.BackColor = Color.FromArgb(255, 99, 71)
            Else
                e.ItemElement.TaskElement.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local)
            End If

            If Errore.Contains("1") OrElse Errore.Contains("2") OrElse Errore.Contains("3") Then
                e.ItemElement.TaskElement.ForeColor = Color.FromArgb(197, 45, 45)
                e.ItemElement.TaskElement.Font = New Font(e.ItemElement.TaskElement.Font, FontStyle.Bold)
            Else
                e.ItemElement.TaskElement.ResetValue(LightVisualElement.ForeColorProperty, Telerik.WinControls.ValueResetFlags.Local)
                e.ItemElement.TaskElement.ResetValue(LightVisualElement.FontProperty, Telerik.WinControls.ValueResetFlags.Local)
            End If

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

            Dim timelineElement = TryCast(e.ItemElement, GanttViewTimelineItemElement)
            If timelineElement IsNot Nothing Then
                ' set custom text
                'timelineElement.TopElement.Text = "Week #1, Month-2020"
                'GetWeekStartDate
                Try
                    Dim sDate() As String = timelineElement.TopElement.Text.Split(",")
                    sDate(0) = sDate(0).Replace("Week#", "")
                    Dim wk As Integer = Val(sDate(0))
                    Dim anno As Integer = Val(sDate(1))
                    Dim newDate As Date = GetWeekStartDate(wk, anno)
                    Dim Month_name = MonthName(Month(newDate), False).ToUpper
                    timelineElement.TopElement.Text = "W" & wk.ToString & " - " & Month_name & " - " & anno.ToString
                Catch ex As Exception
                    timelineElement.TopElement.ResetValue(LightVisualElement.TextProperty, Telerik.WinControls.ValueResetFlags.Local)
                End Try
            Else
                timelineElement.TopElement.ResetValue(LightVisualElement.TextProperty, Telerik.WinControls.ValueResetFlags.Local)
            End If

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
                    Dim festa As Boolean = ut.verifica_giorno_di_festa(tlDate.ToString)
                    If nome.Substring(0, 3) = "dom" Or nome.Substring(0, 3) = "sab" Or festa = True Then
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
            Dim startTimeColumn As New GanttViewTextViewColumn("Ora")
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
            Dim DescStato As New GanttViewTextViewColumn("DescStato")
            Dim EndTimeColumn As New GanttViewTextViewColumn("OraFine")

            CodiceColumn.HeaderText = "Cod. Imp."
            DesColumn.HeaderText = "Tipo Visita"
            titleColumn.HeaderText = "Impianto"
            startColumn.HeaderText = "Data Inizio"
            startTimeColumn.HeaderText = "Ora"
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
            DescStato.HeaderText = "Stato"
            EndTimeColumn.HeaderText = "Ora fine"

            Me.gant.GanttViewElement.Columns.Add(titleColumn)
            Me.gant.GanttViewElement.Columns.Add(CodiceColumn)
            Me.gant.GanttViewElement.Columns.Add(DesColumn)
            Me.gant.GanttViewElement.Columns.Add(TipoImpiantoCol)
            Me.gant.GanttViewElement.Columns.Add(flagDiurno)
            Me.gant.GanttViewElement.Columns.Add(startColumn)
            Me.gant.GanttViewElement.Columns.Add(startTimeColumn)
            Me.gant.GanttViewElement.Columns.Add(endColumn)
            Me.gant.GanttViewElement.Columns.Add(EndTimeColumn)
            Me.gant.GanttViewElement.Columns.Add(dtEffetCol)
            Me.gant.GanttViewElement.Columns.Add(Squadra)

            Me.gant.GanttViewElement.Columns.Add(IDCol)
            Me.gant.GanttViewElement.Columns.Add(CdSocCol)
            Me.gant.GanttViewElement.Columns.Add(CentroCol)
            Me.gant.GanttViewElement.Columns.Add(NoteCol)
            Me.gant.GanttViewElement.Columns.Add(flagStato)
            Me.gant.GanttViewElement.Columns.Add(DescStato)


            'Me.gant.GanttViewElement.Columns.Add(nrBollCol)
            'Me.gant.GanttViewElement.Columns.Add(aaBollCol)
            'Me.gant.GanttViewElement.Columns.Add(firmaCol)
            'Me.gant.GanttViewElement.Columns.Add(NoteCol)

            gant.Columns("Start").FormatString = "{0:dd/MM/yyyy}" ' "{0:dd/MM/yyyy HH:mm}"
            gant.Columns("End").FormatString = "{0:dd/MM/yyyy}"
            gant.Columns("DtEffett").FormatString = "{0:dd/MM/yyyy}"
            gant.Columns("Ora").FormatString = "{0:HH:mm}"

            gant.Columns("CodImpianto").Width = 80
            gant.Columns("DesImpianto").Width = 100
            gant.Columns("tipoImpianto").Width = 100
            gant.Columns("Title").Width = 280
            gant.Columns("End").Width = 100
            gant.Columns("Start").Width = 100
            gant.Columns("Ora").Width = 60
            gant.Columns("OraFine").Width = 80
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
            gant.Columns("DescStato").Visible = False

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

            Me.lblRecords.Text = "Visite trovate: " & dati.Count

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
                itemVis.Ora = Format(CDate(dati(i).dataInizioTS), "HH:mm")
                itemVis.OraFine = Format(CDate(dati(i).dataFineTS), "HH:mm")
                itemVis.DescStato = dati(i).DescStatoVisita
                'Me.gant.Items.Add(itemGruppo)

                itemGruppo.Items.Add(itemVis)
                id = id + 1
            Next

            'If appTipoVis <> tipoVis Then
            Me.gant.Items.Add(itemGruppo)

            If Me.gant.Items.Count > 0 Then
                If Me.gant.Items(0).Items.Count > 0 Then
                    Me.gant.Items(0).Items.Item(0).Selected = True
                End If
            End If

            'End If

            Me.gant.Ratio = 0.55
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

            statoRicerca = True
            statoCaricaScheduler = False
            wbG.AssociatedControl = Me
            wbG.StartWaiting()
            wbG.Visible = True

            t1.Enabled = True

            Me.carica_dati_form()

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
            parms.dataEffett = varDataEff


            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

            Dim postContent = jss.Serialize(parms)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = My.Settings.urlWS & "api/visite/saveVisitaBeta1/postSaveVisitaBeta1"
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

    Private Async Sub start_generaVisite(anno As String, mese As String)
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")
        Dim client As New Http.HttpClient

        Try

            Dim dr As DialogResult = RadMessageBox.Show("Generare le visite?" & vbCrLf & "Attenzione, i dati che non hanno subito variazioni andranno persi.", "Generazione visite", MessageBoxButtons.YesNo, RadMessageIcon.Question)
            If dr = DialogResult.No Then
                Exit Sub
            Else
                wbG.AssociatedControl = Me
                wbG.StartWaiting()
                wbG.Visible = True

                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

                Dim parms As New elencoManutenzioni

                parms.id = Val(varID)


                Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

                Dim postContent = "" 'jss.Serialize(parms)

                Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

                Dim postUrl = My.Settings.urlWS & "api/visite/generaVisite/generaVisite"
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Add("parmAnno", anno)
                client.DefaultRequestHeaders.Add("parmMese", mese)

                Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)

                wbG.StopWaiting()
                wbG.AssociatedControl = Nothing
                wbG.Visible = False

                Dim sStatusCode As String = postResponse.StatusCode.ToString

                If sStatusCode.ToUpper <> "OK" Then
                    Dim msg As String = postResponse.Headers.GetValues("Error").FirstOrDefault()

                    Telerik.WinControls.RadMessageBox.Show(Me, "Operazione non effettuata. " & vbCrLf & "Causa: " & msg, "Genera visite", MessageBoxButtons.OK, RadMessageIcon.Error)
                Else
                    Telerik.WinControls.RadMessageBox.Show(Me, "Operazione effettuata", "Genera visite", MessageBoxButtons.OK, RadMessageIcon.Info)

                    statoRicerca = True
                    statoCaricaScheduler = False
                    wbG.AssociatedControl = Me
                    wbG.StartWaiting()
                    wbG.Visible = True

                    t1.Enabled = True

                    Me.carica_dati_form()
                End If

            End If

        Catch EX As Exception
            wbG.StopWaiting()
            wbG.AssociatedControl = Nothing
            wbG.Visible = False
            Telerik.WinControls.RadMessageBox.Show(Me, "Errore", "Errore", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try


    End Sub

    Private Async Sub start_generaLogVisite()
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")
        Dim client As New Http.HttpClient

        Try

            Dim dr As DialogResult = RadMessageBox.Show("Generare il log delle visite?", "Generazione log visite", MessageBoxButtons.YesNo, RadMessageIcon.Question)
            If dr = DialogResult.No Then
                Exit Sub
            Else
                wbG.AssociatedControl = Me
                wbG.StartWaiting()
                wbG.Visible = True

                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

                Dim parms As New elencoManutenzioni

                Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

                Dim postContent = "" 'jss.Serialize(parms)

                Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

                Dim postUrl = My.Settings.urlWS & "api/visite/generaLogVisite/generaLogVisite"
                client.DefaultRequestHeaders.Accept.Clear()

                Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)

                wbG.StopWaiting()
                wbG.AssociatedControl = Nothing
                wbG.Visible = False

                Dim sStatusCode As String = postResponse.StatusCode.ToString

                If sStatusCode.ToUpper <> "OK" Then
                    Dim msg As String = postResponse.Headers.GetValues("Error").FirstOrDefault()

                    Telerik.WinControls.RadMessageBox.Show(Me, "Operazione non effettuata. " & vbCrLf & "Causa: " & msg, "Genera Log visite", MessageBoxButtons.OK, RadMessageIcon.Error)
                Else
                    Telerik.WinControls.RadMessageBox.Show(Me, "Operazione effettuata", "Genera Log visite", MessageBoxButtons.OK, RadMessageIcon.Info)

                    statoRicerca = True
                    statoCaricaScheduler = False
                    wbG.AssociatedControl = Me
                    wbG.StartWaiting()
                    wbG.Visible = True

                    t1.Enabled = True

                    Me.carica_dati_form()
                    pnlLog.IsExpanded = True

                End If

            End If

        Catch EX As Exception
            wbG.StopWaiting()
            wbG.AssociatedControl = Nothing
            wbG.Visible = False
            Telerik.WinControls.RadMessageBox.Show(Me, EX.Message, "Errore", MessageBoxButtons.OK, RadMessageIcon.Error)
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
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            Dim anno As String = Now.Year.ToString
            Dim mese As String = Now.Month  'DateAndTime.MonthName(Now.Month).ToString.ToUpper
            Dim nSett As String
            Dim visiteChiuse As Boolean


            Dim frm As New FrmExpGantt(anno, mese, "ESPORTA")
            frm.ShowDialog()

            If frm.sAnno <> "" And frm.sMese <> "" Then
                anno = frm.sAnno
                mese = frm.sMese
                nSett = frm.sSett

                visiteChiuse = frm.visiteChiuse

                statoExport = False

                wbG.AssociatedControl = Me
                wbG.StartWaiting()
                wbG.Visible = True
                t1.Enabled = True

                Me.esporta_gantt(anno, mese, visiteChiuse, Val(nSett))
                statoExport = True
                Telerik.WinControls.RadMessageBox.Show(Me, "Operazione effettuata", "Export visite", MessageBoxButtons.OK, RadMessageIcon.Info)
            Else
                Telerik.WinControls.RadMessageBox.Show(Me, "Dati non validi per l'esportazione", "Export visite", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If

        Catch ex As Exception
            Telerik.WinControls.RadMessageBox.Show(Me, ex.Message, "Export visite", MessageBoxButtons.OK, RadMessageIcon.Error)
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


    Private Sub esporta_gantt(anno As String, mese As String, Optional visiteChiuse As Boolean = False, Optional nSettimana As Integer = 0)
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

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
        sSql = sSql & "from " & My.Settings.LibLift & ".animpman "
        sSql = sSql & "where scdsoc = 'MT' and scdcen = 'E14' and year(sdtini) = " & anno & " and month (sdtini) = " & mese
        If nSettimana <> 0 Then
            sSql = sSql & " and week_iso(sdtini) = " & nSettimana
        End If

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
        sSql = sSql & "SNRBOLL, SAABOLL, SFLFIRMA, SFLMANU, SFLSCAM, SDTBOLL, SDTGEN, STSINI, STSFIN, "
        sSql = sSql & "SDTMAN, SDTCHI, SDTUPD, SUTECHI, VDESCR, SUBSTR(CCI.XDTAB, 1, 25) AS DESCCI, SUBSTR(IFF.XDTAB, 1, 25) AS DESINF,  STSINI, STSFIN, STSEFF, SNOTE, VCDABR, "
        sSql = sSql & "SIDSQU, SFLNDI, SQU.QDESCR "
        sSql = sSql & "FROM " & My.Settings.LibLift & ".ANIMPMAN LEFT JOIN LIFT_NET.TBTIPIMAN ON STPMAN = VCDMAN "
        sSql = sSql & "LEFT JOIN " & My.Settings.LibLift & ".ANIMP00F ON AICIM = SCDIMP "
        sSql = sSql & "LEFT JOIN LIFT_DAT.TABEL00F CCI ON CCI.XCDEL = AICCI And CCI.XCDTB = 'CCI' "
        sSql = sSql & "LEFT JOIN LIFT_DAT.TABEL00F IFF ON IFF.XCDEL = CDINF And IFF.XCDTB = 'INF' "
        sSql = sSql & "LEFT JOIN " & My.Settings.LibLift & ".TBSQUADRE SQU ON SQU.QID= SIDSQU "
        sSql = sSql & "where scdsoc = 'MT' and scdcen = 'E14' and year(sdtini) = " & anno & " and month (sdtini) = " & mese

        If nSettimana <> 0 Then
            sSql = sSql & " and week_iso(sdtini) = " & nSettimana
        End If

        If visiteChiuse = False Then
            sSql = sSql & " and year(sdteff) = 1 "
        End If
        sSql = sSql & " order by sdtini "

        cmd.CommandText = sSql
        reader = cmd.ExecuteReader

        If reader.HasRows = False Then
            Telerik.WinControls.RadMessageBox.Show(Me, "Nessuna visita trovata", "Export visite", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
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
        worksheet.Cells(0, 2).SetValue("LINEA")
        worksheet.Cells(0, 3).SetValue("TIPO IMPIANTO")
        worksheet.Cells(0, 4).SetValue("TIPO VISITA")
        worksheet.Cells(0, 5).SetValue("DATA")
        worksheet.Cells(0, 6).SetValue("ORA")
        worksheet.Cells(0, 7).SetValue("D/N")
        worksheet.Cells(0, 8).SetValue("SQUADRA")

        Dim ColumnSel As ColumnSelection


        For Col As Integer = 0 To 8
            Dim C1T As CellIndex = New CellIndex(0, Col)
            Dim C2T As CellIndex = New CellIndex(2, Col)
            ColumnSel = worksheet.Columns(Col, Col)
            ColumnSel.SetBorders(darkBlueBorders)
            worksheet.Cells(C1T, C2T).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
            worksheet.Cells(C1T, C2T).SetVerticalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadVerticalAlignment.Center)
            worksheet.Cells(C1T, C2T).Merge()
            worksheet.Cells(0, Col).SetFontSize(Unit.PointToDip(14))
        Next Col

        'Dim C1T As CellIndex = New CellIndex(0, 0)
        'Dim C2T As CellIndex = New CellIndex(2, 0)
        'ColumnSel = worksheet.Columns(0, 0)
        'ColumnSel.SetBorders(darkBlueBorders)
        'worksheet.Cells(C1T, C2T).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
        'worksheet.Cells(C1T, C2T).SetVerticalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadVerticalAlignment.Center)
        'worksheet.Cells(C1T, C2T).Merge()


        'C1T = New CellIndex(0, 1)
        'C2T = New CellIndex(2, 1)
        'ColumnSel = worksheet.Columns(1, 1)
        'ColumnSel.SetBorders(darkBlueBorders)
        'worksheet.Cells(C1T, C2T).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
        'worksheet.Cells(C1T, C2T).SetVerticalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadVerticalAlignment.Center)
        'worksheet.Cells(C1T, C2T).Merge()


        'C1T = New CellIndex(0, 2)
        'C2T = New CellIndex(2, 2)
        'ColumnSel = worksheet.Columns(2, 2)
        'ColumnSel.SetBorders(darkBlueBorders)
        'worksheet.Cells(C1T, C2T).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
        'worksheet.Cells(C1T, C2T).SetVerticalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadVerticalAlignment.Center)
        'worksheet.Cells(C1T, C2T).Merge()



        'C1T = New CellIndex(0, 3)
        'C2T = New CellIndex(2, 3)
        'ColumnSel = worksheet.Columns(3, 3)
        'ColumnSel.SetBorders(darkBlueBorders)
        'worksheet.Cells(C1T, C2T).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
        'worksheet.Cells(C1T, C2T).SetVerticalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadVerticalAlignment.Center)
        'worksheet.Cells(C1T, C2T).Merge()


        'C1T = New CellIndex(0, 4)
        'C2T = New CellIndex(2, 4)
        'ColumnSel = worksheet.Columns(4, 4)
        'ColumnSel.SetBorders(darkBlueBorders)
        'worksheet.Cells(C1T, C2T).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
        'worksheet.Cells(C1T, C2T).SetVerticalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadVerticalAlignment.Center)
        'worksheet.Cells(C1T, C2T).Merge()


        'C1T = New CellIndex(0, 5)
        'C2T = New CellIndex(2, 5)
        'ColumnSel = worksheet.Columns(5, 5)
        'ColumnSel.SetBorders(darkBlueBorders)
        'worksheet.Cells(C1T, C2T).SetHorizontalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadHorizontalAlignment.Center)
        'worksheet.Cells(C1T, C2T).SetVerticalAlignment(Telerik.Windows.Documents.Spreadsheet.Model.RadVerticalAlignment.Center)
        'worksheet.Cells(C1T, C2T).Merge()


        Dim colini As Integer = 9
        Dim colfin As Integer = 9


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

                Dim festa As Boolean = ut.verifica_giorno_di_festa(dt.ToString)

                If dt > Endaday Then
                    fine = True
                Else
                    worksheet.Cells(currentRow, colfin).SetValue("W" & nWeek & " " & Format(dt, "MMM-yyyy"))
                    worksheet.Cells(currentRow, colfin).SetFontSize(Unit.PointToDip(14))
                    worksheet.Cells(currentRow + 1, colfin).SetValue(dt.Day)
                    worksheet.Cells(currentRow + 1, colfin).SetFontSize(Unit.PointToDip(14))
                    worksheet.Cells(currentRow + 2, colfin).SetValue(giorno.Substring(0, 3))
                    worksheet.Cells(currentRow + 2, colfin).SetFontSize(Unit.PointToDip(14))

                    ColumnSel = worksheet.Columns(colfin, colfin)
                    If giorno.Substring(0, 3) = "dom" Or giorno.Substring(0, 3) = "sab" Or festa = True Then
                        Dim solidPatternFill As PatternFill = PatternFill.CreateSolidFill(ThemableColor.FromArgb(255, 255, 116, 117))
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

        Dim C1 As CellIndex = New CellIndex(0, 0)
        Dim C2 As CellIndex = New CellIndex(2, colfin - 1)
        worksheet.Cells(C1, C2).SetBorders(darkBlueBorders)

        'caricamento delle date da DB
        Dim rigaIniDate As Integer = 3
        Dim ColIniDate As Integer = 9
        Dim arrayDate() As String
        ReDim arrayDate(4)

        Dim dataInizioGantt As DateTime = GetWeekStartDate(weekIni, Val(anno))
        Try

            While reader.Read
                Dim ggDiff As Integer = DateDiff("d", dataInizioGantt, CDate(reader("sdtini")), vbMonday)
                Dim colD As Integer = ColIniDate + ggDiff
                'reader("AISTR").ToString.Trim & " " & reader("AIIND").ToString.Trim
                worksheet.Cells(rigaIniDate, 0).SetValue(reader("AISTR").ToString.Trim & " " & reader("AIIND").ToString.Trim)
                worksheet.Cells(rigaIniDate, 1).SetValue(reader("AIMAT"))
                worksheet.Cells(rigaIniDate, 3).SetValue(reader("DESCCI"))
                worksheet.Cells(rigaIniDate, 4).SetValue(reader("VDESCR"))
                worksheet.Cells(rigaIniDate, 5).SetValue(reader("sdtini"))
                Dim ora As String = reader("STSINI").ToString.Substring(11, 5)
                ora = ora.Replace(".", ":")
                worksheet.Cells(rigaIniDate, 6).SetValue(ora)
                worksheet.Cells(rigaIniDate, 7).SetValue(reader("SFLNDI"))

                worksheet.Cells(rigaIniDate, 0).SetFontSize(Unit.PointToDip(14))
                worksheet.Cells(rigaIniDate, 1).SetFontSize(Unit.PointToDip(14))
                worksheet.Cells(rigaIniDate, 3).SetFontSize(Unit.PointToDip(14))
                worksheet.Cells(rigaIniDate, 4).SetFontSize(Unit.PointToDip(14))
                worksheet.Cells(rigaIniDate, 5).SetFontSize(Unit.PointToDip(14))
                worksheet.Cells(rigaIniDate, 6).SetFontSize(Unit.PointToDip(14))
                worksheet.Cells(rigaIniDate, 7).SetFontSize(Unit.PointToDip(14))

                If reader("SFLNDI") = "N" Then
                    Dim solidPatternStandard As PatternFill = PatternFill.CreateSolidFill(ThemableColor.FromArgb(255, 240, 230, 140))
                    Dim C1Cell As CellIndex = New CellIndex(rigaIniDate, 2)
                    Dim C2Cell As CellIndex = New CellIndex(rigaIniDate, 5)
                    worksheet.Cells(C1Cell, C2Cell).SetFill(solidPatternStandard)
                End If

                If IsDBNull(reader("QDESCR")) = False Then
                    worksheet.Cells(rigaIniDate, 8).SetValue(reader("QDESCR"))
                    'Dim FontF As New ThemableFontFamily("Jokerman")
                    'worksheet.Cells(rigaIniDate, 0).SetFontFamily(FontF)
                    worksheet.Cells(rigaIniDate, 8).SetFontSize(Unit.PointToDip(14))
                End If

                If IsDBNull(reader("DESINF")) = False Then
                    worksheet.Cells(rigaIniDate, 2).SetValue(reader("DESINF"))
                    worksheet.Cells(rigaIniDate, 2).SetFontSize(Unit.PointToDip(14))
                End If

                worksheet.Cells(rigaIniDate, colD).SetValue(reader("VCDABR"))
                worksheet.Cells(rigaIniDate, colD).SetFontSize(Unit.PointToDip(14))

                If Year(CDate(reader("sdteff"))) <> 1 Then
                    Dim solidPatternStandard As PatternFill = PatternFill.CreateSolidFill(ThemableColor.FromArgb(255, 50, 205, 50))
                    worksheet.Cells(rigaIniDate, colD).SetFill(solidPatternStandard)
                    worksheet.Cells(rigaIniDate, colD).SetForeColor(ThemableColor.FromArgb(255, 0, 0, 0))


                Else
                    If reader("VCDABR") = "VT" Then
                        Dim solidPatternStandard As PatternFill = PatternFill.CreateSolidFill(ThemableColor.FromArgb(255, 255, 199, 206))
                        worksheet.Cells(rigaIniDate, colD).SetFill(solidPatternStandard)
                        worksheet.Cells(rigaIniDate, colD).SetForeColor(ThemableColor.FromArgb(255, 158, 27, 27))
                    End If
                End If

                ' & nWeek & " " & Format(dt, "MMM-yyyy")
                rigaIniDate = rigaIniDate + 1
            End While

        Catch ex As Exception

        End Try

        ColumnSel = worksheet.Columns(0, 50)
        ColumnSel.AutoFitWidth()

        Dim pixelWidthToExcelWidth As Double = UnitHelper.PixelWidthToExcelColumnWidth(workbook, 3200)
        Dim newColumnWidth As New ColumnWidth(pixelWidthToExcelWidth, True)
        worksheet.Columns(0).SetWidth(newColumnWidth)

        pixelWidthToExcelWidth = UnitHelper.PixelWidthToExcelColumnWidth(workbook, 900)
        Dim newColumnWidth1 As New ColumnWidth(pixelWidthToExcelWidth, True)
        worksheet.Columns(1).SetWidth(newColumnWidth1)

        pixelWidthToExcelWidth = UnitHelper.PixelWidthToExcelColumnWidth(workbook, 700)
        Dim newColumnWidth2 As New ColumnWidth(pixelWidthToExcelWidth, True)
        worksheet.Columns(2).SetWidth(newColumnWidth2)

        pixelWidthToExcelWidth = UnitHelper.PixelWidthToExcelColumnWidth(workbook, 1400)
        Dim newColumnWidth3 As New ColumnWidth(pixelWidthToExcelWidth, True)
        worksheet.Columns(3).SetWidth(newColumnWidth3)

        pixelWidthToExcelWidth = UnitHelper.PixelWidthToExcelColumnWidth(workbook, 1400)
        Dim newColumnWidth4 As New ColumnWidth(pixelWidthToExcelWidth, True)
        worksheet.Columns(4).SetWidth(newColumnWidth4)

        pixelWidthToExcelWidth = UnitHelper.PixelWidthToExcelColumnWidth(workbook, 900)
        Dim newColumnWidth5 As New ColumnWidth(pixelWidthToExcelWidth, True)
        worksheet.Columns(5).SetWidth(newColumnWidth5)

        pixelWidthToExcelWidth = UnitHelper.PixelWidthToExcelColumnWidth(workbook, 600)
        Dim newColumnWidth6 As New ColumnWidth(pixelWidthToExcelWidth, True)
        worksheet.Columns(6).SetWidth(newColumnWidth6)

        pixelWidthToExcelWidth = UnitHelper.PixelWidthToExcelColumnWidth(workbook, 500)
        Dim newColumnWidth7 As New ColumnWidth(pixelWidthToExcelWidth, True)
        worksheet.Columns(7).SetWidth(newColumnWidth7)

        pixelWidthToExcelWidth = UnitHelper.PixelWidthToExcelColumnWidth(workbook, 1700)
        Dim newColumnWidth8 As New ColumnWidth(pixelWidthToExcelWidth, True)
        worksheet.Columns(8).SetWidth(newColumnWidth8)

        reader.Close()
        cmd.Dispose()

        conn.Close()
        conn.Dispose()

        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "File Excel (*.xlsx)|*.xlsx|Excel 2010 (*.xlsx)|*.xlsx"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            Dim formatProvider As IWorkbookFormatProvider = New Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx.XlsxFormatProvider
            Try
                Using output As Stream = New FileStream(FileName, FileMode.Create)
                    formatProvider.Export(workbook, output)
                End Using

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        'Dim fileName As String = "c:\temp\SampleFile.xlsx"


    End Sub

    Private Function GetWeekStartDate(weekNumber As Integer, year As Integer) As Date
        Dim startDate As New DateTime(year, 1, 1)
        Dim weekDate As DateTime = DateAdd(DateInterval.WeekOfYear, weekNumber - 1, startDate)
        Return DateAdd(DateInterval.Day, (-weekDate.DayOfWeek) + 1, weekDate)
    End Function

    'Private Sub test()
    '    Dim dateFrom As New DateTime(2020, 1, 1)
    '    Dim dateTo As New DateTime(2020, 1, 30)
    '    ' Difference in days, hours, and minutes.
    '    'NumberOfWeeks(oldDate, newDate)
    '    Dim Span As TimeSpan = dateTo.Subtract(dateFrom)
    '    If Span.Days <= 7 Then
    '        If dateFrom.DayOfWeek > dateTo.DayOfWeek Then

    '        End If

    '    End If

    '    Dim Days As Integer = Span.Days - 7 + CInt(dateFrom.DayOfWeek)
    '    Dim WeekCount As Integer = 1
    '    Dim DayCount As Integer = 0
    '    WeekCount = 1
    '    While DayCount < Days
    '        DayCount = DayCount + 7
    '        WeekCount = WeekCount + 1
    '    End While
    'End Sub

    Private Sub cmdBAnnulla_Click(sender As Object, e As EventArgs) Handles cmdBAnnulla.Click
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")
        Dim client As New Http.HttpClient

        Try
            Dim dr As DialogResult = RadMessageBox.Show("Procedere con l'eliminazione?", "Elimina visita", MessageBoxButtons.YesNo, RadMessageIcon.Question)
            If dr = DialogResult.No Then
                Exit Sub
            Else
                salva_dati("ELIMINA")
            End If

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Sub cmdGeneraVisite_Click(sender As Object, e As EventArgs) Handles cmdGeneraVisite.Click
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")
        Try
            Dim frm As New FrmExpGantt("", "", "GENERA")

            Dim anno As String = ""
            Dim mese As String = ""

            frm.ShowDialog()

            If frm.sAnno <> "" And frm.sMese <> "" Then
                anno = frm.sAnno
                mese = frm.sMese
                Me.start_generaVisite(anno, mese)
            End If

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub cmdControlla_Click(sender As Object, e As EventArgs) Handles cmdControlla.Click
        start_generaLogVisite()

        'If varCodImp <> "" Then
        '    Dim ID As String = varCodImp
        '    Dim frm As New FrmImpianto(ID, "MODIFICA")
        '    frm.ShowDialog()
        'End If
    End Sub

    Private Sub cmdChiudiVisite_Click(sender As Object, e As EventArgs) Handles cmdChiudiVisite.Click
        Try
            Dim frm As New FrmChiusuraVisite
            frm.ShowDialog()

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

    Private Sub gant_ToolTipTextNeeded(ByVal sender As Object, ByVal e As Telerik.WinControls.ToolTipTextNeededEventArgs) Handles gant.ToolTipTextNeeded
        Dim taskElement As GanttViewTaskElement = TryCast(sender, GanttViewTaskElement)

        If taskElement IsNot Nothing Then
            Dim gItem As New GanttViewDataItem

            'gItem = DirectCast(e.Item, GanttViewDataItem)

            'If Not IsNothing(gItem(col)) Then
            '    Select Case (col.Name.ToUpper)
            '        Case "DTEFFETT"
            '            valore = gItem(col).ToString
            '            If valore.Contains("01/01/0001") Then
            '                valore = ""
            '            End If
            '            Exit For
            '    End Select

            'End If


            Dim itemElement As GanttGraphicalViewBaseItemElement = TryCast(taskElement.Parent, GanttGraphicalViewBaseItemElement)
            Dim colVisita As GanttViewTextViewColumn
            Dim colStato As GanttViewTextViewColumn
            Dim colOra As GanttViewTextViewColumn
            colVisita = gant.Columns(3)
            colStato = gant.Columns(16)
            colOra = gant.Columns(6)

            Dim sVisita As String = itemElement.Data.Item(colVisita)
            Dim sErr As String = itemElement.Data.Item(colStato)
            Dim sOra As String = itemElement.Data.Item(colOra)

            If itemElement IsNot Nothing Then
                e.ToolTipText = itemElement.Data.Start.ToShortDateString() & " " & sOra & " | " + itemElement.Data.Title & " | " & sErr
            End If
        End If
    End Sub

    Private Sub cmdAnagrafica_Click(sender As Object, e As EventArgs) Handles cmdAnagrafica.Click
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            If varCodImp <> "" Then
                Dim frm As New FrmImpianto(varCodImp, "MODIFICA")
                frm.ShowDialog()
            Else
                RadMessageBox.Show("Nessun impianto selezionato", "Errore", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExpLog.Click
        Try
            Dim saveFileDialog1 As New SaveFileDialog()
            export_file("EXCEL")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub export_file(ByVal tipo As String)
        Dim saveFileDialog1 As New SaveFileDialog()


        Select Case tipo
            Case Is = "PDF"
                saveFileDialog1.Filter = "PDF|*.pdf"
            Case Is = "EXCEL"
                saveFileDialog1.Filter = "Excel|*.xls|Excel 2010|*.xslx"
        End Select

        If saveFileDialog1.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        If saveFileDialog1.FileName.Equals([String].Empty) Then
            RadMessageBox.SetThemeName(Me.gridLog.ThemeName)
            RadMessageBox.Show("Inserisci un nome valido")
            Return
        End If

        Dim fileName As String = saveFileDialog1.FileName

        Dim openExportFile As Boolean = False
        Select Case tipo
            Case Is = "PDF"
                'RunExportToPDF(fileName, openExportFile)
            Case Is = "EXCEL"
                gridLog.Columns("img").IsVisible = False
                gridLog.Columns("dataLog").IsVisible = False
                RunExportToExcelML(fileName, openExportFile)
                gridLog.Columns("img").IsVisible = True
                gridLog.Columns("dataLog").IsVisible = True
            Case Else
                Exit Sub
        End Select

        If openExportFile Then
            Try
                System.Diagnostics.Process.Start(fileName)
            Catch ex As Exception
                Dim message As String = [String].Format("Errore apertura file." & vbLf & "Error message: {0}", ex.Message)
                RadMessageBox.Show(message, "Apertura file", MessageBoxButtons.OK, RadMessageIcon.[Error])
            End Try
        End If

    End Sub


    Private Sub RunExportToExcelML(ByVal fileName As String, ByRef openExportFile As Boolean)

        Dim excelExporter As New ExportToExcelML(Me.gridLog)

        excelExporter.SheetName = "ELENCO ERRORI"
        excelExporter.SummariesExportOption = SummariesOption.ExportAll

        excelExporter.SheetMaxRows = ExcelMaxRows._1048576
        'excelExporter.FileExtension = "xlsx"
        excelExporter.HiddenColumnOption = HiddenOption.DoNotExport
        excelExporter.HiddenRowOption = HiddenOption.DoNotExport
        'excelExporter.PagingExportOption = UI.Export.PagingExportOption.AllPages
        excelExporter.ExportVisualSettings = False

        Try
            excelExporter.RunExport(fileName)

            RadMessageBox.SetThemeName(Me.gridLog.ThemeName)
            Dim dr As DialogResult = RadMessageBox.Show("Esportazione eseguita correttamente. Vuoi aprire il file?", "Esportazione Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question)
            If dr = DialogResult.Yes Then
                openExportFile = True

            End If
        Catch ex As IOException
            RadMessageBox.SetThemeName(Me.gridLog.ThemeName)
            RadMessageBox.Show(Me, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.[Error])
        End Try
    End Sub
    'Public Overrides Function GetTimelineBottomElementText(item As GanttViewTimelineDataItem, index As Integer) As String
    '    If item.Range <> TimeRange.[Custom] Then
    '        Return MyBase.GetTimelineBottomElementText(item, index)
    '    End If
    '    Dim format As String = "{0:yyyy}"
    '    Return String.Format(System.Threading.Thread.CurrentThread.CurrentCulture, format, New DateTime(item.Start.Year + index, 1, 1))
    'End Function

End Class
