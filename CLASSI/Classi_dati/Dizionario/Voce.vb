Public Class Voce
    Public Property Codice() As String
    Public Property Descrizione() As String
    Public Property SottoVoci() As List(Of Sottovoce)
    Public Property Image() As String
    'Public Property Sintetico() As Sintetico

    Public Sub AggiungiSottoVoce(x As Sottovoce)
        If Not SottoVoci.Contains(x) Then
            SottoVoci.Add(x)
            'x.Voce = Me
        End If
    End Sub
End Class
