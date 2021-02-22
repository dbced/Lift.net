Imports System.Data.OleDb
Imports System.Net
Imports System.Reflection
Imports Newtonsoft.Json
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Text
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class FrmTecniciElenco
    Private gElencoCentri As String = ""
    Private user As String
    Private ruolo As String
    Private userAS As String

    Private ws As New webServices

    Public Sub New(ByVal Menu As Telerik.WinControls.UI.RadForm, Optional ByVal ElencoCentri As String = "", Optional ByVal inUser As String = "", Optional ByVal inRuolo As String = "", Optional ByVal inUserAS As String = "")
        InitializeComponent()
        WireEvents()
        ruolo = inRuolo
        user = inUser
        userAS = inUserAS
        gElencoCentri = ElencoCentri
    End Sub

    Private Sub FrmImpiantiElenco_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonDFT.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonBLU.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonRED.tssp")

            cmdAllSoc.ThemeName = "buttonDFT"
            cmdSelAllCentri.ThemeName = "buttonDFT"
            cmdFiltro.ThemeName = "buttonDFT"

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Protected Sub WireEvents()
        AddHandler grid.ViewCellFormatting, AddressOf grid_ViewCellFormatting
        AddHandler grid.ViewRowFormatting, AddressOf grid_ViewRowFormatting
        AddHandler grid.CellFormatting, AddressOf grid_CellFormatting
        AddHandler grid.ContextMenuOpening, AddressOf grid_ContextMenuOpening
        'AddHandler grid.CreateCell, AddressOf grid_CreateCell
        AddHandler grid.ValueChanging, AddressOf grid_ValueChanging
    End Sub

    Private Async Sub async_carica_griglia_tecnici()
        Try

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoTecnici))
            elementi = ws.getElencoTecnici("", txtRicerca.Text, "")
            Await elementi

            carica_griglia_tecnici(elementi.Result)

            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

        Catch ex As Exception
            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False
            MsgBox(ex.Message, vbCritical)

            'wbA.StopWaiting()
            'wbA.AssociatedControl = Nothing
            'wbA.Visible = False

            'wbG.AssociatedControl = Nothing
            'wbG.StopWaiting()
            'wbG.Visible = False

        End Try
    End Sub

    Private Sub carica_griglia_tecnici(dati As List(Of elencoTecnici))
        Try

            grid.DataSource = dati
            Me.LoadSummaryPartite()
            Me.HeaderText_ColumnGriglia()
            Me.HeaderText_ColumnGriglia_width()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub crea_griglia_tecnici()
        Try

            Me.grid.BeginEdit()
            Me.grid.EnableFiltering = True
            Me.grid.MasterTemplate.ShowHeaderCellButtons = True
            Me.grid.MasterTemplate.ShowFilteringRow = False
            Me.grid.AllowAddNewRow = False
            Me.grid.AutoGenerateColumns = False
            Me.grid.EnableGrouping = False

            Dim commandColumn As New GridViewTextBoxColumn
            commandColumn.Name = "Mod"
            commandColumn.DataType = GetType(String)
            commandColumn.HeaderText = "Mod"
            commandColumn.ReadOnly = True
            commandColumn.Width = 50
            commandColumn.IsPinned = True
            ''----------------------------------------------------------------

            Dim colATCOD As New GridViewTextBoxColumn
            colATCOD.Name = "ATCOD"
            colATCOD.DataType = GetType(String)
            colATCOD.FieldName = "ATCOD"

            Dim colATRAG As New GridViewTextBoxColumn
            colATRAG.Name = "ATRAG"
            colATRAG.DataType = GetType(String)
            colATRAG.FieldName = "ATRAG"

            Dim colATCEN As New GridViewTextBoxColumn
            colATCEN.Name = "ATCEN"
            colATCEN.DataType = GetType(String)
            colATCEN.FieldName = "ATCEN"

            Dim colATIME As New GridViewTextBoxColumn
            colATIME.Name = "ATIME"
            colATIME.DataType = GetType(String)
            colATIME.FieldName = "ATIME"

            Dim colATQUA As New GridViewTextBoxColumn
            colATQUA.Name = "DESQUA"
            colATQUA.DataType = GetType(String)
            colATQUA.FieldName = "DESQUA"

            'grid.MasterTemplate.Columns.Add(commandColumn)
            'grid.MasterTemplate.Columns.Add(checkBoxColumn)
            grid.MasterTemplate.Columns.Add(colATCOD)
            grid.MasterTemplate.Columns.Add(colATRAG)
            grid.MasterTemplate.Columns.Add(colATQUA)
            grid.MasterTemplate.Columns.Add(colATCEN)
            grid.MasterTemplate.Columns.Add(colATIME)

            'AddHandler grid.CommandCellClick, AddressOf grid_CommandCellClick

            grid.TableElement.SearchHighlightColor = Color.LimeGreen

            'Me.grid.Columns("Check").AllowFiltering = False
            'Me.grid.Columns("Mod").AllowFiltering = False


            Me.grid.EndEdit()

            grid.AllowSearchRow = True
            'grid.MasterView.SummaryRows(0).PinPosition = PinnedRowPosition.Bottom


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia()
        Try
            Me.grid.Columns("ATRAG").HeaderText = "Ragione Sociale"
            Me.grid.Columns("ATCOD").HeaderText = "Codice"
            Me.grid.Columns("DESQUA").HeaderText = "Qualifica"
            Me.grid.Columns("ATCEN").HeaderText = "Centro"
            Me.grid.Columns("ATIME").HeaderText = "IMEI"


            Me.grid.Columns("ATCOD").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("DESQUA").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("ATCEN").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("ATIME").TextAlignment = ContentAlignment.MiddleCenter

            For i As Integer = 0 To grid.Columns.Count - 1
                Me.grid.Columns(i).ReadOnly = True
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia_width()
        Try
            Me.grid.Columns("ATRAG").Width = 350
            Me.grid.Columns("ATCOD").Width = 100
            Me.grid.Columns("ATCEN").Width = 100
            Me.grid.Columns("DESQUA").Width = 120
            Me.grid.Columns("ATIME").Width = 200


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try

    End Sub
    Private Sub LoadSummaryPartite()
        Try

            Me.grid.MasterTemplate.SummaryRowsBottom.Clear()
            Dim item1 As New GridViewSummaryRowItem()
            item1.Add(New GridViewSummaryItem("AACAD", "{0:R #.###}", GridAggregateFunction.Count))

            Me.grid.MasterTemplate.SummaryRowsBottom.Add(item1)

            grid.MasterTemplate.ShowTotals = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try

    End Sub

    Private Sub grid_GroupSummaryEvaluate(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GroupSummaryEvaluationEventArgs) Handles grid.GroupSummaryEvaluate
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
                If e.SummaryItem.Name = "NUMDOC" Then
                ElseIf e.SummaryItem.Name = "AICIM" Then
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

            ElseIf e.CellElement.ColumnInfo.Name.ToUpper = "IDSDI" Then
                'e.CellElement.Image = My.Resources._16_corner
                'e.CellElement.ImageAlignment = ContentAlignment.TopLeft
                'e.CellElement.TextImageRelation = TextImageRelation.ImageBeforeText
                'e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)

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

    Private Sub grid_FilterPopupRequired(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.FilterPopupRequiredEventArgs) Handles grid.FilterPopupRequired
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

    Private Sub FrmTecniciElenco_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        crea_griglia_tecnici()
        Me.async_carica_griglia_tecnici()
    End Sub

    Private Sub cmdFiltro_Click(sender As Object, e As EventArgs) Handles cmdFiltro.Click
        Me.async_carica_griglia_tecnici()
    End Sub

    Private Sub cmdBModifica_Click(sender As Object, e As EventArgs) Handles cmdBModifica.Click
        Try

            If grid.Rows.Count = 0 Then
                Exit Sub
            End If

            Dim codice As String = grid.CurrentRow.Cells("ATCOD").Value
            Dim frm As New FrmTecnico(codice)
            frm.ShowDialog()
            Me.async_carica_griglia_tecnici()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub cmdInserisci_Click(sender As Object, e As EventArgs) Handles cmdInserisci.Click
        Try
            Dim codice As String = ""
            Dim frm As New FrmTecnico(codice)
            frm.ShowDialog()
            Me.async_carica_griglia_tecnici()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub
End Class
