'-============================================================================================-'
'  CAMM (Crystal Alien Map Maker) program created by Josh (aka. leveleditor / Leveleditor6680) '
'-============================================================================================-'

Imports Nini.Config
Imports Nini.Ini
Public Class FRMEditor

#Region "Declarations"
    Dim IsMapOpen As Boolean = False
    Private BaseFormTitle As String

    Private Property ActiveLevelNum As Integer
        Get
            Return CBOLevel.SelectedIndex
        End Get
        Set(value As Integer)
            CBOLevel.SelectedIndex = value
        End Set
    End Property
    Private ReadOnly _levels As List(Of Level) = New List(Of Level)
    Public ReadOnly Property Levels As List(Of Level)
        Get
            Return _levels
        End Get
    End Property
    Public Property ActiveLevel As Level
        Get
            Return Levels(ActiveLevelNum)
        End Get
        Set(ByVal value As Level)
            Levels(ActiveLevelNum) = value
        End Set
    End Property
    Public Property ActiveMap As Map
        Get
            Return ActiveLevel.Map
        End Get
        Set(ByVal value As Map)
            ActiveLevel.Map = value
        End Set
    End Property

    Private ReadOnly Property MapSizeX As Integer
        Get
            Return ActiveMap.MapSizeX
        End Get
    End Property
    Private ReadOnly Property MapSizeY As Integer
        Get
            Return ActiveMap.MapSizeY
        End Get
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

    'INI Variables.
    Dim INIArray As String = ""
    Dim INISeparator As Char

    'ASCII Lookup Array
    Public Shared Ascii As String() = {}

    Private ReadOnly Property MapTiles As Tile()
        Get
            Return ActiveMap.MapTiles
        End Get
    End Property
    Private ReadOnly Property MapBuildings As List(Of Building)
        Get
            Return ActiveMap.MapBuildings
        End Get
    End Property
    Private ReadOnly Property MapUnits As List(Of Unit)
        Get
            Return ActiveMap.MapUnits
        End Get
    End Property

    Dim SelTiles() As Tile = {} 'Tile Selections.
    Dim SelBuildings() As Building = {} 'Unit, Building, and Item Selections.
    Dim SelUnits() As Building = {} 'Unit Selections.

    Dim ActiveTile As Tile 'The currently active tile selection.
    Dim ActiveBuilding As Building 'The currently active object selection.
    Dim ActiveUnit As Unit 'The currently active unit selection.
