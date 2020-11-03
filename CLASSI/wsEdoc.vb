
Public Class wsEdoc

    Private clientImages As EdocImages.Images = Nothing

    Private Cookie As System.Net.CookieContainer = New System.Net.CookieContainer()
    Private Const CHUNK As Integer = 1024 * 1024
    Private loginUser As String
    Private LoginPassword As String

    'Public Sub New(ByVal UrlServer As String, ByVal UserName As String, ByVal Password As String)
    'clientImages = New EdocImages.Images()
    'clientImages.CookieContainer = Cookie
    'clientImages.Url = UrlServer & "/images.asmx"
    ''clientImages.Url = "http://srvedoc/images.asmx"
    'loginUser = UserName
    'LoginPassword = Password

    'If Not clientImages.Logon(UserName, Password) Then
    '    Throw New Exception("Utente o password errati")
    'End If
    'End Sub

    Public Function retrive_documento_EDOC(codDB As String, sql As String) As String
        Try

            'Dim sw As New EDOC.Service.Wrapper.EDOCWrapper("http://srvedoc/service.asmx", "rm400", "servizio")
            'Dim docs As Object = sw.MainService.Find("999", "TipoDocumento=014")
            'Dim sw As New EdocService.Service
            'sw.CookieContainer = Cookie
            'sw.Url = "http://srvedoc/service.asmx"
            'Dim aa As Object = sw.Login(loginUser, LoginPassword)
            ''sw.LogOn(loginUser)
            'Dim docs As Object = sw.Find(codDB, sql)

            Dim sw As New EDOC.Service.Wrapper.EDOCWrapper("http://srvedoc/", "rm400", "servizio")
            Dim docs() As Integer = sw.MainService.Find(codDB, sql)
            If docs.Count > 0 Then
                Return docs(0).ToString
            Else
                Return ""
            End If
            'Dim EE As New EDOC.Service.Wrapper.EDOCWrapper("http://srvedoc/", "rm400", "servizio")
            'Dim EE As New EDOC.Service.Wrapper.EDOCWrapper
            'EE.Upload()
            'EE.ImageService.Create()
            'EE.ImageService.Upload()
            'EE.ImageService.UploadGDD()

        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class
