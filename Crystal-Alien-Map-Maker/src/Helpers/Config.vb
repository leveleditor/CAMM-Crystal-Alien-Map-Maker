Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Module Config

    Public Function LoadConfig() As Boolean
        AsciiLookup = New List(Of Char)()

        TileDefs = New List(Of TileDef)()
        BuildingDefs = New List(Of BuildingDef)()
        UnitDefs = New List(Of UnitDef)()

        RectangleBrushPresets = New List(Of RectangleBrushPreset)()

        'Make sure the config file actually exists first.
        If Not File.Exists(ConfigFile) Then
            MsgBox("The file '" + ConfigFileName + "' is missing!" + vbNewLine + "Please make sure you have all the required files before running CAMM.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Return False
        End If

        Dim configData As ConfigData

        'Attempt to load the config file.
        Try
            configData = JsonConvert.DeserializeObject(Of ConfigData)(File.ReadAllText(ConfigFile, Encoding.UTF8))
        Catch ex As Exception
            MsgBox("The file '" + ConfigFileName + "' is invalid or outdated and cannot be used!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Return False
        End Try

        'Make sure the config file version matches up with the version for this build of the program.
        If configData.Format < ConfigFormat Then
            MsgBox("The file '" + ConfigFileName + "' is invalid or outdated and cannot be used!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Return False
        ElseIf configData.Format > ConfigFormat Then
            MsgBox("The file '" + ConfigFileName + "' was created for a newer version of CAMM and cannot be used!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Return False
        End If

        'Tile data ascii characters.
        AsciiLookup = configData.TileAscii

        'Tile definitions.
        For Each t As TileDefData In configData.Tiles
            Dim fullImageUrl As String = DataPath + "/" + t.ImageUrl
            Dim theImage As Image = Image.FromFile(fullImageUrl)

            TileImageLookup.Add(t.Id, theImage)

            TileDefs.Add(New TileDef(t.Id, t.IsPassable, t.IsMinerals, t.ImageUrl))
        Next

        'Building definitions.
        For Each b As BuildingDefData In configData.Buildings
            Dim fullImageUrl As String = DataPath + "/" + b.ImageUrl
            Dim fullShadowImageUrl As String = DataPath + "/" + b.ShadowImageUrl

            Dim test As Bitmap = Bitmap.FromFile(fullImageUrl)
            Dim thumbnail As New Bitmap(TileSizeX, TileSizeY)
            Dim bitX, bitY As Integer
            For bitX = 0 To thumbnail.Width - 1
                For bitY = 0 To thumbnail.Height - 1
                    thumbnail.SetPixel(bitX, bitY, test.GetPixel(bitX + ((test.Width / 2) - (TileSizeX / 2)), bitY + ((test.Height / 2) - TileSizeY) + b.OffsetY))
                Next
            Next

            BuildingSmallImageLookup.Add(b.Id, thumbnail)
            BuildingFullImageLookup.Add(b.Id, Image.FromFile(fullImageUrl))
            BuildingShadowImageLookup.Add(b.Id, Image.FromFile(fullShadowImageUrl))

            BuildingDefs.Add(New BuildingDef(b.Id, b.Width, b.Height, CType(b.Team, Team), b.OffsetY, b.ImageUrl, b.ShadowImageUrl))
        Next

        'Unit definitions.
        For Each u As UnitDefData In configData.Units
            Dim fullImageUrl As String = DataPath + "/" + u.ImageUrl
            Dim fullShadowImageUrl As String = DataPath + "/" + u.ShadowImageUrl

            Dim test As Bitmap = Bitmap.FromFile(fullImageUrl)
            Dim w As Integer = TileSizeX
            Dim h As Integer = TileSizeY
            If test.Size.Width < TileSizeX Then
                w = test.Size.Width
            End If
            If test.Size.Height < TileSizeY Then
                h = test.Size.Height
            End If

            Dim thumbnail As New Bitmap(w, h)
            Dim bitX, bitY As Integer
            For bitX = 0 To thumbnail.Width - 1
                For bitY = 0 To thumbnail.Height - 1
                    Dim pixel As Color = Color.Transparent
                    Try
                        pixel = test.GetPixel(bitX + ((test.Width / 2) - (w / 2)), bitY + ((test.Height / 2) - TileSizeY) + u.OffsetY)
                    Catch ex As Exception

                    End Try
                    thumbnail.SetPixel(bitX, bitY, pixel)
                Next
            Next

            UnitSmallImageLookup.Add(u.Id, thumbnail)
            UnitFullImageLookup.Add(u.Id, Image.FromFile(fullImageUrl))
            UnitShadowImageLookup.Add(u.Id, Image.FromFile(fullShadowImageUrl))

            UnitDefs.Add(New UnitDef(u.Id, CType(u.Team, Team), u.Altitude, u.IsPickup, u.OffsetY, u.ImageUrl, u.ShadowImageUrl))
        Next

        'Rectangle brush preset definitions.
        If My.Computer.FileSystem.DirectoryExists(RectangleBrushPath) Then
            Dim files As FileInfo() = New DirectoryInfo(RectangleBrushPath).GetFiles("*.json", SearchOption.AllDirectories)
            For Each fileInfo As FileInfo In files
                Dim data As JToken = JsonConvert.DeserializeObject(File.ReadAllText(fileInfo.FullName))

                Dim title As String = data("Title").ToObject(Of String)
                Dim rows As Integer()() = data("Rows").ToObject(Of Integer()())

                RectangleBrushPresets.Add(New RectangleBrushPreset(fileInfo.Name, title, rows))
            Next
        End If

        Return True
    End Function

    'Tile data ASCII lookup.
    Public AsciiLookup As List(Of Char)

    'Tile definitions.
    Public TileDefs As List(Of TileDef)

    'Building definitions.
    Public BuildingDefs As List(Of BuildingDef)

    'Unit definitions.
    Public UnitDefs As List(Of UnitDef)

    'Rectangle brush preset definitions.
    Public RectangleBrushPresets As List(Of RectangleBrushPreset)

End Module
