Public Class parmRelTabelle
    Dim r_tabParent As String
    Dim r_tabChild As String
    Dim r_CodTab As String

    Public Property codTab() As String
        Get
            Return r_CodTab
        End Get

        Set(ByVal Value As String)
            r_CodTab = Value
        End Set
    End Property

    Public Property codParent() As String
        Get
            Return r_tabParent
        End Get

        Set(ByVal Value As String)
            r_tabParent = Value
        End Set
    End Property

    Public Property codChild() As String
        Get
            Return r_tabChild
        End Get

        Set(ByVal Value As String)
            r_tabChild = Value
        End Set
    End Property

End Class

Public Class parmRelTabelleExt
    Inherits parmRelTabelle

    Dim r_flObbl As String
    Dim r_DefalultValue As String

    Public Property flObbligatorio() As String
        Get
            Return r_flObbl
        End Get

        Set(ByVal Value As String)
            r_flObbl = Value
        End Set
    End Property

    Public Property DefaultValue() As String
        Get
            Return r_DefalultValue
        End Get

        Set(ByVal Value As String)
            r_DefalultValue = Value
        End Set
    End Property

End Class
