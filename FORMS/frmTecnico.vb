Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Web.Script.Serialization
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class FrmTecnico
    Private ws As New webServices
    Private codice As String
    Public Sub New(iCodTecnico As String)
        InitializeComponent()
        codice = iCodTecnico
    End Sub
    Private Sub FrmTecnico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdConferma.ThemeName = "buttonBLU"
        cmdAnnulla.ThemeName = "buttonDFT"
        'crea_griglia_assets()
        'carica_combo_categorie()
        'carica_combo_categorie_asset()
    End Sub

    Private Sub FrmTecnico_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If codice <> "" Then
                async_carica_scheda_tecnico()
            Else
                Me.azzera_campi()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub async_carica_scheda_tecnico()
        Try
            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True


            Dim tec As Threading.Tasks.Task(Of tecnico)
            tec = ws.getTecnico(codice)
            Await tec
            Me.carica_dati(tec)

            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            wb.AssociatedControl = Nothing
            wb.StopWaiting()
            wb.Visible = False
        End Try
    End Sub

    Private Sub azzera_campi()
        Try
            txtCodice.Text = ""
            txtRagSoc.Text = ""
            txtImei.Text = ""
            txtPassword.Text = ""
            cmbInterno.SelectedValue = -1
            cmbTipoIntervento.SelectedValue = -1
            cmbQualifica.SelectedValue = -1
            Me.carica_combo_statici()
            Me.carica_combo_qualifica("")
            Me.carica_combo_centri("")
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub
    Private Sub carica_dati(tec As Threading.Tasks.Task(Of tecnico))
        Try
            Me.carica_combo_statici()
            txtCodice.Text = tec.Result.ATCOD
            txtRagSoc.Text = tec.Result.ATRAG
            txtImei.Text = tec.Result.ATIME
            txtPassword.Text = tec.Result.ATPWD
            cmbInterno.SelectedValue = tec.Result.ATFLG
            cmbTipoIntervento.SelectedValue = tec.Result.ATINV

            txtCodice.ReadOnly = True

            carica_combo_qualifica(tec.Result.ATQUA)
            carica_combo_centri(tec.Result.ATCEN)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_qualifica(qualifica As String)
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("LVD", "")
            Await elementi

            Me.cmbQualifica.DataSource = elementi.Result
            Me.cmbQualifica.DisplayMember = "desElem"
            Me.cmbQualifica.ValueMember = "codElem"
            Me.cmbQualifica.SelectedIndex = -1

            If codice <> "" Then
                cmbQualifica.SelectedValue = qualifica
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Async Sub carica_combo_centri(centro As String)
        Try
            Dim elementi As Threading.Tasks.Task(Of parmTabelle())
            elementi = ws.getDatiTabella("CENTRI", "")
            Await elementi

            Me.cmbCentro.DataSource = elementi.Result
            Me.cmbCentro.DisplayMember = "desElem"
            Me.cmbCentro.ValueMember = "codElem"
            Me.cmbCentro.SelectedIndex = -1

            If codice <> "" Then
                cmbCentro.SelectedValue = centro
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub carica_combo_statici()
        Try
            cmbInterno.Items.Clear()
            cmbTipoIntervento.Items.Clear()

            Dim item As New RadListDataItem("INTERNO", "I")
            cmbInterno.Items.Add(item)

            Dim itemE As New RadListDataItem("ESTERNO", "E")
            cmbInterno.Items.Add(itemE)

            Dim itemC As New RadListDataItem("CHIAMATE", "C")
            cmbTipoIntervento.Items.Add(itemC)

            Dim itemV As New RadListDataItem("VISITE", "V")
            cmbTipoIntervento.Items.Add(itemV)

            Dim itemEN As New RadListDataItem("ENTRAMBE", "E")
            cmbTipoIntervento.Items.Add(itemEN)

            Dim itemS As New RadListDataItem("SOSPESO", "S")
            cmbTipoIntervento.Items.Add(itemS)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmdAnnulla_Click(sender As Object, e As EventArgs) Handles cmdAnnulla.Click
        Me.Close()
    End Sub

    Private Async Sub salva_dati(tecnico As String, azione As String)
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")

        Try
            Dim test As String
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            wb.AssociatedControl = Me
            wb.StartWaiting()
            wb.Visible = True

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            Dim parms As New tecnico
            parms.ATCOD = txtCodice.Text
            parms.ATRAG = txtRagSoc.Text
            parms.ATIME = txtImei.Text
            parms.ATPWD = txtPassword.Text
            parms.ATFLG = cmbInterno.SelectedValue
            parms.ATQUA = cmbQualifica.SelectedValue
            parms.ATZON = "Z099"
            parms.ATCEN = cmbCentro.SelectedValue
            parms.ATINV = cmbTipoIntervento.SelectedValue

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()

            Dim postContent = jss.Serialize(parms)

            Dim httpContent = New System.Net.Http.StringContent(postContent, Encoding.UTF8, "text/json")

            Dim postUrl = "https://localhost:44323/api/anagrafiche/saveTecnico/postSaveTecnico"
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("parmTecnico", postContent)
            client.DefaultRequestHeaders.Add("parmAzione", azione)

            Dim postResponse As Http.HttpResponseMessage = Await client.PostAsync(postUrl, httpContent)

            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False

            Dim sStatusCode As String = postResponse.StatusCode.ToString

            If sStatusCode.ToUpper <> "OK" Then
                Dim msg As String = postResponse.Headers.GetValues("Error").FirstOrDefault()

                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio non effettuato. " & vbCrLf & "Causa: " & msg, "Tecnici", MessageBoxButtons.OK, RadMessageIcon.Info)
            Else
                Telerik.WinControls.RadMessageBox.Show(Me, "Salvataggio effettuato", "Tecnici", MessageBoxButtons.OK, RadMessageIcon.Info)
            End If

        Catch EX As Exception
            wb.StopWaiting()
            wb.AssociatedControl = Nothing
            wb.Visible = False
            Telerik.WinControls.RadMessageBox.Show(Me, "Errore", "Tecnici", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Sub cmdConferma_Click(sender As Object, e As EventArgs) Handles cmdConferma.Click
        If controlli_client() = False Then
            Exit Sub
        End If

        If codice = "" Then
            Me.salva_dati(txtCodice.Text, "INSERISCI")
        Else
            Me.salva_dati(txtCodice.Text, "MODIFICA")
        End If
    End Sub

    Private Function controlli_client() As Boolean
        Telerik.WinControls.RadMessageBox.SetThemeName("MaterialBlueGrey")
        Try
            If txtCodice.Text.Trim = "" Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Inserire il codice", "Tecnici", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                txtCodice.Focus()
                Exit Function
            End If

            If cmbCentro.SelectedIndex = -1 Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Inserire il Centro di appartenenza", "Tecnici", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                cmbCentro.Focus()
                Exit Function
            End If

            If cmbQualifica.SelectedIndex = -1 Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Inserire la qualifica", "Tecnici", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                cmbQualifica.Focus()
                Exit Function
            End If

            If cmbInterno.SelectedIndex = -1 Then
                Telerik.WinControls.RadMessageBox.Show(Me, "Indicare Tecnico interno o esterno", "Tecnici", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                cmbInterno.Focus()
                Exit Function
            End If

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function
End Class
