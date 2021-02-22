Public Class elencoServiziContratto
    Dim r_C1NRC As String
    Dim r_C1SOC As String
    Dim r_C1SER As String
    Dim r_C1CAN As Double
    Dim r_C1CIV As String
    Dim r_C1TFA As String
    Dim r_C1FFA As String
    Dim r_C1CTR As String
    Dim r_C1CTL As String
    Dim r_C1FAF As String
    Dim r_DESSER As String

    Public Property C1NRC() As String
        Get
            Return r_C1NRC
        End Get

        Set(ByVal Value As String)
            r_C1NRC = Value
        End Set
    End Property

    Public Property C1SOC() As String
        Get
            Return r_C1SOC
        End Get

        Set(ByVal Value As String)
            r_C1SOC = Value
        End Set
    End Property


    Public Property C1CAN() As Double
        Get
            Return r_C1CAN
        End Get

        Set(ByVal Value As Double)
            r_C1CAN = Value
        End Set
    End Property

    Public Property C1SER() As String
        Get
            Return r_C1SER
        End Get

        Set(ByVal Value As String)
            r_C1SER = Value
        End Set
    End Property

    Public Property C1CIV() As String
        Get
            Return r_C1CIV
        End Get

        Set(ByVal Value As String)
            r_C1CIV = Value
        End Set
    End Property

    Public Property C1TFA() As String
        Get
            Return r_C1TFA
        End Get

        Set(ByVal Value As String)
            r_C1TFA = Value
        End Set
    End Property

    Public Property C1FFA() As String
        Get
            Return r_C1FFA
        End Get

        Set(ByVal Value As String)
            r_C1FFA = Value
        End Set
    End Property

    Public Property C1CTR() As String
        Get
            Return r_C1CTR
        End Get

        Set(ByVal Value As String)
            r_C1CTR = Value
        End Set
    End Property

    Public Property C1CTL() As String
        Get
            Return r_C1CTL
        End Get

        Set(ByVal Value As String)
            r_C1CTL = Value
        End Set
    End Property

    Public Property C1FAF() As String
        Get
            Return r_C1FAF
        End Get

        Set(ByVal Value As String)
            r_C1FAF = Value
        End Set
    End Property

    Public Property DESSER() As String
        Get
            Return r_DESSER
        End Get

        Set(ByVal Value As String)
            r_DESSER = Value
        End Set
    End Property

End Class
