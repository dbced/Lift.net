<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmServizioContratto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmServizioContratto))
        Me.MaterialBlueGreyTheme1 = New Telerik.WinControls.Themes.MaterialBlueGreyTheme()
        Me.FluentTheme1 = New Telerik.WinControls.Themes.FluentTheme()
        Me.MaterialTealTheme1 = New Telerik.WinControls.Themes.MaterialTealTheme()
        Me.VisualStudio2012LightTheme1 = New Telerik.WinControls.Themes.VisualStudio2012LightTheme()
        Me.Office2013DarkTheme1 = New Telerik.WinControls.Themes.Office2013DarkTheme()
        Me.Office2013DarkTheme2 = New Telerik.WinControls.Themes.Office2013DarkTheme()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.t1 = New System.Windows.Forms.Timer(Me.components)
        Me.CrystalTheme1 = New Telerik.WinControls.Themes.CrystalTheme()
        Me.txtDesSer = New Telerik.WinControls.UI.RadTextBox()
        Me.txtCodSer = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.cmdOkSearchSer = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.txtCanone = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.txtDesIva = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIva = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel33 = New Telerik.WinControls.UI.RadLabel()
        Me.cmdOkSearchIva = New Telerik.WinControls.UI.RadButton()
        Me.cmbFreqFatt = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel10 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel13 = New Telerik.WinControls.UI.RadLabel()
        Me.cmbRivalut = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadPanel1 = New Telerik.WinControls.UI.RadPanel()
        Me.cmdAnnulla = New Telerik.WinControls.UI.RadButton()
        Me.cmdConferma = New Telerik.WinControls.UI.RadButton()
        Me.wb = New Telerik.WinControls.UI.RadWaitingBar()
        Me.DotsRingWaitingBarIndicatorElement2 = New Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement()
        Me.chkFattPostecipata = New Telerik.WinControls.UI.RadRadioButton()
        Me.chkFatAnticipata = New Telerik.WinControls.UI.RadRadioButton()
        CType(Me.txtDesSer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodSer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOkSearchSer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCanone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOkSearchIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbFreqFatt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbRivalut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel1.SuspendLayout()
        CType(Me.cmdAnnulla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdConferma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFattPostecipata, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFatAnticipata, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        't1
        '
        '
        'txtDesSer
        '
        Me.txtDesSer.AutoSize = False
        Me.txtDesSer.ForeColor = System.Drawing.Color.Black
        Me.txtDesSer.Location = New System.Drawing.Point(201, 29)
        Me.txtDesSer.MaxLength = 6
        Me.txtDesSer.Name = "txtDesSer"
        Me.txtDesSer.ReadOnly = True
        Me.txtDesSer.Size = New System.Drawing.Size(535, 36)
        Me.txtDesSer.TabIndex = 194
        Me.txtDesSer.TabStop = False
        Me.txtDesSer.ThemeName = "Fluent"
        CType(Me.txtDesSer.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtDesSer.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'txtCodSer
        '
        Me.txtCodSer.AutoSize = False
        Me.txtCodSer.ForeColor = System.Drawing.Color.Black
        Me.txtCodSer.Location = New System.Drawing.Point(133, 29)
        Me.txtCodSer.MaxLength = 6
        Me.txtCodSer.Name = "txtCodSer"
        Me.txtCodSer.ReadOnly = True
        Me.txtCodSer.Size = New System.Drawing.Size(64, 36)
        Me.txtCodSer.TabIndex = 192
        Me.txtCodSer.ThemeName = "Fluent"
        CType(Me.txtCodSer.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtCodSer.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'RadLabel2
        '
        Me.RadLabel2.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel2.Location = New System.Drawing.Point(64, 35)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(59, 21)
        Me.RadLabel2.TabIndex = 193
        Me.RadLabel2.Text = "Servizio"
        Me.RadLabel2.ThemeName = "MaterialTeal"
        '
        'cmdOkSearchSer
        '
        Me.cmdOkSearchSer.Image = CType(resources.GetObject("cmdOkSearchSer.Image"), System.Drawing.Image)
        Me.cmdOkSearchSer.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdOkSearchSer.Location = New System.Drawing.Point(742, 30)
        Me.cmdOkSearchSer.Name = "cmdOkSearchSer"
        Me.cmdOkSearchSer.Size = New System.Drawing.Size(34, 34)
        Me.cmdOkSearchSer.TabIndex = 195
        Me.cmdOkSearchSer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'RadLabel8
        '
        Me.RadLabel8.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel8.Location = New System.Drawing.Point(71, 79)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(56, 21)
        Me.RadLabel8.TabIndex = 218
        Me.RadLabel8.Text = "Canone"
        Me.RadLabel8.ThemeName = "MaterialTeal"
        '
        'txtCanone
        '
        Me.txtCanone.AutoSize = False
        Me.txtCanone.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCanone.ForeColor = System.Drawing.Color.Black
        Me.txtCanone.Location = New System.Drawing.Point(133, 71)
        Me.txtCanone.Mask = "C"
        Me.txtCanone.MaskType = Telerik.WinControls.UI.MaskType.Numeric
        Me.txtCanone.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txtCanone.Name = "txtCanone"
        '
        '
        '
        Me.txtCanone.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txtCanone.Size = New System.Drawing.Size(202, 36)
        Me.txtCanone.TabIndex = 219
        Me.txtCanone.TabStop = False
        Me.txtCanone.Text = "€ 0,00"
        Me.txtCanone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCanone.ThemeName = "Fluent"
        CType(Me.txtCanone.GetChildAt(0), Telerik.WinControls.UI.RadMaskedEditBoxElement).Text = "€ 0,00"
        CType(Me.txtCanone.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'txtDesIva
        '
        Me.txtDesIva.AutoSize = False
        Me.txtDesIva.ForeColor = System.Drawing.Color.Black
        Me.txtDesIva.Location = New System.Drawing.Point(175, 113)
        Me.txtDesIva.MaxLength = 6
        Me.txtDesIva.Name = "txtDesIva"
        Me.txtDesIva.ReadOnly = True
        Me.txtDesIva.Size = New System.Drawing.Size(161, 36)
        Me.txtDesIva.TabIndex = 241
        Me.txtDesIva.TabStop = False
        Me.txtDesIva.ThemeName = "Fluent"
        CType(Me.txtDesIva.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtDesIva.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'txtIva
        '
        Me.txtIva.AutoSize = False
        Me.txtIva.ForeColor = System.Drawing.Color.Black
        Me.txtIva.Location = New System.Drawing.Point(133, 113)
        Me.txtIva.MaxLength = 6
        Me.txtIva.Name = "txtIva"
        Me.txtIva.ReadOnly = True
        Me.txtIva.Size = New System.Drawing.Size(40, 36)
        Me.txtIva.TabIndex = 239
        Me.txtIva.ThemeName = "Fluent"
        CType(Me.txtIva.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CType(Me.txtIva.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize
        '
        'RadLabel33
        '
        Me.RadLabel33.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel33.Location = New System.Drawing.Point(53, 122)
        Me.RadLabel33.Name = "RadLabel33"
        Me.RadLabel33.Size = New System.Drawing.Size(74, 21)
        Me.RadLabel33.TabIndex = 240
        Me.RadLabel33.Text = "Codice Iva"
        Me.RadLabel33.ThemeName = "MaterialTeal"
        '
        'cmdOkSearchIva
        '
        Me.cmdOkSearchIva.Image = CType(resources.GetObject("cmdOkSearchIva.Image"), System.Drawing.Image)
        Me.cmdOkSearchIva.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdOkSearchIva.Location = New System.Drawing.Point(341, 114)
        Me.cmdOkSearchIva.Name = "cmdOkSearchIva"
        Me.cmdOkSearchIva.Size = New System.Drawing.Size(34, 34)
        Me.cmdOkSearchIva.TabIndex = 242
        Me.cmdOkSearchIva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdOkSearchIva.ThemeName = "ThemeCmdRecubeYEL"
        '
        'cmbFreqFatt
        '
        Me.cmbFreqFatt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbFreqFatt.AutoSize = False
        Me.cmbFreqFatt.ForeColor = System.Drawing.Color.Black
        Me.cmbFreqFatt.Location = New System.Drawing.Point(132, 155)
        Me.cmbFreqFatt.Name = "cmbFreqFatt"
        Me.cmbFreqFatt.NullText = "Seleziona un valore"
        Me.cmbFreqFatt.Size = New System.Drawing.Size(203, 36)
        Me.cmbFreqFatt.TabIndex = 236
        Me.cmbFreqFatt.ThemeName = "Fluent"
        CType(Me.cmbFreqFatt.GetChildAt(0), Telerik.WinControls.UI.RadDropDownListElement).Font = New System.Drawing.Font("Segoe UI", 12.0!)
        '
        'RadLabel10
        '
        Me.RadLabel10.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel10.Location = New System.Drawing.Point(22, 163)
        Me.RadLabel10.Name = "RadLabel10"
        Me.RadLabel10.Size = New System.Drawing.Size(105, 21)
        Me.RadLabel10.TabIndex = 235
        Me.RadLabel10.Text = "Frequenza fatt."
        Me.RadLabel10.ThemeName = "MaterialTeal"
        '
        'RadLabel13
        '
        Me.RadLabel13.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel13.Location = New System.Drawing.Point(31, 205)
        Me.RadLabel13.Name = "RadLabel13"
        Me.RadLabel13.Size = New System.Drawing.Size(94, 21)
        Me.RadLabel13.TabIndex = 237
        Me.RadLabel13.Text = "Rivalutazione"
        Me.RadLabel13.ThemeName = "MaterialTeal"
        '
        'cmbRivalut
        '
        Me.cmbRivalut.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRivalut.AutoSize = False
        Me.cmbRivalut.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cmbRivalut.ForeColor = System.Drawing.Color.Black
        Me.cmbRivalut.Location = New System.Drawing.Point(133, 197)
        Me.cmbRivalut.Name = "cmbRivalut"
        Me.cmbRivalut.NullText = "Seleziona un valore"
        Me.cmbRivalut.Size = New System.Drawing.Size(603, 36)
        Me.cmbRivalut.TabIndex = 238
        Me.cmbRivalut.ThemeName = "Fluent"
        CType(Me.cmbRivalut.GetChildAt(0), Telerik.WinControls.UI.RadDropDownListElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'RadPanel1
        '
        Me.RadPanel1.Controls.Add(Me.cmdAnnulla)
        Me.RadPanel1.Controls.Add(Me.cmdConferma)
        Me.RadPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadPanel1.Location = New System.Drawing.Point(0, 287)
        Me.RadPanel1.Name = "RadPanel1"
        Me.RadPanel1.Size = New System.Drawing.Size(800, 47)
        Me.RadPanel1.TabIndex = 243
        Me.RadPanel1.ThemeName = "Fluent"
        '
        'cmdAnnulla
        '
        Me.cmdAnnulla.Location = New System.Drawing.Point(530, 8)
        Me.cmdAnnulla.Name = "cmdAnnulla"
        Me.cmdAnnulla.Size = New System.Drawing.Size(117, 29)
        Me.cmdAnnulla.TabIndex = 14
        Me.cmdAnnulla.Text = "Annulla"
        Me.cmdAnnulla.ThemeName = "VisualStudio2012Light"
        '
        'cmdConferma
        '
        Me.cmdConferma.Location = New System.Drawing.Point(663, 8)
        Me.cmdConferma.Name = "cmdConferma"
        Me.cmdConferma.Size = New System.Drawing.Size(117, 29)
        Me.cmdConferma.TabIndex = 13
        Me.cmdConferma.Text = "Salva"
        Me.cmdConferma.ThemeName = "VisualStudio2012Light"
        '
        'wb
        '
        Me.wb.AccessibleName = "d"
        Me.wb.Location = New System.Drawing.Point(576, 94)
        Me.wb.Name = "wb"
        Me.wb.Size = New System.Drawing.Size(70, 70)
        Me.wb.TabIndex = 244
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
        'chkFattPostecipata
        '
        Me.chkFattPostecipata.Location = New System.Drawing.Point(341, 247)
        Me.chkFattPostecipata.Name = "chkFattPostecipata"
        Me.chkFattPostecipata.Size = New System.Drawing.Size(188, 22)
        Me.chkFattPostecipata.TabIndex = 246
        Me.chkFattPostecipata.Text = "Fatturazione Postecipata"
        Me.chkFattPostecipata.ThemeName = "MaterialTeal"
        '
        'chkFatAnticipata
        '
        Me.chkFatAnticipata.Location = New System.Drawing.Point(133, 247)
        Me.chkFatAnticipata.Name = "chkFatAnticipata"
        Me.chkFatAnticipata.Size = New System.Drawing.Size(177, 22)
        Me.chkFatAnticipata.TabIndex = 245
        Me.chkFatAnticipata.Text = "Fatturazione Anticipata"
        Me.chkFatAnticipata.ThemeName = "MaterialTeal"
        '
        'FrmServizioContratto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 334)
        Me.Controls.Add(Me.chkFattPostecipata)
        Me.Controls.Add(Me.chkFatAnticipata)
        Me.Controls.Add(Me.wb)
        Me.Controls.Add(Me.RadPanel1)
        Me.Controls.Add(Me.txtDesIva)
        Me.Controls.Add(Me.txtIva)
        Me.Controls.Add(Me.RadLabel33)
        Me.Controls.Add(Me.cmdOkSearchIva)
        Me.Controls.Add(Me.cmbFreqFatt)
        Me.Controls.Add(Me.RadLabel10)
        Me.Controls.Add(Me.RadLabel13)
        Me.Controls.Add(Me.cmbRivalut)
        Me.Controls.Add(Me.RadLabel8)
        Me.Controls.Add(Me.txtCanone)
        Me.Controls.Add(Me.txtDesSer)
        Me.Controls.Add(Me.txtCodSer)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.cmdOkSearchSer)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmServizioContratto"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestione Servizio"
        Me.ThemeName = "MaterialBlueGrey"
        CType(Me.txtDesSer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodSer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOkSearchSer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCanone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOkSearchIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbFreqFatt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbRivalut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel1.ResumeLayout(False)
        CType(Me.cmdAnnulla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdConferma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFattPostecipata, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFatAnticipata, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents txtDesSer As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtCodSer As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdOkSearchSer As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtCanone As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents txtDesIva As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIva As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel33 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdOkSearchIva As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmbFreqFatt As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel10 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel13 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbRivalut As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadPanel1 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents cmdAnnulla As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdConferma As Telerik.WinControls.UI.RadButton
    Friend WithEvents wb As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents DotsRingWaitingBarIndicatorElement2 As Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement
    Friend WithEvents chkFattPostecipata As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents chkFatAnticipata As Telerik.WinControls.UI.RadRadioButton
End Class

