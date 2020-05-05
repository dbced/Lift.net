Public Class tecnico
    Inherits elencoTecnici

    Dim r_ATZON As String
    Dim r_ATPWD As String
    Dim r_ATFLG As String
    Dim r_ATINV As String

    Public Property ATZON() As String
        Get
            Return r_ATZON
        End Get

        Set(ByVal Value As String)
            r_ATZON = Value
        End Set
    End Property

    Public Property ATPWD() As String
        Get
            Return r_ATPWD
        End Get

        Set(ByVal Value As String)
            r_ATPWD = Value
        End Set
    End Property

    Public Property ATFLG() As String
        Get
            Return r_ATFLG
        End Get

        Set(ByVal Value As String)
            r_ATFLG = Value
        End Set
    End Property

    Public Property ATINV() As String
        Get
            Return r_ATINV
        End Get

        Set(ByVal Value As String)
            r_ATINV = Value
        End Set
    End Property

End Class
