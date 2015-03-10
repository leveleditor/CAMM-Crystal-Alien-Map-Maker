<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMEditor
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container
        Dim LBLx As System.Windows.Forms.Label
        Dim LBLTools As System.Windows.Forms.Label
        Dim LBLWidth As System.Windows.Forms.Label
        Dim LBLHeight As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMEditor))
        Me.PICMap = New System.Windows.Forms.PictureBox
        Me.PICActive = New System.Windows.Forms.PictureBox
        Me.LBLSelected = New System.Windows.Forms.Label
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.LBLCursorLoc = New System.Windows.Forms.ToolStripStatusLabel
        Me.LBLAboutVersion = New System.Windows.Forms.ToolStripStatusLabel
        Me.CMDToolErase = New System.Windows.Forms.Button
        Me.PNLMap = New System.Windows.Forms.Panel
        Me.PNLTiles = New System.Windows.Forms.Panel
        Me.PICTiles = New System.Windows.Forms.PictureBox
        Me.MNUMain = New System.Windows.Forms.MenuStrip
        Me.MNUFile = New System.Windows.Forms.ToolStripMenuItem
        Me.CMDNew = New System.Windows.Forms.ToolStripMenuItem
        Me.CMDOpen = New System.Windows.Forms.ToolStripMenuItem
        Me.CMDSave = New System.Windows.Forms.ToolStripMenuItem
        Me.CMDSaveAs = New System.Windows.Forms.ToolStripMenuItem
        Me.Separator1 = New System.Windows.Forms.ToolStripSeparator
        Me.MNUImport = New System.Windows.Forms.ToolStripMenuItem
        Me.CMDImportAS = New System.Windows.Forms.ToolStripMenuItem
        Me.MNUExport = New System.Windows.Forms.ToolStripMenuItem
        Me.CMDExportPNG = New System.Windows.Forms.ToolStripMenuItem
        Me.CMDExportAS = New System.Windows.Forms.ToolStripMenuItem
        Me.Separator2 = New System.Windows.Forms.ToolStripSeparator
        Me.CMDExit = New System.Windows.Forms.ToolStripMenuItem
        Me.Separator5 = New System.Windows.Forms.ToolStripSeparator
        Me.MNUEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.CMDMapProperties = New System.Windows.Forms.ToolStripMenuItem
        Me.Separator6 = New System.Windows.Forms.ToolStripSeparator
        Me.MNUView = New System.Windows.Forms.ToolStripMenuItem
        Me.MNUCHKGrid = New System.Windows.Forms.ToolStripMenuItem
        Me.MNUCHKDebugBuildingPos = New System.Windows.Forms.ToolStripMenuItem
        Me.Separator7 = New System.Windows.Forms.ToolStripSeparator
        Me.MNUHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.CMDAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.Separator4 = New System.Windows.Forms.ToolStripSeparator
        Me.CHKAssociateFileTypeCAMM = New System.Windows.Forms.ToolStripMenuItem
        Me.CHKAssociateFileTypeMap = New System.Windows.Forms.ToolStripMenuItem
        Me.Separator8 = New System.Windows.Forms.ToolStripSeparator
        Me.MNUDev = New System.Windows.Forms.ToolStripMenuItem
        Me.CMDTileDataEditor = New System.Windows.Forms.ToolStripMenuItem
        Me.CMDDeveloper = New System.Windows.Forms.ToolStripMenuItem
        Me.Separator3 = New System.Windows.Forms.ToolStripSeparator
        Me.CMDEditBuildings = New System.Windows.Forms.Button
        Me.CMDEditTiles = New System.Windows.Forms.Button
        Me.CMDEditShroud = New System.Windows.Forms.Button
        Me.PNLBuildings = New System.Windows.Forms.Panel
        Me.PICBuildings = New System.Windows.Forms.PictureBox
        Me.TXTHeight = New System.Windows.Forms.TextBox
        Me.TXTWidth = New System.Windows.Forms.TextBox
        Me.CMDSize = New System.Windows.Forms.Button
        Me.SaveMap = New System.Windows.Forms.SaveFileDialog
        Me.OpenMap = New System.Windows.Forms.OpenFileDialog
        Me.CHKGrid = New System.Windows.Forms.CheckBox
        Me.CMDToolSmartBrush = New System.Windows.Forms.Button
        Me.CMDToolBrush = New System.Windows.Forms.Button
        Me.IntroTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CMDEditUnits = New System.Windows.Forms.Button
        Me.PNLUnits = New System.Windows.Forms.Panel
        Me.PICUnits = New System.Windows.Forms.PictureBox
        Me.SavePNG = New System.Windows.Forms.SaveFileDialog
        Me.MapTabs = New System.Windows.Forms.TabControl
        LBLx = New System.Windows.Forms.Label
        LBLTools = New System.Windows.Forms.Label
        LBLWidth = New System.Windows.Forms.Label
        LBLHeight = New System.Windows.Forms.Label
        CType(Me.PICMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PICActive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusBar.SuspendLayout()
        Me.PNLMap.SuspendLayout()
        Me.PNLTiles.SuspendLayout()
        CType(Me.PICTiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MNUMain.SuspendLayout()
        Me.PNLBuildings.SuspendLayout()
        CType(Me.PICBuildings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNLUnits.SuspendLayout()
        CType(Me.PICUnits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LBLx
        '
        LBLx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        LBLx.AutoSize = True
        LBLx.Location = New System.Drawing.Point(597, 48)
        LBLx.Name = "LBLx"
        LBLx.Size = New System.Drawing.Size(12, 13)
        LBLx.TabIndex = 10
        LBLx.Text = "x"
        '
        'LBLTools
        '
        LBLTools.AutoSize = True
        LBLTools.Location = New System.Drawing.Point(108, 74)
        LBLTools.Name = "LBLTools"
        LBLTools.Size = New System.Drawing.Size(36, 13)
        LBLTools.TabIndex = 17
        LBLTools.Text = "Tools:"
        '
        'LBLWidth
        '
        LBLWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        LBLWidth.Location = New System.Drawing.Point(547, 31)
        LBLWidth.Name = "LBLWidth"
        LBLWidth.Size = New System.Drawing.Size(42, 13)
        LBLWidth.TabIndex = 18
        LBLWidth.Text = "Width"
        LBLWidth.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'LBLHeight
        '
        LBLHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        LBLHeight.Location = New System.Drawing.Point(610, 31)
        LBLHeight.Name = "LBLHeight"
        LBLHeight.Size = New System.Drawing.Size(42, 13)
        LBLHeight.TabIndex = 19
        LBLHeight.Text = "Height"
        LBLHeight.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PICMap
        '
        Me.PICMap.Location = New System.Drawing.Point(0, 0)
        Me.PICMap.Margin = New System.Windows.Forms.Padding(0)
        Me.PICMap.Name = "PICMap"
        Me.PICMap.Size = New System.Drawing.Size(740, 328)
        Me.PICMap.TabIndex = 0
        Me.PICMap.TabStop = False
        '
        'PICActive
        '
        Me.PICActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PICActive.Location = New System.Drawing.Point(9, 43)
        Me.PICActive.Margin = New System.Windows.Forms.Padding(0)
        Me.PICActive.Name = "PICActive"
        Me.PICActive.Size = New System.Drawing.Size(96, 48)
        Me.PICActive.TabIndex = 1
        Me.PICActive.TabStop = False
        '
        'LBLSelected
        '
        Me.LBLSelected.AutoSize = True
        Me.LBLSelected.Location = New System.Drawing.Point(7, 30)
        Me.LBLSelected.Name = "LBLSelected"
        Me.LBLSelected.Size = New System.Drawing.Size(72, 13)
        Me.LBLSelected.TabIndex = 1
        Me.LBLSelected.Text = "Selected Tile:"
        '
        'StatusBar
        '
        Me.StatusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LBLCursorLoc, Me.LBLAboutVersion})
        Me.StatusBar.Location = New System.Drawing.Point(0, 430)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusBar.Size = New System.Drawing.Size(766, 22)
        Me.StatusBar.TabIndex = 8
        Me.StatusBar.Text = "StatusStrip1"
        '
        'LBLCursorLoc
        '
        Me.LBLCursorLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LBLCursorLoc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LBLCursorLoc.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.LBLCursorLoc.Name = "LBLCursorLoc"
        Me.LBLCursorLoc.Size = New System.Drawing.Size(18, 17)
        Me.LBLCursorLoc.Text = "[ ]"
        '
        'LBLAboutVersion
        '
        Me.LBLAboutVersion.Name = "LBLAboutVersion"
        Me.LBLAboutVersion.Size = New System.Drawing.Size(733, 17)
        Me.LBLAboutVersion.Spring = True
        Me.LBLAboutVersion.Text = "<Version> by Josh"
        Me.LBLAboutVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMDToolErase
        '
        Me.CMDToolErase.AutoSize = True
        Me.CMDToolErase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CMDToolErase.Location = New System.Drawing.Point(191, 69)
        Me.CMDToolErase.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.CMDToolErase.Name = "CMDToolErase"
        Me.CMDToolErase.Size = New System.Drawing.Size(47, 23)
        Me.CMDToolErase.TabIndex = 5
        Me.CMDToolErase.Text = "Eraser"
        '
        'PNLMap
        '
        Me.PNLMap.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNLMap.AutoScroll = True
        Me.PNLMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNLMap.Controls.Add(Me.PICMap)
        Me.PNLMap.Location = New System.Drawing.Point(134, 117)
        Me.PNLMap.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.PNLMap.Name = "PNLMap"
        Me.PNLMap.Size = New System.Drawing.Size(623, 308)
        Me.PNLMap.TabIndex = 7
        '
        'PNLTiles
        '
        Me.PNLTiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PNLTiles.AutoScroll = True
        Me.PNLTiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNLTiles.Controls.Add(Me.PICTiles)
        Me.PNLTiles.Location = New System.Drawing.Point(9, 117)
        Me.PNLTiles.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.PNLTiles.Name = "PNLTiles"
        Me.PNLTiles.Size = New System.Drawing.Size(121, 308)
        Me.PNLTiles.TabIndex = 6
        '
        'PICTiles
        '
        Me.PICTiles.Location = New System.Drawing.Point(0, 0)
        Me.PICTiles.Margin = New System.Windows.Forms.Padding(0)
        Me.PICTiles.Name = "PICTiles"
        Me.PICTiles.Size = New System.Drawing.Size(96, 800)
        Me.PICTiles.TabIndex = 5
        Me.PICTiles.TabStop = False
        '
        'MNUMain
        '
        Me.MNUMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MNUFile, Me.Separator5, Me.MNUEdit, Me.Separator6, Me.MNUView, Me.Separator7, Me.MNUHelp, Me.Separator8, Me.MNUDev, Me.Separator3})
        Me.MNUMain.Location = New System.Drawing.Point(0, 0)
        Me.MNUMain.Name = "MNUMain"
        Me.MNUMain.Padding = New System.Windows.Forms.Padding(0)
        Me.MNUMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MNUMain.Size = New System.Drawing.Size(766, 24)
        Me.MNUMain.TabIndex = 0
        Me.MNUMain.Text = "MenuStrip1"
        '
        'MNUFile
        '
        Me.MNUFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMDNew, Me.CMDOpen, Me.CMDSave, Me.CMDSaveAs, Me.Separator1, Me.MNUImport, Me.MNUExport, Me.Separator2, Me.CMDExit})
        Me.MNUFile.Name = "MNUFile"
        Me.MNUFile.Size = New System.Drawing.Size(37, 24)
        Me.MNUFile.Text = "&File"
        '
        'CMDNew
        '
        Me.CMDNew.Name = "CMDNew"
        Me.CMDNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.CMDNew.Size = New System.Drawing.Size(155, 22)
        Me.CMDNew.Text = "&New"
        '
        'CMDOpen
        '
        Me.CMDOpen.Name = "CMDOpen"
        Me.CMDOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.CMDOpen.Size = New System.Drawing.Size(155, 22)
        Me.CMDOpen.Text = "&Open..."
        '
        'CMDSave
        '
        Me.CMDSave.Name = "CMDSave"
        Me.CMDSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.CMDSave.Size = New System.Drawing.Size(155, 22)
        Me.CMDSave.Text = "&Save"
        '
        'CMDSaveAs
        '
        Me.CMDSaveAs.Name = "CMDSaveAs"
        Me.CMDSaveAs.Size = New System.Drawing.Size(155, 22)
        Me.CMDSaveAs.Text = "Save &As..."
        '
        'Separator1
        '
        Me.Separator1.Name = "Separator1"
        Me.Separator1.Size = New System.Drawing.Size(152, 6)
        '
        'MNUImport
        '
        Me.MNUImport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMDImportAS})
        Me.MNUImport.Name = "MNUImport"
        Me.MNUImport.Size = New System.Drawing.Size(155, 22)
        Me.MNUImport.Text = "&Import"
        Me.MNUImport.Visible = False
        '
        'CMDImportAS
        '
        Me.CMDImportAS.Name = "CMDImportAS"
        Me.CMDImportAS.Size = New System.Drawing.Size(170, 22)
        Me.CMDImportAS.Text = "ActionScript Code"
        '
        'MNUExport
        '
        Me.MNUExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMDExportPNG, Me.CMDExportAS})
        Me.MNUExport.Name = "MNUExport"
        Me.MNUExport.Size = New System.Drawing.Size(155, 22)
        Me.MNUExport.Text = "&Export"
        '
        'CMDExportPNG
        '
        Me.CMDExportPNG.Name = "CMDExportPNG"
        Me.CMDExportPNG.Size = New System.Drawing.Size(170, 22)
        Me.CMDExportPNG.Text = "PNG Image [.png]"
        '
        'CMDExportAS
        '
        Me.CMDExportAS.Name = "CMDExportAS"
        Me.CMDExportAS.Size = New System.Drawing.Size(170, 22)
        Me.CMDExportAS.Text = "ActionScript Code"
        Me.CMDExportAS.Visible = False
        '
        'Separator2
        '
        Me.Separator2.Name = "Separator2"
        Me.Separator2.Size = New System.Drawing.Size(152, 6)
        '
        'CMDExit
        '
        Me.CMDExit.Name = "CMDExit"
        Me.CMDExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.CMDExit.Size = New System.Drawing.Size(155, 22)
        Me.CMDExit.Text = "E&xit"
        '
        'Separator5
        '
        Me.Separator5.AutoSize = False
        Me.Separator5.Name = "Separator5"
        Me.Separator5.Size = New System.Drawing.Size(3, 24)
        '
        'MNUEdit
        '
        Me.MNUEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMDMapProperties})
        Me.MNUEdit.Name = "MNUEdit"
        Me.MNUEdit.Size = New System.Drawing.Size(39, 24)
        Me.MNUEdit.Text = "&Edit"
        '
        'CMDMapProperties
        '
        Me.CMDMapProperties.Name = "CMDMapProperties"
        Me.CMDMapProperties.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.CMDMapProperties.Size = New System.Drawing.Size(208, 22)
        Me.CMDMapProperties.Text = "&Map Properties..."
        '
        'Separator6
        '
        Me.Separator6.AutoSize = False
        Me.Separator6.Name = "Separator6"
        Me.Separator6.Size = New System.Drawing.Size(3, 24)
        '
        'MNUView
        '
        Me.MNUView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MNUCHKGrid, Me.MNUCHKDebugBuildingPos})
        Me.MNUView.Name = "MNUView"
        Me.MNUView.Size = New System.Drawing.Size(44, 24)
        Me.MNUView.Text = "&View"
        '
        'MNUCHKGrid
        '
        Me.MNUCHKGrid.Checked = True
        Me.MNUCHKGrid.CheckOnClick = True
        Me.MNUCHKGrid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MNUCHKGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.MNUCHKGrid.Name = "MNUCHKGrid"
        Me.MNUCHKGrid.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.MNUCHKGrid.Size = New System.Drawing.Size(247, 22)
        Me.MNUCHKGrid.Text = "Show &Grid"
        '
        'MNUCHKDebugBuildingPos
        '
        Me.MNUCHKDebugBuildingPos.CheckOnClick = True
        Me.MNUCHKDebugBuildingPos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.MNUCHKDebugBuildingPos.Name = "MNUCHKDebugBuildingPos"
        Me.MNUCHKDebugBuildingPos.Size = New System.Drawing.Size(247, 22)
        Me.MNUCHKDebugBuildingPos.Text = "Debug - Show Building Positions"
        Me.MNUCHKDebugBuildingPos.Visible = False
        '
        'Separator7
        '
        Me.Separator7.AutoSize = False
        Me.Separator7.Name = "Separator7"
        Me.Separator7.Size = New System.Drawing.Size(3, 24)
        '
        'MNUHelp
        '
        Me.MNUHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMDAbout, Me.Separator4, Me.CHKAssociateFileTypeCAMM, Me.CHKAssociateFileTypeMap})
        Me.MNUHelp.Name = "MNUHelp"
        Me.MNUHelp.Size = New System.Drawing.Size(44, 24)
        Me.MNUHelp.Text = "&Help"
        '
        'CMDAbout
        '
        Me.CMDAbout.Enabled = False
        Me.CMDAbout.Name = "CMDAbout"
        Me.CMDAbout.Size = New System.Drawing.Size(209, 22)
        Me.CMDAbout.Text = "&About CAMM..."
        '
        'Separator4
        '
        Me.Separator4.Name = "Separator4"
        Me.Separator4.Size = New System.Drawing.Size(206, 6)
        '
        'CHKAssociateFileTypeCAMM
        '
        Me.CHKAssociateFileTypeCAMM.CheckOnClick = True
        Me.CHKAssociateFileTypeCAMM.Name = "CHKAssociateFileTypeCAMM"
        Me.CHKAssociateFileTypeCAMM.Size = New System.Drawing.Size(209, 22)
        Me.CHKAssociateFileTypeCAMM.Text = "Associate file type .camm"
        '
        'CHKAssociateFileTypeMap
        '
        Me.CHKAssociateFileTypeMap.CheckOnClick = True
        Me.CHKAssociateFileTypeMap.Enabled = False
        Me.CHKAssociateFileTypeMap.Name = "CHKAssociateFileTypeMap"
        Me.CHKAssociateFileTypeMap.Size = New System.Drawing.Size(209, 22)
        Me.CHKAssociateFileTypeMap.Text = "Associate file type .map"
        Me.CHKAssociateFileTypeMap.Visible = False
        '
        'Separator8
        '
        Me.Separator8.AutoSize = False
        Me.Separator8.Name = "Separator8"
        Me.Separator8.Size = New System.Drawing.Size(3, 24)
        '
        'MNUDev
        '
        Me.MNUDev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.MNUDev.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMDTileDataEditor, Me.CMDDeveloper})
        Me.MNUDev.Name = "MNUDev"
        Me.MNUDev.Size = New System.Drawing.Size(39, 24)
        Me.MNUDev.Text = "Dev"
        Me.MNUDev.Visible = False
        '
        'CMDTileDataEditor
        '
        Me.CMDTileDataEditor.Name = "CMDTileDataEditor"
        Me.CMDTileDataEditor.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.CMDTileDataEditor.Size = New System.Drawing.Size(250, 22)
        Me.CMDTileDataEditor.Text = "&Tile Data Editor [Tiles.dat]"
        '
        'CMDDeveloper
        '
        Me.CMDDeveloper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CMDDeveloper.Name = "CMDDeveloper"
        Me.CMDDeveloper.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.CMDDeveloper.Size = New System.Drawing.Size(250, 22)
        Me.CMDDeveloper.Text = "Activate Dev Mode"
        Me.CMDDeveloper.Visible = False
        '
        'Separator3
        '
        Me.Separator3.AutoSize = False
        Me.Separator3.Name = "Separator3"
        Me.Separator3.Size = New System.Drawing.Size(3, 24)
        Me.Separator3.Visible = False
        '
        'CMDEditBuildings
        '
        Me.CMDEditBuildings.AutoSize = True
        Me.CMDEditBuildings.Location = New System.Drawing.Point(191, 43)
        Me.CMDEditBuildings.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.CMDEditBuildings.Name = "CMDEditBuildings"
        Me.CMDEditBuildings.Size = New System.Drawing.Size(80, 23)
        Me.CMDEditBuildings.TabIndex = 3
        Me.CMDEditBuildings.Text = "Edit Buildings"
        Me.CMDEditBuildings.UseVisualStyleBackColor = True
        '
        'CMDEditTiles
        '
        Me.CMDEditTiles.AutoSize = True
        Me.CMDEditTiles.Enabled = False
        Me.CMDEditTiles.Location = New System.Drawing.Point(108, 43)
        Me.CMDEditTiles.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.CMDEditTiles.Name = "CMDEditTiles"
        Me.CMDEditTiles.Size = New System.Drawing.Size(80, 23)
        Me.CMDEditTiles.TabIndex = 2
        Me.CMDEditTiles.Text = "Edit Tiles"
        Me.CMDEditTiles.UseVisualStyleBackColor = True
        '
        'CMDEditShroud
        '
        Me.CMDEditShroud.AutoSize = True
        Me.CMDEditShroud.Enabled = False
        Me.CMDEditShroud.Location = New System.Drawing.Point(357, 43)
        Me.CMDEditShroud.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.CMDEditShroud.Name = "CMDEditShroud"
        Me.CMDEditShroud.Size = New System.Drawing.Size(80, 23)
        Me.CMDEditShroud.TabIndex = 4
        Me.CMDEditShroud.Text = "Edit Shroud"
        Me.CMDEditShroud.UseVisualStyleBackColor = True
        Me.CMDEditShroud.Visible = False
        '
        'PNLBuildings
        '
        Me.PNLBuildings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PNLBuildings.AutoScroll = True
        Me.PNLBuildings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNLBuildings.Controls.Add(Me.PICBuildings)
        Me.PNLBuildings.Location = New System.Drawing.Point(9, 117)
        Me.PNLBuildings.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.PNLBuildings.Name = "PNLBuildings"
        Me.PNLBuildings.Size = New System.Drawing.Size(121, 308)
        Me.PNLBuildings.TabIndex = 9
        Me.PNLBuildings.Visible = False
        '
        'PICBuildings
        '
        Me.PICBuildings.Location = New System.Drawing.Point(0, 0)
        Me.PICBuildings.Margin = New System.Windows.Forms.Padding(0)
        Me.PICBuildings.Name = "PICBuildings"
        Me.PICBuildings.Size = New System.Drawing.Size(96, 800)
        Me.PICBuildings.TabIndex = 5
        Me.PICBuildings.TabStop = False
        '
        'TXTHeight
        '
        Me.TXTHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTHeight.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHeight.Location = New System.Drawing.Point(612, 45)
        Me.TXTHeight.MaxLength = 3
        Me.TXTHeight.Name = "TXTHeight"
        Me.TXTHeight.Size = New System.Drawing.Size(42, 20)
        Me.TXTHeight.TabIndex = 2
        Me.TXTHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TXTWidth
        '
        Me.TXTWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTWidth.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWidth.Location = New System.Drawing.Point(549, 45)
        Me.TXTWidth.MaxLength = 3
        Me.TXTWidth.Name = "TXTWidth"
        Me.TXTWidth.Size = New System.Drawing.Size(42, 20)
        Me.TXTWidth.TabIndex = 1
        Me.TXTWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CMDSize
        '
        Me.CMDSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDSize.AutoSize = True
        Me.CMDSize.Location = New System.Drawing.Point(657, 43)
        Me.CMDSize.Margin = New System.Windows.Forms.Padding(0)
        Me.CMDSize.Name = "CMDSize"
        Me.CMDSize.Size = New System.Drawing.Size(100, 23)
        Me.CMDSize.TabIndex = 0
        Me.CMDSize.Text = "Change Size"
        Me.CMDSize.UseVisualStyleBackColor = True
        '
        'SaveMap
        '
        Me.SaveMap.DefaultExt = "CAMM Map Files|*.camm"
        Me.SaveMap.FileName = "Map1.camm"
        Me.SaveMap.Filter = "CAMM Map Files|*.camm|CAMM Legacy Map File|*.map|All Files|*.*"
        Me.SaveMap.Title = "Select where to save the map file..."
        '
        'OpenMap
        '
        Me.OpenMap.DefaultExt = "CAMM Map Files|*.camm;*.map"
        Me.OpenMap.FileName = "Map1.camm"
        Me.OpenMap.Filter = "CAMM Map Files|*.camm;*.map|All Files|*.*"
        Me.OpenMap.Title = "Select a map file to open..."
        '
        'CHKGrid
        '
        Me.CHKGrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CHKGrid.AutoSize = True
        Me.CHKGrid.Checked = True
        Me.CHKGrid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKGrid.Location = New System.Drawing.Point(468, 47)
        Me.CHKGrid.Name = "CHKGrid"
        Me.CHKGrid.Size = New System.Drawing.Size(75, 17)
        Me.CHKGrid.TabIndex = 12
        Me.CHKGrid.Text = "Show Grid"
        Me.CHKGrid.UseVisualStyleBackColor = True
        '
        'CMDToolSmartBrush
        '
        Me.CMDToolSmartBrush.AutoSize = True
        Me.CMDToolSmartBrush.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CMDToolSmartBrush.Enabled = False
        Me.CMDToolSmartBrush.Location = New System.Drawing.Point(241, 69)
        Me.CMDToolSmartBrush.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.CMDToolSmartBrush.Name = "CMDToolSmartBrush"
        Me.CMDToolSmartBrush.Size = New System.Drawing.Size(74, 23)
        Me.CMDToolSmartBrush.TabIndex = 1
        Me.CMDToolSmartBrush.Text = "Smart Brush"
        Me.CMDToolSmartBrush.UseVisualStyleBackColor = True
        Me.CMDToolSmartBrush.Visible = False
        '
        'CMDToolBrush
        '
        Me.CMDToolBrush.AutoSize = True
        Me.CMDToolBrush.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CMDToolBrush.Enabled = False
        Me.CMDToolBrush.Location = New System.Drawing.Point(144, 69)
        Me.CMDToolBrush.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.CMDToolBrush.Name = "CMDToolBrush"
        Me.CMDToolBrush.Size = New System.Drawing.Size(44, 23)
        Me.CMDToolBrush.TabIndex = 0
        Me.CMDToolBrush.Text = "Brush"
        Me.CMDToolBrush.UseVisualStyleBackColor = True
        '
        'IntroTimer
        '
        Me.IntroTimer.Interval = 15
        '
        'CMDEditUnits
        '
        Me.CMDEditUnits.AutoSize = True
        Me.CMDEditUnits.Location = New System.Drawing.Point(274, 43)
        Me.CMDEditUnits.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.CMDEditUnits.Name = "CMDEditUnits"
        Me.CMDEditUnits.Size = New System.Drawing.Size(80, 23)
        Me.CMDEditUnits.TabIndex = 15
        Me.CMDEditUnits.Text = "Edit Units"
        Me.CMDEditUnits.UseVisualStyleBackColor = True
        '
        'PNLUnits
        '
        Me.PNLUnits.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PNLUnits.AutoScroll = True
        Me.PNLUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PNLUnits.Controls.Add(Me.PICUnits)
        Me.PNLUnits.Location = New System.Drawing.Point(9, 117)
        Me.PNLUnits.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.PNLUnits.Name = "PNLUnits"
        Me.PNLUnits.Size = New System.Drawing.Size(121, 308)
        Me.PNLUnits.TabIndex = 16
        Me.PNLUnits.Visible = False
        '
        'PICUnits
        '
        Me.PICUnits.Location = New System.Drawing.Point(0, 0)
        Me.PICUnits.Margin = New System.Windows.Forms.Padding(0)
        Me.PICUnits.Name = "PICUnits"
        Me.PICUnits.Size = New System.Drawing.Size(96, 800)
        Me.PICUnits.TabIndex = 5
        Me.PICUnits.TabStop = False
        '
        'SavePNG
        '
        Me.SavePNG.DefaultExt = "PNG Images|*.png"
        Me.SavePNG.FileName = "Map1.png"
        Me.SavePNG.Filter = "PNG Images|*png"
        Me.SavePNG.Title = "Export PNG Image..."
        '
        'MapTabs
        '
        Me.MapTabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MapTabs.Location = New System.Drawing.Point(132, 95)
        Me.MapTabs.Name = "MapTabs"
        Me.MapTabs.SelectedIndex = 0
        Me.MapTabs.ShowToolTips = True
        Me.MapTabs.Size = New System.Drawing.Size(629, 333)
        Me.MapTabs.TabIndex = 20
        '
        'FRMEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 452)
        Me.Controls.Add(LBLHeight)
        Me.Controls.Add(LBLWidth)
        Me.Controls.Add(LBLTools)
        Me.Controls.Add(Me.CMDToolSmartBrush)
        Me.Controls.Add(Me.PNLUnits)
        Me.Controls.Add(Me.CMDToolBrush)
        Me.Controls.Add(Me.CMDToolErase)
        Me.Controls.Add(Me.CMDEditUnits)
        Me.Controls.Add(Me.CHKGrid)
        Me.Controls.Add(LBLx)
        Me.Controls.Add(Me.TXTHeight)
        Me.Controls.Add(Me.TXTWidth)
        Me.Controls.Add(Me.CMDSize)
        Me.Controls.Add(Me.CMDEditShroud)
        Me.Controls.Add(Me.CMDEditTiles)
        Me.Controls.Add(Me.CMDEditBuildings)
        Me.Controls.Add(Me.MNUMain)
        Me.Controls.Add(Me.PNLMap)
        Me.Controls.Add(Me.PNLTiles)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.LBLSelected)
        Me.Controls.Add(Me.PICActive)
        Me.Controls.Add(Me.PNLBuildings)
        Me.Controls.Add(Me.MapTabs)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MNUMain
        Me.Name = "FRMEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CAMM (Crystal Alien Map Maker)"
        CType(Me.PICMap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PICActive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.PNLMap.ResumeLayout(False)
        Me.PNLTiles.ResumeLayout(False)
        CType(Me.PICTiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MNUMain.ResumeLayout(False)
        Me.MNUMain.PerformLayout()
        Me.PNLBuildings.ResumeLayout(False)
        CType(Me.PICBuildings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNLUnits.ResumeLayout(False)
        CType(Me.PICUnits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PICMap As System.Windows.Forms.PictureBox
    Friend WithEvents PICActive As System.Windows.Forms.PictureBox
    Friend WithEvents LBLSelected As System.Windows.Forms.Label
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents LBLCursorLoc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LBLAboutVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CMDToolErase As System.Windows.Forms.Button
    Friend WithEvents PNLMap As System.Windows.Forms.Panel
    Friend WithEvents PNLTiles As System.Windows.Forms.Panel
    Friend WithEvents PICTiles As System.Windows.Forms.PictureBox
    Friend WithEvents MNUMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MNUFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMDOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Separator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMDSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMDSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Separator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMDExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMDEditBuildings As System.Windows.Forms.Button
    Friend WithEvents CMDEditTiles As System.Windows.Forms.Button
    Friend WithEvents CMDEditShroud As System.Windows.Forms.Button
    Friend WithEvents PNLBuildings As System.Windows.Forms.Panel
    Friend WithEvents PICBuildings As System.Windows.Forms.PictureBox
    Friend WithEvents TXTHeight As System.Windows.Forms.TextBox
    Friend WithEvents TXTWidth As System.Windows.Forms.TextBox
    Friend WithEvents CMDSize As System.Windows.Forms.Button
    Friend WithEvents SaveMap As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenMap As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CHKGrid As System.Windows.Forms.CheckBox
    Friend WithEvents MNUDev As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMDTileDataEditor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMDToolBrush As System.Windows.Forms.Button
    Friend WithEvents IntroTimer As System.Windows.Forms.Timer
    Friend WithEvents CMDToolSmartBrush As System.Windows.Forms.Button
    Friend WithEvents CMDEditUnits As System.Windows.Forms.Button
    Friend WithEvents PNLUnits As System.Windows.Forms.Panel
    Friend WithEvents PICUnits As System.Windows.Forms.PictureBox
    Friend WithEvents CMDNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNUEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNUView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNUHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNUCHKGrid As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMDMapProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMDAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNUExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMDExportPNG As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SavePNG As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MNUImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMDImportAS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMDDeveloper As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMDExportAS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNUCHKDebugBuildingPos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Separator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CHKAssociateFileTypeCAMM As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CHKAssociateFileTypeMap As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Separator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Separator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Separator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Separator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Separator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MapTabs As System.Windows.Forms.TabControl
End Class
