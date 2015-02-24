Public Class Map

    Public Sub New()
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

    Public SizeX As Integer
    Public SizeY As Integer

    Public FileName As String
    Public MapTitle As String
    Public IsMapFinal As Boolean

    Public MapTiles As Tile()
    Public MapBuildings As List(Of Building)
    Public MapUnits As List(Of Unit)
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
End Class
