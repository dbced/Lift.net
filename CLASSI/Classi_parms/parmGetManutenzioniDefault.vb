Public Class parmGetManutenzioniDefault
    Dim r_CodCat As String
    Dim r_CodImp As String
    Dim r_CodAsset As String

    Public Property codCategoria() As String
        Get
            Return r_CodCat
        End Get

        Set(ByVal Value As String)
            r_CodCat = Value
        End Set
    End Property

    Public Property codImpianto() As String
        Get
            Return r_CodImp
        End Get

        Set(ByVal Value As String)
            r_CodImp = Value
        End Set
    End Property

    Public Property codAsset() As String
        Get
            Return r_CodAsset
        End Get

        Set(ByVal Value As String)
            r_CodAsset = Value
        End Set
    End Property

End Class
