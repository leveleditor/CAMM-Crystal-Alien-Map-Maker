'-============================================================================================-'
'  CAMM (Crystal Alien Map Maker) program created by Josh (aka. leveleditor / Leveleditor6680) '
'-============================================================================================-'

Imports System.Drawing.Imaging
Imports System.Security
Imports Microsoft.Win32
Imports Nini.Config

Public Class FrmEditor

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

    Private isLoaded As Boolean = False
    Private isMouseOnMap As Boolean = False
    Public IsDrawing As Boolean = False
    Private mouseX As Integer
    Private mouseY As Integer
    Private mouseXNoSnap As Integer
    Private mouseYNoSnap As Integer

    'The last key that was pressed.
    Private lastKeyDown As Keys = Keys.None

    Public ActiveEditMode As EditMode = EditMode.Tiles
    Public ActiveToolMode As ToolMode = ToolMode.Brush

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

    'Starting point for the rectangle brush selection.
    Private rectSelectStartX As Integer = -1
    Private rectSelectStartY As Integer = -1

    ReadOnly customToolStripRenderer As ToolStripProfessionalRenderer = New ToolStripProfessionalRenderer(New CustomColorTable())

    Private activeTile As Tile 'The currently active tile selection.
    Private activeBuilding As Building 'The currently active object selection.
    Private activeUnit As Unit 'The currently active unit selection.

    Private closestUnit As Unit = Nothing 'The closest unit to the cursor position.
    Private selectedUnit As Unit = Nothing 'The currently selected unit.

    Private Sub FRMEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Storing default form title.
        baseFormTitle = Me.Text

        'Loading assets.
        LoadAssets()

        'Setting version information.
        lblAboutVersion.Text = BuildType + " v" + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString
        If My.Application.Info.Version.Revision > 0 Then
            lblAboutVersion.Text += "." + My.Application.Info.Version.Build.ToString + "." + My.Application.Info.Version.Revision.ToString
        ElseIf My.Application.Info.Version.Build > 0 And My.Application.Info.Version.Revision <= 0 Then
            lblAboutVersion.Text += "." + My.Application.Info.Version.Build.ToString
        End If
        lblAboutVersion.Text += " by Leveleditor6680 // Josh"

        'Setting ToolStrip renderers
        mnuMain.Renderer = customToolStripRenderer
        staInfoBar.Renderer = customToolStripRenderer
        ctxMapTabs.Renderer = customToolStripRenderer
        ctxMap.Renderer = customToolStripRenderer

        For Each menuItem As ToolStripMenuItem In mnuMain.Items.OfType(Of ToolStripMenuItem)()
            'Dim dropDown As ToolStripDropDownMenu = MenuItem.DropDown
            'dropDown.ShowImageMargin = False
            menuItem.Text = menuItem.Text.ToUpper()
        Next

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

        CheckFileAssociations()

        'Dynamically setting picTiles size.
        picTiles.Size = New Size(TileSizeX + 1, (TileDefs.Length * TileSizeY) + 1)
        picTiles.Invalidate()

        'Dynamically setting picBuildings size.
        picBuildings.Size = New Size(TileSizeX + 1, (BuildingDefs.Length * TileSizeY) + 1)
        picBuildings.Invalidate()

        'Dynamically setting picUnits size.
        picUnits.Size = New Size(TileSizeX + 1, (UnitDefs.Length * TileSizeY) + 1)
        picUnits.Invalidate()

        'Setting default blank values.
        activeTile = New Tile()
        activeBuilding = New Building(0, 0)
        activeUnit = New Unit(0, 0)
        picActive.Image = Nothing

        'Start a new map.
        NewMap()

        If My.Application.CommandLineArgs.Count > 0 Then
            BeginLoadMap(My.Application.CommandLineArgs(0))
        End If

        isLoaded = True
        tmrIntro.Start()
    End Sub

    Private Sub FRMEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("There may be unsaved changes." + vbNewLine + "Are you sure you want to exit?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
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

#Region "Intro Effects"
    'TODO: Need to clean up this mess...
    Dim fadeAlpha As Integer = 350
    Dim fadeRate As Integer = 2
    Dim fadePen As Pen = Pens.Black
    Dim fadeBrush As SolidBrush = Brushes.Black
    Dim introFont As Font = New Font(FontFamily.GenericMonospace, 20, FontStyle.Bold, GraphicsUnit.Pixel)
    Dim introFont2 As Font = New Font(FontFamily.GenericMonospace, 25, FontStyle.Bold, GraphicsUnit.Pixel)
    Dim introBrush As SolidBrush = New SolidBrush(Color.FromArgb(255, 0, 255, 0))
    Dim introBrush2 As SolidBrush = Brushes.DarkGreen
    Dim introFontH As Integer = introFont.GetHeight
    Dim introFontH2 As Integer = introFont2.GetHeight
    Dim introX, introY, sIntro1Width, sIntro2Width, sIntro3Width As Integer
    Dim sIntro1 As String = "Welcome to CAMM!"
    Dim sIntro2 As String = "Crystal Alien Map Maker"
    Dim sIntro3 As String = "By Leveleditor6680 // Josh"
    Sub DrawIntro(g As Graphics)
        sIntro1Width = g.MeasureString(sIntro1, introFont).Width
        sIntro2Width = g.MeasureString(sIntro2, introFont2).Width
        sIntro3Width = g.MeasureString(sIntro3, introFont).Width
        introX = -(picMap.Location.X) + pnlMap.Width / 2
        introY = -(picMap.Location.Y) + pnlMap.Height / 3

        g.DrawRectangle(fadePen, picMap.Bounds)
        g.FillRectangle(fadeBrush, 0, -picMap.Location.Y, picMap.Width, picMap.Height)

        g.DrawString(sIntro1, introFont, introBrush2, introX - sIntro1Width / 2 + 2, introY + 2)
        g.DrawString(sIntro2, introFont2, introBrush2, introX - sIntro2Width / 2 + 2, introY + introFontH + 2)
        g.DrawString(sIntro3, introFont, introBrush2, introX - sIntro3Width / 2 + 2, introY + introFontH2 * 2 + 2)

        g.DrawString(sIntro1, introFont, introBrush, introX - sIntro1Width / 2, introY)
        g.DrawString(sIntro2, introFont2, introBrush, introX - sIntro2Width / 2, introY + introFontH)
        g.DrawString(sIntro3, introFont, introBrush, introX - sIntro3Width / 2, introY + introFontH2 * 2)
    End Sub
    Private Sub tmrIntro_Tick(sender As Object, e As EventArgs) Handles tmrIntro.Tick
        If fadeAlpha >= 0 And fadeAlpha <= 255 Then
            fadePen = New Pen(Color.FromArgb(fadeAlpha, 0, 0, 0))
            fadeBrush = New SolidBrush(Color.FromArgb(fadeAlpha, 0, 0, 0))
        End If

        If fadeAlpha <= 100 And fadeAlpha >= -155 Then
            introBrush = New SolidBrush(Color.FromArgb(fadeAlpha + 155, 0, 255, 0))
            introBrush2 = New SolidBrush(Color.FromArgb(fadeAlpha + 155, Color.DarkGreen.R, Color.DarkGreen.G, Color.DarkGreen.B))
        End If

        If fadeAlpha <= -155 Then
            tmrIntro.Stop()
        Else
            fadeAlpha -= fadeRate
        End If

        picMap.Invalidate()
    End Sub
#End Region

#Region "Grid and Map Operations"

    Private Sub ResizeMap(width As Integer, height As Integer)
        ActiveMap.SetSize(width, height)

        txtWidth.Text = ActiveMap.SizeX
        txtHeight.Text = ActiveMap.SizeY
        picMap.Size = New Size((ActiveMap.SizeX * TileSizeX) + 1, (ActiveMap.SizeY * TileSizeY) + 1)

        picMap.Invalidate()
    End Sub

#End Region

#Region "picMap Events"

    Private Sub picMap_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles picMap.MouseDoubleClick
        If ActiveToolMode = ToolMode.Pointer Then
            ctxMap.Show(picMap, e.Location)
        End If
    End Sub

    Private Sub picMap_MouseDown(sender As Object, e As MouseEventArgs) Handles picMap.MouseDown
        If e.Button = MouseButtons.Left Then
            If IsDrawing = False Then
                IsDrawing = True

                ' Start drawing.
                mouseX = e.X
                mouseY = e.Y
                PointToGrid(mouseX, mouseY)
                mouseXNoSnap = e.X
                mouseYNoSnap = e.Y

                If ActiveEditMode = EditMode.Tiles Then
                    If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                        ActiveMap.Eraser(mouseX, mouseY, ActiveEditMode)
                    ElseIf ActiveToolMode = ToolMode.RectangleBrush Then
                        rectSelectStartX = mouseX
                        rectSelectStartY = mouseY
                    ElseIf ActiveToolMode = ToolMode.SmartBrush Then
                        ActiveMap.SetTileSmart(mouseX, mouseY)
                    ElseIf activeTile.TileId = -1 Then
                        ActiveMap.Eraser(mouseX, mouseY, ActiveEditMode)
                    Else
                        ActiveMap.SetTile(mouseX, mouseY, activeTile)
                    End If
                ElseIf ActiveEditMode = EditMode.Buildings Then
                    If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                        ActiveMap.Eraser(mouseX, mouseY, ActiveEditMode)
                    Else
                        ActiveMap.SetBuilding(mouseX, mouseY, activeBuilding)
                    End If
                ElseIf ActiveEditMode = EditMode.Units Then
                    If ActiveToolMode = ToolMode.Pointer Then
                        selectedUnit = closestUnit
                        If selectedUnit IsNot Nothing Then
                            btnDeleteSelectedUnit.Enabled = True
                            btnUnitProperties.Enabled = True
                        Else
                            btnDeleteSelectedUnit.Enabled = False
                            btnUnitProperties.Enabled = False
                        End If
                    ElseIf ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                        ActiveMap.Eraser(mouseXNoSnap, mouseYNoSnap, ActiveEditMode)
                    Else
                        If mouseYNoSnap - activeUnit.Altitude > 0 Then
                            ActiveMap.SetUnit(mouseXNoSnap, mouseYNoSnap, activeUnit)
                        End If
                    End If
                ElseIf ActiveEditMode = EditMode.Shroud Then
                    'For later.
                End If

                picMap.Invalidate()
            End If
        End If
    End Sub

    Private Sub picMap_MouseUp(sender As Object, e As MouseEventArgs) Handles picMap.MouseUp
        If IsDrawing Then
            IsDrawing = False
        End If

        If ActiveEditMode = EditMode.Tiles And ActiveToolMode = ToolMode.RectangleBrush And Not My.Computer.Keyboard.CtrlKeyDown And rectSelectStartX <> -1 And rectSelectStartY <> -1 Then
            'Fill the selected rectangle with the data from the selected brush preset.
            ActiveMap.SetTileRectangle(rectSelectStartX, rectSelectStartY, mouseX, mouseY, cboRectangleBrush.SelectedItem)

            'Reset starting point for rectangle brush selection.
            rectSelectStartX = -1
            rectSelectStartY = -1
        End If
    End Sub

    Private Sub picMap_MouseMove(sender As Object, e As MouseEventArgs) Handles picMap.MouseMove
        isMouseOnMap = True
        mouseX = e.X
        mouseY = e.Y
        PointToGrid(mouseX, mouseY)
        mouseXNoSnap = e.X
        mouseYNoSnap = e.Y

        If IsDrawing Then
            If ActiveEditMode = EditMode.Tiles Then
                If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                    ActiveMap.Eraser(mouseX, mouseY, ActiveEditMode)
                ElseIf ActiveToolMode = ToolMode.SmartBrush Then
                    ActiveMap.SetTileSmart(mouseX, mouseY)
                ElseIf ActiveToolMode = ToolMode.RectangleBrush Then
                    'Placeholder
                ElseIf activeTile.TileId = -1 Then
                    ActiveMap.Eraser(mouseX, mouseY, ActiveEditMode)
                Else
                    ActiveMap.SetTile(mouseX, mouseY, activeTile)
                End If
            ElseIf ActiveEditMode = EditMode.Buildings Then
                If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                    ActiveMap.Eraser(mouseX, mouseY, ActiveEditMode)
                Else
                    ActiveMap.SetBuilding(mouseX, mouseY, activeBuilding)
                End If
            ElseIf ActiveEditMode = EditMode.Units Then
                If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                    ActiveMap.Eraser(mouseXNoSnap, mouseYNoSnap, ActiveEditMode)
                Else
                    'No click & drag for units, just imagine the spam...
                    'SetUnit(MouseXNoSnap, MouseYNoSnap)
                End If
            ElseIf ActiveEditMode = EditMode.Shroud Then
                'For later, maybe.
            End If
        End If

        Dim debug As Boolean = True
        If IsMouseInBounds() Then
            If debug = True Then
                If ActiveMap.GetTileAt(mouseX, mouseY) IsNot Nothing Then
                    lblCursorLoc.Text = ActiveMap.GetTileAt(mouseX, mouseY).TileId.ToString + " [" + ((mouseX / TileSizeX) + 1).ToString + ", " + ((mouseY / TileSizeY) + 1).ToString + "]"
                Else
                    lblCursorLoc.Text = "null [" + ((mouseX / TileSizeX) + 1).ToString + ", " + ((mouseY / TileSizeY) + 1).ToString + "]"
                End If
                If ActiveMap.GetBuildingAt(mouseX, mouseY) IsNot Nothing Then
                    lblCursorLoc.Text = ActiveMap.GetBuildingAt(mouseX, mouseY).BuildingId + " : " + lblCursorLoc.Text
                End If
            Else
                lblCursorLoc.Text = "[" + ((mouseX / TileSizeX) + 1).ToString + ", " + ((mouseY / TileSizeY) + 1).ToString + "]"
            End If
        End If

        If ActiveToolMode = ToolMode.Pointer Then
            closestUnit = ActiveMap.GetClosestUnit(mouseXNoSnap, mouseYNoSnap, 30)
        End If

        ' Redraw.
        picMap.Invalidate()
    End Sub

    Private Sub picMap_Paint(sender As Object, e As PaintEventArgs) Handles picMap.Paint
        If isLoaded Then
            Dim g As Graphics = e.Graphics

            ActiveMap.Draw(g, DrawGrid, DrawShadows, DrawTeamIndicators, DrawBuildingDebugPos, DrawUnitDebugPos)

            ' Draw the rectangle cursor / selector thingy.
            If IsMouseInBounds() Then
                If ActiveEditMode <> EditMode.Units Then
                    If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                        g.DrawRectangle(PenTileErase, mouseX - (PenTileHover.Width / 2), mouseY - (PenTileHover.Width / 2), TileSizeX + PenTileHover.Width + 1, TileSizeY + PenTileHover.Width + 1)
                    ElseIf ActiveToolMode = ToolMode.RectangleBrush And rectSelectStartX <> -1 And rectSelectStartY <> -1 Then
                        g.DrawRectangle(PenTileHover, rectSelectStartX - (PenTileHover.Width / 2), rectSelectStartY - (PenTileHover.Width / 2), mouseX - rectSelectStartX + TileSizeX + PenTileHover.Width + 1, mouseY - rectSelectStartY + TileSizeY + PenTileHover.Width + 1)
                        g.DrawRectangle(PenTileHover, rectSelectStartX + PenTileHover.Width, rectSelectStartY + PenTileHover.Width, mouseX - rectSelectStartX + TileSizeX - PenTileHover.Width - 1, mouseY - rectSelectStartY + TileSizeY - PenTileHover.Width - 1)
                    Else
                        g.DrawRectangle(PenTileHover, mouseX - (PenTileHover.Width / 2), mouseY - (PenTileHover.Width / 2), TileSizeX + PenTileHover.Width + 1, TileSizeY + PenTileHover.Width + 1)
                    End If
                End If
                If ActiveEditMode = EditMode.Tiles Then
                    'g.DrawImage(ActiveTile.Image, MouseX, MouseY)
                ElseIf ActiveEditMode = EditMode.Buildings And activeBuilding.BuildingId <> "" Then
                    'activeBuilding.DrawBaseplate(g, mouseX, mouseY)
                    'activeBuilding.Draw(g, mouseX, mouseY, True)
                ElseIf ActiveEditMode = EditMode.Units Then
                    If ActiveToolMode = ToolMode.Pointer Then
                        If closestUnit IsNot Nothing Then
                            If DrawTeamIndicators Then
                                closestUnit.DrawTeamIndicator(g)
                            End If
                            g.DrawImage(UnitSelectionHover, closestUnit.X - CInt(UnitSelectionHover.Width / 2), closestUnit.Y - closestUnit.Altitude - CInt(UnitSelectionHover.Height / 2), UnitSelectionHover.Width, UnitSelectionHover.Height)
                            'g.DrawString(closestUnit.UnitId, New Font(FontFamily.GenericMonospace, 12, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.GreenYellow, closestUnit.X, closestUnit.Y)
                        End If
                    ElseIf ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                        g.DrawEllipse(PenTileErase, mouseXNoSnap - 30, mouseYNoSnap - 30, 60, 60)
                    End If
                    If isMouseOnMap And Not IsDrawing And ActiveToolMode <> ToolMode.Eraser And Not My.Computer.Keyboard.CtrlKeyDown And ActiveToolMode <> ToolMode.Pointer And activeUnit.UnitId <> "" Then
                        If mouseYNoSnap - activeUnit.Altitude > 0 Then
                            activeUnit.Draw(g, mouseXNoSnap, mouseYNoSnap, DrawShadows)
                        Else
                            g.DrawLine(New Pen(Color.Red, 2), mouseXNoSnap - 5, mouseYNoSnap - 5, mouseXNoSnap + 5, mouseYNoSnap + 5)
                            g.DrawLine(New Pen(Color.Red, 2), mouseXNoSnap + 5, mouseYNoSnap - 5, mouseXNoSnap - 5, mouseYNoSnap + 5)
                        End If
                    End If
                End If
            End If

            If ActiveEditMode = EditMode.Units Then
                If ActiveToolMode = ToolMode.Pointer Then
                    If selectedUnit IsNot Nothing Then
                        If DrawTeamIndicators Then
                            selectedUnit.DrawTeamIndicator(g)
                        End If
                        g.DrawImage(UnitSelectionClick, selectedUnit.X - CInt(UnitSelectionHover.Width / 2), selectedUnit.Y - selectedUnit.Altitude - CInt(UnitSelectionHover.Height / 2), UnitSelectionHover.Width, UnitSelectionHover.Height)
                        'g.DrawString(selectedUnit.UnitId, New Font(FontFamily.GenericMonospace, 12, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.GreenYellow, selectedUnit.X + 10, selectedUnit.Y - selectedUnit.Altitude - 10)
                    End If
                End If
            End If

            'Draw intro animation.
            If tmrIntro.Enabled Then
                DrawIntro(g)
            End If
        End If
    End Sub

    Private Sub picMap_MouseEnter(sender As Object, e As EventArgs) Handles picMap.MouseEnter
        isMouseOnMap = True
        pnlMap.Focus()
        'Windows.Forms.Cursor.Hide()
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

            For i As Integer = 0 To TileDefs.Length - 1
                If TileDefs(i).HasData Then
                    TileDefs(i).Draw(e.Graphics, 0, i * TileSizeY)
                End If
            Next

            ' Draw the grid.
            DrawGridLines(e.Graphics, picTiles.ClientSize.Width, picTiles.ClientSize.Height)

            'Draw Rectangle around selected Tile.
            If ActiveEditMode = EditMode.Tiles And activeTile.TileId <> -1 And ActiveToolMode <> ToolMode.Eraser And ActiveToolMode <> ToolMode.Pointer Then
                e.Graphics.DrawRectangle(PenSelected, selXTiles + (PenSelected.Width / 2) + 1, selYTiles + (PenSelected.Width / 2) + 1, TileSizeX - PenSelected.Width - 1, TileSizeY - PenSelected.Width - 1)
            End If

            ' Draw the rectangle cursor / selector thingy.
            If isMouseOnSelections Then
                e.Graphics.DrawRectangle(PenSelectionHover, mouseX + (PenSelectionHover.Width / 2) + 1, mouseY + (PenSelectionHover.Width / 2) + 1, TileSizeX - PenSelectionHover.Width - 1, TileSizeY - PenSelectionHover.Width - 1)
            End If

        End If
    End Sub

    Private Sub picTiles_MouseEnter(sender As Object, e As EventArgs) Handles picTiles.MouseEnter
        isMouseOnSelections = True
        isMouseOnMap = False
        pnlTiles.Focus()
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
            mouseX = e.X
            mouseY = e.Y
            PointToGrid(mouseX, mouseY)
            mouseXNoSnap = e.X
            mouseYNoSnap = e.Y
            selXTiles = mouseX
            selYTiles = mouseY

            For i As Integer = 0 To TileDefs.Length - 1
                If mouseY = i * TileSizeY Then
                    picActive.Image = TileDefs(i).Image
                    activeTile.TileId = TileDefs(i).TileId
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
            For i As Integer = 0 To BuildingDefs.Length - 1
                If BuildingDefs(i).HasData Then
                    BuildingDefs(i).DrawThumbnail(e.Graphics, True)
                End If
            Next

            ' Draw the grid.
            DrawGridLines(e.Graphics, picBuildings.ClientSize.Width, picBuildings.ClientSize.Height)

            'Draw Rectangle around selected Buildings.
            If ActiveEditMode = EditMode.Buildings And activeBuilding.BuildingId <> "" And ActiveToolMode <> ToolMode.Eraser And ActiveToolMode <> ToolMode.Pointer Then
                e.Graphics.DrawRectangle(PenSelected, selXBuildings + (PenSelected.Width / 2) + 1, selYBuildings + (PenSelected.Width / 2) + 1, TileSizeX - PenSelected.Width - 1, TileSizeY - PenSelected.Width - 1)
            End If

            ' Draw the rectangle cursor / selector thingy.
            If isMouseOnSelections Then
                e.Graphics.DrawRectangle(PenSelectionHover, mouseX + (PenSelectionHover.Width / 2) + 1, mouseY + (PenSelectionHover.Width / 2) + 1, TileSizeX - PenSelectionHover.Width - 1, TileSizeY - PenSelectionHover.Width - 1)
            End If
        End If
    End Sub

    Private Sub picBuildings_MouseEnter(sender As Object, e As EventArgs) Handles picBuildings.MouseEnter
        isMouseOnSelections = True
        isMouseOnMap = False
        pnlBuildings.Focus()
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
            mouseX = e.X
            mouseY = e.Y
            PointToGrid(mouseX, mouseY)
            mouseXNoSnap = e.X
            mouseYNoSnap = e.Y
            selXBuildings = mouseX
            selYBuildings = mouseY

            For i As Integer = 0 To BuildingDefs.Length - 1
                If BuildingDefs(i).Location = New Point(mouseX, mouseY) Then
                    picActive.Image = BuildingDefs(i).SmallImage
                    activeBuilding.BuildingId = BuildingDefs(i).BuildingId
                    activeBuilding.Team = BuildingDefs(i).Team
                    activeBuilding.BuildingW = BuildingDefs(i).BuildingW
                    activeBuilding.BuildingH = BuildingDefs(i).BuildingH
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
            For i As Integer = 0 To UnitDefs.Length - 1
                If UnitDefs(i).HasData Then
                    UnitDefs(i).DrawThumbnail(e.Graphics, True)
                End If
            Next

            ' Draw the grid.
            DrawGridLines(e.Graphics, picUnits.ClientSize.Width, picUnits.ClientSize.Height)

            'Draw Rectangle around selected Units.
            If ActiveEditMode = EditMode.Units And activeUnit.UnitId <> "" And ActiveToolMode <> ToolMode.Eraser And ActiveToolMode <> ToolMode.Pointer Then
                e.Graphics.DrawRectangle(PenSelected, selXUnits + (PenSelected.Width / 2) + 1, selYUnits + (PenSelected.Width / 2) + 1, TileSizeX - PenSelected.Width - 1, TileSizeY - PenSelected.Width - 1)
            End If

            ' Draw the rectangle cursor / selector thingy.
            If isMouseOnSelections Then
                e.Graphics.DrawRectangle(PenSelectionHover, mouseX + (PenSelectionHover.Width / 2) + 1, mouseY + (PenSelectionHover.Width / 2) + 1, TileSizeX - PenSelectionHover.Width - 1, TileSizeY - PenSelectionHover.Width - 1)
            End If
        End If
    End Sub

    Private Sub picUnits_MouseEnter(sender As Object, e As EventArgs) Handles picUnits.MouseEnter
        isMouseOnSelections = True
        isMouseOnMap = False
        pnlUnits.Focus()
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
            mouseX = e.X
            mouseY = e.Y
            PointToGrid(mouseX, mouseY)
            mouseXNoSnap = e.X
            mouseYNoSnap = e.Y
            selXUnits = mouseX
            selYUnits = mouseY

            For i As Integer = 0 To UnitDefs.Length - 1
                If UnitDefs(i).Position = New Point(mouseX, mouseY) Then
                    picActive.Image = UnitDefs(i).SmallImage
                    activeUnit.UnitId = UnitDefs(i).UnitId
                    activeUnit.Team = UnitDefs(i).Team
                    activeUnit.Altitude = UnitDefs(i).Altitude
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

    Public Sub NewMap()
        Dim newMap As Map = New Map()
        Maps.Add(newMap)
        UpdateMapTabs()
        ActiveMapNum = Maps.IndexOf(newMap)
        UpdateFormTitle()

        picMap.Size = New Size((ActiveMap.SizeX * TileSizeX) + 1, (ActiveMap.SizeY * TileSizeY) + 1)
        txtWidth.Text = ActiveMap.SizeX
        txtHeight.Text = ActiveMap.SizeY
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        'Me.OpenMap.Reset()
        'Me.OpenMap.DefaultExt = "CAMM Map Files|*.map"
        Me.openMap.FileName = "Map1.camm"
        'Me.OpenMap.Filter = "CAMM Map Files|*.map|All Files|*.*"
        Me.openMap.FilterIndex = 1
        Me.openMap.RestoreDirectory = False
        Me.openMap.Title = "Select Map File To Open..."
        Me.openMap.InitialDirectory = FullBasePath + SavePath

        If Me.openMap.ShowDialog = DialogResult.OK Then
            BeginLoadMap(Me.openMap.FileName)
        End If
    End Sub
    Public Sub BeginLoadMap(fileName As String)
        Dim source As New IniConfigSource(fileName)
        Dim config As IConfig = source.Configs.Item("CAMM")
        If config Is Nothing Then
            NewMap()
            ActiveMap.LoadMapv0(source)
            EndLoadMap()
        Else
            Dim v As Integer = config.GetInt("vFormat", -1)
            If v > MapFormat Then
                MsgBox("This map file was created with a newer version of CAMM and cannot be opened.")
            ElseIf v = 1 Then
                NewMap()
                ActiveMap.LoadMapv1(source)

                'TODO: Temp fix for bug unplacable grid spaces after loading a map.
                ResizeMap(ActiveMap.SizeX, ActiveMap.SizeY)

                EndLoadMap()
            ElseIf v = 2 Or v = 3 Or v = 4 Or v = MapFormat Then
                NewMap()
                ActiveMap.LoadMap(source, v)

                'TODO: Temp fix for bug unplacable grid spaces after loading a map.
                ResizeMap(ActiveMap.SizeX, ActiveMap.SizeY)

                EndLoadMap()
            End If
        End If
    End Sub
    Private Sub EndLoadMap()
        ActiveMap.FilePath = openMap.FileName

        UpdateFormTitle()
        UpdateMapTabs()

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
        Me.saveMap.InitialDirectory = FullBasePath + SavePath

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
            My.Computer.FileSystem.WriteAllText(fileName, ActiveMap.GetSaveData(), False)
            ActiveMap.IsMapFinal = False
            ActiveMap.FilePath = fileName
            UpdateMapTabs()
            UpdateFormTitle()
            picMap.Invalidate()
        End If
    End Sub

#End Region

    Private Sub FRMEditor_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        IsDrawing = False
    End Sub

    Private Function IsMouseInBounds()
        If isMouseOnMap Then
            Return ActiveMap.IsMouseInBounds(mouseX, mouseY)
        Else
            Return False
        End If
    End Function

    Private Sub picActive_Paint(sender As Object, e As PaintEventArgs) Handles picActive.Paint
        If ActiveToolMode = ToolMode.Eraser Then
            e.Graphics.Clear(picActive.BackColor)
        Else
            If ActiveEditMode = EditMode.Buildings Then
                If activeBuilding.HasData And activeBuilding.BuildingId <> "" And ActiveToolMode <> ToolMode.Eraser Then
                    e.Graphics.Clear(picActive.BackColor)
                    activeBuilding.DrawThumbnail(e.Graphics, True)
                Else
                    e.Graphics.Clear(picActive.BackColor)
                    e.Graphics.DrawImage(ButtonNeutral, 0, 0, TileSizeX, TileSizeY)
                    e.Graphics.DrawImage(ButtonOverlay, New Point(0, 0))
                End If
            ElseIf ActiveEditMode = EditMode.Units Then
                If activeUnit.HasData And activeUnit.UnitId <> "" And ActiveToolMode <> ToolMode.Eraser Then
                    e.Graphics.Clear(picActive.BackColor)
                    activeUnit.DrawThumbnail(e.Graphics, True)
                Else
                    e.Graphics.Clear(picActive.BackColor)
                    e.Graphics.DrawImage(ButtonNeutral, 0, 0, TileSizeX, TileSizeY)
                    'e.Graphics.DrawImage(ButtonOverlay, New Point(0, 0))
                End If
            End If
        End If
    End Sub

#Region "Menu & UI Events"

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSize_Click(sender As Object, e As EventArgs) Handles btnSize.Click
        If CInt(txtWidth.Text) > 30 Then
            MsgBox("Width cannot be greater than 30." + vbNewLine + "At least for now.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtWidth.Text = "30"
        ElseIf CInt(txtHeight.Text) > 30 Then
            MsgBox("Height cannot be greater than 30." + vbNewLine + "At least for now.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtHeight.Text = "30"
        ElseIf CInt(txtWidth.Text) = 0 Then
            MsgBox("If a 2-Dimensional object has a width of 0, does it really exist?" + vbNewLine + "Width cannot be 0.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtWidth.Text = ActiveMap.SizeX
        ElseIf CInt(txtHeight.Text) = 0 Then
            MsgBox("If a 2-Dimensional object has a height of 0, does it really exist?" + vbNewLine + "Height cannot be 0.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtHeight.Text = ActiveMap.SizeY
        ElseIf CInt(txtWidth.Text) < 10 Then
            MsgBox("Width cannot be less than 10." + vbNewLine + "Gameplay reasons.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtWidth.Text = "10"
        ElseIf CInt(txtHeight.Text) < 10 Then
            MsgBox("Height cannot be less than 10." + vbNewLine + "Gameplay reasons.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtHeight.Text = "10"
        Else
            ResizeMap(txtWidth.Text, txtHeight.Text)
        End If
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

    Private Sub btnDeleteUnit_Click(sender As Object, e As EventArgs) Handles btnDeleteSelectedUnit.Click, btnMapDeleteUnit.Click
        Select Case ActiveEditMode
            Case EditMode.Tiles
                'TODO: Deleted selected tile(s).
            Case EditMode.Buildings
                'TODO: Delete selected building.
            Case EditMode.Units
                If selectedUnit IsNot Nothing Then
                    btnDeleteSelectedUnit.Enabled = False
                    btnUnitProperties.Enabled = False
                    ActiveMap.DeleteUnit(selectedUnit)
                    selectedUnit = Nothing
                    closestUnit = Nothing
                    picMap.Invalidate()
                End If
            Case EditMode.Shroud
                'TODO: Delete selected shroud??
        End Select
    End Sub

    Private Sub btnTileDataEditor_Click(sender As Object, e As EventArgs) Handles btnTileDataEditor.Click
        FrmTileData.ShowDialog(Me)
    End Sub

    Private Sub btnDeveloper_Click(sender As Object, e As EventArgs) Handles btnDeveloper.Click
        mnuDev.Visible = True
        mnuImport.Visible = True
        btnExportAS.Visible = True
        separator3.Visible = True
        mnuchkDebugBuildingPos.Visible = True
        mnuchkDebugUnitPos.Visible = True
    End Sub

    Private Sub btnEditTiles_Click(sender As Object, e As EventArgs) Handles btnEditTiles.Click
        SwitchEditMode(EditMode.Tiles)
    End Sub

    Private Sub btnEditBuildings_Click(sender As Object, e As EventArgs) Handles btnEditBuildings.Click
        SwitchEditMode(EditMode.Buildings)
    End Sub

    Private Sub btnEditUnits_Click(sender As Object, e As EventArgs) Handles btnEditUnits.Click
        SwitchEditMode(EditMode.Units)
    End Sub

    Private Sub btnEditShroud_Click(sender As Object, e As EventArgs) Handles btnEditShroud.Click
        SwitchEditMode(EditMode.Shroud)
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

    Private Sub chkAssociateFileTypeCAMM_CheckStateChanged(sender As Object, e As EventArgs) Handles chkAssociateFileTypeCAMM.CheckStateChanged
        If isLoaded Then
            If chkAssociateFileTypeCAMM.CheckState = CheckState.Checked Then

                Try
                    My.Computer.Registry.ClassesRoot.CreateSubKey(".camm").SetValue("", "CAMM", RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey(".camm").SetValue("Content Type", "text/plain", RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey(".camm").SetValue("PerceivedType", "document", RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM").SetValue("", "CAMM Map File", RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM").SetValue("AlwaysShowExt", "", RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM").SetValue("BrowserFlags", 8, RegistryValueKind.DWord)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM").SetValue("EditFlags", 302144, RegistryValueKind.DWord)
                    ' Thanks to ETXAlienRobot201 for making the .camm file icon.
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM\DefaultIcon").SetValue("", """" + Application.ExecutablePath + """" + ",1", RegistryValueKind.String)
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

    Private Sub chkAssociateFileTypeMap_CheckStateChanged(sender As Object, e As EventArgs) Handles chkAssociateFileTypeMap.CheckStateChanged
        ' TODO: Associate .map files, though it may not be such a good idea.
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
        If selectedUnit IsNot Nothing Then
            lblMapNoActionsAvailable.Visible = False
            ctxMapSeparator1.Visible = True
            btnMapDeleteUnit.Visible = True
            btnMapDeleteUnit.Enabled = True
            btnMapUnitProperties.Visible = True
            btnMapUnitProperties.Enabled = True
        Else
            lblMapNoActionsAvailable.Visible = True
            ctxMapSeparator1.Visible = False
            btnMapDeleteUnit.Visible = False
            btnMapDeleteUnit.Enabled = False
            btnMapUnitProperties.Visible = False
            btnMapUnitProperties.Enabled = False
        End If
    End Sub

    Private Sub btnMapUnitProperties_Click(sender As Object, e As EventArgs) Handles btnMapUnitProperties.Click, btnUnitProperties.Click
        FrmUnitProperties.TargetUnit = selectedUnit
        FrmUnitProperties.ShowDialog(Me)
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
            Dim w As Integer = (ActiveMap.SizeX * TileSizeX) + 1
            Dim h As Integer = (ActiveMap.SizeY * TileSizeY) + 1
            Dim img As Image = New Bitmap(w, h, PixelFormat.Format24bppRgb)
            Dim g As Graphics = Graphics.FromImage(img)
            ActiveMap.Draw(g, DrawGrid, DrawShadows, DrawTeamIndicators, False, False)
            g.Dispose()
            img.Save(savePng.FileName, ImageFormat.Png)
        End If
    End Sub

    Private Sub btnExportAS_Click(sender As Object, e As EventArgs) Handles btnExportAS.Click
        Dim exportAsTileData As String = AsciiLookup(ActiveMap.SizeX) + AsciiLookup(ActiveMap.SizeY)

        For y As Integer = 0 To ActiveMap.SizeY - 1
            For x As Integer = 0 To ActiveMap.SizeX - 1
                Dim idx As Integer = ActiveMap.GetTileAt(x * TileSizeX, y * TileSizeY).TileId
                If idx < 0 Then
                    idx = 0
                End If

                Dim chr As String = AsciiLookup(idx)

                exportAsTileData += chr
            Next x
        Next y

        Dim output As String = vbTab + "this.data = {" + vbNewLine
        output += vbTab + vbTab + "tiles : ""0"
        '0AAAAAAAA AAAAAAAAAAAAAAA    AAAAAAAAAAAAAAAAA 1A A"
        Dim tiles As List(Of Tile) = (From t In TileDefs Order By t.TileId Where t.HasData).ToList()
        For Each t As Tile In tiles
            If t.IsMinerals Then
                output += "1"
            ElseIf Not t.IsPassable Then
                output += "A"
            Else
                output += " "
            End If
        Next
        output += """.split("""",10000)," + vbNewLine
        output += vbTab + vbTab + "map_new : """ + exportAsTileData + """.split("""",10000)" + vbNewLine
        output += vbTab + "};"
        FrmExportAS.txtOutput.Text = output

        FrmExportAS.ShowDialog(Me)
    End Sub

    Public ImportAsTileData As String = ""
    Private Sub btnImportAS_Click(sender As Object, e As EventArgs) Handles btnImportAS.Click
        If FrmImportAS.ShowDialog(Me) = DialogResult.OK And ImportAsTileData <> "" Then
            'TODO: This will have to do for now.
            Dim count As Integer = 0
            For y As Integer = 0 To (ActiveMap.SizeY - 1) * TileSizeY Step TileSizeY
                For x As Integer = 0 To (ActiveMap.SizeX - 1) * TileSizeX Step TileSizeX
                    'ReDim Preserve MapTiles(count)
                    'MapTiles(count) = New Tile(x, y)

                    Dim idx As Integer = AsciiLookup.IndexOf(ImportAsTileData.ToCharArray()(count).ToString())
                    Dim tileId As Integer = -1
                    If idx > 0 Then
                        tileId = idx ' Old calculation: (4350 + 2 * idx)
                    End If

                    For j As Integer = 0 To TileDefs.Length - 1
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
        End If
        Me.Text = title
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim menuLocation As Point = mapTabs.PointToClient(ctxMapTabs.Location)

        For i As Integer = 0 To Maps.Count - 1
            Dim rect As Rectangle = mapTabs.GetTabRect(i)
            If rect.Contains(menuLocation) Then
                If mapTabs.TabPages.Count = 1 Then
                    NewMap()
                End If
                Maps.RemoveAt(i)
                UpdateMapTabs()
                If i - 1 >= 0 Then
                    mapTabs.SelectedIndex = i - 1
                End If
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
                        Maps.RemoveRange(0, i)
                        UpdateMapTabs()
                        mapTabs.SelectedIndex = 0
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
                        Maps.RemoveRange(i + 1, (Maps.Count - 1) - (i + 1) + 1)
                        UpdateMapTabs()
                        mapTabs.SelectedIndex = Maps.Count - 1
                    End If
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub btnCloseAllExceptThis_Click(sender As Object, e As EventArgs) Handles btnCloseAllExceptThis.Click
        Dim exceptMap As Map = ActiveMap
        Maps.Clear()
        Maps.Add(exceptMap)
        UpdateMapTabs()
        mapTabs.SelectedIndex = 0
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

    Public Sub SwitchEditMode(mode As EditMode)
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
        Select Case mode
            Case EditMode.Tiles
                lblSelected.Text = "Selected Tile:"
                picActive.Image = activeTile.Image
                btnEditTiles.Enabled = False
                pnlTiles.Show()
            Case EditMode.Buildings
                lblSelected.Text = "Selected Building:"
                picActive.Image = activeBuilding.SmallImage
                btnEditBuildings.Enabled = False
                pnlBuildings.Show()
            Case EditMode.Units
                lblSelected.Text = "Selected Unit:"
                picActive.Image = activeUnit.SmallImage
                btnEditUnits.Enabled = False
                pnlUnits.Show()
            Case EditMode.Shroud
                lblSelected.Text = "Shroud:"
                picActive.Image = Nothing
                btnEditShroud.Enabled = False
        End Select

        ' Disable the Rectangle Brush tool unless we're switching into Tile edit mode.
        If mode = EditMode.Tiles Then
            If ActiveToolMode <> ToolMode.RectangleBrush Then
                btnToolRectangleBrush.Enabled = True
            End If
        Else
            If ActiveToolMode = ToolMode.RectangleBrush Then
                SwitchToolMode(ToolMode.Brush)
            Else
                btnToolRectangleBrush.Enabled = False
            End If
        End If

        ' Redraw the map.
        picMap.Invalidate()
    End Sub

    Public Sub SwitchToolMode(mode As ToolMode)
        ' Update currently active tool mode.
        ActiveToolMode = mode

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

        ' Disable the Rectangle Brush tool if we're not in Tile edit mode.
        If ActiveEditMode <> EditMode.Tiles Then
            btnToolRectangleBrush.Enabled = False
        End If

        ' Refresh drawing surfaces.
        picTiles.Invalidate()
        picBuildings.Invalidate()
        picUnits.Invalidate()
        picActive.Invalidate()
        picMap.Invalidate()
    End Sub

End Class
