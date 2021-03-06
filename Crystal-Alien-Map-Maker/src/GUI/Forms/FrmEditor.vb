﻿'-============================================================================================-'
'  CAMM (Crystal Alien Map Maker) program created by Josh (aka. leveleditor / Leveleditor6680) '
'-============================================================================================-'

Imports System.Diagnostics
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Security
Imports System.Text
Imports Microsoft.Win32
Imports Newtonsoft.Json

Public Class FrmEditor

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        Icon = My.Resources.Crystal
    End Sub

    Private baseFormTitle As String

    Private Property ActiveMapNum As Integer
        Get
            Return mapTabs.SelectedIndex
        End Get
        Set(value As Integer)
            mapTabs.SelectedIndex = value
        End Set
    End Property
    Private ReadOnly _maps As List(Of Map) = New List(Of Map)
    Public ReadOnly Property Maps As List(Of Map)
        Get
            Return _maps
        End Get
    End Property
    Public Property ActiveMap As Map
        Get
            Return Maps(ActiveMapNum)
        End Get
        Set(value As Map)
            Maps(ActiveMapNum) = value
        End Set
    End Property

    Public ReadOnly Property SelectedRectangleBrushPreset As RectangleBrushPreset
        Get
            Return CType(cboRectangleBrush.SelectedItem, RectangleBrushPreset)
        End Get
    End Property

    Private isLoaded As Boolean = False
    Private isMouseOnMap As Boolean = False
    Public IsDrawing As Boolean = False
    Private mouseX As Integer
    Private mouseY As Integer
    Private mouseXNoSnap As Integer
    Private mouseYNoSnap As Integer

    'The last key that was pressed.
    Private lastKeyDown As Keys = Keys.None

    Private skipDeveloperWarning As Boolean = False

    Public ActiveEditMode As EditMode
    Private tileEditMode As TileEditMode
    Private unitEditMode As UnitEditMode
    Private buildingEditMode As BuildingEditMode

    Public DrawGrid As Boolean = True
    Public DrawShadows As Boolean = True
    Public DrawTeamIndicators As Boolean = False
    Public DrawBuildingDebugPos As Boolean = False
    Public DrawUnitDebugPos As Boolean = False
    Private isMouseOnSelections As Boolean = False
    Dim selXTiles As Integer
    Dim selYTiles As Integer
    Dim selXBuildings As Integer
    Dim selYBuildings As Integer
    Dim selXUnits As Integer
    Dim selYUnits As Integer

    ReadOnly customToolStripRenderer As ToolStripProfessionalRenderer = New ToolStripProfessionalRenderer(New CustomColorTable())

    Private Sub FRMEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Storing default form title.
        baseFormTitle = Me.Text

        'Loading assets.
        LoadAssets()
        btnPlayInGame.Image = ButtonPlay
        btnPlayInGameDefault.Image = ButtonPlay
        btnPlayInGameMods.Image = ButtonPlay

        'Setting version information.
        lblAboutVersion.Text = BuildType + " v" + My.Application.Info.Version.Major.ToString() + "." + My.Application.Info.Version.Minor.ToString()
        If My.Application.Info.Version.Revision > 0 Then
            lblAboutVersion.Text += "." + My.Application.Info.Version.Build.ToString() + "." + My.Application.Info.Version.Revision.ToString()
        ElseIf My.Application.Info.Version.Build > 0 And My.Application.Info.Version.Revision <= 0 Then
            lblAboutVersion.Text += "." + My.Application.Info.Version.Build.ToString()
        End If
        lblAboutVersion.Text += " by Leveleditor6680 // Josh"

        'Setting ToolStrip renderers
        mnuMain.Renderer = customToolStripRenderer
        staInfoBar.Renderer = customToolStripRenderer
        ctxMapTabs.Renderer = customToolStripRenderer
        ctxMap.Renderer = customToolStripRenderer

        For Each menuItem As ToolStripDropDownItem In mnuMain.Items.OfType(Of ToolStripDropDownItem)()
            'Dim dropDown As ToolStripDropDownMenu = MenuItem.DropDown
            'dropDown.ShowImageMargin = False
            menuItem.Text = menuItem.Text.ToUpper()
        Next

        'Set up external links on menu items
        btnExternal1.Tag = "http://marsmissionwiki.wikifoundry.com/page/CAMM+(Crystal+Alien+Map+Maker)"
        btnExternal2.Tag = "https://github.com/leveleditor/CAMM-Crystal-Alien-Map-Maker"
        btnExternal3.Tag = "http://marsmissionwiki.wikifoundry.com/"
        btnExternal4.Tag = "https://crystalien-redux.com/"
        btnExternal5.Tag = "https://github.com/leveleditor/CAMM-Crystal-Alien-Map-Maker/issues"
        btnExternal6.Tag = "https://github.com/Brian151/CAC-Unit-Editor"
        btnExternal7.Tag = "https://github.com/Brian151/CAC-Building-Editor"
        btnExternal8.Tag = "https://github.com/leveleditor/CrystAlien-Conflict-Flash-Wrapper"
        btnExternal9.Tag = "https://crystalien-redux.com/camm.php"

        btnExternal1.ToolTipText = btnExternal1.Tag
        btnExternal2.ToolTipText = btnExternal2.Tag
        btnExternal3.ToolTipText = btnExternal3.Tag
        btnExternal4.ToolTipText = btnExternal4.Tag
        btnExternal5.ToolTipText = btnExternal5.Tag
        btnExternal6.ToolTipText = btnExternal6.Tag
        btnExternal7.ToolTipText = btnExternal7.Tag
        btnExternal8.ToolTipText = btnExternal8.Tag
        btnExternal9.ToolTipText = btnExternal9.Tag

        'Loading the configuration file.
        If Not LoadConfig() Then
            'Close if the configuration data could not be loaded.
            Me.Close()
        End If

        'Fill dropdown list with Rectangle Brush Presets.
        If RectangleBrushPresets.Count > 0 Then
            cboRectangleBrush.Items.AddRange(RectangleBrushPresets.ToArray())
            cboRectangleBrush.DisplayMember = "Title"
            cboRectangleBrush.ValueMember = "FileName"
            cboRectangleBrush.SelectedIndex = 0
        End If

        'Fill "New From Template" menu with maps from the default maps folder.
        Dim defaultMaps As IEnumerable(Of String) = My.Computer.FileSystem.GetFiles(DefaultMapsPath, FileIO.SearchOption.SearchTopLevelOnly, New String() {"*.camm"}).ToList()
        'TODO: Custom sorting algorithm (a bit messy and unconventional, but it does the job). Perhaps find something better later.
        defaultMaps = defaultMaps.OrderBy(Function(a)
                                              If a.Contains("Bonus") Then
                                                  Return "3"
                                              ElseIf a.Contains("Astro") Then
                                                  Return "1"
                                              ElseIf a.Contains("Alien") Then
                                                  Return "2"
                                              End If
                                              Return "4"
                                          End Function).ThenBy(Function(a As String)
                                                                   Return a.Sum(Function(b)
                                                                                    Return Asc(b)
                                                                                End Function)
                                                               End Function)
        For Each filePath As String In defaultMaps
            Dim fileName As String = My.Computer.FileSystem.GetFileInfo(filePath).Name

            'Get information from the map file.
            Dim mapData As MapData = JsonConvert.DeserializeObject(Of MapData)(File.ReadAllText(filePath))
            Dim title As String = mapData.Title
            Dim author As String = mapData.Author

            'Create a new menu item for this template map.
            Dim menuItem As New ToolStripMenuItem(title)
            menuItem.ToolTipText = title + " [" + fileName + "]" + Environment.NewLine + "by " + author

            'Add an event handler for clicking the item.
            AddHandler menuItem.Click, Sub()
                                           BeginLoadMap(filePath)
                                           'Clear the map's file information so that a copy must be saved
                                           'and the original template map remains untouched.
                                           ActiveMap.FilePath = ""
                                           UpdateMapTabs()
                                           UpdateFormTitle()
                                       End Sub

            'Add the item to the menu.
            mnuNewFromTemplate.DropDownItems.Add(menuItem)
        Next

        CheckFileAssociations()

        'Dynamically setting picTiles size.
        picTiles.Size = New Size(TileSizeX + 1, TileDefs.Count * TileSizeY)
        picTiles.Invalidate()

        'Dynamically setting picBuildings size.
        picBuildings.Size = New Size(TileSizeX + 1, BuildingDefs.Count * TileSizeY)
        picBuildings.Invalidate()

        'Dynamically setting picUnits size.
        picUnits.Size = New Size(TileSizeX + 1, UnitDefs.Count * TileSizeY)
        picUnits.Invalidate()

        'Setting default blank values.
        tileEditMode = New TileEditMode(Me)
        unitEditMode = New UnitEditMode(Me)
        buildingEditMode = New BuildingEditMode(Me)

        If My.Application.CommandLineArgs.Count > 0 Then
            'Load the map file(s) passed on the command line.
            For Each fileName As String In My.Application.CommandLineArgs
                BeginLoadMap(fileName)
            Next
        Else
            'Start a new map.
            NewMap()
        End If

        ' Update GUI state for the default edit mode.
        SwitchEditMode(tileEditMode)

        isLoaded = True
    End Sub

    Private Sub FRMEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim mapsToClose As List(Of Map) = New List(Of Map)(Maps)
        Dim numberMapsToClose = Maps.Count
        Dim numberMapsClosed = CloseMaps(mapsToClose)
        If numberMapsClosed < numberMapsToClose Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmEditor_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'Prevent key down event from repeating.
        If e.KeyCode <> lastKeyDown Then
            lastKeyDown = e.KeyCode

            If e.KeyCode = Keys.ControlKey Then
                'Redraw the map when the Ctrl key is pressed.
                picMap.Invalidate()
            End If
        End If
    End Sub

    Private Sub FrmEditor_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        'Allow key down event to fire again.
        lastKeyDown = Keys.None

        If e.KeyCode = Keys.ControlKey Then
            'Redraw the map when the Ctrl key is released.
            picMap.Invalidate()
        End If
    End Sub

