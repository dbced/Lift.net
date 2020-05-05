Public Class elencoDocumenti
    Dim r_annoInt As Integer
    Dim r_numInt As Integer
    Dim r_dataDoc As Date
    Dim r_TipoDoc As String
    Dim r_soc As String
    Dim r_AnnoDoc As Integer
    Dim r_NumDoc As Integer
    Dim r_cdcli As String
    Dim r_RagSoc As String
    Dim r_ImpDoc As Double
    Dim r_Indirizzo As String
    Dim r_centro As String
    Dim r_edocdb As String

    Public Property CodiceCLiente() As String
        Get
            Return r_cdcli
        End Get

        Set(ByVal Value As String)
            r_cdcli = Value
        End Set
    End Property

    Public Property RagioneSociale() As String
        Get
            Return r_RagSoc
        End Get

        Set(ByVal Value As String)
            r_RagSoc = Value
        End Set
    End Property

    Public Property NumDocInt() As Integer
        Get
            Return r_numInt
        End Get

        Set(ByVal Value As Integer)
            r_numInt = Value
        End Set
    End Property

    Public Property annoDocInt() As Integer
        Get
            Return r_numInt
        End Get

        Set(ByVal Value As Integer)
            r_numInt = Value
        End Set
    End Property

    Public Property DataDoc() As Date
        Get
            Return r_dataDoc
        End Get

        Set(ByVal Value As Date)
            r_dataDoc = Value
        End Set
    End Property

    Public Property NumDoc() As Integer
        Get
            Return r_NumDoc
        End Get

        Set(ByVal Value As Integer)
            r_NumDoc = Value
        End Set
    End Property

    Public Property annoDoc() As Integer
        Get
            Return r_AnnoDoc
        End Get

        Set(ByVal Value As Integer)
            r_AnnoDoc = Value
        End Set
    End Property

    Public Property Importo() As Double
        Get
            Return r_ImpDoc
        End Get

        Set(ByVal Value As Double)
            r_ImpDoc = Value
        End Set
    End Property

    Public Property Indirizzo() As String
        Get
            Return r_Indirizzo
        End Get

        Set(ByVal Value As String)
            r_Indirizzo = Value
        End Set
    End Property

    Public Property Centro() As String
        Get
            Return r_centro
        End Get

        Set(ByVal Value As String)
            r_centro = Value
        End Set
    End Property

    Public Property EDOC_db() As String
        Get
            Return r_edocdb
        End Get

        Set(ByVal Value As String)
            r_edocdb = Value
        End Set

    End Property

End Class
