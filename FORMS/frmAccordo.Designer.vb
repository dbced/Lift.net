<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAccordo
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ListViewDetailColumn1 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Mese apertura")
        Dim ListViewDataItemGroup1 As Telerik.WinControls.UI.ListViewDataItemGroup = New Telerik.WinControls.UI.ListViewDataItemGroup("ListViewGroup 1")
        Dim ListViewDetailColumn2 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Mese apertura")
        Dim ListViewDataItemGroup2 As Telerik.WinControls.UI.ListViewDataItemGroup = New Telerik.WinControls.UI.ListViewDataItemGroup("ListViewGroup 1")
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAccordo))
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition4 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition5 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.MaterialBlueGreyTheme1 = New Telerik.WinControls.Themes.MaterialBlueGreyTheme()
        Me.FluentTheme1 = New Telerik.WinControls.Themes.FluentTheme()
        Me.MaterialTealTheme1 = New Telerik.WinControls.Themes.MaterialTealTheme()
        Me.VisualStudio2012LightTheme1 = New Telerik.WinControls.Themes.VisualStudio2012LightTheme()
        Me.Office2013DarkTheme1 = New Telerik.WinControls.Themes.Office2013DarkTheme()
        Me.Office2013DarkTheme2 = New Telerik.WinControls.Themes.Office2013DarkTheme()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.t1 = New System.Windows.Forms.Timer(Me.components)
        Me.CrystalTheme1 = New Telerik.WinControls.Themes.CrystalTheme()
        Me.RPcontainer = New Telerik.WinControls.UI.RadPageView()
        Me.pageAccordo = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadPanel1 = New Telerik.WinControls.UI.RadPanel()
        Me.cmdAnnulla = New Telerik.WinControls.UI.RadButton()
        Me.cmdConferma = New Telerik.WinControls.UI.RadButton()
        Me.RadGroupBox3 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadLabel17 = New Telerik.WinControls.UI.RadLabel()
        Me.txtNrImpianti = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.RadLabel16 = New Telerik.WinControls.UI.RadLabel()
        Me.listPrestazioni = New Telerik.WinControls.UI.RadCheckedListBox()
        Me.listTipoAppalto = New Telerik.WinControls.UI.RadCheckedListBox()
        Me.RadLabel9 = New Telerik.WinControls.UI.RadLabel()
        Me.txtImporto = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.txtDtIniDecor = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.RadLabel18 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel14 = New Telerik.WinControls.UI.RadLabel()
        Me.txtDtFinDecor = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.cmbTipoContratto = New Telerik.WinControls.UI.RadMultiColumnComboBox()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.cmbProvenienza = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadLabel15 = New Telerik.WinControls.UI.RadLabel()
        Me.cmbTipoFatt = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel11 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel12 = New Telerik.WinControls.UI.RadLabel()
        Me.txtCIG = New Telerik.WinControls.UI.RadTextBox()
        Me.txtCUP = New Telerik.WinControls.UI.RadTextBox()
        Me.txtCommessa = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel10 = New Telerik.WinControls.UI.RadLabel()
        Me.txtRitenuta = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.cmbModPag = New Telerik.WinControls.UI.RadMultiColumnComboBox()
        Me.chkIvaRitenuta = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel34 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.txtIdAccordoCliente = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel13 = New Telerik.WinControls.UI.RadLabel()
        Me.groupTipoAccordo = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkAccordoQuadro = New Telerik.WinControls.UI.RadRadioButton()
        Me.chkConvenzione = New Telerik.WinControls.UI.RadRadioButton()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.txtID = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbSocieta = New Telerik.WinControls.UI.RadDropDownList()
        Me.wb = New Telerik.WinControls.UI.RadWaitingBar()
        Me.DotsRingWaitingBarIndicatorElement2 = New Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement()
        Me.cmdOkSearchCli = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.txtCodCliente = New Telerik.WinControls.UI.RadTextBox()
        Me.txtDesCli = New Telerik.WinControls.UI.RadTextBox()
        Me.txtOggetto = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.pageContrattiApp = New Telerik.WinControls.UI.RadPageViewPage()
        Me.gridContratti = New Telerik.WinControls.UI.RadGridView()
        Me.cmdBar = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripE1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.cmdInserisci = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdExportExcel = New Telerik.WinControls.UI.CommandBarButton()
        Me.pageProrogheVarianti = New Telerik.WinControls.UI.RadPageViewPage()
        Me.gridProroghe = New Telerik.WinControls.UI.RadGridView()
        Me.RadCommandBar1 = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement2 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.cmdNuovaProroga = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdNuovaVariante = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdExportProroghe = New Telerik.WinControls.UI.CommandBarButton()
        Me.pageDocumenti = New Telerik.WinControls.UI.RadPageViewPage()
        Me.gridDoc = New Telerik.WinControls.UI.RadGridView()
        Me.pagePolizze = New Telerik.WinControls.UI.RadPageViewPage()
        CType(Me.RPcontainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RPcontainer.SuspendLayout()
        Me.pageAccordo.SuspendLayout()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel1.SuspendLayout()
        CType(Me.cmdAnnulla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdConferma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox3.SuspendLayout()
        CType(Me.RadLabel17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNrImpianti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.listPrestazioni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.listTipoAppalto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDtIniDecor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDtFinDecor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoContratto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoContratto.EditorControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoContratto.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbProvenienza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoFatt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCIG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCUP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCommessa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRitenuta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbModPag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbModPag.EditorControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbModPag.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIvaRitenuta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIdAccordoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.groupTipoAccordo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupTipoAccordo.SuspendLayout()
        CType(Me.chkAccordoQuadro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkConvenzione, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSocieta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOkSearchCli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesCli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOggetto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pageContrattiApp.SuspendLayout()
        CType(Me.gridContratti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridContratti.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pageProrogheVarianti.SuspendLayout()
        CType(Me.gridProroghe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridProroghe.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pageDocumenti.SuspendLayout()
        CType(Me.gridDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridDoc.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        't1
        '
        '
        'RPcontainer
        '
        Me.RPcontainer.Controls.Add(Me.pageAccordo)
        Me.RPcontainer.Controls.Add(Me.pageContrattiApp)
        Me.RPcontainer.Controls.Add(Me.pageProrogheVarianti)
        Me.RPcontainer.Controls.Add(Me.pageDocumenti)
        Me.RPcontainer.Controls.Add(Me.pagePolizze)
        Me.RPcontainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RPcontainer.Location = New System.Drawing.Point(0, 0)
        Me.RPcontainer.Name = "RPcontainer"
        Me.RPcontainer.SelectedPage = Me.pageAccordo
        Me.RPcontainer.Size = New System.Drawing.Size(1226, 695)
        Me.RPcontainer.TabIndex = 243
        Me.RPcontainer.ThemeName = "MaterialBlueGrey"
        CType(Me.RPcontainer.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.None
        CType(Me.RPcontainer.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left
        CType(Me.RPcontainer.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal
        '
        'pageAccordo
        '
        Me.pageAccordo.Controls.Add(Me.RadPanel1)
        Me.pageAccordo.Controls.Add(Me.RadGroupBox3)
        Me.pageAccordo.Controls.Add(Me.RadGroupBox1)
        Me.pageAccordo.Controls.Add(Me.groupTipoAccordo)
        Me.pageAccordo.Controls.Add(Me.RadLabel8)
        Me.pageAccordo.Controls.Add(Me.RadLabel3)
        Me.pageAccordo.Controls.Add(Me.txtID)
        Me.pageAccordo.Controls.Add(Me.cmbSocieta)
        Me.pageAccordo.Controls.Add(Me.wb)
        Me.pageAccordo.Controls.Add(Me.cmdOkSearchCli)
        Me.pageAccordo.Controls.Add(Me.RadLabel2)
        Me.pageAccordo.Controls.Add(Me.txtCodCliente)
        Me.pageAccordo.Controls.Add(Me.txtDesCli)
        Me.pageAccordo.Controls.Add(Me.txtOggetto)
        Me.pageAccordo.Controls.Add(Me.RadLabel1)
        Me.pageAccordo.Image = CType(resources.GetObject("pageAccordo.Image"), System.Drawing.Image)
        Me.pageAccordo.ItemSize = New System.Drawing.SizeF(179.0!, 54.0!)
        Me.pageAccordo.Location = New System.Drawing.Point(185, 6)
        Me.pageAccordo.Name = "pageAccordo"
        Me.pageAccordo.Size = New System.Drawing.Size(1035, 683)
        Me.pageAccordo.Text = "Dati Generali"
        '
        'RadPanel1
        '
        Me.RadPanel1.Controls.Add(Me.cmdAnnulla)
        Me.RadPanel1.Controls.Add(Me.cmdConferma)
        Me.RadPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadPanel1.Location = New System.Drawing.Point(0, 636)
        Me.RadPanel1.Name = "RadPanel1"
        Me.RadPanel1.Size = New System.Drawing.Size(1035, 47)
        Me.RadPanel1.TabIndex = 245
        Me.RadPanel1.ThemeName = "MaterialBlueGrey"
        '
        'cmdAnnulla
        '
        Me.cmdAnnulla.Location = New System.Drawing.Point(724, 9)
        Me.cmdAnnulla.Name = "cmdAnnulla"
        Me.cmdAnnulla.Size = New System.Drawing.Size(117, 29)
        Me.cmdAnnulla.TabIndex = 21
        Me.cmdAnnulla.Text = "Annulla"
        Me.cmdAnnulla.ThemeName = "VisualStudio2012Light"
        '
        'cmdConferma
        '
        Me.cmdConferma.Location = New System.Drawing.Point(857, 9)
        Me.cmdConferma.Name = "cmdConferma"
        Me.cmdConferma.Size = New System.Drawing.Size(117, 29)
        Me.cmdConferma.TabIndex = 22
        Me.cmdConferma.Text = "Salva"
        Me.cmdConferma.ThemeName = "VisualStudio2012Light"
        '
        'RadGroupBox3
        '
        Me.RadGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox3.Controls.Add(Me.RadLabel17)
        Me.RadGroupBox3.Controls.Add(Me.txtNrImpianti)
        Me.RadGroupBox3.Controls.Add(Me.RadLabel16)
        Me.RadGroupBox3.Controls.Add(Me.listPrestazioni)
        Me.RadGroupBox3.Controls.Add(Me.listTipoAppalto)
        Me.RadGroupBox3.Controls.Add(Me.RadLabel9)
        Me.RadGroupBox3.Controls.Add(Me.txtImporto)
        Me.RadGroupBox3.Controls.Add(Me.txtDtIniDecor)
        Me.RadGroupBox3.Controls.Add(Me.RadLabel18)
        Me.RadGroupBox3.Controls.Add(Me.RadLabel14)
        Me.RadGroupBox3.Controls.Add(Me.txtDtFinDecor)
        Me.RadGroupBox3.Controls.Add(Me.RadLabel6)
        Me.RadGroupBox3.Controls.Add(Me.cmbTipoContratto)
        Me.RadGroupBox3.Controls.Add(Me.RadLabel5)
        Me.RadGroupBox3.Controls.Add(Me.RadLabel4)
        Me.RadGroupBox3.Controls.Add(Me.cmbProvenienza)
        Me.RadGroupBox3.HeaderMargin = New System.Windows.Forms.Padding(1)
        Me.RadGroupBox3.HeaderText = "Dati generali accordo"
        Me.RadGroupBox3.Location = New System.Drawing.Point(36, 181)
        Me.RadGroupBox3.Name = "RadGroupBox3"
        Me.RadGroupBox3.Size = New System.Drawing.Size(961, 258)
        Me.RadGroupBox3.TabIndex = 244
        Me.RadGroupBox3.TabStop = False
        Me.RadGroupBox3.Text = "Dati generali accordo"
        Me.RadGroupBox3.ThemeName = "Crystal"
        '
        'RadLabel17
        '
        Me.RadLabel17.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel17.Location = New System.Drawing.Point(786, 86)
        Me.RadLabel17.Name = "RadLabel17"
        Me.RadLabel17.Size = New System.Drawing.Size(83, 21)
        Me.RadLabel17.TabIndex = 244
        Me.RadLabel17.Text = "Nr. Impianti"
        Me.RadLabel17.ThemeName = "MaterialTeal"
        '
        'txtNrImpianti
        '
        Me.txtNrImpianti.AutoSize = False
        Me.txtNrImpianti.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNrImpianti.ForeColor = System.Drawing.Color.Black
        Me.txtNrImpianti.Location = New System.Drawing.Point(875, 78)
        Me.txtNrImpianti.Mask = "99999"
        Me.txtNrImpianti.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.txtNrImpianti.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txtNrImpianti.Name = "txtNrImpianti"
        Me.txtNrImpianti.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtNrImpianti.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.txtNrImpianti.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txtNrImpianti.Size = New System.Drawing.Size(60, 36)
        Me.txtNrImpianti.TabIndex = 12
        Me.txtNrImpianti.TabStop = False
        Me.txtNrImpianti.Text = "0    "
        Me.txtNrImpianti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtNrImpianti.ThemeName = "Fluent"
        CType(Me.txtNrImpianti.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = "0    "
        CType(Me.txtNrImpianti.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'RadLabel16
        '
        Me.RadLabel16.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel16.Location = New System.Drawing.Point(499, 127)
        Me.RadLabel16.Name = "RadLabel16"
        Me.RadLabel16.Size = New System.Drawing.Size(80, 21)
        Me.RadLabel16.TabIndex = 243
        Me.RadLabel16.Text = "Prestazioni"
        Me.RadLabel16.ThemeName = "MaterialTeal"
        '
        'listPrestazioni
        '
        Me.listPrestazioni.AllowColumnReorder = False
        Me.listPrestazioni.AllowColumnResize = False
        Me.listPrestazioni.AllowRemove = False
        ListViewDetailColumn1.HeaderText = "Mese apertura"
        ListViewDetailColumn1.MinWidth = 100.0!
        Me.listPrestazioni.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn1})
        Me.listPrestazioni.GroupItemSize = New System.Drawing.Size(200, 36)
        ListViewDataItemGroup1.Text = "ListViewGroup 1"
        Me.listPrestazioni.Groups.AddRange(New Telerik.WinControls.UI.ListViewDataItemGroup() {ListViewDataItemGroup1})
        Me.listPrestazioni.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysHide
        Me.listPrestazioni.ItemSize = New System.Drawing.Size(200, 36)
        Me.listPrestazioni.Location = New System.Drawing.Point(588, 125)
        Me.listPrestazioni.MultiSelect = True
        Me.listPrestazioni.Name = "listPrestazioni"
        Me.listPrestazioni.Size = New System.Drawing.Size(349, 106)
        Me.listPrestazioni.TabIndex = 13
        Me.listPrestazioni.ThemeName = "Office2013Dark"
        '
        'listTipoAppalto
        '
        Me.listTipoAppalto.AllowColumnReorder = False
        Me.listTipoAppalto.AllowColumnResize = False
        Me.listTipoAppalto.AllowRemove = False
        ListViewDetailColumn2.HeaderText = "Mese apertura"
        ListViewDetailColumn2.MinWidth = 100.0!
        Me.listTipoAppalto.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn2})
        Me.listTipoAppalto.GroupItemSize = New System.Drawing.Size(200, 36)
        ListViewDataItemGroup2.Text = "ListViewGroup 1"
        Me.listTipoAppalto.Groups.AddRange(New Telerik.WinControls.UI.ListViewDataItemGroup() {ListViewDataItemGroup2})
        Me.listTipoAppalto.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysHide
        Me.listTipoAppalto.ItemSize = New System.Drawing.Size(200, 36)
        Me.listTipoAppalto.Location = New System.Drawing.Point(131, 125)
        Me.listTipoAppalto.MultiSelect = True
        Me.listTipoAppalto.Name = "listTipoAppalto"
        Me.listTipoAppalto.Size = New System.Drawing.Size(349, 106)
        Me.listTipoAppalto.TabIndex = 9
        Me.listTipoAppalto.ThemeName = "Office2013Dark"
        '
        'RadLabel9
        '
        Me.RadLabel9.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel9.Location = New System.Drawing.Point(521, 88)
        Me.RadLabel9.Name = "RadLabel9"
        Me.RadLabel9.Size = New System.Drawing.Size(58, 21)
        Me.RadLabel9.TabIndex = 221
        Me.RadLabel9.Text = "Importo"
        Me.RadLabel9.ThemeName = "MaterialTeal"
        '
        'txtImporto
        '
        Me.txtImporto.AutoSize = False
        Me.txtImporto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporto.ForeColor = System.Drawing.Color.Black
        Me.txtImporto.Location = New System.Drawing.Point(586, 79)
        Me.txtImporto.Mask = "C"
        Me.txtImporto.MaskType = Telerik.WinControls.UI.MaskType.Numeric
        Me.txtImporto.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txtImporto.Name = "txtImporto"
        '
        '
        '
        Me.txtImporto.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txtImporto.Size = New System.Drawing.Size(181, 36)
        Me.txtImporto.TabIndex = 11
        Me.txtImporto.TabStop = False
        Me.txtImporto.Text = "€ 0,00"
        Me.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporto.ThemeName = "Fluent"
        CType(Me.txtImporto.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = "€ 0,00"
        CType(Me.txtImporto.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'txtDtIniDecor
        '
        Me.txtDtIniDecor.AutoSize = False
        Me.txtDtIniDecor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDtIniDecor.ForeColor = System.Drawing.Color.Black
        Me.txtDtIniDecor.Location = New System.Drawing.Point(131, 79)
        Me.txtDtIniDecor.Mask = "00/00/0000"
        Me.txtDtIniDecor.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.txtDtIniDecor.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txtDtIniDecor.Name = "txtDtIniDecor"
        '
        '
        '
        Me.txtDtIniDecor.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txtDtIniDecor.Size = New System.Drawing.Size(104, 36)
        Me.txtDtIniDecor.TabIndex = 7
        Me.txtDtIniDecor.TabStop = False
        Me.txtDtIniDecor.Text = "__/__/____"
        Me.txtDtIniDecor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDtIniDecor.ThemeName = "Fluent"
        CType(Me.txtDtIniDecor.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = "__/__/____"
        CType(Me.txtDtIniDecor.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'RadLabel18
        '
        Me.RadLabel18.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel18.Location = New System.Drawing.Point(16, 87)
        Me.RadLabel18.Name = "RadLabel18"
        Me.RadLabel18.Size = New System.Drawing.Size(113, 21)
        Me.RadLabel18.TabIndex = 218
        Me.RadLabel18.Text = "Data decorrenza"
        Me.RadLabel18.ThemeName = "MaterialTeal"
        '
        'RadLabel14
        '
        Me.RadLabel14.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel14.Location = New System.Drawing.Point(17, 127)
        Me.RadLabel14.Name = "RadLabel14"
        Me.RadLabel14.Size = New System.Drawing.Size(90, 21)
        Me.RadLabel14.TabIndex = 236
        Me.RadLabel14.Text = "Tipo Appalto"
        Me.RadLabel14.ThemeName = "MaterialTeal"
        '
        'txtDtFinDecor
        '
        Me.txtDtFinDecor.AutoSize = False
        Me.txtDtFinDecor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDtFinDecor.ForeColor = System.Drawing.Color.Black
        Me.txtDtFinDecor.Location = New System.Drawing.Point(375, 79)
        Me.txtDtFinDecor.Mask = "00/00/0000"
        Me.txtDtFinDecor.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.txtDtFinDecor.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txtDtFinDecor.Name = "txtDtFinDecor"
        '
        '
        '
        Me.txtDtFinDecor.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txtDtFinDecor.Size = New System.Drawing.Size(104, 36)
        Me.txtDtFinDecor.TabIndex = 8
        Me.txtDtFinDecor.TabStop = False
        Me.txtDtFinDecor.Text = "__/__/____"
        Me.txtDtFinDecor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDtFinDecor.ThemeName = "Fluent"
        CType(Me.txtDtFinDecor.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = "__/__/____"
        CType(Me.txtDtFinDecor.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'RadLabel6
        '
        Me.RadLabel6.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel6.Location = New System.Drawing.Point(261, 87)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(102, 21)
        Me.RadLabel6.TabIndex = 216
        Me.RadLabel6.Text = "Data scadenza"
        Me.RadLabel6.ThemeName = "MaterialTeal"
        '
        'cmbTipoContratto
        '
        Me.cmbTipoContratto.AutoSize = False
        '
        'cmbTipoContratto.NestedRadGridView
        '
        Me.cmbTipoContratto.EditorControl.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoContratto.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoContratto.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbTipoContratto.EditorControl.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.cmbTipoContratto.EditorControl.MasterTemplate.AllowAddNewRow = False
        Me.cmbTipoContratto.EditorControl.MasterTemplate.AllowCellContextMenu = False
        Me.cmbTipoContratto.EditorControl.MasterTemplate.AllowColumnChooser = False
        Me.cmbTipoContratto.EditorControl.MasterTemplate.EnableGrouping = False
        Me.cmbTipoContratto.EditorControl.MasterTemplate.ShowFilteringRow = False
        Me.cmbTipoContratto.EditorControl.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.cmbTipoContratto.EditorControl.Name = "NestedRadGridView"
        Me.cmbTipoContratto.EditorControl.ReadOnly = True
        Me.cmbTipoContratto.EditorControl.ShowGroupPanel = False
        Me.cmbTipoContratto.EditorControl.Size = New System.Drawing.Size(240, 150)
        Me.cmbTipoContratto.EditorControl.TabIndex = 0
        Me.cmbTipoContratto.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cmbTipoContratto.ForeColor = System.Drawing.Color.Black
        Me.cmbTipoContratto.Location = New System.Drawing.Point(131, 38)
        Me.cmbTipoContratto.Name = "cmbTipoContratto"
        Me.cmbTipoContratto.NullText = "Seleziona un valore"
        Me.cmbTipoContratto.Size = New System.Drawing.Size(348, 35)
        Me.cmbTipoContratto.TabIndex = 6
        Me.cmbTipoContratto.TabStop = False
        Me.cmbTipoContratto.ThemeName = "Fluent"
        '
        'RadLabel5
        '
        Me.RadLabel5.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel5.Location = New System.Drawing.Point(495, 45)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(87, 21)
        Me.RadLabel5.TabIndex = 180
        Me.RadLabel5.Text = "Provenienza"
        Me.RadLabel5.ThemeName = "MaterialTeal"
        '
        'RadLabel4
        '
        Me.RadLabel4.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel4.Location = New System.Drawing.Point(16, 45)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(99, 21)
        Me.RadLabel4.TabIndex = 178
        Me.RadLabel4.Text = "Tipo contratto"
        Me.RadLabel4.ThemeName = "MaterialTeal"
        '
        'cmbProvenienza
        '
        Me.cmbProvenienza.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbProvenienza.AutoSize = False
        Me.cmbProvenienza.ForeColor = System.Drawing.Color.Black
        Me.cmbProvenienza.Location = New System.Drawing.Point(587, 36)
        Me.cmbProvenienza.Name = "cmbProvenienza"
        Me.cmbProvenienza.NullText = "Seleziona un valore"
        Me.cmbProvenienza.Size = New System.Drawing.Size(348, 36)
        Me.cmbProvenienza.TabIndex = 10
        Me.cmbProvenienza.ThemeName = "Fluent"
        CType(Me.cmbProvenienza.GetChildAt(0), Telerik.WinControls.UI.RadDropDownListElement).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.RadLabel15)
        Me.RadGroupBox1.Controls.Add(Me.cmbTipoFatt)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel11)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel12)
        Me.RadGroupBox1.Controls.Add(Me.txtCIG)
        Me.RadGroupBox1.Controls.Add(Me.txtCUP)
        Me.RadGroupBox1.Controls.Add(Me.txtCommessa)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel10)
        Me.RadGroupBox1.Controls.Add(Me.txtRitenuta)
        Me.RadGroupBox1.Controls.Add(Me.cmbModPag)
        Me.RadGroupBox1.Controls.Add(Me.chkIvaRitenuta)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel34)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel7)
        Me.RadGroupBox1.Controls.Add(Me.txtIdAccordoCliente)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel13)
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(1)
        Me.RadGroupBox1.HeaderText = "Dati di fatturazione"
        Me.RadGroupBox1.Location = New System.Drawing.Point(35, 450)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(962, 171)
        Me.RadGroupBox1.TabIndex = 244
        Me.RadGroupBox1.TabStop = False
        Me.RadGroupBox1.Text = "Dati di fatturazione"
        Me.RadGroupBox1.ThemeName = "Crystal"
        '
        'RadLabel15
        '
        Me.RadLabel15.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel15.Location = New System.Drawing.Point(566, 126)
        Me.RadLabel15.Name = "RadLabel15"
        Me.RadLabel15.Size = New System.Drawing.Size(35, 21)
        Me.RadLabel15.TabIndex = 214
        Me.RadLabel15.Text = "CUP"
        Me.RadLabel15.ThemeName = "MaterialTeal"
        '
        'cmbTipoFatt
        '
        Me.cmbTipoFatt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipoFatt.AutoSize = False
        Me.cmbTipoFatt.ForeColor = System.Drawing.Color.Black
        Me.cmbTipoFatt.Location = New System.Drawing.Point(187, 35)
        Me.cmbTipoFatt.Name = "cmbTipoFatt"
        Me.cmbTipoFatt.NullText = "Seleziona un valore"
        Me.cmbTipoFatt.Size = New System.Drawing.Size(254, 36)
        Me.cmbTipoFatt.TabIndex = 14
        Me.cmbTipoFatt.ThemeName = "Fluent"
        CType(Me.cmbTipoFatt.GetChildAt(0), Telerik.WinControls.UI.RadDropDownListElement).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'RadLabel11
        '
        Me.RadLabel11.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel11.Location = New System.Drawing.Point(53, 42)
        Me.RadLabel11.Name = "RadLabel11"
        Me.RadLabel11.Size = New System.Drawing.Size(121, 21)
        Me.RadLabel11.TabIndex = 244
        Me.RadLabel11.Text = "Tipo Fatturazione"
        Me.RadLabel11.ThemeName = "MaterialTeal"
        '
        'RadLabel12
        '
        Me.RadLabel12.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel12.Location = New System.Drawing.Point(55, 86)
        Me.RadLabel12.Name = "RadLabel12"
        Me.RadLabel12.Size = New System.Drawing.Size(117, 21)
        Me.RadLabel12.TabIndex = 214
        Me.RadLabel12.Text = "Mod. pagamento"
        Me.RadLabel12.ThemeName = "MaterialTeal"
        '
        'txtCIG
        '
        Me.txtCIG.AutoSize = False
        Me.txtCIG.ForeColor = System.Drawing.Color.Black
        Me.txtCIG.Location = New System.Drawing.Point(611, 77)
        Me.txtCIG.MaxLength = 10
        Me.txtCIG.Name = "txtCIG"
        Me.txtCIG.Size = New System.Drawing.Size(254, 36)
        Me.txtCIG.TabIndex = 19
        Me.txtCIG.ThemeName = "Fluent"
        CType(Me.txtCIG.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtCIG.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'txtCUP
        '
        Me.txtCUP.AutoSize = False
        Me.txtCUP.ForeColor = System.Drawing.Color.Black
        Me.txtCUP.Location = New System.Drawing.Point(611, 117)
        Me.txtCUP.MaxLength = 15
        Me.txtCUP.Name = "txtCUP"
        Me.txtCUP.Size = New System.Drawing.Size(254, 36)
        Me.txtCUP.TabIndex = 20
        Me.txtCUP.ThemeName = "Fluent"
        CType(Me.txtCUP.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtCUP.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'txtCommessa
        '
        Me.txtCommessa.AutoSize = False
        Me.txtCommessa.ForeColor = System.Drawing.Color.Black
        Me.txtCommessa.Location = New System.Drawing.Point(611, 35)
        Me.txtCommessa.MaxLength = 12
        Me.txtCommessa.Name = "txtCommessa"
        Me.txtCommessa.Size = New System.Drawing.Size(254, 36)
        Me.txtCommessa.TabIndex = 18
        Me.txtCommessa.ThemeName = "Fluent"
        CType(Me.txtCommessa.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtCommessa.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'RadLabel10
        '
        Me.RadLabel10.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel10.Location = New System.Drawing.Point(38, 125)
        Me.RadLabel10.Name = "RadLabel10"
        Me.RadLabel10.Size = New System.Drawing.Size(142, 21)
        Me.RadLabel10.TabIndex = 223
        Me.RadLabel10.Text = "% ritenuta a garanzia"
        Me.RadLabel10.ThemeName = "MaterialTeal"
        '
        'txtRitenuta
        '
        Me.txtRitenuta.AutoSize = False
        Me.txtRitenuta.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRitenuta.ForeColor = System.Drawing.Color.Black
        Me.txtRitenuta.Location = New System.Drawing.Point(187, 117)
        Me.txtRitenuta.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txtRitenuta.Name = "txtRitenuta"
        '
        '
        '
        Me.txtRitenuta.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txtRitenuta.Size = New System.Drawing.Size(77, 36)
        Me.txtRitenuta.TabIndex = 16
        Me.txtRitenuta.TabStop = False
        Me.txtRitenuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRitenuta.ThemeName = "Fluent"
        CType(Me.txtRitenuta.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = ""
        CType(Me.txtRitenuta.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'cmbModPag
        '
        Me.cmbModPag.AutoSize = False
        '
        'cmbModPag.NestedRadGridView
        '
        Me.cmbModPag.EditorControl.BackColor = System.Drawing.SystemColors.Window
        Me.cmbModPag.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModPag.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbModPag.EditorControl.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.cmbModPag.EditorControl.MasterTemplate.AllowAddNewRow = False
        Me.cmbModPag.EditorControl.MasterTemplate.AllowCellContextMenu = False
        Me.cmbModPag.EditorControl.MasterTemplate.AllowColumnChooser = False
        Me.cmbModPag.EditorControl.MasterTemplate.EnableGrouping = False
        Me.cmbModPag.EditorControl.MasterTemplate.ShowFilteringRow = False
        Me.cmbModPag.EditorControl.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.cmbModPag.EditorControl.Name = "NestedRadGridView"
        Me.cmbModPag.EditorControl.ReadOnly = True
        Me.cmbModPag.EditorControl.ShowGroupPanel = False
        Me.cmbModPag.EditorControl.Size = New System.Drawing.Size(240, 150)
        Me.cmbModPag.EditorControl.TabIndex = 0
        Me.cmbModPag.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cmbModPag.ForeColor = System.Drawing.Color.Black
        Me.cmbModPag.Location = New System.Drawing.Point(187, 77)
        Me.cmbModPag.Name = "cmbModPag"
        Me.cmbModPag.NullText = "Seleziona un valore"
        Me.cmbModPag.Size = New System.Drawing.Size(254, 35)
        Me.cmbModPag.TabIndex = 15
        Me.cmbModPag.TabStop = False
        Me.cmbModPag.ThemeName = "Fluent"
        '
        'chkIvaRitenuta
        '
        Me.chkIvaRitenuta.ForeColor = System.Drawing.Color.DimGray
        Me.chkIvaRitenuta.Location = New System.Drawing.Point(327, 125)
        Me.chkIvaRitenuta.Name = "chkIvaRitenuta"
        Me.chkIvaRitenuta.Size = New System.Drawing.Size(114, 19)
        Me.chkIvaRitenuta.TabIndex = 17
        Me.chkIvaRitenuta.Text = "Ritenuta ivata"
        Me.chkIvaRitenuta.ThemeName = "MaterialTeal"
        '
        'RadLabel34
        '
        Me.RadLabel34.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel34.Location = New System.Drawing.Point(478, 44)
        Me.RadLabel34.Name = "RadLabel34"
        Me.RadLabel34.Size = New System.Drawing.Size(127, 21)
        Me.RadLabel34.TabIndex = 211
        Me.RadLabel34.Text = "Codice commessa"
        Me.RadLabel34.ThemeName = "MaterialTeal"
        '
        'RadLabel7
        '
        Me.RadLabel7.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel7.Location = New System.Drawing.Point(567, 86)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(30, 21)
        Me.RadLabel7.TabIndex = 213
        Me.RadLabel7.Text = "CIG"
        Me.RadLabel7.ThemeName = "MaterialTeal"
        '
        'txtIdAccordoCliente
        '
        Me.txtIdAccordoCliente.AutoSize = False
        Me.txtIdAccordoCliente.ForeColor = System.Drawing.Color.Black
        Me.txtIdAccordoCliente.Location = New System.Drawing.Point(198, 327)
        Me.txtIdAccordoCliente.MaxLength = 6
        Me.txtIdAccordoCliente.Name = "txtIdAccordoCliente"
        Me.txtIdAccordoCliente.ReadOnly = True
        Me.txtIdAccordoCliente.Size = New System.Drawing.Size(247, 36)
        Me.txtIdAccordoCliente.TabIndex = 212
        Me.txtIdAccordoCliente.ThemeName = "Fluent"
        CType(Me.txtIdAccordoCliente.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtIdAccordoCliente.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'RadLabel13
        '
        Me.RadLabel13.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel13.Location = New System.Drawing.Point(35, 336)
        Me.RadLabel13.Name = "RadLabel13"
        Me.RadLabel13.Size = New System.Drawing.Size(124, 21)
        Me.RadLabel13.TabIndex = 213
        Me.RadLabel13.Text = "Id accordo Cliente"
        Me.RadLabel13.ThemeName = "MaterialTeal"
        '
        'groupTipoAccordo
        '
        Me.groupTipoAccordo.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.groupTipoAccordo.Controls.Add(Me.chkAccordoQuadro)
        Me.groupTipoAccordo.Controls.Add(Me.chkConvenzione)
        Me.groupTipoAccordo.HeaderMargin = New System.Windows.Forms.Padding(1)
        Me.groupTipoAccordo.HeaderText = "Tipologia Accordo"
        Me.groupTipoAccordo.Location = New System.Drawing.Point(808, 21)
        Me.groupTipoAccordo.Name = "groupTipoAccordo"
        Me.groupTipoAccordo.Size = New System.Drawing.Size(186, 119)
        Me.groupTipoAccordo.TabIndex = 243
        Me.groupTipoAccordo.TabStop = False
        Me.groupTipoAccordo.Text = "Tipologia Accordo"
        Me.groupTipoAccordo.ThemeName = "Crystal"
        '
        'chkAccordoQuadro
        '
        Me.chkAccordoQuadro.Location = New System.Drawing.Point(21, 46)
        Me.chkAccordoQuadro.Name = "chkAccordoQuadro"
        Me.chkAccordoQuadro.Size = New System.Drawing.Size(136, 19)
        Me.chkAccordoQuadro.TabIndex = 4
        Me.chkAccordoQuadro.Text = "ACCORDO QUADRO"
        Me.chkAccordoQuadro.ThemeName = "Office2013Dark"
        '
        'chkConvenzione
        '
        Me.chkConvenzione.Location = New System.Drawing.Point(22, 82)
        Me.chkConvenzione.Name = "chkConvenzione"
        Me.chkConvenzione.Size = New System.Drawing.Size(108, 19)
        Me.chkConvenzione.TabIndex = 5
        Me.chkConvenzione.Text = "CONVENZIONE"
        Me.chkConvenzione.ThemeName = "Office2013Dark"
        '
        'RadLabel8
        '
        Me.RadLabel8.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel8.Location = New System.Drawing.Point(549, 20)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(21, 21)
        Me.RadLabel8.TabIndex = 195
        Me.RadLabel8.Text = "ID"
        Me.RadLabel8.ThemeName = "MaterialTeal"
        '
        'RadLabel3
        '
        Me.RadLabel3.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel3.Location = New System.Drawing.Point(38, 18)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(56, 21)
        Me.RadLabel3.TabIndex = 176
        Me.RadLabel3.Text = "Società"
        Me.RadLabel3.ThemeName = "MaterialTeal"
        '
        'txtID
        '
        Me.txtID.AutoSize = False
        Me.txtID.ForeColor = System.Drawing.Color.Black
        Me.txtID.Location = New System.Drawing.Point(576, 12)
        Me.txtID.MaxLength = 6
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(79, 36)
        Me.txtID.TabIndex = 194
        Me.txtID.TabStop = False
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtID.ThemeName = "Fluent"
        CType(Me.txtID.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtID.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'cmbSocieta
        '
        Me.cmbSocieta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbSocieta.AutoSize = False
        Me.cmbSocieta.ForeColor = System.Drawing.Color.Black
        Me.cmbSocieta.Location = New System.Drawing.Point(118, 12)
        Me.cmbSocieta.Name = "cmbSocieta"
        Me.cmbSocieta.NullText = "Seleziona un valore"
        Me.cmbSocieta.Size = New System.Drawing.Size(365, 36)
        Me.cmbSocieta.TabIndex = 0
        Me.cmbSocieta.ThemeName = "Fluent"
        CType(Me.cmbSocieta.GetChildAt(0), Telerik.WinControls.UI.RadDropDownListElement).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'wb
        '
        Me.wb.AccessibleName = "d"
        Me.wb.Location = New System.Drawing.Point(687, 105)
        Me.wb.Name = "wb"
        Me.wb.Size = New System.Drawing.Size(70, 70)
        Me.wb.TabIndex = 240
        Me.wb.Text = "RadWaitingBar1"
        Me.wb.ThemeName = "Fluent"
        Me.wb.Visible = False
        Me.wb.WaitingIndicators.Add(Me.DotsRingWaitingBarIndicatorElement2)
        Me.wb.WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        Me.wb.WaitingSpeed = 50
        Me.wb.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsRing
        CType(Me.wb.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        CType(Me.wb.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingSpeed = 50
        CType(Me.wb.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarContentElement).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsRing
        CType(Me.wb.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).Dash = False
        '
        'DotsRingWaitingBarIndicatorElement2
        '
        Me.DotsRingWaitingBarIndicatorElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsRingWaitingBarIndicatorElement2.DisableHTMLRendering = True
        Me.DotsRingWaitingBarIndicatorElement2.DotRadius = 10
        Me.DotsRingWaitingBarIndicatorElement2.Name = "DotsRingWaitingBarIndicatorElement2"
        Me.DotsRingWaitingBarIndicatorElement2.Radius = 30
        Me.DotsRingWaitingBarIndicatorElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsRingWaitingBarIndicatorElement2.UseCompatibleTextRendering = False
        '
        'cmdOkSearchCli
        '
        Me.cmdOkSearchCli.Image = CType(resources.GetObject("cmdOkSearchCli.Image"), System.Drawing.Image)
        Me.cmdOkSearchCli.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdOkSearchCli.Location = New System.Drawing.Point(660, 54)
        Me.cmdOkSearchCli.Name = "cmdOkSearchCli"
        Me.cmdOkSearchCli.Size = New System.Drawing.Size(34, 34)
        Me.cmdOkSearchCli.TabIndex = 2
        Me.cmdOkSearchCli.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'RadLabel2
        '
        Me.RadLabel2.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel2.Location = New System.Drawing.Point(33, 63)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(73, 21)
        Me.RadLabel2.TabIndex = 193
        Me.RadLabel2.Text = "Stipulante"
        Me.RadLabel2.ThemeName = "MaterialTeal"
        '
        'txtCodCliente
        '
        Me.txtCodCliente.AutoSize = False
        Me.txtCodCliente.ForeColor = System.Drawing.Color.Black
        Me.txtCodCliente.Location = New System.Drawing.Point(118, 54)
        Me.txtCodCliente.MaxLength = 6
        Me.txtCodCliente.Name = "txtCodCliente"
        Me.txtCodCliente.ReadOnly = True
        Me.txtCodCliente.Size = New System.Drawing.Size(106, 36)
        Me.txtCodCliente.TabIndex = 1
        Me.txtCodCliente.ThemeName = "Fluent"
        CType(Me.txtCodCliente.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtCodCliente.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'txtDesCli
        '
        Me.txtDesCli.AutoSize = False
        Me.txtDesCli.ForeColor = System.Drawing.Color.Black
        Me.txtDesCli.Location = New System.Drawing.Point(231, 54)
        Me.txtDesCli.MaxLength = 6
        Me.txtDesCli.Name = "txtDesCli"
        Me.txtDesCli.ReadOnly = True
        Me.txtDesCli.Size = New System.Drawing.Size(424, 36)
        Me.txtDesCli.TabIndex = 194
        Me.txtDesCli.TabStop = False
        Me.txtDesCli.ThemeName = "Fluent"
        CType(Me.txtDesCli.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtDesCli.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'txtOggetto
        '
        Me.txtOggetto.AutoSize = False
        Me.txtOggetto.ForeColor = System.Drawing.Color.Black
        Me.txtOggetto.Location = New System.Drawing.Point(118, 96)
        Me.txtOggetto.MaxLength = 150
        Me.txtOggetto.Multiline = True
        Me.txtOggetto.Name = "txtOggetto"
        Me.txtOggetto.Size = New System.Drawing.Size(537, 72)
        Me.txtOggetto.TabIndex = 3
        Me.txtOggetto.TabStop = False
        Me.txtOggetto.ThemeName = "Fluent"
        CType(Me.txtOggetto.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).StretchVertically = True
        CType(Me.txtOggetto.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtOggetto.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'RadLabel1
        '
        Me.RadLabel1.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel1.Location = New System.Drawing.Point(36, 100)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(59, 21)
        Me.RadLabel1.TabIndex = 194
        Me.RadLabel1.Text = "Oggetto"
        Me.RadLabel1.ThemeName = "MaterialTeal"
        '
        'pageContrattiApp
        '
        Me.pageContrattiApp.Controls.Add(Me.gridContratti)
        Me.pageContrattiApp.Controls.Add(Me.cmdBar)
        Me.pageContrattiApp.Image = CType(resources.GetObject("pageContrattiApp.Image"), System.Drawing.Image)
        Me.pageContrattiApp.ItemSize = New System.Drawing.SizeF(179.0!, 54.0!)
        Me.pageContrattiApp.Location = New System.Drawing.Point(185, 6)
        Me.pageContrattiApp.Name = "pageContrattiApp"
        Me.pageContrattiApp.Size = New System.Drawing.Size(1035, 683)
        Me.pageContrattiApp.Text = "Contratti Applicativi"
        '
        'gridContratti
        '
        Me.gridContratti.BackColor = System.Drawing.Color.White
        Me.gridContratti.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridContratti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridContratti.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.gridContratti.ForeColor = System.Drawing.Color.Black
        Me.gridContratti.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.gridContratti.Location = New System.Drawing.Point(0, 40)
        '
        '
        '
        Me.gridContratti.MasterTemplate.AllowAddNewRow = False
        Me.gridContratti.MasterTemplate.AllowColumnChooser = False
        Me.gridContratti.MasterTemplate.AllowDeleteRow = False
        Me.gridContratti.MasterTemplate.AllowDragToGroup = False
        Me.gridContratti.MasterTemplate.AllowRowResize = False
        Me.gridContratti.MasterTemplate.ViewDefinition = TableViewDefinition3
        Me.gridContratti.Name = "gridContratti"
        Me.gridContratti.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gridContratti.ShowGroupPanel = False
        Me.gridContratti.Size = New System.Drawing.Size(1035, 643)
        Me.gridContratti.TabIndex = 241
        Me.gridContratti.ThemeName = "Fluent"
        '
        'cmdBar
        '
        Me.cmdBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmdBar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmdBar.Location = New System.Drawing.Point(0, 0)
        Me.cmdBar.Name = "cmdBar"
        Me.cmdBar.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement1})
        Me.cmdBar.Size = New System.Drawing.Size(1035, 40)
        Me.cmdBar.TabIndex = 244
        Me.cmdBar.ThemeName = "Windows8"
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
        Me.CommandBarStripE1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.cmdInserisci, Me.cmdExportExcel})
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
        Me.cmdInserisci.Text = "Nuovo Contratto"
        Me.cmdInserisci.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdInserisci.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdInserisci.UseCompatibleTextRendering = False
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdExportExcel.DisplayName = "CommandBarButton1"
        Me.cmdExportExcel.DrawText = True
        Me.cmdExportExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExportExcel.Image = CType(resources.GetObject("cmdExportExcel.Image"), System.Drawing.Image)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Text = "Esporta Excel"
        Me.cmdExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdExportExcel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdExportExcel.UseCompatibleTextRendering = False
        '
        'pageProrogheVarianti
        '
        Me.pageProrogheVarianti.Controls.Add(Me.gridProroghe)
        Me.pageProrogheVarianti.Controls.Add(Me.RadCommandBar1)
        Me.pageProrogheVarianti.Image = CType(resources.GetObject("pageProrogheVarianti.Image"), System.Drawing.Image)
        Me.pageProrogheVarianti.ItemSize = New System.Drawing.SizeF(179.0!, 54.0!)
        Me.pageProrogheVarianti.Location = New System.Drawing.Point(185, 6)
        Me.pageProrogheVarianti.Name = "pageProrogheVarianti"
        Me.pageProrogheVarianti.Size = New System.Drawing.Size(1035, 683)
        Me.pageProrogheVarianti.Text = "Proroghe e Varianti"
        '
        'gridProroghe
        '
        Me.gridProroghe.BackColor = System.Drawing.Color.White
        Me.gridProroghe.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridProroghe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridProroghe.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.gridProroghe.ForeColor = System.Drawing.Color.Black
        Me.gridProroghe.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.gridProroghe.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.gridProroghe.MasterTemplate.AllowAddNewRow = False
        Me.gridProroghe.MasterTemplate.AllowColumnChooser = False
        Me.gridProroghe.MasterTemplate.AllowDeleteRow = False
        Me.gridProroghe.MasterTemplate.AllowDragToGroup = False
        Me.gridProroghe.MasterTemplate.AllowRowResize = False
        Me.gridProroghe.MasterTemplate.ViewDefinition = TableViewDefinition4
        Me.gridProroghe.Name = "gridProroghe"
        Me.gridProroghe.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gridProroghe.ShowGroupPanel = False
        Me.gridProroghe.Size = New System.Drawing.Size(1035, 683)
        Me.gridProroghe.TabIndex = 243
        Me.gridProroghe.ThemeName = "Fluent"
        '
        'RadCommandBar1
        '
        Me.RadCommandBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadCommandBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.RadCommandBar1.Name = "RadCommandBar1"
        Me.RadCommandBar1.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement2})
        Me.RadCommandBar1.Size = New System.Drawing.Size(1035, 0)
        Me.RadCommandBar1.TabIndex = 245
        Me.RadCommandBar1.ThemeName = "Windows8"
        '
        'CommandBarRowElement2
        '
        Me.CommandBarRowElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarRowElement2.MinSize = New System.Drawing.Size(25, 25)
        Me.CommandBarRowElement2.Name = "CommandBarRowElement1"
        Me.CommandBarRowElement2.Strips.AddRange(New Telerik.WinControls.UI.CommandBarStripElement() {Me.CommandBarStripElement1})
        Me.CommandBarRowElement2.Text = ""
        Me.CommandBarRowElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarRowElement2.UseCompatibleTextRendering = False
        '
        'CommandBarStripElement1
        '
        Me.CommandBarStripElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarStripElement1.DisplayName = "CommandBarStripElement1"
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.cmdNuovaProroga, Me.cmdNuovaVariante, Me.cmdExportProroghe})
        Me.CommandBarStripElement1.Name = "CommandBarStripE1"
        Me.CommandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarStripElement1.UseCompatibleTextRendering = False
        '
        'cmdNuovaProroga
        '
        Me.cmdNuovaProroga.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdNuovaProroga.DisplayName = "CommandBarButton1"
        Me.cmdNuovaProroga.DrawText = True
        Me.cmdNuovaProroga.Image = CType(resources.GetObject("cmdNuovaProroga.Image"), System.Drawing.Image)
        Me.cmdNuovaProroga.Name = "cmdNuovaProroga"
        Me.cmdNuovaProroga.Text = "Nuova Proroga"
        Me.cmdNuovaProroga.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdNuovaProroga.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdNuovaProroga.UseCompatibleTextRendering = False
        '
        'cmdNuovaVariante
        '
        Me.cmdNuovaVariante.DisplayName = "CommandBarButton3"
        Me.cmdNuovaVariante.DrawText = True
        Me.cmdNuovaVariante.Image = CType(resources.GetObject("cmdNuovaVariante.Image"), System.Drawing.Image)
        Me.cmdNuovaVariante.Name = "cmdNuovaVariante"
        Me.cmdNuovaVariante.Text = "Nuova Variante"
        Me.cmdNuovaVariante.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'cmdExportProroghe
        '
        Me.cmdExportProroghe.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdExportProroghe.DisplayName = "CommandBarButton1"
        Me.cmdExportProroghe.DrawText = True
        Me.cmdExportProroghe.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExportProroghe.Image = CType(resources.GetObject("cmdExportProroghe.Image"), System.Drawing.Image)
        Me.cmdExportProroghe.Name = "cmdExportProroghe"
        Me.cmdExportProroghe.Text = "Esporta Excel"
        Me.cmdExportProroghe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdExportProroghe.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdExportProroghe.UseCompatibleTextRendering = False
        '
        'pageDocumenti
        '
        Me.pageDocumenti.Controls.Add(Me.gridDoc)
        Me.pageDocumenti.Image = CType(resources.GetObject("pageDocumenti.Image"), System.Drawing.Image)
        Me.pageDocumenti.ItemSize = New System.Drawing.SizeF(179.0!, 54.0!)
        Me.pageDocumenti.Location = New System.Drawing.Point(185, 6)
        Me.pageDocumenti.Name = "pageDocumenti"
        Me.pageDocumenti.Size = New System.Drawing.Size(1029, 671)
        Me.pageDocumenti.Text = "Documenti"
        '
        'gridDoc
        '
        Me.gridDoc.BackColor = System.Drawing.Color.White
        Me.gridDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDoc.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.gridDoc.ForeColor = System.Drawing.Color.Black
        Me.gridDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.gridDoc.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.gridDoc.MasterTemplate.AllowAddNewRow = False
        Me.gridDoc.MasterTemplate.AllowColumnChooser = False
        Me.gridDoc.MasterTemplate.AllowDeleteRow = False
        Me.gridDoc.MasterTemplate.AllowDragToGroup = False
        Me.gridDoc.MasterTemplate.AllowRowResize = False
        Me.gridDoc.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        Me.gridDoc.MasterTemplate.ViewDefinition = TableViewDefinition5
        Me.gridDoc.Name = "gridDoc"
        Me.gridDoc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gridDoc.ShowGroupPanel = False
        Me.gridDoc.Size = New System.Drawing.Size(1029, 671)
        Me.gridDoc.TabIndex = 190
        Me.gridDoc.ThemeName = "Fluent"
        '
        'pagePolizze
        '
        Me.pagePolizze.Image = CType(resources.GetObject("pagePolizze.Image"), System.Drawing.Image)
        Me.pagePolizze.ItemSize = New System.Drawing.SizeF(179.0!, 54.0!)
        Me.pagePolizze.Location = New System.Drawing.Point(185, 6)
        Me.pagePolizze.Name = "pagePolizze"
        Me.pagePolizze.Size = New System.Drawing.Size(1035, 683)
        Me.pagePolizze.Text = "Polizze"
        '
        'FrmAccordo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1226, 695)
        Me.Controls.Add(Me.RPcontainer)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAccordo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestione Accordo"
        Me.ThemeName = "MaterialBlueGrey"
        CType(Me.RPcontainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RPcontainer.ResumeLayout(False)
        Me.pageAccordo.ResumeLayout(False)
        Me.pageAccordo.PerformLayout()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel1.ResumeLayout(False)
        CType(Me.cmdAnnulla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdConferma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox3.ResumeLayout(False)
        Me.RadGroupBox3.PerformLayout()
        CType(Me.RadLabel17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNrImpianti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.listPrestazioni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.listTipoAppalto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDtIniDecor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDtFinDecor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoContratto.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoContratto.EditorControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoContratto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbProvenienza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoFatt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCIG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCUP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCommessa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRitenuta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbModPag.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbModPag.EditorControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbModPag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIvaRitenuta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIdAccordoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.groupTipoAccordo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupTipoAccordo.ResumeLayout(False)
        Me.groupTipoAccordo.PerformLayout()
        CType(Me.chkAccordoQuadro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkConvenzione, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSocieta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOkSearchCli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesCli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOggetto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pageContrattiApp.ResumeLayout(False)
        Me.pageContrattiApp.PerformLayout()
        CType(Me.gridContratti.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridContratti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pageProrogheVarianti.ResumeLayout(False)
        Me.pageProrogheVarianti.PerformLayout()
        CType(Me.gridProroghe.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridProroghe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pageDocumenti.ResumeLayout(False)
        CType(Me.gridDoc.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MaterialBlueGreyTheme1 As Telerik.WinControls.Themes.MaterialBlueGreyTheme
    Friend WithEvents FluentTheme1 As Telerik.WinControls.Themes.FluentTheme
    Friend WithEvents MaterialTealTheme1 As Telerik.WinControls.Themes.MaterialTealTheme
    Friend WithEvents VisualStudio2012LightTheme1 As Telerik.WinControls.Themes.VisualStudio2012LightTheme
    Friend WithEvents Office2013DarkTheme1 As Telerik.WinControls.Themes.Office2013DarkTheme
    Friend WithEvents Office2013DarkTheme2 As Telerik.WinControls.Themes.Office2013DarkTheme
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents t1 As Timer
    Friend WithEvents CrystalTheme1 As Telerik.WinControls.Themes.CrystalTheme
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbSocieta As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtDesCli As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtCodCliente As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdOkSearchCli As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtOggetto As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbProvenienza As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtCommessa As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel34 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel12 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbTipoFatt As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtDtIniDecor As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents RadLabel18 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtDtFinDecor As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkIvaRitenuta As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents txtCIG As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtCUP As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel9 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtImporto As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents RadLabel10 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtRitenuta As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents txtIdAccordoCliente As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel13 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel14 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents listPrestazioni As Telerik.WinControls.UI.RadCheckedListBox
    Friend WithEvents wb As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents DotsRingWaitingBarIndicatorElement2 As Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement
    Friend WithEvents cmbTipoContratto As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbModPag As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents RPcontainer As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pageAccordo As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents pageContrattiApp As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtID As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents groupTipoAccordo As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkAccordoQuadro As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents chkConvenzione As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents gridContratti As Telerik.WinControls.UI.RadGridView
    Friend WithEvents RadLabel11 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadGroupBox3 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadLabel15 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents listTipoAppalto As Telerik.WinControls.UI.RadCheckedListBox
    Friend WithEvents RadLabel16 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents pageProrogheVarianti As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents gridProroghe As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pageDocumenti As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents gridDoc As Telerik.WinControls.UI.RadGridView
    Friend WithEvents cmdBar As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripE1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents cmdInserisci As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdExportExcel As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents RadCommandBar1 As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement2 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents cmdNuovaProroga As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdExportProroghe As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdNuovaVariante As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents RadPanel1 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents cmdAnnulla As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdConferma As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel17 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtNrImpianti As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents pagePolizze As Telerik.WinControls.UI.RadPageViewPage
End Class

