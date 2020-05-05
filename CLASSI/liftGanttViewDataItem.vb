Imports Telerik.WinControls.UI

Public Class liftGanttViewDataItem
    Inherits GanttViewDataItem
    Private _nrBoll As Integer
    Private _aaBoll As Integer
    Private _dataEffett As Date

    Public Sub New()
    End Sub
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


End Class
