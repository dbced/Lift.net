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

    Public Async Function getDatiTabellaComboImpianti(codTab As String, Optional codElem As String = "") As Threading.Tasks.Task(Of elenco())
        Dim varses() As elenco

        Try
            Dim test As String
            Dim RestURL As String = My.Settings.urlWS & "api/anagrafiche/GetElencoImpiantiComboList/GetElencoImpiantiComboList"
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
                varses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elenco())(test)
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
                                                      Optional IdVisita As Integer = 0, Optional IdSquadra As Integer = 0,
                                                      Optional DataChiDal As String = "", Optional DataChiAl As String = "",
                                                      Optional flErrate As String = "", Optional flChiuse As String = "") As Threading.Tasks.Task(Of List(Of elencoManutenzioni))
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
            client.DefaultRequestHeaders.Add("parmDataChiusuraDal", DataChiDal)
            client.DefaultRequestHeaders.Add("parmDataChiusuraAl", DataChiAl)
            client.DefaultRequestHeaders.Add("parmErrate", flErrate)
            client.DefaultRequestHeaders.Add("parmChiuse", flChiuse)
            'parmChiuse
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


    Public Async Function getStatChiamateImpianto(CodImp As String, Optional anno As String = "", Optional Stati As String = "", Optional Centri As String = "") As Threading.Tasks.Task(Of List(Of statChiamateImpianto))
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

            client.DefaultRequestHeaders.Add("parmStati", Stati)
            client.DefaultRequestHeaders.Add("parmCentri", Centri)

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

    Public Async Function getDocumentiImpianto(CodImp As String, Optional anno As String = "", Optional cliente As String = "", Optional idAccordo As String = "", Optional idcontratto As String = "") As Threading.Tasks.Task(Of List(Of elencoDocumenti))
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
            client.DefaultRequestHeaders.Add("parmContratto", idcontratto)
            client.DefaultRequestHeaders.Add("parmAccordo", idAccordo)

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

    Public Async Function getElencoTecnici(codice As String, codEle As String, filtro As String) As Threading.Tasks.Task(Of List(Of elencoTecnici))
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
            client.DefaultRequestHeaders.Add("parmCodEle", codEle)
            client.DefaultRequestHeaders.Add("parmFiltro", filtro)

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

    Public Async Function getElencoAgenti(codice As String, filtro As String) As Threading.Tasks.Task(Of List(Of elencoAgenti))
        Dim elenco As New List(Of elencoAgenti)
        Dim lista() As elencoAgenti

        Try
            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/Anagrafiche/GetElencoAgentiList/GetElencoAgentiList"
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
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoAgenti())(dati)
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

    Public Async Function getElencoLogVisite(utente As String, tipo As String, Optional dataDa As String = "", Optional dataA As String = "") As Threading.Tasks.Task(Of List(Of elencoLogs))
        Dim elenco As New List(Of elencoLogs)
        Dim lista() As elencoLogs
        Try

            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/visite/getLogsVisiteList/getLogsVisiteList"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            client.DefaultRequestHeaders.Add("parmUtente", utente)
            client.DefaultRequestHeaders.Add("parmTipoLog", tipo)
            client.DefaultRequestHeaders.Add("parmDataInizio", dataDa)
            client.DefaultRequestHeaders.Add("parmDataFine", dataA)

            Dim parmLog As parmGetLogs = New parmGetLogs

            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoLogs())(dati)
                For i As Integer = 0 To lista.Count - 1
                    elenco.Add(lista(i))
                Next
            End If

            Return elenco

        Catch EX As Exception
            Return elenco
        End Try
    End Function

    Public Async Function getSchedaContratto(idContratto As String) As Threading.Tasks.Task(Of elencoListaContratti)
        Dim contratto As elencoListaContratti

        Try

            Dim jsoncontratto As String
            Dim RestURL As String = My.Settings.urlWS & "api/Contratti/SchedaContratto/GetSchedaContratto"
            Dim client As New Http.HttpClient

            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            Dim parmImp As String = idContratto

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim myContent = jss.Serialize(parmImp)
            RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                jsoncontratto = Await RestResponse.Content.ReadAsStringAsync()
                contratto = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoListaContratti)(jsoncontratto)
            Else
                MsgBox(RestResponse.StatusCode & " " & RestResponse.Content.ToString, vbCritical)
            End If

            Return contratto

        Catch EX As Exception
            MsgBox(EX.Message, vbCritical)
            Return contratto
        End Try

    End Function

    Public Async Function getElencoImpiantiContratto(contratto As String) As Threading.Tasks.Task(Of List(Of elencoImpiantiServiziContratto))
        Dim elenco As New List(Of elencoImpiantiServiziContratto)
        Dim lista() As elencoImpiantiServiziContratto

        Try
            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/Contratti/GetImpiantiContratto/GetImpiantiContratto"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()


            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("contratto", contratto)

            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoImpiantiServiziContratto())(dati)
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

    Public Async Function getElencoServiziContratto(contratto As String, codServizio As String) As Threading.Tasks.Task(Of List(Of elencoServiziContratto))
        Dim elenco As New List(Of elencoServiziContratto)
        Dim lista() As elencoServiziContratto

        Try
            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/Contratti/GetServiziContratto/GetServiziContratto"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()


            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("contratto", contratto)
            client.DefaultRequestHeaders.Add("servizio", codServizio)

            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoServiziContratto())(dati)
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

    Public Async Function getRateContratto(contratto As String) As Threading.Tasks.Task(Of List(Of elencoRateContratto))
        Dim elenco As New List(Of elencoRateContratto)
        Dim lista() As elencoRateContratto

        Try
            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/Contratti/GetRateContratto/GetRateContratto"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("contratto", contratto)

            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoRateContratto())(dati)
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

    Public Async Function getAccordo(id As String) As Threading.Tasks.Task(Of elencoAccordi)
        Dim contratto As elencoAccordi

        Try
            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/Contratti/GetAccordo/GetAccordo"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("contratto", id)

            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                contratto = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoAccordi)(dati)
            End If

            'test = RestResponse.StatusCode.ToString
            Return contratto

        Catch EX As Exception
            contratto.RASCL = EX.Message
            Return contratto
        End Try
    End Function

    Public Async Function getListaContrattiApplicativi(idaccordo As String, id As String, tipo As String) As Threading.Tasks.Task(Of List(Of elencoListaContratti))
        Dim elenco As New List(Of elencoListaContratti)
        Dim lista() As elencoListaContratti

        Try
            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/Contratti/GetListaContrattiApplicativi/GetListaContrattiApplicativi"
            Dim client As New Http.HttpClient

            Dim cl As New elenco

            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("contratto", id)
            client.DefaultRequestHeaders.Add("tipo_contratto", tipo)
            client.DefaultRequestHeaders.Add("accordo", idaccordo)

            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoListaContratti())(dati)
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

    Public Async Function getListaImpianti(listSoc As List(Of societa), listCentri As List(Of centri), Optional codImpianto As String = "", Optional codCli As String = "") As Threading.Tasks.Task(Of List(Of elenco))
        Dim elenco As New List(Of elenco)
        Dim listaImpianti() As elenco

        Try
            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/impianti/ImpiantiListParms/GetImpianti2List"
            Dim client As New Http.HttpClient
            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")

            Dim parmImp As parmImpianti = New parmImpianti

            parmImp.parmSoc = listSoc
            parmImp.parmCentro = listCentri
            parmImp.parmCodCli = codCli
            parmImp.parmCodImpianto = codImpianto

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim myContent = jss.Serialize(parmImp)
            RestURL = RestURL & "?paramList=" & myContent
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()

                listaImpianti = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elenco())(dati)

                For i As Integer = 0 To listaImpianti.Count - 1
                    elenco.Add(listaImpianti(i))
                Next
            End If

            Return elenco

        Catch ex As Exception
            Return elenco
        End Try
    End Function

    Public Async Function getElencoChiamate(parms As parmsRicChiamate) As Threading.Tasks.Task(Of List(Of elencoChiamate))
        Dim elenco As New List(Of elencoChiamate)
        Dim listaChiamate() As elencoChiamate

        Try
            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/Chiamate/GetElencoChiamate/GetElencoChiamate"
            Dim client As New Http.HttpClient
            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim sParms = jss.Serialize(parms)
            client.DefaultRequestHeaders.Add("parmEntry", sParms)
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()

                listaChiamate = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoChiamate())(dati)

                For i As Integer = 0 To listaChiamate.Count - 1
                    elenco.Add(listaChiamate(i))
                Next
            End If

            Return elenco

        Catch ex As Exception
            Return elenco
        End Try
    End Function

    Public Async Function getElencoChiamateMyFleet(IdChiamata As String, centro As String, soc As String, tipoIntervento As String, indAcq As String) As Threading.Tasks.Task(Of List(Of elencoChiamate))
        Dim elenco As New List(Of elencoChiamate)
        Dim listaChiamate() As elencoChiamate

        Try
            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/Chiamate/GetElencoChiamateMyFleet/GetElencoChiamateMyFleet"
            Dim client As New Http.HttpClient
            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            client.DefaultRequestHeaders.Add("idChiamata", IdChiamata)
            client.DefaultRequestHeaders.Add("centro", centro)
            client.DefaultRequestHeaders.Add("soc", soc)
            client.DefaultRequestHeaders.Add("intervento", tipoIntervento)
            client.DefaultRequestHeaders.Add("indacq", indAcq)

            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()

                listaChiamate = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoChiamate())(dati)

                For i As Integer = 0 To listaChiamate.Count - 1
                    elenco.Add(listaChiamate(i))
                Next
            End If

            Return elenco

        Catch ex As Exception
            Return elenco
        End Try
    End Function

    Public Async Function getElencoChiamateTecnicoMyFleet(IdTecnico As String) As Threading.Tasks.Task(Of List(Of elencoChiamate))
        Dim elenco As New List(Of elencoChiamate)
        Dim listaChiamate() As elencoChiamate

        Try
            Dim dati As String
            '{"cod_tec":"9988","from":"2020-01-01","to":"2021-03-03","status":"chi,ass"}

            Dim RestURL As String = "http://git.gruppodelbo.it/api/v1/lift/Av81!udwYSZ0F7GHiozTAPPER_DEADLOCK_PARAD0X/get_chiamate/"
            'Dim Parms As String = String.Format("{""cod_tec:"" ""{0}"" ","from":"" ""{1}"",""to"":""{2}"",""status"":""{3}""}", "A000", "2020-01-01", "2020-12-31", "chi,ass")


            Dim client As New Http.HttpClient
            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()

            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()

                listaChiamate = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elencoChiamate())(dati)

                For i As Integer = 0 To listaChiamate.Count - 1
                    elenco.Add(listaChiamate(i))
                Next
            End If

            Return elenco

        Catch ex As Exception
            Return elenco
        End Try
    End Function

    Public Async Function getElencoOfferte(parms As elencoAssetsImpianto) As Threading.Tasks.Task(Of List(Of elenco))
        Dim elenco As New List(Of elenco)
        Dim offerta() As elenco

        Try
            Dim dati As String
            Dim RestURL As String = My.Settings.urlWS & "api/Offerte/GetOfferteListParms/GetOfferteListParms"
            Dim client As New Http.HttpClient
            Dim cl As New elenco
            Dim paramList As ArrayList = New ArrayList()

            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Add("ApiKey", "12345678ABCD")
            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim sParms = jss.Serialize(parms)
            client.DefaultRequestHeaders.Add("parmEntry", sParms)
            RestURL = RestURL & "?paramList=" & sParms
            Dim RestResponse As Http.HttpResponseMessage = Await client.GetAsync(RestURL)

            If RestResponse.IsSuccessStatusCode Then
                dati = Await RestResponse.Content.ReadAsStringAsync()

                offerta = Newtonsoft.Json.JsonConvert.DeserializeObject(Of elenco())(dati)

                For i As Integer = 0 To offerta.Count - 1
                    elenco.Add(offerta(i))
                Next
            End If
            Return elenco
        Catch ex As Exception
            Return elenco
        End Try
    End Function

End Class
