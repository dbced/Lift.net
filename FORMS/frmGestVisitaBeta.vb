Imports System.Net
Imports System.Text
Imports System.Web.Script.Serialization
Imports Telerik.WinControls
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI

Public Class FrmGestVisitaBeta
    Public iniCodice As String
    Public iniTipoVisita As String
    Public iniData As String
    Public iniDatafine As String
    Public iniDataChi As String
    Public iniAzione As String
    Public iniID As String
    Public iniSoc As String
    Public iniCentro As String
    Public iniNote As String

    Private ws As New webServices
    Private statoCaricaTipoVisita As Boolean
    Private statoCaricaSquadre As Boolean
    Private statoCaricaVisita As Boolean

    Private datiVisita As List(Of elencoManutenzioni)

    Private Sub FrmGestVisitaBeta_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonDFT.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonBLU.tssp")
            ThemeResolutionService.LoadPackageFile(Application.StartupPath & "\buttonRED.tssp")

            cmdAnnulla.ThemeName = "buttonDFT"
            cmdChiudi.ThemeName = "buttonDFT"
            cmdOkSearch.ThemeName = "buttonDFT"
            cmdOkSearchImp.ThemeName = "buttonDFT"
            cmdConferma.ThemeName = "buttonBLU"

            Me.txtData.Format = DateTimePickerFormat.[Custom]
            Me.txtData.CustomFormat = "dd/MM/yyyy HH:mm "
            TryCast(Me.txtData.DateTimePickerElement.CurrentBehavior, RadDateTimePickerCalendar).ShowTimePicker = True
            TryCast(Me.txtData.DateTimePickerElement.CurrentBehavior, RadDateTimePickerCalendar).DropDownMinSize = New Size(330, 250)

            statoCaricaTipoVisita = False
            statoCaricaSquadre = False

            wbG.AssociatedControl = Me
            wbG.StartWaiting()
            wbG.Visible = True

            t1.Enabled = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub t1_Tick(sender As Object, e As EventArgs) Handles t1.Tick
        Try

            If statoCaricaTipoVisita = True And statoCaricaSquadre And statoCaricaVisita = True Then

                Select Case iniAzione
                    Case "INSERISCI"
                        txtSoc.Text = iniSoc
                        txtCentro.Text = iniCentro
                        txtCodice.ReadOnly = False
                        txtData.Value = New DateTime(Now.Year, Now.Month, Now.Day, 8, 0, 0)
                        txtDataFine.Value = New DateTime(Now.Year, Now.Month, Now.Day, 19, 0, 0)
                        txtDataEffett.Value = Nothing

                    Case "MODIFICA"
                        carica_visita(datiVisita)

                End Select

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

    Private Async Sub carica_combo_tipoVisita()
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("TIPOVISITA", "")
            Await elementi

            Me.cmbTipoVisita.DataSource = elementi.Result
            Me.cmbTipoVisita.DisplayMember = "desElem"
            Me.cmbTipoVisita.ValueMember = "codElem"
            Me.cmbTipoVisita.SelectedIndex = -1

            If iniAzione = "MODIFICA" Then
                cmbTipoVisita.SelectedValue = iniTipoVisita
            End If

            statoCaricaTipoVisita = True

        Catch ex As Exception
            statoCaricaTipoVisita = True
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

            If iniAzione = "MODIFICA" Then
                'cmbSquadre.SelectedValue = iniTipoVisita
            End If

            statoCaricaSquadre = True

        Catch ex As Exception
            statoCaricaSquadre = True
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub cmdConferma_Click(sender As Object, e As EventArgs) Handles cmdConferma.Click
        Try
            Me.start_saveData(iniAzione)

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
            parms.codSocieta = iniSoc
            parms.CodCentro = iniCentro
            parms.id = iniID

            If cmbTipoVisita.SelectedIndex >= 0 Then
                parms.tipoVisita = cmbTipoVisita.SelectedValue
            Else
                parms.tipoVisita = ""
            End If
            parms.CodImpianto = txtCodice.Text
            parms.idsquadra = cmbSquadre.SelectedValue
            If chkDiurno.CheckState = CheckState.Checked Then
                parms.flagDiurnoNotturno = "D"
            Else
                parms.flagDiurnoNotturno = "N"
            End If

            Dim o As Integer = Hour(txtData.Value)
            Dim m As Integer = Minute(txtData.Value)
            Dim s As Integer = Second(txtData.Value)

            Dim aa As Integer = Year(txtData.Value)
            Dim dd As Integer = DateTime.Parse(txtData.Value).Day
            Dim mm As Integer = Month(txtData.Value)

            parms.id = Val(iniID)

            parms.dataInizio = New DateTime(aa, mm, dd)
            parms.dataInizioTS = New DateTime(aa, mm, dd, o, m, s)

            o = Hour(txtDataFine.Value)
            m = Minute(txtDataFine.Value)
            s = Second(txtDataFine.Value)

            aa = Year(txtDataFine.Value)
            dd = DateTime.Parse(txtDataFine.Value).Day
            mm = Month(txtDataFine.Value)

            parms.dataFine = New DateTime(aa, mm, dd)
            parms.dataFineTS = New DateTime(aa, mm, dd, o, m, s)

            Dim data As String = txtDataEffett.Value

            If data <> "00:00:00" Then
                o = Hour(txtDataEffett.Value)
                m = Minute(txtDataEffett.Value)
                s = Second(txtDataEffett.Value)

                aa = Year(txtDataEffett.Value)
                dd = DateTime.Parse(txtDataEffett.Value).Day
                mm = Month(txtDataEffett.Value)

                parms.dataEffett = New DateTime(aa, mm, dd)
                parms.dataEffettTS = New DateTime(aa, mm, dd, o, m, s)

            Else
                parms.dataEffett = "01/01/0001"
                parms.dataEffettTS = "01/01/0001 00:00:00"
            End If

            parms.note = txtNote.Text.Trim

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

                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio non effettuato. " & vbCrLf & "Causa: " & msg, "Gestione visita", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio effettuato", "Gestione visita", MessageBoxButtons.OK, RadMessageIcon.Info)
                Me.Close()
            End If

        Catch EX As Exception
            wbG.StopWaiting()
            wbG.AssociatedControl = Nothing
            wbG.Visible = False
            Telerik.WinControls.RadMessageBox.Show(Me, "Errore", "Gestione visita", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Async Sub start_saveData(azione As String)
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            Dim response As String = Await controlla_dati(azione)
            If response.Contains("Errore:") Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Errori riscontrati: " & vbCrLf & response, "Gestione visita", MessageBoxButtons.OK, RadMessageIcon.Error)

            ElseIf response = "OK" Then
                Me.salva_dati(azione)
                Me.Close()

            Else
                Dim dr As DialogResult = RadMessageBox.Show(response & vbCrLf & "Continuare?", "Gestione visita", MessageBoxButtons.YesNo, RadMessageIcon.Question)
                If dr = DialogResult.No Then
                    Exit Sub
                Else
                    Me.salva_dati(azione)
                    Me.Close()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Async Function controlla_dati(azione As String) As Threading.Tasks.Task(Of String)
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
            parms.codSocieta = iniSoc
            parms.CodCentro = iniCentro
            parms.id = iniID

            If cmbTipoVisita.SelectedIndex >= 0 Then
                parms.tipoVisita = cmbTipoVisita.SelectedValue
            Else
                parms.tipoVisita = ""
            End If
            parms.CodImpianto = txtCodice.Text
            parms.idsquadra = cmbSquadre.SelectedValue
            If chkDiurno.CheckState = CheckState.Checked Then
                parms.flagDiurnoNotturno = "D"
            Else
                parms.flagDiurnoNotturno = "N"
            End If

            Dim o As Integer = Hour(txtData.Value)
            Dim m As Integer = Minute(txtData.Value)
            Dim s As Integer = Second(txtData.Value)

            Dim aa As Integer = Year(txtData.Value)
            Dim dd As Integer = DateTime.Parse(txtData.Value).Day
            Dim mm As Integer = Month(txtData.Value)

            parms.id = Val(iniID)

            parms.dataInizio = New DateTime(aa, mm, dd)
            parms.dataInizioTS = New DateTime(aa, mm, dd, o, m, s)

            o = Hour(txtDataFine.Value)
            m = Minute(txtDataFine.Value)
            s = Second(txtDataFine.Value)

            aa = Year(txtDataFine.Value)
            dd = DateTime.Parse(txtDataFine.Value).Day
            mm = Month(txtDataFine.Value)

            parms.dataFine = New DateTime(aa, mm, dd)
            parms.dataFineTS = New DateTime(aa, mm, dd, o, m, s)

            Dim data As String = txtDataEffett.Value

            If data <> "00:00:00" Then
                o = Hour(txtDataEffett.Value)
                m = Minute(txtDataEffett.Value)
                s = Second(txtDataEffett.Value)

                aa = Year(txtDataEffett.Value)
                dd = DateTime.Parse(txtDataEffett.Value).Day
                mm = Month(txtDataEffett.Value)

                parms.dataEffett = New DateTime(aa, mm, dd)
                parms.dataEffettTS = New DateTime(aa, mm, dd, o, m, s)

            Else
                parms.dataEffett = "01/01/0001"
                parms.dataEffettTS = "01/01/0001 00:00:00"
            End If

            parms.note = txtNote.Text.Trim

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

            Dim postContent = jss.Serialize(parms)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = My.Settings.urlWS & "api/visite/controlloVisitaLiv1/controlloVisitaLiv1"
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

                'Telerik.WinControls.RadMessageBox.Show(Me, "Errori rscontrati: " & vbCrLf & msg.Replace("%0d%0a", vbCrLf), "Gestione visita", MessageBoxButtons.OK, RadMessageIcon.Error)
                Return msg.Replace("%0d%0a", vbCrLf)
            Else
                Return "OK"
                'Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio effettuato", "Gestione visita", MessageBoxButtons.OK, RadMessageIcon.Info)
            End If

        Catch EX As Exception
            wbG.StopWaiting()
            wbG.AssociatedControl = Nothing
            wbG.Visible = False
            Return "Errore: " & EX.Message
            'Telerik.WinControls.RadMessageBox.Show(Me, "Errore", "Gestione visita", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Function

    Private Sub FrmGestVisitaBeta_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Me.carica_combo_tipoVisita()
            Me.carica_combo_squadre()
            If iniAzione = "MODIFICA" Then
                Me.async_carica_gantt_manutenzioni("", "", "", "",,,,, Val(iniID))
            Else
                statoCaricaVisita = True
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub txtData_LostFocus(sender As Object, e As EventArgs) Handles txtData.LostFocus
        Try
            'If IsDate(txtData.Value) Then
            '    txtDataFine.Value = Format(txtData.Value, "dd/MM/yyyy") & " 23:00:00"
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblEffett_Click(sender As Object, e As EventArgs) Handles lblEffett.Click

    End Sub

    Private Sub cmdChiudi_Click(sender As Object, e As EventArgs) Handles cmdChiudi.Click
        Try
            txtDataEffett.Value = Now
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdAnnulla_Click(sender As Object, e As EventArgs) Handles cmdAnnulla.Click
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdOkSearch_Click(sender As Object, e As EventArgs) Handles cmdOkSearch.Click
        Try
            Dim frm As New FrmTabelle("SQUADRE")
            frm.ShowDialog()
            Me.carica_combo_squadre()
        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub async_carica_gantt_manutenzioni(codImp As String, codSoc As String, codCen As String, codCli As String,
                                                      Optional Matricola As String = "", Optional DataIni As String = "",
                                                      Optional DataFine As String = "", Optional Descr As String = "", Optional IdVisita As Integer = 0)
        Try

            Dim elementi As Threading.Tasks.Task(Of List(Of elencoManutenzioni))
            elementi = ws.getManutenzioniElenco(codImp, codSoc, codCen, codCli, Matricola, DataIni, DataFine, Descr, IdVisita)
            Await elementi

            datiVisita = elementi.Result
            statoCaricaVisita = True

            'Me.carica_gantt_visite(elementi.Result)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub carica_visita(dati As List(Of elencoManutenzioni))
        Try
            txtSoc.Text = dati(0).codSocieta
            txtCentro.Text = dati(0).CodCentro

            txtCodice.Text = dati(0).CodImpianto
            txtData.Value = CDate(dati(0).dataInizioTS)
            txtDataFine.Value = CDate(dati(0).dataFineTS)
            txtDataEffett.Value = CDate(dati(0).dataEffettTS)
            cmbTipoVisita.SelectedValue = dati(0).tipoVisita
            txtNote.Text = dati(0).note
            txtDescr.Text = dati(0).descrImpianto
            cmbSquadre.SelectedValue = dati(0).idsquadra.ToString

            If dati(0).flagDiurnoNotturno = "D" Then
                chkDiurno.CheckState = CheckState.Checked
            Else
                chkNotturno.CheckState = CheckState.Checked
            End If

            If IsDate(CDate(dati(0).dataEffettTS)) Then
                If Not dati(0).dataEffettTS.Contains("01/01/0001") Then
                    cmdConferma.Enabled = False
                    lblChiusa.Visible = True
                End If
            End If

            txtCodice.ReadOnly = True
            txtDescr.ReadOnly = True
            cmdOkSearchImp.Enabled = False

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
        End Try

    End Sub

    Private Sub cmdOkSearchImp_Click(sender As Object, e As EventArgs) Handles cmdOkSearchImp.Click
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            If txtDescr.Text.Trim.Length >= 6 Then
                Me.carica_combo_impianti()
            Else
                Telerik.WinControls.RadMessageBox.Show(Me, "Inserire almeno 6 caratteri ", "Gestione visita", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub carica_combo_impianti()
        Try
            Dim elementi As Threading.Tasks.Task(Of elenco())
            elementi = ws.getDatiTabellaComboImpianti("", txtDescr.Text)
            Await elementi

            Me.cmbImpianti.Columns.Clear()
            cmbImpianti.MultiColumnComboBoxElement.DropDownAnimationEnabled = False

            Me.cmbImpianti.AutoSizeDropDownToBestFit = True
            Dim multiColumnComboElement As RadMultiColumnComboBoxElement = Me.cmbImpianti.MultiColumnComboBoxElement
            multiColumnComboElement.DropDownSizingMode = SizingMode.UpDownAndRightBottom
            multiColumnComboElement.DropDownMinSize = New Size(420, 300)
            multiColumnComboElement.EditorControl.MasterTemplate.AutoGenerateColumns = False

            Dim column = New GridViewTextBoxColumn("AICIM")
            column.HeaderText = "Cd. Impianto"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("AIIND")
            column.HeaderText = "Indirizzo"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("AIMAT")
            column.HeaderText = "Matricola"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("FLDIURNO")
            column.HeaderText = "D/N"
            multiColumnComboElement.Columns.Add(column)

            column = New GridViewTextBoxColumn("IDSQUADRA")
            column.HeaderText = "ID SQUADRA"
            multiColumnComboElement.Columns.Add(column)

            Me.cmbImpianti.DisplayMember = "AIIND"
            Me.cmbImpianti.ValueMember = "AICIM"
            Me.cmbImpianti.DataSource = elementi.Result

            Me.cmbImpianti.AutoFilter = True
            Dim compositeFilter As New CompositeFilterDescriptor()
            Dim aicim As New FilterDescriptor("AICIM", FilterOperator.Contains, "")
            Dim aiind As New FilterDescriptor("AIIND", FilterOperator.Contains, "")
            Dim aimat As New FilterDescriptor("AIMAT", FilterOperator.Contains, "")
            Dim fldiurno As New FilterDescriptor("FLDIURNO", FilterOperator.Contains, "")
            Dim idsquadra As New FilterDescriptor("IDSQUADRA", FilterOperator.Contains, "")

            compositeFilter.FilterDescriptors.Add(aicim)
            compositeFilter.FilterDescriptors.Add(aiind)
            compositeFilter.FilterDescriptors.Add(aimat)
            compositeFilter.FilterDescriptors.Add(fldiurno)
            compositeFilter.FilterDescriptors.Add(idsquadra)

            compositeFilter.LogicalOperator = FilterLogicalOperator.[Or]
            Me.cmbImpianti.EditorControl.FilterDescriptors.Add(compositeFilter)

            Me.cmbImpianti.SelectedIndex = -1

            cmbImpianti.Visible = True
            txtDescr.Visible = False
            cmbImpianti.Focus()
            cmbImpianti.MultiColumnComboBoxElement.ShowPopup()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub seleziona_impianto()
        Try
            If cmbImpianti.Visible = False Then
                Exit Sub
            End If

            If cmbImpianti.SelectedIndex >= 0 Then
                Dim value As Object = cmbImpianti.EditorControl.Rows(cmbImpianti.SelectedIndex).Cells("AIIND").Value
                Dim fldin As Object = cmbImpianti.EditorControl.Rows(cmbImpianti.SelectedIndex).Cells("FLDIURNO").Value
                Dim idSquadra As Object = cmbImpianti.EditorControl.Rows(cmbImpianti.SelectedIndex).Cells("IDSQUADRA").Value

                txtCodice.Text = cmbImpianti.SelectedValue.ToString
                txtDescr.Text = value.ToString
                If fldin = "N" Then
                    chkNotturno.IsChecked = True
                Else
                    chkDiurno.IsChecked = True
                End If

                cmbSquadre.SelectedValue = idSquadra.ToString
            Else
                txtCodice.Text = ""
                txtDescr.Text = ""
            End If

            cmbImpianti.Visible = False
            txtDescr.Visible = True

        Catch ex As Exception
            txtCodice.Text = ""
            txtDescr.Text = ""
            cmbImpianti.Visible = False
            txtDescr.Visible = True

        End Try
    End Sub

    Private Sub cmbImpianti_LostFocus(sender As Object, e As EventArgs) Handles cmbImpianti.LostFocus
        seleziona_impianto()
    End Sub

    Private Sub chkNotturno_ToggleStateChanged(sender As Object, args As StateChangedEventArgs) Handles chkNotturno.ToggleStateChanged
        Try
            If iniAzione = "INSERISCI" Then
                If IsDate(txtData.Value) Then
                    txtData.Value = New DateTime(Year(txtData.Value), Month(txtData.Value), DateTime.Parse(txtData.Value).Day, 19, 0, 0)
                    txtDataFine.Value = New DateTime(Year(txtData.Value), Month(txtData.Value), DateTime.Parse(txtData.Value).Day, 23, 0, 0)
                Else
                    txtData.Value = New DateTime(Now.Year, Now.Month, Now.Day, 19, 0, 0)
                    txtDataFine.Value = New DateTime(Now.Year, Now.Month, Now.Day, 23, 0, 0)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkDiurno_ToggleStateChanged(sender As Object, args As StateChangedEventArgs) Handles chkDiurno.ToggleStateChanged
        Try
            If iniAzione = "INSERISCI" Then
                If IsDate(txtData.Value) Then
                    txtData.Value = New DateTime(Year(txtData.Value), Month(txtData.Value), DateTime.Parse(txtData.Value).Day, 8, 0, 0)
                    txtDataFine.Value = New DateTime(Year(txtData.Value), Month(txtData.Value), DateTime.Parse(txtData.Value).Day, 19, 0, 0)
                Else
                    txtData.Value = New DateTime(Now.Year, Now.Month, Now.Day, 8, 0, 0)
                    txtDataFine.Value = New DateTime(Now.Year, Now.Month, Now.Day, 19, 0, 0)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtData_ValueChanged(sender As Object, e As EventArgs) Handles txtData.ValueChanged

    End Sub
End Class
