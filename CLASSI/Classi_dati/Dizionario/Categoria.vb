Public Class Categoria
    Public Property Codice() As String
    Public Property Descrizione() As String
    'Public Property Dizionario() As Dizionario
    Public Property Tipologie As List(Of Tipologia)

    Public Sub AggiungiTipologia(tip As Tipologia)
        If Not Tipologie.Contains(tip) Then
            Tipologie.Add(tip)
            ' tip.Categoria = Me
        End If
    End Sub
End Class
