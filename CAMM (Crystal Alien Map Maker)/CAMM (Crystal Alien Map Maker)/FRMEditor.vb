'-============================================================================================-'
'  CAMM (Crystal Alien Map Maker) program created by Josh (aka. leveleditor / Leveleditor6680) '
'-============================================================================================-'

Imports Nini.Config
Imports Nini.Ini
Public Class FRMEditor

    Dim IsMapOpen As Boolean = False
    Private BaseFormTitle As String

    Private Property ActiveMapNum As Integer
        Get
            Return MapTabs.SelectedIndex
        End Get
        Set(value As Integer)
            MapTabs.SelectedIndex = value
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
        Set(ByVal value As Map)
            Maps(ActiveMapNum) = value
        End Set
    End Property

    Private IsLoaded As Boolean = False
    Private IsMouseOnMap As Boolean = False
    Public IsDrawing As Boolean = False
    Private MouseX As Integer
    Private MouseY As Integer
    Private MouseXNoSnap As Integer
    Private MouseYNoSnap As Integer

    Public ActiveEditMode As EditMode = EditMode.Tiles
    Public ActiveToolMode As ToolMode = ToolMode.Brush

    Public DrawGrid As Boolean = True
    Public DrawBuildingDebugPos As Boolean = False
    Private IsMouseOnSelections As Boolean = False
    Dim SelX_Tiles As Integer
    Dim SelY_Tiles As Integer
    Dim SelX_Buildings As Integer
    Dim SelY_Buildings As Integer
    Dim SelX_Units As Integer
    Dim SelY_Units As Integer

    ReadOnly CustomToolStripRenderer As ToolStripProfessionalRenderer = New ToolStripProfessionalRenderer(New CustomColorTable())

    Private ActiveTile As Tile 'The currently active tile selection.
    Private ActiveBuilding As Building 'The currently active object selection.
    Private ActiveUnit As Unit 'The currently active unit selection.

    Private Sub FRMEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Storing default form title.
        BaseFormTitle = Me.Text

        'Loading assets.
        LoadAssets()

        'Setting version information.
        LBLAboutVersion.Text = BuildType + " v" + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString
        If My.Application.Info.Version.Revision > 0 Then
            LBLAboutVersion.Text += "." + My.Application.Info.Version.Build.ToString + "." + My.Application.Info.Version.Revision.ToString
        ElseIf My.Application.Info.Version.Build > 0 And My.Application.Info.Version.Revision <= 0 Then
            LBLAboutVersion.Text += "." + My.Application.Info.Version.Build.ToString
        End If
        LBLAboutVersion.Text += " by Leveleditor6680 // Josh"

        'Setting ToolStrip renderers
        MNUMain.Renderer = CustomToolStripRenderer
        StatusBar.Renderer = CustomToolStripRenderer
        CTXMapTabs.Renderer = CustomToolStripRenderer

        For Each MenuItem As ToolStripMenuItem In MNUMain.Items.OfType(Of ToolStripMenuItem)()
            'Dim dropDown As ToolStripDropDownMenu = MenuItem.DropDown
            'dropDown.ShowImageMargin = False
            MenuItem.Text = MenuItem.Text.ToUpper()
        Next

        'Loading Tiles.dat data file.
        If My.Computer.FileSystem.FileExists(TileDataFile) = False Then
            MsgBox("The 'Tiles.dat' file is missing!" + vbNewLine + "Please make sure you have all required files before using CAMM.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Me.Close()
        End If

        CheckFileAssociations()

        Dim reader As New IniReader(TileDataFile) With {.IgnoreComments = True, .AcceptCommentAfterKey = False}
        Dim source As New IniConfigSource(New IniDocument(reader))
        Dim config As IConfig = source.Configs.Item("CAMM")
        If config Is Nothing Then
            MsgBox("The 'Tiles.dat' file is invalid or outdated and cannot be used!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Me.Close()
        End If
        Dim vFormat = config.GetInt("vFormat", -1)
        If vFormat = 1 Or vFormat = 2 Or vFormat = 3 Then
            MsgBox("The 'Tiles.dat' file is outdated." + vbNewLine + "Please update this file before using CAMM.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Me.Close()
        ElseIf vFormat < TilesDatVersion Then
            MsgBox("The 'Tiles.dat' file is invalid or outdated and cannot be used!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Me.Close()
        ElseIf vFormat > TilesDatVersion Then
            MsgBox("The 'Tiles.dat' file was created with a newer version of CAMM and cannot be used!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Me.Close()
        ElseIf vFormat = TilesDatVersion Then
            LoadConfig(source)
        End If

        'Dynamically setting PICTiles size.
        PICTiles.Size = New Size(TileSizeX + 1, (TileDefs.Length * TileSizeY) + 1)
        PICTiles.Invalidate()

        'Dynamically setting PICBuildings size.
        PICBuildings.Size = New Size(TileSizeX + 1, (BuildingDefs.Length * TileSizeY) + 1)
        PICBuildings.Invalidate()

        'Dynamically setting PICUnits size.
        PICUnits.Size = New Size(TileSizeX + 1, (UnitDefs.Length * TileSizeY) + 1)
        PICUnits.Invalidate()

        'Setting default blank values.
        ActiveTile = New Tile(0, 0)
        ActiveBuilding = New Building(0, 0)
        ActiveUnit = New Unit(0, 0)
        PICActive.Image = Nothing

        'Start a new map.
        NewMap()

        If My.Application.CommandLineArgs.Count > 0 Then
            BeginLoadMap(My.Application.CommandLineArgs(0))
        End If

        IsLoaded = True
        IntroTimer.Start()
    End Sub

    Private Sub FRMEditor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("There may be unsaved changes." + vbNewLine + "Are you sure you want to exit?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
            e.Cancel = True
        End If
    End Sub

#Region "Intro Effects"
    'TODO: Need to clean up this mess...
    Dim FadeAlpha As Integer = 350
    Dim FadeRate As Integer = 2
    Dim FadePen As Pen = Pens.Black
    Dim FadeBrush As SolidBrush = Brushes.Black
    Dim IntroFont As Font = New Font(FontFamily.GenericMonospace, 20, FontStyle.Bold, GraphicsUnit.Pixel)
    Dim IntroFont2 As Font = New Font(Drawing.FontFamily.GenericMonospace, 25, FontStyle.Bold, GraphicsUnit.Pixel)
    Dim IntroBrush As SolidBrush = New SolidBrush(Color.FromArgb(255, 0, 255, 0))
    Dim IntroBrush2 As SolidBrush = Brushes.DarkGreen
    Dim IntroFontH As Integer = IntroFont.GetHeight
    Dim IntroFontH2 As Integer = IntroFont2.GetHeight
    Dim IntroX, IntroY, sIntro1_width, sIntro2_width, sIntro3_width As Integer
    Dim sIntro1 As String = "Welcome to CAMM!"
    Dim sIntro2 As String = "Crystal Alien Map Maker"
    Dim sIntro3 As String = "By Leveleditor6680 // Josh"
    Sub DrawIntro(ByRef g As Graphics)
        sIntro1_width = g.MeasureString(sIntro1, IntroFont).Width
        sIntro2_width = g.MeasureString(sIntro2, IntroFont2).Width
        sIntro3_width = g.MeasureString(sIntro3, IntroFont).Width
        IntroX = -(PICMap.Location.X) + PNLMap.Width / 2
        IntroY = -(PICMap.Location.Y) + PNLMap.Height / 3

        g.DrawRectangle(FadePen, PICMap.Bounds)
        g.FillRectangle(FadeBrush, 0, -PICMap.Location.Y, PICMap.Width, PICMap.Height)

        g.DrawString(sIntro1, IntroFont, IntroBrush2, IntroX - sIntro1_width / 2 + 2, IntroY + 2)
        g.DrawString(sIntro2, IntroFont2, IntroBrush2, IntroX - sIntro2_width / 2 + 2, IntroY + IntroFontH + 2)
        g.DrawString(sIntro3, IntroFont, IntroBrush2, IntroX - sIntro3_width / 2 + 2, IntroY + IntroFontH2 * 2 + 2)

        g.DrawString(sIntro1, IntroFont, IntroBrush, IntroX - sIntro1_width / 2, IntroY)
        g.DrawString(sIntro2, IntroFont2, IntroBrush, IntroX - sIntro2_width / 2, IntroY + IntroFontH)
        g.DrawString(sIntro3, IntroFont, IntroBrush, IntroX - sIntro3_width / 2, IntroY + IntroFontH2 * 2)
    End Sub
    Private Sub IntroTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntroTimer.Tick
        If FadeAlpha >= 0 And FadeAlpha <= 255 Then
            FadePen = New Pen(Color.FromArgb(FadeAlpha, 0, 0, 0))
            FadeBrush = New SolidBrush(Color.FromArgb(FadeAlpha, 0, 0, 0))
        End If

        If FadeAlpha <= 100 And FadeAlpha >= -155 Then
            IntroBrush = New SolidBrush(Color.FromArgb(FadeAlpha + 155, 0, 255, 0))
            IntroBrush2 = New SolidBrush(Color.FromArgb(FadeAlpha + 155, Color.DarkGreen.R, Color.DarkGreen.G, Color.DarkGreen.B))
        End If

        If FadeAlpha <= -155 Then
            IntroTimer.Stop()
        Else
            FadeAlpha -= FadeRate
        End If

        PICMap.Invalidate()
    End Sub
#End Region

#Region "Grid and Map Operations"

    Private Sub ResizeMap(ByVal width As Integer, ByVal height As Integer)
        ActiveMap.SetSize(width, height)

        TXTWidth.Text = ActiveMap.SizeX
        TXTHeight.Text = ActiveMap.SizeY
        PICMap.Size = New Size((ActiveMap.SizeX * TileSizeX) + 1, (ActiveMap.SizeY * TileSizeY) + 1)

        PICMap.Invalidate()
    End Sub

#End Region

#Region "PICMap Events"

    Private Sub PICMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PICMap.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If IsDrawing = False Then
                IsDrawing = True

                ' Start drawing.
                MouseX = e.X
                MouseY = e.Y
                PointToGrid(MouseX, MouseY)
                MouseXNoSnap = e.X
                MouseYNoSnap = e.Y

                If ActiveEditMode = EditMode.Tiles Then
                    If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Or ActiveTile.TileId = -1 Then
                        ActiveMap.Eraser(MouseX, MouseY, ActiveEditMode)
                    ElseIf ActiveToolMode = ToolMode.SmartBrush Then
                        ActiveMap.SetTileSmart(MouseX, MouseY)
                    Else
                        ActiveMap.SetTile(MouseX, MouseY, ActiveTile)
                    End If
                ElseIf ActiveEditMode = EditMode.Buildings Then
                    If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                        ActiveMap.Eraser(MouseX, MouseY, ActiveEditMode)
                    Else
                        ActiveMap.SetBuilding(MouseX, MouseY, ActiveBuilding)
                    End If
                ElseIf ActiveEditMode = EditMode.Units Then
                    If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                        ActiveMap.Eraser(MouseX, MouseY, ActiveEditMode)
                    Else
                        ActiveMap.SetUnit(MouseXNoSnap, MouseYNoSnap, ActiveUnit)
                    End If
                ElseIf ActiveEditMode = EditMode.Shroud Then
                    'For later.
                End If

                PICMap.Invalidate()
            End If
        End If
    End Sub

    Private Sub PICMap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PICMap.MouseUp
        If IsDrawing Then
            IsDrawing = False
        End If
    End Sub

    Private Sub PICMap_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PICMap.MouseMove
        IsMouseOnMap = True
        MouseX = e.X
        MouseY = e.Y
        PointToGrid(MouseX, MouseY)
        MouseXNoSnap = e.X
        MouseYNoSnap = e.Y

        If IsDrawing Then
            If ActiveEditMode = EditMode.Tiles Then
                If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Or ActiveTile.TileId = -1 Then
                    ActiveMap.Eraser(MouseX, MouseY, ActiveEditMode)
                ElseIf ActiveToolMode = ToolMode.SmartBrush Then
                    ActiveMap.SetTileSmart(MouseX, MouseY)
                Else
                    ActiveMap.SetTile(MouseX, MouseY, ActiveTile)
                End If
            ElseIf ActiveEditMode = EditMode.Buildings Then
                If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                    ActiveMap.Eraser(MouseX, MouseY, ActiveEditMode)
                Else
                    ActiveMap.SetBuilding(MouseX, MouseY, ActiveBuilding)
                End If
            ElseIf ActiveEditMode = EditMode.Units Then
                If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                    ActiveMap.Eraser(MouseX, MouseY, ActiveEditMode)
                Else
                    'No click & drag for units, just imagine the spam...
                    'SetUnit(MouseXNoSnap, MouseYNoSnap)
                End If
            ElseIf ActiveEditMode = EditMode.Shroud Then
                'For later, maybe.
            End If
        End If

        Dim Debug As Boolean = True
        If IsMouseInBounds() Then
            If Debug = True Then
                If ActiveMap.GetTileAt(MouseX, MouseY) IsNot Nothing Then
                    LBLCursorLoc.Text = ActiveMap.GetTileAt(MouseX, MouseY).TileId.ToString + " [" + ((MouseX / TileSizeX) + 1).ToString + ", " + ((MouseY / TileSizeY) + 1).ToString + "]"
                Else
                    LBLCursorLoc.Text = "null [" + ((MouseX / TileSizeX) + 1).ToString + ", " + ((MouseY / TileSizeY) + 1).ToString + "]"
                End If
                If ActiveMap.GetBuildingAt(MouseX, MouseY) IsNot Nothing Then
                    LBLCursorLoc.Text = ActiveMap.GetBuildingAt(MouseX, MouseY).BuildingId + " : " + LBLCursorLoc.Text
                End If
            Else
                LBLCursorLoc.Text = "[" + ((MouseX / TileSizeX) + 1).ToString + ", " + ((MouseY / TileSizeY) + 1).ToString + "]"
            End If
        End If

        ' Redraw.
        PICMap.Invalidate()
    End Sub

    Private Sub PICMap_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PICMap.Paint
        If IsLoaded Then
            Dim g As Graphics = e.Graphics

            ActiveMap.Draw(g, DrawGrid, DrawBuildingDebugPos)

            ' Draw the rectangle cursor / selector thingy.
            If IsMouseInBounds() Then
                If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                    g.DrawRectangle(PenTileErase, MouseX - (PenTileHover.Width / 2), MouseY - (PenTileHover.Width / 2), TileSizeX + PenTileHover.Width + 1, TileSizeY + PenTileHover.Width + 1)
                Else
                    g.DrawRectangle(PenTileHover, MouseX - (PenTileHover.Width / 2), MouseY - (PenTileHover.Width / 2), TileSizeX + PenTileHover.Width + 1, TileSizeY + PenTileHover.Width + 1)
                End If
                If ActiveEditMode = EditMode.Tiles Then
                    'g.DrawImage(ActiveTile.Image, MouseX, MouseY)
                ElseIf ActiveEditMode = EditMode.Buildings And ActiveBuilding.BuildingId <> "" Then
                    'OffY2 = TileSizeY

                    'g.DrawImage(ActiveBuilding.FullImage, _
                    '     ActiveBuilding.DrawPos.X - CInt(ActiveBuilding.FullImage.Width / 2), _
                    '     ActiveBuilding.DrawPos.Y - CInt(ActiveBuilding.FullImage.Height / 2) + OffY, _
                    '     ActiveBuilding.FullImage.Width, _
                    '     ActiveBuilding.FullImage.Height)

                    'g.DrawImage(ActiveBuilding.FullImage, MouseX, MouseY, ActiveBuilding.FullImage.Width, ActiveBuilding.FullImage.Height)
                ElseIf ActiveEditMode = EditMode.Units And ActiveUnit.UnitId <> "" Then
                    If IsMouseOnMap And Not IsDrawing And ActiveToolMode <> ToolMode.Eraser Then
                        g.DrawImage(ActiveUnit.FullImage, _
                            MouseXNoSnap - CInt(ActiveUnit.FullImage.Width / 2), _
                            MouseYNoSnap - CInt(ActiveUnit.FullImage.Height / 2), _
                            ActiveUnit.FullImage.Width, _
                            ActiveUnit.FullImage.Height)
                    End If
                    'g.DrawImage(ActiveUnit.FullImage, MouseXNoSnap, MouseYNoSnap, ActiveUnit.FullImage.Width, ActiveUnit.FullImage.Height)
                End If
            End If

            'Draw intro animation.
            If IntroTimer.Enabled Then
                DrawIntro(g)
            End If
        End If
    End Sub

    Private Sub PICMap_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PICMap.MouseEnter
        IsMouseOnMap = True
        PNLMap.Focus()
        'Windows.Forms.Cursor.Hide()
    End Sub

    Private Sub PICMap_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PICMap.MouseLeave
        IsMouseOnMap = False
        Windows.Forms.Cursor.Show()
        LBLCursorLoc.Text = "[ ]"
        PICMap.Invalidate()
    End Sub

#End Region

#Region "PICTiles Events"

    Private Sub PICTiles_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PICTiles.Paint
        If IsLoaded Then
            e.Graphics.Clear(PICTiles.BackColor)

            For i As Integer = 0 To TileDefs.Length - 1
                If TileDefs(i).HasData Then
                    e.Graphics.DrawImage(TileDefs(i).Image, TileDefs(i).Position)
                End If
            Next

            ' Draw the grid.
            For x As Integer = 0 To PICTiles.ClientSize.Width Step TileSizeX
                For y As Integer = 0 To PICTiles.ClientSize.Height Step TileSizeY
                    e.Graphics.DrawLine(PenGrid, x, y, x + 0.5F, y + TileSizeY)
                    e.Graphics.DrawLine(PenGrid, x, y, x + TileSizeX, y + 0.5F)
                Next y
            Next x

            'Draw Rectangle around selected Tile.
            If ActiveEditMode = EditMode.Tiles And ActiveTile.TileId <> -1 And ActiveToolMode <> ToolMode.Eraser Then
                e.Graphics.DrawRectangle(PenSelected, SelX_Tiles + (PenSelected.Width / 2) + 1, SelY_Tiles + (PenSelected.Width / 2) + 1, TileSizeX - PenSelected.Width - 1, TileSizeY - PenSelected.Width - 1)
            End If

            ' Draw the rectangle cursor / selector thingy.
            If IsMouseOnSelections Then
                e.Graphics.DrawRectangle(PenSelectionHover, MouseX + (PenSelectionHover.Width / 2) + 1, MouseY + (PenSelectionHover.Width / 2) + 1, TileSizeX - PenSelectionHover.Width - 1, TileSizeY - PenSelectionHover.Width - 1)
            End If

        End If
    End Sub

    Private Sub PICTiles_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PICTiles.MouseEnter
        IsMouseOnSelections = True
        IsMouseOnMap = False
        PNLTiles.Focus()
    End Sub

    Private Sub PICTiles_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PICTiles.MouseLeave
        IsMouseOnSelections = False
        LBLCursorLoc.Text = "[ ]"
        PICTiles.Invalidate()
    End Sub

    Private Sub PICTiles_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PICTiles.MouseMove
        IsMouseOnSelections = True
        MouseX = e.X
        MouseY = e.Y
        PointToGrid(MouseX, MouseY)
        MouseXNoSnap = e.X
        MouseYNoSnap = e.Y

        ' Redraw.
        PICTiles.Invalidate()
    End Sub

    Private Sub PICTiles_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PICTiles.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            MouseX = e.X
            MouseY = e.Y
            PointToGrid(MouseX, MouseY)
            MouseXNoSnap = e.X
            MouseYNoSnap = e.Y
            SelX_Tiles = MouseX
            SelY_Tiles = MouseY

            For i As Integer = 0 To TileDefs.Length - 1
                If TileDefs(i).Position = New Point(MouseX, MouseY) Then
                    PICActive.Image = TileDefs(i).Image
                    ActiveTile.TileId = TileDefs(i).TileId
                End If
            Next

            PICTiles.Invalidate()
        End If
    End Sub

#End Region
#Region "PICBuildings Events"

    Private Sub PICBuildings_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PICBuildings.Paint
        If IsLoaded Then
            e.Graphics.Clear(PICBuildings.BackColor)
            'e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

            ' Draw the object selections.
            For i As Integer = 0 To BuildingDefs.Length - 1
                If BuildingDefs(i).HasData Then
                    If BuildingDefs(i).Team = Team.Astros Then
                        e.Graphics.DrawImage(ButtonAstro, BuildingDefs(i).Location.X, BuildingDefs(i).Location.Y, ButtonAstro.Width, ButtonAstro.Height)
                    ElseIf BuildingDefs(i).Team = Team.Aliens Then
                        e.Graphics.DrawImage(ButtonAlien, BuildingDefs(i).Location.X, BuildingDefs(i).Location.Y, ButtonAlien.Width, ButtonAlien.Height)
                    Else
                        e.Graphics.DrawImage(ButtonNeutral, BuildingDefs(i).Location.X, BuildingDefs(i).Location.Y, ButtonNeutral.Width, ButtonNeutral.Height)
                    End If
                    e.Graphics.DrawImage(BuildingDefs(i).SmallImage, BuildingDefs(i).Location)
                    e.Graphics.DrawImage(ButtonOverlay, BuildingDefs(i).Location)
                End If
            Next

            ' Draw the grid.
            For x As Integer = 0 To PICBuildings.ClientSize.Width Step TileSizeX
                For y As Integer = 0 To PICBuildings.ClientSize.Height Step TileSizeY
                    e.Graphics.DrawLine(PenGrid, x, y, x + 0.5F, y + TileSizeY)
                    e.Graphics.DrawLine(PenGrid, x, y, x + TileSizeX, y + 0.5F)
                Next y
            Next x

            'Draw Rectangle around selected Buildings.
            If ActiveEditMode = EditMode.Buildings And ActiveBuilding.BuildingId <> "" And ActiveToolMode <> ToolMode.Eraser Then
                e.Graphics.DrawRectangle(PenSelected, SelX_Buildings + (PenSelected.Width / 2) + 1, SelY_Buildings + (PenSelected.Width / 2) + 1, TileSizeX - PenSelected.Width - 1, TileSizeY - PenSelected.Width - 1)
            End If

            ' Draw the rectangle cursor / selector thingy.
            If IsMouseOnSelections Then
                e.Graphics.DrawRectangle(PenSelectionHover, MouseX + (PenSelectionHover.Width / 2) + 1, MouseY + (PenSelectionHover.Width / 2) + 1, TileSizeX - PenSelectionHover.Width - 1, TileSizeY - PenSelectionHover.Width - 1)
            End If
        End If
    End Sub

    Private Sub PICBuildings_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PICBuildings.MouseEnter
        IsMouseOnSelections = True
        IsMouseOnMap = False
        PNLBuildings.Focus()
    End Sub

    Private Sub PICBuildings_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PICBuildings.MouseLeave
        IsMouseOnSelections = False
        LBLCursorLoc.Text = "[ ]"
        PICBuildings.Invalidate()
    End Sub

    Private Sub PICBuildings_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PICBuildings.MouseMove
        IsMouseOnSelections = True
        MouseX = e.X
        MouseY = e.Y
        PointToGrid(MouseX, MouseY)
        MouseXNoSnap = e.X
        MouseYNoSnap = e.Y

        ' Redraw.
        PICBuildings.Invalidate()
    End Sub

    Private Sub PICBuildings_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PICBuildings.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            MouseX = e.X
            MouseY = e.Y
            PointToGrid(MouseX, MouseY)
            MouseXNoSnap = e.X
            MouseYNoSnap = e.Y
            SelX_Buildings = MouseX
            SelY_Buildings = MouseY

            For i As Integer = 0 To BuildingDefs.Length - 1
                If BuildingDefs(i).Location = New Point(MouseX, MouseY) Then
                    PICActive.Image = BuildingDefs(i).SmallImage
                    ActiveBuilding.BuildingId = BuildingDefs(i).BuildingId
                    ActiveBuilding.Team = BuildingDefs(i).Team
                    ActiveBuilding.BuildingW = BuildingDefs(i).BuildingW
                    ActiveBuilding.BuildingH = BuildingDefs(i).BuildingH
                End If
            Next

            PICBuildings.Invalidate()
        End If
    End Sub

#End Region
#Region "PICUnits Events"

    Private Sub PICUnits_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PICUnits.Paint
        If IsLoaded Then
            e.Graphics.Clear(PICUnits.BackColor)

            ' Draw the object selections.
            For i As Integer = 0 To UnitDefs.Length - 1
                If UnitDefs(i).HasData Then
                    If UnitDefs(i).Team = Team.Astros Then
                        e.Graphics.DrawImage(ButtonAstro, UnitDefs(i).Position)
                    ElseIf UnitDefs(i).Team = Team.Aliens Then
                        e.Graphics.DrawImage(ButtonAlien, UnitDefs(i).Position)
                    Else
                        e.Graphics.DrawImage(ButtonNeutral, UnitDefs(i).Position.X, UnitDefs(i).Position.Y, ButtonNeutral.Width, ButtonNeutral.Height)
                    End If
                    e.Graphics.DrawImage(UnitDefs(i).SmallImage, UnitDefs(i).Position)
                    'e.Graphics.DrawImage(ButtonOverlay, SelUnits(i).Location)
                End If
            Next

            ' Draw the grid.
            For x As Integer = 0 To PICUnits.ClientSize.Width Step TileSizeX
                For y As Integer = 0 To PICUnits.ClientSize.Height Step TileSizeY
                    e.Graphics.DrawLine(PenGrid, x, y, x + 0.5F, y + TileSizeY)
                    e.Graphics.DrawLine(PenGrid, x, y, x + TileSizeX, y + 0.5F)
                Next y
            Next x

            'Draw Rectangle around selected Units.
            If ActiveEditMode = EditMode.Units And ActiveUnit.UnitId <> "" And ActiveToolMode <> ToolMode.Eraser Then
                e.Graphics.DrawRectangle(PenSelected, SelX_Units + (PenSelected.Width / 2) + 1, SelY_Units + (PenSelected.Width / 2) + 1, TileSizeX - PenSelected.Width - 1, TileSizeY - PenSelected.Width - 1)
            End If

            ' Draw the rectangle cursor / selector thingy.
            If IsMouseOnSelections Then
                e.Graphics.DrawRectangle(PenSelectionHover, MouseX + (PenSelectionHover.Width / 2) + 1, MouseY + (PenSelectionHover.Width / 2) + 1, TileSizeX - PenSelectionHover.Width - 1, TileSizeY - PenSelectionHover.Width - 1)
            End If
        End If
    End Sub

    Private Sub PICUnits_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PICUnits.MouseEnter
        IsMouseOnSelections = True
        IsMouseOnMap = False
        PNLUnits.Focus()
    End Sub

    Private Sub PICUnits_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PICUnits.MouseLeave
        IsMouseOnSelections = False
        LBLCursorLoc.Text = "[ ]"
        PICUnits.Invalidate()
    End Sub

    Private Sub PICUnits_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PICUnits.MouseMove
        IsMouseOnSelections = True
        MouseX = e.X
        MouseY = e.Y
        PointToGrid(MouseX, MouseY)
        MouseXNoSnap = e.X
        MouseYNoSnap = e.Y

        ' Redraw.
        PICUnits.Invalidate()
    End Sub

    Private Sub PICUnits_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PICUnits.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            MouseX = e.X
            MouseY = e.Y
            PointToGrid(MouseX, MouseY)
            MouseXNoSnap = e.X
            MouseYNoSnap = e.Y
            SelX_Units = MouseX
            SelY_Units = MouseY

            For i As Integer = 0 To UnitDefs.Length - 1
                If UnitDefs(i).Position = New Point(MouseX, MouseY) Then
                    PICActive.Image = UnitDefs(i).SmallImage
                    ActiveUnit.UnitId = UnitDefs(i).UnitId
                    ActiveUnit.Team = UnitDefs(i).Team
                End If
            Next

            PICUnits.Invalidate()
        End If
    End Sub

#End Region

#Region "File Operations"

    Private Sub CMDNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDNew.Click
        'TODO: Code for File > New.
        'IsMapFinal = False
        IsMapOpen = False
        'Just going to clear the map for now...
        If MsgBox("Are you sure you want to make a new map?" + vbNewLine + vbNewLine + "Any currently unsaved changes will be lost.", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            NewMap()
        End If
    End Sub

    Public Sub NewMap()
        'Setting default blank values.
        'ActiveTile = New Tile(0, 0)
        'ActiveBuilding = New Building(0, 0)
        'ActiveUnit = New Unit(0, 0)
        'PICActive.Image = Nothing
        'PICTiles.Invalidate()
        'PICBuildings.Invalidate()
        'PICUnits.Invalidate()

        Dim newMap As Map = New Map()
        newMap.MapTitle = "New Map"
        Maps.Add(newMap)
        UpdateMapTabs()
        'CBOLevel.Items.Add("Map " + Levels.Count.ToString() + " [" + newLevel.Map.MapTitle + "]")
        ActiveMapNum = Maps.IndexOf(newMap)
        UpdateFormTitle()

        PICMap.Size = New Size((ActiveMap.SizeX * TileSizeX) + 1, (ActiveMap.SizeY * TileSizeY) + 1)
        TXTWidth.Text = ActiveMap.SizeX
        TXTHeight.Text = ActiveMap.SizeY
    End Sub

    Private Sub CMDOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOpen.Click
        'Me.OpenMap.Reset()
        'Me.OpenMap.DefaultExt = "CAMM Map Files|*.map"
        'Me.OpenMap.FileName = My.Application.Info.DirectoryPath + DataPath + "/_Save Data/Map1.camm"
        Me.OpenMap.FileName = "Map1.camm"
        'Me.OpenMap.Filter = "CAMM Map Files|*.map|All Files|*.*"
        Me.OpenMap.FilterIndex = 1
        Me.OpenMap.RestoreDirectory = False
        Me.OpenMap.Title = "Select Map File To Open..."
        Me.OpenMap.InitialDirectory = My.Application.Info.DirectoryPath + DataPath + "/_Save Data/"

        If Me.OpenMap.ShowDialog = DialogResult.OK Then
            BeginLoadMap(Me.OpenMap.FileName)
        End If
    End Sub
    Public Sub BeginLoadMap(ByVal FileName As String)
        Dim source As New IniConfigSource(FileName)
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
        IsMapOpen = True

        ActiveMap.FileName = OpenMap.FileName

        UpdateFormTitle()
        UpdateMapTabs()

        PICMap.Invalidate()
    End Sub

    Private Sub CMDSaveMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSaveAs.Click
        Me.SaveMap.Reset()
        'Me.SaveMap.DefaultExt = "CAMM Map Files|*.camm"
        'Me.SaveMap.FileName = (My.Application.Info.DirectoryPath & "/../../Tile Data/_Save Data/Map1.map")
        If ActiveMap.MapTitle <> "" Then
            Me.SaveMap.FileName = ActiveMap.MapTitle
        Else
            Me.SaveMap.FileName = "Map1.camm"
        End If
        Me.SaveMap.Filter = "CAMM Map Files|*.camm|All Files|*.*"
        Me.SaveMap.FilterIndex = 1
        Me.SaveMap.RestoreDirectory = False
        Me.SaveMap.Title = "Select Where To Save Map File..."
        Me.SaveMap.InitialDirectory = My.Application.Info.DirectoryPath + DataPath + "/Tile Data/_Save Data/"

        If Me.SaveMap.ShowDialog = DialogResult.OK Then
            SaveFile(SaveMap.FileName)
        End If
    End Sub
    Private Sub CMDSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSave.Click
        If IsMapOpen Then
            If ActiveMap.IsMapFinal Then
                MsgBox("This map has been marked as ""Final"" and cannot be saved." + vbNewLine + "You may save an editable copy using File > SaveAs.")
            Else
                SaveFile(ActiveMap.FileName)
            End If
        Else
            CMDSaveMap_Click(sender, e)
        End If
    End Sub

    Private Sub SaveFile(ByVal FileName As String)
        Dim FileExists As Boolean = My.Computer.FileSystem.FileExists(FileName)
        Dim IsReadOnly As Boolean = My.Computer.FileSystem.GetFileInfo(FileName).IsReadOnly
        If FileExists And IsReadOnly Then
            MsgBox("Unable to save map file, the file is set to read-only." + vbNewLine + "Please try saving using File > SaveAs.")
        Else
            My.Computer.FileSystem.WriteAllText(FileName, ActiveMap.GetSaveData(), False)
            IsMapOpen = True
            ActiveMap.IsMapFinal = False
            ActiveMap.FileName = FileName
            UpdateFormTitle()
            MsgBox("Map file saved successfully.")
        End If
        PICMap.Invalidate()
    End Sub

#End Region

    Private Sub FRMEditor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        IsDrawing = False
    End Sub

    Private Function IsMouseInBounds()
        If MouseX < 0 Then
            Return False
        ElseIf MouseY < 0 Then
            Return False
        ElseIf MouseX > (ActiveMap.SizeX * TileSizeX) - 1 Then
            Return False
        ElseIf MouseY > (ActiveMap.SizeY * TileSizeY) - 1 Then
            Return False
        ElseIf IsMouseOnMap = False Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub PICActive_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PICActive.Paint
        If ActiveToolMode = ToolMode.Eraser Then
            e.Graphics.Clear(PICActive.BackColor)
        Else
            If ActiveEditMode = EditMode.Buildings Then
                If ActiveBuilding.HasData And ActiveBuilding.BuildingId <> "" And ActiveToolMode <> ToolMode.Eraser Then
                    e.Graphics.Clear(PICActive.BackColor)
                    If ActiveBuilding.Team = Team.Astros Then
                        e.Graphics.DrawImage(ButtonAstro, New Point(0, 0))
                    ElseIf ActiveBuilding.Team = Team.Aliens Then
                        e.Graphics.DrawImage(ButtonAlien, New Point(0, 0))
                    Else
                        e.Graphics.DrawImage(ButtonNeutral, 0, 0, TileSizeX, TileSizeY)
                    End If
                    e.Graphics.DrawImage(ActiveBuilding.SmallImage, New Point(0, 0))
                    e.Graphics.DrawImage(ButtonOverlay, New Point(0, 0))
                Else
                    e.Graphics.Clear(PICActive.BackColor)
                    e.Graphics.DrawImage(ButtonNeutral, 0, 0, TileSizeX, TileSizeY)
                    e.Graphics.DrawImage(ButtonOverlay, New Point(0, 0))
                End If
            ElseIf ActiveEditMode = EditMode.Units Then
                If ActiveUnit.HasData And ActiveUnit.UnitId <> "" And ActiveToolMode <> ToolMode.Eraser Then
                    e.Graphics.Clear(PICActive.BackColor)
                    If ActiveUnit.Team = Team.Astros Then
                        e.Graphics.DrawImage(ButtonAstro, New Point(0, 0))
                    ElseIf ActiveUnit.Team = Team.Aliens Then
                        e.Graphics.DrawImage(ButtonAlien, New Point(0, 0))
                    Else
                        e.Graphics.DrawImage(ButtonNeutral, 0, 0, TileSizeX, TileSizeY)
                    End If
                    e.Graphics.DrawImage(ActiveUnit.SmallImage, New Point(0, 0))
                    'e.Graphics.DrawImage(ButtonOverlay, New Point(0, 0))
                Else
                    e.Graphics.Clear(PICActive.BackColor)
                    e.Graphics.DrawImage(ButtonNeutral, 0, 0, TileSizeX, TileSizeY)
                    'e.Graphics.DrawImage(ButtonOverlay, New Point(0, 0))
                End If
            End If
        End If
    End Sub

#Region "Menu & UI Events"

    Private Sub CMDExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDExit.Click
        Me.Close()
    End Sub

    Private Sub CMDSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSize.Click
        If CInt(TXTWidth.Text) > 30 Then
            MsgBox("Width cannot be greater than 30." + vbNewLine + "At least for now.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            TXTWidth.Text = "30"
        ElseIf CInt(TXTHeight.Text) > 30 Then
            MsgBox("Height cannot be greater than 30." + vbNewLine + "At least for now.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            TXTHeight.Text = "30"
        ElseIf CInt(TXTWidth.Text) = 0 Then
            MsgBox("If a 2-Dimensional object has a width of 0, does it really exist?" + vbNewLine + "Width cannot be 0.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            TXTWidth.Text = ActiveMap.SizeX
        ElseIf CInt(TXTHeight.Text) = 0 Then
            MsgBox("If a 2-Dimensional object has a height of 0, does it really exist?" + vbNewLine + "Height cannot be 0.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            TXTHeight.Text = ActiveMap.SizeY
        ElseIf CInt(TXTWidth.Text) < 10 Then
            MsgBox("Width cannot be less than 10." + vbNewLine + "Gameplay reasons.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            TXTWidth.Text = "10"
        ElseIf CInt(TXTHeight.Text) < 10 Then
            MsgBox("Height cannot be less than 10." + vbNewLine + "Gameplay reasons.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            TXTHeight.Text = "10"
        Else
            ResizeMap(TXTWidth.Text, TXTHeight.Text)
        End If
    End Sub

    Private Sub CHKGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKGrid.CheckedChanged, MNUCHKGrid.CheckedChanged
        DrawGrid = sender.Checked
        CHKGrid.Checked = DrawGrid
        MNUCHKGrid.Checked = DrawGrid
        PICMap.Invalidate()
    End Sub

    Private Sub MNUCHKDebugBuildingPos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUCHKDebugBuildingPos.CheckedChanged
        DrawBuildingDebugPos = sender.Checked
        MNUCHKDebugBuildingPos.Checked = DrawBuildingDebugPos
        PICMap.Invalidate()
    End Sub

    Private Sub CMDTileDataEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDTileDataEditor.Click
        FRMTileData.ShowDialog(Me)
    End Sub

    Private Sub CMDDeveloper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDeveloper.Click
        MNUDev.Visible = True
        MNUImport.Visible = True
        CMDExportAS.Visible = True
        Separator3.Visible = True
        MNUCHKDebugBuildingPos.Visible = True
    End Sub

    Private Sub CMDEditTiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEditTiles.Click
        ActiveEditMode = EditMode.Tiles
        LBLSelected.Text = "Selected Tile:"
        PICActive.Image = ActiveTile.Image
        CMDEditTiles.Enabled = False
        CMDEditBuildings.Enabled = True
        CMDEditUnits.Enabled = True
        PNLTiles.Show()
        PNLBuildings.Hide()
        PNLUnits.Hide()
        PNLMap.Height = PNLTiles.Height
        PNLMap.Location = New Point(PNLMap.Location.X, PNLTiles.Location.Y)
    End Sub

    Private Sub CMDEditBuildings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEditBuildings.Click
        ActiveEditMode = EditMode.Buildings
        LBLSelected.Text = "Selected Building:"
        PICActive.Image = ActiveBuilding.SmallImage
        CMDEditTiles.Enabled = True
        CMDEditBuildings.Enabled = False
        CMDEditUnits.Enabled = True
        PNLTiles.Hide()
        PNLBuildings.Show()
        PNLUnits.Hide()
        PNLMap.Height = PNLBuildings.Height
        PNLMap.Location = New Point(PNLMap.Location.X, PNLBuildings.Location.Y)
    End Sub

    Private Sub CMDEditUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEditUnits.Click
        ActiveEditMode = EditMode.Units
        LBLSelected.Text = "Selected Unit:"
        PICActive.Image = ActiveUnit.SmallImage
        CMDEditTiles.Enabled = True
        CMDEditBuildings.Enabled = True
        CMDEditUnits.Enabled = False
        PNLTiles.Hide()
        PNLBuildings.Hide()
        PNLUnits.Show()
        PNLMap.Height = PNLUnits.Height
        PNLMap.Location = New Point(PNLMap.Location.X, PNLUnits.Location.Y)
    End Sub

    Private Sub CMDEditShroud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEditShroud.Click
        ActiveEditMode = EditMode.Shroud
    End Sub

    Private Sub CMDToolBrush_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDToolBrush.Click
        ActiveToolMode = ToolMode.Brush

        CMDToolBrush.Enabled = False
        'CMDToolSmartBrush.Enabled = True
        CMDToolErase.Enabled = True
        'PICTiles.Show()
        'PICBuildings.Show()
        'PICUnits.Show()
        PICTiles.Invalidate()
        PICBuildings.Invalidate()
        PICUnits.Invalidate()
        PICActive.Invalidate()
    End Sub

    Private Sub CMDToolSmartBrush_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDToolSmartBrush.Click
        ActiveToolMode = ToolMode.SmartBrush

        PICActive.Image = Nothing
        ActiveTile = New Tile(0, 0)
        ActiveTile.TileId = -2

        CMDToolBrush.Enabled = True
        CMDToolSmartBrush.Enabled = False
        CMDToolErase.Enabled = True
    End Sub

    Private Sub CMDToolErase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDToolErase.Click
        ActiveToolMode = ToolMode.Eraser

        'PICActive.Image = Nothing
        'If activeEditMode = EditMode.Tiles Then
        '    'ToolMode = 0
        '    ActiveTile = New Tile(0, 0)
        'ElseIf activeEditMode = EditMode.Buildings Then
        '    ActiveBuilding = New c_Object(0, 0)
        'ElseIf activeEditMode = EditMode.Units Then
        '    ActiveUnit = New Unit(0, 0)
        'ElseIf activeEditMode = EditMode.Shroud Then
        '    'For later.
        'End If

        CMDToolBrush.Enabled = True
        'CMDToolSmartBrush.Enabled = True
        CMDToolErase.Enabled = False
        'PICTiles.Hide()
        'PICBuildings.Hide()
        'PICUnits.Hide()
        PICTiles.Invalidate()
        PICBuildings.Invalidate()
        PICUnits.Invalidate()
        PICActive.Invalidate()
    End Sub

    Private Sub CHKAssociateFileTypeCAMM_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKAssociateFileTypeCAMM.CheckStateChanged
        If IsLoaded Then
            If CHKAssociateFileTypeCAMM.CheckState = CheckState.Checked Then

                Try
                    My.Computer.Registry.ClassesRoot.CreateSubKey(".camm").SetValue("", "CAMM", Microsoft.Win32.RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey(".camm").SetValue("Content Type", "text/plain", Microsoft.Win32.RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey(".camm").SetValue("PerceivedType", "document", Microsoft.Win32.RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM").SetValue("", "CAMM Map File", Microsoft.Win32.RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM").SetValue("AlwaysShowExt", "", Microsoft.Win32.RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM").SetValue("BrowserFlags", 8, Microsoft.Win32.RegistryValueKind.DWord)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM").SetValue("EditFlags", 302144, Microsoft.Win32.RegistryValueKind.DWord)
                    ' Thanks to ETXAlienRobot201 for making the .camm file icon.
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM\DefaultIcon").SetValue("", """" + Application.ExecutablePath + """" + ",1", Microsoft.Win32.RegistryValueKind.String)
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM\shell").SetValue("", "open")
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM\shell\open").SetValue("", "&Edit with CAMM")
                    My.Computer.Registry.ClassesRoot.CreateSubKey("CAMM\shell\open\command").SetValue("", Application.ExecutablePath + " ""%l"" ", Microsoft.Win32.RegistryValueKind.String)
                Catch ex As UnauthorizedAccessException
                    ' No access to register the .camm file extension, just ignore this.
                Catch ex As Exception
                    ' I'm sure there's any number of other things that could happen here,
                    ' we are dealing with a core system feature after all.
                    MsgBox(ex.Message + vbNewLine + vbNewLine + ex.StackTrace)
                End Try

            ElseIf CHKAssociateFileTypeCAMM.CheckState = CheckState.Unchecked Then

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

    Private Sub CHKAssociateFileTypeMap_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKAssociateFileTypeMap.CheckStateChanged
        ' TODO: Associate .map files, though it may not be such a good idea.
    End Sub

#End Region

    Private Sub CheckFileAssociations()

        Try
            If My.Computer.Registry.ClassesRoot.GetSubKeyNames().Contains(".camm") And My.Computer.Registry.ClassesRoot.GetSubKeyNames().Contains("CAMM") Then
                If My.Computer.Registry.ClassesRoot.OpenSubKey(".camm", False).GetValue("", "-1") <> "CAMM" Or My.Computer.Registry.ClassesRoot.OpenSubKey("CAMM", False).GetValue("", "-1") <> "CAMM Map File" Then
                    CHKAssociateFileTypeCAMM.CheckState = CheckState.Indeterminate
                Else
                    CHKAssociateFileTypeCAMM.CheckState = CheckState.Checked
                End If
            Else
                CHKAssociateFileTypeCAMM.CheckState = CheckState.Unchecked
            End If
            My.Computer.Registry.ClassesRoot.OpenSubKey(".camm", True)
            My.Computer.Registry.ClassesRoot.OpenSubKey("CAMM", True)
        Catch ex As UnauthorizedAccessException
            ' No access to read or write the registry...
            CHKAssociateFileTypeCAMM.Enabled = False
            CHKAssociateFileTypeCAMM.ToolTipText = "You must run CAMM as an Administrator to change this."
            'CHKAssociateFileTypeMap.Enabled = False
        Catch ex As Security.SecurityException
            ' No access to read or write the registry...
            CHKAssociateFileTypeCAMM.Enabled = False
            CHKAssociateFileTypeCAMM.ToolTipText = "You must run CAMM as an Administrator to change this."
            'CHKAssociateFileTypeMap.Enabled = False
        Catch ex As Exception
            ' I'm sure there's any number of other things that could happen here,
            ' we are dealing with a core system feature after all.
            ' MsgBox(ex.Message + vbNewLine + vbNewLine + ex.StackTrace)
        End Try

    End Sub

#Region "Export & Import"

    Private Sub CMDExportPNG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDExportPNG.Click
        If SavePNG.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim W As Integer = (ActiveMap.SizeX * TileSizeX) + 1
            Dim H As Integer = (ActiveMap.SizeY * TileSizeY) + 1
            Dim img As Image = New Bitmap(W, H, Imaging.PixelFormat.Format24bppRgb)
            Dim g As Graphics = Graphics.FromImage(img)
            ActiveMap.Draw(g, DrawGrid, False)
            g.Dispose()
            img.Save(SavePNG.FileName, Imaging.ImageFormat.Png)
        End If
    End Sub

    Private Sub CMDExportAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDExportAS.Click
        Dim ExportASTileData As String = AsciiLookup(ActiveMap.SizeX) + AsciiLookup(ActiveMap.SizeY)

        For y As Integer = 0 To ActiveMap.SizeY - 1
            For x As Integer = 0 To ActiveMap.SizeX - 1
                Dim idx As Integer = ActiveMap.GetTileAt(x * TileSizeX, y * TileSizeY).TileId
                If idx < 0 Then
                    idx = 0
                End If

                Dim chr As String = AsciiLookup(idx)

                ExportASTileData += chr
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
        output += vbTab + vbTab + "map_new : """ + ExportASTileData + """.split("""",10000)" + vbNewLine
        output += vbTab + "};"
        FRMExportAS.TXTOutput.Text = output

        FRMExportAS.ShowDialog(Me)
    End Sub

    Public ImportASTileData As String = ""
    Private Sub CMDImportAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDImportAS.Click
        If FRMImportAS.ShowDialog(Me) = Windows.Forms.DialogResult.OK And ImportASTileData <> "" Then
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

                    For j As Integer = 0 To TileDefs.Length - 1
                        If tileId = TileDefs(j).TileId Then
                            ActiveMap.SetTile(x, y, New Tile(x, y, tileId))
                            Exit For
                        End If
                    Next

                    count += 1
                Next x
            Next y

            IsMapOpen = False
            ActiveMap.MapTitle += " (Imported ActionScript)"
            UpdateMapTabs()
            UpdateFormTitle()
            PICMap.Invalidate()
        End If
    End Sub

#End Region

    Private Sub CMDMapProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDMapProperties.Click
        FRMMapProperties.ShowDialog(Me)
    End Sub

    Private Sub MapTabs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MapTabs.SelectedIndexChanged
        'ActiveLevelNum = CBOLevel.SelectedIndex
        UpdateFormTitle()
        PICMap.Invalidate()
    End Sub

    Private Sub UpdateMapTabs()
        If Maps.Count < MapTabs.TabPages.Count Then
            Do
                MapTabs.TabPages.RemoveAt(MapTabs.TabPages.Count - 1)
            Loop Until Maps.Count = MapTabs.TabPages.Count
        End If
        If MapTabs.TabPages.Count > 0 Then
            For i As Integer = 0 To MapTabs.TabPages.Count - 1
                Dim tabText As String = (i + 1).ToString() + ") " + Maps(i).MapTitle
                MapTabs.TabPages(i).Text = tabText
                'MapTabs.TabPages(i).ToolTipText = tabText
            Next
        End If
        If Maps.Count > MapTabs.TabPages.Count Then
            For i As Integer = MapTabs.TabPages.Count To Maps.Count - 1
                Dim tabText As String = (i + 1).ToString() + ") " + Maps(i).MapTitle
                Dim newTab = New TabPage(tabText)
                'newTab.ToolTipText = tabText
                MapTabs.TabPages.Add(newTab)
            Next
        End If
    End Sub

    Private Sub UpdateFormTitle()
        Dim title As String = BaseFormTitle
        If Maps.Count > 0 Then
            title += " - " + ActiveMap.MapTitle
            If Not String.IsNullOrEmpty(ActiveMap.FileName) Then
                title += " - " + My.Computer.FileSystem.GetFileInfo(ActiveMap.FileName).Name
            Else
                title += " - (Unsaved)"
            End If
        End If
        Me.Text = title
    End Sub

    Private Sub CMDClose_Click(sender As Object, e As EventArgs) Handles CMDClose.Click
        Dim menuLocation As Point = MapTabs.PointToClient(CTXMapTabs.Location)

        For i As Integer = 0 To Maps.Count - 1
            Dim rect As Rectangle = MapTabs.GetTabRect(i)
            If rect.Contains(menuLocation) Then
                If MapTabs.TabPages.Count = 1 Then
                    NewMap()
                End If
                Maps.RemoveAt(i)
                UpdateMapTabs()
                If i - 1 >= 0 Then
                    MapTabs.SelectedIndex = i - 1
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub CTXMapTabs_Opened(sender As Object, e As EventArgs) Handles CTXMapTabs.Opened
        Dim menuLocation As Point = MapTabs.PointToClient(CTXMapTabs.Location)

        For i As Integer = 0 To Maps.Count - 1
            Dim rect As Rectangle = MapTabs.GetTabRect(i)
            If rect.Contains(menuLocation) Then
                If i >= 0 Then
                    MapTabs.SelectedIndex = i
                End If
                Exit For
            End If
        Next
    End Sub
End Class
