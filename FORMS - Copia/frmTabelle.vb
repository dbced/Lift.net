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

Public Class FrmTabelle
    Public codiceTabella As String
    Private ws As New webServices
    Private gAzione As String

    Public Sub New()
        InitializeComponent()
        WireEvents()
    End Sub

    Protected Sub WireEvents()

        AddHandler grid.ContextMenuOpening, AddressOf gridFatt_ContextMenuOpening
        AddHandler grid.ViewCellFormatting, AddressOf gridFatt_ViewCellFormatting
        AddHandler grid.CellFormatting, AddressOf gridFatt_CellFormatting
        AddHandler grid.ViewRowFormatting, AddressOf gridFatt_ViewRowFormatting
        'AddHandler gridAsset.CurrentRowChanged, AddressOf gridAsset_CurrentRowChanged

    End Sub

    Private Sub FrmImpiantoAssets_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmdConferma.ThemeName = "buttonBLU"
        cmdAnnulla.ThemeName = "buttonDFT"
        crea_griglia()
        async_carica_griglia()
    End Sub

    Private Async Sub async_carica_griglia()
        Try
            wbA.AssociatedControl = grid
            wbA.StartWaiting()
            wbA.Visible = True

            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella(codiceTabella)
            Await elementi

            carica_griglia(elementi.Result)

            wbA.StopWaiting()
            wbA.AssociatedControl = Nothing
            wbA.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            wbA.StopWaiting()
            wbA.AssociatedControl = Nothing
            wbA.Visible = False
        End Try
    End Sub

    Private Sub abilita_elementi(abilita As Boolean)
        Try
            cmdInsDett.Enabled = Not abilita
            cmdEliminaRiga.Enabled = Not abilita
            cmdModDett.Enabled = Not abilita
            grid.Enabled = Not abilita
            pnlDati.Visible = abilita

        Catch ex As Exception

        End Try
    End Sub

    Private Sub carica_griglia(elenco() As parmTabelle)
        Try

            grid.DataSource = elenco
            Me.HeaderText_ColumnGriglia()
            Me.HeaderText_Column_Griglia_width()

            Me.grid.MasterTemplate.ShowFilteringRow = False
            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
        End Try

    End Sub

    Private Sub crea_griglia()
        Try

            Me.grid.BeginEdit()
            'Me.gridasset.EnableFiltering = True
            'Me.gridAsset.MasterTemplate.ShowHeaderCellButtons = True
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

            Dim colCODELEM As New GridViewDecimalColumn
            colCODELEM.Name = "CODELEM"
            colCODELEM.DataType = GetType(String)
            colCODELEM.FieldName = "CODELEM"

            Dim colDESCR As New GridViewDecimalColumn
            colDESCR.Name = "DESELEM"
            colDESCR.DataType = GetType(String)
            colDESCR.FieldName = "DESELEM"

            'gridAsset.MasterTemplate.Columns.Add(commandColumn)
            'gridasset.MasterTemplate.Columns.Add(checkBoxColumn)
            grid.MasterTemplate.Columns.Add(colCODELEM)
            grid.MasterTemplate.Columns.Add(colDESCR)

            grid.TableElement.SearchHighlightColor = Color.LimeGreen

            Me.grid.EndEdit()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Crea griglia assets")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia()
        Try

            Me.grid.Columns("CODELEM").HeaderText = "Codice"
            Me.grid.Columns("DESELEM").HeaderText = "Descrizione"

            Me.grid.Columns("CODELEM").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("DESELEM").TextAlignment = ContentAlignment.MiddleLeft

            Me.grid.Columns("DESELEM").ReadOnly = True
            Me.grid.Columns("CODELEM").ReadOnly = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_Griglia_width()
        Try
            'Me.gridAsset.Columns("img").Width = 50
            Me.grid.Columns("CODELEM").Width = 90
            Me.grid.Columns("DESELEM").Width = 200

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub cmdModDett_Click(sender As Object, e As EventArgs) Handles cmdModDett.Click
        gAzione = "MODIFICA"
        abilita_elementi(True)
        Me.carica_dati()
    End Sub

    Private Sub carica_dati()
        Try
            Select Case gAzione
                Case Is = "NUOVO"
                    txtCodice.Text = ""
                    txtDescr.Text = ""

                Case Is = "MODIFICA"
                    If grid.Rows.Count > 0 Then
                        txtCodice.Text = grid.CurrentRow.Cells("CODELEM").Value
                        txtDescr.Text = grid.CurrentRow.Cells("DESELEM").Value
                    End If

            End Select


        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub cmdAnnulla_Click(sender As Object, e As EventArgs) Handles cmdAnnulla.Click
        abilita_elementi(False)
    End Sub

    Private Sub cmdConferma_Click(sender As Object, e As EventArgs) Handles cmdConferma.Click
        salva_dati()

    End Sub

    Private Sub cmdInsDett_Click(sender As Object, e As EventArgs) Handles cmdInsDett.Click
        gAzione = "NUOVO"
        carica_dati()
        abilita_elementi(True)
    End Sub


    Private Async Sub salva_dati()
        Try
            Dim test As String

            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            wbA.AssociatedControl = grid
            wbA.StartWaiting()
            wbA.Visible = True

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            Dim parms As New parmGetTabella
            parms.desElem = txtDescr.Text
            parms.codElemento = txtCodice.Text
            parms.codtabella = codiceTabella

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

            'Dim scI As New parmGetSchedaImpianto
            'scI = Newtonsoft.Json.JsonConvert.DeserializeObject(Of parmPostAssets)(parms)
            Dim postContent = jss.Serialize(parms)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = "https://localhost:44323/api/tabelle/saveTabelle/postSaveTabelle"

            client.DefaultRequestHeaders.Add("parmEntry", postContent)

            Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)

            abilita_elementi(False)

            wbA.StopWaiting()
            wbA.AssociatedControl = Nothing
            wbA.Visible = False

            async_carica_griglia()

        Catch EX As Exception
            wbA.StopWaiting()
            wbA.AssociatedControl = Nothing
            wbA.Visible = False
            MsgBox(EX.Message, vbCritical)
        End Try


    End Sub

#Region "******* EVENTI GRIGLIE *******************"
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
                    'e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local)
                    'e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                    e.CellElement.BackColor = Color.FromArgb(230, 230, 230)
                    e.CellElement.ForeColor = Color.Black
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
End Class
