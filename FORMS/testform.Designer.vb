<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class testform
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(testform))
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.grpBox = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmdFiltro = New Telerik.WinControls.UI.RadButton()
        Me.cmbCentro = New Telerik.WinControls.UI.RadCheckedDropDownList()
        Me.cmdSelAllCentri = New Telerik.WinControls.UI.RadButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbSoc = New Telerik.WinControls.UI.RadCheckedDropDownList()
        Me.cmdAllSoc = New Telerik.WinControls.UI.RadButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.grid = New Telerik.WinControls.UI.RadGridView()
        Me.cmdBar = New Telerik.WinControls.UI.RadCommandBar()
        Me.cmdRowBar = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.cmdInserisci = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdAnnulla = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdModifica = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdDuplica = New Telerik.WinControls.UI.CommandBarButton()
        Me.CommandBarButton5 = New Telerik.WinControls.UI.CommandBarButton()
        CType(Me.grpBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBox.SuspendLayout()
        CType(Me.cmdFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdSelAllCentri, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdAllSoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBox
        '
        Me.grpBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.grpBox.Controls.Add(Me.cmdFiltro)
        Me.grpBox.Controls.Add(Me.cmbCentro)
        Me.grpBox.Controls.Add(Me.cmdSelAllCentri)
        Me.grpBox.Controls.Add(Me.Label7)
        Me.grpBox.Controls.Add(Me.cmbSoc)
        Me.grpBox.Controls.Add(Me.cmdAllSoc)
        Me.grpBox.Controls.Add(Me.Label1)
        Me.grpBox.Controls.Add(Me.RadLabel2)
        Me.grpBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBox.HeaderText = ""
        Me.grpBox.HeaderTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.grpBox.Location = New System.Drawing.Point(0, 0)
        Me.grpBox.Name = "grpBox"
        Me.grpBox.Padding = New System.Windows.Forms.Padding(2)
        Me.grpBox.Size = New System.Drawing.Size(1196, 83)
        Me.grpBox.TabIndex = 2
        Me.grpBox.ThemeName = "MaterialTeal"
        '
        'cmdFiltro
        '
        Me.cmdFiltro.Image = CType(resources.GetObject("cmdFiltro.Image"), System.Drawing.Image)
        Me.cmdFiltro.Location = New System.Drawing.Point(570, 36)
        Me.cmdFiltro.Name = "cmdFiltro"
        Me.cmdFiltro.Size = New System.Drawing.Size(81, 31)
        Me.cmdFiltro.TabIndex = 179
        Me.cmdFiltro.Text = "CERCA"
        Me.cmdFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFiltro.ThemeName = "Fluent"
        '
        'cmbCentro
        '
        Me.cmbCentro.AutoSize = False
        Me.cmbCentro.Location = New System.Drawing.Point(431, 37)
        Me.cmbCentro.Name = "cmbCentro"
        Me.cmbCentro.Size = New System.Drawing.Size(74, 28)
        Me.cmbCentro.TabIndex = 178
        Me.cmbCentro.ThemeName = "Fluent"
        '
        'cmdSelAllCentri
        '
        Me.cmdSelAllCentri.Image = CType(resources.GetObject("cmdSelAllCentri.Image"), System.Drawing.Image)
        Me.cmdSelAllCentri.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdSelAllCentri.Location = New System.Drawing.Point(511, 38)
        Me.cmdSelAllCentri.Name = "cmdSelAllCentri"
        Me.cmdSelAllCentri.Size = New System.Drawing.Size(26, 25)
        Me.cmdSelAllCentri.TabIndex = 177
        Me.cmdSelAllCentri.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSelAllCentri.ThemeName = "Fluent"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(377, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 18)
        Me.Label7.TabIndex = 176
        Me.Label7.Text = "Centro"
        '
        'cmbSoc
        '
        Me.cmbSoc.AutoSize = False
        Me.cmbSoc.Location = New System.Drawing.Point(71, 36)
        Me.cmbSoc.Name = "cmbSoc"
        Me.cmbSoc.Size = New System.Drawing.Size(255, 28)
        Me.cmbSoc.TabIndex = 174
        Me.cmbSoc.ThemeName = "Fluent"
        '
        'cmdAllSoc
        '
        Me.cmdAllSoc.Image = CType(resources.GetObject("cmdAllSoc.Image"), System.Drawing.Image)
        Me.cmdAllSoc.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdAllSoc.Location = New System.Drawing.Point(333, 37)
        Me.cmdAllSoc.Name = "cmdAllSoc"
        Me.cmdAllSoc.Size = New System.Drawing.Size(26, 26)
        Me.cmdAllSoc.TabIndex = 175
        Me.cmdAllSoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAllSoc.ThemeName = "Fluent"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 18)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "Società"
        '
        'RadLabel2
        '
        Me.RadLabel2.AutoSize = False
        Me.RadLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.RadLabel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadLabel2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.ForeColor = System.Drawing.Color.Black
        Me.RadLabel2.Location = New System.Drawing.Point(2, 2)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(1192, 24)
        Me.RadLabel2.TabIndex = 172
        Me.RadLabel2.Text = "Filtri"
        '
        'grid
        '
        Me.grid.Location = New System.Drawing.Point(-70, 106)
        '
        '
        '
        Me.grid.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(1337, 278)
        Me.grid.TabIndex = 3
        Me.grid.ThemeName = "Fluent"
        '
        'cmdBar
        '
        Me.cmdBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdBar.Location = New System.Drawing.Point(0, 438)
        Me.cmdBar.Name = "cmdBar"
        Me.cmdBar.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.cmdRowBar})
        Me.cmdBar.Size = New System.Drawing.Size(1196, 106)
        Me.cmdBar.TabIndex = 4
        Me.cmdBar.ThemeName = "Fluent"
        '
        'cmdRowBar
        '
        Me.cmdRowBar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdRowBar.MinSize = New System.Drawing.Size(25, 25)
        Me.cmdRowBar.Name = "cmdRowBar"
        Me.cmdRowBar.Strips.AddRange(New Telerik.WinControls.UI.CommandBarStripElement() {Me.CommandBarStripElement1})
        Me.cmdRowBar.Text = ""
        Me.cmdRowBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdRowBar.UseCompatibleTextRendering = False
        '
        'CommandBarStripElement1
        '
        Me.CommandBarStripElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarStripElement1.DisplayName = "CommandBarStripElement1"
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.cmdInserisci, Me.cmdAnnulla, Me.cmdModifica, Me.cmdDuplica, Me.CommandBarButton5})
        Me.CommandBarStripElement1.Name = "CommandBarStripElement1"
        Me.CommandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarStripElement1.UseCompatibleTextRendering = False
        '
        'cmdInserisci
        '
        Me.cmdInserisci.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdInserisci.DisplayName = "CommandBarButton1"
        Me.cmdInserisci.DrawText = True
        Me.cmdInserisci.EnableHighlight = False
        Me.cmdInserisci.Image = CType(resources.GetObject("cmdInserisci.Image"), System.Drawing.Image)
        Me.cmdInserisci.Name = "cmdInserisci"
        Me.cmdInserisci.Text = "Nuova Offerta"
        Me.cmdInserisci.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdInserisci.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdInserisci.UseCompatibleTextRendering = False
        '
        'cmdAnnulla
        '
        Me.cmdAnnulla.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdAnnulla.DisplayName = "CommandBarButton2"
        Me.cmdAnnulla.DrawText = True
        Me.cmdAnnulla.EnableHighlight = False
        Me.cmdAnnulla.Image = Global.LiftCore.My.Resources.Resources.DocAnnulla
        Me.cmdAnnulla.Name = "cmdAnnulla"
        Me.cmdAnnulla.Text = "Annulla Offerta"
        Me.cmdAnnulla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdAnnulla.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdAnnulla.UseCompatibleTextRendering = False
        '
        'cmdModifica
        '
        Me.cmdModifica.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdModifica.DisplayName = "CommandBarButton3"
        Me.cmdModifica.DrawText = True
        Me.cmdModifica.EnableHighlight = False
        Me.cmdModifica.Image = Global.LiftCore.My.Resources.Resources.DocModifica
        Me.cmdModifica.Name = "cmdModifica"
        Me.cmdModifica.Text = "Modifica Offerta"
        Me.cmdModifica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdModifica.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdModifica.UseCompatibleTextRendering = False
        '
        'cmdDuplica
        '
        Me.cmdDuplica.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdDuplica.DisplayName = "CommandBarButton4"
        Me.cmdDuplica.DrawText = True
        Me.cmdDuplica.EnableHighlight = False
        Me.cmdDuplica.Image = Global.LiftCore.My.Resources.Resources.DocDuplica
        Me.cmdDuplica.Name = "cmdDuplica"
        Me.cmdDuplica.Text = "Duplica Offerta"
        Me.cmdDuplica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdDuplica.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdDuplica.UseCompatibleTextRendering = False
        '
        'CommandBarButton5
        '
        Me.CommandBarButton5.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarButton5.DisplayName = "CommandBarButton5"
        Me.CommandBarButton5.DrawText = True
        Me.CommandBarButton5.EnableHighlight = False
        Me.CommandBarButton5.Image = Global.LiftCore.My.Resources.Resources.Stampante
        Me.CommandBarButton5.Name = "CommandBarButton5"
        Me.CommandBarButton5.Text = "Stampa Elenco"
        Me.CommandBarButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CommandBarButton5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarButton5.UseCompatibleTextRendering = False
        '
        'testform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1196, 544)
        Me.Controls.Add(Me.cmdBar)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.grpBox)
        Me.Name = "testform"
        Me.Text = "testform"
        CType(Me.grpBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBox.ResumeLayout(False)
        Me.grpBox.PerformLayout()
        CType(Me.cmdFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdSelAllCentri, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdAllSoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpBox As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents cmdFiltro As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmbCentro As Telerik.WinControls.UI.RadCheckedDropDownList
    Friend WithEvents cmdSelAllCentri As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbSoc As Telerik.WinControls.UI.RadCheckedDropDownList
    Friend WithEvents cmdAllSoc As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label1 As Label
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents grid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents cmdBar As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents cmdRowBar As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents cmdInserisci As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdAnnulla As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdModifica As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdDuplica As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents CommandBarButton5 As Telerik.WinControls.UI.CommandBarButton
End Class
