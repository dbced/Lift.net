<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImpiantoAssets
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImpiantoAssets))
        Me.MaterialTealTheme1 = New Telerik.WinControls.Themes.MaterialTealTheme()
        Me.FluentTheme1 = New Telerik.WinControls.Themes.FluentTheme()
        Me.Office2013DarkTheme1 = New Telerik.WinControls.Themes.Office2013DarkTheme()
        Me.gridAsset = New Telerik.WinControls.UI.RadGridView()
        Me.wbA = New Telerik.WinControls.UI.RadWaitingBar()
        Me.DotsSpinnerWaitingBarIndicatorElement1 = New Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement()
        Me.pnlDati = New Telerik.WinControls.UI.RadScrollablePanel()
        Me.chkPian = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.cmdAnnulla = New Telerik.WinControls.UI.RadButton()
        Me.cmdConferma = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.cmbCategoria = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.txtDescr = New Telerik.WinControls.UI.RadTextBox()
        Me.txtCodice = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.cmbMacroCat = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmdInserisciRiga = New Telerik.WinControls.UI.RadCommandBar()
        Me.cmdBarDettE1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.cmdBarStripDettE1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.cmdInsDett = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdModDett = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdEliminaRiga = New Telerik.WinControls.UI.CommandBarButton()
        Me.MaterialBlueGreyTheme1 = New Telerik.WinControls.Themes.MaterialBlueGreyTheme()
        Me.RadThemeManager1 = New Telerik.WinControls.RadThemeManager()
        Me.RadTextBox1 = New Telerik.WinControls.UI.RadTextBox()
        Me.RadTextBox2 = New Telerik.WinControls.UI.RadTextBox()
        Me.RadTextBox3 = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.cmdOkSearchDiz = New Telerik.WinControls.UI.RadButton()
        CType(Me.gridAsset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridAsset.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gridAsset.SuspendLayout()
        CType(Me.wbA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDati, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDati.PanelContainer.SuspendLayout()
        Me.pnlDati.SuspendLayout()
        CType(Me.chkPian, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdAnnulla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdConferma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMacroCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdInserisciRiga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadTextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadTextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadTextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOkSearchDiz, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridAsset
        '
        Me.gridAsset.BackColor = System.Drawing.Color.White
        Me.gridAsset.Controls.Add(Me.wbA)
        Me.gridAsset.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridAsset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridAsset.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.gridAsset.ForeColor = System.Drawing.Color.Black
        Me.gridAsset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.gridAsset.Location = New System.Drawing.Point(0, 30)
        '
        '
        '
        Me.gridAsset.MasterTemplate.AllowAddNewRow = False
        Me.gridAsset.MasterTemplate.AllowColumnChooser = False
        Me.gridAsset.MasterTemplate.AllowDeleteRow = False
        Me.gridAsset.MasterTemplate.AllowDragToGroup = False
        Me.gridAsset.MasterTemplate.AllowRowResize = False
        Me.gridAsset.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.gridAsset.Name = "gridAsset"
        Me.gridAsset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gridAsset.ShowGroupPanel = False
        Me.gridAsset.Size = New System.Drawing.Size(713, 366)
        Me.gridAsset.TabIndex = 35
        Me.gridAsset.ThemeName = "Fluent"
        '
        'wbA
        '
        Me.wbA.Location = New System.Drawing.Point(244, 265)
        Me.wbA.Name = "wbA"
        Me.wbA.Size = New System.Drawing.Size(70, 70)
        Me.wbA.TabIndex = 200
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
        Me.pnlDati.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDati.Location = New System.Drawing.Point(0, 396)
        Me.pnlDati.Name = "pnlDati"
        Me.pnlDati.Padding = New System.Windows.Forms.Padding(0)
        '
        'pnlDati.PanelContainer
        '
        Me.pnlDati.PanelContainer.Controls.Add(Me.cmdOkSearchDiz)
        Me.pnlDati.PanelContainer.Controls.Add(Me.RadLabel5)
        Me.pnlDati.PanelContainer.Controls.Add(Me.RadTextBox3)
        Me.pnlDati.PanelContainer.Controls.Add(Me.RadTextBox2)
        Me.pnlDati.PanelContainer.Controls.Add(Me.RadTextBox1)
        Me.pnlDati.PanelContainer.Controls.Add(Me.chkPian)
        Me.pnlDati.PanelContainer.Controls.Add(Me.RadButton1)
        Me.pnlDati.PanelContainer.Controls.Add(Me.cmdAnnulla)
        Me.pnlDati.PanelContainer.Controls.Add(Me.cmdConferma)
        Me.pnlDati.PanelContainer.Controls.Add(Me.RadLabel4)
        Me.pnlDati.PanelContainer.Controls.Add(Me.cmbCategoria)
        Me.pnlDati.PanelContainer.Controls.Add(Me.RadLabel2)
        Me.pnlDati.PanelContainer.Controls.Add(Me.RadLabel1)
        Me.pnlDati.PanelContainer.Controls.Add(Me.txtDescr)
        Me.pnlDati.PanelContainer.Controls.Add(Me.txtCodice)
        Me.pnlDati.PanelContainer.Controls.Add(Me.RadLabel3)
        Me.pnlDati.PanelContainer.Controls.Add(Me.cmbMacroCat)
        Me.pnlDati.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlDati.PanelContainer.Size = New System.Drawing.Size(713, 335)
        Me.pnlDati.Size = New System.Drawing.Size(713, 335)
        Me.pnlDati.TabIndex = 36
        Me.pnlDati.ThemeName = "MaterialTeal"
        Me.pnlDati.Visible = False
        '
        'chkPian
        '
        Me.chkPian.ForeColor = System.Drawing.Color.DimGray
        Me.chkPian.Location = New System.Drawing.Point(197, 255)
        Me.chkPian.Name = "chkPian"
        Me.chkPian.Size = New System.Drawing.Size(272, 19)
        Me.chkPian.TabIndex = 38
        Me.chkPian.Text = "Consenti pianificazione manutenzione"
        Me.chkPian.ThemeName = "MaterialTeal"
        '
        'RadButton1
        '
        Me.RadButton1.Location = New System.Drawing.Point(613, 119)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(83, 29)
        Me.RadButton1.TabIndex = 181
        Me.RadButton1.Text = "Salva"
        Me.RadButton1.ThemeName = "VisualStudio2012Light"
        Me.RadButton1.Visible = False
        '
        'cmdAnnulla
        '
        Me.cmdAnnulla.Location = New System.Drawing.Point(518, 285)
        Me.cmdAnnulla.Name = "cmdAnnulla"
        Me.cmdAnnulla.Size = New System.Drawing.Size(83, 29)
        Me.cmdAnnulla.TabIndex = 180
        Me.cmdAnnulla.Text = "Annulla"
        Me.cmdAnnulla.ThemeName = "VisualStudio2012Light"
        '
        'cmdConferma
        '
        Me.cmdConferma.Location = New System.Drawing.Point(610, 285)
        Me.cmdConferma.Name = "cmdConferma"
        Me.cmdConferma.Size = New System.Drawing.Size(83, 29)
        Me.cmdConferma.TabIndex = 179
        Me.cmdConferma.Text = "Salva"
        Me.cmdConferma.ThemeName = "VisualStudio2012Light"
        '
        'RadLabel4
        '
        Me.RadLabel4.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel4.Location = New System.Drawing.Point(59, 158)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(110, 21)
        Me.RadLabel4.TabIndex = 177
        Me.RadLabel4.Text = "Categoria Asset"
        Me.RadLabel4.ThemeName = "MaterialTeal"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCategoria.AutoSize = False
        Me.cmbCategoria.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cmbCategoria.ForeColor = System.Drawing.Color.SteelBlue
        Me.cmbCategoria.Location = New System.Drawing.Point(197, 150)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.NullText = "Seleziona un valore"
        Me.cmbCategoria.Size = New System.Drawing.Size(200, 36)
        Me.cmbCategoria.TabIndex = 3
        Me.cmbCategoria.ThemeName = "Fluent"
        CType(Me.cmbCategoria.GetChildAt(0), Telerik.WinControls.UI.RadDropDownListElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'RadLabel2
        '
        Me.RadLabel2.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel2.Location = New System.Drawing.Point(59, 74)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(83, 21)
        Me.RadLabel2.TabIndex = 174
        Me.RadLabel2.Text = "Descrizione"
        Me.RadLabel2.ThemeName = "MaterialTeal"
        '
        'RadLabel1
        '
        Me.RadLabel1.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel1.Location = New System.Drawing.Point(57, 25)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(61, 21)
        Me.RadLabel1.TabIndex = 173
        Me.RadLabel1.Text = "ID Asset"
        Me.RadLabel1.ThemeName = "MaterialTeal"
        '
        'txtDescr
        '
        Me.txtDescr.AutoSize = False
        Me.txtDescr.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtDescr.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtDescr.Location = New System.Drawing.Point(197, 59)
        Me.txtDescr.MaxLength = 100
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(451, 36)
        Me.txtDescr.TabIndex = 1
        Me.txtDescr.ThemeName = "Fluent"
        CType(Me.txtDescr.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'txtCodice
        '
        Me.txtCodice.AutoSize = False
        Me.txtCodice.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtCodice.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtCodice.Location = New System.Drawing.Point(197, 13)
        Me.txtCodice.MaxLength = 6
        Me.txtCodice.Name = "txtCodice"
        Me.txtCodice.ReadOnly = True
        Me.txtCodice.Size = New System.Drawing.Size(100, 36)
        Me.txtCodice.TabIndex = 0
        Me.txtCodice.ThemeName = "Fluent"
        CType(Me.txtCodice.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        CType(Me.txtCodice.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'RadLabel3
        '
        Me.RadLabel3.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel3.Location = New System.Drawing.Point(59, 112)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(113, 21)
        Me.RadLabel3.TabIndex = 175
        Me.RadLabel3.Text = "Macro categoria"
        Me.RadLabel3.ThemeName = "MaterialTeal"
        '
        'cmbMacroCat
        '
        Me.cmbMacroCat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbMacroCat.AutoSize = False
        Me.cmbMacroCat.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cmbMacroCat.ForeColor = System.Drawing.Color.SteelBlue
        Me.cmbMacroCat.Location = New System.Drawing.Point(197, 104)
        Me.cmbMacroCat.Name = "cmbMacroCat"
        Me.cmbMacroCat.NullText = "Seleziona un valore"
        Me.cmbMacroCat.Size = New System.Drawing.Size(200, 36)
        Me.cmbMacroCat.TabIndex = 2
        Me.cmbMacroCat.ThemeName = "Fluent"
        CType(Me.cmbMacroCat.GetChildAt(0), Telerik.WinControls.UI.RadDropDownListElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'cmdInserisciRiga
        '
        Me.cmdInserisciRiga.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmdInserisciRiga.Location = New System.Drawing.Point(0, 0)
        Me.cmdInserisciRiga.Name = "cmdInserisciRiga"
        Me.cmdInserisciRiga.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.cmdBarDettE1})
        Me.cmdInserisciRiga.Size = New System.Drawing.Size(713, 30)
        Me.cmdInserisciRiga.TabIndex = 37
        Me.cmdInserisciRiga.TabStop = False
        Me.cmdInserisciRiga.ThemeName = "VisualStudio2012Light"
        CType(Me.cmdInserisciRiga.GetChildAt(0), Telerik.WinControls.UI.RadCommandBarElement).BorderInnerColor4 = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer))
        CType(Me.cmdInserisciRiga.GetChildAt(0), Telerik.WinControls.UI.RadCommandBarElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(6, Byte), Integer), CType(CType(249, Byte), Integer))
        '
        'cmdBarDettE1
        '
        Me.cmdBarDettE1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBarDettE1.MinSize = New System.Drawing.Size(25, 25)
        Me.cmdBarDettE1.Name = "cmdBarDettE1"
        Me.cmdBarDettE1.Strips.AddRange(New Telerik.WinControls.UI.CommandBarStripElement() {Me.cmdBarStripDettE1})
        Me.cmdBarDettE1.Text = ""
        Me.cmdBarDettE1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBarDettE1.UseCompatibleTextRendering = False
        '
        'cmdBarStripDettE1
        '
        Me.cmdBarStripDettE1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBarStripDettE1.DisplayName = "CommandBarStripElement1"
        Me.cmdBarStripDettE1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.cmdInsDett, Me.cmdModDett, Me.cmdEliminaRiga})
        Me.cmdBarStripDettE1.Name = "cmdBarStripDettE1"
        Me.cmdBarStripDettE1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBarStripDettE1.UseCompatibleTextRendering = False
        '
        'cmdInsDett
        '
        Me.cmdInsDett.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdInsDett.DisplayName = "CommandBarButton1"
        Me.cmdInsDett.DrawText = True
        Me.cmdInsDett.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsDett.Image = CType(resources.GetObject("cmdInsDett.Image"), System.Drawing.Image)
        Me.cmdInsDett.Name = "cmdInsDett"
        Me.cmdInsDett.Text = "Inserisci"
        Me.cmdInsDett.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdInsDett.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdInsDett.UseCompatibleTextRendering = False
        '
        'cmdModDett
        '
        Me.cmdModDett.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdModDett.DisplayName = "CommandBarButton2"
        Me.cmdModDett.DrawText = True
        Me.cmdModDett.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdModDett.Image = CType(resources.GetObject("cmdModDett.Image"), System.Drawing.Image)
        Me.cmdModDett.Name = "cmdModDett"
        Me.cmdModDett.Text = "Modifica"
        Me.cmdModDett.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdModDett.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdModDett.UseCompatibleTextRendering = False
        '
        'cmdEliminaRiga
        '
        Me.cmdEliminaRiga.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdEliminaRiga.DisplayName = "CommandBarButton3"
        Me.cmdEliminaRiga.DrawText = True
        Me.cmdEliminaRiga.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminaRiga.Image = CType(resources.GetObject("cmdEliminaRiga.Image"), System.Drawing.Image)
        Me.cmdEliminaRiga.Name = "cmdEliminaRiga"
        Me.cmdEliminaRiga.Text = "Elimina"
        Me.cmdEliminaRiga.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminaRiga.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdEliminaRiga.UseCompatibleTextRendering = False
        '
        'RadTextBox1
        '
        Me.RadTextBox1.AutoSize = False
        Me.RadTextBox1.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.RadTextBox1.ForeColor = System.Drawing.Color.SteelBlue
        Me.RadTextBox1.Location = New System.Drawing.Point(198, 195)
        Me.RadTextBox1.MaxLength = 6
        Me.RadTextBox1.Name = "RadTextBox1"
        Me.RadTextBox1.ReadOnly = True
        Me.RadTextBox1.Size = New System.Drawing.Size(114, 36)
        Me.RadTextBox1.TabIndex = 182
        Me.RadTextBox1.ThemeName = "Fluent"
        CType(Me.RadTextBox1.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        CType(Me.RadTextBox1.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'RadTextBox2
        '
        Me.RadTextBox2.AutoSize = False
        Me.RadTextBox2.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.RadTextBox2.ForeColor = System.Drawing.Color.SteelBlue
        Me.RadTextBox2.Location = New System.Drawing.Point(328, 195)
        Me.RadTextBox2.MaxLength = 6
        Me.RadTextBox2.Name = "RadTextBox2"
        Me.RadTextBox2.ReadOnly = True
        Me.RadTextBox2.Size = New System.Drawing.Size(114, 36)
        Me.RadTextBox2.TabIndex = 183
        Me.RadTextBox2.ThemeName = "Fluent"
        CType(Me.RadTextBox2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        CType(Me.RadTextBox2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'RadTextBox3
        '
        Me.RadTextBox3.AutoSize = False
        Me.RadTextBox3.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.RadTextBox3.ForeColor = System.Drawing.Color.SteelBlue
        Me.RadTextBox3.Location = New System.Drawing.Point(457, 195)
        Me.RadTextBox3.MaxLength = 6
        Me.RadTextBox3.Name = "RadTextBox3"
        Me.RadTextBox3.ReadOnly = True
        Me.RadTextBox3.Size = New System.Drawing.Size(114, 36)
        Me.RadTextBox3.TabIndex = 184
        Me.RadTextBox3.ThemeName = "Fluent"
        CType(Me.RadTextBox3.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        CType(Me.RadTextBox3.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'RadLabel5
        '
        Me.RadLabel5.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel5.Location = New System.Drawing.Point(62, 203)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(107, 21)
        Me.RadLabel5.TabIndex = 185
        Me.RadLabel5.Text = "Voce dizionario"
        Me.RadLabel5.ThemeName = "MaterialTeal"
        '
        'cmdOkSearchDiz
        '
        Me.cmdOkSearchDiz.Image = CType(resources.GetObject("cmdOkSearchDiz.Image"), System.Drawing.Image)
        Me.cmdOkSearchDiz.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdOkSearchDiz.Location = New System.Drawing.Point(577, 200)
        Me.cmdOkSearchDiz.Name = "cmdOkSearchDiz"
        Me.cmdOkSearchDiz.Size = New System.Drawing.Size(25, 26)
        Me.cmdOkSearchDiz.TabIndex = 191
        Me.cmdOkSearchDiz.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdOkSearchDiz.ThemeName = "ThemeCmdRecubeYEL"
        '
        'FrmImpiantoAssets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 731)
        Me.Controls.Add(Me.gridAsset)
        Me.Controls.Add(Me.pnlDati)
        Me.Controls.Add(Me.cmdInserisciRiga)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImpiantoAssets"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Assets"
        Me.ThemeName = "MaterialBlueGrey"
        CType(Me.gridAsset.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridAsset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gridAsset.ResumeLayout(False)
        Me.gridAsset.PerformLayout()
        CType(Me.wbA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDati.PanelContainer.ResumeLayout(False)
        Me.pnlDati.PanelContainer.PerformLayout()
        CType(Me.pnlDati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDati.ResumeLayout(False)
        CType(Me.chkPian, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdAnnulla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdConferma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMacroCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdInserisciRiga, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadTextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadTextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadTextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOkSearchDiz, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MaterialTealTheme1 As Telerik.WinControls.Themes.MaterialTealTheme
    Friend WithEvents FluentTheme1 As Telerik.WinControls.Themes.FluentTheme
    Friend WithEvents Office2013DarkTheme1 As Telerik.WinControls.Themes.Office2013DarkTheme
    Friend WithEvents gridAsset As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pnlDati As Telerik.WinControls.UI.RadScrollablePanel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbCategoria As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtDescr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtCodice As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbMacroCat As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmdInserisciRiga As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents cmdBarDettE1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents cmdBarStripDettE1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents cmdInsDett As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdModDett As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdEliminaRiga As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdAnnulla As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdConferma As Telerik.WinControls.UI.RadButton
    Friend WithEvents wbA As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents DotsSpinnerWaitingBarIndicatorElement1 As Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement
    Friend WithEvents MaterialBlueGreyTheme1 As Telerik.WinControls.Themes.MaterialBlueGreyTheme
    Friend WithEvents RadThemeManager1 As Telerik.WinControls.RadThemeManager
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents chkPian As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadTextBox3 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadTextBox2 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadTextBox1 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmdOkSearchDiz As Telerik.WinControls.UI.RadButton
End Class

