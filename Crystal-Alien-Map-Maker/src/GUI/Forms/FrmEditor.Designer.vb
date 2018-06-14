<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEditor
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEditor))
        Me.lblx = New System.Windows.Forms.Label()
        Me.lblTools = New System.Windows.Forms.Label()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.picMap = New System.Windows.Forms.PictureBox()
        Me.ctxMap = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.lblMapNoActionsAvailable = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnMapUnitProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxMapSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMapDeleteObject = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxMapSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMapCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.picActive = New System.Windows.Forms.PictureBox()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.staInfoBar = New System.Windows.Forms.StatusStrip()
        Me.lblCursorLoc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblAboutVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnToolErase = New System.Windows.Forms.Button()
        Me.pnlMap = New System.Windows.Forms.Panel()
        Me.pnlTiles = New System.Windows.Forms.Panel()
        Me.picTiles = New System.Windows.Forms.PictureBox()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNewFromTemplate = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.separator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImportAS = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExportPNG = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExportAS = New System.Windows.Forms.ToolStripMenuItem()
        Me.separator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.separator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDeleteSelectedObject = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnUnitProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.separator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMapProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.separator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuchkGrid = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuchkShadows = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuchkTeamIndicators = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuchkDebugBuildingPos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuchkDebugUnitPos = New System.Windows.Forms.ToolStripMenuItem()
        Me.separator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.separator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.chkAssociateFileTypeCAMM = New System.Windows.Forms.ToolStripMenuItem()
        Me.separator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDev = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnConfigEditor = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDeveloper = New System.Windows.Forms.ToolStripMenuItem()
        Me.separator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEditBuildings = New System.Windows.Forms.Button()
        Me.btnEditTiles = New System.Windows.Forms.Button()
        Me.btnEditShroud = New System.Windows.Forms.Button()
        Me.pnlBuildings = New System.Windows.Forms.Panel()
        Me.picBuildings = New System.Windows.Forms.PictureBox()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.btnSize = New System.Windows.Forms.Button()
        Me.saveMap = New System.Windows.Forms.SaveFileDialog()
        Me.openMap = New System.Windows.Forms.OpenFileDialog()
        Me.chkGrid = New System.Windows.Forms.CheckBox()
        Me.btnToolSmartBrush = New System.Windows.Forms.Button()
        Me.btnToolBrush = New System.Windows.Forms.Button()
        Me.tmrIntro = New System.Windows.Forms.Timer(Me.components)
        Me.btnEditUnits = New System.Windows.Forms.Button()
        Me.pnlUnits = New System.Windows.Forms.Panel()
        Me.picUnits = New System.Windows.Forms.PictureBox()
        Me.savePng = New System.Windows.Forms.SaveFileDialog()
        Me.mapTabs = New System.Windows.Forms.TabControl()
        Me.ctxMapTabs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCloseAllExceptThis = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCloseAllLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCloseAllRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnToolPointer = New System.Windows.Forms.Button()
        Me.btnToolRectangleBrush = New System.Windows.Forms.Button()
        Me.cboRectangleBrush = New System.Windows.Forms.ComboBox()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMap.SuspendLayout()
        CType(Me.picActive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.staInfoBar.SuspendLayout()
        Me.pnlMap.SuspendLayout()
        Me.pnlTiles.SuspendLayout()
        CType(Me.picTiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuMain.SuspendLayout()
        Me.pnlBuildings.SuspendLayout()
        CType(Me.picBuildings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlUnits.SuspendLayout()
        CType(Me.picUnits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMapTabs.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblx
        '
        Me.lblx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblx.AutoSize = True
        Me.lblx.Location = New System.Drawing.Point(597, 48)
        Me.lblx.Name = "lblx"
        Me.lblx.Size = New System.Drawing.Size(12, 13)
        Me.lblx.TabIndex = 9
        Me.lblx.Text = "x"
        '
        'lblTools
        '
        Me.lblTools.AutoSize = True
        Me.lblTools.Location = New System.Drawing.Point(132, 74)
        Me.lblTools.Name = "lblTools"
        Me.lblTools.Size = New System.Drawing.Size(36, 13)
        Me.lblTools.TabIndex = 13
        Me.lblTools.Text = "Tools:"
        '
        'lblWidth
        '
        Me.lblWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWidth.Location = New System.Drawing.Point(547, 31)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(42, 13)
        Me.lblWidth.TabIndex = 7
        Me.lblWidth.Text = "Width"
        Me.lblWidth.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblHeight
        '
        Me.lblHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeight.Location = New System.Drawing.Point(610, 31)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(42, 13)
        Me.lblHeight.TabIndex = 10
        Me.lblHeight.Text = "Height"
        Me.lblHeight.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'picMap
        '
        Me.picMap.ContextMenuStrip = Me.ctxMap
        Me.picMap.Location = New System.Drawing.Point(0, 0)
        Me.picMap.Margin = New System.Windows.Forms.Padding(0)
        Me.picMap.Name = "picMap"
        Me.picMap.Size = New System.Drawing.Size(740, 328)
        Me.picMap.TabIndex = 0
        Me.picMap.TabStop = False
        '
        'ctxMap
        '
        Me.ctxMap.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblMapNoActionsAvailable, Me.btnMapUnitProperties, Me.ctxMapSeparator1, Me.btnMapDeleteObject, Me.ctxMapSeparator2, Me.btnMapCancel})
        Me.ctxMap.Name = "ctxMap"
        Me.ctxMap.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ctxMap.Size = New System.Drawing.Size(203, 104)
        '
        'lblMapNoActionsAvailable
        '
        Me.lblMapNoActionsAvailable.Enabled = False
        Me.lblMapNoActionsAvailable.Name = "lblMapNoActionsAvailable"
        Me.lblMapNoActionsAvailable.Size = New System.Drawing.Size(202, 22)
        Me.lblMapNoActionsAvailable.Text = "No actions available."
        '
        'btnMapUnitProperties
        '
        Me.btnMapUnitProperties.Enabled = False
        Me.btnMapUnitProperties.Name = "btnMapUnitProperties"
        Me.btnMapUnitProperties.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.btnMapUnitProperties.Size = New System.Drawing.Size(202, 22)
        Me.btnMapUnitProperties.Text = "Unit &Properties..."
        Me.btnMapUnitProperties.Visible = False
        '
        'ctxMapSeparator1
        '
        Me.ctxMapSeparator1.Name = "ctxMapSeparator1"
        Me.ctxMapSeparator1.Size = New System.Drawing.Size(199, 6)
        '
        'btnMapDeleteObject
        '
        Me.btnMapDeleteObject.Enabled = False
        Me.btnMapDeleteObject.Name = "btnMapDeleteObject"
        Me.btnMapDeleteObject.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.btnMapDeleteObject.Size = New System.Drawing.Size(202, 22)
        Me.btnMapDeleteObject.Text = "&Delete Object"
        Me.btnMapDeleteObject.Visible = False
        '
        'ctxMapSeparator2
        '
        Me.ctxMapSeparator2.Name = "ctxMapSeparator2"
        Me.ctxMapSeparator2.Size = New System.Drawing.Size(199, 6)
        '
        'btnMapCancel
        '
        Me.btnMapCancel.Name = "btnMapCancel"
        Me.btnMapCancel.ShortcutKeyDisplayString = "Esc"
        Me.btnMapCancel.Size = New System.Drawing.Size(202, 22)
        Me.btnMapCancel.Text = "&Cancel"
        '
        'picActive
        '
        Me.picActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picActive.Location = New System.Drawing.Point(9, 43)
        Me.picActive.Margin = New System.Windows.Forms.Padding(0)
        Me.picActive.Name = "picActive"
        Me.picActive.Size = New System.Drawing.Size(96, 48)
        Me.picActive.TabIndex = 1
        Me.picActive.TabStop = False
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Location = New System.Drawing.Point(7, 30)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(72, 13)
        Me.lblSelected.TabIndex = 1
        Me.lblSelected.Text = "Selected Tile:"
        '
        'staInfoBar
        '
        Me.staInfoBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.staInfoBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblCursorLoc, Me.lblAboutVersion})
        Me.staInfoBar.Location = New System.Drawing.Point(0, 430)
        Me.staInfoBar.Name = "staInfoBar"
        Me.staInfoBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.staInfoBar.Size = New System.Drawing.Size(766, 22)
        Me.staInfoBar.TabIndex = 22
        Me.staInfoBar.Text = "StatusStrip1"
        '
        'lblCursorLoc
        '
        Me.lblCursorLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCursorLoc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.lblCursorLoc.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.lblCursorLoc.Name = "lblCursorLoc"
        Me.lblCursorLoc.Size = New System.Drawing.Size(18, 17)
        Me.lblCursorLoc.Text = "[ ]"
        '
        'lblAboutVersion
        '
        Me.lblAboutVersion.Name = "lblAboutVersion"
        Me.lblAboutVersion.Size = New System.Drawing.Size(733, 17)
        Me.lblAboutVersion.Spring = True
        Me.lblAboutVersion.Text = "<Version> by Josh"
        Me.lblAboutVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnToolErase
        '
        Me.btnToolErase.AutoSize = True
        Me.btnToolErase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnToolErase.Location = New System.Drawing.Point(373, 69)
        Me.btnToolErase.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnToolErase.Name = "btnToolErase"
        Me.btnToolErase.Size = New System.Drawing.Size(47, 23)
        Me.btnToolErase.TabIndex = 17
        Me.btnToolErase.Text = "Eraser"
        '
        'pnlMap
        '
        Me.pnlMap.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMap.AutoScroll = True
        Me.pnlMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMap.Controls.Add(Me.picMap)
        Me.pnlMap.Location = New System.Drawing.Point(134, 117)
        Me.pnlMap.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.pnlMap.Name = "pnlMap"
        Me.pnlMap.Size = New System.Drawing.Size(623, 308)
        Me.pnlMap.TabIndex = 20
        '
        'pnlTiles
        '
        Me.pnlTiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlTiles.AutoScroll = True
        Me.pnlTiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTiles.Controls.Add(Me.picTiles)
        Me.pnlTiles.Location = New System.Drawing.Point(9, 117)
        Me.pnlTiles.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.pnlTiles.Name = "pnlTiles"
        Me.pnlTiles.Size = New System.Drawing.Size(121, 308)
        Me.pnlTiles.TabIndex = 21
        '
        'picTiles
        '
        Me.picTiles.Location = New System.Drawing.Point(0, 0)
        Me.picTiles.Margin = New System.Windows.Forms.Padding(0)
        Me.picTiles.Name = "picTiles"
        Me.picTiles.Size = New System.Drawing.Size(96, 800)
        Me.picTiles.TabIndex = 5
        Me.picTiles.TabStop = False
        '
        'mnuMain
        '
        Me.mnuMain.AutoSize = False
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.separator5, Me.mnuEdit, Me.separator6, Me.mnuView, Me.separator7, Me.mnuHelp, Me.separator8, Me.mnuDev, Me.separator3})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Padding = New System.Windows.Forms.Padding(0)
        Me.mnuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.mnuMain.Size = New System.Drawing.Size(766, 24)
        Me.mnuMain.TabIndex = 0
        Me.mnuMain.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.mnuNewFromTemplate, Me.btnOpen, Me.btnSave, Me.btnSaveAs, Me.separator1, Me.mnuImport, Me.mnuExport, Me.separator2, Me.btnExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 24)
        Me.mnuFile.Text = "&File"
        '
        'btnNew
        '
        Me.btnNew.Name = "btnNew"
        Me.btnNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.btnNew.Size = New System.Drawing.Size(222, 22)
        Me.btnNew.Text = "&New"
        '
        'mnuNewFromTemplate
        '
        Me.mnuNewFromTemplate.Name = "mnuNewFromTemplate"
        Me.mnuNewFromTemplate.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.mnuNewFromTemplate.Size = New System.Drawing.Size(222, 22)
        Me.mnuNewFromTemplate.Text = "New From &Template"
        '
        'btnOpen
        '
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.btnOpen.Size = New System.Drawing.Size(222, 22)
        Me.btnOpen.Text = "&Open..."
        '
        'btnSave
        '
        Me.btnSave.Name = "btnSave"
        Me.btnSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.btnSave.Size = New System.Drawing.Size(222, 22)
        Me.btnSave.Text = "&Save"
        '
        'btnSaveAs
        '
        Me.btnSaveAs.Name = "btnSaveAs"
        Me.btnSaveAs.Size = New System.Drawing.Size(222, 22)
        Me.btnSaveAs.Text = "Save &As..."
        '
        'separator1
        '
        Me.separator1.Name = "separator1"
        Me.separator1.Size = New System.Drawing.Size(219, 6)
        '
        'mnuImport
        '
        Me.mnuImport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImportAS})
        Me.mnuImport.Name = "mnuImport"
        Me.mnuImport.Size = New System.Drawing.Size(222, 22)
        Me.mnuImport.Text = "&Import"
        Me.mnuImport.Visible = False
        '
        'btnImportAS
        '
        Me.btnImportAS.Name = "btnImportAS"
        Me.btnImportAS.Size = New System.Drawing.Size(170, 22)
        Me.btnImportAS.Text = "ActionScript Code"
        '
        'mnuExport
        '
        Me.mnuExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExportPNG, Me.btnExportAS})
        Me.mnuExport.Name = "mnuExport"
        Me.mnuExport.Size = New System.Drawing.Size(222, 22)
        Me.mnuExport.Text = "&Export"
        '
        'btnExportPNG
        '
        Me.btnExportPNG.Name = "btnExportPNG"
        Me.btnExportPNG.Size = New System.Drawing.Size(170, 22)
        Me.btnExportPNG.Text = "PNG Image [.png]"
        '
        'btnExportAS
        '
        Me.btnExportAS.Name = "btnExportAS"
        Me.btnExportAS.Size = New System.Drawing.Size(170, 22)
        Me.btnExportAS.Text = "ActionScript Code"
        Me.btnExportAS.Visible = False
        '
        'separator2
        '
        Me.separator2.Name = "separator2"
        Me.separator2.Size = New System.Drawing.Size(219, 6)
        '
        'btnExit
        '
        Me.btnExit.Name = "btnExit"
        Me.btnExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.btnExit.Size = New System.Drawing.Size(222, 22)
        Me.btnExit.Text = "E&xit"
        '
        'separator5
        '
        Me.separator5.AutoSize = False
        Me.separator5.Name = "separator5"
        Me.separator5.Size = New System.Drawing.Size(3, 24)
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDeleteSelectedObject, Me.btnUnitProperties, Me.separator9, Me.btnMapProperties})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(39, 24)
        Me.mnuEdit.Text = "&Edit"
        '
        'btnDeleteSelectedObject
        '
        Me.btnDeleteSelectedObject.Enabled = False
        Me.btnDeleteSelectedObject.Name = "btnDeleteSelectedObject"
        Me.btnDeleteSelectedObject.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.btnDeleteSelectedObject.Size = New System.Drawing.Size(249, 22)
        Me.btnDeleteSelectedObject.Text = "Delete Selected Object"
        '
        'btnUnitProperties
        '
        Me.btnUnitProperties.Enabled = False
        Me.btnUnitProperties.Name = "btnUnitProperties"
        Me.btnUnitProperties.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.btnUnitProperties.Size = New System.Drawing.Size(249, 22)
        Me.btnUnitProperties.Text = "Selected Unit &Properties..."
        '
        'separator9
        '
        Me.separator9.Name = "separator9"
        Me.separator9.Size = New System.Drawing.Size(246, 6)
        '
        'btnMapProperties
        '
        Me.btnMapProperties.Name = "btnMapProperties"
        Me.btnMapProperties.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.btnMapProperties.Size = New System.Drawing.Size(249, 22)
        Me.btnMapProperties.Text = "&Map Properties..."
        '
        'separator6
        '
        Me.separator6.AutoSize = False
        Me.separator6.Name = "separator6"
        Me.separator6.Size = New System.Drawing.Size(3, 24)
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuchkGrid, Me.mnuchkShadows, Me.mnuchkTeamIndicators, Me.mnuchkDebugBuildingPos, Me.mnuchkDebugUnitPos})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(44, 24)
        Me.mnuView.Text = "&View"
        '
        'mnuchkGrid
        '
        Me.mnuchkGrid.Checked = True
        Me.mnuchkGrid.CheckOnClick = True
        Me.mnuchkGrid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuchkGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuchkGrid.Name = "mnuchkGrid"
        Me.mnuchkGrid.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.mnuchkGrid.Size = New System.Drawing.Size(247, 22)
        Me.mnuchkGrid.Text = "Show &Grid"
        '
        'mnuchkShadows
        '
        Me.mnuchkShadows.Checked = True
        Me.mnuchkShadows.CheckOnClick = True
        Me.mnuchkShadows.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuchkShadows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuchkShadows.Name = "mnuchkShadows"
        Me.mnuchkShadows.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mnuchkShadows.Size = New System.Drawing.Size(247, 22)
        Me.mnuchkShadows.Text = "Show &Shadows"
        '
        'mnuchkTeamIndicators
        '
        Me.mnuchkTeamIndicators.CheckOnClick = True
        Me.mnuchkTeamIndicators.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuchkTeamIndicators.Name = "mnuchkTeamIndicators"
        Me.mnuchkTeamIndicators.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.mnuchkTeamIndicators.Size = New System.Drawing.Size(247, 22)
        Me.mnuchkTeamIndicators.Text = "Show &Team Indicators"
        '
        'mnuchkDebugBuildingPos
        '
        Me.mnuchkDebugBuildingPos.CheckOnClick = True
        Me.mnuchkDebugBuildingPos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuchkDebugBuildingPos.Name = "mnuchkDebugBuildingPos"
        Me.mnuchkDebugBuildingPos.Size = New System.Drawing.Size(247, 22)
        Me.mnuchkDebugBuildingPos.Text = "Debug - Show Building Positions"
        Me.mnuchkDebugBuildingPos.Visible = False
        '
        'mnuchkDebugUnitPos
        '
        Me.mnuchkDebugUnitPos.CheckOnClick = True
        Me.mnuchkDebugUnitPos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuchkDebugUnitPos.Name = "mnuchkDebugUnitPos"
        Me.mnuchkDebugUnitPos.Size = New System.Drawing.Size(247, 22)
        Me.mnuchkDebugUnitPos.Text = "Debug - Show Unit Positions"
        Me.mnuchkDebugUnitPos.Visible = False
        '
        'separator7
        '
        Me.separator7.AutoSize = False
        Me.separator7.Name = "separator7"
        Me.separator7.Size = New System.Drawing.Size(3, 24)
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAbout, Me.separator4, Me.chkAssociateFileTypeCAMM})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(44, 24)
        Me.mnuHelp.Text = "&Help"
        '
        'btnAbout
        '
        Me.btnAbout.Enabled = False
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(209, 22)
        Me.btnAbout.Text = "&About CAMM..."
        '
        'separator4
        '
        Me.separator4.Name = "separator4"
        Me.separator4.Size = New System.Drawing.Size(206, 6)
        '
        'chkAssociateFileTypeCAMM
        '
        Me.chkAssociateFileTypeCAMM.Checked = True
        Me.chkAssociateFileTypeCAMM.CheckOnClick = True
        Me.chkAssociateFileTypeCAMM.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkAssociateFileTypeCAMM.Name = "chkAssociateFileTypeCAMM"
        Me.chkAssociateFileTypeCAMM.Size = New System.Drawing.Size(209, 22)
        Me.chkAssociateFileTypeCAMM.Text = "Associate file type .camm"
        '
        'separator8
        '
        Me.separator8.AutoSize = False
        Me.separator8.Name = "separator8"
        Me.separator8.Size = New System.Drawing.Size(3, 24)
        '
        'mnuDev
        '
        Me.mnuDev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuDev.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnConfigEditor, Me.btnDeveloper})
        Me.mnuDev.Name = "mnuDev"
        Me.mnuDev.Size = New System.Drawing.Size(39, 24)
        Me.mnuDev.Text = "Dev"
        Me.mnuDev.Visible = False
        '
        'btnConfigEditor
        '
        Me.btnConfigEditor.Name = "btnConfigEditor"
        Me.btnConfigEditor.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.btnConfigEditor.Size = New System.Drawing.Size(256, 22)
        Me.btnConfigEditor.Text = "&Configuration Editor"
        '
        'btnDeveloper
        '
        Me.btnDeveloper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnDeveloper.Name = "btnDeveloper"
        Me.btnDeveloper.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.btnDeveloper.Size = New System.Drawing.Size(256, 22)
        Me.btnDeveloper.Text = "Activate Dev Mode"
        Me.btnDeveloper.Visible = False
        '
        'separator3
        '
        Me.separator3.AutoSize = False
        Me.separator3.Name = "separator3"
        Me.separator3.Size = New System.Drawing.Size(3, 24)
        Me.separator3.Visible = False
        '
        'btnEditBuildings
        '
        Me.btnEditBuildings.AutoSize = True
        Me.btnEditBuildings.Location = New System.Drawing.Point(215, 43)
        Me.btnEditBuildings.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnEditBuildings.Name = "btnEditBuildings"
        Me.btnEditBuildings.Size = New System.Drawing.Size(80, 23)
        Me.btnEditBuildings.TabIndex = 3
        Me.btnEditBuildings.Text = "Edit Buildings"
        Me.btnEditBuildings.UseVisualStyleBackColor = True
        '
        'btnEditTiles
        '
        Me.btnEditTiles.AutoSize = True
        Me.btnEditTiles.Enabled = False
        Me.btnEditTiles.Location = New System.Drawing.Point(132, 43)
        Me.btnEditTiles.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnEditTiles.Name = "btnEditTiles"
        Me.btnEditTiles.Size = New System.Drawing.Size(80, 23)
        Me.btnEditTiles.TabIndex = 2
        Me.btnEditTiles.Text = "Edit Tiles"
        Me.btnEditTiles.UseVisualStyleBackColor = True
        '
        'btnEditShroud
        '
        Me.btnEditShroud.AutoSize = True
        Me.btnEditShroud.Enabled = False
        Me.btnEditShroud.Location = New System.Drawing.Point(381, 43)
        Me.btnEditShroud.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnEditShroud.Name = "btnEditShroud"
        Me.btnEditShroud.Size = New System.Drawing.Size(80, 23)
        Me.btnEditShroud.TabIndex = 5
        Me.btnEditShroud.Text = "Edit Shroud"
        Me.btnEditShroud.UseVisualStyleBackColor = True
        Me.btnEditShroud.Visible = False
        '
        'pnlBuildings
        '
        Me.pnlBuildings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlBuildings.AutoScroll = True
        Me.pnlBuildings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBuildings.Controls.Add(Me.picBuildings)
        Me.pnlBuildings.Location = New System.Drawing.Point(9, 117)
        Me.pnlBuildings.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.pnlBuildings.Name = "pnlBuildings"
        Me.pnlBuildings.Size = New System.Drawing.Size(121, 308)
        Me.pnlBuildings.TabIndex = 21
        Me.pnlBuildings.Visible = False
        '
        'picBuildings
        '
        Me.picBuildings.Location = New System.Drawing.Point(0, 0)
        Me.picBuildings.Margin = New System.Windows.Forms.Padding(0)
        Me.picBuildings.Name = "picBuildings"
        Me.picBuildings.Size = New System.Drawing.Size(96, 800)
        Me.picBuildings.TabIndex = 5
        Me.picBuildings.TabStop = False
        '
        'txtHeight
        '
        Me.txtHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeight.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.Location = New System.Drawing.Point(612, 45)
        Me.txtHeight.MaxLength = 3
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(42, 20)
        Me.txtHeight.TabIndex = 11
        Me.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWidth
        '
        Me.txtWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWidth.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWidth.Location = New System.Drawing.Point(549, 45)
        Me.txtWidth.MaxLength = 3
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(42, 20)
        Me.txtWidth.TabIndex = 8
        Me.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSize
        '
        Me.btnSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSize.AutoSize = True
        Me.btnSize.Location = New System.Drawing.Point(657, 43)
        Me.btnSize.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSize.Name = "btnSize"
        Me.btnSize.Size = New System.Drawing.Size(100, 23)
        Me.btnSize.TabIndex = 12
        Me.btnSize.Text = "Change Size"
        Me.btnSize.UseVisualStyleBackColor = True
        '
        'saveMap
        '
        Me.saveMap.DefaultExt = "CAMM Map Files|*.camm"
        Me.saveMap.FileName = "Map1.camm"
        Me.saveMap.Filter = "CAMM Map Files|*.camm|CAMM Legacy Map File|*.map|All Files|*.*"
        Me.saveMap.Title = "Select where to save the map file..."
        '
        'openMap
        '
        Me.openMap.DefaultExt = "CAMM Map Files|*.camm;*.map"
        Me.openMap.FileName = "Map1.camm"
        Me.openMap.Filter = "CAMM Map Files|*.camm;*.map|All Files|*.*"
        Me.openMap.Multiselect = True
        Me.openMap.Title = "Select map file(s) to open..."
        '
        'chkGrid
        '
        Me.chkGrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkGrid.AutoSize = True
        Me.chkGrid.Checked = True
        Me.chkGrid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGrid.Location = New System.Drawing.Point(468, 47)
        Me.chkGrid.Name = "chkGrid"
        Me.chkGrid.Size = New System.Drawing.Size(75, 17)
        Me.chkGrid.TabIndex = 6
        Me.chkGrid.Text = "Show Grid"
        Me.chkGrid.UseVisualStyleBackColor = True
        '
        'btnToolSmartBrush
        '
        Me.btnToolSmartBrush.AutoSize = True
        Me.btnToolSmartBrush.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnToolSmartBrush.Enabled = False
        Me.btnToolSmartBrush.Location = New System.Drawing.Point(423, 69)
        Me.btnToolSmartBrush.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnToolSmartBrush.Name = "btnToolSmartBrush"
        Me.btnToolSmartBrush.Size = New System.Drawing.Size(74, 23)
        Me.btnToolSmartBrush.TabIndex = 18
        Me.btnToolSmartBrush.Text = "Smart Brush"
        Me.btnToolSmartBrush.UseVisualStyleBackColor = True
        Me.btnToolSmartBrush.Visible = False
        '
        'btnToolBrush
        '
        Me.btnToolBrush.AutoSize = True
        Me.btnToolBrush.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnToolBrush.Enabled = False
        Me.btnToolBrush.Location = New System.Drawing.Point(227, 69)
        Me.btnToolBrush.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnToolBrush.Name = "btnToolBrush"
        Me.btnToolBrush.Size = New System.Drawing.Size(44, 23)
        Me.btnToolBrush.TabIndex = 15
        Me.btnToolBrush.Text = "Brush"
        Me.btnToolBrush.UseVisualStyleBackColor = True
        '
        'tmrIntro
        '
        Me.tmrIntro.Interval = 15
        '
        'btnEditUnits
        '
        Me.btnEditUnits.AutoSize = True
        Me.btnEditUnits.Location = New System.Drawing.Point(298, 43)
        Me.btnEditUnits.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnEditUnits.Name = "btnEditUnits"
        Me.btnEditUnits.Size = New System.Drawing.Size(80, 23)
        Me.btnEditUnits.TabIndex = 4
        Me.btnEditUnits.Text = "Edit Units"
        Me.btnEditUnits.UseVisualStyleBackColor = True
        '
        'pnlUnits
        '
        Me.pnlUnits.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlUnits.AutoScroll = True
        Me.pnlUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUnits.Controls.Add(Me.picUnits)
        Me.pnlUnits.Location = New System.Drawing.Point(9, 117)
        Me.pnlUnits.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.pnlUnits.Name = "pnlUnits"
        Me.pnlUnits.Size = New System.Drawing.Size(121, 308)
        Me.pnlUnits.TabIndex = 21
        Me.pnlUnits.Visible = False
        '
        'picUnits
        '
        Me.picUnits.Location = New System.Drawing.Point(0, 0)
        Me.picUnits.Margin = New System.Windows.Forms.Padding(0)
        Me.picUnits.Name = "picUnits"
        Me.picUnits.Size = New System.Drawing.Size(96, 800)
        Me.picUnits.TabIndex = 5
        Me.picUnits.TabStop = False
        '
        'savePng
        '
        Me.savePng.DefaultExt = "PNG Images|*.png"
        Me.savePng.FileName = "Map1.png"
        Me.savePng.Filter = "PNG Images|*png"
        Me.savePng.Title = "Export PNG Image..."
        '
        'mapTabs
        '
        Me.mapTabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mapTabs.ContextMenuStrip = Me.ctxMapTabs
        Me.mapTabs.Location = New System.Drawing.Point(132, 95)
        Me.mapTabs.Name = "mapTabs"
        Me.mapTabs.SelectedIndex = 0
        Me.mapTabs.ShowToolTips = True
        Me.mapTabs.Size = New System.Drawing.Size(629, 333)
        Me.mapTabs.TabIndex = 19
        '
        'ctxMapTabs
        '
        Me.ctxMapTabs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnClose, Me.btnCloseAllExceptThis, Me.btnCloseAllLeft, Me.btnCloseAllRight})
        Me.ctxMapTabs.Name = "ContextMenuStrip1"
        Me.ctxMapTabs.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ctxMapTabs.ShowCheckMargin = True
        Me.ctxMapTabs.ShowImageMargin = False
        Me.ctxMapTabs.Size = New System.Drawing.Size(186, 92)
        '
        'btnClose
        '
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(185, 22)
        Me.btnClose.Text = "Close"
        '
        'btnCloseAllExceptThis
        '
        Me.btnCloseAllExceptThis.Name = "btnCloseAllExceptThis"
        Me.btnCloseAllExceptThis.Size = New System.Drawing.Size(185, 22)
        Me.btnCloseAllExceptThis.Text = "Close All Except This"
        '
        'btnCloseAllLeft
        '
        Me.btnCloseAllLeft.Name = "btnCloseAllLeft"
        Me.btnCloseAllLeft.Size = New System.Drawing.Size(185, 22)
        Me.btnCloseAllLeft.Text = "Close All to the Left"
        '
        'btnCloseAllRight
        '
        Me.btnCloseAllRight.Name = "btnCloseAllRight"
        Me.btnCloseAllRight.Size = New System.Drawing.Size(185, 22)
        Me.btnCloseAllRight.Text = "Close All to the Right"
        '
        'btnToolPointer
        '
        Me.btnToolPointer.AutoSize = True
        Me.btnToolPointer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnToolPointer.Location = New System.Drawing.Point(174, 69)
        Me.btnToolPointer.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnToolPointer.Name = "btnToolPointer"
        Me.btnToolPointer.Size = New System.Drawing.Size(50, 23)
        Me.btnToolPointer.TabIndex = 14
        Me.btnToolPointer.Text = "Pointer"
        Me.btnToolPointer.UseVisualStyleBackColor = True
        '
        'btnToolRectangleBrush
        '
        Me.btnToolRectangleBrush.AutoSize = True
        Me.btnToolRectangleBrush.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnToolRectangleBrush.Location = New System.Drawing.Point(274, 69)
        Me.btnToolRectangleBrush.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnToolRectangleBrush.Name = "btnToolRectangleBrush"
        Me.btnToolRectangleBrush.Size = New System.Drawing.Size(96, 23)
        Me.btnToolRectangleBrush.TabIndex = 16
        Me.btnToolRectangleBrush.Text = "Rectangle Brush"
        '
        'cboRectangleBrush
        '
        Me.cboRectangleBrush.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboRectangleBrush.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRectangleBrush.DropDownWidth = 256
        Me.cboRectangleBrush.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRectangleBrush.FormattingEnabled = True
        Me.cboRectangleBrush.IntegralHeight = False
        Me.cboRectangleBrush.ItemHeight = 48
        Me.cboRectangleBrush.Location = New System.Drawing.Point(9, 43)
        Me.cboRectangleBrush.Name = "cboRectangleBrush"
        Me.cboRectangleBrush.Size = New System.Drawing.Size(121, 54)
        Me.cboRectangleBrush.TabIndex = 16
        Me.cboRectangleBrush.Visible = False
        '
        'FrmEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 452)
        Me.Controls.Add(Me.cboRectangleBrush)
        Me.Controls.Add(Me.lblHeight)
        Me.Controls.Add(Me.lblWidth)
        Me.Controls.Add(Me.lblTools)
        Me.Controls.Add(Me.btnToolRectangleBrush)
        Me.Controls.Add(Me.btnToolSmartBrush)
        Me.Controls.Add(Me.pnlUnits)
        Me.Controls.Add(Me.btnToolPointer)
        Me.Controls.Add(Me.btnToolBrush)
        Me.Controls.Add(Me.btnToolErase)
        Me.Controls.Add(Me.btnEditUnits)
        Me.Controls.Add(Me.chkGrid)
        Me.Controls.Add(Me.lblx)
        Me.Controls.Add(Me.txtHeight)
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.btnSize)
        Me.Controls.Add(Me.btnEditShroud)
        Me.Controls.Add(Me.btnEditTiles)
        Me.Controls.Add(Me.btnEditBuildings)
        Me.Controls.Add(Me.mnuMain)
        Me.Controls.Add(Me.pnlMap)
        Me.Controls.Add(Me.pnlTiles)
        Me.Controls.Add(Me.staInfoBar)
        Me.Controls.Add(Me.lblSelected)
        Me.Controls.Add(Me.picActive)
        Me.Controls.Add(Me.pnlBuildings)
        Me.Controls.Add(Me.mapTabs)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "FrmEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CAMM (Crystal Alien Map Maker)"
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMap.ResumeLayout(False)
        CType(Me.picActive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.staInfoBar.ResumeLayout(False)
        Me.staInfoBar.PerformLayout()
        Me.pnlMap.ResumeLayout(False)
        Me.pnlTiles.ResumeLayout(False)
        CType(Me.picTiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.pnlBuildings.ResumeLayout(False)
        CType(Me.picBuildings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlUnits.ResumeLayout(False)
        CType(Me.picUnits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMapTabs.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblx As System.Windows.Forms.Label
    Friend WithEvents lblTools As System.Windows.Forms.Label
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents picActive As System.Windows.Forms.PictureBox
    Friend WithEvents lblSelected As System.Windows.Forms.Label
    Friend WithEvents staInfoBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblCursorLoc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblAboutVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnToolErase As System.Windows.Forms.Button
    Friend WithEvents pnlMap As System.Windows.Forms.Panel
    Friend WithEvents pnlTiles As System.Windows.Forms.Panel
    Friend WithEvents picTiles As System.Windows.Forms.PictureBox
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents separator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents separator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEditBuildings As System.Windows.Forms.Button
    Friend WithEvents btnEditTiles As System.Windows.Forms.Button
    Friend WithEvents btnEditShroud As System.Windows.Forms.Button
    Friend WithEvents pnlBuildings As System.Windows.Forms.Panel
    Friend WithEvents picBuildings As System.Windows.Forms.PictureBox
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents btnSize As System.Windows.Forms.Button
    Friend WithEvents saveMap As System.Windows.Forms.SaveFileDialog
    Friend WithEvents openMap As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkGrid As System.Windows.Forms.CheckBox
    Friend WithEvents mnuDev As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnConfigEditor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnToolBrush As System.Windows.Forms.Button
    Friend WithEvents tmrIntro As System.Windows.Forms.Timer
    Friend WithEvents btnToolSmartBrush As System.Windows.Forms.Button
    Friend WithEvents btnEditUnits As System.Windows.Forms.Button
    Friend WithEvents pnlUnits As System.Windows.Forms.Panel
    Friend WithEvents picUnits As System.Windows.Forms.PictureBox
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuchkGrid As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnMapProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExportPNG As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents savePng As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mnuImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImportAS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDeveloper As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExportAS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuchkDebugBuildingPos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents separator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkAssociateFileTypeCAMM As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents separator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents separator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents separator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents separator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents separator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mapTabs As System.Windows.Forms.TabControl
    Friend WithEvents ctxMapTabs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCloseAllLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCloseAllRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCloseAllExceptThis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuchkShadows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuchkDebugUnitPos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnToolPointer As System.Windows.Forms.Button
    Friend WithEvents btnDeleteSelectedObject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents separator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnToolRectangleBrush As System.Windows.Forms.Button
    Friend WithEvents cboRectangleBrush As System.Windows.Forms.ComboBox
    Friend WithEvents ctxMap As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnMapUnitProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnUnitProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMapSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblMapNoActionsAvailable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnMapDeleteObject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMapSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnMapCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuchkTeamIndicators As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNewFromTemplate As ToolStripMenuItem
End Class
