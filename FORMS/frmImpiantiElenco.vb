Imports System.Data.OleDb
Imports System.Net
Imports System.Reflection
Imports Newtonsoft.Json
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Text
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class FrmImpiantiElenco
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

    Private Async Sub carica_impianti()
        Try
            Dim test As String
            Dim RestURL As String = My.Settings.urlWS & "api/impianti/ImpiantiListParms/GetImpianti2List"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")


            'Dim JsonData As String = Json
            'Dim RestContent As New Http.StringContent(JsonData, Encoding.UTF8, "application/json")

            Dim parmImp As parmImpianti = New parmImpianti

            Dim listCentri As List(Of centri) = New List(Of centri)()
            Dim item As New centri
            Dim item2 As New centri
            item.Centro = "C20"
            'item2.Centro = "C30"
            listCentri.Add(item)
            'listCentri.Add(item2)

            Dim listSoc As List(Of societa) = New List(Of societa)()
            For Each itemS As RadCheckedListDataItem In cmbSoc.Items
                If itemS.Checked = True Then
                    Dim elem As New societa
                    elem.societa = itemS.Value.ToString.Trim
                    listSoc.Add(elem)
                End If
            Next

            'listSoc.Add(itemS2)
            'listSoc.Add(itemS3)

            parmImp.parmSoc = listSoc
            parmImp.parmCentro = listCentri
            parmImp.parmCodCli = ""
            parmImp.parmCodImpianto = ""

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim myContent = jss.Serialize(parmImp)
            RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                test = Await RestResponse.Content.ReadAsStringAsync()
                Dim varses() As elenco
                varses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elenco())(test)
                grid.DataSource = varses
            End If

            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

            statoCaricaGriglia = True

            test = RestResponse.StatusCode.ToString

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

        End Try


    End Sub

    Private Sub FrmImpiantiElenco_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonDFT.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonBLU.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonRED.tssp")

            cmdAllSoc.ThemeName = "buttonDFT"
            cmdSelAllCentri.ThemeName = "buttonDFT"
            cmdFiltro.ThemeName = "buttonDFT"

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

    'Private Sub carica_combo_soc()
    '    Try
    '        Dim conn As New OleDbConnection(My.Settings.cnAS400.ToString)
    '        conn.Open()

    '        Dim ssql As String = "SELECT TRIM(XCDEL) AS XCDEL, SUBSTR(XDTAB, 1, 30) AS XDTAB " _
    '                            & "FROM LIFT_DAT.TABEL00F " _
    '                            & "WHERE XCDTB = 'SOC' AND ATX01 = '' ORDER BY SUBSTR(XDTAB, 1, 30) "

    '        Dim cmd As New OleDbCommand(ssql, conn)
    '        Dim reader As OleDbDataReader = cmd.ExecuteReader()

    '        Me.cmbSoc.DataSource = reader
    '        Me.cmbSoc.DisplayMember = "XDTAB"
    '        Me.cmbSoc.ValueMember = "XCDEL"
    '        Me.cmbSoc.SelectedIndex = -1

    '        conn.Close()
    '        conn.Dispose()

    '    Catch ex As Exception
    '        MsgBox(ex.Message, vbCritical, "RECUBE")
    '    End Try
    'End Sub

    Private Sub carica_griglia_fatture_async()
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

            Dim colAICIM As New GridViewDecimalColumn
            colAICIM.Name = "AICIM"
            colAICIM.DataType = GetType(Integer)
            colAICIM.FieldName = "AICIM"

            Dim colAICLI As New GridViewDecimalColumn
            colAICLI.Name = "AICLI"
            colAICLI.DataType = GetType(String)
            colAICLI.FieldName = "AICLI"

            'Dim colCENTRO As New GridViewTextBoxColumn
            'colCENTRO.Name = "CODICECENTRO"
            'colCENTRO.DataType = GetType(String)
            'colCENTRO.FieldName = "CODICECENTRO"

            Dim colAISTR As New GridViewTextBoxColumn
            colAISTR.Name = "AISTR"
            colAISTR.DataType = GetType(String)
            colAISTR.FieldName = "AISTR"

            Dim colAIIND As New GridViewTextBoxColumn
            colAIIND.Name = "AIIND"
            colAIIND.DataType = GetType(String)
            colAIIND.FieldName = "AIIND"

            Dim colAILOC As New GridViewTextBoxColumn
            colAILOC.Name = "AILOC"
            colAILOC.DataType = GetType(String)
            colAILOC.FieldName = "AILOC"

            Dim colAICAP As New GridViewTextBoxColumn
            colAICAP.Name = "AICAP"
            colAICAP.DataType = GetType(String)
            colAICAP.FieldName = "AICAP"

            Dim colAIAMM As New GridViewTextBoxColumn
            colAIAMM.Name = "AIAMM"
            colAIAMM.DataType = GetType(String)
            colAIAMM.FieldName = "AIAMM"

            Dim colDESAMM As New GridViewTextBoxColumn
            colDESAMM.Name = "DESAMM"
            colDESAMM.DataType = GetType(String)
            colDESAMM.FieldName = "DESAMM"

            Dim colDESCLI As New GridViewTextBoxColumn
            colDESCLI.Name = "DESCLI"
            colDESCLI.DataType = GetType(String)
            colDESCLI.FieldName = "DESCLI"

            Dim colCODSOC As New GridViewTextBoxColumn
            colCODSOC.Name = "CODSOC"
            colCODSOC.DataType = GetType(String)
            colCODSOC.FieldName = "CODSOC"

            Dim colCODCEN As New GridViewTextBoxColumn
            colCODCEN.Name = "CODCEN"
            colCODCEN.DataType = GetType(String)
            colCODCEN.FieldName = "CODCEN"

            Dim colDESTIM As New GridViewTextBoxColumn
            colDESTIM.Name = "DESTIM"
            colDESTIM.DataType = GetType(String)
            colDESTIM.FieldName = "DESTIM"


            'grid.MasterTemplate.Columns.Add(commandColumn)
            'grid.MasterTemplate.Columns.Add(checkBoxColumn)
            grid.MasterTemplate.Columns.Add(colCODSOC)
            grid.MasterTemplate.Columns.Add(colCODCEN)
            grid.MasterTemplate.Columns.Add(colAICIM)
            grid.MasterTemplate.Columns.Add(colDESTIM)
            grid.MasterTemplate.Columns.Add(colAICLI)
            grid.MasterTemplate.Columns.Add(colDESCLI)
            grid.MasterTemplate.Columns.Add(colAIAMM)
            grid.MasterTemplate.Columns.Add(colDESAMM)
            'grid.MasterTemplate.Columns.Add(colCENTRO)
            grid.MasterTemplate.Columns.Add(colAISTR)
            grid.MasterTemplate.Columns.Add(colAIIND)
            grid.MasterTemplate.Columns.Add(colAILOC)
            grid.MasterTemplate.Columns.Add(colAICAP)


            'AddHandler grid.CommandCellClick, AddressOf grid_CommandCellClick

            grid.TableElement.SearchHighlightColor = Color.LimeGreen

            'Me.grid.Columns("Check").AllowFiltering = False
            'Me.grid.Columns("Mod").AllowFiltering = False


            Me.grid.EndEdit()

            grid.AllowSearchRow = True
            'grid.MasterView.SummaryRows(0).PinPosition = PinnedRowPosition.Bottom

            Me.HeaderText_ColumnFatture()
            Me.HeaderText_Column_Fatture_width()

            'caricamento totali griglia

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnFatture()
        Try
            Me.grid.Columns("CODSOC").HeaderText = "Soc."
            Me.grid.Columns("CODCEN").HeaderText = "Centro"
            Me.grid.Columns("AICIM").HeaderText = "Cod. Impianto"
            Me.grid.Columns("DESTIM").HeaderText = "Tipo Impianto"
            Me.grid.Columns("AICLI").HeaderText = "Cod. Cliente"
            Me.grid.Columns("DESCLI").HeaderText = "Ragione Sociale Cliente"
            Me.grid.Columns("DESAMM").HeaderText = "Ragione Sociale Amministratore"
            'Me.grid.Columns("CODICECENTRO").HeaderText = "Centro"
            Me.grid.Columns("AISTR").HeaderText = "cod. Strada"
            Me.grid.Columns("AIIND").HeaderText = "Indirizzo"
            Me.grid.Columns("AILOC").HeaderText = "Località"
            Me.grid.Columns("AICAP").HeaderText = "CAP"
            Me.grid.Columns("AIAMM").HeaderText = "Codice Amm."

            Me.grid.Columns("CODSOC").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("DESTIM").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("CODCEN").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("AICIM").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("AICLI").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("AISTR").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("AIAMM").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("AILOC").TextAlignment = ContentAlignment.MiddleCenter

            'Me.grid.Columns("mod").IsVisible = False
            'Me.grid.Columns("ALIQUOTA").IsVisible = False
            'Me.grid.Columns("IMPONIBILE").IsVisible = False
            'Me.grid.Columns("IMPOSTA").IsVisible = False
            'Me.grid.Columns("TOTALE").IsVisible = False

            Me.grid.Columns("CODSOC").ReadOnly = True
            Me.grid.Columns("DESTIM").ReadOnly = True
            Me.grid.Columns("CODCEN").ReadOnly = True
            Me.grid.Columns("AICIM").ReadOnly = True
            Me.grid.Columns("AICLI").ReadOnly = True
            Me.grid.Columns("AISTR").ReadOnly = True
            Me.grid.Columns("AIIND").ReadOnly = True
            Me.grid.Columns("AILOC").ReadOnly = True
            Me.grid.Columns("AICAP").ReadOnly = True
            Me.grid.Columns("AIAMM").ReadOnly = True
            Me.grid.Columns("DESCLI").ReadOnly = True
            Me.grid.Columns("DESAMM").ReadOnly = True


            'Me.grid.Columns("DATADOC").FormatString = "{0:dd/MM/yyyy}"

            'Me.grid.Columns("IMPOSTA").FormatString = "{0:#,##0.00}"


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_Fatture_width()
        Try
            Me.grid.Columns("CODSOC").Width = 80
            Me.grid.Columns("CODCEN").Width = 90
            Me.grid.Columns("DESTIM").Width = 130
            Me.grid.Columns("AICIM").Width = 100
            Me.grid.Columns("AICLI").Width = 90
            'Me.grid.Columns("CODICECENTRO").Width = 80
            Me.grid.Columns("AISTR").Width = 140
            Me.grid.Columns("AIIND").Width = 230
            Me.grid.Columns("DESAMM").Width = 230
            Me.grid.Columns("DESCLI").Width = 230
            Me.grid.Columns("AILOC").Width = 150
            Me.grid.Columns("AICAP").Width = 60
            Me.grid.Columns("AIAMM").Width = 80

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub


    Private Sub LoadSummaryPartite()
        Try

            Me.grid.MasterTemplate.SummaryRowsBottom.Clear()
            Dim item1 As New GridViewSummaryRowItem()
            item1.Add(New GridViewSummaryItem("AICIM", "{0:R #.###}", GridAggregateFunction.Count))

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

    'Private Sub carica_combo_centro()
    '    Try

    '        Dim filtro As String

    '        Dim conn As New OleDbConnection(My.Settings.cnAS400.ToString)
    '        conn.Open()

    '        filtro = "WHERE ATX07 = ''"

    '        If gElencoCentri <> "*" Then
    '            filtro = filtro & " AND TCCEN IN (" & gElencoCentri & ")"
    '        End If

    '        Dim ssql As String = "SELECT TCCEN, TCDES " _
    '            & "FROM COMUNERE.TABCE00F " _
    '            & filtro _
    '            & "ORDER BY TCCEN "

    '        Dim cmd As New OleDbCommand(ssql, conn)
    '        Dim reader As OleDbDataReader = cmd.ExecuteReader()

    '        Me.cmbCentro.DataSource = reader
    '        Me.cmbCentro.DisplayMember = "TCCEN"
    '        Me.cmbCentro.ValueMember = "TCCEN"
    '        Me.cmbCentro.SelectedIndex = -1

    '        reader.Close()

    '        conn.Close()
    '        conn.Dispose()

    '    Catch ex As Exception
    '        MsgBox(ex.Message, vbCritical, "RECUBE")
    '    End Try
    'End Sub

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
            Dim ID As String = grid.CurrentRow.Cells("AICIM").Value.ToString
            Dim frm As New FrmImpianto(ID, "MODIFICA")
            frm.ShowDialog()
        End If
    End Sub

    Private Sub FrmImpiantiElenco_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Me.carica_combo_soc()
            Me.carica_combo_centro()
            Me.carica_griglia_fatture_async()
            'Me.carica_impianti()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdInserisci_Click(sender As Object, e As EventArgs) Handles cmdInserisci.Click
        Dim frm As New FrmImpianto(0, "NUOVO")
        frm.ShowDialog()
    End Sub

    Private Sub cmdFiltro_Click(sender As Object, e As EventArgs) Handles cmdFiltro.Click
        Me.carica_impianti()
    End Sub
End Class
