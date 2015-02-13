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

    Public Sub UpgradeTerrainId(ByVal fromVersion As Integer, ByVal toVersion As Integer, ByRef terrainId As String)
        If fromVersion < 5 And toVersion = 5 Then
            ' The easy way to map old terrain Ids to new ones.
            Dim upgradeFile As String = My.Application.Info.DirectoryPath + DataPath + "/UpgradeTerrain.dat"
            Dim upgradeHeader As String = "Terrain data v4 -> v5"
            Dim upgradeData As String = My.Computer.FileSystem.ReadAllText(upgradeFile)

            If upgradeData.Contains(upgradeHeader) Then
                Dim reader As StringReader = New StringReader(upgradeData)
                Dim source As New IniConfigSource(reader)
                Dim config As IConfig = source.Configs.Item(upgradeHeader)
                Dim newId As String = config.GetString(terrainId, "")

                reader.Close()

                If Not String.IsNullOrEmpty(newId) Then
                    terrainId = newId
                End If
            End If
        End If
    End Sub
End Module
