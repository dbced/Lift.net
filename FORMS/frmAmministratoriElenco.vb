Imports System.Data.OleDb
Imports System.Net
Imports System.Reflection
Imports Newtonsoft.Json
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Text
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Public Class FrmAmministratoriElenco
    Private gElencoCentri As String = ""
    Private user As String
    Private ruolo As String
    Private userAS As String

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

    Private Async Sub carica_Amministratori()
        Try
            Dim test As String
            Dim RestURL As String = My.Settings.urlWS & "api/Anagrafiche/GetElencoAmministratoriList/GetElencoAmministratoriList"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodTab", "")
            client.DefaultRequestHeaders.Add("parmCodEle", txtRicerca.Text)


            'Dim parmImp As parmGetTabella = New parmGetTabella

            'Dim listCentri As List(Of centri) = New List(Of centri)()
            'Dim item As New centri
            'Dim item2 As New centri
            'item.Centro = "C20"
            ''item2.Centro = "C30"
            'listCentri.Add(item)
            ''listCentri.Add(item2)

            'Dim listSoc As List(Of societa) = New List(Of societa)()
            'For Each itemS As RadCheckedListDataItem In cmbSoc.Items
            '    If itemS.Checked = True Then
            '        Dim elem As New societa
            '        elem.societa = itemS.Value.ToString.Trim
            '        listSoc.Add(elem)
            '    End If
            'Next

            ''listSoc.Add(itemS2)
            ''listSoc.Add(itemS3)

            'parmImp.codElemento = txtRicerca.Text
            'parmImp.codtabella = ""
            'parmImp.codElem = ""

            'Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent


            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                test = Await RestResponse.Content.ReadAsStringAsync()
                Dim varses() As elencoAmministratori
                varses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoAmministratori())(test)
                grid.DataSource = varses
            End If

            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

            test = RestResponse.StatusCode.ToString

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

        End Try


    End Sub

    Private Sub carica_griglia_async()
        Try

            Me.LoadSummaryPartite()

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

            Dim colAACAD As New GridViewTextBoxColumn
            colAACAD.Name = "AACAD"
            colAACAD.DataType = GetType(String)
            colAACAD.FieldName = "AACAD"

            Dim colAANOM As New GridViewTextBoxColumn
            colAANOM.Name = "AANOM"
            colAANOM.DataType = GetType(String)
            colAANOM.FieldName = "AANOM"

            Dim colAACDF As New GridViewTextBoxColumn
            colAACDF.Name = "AACDF"
            colAACDF.DataType = GetType(String)
            colAACDF.FieldName = "AACDF"

            Dim colAPAIV As New GridViewTextBoxColumn
            colAPAIV.Name = "APAIV"
            colAPAIV.DataType = GetType(String)
            colAPAIV.FieldName = "APAIV"

            Dim colAAIND As New GridViewTextBoxColumn
            colAAIND.Name = "AAIND"
            colAAIND.DataType = GetType(String)
            colAAIND.FieldName = "AAIND"

            Dim colAACOM As New GridViewTextBoxColumn
            colAACOM.Name = "AACOM"
            colAACOM.DataType = GetType(String)
            colAACOM.FieldName = "AACOM"

            Dim colAACAP As New GridViewTextBoxColumn
            colAACAP.Name = "AACAP"
            colAACAP.DataType = GetType(String)
            colAACAP.FieldName = "AACAP"

            Dim colAASPR As New GridViewTextBoxColumn
            colAASPR.Name = "AASPR"
            colAASPR.DataType = GetType(String)
            colAASPR.FieldName = "AASPR"

            Dim colAATL1 As New GridViewTextBoxColumn
            colAATL1.Name = "AATL1"
            colAATL1.DataType = GetType(String)
            colAATL1.FieldName = "AATL1"

            Dim colAATL2 As New GridViewTextBoxColumn
            colAATL2.Name = "AATL2"
            colAATL2.DataType = GetType(String)
            colAATL2.FieldName = "AATL2"

            Dim colAATL3 As New GridViewTextBoxColumn
            colAATL3.Name = "AATL3"
            colAATL3.DataType = GetType(String)
            colAATL3.FieldName = "AATL3"

            Dim colAATL4 As New GridViewTextBoxColumn
            colAATL4.Name = "AATL4"
            colAATL4.DataType = GetType(String)
            colAATL4.FieldName = "AATL4"



            'grid.MasterTemplate.Columns.Add(commandColumn)
            'grid.MasterTemplate.Columns.Add(checkBoxColumn)
            grid.MasterTemplate.Columns.Add(colAACAD)
            grid.MasterTemplate.Columns.Add(colAANOM)
            grid.MasterTemplate.Columns.Add(colAACDF)
            grid.MasterTemplate.Columns.Add(colAPAIV)
            grid.MasterTemplate.Columns.Add(colAAIND)
            grid.MasterTemplate.Columns.Add(colAACOM)
            grid.MasterTemplate.Columns.Add(colAACAP)
            grid.MasterTemplate.Columns.Add(colAASPR)
            'grid.MasterTemplate.Columns.Add(colCENTRO)
            grid.MasterTemplate.Columns.Add(colAATL1)
            grid.MasterTemplate.Columns.Add(colAATL2)
            grid.MasterTemplate.Columns.Add(colAATL3)
            grid.MasterTemplate.Columns.Add(colAATL4)


            'AddHandler grid.CommandCellClick, AddressOf grid_CommandCellClick

            grid.TableElement.SearchHighlightColor = Color.LimeGreen

            'Me.grid.Columns("Check").AllowFiltering = False
            'Me.grid.Columns("Mod").AllowFiltering = False


            Me.grid.EndEdit()

            grid.AllowSearchRow = True
            'grid.MasterView.SummaryRows(0).PinPosition = PinnedRowPosition.Bottom

            Me.HeaderText_ColumnGriglia()
            Me.HeaderText_ColumnGriglia_width()

            'caricamento totali griglia

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia()
        Try
            Me.grid.Columns("AANOM").HeaderText = "Ragione Sociale"
            Me.grid.Columns("AACAD").HeaderText = "Codice"
            Me.grid.Columns("AAIND").HeaderText = "Indirizzo"
            Me.grid.Columns("AACOM").HeaderText = "Località"
            Me.grid.Columns("AASPR").HeaderText = "Prov"
            Me.grid.Columns("AACAP").HeaderText = "CAP"
            Me.grid.Columns("AACDF").HeaderText = "Codice Fiscale"
            Me.grid.Columns("APAIV").HeaderText = "Partita Iva"
            Me.grid.Columns("AATL1").HeaderText = "Tel. casa"
            Me.grid.Columns("AATL2").HeaderText = "Tel. Ufficio"
            Me.grid.Columns("AATL3").HeaderText = "Cellulare"
            Me.grid.Columns("AATL4").HeaderText = "Fax"


            Me.grid.Columns("AACAD").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("AASPR").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("AACAP").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("AACDF").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("APAIV").TextAlignment = ContentAlignment.MiddleCenter


            'Me.grid.Columns("mod").IsVisible = False
            'Me.grid.Columns("ALIQUOTA").IsVisible = False
            'Me.grid.Columns("IMPONIBILE").IsVisible = False
            'Me.grid.Columns("IMPOSTA").IsVisible = False
            'Me.grid.Columns("TOTALE").IsVisible = False

            For i As Integer = 0 To grid.Columns.Count - 1
                Me.grid.Columns(i).ReadOnly = True
            Next


            'Me.grid.Columns("DATADOC").FormatString = "{0:dd/MM/yyyy}"

            'Me.grid.Columns("IMPOSTA").FormatString = "{0:#,##0.00}"


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia_width()
        Try
            Me.grid.Columns("AANOM").Width = 250
            Me.grid.Columns("AACAD").Width = 100
            Me.grid.Columns("AAIND").Width = 250
            Me.grid.Columns("AACOM").Width = 200
            Me.grid.Columns("AASPR").Width = 80
            Me.grid.Columns("AACAP").Width = 80
            Me.grid.Columns("AACDF").Width = 150
            Me.grid.Columns("APAIV").Width = 150
            Me.grid.Columns("AATL1").Width = 120
            Me.grid.Columns("AATL2").Width = 120
            Me.grid.Columns("AATL3").Width = 120
            Me.grid.Columns("AATL4").Width = 120

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
    Private Sub cmdFiltro_Click(sender As Object, e As EventArgs) Handles cmdFiltro.Click
        Me.carica_Amministratori()
    End Sub

    Private Sub FrmAmministratoriElenco_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.carica_griglia_async()
    End Sub

    Private Sub cmdBModifica_Click(sender As Object, e As EventArgs) Handles cmdBModifica.Click
        Try
            Dim frm As New FrmAmministratore
            frm.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub
End Class


