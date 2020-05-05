Public Class elencoClienti
    Dim r_RASCL As String
    Dim r_CDFIS As String
    Dim r_CDCLI As String
    Dim r_CPAIV As String
    Dim r_INDCL As String

    Public Property RASCL() As String
        Get
            Return r_RASCL
        End Get

        Set(ByVal Value As String)
            r_RASCL = Value
        End Set
    End Property

    Public Property CDFIS() As String
        Get
            Return r_CDFIS
        End Get

        Set(ByVal Value As String)
            r_CDFIS = Value
        End Set
    End Property

    Public Property CPAIV() As String
        Get
            Return r_CPAIV
        End Get

        Set(ByVal Value As String)
            r_CPAIV = Value
        End Set
    End Property

    Public Property CDCLI() As String
        Get
            Return r_CDCLI
        End Get

        Set(ByVal Value As String)
            r_CDCLI = Value
        End Set
    End Property


    Public Property INDCL() As String
        Get
            Return r_INDCL
        End Get

        Set(ByVal Value As String)
            r_INDCL = Value
        End Set
    End Property

End Class
