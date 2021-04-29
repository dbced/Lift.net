<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmChiamate
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChiamate))
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.MaterialBlueGreyTheme1 = New Telerik.WinControls.Themes.MaterialBlueGreyTheme()
        Me.FluentTheme1 = New Telerik.WinControls.Themes.FluentTheme()
        Me.MaterialTealTheme1 = New Telerik.WinControls.Themes.MaterialTealTheme()
        Me.VisualStudio2012LightTheme1 = New Telerik.WinControls.Themes.VisualStudio2012LightTheme()
        Me.Office2013DarkTheme1 = New Telerik.WinControls.Themes.Office2013DarkTheme()
        Me.Office2013DarkTheme2 = New Telerik.WinControls.Themes.Office2013DarkTheme()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.t1 = New System.Windows.Forms.Timer(Me.components)
        Me.CrystalTheme1 = New Telerik.WinControls.Themes.CrystalTheme()
        Me.dockGen = New Telerik.WinControls.UI.Docking.RadDock()
        Me.DocWinRicerca = New Telerik.WinControls.UI.Docking.DocumentWindow()
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel22 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel21 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel20 = New Telerik.WinControls.UI.RadLabel()
        Me.lista_Stati = New Telerik.WinControls.UI.RadCheckedListBox()
        Me.RadLabel18 = New Telerik.WinControls.UI.RadLabel()
        Me.txtDesClienteRic = New Telerik.WinControls.UI.RadTextBox()
        Me.txtDesImpRic = New Telerik.WinControls.UI.RadTextBox()
        Me.txtDesTecRic = New Telerik.WinControls.UI.RadTextBox()
        Me.txtDesCentroRic = New Telerik.WinControls.UI.RadTextBox()
        Me.txtDesSocRic = New Telerik.WinControls.UI.RadTextBox()
        Me.txtCodTecRic = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel16 = New Telerik.WinControls.UI.RadLabel()
        Me.txtAperturaAl = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.txtAperturaDal = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.RadLabel15 = New Telerik.WinControls.UI.RadLabel()
        Me.chkImpiantiFunz = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkImpiantiFermi = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkImpiantiDisdetti = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkChiamateReper = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkChiamateSabato = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkChiamateRep = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkImpiantiNonCritici = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkImpiantiCritici = New Telerik.WinControls.UI.RadCheckBox()
        Me.txtCodImpRic = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel13 = New Telerik.WinControls.UI.RadLabel()
        Me.txtCodCentroRic = New Telerik.WinControls.UI.RadTextBox()
        Me.txtCodSocRic = New Telerik.WinControls.UI.RadTextBox()
        Me.cmdSearchTec = New Telerik.WinControls.UI.RadButton()
        Me.cmdSearchImp = New Telerik.WinControls.UI.RadButton()
        Me.cmdSearchCen = New Telerik.WinControls.UI.RadButton()
        Me.cmdSearchSoc = New Telerik.WinControls.UI.RadButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodClienteRic = New Telerik.WinControls.UI.RadTextBox()
        Me.cmdSearchCli = New Telerik.WinControls.UI.RadButton()
        Me.cmdFiltro = New Telerik.WinControls.UI.RadButton()
        Me.DocContainerUp = New Telerik.WinControls.UI.Docking.DocumentContainer()
        Me.DocumentTabStrip4 = New Telerik.WinControls.UI.Docking.DocumentTabStrip()
        Me.DocWinElenco = New Telerik.WinControls.UI.Docking.DocumentWindow()
        Me.grid = New Telerik.WinControls.UI.RadGridView()
        Me.wb4 = New Telerik.WinControls.UI.RadWaitingBar()
        Me.DotsLineWaitingBarIndicatorElement4 = New Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement()
        Me.wb3 = New Telerik.WinControls.UI.RadWaitingBar()
        Me.DotsLineWaitingBarIndicatorElement3 = New Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement()
        Me.wb2 = New Telerik.WinControls.UI.RadWaitingBar()
        Me.DotsLineWaitingBarIndicatorElement2 = New Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement()
        Me.wb1 = New Telerik.WinControls.UI.RadWaitingBar()
        Me.DotsLineWaitingBarIndicatorElement1 = New Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement()
        Me.wb = New Telerik.WinControls.UI.RadWaitingBar()
        Me.DotsRingWaitingBarIndicatorElement2 = New Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement()
        Me.cmdBar = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripE1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.cmdInserisci = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdModChiam = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdDelChiam = New Telerik.WinControls.UI.CommandBarButton()
        Me.DocTabStripMappa = New Telerik.WinControls.UI.Docking.DocumentTabStrip()
        Me.ToolWinMap = New Telerik.WinControls.UI.Docking.ToolWindow()
        Me.map = New Telerik.WinControls.UI.RadMap()
        Me.RadCommandBar1 = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement2 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.cmdBarStripE1mappa = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.cmdBcaricaTecnici = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdBCaricaLimit = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdBFocusTec = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdBFocusImp = New Telerik.WinControls.UI.CommandBarButton()
        Me.ToolTabStrip1 = New Telerik.WinControls.UI.Docking.ToolTabStrip()
        Me.ToolWinChiamata = New Telerik.WinControls.UI.Docking.ToolWindow()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.cmdAnnulla = New Telerik.WinControls.UI.RadButton()
        Me.cmdConferma = New Telerik.WinControls.UI.RadButton()
        Me.groupImpianto = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtTipoImp = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbCentri = New Telerik.WinControls.UI.RadMultiColumnComboBox()
        Me.RadLabel12 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel11 = New Telerik.WinControls.UI.RadLabel()
        Me.txtLocalita = New Telerik.WinControls.UI.RadTextBox()
        Me.TxtCodice = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbSocieta = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel10 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel9 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel17 = New Telerik.WinControls.UI.RadLabel()
        Me.txtIndirizzo = New Telerik.WinControls.UI.RadTextBox()
        Me.cmdOkSearchImp = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel14 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.txtCap = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.txtProv = New Telerik.WinControls.UI.RadTextBox()
        Me.groupInfo = New Telerik.WinControls.UI.RadGroupBox()
        Me.imgTel = New System.Windows.Forms.PictureBox()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadLabel27 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel25 = New Telerik.WinControls.UI.RadLabel()
        Me.optAPE = New Telerik.WinControls.UI.RadRadioButton()
        Me.optCHI = New Telerik.WinControls.UI.RadRadioButton()
        Me.optASS = New Telerik.WinControls.UI.RadRadioButton()
        Me.optSOS = New Telerik.WinControls.UI.RadRadioButton()
        Me.optLAV = New Telerik.WinControls.UI.RadRadioButton()
        Me.txtDataStato = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.txtOraStato = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.listStati = New Telerik.WinControls.UI.RadListControl()
        Me.RadLabel24 = New Telerik.WinControls.UI.RadLabel()
        Me.txtRiscontro = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbTecnico = New Telerik.WinControls.UI.RadMultiColumnComboBox()
        Me.cmbStatoChiamata = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel19 = New Telerik.WinControls.UI.RadLabel()
        Me.txtDataAssegn = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.txtOraAss = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.groupChiamata = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.txtIdWeb = New Telerik.WinControls.UI.RadTextBox()
        Me.chkOre13 = New Telerik.WinControls.UI.RadCheckBox()
        Me.txtID = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel23 = New Telerik.WinControls.UI.RadLabel()
        Me.txtChiamante = New Telerik.WinControls.UI.RadTextBox()
        Me.txtRecapito = New Telerik.WinControls.UI.RadTextBox()
        Me.txtMotivo = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbMotivo = New Telerik.WinControls.UI.RadDropDownList()
        Me.chkIntrappolamento = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkImpiantoFermo = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkReperib = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.splitDashBoard = New Telerik.WinControls.UI.RadSplitContainer()
        Me.SplitDash1 = New Telerik.WinControls.UI.SplitPanel()
        Me.lblVisAssegnate = New Telerik.WinControls.UI.RadLabel()
        Me.lblNrAss = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel32 = New Telerik.WinControls.UI.RadLabel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.SplitDash2 = New Telerik.WinControls.UI.SplitPanel()
        Me.lblVisLav = New Telerik.WinControls.UI.RadLabel()
        Me.lblNrLav = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel26 = New Telerik.WinControls.UI.RadLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SplitDash3 = New Telerik.WinControls.UI.SplitPanel()
        Me.lblImpiantiFermi = New Telerik.WinControls.UI.RadLabel()
        Me.lblVisSos = New Telerik.WinControls.UI.RadLabel()
        Me.lblNrSos = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel28 = New Telerik.WinControls.UI.RadLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.SplitDash4 = New Telerik.WinControls.UI.SplitPanel()
        Me.lblVisChi = New Telerik.WinControls.UI.RadLabel()
        Me.lblNrChi = New Telerik.WinControls.UI.RadLabel()
        Me.lblChiamateChiuse = New Telerik.WinControls.UI.RadLabel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Images1 = New LiftCore.EdocImages.Images()
        Me.t1Dash = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dockGen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dockGen.SuspendLayout()
        Me.DocWinRicerca.SuspendLayout()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lista_Stati, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesClienteRic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesImpRic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesTecRic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesCentroRic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesSocRic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodTecRic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAperturaAl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAperturaDal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkImpiantiFunz, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkImpiantiFermi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkImpiantiDisdetti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkChiamateReper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkChiamateSabato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkChiamateRep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkImpiantiNonCritici, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkImpiantiCritici, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodImpRic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodCentroRic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodSocRic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdSearchTec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdSearchImp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdSearchCen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdSearchSoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodClienteRic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdSearchCli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocContainerUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DocContainerUp.SuspendLayout()
        CType(Me.DocumentTabStrip4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DocumentTabStrip4.SuspendLayout()
        Me.DocWinElenco.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grid.SuspendLayout()
        CType(Me.wb4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wb3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wb2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wb1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocTabStripMappa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DocTabStripMappa.SuspendLayout()
        Me.ToolWinMap.SuspendLayout()
        CType(Me.map, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToolTabStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolTabStrip1.SuspendLayout()
        Me.ToolWinChiamata.SuspendLayout()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdAnnulla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdConferma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.groupImpianto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupImpianto.SuspendLayout()
        CType(Me.txtTipoImp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentri, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentri.EditorControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentri.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLocalita, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSocieta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIndirizzo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOkSearchImp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.groupInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupInfo.SuspendLayout()
        CType(Me.imgTel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.RadLabel27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optAPE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optCHI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optASS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optSOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optLAV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataStato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOraStato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.listStati, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRiscontro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTecnico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTecnico.EditorControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTecnico.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbStatoChiamata, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDataAssegn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOraAss, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.groupChiamata, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupChiamata.SuspendLayout()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIdWeb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOre13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChiamante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRecapito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIntrappolamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkImpiantoFermo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkReperib, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splitDashBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitDashBoard.SuspendLayout()
        CType(Me.SplitDash1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitDash1.SuspendLayout()
        CType(Me.lblVisAssegnate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNrAss, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitDash2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitDash2.SuspendLayout()
        CType(Me.lblVisLav, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNrLav, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitDash3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitDash3.SuspendLayout()
        CType(Me.lblImpiantiFermi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblVisSos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNrSos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitDash4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitDash4.SuspendLayout()
        CType(Me.lblVisChi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNrChi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblChiamateChiuse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        't1
        '
        '
        'dockGen
        '
        Me.dockGen.ActiveWindow = Me.ToolWinMap
        Me.dockGen.CausesValidation = False
        Me.dockGen.Controls.Add(Me.DocContainerUp)
        Me.dockGen.Controls.Add(Me.ToolTabStrip1)
        Me.dockGen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dockGen.IsCleanUpTarget = True
        Me.dockGen.Location = New System.Drawing.Point(0, 116)
        Me.dockGen.MainDocumentContainer = Me.DocContainerUp
        Me.dockGen.Name = "dockGen"
        Me.dockGen.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.dockGen.Padding = New System.Windows.Forms.Padding(0)
        '
        '
        '
        Me.dockGen.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.dockGen.Size = New System.Drawing.Size(1538, 827)
        Me.dockGen.SplitterWidth = 8
        Me.dockGen.TabIndex = 194
        Me.dockGen.TabStop = False
        Me.dockGen.ThemeName = "Fluent"
        '
        'DocWinRicerca
        '
        Me.DocWinRicerca.Controls.Add(Me.RadButton2)
        Me.DocWinRicerca.Controls.Add(Me.RadLabel22)
        Me.DocWinRicerca.Controls.Add(Me.RadLabel21)
        Me.DocWinRicerca.Controls.Add(Me.RadLabel20)
        Me.DocWinRicerca.Controls.Add(Me.lista_Stati)
        Me.DocWinRicerca.Controls.Add(Me.RadLabel18)
        Me.DocWinRicerca.Controls.Add(Me.txtDesClienteRic)
        Me.DocWinRicerca.Controls.Add(Me.txtDesImpRic)
        Me.DocWinRicerca.Controls.Add(Me.txtDesTecRic)
        Me.DocWinRicerca.Controls.Add(Me.txtDesCentroRic)
        Me.DocWinRicerca.Controls.Add(Me.txtDesSocRic)
        Me.DocWinRicerca.Controls.Add(Me.txtCodTecRic)
        Me.DocWinRicerca.Controls.Add(Me.RadLabel16)
        Me.DocWinRicerca.Controls.Add(Me.txtAperturaAl)
        Me.DocWinRicerca.Controls.Add(Me.txtAperturaDal)
        Me.DocWinRicerca.Controls.Add(Me.RadLabel15)
        Me.DocWinRicerca.Controls.Add(Me.chkImpiantiFunz)
        Me.DocWinRicerca.Controls.Add(Me.chkImpiantiFermi)
        Me.DocWinRicerca.Controls.Add(Me.chkImpiantiDisdetti)
        Me.DocWinRicerca.Controls.Add(Me.chkChiamateReper)
        Me.DocWinRicerca.Controls.Add(Me.chkChiamateSabato)
        Me.DocWinRicerca.Controls.Add(Me.chkChiamateRep)
        Me.DocWinRicerca.Controls.Add(Me.chkImpiantiNonCritici)
        Me.DocWinRicerca.Controls.Add(Me.chkImpiantiCritici)
        Me.DocWinRicerca.Controls.Add(Me.txtCodImpRic)
        Me.DocWinRicerca.Controls.Add(Me.RadLabel13)
        Me.DocWinRicerca.Controls.Add(Me.txtCodCentroRic)
        Me.DocWinRicerca.Controls.Add(Me.txtCodSocRic)
        Me.DocWinRicerca.Controls.Add(Me.cmdSearchTec)
        Me.DocWinRicerca.Controls.Add(Me.cmdSearchImp)
        Me.DocWinRicerca.Controls.Add(Me.cmdSearchCen)
        Me.DocWinRicerca.Controls.Add(Me.cmdSearchSoc)
        Me.DocWinRicerca.Controls.Add(Me.Label3)
        Me.DocWinRicerca.Controls.Add(Me.txtCodClienteRic)
        Me.DocWinRicerca.Controls.Add(Me.cmdSearchCli)
        Me.DocWinRicerca.Controls.Add(Me.cmdFiltro)
        Me.DocWinRicerca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.DocWinRicerca.Image = CType(resources.GetObject("DocWinRicerca.Image"), System.Drawing.Image)
        Me.DocWinRicerca.Location = New System.Drawing.Point(5, 47)
        Me.DocWinRicerca.Name = "DocWinRicerca"
        Me.DocWinRicerca.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument
        Me.DocWinRicerca.Size = New System.Drawing.Size(889, 319)
        Me.DocWinRicerca.Text = "Ricerca Chiamate"
        '
        'RadButton2
        '
        Me.RadButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadButton2.Image = CType(resources.GetObject("RadButton2.Image"), System.Drawing.Image)
        Me.RadButton2.Location = New System.Drawing.Point(773, 229)
        Me.RadButton2.Name = "RadButton2"
        Me.RadButton2.Size = New System.Drawing.Size(81, 31)
        Me.RadButton2.TabIndex = 242
        Me.RadButton2.Text = "CERCA"
        Me.RadButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton2.ThemeName = "ThemeCmdRecubeYEL"
        '
        'RadLabel22
        '
        Me.RadLabel22.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel22.Location = New System.Drawing.Point(56, 24)
        Me.RadLabel22.Name = "RadLabel22"
        Me.RadLabel22.Size = New System.Drawing.Size(56, 21)
        Me.RadLabel22.TabIndex = 241
        Me.RadLabel22.Text = "Società"
        Me.RadLabel22.ThemeName = "MaterialTeal"
        '
        'RadLabel21
        '
        Me.RadLabel21.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel21.Location = New System.Drawing.Point(53, 93)
        Me.RadLabel21.Name = "RadLabel21"
        Me.RadLabel21.Size = New System.Drawing.Size(59, 21)
        Me.RadLabel21.TabIndex = 240
        Me.RadLabel21.Text = "Tecnico"
        Me.RadLabel21.ThemeName = "MaterialTeal"
        '
        'RadLabel20
        '
        Me.RadLabel20.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel20.Location = New System.Drawing.Point(62, 57)
        Me.RadLabel20.Name = "RadLabel20"
        Me.RadLabel20.Size = New System.Drawing.Size(50, 21)
        Me.RadLabel20.TabIndex = 239
        Me.RadLabel20.Text = "Centro"
        Me.RadLabel20.ThemeName = "MaterialTeal"
        '
        'lista_Stati
        '
        Me.lista_Stati.AllowColumnReorder = False
        Me.lista_Stati.AllowColumnResize = False
        Me.lista_Stati.AllowRemove = False
        ListViewDetailColumn1.HeaderText = "Mese apertura"
        ListViewDetailColumn1.MinWidth = 100.0!
        Me.lista_Stati.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn1})
        Me.lista_Stati.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lista_Stati.GroupItemSize = New System.Drawing.Size(200, 36)
        ListViewDataItemGroup1.Text = "ListViewGroup 1"
        Me.lista_Stati.Groups.AddRange(New Telerik.WinControls.UI.ListViewDataItemGroup() {ListViewDataItemGroup1})
        Me.lista_Stati.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysHide
        Me.lista_Stati.ItemSize = New System.Drawing.Size(200, 36)
        Me.lista_Stati.Location = New System.Drawing.Point(121, 195)
        Me.lista_Stati.MultiSelect = True
        Me.lista_Stati.Name = "lista_Stati"
        Me.lista_Stati.Size = New System.Drawing.Size(255, 118)
        Me.lista_Stati.TabIndex = 27
        Me.lista_Stati.ThemeName = "Office2013Dark"
        '
        'RadLabel18
        '
        Me.RadLabel18.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel18.Location = New System.Drawing.Point(7, 195)
        Me.RadLabel18.Name = "RadLabel18"
        Me.RadLabel18.Size = New System.Drawing.Size(105, 21)
        Me.RadLabel18.TabIndex = 238
        Me.RadLabel18.Text = "Stato chiamata"
        Me.RadLabel18.ThemeName = "MaterialTeal"
        '
        'txtDesClienteRic
        '
        Me.txtDesClienteRic.AutoSize = False
        Me.txtDesClienteRic.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtDesClienteRic.ForeColor = System.Drawing.Color.Black
        Me.txtDesClienteRic.Location = New System.Drawing.Point(446, 259)
        Me.txtDesClienteRic.MaxLength = 35
        Me.txtDesClienteRic.Name = "txtDesClienteRic"
        Me.txtDesClienteRic.ReadOnly = True
        Me.txtDesClienteRic.Size = New System.Drawing.Size(91, 30)
        Me.txtDesClienteRic.TabIndex = 236
        Me.txtDesClienteRic.TabStop = False
        Me.txtDesClienteRic.ThemeName = "Fluent"
        Me.txtDesClienteRic.Visible = False
        CType(Me.txtDesClienteRic.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'txtDesImpRic
        '
        Me.txtDesImpRic.AutoSize = False
        Me.txtDesImpRic.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtDesImpRic.ForeColor = System.Drawing.Color.Black
        Me.txtDesImpRic.Location = New System.Drawing.Point(231, 124)
        Me.txtDesImpRic.MaxLength = 35
        Me.txtDesImpRic.Name = "txtDesImpRic"
        Me.txtDesImpRic.ReadOnly = True
        Me.txtDesImpRic.Size = New System.Drawing.Size(332, 30)
        Me.txtDesImpRic.TabIndex = 235
        Me.txtDesImpRic.TabStop = False
        Me.txtDesImpRic.ThemeName = "Fluent"
        CType(Me.txtDesImpRic.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'txtDesTecRic
        '
        Me.txtDesTecRic.AutoSize = False
        Me.txtDesTecRic.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtDesTecRic.ForeColor = System.Drawing.Color.Black
        Me.txtDesTecRic.Location = New System.Drawing.Point(231, 89)
        Me.txtDesTecRic.MaxLength = 35
        Me.txtDesTecRic.Name = "txtDesTecRic"
        Me.txtDesTecRic.ReadOnly = True
        Me.txtDesTecRic.Size = New System.Drawing.Size(332, 30)
        Me.txtDesTecRic.TabIndex = 234
        Me.txtDesTecRic.TabStop = False
        Me.txtDesTecRic.ThemeName = "Fluent"
        CType(Me.txtDesTecRic.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'txtDesCentroRic
        '
        Me.txtDesCentroRic.AutoSize = False
        Me.txtDesCentroRic.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtDesCentroRic.ForeColor = System.Drawing.Color.Black
        Me.txtDesCentroRic.Location = New System.Drawing.Point(231, 54)
        Me.txtDesCentroRic.MaxLength = 35
        Me.txtDesCentroRic.Name = "txtDesCentroRic"
        Me.txtDesCentroRic.ReadOnly = True
        Me.txtDesCentroRic.Size = New System.Drawing.Size(332, 30)
        Me.txtDesCentroRic.TabIndex = 233
        Me.txtDesCentroRic.TabStop = False
        Me.txtDesCentroRic.ThemeName = "Fluent"
        CType(Me.txtDesCentroRic.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'txtDesSocRic
        '
        Me.txtDesSocRic.AutoSize = False
        Me.txtDesSocRic.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtDesSocRic.ForeColor = System.Drawing.Color.Black
        Me.txtDesSocRic.Location = New System.Drawing.Point(231, 19)
        Me.txtDesSocRic.MaxLength = 35
        Me.txtDesSocRic.Name = "txtDesSocRic"
        Me.txtDesSocRic.ReadOnly = True
        Me.txtDesSocRic.Size = New System.Drawing.Size(332, 30)
        Me.txtDesSocRic.TabIndex = 232
        Me.txtDesSocRic.TabStop = False
        Me.txtDesSocRic.ThemeName = "Fluent"
        CType(Me.txtDesSocRic.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'txtCodTecRic
        '
        Me.txtCodTecRic.AutoSize = False
        Me.txtCodTecRic.ForeColor = System.Drawing.Color.Black
        Me.txtCodTecRic.Location = New System.Drawing.Point(121, 89)
        Me.txtCodTecRic.MaxLength = 6
        Me.txtCodTecRic.Name = "txtCodTecRic"
        Me.txtCodTecRic.Size = New System.Drawing.Size(108, 30)
        Me.txtCodTecRic.TabIndex = 22
        Me.txtCodTecRic.ThemeName = "Fluent"
        CType(Me.txtCodTecRic.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtCodTecRic.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'RadLabel16
        '
        Me.RadLabel16.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel16.Location = New System.Drawing.Point(253, 164)
        Me.RadLabel16.Name = "RadLabel16"
        Me.RadLabel16.Size = New System.Drawing.Size(19, 21)
        Me.RadLabel16.TabIndex = 227
        Me.RadLabel16.Text = "al"
        Me.RadLabel16.ThemeName = "MaterialTeal"
        '
        'txtAperturaAl
        '
        Me.txtAperturaAl.AutoSize = False
        Me.txtAperturaAl.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtAperturaAl.ForeColor = System.Drawing.Color.Black
        Me.txtAperturaAl.Location = New System.Drawing.Point(273, 157)
        Me.txtAperturaAl.Mask = "00/00/0000"
        Me.txtAperturaAl.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.txtAperturaAl.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txtAperturaAl.Name = "txtAperturaAl"
        '
        '
        '
        Me.txtAperturaAl.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txtAperturaAl.Size = New System.Drawing.Size(104, 30)
        Me.txtAperturaAl.TabIndex = 26
        Me.txtAperturaAl.TabStop = False
        Me.txtAperturaAl.Text = "__/__/____"
        Me.txtAperturaAl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAperturaAl.ThemeName = "Fluent"
        CType(Me.txtAperturaAl.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = "__/__/____"
        CType(Me.txtAperturaAl.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'txtAperturaDal
        '
        Me.txtAperturaDal.AutoSize = False
        Me.txtAperturaDal.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtAperturaDal.ForeColor = System.Drawing.Color.Black
        Me.txtAperturaDal.Location = New System.Drawing.Point(121, 158)
        Me.txtAperturaDal.Mask = "00/00/0000"
        Me.txtAperturaDal.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.txtAperturaDal.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txtAperturaDal.Name = "txtAperturaDal"
        '
        '
        '
        Me.txtAperturaDal.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txtAperturaDal.Size = New System.Drawing.Size(108, 30)
        Me.txtAperturaDal.TabIndex = 25
        Me.txtAperturaDal.TabStop = False
        Me.txtAperturaDal.Text = "__/__/____"
        Me.txtAperturaDal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAperturaDal.ThemeName = "Fluent"
        CType(Me.txtAperturaDal.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = "__/__/____"
        CType(Me.txtAperturaDal.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'RadLabel15
        '
        Me.RadLabel15.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel15.Location = New System.Drawing.Point(25, 165)
        Me.RadLabel15.Name = "RadLabel15"
        Me.RadLabel15.Size = New System.Drawing.Size(87, 21)
        Me.RadLabel15.TabIndex = 226
        Me.RadLabel15.Text = "Apertura dal"
        Me.RadLabel15.ThemeName = "MaterialTeal"
        '
        'chkImpiantiFunz
        '
        Me.chkImpiantiFunz.ForeColor = System.Drawing.Color.DimGray
        Me.chkImpiantiFunz.Location = New System.Drawing.Point(614, 170)
        Me.chkImpiantiFunz.Name = "chkImpiantiFunz"
        Me.chkImpiantiFunz.Size = New System.Drawing.Size(153, 19)
        Me.chkImpiantiFunz.TabIndex = 34
        Me.chkImpiantiFunz.Text = "Impianti in funzione"
        Me.chkImpiantiFunz.ThemeName = "MaterialTeal"
        '
        'chkImpiantiFermi
        '
        Me.chkImpiantiFermi.ForeColor = System.Drawing.Color.DimGray
        Me.chkImpiantiFermi.Location = New System.Drawing.Point(614, 145)
        Me.chkImpiantiFermi.Name = "chkImpiantiFermi"
        Me.chkImpiantiFermi.Size = New System.Drawing.Size(116, 19)
        Me.chkImpiantiFermi.TabIndex = 33
        Me.chkImpiantiFermi.Text = "Impianti fermi"
        Me.chkImpiantiFermi.ThemeName = "MaterialTeal"
        '
        'chkImpiantiDisdetti
        '
        Me.chkImpiantiDisdetti.ForeColor = System.Drawing.Color.DimGray
        Me.chkImpiantiDisdetti.Location = New System.Drawing.Point(614, 196)
        Me.chkImpiantiDisdetti.Name = "chkImpiantiDisdetti"
        Me.chkImpiantiDisdetti.Size = New System.Drawing.Size(176, 19)
        Me.chkImpiantiDisdetti.TabIndex = 35
        Me.chkImpiantiDisdetti.Text = "Includi impianti disdetti"
        Me.chkImpiantiDisdetti.ThemeName = "MaterialTeal"
        '
        'chkChiamateReper
        '
        Me.chkChiamateReper.ForeColor = System.Drawing.Color.DimGray
        Me.chkChiamateReper.Location = New System.Drawing.Point(614, 120)
        Me.chkChiamateReper.Name = "chkChiamateReper"
        Me.chkChiamateReper.Size = New System.Drawing.Size(132, 19)
        Me.chkChiamateReper.TabIndex = 32
        Me.chkChiamateReper.Text = "Intrappolamento"
        Me.chkChiamateReper.ThemeName = "MaterialTeal"
        '
        'chkChiamateSabato
        '
        Me.chkChiamateSabato.ForeColor = System.Drawing.Color.DimGray
        Me.chkChiamateSabato.Location = New System.Drawing.Point(614, 95)
        Me.chkChiamateSabato.Name = "chkChiamateSabato"
        Me.chkChiamateSabato.Size = New System.Drawing.Size(262, 19)
        Me.chkChiamateSabato.TabIndex = 31
        Me.chkChiamateSabato.Text = "Reperibilità sabato prima delle 13:00"
        Me.chkChiamateSabato.ThemeName = "MaterialTeal"
        '
        'chkChiamateRep
        '
        Me.chkChiamateRep.ForeColor = System.Drawing.Color.DimGray
        Me.chkChiamateRep.Location = New System.Drawing.Point(614, 69)
        Me.chkChiamateRep.Name = "chkChiamateRep"
        Me.chkChiamateRep.Size = New System.Drawing.Size(175, 19)
        Me.chkChiamateRep.TabIndex = 30
        Me.chkChiamateRep.Text = "Chiamate in reperibilità"
        Me.chkChiamateRep.ThemeName = "MaterialTeal"
        '
        'chkImpiantiNonCritici
        '
        Me.chkImpiantiNonCritici.ForeColor = System.Drawing.Color.DimGray
        Me.chkImpiantiNonCritici.Location = New System.Drawing.Point(614, 44)
        Me.chkImpiantiNonCritici.Name = "chkImpiantiNonCritici"
        Me.chkImpiantiNonCritici.Size = New System.Drawing.Size(145, 19)
        Me.chkImpiantiNonCritici.TabIndex = 29
        Me.chkImpiantiNonCritici.Text = "Impianti non critici"
        Me.chkImpiantiNonCritici.ThemeName = "MaterialTeal"
        '
        'chkImpiantiCritici
        '
        Me.chkImpiantiCritici.ForeColor = System.Drawing.Color.DimGray
        Me.chkImpiantiCritici.Location = New System.Drawing.Point(614, 19)
        Me.chkImpiantiCritici.Name = "chkImpiantiCritici"
        Me.chkImpiantiCritici.Size = New System.Drawing.Size(117, 19)
        Me.chkImpiantiCritici.TabIndex = 28
        Me.chkImpiantiCritici.Text = "Impianti critici"
        Me.chkImpiantiCritici.ThemeName = "MaterialTeal"
        '
        'txtCodImpRic
        '
        Me.txtCodImpRic.AutoSize = False
        Me.txtCodImpRic.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtCodImpRic.ForeColor = System.Drawing.Color.Black
        Me.txtCodImpRic.Location = New System.Drawing.Point(121, 125)
        Me.txtCodImpRic.MaxLength = 35
        Me.txtCodImpRic.Name = "txtCodImpRic"
        Me.txtCodImpRic.ReadOnly = True
        Me.txtCodImpRic.Size = New System.Drawing.Size(108, 30)
        Me.txtCodImpRic.TabIndex = 23
        Me.txtCodImpRic.ThemeName = "Fluent"
        CType(Me.txtCodImpRic.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'RadLabel13
        '
        Me.RadLabel13.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel13.Location = New System.Drawing.Point(48, 131)
        Me.RadLabel13.Name = "RadLabel13"
        Me.RadLabel13.Size = New System.Drawing.Size(64, 21)
        Me.RadLabel13.TabIndex = 216
        Me.RadLabel13.Text = "Impianto"
        Me.RadLabel13.ThemeName = "MaterialTeal"
        '
        'txtCodCentroRic
        '
        Me.txtCodCentroRic.AutoSize = False
        Me.txtCodCentroRic.ForeColor = System.Drawing.Color.Black
        Me.txtCodCentroRic.Location = New System.Drawing.Point(121, 55)
        Me.txtCodCentroRic.MaxLength = 6
        Me.txtCodCentroRic.Name = "txtCodCentroRic"
        Me.txtCodCentroRic.Size = New System.Drawing.Size(108, 30)
        Me.txtCodCentroRic.TabIndex = 21
        Me.txtCodCentroRic.ThemeName = "Fluent"
        CType(Me.txtCodCentroRic.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtCodCentroRic.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'txtCodSocRic
        '
        Me.txtCodSocRic.AutoSize = False
        Me.txtCodSocRic.ForeColor = System.Drawing.Color.Black
        Me.txtCodSocRic.Location = New System.Drawing.Point(121, 19)
        Me.txtCodSocRic.MaxLength = 6
        Me.txtCodSocRic.Name = "txtCodSocRic"
        Me.txtCodSocRic.Size = New System.Drawing.Size(108, 30)
        Me.txtCodSocRic.TabIndex = 20
        Me.txtCodSocRic.ThemeName = "Fluent"
        CType(Me.txtCodSocRic.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtCodSocRic.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'cmdSearchTec
        '
        Me.cmdSearchTec.Image = CType(resources.GetObject("cmdSearchTec.Image"), System.Drawing.Image)
        Me.cmdSearchTec.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdSearchTec.Location = New System.Drawing.Point(567, 90)
        Me.cmdSearchTec.Name = "cmdSearchTec"
        Me.cmdSearchTec.Size = New System.Drawing.Size(28, 28)
        Me.cmdSearchTec.TabIndex = 230
        Me.cmdSearchTec.TabStop = False
        Me.cmdSearchTec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSearchTec.ThemeName = "ThemeCmdRecubeYEL"
        '
        'cmdSearchImp
        '
        Me.cmdSearchImp.Image = CType(resources.GetObject("cmdSearchImp.Image"), System.Drawing.Image)
        Me.cmdSearchImp.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdSearchImp.Location = New System.Drawing.Point(567, 126)
        Me.cmdSearchImp.Name = "cmdSearchImp"
        Me.cmdSearchImp.Size = New System.Drawing.Size(28, 28)
        Me.cmdSearchImp.TabIndex = 217
        Me.cmdSearchImp.TabStop = False
        Me.cmdSearchImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSearchImp.ThemeName = "ThemeCmdRecubeYEL"
        '
        'cmdSearchCen
        '
        Me.cmdSearchCen.Image = CType(resources.GetObject("cmdSearchCen.Image"), System.Drawing.Image)
        Me.cmdSearchCen.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdSearchCen.Location = New System.Drawing.Point(567, 56)
        Me.cmdSearchCen.Name = "cmdSearchCen"
        Me.cmdSearchCen.Size = New System.Drawing.Size(28, 28)
        Me.cmdSearchCen.TabIndex = 204
        Me.cmdSearchCen.TabStop = False
        Me.cmdSearchCen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSearchCen.ThemeName = "ThemeCmdRecubeYEL"
        '
        'cmdSearchSoc
        '
        Me.cmdSearchSoc.Image = CType(resources.GetObject("cmdSearchSoc.Image"), System.Drawing.Image)
        Me.cmdSearchSoc.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdSearchSoc.Location = New System.Drawing.Point(567, 20)
        Me.cmdSearchSoc.Name = "cmdSearchSoc"
        Me.cmdSearchSoc.Size = New System.Drawing.Size(28, 28)
        Me.cmdSearchSoc.TabIndex = 201
        Me.cmdSearchSoc.TabStop = False
        Me.cmdSearchSoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSearchSoc.ThemeName = "ThemeCmdRecubeYEL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(391, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 18)
        Me.Label3.TabIndex = 199
        Me.Label3.Text = "Cliente"
        Me.Label3.Visible = False
        '
        'txtCodClienteRic
        '
        Me.txtCodClienteRic.AutoSize = False
        Me.txtCodClienteRic.ForeColor = System.Drawing.Color.Black
        Me.txtCodClienteRic.Location = New System.Drawing.Point(446, 223)
        Me.txtCodClienteRic.MaxLength = 6
        Me.txtCodClienteRic.Name = "txtCodClienteRic"
        Me.txtCodClienteRic.Size = New System.Drawing.Size(91, 30)
        Me.txtCodClienteRic.TabIndex = 24
        Me.txtCodClienteRic.ThemeName = "Fluent"
        Me.txtCodClienteRic.Visible = False
        CType(Me.txtCodClienteRic.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtCodClienteRic.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'cmdSearchCli
        '
        Me.cmdSearchCli.Image = CType(resources.GetObject("cmdSearchCli.Image"), System.Drawing.Image)
        Me.cmdSearchCli.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdSearchCli.Location = New System.Drawing.Point(543, 225)
        Me.cmdSearchCli.Name = "cmdSearchCli"
        Me.cmdSearchCli.Size = New System.Drawing.Size(28, 28)
        Me.cmdSearchCli.TabIndex = 198
        Me.cmdSearchCli.TabStop = False
        Me.cmdSearchCli.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSearchCli.ThemeName = "ThemeCmdRecubeYEL"
        Me.cmdSearchCli.Visible = False
        '
        'cmdFiltro
        '
        Me.cmdFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFiltro.Image = CType(resources.GetObject("cmdFiltro.Image"), System.Drawing.Image)
        Me.cmdFiltro.Location = New System.Drawing.Point(772, 281)
        Me.cmdFiltro.Name = "cmdFiltro"
        Me.cmdFiltro.Size = New System.Drawing.Size(81, 31)
        Me.cmdFiltro.TabIndex = 36
        Me.cmdFiltro.Text = "CERCA"
        Me.cmdFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdFiltro.ThemeName = "ThemeCmdRecubeYEL"
        '
        'DocContainerUp
        '
        Me.DocContainerUp.CausesValidation = False
        Me.DocContainerUp.Controls.Add(Me.DocumentTabStrip4)
        Me.DocContainerUp.Controls.Add(Me.DocTabStripMappa)
        Me.DocContainerUp.Name = "DocContainerUp"
        '
        '
        '
        Me.DocContainerUp.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.DocContainerUp.SizeInfo.AbsoluteSize = New System.Drawing.Size(546, 373)
        Me.DocContainerUp.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill
        Me.DocContainerUp.SizeInfo.SplitterCorrection = New System.Drawing.Size(-552, -856)
        Me.DocContainerUp.SplitterWidth = 8
        Me.DocContainerUp.ThemeName = "Fluent"
        '
        'DocumentTabStrip4
        '
        Me.DocumentTabStrip4.CanUpdateChildIndex = True
        Me.DocumentTabStrip4.CausesValidation = False
        Me.DocumentTabStrip4.Controls.Add(Me.DocWinElenco)
        Me.DocumentTabStrip4.Controls.Add(Me.DocWinRicerca)
        Me.DocumentTabStrip4.Location = New System.Drawing.Point(0, 0)
        Me.DocumentTabStrip4.Name = "DocumentTabStrip4"
        '
        '
        '
        Me.DocumentTabStrip4.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.DocumentTabStrip4.SelectedIndex = 0
        Me.DocumentTabStrip4.Size = New System.Drawing.Size(926, 373)
        Me.DocumentTabStrip4.SizeInfo.AbsoluteSize = New System.Drawing.Size(200, 374)
        Me.DocumentTabStrip4.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.1052288!, 0!)
        Me.DocumentTabStrip4.SizeInfo.SplitterCorrection = New System.Drawing.Size(128, 174)
        Me.DocumentTabStrip4.TabIndex = 2
        Me.DocumentTabStrip4.TabStop = False
        Me.DocumentTabStrip4.ThemeName = "Fluent"
        '
        'DocWinElenco
        '
        Me.DocWinElenco.Controls.Add(Me.grid)
        Me.DocWinElenco.Controls.Add(Me.cmdBar)
        Me.DocWinElenco.DocumentButtons = Telerik.WinControls.UI.Docking.DocumentStripButtons.None
        Me.DocWinElenco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.DocWinElenco.ForeColor = System.Drawing.Color.Black
        Me.DocWinElenco.Image = CType(resources.GetObject("DocWinElenco.Image"), System.Drawing.Image)
        Me.DocWinElenco.Location = New System.Drawing.Point(5, 47)
        Me.DocWinElenco.Name = "DocWinElenco"
        Me.DocWinElenco.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument
        Me.DocWinElenco.Size = New System.Drawing.Size(914, 319)
        Me.DocWinElenco.Text = "Elenco Chiamate"
        '
        'grid
        '
        Me.grid.BackColor = System.Drawing.Color.White
        Me.grid.Controls.Add(Me.wb4)
        Me.grid.Controls.Add(Me.wb3)
        Me.grid.Controls.Add(Me.wb2)
        Me.grid.Controls.Add(Me.wb1)
        Me.grid.Controls.Add(Me.wb)
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grid.ForeColor = System.Drawing.Color.Black
        Me.grid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grid.Location = New System.Drawing.Point(0, 30)
        '
        '
        '
        Me.grid.MasterTemplate.AllowAddNewRow = False
        Me.grid.MasterTemplate.AllowColumnChooser = False
        Me.grid.MasterTemplate.AllowDeleteRow = False
        Me.grid.MasterTemplate.AllowDragToGroup = False
        Me.grid.MasterTemplate.AllowRowResize = False
        Me.grid.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.grid.Name = "grid"
        Me.grid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grid.ShowGroupPanel = False
        Me.grid.Size = New System.Drawing.Size(914, 289)
        Me.grid.TabIndex = 0
        Me.grid.ThemeName = "Office2013Dark"
        '
        'wb4
        '
        Me.wb4.AccessibleName = "d"
        Me.wb4.Location = New System.Drawing.Point(170, 150)
        Me.wb4.Name = "wb4"
        Me.wb4.Size = New System.Drawing.Size(130, 24)
        Me.wb4.TabIndex = 211
        Me.wb4.Text = "RadWaitingBar1"
        Me.wb4.ThemeName = "Fluent"
        Me.wb4.Visible = False
        Me.wb4.WaitingIndicators.Add(Me.DotsLineWaitingBarIndicatorElement4)
        Me.wb4.WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        Me.wb4.WaitingSpeed = 80
        Me.wb4.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsLine
        CType(Me.wb4.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        CType(Me.wb4.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingSpeed = 80
        CType(Me.wb4.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarContentElement).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsLine
        CType(Me.wb4.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).Dash = False
        '
        'DotsLineWaitingBarIndicatorElement4
        '
        Me.DotsLineWaitingBarIndicatorElement4.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsLineWaitingBarIndicatorElement4.Name = "DotsLineWaitingBarIndicatorElement4"
        Me.DotsLineWaitingBarIndicatorElement4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsLineWaitingBarIndicatorElement4.UseCompatibleTextRendering = False
        '
        'wb3
        '
        Me.wb3.AccessibleName = "d"
        Me.wb3.Location = New System.Drawing.Point(170, 120)
        Me.wb3.Name = "wb3"
        Me.wb3.Size = New System.Drawing.Size(130, 24)
        Me.wb3.TabIndex = 210
        Me.wb3.Text = "RadWaitingBar1"
        Me.wb3.ThemeName = "Fluent"
        Me.wb3.Visible = False
        Me.wb3.WaitingIndicators.Add(Me.DotsLineWaitingBarIndicatorElement3)
        Me.wb3.WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        Me.wb3.WaitingSpeed = 80
        Me.wb3.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsLine
        CType(Me.wb3.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        CType(Me.wb3.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingSpeed = 80
        CType(Me.wb3.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarContentElement).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsLine
        CType(Me.wb3.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).Dash = False
        '
        'DotsLineWaitingBarIndicatorElement3
        '
        Me.DotsLineWaitingBarIndicatorElement3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsLineWaitingBarIndicatorElement3.Name = "DotsLineWaitingBarIndicatorElement3"
        Me.DotsLineWaitingBarIndicatorElement3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsLineWaitingBarIndicatorElement3.UseCompatibleTextRendering = False
        '
        'wb2
        '
        Me.wb2.AccessibleName = "d"
        Me.wb2.Location = New System.Drawing.Point(170, 90)
        Me.wb2.Name = "wb2"
        Me.wb2.Size = New System.Drawing.Size(130, 24)
        Me.wb2.TabIndex = 209
        Me.wb2.Text = "RadWaitingBar1"
        Me.wb2.ThemeName = "Fluent"
        Me.wb2.Visible = False
        Me.wb2.WaitingIndicators.Add(Me.DotsLineWaitingBarIndicatorElement2)
        Me.wb2.WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        Me.wb2.WaitingSpeed = 80
        Me.wb2.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsLine
        CType(Me.wb2.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        CType(Me.wb2.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingSpeed = 80
        CType(Me.wb2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarContentElement).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsLine
        CType(Me.wb2.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).Dash = False
        '
        'DotsLineWaitingBarIndicatorElement2
        '
        Me.DotsLineWaitingBarIndicatorElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsLineWaitingBarIndicatorElement2.Name = "DotsLineWaitingBarIndicatorElement2"
        Me.DotsLineWaitingBarIndicatorElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsLineWaitingBarIndicatorElement2.UseCompatibleTextRendering = False
        '
        'wb1
        '
        Me.wb1.AccessibleName = "d"
        Me.wb1.Location = New System.Drawing.Point(170, 60)
        Me.wb1.Name = "wb1"
        Me.wb1.Size = New System.Drawing.Size(130, 24)
        Me.wb1.TabIndex = 208
        Me.wb1.Text = "RadWaitingBar1"
        Me.wb1.ThemeName = "Fluent"
        Me.wb1.Visible = False
        Me.wb1.WaitingIndicators.Add(Me.DotsLineWaitingBarIndicatorElement1)
        Me.wb1.WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        Me.wb1.WaitingSpeed = 80
        Me.wb1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsLine
        CType(Me.wb1.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        CType(Me.wb1.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingSpeed = 80
        CType(Me.wb1.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarContentElement).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsLine
        CType(Me.wb1.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).Dash = False
        '
        'DotsLineWaitingBarIndicatorElement1
        '
        Me.DotsLineWaitingBarIndicatorElement1.Name = "DotsLineWaitingBarIndicatorElement1"
        '
        'wb
        '
        Me.wb.AccessibleName = "d"
        Me.wb.Location = New System.Drawing.Point(372, 103)
        Me.wb.Name = "wb"
        Me.wb.Size = New System.Drawing.Size(70, 70)
        Me.wb.TabIndex = 207
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
        'cmdBar
        '
        Me.cmdBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmdBar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmdBar.Location = New System.Drawing.Point(0, 0)
        Me.cmdBar.Name = "cmdBar"
        Me.cmdBar.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement1})
        Me.cmdBar.Size = New System.Drawing.Size(914, 30)
        Me.cmdBar.TabIndex = 245
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
        Me.CommandBarStripE1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.cmdInserisci, Me.cmdModChiam, Me.cmdDelChiam})
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
        Me.cmdInserisci.Text = "Inserisci"
        Me.cmdInserisci.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdInserisci.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdInserisci.UseCompatibleTextRendering = False
        '
        'cmdModChiam
        '
        Me.cmdModChiam.DisplayName = "CommandBarButton2"
        Me.cmdModChiam.DrawText = True
        Me.cmdModChiam.Image = CType(resources.GetObject("cmdModChiam.Image"), System.Drawing.Image)
        Me.cmdModChiam.Name = "cmdModChiam"
        Me.cmdModChiam.Text = "Modifica"
        Me.cmdModChiam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'cmdDelChiam
        '
        Me.cmdDelChiam.DisplayName = "CommandBarButton1"
        Me.cmdDelChiam.DrawText = True
        Me.cmdDelChiam.Image = CType(resources.GetObject("cmdDelChiam.Image"), System.Drawing.Image)
        Me.cmdDelChiam.Name = "cmdDelChiam"
        Me.cmdDelChiam.Text = "Elimina"
        Me.cmdDelChiam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'DocTabStripMappa
        '
        Me.DocTabStripMappa.CanUpdateChildIndex = True
        Me.DocTabStripMappa.CausesValidation = False
        Me.DocTabStripMappa.Controls.Add(Me.ToolWinMap)
        Me.DocTabStripMappa.Location = New System.Drawing.Point(934, 0)
        Me.DocTabStripMappa.Name = "DocTabStripMappa"
        '
        '
        '
        Me.DocTabStripMappa.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.DocTabStripMappa.SelectedIndex = 0
        Me.DocTabStripMappa.Size = New System.Drawing.Size(604, 373)
        Me.DocTabStripMappa.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(-0.1052288!, 0!)
        Me.DocTabStripMappa.SizeInfo.SplitterCorrection = New System.Drawing.Size(-257, 0)
        Me.DocTabStripMappa.TabIndex = 1
        Me.DocTabStripMappa.TabStop = False
        Me.DocTabStripMappa.ThemeName = "Fluent"
        '
        'ToolWinMap
        '
        Me.ToolWinMap.Caption = Nothing
        Me.ToolWinMap.Controls.Add(Me.map)
        Me.ToolWinMap.Controls.Add(Me.RadCommandBar1)
        Me.ToolWinMap.DocumentButtons = Telerik.WinControls.UI.Docking.DocumentStripButtons.None
        Me.ToolWinMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ToolWinMap.Image = CType(resources.GetObject("ToolWinMap.Image"), System.Drawing.Image)
        Me.ToolWinMap.Location = New System.Drawing.Point(5, 47)
        Me.ToolWinMap.Name = "ToolWinMap"
        Me.ToolWinMap.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Floating
        Me.ToolWinMap.Size = New System.Drawing.Size(592, 319)
        Me.ToolWinMap.Text = "MAPPA"
        Me.ToolWinMap.ToolCaptionButtons = Telerik.WinControls.UI.Docking.ToolStripCaptionButtons.None
        '
        'map
        '
        Me.map.Dock = System.Windows.Forms.DockStyle.Fill
        Me.map.Location = New System.Drawing.Point(36, 0)
        Me.map.Name = "map"
        Me.map.ShowLegend = False
        Me.map.ShowMiniMap = False
        Me.map.ShowNavigationBar = False
        Me.map.ShowScaleIndicator = False
        Me.map.ShowSearchBar = False
        Me.map.Size = New System.Drawing.Size(556, 319)
        Me.map.TabIndex = 1
        Me.map.ThemeName = "Fluent"
        '
        'RadCommandBar1
        '
        Me.RadCommandBar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.RadCommandBar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RadCommandBar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.RadCommandBar1.Name = "RadCommandBar1"
        Me.RadCommandBar1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.RadCommandBar1.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement2})
        Me.RadCommandBar1.Size = New System.Drawing.Size(36, 319)
        Me.RadCommandBar1.TabIndex = 246
        Me.RadCommandBar1.ThemeName = "Crystal"
        '
        'CommandBarRowElement2
        '
        Me.CommandBarRowElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarRowElement2.MinSize = New System.Drawing.Size(25, 25)
        Me.CommandBarRowElement2.Name = "CommandBarRowElement1"
        Me.CommandBarRowElement2.Strips.AddRange(New Telerik.WinControls.UI.CommandBarStripElement() {Me.cmdBarStripE1mappa})
        Me.CommandBarRowElement2.Text = ""
        Me.CommandBarRowElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.CommandBarRowElement2.UseCompatibleTextRendering = False
        '
        'cmdBarStripE1mappa
        '
        Me.cmdBarStripE1mappa.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBarStripE1mappa.DisplayName = "CommandBarStripElement1"
        Me.cmdBarStripE1mappa.GradientAngle = 3060.0!
        '
        '
        '
        Me.cmdBarStripE1mappa.Grip.AngleTransform = 90.0!
        Me.cmdBarStripE1mappa.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.cmdBcaricaTecnici, Me.cmdBCaricaLimit, Me.cmdBFocusTec, Me.cmdBFocusImp})
        Me.cmdBarStripE1mappa.Name = "cmdBarStripE1mappa"
        '
        '
        '
        Me.cmdBarStripE1mappa.OverflowButton.AngleTransform = 90.0!
        Me.cmdBarStripE1mappa.StretchHorizontally = False
        Me.cmdBarStripE1mappa.StretchVertically = False
        Me.cmdBarStripE1mappa.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBarStripE1mappa.UseCompatibleTextRendering = False
        CType(Me.cmdBarStripE1mappa.GetChildAt(0), Telerik.WinControls.UI.RadCommandBarGrip).AngleTransform = 90.0!
        CType(Me.cmdBarStripE1mappa.GetChildAt(2), Telerik.WinControls.UI.RadCommandBarOverflowButton).AngleTransform = 90.0!
        '
        'cmdBcaricaTecnici
        '
        Me.cmdBcaricaTecnici.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBcaricaTecnici.DisplayName = "CommandBarButton1"
        Me.cmdBcaricaTecnici.DrawText = False
        Me.cmdBcaricaTecnici.Image = CType(resources.GetObject("cmdBcaricaTecnici.Image"), System.Drawing.Image)
        Me.cmdBcaricaTecnici.Name = "cmdBcaricaTecnici"
        Me.cmdBcaricaTecnici.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.cmdBcaricaTecnici.Text = "Inserisci"
        Me.cmdBcaricaTecnici.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdBcaricaTecnici.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBcaricaTecnici.ToolTipText = "Carica tecnici sulla mappa"
        Me.cmdBcaricaTecnici.UseCompatibleTextRendering = False
        '
        'cmdBCaricaLimit
        '
        Me.cmdBCaricaLimit.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBCaricaLimit.DisplayName = "CommandBarButton2"
        Me.cmdBCaricaLimit.DrawText = False
        Me.cmdBCaricaLimit.Image = CType(resources.GetObject("cmdBCaricaLimit.Image"), System.Drawing.Image)
        Me.cmdBCaricaLimit.Name = "cmdBCaricaLimit"
        Me.cmdBCaricaLimit.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.cmdBCaricaLimit.Text = "Modifica"
        Me.cmdBCaricaLimit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdBCaricaLimit.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBCaricaLimit.ToolTipText = "Carica tecnici nel raggio di 10 km"
        Me.cmdBCaricaLimit.UseCompatibleTextRendering = False
        '
        'cmdBFocusTec
        '
        Me.cmdBFocusTec.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBFocusTec.DisplayName = "CommandBarButton1"
        Me.cmdBFocusTec.DrawText = False
        Me.cmdBFocusTec.Image = CType(resources.GetObject("cmdBFocusTec.Image"), System.Drawing.Image)
        Me.cmdBFocusTec.Name = "cmdBFocusTec"
        Me.cmdBFocusTec.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.cmdBFocusTec.Text = "Elimina"
        Me.cmdBFocusTec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdBFocusTec.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.cmdBFocusTec.ToolTipText = "diminuisci"
        Me.cmdBFocusTec.UseCompatibleTextRendering = False
        '
        'cmdBFocusImp
        '
        Me.cmdBFocusImp.DisplayName = "CommandBarButton1"
        Me.cmdBFocusImp.Image = CType(resources.GetObject("cmdBFocusImp.Image"), System.Drawing.Image)
        Me.cmdBFocusImp.Name = "cmdBFocusImp"
        Me.cmdBFocusImp.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.cmdBFocusImp.Text = "CommandBarButton1"
        '
        'ToolTabStrip1
        '
        Me.ToolTabStrip1.CanUpdateChildIndex = True
        Me.ToolTabStrip1.Controls.Add(Me.ToolWinChiamata)
        Me.ToolTabStrip1.Location = New System.Drawing.Point(0, 381)
        Me.ToolTabStrip1.Name = "ToolTabStrip1"
        '
        '
        '
        Me.ToolTabStrip1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.ToolTabStrip1.SelectedIndex = 0
        Me.ToolTabStrip1.Size = New System.Drawing.Size(1538, 446)
        Me.ToolTabStrip1.SizeInfo.AbsoluteSize = New System.Drawing.Size(200, 446)
        Me.ToolTabStrip1.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.1543847!, 0!)
        Me.ToolTabStrip1.SizeInfo.SplitterCorrection = New System.Drawing.Size(203, 246)
        Me.ToolTabStrip1.TabIndex = 3
        Me.ToolTabStrip1.TabStop = False
        Me.ToolTabStrip1.ThemeName = "Fluent"
        '
        'ToolWinChiamata
        '
        Me.ToolWinChiamata.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolWinChiamata.Caption = Nothing
        Me.ToolWinChiamata.Controls.Add(Me.RadButton1)
        Me.ToolWinChiamata.Controls.Add(Me.cmdAnnulla)
        Me.ToolWinChiamata.Controls.Add(Me.cmdConferma)
        Me.ToolWinChiamata.Controls.Add(Me.groupImpianto)
        Me.ToolWinChiamata.Controls.Add(Me.groupInfo)
        Me.ToolWinChiamata.Controls.Add(Me.groupChiamata)
        Me.ToolWinChiamata.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ToolWinChiamata.Location = New System.Drawing.Point(4, 34)
        Me.ToolWinChiamata.Name = "ToolWinChiamata"
        Me.ToolWinChiamata.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked
        Me.ToolWinChiamata.Size = New System.Drawing.Size(1530, 408)
        Me.ToolWinChiamata.Text = "DETTAGLIO CHIAMATA"
        Me.ToolWinChiamata.ToolCaptionButtons = Telerik.WinControls.UI.Docking.ToolStripCaptionButtons.AutoHide
        '
        'RadButton1
        '
        Me.RadButton1.Location = New System.Drawing.Point(810, 377)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(117, 29)
        Me.RadButton1.TabIndex = 216
        Me.RadButton1.Text = "test"
        Me.RadButton1.ThemeName = "VisualStudio2012Light"
        Me.RadButton1.Visible = False
        '
        'cmdAnnulla
        '
        Me.cmdAnnulla.Location = New System.Drawing.Point(1259, 374)
        Me.cmdAnnulla.Name = "cmdAnnulla"
        Me.cmdAnnulla.Size = New System.Drawing.Size(117, 29)
        Me.cmdAnnulla.TabIndex = 18
        Me.cmdAnnulla.Text = "Annulla"
        Me.cmdAnnulla.ThemeName = "VisualStudio2012Light"
        '
        'cmdConferma
        '
        Me.cmdConferma.Location = New System.Drawing.Point(1392, 374)
        Me.cmdConferma.Name = "cmdConferma"
        Me.cmdConferma.Size = New System.Drawing.Size(117, 29)
        Me.cmdConferma.TabIndex = 19
        Me.cmdConferma.Text = "Salva"
        Me.cmdConferma.ThemeName = "VisualStudio2012Light"
        '
        'groupImpianto
        '
        Me.groupImpianto.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.groupImpianto.Controls.Add(Me.txtTipoImp)
        Me.groupImpianto.Controls.Add(Me.cmbCentri)
        Me.groupImpianto.Controls.Add(Me.RadLabel12)
        Me.groupImpianto.Controls.Add(Me.RadLabel11)
        Me.groupImpianto.Controls.Add(Me.txtLocalita)
        Me.groupImpianto.Controls.Add(Me.TxtCodice)
        Me.groupImpianto.Controls.Add(Me.cmbSocieta)
        Me.groupImpianto.Controls.Add(Me.RadLabel10)
        Me.groupImpianto.Controls.Add(Me.RadLabel3)
        Me.groupImpianto.Controls.Add(Me.RadLabel9)
        Me.groupImpianto.Controls.Add(Me.RadLabel17)
        Me.groupImpianto.Controls.Add(Me.txtIndirizzo)
        Me.groupImpianto.Controls.Add(Me.cmdOkSearchImp)
        Me.groupImpianto.Controls.Add(Me.RadLabel14)
        Me.groupImpianto.Controls.Add(Me.RadLabel1)
        Me.groupImpianto.Controls.Add(Me.txtCap)
        Me.groupImpianto.Controls.Add(Me.txtProv)
        Me.groupImpianto.HeaderImage = CType(resources.GetObject("groupImpianto.HeaderImage"), System.Drawing.Image)
        Me.groupImpianto.HeaderMargin = New System.Windows.Forms.Padding(1)
        Me.groupImpianto.HeaderText = "DATI IMPIANTO"
        Me.groupImpianto.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.groupImpianto.HeaderTextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.groupImpianto.Location = New System.Drawing.Point(14, 22)
        Me.groupImpianto.Name = "groupImpianto"
        Me.groupImpianto.Size = New System.Drawing.Size(444, 341)
        Me.groupImpianto.TabIndex = 215
        Me.groupImpianto.Text = "DATI IMPIANTO"
        Me.groupImpianto.ThemeName = "MaterialBlueGrey"
        '
        'txtTipoImp
        '
        Me.txtTipoImp.AutoSize = False
        Me.txtTipoImp.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtTipoImp.ForeColor = System.Drawing.Color.Black
        Me.txtTipoImp.Location = New System.Drawing.Point(84, 150)
        Me.txtTipoImp.MaxLength = 35
        Me.txtTipoImp.Name = "txtTipoImp"
        Me.txtTipoImp.ReadOnly = True
        Me.txtTipoImp.Size = New System.Drawing.Size(346, 30)
        Me.txtTipoImp.TabIndex = 219
        Me.txtTipoImp.TabStop = False
        Me.txtTipoImp.ThemeName = "Fluent"
        CType(Me.txtTipoImp.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'cmbCentri
        '
        Me.cmbCentri.AutoSize = False
        '
        'cmbCentri.NestedRadGridView
        '
        Me.cmbCentri.EditorControl.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCentri.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentri.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbCentri.EditorControl.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.cmbCentri.EditorControl.MasterTemplate.AllowAddNewRow = False
        Me.cmbCentri.EditorControl.MasterTemplate.AllowCellContextMenu = False
        Me.cmbCentri.EditorControl.MasterTemplate.AllowColumnChooser = False
        Me.cmbCentri.EditorControl.MasterTemplate.EnableGrouping = False
        Me.cmbCentri.EditorControl.MasterTemplate.ShowFilteringRow = False
        Me.cmbCentri.EditorControl.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.cmbCentri.EditorControl.Name = "NestedRadGridView"
        Me.cmbCentri.EditorControl.ReadOnly = True
        Me.cmbCentri.EditorControl.ShowGroupPanel = False
        Me.cmbCentri.EditorControl.Size = New System.Drawing.Size(240, 150)
        Me.cmbCentri.EditorControl.TabIndex = 0
        Me.cmbCentri.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cmbCentri.ForeColor = System.Drawing.Color.Black
        Me.cmbCentri.Location = New System.Drawing.Point(84, 80)
        Me.cmbCentri.Name = "cmbCentri"
        Me.cmbCentri.NullText = "Centro"
        Me.cmbCentri.Size = New System.Drawing.Size(347, 30)
        Me.cmbCentri.TabIndex = 1
        Me.cmbCentri.TabStop = False
        Me.cmbCentri.ThemeName = "Fluent"
        '
        'RadLabel12
        '
        Me.RadLabel12.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel12.Location = New System.Drawing.Point(190, 259)
        Me.RadLabel12.Name = "RadLabel12"
        Me.RadLabel12.Size = New System.Drawing.Size(41, 21)
        Me.RadLabel12.TabIndex = 217
        Me.RadLabel12.Text = "Prov."
        Me.RadLabel12.ThemeName = "MaterialTeal"
        '
        'RadLabel11
        '
        Me.RadLabel11.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel11.Location = New System.Drawing.Point(15, 259)
        Me.RadLabel11.Name = "RadLabel11"
        Me.RadLabel11.Size = New System.Drawing.Size(35, 21)
        Me.RadLabel11.TabIndex = 6
        Me.RadLabel11.Text = "CAP"
        Me.RadLabel11.ThemeName = "MaterialTeal"
        '
        'txtLocalita
        '
        Me.txtLocalita.AutoSize = False
        Me.txtLocalita.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtLocalita.ForeColor = System.Drawing.Color.Black
        Me.txtLocalita.Location = New System.Drawing.Point(84, 220)
        Me.txtLocalita.MaxLength = 35
        Me.txtLocalita.Name = "txtLocalita"
        Me.txtLocalita.ReadOnly = True
        Me.txtLocalita.Size = New System.Drawing.Size(346, 30)
        Me.txtLocalita.TabIndex = 216
        Me.txtLocalita.TabStop = False
        Me.txtLocalita.ThemeName = "Fluent"
        CType(Me.txtLocalita.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'TxtCodice
        '
        Me.TxtCodice.AutoSize = False
        Me.TxtCodice.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.TxtCodice.ForeColor = System.Drawing.Color.Black
        Me.TxtCodice.Location = New System.Drawing.Point(84, 115)
        Me.TxtCodice.MaxLength = 35
        Me.TxtCodice.Name = "TxtCodice"
        Me.TxtCodice.ReadOnly = True
        Me.TxtCodice.Size = New System.Drawing.Size(112, 30)
        Me.TxtCodice.TabIndex = 2
        Me.TxtCodice.ThemeName = "Fluent"
        CType(Me.TxtCodice.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'cmbSocieta
        '
        Me.cmbSocieta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbSocieta.AutoSize = False
        Me.cmbSocieta.ForeColor = System.Drawing.Color.Black
        Me.cmbSocieta.Location = New System.Drawing.Point(85, 45)
        Me.cmbSocieta.Name = "cmbSocieta"
        Me.cmbSocieta.NullText = "Seleziona un valore"
        Me.cmbSocieta.Size = New System.Drawing.Size(346, 30)
        Me.cmbSocieta.TabIndex = 0
        Me.cmbSocieta.ThemeName = "Fluent"
        CType(Me.cmbSocieta.GetChildAt(0), Telerik.WinControls.UI.RadDropDownListElement).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'RadLabel10
        '
        Me.RadLabel10.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel10.Location = New System.Drawing.Point(15, 87)
        Me.RadLabel10.Name = "RadLabel10"
        Me.RadLabel10.Size = New System.Drawing.Size(50, 21)
        Me.RadLabel10.TabIndex = 214
        Me.RadLabel10.Text = "Centro"
        Me.RadLabel10.ThemeName = "MaterialTeal"
        '
        'RadLabel3
        '
        Me.RadLabel3.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel3.Location = New System.Drawing.Point(14, 190)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(63, 21)
        Me.RadLabel3.TabIndex = 4
        Me.RadLabel3.Text = "Indirizzo"
        Me.RadLabel3.ThemeName = "MaterialTeal"
        '
        'RadLabel9
        '
        Me.RadLabel9.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel9.Location = New System.Drawing.Point(15, 51)
        Me.RadLabel9.Name = "RadLabel9"
        Me.RadLabel9.Size = New System.Drawing.Size(56, 21)
        Me.RadLabel9.TabIndex = 212
        Me.RadLabel9.Text = "Società"
        Me.RadLabel9.ThemeName = "MaterialTeal"
        '
        'RadLabel17
        '
        Me.RadLabel17.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel17.Location = New System.Drawing.Point(13, 155)
        Me.RadLabel17.Name = "RadLabel17"
        Me.RadLabel17.Size = New System.Drawing.Size(68, 21)
        Me.RadLabel17.TabIndex = 187
        Me.RadLabel17.Text = "Tipo Imp."
        Me.RadLabel17.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel17.ThemeName = "MaterialTeal"
        '
        'txtIndirizzo
        '
        Me.txtIndirizzo.AutoSize = False
        Me.txtIndirizzo.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtIndirizzo.ForeColor = System.Drawing.Color.Black
        Me.txtIndirizzo.Location = New System.Drawing.Point(84, 185)
        Me.txtIndirizzo.MaxLength = 35
        Me.txtIndirizzo.Name = "txtIndirizzo"
        Me.txtIndirizzo.ReadOnly = True
        Me.txtIndirizzo.Size = New System.Drawing.Size(346, 30)
        Me.txtIndirizzo.TabIndex = 4
        Me.txtIndirizzo.ThemeName = "Fluent"
        CType(Me.txtIndirizzo.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'cmdOkSearchImp
        '
        Me.cmdOkSearchImp.Image = CType(resources.GetObject("cmdOkSearchImp.Image"), System.Drawing.Image)
        Me.cmdOkSearchImp.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdOkSearchImp.Location = New System.Drawing.Point(199, 116)
        Me.cmdOkSearchImp.Name = "cmdOkSearchImp"
        Me.cmdOkSearchImp.Size = New System.Drawing.Size(28, 28)
        Me.cmdOkSearchImp.TabIndex = 208
        Me.cmdOkSearchImp.TabStop = False
        Me.cmdOkSearchImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdOkSearchImp.ThemeName = "ThemeCmdRecubeYEL"
        '
        'RadLabel14
        '
        Me.RadLabel14.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel14.Location = New System.Drawing.Point(15, 227)
        Me.RadLabel14.Name = "RadLabel14"
        Me.RadLabel14.Size = New System.Drawing.Size(58, 21)
        Me.RadLabel14.TabIndex = 5
        Me.RadLabel14.Text = "Località"
        Me.RadLabel14.ThemeName = "MaterialTeal"
        '
        'RadLabel1
        '
        Me.RadLabel1.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel1.Location = New System.Drawing.Point(15, 121)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(64, 21)
        Me.RadLabel1.TabIndex = 2
        Me.RadLabel1.Text = "Impianto"
        Me.RadLabel1.ThemeName = "MaterialTeal"
        '
        'txtCap
        '
        Me.txtCap.AutoSize = False
        Me.txtCap.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCap.ForeColor = System.Drawing.Color.Black
        Me.txtCap.Location = New System.Drawing.Point(84, 254)
        Me.txtCap.Mask = "d5"
        Me.txtCap.MaskType = Telerik.WinControls.UI.MaskType.Numeric
        Me.txtCap.Name = "txtCap"
        Me.txtCap.ReadOnly = True
        Me.txtCap.Size = New System.Drawing.Size(79, 30)
        Me.txtCap.TabIndex = 6
        Me.txtCap.TabStop = False
        Me.txtCap.Text = "00000"
        Me.txtCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCap.ThemeName = "Fluent"
        CType(Me.txtCap.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = "00000"
        CType(Me.txtCap.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).NullText = ""
        CType(Me.txtCap.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'txtProv
        '
        Me.txtProv.AutoSize = False
        Me.txtProv.ForeColor = System.Drawing.Color.Black
        Me.txtProv.Location = New System.Drawing.Point(231, 254)
        Me.txtProv.MaxLength = 2
        Me.txtProv.Name = "txtProv"
        Me.txtProv.ReadOnly = True
        Me.txtProv.Size = New System.Drawing.Size(44, 30)
        Me.txtProv.TabIndex = 7
        Me.txtProv.TabStop = False
        Me.txtProv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtProv.ThemeName = "Fluent"
        CType(Me.txtProv.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).NullText = ""
        CType(Me.txtProv.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        CType(Me.txtProv.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'groupInfo
        '
        Me.groupInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.groupInfo.Controls.Add(Me.imgTel)
        Me.groupInfo.Controls.Add(Me.RadGroupBox1)
        Me.groupInfo.Controls.Add(Me.listStati)
        Me.groupInfo.Controls.Add(Me.RadLabel24)
        Me.groupInfo.Controls.Add(Me.txtRiscontro)
        Me.groupInfo.Controls.Add(Me.cmbTecnico)
        Me.groupInfo.Controls.Add(Me.cmbStatoChiamata)
        Me.groupInfo.Controls.Add(Me.RadLabel6)
        Me.groupInfo.Controls.Add(Me.RadLabel19)
        Me.groupInfo.Controls.Add(Me.txtDataAssegn)
        Me.groupInfo.Controls.Add(Me.RadLabel8)
        Me.groupInfo.Controls.Add(Me.txtOraAss)
        Me.groupInfo.HeaderImage = CType(resources.GetObject("groupInfo.HeaderImage"), System.Drawing.Image)
        Me.groupInfo.HeaderMargin = New System.Windows.Forms.Padding(1)
        Me.groupInfo.HeaderText = "INFO CHIAMATA"
        Me.groupInfo.HeaderTextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.groupInfo.Location = New System.Drawing.Point(907, 22)
        Me.groupInfo.Name = "groupInfo"
        Me.groupInfo.Size = New System.Drawing.Size(602, 341)
        Me.groupInfo.TabIndex = 210
        Me.groupInfo.Text = "INFO CHIAMATA"
        Me.groupInfo.ThemeName = "MaterialBlueGrey"
        '
        'imgTel
        '
        Me.imgTel.BackColor = System.Drawing.Color.Transparent
        Me.imgTel.Location = New System.Drawing.Point(340, 44)
        Me.imgTel.Name = "imgTel"
        Me.imgTel.Size = New System.Drawing.Size(24, 24)
        Me.imgTel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.imgTel.TabIndex = 197
        Me.imgTel.TabStop = False
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.RadLabel27)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel25)
        Me.RadGroupBox1.Controls.Add(Me.optAPE)
        Me.RadGroupBox1.Controls.Add(Me.optCHI)
        Me.RadGroupBox1.Controls.Add(Me.optASS)
        Me.RadGroupBox1.Controls.Add(Me.optSOS)
        Me.RadGroupBox1.Controls.Add(Me.optLAV)
        Me.RadGroupBox1.Controls.Add(Me.txtDataStato)
        Me.RadGroupBox1.Controls.Add(Me.txtOraStato)
        Me.RadGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.RadGroupBox1.HeaderText = "Stato della chiamata"
        Me.RadGroupBox1.Location = New System.Drawing.Point(92, 80)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(268, 137)
        Me.RadGroupBox1.TabIndex = 196
        Me.RadGroupBox1.Text = "Stato della chiamata"
        Me.RadGroupBox1.ThemeName = "Office2013Dark"
        '
        'RadLabel27
        '
        Me.RadLabel27.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel27.Location = New System.Drawing.Point(153, 75)
        Me.RadLabel27.Name = "RadLabel27"
        Me.RadLabel27.Size = New System.Drawing.Size(30, 21)
        Me.RadLabel27.TabIndex = 184
        Me.RadLabel27.Text = "Ora"
        Me.RadLabel27.ThemeName = "MaterialTeal"
        '
        'RadLabel25
        '
        Me.RadLabel25.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel25.Location = New System.Drawing.Point(152, 22)
        Me.RadLabel25.Name = "RadLabel25"
        Me.RadLabel25.Size = New System.Drawing.Size(37, 21)
        Me.RadLabel25.TabIndex = 183
        Me.RadLabel25.Text = "Data"
        Me.RadLabel25.ThemeName = "MaterialTeal"
        '
        'optAPE
        '
        Me.optAPE.Location = New System.Drawing.Point(19, 32)
        Me.optAPE.Name = "optAPE"
        Me.optAPE.Size = New System.Drawing.Size(61, 18)
        Me.optAPE.TabIndex = 186
        Me.optAPE.Text = "APERTA"
        Me.optAPE.ThemeName = "Fluent"
        '
        'optCHI
        '
        Me.optCHI.Location = New System.Drawing.Point(19, 112)
        Me.optCHI.Name = "optCHI"
        Me.optCHI.Size = New System.Drawing.Size(60, 18)
        Me.optCHI.TabIndex = 190
        Me.optCHI.Text = "CHIUSA"
        Me.optCHI.ThemeName = "Fluent"
        '
        'optASS
        '
        Me.optASS.Location = New System.Drawing.Point(19, 52)
        Me.optASS.Name = "optASS"
        Me.optASS.Size = New System.Drawing.Size(83, 18)
        Me.optASS.TabIndex = 187
        Me.optASS.Text = "ASSEGNATA"
        Me.optASS.ThemeName = "Fluent"
        '
        'optSOS
        '
        Me.optSOS.Location = New System.Drawing.Point(19, 92)
        Me.optSOS.Name = "optSOS"
        Me.optSOS.Size = New System.Drawing.Size(67, 18)
        Me.optSOS.TabIndex = 189
        Me.optSOS.Text = "SOSPESA"
        Me.optSOS.ThemeName = "Fluent"
        '
        'optLAV
        '
        Me.optLAV.Location = New System.Drawing.Point(19, 72)
        Me.optLAV.Name = "optLAV"
        Me.optLAV.Size = New System.Drawing.Size(110, 18)
        Me.optLAV.TabIndex = 188
        Me.optLAV.Text = "IN LAVORAZIONE"
        Me.optLAV.ThemeName = "Fluent"
        '
        'txtDataStato
        '
        Me.txtDataStato.AutoSize = False
        Me.txtDataStato.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtDataStato.ForeColor = System.Drawing.Color.Black
        Me.txtDataStato.Location = New System.Drawing.Point(152, 43)
        Me.txtDataStato.Mask = "00/00/0000"
        Me.txtDataStato.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.txtDataStato.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txtDataStato.Name = "txtDataStato"
        '
        '
        '
        Me.txtDataStato.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txtDataStato.Size = New System.Drawing.Size(97, 30)
        Me.txtDataStato.TabIndex = 15
        Me.txtDataStato.TabStop = False
        Me.txtDataStato.Text = "__/__/____"
        Me.txtDataStato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDataStato.ThemeName = "Fluent"
        CType(Me.txtDataStato.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = "__/__/____"
        CType(Me.txtDataStato.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'txtOraStato
        '
        Me.txtOraStato.AutoSize = False
        Me.txtOraStato.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOraStato.ForeColor = System.Drawing.Color.Black
        Me.txtOraStato.Location = New System.Drawing.Point(152, 96)
        Me.txtOraStato.Mask = "t"
        Me.txtOraStato.MaskType = Telerik.WinControls.UI.MaskType.DateTime
        Me.txtOraStato.Name = "txtOraStato"
        Me.txtOraStato.NullText = "ora"
        Me.txtOraStato.Size = New System.Drawing.Size(97, 30)
        Me.txtOraStato.TabIndex = 16
        Me.txtOraStato.TabStop = False
        Me.txtOraStato.Text = "11:51"
        Me.txtOraStato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtOraStato.ThemeName = "Fluent"
        CType(Me.txtOraStato.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = "11:51"
        CType(Me.txtOraStato.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).NullText = "ora"
        CType(Me.txtOraStato.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'listStati
        '
        Me.listStati.ItemHeight = 40
        Me.listStati.Location = New System.Drawing.Point(380, 44)
        Me.listStati.Name = "listStati"
        Me.listStati.Size = New System.Drawing.Size(206, 276)
        Me.listStati.TabIndex = 185
        Me.listStati.TabStop = False
        Me.listStati.ThemeName = "Fluent"
        '
        'RadLabel24
        '
        Me.RadLabel24.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel24.Location = New System.Drawing.Point(15, 223)
        Me.RadLabel24.Name = "RadLabel24"
        Me.RadLabel24.Size = New System.Drawing.Size(69, 21)
        Me.RadLabel24.TabIndex = 184
        Me.RadLabel24.Text = "Riscontro"
        Me.RadLabel24.ThemeName = "MaterialTeal"
        '
        'txtRiscontro
        '
        Me.txtRiscontro.AutoSize = False
        Me.txtRiscontro.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtRiscontro.ForeColor = System.Drawing.Color.Black
        Me.txtRiscontro.Location = New System.Drawing.Point(93, 223)
        Me.txtRiscontro.MaxLength = 255
        Me.txtRiscontro.Multiline = True
        Me.txtRiscontro.Name = "txtRiscontro"
        Me.txtRiscontro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRiscontro.Size = New System.Drawing.Size(270, 93)
        Me.txtRiscontro.TabIndex = 17
        Me.txtRiscontro.ThemeName = "Fluent"
        CType(Me.txtRiscontro.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'cmbTecnico
        '
        Me.cmbTecnico.AutoSize = False
        '
        'cmbTecnico.NestedRadGridView
        '
        Me.cmbTecnico.EditorControl.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTecnico.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTecnico.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbTecnico.EditorControl.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.cmbTecnico.EditorControl.MasterTemplate.AllowAddNewRow = False
        Me.cmbTecnico.EditorControl.MasterTemplate.AllowCellContextMenu = False
        Me.cmbTecnico.EditorControl.MasterTemplate.AllowColumnChooser = False
        Me.cmbTecnico.EditorControl.MasterTemplate.EnableGrouping = False
        Me.cmbTecnico.EditorControl.MasterTemplate.ShowFilteringRow = False
        Me.cmbTecnico.EditorControl.MasterTemplate.ViewDefinition = TableViewDefinition3
        Me.cmbTecnico.EditorControl.Name = "NestedRadGridView"
        Me.cmbTecnico.EditorControl.ReadOnly = True
        Me.cmbTecnico.EditorControl.ShowGroupPanel = False
        Me.cmbTecnico.EditorControl.Size = New System.Drawing.Size(240, 150)
        Me.cmbTecnico.EditorControl.TabIndex = 0
        Me.cmbTecnico.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cmbTecnico.ForeColor = System.Drawing.Color.Black
        Me.cmbTecnico.Location = New System.Drawing.Point(93, 44)
        Me.cmbTecnico.Name = "cmbTecnico"
        Me.cmbTecnico.NullText = "Tecnico"
        Me.cmbTecnico.Size = New System.Drawing.Size(244, 30)
        Me.cmbTecnico.TabIndex = 11
        Me.cmbTecnico.TabStop = False
        Me.cmbTecnico.ThemeName = "Fluent"
        '
        'cmbStatoChiamata
        '
        Me.cmbStatoChiamata.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbStatoChiamata.AutoSize = False
        Me.cmbStatoChiamata.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cmbStatoChiamata.ForeColor = System.Drawing.Color.Black
        Me.cmbStatoChiamata.Location = New System.Drawing.Point(5, 281)
        Me.cmbStatoChiamata.Name = "cmbStatoChiamata"
        Me.cmbStatoChiamata.NullText = "Seleziona un valore"
        Me.cmbStatoChiamata.Size = New System.Drawing.Size(138, 30)
        Me.cmbStatoChiamata.TabIndex = 14
        Me.cmbStatoChiamata.ThemeName = "Fluent"
        Me.cmbStatoChiamata.Visible = False
        CType(Me.cmbStatoChiamata.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.StackLayoutElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        CType(Me.cmbStatoChiamata.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).NullText = "Seleziona un valore"
        CType(Me.cmbStatoChiamata.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'RadLabel6
        '
        Me.RadLabel6.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel6.Location = New System.Drawing.Point(13, 318)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(41, 21)
        Me.RadLabel6.TabIndex = 181
        Me.RadLabel6.Text = "Stato"
        Me.RadLabel6.ThemeName = "MaterialTeal"
        Me.RadLabel6.Visible = False
        '
        'RadLabel19
        '
        Me.RadLabel19.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel19.Location = New System.Drawing.Point(15, 51)
        Me.RadLabel19.Name = "RadLabel19"
        Me.RadLabel19.Size = New System.Drawing.Size(59, 21)
        Me.RadLabel19.TabIndex = 179
        Me.RadLabel19.Text = "Tecnico"
        Me.RadLabel19.ThemeName = "MaterialTeal"
        '
        'txtDataAssegn
        '
        Me.txtDataAssegn.AutoSize = False
        Me.txtDataAssegn.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataAssegn.ForeColor = System.Drawing.Color.Black
        Me.txtDataAssegn.Location = New System.Drawing.Point(393, 15)
        Me.txtDataAssegn.Mask = "00/00/0000"
        Me.txtDataAssegn.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.txtDataAssegn.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txtDataAssegn.Name = "txtDataAssegn"
        Me.txtDataAssegn.ReadOnly = True
        '
        '
        '
        Me.txtDataAssegn.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txtDataAssegn.Size = New System.Drawing.Size(97, 30)
        Me.txtDataAssegn.TabIndex = 12
        Me.txtDataAssegn.TabStop = False
        Me.txtDataAssegn.Text = "__/__/____"
        Me.txtDataAssegn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDataAssegn.ThemeName = "Fluent"
        Me.txtDataAssegn.Visible = False
        CType(Me.txtDataAssegn.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = "__/__/____"
        CType(Me.txtDataAssegn.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'RadLabel8
        '
        Me.RadLabel8.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel8.Location = New System.Drawing.Point(238, 19)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(133, 21)
        Me.RadLabel8.TabIndex = 6
        Me.RadLabel8.Text = "Data/ora assegnaz."
        Me.RadLabel8.ThemeName = "MaterialTeal"
        Me.RadLabel8.Visible = False
        '
        'txtOraAss
        '
        Me.txtOraAss.AutoSize = False
        Me.txtOraAss.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOraAss.ForeColor = System.Drawing.Color.Black
        Me.txtOraAss.Location = New System.Drawing.Point(504, 15)
        Me.txtOraAss.Mask = "00000"
        Me.txtOraAss.Name = "txtOraAss"
        Me.txtOraAss.NullText = "ora"
        Me.txtOraAss.ReadOnly = True
        Me.txtOraAss.Size = New System.Drawing.Size(79, 30)
        Me.txtOraAss.TabIndex = 13
        Me.txtOraAss.TabStop = False
        Me.txtOraAss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtOraAss.ThemeName = "Fluent"
        Me.txtOraAss.Visible = False
        CType(Me.txtOraAss.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = ""
        CType(Me.txtOraAss.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).NullText = "ora"
        CType(Me.txtOraAss.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'groupChiamata
        '
        Me.groupChiamata.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.groupChiamata.Controls.Add(Me.RadLabel7)
        Me.groupChiamata.Controls.Add(Me.txtIdWeb)
        Me.groupChiamata.Controls.Add(Me.chkOre13)
        Me.groupChiamata.Controls.Add(Me.txtID)
        Me.groupChiamata.Controls.Add(Me.RadLabel23)
        Me.groupChiamata.Controls.Add(Me.txtChiamante)
        Me.groupChiamata.Controls.Add(Me.txtRecapito)
        Me.groupChiamata.Controls.Add(Me.txtMotivo)
        Me.groupChiamata.Controls.Add(Me.cmbMotivo)
        Me.groupChiamata.Controls.Add(Me.chkIntrappolamento)
        Me.groupChiamata.Controls.Add(Me.chkImpiantoFermo)
        Me.groupChiamata.Controls.Add(Me.chkReperib)
        Me.groupChiamata.Controls.Add(Me.RadLabel5)
        Me.groupChiamata.Controls.Add(Me.RadLabel4)
        Me.groupChiamata.Controls.Add(Me.RadLabel2)
        Me.groupChiamata.HeaderImage = CType(resources.GetObject("groupChiamata.HeaderImage"), System.Drawing.Image)
        Me.groupChiamata.HeaderMargin = New System.Windows.Forms.Padding(1)
        Me.groupChiamata.HeaderText = "DATI CHIAMATA"
        Me.groupChiamata.HeaderTextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.groupChiamata.Location = New System.Drawing.Point(475, 22)
        Me.groupChiamata.Name = "groupChiamata"
        Me.groupChiamata.Size = New System.Drawing.Size(415, 342)
        Me.groupChiamata.TabIndex = 209
        Me.groupChiamata.Text = "DATI CHIAMATA"
        Me.groupChiamata.ThemeName = "MaterialBlueGrey"
        '
        'RadLabel7
        '
        Me.RadLabel7.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel7.Location = New System.Drawing.Point(235, 41)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(53, 21)
        Me.RadLabel7.TabIndex = 217
        Me.RadLabel7.Text = "ID Web"
        Me.RadLabel7.ThemeName = "MaterialTeal"
        '
        'txtIdWeb
        '
        Me.txtIdWeb.AutoSize = False
        Me.txtIdWeb.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdWeb.ForeColor = System.Drawing.Color.Black
        Me.txtIdWeb.Location = New System.Drawing.Point(290, 36)
        Me.txtIdWeb.MaxLength = 35
        Me.txtIdWeb.Name = "txtIdWeb"
        Me.txtIdWeb.ReadOnly = True
        Me.txtIdWeb.Size = New System.Drawing.Size(106, 30)
        Me.txtIdWeb.TabIndex = 216
        Me.txtIdWeb.TabStop = False
        Me.txtIdWeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIdWeb.ThemeName = "Fluent"
        CType(Me.txtIdWeb.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'chkOre13
        '
        Me.chkOre13.ForeColor = System.Drawing.Color.DimGray
        Me.chkOre13.Location = New System.Drawing.Point(184, 310)
        Me.chkOre13.Name = "chkOre13"
        Me.chkOre13.Size = New System.Drawing.Size(196, 19)
        Me.chkOre13.TabIndex = 10
        Me.chkOre13.Text = "Reperib. Sabato oltre le 13"
        Me.chkOre13.ThemeName = "MaterialTeal"
        '
        'txtID
        '
        Me.txtID.AutoSize = False
        Me.txtID.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.ForeColor = System.Drawing.Color.Black
        Me.txtID.Location = New System.Drawing.Point(95, 36)
        Me.txtID.MaxLength = 35
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(106, 30)
        Me.txtID.TabIndex = 215
        Me.txtID.TabStop = False
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtID.ThemeName = "Fluent"
        CType(Me.txtID.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'RadLabel23
        '
        Me.RadLabel23.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel23.Location = New System.Drawing.Point(11, 41)
        Me.RadLabel23.Name = "RadLabel23"
        Me.RadLabel23.Size = New System.Drawing.Size(84, 21)
        Me.RadLabel23.TabIndex = 214
        Me.RadLabel23.Text = "ID chiamata"
        Me.RadLabel23.ThemeName = "MaterialTeal"
        '
        'txtChiamante
        '
        Me.txtChiamante.AutoSize = False
        Me.txtChiamante.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtChiamante.ForeColor = System.Drawing.Color.Black
        Me.txtChiamante.Location = New System.Drawing.Point(95, 70)
        Me.txtChiamante.MaxLength = 35
        Me.txtChiamante.Name = "txtChiamante"
        Me.txtChiamante.Size = New System.Drawing.Size(301, 30)
        Me.txtChiamante.TabIndex = 3
        Me.txtChiamante.ThemeName = "Fluent"
        CType(Me.txtChiamante.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'txtRecapito
        '
        Me.txtRecapito.AutoSize = False
        Me.txtRecapito.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtRecapito.ForeColor = System.Drawing.Color.Black
        Me.txtRecapito.Location = New System.Drawing.Point(95, 104)
        Me.txtRecapito.MaxLength = 35
        Me.txtRecapito.Name = "txtRecapito"
        Me.txtRecapito.Size = New System.Drawing.Size(301, 30)
        Me.txtRecapito.TabIndex = 4
        Me.txtRecapito.ThemeName = "Fluent"
        CType(Me.txtRecapito.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'txtMotivo
        '
        Me.txtMotivo.AutoSize = False
        Me.txtMotivo.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txtMotivo.ForeColor = System.Drawing.Color.Black
        Me.txtMotivo.Location = New System.Drawing.Point(95, 172)
        Me.txtMotivo.MaxLength = 100
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMotivo.Size = New System.Drawing.Size(301, 101)
        Me.txtMotivo.TabIndex = 6
        Me.txtMotivo.ThemeName = "Fluent"
        CType(Me.txtMotivo.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'cmbMotivo
        '
        Me.cmbMotivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbMotivo.AutoSize = False
        Me.cmbMotivo.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cmbMotivo.ForeColor = System.Drawing.Color.Black
        Me.cmbMotivo.Location = New System.Drawing.Point(95, 138)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.NullText = "Seleziona un valore"
        Me.cmbMotivo.Size = New System.Drawing.Size(301, 30)
        Me.cmbMotivo.TabIndex = 5
        Me.cmbMotivo.ThemeName = "Fluent"
        CType(Me.cmbMotivo.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.StackLayoutElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        CType(Me.cmbMotivo.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).NullText = "Seleziona un valore"
        CType(Me.cmbMotivo.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'chkIntrappolamento
        '
        Me.chkIntrappolamento.ForeColor = System.Drawing.Color.DimGray
        Me.chkIntrappolamento.Location = New System.Drawing.Point(41, 286)
        Me.chkIntrappolamento.Name = "chkIntrappolamento"
        Me.chkIntrappolamento.Size = New System.Drawing.Size(132, 19)
        Me.chkIntrappolamento.TabIndex = 7
        Me.chkIntrappolamento.Text = "Intrappolamento"
        Me.chkIntrappolamento.ThemeName = "MaterialTeal"
        '
        'chkImpiantoFermo
        '
        Me.chkImpiantoFermo.ForeColor = System.Drawing.Color.DimGray
        Me.chkImpiantoFermo.Location = New System.Drawing.Point(41, 311)
        Me.chkImpiantoFermo.Name = "chkImpiantoFermo"
        Me.chkImpiantoFermo.Size = New System.Drawing.Size(125, 19)
        Me.chkImpiantoFermo.TabIndex = 8
        Me.chkImpiantoFermo.Text = "Impianto fermo"
        Me.chkImpiantoFermo.ThemeName = "MaterialTeal"
        '
        'chkReperib
        '
        Me.chkReperib.ForeColor = System.Drawing.Color.DimGray
        Me.chkReperib.Location = New System.Drawing.Point(184, 285)
        Me.chkReperib.Name = "chkReperib"
        Me.chkReperib.Size = New System.Drawing.Size(179, 19)
        Me.chkReperib.TabIndex = 9
        Me.chkReperib.Text = "Intervento in reperibilità"
        Me.chkReperib.ThemeName = "MaterialTeal"
        '
        'RadLabel5
        '
        Me.RadLabel5.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel5.Location = New System.Drawing.Point(11, 143)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(52, 21)
        Me.RadLabel5.TabIndex = 20
        Me.RadLabel5.Text = "Motivo"
        Me.RadLabel5.ThemeName = "MaterialTeal"
        '
        'RadLabel4
        '
        Me.RadLabel4.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel4.Location = New System.Drawing.Point(11, 109)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(64, 21)
        Me.RadLabel4.TabIndex = 18
        Me.RadLabel4.Text = "Recapito"
        Me.RadLabel4.ThemeName = "MaterialTeal"
        '
        'RadLabel2
        '
        Me.RadLabel2.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel2.Location = New System.Drawing.Point(11, 76)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(77, 21)
        Me.RadLabel2.TabIndex = 16
        Me.RadLabel2.Text = "Chiamante"
        Me.RadLabel2.ThemeName = "MaterialTeal"
        '
        'splitDashBoard
        '
        Me.splitDashBoard.Controls.Add(Me.SplitDash1)
        Me.splitDashBoard.Controls.Add(Me.SplitDash2)
        Me.splitDashBoard.Controls.Add(Me.SplitDash3)
        Me.splitDashBoard.Controls.Add(Me.SplitDash4)
        Me.splitDashBoard.Dock = System.Windows.Forms.DockStyle.Top
        Me.splitDashBoard.Location = New System.Drawing.Point(0, 0)
        Me.splitDashBoard.Name = "splitDashBoard"
        '
        '
        '
        Me.splitDashBoard.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.splitDashBoard.Size = New System.Drawing.Size(1538, 116)
        Me.splitDashBoard.TabIndex = 195
        Me.splitDashBoard.TabStop = False
        Me.splitDashBoard.ThemeName = "Office2013Dark"
        '
        'SplitDash1
        '
        Me.SplitDash1.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.SplitDash1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.SplitDash1.Controls.Add(Me.lblVisAssegnate)
        Me.SplitDash1.Controls.Add(Me.lblNrAss)
        Me.SplitDash1.Controls.Add(Me.RadLabel32)
        Me.SplitDash1.Controls.Add(Me.PictureBox4)
        Me.SplitDash1.Location = New System.Drawing.Point(0, 0)
        Me.SplitDash1.Name = "SplitDash1"
        '
        '
        '
        Me.SplitDash1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitDash1.Size = New System.Drawing.Size(382, 116)
        Me.SplitDash1.TabIndex = 0
        Me.SplitDash1.TabStop = False
        Me.SplitDash1.Text = "SplitPanel1"
        Me.SplitDash1.ThemeName = "Office2013Dark"
        CType(Me.SplitDash1.GetChildAt(0), Telerik.WinControls.UI.SplitPanelElement).Margin = New System.Windows.Forms.Padding(0)
        CType(Me.SplitDash1.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).Opacity = 1.0R
        CType(Me.SplitDash1.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).Padding = New System.Windows.Forms.Padding(0)
        CType(Me.SplitDash1.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).Margin = New System.Windows.Forms.Padding(1)
        '
        'lblVisAssegnate
        '
        Me.lblVisAssegnate.AutoSize = False
        Me.lblVisAssegnate.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.lblVisAssegnate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblVisAssegnate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVisAssegnate.ForeColor = System.Drawing.Color.White
        Me.lblVisAssegnate.Image = CType(resources.GetObject("lblVisAssegnate.Image"), System.Drawing.Image)
        Me.lblVisAssegnate.Location = New System.Drawing.Point(0, 85)
        Me.lblVisAssegnate.Name = "lblVisAssegnate"
        Me.lblVisAssegnate.Size = New System.Drawing.Size(382, 31)
        Me.lblVisAssegnate.TabIndex = 4
        Me.lblVisAssegnate.Text = "VISUALIZZA"
        Me.lblVisAssegnate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'lblNrAss
        '
        Me.lblNrAss.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNrAss.ForeColor = System.Drawing.Color.White
        Me.lblNrAss.Location = New System.Drawing.Point(94, 4)
        Me.lblNrAss.Name = "lblNrAss"
        Me.lblNrAss.Size = New System.Drawing.Size(36, 51)
        Me.lblNrAss.TabIndex = 2
        Me.lblNrAss.Text = "0"
        '
        'RadLabel32
        '
        Me.RadLabel32.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel32.ForeColor = System.Drawing.Color.White
        Me.RadLabel32.Location = New System.Drawing.Point(99, 52)
        Me.RadLabel32.Name = "RadLabel32"
        Me.RadLabel32.Size = New System.Drawing.Size(188, 22)
        Me.RadLabel32.TabIndex = 3
        Me.RadLabel32.Text = "CHIAMATE ASSEGNATE"
        '
        'PictureBox4
        '
        Me.PictureBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.PictureBox4.Size = New System.Drawing.Size(382, 91)
        Me.PictureBox4.TabIndex = 4
        Me.PictureBox4.TabStop = False
        '
        'SplitDash2
        '
        Me.SplitDash2.BackColor = System.Drawing.Color.FromArgb(CType(CType(121, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.SplitDash2.Controls.Add(Me.lblVisLav)
        Me.SplitDash2.Controls.Add(Me.lblNrLav)
        Me.SplitDash2.Controls.Add(Me.RadLabel26)
        Me.SplitDash2.Controls.Add(Me.PictureBox1)
        Me.SplitDash2.Location = New System.Drawing.Point(386, 0)
        Me.SplitDash2.Name = "SplitDash2"
        '
        '
        '
        Me.SplitDash2.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitDash2.Size = New System.Drawing.Size(382, 116)
        Me.SplitDash2.TabIndex = 1
        Me.SplitDash2.TabStop = False
        Me.SplitDash2.Text = "SplitPanel2"
        Me.SplitDash2.ThemeName = "Office2013Dark"
        '
        'lblVisLav
        '
        Me.lblVisLav.AutoSize = False
        Me.lblVisLav.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.lblVisLav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblVisLav.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVisLav.ForeColor = System.Drawing.Color.White
        Me.lblVisLav.Image = CType(resources.GetObject("lblVisLav.Image"), System.Drawing.Image)
        Me.lblVisLav.Location = New System.Drawing.Point(0, 85)
        Me.lblVisLav.Name = "lblVisLav"
        Me.lblVisLav.Size = New System.Drawing.Size(382, 31)
        Me.lblVisLav.TabIndex = 5
        Me.lblVisLav.Text = "VISUALIZZA"
        Me.lblVisLav.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'lblNrLav
        '
        Me.lblNrLav.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNrLav.ForeColor = System.Drawing.Color.White
        Me.lblNrLav.Location = New System.Drawing.Point(94, 4)
        Me.lblNrLav.Name = "lblNrLav"
        Me.lblNrLav.Size = New System.Drawing.Size(36, 51)
        Me.lblNrLav.TabIndex = 0
        Me.lblNrLav.Text = "0"
        '
        'RadLabel26
        '
        Me.RadLabel26.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel26.ForeColor = System.Drawing.Color.White
        Me.RadLabel26.Location = New System.Drawing.Point(86, 52)
        Me.RadLabel26.Name = "RadLabel26"
        Me.RadLabel26.Size = New System.Drawing.Size(233, 22)
        Me.RadLabel26.TabIndex = 1
        Me.RadLabel26.Text = "CHIAMATE IN LAVORAZIONE"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.PictureBox1.Size = New System.Drawing.Size(382, 91)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'SplitDash3
        '
        Me.SplitDash3.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.SplitDash3.Controls.Add(Me.lblImpiantiFermi)
        Me.SplitDash3.Controls.Add(Me.lblVisSos)
        Me.SplitDash3.Controls.Add(Me.lblNrSos)
        Me.SplitDash3.Controls.Add(Me.RadLabel28)
        Me.SplitDash3.Controls.Add(Me.PictureBox2)
        Me.SplitDash3.Location = New System.Drawing.Point(772, 0)
        Me.SplitDash3.Name = "SplitDash3"
        '
        '
        '
        Me.SplitDash3.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitDash3.Size = New System.Drawing.Size(382, 116)
        Me.SplitDash3.TabIndex = 2
        Me.SplitDash3.TabStop = False
        Me.SplitDash3.Text = "SplitPanel3"
        Me.SplitDash3.ThemeName = "Office2013Dark"
        '
        'lblImpiantiFermi
        '
        Me.lblImpiantiFermi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpiantiFermi.ForeColor = System.Drawing.Color.White
        Me.lblImpiantiFermi.Location = New System.Drawing.Point(105, 63)
        Me.lblImpiantiFermi.Name = "lblImpiantiFermi"
        Me.lblImpiantiFermi.Size = New System.Drawing.Size(115, 17)
        Me.lblImpiantiFermi.TabIndex = 7
        Me.lblImpiantiFermi.Text = "IMPIANTI FERMI 0"
        '
        'lblVisSos
        '
        Me.lblVisSos.AutoSize = False
        Me.lblVisSos.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblVisSos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblVisSos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVisSos.ForeColor = System.Drawing.Color.White
        Me.lblVisSos.Image = CType(resources.GetObject("lblVisSos.Image"), System.Drawing.Image)
        Me.lblVisSos.Location = New System.Drawing.Point(0, 85)
        Me.lblVisSos.Name = "lblVisSos"
        Me.lblVisSos.Size = New System.Drawing.Size(382, 31)
        Me.lblVisSos.TabIndex = 6
        Me.lblVisSos.Text = "VISUALIZZA"
        Me.lblVisSos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'lblNrSos
        '
        Me.lblNrSos.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNrSos.ForeColor = System.Drawing.Color.White
        Me.lblNrSos.Location = New System.Drawing.Point(98, 4)
        Me.lblNrSos.Name = "lblNrSos"
        Me.lblNrSos.Size = New System.Drawing.Size(28, 41)
        Me.lblNrSos.TabIndex = 2
        Me.lblNrSos.Text = "0"
        '
        'RadLabel28
        '
        Me.RadLabel28.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel28.ForeColor = System.Drawing.Color.White
        Me.RadLabel28.Location = New System.Drawing.Point(90, 43)
        Me.RadLabel28.Name = "RadLabel28"
        Me.RadLabel28.Size = New System.Drawing.Size(144, 19)
        Me.RadLabel28.TabIndex = 3
        Me.RadLabel28.Text = "CHIAMATE SOSPESE"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.PictureBox2.Size = New System.Drawing.Size(382, 91)
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'SplitDash4
        '
        Me.SplitDash4.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.SplitDash4.Controls.Add(Me.lblVisChi)
        Me.SplitDash4.Controls.Add(Me.lblNrChi)
        Me.SplitDash4.Controls.Add(Me.lblChiamateChiuse)
        Me.SplitDash4.Controls.Add(Me.PictureBox3)
        Me.SplitDash4.Location = New System.Drawing.Point(1158, 0)
        Me.SplitDash4.Name = "SplitDash4"
        '
        '
        '
        Me.SplitDash4.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitDash4.Size = New System.Drawing.Size(380, 116)
        Me.SplitDash4.TabIndex = 3
        Me.SplitDash4.TabStop = False
        Me.SplitDash4.Text = "SplitPanel4"
        Me.SplitDash4.ThemeName = "Office2013Dark"
        '
        'lblVisChi
        '
        Me.lblVisChi.AutoSize = False
        Me.lblVisChi.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(13, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.lblVisChi.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblVisChi.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVisChi.ForeColor = System.Drawing.Color.White
        Me.lblVisChi.Image = CType(resources.GetObject("lblVisChi.Image"), System.Drawing.Image)
        Me.lblVisChi.Location = New System.Drawing.Point(0, 85)
        Me.lblVisChi.Name = "lblVisChi"
        Me.lblVisChi.Size = New System.Drawing.Size(380, 31)
        Me.lblVisChi.TabIndex = 7
        Me.lblVisChi.Text = "VISUALIZZA"
        Me.lblVisChi.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'lblNrChi
        '
        Me.lblNrChi.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNrChi.ForeColor = System.Drawing.Color.White
        Me.lblNrChi.Location = New System.Drawing.Point(94, 4)
        Me.lblNrChi.Name = "lblNrChi"
        Me.lblNrChi.Size = New System.Drawing.Size(36, 51)
        Me.lblNrChi.TabIndex = 2
        Me.lblNrChi.Text = "0"
        '
        'lblChiamateChiuse
        '
        Me.lblChiamateChiuse.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChiamateChiuse.ForeColor = System.Drawing.Color.White
        Me.lblChiamateChiuse.Location = New System.Drawing.Point(84, 52)
        Me.lblChiamateChiuse.Name = "lblChiamateChiuse"
        Me.lblChiamateChiuse.Size = New System.Drawing.Size(135, 19)
        Me.lblChiamateChiuse.TabIndex = 3
        Me.lblChiamateChiuse.Text = "CHIAMATE CHIUSE"
        '
        'PictureBox3
        '
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.PictureBox3.Size = New System.Drawing.Size(380, 91)
        Me.PictureBox3.TabIndex = 4
        Me.PictureBox3.TabStop = False
        '
        'Images1
        '
        Me.Images1.Credentials = Nothing
        Me.Images1.Url = "http://srvedoc/images.asmx"
        Me.Images1.UseDefaultCredentials = False
        '
        't1Dash
        '
        Me.t1Dash.Interval = 10000
        '
        'FrmChiamate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1538, 943)
        Me.Controls.Add(Me.dockGen)
        Me.Controls.Add(Me.splitDashBoard)
        Me.Name = "FrmChiamate"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestione chiamate"
        Me.ThemeName = "MaterialBlueGrey"
        CType(Me.dockGen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dockGen.ResumeLayout(False)
        Me.DocWinRicerca.ResumeLayout(False)
        Me.DocWinRicerca.PerformLayout()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lista_Stati, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesClienteRic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesImpRic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesTecRic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesCentroRic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesSocRic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodTecRic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAperturaAl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAperturaDal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkImpiantiFunz, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkImpiantiFermi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkImpiantiDisdetti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkChiamateReper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkChiamateSabato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkChiamateRep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkImpiantiNonCritici, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkImpiantiCritici, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodImpRic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodCentroRic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodSocRic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdSearchTec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdSearchImp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdSearchCen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdSearchSoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodClienteRic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdSearchCli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocContainerUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DocContainerUp.ResumeLayout(False)
        CType(Me.DocumentTabStrip4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DocumentTabStrip4.ResumeLayout(False)
        Me.DocWinElenco.ResumeLayout(False)
        Me.DocWinElenco.PerformLayout()
        CType(Me.grid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grid.ResumeLayout(False)
        Me.grid.PerformLayout()
        CType(Me.wb4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wb3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wb2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wb1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocTabStripMappa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DocTabStripMappa.ResumeLayout(False)
        Me.ToolWinMap.ResumeLayout(False)
        Me.ToolWinMap.PerformLayout()
        CType(Me.map, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToolTabStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolTabStrip1.ResumeLayout(False)
        Me.ToolWinChiamata.ResumeLayout(False)
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdAnnulla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdConferma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.groupImpianto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupImpianto.ResumeLayout(False)
        Me.groupImpianto.PerformLayout()
        CType(Me.txtTipoImp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentri.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentri.EditorControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentri, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLocalita, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSocieta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIndirizzo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOkSearchImp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.groupInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupInfo.ResumeLayout(False)
        Me.groupInfo.PerformLayout()
        CType(Me.imgTel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.RadLabel27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optAPE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optCHI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optASS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optSOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optLAV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataStato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOraStato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.listStati, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRiscontro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTecnico.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTecnico.EditorControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTecnico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbStatoChiamata, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDataAssegn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOraAss, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.groupChiamata, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupChiamata.ResumeLayout(False)
        Me.groupChiamata.PerformLayout()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIdWeb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOre13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChiamante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRecapito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIntrappolamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkImpiantoFermo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkReperib, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.splitDashBoard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitDashBoard.ResumeLayout(False)
        CType(Me.SplitDash1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitDash1.ResumeLayout(False)
        Me.SplitDash1.PerformLayout()
        CType(Me.lblVisAssegnate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNrAss, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitDash2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitDash2.ResumeLayout(False)
        Me.SplitDash2.PerformLayout()
        CType(Me.lblVisLav, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNrLav, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitDash3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitDash3.ResumeLayout(False)
        Me.SplitDash3.PerformLayout()
        CType(Me.lblImpiantiFermi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblVisSos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNrSos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitDash4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitDash4.ResumeLayout(False)
        Me.SplitDash4.PerformLayout()
        CType(Me.lblVisChi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNrChi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblChiamateChiuse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dockGen As Telerik.WinControls.UI.Docking.RadDock
    Friend WithEvents ToolWinChiamata As Telerik.WinControls.UI.Docking.ToolWindow
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtProv As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents wb As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents DotsRingWaitingBarIndicatorElement2 As Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement
    Friend WithEvents RadLabel19 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtCap As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents RadLabel14 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtDataAssegn As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents txtIndirizzo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel17 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents DocContainerUp As Telerik.WinControls.UI.Docking.DocumentContainer
    Friend WithEvents DocWinElenco As Telerik.WinControls.UI.Docking.DocumentWindow
    Friend WithEvents grid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents ToolWinMap As Telerik.WinControls.UI.Docking.ToolWindow
    Friend WithEvents map As Telerik.WinControls.UI.RadMap
    Friend WithEvents DocTabStripMappa As Telerik.WinControls.UI.Docking.DocumentTabStrip
    Friend WithEvents groupChiamata As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents cmdOkSearchImp As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtOraAss As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents groupInfo As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtDataStato As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents txtOraStato As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents cmbStatoChiamata As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbMotivo As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents chkIntrappolamento As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkImpiantoFermo As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkReperib As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents groupImpianto As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents cmbSocieta As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel10 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel9 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdAnnulla As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdConferma As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel12 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel11 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtLocalita As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents TxtCodice As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents DocumentTabStrip4 As Telerik.WinControls.UI.Docking.DocumentTabStrip
    Friend WithEvents DocWinRicerca As Telerik.WinControls.UI.Docking.DocumentWindow
    Friend WithEvents ToolTabStrip1 As Telerik.WinControls.UI.Docking.ToolTabStrip
    Friend WithEvents cmdBar As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripE1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents cmdInserisci As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdModChiam As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdDelChiam As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents txtCodCentroRic As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmdSearchCen As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtCodSocRic As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmdSearchSoc As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCodClienteRic As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmdSearchCli As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdFiltro As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmbCentri As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents txtTipoImp As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtChiamante As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtRecapito As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtMotivo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbTecnico As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents txtDesClienteRic As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtDesImpRic As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtDesTecRic As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtDesCentroRic As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtDesSocRic As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtCodTecRic As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmdSearchTec As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel16 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtAperturaAl As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents txtAperturaDal As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents RadLabel15 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkImpiantiFunz As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkImpiantiFermi As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkImpiantiDisdetti As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkChiamateReper As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkChiamateSabato As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkChiamateRep As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkImpiantiNonCritici As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkImpiantiCritici As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents txtCodImpRic As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmdSearchImp As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel13 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lista_Stati As Telerik.WinControls.UI.RadCheckedListBox
    Friend WithEvents RadLabel18 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadCommandBar1 As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement2 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents cmdBarStripE1mappa As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents cmdBcaricaTecnici As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdBCaricaLimit As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdBFocusTec As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdBFocusImp As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents RadLabel22 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel21 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel20 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtID As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel23 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkOre13 As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel24 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtRiscontro As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents splitDashBoard As Telerik.WinControls.UI.RadSplitContainer
    Friend WithEvents SplitDash1 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents SplitDash2 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents SplitDash3 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents SplitDash4 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents RadLabel26 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblNrLav As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Images1 As EdocImages.Images
    Friend WithEvents lblNrAss As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel32 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblNrSos As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel28 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblNrChi As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblChiamateChiuse As Telerik.WinControls.UI.RadLabel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents lblVisAssegnate As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblVisLav As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblVisSos As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblVisChi As Telerik.WinControls.UI.RadLabel
    Friend WithEvents t1Dash As Timer
    Friend WithEvents wb4 As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents DotsLineWaitingBarIndicatorElement4 As Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement
    Friend WithEvents wb3 As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents DotsLineWaitingBarIndicatorElement3 As Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement
    Friend WithEvents wb2 As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents DotsLineWaitingBarIndicatorElement2 As Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement
    Friend WithEvents wb1 As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents DotsLineWaitingBarIndicatorElement1 As Telerik.WinControls.UI.DotsLineWaitingBarIndicatorElement
    Friend WithEvents lblImpiantiFermi As Telerik.WinControls.UI.RadLabel
    Friend WithEvents listStati As Telerik.WinControls.UI.RadListControl
    Friend WithEvents optCHI As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optSOS As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optLAV As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optASS As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optAPE As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadLabel25 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel27 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtIdWeb As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents imgTel As PictureBox
    Friend WithEvents RadButton2 As Telerik.WinControls.UI.RadButton
End Class

