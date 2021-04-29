Public Class statChiamateImpianto
    Dim r_Anno As Integer
    Dim r_nrchi As Integer
    Dim r_nrsos As Integer
    Dim r_nrFerme As Integer
    Dim r_nrass As Integer
    Dim r_nrlav As Integer
    Dim r_nrcChi As Integer

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

    Public Property nr_chiamate_ass() As Integer
        Get
            Return r_nrass
        End Get

        Set(ByVal Value As Integer)
            r_nrass = Value
        End Set
    End Property

    Public Property nr_chiamate_lav() As Integer
        Get
            Return r_nrlav
        End Get

        Set(ByVal Value As Integer)
            r_nrlav = Value
        End Set
    End Property

    Public Property nr_chiamate_sos() As Integer
        Get
            Return r_nrsos
        End Get

        Set(ByVal Value As Integer)
            r_nrsos = Value
        End Set
    End Property

    Public Property nr_chiamate_sos_ferme() As Integer
        Get
            Return r_nrFerme
        End Get

        Set(ByVal Value As Integer)
            r_nrFerme = Value
        End Set
    End Property


    Public Property nr_chiamate_chi() As Integer
        Get
            Return r_nrcChi
        End Get

        Set(ByVal Value As Integer)
            r_nrcChi = Value
        End Set
    End Property

End Class
