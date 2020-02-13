Imports Newtonsoft.Json

Public Class Map

    Public Sub New()
        mapIdPool += 1
        MapId = mapIdPool

        _sizeX = 10
        _sizeY = 10
        _fileName = ""
        _filePath = ""
        Title = "New Map " + MapId.ToString()
        Author = ""
        IsMapFinal = False
        AccessCode = "custom"

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

        IsModified = False
    End Sub

    Private Shared mapIdPool As Integer
    Public ReadOnly MapId As Integer

    Public Property IsModified As Boolean

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

    Public ClosestUnit As Unit = Nothing 'The closest unit to the cursor position.
    Public SelectedUnit As Unit = Nothing 'The currently selected unit.
    Public ClosestBuilding As Building = Nothing 'The closest building to the cursor position.
    Public SelectedBuilding As Building = Nothing 'The currently selected building.

    Private _Title As String
    Public Property Title As String
        Get
            Return _Title
        End Get
        Set
            _Title = Value
            IsModified = True
        End Set
    End Property

    Private _Author As String
    Public Property Author As String
        Get
            Return _Author
        End Get
        Set
            _Author = Value
            IsModified = True
        End Set
    End Property

    Private _IsMapFinal As Boolean
    Public Property IsMapFinal As Boolean
        Get
            Return _IsMapFinal
        End Get
        Set
            _IsMapFinal = Value
            IsModified = True
        End Set
    End Property

    Private _AccessCode As String
    Public Property AccessCode As String
        Get
            Return _AccessCode
        End Get
        Set
            _AccessCode = Value
            IsModified = True
        End Set
    End Property

    Private mapTiles As Tile(,)
    Private mapBuildings As List(Of Building)
    Private mapUnits As List(Of Unit)

    Private _Faction As Team
    Public Property Faction As Team
        Get
            Return _Faction
        End Get
        Set
            _Faction = Value
            IsModified = True
        End Set
    End Property

    Private _CashPlayer As Integer
    Public Property CashPlayer As Integer
        Get
            Return _CashPlayer
        End Get
        Set
            _CashPlayer = Value
            IsModified = True
        End Set
    End Property

    Private _CashEnemy As Integer
    Public Property CashEnemy As Integer
        Get
            Return _CashEnemy
        End Get
        Set
            _CashEnemy = Value
            IsModified = True
        End Set
    End Property

    Private _IsTraining As Boolean
    Public Property IsTraining As Boolean
        Get
            Return _IsTraining
        End Get
        Set
            _IsTraining = Value
            IsModified = True
        End Set
    End Property

    Private _IsConflict As Boolean
    Public Property IsConflict As Boolean
        Get
            Return _IsConflict
        End Get
        Set
            _IsConflict = Value
            IsModified = True
        End Set
    End Property

    Private _IsSpecialLevel As Boolean
    Public Property IsSpecialLevel As Boolean
        Get
            Return _IsSpecialLevel
        End Get
        Set
            _IsSpecialLevel = Value
            IsModified = True
        End Set
    End Property

    Private _IsLastSpecialLevel As Boolean
    Public Property IsLastSpecialLevel As Boolean
        Get
            Return _IsLastSpecialLevel
        End Get
        Set
            _IsLastSpecialLevel = Value
            IsModified = True
        End Set
    End Property

    Private _IsBonusLevel As Boolean
    Public Property IsBonusLevel As Boolean
        Get
            Return _IsBonusLevel
        End Get
        Set
            _IsBonusLevel = Value
            IsModified = True
        End Set
    End Property

    Public Sub ClearSelection()
        ClearSelectedUnit()
        ClearSelectedBuilding()
    End Sub

    Public Sub ClearSelectedUnit()
        SelectedUnit = Nothing
        ClosestUnit = Nothing
    End Sub

    Public Sub ClearSelectedBuilding()
        SelectedBuilding = Nothing
        ClosestBuilding = Nothing
    End Sub

    Public Sub SetSize(width As Integer, height As Integer)
        If width <> SizeX Or height <> SizeY Then
            Dim tempTiles As Tile(,) = mapTiles

            Dim smallestSizeX As Integer = If(width > SizeX, SizeX, width)
            Dim smallestSizeY As Integer = If(height > SizeY, SizeY, height)

            _sizeX = width
            _sizeY = height

            InitTiles()

            For x As Integer = 0 To smallestSizeX - 1
                For y As Integer = 0 To smallestSizeY - 1
                    mapTiles(x, y) = tempTiles(x, y)
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

            IsModified = True
        End If
    End Sub

    Public Sub Clear()
        For x As Integer = 0 To SizeX - 1
            For y As Integer = 0 To SizeY - 1
                mapTiles(x, y) = New Tile()
            Next
        Next
        mapBuildings.Clear()
        mapUnits.Clear()

        IsModified = True
    End Sub

    Private Sub InitTiles()
        mapTiles = New Tile(SizeX, SizeY) {}
        For x As Integer = 0 To SizeX - 1
            For y As Integer = 0 To SizeY - 1
                mapTiles(x, y) = New Tile()
            Next
        Next
    End Sub

    Public Function GetTileAt(mouseX As Integer, mouseY As Integer) As Tile
        For x As Integer = 0 To SizeX - 1
            For y As Integer = 0 To SizeY - 1
                If x * TileSizeX = mouseX And y * TileSizeY = mouseY Then
                    Return mapTiles(x, y)
                End If
            Next
        Next
        Return Nothing
    End Function
    Public Function GetBuildingAt(mouseX As Integer, mouseY As Integer) As Building
        For i As Integer = 0 To mapBuildings.Count() - 1
            If mapBuildings(i).Location = New Point(mouseX, mouseY) And mapBuildings(i).BuildingId <> "" Then
                Return mapBuildings(i)
            End If
        Next
        Return Nothing
    End Function
    Public Function GetUnitsNear(mouseX As Integer, mouseY As Integer, maxDistance As Integer) As List(Of Unit)
        Dim returnUnits As List(Of Unit) = New List(Of Unit)
        For i As Integer = 0 To mapUnits.Count() - 1
            If GetRadialDistance(mouseX, mouseY, mapUnits(i).X, mapUnits(i).Y - mapUnits(i).Altitude) <= maxDistance Then
                returnUnits.Add(mapUnits(i))
            End If
        Next
        Return returnUnits
    End Function
    Public Function GetClosestUnit(mouseX As Integer, mouseY As Integer, maxDistance As Integer) As Unit
        Dim closeUnits As List(Of Unit) = GetUnitsNear(mouseX, mouseY, maxDistance)
        Dim closestUnit As Unit = Nothing
        If closeUnits.Count > 0 Then
            For i As Integer = 0 To closeUnits.Count - 1
                If i = 0 Then
                    closestUnit = closeUnits(i)
                ElseIf GetRadialDistance(mouseX, mouseY, closeUnits(i).X, closeUnits(i).Y - closeUnits(i).Altitude) < GetRadialDistance(mouseX, mouseY, closestUnit.X, closestUnit.Y - closestUnit.Altitude) Then
                    closestUnit = closeUnits(i)
                End If
            Next
        End If
        Return closestUnit
    End Function

    Public Sub SetTile(mouseX As Integer, mouseY As Integer, tile As Tile)
        If IsMouseInBounds(mouseX, mouseY) Then
            For x As Integer = 0 To SizeX - 1
                For y As Integer = 0 To SizeY - 1
                    If mouseX = x * TileSizeX And mouseY = y * TileSizeY Then
                        mapTiles(x, y) = New Tile(tile.TileId, tile.IsPassable, tile.IsMinerals)
                        IsModified = True
                        Return
                    End If
                Next
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

    Public Sub SetTileRectangle(startX As Integer, startY As Integer, endX As Integer, endY As Integer, rectBrushPreset As RectangleBrushPreset)
        Dim data As Integer()() = rectBrushPreset.Data

        For x As Integer = startX To endX Step TileSizeX
            For y As Integer = startY To endY Step TileSizeY
                Dim tileId As Integer
                If x = startX And y = startY Then
                    'Top Left
                    tileId = data(0)(0)
                ElseIf x = endX And y = startY Then
                    'Top Right
                    tileId = data(0)(2)
                ElseIf x = startX And y = endY Then
                    'Bottom Left
                    tileId = data(2)(0)
                ElseIf x = endX And y = endY Then
                    'Bottom Right
                    tileId = data(2)(2)
                ElseIf x <> startX And x <> endX And y = startY Then
                    'Top Middle
                    tileId = data(0)(1)
                ElseIf x = startX And y <> startY And y <> endY Then
                    'Left Middle
                    tileId = data(1)(0)
                ElseIf x = endX And y <> startY And y <> endY Then
                    'Right Middle
                    tileId = data(1)(2)
                ElseIf x <> startX And x <> endX And y = endY Then
                    'Bottom Middle
                    tileId = data(2)(1)
                Else
                    'Somewhere in the middle
                    tileId = data(1)(1)
                End If
                If tileId <> -1 Then
                    SetTile(x, y, New Tile(tileId))
                End If
            Next
        Next

        IsModified = True
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

            IsModified = True
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
                Dim newUnit As Unit = New Unit(mouseX, mouseY, unit.UnitId, unit.Team, unit.Altitude, unit.IsPickup, unit.Angle, unit.Damage)
                mapUnits.Add(newUnit)

                ' Reorder the list based on the Y locations of the units.
                ' This ensures that units closer to the top of the map render
                ' beneath units closer to the bottom of the map.
                mapUnits = (From u In mapUnits Order By u.Position.Y, u.Position.X).ToList()
            End If

            IsModified = True
        End If
    End Sub

    Public Function IsMouseInBounds(mouseX As Integer, mouseY As Integer) As Boolean
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

    Public Sub EraseTile(mouseX As Integer, mouseY As Integer)
        SetTile(mouseX, mouseY, New Tile())
    End Sub

    Public Sub EraseBuildings(mouseX As Integer, mouseY As Integer)
        Dim temp As List(Of Building) = mapBuildings.ToList()
        For i As Integer = 0 To mapBuildings.Count() - 1
            If mapBuildings(i).Location = New Point(mouseX, mouseY) Then
                temp.Remove(mapBuildings(i))
            End If
        Next
        mapBuildings = temp

        IsModified = True
    End Sub

    Public Sub EraseUnits(mouseX As Integer, mouseY As Integer)
        Dim temp As List(Of Unit) = mapUnits.ToList()
        Dim toRemove As List(Of Unit) = GetUnitsNear(mouseX, mouseY, 30)
        For i As Integer = 0 To toRemove.Count() - 1
            temp.Remove(toRemove(i))
        Next
        mapUnits = temp

        IsModified = True
    End Sub

    Public Function DeleteUnit(unit As Unit) As Boolean
        IsModified = True
        Return mapUnits.Remove(unit)
    End Function
    Public Function DeleteBuilding(building As Building) As Boolean
        IsModified = True
        Return mapBuildings.Remove(building)
    End Function

    Public Sub Draw(g As Graphics, drawGrid As Boolean, drawShadows As Boolean, drawUnitTeamIndicators As Boolean, drawBuildingTeamIndicators As Boolean, Optional ByVal debugBuildingPos As Boolean = False, Optional ByVal debugUnitPos As Boolean = False)
        g.Clear(Color.FromKnownColor(KnownColor.Control))

        ' Draw the background
        Dim bgX As Integer = 0
        Dim bgY As Integer = 0
        Do Until bgX >= SizeX * TileSizeX
            Do Until bgY >= SizeY * TileSizeY
                g.DrawImage(Background, bgX, bgY, Background.Width, Background.Height)
                bgY += Background.Height
            Loop
            bgY = 0
            bgX += Background.Width
        Loop

        ' Draw any existing tiles.
        For x As Integer = 0 To SizeX - 1
            For y As Integer = 0 To SizeY - 1
                If mapTiles(x, y).HasData Then
                    mapTiles(x, y).Draw(g, x * TileSizeX, y * TileSizeY)
                End If
            Next
        Next

        If drawGrid Then
            ' Draw the grid.
            DrawGridLines(g, SizeX * TileSizeX, SizeY * TileSizeY)
        End If

        ' Draw building baseplates.
        For i As Integer = 0 To mapBuildings.Count() - 1
            If mapBuildings(i).HasData Then
                mapBuildings(i).DrawBaseplate(g)
            End If
        Next

        If drawShadows Then
            ' Draw any existing building shadows.
            For i As Integer = 0 To mapBuildings.Count() - 1
                If mapBuildings(i).HasData Then
                    mapBuildings(i).DrawShadow(g)
                End If
            Next

            ' Draw any existing unit shadows.
            For i As Integer = 0 To mapUnits.Count() - 1
                If mapUnits(i).HasData Then
                    mapUnits(i).DrawShadow(g)
                End If
            Next
        End If

        ' Draw any existing buildings.
        For i As Integer = 0 To mapBuildings.Count() - 1
            If mapBuildings(i).HasData Then
                mapBuildings(i).Draw(g)

                If debugBuildingPos Then
                    g.DrawRectangle(Pens.Lime, mapBuildings(i).Location.X - 1, mapBuildings(i).Location.Y - 1, 2, 2)
                    g.DrawRectangle(Pens.Blue, mapBuildings(i).DrawPos.X - 2, mapBuildings(i).DrawPos.Y - 2, 4, 4)
                End If
            End If
        Next

        ' Draw any existing units.
        For i As Integer = 0 To mapUnits.Count() - 1
            If mapUnits(i).HasData Then
                mapUnits(i).Draw(g)

                If debugUnitPos Then
                    g.DrawLine(Pens.LightSkyBlue, mapUnits(i).X, mapUnits(i).Y, mapUnits(i).X, mapUnits(i).Y - mapUnits(i).Altitude)
                    g.DrawRectangle(Pens.Lime, mapUnits(i).X - 1, mapUnits(i).Y - 1, 2, 2)
                    g.DrawRectangle(Pens.Blue, mapUnits(i).X - 2, mapUnits(i).Y - mapUnits(i).Altitude - 2, 4, 4)
                End If
            End If
        Next

        ' Draw team indicator icons.
        If drawUnitTeamIndicators Then
            For i As Integer = 0 To mapUnits.Count() - 1
                If mapUnits(i).HasData Then
                    mapUnits(i).DrawTeamIndicator(g)
                End If
            Next
        End If
        If drawBuildingTeamIndicators Then
            For i As Integer = 0 To mapBuildings.Count() - 1
                If mapBuildings(i).HasData Then
                    mapBuildings(i).DrawTeamIndicator(g)
                End If
            Next
        End If
    End Sub

    Public Function GetSaveData() As String
        Dim tileData As New List(Of Integer)
        For y As Integer = 0 To SizeY - 1
            For x As Integer = 0 To SizeX - 1
                If mapTiles(x, y).HasData Then
                    tileData.Add(mapTiles(x, y).TileId)
                Else
                    tileData.Add(-1)
                End If
            Next
        Next

        Dim buildingData As New List(Of BuildingData)(From b As Building In mapBuildings Where b.HasData Select New BuildingData() With
        {
            .Id = b.BuildingId,
            .X = (b.Location.X / TileSizeX),
            .Y = (b.Location.Y / TileSizeY),
            .Team = CInt(b.Team),
            .Angle = b.Angle,
            .Damage = b.Damage
        })

        Dim unitData As New List(Of UnitData)(From u As Unit In mapUnits Where u.HasData Select New UnitData() With
        {
            .Id = u.UnitId,
            .X = u.X,
            .Y = u.Y,
            .Team = CInt(u.Team),
            .Angle = u.Angle,
            .Damage = u.Damage,
            .AiTarget = u.AiTarget,
            .AiObj = u.AiObj,
            .Respawn = u.Respawn
        })

        Dim mapData As New MapData() With {
            .Format = MapFormat,
            .Title = Title,
            .Author = Author,
            .Width = SizeX,
            .Height = SizeY,
            .Team = CInt(Faction),
            .CashPlayer = CashPlayer,
            .CashEnemy = CashEnemy,
            .IsTraining = IsTraining,
            .IsConflict = IsConflict,
            .IsSpecialLevel = IsSpecialLevel,
            .IsLastSpecialLevel = IsLastSpecialLevel,
            .IsBonusLevel = IsBonusLevel,
            .IsFinal = IsMapFinal,
            .AccessCode = AccessCode,
            .Tiles = tileData,
            .Buildings = buildingData,
            .Units = unitData
        }

        Return JsonConvert.SerializeObject(mapData, Formatting.Indented)
    End Function

    Public Sub LoadMap(mapData As MapData)
        Title = mapData.Title
        Author = mapData.Author
        SetSize(mapData.Width, mapData.Height)
        Faction = mapData.Team
        CashPlayer = mapData.CashPlayer
        CashEnemy = mapData.CashEnemy
        IsTraining = mapData.IsTraining
        IsConflict = mapData.IsConflict
        IsSpecialLevel = mapData.IsSpecialLevel
        IsLastSpecialLevel = mapData.IsLastSpecialLevel
        IsBonusLevel = mapData.IsBonusLevel
        IsMapFinal = mapData.IsFinal
        AccessCode = If(mapData.AccessCode, AccessCode)

        Dim i As Integer = 0
        For y As Integer = 0 To mapData.Height - 1
            For x As Integer = 0 To mapData.Width - 1
                mapTiles(x, y) = New Tile(mapData.Tiles(i))
                i += 1
            Next
        Next

        For Each unit As UnitData In mapData.Units
            'TODO: There should be a better place to do this lookup than right here.
            Dim unitAltitude As Integer = (From u In UnitDefs Where u.UnitId = unit.Id Select u.Altitude).First()
            Dim unitIsPickup As Boolean = (From u In UnitDefs Where u.UnitId = unit.Id Select u.IsPickup).First()

            mapUnits.Add(New Unit(unit.X, unit.Y, unit.Id, unit.Team, unitAltitude, unitIsPickup, unit.Angle, unit.Damage, unit.AiTarget, unit.AiObj, unit.Respawn))
        Next

        For Each building As BuildingData In mapData.Buildings
            'TODO: There should be a better place to do this lookup than right here.
            Dim w As Integer = (From b In BuildingDefs Where b.BuildingId = building.Id Select b.BuildingW).First()
            Dim h As Integer = (From b In BuildingDefs Where b.BuildingId = building.Id Select b.BuildingH).First()

            mapBuildings.Add(New Building(building.X * TileSizeX, building.Y * TileSizeY, building.Id, building.Team, w, h, building.Angle, building.Damage))
        Next

        IsModified = False
    End Sub

End Class
