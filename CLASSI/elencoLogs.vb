Public Class elencoLogs
    Dim r_ID As Integer
    Dim r_UTENTE As String
    Dim r_DESCR As String
    Dim r_DATA As String
    Dim r_TIPOLOG As String
    Dim r_LIVLOG As Integer

    Public Property idLog() As Integer
        Get
            Return r_ID
        End Get

        Set(ByVal Value As Integer)
            r_ID = Value
        End Set
    End Property

    Public Property UtenteLog() As String
        Get
            Return r_UTENTE
        End Get

        Set(ByVal Value As String)
            r_UTENTE = Value
        End Set
    End Property

    Public Property dataLog() As String
        Get
            Return r_DATA
        End Get

        Set(ByVal Value As String)
            r_DATA = Value
        End Set

    End Property

    Public Property descrLog() As String
        Get
            Return r_DESCR
        End Get

        Set(ByVal Value As String)
            r_DESCR = Value
        End Set
    End Property

    Public Property tipoLog() As String
        Get
            Return r_TIPOLOG
        End Get

        Set(ByVal Value As String)
            r_TIPOLOG = Value
        End Set
    End Property
    Public Property LivelloLog() As Integer
        Get
            Return r_LIVLOG
        End Get

        Set(ByVal Value As Integer)
            r_LIVLOG = Value
        End Set
    End Property
End Class
