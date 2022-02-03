<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Test
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.MaterialBlueGreyTheme1 = New Telerik.WinControls.Themes.MaterialBlueGreyTheme()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(66, 115)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(193, 41)
        Me.Button6.TabIndex = 7
        Me.Button6.Text = "TEST NUOVO CTR ATIPICO"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(66, 50)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(193, 41)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "TEST MODIFICA CTR ATIPICO"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 220)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Test"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TEST"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents MaterialBlueGreyTheme1 As Telerik.WinControls.Themes.MaterialBlueGreyTheme
End Class

