Public Class parmImpianti
    Dim r_parmSoc As List(Of societa)
    Dim r_parmCen As List(Of centri)
    Dim r_parmCodCli As String
    Dim r_parmCodImp As String

    Public Property parmSoc() As List(Of societa)

        Get
            Return r_parmSoc
        End Get

        Set(ByVal Value As List(Of societa))
            r_parmSoc = Value
        End Set

    End Property

    Public Property parmCentro() As List(Of centri)
        Get
            Return r_parmCen
        End Get

        Set(ByVal Value As List(Of centri))
            r_parmCen = Value
        End Set

    End Property

    Public Property parmCodCli() As String
        Get
            Return r_parmCodCli
        End Get

        Set(ByVal Value As String)
            r_parmCodCli = Value
        End Set
    End Property

    Public Property parmCodImpianto() As String
        Get
            Return r_parmCodImp
        End Get

        Set(ByVal Value As String)
            r_parmCodImp = Value
        End Set
    End Property

End Class

Public Class centri
    Dim r_parmCen As String

    Public Property Centro() As String
        Get
            Return r_parmCen
        End Get

        Set(ByVal Value As String)
            r_parmCen = Value
        End Set
    End Property

End Class

Public Class societa
    Dim r_parmSoc As String

    Public Property societa() As String
        Get
            Return r_parmSoc
        End Get

        Set(ByVal Value As String)
            r_parmSoc = Value
        End Set
    End Property

End Class