#Region "Grid and Map Operations"

    Private Sub ResizeMap(width As Integer, height As Integer)
        ActiveMap.SetSize(width, height)

        UpdateMapSize()
    End Sub

    Private Sub UpdateMapSize()
        txtWidth.Text = ActiveMap.SizeX
        txtHeight.Text = ActiveMap.SizeY
        picMap.Size = New Size(ActiveMap.SizeX * TileSizeX, ActiveMap.SizeY * TileSizeY)

        picMap.Invalidate()
    End Sub

#End Region

#Region "picMap Events"

    Private Sub picMap_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles picMap.MouseDoubleClick
        If ActiveEditMode.ShowContextMenu Then
            ctxMap.Show(picMap, e.Location)
        End If
    End Sub

    Private Sub picMap_MouseDown(sender As Object, e As MouseEventArgs) Handles picMap.MouseDown
        If e.Button = MouseButtons.Left Then
            If IsDrawing = False Then
                IsDrawing = True

                mouseX = e.X
                mouseY = e.Y
                PointToGrid(mouseX, mouseY)
                mouseXNoSnap = e.X
                mouseYNoSnap = e.Y

                ActiveEditMode.PerformMouseAction(mouseX, mouseY, mouseXNoSnap, mouseYNoSnap, True, IsDrawing)

                picMap.Invalidate()
            End If
        End If
    End Sub

    Private Sub picMap_MouseUp(sender As Object, e As MouseEventArgs) Handles picMap.MouseUp
        If e.Button = MouseButtons.Left Then
            If IsDrawing Then
                IsDrawing = False

                mouseX = e.X
                mouseY = e.Y
                PointToGrid(mouseX, mouseY)
                mouseXNoSnap = e.X
                mouseYNoSnap = e.Y

                ActiveEditMode.PerformMouseRelease(mouseX, mouseY, mouseXNoSnap, mouseYNoSnap)

                UpdateMapTabs()
                UpdateFormTitle()
                picMap.Invalidate()
            End If
        ElseIf e.Button = MouseButtons.Right Then
            If ActiveEditMode.ShowContextMenu Then
                ctxMap.Show(picMap, e.Location)
            End If
        End If
    End Sub

    Private Sub picMap_MouseMove(sender As Object, e As MouseEventArgs) Handles picMap.MouseMove
        isMouseOnMap = True
        mouseX = e.X
        mouseY = e.Y
        PointToGrid(mouseX, mouseY)
        mouseXNoSnap = e.X
        mouseYNoSnap = e.Y

        ActiveEditMode.PerformMouseAction(mouseX, mouseY, mouseXNoSnap, mouseYNoSnap, False, IsDrawing)

        Dim debug As Boolean = True
        If IsMouseInBounds() Then
            If debug = True Then
                If ActiveMap.GetTileAt(mouseX, mouseY) IsNot Nothing Then
                    lblCursorLoc.Text = ActiveMap.GetTileAt(mouseX, mouseY).TileId.ToString() + " [" + ((mouseX / TileSizeX) + 1).ToString() + ", " + ((mouseY / TileSizeY) + 1).ToString() + "]"
                Else
                    lblCursorLoc.Text = "null [" + ((mouseX / TileSizeX) + 1).ToString() + ", " + ((mouseY / TileSizeY) + 1).ToString() + "]"
                End If
                If ActiveMap.GetBuildingAt(mouseX, mouseY) IsNot Nothing Then
                    lblCursorLoc.Text = ActiveMap.GetBuildingAt(mouseX, mouseY).BuildingId + " : " + lblCursorLoc.Text
                End If
            Else
                lblCursorLoc.Text = "[" + ((mouseX / TileSizeX) + 1).ToString() + ", " + ((mouseY / TileSizeY) + 1).ToString() + "]"
            End If
        End If

        ' Redraw.
        picMap.Invalidate()
    End Sub

    Private Sub picMap_Paint(sender As Object, e As PaintEventArgs) Handles picMap.Paint
        If isLoaded Then
            Dim g As Graphics = e.Graphics

            Dim drawUnitTeamIndicators As Boolean = DrawTeamIndicators And ActiveEditMode Is unitEditMode
            Dim drawBuildingTeamIndicators As Boolean = DrawTeamIndicators And ActiveEditMode Is buildingEditMode
            ActiveMap.Draw(g, DrawGrid, DrawShadows, drawUnitTeamIndicators, drawBuildingTeamIndicators, DrawBuildingDebugPos, DrawUnitDebugPos)

            ActiveEditMode.Draw(g, mouseX, mouseY, mouseXNoSnap, mouseYNoSnap, IsDrawing)
        End If
    End Sub

    Private Sub picMap_MouseEnter(sender As Object, e As EventArgs) Handles picMap.MouseEnter
        isMouseOnMap = True
    End Sub

    Private Sub picMap_MouseLeave(sender As Object, e As EventArgs) Handles picMap.MouseLeave
        isMouseOnMap = False
        Cursor.Show()
        lblCursorLoc.Text = "[ ]"
        picMap.Invalidate()
    End Sub

#End Region

