Public Class elencoChiusureVis
    Dim r_ID As Integer
    Dim r_DATA As String

    Public Property id() As Integer
        Get
            Return r_ID
        End Get

        Set(ByVal Value As Integer)
            r_ID = Value
        End Set
    End Property

    Public Property dataChiusura() As String
        Get
            Return r_DATA
        End Get

        Set(ByVal Value As String)
            r_DATA = Value
        End Set

    End Property

End Class
