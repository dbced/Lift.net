<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRicercaTabelle
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRicercaTabelle))
        Me.MaterialTealTheme1 = New Telerik.WinControls.Themes.MaterialTealTheme()
        Me.FluentTheme1 = New Telerik.WinControls.Themes.FluentTheme()
        Me.MaterialBlueGreyTheme1 = New Telerik.WinControls.Themes.MaterialBlueGreyTheme()
        Me.Office2013DarkTheme1 = New Telerik.WinControls.Themes.Office2013DarkTheme()
        Me.VisualStudio2012LightTheme1 = New Telerik.WinControls.Themes.VisualStudio2012LightTheme()
        Me.grid = New Telerik.WinControls.UI.RadGridView()
        Me.wbA = New Telerik.WinControls.UI.RadWaitingBar()
        Me.DotsSpinnerWaitingBarIndicatorElement1 = New Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement()
        Me.pnlDati = New Telerik.WinControls.UI.RadScrollablePanel()
        Me.cmdFiltro = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.txtDescr = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.MaterialPinkTheme1 = New Telerik.WinControls.Themes.MaterialPinkTheme()
        Me.MaterialTheme1 = New Telerik.WinControls.Themes.MaterialTheme()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grid.SuspendLayout()
        CType(Me.wbA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDati, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDati.PanelContainer.SuspendLayout()
        Me.pnlDati.SuspendLayout()
        CType(Me.cmdFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid
        '
        Me.grid.BackColor = System.Drawing.Color.White
        Me.grid.Controls.Add(Me.wbA)
        Me.grid.Cursor = System.Windows.Forms.Cursors.Default
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grid.ForeColor = System.Drawing.Color.Black
        Me.grid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grid.Location = New System.Drawing.Point(0, 117)
        '
        '
        '
        Me.grid.MasterTemplate.AllowAddNewRow = False
        Me.grid.MasterTemplate.AllowColumnChooser = False
        Me.grid.MasterTemplate.AllowDeleteRow = False
        Me.grid.MasterTemplate.AllowDragToGroup = False
        Me.grid.MasterTemplate.AllowRowResize = False
        Me.grid.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        Me.grid.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.grid.Name = "grid"
        Me.grid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grid.ShowGroupPanel = False
        Me.grid.Size = New System.Drawing.Size(719, 414)
        Me.grid.TabIndex = 40
        Me.grid.ThemeName = "Fluent"
        '
        'wbA
        '
        Me.wbA.Location = New System.Drawing.Point(549, 66)
        Me.wbA.Name = "wbA"
        Me.wbA.Size = New System.Drawing.Size(70, 70)
        Me.wbA.TabIndex = 201
        Me.wbA.Text = "RadWaitingBar1"
        Me.wbA.Visible = False
        Me.wbA.WaitingIndicators.Add(Me.DotsSpinnerWaitingBarIndicatorElement1)
        Me.wbA.WaitingSpeed = 100
        Me.wbA.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsSpinner
        CType(Me.wbA.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingSpeed = 100
        CType(Me.wbA.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarContentElement).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsSpinner
        CType(Me.wbA.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).Dash = False
        '
        'DotsSpinnerWaitingBarIndicatorElement1
        '
        Me.DotsSpinnerWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsSpinnerWaitingBarIndicatorElement1.Name = "DotsSpinnerWaitingBarIndicatorElement1"
        Me.DotsSpinnerWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsSpinnerWaitingBarIndicatorElement1.UseCompatibleTextRendering = False
        '
        'pnlDati
        '
        Me.pnlDati.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDati.Location = New System.Drawing.Point(0, 0)
        Me.pnlDati.Name = "pnlDati"
        Me.pnlDati.Padding = New System.Windows.Forms.Padding(0)
        '
        'pnlDati.PanelContainer
        '
        Me.pnlDati.PanelContainer.Controls.Add(Me.cmdFiltro)
        Me.pnlDati.PanelContainer.Controls.Add(Me.RadLabel1)
        Me.pnlDati.PanelContainer.Controls.Add(Me.txtDescr)
        Me.pnlDati.PanelContainer.Controls.Add(Me.RadLabel2)
        Me.pnlDati.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlDati.PanelContainer.Size = New System.Drawing.Size(719, 117)
        Me.pnlDati.Size = New System.Drawing.Size(719, 117)
        Me.pnlDati.TabIndex = 42
        Me.pnlDati.ThemeName = "MaterialTeal"
        '
        'cmdFiltro
        '
        Me.cmdFiltro.Image = CType(resources.GetObject("cmdFiltro.Image"), System.Drawing.Image)
        Me.cmdFiltro.Location = New System.Drawing.Point(584, 33)
        Me.cmdFiltro.Name = "cmdFiltro"
        Me.cmdFiltro.Size = New System.Drawing.Size(81, 31)
        Me.cmdFiltro.TabIndex = 176
        Me.cmdFiltro.Text = "CERCA"
        Me.cmdFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFiltro.ThemeName = "ThemeCmdRecubeYEL"
        '
        'RadLabel1
        '
        Me.RadLabel1.AutoSize = False
        Me.RadLabel1.BackColor = System.Drawing.Color.Gainsboro
        Me.RadLabel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.ForeColor = System.Drawing.Color.Black
        Me.RadLabel1.Location = New System.Drawing.Point(0, 98)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(719, 19)
        Me.RadLabel1.TabIndex = 177
        Me.RadLabel1.Text = "RISULTATO DELLA RICERCA"
        Me.RadLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDescr
        '
        Me.txtDescr.AutoSize = False
        Me.txtDescr.ForeColor = System.Drawing.Color.Black
        Me.txtDescr.Location = New System.Drawing.Point(86, 30)
        Me.txtDescr.MaxLength = 0
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(486, 36)
        Me.txtDescr.TabIndex = 175
        Me.txtDescr.ThemeName = "Fluent"
        CType(Me.txtDescr.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        CType(Me.txtDescr.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'RadLabel2
        '
        Me.RadLabel2.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel2.Location = New System.Drawing.Point(24, 38)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(56, 21)
        Me.RadLabel2.TabIndex = 174
        Me.RadLabel2.Text = "Ricerca"
        Me.RadLabel2.ThemeName = "MaterialTeal"
        '
        'FrmRicercaTabelle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 531)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.pnlDati)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRicercaTabelle"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ricerca"
        Me.ThemeName = "MaterialTeal"
        CType(Me.grid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grid.ResumeLayout(False)
        Me.grid.PerformLayout()
        CType(Me.wbA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDati.PanelContainer.ResumeLayout(False)
        Me.pnlDati.PanelContainer.PerformLayout()
        CType(Me.pnlDati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDati.ResumeLayout(False)
        CType(Me.cmdFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MaterialTealTheme1 As Telerik.WinControls.Themes.MaterialTealTheme
    Friend WithEvents FluentTheme1 As Telerik.WinControls.Themes.FluentTheme
    Friend WithEvents MaterialBlueGreyTheme1 As Telerik.WinControls.Themes.MaterialBlueGreyTheme
    Friend WithEvents Office2013DarkTheme1 As Telerik.WinControls.Themes.Office2013DarkTheme
    Friend WithEvents VisualStudio2012LightTheme1 As Telerik.WinControls.Themes.VisualStudio2012LightTheme
    Friend WithEvents grid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents wbA As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents DotsSpinnerWaitingBarIndicatorElement1 As Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement
    Friend WithEvents pnlDati As Telerik.WinControls.UI.RadScrollablePanel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtDescr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmdFiltro As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents MaterialPinkTheme1 As Telerik.WinControls.Themes.MaterialPinkTheme
    Friend WithEvents MaterialTheme1 As Telerik.WinControls.Themes.MaterialTheme
End Class

