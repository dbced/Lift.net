Public Class Tipologia
    Public Property Codice() As String
    Public Property Descrizione() As String
    'Public Property Categoria() As Categoria
    Public Property Sintetici() As List(Of Sintetico)

    Public Sub AggiungiSintetico(sin As Sintetico)
        If Not Sintetici.Contains(sin) Then
            Sintetici.Add(sin)
            'sin.Tipologia = Me
        End If
    End Sub
End Class
