Public Class Fornitore
    Public Property CDFOR() As String
    Public Property RASFO() As String
    Public Property CDRIF() As String
    Public Property INDFO() As String
    Public Property LOCFO() As String
    Public Property PROFO() As String
    Public Property CAPFO() As String
    Public Property NTEFO() As String
    Public Property CNOTE() As String
    Public Property CDFIS() As String
    Public Property CPAIV() As String
    Public Property COPAG() As String
    Public Overrides Function ToString() As String
        Return Me.RASFO
    End Function
End Class
