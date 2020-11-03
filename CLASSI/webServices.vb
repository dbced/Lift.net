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
Imports Telerik.WinControls.UI.Map.Bing
Imports Telerik.WinControls.UI.Map
Imports System.Net.Http

Public Class webServices
    Public Async Function getDatiTabellaComuniIT(codTab As String, Optional codElem As String = "") As Threading.Tasks.Task(Of parmComuni())
        Dim varses() As parmComuni

        Try
            Dim test As String
            Dim RestURL As String = My.Settings.urlWS & "api/tabelle/GetValoriComuniList/GetValoriComuni"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodTab", codTab)
            client.DefaultRequestHeaders.Add("parmCodEle", codElem)

            Dim parmImp As parmGetTabella = New parmGetTabella

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                test = Await RestResponse.Content.ReadAsStringAsync()
                varses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of parmComuni())(test)
            End If

            test = RestResponse.StatusCode.ToString
            Return varses


        Catch EX As Exception
            Return varses
        End Try

    End Function

    Public Async Function getDatiListe(codTab As String, Optional codElem As String = "") As Threading.Tasks.Task(Of parmTabelle())
        Dim varses() As parmTabelle

        Try
            Dim test As String
            Dim RestURL As String = My.Settings.urlWS & "api/tabelle/GetValoriListeList/GetValoriListe"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodTab", codTab)
            client.DefaultRequestHeaders.Add("parmCodEle", codElem)

            Dim parmImp As parmGetTabella = New parmGetTabella

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                test = Await RestResponse.Content.ReadAsStringAsync()
                varses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of parmTabelle())(test)
            End If

            test = RestResponse.StatusCode.ToString
            Return varses

        Catch EX As Exception
            Return varses
        End Try


    End Function

    Public Async Function getDatiTabellaClienti(codTab As String, Optional codElem As String = "") As Threading.Tasks.Task(Of elencoClienti())
        Dim varses() As elencoClienti

        Try
            Dim test As String
            Dim RestURL As String = My.Settings.urlWS & "api/anagrafiche/GetElencoClientiList/GetElencoClientiList"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodTab", codTab)
            client.DefaultRequestHeaders.Add("parmCodEle", codElem)

            Dim parmImp As parmGetTabella = New parmGetTabella

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                test = Await RestResponse.Content.ReadAsStringAsync()
                varses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoClienti())(test)
            End If

            test = RestResponse.StatusCode.ToString
            Return varses


        Catch EX As Exception
            Return varses
        End Try


    End Function

    Public Async Function getTabellaReperibilita(codCen As String, codZona As String) As Threading.Tasks.Task(Of elencoReperibilita())
        Dim varses() As elencoReperibilita

        Try
            Dim elenco As String
            Dim RestURL As String = My.Settings.urlWS & "api/tabelle/GetElencoReperib/GetElencoReperib"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodCen", codCen)
            client.DefaultRequestHeaders.Add("parmCodZon", codZona)

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                elenco = Await RestResponse.Content.ReadAsStringAsync()
                varses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoReperibilita())(elenco)
            End If

            Return varses

        Catch EX As Exception
            Return varses
        End Try


    End Function

    Public Async Function getDatiTabella(codTab As String, Optional codElem As String = "", Optional filtro As String = "") As Threading.Tasks.Task(Of parmTabelle())
        Dim varses() As parmTabelle

        Try
            Dim test As String
            Dim RestURL As String = My.Settings.urlWS & "api/tabelle/GetValoriTabelleList/GetValoriTabelle"

            'Dim authtHandler As HttpClientHandler = New HttpClientHandler() With {.Credentials = CredentialCache.DefaultNetworkCredentials}
            'Dim client As New Http.HttpClient(authtHandler)

            Dim client As New Http.HttpClient()
            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodTab", codTab)
            client.DefaultRequestHeaders.Add("parmCodEle", codElem)
            client.DefaultRequestHeaders.Add("parmFiltro", filtro)

            Dim parmImp As parmGetTabella = New parmGetTabella

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                test = Await RestResponse.Content.ReadAsStringAsync()
                varses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of parmTabelle())(test)
            End If

            test = RestResponse.StatusCode.ToString
            Return varses

        Catch EX As Exception
            Return varses
        End Try

    End Function

    Public Async Function getSchedaImpianto(idImpianto As String) As Threading.Tasks.Task(Of parmGetSchedaImpianto)
        Dim impianto As parmGetSchedaImpianto

        Try

            Dim test As String
            Dim RestURL As String = My.Settings.urlWS & "api/impianti/SchedaImpianto/GetImpianto"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            Dim parmImp As String = idImpianto

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim myContent = jss.Serialize(parmImp)
            RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                test = Await RestResponse.Content.ReadAsStringAsync()
                impianto = Newtonsoft.Json.JsonConvert.DeserializeObject(Of parmGetSchedaImpianto)(test)
            Else
                MsgBox(RestResponse.StatusCode & " " & RestResponse.Content.ToString, vbCritical)
            End If

            Return impianto

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
            Return impianto
        End Try

    End Function

    Public Async Function getDatiTecniciAsset(IdAsset As String, CodImp As String) As Threading.Tasks.Task(Of datiTecnici())
        Dim varses() As datiTecnici

        Try

            Dim test As String
            Dim RestURL As String = My.Settings.urlWS & "api/impianti/GetDatiTecniciAssets/GetDatiTecniciAssets"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("idAsset", IdAsset)
            client.DefaultRequestHeaders.Add("CodImp", CodImp)

            Dim parmImp As parmGetTabella = New parmGetTabella

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                test = Await RestResponse.Content.ReadAsStringAsync()
                varses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of datiTecnici())(test)
                'Me.carica_griglia_datiTecnici_assets(varses)
            End If

            Return varses

        Catch EX As Exception
            Return varses
        End Try

    End Function

    Public Async Function getDatiTecniciImpianto(CodImp As String, codCat As String) As Threading.Tasks.Task(Of List(Of datiTecnici))
        Dim varses As New List(Of datiTecnici)
        Dim lista() As datiTecnici
        Try

            Dim test As String
            Dim RestURL As String = My.Settings.urlWS & "api/impianti/GetDatiTecniciImpianto/GetDatiTecniciImpianto"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("CodImp", CodImp)
            client.DefaultRequestHeaders.Add("CodCat", codCat)

            Dim parmImp As parmGetTabella = New parmGetTabella

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                test = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of datiTecnici())(test)
                For i As Integer = 0 To lista.Count - 1
                    varses.Add(lista(i))
                Next

                'Me.carica_griglia_datiTecnici_assets(varses)
            End If

            Return varses

        Catch EX As Exception
            Return varses
        End Try

    End Function

    Public Async Function carica_assets_impianto(idImpianto As String) As Threading.Tasks.Task(Of elencoAssetsImpianto())
        Dim assets() As elencoAssetsImpianto

        Try
            Dim test As String
            Dim RestURL As String = My.Settings.urlWS & "api/impianti/GetAssetsImpianto/GetAssetsImpianto"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            Dim parmImp As String = idImpianto

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim myContent = jss.Serialize(parmImp)
            RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                test = Await RestResponse.Content.ReadAsStringAsync()
                assets = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoAssetsImpianto())(test)
            Else
                MsgBox(RestResponse.StatusCode & " " & RestResponse.Content.ToString, vbCritical)
            End If

            Return assets

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
            Return assets
        End Try

    End Function

    Public Async Function carica_lista_assets(categoria As String) As Threading.Tasks.Task(Of elencoAssetsImpianto())
        Dim assets() As elencoAssetsImpianto

        Try
            Dim test As String
            Dim RestURL As String = My.Settings.urlWS & "api/impianti/GetAssetsList/GetAssetsList"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            Dim parmImp As String = categoria

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim myContent = jss.Serialize(parmImp)
            RestURL = RestURL & "?categoria=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                test = Await RestResponse.Content.ReadAsStringAsync()
                assets = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoAssetsImpianto())(test)
            Else
                MsgBox(RestResponse.StatusCode & " " & RestResponse.Content.ToString, vbCritical)
            End If

            Return assets

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
            Return assets
        End Try

    End Function

    Public Async Function getManutenzioniDefault(CodImp As String, codCat As String, Optional CodAss As String = "") As Threading.Tasks.Task(Of List(Of elencoManutDefault))
        Dim elenco As New List(Of elencoManutDefault)
        Dim lista() As elencoManutDefault
        Try

            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/visite/getManutenzioniDefault/getManutenzioniDefault"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodCat", codCat)
            client.DefaultRequestHeaders.Add("parmCodImp", CodImp)
            client.DefaultRequestHeaders.Add("parmCodAss", CodAss)

            Dim parmImp As parmGetManutenzioniDefault = New parmGetManutenzioniDefault

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoManutDefault())(dati)
                For i As Integer = 0 To lista.Count - 1
                    elenco.Add(lista(i))
                Next

                'Me.carica_griglia_datiTecnici_assets(varses)
            End If

            Return elenco

        Catch EX As Exception
            Return elenco
        End Try

    End Function

    Public Async Function getElencoTasks(codCat As String, CodVis As String) As Threading.Tasks.Task(Of List(Of elencoTasksVisita))
        Dim elenco As New List(Of elencoTasksVisita)
        Dim lista() As elencoTasksVisita
        Try

            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/visite/GetTasksElenco/GetTasksElenco"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodCat", codCat)
            client.DefaultRequestHeaders.Add("parmCodVis", CodVis)

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoTasksVisita())(dati)
                For i As Integer = 0 To lista.Count - 1
                    elenco.Add(lista(i))
                Next
            End If

            Return elenco

        Catch EX As Exception
            Return elenco
        End Try

    End Function

    Public Async Function getManutenzioniElenco(CodImp As String, cdSoc As String, cdcen As String, cdcli As String,
                                                      Optional Matricola As String = "", Optional DataIni As String = "",
                                                      Optional DataFine As String = "", Optional Descr As String = "",
                                                      Optional IdVisita As Integer = 0, Optional IdSquadra As Integer = 0) As Threading.Tasks.Task(Of List(Of elencoManutenzioni))
        Dim elenco As New List(Of elencoManutenzioni)
        Dim lista() As elencoManutenzioni
        Try

            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/visite/getManutenzioniElenco/getManutenzioniElenco"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodImp", CodImp)
            client.DefaultRequestHeaders.Add("parmCodSoc", cdSoc)
            client.DefaultRequestHeaders.Add("parmCodCen", cdcen)
            client.DefaultRequestHeaders.Add("parmCodCli", cdcli)
            client.DefaultRequestHeaders.Add("parmMatricola", Matricola)
            client.DefaultRequestHeaders.Add("parmDataIni", DataIni)
            client.DefaultRequestHeaders.Add("parmDataFine", DataFine)
            client.DefaultRequestHeaders.Add("parmDescr", Descr)
            client.DefaultRequestHeaders.Add("parmIdVisita", IdVisita.ToString)
            client.DefaultRequestHeaders.Add("parmIdSquadra", IdSquadra.ToString)

            Dim parmImp As parmGetManutenzioniDefault = New parmGetManutenzioniDefault

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoManutenzioni())(dati)
                For i As Integer = 0 To lista.Count - 1
                    elenco.Add(lista(i))
                Next

                'Me.carica_griglia_datiTecnici_assets(varses)
            End If

            Return elenco

        Catch EX As Exception
            Return elenco
        End Try


    End Function

    Public Async Function getStatManutenzioni(CodImp As String, Optional anno As String = "") As Threading.Tasks.Task(Of List(Of statManutenzioni))
        Dim elenco As New List(Of statManutenzioni)
        Dim lista() As statManutenzioni
        Try

            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/statImpianti/getStatManutenzioni/getStatManutenzioni"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodImp", CodImp)
            If anno <> "" Then
                client.DefaultRequestHeaders.Add("parmAnno", anno)
            End If

            Dim parmImp As parmGetManutenzioniDefault = New parmGetManutenzioniDefault

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of statManutenzioni())(dati)
                For i As Integer = 0 To lista.Count - 1
                    elenco.Add(lista(i))
                Next

                'Me.carica_griglia_datiTecnici_assets(varses)
            End If

            Return elenco

        Catch EX As Exception
            Return elenco
        End Try


    End Function

    Public Async Function getStatBuoniImpianto(CodImp As String, Optional anno As String = "") As Threading.Tasks.Task(Of List(Of statBuoniImpianto))
        Dim elenco As New List(Of statBuoniImpianto)
        Dim lista() As statBuoniImpianto
        Try

            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/statImpianti/getStatBuoniImp/getStatBuoniImp"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodImp", CodImp)
            If anno <> "" Then
                client.DefaultRequestHeaders.Add("parmAnno", anno)
            End If

            Dim parmImp As parmGetManutenzioniDefault = New parmGetManutenzioniDefault

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of statBuoniImpianto())(dati)
                For i As Integer = 0 To lista.Count - 1
                    elenco.Add(lista(i))
                Next
            End If

            Return elenco

        Catch EX As Exception
            Return elenco
        End Try


    End Function

    Public Async Function getStatFatturatoImpianto(CodImp As String, Optional anno As String = "") As Threading.Tasks.Task(Of List(Of statFatturatoImpianto))
        Dim elenco As New List(Of statFatturatoImpianto)
        Dim lista() As statFatturatoImpianto
        Try

            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/statImpianti/getStatFatturatoImp/getStatFatturatoImp"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodImp", CodImp)
            If anno <> "" Then
                client.DefaultRequestHeaders.Add("parmAnno", anno)
            End If

            Dim parmImp As parmGetManutenzioniDefault = New parmGetManutenzioniDefault

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of statFatturatoImpianto())(dati)
                For i As Integer = 0 To lista.Count - 1
                    elenco.Add(lista(i))
                Next
            End If

            Return elenco

        Catch EX As Exception
            Return elenco
        End Try
    End Function

    Public Async Function getStatCanoniImpianto(CodImp As String, Optional anno As String = "") As Threading.Tasks.Task(Of List(Of statCanoniImpianto))
        Dim elenco As New List(Of statCanoniImpianto)
        Dim lista() As statCanoniImpianto
        Try

            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/statImpianti/getStatCanoniImp/getStatCanoniImp"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodImp", CodImp)
            If anno <> "" Then
                client.DefaultRequestHeaders.Add("parmAnno", anno)
            End If

            Dim parmImp As parmGetManutenzioniDefault = New parmGetManutenzioniDefault

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of statCanoniImpianto())(dati)
                For i As Integer = 0 To lista.Count - 1
                    elenco.Add(lista(i))
                Next
            End If

            Return elenco

        Catch EX As Exception
            Return elenco
        End Try
    End Function


    Public Async Function getStatChiamateImpianto(CodImp As String, Optional anno As String = "") As Threading.Tasks.Task(Of List(Of statChiamateImpianto))
        Dim elenco As New List(Of statChiamateImpianto)
        Dim lista() As statChiamateImpianto
        Try

            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/statImpianti/getStatChiamateImp/getStatChiamateImp"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodImp", CodImp)
            If anno <> "" Then
                client.DefaultRequestHeaders.Add("parmAnno", anno)
            End If

            Dim parmImp As parmGetManutenzioniDefault = New parmGetManutenzioniDefault

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of statChiamateImpianto())(dati)
                For i As Integer = 0 To lista.Count - 1
                    elenco.Add(lista(i))
                Next
            End If

            Return elenco

        Catch EX As Exception
            Return elenco
        End Try
    End Function

    Public Async Function getDocumentiImpianto(CodImp As String, Optional anno As String = "", Optional cliente As String = "") As Threading.Tasks.Task(Of List(Of elencoDocumenti))
        Dim elenco As New List(Of elencoDocumenti)
        Dim lista() As elencoDocumenti
        Try

            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/Documenti/getDocumentiImp/getDocumentiImp"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            client.DefaultRequestHeaders.Add("parmCodImp", CodImp)
            client.DefaultRequestHeaders.Add("parmAnno", anno)
            client.DefaultRequestHeaders.Add("parmCliente", cliente)

            Dim parmImp As parmGetManutenzioniDefault = New parmGetManutenzioniDefault

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            'Dim myContent = jss.Serialize(parmImp)
            'RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoDocumenti())(dati)
                For i As Integer = 0 To lista.Count - 1
                    elenco.Add(lista(i))
                Next
            End If

            Return elenco

        Catch EX As Exception
            Return elenco
        End Try
    End Function

    Public Async Function getElencoTecnici(codice As String, filtro As String) As Threading.Tasks.Task(Of List(Of elencoTecnici))
        Dim elenco As New List(Of elencoTecnici)
        Dim lista() As elencoTecnici

        Try
            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/Anagrafiche/GetElencoTecniciList/GetElencoTecniciList"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()


            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodTab", codice)
            client.DefaultRequestHeaders.Add("parmCodEle", filtro)

            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoTecnici())(dati)
                For i As Integer = 0 To lista.Count - 1
                    elenco.Add(lista(i))
                Next
            End If

            'test = RestResponse.StatusCode.ToString

            Return elenco

        Catch EX As Exception
            Return elenco
        End Try

    End Function

    Public Async Function getElencoAmministratori(codice As String, filtro As String) As Threading.Tasks.Task(Of List(Of elencoAmministratori))
        Dim elenco As New List(Of elencoAmministratori)
        Dim lista() As elencoAmministratori

        Try
            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/Anagrafiche/GetElencoAmministratoriList/GetElencoAmministratoriList"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()


            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodTab", codice)
            client.DefaultRequestHeaders.Add("parmCodEle", filtro)

            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoAmministratori())(dati)
                For i As Integer = 0 To lista.Count - 1
                    elenco.Add(lista(i))
                Next
            End If

            'test = RestResponse.StatusCode.ToString

            Return elenco

        Catch EX As Exception
            Return elenco
        End Try

    End Function

    Public Async Function getTecnico(codice As String) As Threading.Tasks.Task(Of tecnico)
        Dim tec As New tecnico


        Try
            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/Anagrafiche/GetTecnico/GetTecnico"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()


            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("parmCodTab", codice)

            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                tec = Newtonsoft.Json.JsonConvert.DeserializeObject(Of tecnico)(dati)
            End If

            'test = RestResponse.StatusCode.ToString

            Return tec

        Catch EX As Exception
            Return tec
        End Try

    End Function

End Class
