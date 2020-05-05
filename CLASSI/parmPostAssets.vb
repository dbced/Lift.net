Public Class parmPostAssets
    Dim r_CHID As Integer
    Dim r_CHCDCAT As String
    Dim r_CHDESCR As String
    Dim r_CDIMP As String
    Dim r_CTCODICE As String
    Dim r_azione As String
    Dim r_NRASS As Integer
    Dim r_FLPIAN As String

    Public Property CHID() As Integer
        Get
            Return r_CHID
        End Get

        Set(ByVal Value As Integer)
            r_CHID = Value
        End Set
    End Property

    Public Property CHCDCAT() As String
        Get
            Return r_CHCDCAT
        End Get

        Set(ByVal Value As String)
            r_CHCDCAT = Value
        End Set
    End Property

    Public Property CHDESCR() As String
        Get
            Return r_CHDESCR
        End Get

        Set(ByVal Value As String)
            r_CHDESCR = Value
        End Set
    End Property

    Public Property CodCatAsset() As String
        Get
            Return r_CTCODICE
        End Get

        Set(ByVal Value As String)
            r_CTCODICE = Value
        End Set
    End Property

    Public Property azione() As String
        Get
            Return r_azione
        End Get

        Set(ByVal Value As String)
            r_azione = Value
        End Set
    End Property

    Public Property CODIMP() As String
        Get
            Return r_CDIMP
        End Get

        Set(ByVal Value As String)
            r_CDIMP = Value
        End Set
    End Property

    Public Property NUMASSETS() As Integer
        Get
            Return r_NRASS
        End Get

        Set(ByVal Value As Integer)
            r_NRASS = Value
        End Set
    End Property

    Public Property flagPianifica() As String
        Get
            Return r_FLPIAN
        End Get

        Set(ByVal Value As String)
            r_FLPIAN = Value
        End Set
    End Property

End Class