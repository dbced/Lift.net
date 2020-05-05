Public Class statBuoniImpianto
    Dim r_Anno As Integer
    Dim r_nrbuo As Integer

    Public Property anno() As Integer
        Get
            Return r_Anno
        End Get

        Set(ByVal Value As Integer)
            r_Anno = Value
        End Set
    End Property


    Public Property nr_buoni() As Integer
        Get
            Return r_nrbuo
        End Get

        Set(ByVal Value As Integer)
            r_nrbuo = Value
        End Set
    End Property

End Class
