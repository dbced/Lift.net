Public Class parmPostParVisAsset
    Dim r_CDMAN As String
    Dim r_DESCR As String
    Dim r_CDCAT As String
    Dim r_CDIMP As String
    Dim r_CDASS As String
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
    Dim r_azione As String
    Dim r_id As Integer
    Dim r_esec As Integer

    Public Property id() As Integer
        Get
            Return r_id
        End Get

        Set(ByVal Value As Integer)
            r_id = Value
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

    Public Property CodiceVisita() As String
        Get
            Return r_CDMAN
        End Get

        Set(ByVal Value As String)
            r_CDMAN = Value
        End Set
    End Property

    Public Property CodiceAsset() As String
        Get
            Return r_CDASS
        End Get

        Set(ByVal Value As String)
            r_CDASS = Value
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
            Return R_esec
        End Get

        Set(ByVal Value As Integer)
            R_esec = Value
        End Set
    End Property

End Class