#End Region

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

        Dim Y1 As Integer = 0
        Dim Y2 As Integer = 0
        Dim Y3 As Integer = 0
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
            INIArray = config.GetString("Array Modifiers")
            INISeparator = Char.Parse(config.GetString("Array Separator"))

            config = source.Configs.Item("ASCII LOOKUP")
            Dim AsciiSeparator As String = config.GetString("Ascii Separator")
            Ascii = config.Get("Ascii Array").Trim(INIArray.ToCharArray).Trim(AsciiSeparator.ToCharArray()).Split(New String() {AsciiSeparator}, StringSplitOptions.None)

            config = source.Configs.Item("DEFINE TERRAIN")
            For i As Integer = 0 To config.GetKeys().Length - 1
                Dim KeyName As String = "Terrain" + i.ToString
                If config.Get(KeyName, "-1") <> "-1" Then
                    Dim KeyArray As String() = config.Get(KeyName).Trim(INIArray.ToCharArray).Split(New Char() {INISeparator}, StringSplitOptions.None)
                    Dim TerrainID As String = KeyArray(0)
                    Dim IsPassable As Boolean = CBool(KeyArray(1))
                    Dim IsMinerals As Boolean = CBool(KeyArray(2))
                    Dim ImageUrl As String = KeyArray(3)

                    Dim FullImageURL As String = My.Application.Info.DirectoryPath + DataPath + "/../" + ImageUrl
                    Dim TheImage As Image = Image.FromFile(FullImageURL)

                    ReDim Preserve SelTiles(Y1)
                    SelTiles(Y1) = New Tile(0, Y1 * TileSizeY, TheImage, TerrainID, IsPassable, IsMinerals)

                    Y1 += 1

                End If
            Next

            config = source.Configs.Item("DEFINE BUILDINGS")
            For i As Integer = 0 To config.GetKeys().Length - 1
                Dim KeyName As String = "Building" + i.ToString
                If config.Get(KeyName, "-1") <> "-1" Then
                    Dim KeyArray As String() = config.Get(KeyName).Trim(INIArray.ToCharArray).Split(New Char() {INISeparator}, StringSplitOptions.None)
                    Dim ObjectID As String = KeyArray(0)
                    Dim Width As Integer = CInt(KeyArray(1))
                    Dim Height As Integer = CInt(KeyArray(2))
                    Dim Team As Team = CType(Integer.Parse(KeyArray(3)), Team)
                    Dim Angle As Single = CSng(KeyArray(4))
                    Dim Damage As Single = CSng(KeyArray(5))
                    Dim OffsetY As Integer = CInt(KeyArray(6))
                    Dim ImageUrl As String = KeyArray(7)
                    Dim FullImageURL As String = My.Application.Info.DirectoryPath + DataPath + "/../" + ImageUrl

                    Dim Test As Bitmap = Bitmap.FromFile(FullImageURL)
                    Dim flag As New Bitmap(TileSizeX, TileSizeY)
                    Dim BitX, BitY As Integer
                    For BitX = 0 To flag.Width - 1
                        For BitY = 0 To flag.Height - 1
                            flag.SetPixel(BitX, BitY, Test.GetPixel(BitX + ((Test.Width / 2) - (TileSizeX / 2)), BitY + ((Test.Height / 2) - TileSizeY) + OffsetY))
                        Next
                    Next
                    Dim TheImage As Image = flag
                    'TheImage = TheImage.GetThumbnailImage(TileSizeX, TileSizeY, Nothing, System.IntPtr.Zero)

                    ReDim Preserve SelBuildings(Y2)
                    SelBuildings(Y2) = New Building(0, Y2 * TileSizeY, TheImage, ObjectID, Team, Angle, Damage, Width, Height)
                    SelBuildings(Y2).FullImage = Image.FromFile(FullImageURL)

                    Y2 += 1
                End If
            Next

            config = source.Configs.Item("DEFINE UNITS")
            For i As Integer = 0 To config.GetKeys().Length - 1
                Dim KeyName As String = "Unit" + i.ToString
                If config.Get(KeyName, "-1") <> "-1" Then
                    Dim KeyArray As String() = config.Get(KeyName).Trim(INIArray.ToCharArray).Split(New Char() {INISeparator}, StringSplitOptions.None)
                    Dim ObjectID As String = KeyArray(0)
                    Dim Width As Integer = CInt(KeyArray(1))
                    Dim Height As Integer = CInt(KeyArray(2))
                    Dim Team As Team = CType(Integer.Parse(KeyArray(3)), Team)
                    Dim Angle As Single = CSng(KeyArray(4))
                    Dim Damage As Single = CSng(KeyArray(5))
                    Dim OffsetY As Integer = CInt(KeyArray(6))
                    Dim ImageUrl As String = KeyArray(7)
                    Dim FullImageURL As String = My.Application.Info.DirectoryPath + DataPath + "/../" + ImageUrl

                    Dim Test As Bitmap = Bitmap.FromFile(FullImageURL)
                    Dim W As Integer = TileSizeX
                    Dim H As Integer = TileSizeY
                    If Test.Size.Width < TileSizeX Then
                        W = Test.Size.Width
                    End If
                    If Test.Size.Height < TileSizeY Then
                        H = Test.Size.Height
                    End If

                    Dim flag As New Bitmap(W, H)
                    Dim BitX, BitY As Integer
                    For BitX = 0 To flag.Width - 1
                        For BitY = 0 To flag.Height - 1
                            Dim Pixel As Color = Color.Transparent
                            Try
                                Pixel = Test.GetPixel(BitX + ((Test.Width / 2) - (W / 2)), BitY + ((Test.Height / 2) - TileSizeY) + OffsetY)
                            Catch ex As Exception

                            End Try
                            flag.SetPixel(BitX, BitY, Pixel)
                        Next
                    Next
                    Dim TheImage As Image = flag
                    'TheImage = TheImage.GetThumbnailImage(TileSizeX, TileSizeY, Nothing, System.IntPtr.Zero)

                    ReDim Preserve SelUnits(Y3)
                    SelUnits(Y3) = New Building(0, Y3 * TileSizeY, TheImage, ObjectID, Team, Angle, Damage, Width, Height)
                    SelUnits(Y3).FullImage = Image.FromFile(FullImageURL)

                    Y3 += 1
                End If
            Next
        End If

        'Dynamically setting PICTiles size.
        PICTiles.Size = New Size(TileSizeX + 1, (Y1 * TileSizeY) + 1)
        PICTiles.Invalidate()

        'Dynamically setting PICBuildings size.
        PICBuildings.Size = New Size(TileSizeX + 1, (Y2 * TileSizeY) + 1)
        PICBuildings.Invalidate()

        'Dynamically setting PICUnits size.
        PICUnits.Size = New Size(TileSizeX + 1, (Y3 * TileSizeY) + 1)
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
        If IntroTimer.Enabled Then
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
        End If
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

        TXTWidth.Text = ActiveMap.MapSizeX
        TXTHeight.Text = ActiveMap.MapSizeY
        PICMap.Size = New Size((ActiveMap.MapSizeX * TileSizeX) + 1, (ActiveMap.MapSizeY * TileSizeY) + 1)

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
        RenderMapToGraphics(e.Graphics)
    End Sub

    Public Sub RenderMapToGraphics(ByRef g As Graphics)
        If IsLoaded Then
            g.Clear(Color.FromKnownColor(KnownColor.Control))

            ' Draw the background
            Dim BGX As Integer = 0
            Dim BGY As Integer = 0
            Do Until BGX >= PICMap.ClientSize.Width
                Do Until BGY >= PICMap.ClientSize.Height
                    g.DrawImage(Background, BGX, BGY)
                    BGY += Background.Height
                Loop
                BGY = 0
                BGX += Background.Width
            Loop

            ' Draw any existing tiles.
            For i As Integer = 0 To MapTiles.Length - 1
                If MapTiles(i).HasData Then
                    g.DrawImage(MapTiles(i).Image, MapTiles(i).Position)
                End If
            Next

            ' Draw building baseplates.
            For i As Integer = 0 To MapBuildings.Count() - 1
                If MapBuildings(i).HasData Then
                    Dim teamBaseplate As Image = Nothing
                    If MapBuildings(i).Team = Team.Astros And MapBuildings(i).BuildingW = 1 Then
                        teamBaseplate = BaseplateAstroSmall
                    ElseIf MapBuildings(i).Team = Team.Aliens And MapBuildings(i).BuildingW = 1 Then
                        teamBaseplate = BaseplateAlienSmall
                    ElseIf MapBuildings(i).Team = Team.Astros Then
                        teamBaseplate = BaseplateAstroWide
                    ElseIf MapBuildings(i).Team = Team.Aliens Then
                        teamBaseplate = BaseplateAlienWide
                    End If
                    If teamBaseplate IsNot Nothing Then
                        Dim location As Point = MapBuildings(i).Location
                        If MapBuildings(i).BuildingW > 1 Then
                            location.X += (MapBuildings(i).BuildingW * TileSizeX) / 2
                            location.X -= TileSizeX
                        Else
                            location.X -= TileSizeX / 2
                        End If
                        If MapBuildings(i).BuildingH > 1 Then
                            location.Y += (MapBuildings(i).BuildingH * TileSizeY) - TileSizeY
                        End If
                        location.Y -= TileSizeY + 10

                        g.DrawImage(teamBaseplate, _
                                 location.X, _
                                 location.Y, _
                                 teamBaseplate.Width, _
                                 teamBaseplate.Height)
                    End If
                End If
            Next

            ' Draw any existing buildings.
            For i As Integer = 0 To MapBuildings.Count() - 1
                If MapBuildings(i).HasData Then

                    g.DrawImage(MapBuildings(i).FullImage, _
                         MapBuildings(i).DrawPos.X, _
                         MapBuildings(i).DrawPos.Y, _
                         MapBuildings(i).FullImage.Width, _
                         MapBuildings(i).FullImage.Height)

                    If DrawBuildingDebugPos Then
                        g.DrawRectangle(Pens.Lime, MapBuildings(i).Location.X - 1, MapBuildings(i).Location.Y - 1, 2, 2)
                        g.DrawRectangle(Pens.Blue, MapBuildings(i).DrawPos.X - 2, MapBuildings(i).DrawPos.Y - 2, 4, 4)
                    End If
                End If
            Next

            ' Draw any existing units.
            For i As Integer = 0 To MapUnits.Count() - 1
                If MapUnits(i).HasData Then

                    g.DrawImage(MapUnits(i).FullImage, _
                         MapUnits(i).Position.X - CInt(MapUnits(i).FullImage.Width / 2), _
                         MapUnits(i).Position.Y - CInt(MapUnits(i).FullImage.Height / 2), _
                         MapUnits(i).FullImage.Width, _
                         MapUnits(i).FullImage.Height)
                End If
            Next

            If DrawGrid Then
                ' Draw the grid.
                For x As Integer = 0 To PICMap.ClientSize.Width Step TileSizeX
                    For y As Integer = 0 To PICMap.ClientSize.Height Step TileSizeY
                        g.DrawLine(PenGrid, x, y, x + 0.5F, y + TileSizeY)
                        g.DrawLine(PenGrid, x, y, x + TileSizeX, y + 0.5F)
                    Next y
                Next x
            End If

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
            DrawIntro(g)
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

            For i As Integer = 0 To SelTiles.Length - 1
                If SelTiles(i).HasData Then
                    e.Graphics.DrawImage(SelTiles(i).Image, SelTiles(i).Position)
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

            For i As Integer = 0 To SelTiles.Length - 1
                If SelTiles(i).Position = New Point(MouseX, MouseY) Then
                    PICActive.Image = SelTiles(i).Image
                    ActiveTile.Image = SelTiles(i).Image
                    ActiveTile.TileId = SelTiles(i).TileId
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
            For i As Integer = 0 To SelBuildings.Length - 1
                If SelBuildings(i).HasData Then
                    If SelBuildings(i).Team = Team.Astros Then
                        e.Graphics.DrawImage(ButtonAstro, SelBuildings(i).Location.X, SelBuildings(i).Location.Y, ButtonAstro.Width, ButtonAstro.Height)
                    ElseIf SelBuildings(i).Team = Team.Aliens Then
                        e.Graphics.DrawImage(ButtonAlien, SelBuildings(i).Location.X, SelBuildings(i).Location.Y, ButtonAlien.Width, ButtonAlien.Height)
                    Else
                        e.Graphics.DrawImage(ButtonNeutral, SelBuildings(i).Location.X, SelBuildings(i).Location.Y, ButtonNeutral.Width, ButtonNeutral.Height)
                    End If
                    e.Graphics.DrawImage(SelBuildings(i).Image, SelBuildings(i).Location)
                    e.Graphics.DrawImage(ButtonOverlay, SelBuildings(i).Location)
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

            For i As Integer = 0 To SelBuildings.Length - 1
                If SelBuildings(i).Location = New Point(MouseX, MouseY) Then
                    PICActive.Image = SelBuildings(i).Image
                    ActiveBuilding.Image = SelBuildings(i).Image
                    ActiveBuilding.FullImage = SelBuildings(i).FullImage
                    ActiveBuilding.BuildingId = SelBuildings(i).BuildingId
                    ActiveBuilding.Team = SelBuildings(i).Team
                    ActiveBuilding.BuildingW = SelBuildings(i).BuildingW
                    ActiveBuilding.BuildingH = SelBuildings(i).BuildingH
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
            For i As Integer = 0 To SelUnits.Length - 1
                If SelUnits(i).HasData Then
                    If SelUnits(i).Team = Team.Astros Then
                        e.Graphics.DrawImage(ButtonAstro, SelUnits(i).Location)
                    ElseIf SelUnits(i).Team = Team.Aliens Then
                        e.Graphics.DrawImage(ButtonAlien, SelUnits(i).Location)
                    Else
                        e.Graphics.DrawImage(ButtonNeutral, SelUnits(i).Location.X, SelUnits(i).Location.Y, ButtonNeutral.Width, ButtonNeutral.Height)
                    End If
                    e.Graphics.DrawImage(SelUnits(i).Image, SelUnits(i).Location)
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

            For i As Integer = 0 To SelUnits.Length - 1
                If SelUnits(i).Location = New Point(MouseX, MouseY) Then
                    PICActive.Image = SelUnits(i).Image
                    ActiveUnit.Image = SelUnits(i).Image
                    ActiveUnit.FullImage = SelUnits(i).FullImage
                    ActiveUnit.UnitId = SelUnits(i).BuildingId
                    ActiveUnit.Team = SelUnits(i).Team
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

        Dim newLevel As Level = New Level()
        newLevel.Map.MapTitle = "New Map"
        Levels.Add(newLevel)
        UpdateLevelsList()
        'CBOLevel.Items.Add("Map " + Levels.Count.ToString() + " [" + newLevel.Map.MapTitle + "]")
        ActiveLevelNum = Levels.IndexOf(newLevel)
        UpdateFormTitle()

        PICMap.Size = New Size((ActiveMap.MapSizeX * TileSizeX) + 1, (ActiveMap.MapSizeY * TileSizeY) + 1)
        TXTWidth.Text = ActiveMap.MapSizeX
        TXTHeight.Text = ActiveMap.MapSizeY
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
            LoadMapv0(source, config)
        Else
            Dim v As Integer = config.GetInt("vFormat", -1)
            If v > MapFormat Then
                MsgBox("This map file was created with a newer version of CAMM and cannot be opened.")
            ElseIf v = 1 Then
                LoadMapv1(source, config)
            ElseIf v = 2 Or v = 3 Or v = 4 Or v = MapFormat Then
                LoadMapv2v3v4v5(source, config, v)
            End If
        End If
        UpdateLevelsList()
    End Sub
    Public Sub LoadMapv0(ByVal source As IniConfigSource, ByVal config As IConfig)
        'InitTiles()
        NewMap()
        config = source.Configs.Item("Map Size")
        ActiveMap.SetSize(config.GetInt("W"), config.GetInt("H"))
        ActiveMap.MapTitle = "Converted Map"
        'InitMap()
        config = source.Configs.Item("Tile Data")
        For i As Integer = 0 To MapTiles.Length - 1
            Dim TempName As String = "Tile_1_" + (i + 1).ToString
            Dim TempArray As String() = config.Get(TempName).Trim("()".ToCharArray).Split(New Char() {Char.Parse(":")}, StringSplitOptions.None)
            Dim TempTileID As Integer = Integer.Parse(TempArray(0))
            'There is no need of getting the 'Team' info since it should have always been set as 'Neutral' and it's useless now.
            Dim TempTileType As String = TempArray(2)

            ' Upgrade old terrain Ids
            UpgradeTerrainId(0, MapFormat, TempTileID)

            MapTiles(i).TileId = TempTileID
            'Tiles(i).Tile_Type = TempTileType
            For j As Integer = 0 To SelTiles.Length - 1
                If MapTiles(i).TileId = SelTiles(j).TileId Then
                    MapTiles(i).Image = SelTiles(j).Image
                    Exit For
                End If
            Next
        Next

        IsMapOpen = True
        ActiveMap.FileName = OpenMap.FileName
        UpdateFormTitle()
        PICMap.Invalidate()
    End Sub
    Public Sub LoadMapv1(ByVal source As IniConfigSource, ByVal config As IConfig)
        NewMap()
        config = source.Configs.Item("Level")
        ActiveMap.MapTitle = config.GetString("Title")
        ActiveMap.SetSize(config.GetInt("W"), config.GetInt("H"))
        ActiveLevel.Team = CType(config.GetInt("Team"), Team)

        'InitMap()

        config = source.Configs.Item("Terrain")
        Dim TerrainCount As Integer = config.GetKeys().Length - 1
        If TerrainCount > 0 Then
            For i As Integer = 0 To TerrainCount
                If config.GetKeys(i) <> "-1" Then
                    Dim KeyArray As String() = config.Get(config.GetKeys(i)).Trim("{}".ToCharArray).Split(New Char() {Char.Parse("|")}, StringSplitOptions.None)
                    Dim TerrainID As Integer = Integer.Parse(KeyArray(0))
                    Dim PosX As Integer = KeyArray(1)
                    Dim PosY As Integer = KeyArray(2)

                    ' Upgrade old terrain Ids
                    UpgradeTerrainId(1, MapFormat, TerrainID)

                    MapTiles(i).TileId = TerrainID
                    MapTiles(i).Position = New Point(PosX * TileSizeX, PosY * TileSizeY)
                    For j As Integer = 0 To SelTiles.Length - 1
                        If MapTiles(i).TileId = SelTiles(j).TileId Then
                            MapTiles(i).Image = SelTiles(j).Image
                            Exit For
                        End If
                    Next
                End If
            Next
        End If

        config = source.Configs.Item("Objects")
        Dim ObjectCount As Integer = config.GetKeys().Length - 1
        If ObjectCount > 0 Then
            For i As Integer = 0 To ObjectCount
                If config.GetKeys(i) <> "-1" Then
                    Dim KeyArray As String() = config.Get(config.GetKeys(i)).Trim("{}".ToCharArray).Split(New Char() {Char.Parse("|")}, StringSplitOptions.None)
                    Dim ObjectID As String = KeyArray(0)
                    Dim PosX As Integer = KeyArray(1)
                    Dim PosY As Integer = KeyArray(2)
                    Dim IsFriend As Boolean = KeyArray(3)
                    Dim Team As Team = Team.Astros
                    If IsFriend Then
                        Team = Team.Aliens
                    End If
                    Dim Angle As Single = KeyArray(4)
                    Dim Damage As Single = KeyArray(5)

                    MapBuildings.Add(New Building(PosX * TileSizeX, PosY * TileSizeY))

                    ' Upgrade old building Ids
                    UpgradeBuildingId(1, MapFormat, ObjectID)

                    MapBuildings(i).BuildingId = ObjectID

                    MapBuildings(i).Team = Team
                    MapBuildings(i).Angle = Angle
                    MapBuildings(i).Damage = Damage
                    For j As Integer = 0 To SelBuildings.Length - 1
                        If MapBuildings(i).BuildingId = SelBuildings(j).BuildingId Then
                            MapBuildings(i).Image = SelBuildings(j).Image
                            MapBuildings(i).FullImage = SelBuildings(j).FullImage
                            'Note to self:
                            'I wasted half a day trying to figure out what was going wrong,
                            'only to discover I forgot these 2 extremely obvious missing lines:
                            MapBuildings(i).BuildingW = SelBuildings(j).BuildingW
                            MapBuildings(i).BuildingH = SelBuildings(j).BuildingH
                            Exit For
                        End If
                    Next

                    ActiveMap.UpgradeBuildingLocation(1, MapFormat, i, PosX * TileSizeX)
                End If
            Next
        End If

        'TODO: Temp fix for bug unplacable grid spaces after loading a map.
        ResizeMap(MapSizeX, MapSizeY)

        IsMapOpen = True
        ActiveMap.FileName = OpenMap.FileName
        UpdateFormTitle()
        PICMap.Invalidate()
    End Sub
    Public Sub LoadMapv2v3v4v5(ByVal source As IniConfigSource, ByVal config As IConfig, ByVal v As Integer)
        NewMap()
        config = source.Configs.Item("Level")
        ActiveMap.MapTitle = config.GetString("Title")
        ActiveMap.SetSize(config.GetInt("W"), config.GetInt("H"))
        ActiveLevel.Team = CType(config.GetInt("Team"), Team)
        ActiveLevel.CashPlayer = config.GetInt("CashPlayer", Level.CashPlayerDefault)
        ActiveLevel.CashEnemy = config.GetInt("CashEnemy", Level.CashEnemyDefault)
        ActiveLevel.IsTraining = config.GetBoolean("isTraining", Level.IsTrainingDefault)
        ActiveLevel.IsConflict = config.GetBoolean("isConflict", Level.IsConflictDefault)
        ActiveLevel.IsSpecialLevel = config.GetBoolean("isSpecialLevel", Level.IsSpecialLevelDefault)
        ActiveLevel.IsLastSpecialLevel = config.GetBoolean("isLastSpecialLevel", Level.IsLastSpecialLevelDefault)
        ActiveLevel.IsBonusLevel = config.GetBoolean("isBonusLevel", Level.IsBonusLevelDefault)
        ActiveMap.IsMapFinal = config.GetBoolean("Final", False)

        'InitMap()

        config = source.Configs.Item("Terrain")
        For i As Integer = 0 To config.GetKeys().Length - 1
            If config.GetKeys(i) <> "-1" Then
                Dim KeyArray As String() = config.Get(config.GetKeys(i)).Trim("{}".ToCharArray).Split(New Char() {Char.Parse("|")}, StringSplitOptions.None)
                Dim TerrainID As Integer = Integer.Parse(KeyArray(0))
                Dim PosX As Integer = KeyArray(1)
                Dim PosY As Integer = KeyArray(2)

                ' Upgrade old terrain Ids
                UpgradeTerrainId(v, MapFormat, TerrainID)

                MapTiles(i).TileId = TerrainID

                MapTiles(i).Position = New Point(PosX * TileSizeX, PosY * TileSizeY)
                For j As Integer = 0 To SelTiles.Length - 1
                    If MapTiles(i).TileId = SelTiles(j).TileId Then
                        MapTiles(i).Image = SelTiles(j).Image
                        Exit For
                    End If
                Next
            End If
        Next

        config = source.Configs.Item("Buildings")
        For i As Integer = 0 To config.GetKeys().Length - 1
            If config.GetKeys(i) <> "-1" Then
                Dim KeyArray As String() = config.Get(config.GetKeys(i)).Trim("{}".ToCharArray).Split(New Char() {Char.Parse("|")}, StringSplitOptions.None)
                Dim ObjectID As String = KeyArray(0)
                Dim PosX As Integer = KeyArray(1)
                Dim PosY As Integer = KeyArray(2)
                Dim IsFriend As Boolean = KeyArray(3)
                Dim Team As Team = Team.Astros
                If IsFriend Then
                    Team = Team.Aliens
                End If
                Dim Angle As Single = KeyArray(4)
                Dim Damage As Single = KeyArray(5)

                MapBuildings.Add(New Building(PosX * TileSizeX, PosY * TileSizeY))

                ' Upgrade old building Ids
                UpgradeBuildingId(v, MapFormat, ObjectID)

                MapBuildings(i).BuildingId = ObjectID

                MapBuildings(i).Team = Team
                MapBuildings(i).Angle = Angle
                MapBuildings(i).Damage = Damage
                For j As Integer = 0 To SelBuildings.Length - 1
                    If MapBuildings(i).BuildingId = SelBuildings(j).BuildingId Then
                        MapBuildings(i).Image = SelBuildings(j).Image
                        MapBuildings(i).FullImage = SelBuildings(j).FullImage
                        MapBuildings(i).BuildingW = SelBuildings(j).BuildingW
                        MapBuildings(i).BuildingH = SelBuildings(j).BuildingH
                        Exit For
                    End If
                Next

                If v < 4 Then
                    ActiveMap.UpgradeBuildingLocation(v, MapFormat, i, PosX * TileSizeX)
                End If
            End If
        Next

        config = source.Configs.Item("Units")
        For i As Integer = 0 To config.GetKeys().Length - 1
            If config.GetKeys(i) <> "-1" Then
                Dim KeyArray As String() = config.Get(config.GetKeys(i)).Trim("{}".ToCharArray).Split(New Char() {Char.Parse("|")}, StringSplitOptions.None)
                Dim UnitId As String = KeyArray(0)
                Dim PosX As Integer = KeyArray(1)
                Dim PosY As Integer = KeyArray(2)
                Dim IsFriend As Boolean = KeyArray(3)
                Dim Team As Team = Team.Astros
                If IsFriend Then
                    Team = Team.Aliens
                End If
                Dim Angle As Single = KeyArray(4)
                Dim Damage As Single = KeyArray(5)

                Dim unitX, unitY As Integer
                If v = 2 Then
                    unitX = PosX * TileSizeX
                    unitY = PosY * TileSizeY

                    unitX += (TileSizeX / 2)

                    Dim topLeftX As Single = Math.Floor((unitX / TileSizeX) - 1 / 2) + 1
                    Dim topLeftY As Single = Math.Floor((unitX / TileSizeX) - 1 + 3)
                    Dim dockX As Single = (topLeftX + ((1 / 2) - 1)) + 1 * TileSizeX
                    Dim dockY As Single = (topLeftY + (1 - 1)) + 1 * TileSizeX
                    dockX = Math.Ceiling(dockX / TileSizeX)
                    dockY = Math.Ceiling(dockY / TileSizeY)

                    unitX -= dockX
                    unitY -= dockY + TileSizeY
                Else
                    unitX = PosX
                    unitY = PosY
                End If

                ' Upgrade old unit Ids
                UpgradeUnitId(v, MapFormat, UnitId)

                Dim temp As Unit = New Unit(unitX, unitY, Nothing, UnitId, Team, Angle, Damage)
                For j As Integer = 0 To SelUnits.Length - 1
                    If temp.UnitId = SelUnits(j).BuildingId Then
                        temp.Image = SelUnits(j).Image
                        temp.FullImage = SelUnits(j).FullImage
                        Exit For
                    End If
                Next
                MapUnits.Add(temp)

                'TODO: Temp fix for a bug that I'm too lazy to fix. (Verify if this is fixed!)
                'SetDrawPos(1, i, PosX * TileSizeX)
            End If
        Next

        'TODO: Temp fix for bug unplacable grid spaces after loading a map.
        ResizeMap(MapSizeX, MapSizeY)

        IsMapOpen = True
        ActiveMap.FileName = OpenMap.FileName
        UpdateFormTitle()
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
            My.Computer.FileSystem.WriteAllText(FileName, ActiveLevel.GetSaveData(), False)
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
        ElseIf MouseX > (MapSizeX * TileSizeX) - 1 Then
            Return False
        ElseIf MouseY > (MapSizeY * TileSizeY) - 1 Then
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
                    e.Graphics.DrawImage(ActiveBuilding.Image, New Point(0, 0))
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
                    e.Graphics.DrawImage(ActiveUnit.Image, New Point(0, 0))
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
            TXTWidth.Text = MapSizeX
        ElseIf CInt(TXTHeight.Text) = 0 Then
            MsgBox("If a 2-Dimensional object has a height of 0, does it really exist?" + vbNewLine + "Height cannot be 0.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            TXTHeight.Text = MapSizeY
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
        PICActive.Image = ActiveBuilding.Image
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
        PICActive.Image = ActiveUnit.Image
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
            Dim W As Integer = (MapSizeX * TileSizeX) + 1
            Dim H As Integer = (MapSizeY * TileSizeY) + 1
            Dim img As Image = New Bitmap(W, H, Imaging.PixelFormat.Format24bppRgb)
            Dim g As Graphics = Graphics.FromImage(img)
            RenderMapToGraphics(g)
            g.Dispose()
            img.Save(SavePNG.FileName, Imaging.ImageFormat.Png)
        End If
    End Sub

    Private Sub CMDExportAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDExportAS.Click
        Dim ExportASTileData As String = Ascii(MapSizeX) + Ascii(MapSizeY)

        For y As Integer = 0 To MapSizeY - 1
            For x As Integer = 0 To MapSizeX - 1
                Dim idx As Integer = ActiveMap.GetTileAt(x * TileSizeX, y * TileSizeY).TileId
                If idx < 0 Then
                    idx = 0
                End If

                Dim chr As String = Ascii(idx)

                ExportASTileData += chr
            Next x
        Next y

        Dim output As String = vbTab + "this.data = {" + vbNewLine
        output += vbTab + vbTab + "tiles : ""0"
        '0AAAAAAAA AAAAAAAAAAAAAAA    AAAAAAAAAAAAAAAAA 1A A"
        Dim tiles As List(Of Tile) = (From t In SelTiles Order By t.TileId Where t.HasData).ToList()
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
            For y As Integer = 0 To (MapSizeY - 1) * TileSizeY Step TileSizeY
                For x As Integer = 0 To (MapSizeX - 1) * TileSizeX Step TileSizeX
                    'ReDim Preserve MapTiles(count)
                    'MapTiles(count) = New Tile(x, y)

                    Dim idx As Integer = Array.IndexOf(Ascii, ImportASTileData.ToCharArray()(count).ToString)
                    Dim tileId As Integer = -1
                    If idx > 0 Then
                        tileId = idx ' Old calculation: (4350 + 2 * idx)
                    End If

                    For j As Integer = 0 To SelTiles.Length - 1
                        If tileId = SelTiles(j).TileId Then
                            ActiveMap.SetTile(x, y, New Tile(x, y, SelTiles(j).Image, tileId))
                            'MapTiles(count).Image = SelTiles(j).Image
                            Exit For
                        End If
                    Next

                    count += 1
                Next x
            Next y

            IsMapOpen = False
            ActiveMap.MapTitle += " (Imported ActionScript)"
            UpdateFormTitle()
            PICMap.Invalidate()
        End If
    End Sub

#End Region

    Private Sub CMDMapProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDMapProperties.Click
        FRMMapProperties.ShowDialog(Me)
    End Sub

    Private Sub CBOLevel_DropDown(sender As Object, e As EventArgs) Handles CBOLevel.DropDown
        'Dim temp As Integer = ActiveLevelNum
        'CBOLevel.Items.Clear()
        'For i As Integer = 1 To _levels.Count
        '    CBOLevel.Items.Add("Map " + i.ToString())
        'Next
        'ActiveLevelNum = temp
        UpdateLevelsList()
    End Sub

    Private Sub CBOLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOLevel.SelectedIndexChanged
        'ActiveLevelNum = CBOLevel.SelectedIndex
        UpdateFormTitle()
        PICMap.Invalidate()
    End Sub

    Private Sub UpdateLevelsList()
        If CBOLevel.Items.Count > 0 Then
            For i As Integer = 0 To CBOLevel.Items.Count - 1
                CBOLevel.Items(i) = (i + 1).ToString() + ") " + Levels(i).Map.MapTitle
            Next
        End If
        If Levels.Count > CBOLevel.Items.Count Then
            For i As Integer = CBOLevel.Items.Count To Levels.Count - 1
                CBOLevel.Items.Add((i + 1).ToString() + ") " + Levels(i).Map.MapTitle)
            Next
        End If
    End Sub

    Private Sub UpdateFormTitle()
        Dim title As String = BaseFormTitle
        If Levels.Count > 0 Then
            title += " - " + ActiveMap.MapTitle
            If Not String.IsNullOrEmpty(ActiveMap.FileName) Then
                title += " - " + My.Computer.FileSystem.GetFileInfo(ActiveMap.FileName).Name
            Else
                title += " - (Unsaved)"
            End If
        End If
        Me.Text = title
    End Sub
End Class
