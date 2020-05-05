Public Class parmTabelle

    Dim r_codice As String
    Dim r_descr As String

    Public Property codElem() As String
        Get
            Return r_codice
        End Get

        Set(ByVal Value As String)
            r_codice = Value
        End Set
    End Property

    Public Property desElem() As String
        Get
            Return r_descr
        End Get

        Set(ByVal Value As String)
            r_descr = Value
        End Set
    End Property

End Class

Public Class parmGetTabella
    Inherits parmTabelle

    Dim r_codTab As String
    Dim r_codElem As String
    Dim r_filtro As String

    Public Property codtabella() As String
        Get
            Return r_codTab
        End Get

        Set(ByVal Value As String)
            r_codTab = Value
        End Set
    End Property

    Public Property codElemento() As String
        Get
            Return r_codElem
        End Get

        Set(ByVal Value As String)
            r_codElem = Value
        End Set
    End Property

    Public Property filtro() As String
        Get
            Return r_filtro
        End Get

        Set(ByVal Value As String)
            r_filtro = Value
        End Set
    End Property

End Class
