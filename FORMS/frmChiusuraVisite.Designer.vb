<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChiusuraVisite
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChiusuraVisite))
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.FluentDarkTheme1 = New Telerik.WinControls.Themes.FluentDarkTheme()
        Me.VisualStudio2012LightTheme1 = New Telerik.WinControls.Themes.VisualStudio2012LightTheme()
        Me.FluentTheme1 = New Telerik.WinControls.Themes.FluentTheme()
        Me.MaterialTealTheme1 = New Telerik.WinControls.Themes.MaterialTealTheme()
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        Me.t1 = New System.Windows.Forms.Timer(Me.components)
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.txtData = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.cmdAnnulla = New Telerik.WinControls.UI.RadButton()
        Me.cmdConferma = New Telerik.WinControls.UI.RadButton()
        Me.cmdOkSearchImp = New Telerik.WinControls.UI.RadButton()
        Me.grid = New Telerik.WinControls.UI.RadGridView()
        Me.wbG = New Telerik.WinControls.UI.RadWaitingBar()
        Me.DotsRingWaitingBarIndicatorElement1 = New Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement()
        Me.Office2013LightTheme1 = New Telerik.WinControls.Themes.Office2013LightTheme()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.cmbSquadre = New Telerik.WinControls.UI.RadDropDownList()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdAnnulla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdConferma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOkSearchImp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wbG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSquadre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        't1
        '
        '
        'RadLabel2
        '
        Me.RadLabel2.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel2.Location = New System.Drawing.Point(20, 21)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(75, 21)
        Me.RadLabel2.TabIndex = 182
        Me.RadLabel2.Text = "Data visita"
        Me.RadLabel2.ThemeName = "MaterialTeal"
        '
        'txtData
        '
        Me.txtData.AutoSize = False
        Me.txtData.CalendarSize = New System.Drawing.Size(290, 320)
        Me.txtData.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtData.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtData.Location = New System.Drawing.Point(105, 12)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(142, 38)
        Me.txtData.TabIndex = 179
        Me.txtData.TabStop = False
        Me.txtData.Text = "19/08/2020 14:59"
        Me.txtData.ThemeName = "Fluent"
        Me.txtData.Value = New Date(2020, 8, 19, 14, 59, 21, 432)
        '
        'cmdAnnulla
        '
        Me.cmdAnnulla.Location = New System.Drawing.Point(513, 529)
        Me.cmdAnnulla.Name = "cmdAnnulla"
        Me.cmdAnnulla.Size = New System.Drawing.Size(123, 29)
        Me.cmdAnnulla.TabIndex = 180
        Me.cmdAnnulla.Text = "Annulla"
        Me.cmdAnnulla.ThemeName = "VisualStudio2012Light"
        '
        'cmdConferma
        '
        Me.cmdConferma.Location = New System.Drawing.Point(659, 529)
        Me.cmdConferma.Name = "cmdConferma"
        Me.cmdConferma.Size = New System.Drawing.Size(123, 29)
        Me.cmdConferma.TabIndex = 181
        Me.cmdConferma.Text = "Chiudi visite"
        Me.cmdConferma.ThemeName = "VisualStudio2012Light"
        '
        'cmdOkSearchImp
        '
        Me.cmdOkSearchImp.Image = CType(resources.GetObject("cmdOkSearchImp.Image"), System.Drawing.Image)
        Me.cmdOkSearchImp.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdOkSearchImp.Location = New System.Drawing.Point(252, 15)
        Me.cmdOkSearchImp.Name = "cmdOkSearchImp"
        Me.cmdOkSearchImp.Size = New System.Drawing.Size(34, 31)
        Me.cmdOkSearchImp.TabIndex = 223
        Me.cmdOkSearchImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdOkSearchImp.ThemeName = "ThemeCmdRecubeYEL"
        '
        'grid
        '
        Me.grid.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grid.Location = New System.Drawing.Point(20, 70)
        '
        '
        '
        Me.grid.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(1160, 435)
        Me.grid.TabIndex = 224
        Me.grid.ThemeName = "Office2013Light"
        '
        'wbG
        '
        Me.wbG.Location = New System.Drawing.Point(25, 511)
        Me.wbG.Name = "wbG"
        Me.wbG.Size = New System.Drawing.Size(70, 70)
        Me.wbG.TabIndex = 225
        Me.wbG.Text = "RadWaitingBar1"
        Me.wbG.ThemeName = "Fluent"
        Me.wbG.Visible = False
        Me.wbG.WaitingIndicators.Add(Me.DotsRingWaitingBarIndicatorElement1)
        Me.wbG.WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        Me.wbG.WaitingSpeed = 50
        Me.wbG.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsRing
        CType(Me.wbG.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingIndicatorSize = New System.Drawing.Size(100, 14)
        CType(Me.wbG.GetChildAt(0), Telerik.WinControls.UI.RadWaitingBarElement).WaitingSpeed = 50
        CType(Me.wbG.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarContentElement).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsRing
        CType(Me.wbG.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.WaitingBarSeparatorElement).Dash = False
        '
        'DotsRingWaitingBarIndicatorElement1
        '
        Me.DotsRingWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsRingWaitingBarIndicatorElement1.DotRadius = 10
        Me.DotsRingWaitingBarIndicatorElement1.Name = "DotsRingWaitingBarIndicatorElement1"
        Me.DotsRingWaitingBarIndicatorElement1.Radius = 30
        Me.DotsRingWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.DotsRingWaitingBarIndicatorElement1.UseCompatibleTextRendering = False
        '
        'RadLabel7
        '
        Me.RadLabel7.ForeColor = System.Drawing.Color.DimGray
        Me.RadLabel7.Location = New System.Drawing.Point(403, 19)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(111, 21)
        Me.RadLabel7.TabIndex = 227
        Me.RadLabel7.Text = "Squadra Tecnici"
        Me.RadLabel7.ThemeName = "MaterialTeal"
        '
        'cmbSquadre
        '
        Me.cmbSquadre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbSquadre.AutoSize = False
        Me.cmbSquadre.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cmbSquadre.ForeColor = System.Drawing.Color.Black
        Me.cmbSquadre.Location = New System.Drawing.Point(519, 12)
        Me.cmbSquadre.Name = "cmbSquadre"
        Me.cmbSquadre.NullText = "Seleziona un valore"
        Me.cmbSquadre.Size = New System.Drawing.Size(266, 36)
        Me.cmbSquadre.TabIndex = 226
        Me.cmbSquadre.ThemeName = "Fluent"
        CType(Me.cmbSquadre.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.StackLayoutElement).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        CType(Me.cmbSquadre.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).NullText = "Seleziona un valore"
        CType(Me.cmbSquadre.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Segoe UI", 11.25!)
        '
        'FrmChiusuraVisite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1205, 585)
        Me.Controls.Add(Me.RadLabel7)
        Me.Controls.Add(Me.cmbSquadre)
        Me.Controls.Add(Me.wbG)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.cmdOkSearchImp)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.cmdAnnulla)
        Me.Controls.Add(Me.cmdConferma)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmChiusuraVisite"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chiusura visite"
        Me.ThemeName = "MaterialBlueGrey"
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdAnnulla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdConferma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOkSearchImp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wbG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSquadre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FluentDarkTheme1 As Telerik.WinControls.Themes.FluentDarkTheme
    Friend WithEvents VisualStudio2012LightTheme1 As Telerik.WinControls.Themes.VisualStudio2012LightTheme
    Friend WithEvents FluentTheme1 As Telerik.WinControls.Themes.FluentTheme
    Friend WithEvents MaterialTealTheme1 As Telerik.WinControls.Themes.MaterialTealTheme
    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
    Friend WithEvents t1 As Timer
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtData As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents cmdAnnulla As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdConferma As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdOkSearchImp As Telerik.WinControls.UI.RadButton
    Friend WithEvents grid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents wbG As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents DotsRingWaitingBarIndicatorElement1 As Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement
    Friend WithEvents Office2013LightTheme1 As Telerik.WinControls.Themes.Office2013LightTheme
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbSquadre As Telerik.WinControls.UI.RadDropDownList
End Class

