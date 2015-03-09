Imports System.IO
Imports Nini.Config

Public Module Utils
    ''' <summary>
    ''' Rounds the specified coordinates to the nearest grid location.
    ''' </summary>
    ''' <param name="x">The x coordinate to round</param>
    ''' <param name="y">The y coordinate to round</param>
    ''' <remarks>Useful for getting the grid location of the cursor</remarks>
    Public Sub PointToGrid(ByRef x As Integer, ByRef y As Integer)
        Dim ix As Integer = (x - TileSizeX / 2) / TileSizeX
        Dim iy As Integer = (y - TileSizeY / 2) / TileSizeY
        x = ix * TileSizeX
        y = iy * TileSizeY
    End Sub

    ''' <summary>
    ''' Rounds the specified coordinates to the nearest grid location.
    ''' </summary>
    ''' <param name="point">The point containing the x and y coordinates to round</param>
    ''' <remarks>Useful for getting the grid location of the cursor</remarks>
    Public Sub PointToGrid(ByRef point As Point)
        PointToGrid(point.X, point.Y)
    End Sub

    Public Sub UpgradeBuildingId(ByVal fromVersion As Integer, ByVal toVersion As Integer, ByRef objectId As String)
        If fromVersion < 4 And (toVersion = 4 Or toVersion = 5) Then
            ' The easy way to map old building Ids to new ones.
            Dim upgradeFile As String = My.Application.Info.DirectoryPath + DataPath + "/UpgradeBuildings.dat"
            Dim upgradeHeader As String = "Buildings data v3 -> v4"
            Dim upgradeData As String = My.Computer.FileSystem.ReadAllText(upgradeFile)

            If upgradeData.Contains(upgradeHeader) Then
                Dim reader As StringReader = New StringReader(upgradeData)
                Dim source As New IniConfigSource(reader)
                Dim config As IConfig = source.Configs.Item(upgradeHeader)
                Dim newId As String = config.GetString(objectId, "")

                reader.Close()

                If Not String.IsNullOrEmpty(newId) Then
                    objectId = newId
                End If
            End If
        End If
    End Sub

    Public Sub UpgradeUnitId(ByVal fromVersion As Integer, ByVal toVersion As Integer, ByRef unitId As String)
        If fromVersion < 4 And (toVersion = 4 Or toVersion = 5) Then
            ' The easy way to map old unit Ids to new ones.
            Dim upgradeFile As String = My.Application.Info.DirectoryPath + DataPath + "/UpgradeUnits.dat"
            Dim upgradeHeader As String = "Units data v3 -> v4"
            Dim upgradeData As String = My.Computer.FileSystem.ReadAllText(upgradeFile)

            If upgradeData.Contains(upgradeHeader) Then
                Dim reader As StringReader = New StringReader(upgradeData)
                Dim source As New IniConfigSource(reader)
                Dim config As IConfig = source.Configs.Item(upgradeHeader)
                Dim newId As String = config.GetString(unitId, "")

                reader.Close()

                If Not String.IsNullOrEmpty(newId) Then
                    unitId = newId
                End If
            End If
        End If
    End Sub

    Public Sub UpgradeTerrainId(ByVal fromVersion As Integer, ByVal toVersion As Integer, ByRef terrainId As Integer)
        If fromVersion < 5 And toVersion = 5 Then
            ' The easy way to map old terrain Ids to new ones.
            Dim upgradeFile As String = My.Application.Info.DirectoryPath + DataPath + "/UpgradeTerrain.dat"
            Dim upgradeHeader As String = "Terrain data v4 -> v5"
            Dim upgradeData As String = My.Computer.FileSystem.ReadAllText(upgradeFile)

            If upgradeData.Contains(upgradeHeader) Then
                Dim reader As StringReader = New StringReader(upgradeData)
                Dim source As New IniConfigSource(reader)
                Dim config As IConfig = source.Configs.Item(upgradeHeader)
                Dim newId As String = config.GetString(terrainId.ToString, "")

                reader.Close()

                If Not String.IsNullOrEmpty(newId) Then
                    terrainId = Integer.Parse(newId)
                End If
            End If
        End If
    End Sub

    Public Sub UpgradeBuildingLocation(ByVal fromVersion As Integer, ByVal toVersion As Integer, ByVal buildingW As Integer, ByVal buildingH As Integer, ByVal fullImageWidth As Integer, ByVal fullImageHeight As Integer, ByRef buildingLocation As Point)
        If fromVersion < 4 And (toVersion = 4 Or toVersion = 5) Then
            ' <<< Start old SetDrawPos code >>>
            Dim tempDrawPos As Point = buildingLocation

            If buildingW Mod 2 Then
                tempDrawPos = New Point(tempDrawPos.X + (TileSizeX / 2), tempDrawPos.Y)
            End If
            If buildingH <> 2 Then
                tempDrawPos = New Point(tempDrawPos.X, tempDrawPos.Y - TileSizeY)
            End If

            Dim topLeftX As Single = Math.Floor((buildingLocation.X / TileSizeX) - buildingW / 2) + 1
            Dim topLeftY As Single = Math.Floor((buildingLocation.X / TileSizeX) - buildingH + 3)
            Dim dockX As Single = (topLeftX + ((buildingW / 2) - 1)) + 1 * TileSizeX
            Dim dockY As Single = (topLeftY + (buildingH - 1)) + 1 * TileSizeX
            dockX = Math.Ceiling(dockX / TileSizeX) - 2
            dockY = Math.Ceiling(dockY / TileSizeY) - 3

            tempDrawPos = New Point(tempDrawPos.X - dockX, tempDrawPos.Y - dockY)

            If buildingH = 2 Then
                tempDrawPos = New Point(tempDrawPos.X, tempDrawPos.Y - TileSizeY)
            End If

            ' There was also some related code in RenderMapToGraphics
            tempDrawPos = New Point( _
                tempDrawPos.X - CInt(fullImageWidth / 2), _
                tempDrawPos.Y - CInt(fullImageHeight / 2) + TileSizeY)

            ' <<< End old SetDrawPos code >>>

            ' New SetDrawPos code, but reversed!
            ' Warning: Buildings that were actually out of bounds in old maps may end up off screen.

            Dim fixedLocation As Point = New Point(tempDrawPos.X + 1, tempDrawPos.Y + 1)

            fixedLocation.X += (fullImageWidth - (buildingW * TileSizeX)) / 2
            fixedLocation.Y += (fullImageHeight - (buildingH * TileSizeY)) / 2

            PointToGrid(fixedLocation)
            buildingLocation = fixedLocation
        End If
    End Sub
End Module
