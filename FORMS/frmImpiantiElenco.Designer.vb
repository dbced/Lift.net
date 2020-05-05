<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImpiantiElenco
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
        Me.components = New System.ComponentModel.Container()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImpiantiElenco))
        Me.VisualStudio2012LightTheme1 = New Telerik.WinControls.Themes.VisualStudio2012LightTheme()
        Me.FluentTheme1 = New Telerik.WinControls.Themes.FluentTheme()
        Me.MaterialTealTheme1 = New Telerik.WinControls.Themes.MaterialTealTheme()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.grid = New Telerik.WinControls.UI.RadGridView()
        Me.wb = New Telerik.WinControls.UI.RadWaitingBar()
        Me.DotsRingWaitingBarIndicatorElement1 = New Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement()
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripE1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.cmdInserisci = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdBAnnulla = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdBModifica = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdBimport = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdBStampaElenco = New Telerik.WinControls.UI.CommandBarButton()
        Me.xmdExportExcel = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdBar = New Telerik.WinControls.UI.RadCommandBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grpBox = New Telerik.WinControls.UI.RadGroupBox()
        Me.wb3 = New Telerik.WinControls.UI.RadWaitingBar()
        Me.DotsSpinnerWaitingBarIndicatorElement3 = New Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement()
        Me.wb2 = New Telerik.WinControls.UI.RadWaitingBar()
        Me.DotsSpinnerWaitingBarIndicatorElement2 = New Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement()
        Me.cmbCentro = New Telerik.WinControls.UI.RadCheckedDropDownList()
        Me.cmbSoc = New Telerik.WinControls.UI.RadCheckedDropDownList()
        Me.cmdAllSoc = New Telerik.WinControls.UI.RadButton()
        Me.cmdSelAllCentri = New Telerik.WinControls.UI.RadButton()
        Me.cmdFiltro = New Telerik.WinControls.UI.RadButton()
        Me.MaterialBlueGreyTheme1 = New Telerik.WinControls.Themes.MaterialBlueGreyTheme()
        Me.t1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grid.SuspendLayout()
        CType(Me.wb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBox.SuspendLayout()
        CType(Me.wb3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wb2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdAllSoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdSelAllCentri, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid
        '
        Me.grid.Controls.Add(Me.wb)
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Location = New System.Drawing.Point(0, 192)
        '
        '
        '
        Me.grid.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(1291, 405)
        Me.grid.TabIndex = 98
        Me.grid.ThemeName = "Fluent"
        '
        'wb
        '
        Me.wb.Location = New System.Drawing.Point(360, 160)
        Me.wb.Name = "wb"
        Me.wb.Size = New System.Drawing.Size(70, 70)
        Me.wb.TabIndex = 99
        Me.wb.Text = "wb"
        Me.wb.ThemeName = "Fluent"
        Me.wb.Visible = False
        Me.wb.WaitingIndicators.Add(Me.DotsRingWaitingBarIndicatorElement1)
        Me.wb.WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        Me.wb.WaitingSpeed = 50
        Me.wb.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsRing
        CType(Me.wb.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        CType(Me.wb.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingSpeed = 50
        CType(Me.wb.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarContentElement).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsRing
        CType(Me.wb.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).Dash = False
        '
        'DotsRingWaitingBarIndicatorElement1
        '
        Me.DotsRingWaitingBarIndicatorElement1.DotRadius = 10
        Me.DotsRingWaitingBarIndicatorElement1.Name = "DotsRingWaitingBarIndicatorElement1"
        Me.DotsRingWaitingBarIndicatorElement1.Radius = 30
        '
        'CommandBarRowElement1
        '
        Me.CommandBarRowElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarRowElement1.MinSize = New System.Drawing.Size(25, 25)
        Me.CommandBarRowElement1.Name = "CommandBarRowElement1"
        Me.CommandBarRowElement1.Strips.AddRange(New Telerik.WinControls.UI.CommandBarStripElement() {Me.CommandBarStripE1})
        Me.CommandBarRowElement1.Text = ""
        Me.CommandBarRowElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarRowElement1.UseCompatibleTextRendering = False
        '
        'CommandBarStripE1
        '
        Me.CommandBarStripE1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarStripE1.DisplayName = "CommandBarStripElement1"
        Me.CommandBarStripE1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.cmdInserisci, Me.cmdBAnnulla, Me.cmdBModifica, Me.cmdBimport, Me.cmdBStampaElenco, Me.xmdExportExcel})
        Me.CommandBarStripE1.Name = "CommandBarStripE1"
        Me.CommandBarStripE1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarStripE1.UseCompatibleTextRendering = False
        '
        'cmdInserisci
        '
        Me.cmdInserisci.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdInserisci.DisplayName = "CommandBarButton1"
        Me.cmdInserisci.DrawText = True
        Me.cmdInserisci.Image = CType(resources.GetObject("cmdInserisci.Image"), System.Drawing.Image)
        Me.cmdInserisci.Name = "cmdInserisci"
        Me.cmdInserisci.Text = "Nuovo Impianto"
        Me.cmdInserisci.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdInserisci.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdInserisci.UseCompatibleTextRendering = False
        '
        'cmdBAnnulla
        '
        Me.cmdBAnnulla.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBAnnulla.DisplayName = "CommandBarButton4"
        Me.cmdBAnnulla.DrawText = True
        Me.cmdBAnnulla.Image = CType(resources.GetObject("cmdBAnnulla.Image"), System.Drawing.Image)
        Me.cmdBAnnulla.Name = "cmdBAnnulla"
        Me.cmdBAnnulla.Text = "Annulla Impianto"
        Me.cmdBAnnulla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdBAnnulla.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBAnnulla.UseCompatibleTextRendering = False
        '
        'cmdBModifica
        '
        Me.cmdBModifica.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBModifica.DisplayName = "CommandBarButton5"
        Me.cmdBModifica.DrawText = True
        Me.cmdBModifica.Image = CType(resources.GetObject("cmdBModifica.Image"), System.Drawing.Image)
        Me.cmdBModifica.Name = "cmdBModifica"
        Me.cmdBModifica.Text = "Modifica Impianto"
        Me.cmdBModifica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdBModifica.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBModifica.UseCompatibleTextRendering = False
        '
        'cmdBimport
        '
        Me.cmdBimport.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBimport.DisplayName = "CommandBarButton1"
        Me.cmdBimport.DrawText = True
        Me.cmdBimport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBimport.Image = CType(resources.GetObject("cmdBimport.Image"), System.Drawing.Image)
        Me.cmdBimport.Name = "cmdBimport"
        Me.cmdBimport.Text = "Importa Impianti"
        Me.cmdBimport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdBimport.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBimport.UseCompatibleTextRendering = False
        '
        'cmdBStampaElenco
        '
        Me.cmdBStampaElenco.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBStampaElenco.DisplayName = "CommandBarButton1"
        Me.cmdBStampaElenco.DrawText = True
        Me.cmdBStampaElenco.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBStampaElenco.Image = CType(resources.GetObject("cmdBStampaElenco.Image"), System.Drawing.Image)
        Me.cmdBStampaElenco.Name = "cmdBStampaElenco"
        Me.cmdBStampaElenco.Text = "Stampa Elenco"
        Me.cmdBStampaElenco.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdBStampaElenco.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBStampaElenco.UseCompatibleTextRendering = False
        '
        'xmdExportExcel
        '
        Me.xmdExportExcel.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.xmdExportExcel.DisplayName = "CommandBarButton1"
        Me.xmdExportExcel.DrawText = True
        Me.xmdExportExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xmdExportExcel.Image = CType(resources.GetObject("xmdExportExcel.Image"), System.Drawing.Image)
        Me.xmdExportExcel.Name = "xmdExportExcel"
        Me.xmdExportExcel.Text = "Esporta Excel"
        Me.xmdExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.xmdExportExcel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.xmdExportExcel.UseCompatibleTextRendering = False
        '
        'cmdBar
        '
        Me.cmdBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmdBar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmdBar.Location = New System.Drawing.Point(0, 0)
        Me.cmdBar.Name = "cmdBar"
        Me.cmdBar.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement1})
        Me.cmdBar.Size = New System.Drawing.Size(1291, 67)
        Me.cmdBar.TabIndex = 43
        Me.cmdBar.ThemeName = "Windows8"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(24, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 18)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Società"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 18)
        Me.Label2.TabIndex = 88
        '
        'RadLabel2
        '
        Me.RadLabel2.AutoSize = False
        Me.RadLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.RadLabel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadLabel2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.ForeColor = System.Drawing.Color.Black
        Me.RadLabel2.Location = New System.Drawing.Point(2, 18)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(1287, 24)
        Me.RadLabel2.TabIndex = 171
        Me.RadLabel2.Text = "Filtri"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(429, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 18)
        Me.Label7.TabIndex = 157
        Me.Label7.Text = "Centro"
        '
        'grpBox
        '
        Me.grpBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grpBox.Controls.Add(Me.wb3)
        Me.grpBox.Controls.Add(Me.wb2)
        Me.grpBox.Controls.Add(Me.cmbCentro)
        Me.grpBox.Controls.Add(Me.cmbSoc)
        Me.grpBox.Controls.Add(Me.cmdAllSoc)
        Me.grpBox.Controls.Add(Me.cmdSelAllCentri)
        Me.grpBox.Controls.Add(Me.cmdFiltro)
        Me.grpBox.Controls.Add(Me.Label7)
        Me.grpBox.Controls.Add(Me.RadLabel2)
        Me.grpBox.Controls.Add(Me.Label2)
        Me.grpBox.Controls.Add(Me.Label1)
        Me.grpBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBox.HeaderText = ""
        Me.grpBox.Location = New System.Drawing.Point(0, 67)
        Me.grpBox.Name = "grpBox"
        Me.grpBox.Size = New System.Drawing.Size(1291, 125)
        Me.grpBox.TabIndex = 97
        Me.grpBox.ThemeName = "MaterialTeal"
        '
        'wb3
        '
        Me.wb3.Location = New System.Drawing.Point(1027, 49)
        Me.wb3.Name = "wb3"
        Me.wb3.Size = New System.Drawing.Size(70, 70)
        Me.wb3.TabIndex = 174
        Me.wb3.Text = "RadWaitingBar1"
        Me.wb3.Visible = False
        Me.wb3.WaitingIndicators.Add(Me.DotsSpinnerWaitingBarIndicatorElement3)
        Me.wb3.WaitingSpeed = 100
        Me.wb3.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsSpinner
        CType(Me.wb3.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingSpeed = 100
        CType(Me.wb3.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarContentElement).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsSpinner
        CType(Me.wb3.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).Dash = False
        '
        'DotsSpinnerWaitingBarIndicatorElement3
        '
        Me.DotsSpinnerWaitingBarIndicatorElement3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsSpinnerWaitingBarIndicatorElement3.Name = "DotsSpinnerWaitingBarIndicatorElement3"
        Me.DotsSpinnerWaitingBarIndicatorElement3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsSpinnerWaitingBarIndicatorElement3.UseCompatibleTextRendering = False
        '
        'wb2
        '
        Me.wb2.Location = New System.Drawing.Point(939, 50)
        Me.wb2.Name = "wb2"
        Me.wb2.Size = New System.Drawing.Size(70, 70)
        Me.wb2.TabIndex = 173
        Me.wb2.Text = "RadWaitingBar1"
        Me.wb2.Visible = False
        Me.wb2.WaitingIndicators.Add(Me.DotsSpinnerWaitingBarIndicatorElement2)
        Me.wb2.WaitingSpeed = 100
        Me.wb2.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsSpinner
        CType(Me.wb2.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingSpeed = 100
        CType(Me.wb2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarContentElement).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsSpinner
        CType(Me.wb2.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).Dash = False
        '
        'DotsSpinnerWaitingBarIndicatorElement2
        '
        Me.DotsSpinnerWaitingBarIndicatorElement2.Name = "DotsSpinnerWaitingBarIndicatorElement2"
        '
        'cmbCentro
        '
        Me.cmbCentro.AutoSize = False
        Me.cmbCentro.Location = New System.Drawing.Point(483, 68)
        Me.cmbCentro.Name = "cmbCentro"
        Me.cmbCentro.Size = New System.Drawing.Size(74, 28)
        Me.cmbCentro.TabIndex = 172
        Me.cmbCentro.ThemeName = "Fluent"
        '
        'cmbSoc
        '
        Me.cmbSoc.AutoSize = False
        Me.cmbSoc.Location = New System.Drawing.Point(83, 67)
        Me.cmbSoc.Name = "cmbSoc"
        Me.cmbSoc.Size = New System.Drawing.Size(255, 28)
        Me.cmbSoc.TabIndex = 100
        Me.cmbSoc.ThemeName = "Fluent"
        '
        'cmdAllSoc
        '
        Me.cmdAllSoc.Image = CType(resources.GetObject("cmdAllSoc.Image"), System.Drawing.Image)
        Me.cmdAllSoc.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdAllSoc.Location = New System.Drawing.Point(345, 68)
        Me.cmdAllSoc.Name = "cmdAllSoc"
        Me.cmdAllSoc.Size = New System.Drawing.Size(26, 26)
        Me.cmdAllSoc.TabIndex = 155
        Me.cmdAllSoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAllSoc.ThemeName = "ThemeCmdRecubeYEL"
        '
        'cmdSelAllCentri
        '
        Me.cmdSelAllCentri.Image = CType(resources.GetObject("cmdSelAllCentri.Image"), System.Drawing.Image)
        Me.cmdSelAllCentri.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdSelAllCentri.Location = New System.Drawing.Point(563, 69)
        Me.cmdSelAllCentri.Name = "cmdSelAllCentri"
        Me.cmdSelAllCentri.Size = New System.Drawing.Size(26, 26)
        Me.cmdSelAllCentri.TabIndex = 158
        Me.cmdSelAllCentri.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSelAllCentri.ThemeName = "ThemeCmdRecubeYEL"
        '
        'cmdFiltro
        '
        Me.cmdFiltro.Image = CType(resources.GetObject("cmdFiltro.Image"), System.Drawing.Image)
        Me.cmdFiltro.Location = New System.Drawing.Point(631, 66)
        Me.cmdFiltro.Name = "cmdFiltro"
        Me.cmdFiltro.Size = New System.Drawing.Size(81, 31)
        Me.cmdFiltro.TabIndex = 12
        Me.cmdFiltro.Text = "CERCA"
        Me.cmdFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFiltro.ThemeName = "ThemeCmdRecubeYEL"
        '
        'FrmImpiantiElenco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1291, 597)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.grpBox)
        Me.Controls.Add(Me.cmdBar)
        Me.Name = "FrmImpiantiElenco"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Anagrafica Impianti"
        Me.ThemeName = "MaterialBlueGrey"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grid.ResumeLayout(False)
        Me.grid.PerformLayout()
        CType(Me.wb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBox.ResumeLayout(False)
        Me.grpBox.PerformLayout()
        CType(Me.wb3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wb2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdAllSoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdSelAllCentri, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents VisualStudio2012LightTheme1 As Telerik.WinControls.Themes.VisualStudio2012LightTheme
    Friend WithEvents FluentTheme1 As Telerik.WinControls.Themes.FluentTheme
    Friend WithEvents MaterialTealTheme1 As Telerik.WinControls.Themes.MaterialTealTheme
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents grid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents wb As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents CommandBarRowElement1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripE1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents cmdInserisci As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdBAnnulla As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdBModifica As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdBimport As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdBStampaElenco As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents xmdExportExcel As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdBar As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents cmdFiltro As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdSelAllCentri As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdAllSoc As Telerik.WinControls.UI.RadButton
    Friend WithEvents grpBox As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents cmbCentro As Telerik.WinControls.UI.RadCheckedDropDownList
    Friend WithEvents cmbSoc As Telerik.WinControls.UI.RadCheckedDropDownList
    Friend WithEvents wb3 As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents DotsSpinnerWaitingBarIndicatorElement3 As Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement
    Friend WithEvents wb2 As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents DotsSpinnerWaitingBarIndicatorElement2 As Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement
    Friend WithEvents MaterialBlueGreyTheme1 As Telerik.WinControls.Themes.MaterialBlueGreyTheme
    Friend WithEvents DotsRingWaitingBarIndicatorElement1 As Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement
    Friend WithEvents t1 As Timer
End Class

