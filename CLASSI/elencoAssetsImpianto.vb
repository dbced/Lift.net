Public Class elencoAssetsImpianto
    Dim r_CHID As Integer
    Dim r_CHCDCAT As String
    Dim r_CHDESCR As String
    Dim r_AICIM As String
    Dim r_NUMCHL As Integer
    Dim r_descrMacroCat As String
    Dim r_descrCat As String
    Dim r_CTCODICE As String
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

    Public Property CDIMP() As String
        Get
            Return r_AICIM
        End Get

        Set(ByVal Value As String)
            r_AICIM = Value
        End Set
    End Property

    Public Property NUMCHL() As Integer
        Get
            Return r_NUMCHL
        End Get

        Set(ByVal Value As Integer)
            r_NUMCHL = Value
        End Set
    End Property

    Public Property DESCRCAT() As String
        Get
            Return r_descrCat
        End Get

        Set(ByVal Value As String)
            r_descrCat = Value
        End Set
    End Property

    Public Property DESCRMACROCAT() As String
        Get
            Return r_descrMacroCat
        End Get

        Set(ByVal Value As String)
            r_descrMacroCat = Value
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

    Public Property flagPianifica() As String
        Get
            Return r_FLPIAN
        End Get

        Set(ByVal Value As String)
            r_FLPIAN = Value
        End Set
    End Property

End Class