#Region "picTiles Events"

    Private Sub picTiles_Paint(sender As Object, e As PaintEventArgs) Handles picTiles.Paint
        If isLoaded Then
            e.Graphics.Clear(picTiles.BackColor)

            For i As Integer = 0 To TileDefs.Count - 1
                If TileDefs(i).HasData Then
                    TileDefs(i).Draw(e.Graphics, 0, i * TileSizeY)
                End If
            Next

            ' Draw the grid.
            DrawGridLines(e.Graphics, picTiles.ClientSize.Width, picTiles.ClientSize.Height)

            'Draw Rectangle around selected Tile.
            If tileEditMode.ActiveTile.TileId <> -1 And tileEditMode.ActiveToolMode = ToolMode.Brush Then
                e.Graphics.DrawRectangle(PenSelected, selXTiles + (PenSelected.Width / 2), selYTiles + (PenSelected.Width / 2), TileSizeX - PenSelected.Width, TileSizeY - PenSelected.Width + 1)
            End If

            ' Draw the rectangle cursor / selector thingy.
            If isMouseOnSelections Then
                e.Graphics.DrawRectangle(PenSelectionHover, mouseX + (PenSelectionHover.Width / 2), mouseY + (PenSelectionHover.Width / 2), TileSizeX - PenSelectionHover.Width, TileSizeY - PenSelectionHover.Width + 1)
            End If

        End If
    End Sub

    Private Sub picTiles_MouseEnter(sender As Object, e As EventArgs) Handles picTiles.MouseEnter
        isMouseOnSelections = True
        isMouseOnMap = False
    End Sub

    Private Sub picTiles_MouseLeave(sender As Object, e As EventArgs) Handles picTiles.MouseLeave
        isMouseOnSelections = False
        lblCursorLoc.Text = "[ ]"
        picTiles.Invalidate()
    End Sub

    Private Sub picTiles_MouseMove(sender As Object, e As MouseEventArgs) Handles picTiles.MouseMove
        isMouseOnSelections = True
        mouseX = e.X
        mouseY = e.Y
        PointToGrid(mouseX, mouseY)
        mouseXNoSnap = e.X
        mouseYNoSnap = e.Y

        ' Redraw.
        picTiles.Invalidate()
    End Sub

    Private Sub picTiles_MouseDown(sender As Object, e As MouseEventArgs) Handles picTiles.MouseDown
        If e.Button = MouseButtons.Left Then
            SwitchToolMode(ToolMode.Brush)

            mouseX = e.X
            mouseY = e.Y
            PointToGrid(mouseX, mouseY)
            mouseXNoSnap = e.X
            mouseYNoSnap = e.Y
            selXTiles = mouseX
            selYTiles = mouseY

            For i As Integer = 0 To TileDefs.Count - 1
                If mouseY = i * TileSizeY Then
                    picActive.Image = TileDefs(i).Image
                    tileEditMode.ActiveTile.TileId = TileDefs(i).TileId
                    tileEditMode.ActiveTile.IsPassable = TileDefs(i).IsPassable
                    tileEditMode.ActiveTile.IsMinerals = TileDefs(i).IsMinerals
                End If
            Next

            picTiles.Invalidate()
        End If
    End Sub

#End Region
#Region "picBuildings Events"

    Private Sub picBuildings_Paint(sender As Object, e As PaintEventArgs) Handles picBuildings.Paint
        If isLoaded Then
            e.Graphics.Clear(picBuildings.BackColor)

            ' Draw the object selections.
            For i As Integer = 0 To BuildingDefs.Count - 1
                If BuildingDefs(i).HasData Then
                    BuildingDefs(i).DrawThumbnail(e.Graphics, 0, i * TileSizeY, True)
                End If
            Next

            ' Draw the grid.
            DrawGridLines(e.Graphics, picBuildings.ClientSize.Width, picBuildings.ClientSize.Height)

            'Draw Rectangle around selected Buildings.
            If buildingEditMode.ActiveBuilding.BuildingId <> "" And buildingEditMode.ActiveToolMode = ToolMode.Brush Then
                e.Graphics.DrawRectangle(PenSelected, selXBuildings + (PenSelected.Width / 2), selYBuildings + (PenSelected.Width / 2), TileSizeX - PenSelected.Width, TileSizeY - PenSelected.Width + 1)
            End If

            ' Draw the rectangle cursor / selector thingy.
            If isMouseOnSelections Then
                e.Graphics.DrawRectangle(PenSelectionHover, mouseX + (PenSelectionHover.Width / 2), mouseY + (PenSelectionHover.Width / 2), TileSizeX - PenSelectionHover.Width, TileSizeY - PenSelectionHover.Width + 1)
            End If
        End If
    End Sub

    Private Sub picBuildings_MouseEnter(sender As Object, e As EventArgs) Handles picBuildings.MouseEnter
        isMouseOnSelections = True
        isMouseOnMap = False
    End Sub

    Private Sub picBuildings_MouseLeave(sender As Object, e As EventArgs) Handles picBuildings.MouseLeave
        isMouseOnSelections = False
        lblCursorLoc.Text = "[ ]"
        picBuildings.Invalidate()
    End Sub

    Private Sub picBuildings_MouseMove(sender As Object, e As MouseEventArgs) Handles picBuildings.MouseMove
        isMouseOnSelections = True
        mouseX = e.X
        mouseY = e.Y
        PointToGrid(mouseX, mouseY)
        mouseXNoSnap = e.X
        mouseYNoSnap = e.Y

        ' Redraw.
        picBuildings.Invalidate()
    End Sub

    Private Sub picBuildings_MouseDown(sender As Object, e As MouseEventArgs) Handles picBuildings.MouseDown
        If e.Button = MouseButtons.Left Then
            SwitchToolMode(ToolMode.Brush)

            mouseX = e.X
            mouseY = e.Y
            PointToGrid(mouseX, mouseY)
            mouseXNoSnap = e.X
            mouseYNoSnap = e.Y
            selXBuildings = mouseX
            selYBuildings = mouseY

            For i As Integer = 0 To BuildingDefs.Count - 1
                If mouseY = i * TileSizeY Then
                    picActive.Image = BuildingDefs(i).SmallImage
                    buildingEditMode.ActiveBuilding.BuildingId = BuildingDefs(i).BuildingId
                    buildingEditMode.ActiveBuilding.Team = BuildingDefs(i).Team
                    buildingEditMode.ActiveBuilding.BuildingW = BuildingDefs(i).BuildingW
                    buildingEditMode.ActiveBuilding.BuildingH = BuildingDefs(i).BuildingH
                End If
            Next

            picBuildings.Invalidate()
        End If
    End Sub

#End Region
#Region "picUnits Events"

    Private Sub picUnits_Paint(sender As Object, e As PaintEventArgs) Handles picUnits.Paint
        If isLoaded Then
            e.Graphics.Clear(picUnits.BackColor)

            ' Draw the object selections.
            For i As Integer = 0 To UnitDefs.Count - 1
                If UnitDefs(i).HasData Then
                    UnitDefs(i).DrawThumbnail(e.Graphics, 0, i * TileSizeY, True)
                End If
            Next

            ' Draw the grid.
            DrawGridLines(e.Graphics, picUnits.ClientSize.Width, picUnits.ClientSize.Height)

            'Draw Rectangle around selected Units.
            If unitEditMode.ActiveUnit.UnitId <> "" And unitEditMode.ActiveToolMode = ToolMode.Brush Then
                e.Graphics.DrawRectangle(PenSelected, selXUnits + (PenSelected.Width / 2), selYUnits + (PenSelected.Width / 2), TileSizeX - PenSelected.Width, TileSizeY - PenSelected.Width + 1)
            End If

            ' Draw the rectangle cursor / selector thingy.
            If isMouseOnSelections Then
                e.Graphics.DrawRectangle(PenSelectionHover, mouseX + (PenSelectionHover.Width / 2), mouseY + (PenSelectionHover.Width / 2), TileSizeX - PenSelectionHover.Width, TileSizeY - PenSelectionHover.Width + 1)
            End If
        End If
    End Sub

    Private Sub picUnits_MouseEnter(sender As Object, e As EventArgs) Handles picUnits.MouseEnter
        isMouseOnSelections = True
        isMouseOnMap = False
    End Sub

    Private Sub picUnits_MouseLeave(sender As Object, e As EventArgs) Handles picUnits.MouseLeave
        isMouseOnSelections = False
        lblCursorLoc.Text = "[ ]"
        picUnits.Invalidate()
    End Sub

    Private Sub picUnits_MouseMove(sender As Object, e As MouseEventArgs) Handles picUnits.MouseMove
        isMouseOnSelections = True
        mouseX = e.X
        mouseY = e.Y
        PointToGrid(mouseX, mouseY)
        mouseXNoSnap = e.X
        mouseYNoSnap = e.Y

        ' Redraw.
        picUnits.Invalidate()
    End Sub

    Private Sub picUnits_MouseDown(sender As Object, e As MouseEventArgs) Handles picUnits.MouseDown
        If e.Button = MouseButtons.Left Then
            SwitchToolMode(ToolMode.Brush)

            mouseX = e.X
            mouseY = e.Y
            PointToGrid(mouseX, mouseY)
            mouseXNoSnap = e.X
            mouseYNoSnap = e.Y
            selXUnits = mouseX
            selYUnits = mouseY

            For i As Integer = 0 To UnitDefs.Count - 1
                If mouseY = i * TileSizeY Then
                    picActive.Image = UnitDefs(i).SmallImage
                    unitEditMode.ActiveUnit.UnitId = UnitDefs(i).UnitId
                    unitEditMode.ActiveUnit.Team = UnitDefs(i).Team
                    unitEditMode.ActiveUnit.Altitude = UnitDefs(i).Altitude
                    unitEditMode.ActiveUnit.IsPickup = UnitDefs(i).IsPickup
                End If
            Next

            picUnits.Invalidate()
        End If
    End Sub

