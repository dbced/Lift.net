<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExpGantt
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
        Dim RadListDataItem5 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem6 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem7 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem8 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Me.MaterialBlueGreyTheme1 = New Telerik.WinControls.Themes.MaterialBlueGreyTheme()
        Me.MaterialTheme1 = New Telerik.WinControls.Themes.MaterialTheme()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.cmbAnno = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.cmbMese = New Telerik.WinControls.UI.RadDropDownList()
        Me.chkChiuse = New Telerik.WinControls.UI.RadCheckBox()
        Me.FluentTheme1 = New Telerik.WinControls.Themes.FluentTheme()
        Me.cmdAnnulla = New Telerik.WinControls.UI.RadButton()
        Me.cmdConferma = New Telerik.WinControls.UI.RadButton()
        Me.lblSett = New Telerik.WinControls.UI.RadLabel()
        Me.cmbSettimana = New Telerik.WinControls.UI.RadDropDownList()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAnno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMese, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkChiuse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdAnnulla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdConferma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSett, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSettimana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadLabel6
        '
        Me.RadLabel6.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel6.Location = New System.Drawing.Point(17, 45)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(41, 21)
        Me.RadLabel6.TabIndex = 179
        Me.RadLabel6.Text = "Anno"
        Me.RadLabel6.ThemeName = "MaterialTeal"
        '
        'cmbAnno
        '
        Me.cmbAnno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbAnno.AutoSize = False
        Me.cmbAnno.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cmbAnno.ForeColor = System.Drawing.Color.Black
        RadListDataItem5.Text = "2020"
        RadListDataItem6.Text = "2021"
        RadListDataItem7.Text = "2022"
        RadListDataItem8.Text = "2023"
        Me.cmbAnno.Items.Add(RadListDataItem5)
        Me.cmbAnno.Items.Add(RadListDataItem6)
        Me.cmbAnno.Items.Add(RadListDataItem7)
        Me.cmbAnno.Items.Add(RadListDataItem8)
        Me.cmbAnno.Location = New System.Drawing.Point(95, 38)
        Me.cmbAnno.Name = "cmbAnno"
        Me.cmbAnno.NullText = "Seleziona un valore"
        Me.cmbAnno.Size = New System.Drawing.Size(103, 36)
        Me.cmbAnno.TabIndex = 0
        Me.cmbAnno.ThemeName = "Fluent"
        CType(Me.cmbAnno.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.StackLayoutElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        CType(Me.cmbAnno.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).NullText = "Seleziona un valore"
        CType(Me.cmbAnno.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'RadLabel1
        '
        Me.RadLabel1.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel1.Location = New System.Drawing.Point(12, 89)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(43, 21)
        Me.RadLabel1.TabIndex = 181
        Me.RadLabel1.Text = "Mese"
        Me.RadLabel1.ThemeName = "MaterialTeal"
        '
        'cmbMese
        '
        Me.cmbMese.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbMese.AutoSize = False
        Me.cmbMese.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cmbMese.ForeColor = System.Drawing.Color.Black
        Me.cmbMese.Location = New System.Drawing.Point(95, 82)
        Me.cmbMese.Name = "cmbMese"
        Me.cmbMese.NullText = "Seleziona un valore"
        Me.cmbMese.Size = New System.Drawing.Size(266, 36)
        Me.cmbMese.TabIndex = 1
        Me.cmbMese.ThemeName = "Fluent"
        CType(Me.cmbMese.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.StackLayoutElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        CType(Me.cmbMese.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).NullText = "Seleziona un valore"
        CType(Me.cmbMese.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'chkChiuse
        '
        Me.chkChiuse.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkChiuse.Location = New System.Drawing.Point(95, 178)
        Me.chkChiuse.Name = "chkChiuse"
        Me.chkChiuse.Size = New System.Drawing.Size(106, 24)
        Me.chkChiuse.TabIndex = 2
        Me.chkChiuse.Text = "Visite chiuse"
        '
        'cmdAnnulla
        '
        Me.cmdAnnulla.Location = New System.Drawing.Point(144, 213)
        Me.cmdAnnulla.Name = "cmdAnnulla"
        Me.cmdAnnulla.Size = New System.Drawing.Size(99, 29)
        Me.cmdAnnulla.TabIndex = 3
        Me.cmdAnnulla.Text = "Annulla"
        Me.cmdAnnulla.ThemeName = "VisualStudio2012Light"
        '
        'cmdConferma
        '
        Me.cmdConferma.Location = New System.Drawing.Point(257, 213)
        Me.cmdConferma.Name = "cmdConferma"
        Me.cmdConferma.Size = New System.Drawing.Size(99, 29)
        Me.cmdConferma.TabIndex = 4
        Me.cmdConferma.Text = "Esporta"
        Me.cmdConferma.ThemeName = "VisualStudio2012Light"
        '
        'lblSett
        '
        Me.lblSett.ForeColor = System.Drawing.Color.DimGray
        Me.lblSett.Location = New System.Drawing.Point(10, 133)
        Me.lblSett.Name = "lblSett"
        Me.lblSett.Size = New System.Drawing.Size(73, 21)
        Me.lblSett.TabIndex = 183
        Me.lblSett.Text = "Settimana"
        Me.lblSett.ThemeName = "MaterialTeal"
        '
        'cmbSettimana
        '
        Me.cmbSettimana.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbSettimana.AutoSize = False
        Me.cmbSettimana.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cmbSettimana.ForeColor = System.Drawing.Color.Black
        Me.cmbSettimana.Location = New System.Drawing.Point(95, 126)
        Me.cmbSettimana.Name = "cmbSettimana"
        Me.cmbSettimana.NullText = "Seleziona un valore"
        Me.cmbSettimana.Size = New System.Drawing.Size(266, 36)
        Me.cmbSettimana.TabIndex = 182
        Me.cmbSettimana.ThemeName = "Fluent"
        CType(Me.cmbSettimana.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.StackLayoutElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        CType(Me.cmbSettimana.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).NullText = "Seleziona un valore"
        CType(Me.cmbSettimana.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'FrmExpGantt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 261)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblSett)
        Me.Controls.Add(Me.cmbSettimana)
        Me.Controls.Add(Me.cmdAnnulla)
        Me.Controls.Add(Me.cmdConferma)
        Me.Controls.Add(Me.chkChiuse)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.cmbMese)
        Me.Controls.Add(Me.RadLabel6)
        Me.Controls.Add(Me.cmbAnno)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmExpGantt"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Esporta"
        Me.ThemeName = "MaterialBlueGrey"
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAnno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMese, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkChiuse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdAnnulla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdConferma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSett, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSettimana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MaterialBlueGreyTheme1 As Telerik.WinControls.Themes.MaterialBlueGreyTheme
    Friend WithEvents MaterialTheme1 As Telerik.WinControls.Themes.MaterialTheme
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbAnno As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbMese As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents chkChiuse As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents FluentTheme1 As Telerik.WinControls.Themes.FluentTheme
    Friend WithEvents cmdAnnulla As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdConferma As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblSett As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbSettimana As Telerik.WinControls.UI.RadDropDownList
End Class

