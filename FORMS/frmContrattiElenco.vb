Imports System.Data.OleDb
Imports System.Net
Imports System.Reflection
Imports Newtonsoft.Json
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Text
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class FrmContrattiElenco
    Private gElencoCentri As String = ""
    Private user As String
    Private ruolo As String
    Private userAS As String
    Private ws As New webServices

    Dim statoCaricaSoc As Boolean
    Dim statoCaricaCentri As Boolean
    Dim statoCaricaGriglia As Boolean
    Dim formInCaricamento As Boolean

    Public Sub New(ByVal Menu As Telerik.WinControls.UI.RadForm, Optional ByVal ElencoCentri As String = "", Optional ByVal inUser As String = "", Optional ByVal inRuolo As String = "", Optional ByVal inUserAS As String = "")
        InitializeComponent()
        WireEvents()
        ruolo = inRuolo
        user = inUser
        userAS = inUserAS
        gElencoCentri = ElencoCentri
    End Sub

    Protected Sub WireEvents()
        AddHandler grid.ViewCellFormatting, AddressOf gridFatt_ViewCellFormatting
        AddHandler grid.ViewRowFormatting, AddressOf gridFatt_ViewRowFormatting
        AddHandler grid.CellFormatting, AddressOf gridFatt_CellFormatting
        AddHandler grid.ContextMenuOpening, AddressOf gridFatt_ContextMenuOpening
        'AddHandler grid.CreateCell, AddressOf grid_CreateCell
        AddHandler grid.ValueChanging, AddressOf grid_ValueChanging
    End Sub

    Private Async Sub carica_contratti()
        Try
            Dim parms As New elencoAssetsImpianto

            Dim stringResponse As String
            Dim RestURL As String = My.Settings.urlWS & "api/Contratti/GetElencoContrattiList/GetElencoContrattiList"
            Dim client As New Http.HttpClient

            Dim cl As New elencoListaContratti

            Dim paramList As ArrayList = New ArrayList()

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            Dim parmCtr As parmsRicContratti = New parmsRicContratti

            Dim listCentri As List(Of lista_centri) = New List(Of lista_centri)()

            Dim listSoc As List(Of lista_societa) = New List(Of lista_societa)()
            For Each itemS As RadCheckedListDataItem In cmbSoc.Items
                If itemS.Checked = True Then
                    Dim elem As New lista_societa
                    elem.societa = itemS.Value.ToString.Trim
                    listSoc.Add(elem)
                End If
            Next

            parmCtr.parmSoc = listSoc
            parmCtr.parmCentro = listCentri
            parmCtr.parmCodCli = txtCodCliente.Text.Trim
            parmCtr.parmCodImpianto = ""
            parmCtr.parmCodContratto = ""
            parmCtr.parmCtrAttivi = IIf(chkAttivi.Checked = True, "S", "N")

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim myContent = jss.Serialize(parmCtr)
            RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                stringResponse = Await RestResponse.Content.ReadAsStringAsync()
                Dim varses() As elencoListaContratti
                varses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoListaContratti())(stringResponse)
                grid.DataSource = varses
            End If

            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

            statoCaricaGriglia = True

            stringResponse = RestResponse.StatusCode.ToString

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

        End Try


    End Sub

    Private Sub FrmContrattiElenco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonDFT.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonBLU.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonRED.tssp")

            cmdAllSoc.ThemeName = "buttonDFT"
            cmdSelAllCentri.ThemeName = "buttonDFT"
            cmdFiltro.ThemeName = "buttonDFT"
            cmdOkSearchCli.ThemeName = "buttonDFT"

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            t1.Enabled = True
            formInCaricamento = True

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub
    Private Sub t1_Tick(sender As Object, e As EventArgs) Handles t1.Tick
        Try
            If statoCaricaSoc = True And statoCaricaCentri = True Then

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

    Private Sub carica_griglia_contratti_async()
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

            Dim colCTTFA As New GridViewTextBoxColumn
            colCTTFA.Name = "CTTFA"
            colCTTFA.DataType = GetType(String)
            colCTTFA.FieldName = "CTTFA"

            Dim colCTRTA As New GridViewTextBoxColumn
            colCTRTA.Name = "CTRTA"
            colCTRTA.DataType = GetType(String)
            colCTRTA.FieldName = "CTRTA"

            Dim colCTNIM As New GridViewDecimalColumn
            colCTNIM.Name = "CTNIM"
            colCTNIM.DataType = GetType(Integer)
            colCTNIM.FieldName = "CTNIM"

            Dim colRASCL As New GridViewTextBoxColumn
            colRASCL.Name = "RASCL"
            colRASCL.DataType = GetType(String)
            colRASCL.FieldName = "RASCL"

            Dim colINDCL As New GridViewTextBoxColumn
            colINDCL.Name = "INDCL"
            colINDCL.DataType = GetType(String)
            colINDCL.FieldName = "INDCL"

            Dim colLOCCL As New GridViewTextBoxColumn
            colLOCCL.Name = "LOCCL"
            colLOCCL.DataType = GetType(String)
            colLOCCL.FieldName = "LOCCL"

            'grid.MasterTemplate.Columns.Add(commandColumn)
            'grid.MasterTemplate.Columns.Add(checkBoxColumn)

            grid.MasterTemplate.Columns.Add(colCTSOC)
            grid.MasterTemplate.Columns.Add(colCTNRC)
            grid.MasterTemplate.Columns.Add(colCTDTD)
            grid.MasterTemplate.Columns.Add(colCTDTS)
            grid.MasterTemplate.Columns.Add(colCTNIM)
            grid.MasterTemplate.Columns.Add(colCTCLI)
            grid.MasterTemplate.Columns.Add(colRASCL)
            grid.MasterTemplate.Columns.Add(colINDCL)
            grid.MasterTemplate.Columns.Add(colLOCCL)

            'AddHandler grid.CommandCellClick, AddressOf grid_CommandCellClick

            grid.TableElement.SearchHighlightColor = Color.LimeGreen

            'Me.grid.Columns("Check").AllowFiltering = False
            'Me.grid.Columns("Mod").AllowFiltering = False

            Me.grid.EndEdit()

            grid.AllowSearchRow = True
            'grid.MasterView.SummaryRows(0).PinPosition = PinnedRowPosition.Bottom

            Me.HeaderText_ColumnContratti()
            Me.HeaderText_Column_Contratti_width()

            'caricamento totali griglia

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnContratti()
        Try
            Me.grid.Columns("CTSOC").HeaderText = "Soc."
            Me.grid.Columns("CTNRC").HeaderText = "Contratto"
            Me.grid.Columns("CTDTD").HeaderText = "Decorrenza"
            Me.grid.Columns("CTDTS").HeaderText = "Scadenza"
            Me.grid.Columns("CTNIM").HeaderText = "N. Impianti"
            Me.grid.Columns("CTCLI").HeaderText = "Cod. Cliente"
            Me.grid.Columns("RASCL").HeaderText = "Ragione Sociale"
            Me.grid.Columns("INDCL").HeaderText = "Indirizzo"
            Me.grid.Columns("LOCCL").HeaderText = "Località"

            Me.grid.Columns("CTSOC").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("CTNRC").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("CTDTD").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("CTDTS").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("CTNIM").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("CTCLI").TextAlignment = ContentAlignment.MiddleCenter

            Me.grid.Columns("CTSOC").ReadOnly = True
            Me.grid.Columns("CTNRC").ReadOnly = True
            Me.grid.Columns("CTDTD").ReadOnly = True
            Me.grid.Columns("CTDTS").ReadOnly = True
            Me.grid.Columns("CTNIM").ReadOnly = True
            Me.grid.Columns("CTCLI").ReadOnly = True
            Me.grid.Columns("RASCL").ReadOnly = True
            Me.grid.Columns("INDCL").ReadOnly = True
            Me.grid.Columns("LOCCL").ReadOnly = True

            Me.grid.Columns("CTDTD").FormatString = "{0:dd/MM/yyyy}"
            Me.grid.Columns("CTDTS").FormatString = "{0:dd/MM/yyyy}"

            'Me.grid.Columns("IMPOSTA").FormatString = "{0:#,##0.00}"


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_Contratti_width()
        Try
            Me.grid.Columns("CTSOC").Width = 80
            Me.grid.Columns("CTNRC").Width = 90
            Me.grid.Columns("CTDTD").Width = 100
            Me.grid.Columns("CTDTS").Width = 100
            Me.grid.Columns("CTNIM").Width = 80
            Me.grid.Columns("CTCLI").Width = 120
            Me.grid.Columns("RASCL").Width = 350
            Me.grid.Columns("INDCL").Width = 250
            Me.grid.Columns("LOCCL").Width = 200

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub


    Private Sub LoadSummaryPartite()
        Try

            Me.grid.MasterTemplate.SummaryRowsBottom.Clear()
            Dim item1 As New GridViewSummaryRowItem()
            item1.Add(New GridViewSummaryItem("CTNRC", "{0:R #.###}", GridAggregateFunction.Count))

            Me.grid.MasterTemplate.SummaryRowsBottom.Add(item1)

            grid.MasterTemplate.ShowTotals = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try

    End Sub

    Private Sub gridFatt_GroupSummaryEvaluate(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GroupSummaryEvaluationEventArgs) Handles grid.GroupSummaryEvaluate
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

    Private Sub gridFatt_ViewRowFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.RowFormattingEventArgs)

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
    Private Sub gridFatt_CellFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs)

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

    Private Sub gridFatt_ContextMenuOpening(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.ContextMenuOpeningEventArgs)
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

    Private Sub cmdBModifica_Click(sender As Object, e As EventArgs) Handles cmdBModifica.Click

        If grid.Rows.Count > 0 Then
            Dim ID As String = grid.CurrentRow.Cells("CTNRC").Value.ToString
            Dim frm As New FrmContratto(ID, "MODIFICA")
            frm.ShowDialog()
        End If
    End Sub

    Private Sub FrmContrattiElenco_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            Me.carica_combo_soc()
            Me.carica_combo_centro()
            Me.carica_griglia_contratti_async()

            'Me.carica_impianti()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdInserisci_Click(sender As Object, e As EventArgs) Handles cmdInserisci.Click
        Dim frm As New FrmImpianto(0, "NUOVO")
        frm.ShowDialog()
    End Sub

    Private Sub cmdFiltro_Click(sender As Object, e As EventArgs) Handles cmdFiltro.Click
        Me.carica_contratti()
    End Sub

    Private Sub cmdOkSearchCli_Click(sender As Object, e As EventArgs) Handles cmdOkSearchCli.Click
        Try
            Dim frm As New FrmRicercaTabelle("CLIENTI")
            frm.CodiceOut = ""
            frm.DescrOut = ""
            frm.ShowDialog()
            txtCodCliente.Text = frm.CodiceOut
        Catch ex As Exception

        End Try
    End Sub
End Class