#End Region

#Region "File Operations"

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        NewMap()
    End Sub

    Public Sub AddMap(map As Map)
        Maps.Add(map)
        UpdateMapTabs()
        ActiveMapNum = Maps.IndexOf(map)
        UpdateFormTitle()
        UpdateMapSize()
    End Sub

    Public Sub NewMap()
        AddMap(New Map())
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Me.openMap.FileName = "Map1.camm"
        Me.openMap.FilterIndex = 1
        Me.openMap.RestoreDirectory = False
        Me.openMap.InitialDirectory = SavePath

        If Me.openMap.ShowDialog = DialogResult.OK Then
            For Each fileName As String In Me.openMap.FileNames
                BeginLoadMap(fileName)
            Next
        End If
    End Sub
    Public Sub BeginLoadMap(fileName As String)
        'Check if the same map is already open in a tab.
        For Each otherMap As Map In Maps
            If otherMap.FilePath = fileName Then
                'Avoid loading the same map into two different tabs.
                'Instead, select the current tab and abort loading.
                ActiveMapNum = Maps.IndexOf(otherMap)
                Return
            End If
        Next

        Dim mapData As MapData? = Nothing
        Try
            'Attempt to load the map file as a JSON object.
            mapData = JsonConvert.DeserializeObject(Of MapData)(File.ReadAllText(fileName))
        Catch ex As Exception
            'Loading as JSON failed.
        End Try

        If mapData IsNot Nothing Then
            Dim map As Map = New Map()
            If mapData.Value.Format >= BaseJsonMapFormat And mapData.Value.Format <= MapFormat Then
                map.LoadMap(mapData)
                AddMap(map)
                EndLoadMap(fileName)
            ElseIf mapData.Value.Format > MapFormat Then
                MsgBox("This map file was created with a newer version of CAMM and cannot be opened.")
            ElseIf mapData.Value.Format < BaseJsonMapFormat Then
                MsgBox("This map file was created with an older version of CAMM and cannot be opened. The file format is no longer supported.")
            Else
                MsgBox("This map file has an invalid value of '" + mapData.Value.Format.ToString() + "' for the map format and cannot be opened.")
            End If
        Else
            MsgBox("This map file format is either not supported by this version of CAMM, or is otherwise invalid and cannot be opened. Try opening and re-saving it in an earlier version of CAMM (v1.4.0.53) to upgrade the file format first.")
        End If
    End Sub
    Private Sub EndLoadMap(fileName As String)
        ActiveMap.FilePath = fileName

        UpdateFormTitle()
        UpdateMapTabs()
        UpdateMapSize()

        picMap.Invalidate()
    End Sub

    Private Sub btnSaveAs_Click(sender As Object, e As EventArgs) Handles btnSaveAs.Click
        Me.saveMap.Reset()
        'Me.SaveMap.DefaultExt = "CAMM Map Files|*.camm"
        If ActiveMap.Title <> "" Then
            Me.saveMap.FileName = ActiveMap.Title
        Else
            Me.saveMap.FileName = "Map1.camm"
        End If
        Me.saveMap.Filter = "CAMM Map Files|*.camm|All Files|*.*"
        Me.saveMap.FilterIndex = 1
        Me.saveMap.RestoreDirectory = False
        Me.saveMap.Title = "Select Where To Save Map File..."
        Me.saveMap.InitialDirectory = SavePath

        If Me.saveMap.ShowDialog = DialogResult.OK Then
            SaveFile(saveMap.FileName)
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not String.IsNullOrEmpty(ActiveMap.FilePath) Then
            If ActiveMap.IsMapFinal Then
                MsgBox("This map has been marked as ""Final"" and cannot be saved." + vbNewLine + "You may save an editable copy using File > SaveAs.")
            Else
                SaveFile(ActiveMap.FilePath)
            End If
        Else
            btnSaveAs_Click(sender, e)
        End If
    End Sub

    Private Sub SaveFile(fileName As String)
        Dim fileExists As Boolean = My.Computer.FileSystem.FileExists(fileName)
        Dim isReadOnly As Boolean = False
        If fileExists Then
            isReadOnly = My.Computer.FileSystem.GetFileInfo(fileName).IsReadOnly
        End If

        If isReadOnly Then
            MsgBox("Unable to save map file, the file is set to read-only." + vbNewLine + "Please try saving using File > SaveAs.")
        Else
            ActiveMap.IsMapFinal = False
            My.Computer.FileSystem.WriteAllText(fileName, ActiveMap.GetSaveData(), False)
            ActiveMap.FilePath = fileName
            ActiveMap.IsModified = False
            UpdateMapTabs()
            UpdateFormTitle()
            picMap.Invalidate()
        End If
    End Sub

#End Region

    Private Sub FRMEditor_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        IsDrawing = False
    End Sub

    Public Function IsMouseInBounds() As Boolean
        If isMouseOnMap Then
            Return ActiveMap.IsMouseInBounds(mouseX, mouseY)
        Else
            Return False
        End If
    End Function

    Private Sub picActive_Paint(sender As Object, e As PaintEventArgs) Handles picActive.Paint
        If ActiveEditMode.ActiveToolMode = ToolMode.Eraser Then
            e.Graphics.Clear(picActive.BackColor)
        Else
            If ActiveEditMode Is buildingEditMode Then
                If buildingEditMode.ActiveBuilding.HasData And buildingEditMode.ActiveBuilding.BuildingId <> "" And buildingEditMode.ActiveToolMode <> ToolMode.Eraser Then
                    e.Graphics.Clear(picActive.BackColor)
                    buildingEditMode.ActiveBuilding.DrawThumbnail(e.Graphics, True)
                Else
                    e.Graphics.Clear(picActive.BackColor)
                    e.Graphics.DrawImage(ButtonNeutral, 0, 0, TileSizeX, TileSizeY)
                    e.Graphics.DrawImage(ButtonOverlay, 0, 0, TileSizeX, TileSizeY)
                End If
            ElseIf ActiveEditMode Is unitEditMode Then
                If unitEditMode.ActiveUnit.HasData And unitEditMode.ActiveUnit.UnitId <> "" And unitEditMode.ActiveToolMode <> ToolMode.Eraser Then
                    e.Graphics.Clear(picActive.BackColor)
                    unitEditMode.ActiveUnit.DrawThumbnail(e.Graphics, True)
                Else
                    e.Graphics.Clear(picActive.BackColor)
                    e.Graphics.DrawImage(ButtonNeutral, 0, 0, TileSizeX, TileSizeY)
                End If
            End If
        End If
    End Sub

