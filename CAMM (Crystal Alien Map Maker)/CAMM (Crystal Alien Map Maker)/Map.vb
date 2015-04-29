Imports Nini.Config

Public Class Map

    Public Sub New()
        mapIdPool += 1
        MapId = mapIdPool

        _sizeX = 10
        _sizeY = 10
        _fileName = ""
        _filePath = ""
        MapTitle = "New Map " + MapId.ToString()
        IsMapFinal = False

        mapTiles = New Tile() {}
        tempTiles = New Tile() {}
        InitTiles()
        mapBuildings = New List(Of Building)
        mapUnits = New List(Of Unit)

        Faction = Team.Astros
        CashPlayer = CashPlayerDefault
        CashEnemy = CashEnemyDefault

        IsTraining = IsTrainingDefault
        IsConflict = IsConflictDefault
        IsSpecialLevel = IsSpecialLevelDefault
        IsLastSpecialLevel = IsLastSpecialLevelDefault
        IsBonusLevel = IsBonusLevelDefault
    End Sub

    Private Shared mapIdPool As Integer
    Public ReadOnly MapId As Integer

    Private _sizeX As Integer
    Public ReadOnly Property SizeX As Integer
        Get
            Return _sizeX
        End Get
    End Property

    Private _sizeY As Integer
    Public ReadOnly Property SizeY As Integer
        Get
            Return _sizeY
        End Get
    End Property

    Private _fileName As String
    Public ReadOnly Property FileName As String
        Get
            Return _fileName
        End Get
    End Property

    Private _filePath As String
    Public Property FilePath As String
        Get
            Return _filePath
        End Get
        Set(value As String)
            _filePath = value
            If Not String.IsNullOrEmpty(_filePath) Then
                _fileName = My.Computer.FileSystem.GetFileInfo(_filePath).Name
            Else
                _fileName = ""
            End If
        End Set
    End Property

    Public MapTitle As String
    Public IsMapFinal As Boolean

    Private mapTiles As Tile()
    Private mapBuildings As List(Of Building)
    Private mapUnits As List(Of Unit)
    'Temporary array for resizing the map.
    Private tempTiles As Tile()

    Public Faction As Team
    Public CashPlayer As Integer
    Public CashEnemy As Integer

    Public IsTraining As Boolean
    Public IsConflict As Boolean
    Public IsSpecialLevel As Boolean
    Public IsLastSpecialLevel As Boolean
    Public IsBonusLevel As Boolean

    Public Sub SetSize(width As Integer, height As Integer)
        ' TODO: The map shouldn't resize if it's already at the specified size, but due to a tempfix for bug "unplacable grid spaces after loading a map" it has to be able to set the map to it's own size...
        'If (width <> MapSizeX And height <> MapSizeY) Then
        ReDim tempTiles(SizeX * SizeY)
        tempTiles = mapTiles

        _sizeX = width
        _sizeY = height

        InitTiles()

        For i As Integer = 0 To mapTiles.Length - 1
            For j As Integer = 0 To tempTiles.Length - 1
                If mapTiles(i).Position = tempTiles(j).Position Then
                    mapTiles(i) = tempTiles(j)
                    Exit For
                End If
            Next
        Next
        Dim tempUnits As List(Of Unit) = mapUnits.ToList()
        For i As Integer = 0 To mapUnits.Count() - 1
            Dim pos As Point = mapUnits(i).Position
            If pos.X < 0 Or pos.Y < 0 Or pos.X > (SizeX * TileSizeX) - 1 Or pos.Y > (SizeY * TileSizeY) - 1 Then
                tempUnits.Remove(mapUnits(i))
            End If
        Next
        mapUnits = tempUnits
        'End If
    End Sub

    Public Sub ClearMap()
        For i As Integer = 0 To mapTiles.Length - 1
            mapTiles(i) = New Tile(0, 0)
        Next
        mapBuildings.Clear()
        mapUnits.Clear()
    End Sub

    Private Sub InitTiles()
        Dim tilesCounted As Integer = 0
        For y As Integer = 0 To (SizeY - 1) * TileSizeY Step TileSizeY
            For x As Integer = 0 To (SizeX - 1) * TileSizeX Step TileSizeX
                ReDim Preserve mapTiles(tilesCounted)
                mapTiles(tilesCounted) = New Tile(x, y)
                tilesCounted += 1
            Next x
        Next y
    End Sub

    Public Function GetTileAt(mouseX As Integer, mouseY As Integer) As Tile
        Dim returnTile As Tile = Nothing
        For i As Integer = 0 To mapTiles.Length - 1
            If mapTiles(i).Position = New Point(mouseX, mouseY) Then
                returnTile = mapTiles(i)
                Exit For
            End If
        Next
        Return returnTile
    End Function
    Public Function GetBuildingAt(mouseX As Integer, mouseY As Integer) As Building
        Dim returnBuilding As Building = Nothing
        For i As Integer = 0 To mapBuildings.Count() - 1
            If mapBuildings(i).Location = New Point(mouseX, mouseY) And mapBuildings(i).BuildingId <> "" Then
                returnBuilding = mapBuildings(i)
                Exit For
            End If
        Next
        Return returnBuilding
    End Function

    Public Sub SetTile(mouseX As Integer, mouseY As Integer, tile As Tile)
        If IsMouseInBounds(mouseX, mouseY) Then
            For i As Integer = 0 To mapTiles.Length - 1
                If mapTiles(i).Position.X = mouseX And mapTiles(i).Position.Y = mouseY Then
                    mapTiles(i) = New Tile(mouseX, mouseY, tile.TileId, tile.IsPassable, tile.IsMinerals)
                End If
            Next
        End If
    End Sub

    Public Sub SetTileSmart(mouseX As Integer, mouseY As Integer)
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

    Public Sub SetBuilding(mouseX As Integer, mouseY As Integer, building As Building)
        If IsMouseInBounds(mouseX, mouseY) Then
            Dim found As Boolean = False
            For i As Integer = 0 To mapBuildings.Count() - 1
                If mapBuildings(i).Location.X = mouseX And mapBuildings(i).Location.Y = mouseY Then
                    found = True

                    mapBuildings(i) = New Building(mouseX, mouseY, building.BuildingId, building.Team, building.BuildingW, building.BuildingH, building.Angle, building.Damage)

                    Exit For
                End If
            Next
            If Not found Then
                Dim newBuilding As Building = New Building(mouseX, mouseY, building.BuildingId, building.Team, building.BuildingW, building.BuildingH, building.Angle, building.Damage)
                mapBuildings.Add(newBuilding)
            End If

            ' Reorder the list based on the Y locations of the buidings.
            ' This ensures that buildings closer to the top of the map render
            ' beneath buildings closer to the bottom of the map.
            mapBuildings = (From b In mapBuildings Order By b.Location.Y, b.Location.X).ToList()
        End If
    End Sub

    Public Sub SetUnit(mouseX As Integer, mouseY As Integer, unit As Unit)
        If IsMouseInBounds(mouseX, mouseY) Then
            Dim found As Boolean = False
            For i As Integer = 0 To mapUnits.Count() - 1
                ' This should help prevent spam and accidental double clicks.
                If mapUnits(i).Position.X = mouseX And mapUnits(i).Position.Y = mouseY And mapUnits(i).UnitId = unit.UnitId Then
                    found = True
                    Exit For
                End If
            Next
            If Not found Then
                Dim newUnit As Unit = New Unit(mouseX, mouseY, unit.UnitId, unit.Team, unit.Altitude, unit.Angle, unit.Damage)
                mapUnits.Add(newUnit)

                ' Reorder the list based on the Y locations of the units.
                ' This ensures that units closer to the top of the map render
                ' beneath units closer to the bottom of the map.
                mapUnits = (From u In mapUnits Order By u.Position.Y, u.Position.X).ToList()
            End If
        End If
    End Sub

    Public Function IsMouseInBounds(mouseX As Integer, mouseY As Integer)
        If mouseX < 0 Then
            Return False
        ElseIf mouseY < 0 Then
            Return False
        ElseIf mouseX > (SizeX * TileSizeX) - 1 Then
            Return False
        ElseIf mouseY > (SizeY * TileSizeY) - 1 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub Eraser(mouseX As Integer, mouseY As Integer, mode As EditMode)
        Select Case mode
            Case EditMode.Tiles
                SetTile(mouseX, mouseY, New Tile(mouseX, mouseY))
            Case EditMode.Buildings
                Dim temp As List(Of Building) = mapBuildings.ToList()
                For i As Integer = 0 To mapBuildings.Count() - 1
                    If mapBuildings(i).Location = New Point(mouseX, mouseY) Then
                        temp.Remove(mapBuildings(i))
                    End If
                Next
                mapBuildings = temp
            Case EditMode.Units
                Dim temp As List(Of Unit) = mapUnits.ToList()
                For i As Integer = 0 To mapUnits.Count() - 1
                    If mapUnits(i).X >= mouseX And _
                       mapUnits(i).Y >= mouseY And _
                       mapUnits(i).X <= mouseX + TileSizeX And _
                       mapUnits(i).Y <= mouseY + TileSizeY Then
                        temp.Remove(mapUnits(i))
                    End If
                Next
                mapUnits = temp
        End Select
    End Sub

    Public Sub Draw(ByRef g As Graphics, drawGrid As Boolean, drawShadows As Boolean, Optional ByVal debugBuildingPos As Boolean = False)
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
        For i As Integer = 0 To mapTiles.Length - 1
            If mapTiles(i).HasData Then
                g.DrawImage(mapTiles(i).Image, mapTiles(i).Position)
            End If
        Next

        ' Draw building baseplates.
        For i As Integer = 0 To mapBuildings.Count() - 1
            If mapBuildings(i).HasData Then
                Dim teamBaseplate As Image = Nothing
                If mapBuildings(i).Team = Team.Astros And mapBuildings(i).BuildingW = 1 Then
                    teamBaseplate = BaseplateAstroSmall
                ElseIf mapBuildings(i).Team = Team.Aliens And mapBuildings(i).BuildingW = 1 Then
                    teamBaseplate = BaseplateAlienSmall
                ElseIf mapBuildings(i).Team = Team.Astros Then
                    teamBaseplate = BaseplateAstroWide
                ElseIf mapBuildings(i).Team = Team.Aliens Then
                    teamBaseplate = BaseplateAlienWide
                End If
                If teamBaseplate IsNot Nothing Then
                    Dim location As Point = mapBuildings(i).Location
                    If mapBuildings(i).BuildingW > 1 Then
                        location.X += (mapBuildings(i).BuildingW * TileSizeX) / 2
                        location.X -= TileSizeX
                    Else
                        location.X -= TileSizeX / 2
                    End If
                    If mapBuildings(i).BuildingH > 1 Then
                        location.Y += (mapBuildings(i).BuildingH * TileSizeY) - TileSizeY
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

        If drawShadows Then
            ' Draw any existing building shadows.
            For i As Integer = 0 To mapBuildings.Count() - 1
                If mapBuildings(i).HasData Then

                    g.DrawImage(mapBuildings(i).ShadowImage, _
                         mapBuildings(i).DrawPos.X, _
                         mapBuildings(i).DrawPos.Y, _
                         mapBuildings(i).FullImage.Width, _
                         mapBuildings(i).FullImage.Height)
                End If
            Next

            ' Draw any existing unit shadows.
            For i As Integer = 0 To mapUnits.Count() - 1
                If mapUnits(i).HasData Then

                    g.DrawImage(mapUnits(i).ShadowImage, _
                         mapUnits(i).Position.X - CInt(mapUnits(i).ShadowImage.Width / 2), _
                         mapUnits(i).Position.Y - CInt(mapUnits(i).ShadowImage.Height / 2), _
                         mapUnits(i).ShadowImage.Width, _
                         mapUnits(i).ShadowImage.Height)
                End If
            Next
        End If

        ' Draw any existing buildings.
        For i As Integer = 0 To mapBuildings.Count() - 1
            If mapBuildings(i).HasData Then

                g.DrawImage(mapBuildings(i).FullImage, _
                     mapBuildings(i).DrawPos.X, _
                     mapBuildings(i).DrawPos.Y, _
                     mapBuildings(i).FullImage.Width, _
                     mapBuildings(i).FullImage.Height)

                If debugBuildingPos Then
                    g.DrawRectangle(Pens.Lime, mapBuildings(i).Location.X - 1, mapBuildings(i).Location.Y - 1, 2, 2)
                    g.DrawRectangle(Pens.Blue, mapBuildings(i).DrawPos.X - 2, mapBuildings(i).DrawPos.Y - 2, 4, 4)
                End If
            End If
        Next

        ' Draw any existing units.
        For i As Integer = 0 To mapUnits.Count() - 1
            If mapUnits(i).HasData Then

                g.DrawImage(mapUnits(i).FullImage, _
                     mapUnits(i).Position.X - CInt(mapUnits(i).FullImage.Width / 2), _
                     mapUnits(i).Position.Y - CInt(mapUnits(i).FullImage.Height / 2) - mapUnits(i).Altitude, _
                     mapUnits(i).FullImage.Width, _
                     mapUnits(i).FullImage.Height)
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

        saveFileData += _
            "[CAMM]" + vbNewLine + _
            "vFormat = " + MapFormat.ToString + vbNewLine + _
            vbNewLine

        saveFileData += _
            "[Level]" + vbNewLine + _
            "Title = " + MapTitle + vbNewLine + _
            "W = " + SizeX.ToString + vbNewLine + _
            "H = " + SizeY.ToString + vbNewLine + _
            "Team = " + CInt(Faction).ToString + vbNewLine + _
            "CashPlayer = " + CashPlayer.ToString + vbNewLine + _
            "CashEnemy = " + CashEnemy.ToString + vbNewLine + _
            "isTraining = " + IsTraining.ToString + vbNewLine + _
            "isConflict = " + IsConflict.ToString + vbNewLine + _
            "isSpecialLevel = " + IsSpecialLevel.ToString + vbNewLine + _
            "isLastSpecialLevel = " + IsLastSpecialLevel.ToString + vbNewLine + _
            "isBonusLevel = " + IsBonusLevel.ToString + vbNewLine + _
            vbNewLine

        saveFileData += "[Terrain]" + vbNewLine + _
            "; Terrain Format: {str_ID|i_posX|i_posY}" + vbNewLine

        Dim terrainNumber As Integer = 0
        For i As Integer = 0 To mapTiles.Length - 1
            If mapTiles(i).HasData Then
                saveFileData += "Terrain" + terrainNumber.ToString + " = {" + mapTiles(i).TileId.ToString + "|" + (mapTiles(i).X / TileSizeX).ToString + "|" + (mapTiles(i).Y / TileSizeY).ToString + "}" + vbNewLine
                terrainNumber += 1
            End If
        Next

        saveFileData += vbNewLine + "[Buildings]" + vbNewLine + _
                        "; Building Format: {str_ID|i_posX|i_posY|bool_isFriend|f_angle|f_damage}" + vbNewLine

        Dim buildingNumber As Integer = 0
        For i As Integer = 0 To mapBuildings.Count() - 1
            If mapBuildings(i).HasData Then
                saveFileData += "Building" + buildingNumber.ToString + " = {" + mapBuildings(i).BuildingId + "|" + (mapBuildings(i).Location.X / TileSizeX).ToString + "|" + (mapBuildings(i).Location.Y / TileSizeY).ToString + "|" + CInt(mapBuildings(i).Team).ToString + "|" + mapBuildings(i).Angle.ToString + "|" + mapBuildings(i).Damage.ToString + "}" + vbNewLine
                buildingNumber += 1
            End If
        Next

        saveFileData += vbNewLine + "[Units]" + vbNewLine + _
                        "; Unit Format: {str_ID|i_posX|i_posY|bool_isFriend|f_angle|f_damage}" + vbNewLine

        Dim unitNumber As Integer = 0
        For i As Integer = 0 To mapUnits.Count() - 1
            If mapUnits(i).HasData Then
                saveFileData += "Unit" + unitNumber.ToString + " = {" + mapUnits(i).UnitId + "|" + mapUnits(i).X.ToString + "|" + mapUnits(i).Y.ToString + "|" + CInt(mapUnits(i).Team).ToString + "|" + mapUnits(i).Angle.ToString + "|" + mapUnits(i).Damage.ToString + "}" + vbNewLine
                unitNumber += 1
            End If
        Next

        saveFileData += vbNewLine + "; Map Created Using CAMM Crystal Alien Map Maker"

        Return saveFileData
    End Function

    Public Sub LoadMapv0(source As IniConfigSource)
        Dim config As IniConfig

        config = source.Configs.Item("Map Size")
        SetSize(config.GetInt("W"), config.GetInt("H"))

        MapTitle = "Converted Map"

        config = source.Configs.Item("Tile Data")
        For i As Integer = 0 To mapTiles.Length - 1
            Dim tempName As String = "Tile_1_" + (i + 1).ToString
            Dim tempArray As String() = config.Get(tempName).Trim("()".ToCharArray).Split(New Char() {Char.Parse(":")}, StringSplitOptions.None)
            Dim tempTileId As Integer = Integer.Parse(tempArray(0))

            'There is no need of getting the 'Team' info since it should have always been set as 'Neutral' and it's useless now.

            ' Upgrade old terrain Ids
            UpgradeTerrainId(0, MapFormat, tempTileId)

            mapTiles(i).TileId = tempTileId
        Next
    End Sub

    Public Sub LoadMapv1(source As IniConfigSource)
        Dim config As IniConfig

        config = source.Configs.Item("Level")
        MapTitle = config.GetString("Title")
        SetSize(config.GetInt("W"), config.GetInt("H"))
        Faction = CType(config.GetInt("Team"), Team)

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

                    mapTiles(i).TileId = terrainId
                    mapTiles(i).Position = New Point(posX * TileSizeX, posY * TileSizeY)
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

                    Dim building As Building = New Building(posX * TileSizeX, posY * TileSizeY)

                    ' Upgrade old building Ids
                    UpgradeBuildingId(1, MapFormat, buildingId)

                    building.BuildingId = buildingId

                    building.Team = team
                    building.Angle = angle
                    building.Damage = damage
                    For j As Integer = 0 To BuildingDefs.Length - 1
                        If building.BuildingId = BuildingDefs(j).BuildingId Then
                            'Note to self:
                            'I wasted half a day trying to figure out what was going wrong,
                            'only to discover I forgot these 2 extremely obvious missing lines:
                            building.BuildingW = BuildingDefs(j).BuildingW
                            building.BuildingH = BuildingDefs(j).BuildingH
                            Exit For
                        End If
                    Next

                    UpgradeBuildingLocation(1, MapFormat, building.BuildingW, building.BuildingH, building.FullImage.Width, building.FullImage.Height, building.Location)

                    mapBuildings.Add(building)
                End If
            Next
        End If
    End Sub

    Public Sub LoadMap(source As IniConfigSource, v As Integer)
        Dim config As IniConfig

        config = source.Configs.Item("Level")
        MapTitle = config.GetString("Title")
        SetSize(config.GetInt("W"), config.GetInt("H"))
        Faction = CType(config.GetInt("Team"), Team)
        CashPlayer = config.GetInt("CashPlayer", CashPlayerDefault)
        CashEnemy = config.GetInt("CashEnemy", CashEnemyDefault)
        IsTraining = config.GetBoolean("isTraining", IsTrainingDefault)
        IsConflict = config.GetBoolean("isConflict", IsConflictDefault)
        IsSpecialLevel = config.GetBoolean("isSpecialLevel", IsSpecialLevelDefault)
        IsLastSpecialLevel = config.GetBoolean("isLastSpecialLevel", IsLastSpecialLevelDefault)
        IsBonusLevel = config.GetBoolean("isBonusLevel", IsBonusLevelDefault)
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

                mapTiles(i).TileId = terrainId

                mapTiles(i).Position = New Point(posX * TileSizeX, posY * TileSizeY)
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

                Dim building As Building = New Building(posX * TileSizeX, posY * TileSizeY)

                ' Upgrade old building Ids
                UpgradeBuildingId(v, MapFormat, objectId)

                building.BuildingId = objectId

                building.Team = team
                building.Angle = angle
                building.Damage = damage
                For j As Integer = 0 To BuildingDefs.Length - 1
                    If building.BuildingId = BuildingDefs(j).BuildingId Then
                        building.BuildingW = BuildingDefs(j).BuildingW
                        building.BuildingH = BuildingDefs(j).BuildingH
                        Exit For
                    End If
                Next

                If v < 4 Then
                    UpgradeBuildingLocation(v, MapFormat, building.BuildingW, building.BuildingH, building.FullImage.Width, building.FullImage.Height, building.Location)
                End If

                mapBuildings.Add(building)
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

                Dim unitAltitude As Integer = (From u In UnitDefs Where u.UnitId = unitId Select u.Altitude).First()
                Dim temp As Unit = New Unit(unitX, unitY, unitId, team, unitAltitude, angle, damage)
                mapUnits.Add(temp)
            End If
        Next
    End Sub
End Class
