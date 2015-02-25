Imports Nini.Config

Public Class Map

    Public Sub New(ByVal parent As Level)
        Level = parent

        SizeX = 10
        SizeY = 10
        FileName = ""
        MapTitle = ""
        IsMapFinal = False

        MapTiles = New Tile() {}
        TempTiles = New Tile() {}
        InitTiles()
        MapBuildings = New List(Of Building)
        MapUnits = New List(Of Unit)
    End Sub

    Private _level As Level
    Public Property Level As Level
        Get
            Return _level
        End Get
        Private Set(value As Level)
            _level = value
        End Set
    End Property

    Private _sizeX As Integer
    Public Property SizeX As Integer
        Get
            Return _sizeX
        End Get
        Private Set(value As Integer)
            _sizeX = value
        End Set
    End Property

    Private _sizeY As Integer
    Public Property SizeY As Integer
        Get
            Return _sizeY
        End Get
        Private Set(value As Integer)
            _sizeY = value
        End Set
    End Property

    Public FileName As String
    Public MapTitle As String
    Public IsMapFinal As Boolean

    Private MapTiles As Tile()
    Private MapBuildings As List(Of Building)
    Private MapUnits As List(Of Unit)
    'Temporary array for resizing the map.
    Private TempTiles As Tile()

    Public Sub SetSize(ByVal width As Integer, ByVal height As Integer)
        ' TODO: The map shouldn't resize if it's already at the specified size, but due to a tempfix for bug "unplacable grid spaces after loading a map" it has to be able to set the map to it's own size...
        'If (width <> MapSizeX And height <> MapSizeY) Then
        ReDim TempTiles(SizeX * SizeY)
        TempTiles = MapTiles

        SizeX = width
        SizeY = height

        InitTiles()

        For i As Integer = 0 To MapTiles.Length - 1
            For j As Integer = 0 To TempTiles.Length - 1
                If MapTiles(i).Position = TempTiles(j).Position Then
                    MapTiles(i) = TempTiles(j)
                    Exit For
                End If
            Next
        Next
        Dim tempUnits As List(Of Unit) = MapUnits.ToList()
        For i As Integer = 0 To MapUnits.Count() - 1
            Dim pos As Point = MapUnits(i).Position
            If pos.X < 0 Or pos.Y < 0 Or pos.X > (SizeX * TileSizeX) - 1 Or pos.Y > (SizeY * TileSizeY) - 1 Then
                tempUnits.Remove(MapUnits(i))
            End If
        Next
        MapUnits = tempUnits
        'End If
    End Sub

    Public Sub ClearMap()
        For i As Integer = 0 To MapTiles.Length - 1
            MapTiles(i) = New Tile(0, 0)
        Next
        MapBuildings.Clear()
        MapUnits.Clear()
    End Sub

    Public Sub InitTiles()
        Dim tilesCounted As Integer = 0
        For y As Integer = 0 To (SizeY - 1) * TileSizeY Step TileSizeY
            For x As Integer = 0 To (SizeX - 1) * TileSizeX Step TileSizeX
                ReDim Preserve MapTiles(tilesCounted)
                MapTiles(tilesCounted) = New Tile(x, y)
                tilesCounted += 1
            Next x
        Next y
    End Sub

    Public Function GetTileAt(ByVal mouseX As Integer, ByVal mouseY As Integer) As Tile
        Dim returnTile As Tile = Nothing
        For i As Integer = 0 To MapTiles.Length - 1
            If MapTiles(i).Position = New Point(mouseX, mouseY) Then
                returnTile = MapTiles(i)
                Exit For
            End If
        Next
        Return returnTile
    End Function
    Public Function GetBuildingAt(ByVal mouseX As Integer, ByVal mouseY As Integer) As Building
        Dim returnBuilding As Building = Nothing
        For i As Integer = 0 To MapBuildings.Count() - 1
            If MapBuildings(i).Location = New Point(mouseX, mouseY) And MapBuildings(i).BuildingId <> "" Then
                returnBuilding = MapBuildings(i)
                Exit For
            End If
        Next
        Return returnBuilding
    End Function

    Public Sub SetTile(ByVal mouseX As Integer, ByVal mouseY As Integer, ByVal tile As Tile)
        If IsMouseInBounds(mouseX, mouseY) Then
            For i As Integer = 0 To MapTiles.Length - 1
                If MapTiles(i).Position.X = mouseX And MapTiles(i).Position.Y = mouseY Then
                    MapTiles(i) = New Tile(mouseX, mouseY, tile.Image, tile.TileId, tile.IsPassable, tile.IsMinerals)
                End If
            Next
        End If
    End Sub

    Public Sub SetTileSmart(ByVal mouseX As Integer, ByVal mouseY As Integer)
        Throw New NotImplementedException("The Smart Tile Brush feature is not yet implemented. Feel free to implement it yourself and submit a pull request on GitHub!")

        'If IsMouseInBounds(mouseX, mouseY) Then
        '    For i As Integer = 0 To MapTiles.Length - 1
        '        If MapTiles(i).Position.X = mouseX And MapTiles(i).Position.Y = mouseY Then
        '            Dim finalId As Integer = -1

        '            'This would take a while to finish...
        '            If MapTiles(i).TileId = -1 And _
        '            MapTiles(i + 1).TileId = -1 And _
        '            MapTiles(i - 1).TileId = -1 And _
        '            MapTiles(i - MapSizeX).TileId = -1 And _
        '            MapTiles(i + MapSizeX).TileId = -1 Then
        '                finalId = 8
        '            End If

        '            For j As Integer = 0 To SelTiles.Length - 1
        '                If finalId = SelTiles(j).TileId Then
        '                    MapTiles(i) = New Tile(mouseX, mouseY, SelTiles(j).Image, SelTiles(j).TileId)
        '                    Exit For
        '                End If
        '            Next

        '            Exit For
        '        End If
        '    Next
        'End If
    End Sub

    Public Sub SetBuilding(ByVal mouseX As Integer, ByVal mouseY As Integer, ByVal building As Building)
        If IsMouseInBounds(mouseX, mouseY) Then
            Dim found As Boolean = False
            For i As Integer = 0 To MapBuildings.Count() - 1
                If MapBuildings(i).Location.X = mouseX And MapBuildings(i).Location.Y = mouseY Then
                    found = True

                    MapBuildings(i) = New Building(mouseX, mouseY, building.Image, building.BuildingId, building.Team, building.Angle, building.Damage, building.BuildingW, building.BuildingH)
                    MapBuildings(i).FullImage = building.FullImage

                    Exit For
                End If
            Next
            If Not found Then
                Dim newBuilding As Building = New Building(mouseX, mouseY, building.Image, building.BuildingId, building.Team, building.Angle, building.Damage, building.BuildingW, building.BuildingH)
                newBuilding.FullImage = building.FullImage
                MapBuildings.Add(newBuilding)
            End If

            ' Reorder the list based on the Y locations of the buidings.
            ' This ensures that buildings closer to the top of the map render
            ' beneath buildings closer to the bottom of the map.
            MapBuildings = (From b In MapBuildings Order By b.Location.Y, b.Location.X).ToList()
        End If
    End Sub

    Public Sub SetUnit(ByVal mouseX As Integer, ByVal mouseY As Integer, ByVal unit As Unit)
        If IsMouseInBounds(mouseX, mouseY) Then
            Dim found As Boolean = False
            For i As Integer = 0 To MapUnits.Count() - 1
                ' This should help prevent spam and accidental double clicks.
                If MapUnits(i).Position.X = mouseX And MapUnits(i).Position.Y = mouseY And MapUnits(i).UnitId = unit.UnitId Then
                    found = True
                    Exit For
                End If
            Next
            If Not found Then
                Dim newUnit As Unit = New Unit(mouseX, mouseY, unit.Image, unit.UnitId, unit.Team, unit.Angle, unit.Damage)
                newUnit.FullImage = unit.FullImage
                MapUnits.Add(newUnit)

                ' Reorder the list based on the Y locations of the units.
                ' This ensures that units closer to the top of the map render
                ' beneath units closer to the bottom of the map.
                MapUnits = (From u In MapUnits Order By u.Position.Y, u.Position.X).ToList()
            End If
        End If
    End Sub

    Public Function IsMouseInBounds(ByVal mouseX As Integer, ByVal mouseY As Integer)
        If mouseX < 0 Then
            Return False
        ElseIf mouseY < 0 Then
            Return False
        ElseIf mouseX > (SizeX * TileSizeX) - 1 Then
            Return False
        ElseIf mouseY > (SizeY * TileSizeY) - 1 Then
            Return False
            'ElseIf IsMouseOnMap = False Then
            '    Return False
        Else
            Return True
        End If
    End Function

    Public Sub Eraser(ByVal mouseX As Integer, ByVal mouseY As Integer, ByVal mode As EditMode)
        Select Case mode
            Case EditMode.Tiles
                SetTile(mouseX, mouseY, New Tile(mouseX, mouseY))
            Case EditMode.Buildings
                Dim temp As List(Of Building) = MapBuildings.ToList()
                For i As Integer = 0 To MapBuildings.Count() - 1
                    If MapBuildings(i).Location = New Point(mouseX, mouseY) Then
                        temp.Remove(MapBuildings(i))
                    End If
                Next
                MapBuildings = temp
            Case EditMode.Units
                Dim temp As List(Of Unit) = MapUnits.ToList()
                For i As Integer = 0 To MapUnits.Count() - 1
                    If MapUnits(i).X >= mouseX And _
                       MapUnits(i).Y >= mouseY And _
                       MapUnits(i).X <= mouseX + TileSizeX And _
                       MapUnits(i).Y <= mouseY + TileSizeY Then
                        temp.Remove(MapUnits(i))
                    End If
                Next
                MapUnits = temp
        End Select
    End Sub

    Public Sub UpgradeBuildingLocation(ByVal oldv As Integer, ByVal newv As Integer, ByVal i As Integer, ByVal xpos As Integer)
        If oldv < 4 And (newv = 4 Or newv = 5) Then
            ' <<< Start old SetDrawPos code >>>
            Dim tempDrawPos As Point = MapBuildings(i).Location

            If MapBuildings(i).BuildingW Mod 2 Then
                tempDrawPos = New Point(tempDrawPos.X + (TileSizeX / 2), tempDrawPos.Y)
            End If
            If MapBuildings(i).BuildingH <> 2 Then
                tempDrawPos = New Point(tempDrawPos.X, tempDrawPos.Y - TileSizeY)
            End If

            Dim topLeftX As Single = Math.Floor((xpos / TileSizeX) - MapBuildings(i).BuildingW / 2) + 1
            Dim topLeftY As Single = Math.Floor((xpos / TileSizeX) - MapBuildings(i).BuildingH + 3)
            Dim dockX As Single = (topLeftX + ((MapBuildings(i).BuildingW / 2) - 1)) + 1 * TileSizeX
            Dim dockY As Single = (topLeftY + (MapBuildings(i).BuildingH - 1)) + 1 * TileSizeX
            dockX = Math.Ceiling(dockX / TileSizeX) - 2
            dockY = Math.Ceiling(dockY / TileSizeY) - 3

            tempDrawPos = New Point(tempDrawPos.X - dockX, tempDrawPos.Y - dockY)

            If MapBuildings(i).BuildingH = 2 Then
                tempDrawPos = New Point(tempDrawPos.X, tempDrawPos.Y - TileSizeY)
            End If

            ' There was also some related code in RenderMapToGraphics
            Dim OffY As Integer = TileSizeY

            tempDrawPos = New Point( _
                tempDrawPos.X - CInt(MapBuildings(i).FullImage.Width / 2), _
                tempDrawPos.Y - CInt(MapBuildings(i).FullImage.Height / 2) + OffY)

            ' <<< End old SetDrawPos code >>>

            ' New SetDrawPos code, but reversed!
            ' Warning: Buildings that were actually out of bounds in old maps may end up off screen.
            MapBuildings(i).Location = tempDrawPos

            Dim fixedLocation As Point = New Point(MapBuildings(i).Location.X + 1, MapBuildings(i).Location.Y + 1)

            fixedLocation.X += (MapBuildings(i).FullImage.Width - (MapBuildings(i).BuildingW * TileSizeX)) / 2
            fixedLocation.Y += (MapBuildings(i).FullImage.Height - (MapBuildings(i).BuildingH * TileSizeY)) / 2

            PointToGrid(fixedLocation)
            MapBuildings(i).Location = fixedLocation
        End If
    End Sub

    Public Sub Draw(ByRef g As Graphics, ByVal drawGrid As Boolean, Optional ByVal debugBuildingPos As Boolean = False)
        g.Clear(Color.FromKnownColor(KnownColor.Control))

        ' Draw the background
        Dim bgX As Integer = 0
        Dim bgY As Integer = 0
        Do Until bgX >= SizeX * TileSizeX
            Do Until bgY >= SizeY * TileSizeY
                g.DrawImage(Background, bgX, bgY)
                bgY += Background.Height
            Loop
            bgY = 0
            bgX += Background.Width
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

                If debugBuildingPos Then
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

        If drawGrid Then
            ' Draw the grid.
            For x As Integer = 0 To SizeX * TileSizeX Step TileSizeX
                For y As Integer = 0 To SizeY * TileSizeY Step TileSizeY
                    g.DrawLine(PenGrid, x, y, x + 0.5F, y + TileSizeY)
                    g.DrawLine(PenGrid, x, y, x + TileSizeX, y + 0.5F)
                Next y
            Next x
        End If
    End Sub

    Public Function GetSaveData() As String
        Dim saveFileData As String = ""

        saveFileData += "[Terrain]" + vbNewLine + _
            "; Terrain Format: {str_ID|i_posX|i_posY}" + vbNewLine

        Dim terrainNumber As Integer = 0
        For i As Integer = 0 To MapTiles.Length - 1
            If MapTiles(i).HasData Then
                saveFileData += "Terrain" + terrainNumber.ToString + " = {" + MapTiles(i).TileId.ToString + "|" + (MapTiles(i).X / TileSizeX).ToString + "|" + (MapTiles(i).Y / TileSizeY).ToString + "}" + vbNewLine
                terrainNumber += 1
            End If
        Next

        saveFileData += vbNewLine + "[Buildings]" + vbNewLine + _
                        "; Building Format: {str_ID|i_posX|i_posY|bool_isFriend|f_angle|f_damage}" + vbNewLine

        Dim buildingNumber As Integer = 0
        For i As Integer = 0 To MapBuildings.Count() - 1
            If MapBuildings(i).HasData Then
                saveFileData += "Building" + buildingNumber.ToString + " = {" + MapBuildings(i).BuildingId + "|" + (MapBuildings(i).Location.X / TileSizeX).ToString + "|" + (MapBuildings(i).Location.Y / TileSizeY).ToString + "|" + CInt(MapBuildings(i).Team).ToString + "|" + MapBuildings(i).Angle.ToString + "|" + MapBuildings(i).Damage.ToString + "}" + vbNewLine
                buildingNumber += 1
            End If
        Next

        saveFileData += vbNewLine + "[Units]" + vbNewLine + _
                        "; Unit Format: {str_ID|i_posX|i_posY|bool_isFriend|f_angle|f_damage}" + vbNewLine

        Dim unitNumber As Integer = 0
        For i As Integer = 0 To MapUnits.Count() - 1
            If MapUnits(i).HasData Then
                saveFileData += "Unit" + unitNumber.ToString + " = {" + MapUnits(i).UnitId + "|" + MapUnits(i).X.ToString + "|" + MapUnits(i).Y.ToString + "|" + CInt(MapUnits(i).Team).ToString + "|" + MapUnits(i).Angle.ToString + "|" + MapUnits(i).Damage.ToString + "}" + vbNewLine
                unitNumber += 1
            End If
        Next

        Return saveFileData
    End Function

    Public Sub LoadMapv0(ByVal source As IniConfigSource)
        Dim config As IniConfig

        config = source.Configs.Item("Map Size")
        SetSize(config.GetInt("W"), config.GetInt("H"))

        MapTitle = "Converted Map"

        config = source.Configs.Item("Tile Data")
        For i As Integer = 0 To MapTiles.Length - 1
            Dim tempName As String = "Tile_1_" + (i + 1).ToString
            Dim tempArray As String() = config.Get(tempName).Trim("()".ToCharArray).Split(New Char() {Char.Parse(":")}, StringSplitOptions.None)
            Dim tempTileId As Integer = Integer.Parse(tempArray(0))

            'There is no need of getting the 'Team' info since it should have always been set as 'Neutral' and it's useless now.

            ' Upgrade old terrain Ids
            UpgradeTerrainId(0, MapFormat, tempTileId)

            MapTiles(i).TileId = tempTileId

            For j As Integer = 0 To FRMEditor.SelTiles.Length - 1
                If MapTiles(i).TileId = FRMEditor.SelTiles(j).TileId Then
                    MapTiles(i).Image = FRMEditor.SelTiles(j).Image
                    Exit For
                End If
            Next
        Next
    End Sub

    Public Sub LoadMapv1(ByVal source As IniConfigSource)
        Dim config As IniConfig

        config = source.Configs.Item("Level")
        MapTitle = config.GetString("Title")
        SetSize(config.GetInt("W"), config.GetInt("H"))
        Level.Team = CType(config.GetInt("Team"), Team)

        config = source.Configs.Item("Terrain")
        Dim terrainCount As Integer = config.GetKeys().Length - 1
        If terrainCount > 0 Then
            For i As Integer = 0 To terrainCount
                If config.GetKeys(i) <> "-1" Then
                    Dim keyArray As String() = config.Get(config.GetKeys(i)).Trim("{}".ToCharArray).Split(New Char() {Char.Parse("|")}, StringSplitOptions.None)
                    Dim terrainId As Integer = Integer.Parse(keyArray(0))
                    Dim posX As Integer = keyArray(1)
                    Dim posY As Integer = keyArray(2)

                    ' Upgrade old terrain Ids
                    UpgradeTerrainId(1, MapFormat, terrainId)

                    MapTiles(i).TileId = terrainId
                    MapTiles(i).Position = New Point(posX * TileSizeX, posY * TileSizeY)
                    For j As Integer = 0 To FRMEditor.SelTiles.Length - 1
                        If MapTiles(i).TileId = FRMEditor.SelTiles(j).TileId Then
                            MapTiles(i).Image = FRMEditor.SelTiles(j).Image
                            Exit For
                        End If
                    Next
                End If
            Next
        End If

        config = source.Configs.Item("Objects")
        Dim objectCount As Integer = config.GetKeys().Length - 1
        If objectCount > 0 Then
            For i As Integer = 0 To objectCount
                If config.GetKeys(i) <> "-1" Then
                    Dim keyArray As String() = config.Get(config.GetKeys(i)).Trim("{}".ToCharArray).Split(New Char() {Char.Parse("|")}, StringSplitOptions.None)
                    Dim buildingId As String = keyArray(0)
                    Dim posX As Integer = keyArray(1)
                    Dim posY As Integer = keyArray(2)
                    Dim isFriend As Boolean = keyArray(3)
                    Dim team As Team = team.Astros
                    If isFriend Then
                        team = team.Aliens
                    End If
                    Dim angle As Single = keyArray(4)
                    Dim damage As Single = keyArray(5)

                    MapBuildings.Add(New Building(posX * TileSizeX, posY * TileSizeY))

                    ' Upgrade old building Ids
                    UpgradeBuildingId(1, MapFormat, buildingId)

                    MapBuildings(i).BuildingId = buildingId

                    MapBuildings(i).Team = team
                    MapBuildings(i).Angle = angle
                    MapBuildings(i).Damage = damage
                    For j As Integer = 0 To FRMEditor.SelBuildings.Length - 1
                        If MapBuildings(i).BuildingId = FRMEditor.SelBuildings(j).BuildingId Then
                            MapBuildings(i).Image = FRMEditor.SelBuildings(j).Image
                            MapBuildings(i).FullImage = FRMEditor.SelBuildings(j).FullImage
                            'Note to self:
                            'I wasted half a day trying to figure out what was going wrong,
                            'only to discover I forgot these 2 extremely obvious missing lines:
                            MapBuildings(i).BuildingW = FRMEditor.SelBuildings(j).BuildingW
                            MapBuildings(i).BuildingH = FRMEditor.SelBuildings(j).BuildingH
                            Exit For
                        End If
                    Next

                    UpgradeBuildingLocation(1, MapFormat, i, posX * TileSizeX)
                End If
            Next
        End If
    End Sub

    Public Sub LoadMap(ByVal source As IniConfigSource, ByVal v As Integer)
        Dim config As IniConfig

        config = source.Configs.Item("Level")
        MapTitle = config.GetString("Title")
        SetSize(config.GetInt("W"), config.GetInt("H"))
        Level.Team = CType(config.GetInt("Team"), Team)
        Level.CashPlayer = config.GetInt("CashPlayer", Level.CashPlayerDefault)
        Level.CashEnemy = config.GetInt("CashEnemy", Level.CashEnemyDefault)
        Level.IsTraining = config.GetBoolean("isTraining", Level.IsTrainingDefault)
        Level.IsConflict = config.GetBoolean("isConflict", Level.IsConflictDefault)
        Level.IsSpecialLevel = config.GetBoolean("isSpecialLevel", Level.IsSpecialLevelDefault)
        Level.IsLastSpecialLevel = config.GetBoolean("isLastSpecialLevel", Level.IsLastSpecialLevelDefault)
        Level.IsBonusLevel = config.GetBoolean("isBonusLevel", Level.IsBonusLevelDefault)
        IsMapFinal = config.GetBoolean("Final", False)

        config = source.Configs.Item("Terrain")
        For i As Integer = 0 To config.GetKeys().Length - 1
            If config.GetKeys(i) <> "-1" Then
                Dim keyArray As String() = config.Get(config.GetKeys(i)).Trim("{}".ToCharArray).Split(New Char() {Char.Parse("|")}, StringSplitOptions.None)
                Dim terrainId As Integer = Integer.Parse(keyArray(0))
                Dim posX As Integer = keyArray(1)
                Dim posY As Integer = keyArray(2)

                ' Upgrade old terrain Ids
                UpgradeTerrainId(v, MapFormat, terrainId)

                MapTiles(i).TileId = terrainId

                MapTiles(i).Position = New Point(posX * TileSizeX, posY * TileSizeY)
                For j As Integer = 0 To FRMEditor.SelTiles.Length - 1
                    If MapTiles(i).TileId = FRMEditor.SelTiles(j).TileId Then
                        MapTiles(i).Image = FRMEditor.SelTiles(j).Image
                        Exit For
                    End If
                Next
            End If
        Next

        config = source.Configs.Item("Buildings")
        For i As Integer = 0 To config.GetKeys().Length - 1
            If config.GetKeys(i) <> "-1" Then
                Dim keyArray As String() = config.Get(config.GetKeys(i)).Trim("{}".ToCharArray).Split(New Char() {Char.Parse("|")}, StringSplitOptions.None)
                Dim objectId As String = keyArray(0)
                Dim posX As Integer = keyArray(1)
                Dim posY As Integer = keyArray(2)
                Dim isFriend As Boolean = keyArray(3)
                Dim team As Team = team.Astros
                If isFriend Then
                    team = team.Aliens
                End If
                Dim angle As Single = keyArray(4)
                Dim damage As Single = keyArray(5)

                MapBuildings.Add(New Building(posX * TileSizeX, posY * TileSizeY))

                ' Upgrade old building Ids
                UpgradeBuildingId(v, MapFormat, objectId)

                MapBuildings(i).BuildingId = objectId

                MapBuildings(i).Team = team
                MapBuildings(i).Angle = angle
                MapBuildings(i).Damage = damage
                For j As Integer = 0 To FRMEditor.SelBuildings.Length - 1
                    If MapBuildings(i).BuildingId = FRMEditor.SelBuildings(j).BuildingId Then
                        MapBuildings(i).Image = FRMEditor.SelBuildings(j).Image
                        MapBuildings(i).FullImage = FRMEditor.SelBuildings(j).FullImage
                        MapBuildings(i).BuildingW = FRMEditor.SelBuildings(j).BuildingW
                        MapBuildings(i).BuildingH = FRMEditor.SelBuildings(j).BuildingH
                        Exit For
                    End If
                Next

                If v < 4 Then
                    UpgradeBuildingLocation(v, MapFormat, i, posX * TileSizeX)
                End If
            End If
        Next

        config = source.Configs.Item("Units")
        For i As Integer = 0 To config.GetKeys().Length - 1
            If config.GetKeys(i) <> "-1" Then
                Dim keyArray As String() = config.Get(config.GetKeys(i)).Trim("{}".ToCharArray).Split(New Char() {Char.Parse("|")}, StringSplitOptions.None)
                Dim unitId As String = keyArray(0)
                Dim posX As Integer = keyArray(1)
                Dim posY As Integer = keyArray(2)
                Dim isFriend As Boolean = keyArray(3)
                Dim team As Team = team.Astros
                If isFriend Then
                    team = team.Aliens
                End If
                Dim angle As Single = keyArray(4)
                Dim damage As Single = keyArray(5)

                Dim unitX, unitY As Integer
                If v = 2 Then
                    unitX = posX * TileSizeX
                    unitY = posY * TileSizeY

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
                    unitX = posX
                    unitY = posY
                End If

                ' Upgrade old unit Ids
                UpgradeUnitId(v, MapFormat, unitId)

                Dim temp As Unit = New Unit(unitX, unitY, Nothing, unitId, team, angle, damage)
                For j As Integer = 0 To FRMEditor.SelUnits.Length - 1
                    If temp.UnitId = FRMEditor.SelUnits(j).BuildingId Then
                        temp.Image = FRMEditor.SelUnits(j).Image
                        temp.FullImage = FRMEditor.SelUnits(j).FullImage
                        Exit For
                    End If
                Next
                MapUnits.Add(temp)
            End If
        Next
    End Sub
End Class