#Region "Menu & UI Events"

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSize_Click(sender As Object, e As EventArgs) Handles btnSize.Click
        ResizeMap(txtWidth.Value, txtHeight.Value)
    End Sub

    Private Sub chkGrid_CheckedChanged(sender As Object, e As EventArgs) Handles chkGrid.CheckedChanged, mnuchkGrid.CheckedChanged
        DrawGrid = sender.Checked
        chkGrid.Checked = DrawGrid
        mnuchkGrid.Checked = DrawGrid
        picMap.Invalidate()
    End Sub

    Private Sub mnuchkShadows_CheckedChanged(sender As Object, e As EventArgs) Handles mnuchkShadows.CheckedChanged
        DrawShadows = sender.Checked
        picMap.Invalidate()
    End Sub

    Private Sub mnuchkTeamIndicators_Click(sender As Object, e As EventArgs) Handles mnuchkTeamIndicators.Click
        DrawTeamIndicators = sender.Checked
        picMap.Invalidate()
    End Sub

    Private Sub mnuchkDebugBuildingPos_CheckedChanged(sender As Object, e As EventArgs) Handles mnuchkDebugBuildingPos.CheckedChanged
        DrawBuildingDebugPos = sender.Checked
        picMap.Invalidate()
    End Sub

    Private Sub mnuchkDebugUnitPos_CheckedChanged(sender As Object, e As EventArgs) Handles mnuchkDebugUnitPos.CheckedChanged
        DrawUnitDebugPos = sender.Checked
        picMap.Invalidate()
    End Sub

    Private Sub btnDeleteObject_Click(sender As Object, e As EventArgs) Handles btnDeleteSelectedObject.Click, btnMapDeleteObject.Click
        If ActiveEditMode Is tileEditMode Then
            'TODO: Deleted selected tile(s).
        ElseIf ActiveEditMode Is buildingEditMode Then
            If ActiveMap.SelectedBuilding IsNot Nothing Then
                btnDeleteSelectedObject.Enabled = False
                btnObjectProperties.Enabled = False
                ActiveMap.DeleteBuilding(ActiveMap.SelectedBuilding)
            End If
        ElseIf ActiveEditMode Is unitEditMode Then
            If ActiveMap.SelectedUnit IsNot Nothing Then
                btnDeleteSelectedObject.Enabled = False
                btnObjectProperties.Enabled = False
                ActiveMap.DeleteUnit(ActiveMap.SelectedUnit)
            End If
        End If

        ActiveMap.ClearSelection()
        picMap.Invalidate()
        UpdateMapTabs()
        UpdateFormTitle()
    End Sub

    Private Sub btnConfigEditor_Click(sender As Object, e As EventArgs) Handles btnConfigEditor.Click
        FrmConfigEditor.ShowDialog(Me)
    End Sub

    Private Sub mnuchkDeveloper_CheckedChanged(sender As Object, e As EventArgs) Handles mnuchkDeveloper.Click
        Dim shouldToggle As Boolean = False
        If Not mnuDev.Visible And Not skipDeveloperWarning Then
            If MsgBox("Note: Developer Mode is intended for advanced development and modding efforts and is not intended for general use. Changes made using developer options can potentially break normal editing ability.", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation, "Enable Developer Mode") = MsgBoxResult.Ok Then
                shouldToggle = True
                skipDeveloperWarning = True
            End If
        Else
            shouldToggle = True
        End If
        If shouldToggle Then
            mnuchkDeveloper.Checked = Not mnuchkDeveloper.Checked
            mnuDev.Visible = mnuchkDeveloper.Checked
            separator3.Visible = mnuchkDeveloper.Checked
            mnuImport.Visible = mnuchkDeveloper.Checked
            btnExportAS.Visible = mnuchkDeveloper.Checked
            separator13.Visible = mnuchkDeveloper.Checked
            mnuchkDebugBuildingPos.Visible = mnuchkDeveloper.Checked
            mnuchkDebugUnitPos.Visible = mnuchkDeveloper.Checked
        End If
    End Sub

    Private Sub btnPlayInGame_Click(sender As Object, e As EventArgs) Handles btnPlayInGame.ButtonClick, btnPlayInGameDefault.Click
        launchGamePlayer(False)
    End Sub

    Private Sub btnPlayInGameMods_Click(sender As Object, e As EventArgs) Handles btnPlayInGameMods.Click
        launchGamePlayer(True)
    End Sub

    Private Sub launchGamePlayer(modded As Boolean)
        Dim autoPlay As Boolean = Not modded
        Dim autoPlayString As String = If(autoPlay, "yes", "no")
        Dim skipMenu As Boolean = mnuchkSkipMenu.Checked
        Dim skipMenuString As String = If(skipMenu, "yes", "no")
        Dim size As Size = New Size(If(modded, 750, 600), 400)
        Dim sizeString As String = size.Width.ToString() + "x" + size.Height.ToString()

        ' Save the map to a temporary file without changing anything inside the editor such as the unsaved file status.
        Dim fileName As String = My.Computer.FileSystem.GetTempFileName()
        My.Computer.FileSystem.WriteAllText(fileName, ActiveMap.GetSaveData(), False)

        ' Basic sanitization of the filename for the command line and for the AIR runtime to use.
        fileName = """" + fileName.Replace("\", "/") + """"

        Dim commandArgs As String = If(mnuDev.Visible, "-console ", "") + "-autoplay=" + autoPlayString + " -skipmenu=" + skipMenuString + " -size " + sizeString + " -cammfile " + fileName

        If Environment.OSVersion.VersionString.Contains("Windows") Then
            If File.Exists(CACPlayerPath_Windows1) Then
                Process.Start(CACPlayerPath_Windows1, commandArgs)
            ElseIf File.Exists(CACPlayerPath_Windows2) Then
                Process.Start(CACPlayerPath_Windows2, commandArgs)
            Else
                If MsgBox("In order to enable the level player, you need to download and install the standalone CAC Player app from " + btnExternal9.Tag + Environment.NewLine + Environment.NewLine + "Press OK to open the webpage." + Environment.NewLine + Environment.NewLine + "Note: CAMM needs to find the CAC Player Windows program (.exe) in the default 'Installation Location' on Windows.", MsgBoxStyle.OkCancel + MsgBoxStyle.Information) = MsgBoxResult.Ok Then
                    btnExternal_Click(btnExternal4, New EventArgs())
                End If
            End If
        ElseIf Directory.Exists(CACPlayerPath_MacOS) Then
            Process.Start("open", "'" + CACPlayerPath_MacOS + "' --args " + commandArgs)
        ElseIf Directory.Exists("/Applications") Then
            If MsgBox("In order to enable the level player, you need to download and install the standalone CAC Player app from " + btnExternal9.Tag + Environment.NewLine + Environment.NewLine + "Press OK to open the webpage." + Environment.NewLine + Environment.NewLine + "Note: CAMM needs to find the CAC Player Mac app (.app) in the default 'Installation Location' on Macintosh/Mac OS X.", MsgBoxStyle.OkCancel + MsgBoxStyle.Information) = MsgBoxResult.Ok Then
                btnExternal_Click(btnExternal4, New EventArgs())
            End If
        Else
            MsgBox("Sorry, your operating system is currently not supported by this feature.", MsgBoxStyle.OkOnly, "Play Level: Operating System not supported")
        End If
    End Sub

    Private Sub btnEditTiles_Click(sender As Object, e As EventArgs) Handles btnEditTiles.Click
        SwitchEditMode(tileEditMode)
    End Sub

    Private Sub btnEditBuildings_Click(sender As Object, e As EventArgs) Handles btnEditBuildings.Click
        SwitchEditMode(buildingEditMode)
    End Sub

    Private Sub btnEditUnits_Click(sender As Object, e As EventArgs) Handles btnEditUnits.Click
        SwitchEditMode(unitEditMode)
    End Sub

    Private Sub btnEditShroud_Click(sender As Object, e As EventArgs) Handles btnEditShroud.Click
        'TODO: Shroud edit mode.
    End Sub

    Private Sub btnToolPointer_Click(sender As Object, e As EventArgs) Handles btnToolPointer.Click
        SwitchToolMode(ToolMode.Pointer)
    End Sub

    Private Sub btnToolBrush_Click(sender As Object, e As EventArgs) Handles btnToolBrush.Click
        SwitchToolMode(ToolMode.Brush)
    End Sub

    Private Sub btnToolRectangleBrush_Click(sender As Object, e As EventArgs) Handles btnToolRectangleBrush.Click
        SwitchToolMode(ToolMode.RectangleBrush)
    End Sub

    Private Sub btnToolSmartBrush_Click(sender As Object, e As EventArgs) Handles btnToolSmartBrush.Click
        SwitchToolMode(ToolMode.SmartBrush)
    End Sub

    Private Sub btnToolErase_Click(sender As Object, e As EventArgs) Handles btnToolErase.Click
        SwitchToolMode(ToolMode.Eraser)
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        Using aboutForm As New FrmAbout()
            aboutForm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub btnExternal_Click(sender As Object, e As EventArgs) Handles btnExternal1.Click, btnExternal2.Click, btnExternal3.Click, btnExternal4.Click, btnExternal5.Click, btnExternal6.Click, btnExternal7.Click, btnExternal8.Click, btnExternal9.Click
        OpenLinkInDefaultBrowser(Me, CType(sender, ToolStripMenuItem).Tag.ToString())
    End Sub

    Private Sub chkAssociateFileTypeCAMM_CheckStateChanged(sender As Object, e As EventArgs) Handles chkAssociateFileTypeCAMM.CheckStateChanged
        If isLoaded Then
            If chkAssociateFileTypeCAMM.CheckState = CheckState.Checked Then

                Try
                    My.Computer.Registry.ClassesRoot.CreateSubKey(".camm").SetValue("", "CAMM", RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey(".camm").SetValue("Content Type", "application/json", RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey(".camm").SetValue("PerceivedType", "document", RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM").SetValue("", "CAMM Map File", RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM").SetValue("AlwaysShowExt", "", RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM").SetValue("BrowserFlags", 8, RegistryValueKind.DWord)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM").SetValue("EditFlags", 302144, RegistryValueKind.DWord)
                    ' Thanks to ETXAlienRobot201 for making the .camm file icon.
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM\DefaultIcon").SetValue("", """" + DataPath + "/Icons/CAMMFile.ico""", RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM\shell").SetValue("", "open")
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM\shell\open").SetValue("", "&Edit with CAMM")
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM\shell\open\command").SetValue("", Application.ExecutablePath + " ""%l"" ", RegistryValueKind.String)
                Catch ex As UnauthorizedAccessException
                    ' No access to register the .camm file extension, just ignore this.
                Catch ex As Exception
                    ' I'm sure there's any number of other things that could happen here,
                    ' we are dealing with a core system feature after all.
                    MsgBox(ex.Message + vbNewLine + vbNewLine + ex.StackTrace)
                End Try

            ElseIf chkAssociateFileTypeCAMM.CheckState = CheckState.Unchecked Then

                Try
                    If My.Computer.Registry.ClassesRoot.GetSubKeyNames().Contains(".camm") Then
                        My.Computer.Registry.ClassesRoot.DeleteSubKeyTree(".camm")
                    End If
                    If My.Computer.Registry.ClassesRoot.GetSubKeyNames().Contains("CAMM") Then
                        My.Computer.Registry.ClassesRoot.DeleteSubKeyTree("CAMM")
                    End If
                Catch ex As UnauthorizedAccessException
                    ' No access to unregister the .camm file extension, just ignore this.
                Catch ex As Exception
                    ' I'm sure there's any number of other things that could happen here,
                    ' we are dealing with a core system feature after all.
                    'MsgBox(ex.Message + vbNewLine + vbNewLine + ex.StackTrace)
                End Try

            End If

            CheckFileAssociations()
        End If
    End Sub

    Private Sub cboRectangleBrush_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cboRectangleBrush.DrawItem
        Dim g As Graphics = e.Graphics

        'Get a reference to the selected item as it's proper type.
        Dim item As RectangleBrushPreset = cboRectangleBrush.Items(e.Index)

        'Make a smaller variant of the current item's font for the File Name.
        Dim smallFont As Font = New Font(e.Font.FontFamily, e.Font.Size - 2, FontStyle.Regular)

        'Make a Brush for text based on the font color of the current item.
        Dim fontBrush As Brush = New SolidBrush(e.ForeColor)

        'Draw the combo box's default background and focus rectangle.
        e.DrawBackground()
        e.DrawFocusRectangle()

        'Draw the item's Preview Image.
        g.DrawImage(item.Preview, e.Bounds.X, e.Bounds.Y, item.Preview.Width, item.Preview.Height)

        'Draw the item's Title.
        g.DrawString(item.Title, e.Font, fontBrush, e.Bounds.X + item.Preview.Width + smallFont.Height, e.Bounds.Y + smallFont.Height)

        'Draw the item's File Name.
        g.DrawString(item.FileName, smallFont, fontBrush, e.Bounds.X + item.Preview.Width + smallFont.Height, e.Bounds.Y + smallFont.Height + e.Font.Height)
    End Sub

    Private Sub ctxMap_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ctxMap.Opening
        Dim hasAction As Boolean = False

        If ActiveMap.SelectedUnit IsNot Nothing Or ActiveMap.SelectedBuilding IsNot Nothing Then
            hasAction = True
            btnMapDeleteObject.Visible = True
            btnMapDeleteObject.Enabled = True
            btnMapObjectProperties.Visible = True
            btnMapObjectProperties.Enabled = True
            ctxMapSeparator1.Visible = True
        Else
            btnMapDeleteObject.Visible = False
            btnMapDeleteObject.Enabled = False
            btnMapObjectProperties.Visible = False
            btnMapObjectProperties.Enabled = False
            ctxMapSeparator1.Visible = False
        End If

        If hasAction Then
            lblMapNoActionsAvailable.Visible = False
        Else
            lblMapNoActionsAvailable.Visible = True
        End If
    End Sub

    Private Sub mnuEdit_DropDownOpening(sender As Object, e As EventArgs) Handles mnuEdit.DropDownOpening
        If ActiveMap.SelectedUnit IsNot Nothing Or ActiveMap.SelectedBuilding IsNot Nothing Then
            btnDeleteSelectedObject.Enabled = True
            btnObjectProperties.Enabled = True
        Else
            btnDeleteSelectedObject.Enabled = False
            btnObjectProperties.Enabled = False
        End If
    End Sub

    Private Sub btnMapObjectProperties_Click(sender As Object, e As EventArgs) Handles btnMapObjectProperties.Click, btnObjectProperties.Click
        If ActiveEditMode Is unitEditMode Then
            Dim propertiesForm As New FrmUnitProperties(ActiveMap.SelectedUnit)
            propertiesForm.ShowDialog(Me)
        ElseIf ActiveEditMode Is buildingEditMode Then
            Dim propertiesForm As New FrmBuildingProperties(ActiveMap.SelectedBuilding)
            propertiesForm.ShowDialog(Me)
        End If
        picMap.Invalidate()
    End Sub

#End Region

    Private Sub CheckFileAssociations()

        Try
            If My.Computer.Registry.ClassesRoot.GetSubKeyNames().Contains(".camm") And My.Computer.Registry.ClassesRoot.GetSubKeyNames().Contains("CAMM") Then
                If My.Computer.Registry.ClassesRoot.OpenSubKey(".camm", False).GetValue("", "-1") <> "CAMM" Or My.Computer.Registry.ClassesRoot.OpenSubKey("CAMM", False).GetValue("", "-1") <> "CAMM Map File" Then
                    chkAssociateFileTypeCAMM.CheckState = CheckState.Indeterminate
                Else
                    chkAssociateFileTypeCAMM.CheckState = CheckState.Checked
                End If
            Else
                chkAssociateFileTypeCAMM.CheckState = CheckState.Unchecked
            End If
            My.Computer.Registry.ClassesRoot.OpenSubKey(".camm", True)
            My.Computer.Registry.ClassesRoot.OpenSubKey("CAMM", True)
        Catch ex As UnauthorizedAccessException
            ' No access to read or write the registry...
            chkAssociateFileTypeCAMM.Enabled = False
            chkAssociateFileTypeCAMM.ToolTipText = "You must run CAMM as an Administrator to change this."
            'chkAssociateFileTypeMap.Enabled = False
        Catch ex As SecurityException
            ' No access to read or write the registry...
            chkAssociateFileTypeCAMM.Enabled = False
            chkAssociateFileTypeCAMM.ToolTipText = "You must run CAMM as an Administrator to change this."
            'chkAssociateFileTypeMap.Enabled = False
        Catch ex As Exception
            ' I'm sure there's any number of other things that could happen here,
            ' we are dealing with a core system feature after all.
            ' MsgBox(ex.Message + vbNewLine + vbNewLine + ex.StackTrace)
        End Try

    End Sub

#Region "Export & Import"

    Private Sub btnExportPNG_Click(sender As Object, e As EventArgs) Handles btnExportPNG.Click
        If savePng.ShowDialog(Me) = DialogResult.OK Then
            Dim w As Integer = ActiveMap.SizeX * TileSizeX
            Dim h As Integer = ActiveMap.SizeY * TileSizeY
            Dim img As Image = New Bitmap(w, h, PixelFormat.Format24bppRgb)
            Dim g As Graphics = Graphics.FromImage(img)
            Dim drawUnitTeamIndicators As Boolean = DrawTeamIndicators And ActiveEditMode Is unitEditMode
            Dim drawBuildingTeamIndicators As Boolean = DrawTeamIndicators And ActiveEditMode Is buildingEditMode
            ActiveMap.Draw(g, DrawGrid, DrawShadows, drawUnitTeamIndicators, drawBuildingTeamIndicators, False, False)
            g.Dispose()
            img.Save(savePng.FileName, ImageFormat.Png)
        End If
    End Sub

    Private Sub btnExportAS_Click(sender As Object, e As EventArgs) Handles btnExportAS.Click
        Dim exportASTileData As String = AsciiLookup(ActiveMap.SizeX) + AsciiLookup(ActiveMap.SizeY)

        For y As Integer = 0 To ActiveMap.SizeY - 1
            For x As Integer = 0 To ActiveMap.SizeX - 1
                Dim idx As Integer = ActiveMap.GetTileAt(x * TileSizeX, y * TileSizeY).TileId
                If idx < 0 Then
                    idx = 0
                End If

                Dim chr As String = AsciiLookup(idx)

                exportASTileData += chr
            Next x
        Next y

        Dim output As String = vbTab + "this.data = {" + vbNewLine
        output += vbTab + vbTab + "tiles : ""0"
        '0AAAAAAAA AAAAAAAAAAAAAAA    AAAAAAAAAAAAAAAAA 1A A"
        Dim tiles As List(Of TileDef) = (From t In TileDefs Order By t.TileId Where t.HasData).ToList()
        For Each t As TileDef In tiles
            If t.IsMinerals Then
                output += "1"
            ElseIf Not t.IsPassable Then
                output += "A"
            Else
                output += " "
            End If
        Next
        output += """.split("""",10000)," + vbNewLine
        output += vbTab + vbTab + "map_new : """ + exportASTileData + """.split("""",10000)" + vbNewLine
        output += vbTab + "};"
        FrmExportAS.txtOutput.Text = output

        FrmExportAS.ShowDialog(Me)
    End Sub

    Public ImportASTileData As String = ""

    Private Sub btnImportAS_Click(sender As Object, e As EventArgs) Handles btnImportAS.Click
        If FrmImportAS.ShowDialog(Me) = DialogResult.OK And ImportASTileData <> "" Then
            'TODO: This will have to do for now.
            Dim count As Integer = 0
            For y As Integer = 0 To (ActiveMap.SizeY - 1) * TileSizeY Step TileSizeY
                For x As Integer = 0 To (ActiveMap.SizeX - 1) * TileSizeX Step TileSizeX
                    'ReDim Preserve MapTiles(count)
                    'MapTiles(count) = New Tile(x, y)

                    Dim idx As Integer = AsciiLookup.IndexOf(ImportASTileData.ToCharArray()(count).ToString())
                    Dim tileId As Integer = -1
                    If idx > 0 Then
                        tileId = idx ' Old calculation: (4350 + 2 * idx)
                    End If

                    For j As Integer = 0 To TileDefs.Count - 1
                        If tileId = TileDefs(j).TileId Then
                            ActiveMap.SetTile(x, y, New Tile(tileId))
                            Exit For
                        End If
                    Next

                    count += 1
                Next x
            Next y

            ActiveMap.Title += " (Imported ActionScript)"
            UpdateMapTabs()
            UpdateFormTitle()
            UpdateMapSize()
            picMap.Invalidate()
        End If
    End Sub

#End Region

    Private Sub btnMapProperties_Click(sender As Object, e As EventArgs) Handles btnMapProperties.Click
        FrmMapProperties.ShowDialog(Me)
        UpdateMapTabs()
        UpdateFormTitle()
    End Sub

    Private Sub mapTabs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mapTabs.SelectedIndexChanged
        'ActiveLevelNum = CBOLevel.SelectedIndex
        UpdateFormTitle()
        UpdateMapSize()
        picMap.Invalidate()
    End Sub

    Private Sub UpdateMapTabs()
        If Maps.Count < mapTabs.TabPages.Count Then
            Do
                mapTabs.TabPages.RemoveAt(mapTabs.TabPages.Count - 1)
            Loop Until Maps.Count = mapTabs.TabPages.Count
        End If
        If mapTabs.TabPages.Count > 0 Then
            For i As Integer = 0 To mapTabs.TabPages.Count - 1
                Dim tabText As String = Maps(i).FileName
                If String.IsNullOrEmpty(tabText) Then
                    tabText = Maps(i).Title
                End If
                If Maps(i).IsModified Then
                    tabText += "*"
                End If
                mapTabs.TabPages(i).Text = tabText
                mapTabs.TabPages(i).ToolTipText = Maps(i).Title
                If Not String.IsNullOrEmpty(Maps(i).Author) Then
                    mapTabs.TabPages(i).ToolTipText += vbNewLine + "Author: " + Maps(i).Author
                End If
                If Not String.IsNullOrEmpty(Maps(i).FilePath) Then
                    mapTabs.TabPages(i).ToolTipText += vbNewLine + Maps(i).FilePath
                End If
            Next
        End If
        If Maps.Count > mapTabs.TabPages.Count Then
            For i As Integer = mapTabs.TabPages.Count To Maps.Count - 1
                Dim tabText As String = Maps(i).FileName
                If String.IsNullOrEmpty(tabText) Then
                    tabText = Maps(i).Title
                End If
                If Maps(i).IsModified Then
                    tabText += "*"
                End If
                Dim newTab = New TabPage(tabText)
                newTab.ToolTipText = Maps(i).Title
                If Not String.IsNullOrEmpty(Maps(i).Author) Then
                    newTab.ToolTipText += vbNewLine + "Author: " + Maps(i).Author
                End If
                If Not String.IsNullOrEmpty(Maps(i).FilePath) Then
                    newTab.ToolTipText += vbNewLine + Maps(i).FilePath
                End If
                mapTabs.TabPages.Add(newTab)
            Next
        End If
        picMap.Invalidate()
    End Sub

    Private Sub UpdateFormTitle()
        Dim title As String = baseFormTitle
        If Maps.Count > 0 Then
            title += " - " + ActiveMap.Title
            If Not String.IsNullOrEmpty(ActiveMap.FilePath) Then
                title += " - " + My.Computer.FileSystem.GetFileInfo(ActiveMap.FilePath).Name
            Else
                title += " - (Unsaved)"
            End If
            If ActiveMap.IsModified Then
                title += "*"
            End If
        End If
        Me.Text = title
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim menuLocation As Point = mapTabs.PointToClient(ctxMapTabs.Location)

        For i As Integer = 0 To Maps.Count - 1
            Dim rect As Rectangle = mapTabs.GetTabRect(i)
            If rect.Contains(menuLocation) Then
                Dim mapsToClose As List(Of Map) = New List(Of Map)()
                mapsToClose.Add(Maps(i))
                CloseMaps(mapsToClose)
                Exit For
            End If
        Next
    End Sub

    Private Sub btnCloseAllLeft_Click(sender As Object, e As EventArgs) Handles btnCloseAllLeft.Click
        Dim menuLocation As Point = mapTabs.PointToClient(ctxMapTabs.Location)

        If Maps.Count > 1 Then
            For i As Integer = 0 To Maps.Count - 1
                Dim rect As Rectangle = mapTabs.GetTabRect(i)
                If rect.Contains(menuLocation) Then
                    If i > 0 Then
                        Dim mapsToClose As List(Of Map) = New List(Of Map)()
                        mapsToClose.AddRange(Maps.GetRange(0, i))
                        CloseMaps(mapsToClose)
                    End If
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub btnCloseAllRight_Click(sender As Object, e As EventArgs) Handles btnCloseAllRight.Click
        Dim menuLocation As Point = mapTabs.PointToClient(ctxMapTabs.Location)

        If Maps.Count > 1 Then
            For i As Integer = 0 To Maps.Count - 1
                Dim rect As Rectangle = mapTabs.GetTabRect(i)
                If rect.Contains(menuLocation) Then
                    If i < Maps.Count Then
                        Dim mapsToClose As List(Of Map) = New List(Of Map)()
                        mapsToClose.AddRange(Maps.GetRange(i + 1, (Maps.Count - 1) - (i + 1) + 1))
                        CloseMaps(mapsToClose)
                    End If
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub btnCloseAllExceptThis_Click(sender As Object, e As EventArgs) Handles btnCloseAllExceptThis.Click
        Dim exceptMap As Map = ActiveMap
        Dim mapsToClose As List(Of Map) = New List(Of Map)()
        mapsToClose.AddRange(Maps)
        mapsToClose.Remove(exceptMap)
        CloseMaps(mapsToClose)
    End Sub

    Private Sub mapTabs_MouseDown(sender As Object, e As MouseEventArgs) Handles mapTabs.MouseDown
        If e.Button = MouseButtons.Right Then
            For i As Integer = 0 To Maps.Count - 1
                Dim rect As Rectangle = mapTabs.GetTabRect(i)
                If rect.Contains(e.Location) Then
                    If i >= 0 Then
                        mapTabs.SelectedIndex = i
                    End If
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub UpdateMapTabsMaintainSelected(currentlyActiveMap As Map, currentlySelectedTabIndex As Integer)
        UpdateMapTabs()
        If Maps.Contains(currentlyActiveMap) Then
            mapTabs.SelectedIndex = Maps.IndexOf(currentlyActiveMap)
        ElseIf currentlySelectedTabIndex >= mapTabs.TabPages.Count Then
            mapTabs.SelectedIndex = mapTabs.TabPages.Count - 1
        End If
    End Sub

    Private Function CloseMaps(mapsToClose As List(Of Map)) As Integer
        Dim numberMapsClosed As Integer = 0

        Dim currentlyActiveMap As Map = ActiveMap
        Dim currentlySelectedTabIndex As Integer = mapTabs.SelectedIndex

        Dim unsavedMaps As Integer = 0
        Dim mapsToCloseForSure As List(Of Map) = New List(Of Map)()

        For Each map As Map In mapsToClose
            If map.IsModified Then
                unsavedMaps += 1
            Else
                mapsToCloseForSure.Add(map)
            End If
        Next

        For Each map In mapsToCloseForSure
            Maps.Remove(map)
            mapsToClose.Remove(map)
            numberMapsClosed += 1
        Next

        If unsavedMaps > 0 Then
            UpdateMapTabsMaintainSelected(currentlyActiveMap, currentlySelectedTabIndex)

            If MsgBox("There are " + unsavedMaps.ToString() + " maps to be closed with unsaved changes." + vbNewLine + "Are you sure you want to close them and discard all changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For Each map In mapsToClose
                    Maps.Remove(map)
                    numberMapsClosed += 1
                Next
            End If
        End If

        If Maps.Count < 1 Then
            NewMap()
        End If

        UpdateMapTabsMaintainSelected(currentlyActiveMap, currentlySelectedTabIndex)
        UpdateFormTitle()
        UpdateMapSize()
        picMap.Invalidate()

        Return numberMapsClosed
    End Function

    Private Sub SwitchEditMode(mode As EditMode)
        ' Update currently active edit mode.
        ActiveEditMode = mode

        ' Enable all edit mode buttons.
        btnEditTiles.Enabled = True
        btnEditBuildings.Enabled = True
        btnEditUnits.Enabled = True
        'btnEditShroud.Enabled = True

        ' Hide all edit mode panels.
        pnlTiles.Hide()
        pnlBuildings.Hide()
        pnlUnits.Hide()

        ' Change label text to currently active edit mode.
        ' Change selected object preview to selected object of active edit mode.
        ' Disable button of currently active edit mode.
        ' Show the relevant edit mode panel.
        If mode Is tileEditMode Then
            lblSelected.Text = "Selected Tile:"
            picActive.Image = tileEditMode.ActiveTile.Image
            btnEditTiles.Enabled = False
            pnlTiles.Show()
        ElseIf mode Is buildingEditMode Then
            lblSelected.Text = "Selected Building:"
            picActive.Image = buildingEditMode.ActiveBuilding.SmallImage
            btnEditBuildings.Enabled = False
            pnlBuildings.Show()
        ElseIf mode Is unitEditMode Then
            lblSelected.Text = "Selected Unit:"
            picActive.Image = unitEditMode.ActiveUnit.SmallImage
            btnEditUnits.Enabled = False
            pnlUnits.Show()
        End If

        ' Disable the Rectangle Brush tool unless we're switching into Tile edit mode.
        ' Pointer tool is currently disabled for Tile edit mode as it does nothing.
        If mode Is tileEditMode Then
            If tileEditMode.ActiveToolMode <> ToolMode.RectangleBrush Then
                btnToolRectangleBrush.Enabled = True
            End If
            btnToolRectangleBrush.Visible = True

            btnToolPointer.Visible = False
            btnToolPointer.Enabled = False
        Else
            btnToolRectangleBrush.Visible = False
            btnToolRectangleBrush.Enabled = False
            btnToolPointer.Enabled = True
            btnToolPointer.Visible = True
        End If

        ' Ensure the GUI state is updated to match the tool mode of the active edit mode.
        SwitchToolMode(ActiveEditMode.ActiveToolMode)
    End Sub

    Private Sub SwitchToolMode(mode As ToolMode)
        ' Update currently active tool mode.
        ActiveEditMode.ActiveToolMode = mode

        ' Enable all buttons.
        btnToolPointer.Enabled = True
        btnToolBrush.Enabled = True
        btnToolRectangleBrush.Enabled = True
        btnToolSmartBrush.Enabled = True
        btnToolErase.Enabled = True

        ' Hide the Rectange Brush Presets dropdown.
        cboRectangleBrush.Hide()

        ' Disable button of currently active tool mode.
        ' Do any other tool specific stuff.
        Select Case mode
            Case ToolMode.Pointer
                btnToolPointer.Enabled = False
            Case ToolMode.Brush
                btnToolBrush.Enabled = False
            Case ToolMode.SmartBrush
                btnToolSmartBrush.Enabled = False
            Case ToolMode.RectangleBrush
                btnToolRectangleBrush.Enabled = False
                cboRectangleBrush.Show()
                cboRectangleBrush.BringToFront()
                cboRectangleBrush.Focus()
            Case ToolMode.Eraser
                btnToolErase.Enabled = False
        End Select

        ' Clear currently selected objects.
        ActiveMap.ClearSelection()

        ' Refresh drawing surfaces.
        picTiles.Invalidate()
        picBuildings.Invalidate()
        picUnits.Invalidate()
        picActive.Invalidate()
        picMap.Invalidate()
    End Sub
End Class
