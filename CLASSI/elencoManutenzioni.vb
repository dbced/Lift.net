Public Class elencoManutenzioni
    Dim r_ID As Long
    Dim r_CDSOC As String
    Dim r_CDCEN As String
    Dim r_CDIMP As String
    Dim r_DTINI As String
    Dim r_DTFIN As String
    Dim r_DTEFF As String
    Dim r_TPMAN As String
    Dim r_NRBOL As Long
    Dim r_AABOL As Integer
    Dim r_FLFIR As String
    Dim R_FLMAN As String
    Dim r_FLSCA As String
    Dim r_DTBOL As String
    Dim r_DTGEN As String
    Dim r_DTMAN As String
    Dim r_DTCHI As String
    Dim r_DTUPD As String
    Dim r_FONTE As String
    Dim r_DESCR As String
    Dim r_DESCRIMP As String
    Dim r_TIPOIMP As String
    Dim r_MATR As String
    Dim r_TSINI As String
    Dim r_TSFIN As String
    Dim r_TSEFF As String
    Dim r_NOTE As String
    Dim r_CDABR As String
    Dim r_FLNDI As String
    Dim r_DESSQ As String
    Dim r_FLSTA As String
    Dim r_DESST As String
    Dim r_IDSQU As Integer

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

    Public Property dataInizio() As String
        Get
            Return r_DTINI
        End Get

        Set(ByVal Value As String)
            r_DTINI = Value
        End Set
    End Property

    Public Property dataFine() As String
        Get
            Return r_DTFIN
        End Get

        Set(ByVal Value As String)
            r_DTFIN = Value
        End Set

    End Property

    Public Property dataEffett() As String
        Get
            Return r_DTEFF
        End Get

        Set(ByVal Value As String)
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

    Public Property dataGenBoll() As String
        Get
            Return r_DTBOL
        End Get

        Set(ByVal Value As String)
            r_DTBOL = Value
        End Set

    End Property

    Public Property dataGenVisita() As String
        Get
            Return r_DTGEN
        End Get

        Set(ByVal Value As String)
            r_DTGEN = Value
        End Set

    End Property

    Public Property dataInsManuale() As String
        Get
            Return r_DTMAN
        End Get

        Set(ByVal Value As String)
            r_DTMAN = Value
        End Set

    End Property

    Public Property dataChiusura() As String
        Get
            Return r_DTCHI
        End Get

        Set(ByVal Value As String)
            r_DTCHI = Value
        End Set

    End Property

    Public Property dataAggiorn() As String
        Get
            Return r_DTUPD
        End Get

        Set(ByVal Value As String)
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

    Public Property descrImpianto() As String
        Get
            Return r_DESCRIMP
        End Get

        Set(ByVal Value As String)
            r_DESCRIMP = Value
        End Set
    End Property

    Public Property TipoImpianto() As String
        Get
            Return r_TIPOIMP
        End Get

        Set(ByVal Value As String)
            r_TIPOIMP = Value
        End Set
    End Property

    Public Property Matricola() As String
        Get
            Return r_MATR
        End Get

        Set(ByVal Value As String)
            r_MATR = Value
        End Set
    End Property

    Public Property dataInizioTS() As String
        Get
            Return r_TSINI
        End Get

        Set(ByVal Value As String)
            r_TSINI = Value
        End Set
    End Property

    Public Property dataFineTS() As String
        Get
            Return r_TSFIN
        End Get

        Set(ByVal Value As String)
            r_TSFIN = Value
        End Set

    End Property

    Public Property dataEffettTS() As String
        Get
            Return r_TSEFF
        End Get

        Set(ByVal Value As String)
            r_TSEFF = Value
        End Set

    End Property

    Public Property note() As String
        Get
            Return r_NOTE
        End Get

        Set(ByVal Value As String)
            r_NOTE = Value
        End Set

    End Property

    Public Property cdabbrev() As String
        Get
            Return r_CDABR
        End Get

        Set(ByVal Value As String)
            r_CDABR = Value
        End Set

    End Property

    Public Property idsquadra() As Integer
        Get
            Return r_IDSQU
        End Get

        Set(ByVal Value As Integer)
            r_IDSQU = Value
        End Set

    End Property

    Public Property des_squadra() As String
        Get
            Return r_DESSQ
        End Get

        Set(ByVal Value As String)
            r_DESSQ = Value
        End Set

    End Property

    Public Property flagDiurnoNotturno() As String
        Get
            Return r_FLNDI
        End Get

        Set(ByVal Value As String)
            r_FLNDI = Value
        End Set

    End Property

    Public Property flagStatoVisita() As String
        Get
            Return r_FLSTA
        End Get

        Set(ByVal Value As String)
            r_FLSTA = Value
        End Set

    End Property

    Public Property DescStatoVisita() As String
        Get
            Return r_DESST
        End Get

        Set(ByVal Value As String)
            r_DESST = Value
        End Set

    End Property


End Class
