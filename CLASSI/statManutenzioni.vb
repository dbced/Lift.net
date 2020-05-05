Public Class statManutenzioni
    Dim r_CDIMP As String
    Dim r_TPMAN As String
    Dim r_Anno As Integer
    Dim r_DESCR As String
    Dim r_prev As Integer
    Dim r_effet As Integer

    Public Property CodImpianto() As String
        Get
            Return r_CDIMP
        End Get

        Set(ByVal Value As String)
            r_CDIMP = Value
        End Set
    End Property


    Public Property tipoVisita() As String
        Get
            Return r_TPMAN
        End Get

        Set(ByVal Value As String)
            r_TPMAN = Value
        End Set
    End Property


    Public Property anno() As Integer
        Get
            Return r_Anno
        End Get

        Set(ByVal Value As Integer)
            r_Anno = Value
        End Set
    End Property


    Public Property preventivate() As Integer
        Get
            Return r_prev
        End Get

        Set(ByVal Value As Integer)
            r_prev = Value
        End Set

    End Property

    Public Property effettuate() As Integer
        Get
            Return r_effet
        End Get

        Set(ByVal Value As Integer)
            r_effet = Value
        End Set


    End Property
    Public Property descrMan() As String
        Get
            Return r_DESCR
        End Get

        Set(ByVal Value As String)
            r_DESCR = Value
        End Set

    End Property
End Class
