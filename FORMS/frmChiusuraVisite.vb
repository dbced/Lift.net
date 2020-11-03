Imports System.Net
Imports System.Text
Imports System.Web.Script.Serialization
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class FrmChiusuraVisite
    Private ws As New webServices
    Private statoCaricaGriglia As Boolean

    Private Sub FrmChiusuraVisite_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonDFT.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonBLU.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonRED.tssp")

            cmdAnnulla.ThemeName = "buttonDFT"
            cmdOkSearchImp.ThemeName = "buttonDFT"
            cmdConferma.ThemeName = "buttonRED"

            Me.txtData.Format = DateTimePickerFormat.[Custom]
            Me.txtData.CustomFormat = "dd/MM/yyyy"
            Me.txtData.Value = Now.Date
            'TryCast(Me.txtData.DateTimePickerElement.CurrentBehavior, RadDateTimePickerCalendar).ShowTimePicker = True
            'TryCast(Me.txtData.DateTimePickerElement.CurrentBehavior, RadDateTimePickerCalendar).DropDownMinSize = New Size(330, 250)

            'statoCaricaTipoVisita = False
            statoCaricaGriglia = False

            wbG.AssociatedControl = Me
            wbG.StartWaiting()
            wbG.Visible = True

            Me.crea_griglia()

            t1.Enabled = True

        Catch ex As Exception

        End Try

    End Sub

    Private Sub t1_Tick(sender As Object, e As EventArgs) Handles t1.Tick
        Try

            If (statoCaricaGriglia = True) Then

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
            Dim dataChiDal As String
            Dim dataChiAl As String

            codSoc = "MT"
            codCen = "E14"
            dataIni = IIf(IsDate(txtData.Value), txtData.Value, "")
            dataFine = IIf(IsDate(txtData.Value), txtData.Value, "")
            dataChiDal = "01/01/0001"
            dataChiAl = "01/01/0001"

            async_carica_manutenzioni(codimp, codSoc, codCen, codcli, Matricola, dataIni, dataFine, Descrizione, IdSquadra, dataChiDal, dataChiAl)

        Catch ex As Exception
            Telerik.WinControls.RadMessageBox.Show(Me, ex.Message, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Async Sub async_carica_manutenzioni(codImp As String, codSoc As String, codCen As String, codCli As String,
                                                      Optional Matricola As String = "", Optional DataIni As String = "",
                                                      Optional DataFine As String = "", Optional Descr As String = "",
                                                      Optional IdSquadra As String = "", Optional DataChiDal As String = "",
                                                      Optional DataChiAl As String = "")
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoManutenzioni))
            elementi = ws.getManutenzioniElenco(codImp, codSoc, codCen, codCli, Matricola, DataIni, DataFine, Descr,, IdSquadra, DataChiDal, DataChiAl)
            Await elementi

            Me.carica_visite(elementi.Result)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub carica_visite(dati As List(Of elencoManutenzioni))
        Try
            Me.carica_griglia(dati)
            statoCaricaGriglia = True
        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
        End Try

    End Sub

    Private Sub cmdOkSearchImp_Click(sender As Object, e As EventArgs) Handles cmdOkSearchImp.Click
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            If IsDate(txtData.Value) = False Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Nessuna data selezionata", "Chiusura visite", MessageBoxButtons.OK, RadMessageIcon.Error)
                txtData.Focus()
                Exit Sub
            End If

            statoCaricaGriglia = False

            wbG.AssociatedControl = Me
            wbG.StartWaiting()
            wbG.Visible = True

            t1.Enabled = True

            Me.carica_dati_form()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmChiusuraVisite_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Me.carica_dati_form()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub crea_griglia()
        Try

            Me.grid.BeginEdit()
            Me.grid.EnableFiltering = False
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

            'checkbox colum -------------------------------------------------
            Dim checkBoxColumn As New GridViewCheckBoxColumn()
            checkBoxColumn.DataType = GetType(Integer)
            checkBoxColumn.Name = "CHECK"
            checkBoxColumn.FieldName = "CHECK"
            checkBoxColumn.HeaderText = " "
            checkBoxColumn.Width = 50
            checkBoxColumn.IsPinned = True
            checkBoxColumn.EditMode = EditMode.OnValueChange
            'checkBoxColumn.Checked = False
            checkBoxColumn.EnableHeaderCheckBox = True
            '----------------------------------------------------------------

            Dim colId As New GridViewDecimalColumn
            colId.Name = "id"
            colId.DataType = GetType(Integer)
            colId.FieldName = "id"

            Dim colImpianto As New GridViewTextBoxColumn
            colImpianto.Name = "CodImpianto"
            colImpianto.DataType = GetType(String)
            colImpianto.FieldName = "CodImpianto"

            Dim colDesImp As New GridViewTextBoxColumn
            colDesImp.Name = "DescrImpianto"
            colDesImp.DataType = GetType(String)
            colDesImp.FieldName = "DescrImpianto"


            Dim colDataini As New GridViewDateTimeColumn
            colDataini.Name = "DataInizio"
            colDataini.DataType = GetType(System.DateTime)
            colDataini.FieldName = "DataInizio"
            colDataini.FormatString = "{0:dd/MM/yyyy}"
            colDataini.CustomFormat = "dd/MM/yyyy"

            Dim colDataEff As New GridViewDateTimeColumn
            colDataEff.Name = "DataEffett"
            colDataEff.DataType = GetType(System.DateTime)
            colDataEff.FieldName = "DataEffett"
            colDataEff.FormatString = "{0:dd/MM/yyyy}"
            colDataEff.CustomFormat = "dd/MM/yyyy"


            Dim colTipoVis As New GridViewTextBoxColumn
            colTipoVis.Name = "tipoVisita"
            colTipoVis.DataType = GetType(String)
            colTipoVis.FieldName = "tipoVisita"

            Dim colDesTipo As New GridViewTextBoxColumn
            colDesTipo.Name = "DescrMan"
            colDesTipo.DataType = GetType(String)
            colDesTipo.FieldName = "DescrMan"


            'grid.MasterTemplate.Columns.Add(commandColumn)

            grid.MasterTemplate.Columns.Add(checkBoxColumn)
            grid.MasterTemplate.Columns.Add(colId)
            grid.MasterTemplate.Columns.Add(colImpianto)
            grid.MasterTemplate.Columns.Add(colDesImp)
            grid.MasterTemplate.Columns.Add(colTipoVis)
            grid.MasterTemplate.Columns.Add(colDesTipo)
            grid.MasterTemplate.Columns.Add(colDataini)
            grid.MasterTemplate.Columns.Add(colDataEff)

            grid.TableElement.SearchHighlightColor = Color.LimeGreen

            Me.grid.Columns("Check").AllowFiltering = False
            'Me.grid.Columns("Mod").AllowFiltering = False


            Me.grid.EndEdit()

            grid.AllowSearchRow = False

            Me.LoadSummary()
            grid.MasterView.SummaryRows(0).PinPosition = PinnedRowPosition.Bottom


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_ColumnGriglia_width()
        Try
            'Me.gridLog.Columns("DescrLog").Width = 800
            'Me.gridLog.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill
            Me.grid.Columns("DataInizio").Width = 90
            Me.grid.Columns("DataEffett").Width = 110
            Me.grid.Columns("DescrMan").Width = 120
            Me.grid.Columns("DEscrImpianto").Width = 350

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub carica_griglia(dati As List(Of elencoManutenzioni))
        Try

            grid.DataSource = dati
            Me.HeaderText_ColumnGriglia(grid)
            Me.HeaderText_ColumnGriglia_width()
            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
        End Try

    End Sub

    Private Sub HeaderText_ColumnGriglia(griglia As RadGridView)
        Try
            griglia.Columns("DescrImpianto").HeaderText = "Impianto"
            griglia.Columns("DescrMan").HeaderText = "tipo visita"
            griglia.Columns("DataInizio").HeaderText = "Data visita"
            griglia.Columns("DataEffett").HeaderText = "Data chiusura"

            griglia.Columns("DataInizio").TextAlignment = ContentAlignment.MiddleCenter
            griglia.Columns("DataEffett").TextAlignment = ContentAlignment.MiddleCenter

            For i = 0 To griglia.Columns.Count - 1
                griglia.Columns(i).ReadOnly = True
                griglia.Columns(i).IsVisible = False
            Next

            griglia.Columns("DataInizio").IsVisible = True
            griglia.Columns("DataEffett").IsVisible = True
            griglia.Columns("DescrMan").IsVisible = True
            griglia.Columns("DescrImpianto").IsVisible = True
            griglia.Columns("check").IsVisible = True
            griglia.Columns("check").ReadOnly = False

            'griglia.Columns("DataInizio").FormatString = "{0:dd/MM/yyyy}"
            'griglia.Columns("DataEffett").FormatString = "{0:dd/MM/yyyy}"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Errore")
        End Try
    End Sub

    Private Sub grid_ContextMenuOpening(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.ContextMenuOpeningEventArgs) Handles grid.ContextMenuOpening
        e.Cancel = True
    End Sub

    Private Sub grid_CellFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grid.CellFormatting
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

            ElseIf e.CellElement.ColumnInfo.Name.ToUpper = "DATAEFFETT" Then
                'If Not IsNothing(e.CellElement.Text) AndAlso e.CellElement.Text <> "" Then

                '    If Year(CDate(e.CellElement.Text)) = 1 Then
                '        e.CellElement.ForeColor = e.CellElement.BackColor
                '    Else
                '        e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                '    End If
                'End If
            Else
                e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local)
                e.CellElement.Image = Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub grid_ViewRowFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.RowFormattingEventArgs) Handles grid.ViewRowFormatting

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

    Private Sub grid_ValueChanging(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.ValueChangingEventArgs) Handles grid.ValueChanging
        Try
            If TypeOf sender Is GridViewCellInfo Then
                Dim Row As GridViewCellInfo = sender
                Dim lastRow As GridViewRowInfo = Row.RowInfo

                'If resetFlags Then Exit Sub

                Dim cell As GridViewCellInfo = lastRow.Cells("CHECK")

                If cell.ColumnInfo.GetType().Equals(GetType(GridViewCheckBoxColumn)) Then
                    If IsDate(lastRow.Cells("DataEffett").Value) Then
                        If Year(CDate(lastRow.Cells("DataEffett").Value)) <> 1 Then
                            e.Cancel = True
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Chiusura visite")
        End Try
    End Sub


    Private Sub grid_Click(sender As Object, e As EventArgs) Handles grid.Click

    End Sub

    Private Sub grid_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles grid.CellDoubleClick
        Try
            If e.Column.Name.ToUpper = "DESCRIMPIANTO" Then
                Dim rowInfo As GridViewRowInfo = e.Row

                If Not IsNothing(rowInfo) Then
                    Dim id As Integer = rowInfo.Cells("ID").Value
                    Dim frm As New FrmGestVisitaBeta
                    frm.iniID = id
                    frm.iniAzione = "MODIFICA"
                    frm.ShowDialog()

                    statoCaricaGriglia = False

                    wbG.AssociatedControl = Me
                    wbG.StartWaiting()
                    wbG.Visible = True

                    t1.Enabled = True

                    Me.carica_dati_form()

                Else
                    RadMessageBox.Show("Nessun dato da visualizzare.", "Visita", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub chiudi_visite_db()
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

            Dim parms As List(Of elencoChiusureVis) = New List(Of elencoChiusureVis)()

            For Each row As GridViewRowInfo In grid.Rows
                Dim item As New elencoChiusureVis
                If row.Cells("CHECK").Value = 1 Then
                    item.id = row.Cells("ID").Value
                    item.dataChiusura = Now.Date
                    parms.Add(item)
                End If
            Next

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim postContent = jss.Serialize(parms)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = My.Settings.urlWS & "api/visite/postChiudiVisite/postChiudiVisite"
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("parmElencoChiusure", postContent)


            Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)

            wbG.StopWaiting()
            wbG.AssociatedControl = Nothing
            wbG.Visible = False

            Dim sStatusCode As String = postResponse.StatusCode.ToString

            If sStatusCode.ToUpper <> "OK" Then
                Dim msg As String = postResponse.Headers.GetValues("Error").FirstOrDefault()

                Telerik.WinControls.RadMessageBox.Show(Me, "Operazione non effettuata. " & vbCrLf & "Causa: " & msg, "Chiusura visite", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Telerik.WinControls.RadMessageBox.Show(Me, "Operazione effettuata", "Chiusura visite", MessageBoxButtons.OK, RadMessageIcon.Info)

                statoCaricaGriglia = False

                wbG.AssociatedControl = Me
                wbG.StartWaiting()
                wbG.Visible = True

                t1.Enabled = True

                Me.carica_dati_form()
            End If

        Catch EX As Exception
            wbG.StopWaiting()
            wbG.AssociatedControl = Nothing
            wbG.Visible = False
            Telerik.WinControls.RadMessageBox.Show(Me, "Errore", "Errore", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Sub cmdConferma_Click(sender As Object, e As EventArgs) Handles cmdConferma.Click
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")
        Dim dr As DialogResult = RadMessageBox.Show("Chiudere le visite?", "Chiusura visite", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If dr = DialogResult.No Then
            Exit Sub
        End If

        chiudi_visite_db()
    End Sub

    Private Sub cmdAnnulla_Click(sender As Object, e As EventArgs) Handles cmdAnnulla.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub LoadSummary()
        Try

            Me.grid.MasterTemplate.SummaryRowsBottom.Clear()
            Dim item1 As New GridViewSummaryRowItem()
            item1.Add(New GridViewSummaryItem("DataInizio", "{0:F0}", GridAggregateFunction.Count))

            Me.grid.MasterTemplate.SummaryRowsBottom.Add(item1)
            grid.MasterTemplate.ShowTotals = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Chiusura")
        End Try

    End Sub
End Class
