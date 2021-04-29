Public Class parmsRicChiamate
    Inherits parmsRicContratti

    Private r_parmchiamateAssegnate As String
    Private r_parmchiamateChiuse As String
    Private r_parmchiamateSospese As String

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


End Class
