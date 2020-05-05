Public Class elencoManutenzioni
    Dim r_ID As Long
    Dim r_CDSOC As String
    Dim r_CDCEN As String
    Dim r_CDIMP As String
    Dim r_DTINI As Date
    Dim r_DTFIN As Date
    Dim r_DTEFF As Date
    Dim r_TPMAN As String
    Dim r_NRBOL As Long
    Dim r_AABOL As Integer
    Dim r_FLFIR As String
    Dim R_FLMAN As String
    Dim r_FLSCA As String
    Dim r_DTBOL As Date
    Dim r_DTGEN As Date
    Dim r_DTMAN As Date
    Dim r_DTCHI As Date
    Dim r_DTUPD As Date
    Dim r_FONTE As String
    Dim r_DESCR As String

    Public Property id() As Long
        Get
            Return r_ID
        End Get

        Set(ByVal Value As Long)
            r_ID = Value
        End Set
    End Property

    Public Property codSocieta() As String
        Get
            Return r_CDSOC
        End Get

        Set(ByVal Value As String)
            r_CDSOC = Value
        End Set
    End Property

    Public Property CodCentro() As String
        Get
            Return r_CDCEN
        End Get

        Set(ByVal Value As String)
            r_CDCEN = Value
        End Set
    End Property

    Public Property CodImpianto() As String
        Get
            Return r_CDIMP
        End Get

        Set(ByVal Value As String)
            r_CDIMP = Value
        End Set
    End Property

    Public Property dataInizio() As Date
        Get
            Return r_DTINI
        End Get

        Set(ByVal Value As Date)
            r_DTINI = Value
        End Set
    End Property

    Public Property dataFine() As Date
        Get
            Return r_DTFIN
        End Get

        Set(ByVal Value As Date)
            r_DTFIN = Value
        End Set

    End Property

    Public Property dataEffett() As Date
        Get
            Return r_DTEFF
        End Get

        Set(ByVal Value As Date)
            r_DTEFF = Value
        End Set

    End Property

    Public Property tipoVisita() As String
        Get
            Return r_TPMAN
        End Get

        Set(ByVal Value As String)
            r_TPMAN = Value
        End Set
    End Property

    Public Property numBoll() As Long
        Get
            Return r_NRBOL
        End Get

        Set(ByVal Value As Long)
            r_NRBOL = Value
        End Set
    End Property

    Public Property annoBoll() As Integer
        Get
            Return r_AABOL
        End Get

        Set(ByVal Value As Integer)
            r_AABOL = Value
        End Set
    End Property

    Public Property flagFirmato() As String
        Get
            Return r_FLFIR
        End Get

        Set(ByVal Value As String)
            r_FLFIR = Value
        End Set

    End Property

    Public Property flagManuale() As String
        Get
            Return R_FLMAN
        End Get

        Set(ByVal Value As String)
            R_FLMAN = Value
        End Set
    End Property

    Public Property flagScambiato() As String
        Get
            Return r_FLSCA
        End Get

        Set(ByVal Value As String)
            r_FLSCA = Value
        End Set
    End Property

    Public Property dataGenBoll() As Date
        Get
            Return r_DTBOL
        End Get

        Set(ByVal Value As Date)
            r_DTBOL = Value
        End Set

    End Property

    Public Property dataGenVisita() As Date
        Get
            Return r_DTGEN
        End Get

        Set(ByVal Value As Date)
            r_DTGEN = Value
        End Set

    End Property

    Public Property dataInsManuale() As Date
        Get
            Return r_DTMAN
        End Get

        Set(ByVal Value As Date)
            r_DTMAN = Value
        End Set

    End Property

    Public Property dataChiusura() As Date
        Get
            Return r_DTCHI
        End Get

        Set(ByVal Value As Date)
            r_DTCHI = Value
        End Set

    End Property

    Public Property dataAggiorn() As Date
        Get
            Return r_DTUPD
        End Get

        Set(ByVal Value As Date)
            r_DTUPD = Value
        End Set

    End Property

    Public Property FonteChiusura() As String
        Get
            Return r_FONTE
        End Get

        Set(ByVal Value As String)
            r_FONTE = Value
        End Set

    End Property

    Public Property DescrMan() As String
        Get
            Return r_DESCR
        End Get

        Set(ByVal Value As String)
            r_DESCR = Value
        End Set
    End Property

End Class
