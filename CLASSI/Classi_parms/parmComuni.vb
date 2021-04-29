Public Class parmComuni
    Dim r_Prov As String
    Dim r_Loc As String
    Dim r_cap As String

    Public Property prov() As String
        Get
            Return r_Prov
        End Get

        Set(ByVal Value As String)
            r_Prov = Value
        End Set
    End Property

    Public Property localita() As String
        Get
            Return r_Loc
        End Get

        Set(ByVal Value As String)
            r_Loc = Value
        End Set
    End Property

    Public Property cap() As String
        Get
            Return r_cap
        End Get

        Set(ByVal Value As String)
            r_cap = Value
        End Set
    End Property

End Class
