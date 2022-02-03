Imports System.IO

Public Class frmPDFPreview
    Dim pdf As String
    Public Sub New(fi As String)

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        pdf = fi
        'RadPdfViewer1.LoadDocument(pdf)
    End Sub

    Private Sub frmPDFPreview_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        File.Delete(pdf)
    End Sub

    Private Sub frmPDFPreview_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        RadPdfViewer1.LoadDocument(pdf)
    End Sub
End Class