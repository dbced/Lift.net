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
Public Class FrmImpiantoAssets
    Public categoria As String
    Public rtnAsset As New elencoAssetsImpianto
    Private ws As New webServices
    Private gAzione As String

    Public Sub New()
        InitializeComponent()
        WireEvents()
    End Sub

    Protected Sub WireEvents()

        AddHandler gridAsset.ContextMenuOpening, AddressOf gridFatt_ContextMenuOpening
        AddHandler gridAsset.ViewCellFormatting, AddressOf gridFatt_ViewCellFormatting
        AddHandler gridAsset.CellFormatting, AddressOf gridFatt_CellFormatting
        AddHandler gridAsset.ViewRowFormatting, AddressOf gridFatt_ViewRowFormatting
        'AddHandler gridAsset.CurrentRowChanged, AddressOf gridAsset_CurrentRowChanged

    End Sub

    Private Sub FrmImpiantoAssets_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmdConferma.ThemeName = "buttonBLU"
        cmdAnnulla.ThemeName = "buttonDFT"
        cmdOkSearchDiz.ThemeName = "buttonDFT"

        crea_griglia_assets()
        carica_combo_categorie()
        carica_combo_categorie_asset()
        async_carica_griglia_asset_impianto()
    End Sub

    Private Sub abilita_elementi(abilita As Boolean)
        Try
            cmdInsDett.Enabled = Not abilita
            cmdEliminaRiga.Enabled = Not abilita
            cmdModDett.Enabled = Not abilita
            gridAsset.Enabled = Not abilita
            pnlDati.Visible = abilita

        Catch ex As Exception

        End Try
    End Sub
    Private Async Sub carica_combo_categorie()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("CCI", "")
            Await elementi

            Me.cmbMacroCat.DataSource = elementi.Result
            Me.cmbMacroCat.DisplayMember = "desElem"
            Me.cmbMacroCat.ValueMember = "codElem"
            Me.cmbMacroCat.SelectedIndex = -1

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_categorie_asset()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("CATASSET", "")
            Await elementi

            Me.cmbCategoria.DataSource = elementi.Result
            Me.cmbCategoria.DisplayMember = "desElem"
            Me.cmbCategoria.ValueMember = "codElem"
            Me.cmbCategoria.SelectedIndex = -1

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub async_carica_griglia_asset_impianto()
        Try
            wbA.AssociatedControl = gridAsset
            wbA.StartWaiting()
            wbA.Visible = True

            Dim elementi As Threading.Tasks.Task(Of elencoAssetsImpianto())
            elementi = ws.carica_lista_assets(categoria)
            Await elementi

            carica_griglia_assets_impianto(elementi.Result)

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

    Private Sub carica_griglia_assets_impianto(elelncoAssets() As elencoAssetsImpianto)
        Try

            gridAsset.DataSource = elelncoAssets
            Me.HeaderText_ColumnGriglia_assets()
            Me.HeaderText_Column_Griglia_assets_width()

            Me.gridAsset.MasterTemplate.ShowFilteringRow = False
            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
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

            Dim colCHDESCR As New GridViewTextBoxColumn
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

            Dim colDESCRCAT As New GridViewTextBoxColumn
            colDESCRCAT.Name = "DESCRCAT"
            colDESCRCAT.DataType = GetType(String)
            colDESCRCAT.FieldName = "DESCRCAT"

            Dim colDESCRMCAT As New GridViewTextBoxColumn
            colDESCRMCAT.Name = "DESCRMACROCAT"
            colDESCRMCAT.DataType = GetType(String)
            colDESCRMCAT.FieldName = "DESCRMACROCAT"

            Dim colCODCATASSET As New GridViewTextBoxColumn
            colCODCATASSET.Name = "CODCATASSET"
            colCODCATASSET.DataType = GetType(String)
            colCODCATASSET.FieldName = "CODCATASSET"

            Dim colFLPIANIFICA As New GridViewTextBoxColumn
            colFLPIANIFICA.Name = "FLAGPIANIFICA"
            colFLPIANIFICA.DataType = GetType(String)
            colFLPIANIFICA.FieldName = "FLAGPIANIFICA"

            'gridAsset.MasterTemplate.Columns.Add(commandColumn)
            'gridasset.MasterTemplate.Columns.Add(checkBoxColumn)
            gridAsset.MasterTemplate.Columns.Add(colCHID)
            gridAsset.MasterTemplate.Columns.Add(colCHDESCR)
            gridAsset.MasterTemplate.Columns.Add(colNUMCHL)
            gridAsset.MasterTemplate.Columns.Add(colCHCDCAT)
            gridAsset.MasterTemplate.Columns.Add(colCDIMP)
            gridAsset.MasterTemplate.Columns.Add(colDESCRCAT)
            gridAsset.MasterTemplate.Columns.Add(colDESCRMCAT)
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

    Private Sub HeaderText_ColumnGriglia_assets()
        Try

            Me.gridAsset.Columns("CHID").HeaderText = "Id"
            Me.gridAsset.Columns("CHDESCR").HeaderText = "Descrizione Asset"
            Me.gridAsset.Columns("NUMCHL").HeaderText = "N. Assets"
            Me.gridAsset.Columns("DESCRCAT").HeaderText = "Categoria"
            Me.gridAsset.Columns("DESCRMACROCAT").HeaderText = "Macro Categoria"
            Me.gridAsset.Columns("FLAGPIANIFICA").HeaderText = "Pianifica"

            Me.gridAsset.Columns("NUMCHL").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridAsset.Columns("CHID").TextAlignment = ContentAlignment.MiddleCenter
            Me.gridAsset.Columns("CHDESCR").TextAlignment = ContentAlignment.MiddleLeft
            Me.gridAsset.Columns("FLAGPIANIFICA").TextAlignment = ContentAlignment.MiddleCenter

            Me.gridAsset.Columns("CHCDCAT").IsVisible = False
            Me.gridAsset.Columns("CDIMP").IsVisible = False
            Me.gridAsset.Columns("NUMCHL").IsVisible = False
            Me.gridAsset.Columns("CODCATASSET").IsVisible = False

            Me.gridAsset.Columns("CHDESCR").ReadOnly = True
            Me.gridAsset.Columns("NUMCHL").ReadOnly = True
            Me.gridAsset.Columns("CHID").ReadOnly = True
            Me.gridAsset.Columns("DESCRCAT").ReadOnly = True
            Me.gridAsset.Columns("DESCRMACROCAT").ReadOnly = True
            Me.gridAsset.Columns("FLAGPIANIFICA").ReadOnly = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_Griglia_assets_width()
        Try
            'Me.gridAsset.Columns("img").Width = 50
            Me.gridAsset.Columns("CHDESCR").Width = 150
            Me.gridAsset.Columns("DESCRCAT").Width = 120
            Me.gridAsset.Columns("DESCRMACROCAT").Width = 150
            Me.gridAsset.Columns("CHID").Width = 80
            Me.gridAsset.Columns("FLAGPIANIFICA").Width = 100
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
                    cmbMacroCat.SelectedIndex = -1
                    cmbCategoria.SelectedIndex = -1
                    chkPian.Checked = False

                Case Is = "MODIFICA"
                    If gridAsset.Rows.Count > 0 Then
                        txtCodice.Text = gridAsset.CurrentRow.Cells("CHID").Value
                        txtDescr.Text = gridAsset.CurrentRow.Cells("CHDESCR").Value
                        cmbMacroCat.SelectedValue = gridAsset.CurrentRow.Cells("CHCDCAT").Value
                        cmbCategoria.SelectedValue = gridAsset.CurrentRow.Cells("CODCATASSET").Value
                        chkPian.Checked = IIf(gridAsset.CurrentRow.Cells("FLAGPIANIFICA").Value = "N", False, True)
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

            wbA.AssociatedControl = gridAsset
            wbA.StartWaiting()
            wbA.Visible = True

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            Dim parms As New parmPostAssets
            parms.azione = gAzione
            parms.CHDESCR = txtDescr.Text
            parms.CHCDCAT = cmbMacroCat.SelectedValue
            parms.CodCatAsset = cmbCategoria.SelectedValue
            parms.NUMASSETS = 0
            parms.CODIMP = ""
            parms.flagPianifica = IIf(chkPian.Checked = False, "N", "S")

            If gAzione = "NUOVO" Then
                parms.CHID = 0
            Else
                parms.CHID = Val(txtCodice.Text)
            End If

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

            'Dim scI As New parmGetSchedaImpianto
            'scI = Newtonsoft.Json.JsonConvert.DeserializeObject(Of parmPostAssets)(parms)
            Dim postContent = jss.Serialize(parms)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = My.Settings.urlWS & "api/impianti/saveAsset/postAsset" & "?paramList=1234"
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("parmEntry", postContent)

            Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)

            abilita_elementi(False)

            wbA.StopWaiting()
            wbA.AssociatedControl = Nothing
            wbA.Visible = False

            async_carica_griglia_asset_impianto()

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
                If gridAsset.FilterDescriptors.Expression.ToString.ToUpper.Contains(e.CellElement.ColumnInfo.Name) Then
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

    Private Sub gridAsset_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles gridAsset.CellDoubleClick
        Try

            rtnAsset.CHID = gridAsset.CurrentRow.Cells("CHID").Value
            rtnAsset.CHDESCR = gridAsset.CurrentRow.Cells("CHDESCR").Value
            rtnAsset.CHCDCAT = gridAsset.CurrentRow.Cells("CHCDCAT").Value
            rtnAsset.CodCatAsset = gridAsset.CurrentRow.Cells("CODCATASSET").Value
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Dim frm As New FrmTabelle("GRUPPI")
        frm.ShowDialog()
    End Sub

#End Region

End Class
