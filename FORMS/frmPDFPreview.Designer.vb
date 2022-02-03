<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPDFPreview
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPDFPreview))
        Me.RadPdfViewer1 = New Telerik.WinControls.UI.RadPdfViewer()
        Me.RadPdfViewerNavigator1 = New Telerik.WinControls.UI.RadPdfViewerNavigator()
        CType(Me.RadPdfViewer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPdfViewerNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadPdfViewer1
        '
        Me.RadPdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadPdfViewer1.FitToWidth = True
        Me.RadPdfViewer1.Location = New System.Drawing.Point(0, 48)
        Me.RadPdfViewer1.Name = "RadPdfViewer1"
        Me.RadPdfViewer1.Size = New System.Drawing.Size(771, 540)
        Me.RadPdfViewer1.TabIndex = 0
        Me.RadPdfViewer1.ThemeName = "MaterialBlueGrey"
        Me.RadPdfViewer1.ThumbnailsScaleFactor = 0.15!
        '
        'RadPdfViewerNavigator1
        '
        Me.RadPdfViewerNavigator1.AssociatedViewer = Me.RadPdfViewer1
        Me.RadPdfViewerNavigator1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadPdfViewerNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.RadPdfViewerNavigator1.Name = "RadPdfViewerNavigator1"
        Me.RadPdfViewerNavigator1.Size = New System.Drawing.Size(771, 48)
        Me.RadPdfViewerNavigator1.TabIndex = 1
        Me.RadPdfViewerNavigator1.ThemeName = "MaterialBlueGrey"
        '
        'frmPDFPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 588)
        Me.Controls.Add(Me.RadPdfViewer1)
        Me.Controls.Add(Me.RadPdfViewerNavigator1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPDFPreview"
        Me.Text = "Anteprima Offerta"
        CType(Me.RadPdfViewer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPdfViewerNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RadPdfViewer1 As Telerik.WinControls.UI.RadPdfViewer
    Friend WithEvents RadPdfViewerNavigator1 As Telerik.WinControls.UI.RadPdfViewerNavigator
End Class
