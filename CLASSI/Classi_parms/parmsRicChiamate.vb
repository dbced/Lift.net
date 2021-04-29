Public Class parmsRicChiamate
    Inherits parmsRicContratti

    Private r_parmchiamateAssegnate As String
    Private r_parmchiamateChiuse As String
    Private r_parmchiamateSospese As String
    Private r_parmDataAperturaDa As String
    Private r_parmDataAperturaA As String
    Private r_parmTecnico As String
    Private r_parmImpiantiCritici As String
    Private r_parmImpiantiNonCritici As String
    Private r_parmChiamateReper As String
    Private r_parmChiamateReperSabato As String
    Private r_parmChiamateIntrap As String
    Private r_parmImpiantiFermi As String
    Private r_parmImpiantiFunz As String
    Private r_parmImpiantiDisdetti As String
    Private r_parmStati As List(Of parmTabelle)
    Private r_ID As Integer
    Private r_parmDataChiusuraDa As String
    Private r_parmDataChiusuraA As String

    Public Property parmchiamateAssegnate() As String
        Get
            Return r_parmchiamateAssegnate
        End Get

        Set(ByVal Value As String)
            r_parmchiamateAssegnate = Value
        End Set
    End Property

    Public Property parmchiamateChiuse() As String
        Get
            Return r_parmchiamateChiuse
        End Get

        Set(ByVal Value As String)
            r_parmchiamateChiuse = Value
        End Set
    End Property

    Public Property parmchiamateSospese() As String
        Get
            Return r_parmchiamateSospese
        End Get

        Set(ByVal Value As String)
            r_parmchiamateSospese = Value
        End Set
    End Property

    Public Property parmDataAperturaDa() As String
        Get
            Return r_parmDataAperturaDa
        End Get

        Set(ByVal Value As String)
            r_parmDataAperturaDa = Value
        End Set
    End Property

    Public Property parmDataAperturaA() As String
        Get
            Return r_parmDataAperturaA
        End Get

        Set(ByVal Value As String)
            r_parmDataAperturaA = Value
        End Set
    End Property

    Public Property parmDataChiusuraDa() As String
        Get
            Return r_parmDataChiusuraDa
        End Get

        Set(ByVal Value As String)
            r_parmDataChiusuraDa = Value
        End Set
    End Property

    Public Property parmDataChiusruraA() As String
        Get
            Return r_parmDataChiusuraA
        End Get

        Set(ByVal Value As String)
            r_parmDataChiusuraA = Value
        End Set
    End Property

    Public Property parmTecnico() As String
        Get
            Return r_parmTecnico
        End Get

        Set(ByVal Value As String)
            r_parmTecnico = Value
        End Set
    End Property

    Public Property parmImpiantiCritici() As String
        Get
            Return r_parmImpiantiCritici
        End Get

        Set(ByVal Value As String)
            r_parmImpiantiCritici = Value
        End Set
    End Property

    Public Property parmImpiantiNonCritici() As String
        Get
            Return r_parmImpiantiNonCritici
        End Get

        Set(ByVal Value As String)
            r_parmImpiantiNonCritici = Value
        End Set
    End Property

    Public Property parmChiamateReper() As String
        Get
            Return r_parmChiamateReper
        End Get

        Set(ByVal Value As String)
            r_parmChiamateReper = Value
        End Set
    End Property

    Public Property parmChiamateReperSabato() As String
        Get
            Return r_parmChiamateReperSabato
        End Get

        Set(ByVal Value As String)
            r_parmChiamateReperSabato = Value
        End Set
    End Property

    Public Property parmChiamateIntrap() As String
        Get
            Return r_parmChiamateIntrap
        End Get

        Set(ByVal Value As String)
            r_parmChiamateIntrap = Value
        End Set
    End Property

    Public Property parmImpiantiFermi() As String
        Get
            Return r_parmImpiantiFermi
        End Get

        Set(ByVal Value As String)
            r_parmImpiantiFermi = Value
        End Set
    End Property

    Public Property parmImpiantiFunz() As String
        Get
            Return r_parmImpiantiFunz
        End Get

        Set(ByVal Value As String)
            r_parmImpiantiFunz = Value
        End Set
    End Property

    Public Property parmImpiantiDisdetti() As String
        Get
            Return r_parmImpiantiDisdetti
        End Get

        Set(ByVal Value As String)
            r_parmImpiantiDisdetti = Value
        End Set
    End Property

    Public Property idChiamata() As Integer
        Get
            Return r_ID
        End Get

        Set(ByVal Value As Integer)
            r_ID = Value
        End Set
    End Property

    Public Property parmStati() As List(Of parmTabelle)

        Get
            Return r_parmStati
        End Get

        Set(ByVal Value As List(Of parmTabelle))
            r_parmStati = Value
        End Set

    End Property

End Class
