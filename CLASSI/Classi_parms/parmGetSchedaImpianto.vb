Public Class parmGetSchedaImpianto
    Inherits elenco

    Dim r_parmDatiTec As List(Of datiTecnici)

    Public Property datiTecnici() As List(Of datiTecnici)
        Get
            Return r_parmDatiTec
        End Get

        Set(ByVal Value As List(Of datiTecnici))
            r_parmDatiTec = Value
        End Set
    End Property

End Class

Public Class datiTecnici
    Dim r_cdGruppo As String
    Dim r_desGruppo As String
    Dim r_codVoce As String
    Dim r_desVoce As String
    Dim r_Valore As String
    Dim r_unmis As String
    Dim r_codlista As String

    Public Property cdGruppo() As String
        Get
            Return r_cdGruppo
        End Get

        Set(ByVal Value As String)
            r_cdGruppo = Value
        End Set
    End Property

    Public Property desGruppo() As String
        Get
            Return r_desGruppo
        End Get

        Set(ByVal Value As String)
            r_desGruppo = Value
        End Set
    End Property

    Public Property codVoce() As String
        Get
            Return r_codVoce
        End Get

        Set(ByVal Value As String)
            r_codVoce = Value
        End Set
    End Property

    Public Property desVoce() As String
        Get
            Return r_desVoce
        End Get

        Set(ByVal Value As String)
            r_desVoce = Value
        End Set
    End Property

    Public Property valore() As String
        Get
            Return r_Valore
        End Get

        Set(ByVal Value As String)
            r_Valore = Value
        End Set
    End Property

    Public Property unMis() As String
        Get
            Return r_unmis
        End Get

        Set(ByVal Value As String)
            r_unmis = Value
        End Set
    End Property

    Public Property codice_lista() As String
        Get
            Return r_codlista
        End Get

        Set(ByVal Value As String)
            r_codlista = Value
        End Set
    End Property

End Class
