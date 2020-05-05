Public Class statCanoniImpianto
    Dim r_Anno As Integer
    Dim r_importo As Double

    Public Property anno() As Integer
        Get
            Return r_Anno
        End Get

        Set(ByVal Value As Integer)
            r_Anno = Value
        End Set
    End Property


    Public Property importo() As Double
        Get
            Return r_importo
        End Get

        Set(ByVal Value As Double)
            r_importo = Value
        End Set
    End Property
End Class
