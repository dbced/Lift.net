Public Class parmGetLogs
    Dim r_utente As String
    Dim r_tipolog As String
    Dim r_dataDa As String
    Dim r_dataA As String

    Public Property utente() As String
        Get
            Return r_utente
        End Get

        Set(ByVal Value As String)
            r_utente = Value
        End Set
    End Property

    Public Property tipoLog() As String
        Get
            Return r_tipolog
        End Get

        Set(ByVal Value As String)
            r_tipolog = Value
        End Set
    End Property

    Public Property DataInizio() As String
        Get
            Return r_dataDa
        End Get

        Set(ByVal Value As String)
            r_dataDa = Value
        End Set
    End Property

    Public Property DataFine() As String
        Get
            Return r_dataA
        End Get

        Set(ByVal Value As String)
            r_dataA = Value
        End Set
    End Property

End Class
