Public Class parmsRicContratti
    Dim r_parmSoc As List(Of lista_societa)
    Dim r_parmCen As List(Of lista_centri)
    Dim r_parmCodCli As String
    Dim r_parmCodImp As String
    Dim r_parmCodCtr As String
    Dim r_parmCtrAttivi As String


    Public Property parmSoc() As List(Of lista_societa)

        Get
            Return r_parmSoc
        End Get

        Set(ByVal Value As List(Of lista_societa))
            r_parmSoc = Value
        End Set

    End Property

    Public Property parmCentro() As List(Of lista_centri)
        Get
            Return r_parmCen
        End Get

        Set(ByVal Value As List(Of lista_centri))
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

    Public Property parmCodContratto() As String
        Get
            Return r_parmCodCtr
        End Get

        Set(ByVal Value As String)
            r_parmCodCtr = Value
        End Set
    End Property

    Public Property parmCtrAttivi() As String
        Get
            Return r_parmCtrAttivi
        End Get

        Set(ByVal Value As String)
            r_parmCtrAttivi = Value
        End Set
    End Property

End Class

Public Class lista_centri
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

Public Class lista_societa
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
