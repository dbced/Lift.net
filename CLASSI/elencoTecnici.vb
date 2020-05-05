Public Class elencoTecnici
    Dim r_ATRAG As String
    Dim r_ATCOD As String
    Dim r_ATIME As String
    Dim r_ATQUA As String
    Dim r_ATCEN As String
    Dim r_DESQUA As String

    Public Property ATRAG() As String
        Get
            Return r_ATRAG
        End Get

        Set(ByVal Value As String)
            r_ATRAG = Value
        End Set
    End Property

    Public Property ATCOD() As String
        Get
            Return r_ATCOD
        End Get

        Set(ByVal Value As String)
            r_ATCOD = Value
        End Set
    End Property

    Public Property ATIME() As String
        Get
            Return r_ATIME
        End Get

        Set(ByVal Value As String)
            r_ATIME = Value
        End Set

    End Property

    Public Property ATQUA() As String
        Get
            Return r_ATQUA
        End Get

        Set(ByVal Value As String)
            r_ATQUA = Value
        End Set
    End Property

    Public Property ATCEN() As String
        Get
            Return r_ATCEN
        End Get

        Set(ByVal Value As String)
            r_ATCEN = Value
        End Set
    End Property

    Public Property DESQUA() As String
        Get
            Return r_DESQUA
        End Get

        Set(ByVal Value As String)
            r_DESQUA = Value
        End Set
    End Property

End Class
