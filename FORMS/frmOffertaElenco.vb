Imports System.ComponentModel
Imports System.Globalization
Imports System.Net
Imports System.Threading
Imports System.Web.Script.Serialization
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class FrmOffertaElenco
    Private gElencoCentri As String = ""
    Private user As String
    Private ruolo As String
    Private userAS As String
    Private ws As New webServices
    Private modalForm As String

    Dim statoCaricaSoc As Boolean
    Dim statoCaricaCentri As Boolean
    'Dim statoCaricaGriglia As Boolean
    Dim formInCaricamento As Boolean
    Dim grigliaCreata As Boolean
    Dim azione As String

    Public Sub New(ByVal Menu As Telerik.WinControls.UI.RadForm, Optional ByVal ElencoCentri As String = "", Optional ByVal inUser As String = "", Optional ByVal inRuolo As String = "", Optional ByVal inUserAS As String = "", Optional modal As String = "")
        InitializeComponent()
        WireEvents()
        ruolo = inRuolo
        user = inUser
        userAS = inUserAS
        gElencoCentri = ElencoCentri
        modalForm = modal
    End Sub

    Protected Sub WireEvents()
        AddHandler grid.ViewCellFormatting, AddressOf gridFatt_ViewCellFormatting
        AddHandler grid.ViewRowFormatting, AddressOf gridFatt_ViewRowFormatting
        AddHandler grid.CellFormatting, AddressOf gridFatt_CellFormatting
        AddHandler grid.ContextMenuOpening, AddressOf gridFatt_ContextMenuOpening
        'AddHandler grid.CreateCell, AddressOf grid_CreateCell
        AddHandler grid.ValueChanging, AddressOf grid_ValueChanging
    End Sub
    Private Sub FrmOffertaElenco_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonDFT.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonBLU.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonRED.tssp")

            cmdAllSoc.ThemeName = "buttonDFT"
            cmdSelAllCentri.ThemeName = "buttonDFT"
            cmdFiltro.ThemeName = "buttonDFT"

            grigliaCreata = False

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True
            t1.Enabled = True
            formInCaricamento = True
            'Me.inizializza_background()

            If modalForm = "RICERCA" Then
                cmdBar.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub t1_Tick(sender As Object, e As EventArgs) Handles t1.Tick
        Try
            If statoCaricaSoc = True And statoCaricaCentri = True Then
                Aggiorna_dash()
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

    Private Async Sub Aggiorna_dash()
        Dim dash As Threading.Tasks.Task(Of List(Of Integer))
        Dim x As New parmsOfferte
        If cmbCentro.CheckedItems.Count > 0 Then
            x.parmCen = New List(Of centri)
            For Each el As RadListDataItem In cmbCentro.CheckedItems
                Dim cen As New centri
                cen.Centro = el.Text
                x.parmCen.Add(cen)
            Next
        End If
        If cmbSoc.CheckedItems.Count > 0 Then
            x.parmSoc = New List(Of societa)
            For Each el As RadListDataItem In cmbSoc.CheckedItems
                Dim soc As New societa
                soc.societa = el.Value
                x.parmSoc.Add(soc)
            Next
        End If
        dash = ws.getDashOfferta(x)
        Await dash
        Dim DashOff As List(Of Integer) = dash.Result
        num_al_vaglio.Text = String.Format("{0:N0}", DashOff(0))
        num_accettate.Text = String.Format("{0:N0}", DashOff(1))
        num_in_sblocco.Text = String.Format("{0:N0}", DashOff(2))
        num_annullate.Text = String.Format("{0:N0}", DashOff(3))
    End Sub

    Private Async Sub carica_combo_soc()
        Try
            Dim filtro As String = ""


            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("RELSOC", "", filtro)
            Await elementi

            Me.cmbSoc.DataSource = elementi.Result
            Me.cmbSoc.DisplayMember = "desElem"
            Me.cmbSoc.ValueMember = "codElem"
            Me.cmbSoc.SelectedIndex = -1
            Me.cmbSoc.Tag = "0"
            statoCaricaSoc = True

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
            elementi = ws.getDatiTabella("RELCEN", "", filtro)
            Await elementi

            Me.cmbCentro.DataSource = elementi.Result
            Me.cmbCentro.DisplayMember = "codElem"
            Me.cmbCentro.ValueMember = "codElem"
            Me.cmbCentro.SelectedIndex = -1
            Me.cmbCentro.Tag = "0"

            statoCaricaCentri = True

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_stato()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("OFFSTATO", "")
            Await elementi

            Me.cmbStato.DataSource = elementi.Result
            Me.cmbStato.DisplayMember = "desElem"
            Me.cmbStato.ValueMember = "codElem"
            Me.cmbStato.SelectedIndex = -1
            Me.cmbStato.Tag = "0"

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub cmdFiltro_Click(sender As Object, e As EventArgs) Handles cmdFiltro.Click
        Try
            Dim parms As New parmsOfferte
            'Dim listSoc As New List(Of societa)
            'Dim listCentri As New List(Of centri)
            'Dim listStat As New List(Of String)
            parms.parmSoc = New List(Of societa)
            parms.parmCen = New List(Of centri)
            parms.parmStat = New List(Of String)
            Dim codImpianto As String = ""

            If grigliaCreata = False Then
                Me.crea_griglia_offerte()
            End If

            For Each el As RadListDataItem In cmbSoc.CheckedItems
                Dim soc As New societa
                soc.societa = el.Value
                parms.parmSoc.Add(soc)
            Next
            For Each el As RadListDataItem In cmbCentro.CheckedItems
                Dim cen As New centri
                cen.Centro = el.Text
                parms.parmCen.Add(cen)
            Next

            For Each el As RadListDataItem In cmbStato.CheckedItems
                parms.parmStat.Add(el.Value)
            Next

            If txtNum.Text <> "0" Then
                parms.parmProgOff = txtNum.Text
            End If

            If txtAnno.Text <> "0" Then
                parms.parmAnnoOff = txtAnno.Text
            End If

            'parms.parmSoc = listSoc
            'parms.parmCen = listCentri

            Me.async_carica_griglia_offerte(parms)

        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub async_carica_griglia_offerte(parms As parmsOfferte)
        Try
            If formInCaricamento = False Then
                wb.AssociatedControl = Me
                wb.StartWaiting()
                wb.Visible = True
            End If

            Dim elementi As Threading.Tasks.Task(Of List(Of Offerta))
            elementi = ws.getElencoOfferte(parms)
            Await elementi

            carica_griglia_offerte(elementi.Result)

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

    Private Sub carica_griglia_offerte(dati As List(Of Offerta))
        Try

            grid.DataSource = dati
            Me.HeaderText_ColumnGriglia_offerte()
            Me.HeaderText_Column_Grigliaofferte_width()

            Me.grid.MasterTemplate.ShowFilteringRow = False

            Application.CurrentCulture = New System.Globalization.CultureInfo("it-IT")

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
        End Try

    End Sub

    Private Sub HeaderText_ColumnGriglia_offerte()
        Try
            Me.grid.Columns("B1CENTRO").HeaderText = "Centro"
            Me.grid.Columns("B1SOCMDB").HeaderText = "Società"
            Me.grid.Columns("B1IDOFF").HeaderText = "Id Offerta"
            Me.grid.Columns("B1PROGR").HeaderText = "Progressivo Offerta"
            Me.grid.Columns("B1AAOFF").HeaderText = "Anno Offerta"
            Me.grid.Columns("B1DTOFF").HeaderText = "Data Offerta"
            Me.grid.Columns("B1STATOFF").HeaderText = "Stato Offerta"
            Me.grid.Columns("AICLI").HeaderText = "Codice Cliente"
            Me.grid.Columns("B1CODORIG").HeaderText = "Codice Origine"
            Me.grid.Columns("B1CODCOMM").HeaderText = "Codice Commessa"
            Me.grid.Columns("B1TOTDOC").HeaderText = "Importo"
            Me.grid.Columns("B1DTACC").HeaderText = "Data Accettazione"
            Me.grid.Columns("B1CODIMP").HeaderText = "Codice Impianto"
            Me.grid.Columns("TIPOIMP").HeaderText = "Tipo Impianto"
            Me.grid.Columns("AFRAG").HeaderText = "Commerciale"
            Me.grid.Columns("B1IDBUO").HeaderText = "ID Buono"
            Me.grid.Columns("B1RISORSA").HeaderText = "Risorsa"
            Me.grid.Columns("Subappaltatore").HeaderText = "Subappaltatore"


            'Me.grid.Columns("A7SOCMDB").TextAlignment = ContentAlignment.MiddleCenter
            'Me.grid.Columns("A7CENMDB").TextAlignment = ContentAlignment.MiddleCenter
            'Me.grid.Columns("A7IDCHIA").TextAlignment = ContentAlignment.MiddleLeft
            'Me.grid.Columns("A7CODIMP").TextAlignment = ContentAlignment.MiddleCenter
            'Me.grid.Columns("A7CODTEC").TextAlignment = ContentAlignment.MiddleCenter
            'Me.grid.Columns("A7STATOC").TextAlignment = ContentAlignment.MiddleCenter

            For Each col In Me.grid.Columns
                col.ReadOnly = True
                col.IsVisible = False
            Next

            Me.grid.Columns("B1CENTRO").IsVisible = True
            Me.grid.Columns("B1SOCMDB").IsVisible = True
            Me.grid.Columns("B1IDOFF").IsVisible = True
            Me.grid.Columns("B1PROGR").IsVisible = True
            Me.grid.Columns("B1AAOFF").IsVisible = True
            Me.grid.Columns("B1DTOFF").IsVisible = True
            Me.grid.Columns("B1STATOFF").IsVisible = True
            Me.grid.Columns("AICLI").IsVisible = True
            Me.grid.Columns("B1CODORIG").IsVisible = True
            Me.grid.Columns("B1CODCOMM").IsVisible = True
            Me.grid.Columns("B1TOTDOC").IsVisible = True
            Me.grid.Columns("B1DTACC").IsVisible = True
            Me.grid.Columns("B1CODIMP").IsVisible = True
            Me.grid.Columns("TIPOIMP").IsVisible = True
            Me.grid.Columns("AFRAG").IsVisible = True
            Me.grid.Columns("B1IDBUO").IsVisible = True
            Me.grid.Columns("B1RISORSA").IsVisible = True
            Me.grid.Columns("Subappaltatore").IsVisible = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub HeaderText_Column_Grigliaofferte_width()
        Try
            Me.grid.Columns("B1CENTRO").Width = 50
            Me.grid.Columns("B1SOCMDB").Width = 55
            Me.grid.Columns("B1IDOFF").Width = 68
            Me.grid.Columns("B1PROGR").Width = 92
            Me.grid.Columns("B1AAOFF").Width = 63
            Me.grid.Columns("B1DTOFF").Width = 88
            Me.grid.Columns("B1STATOFF").Width = 91
            Me.grid.Columns("AICLI").Width = 71
            Me.grid.Columns("B1CODORIG").Width = 250
            Me.grid.Columns("B1CODCOMM").Width = 125
            Me.grid.Columns("B1TOTDOC").Width = 85
            Me.grid.Columns("B1DTACC").Width = 95
            Me.grid.Columns("B1CODIMP").Width = 82
            Me.grid.Columns("TIPOIMP").Width = 135
            Me.grid.Columns("AFRAG").Width = 90
            Me.grid.Columns("B1IDBUO").Width = 64
            Me.grid.Columns("B1RISORSA").Width = 56
            Me.grid.Columns("Subappaltatore").Width = 102

            Me.grid.Columns("B1DTOFF").FormatString = "{0:dd/MM/yyyy}"
            Me.grid.Columns("B1DTOFF").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("B1DTACC").FormatString = "{0:dd/MM/yyyy}"
            Me.grid.Columns("B1DTACC").TextAlignment = ContentAlignment.MiddleCenter
            Me.grid.Columns("B1TOTDOC").FormatString = "{0:c2}"
            Me.grid.Columns("B1TOTDOC").NullValue = 0
            'Me.grid.Columns("A7TSCHIU").FormatString = "{0:dd/MM/yyyy}"
            'Me.grid.Columns("A7STATOC").FormatString = "{0:dd/MM/yyyy}"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "RECUBE")
        End Try
    End Sub

    Private Sub crea_griglia_offerte()
        Try
            'Me.LoadSummaryCanoni()

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

            Dim B1CENTRO As New GridViewTextBoxColumn
            Dim B1SOCMDB As New GridViewTextBoxColumn
            Dim B1IDOFF As New GridViewDecimalColumn
            Dim B1PROGR As New GridViewDecimalColumn
            Dim B1AAOFF As New GridViewDecimalColumn
            Dim B1DTOFF As New GridViewDateTimeColumn
            Dim B1STATOFF As New GridViewTextBoxColumn
            Dim AICLI As New GridViewTextBoxColumn
            Dim B1CODORIG As New GridViewTextBoxColumn
            Dim B1CODCOMM As New GridViewTextBoxColumn
            Dim B1TOTDOC As New GridViewDecimalColumn
            Dim B1DTACC As New GridViewDateTimeColumn
            Dim B1CODIMP As New GridViewDecimalColumn
            Dim TIPOIMP As New GridViewTextBoxColumn
            Dim AFRAG As New GridViewTextBoxColumn
            Dim B1IDBUO As New GridViewDecimalColumn
            Dim B1RISORSA As New GridViewTextBoxColumn
            Dim Subappaltatore As New GridViewTextBoxColumn

            B1CENTRO.Name = "B1CENTRO"
            B1SOCMDB.Name = "B1SOCMDB"
            B1IDOFF.Name = "B1IDOFF"
            B1PROGR.Name = "B1PROGR"
            B1AAOFF.Name = "B1AAOFF"
            B1DTOFF.Name = "B1DTOFF"
            B1STATOFF.Name = "B1STATOFF"
            AICLI.Name = "AICLI"
            B1CODORIG.Name = "B1CODORIG"
            B1CODCOMM.Name = "B1CODCOMM"
            B1TOTDOC.Name = "B1TOTDOC"
            B1DTACC.Name = "B1DTACC"
            B1CODIMP.Name = "B1CODIMP"
            TIPOIMP.Name = "TIPOIMP"
            AFRAG.Name = "AFRAG"
            B1IDBUO.Name = "B1IDBUO"
            B1RISORSA.Name = "B1RISORSA"
            Subappaltatore.Name = "Subappaltatore"

            B1CENTRO.DataType = GetType(String)
            B1SOCMDB.DataType = GetType(String)
            B1IDOFF.DataType = GetType(Long)
            B1PROGR.DataType = GetType(Long)
            B1AAOFF.DataType = GetType(Integer)
            B1DTOFF.DataType = GetType(Date)
            B1STATOFF.DataType = GetType(String)
            AICLI.DataType = GetType(Long)
            B1CODORIG.DataType = GetType(String)
            B1CODCOMM.DataType = GetType(String)
            B1TOTDOC.DataType = GetType(Double)
            B1DTACC.DataType = GetType(Date)
            B1CODIMP.DataType = GetType(String)
            TIPOIMP.DataType = GetType(String)
            AFRAG.DataType = GetType(String)
            B1IDBUO.DataType = GetType(Long)
            B1RISORSA.DataType = GetType(String)
            Subappaltatore.DataType = GetType(String)


            B1CENTRO.FieldName = "B1CENTRO"
            B1SOCMDB.FieldName = "B1SOCMDB"
            B1IDOFF.FieldName = "B1IDOFF"
            B1PROGR.FieldName = "B1PROGR"
            B1AAOFF.FieldName = "B1AAOFF"
            B1DTOFF.FieldName = "B1DTOFF"
            B1STATOFF.FieldName = "B1STATOFF"
            AICLI.FieldName = "AICLI"
            B1CODORIG.FieldName = "B1CODORIG"
            B1CODCOMM.FieldName = "B1CODCOMM"
            B1TOTDOC.FieldName = "B1TOTDOC"
            B1DTACC.FieldName = "B1DTACC"
            B1CODIMP.FieldName = "B1CODIMP"
            TIPOIMP.FieldName = "TIPOIMP"
            AFRAG.FieldName = "AFRAG"
            B1IDBUO.FieldName = "B1IDBUO"
            B1RISORSA.FieldName = "B1RISORSA"
            Subappaltatore.FieldName = "Subappaltatore"

            grid.MasterTemplate.Columns.Add(B1CENTRO)
            grid.MasterTemplate.Columns.Add(B1SOCMDB)
            grid.MasterTemplate.Columns.Add(B1IDOFF)
            grid.MasterTemplate.Columns.Add(B1PROGR)
            grid.MasterTemplate.Columns.Add(B1AAOFF)
            grid.MasterTemplate.Columns.Add(B1DTOFF)
            grid.MasterTemplate.Columns.Add(B1STATOFF)
            grid.MasterTemplate.Columns.Add(AICLI)
            grid.MasterTemplate.Columns.Add(B1CODORIG)
            grid.MasterTemplate.Columns.Add(B1CODCOMM)
            grid.MasterTemplate.Columns.Add(B1TOTDOC)
            grid.MasterTemplate.Columns.Add(B1DTACC)
            grid.MasterTemplate.Columns.Add(B1CODIMP)
            grid.MasterTemplate.Columns.Add(TIPOIMP)
            grid.MasterTemplate.Columns.Add(AFRAG)
            grid.MasterTemplate.Columns.Add(B1IDBUO)
            grid.MasterTemplate.Columns.Add(B1RISORSA)
            grid.MasterTemplate.Columns.Add(Subappaltatore)

            grid.TableElement.SearchHighlightColor = Color.LimeGreen

            Me.grid.EndEdit()
            grigliaCreata = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Crea griglia offerte")
        End Try
    End Sub

    Private Sub cmdInserisci_Click(sender As Object, e As EventArgs) Handles cmdInserisci.Click
        Dim frm As New FrmImpianto(0, "NUOVO")
        frm.ShowDialog()
    End Sub

    Private Sub cmdModifica_Click(sender As Object, e As EventArgs) Handles cmdModifica.Click

        If grid.Rows.Count > 0 Then
            Dim ID As String = grid.CurrentRow.Cells("AICIM").Value.ToString
            Dim frm As New FrmImpianto(ID, "MODIFICA")
            frm.ShowDialog()
        End If
    End Sub
    Private Sub grid_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles grid.CellDoubleClick
        Try
            If grid.Rows.Count = 0 Then Exit Sub

            If e.Column.Name.ToUpper = "AICIM" AndAlso modalForm = "RICERCA" Then
                Dim rowInfo As GridViewRowInfo = e.Row
                Me.Close()
                Me.Dispose()
            Else


                Dim parm As New parmsOfferte()
                parm.parmCen = New List(Of centri)
                parm.parmSoc = New List(Of societa)
                parm.parmCen.Add(New centri With {.Centro = e.Row.Cells("B1CENTRO").Value})
                parm.parmSoc.Add(New societa With {.societa = e.Row.Cells("B1SOCMDB").Value})

                parm.parmAnnoOff = e.Row.Cells("B1AAOFF").Value
                parm.parmIdOfferta = e.Row.Cells("B1IDOFF").Value
                parm.parmProgOff = e.Row.Cells("B1PROGR").Value
                Dim frmi As New FrmOfferta(parm) '(FRM, "*", "ADMIN", "ADMI", "SISINFOMA")
                frmi.StartPosition = FormStartPosition.CenterScreen
                frmi.Menu.Pages(0).Text = $"Offerta {e.Row.Cells("B1PROGR").Value}/{e.Row.Cells("B1AAOFF").Value}"
                frmi.Show()

                'Dim par As New parmsOfferte
                'par.parmCen.Add(e.Row.Cells("B1CENTRO").Value)
                'par.parmSoc.Add(e.Row.Cells("B1SOCMDB").Value)
                'par.parmAnnoOff = e.Row.Cells("B1AAOFF").Value
                'par.parmIdOfferta = e.Row.Cells("B1IDOFF").Value
                'par.parmProgOff = e.Row.Cells("B1PROGR").Value
                'par.parmCodImp = e.Row.Cells("B1CODIMP").Value

                'Dim offer As New FrmOfferta(par)
                'offer.Show()
            End If

        Catch ex As Exception

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

    Private Sub FrmOffertaElenco_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Me.carica_combo_soc()
            Me.carica_combo_centro()
            Me.carica_combo_stato()
            'Me.async_carica_griglia_offerte(New parmsOfferte)
            'Me.carica_impianti()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CommandBarButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdAllSoc_Click(sender As Object, e As EventArgs) Handles cmdAllSoc.Click
        cmbSoc.ShowCheckAllItems = False
        Dim val As String = cmbSoc.Tag
        If val = "0" Then
            For Each soc As RadCheckedListDataItem In cmbSoc.Items
                soc.Checked = True
            Next
            val = "1"
        ElseIf val = "1" Then
            For Each soc As RadCheckedListDataItem In cmbSoc.Items
                soc.Checked = False
            Next
            val = "0"
        End If
        cmbSoc.Tag = val
    End Sub

    Private Sub cmdSelAllCentri_Click(sender As Object, e As EventArgs) Handles cmdSelAllCentri.Click
        cmbCentro.ShowCheckAllItems = False
        Dim val As String = cmbCentro.Tag
        If val = "0" Then
            For Each cen As RadCheckedListDataItem In cmbCentro.Items
                cen.Checked = True
            Next
            val = "1"
        ElseIf val = "1" Then
            For Each cen As RadCheckedListDataItem In cmbCentro.Items
                cen.Checked = False
            Next
            val = "0"
        End If
        cmbCentro.Tag = val
    End Sub

    Private Sub cmbCentro_ItemCheckedChanged(sender As Object, e As EventArgs) Handles cmbCentro.ItemCheckedChanged
        Aggiorna_dash()
    End Sub

    Private Sub cmbSoc_ItemCheckedChanged(sender As Object, e As RadCheckedListDataItemEventArgs) Handles cmbSoc.ItemCheckedChanged
        Aggiorna_dash()
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        cmbStato.ShowCheckAllItems = False
        Dim val As String = cmbStato.Tag
        If val = "0" Then
            For Each stato As RadCheckedListDataItem In cmbStato.Items
                stato.Checked = True
            Next
            val = "1"
        ElseIf val = "1" Then
            For Each stato As RadCheckedListDataItem In cmbStato.Items
                stato.Checked = False
            Next
            val = "0"
        End If
        cmbStato.Tag = val
    End Sub

    Private Sub lbShowVaglio_Click(sender As Object, e As EventArgs) Handles lbShowVaglio.Click
        cmbStato.CheckedItems.Clear()
        cmbStato.SelectedValue = "B"
        cmdFiltro_Click(sender, e)
    End Sub

    Private Sub lbShowAcc_Click(sender As Object, e As EventArgs) Handles lbShowAcc.Click
        cmbStato.CheckedItems.Clear()
        cmbStato.SelectedValue = "A"
        cmdFiltro_Click(sender, e)
    End Sub

    Private Sub lbShowBlocc_Click(sender As Object, e As EventArgs) Handles lbShowBlocc.Click
        cmbStato.CheckedItems.Clear()
        cmbStato.SelectedValue = "S"
        cmbStato.SelectedValue = "R"
        cmbStato.SelectedValue = "T"
        cmdFiltro_Click(sender, e)
    End Sub

    Private Sub lbShowAnn_Click(sender As Object, e As EventArgs) Handles lbShowAnn.Click
        cmbStato.CheckedItems.Clear()
        cmbStato.SelectedValue = "N"
        cmdFiltro_Click(sender, e)
    End Sub
End Class
