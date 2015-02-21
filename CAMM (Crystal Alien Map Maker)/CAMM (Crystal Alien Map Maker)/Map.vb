Public Class Map

    Public Sub New()
        MapSizeX = 10
        MapSizeY = 10
        MapTitle = ""
        IsMapFinal = False

        MapTiles = New Tile() {}
        TempTiles = New Tile() {}
        InitTiles()
        MapBuildings = New List(Of Building)
        MapUnits = New List(Of Unit)
    End Sub

    Public MapSizeX As Integer
    Public MapSizeY As Integer
    Public MapTitle As String
    Public IsMapFinal As Boolean

    Dim MapTiles As Tile()
    Dim MapBuildings As List(Of Building)
    Dim MapUnits As List(Of Unit)
    'Temporary array for resizing the map.
    Private TempTiles As Tile()

    Public Sub SetSize(ByVal width As Integer, ByVal height As Integer)
        If (width <> MapSizeX And height <> MapSizeY) Then
            ReDim TempTiles(MapSizeX * MapSizeY)
            TempTiles = MapTiles

            MapSizeX = width
            MapSizeY = height
            'TXTWidth.Text = MapSizeX
            'TXTHeight.Text = MapSizeY
            'PICMap.Size = New Size((MapSizeX * TileSizeX) + 1, (MapSizeY * TileSizeY) + 1)

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
                If pos.X < 0 Or pos.Y < 0 Or pos.X > (MapSizeX * TileSizeX) - 1 Or pos.Y > (MapSizeY * TileSizeY) - 1 Then
                    tempUnits.Remove(MapUnits(i))
                End If
            Next
            MapUnits = tempUnits

            'PICMap.Invalidate()
        End If
    End Sub

    Public Sub ClearMap()
        For i As Integer = 0 To MapTiles.Length - 1
            MapTiles(i) = New Tile(0, 0)
        Next
        MapBuildings.Clear()
        MapUnits.Clear()
    End Sub

    Public Sub InitMap()
        'Clean the map.
        ClearMap()

        InitTiles()
    End Sub

    Public Sub InitTiles()
        Dim tilesCounted As Integer = 0
        For y As Integer = 0 To (MapSizeY - 1) * TileSizeY Step TileSizeY
            For x As Integer = 0 To (MapSizeX - 1) * TileSizeX Step TileSizeX
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
                    MapTiles(i) = tile
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

                    building.Location = New Point(mouseX, mouseY)
                    MapBuildings(i) = building

                    Exit For
                End If
            Next
            If Not found Then
                building.Location = New Point(mouseX, mouseY)
                MapBuildings.Add(building)
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
                unit.Position = New Point(mouseX, mouseY)
                MapUnits.Add(unit)

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
        ElseIf mouseX > (MapSizeX * TileSizeX) - 1 Then
            Return False
        ElseIf mouseY > (MapSizeY * TileSizeY) - 1 Then
            Return False
            'ElseIf IsMouseOnMap = False Then
            '    Return False
        Else
            Return True
        End If
    End Function

End Class
