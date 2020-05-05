Public Class statChiamateImpianto
    Dim r_Anno As Integer
    Dim r_nrchi As Integer

    Public Property anno() As Integer
        Get
            Return r_Anno
        End Get

        Set(ByVal Value As Integer)
            r_Anno = Value
        End Set
    End Property


    Public Property nr_chiamate() As Integer
        Get
            Return r_nrchi
        End Get

        Set(ByVal Value As Integer)
            r_nrchi = Value
        End Set
    End Property
End Class
