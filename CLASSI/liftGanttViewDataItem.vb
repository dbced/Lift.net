Imports Telerik.WinControls.UI

Public Class liftGanttViewDataItem
    Inherits GanttViewDataItem
    Private _nrBoll As Integer
    Private _aaBoll As Integer
    Private _dataEffett As Date
    Private _tipoImpianto As String
    Private _CodImpianto As String
    Private _DesImpianto As String
    Private _ID As String
    Private _CDSOC As String
    Private _CENTRO As String
    Private _NOTE As String
    Private _SQUADRA As String
    Private _DIURNO As String
    Private _IDSQUADRA As String
    Private _FLSTA As String
    Private _DESST As String
    Private _ORAST As String
    Private _ORAFI As String

    Public Sub New()
    End Sub

    Public Property ID As String
        Get
            Return Me._ID
        End Get

        Set(ByVal value As String)
            Me._ID = value
        End Set
    End Property

    Public Property CodImpianto As String
        Get
            Return Me._CodImpianto
        End Get

        Set(ByVal value As String)
            Me._CodImpianto = value
        End Set
    End Property

    Public Property NrBoll As Integer
        Get
            Return Me._nrBoll
        End Get

        Set(ByVal value As Integer)
            Me._nrBoll = value
        End Set
    End Property

    Public Property AnnoBoll As Integer
        Get
            Return Me._aaBoll
        End Get

        Set(ByVal value As Integer)
            Me._aaBoll = value
        End Set

    End Property
    Public Property dtEffett As Date
        Get
            Return Me._dataEffett
        End Get

        Set(ByVal value As Date)
            Me._dataEffett = value
        End Set
    End Property

    Public Property tipoImpianto As String
        Get
            Return Me._tipoImpianto
        End Get

        Set(ByVal value As String)
            Me._tipoImpianto = value
        End Set
    End Property

    Public Property DesImpianto As String
        Get
            Return Me._DesImpianto
        End Get

        Set(ByVal value As String)
            Me._DesImpianto = value
        End Set
    End Property

    Public Property CdSoc As String
        Get
            Return Me._CDSOC
        End Get

        Set(ByVal value As String)
            Me._CDSOC = value
        End Set
    End Property

    Public Property Centro As String
        Get
            Return Me._CENTRO
        End Get

        Set(ByVal value As String)
            Me._CENTRO = value
        End Set
    End Property

    Public Property Note As String
        Get
            Return Me._NOTE
        End Get

        Set(ByVal value As String)
            Me._NOTE = value
        End Set
    End Property

    Public Property Squadra As String
        Get
            Return Me._SQUADRA
        End Get

        Set(ByVal value As String)
            Me._SQUADRA = value
        End Set
    End Property

    Public Property FlagDiurno As String
        Get
            Return Me._DIURNO
        End Get

        Set(ByVal value As String)
            Me._DIURNO = value
        End Set
    End Property

    Public Property IdSquadra As Integer
        Get
            Return Me._IDSQUADRA
        End Get

        Set(ByVal value As Integer)
            Me._IDSQUADRA = value
        End Set
    End Property

    Public Property FlagStato As String
        Get
            Return Me._FLSTA
        End Get

        Set(ByVal value As String)
            Me._FLSTA = value
        End Set
    End Property

    Public Property DescStato As String
        Get
            Return Me._DESST
        End Get

        Set(ByVal value As String)
            Me._DESST = value
        End Set
    End Property

    Public Property Ora As String
        Get
            Return Me._ORAST
        End Get

        Set(ByVal value As String)
            Me._ORAST = value
        End Set
    End Property

    Public Property OraFine As String
        Get
            Return Me._ORAFI
        End Get

        Set(ByVal value As String)
            Me._ORAFI = value
        End Set
    End Property

End Class
