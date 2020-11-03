Public Class elencoManutDefault
    Dim r_CDMAN As String
    Dim r_DESCR As String
    Dim r_CDCAT As String
    Dim r_CDIMP As String
    Dim r_FLCICL As String
    Dim r_FLORD As String
    Dim r_FLSEM As String
    Dim r_FLSTAG As String
    Dim r_FLBIE As String
    Dim r_FLOBL As String
    Dim r_FLDTOBL As String
    Dim R_FREQ As Integer
    Dim r_GGSTUP As Integer
    Dim r_GGMMI As String
    Dim r_GGMMF As String
    Dim r_ID As Integer
    Dim r_esec As Integer

    Public Property ID() As Integer
        Get
            Return r_ID
        End Get

        Set(ByVal Value As Integer)
            r_ID = Value
        End Set
    End Property
    Public Property CodiceVisita() As String
        Get
            Return r_CDMAN
        End Get

        Set(ByVal Value As String)
            r_CDMAN = Value
        End Set
    End Property

    Public Property DescrVisita() As String
        Get
            Return r_DESCR
        End Get

        Set(ByVal Value As String)
            r_DESCR = Value
        End Set
    End Property

    Public Property CodiceCateg() As String
        Get
            Return r_CDCAT
        End Get

        Set(ByVal Value As String)
            r_CDCAT = Value
        End Set
    End Property

    Public Property CodiceImpianto() As String
        Get
            Return r_CDIMP
        End Get

        Set(ByVal Value As String)
            r_CDIMP = Value
        End Set
    End Property

    Public Property flagVisCiclica() As String
        Get
            Return r_FLCICL
        End Get

        Set(ByVal Value As String)
            r_FLCICL = Value
        End Set
    End Property

    Public Property flagVisOrdinaria() As String
        Get
            Return r_FLORD
        End Get

        Set(ByVal Value As String)
            r_FLORD = Value
        End Set
    End Property

    Public Property flagVisSemestrale() As String
        Get
            Return r_FLSEM
        End Get

        Set(ByVal Value As String)
            r_FLSEM = Value
        End Set
    End Property

    Public Property flagVisStagionale() As String
        Get
            Return r_FLSTAG
        End Get

        Set(ByVal Value As String)
            r_FLSTAG = Value
        End Set

    End Property

    Public Property flagVisBiennale() As String
        Get
            Return r_FLBIE
        End Get

        Set(ByVal Value As String)
            r_FLBIE = Value
        End Set
    End Property

    Public Property flagVisOblig() As String
        Get
            Return r_FLOBL
        End Get

        Set(ByVal Value As String)
            r_FLOBL = Value
        End Set
    End Property

    Public Property flagUltimaDataVisita() As String
        Get
            Return r_FLDTOBL
        End Get

        Set(ByVal Value As String)
            r_FLDTOBL = Value
        End Set

    End Property

    Public Property Frequenza() As Integer
        Get
            Return R_FREQ
        End Get

        Set(ByVal Value As Integer)
            R_FREQ = Value
        End Set
    End Property

    Public Property ggSturtup() As Integer
        Get
            Return r_GGSTUP
        End Get

        Set(ByVal Value As Integer)
            r_GGSTUP = Value
        End Set
    End Property

    Public Property PeriodoIniz() As String
        Get
            Return r_GGMMI
        End Get

        Set(ByVal Value As String)
            r_GGMMI = Value
        End Set

    End Property

    Public Property PeriodoFin() As String
        Get
            Return r_GGMMF
        End Get

        Set(ByVal Value As String)
            r_GGMMF = Value
        End Set

    End Property

    Public Property TempoEsec() As Integer
        Get
            Return r_esec
        End Get

        Set(ByVal Value As Integer)
            r_esec = Value
        End Set

    End Property

End Class
