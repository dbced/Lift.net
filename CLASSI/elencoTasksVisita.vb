Public Class elencoTasksVisita
    Dim r_IdTask As Integer
    Dim r_DesTask As String


    Public Property IdTask() As Integer
        Get
            Return r_IdTask
        End Get

        Set(ByVal Value As Integer)
            r_IdTask = Value
        End Set
    End Property

    Public Property DesTask() As String
        Get
            Return r_DesTask
        End Get

        Set(ByVal Value As String)
            r_DesTask = Value
        End Set
    End Property
End Class
