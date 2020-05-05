Public Class statFatturatoImpianto
    Inherits statCanoniImpianto
    Dim r_tipoFat As String
    Public Property tipoFatt() As String
        Get
            Return r_tipoFat
        End Get

        Set(ByVal Value As String)
            r_tipoFat = Value
        End Set

    End Property

End Class
