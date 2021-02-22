Public Class elencoAgenti
    Dim r_RASCL As String
    Dim r_CDFIS As String
    Dim r_CDAGE As String
    Dim r_CPAIV As String
    Dim r_INDCL As String
    Dim r_LOCCL As String
    Dim r_PROV As String
    Dim r_CAP As String
    Dim r_TEL As String
    Dim r_FLGINT As String
    Dim r_CENTRO As String

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

    Public Property CDAGE() As String
        Get
            Return r_CDAGE
        End Get

        Set(ByVal Value As String)
            r_CDAGE = Value
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

    Public Property LOCCL() As String
        Get
            Return r_LOCCL
        End Get

        Set(ByVal Value As String)
            r_LOCCL = Value
        End Set
    End Property

    Public Property PROV() As String
        Get
            Return r_PROV
        End Get

        Set(ByVal Value As String)
            r_PROV = Value
        End Set
    End Property

    Public Property TEL() As String
        Get
            Return r_TEL
        End Get

        Set(ByVal Value As String)
            r_TEL = Value
        End Set
    End Property

    Public Property FLGINT() As String
        Get
            Return r_FLGINT
        End Get

        Set(ByVal Value As String)
            r_FLGINT = Value
        End Set
    End Property

    Public Property CENTRO() As String
        Get
            Return r_CENTRO
        End Get

        Set(ByVal Value As String)
            r_CENTRO = Value
        End Set
    End Property

End Class
