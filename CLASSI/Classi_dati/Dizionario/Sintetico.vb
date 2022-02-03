Public Class Sintetico
    Public Property Codice() As String
    Public Property Descrizione() As String
    Public Property Voci() As List(Of Voce)
    Public Property Image As String
    'Public Property Tipologia() As Tipologia

    Public Sub AggiungiVoce(x As Voce)
        If Not Voci.Contains(x) Then
            Voci.Add(x)
            ' x.Sintetico = Me
        End If
    End Sub
End Class
