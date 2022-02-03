Public Class Dizionario
    Public Property DSCDZ() As String
    Public Property Descrizione() As String
    Public Property Categorie() As List(Of Categoria)
    Public Property Err As Errore
    Public Sub AggiungiCategoria(cat As Categoria)
        If Not Categorie.Contains(cat) Then
            Categorie.Add(cat)
            'cat.Dizionario = Me
        End If
    End Sub
End Class
