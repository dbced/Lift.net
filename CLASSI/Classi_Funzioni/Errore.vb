Public Class Errore
    Enum ModuloErrore
        Server = 0
        Client = 1
    End Enum

    Enum TipoErrore
        Comunicazione = 1
        Database = 2
        Malloc = 3
    End Enum
    Public Property Codice As String
    Public Property Tipo As TipoErrore
    Public Property Stack As String
    Public Property Modulo As ModuloErrore
    Public Property Utente As String
    Public Property Messaggio As String

    Public Sub New(ex As Exception)
        If Not IsNothing(ex) Then
            Me.Messaggio = ex.Message
            Me.Stack = ex.StackTrace
        End If
    End Sub

    Public Sub sendReport()
        'Invio mail al Ced come Report Errore?
        'Da discuterne con Gianni
    End Sub

End Class
