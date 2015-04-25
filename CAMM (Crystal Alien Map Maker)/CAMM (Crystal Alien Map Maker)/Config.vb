Imports Nini.Config

Public Module Config

    Public Sub LoadConfig(source As IniConfigSource)
        AsciiLookup = New List(Of Char)()

        TileDefs = New Tile() {}
        BuildingDefs = New Building() {}
        UnitDefs = New Unit() {}

        Dim config As IConfig

        config = source.Configs.Item("ASCII LOOKUP")
        Dim asciiSeparator As String = config.GetString("Ascii Separator")
        Dim ascii As String() = config.Get("Ascii Array").Trim(IniArray.ToCharArray).Trim(asciiSeparator.ToCharArray()).Split(New String() {asciiSeparator}, StringSplitOptions.None)
        For Each str As String In ascii
            AsciiLookup.Add(Char.Parse(str))
        Next

        config = source.Configs.Item("DEFINE TERRAIN")
        For i As Integer = 0 To config.GetKeys().Length - 1
            Dim keyName As String = "Terrain" + i.ToString
            If config.Get(keyName, "-1") <> "-1" Then
                Dim keyArray As String() = config.Get(keyName).Trim(IniArray.ToCharArray).Split(New Char() {IniSeparator}, StringSplitOptions.None)
                Dim tileId As String = keyArray(0)
                Dim isPassable As Boolean = CBool(keyArray(1))
                Dim isMinerals As Boolean = CBool(keyArray(2))
                Dim imageUrl As String = keyArray(3)

                Dim fullImageUrl As String = My.Application.Info.DirectoryPath + DataPath + "/../" + imageUrl
                Dim theImage As Image = Image.FromFile(fullImageUrl)

                TileImageLookup.Add(tileId, theImage)

                ReDim Preserve TileDefs(i)
                TileDefs(i) = New Tile(0, i * TileSizeY, tileId, isPassable, isMinerals)
            End If
        Next

        config = source.Configs.Item("DEFINE BUILDINGS")
        For i As Integer = 0 To config.GetKeys().Length - 1
            Dim keyName As String = "Building" + i.ToString
            If config.Get(keyName, "-1") <> "-1" Then
                Dim keyArray As String() = config.Get(keyName).Trim(IniArray.ToCharArray).Split(New Char() {IniSeparator}, StringSplitOptions.None)
                Dim buildingId As String = keyArray(0)
                Dim width As Integer = CInt(keyArray(1))
                Dim height As Integer = CInt(keyArray(2))
                Dim team As Team = CType(Integer.Parse(keyArray(3)), Team)
                Dim offsetY As Integer = CInt(keyArray(4))
                Dim imageUrl As String = keyArray(5)
                Dim fullImageUrl As String = My.Application.Info.DirectoryPath + DataPath + "/../" + imageUrl

                Dim test As Bitmap = Bitmap.FromFile(fullImageUrl)
                Dim thumbnail As New Bitmap(TileSizeX, TileSizeY)
                Dim bitX, bitY As Integer
                For bitX = 0 To thumbnail.Width - 1
                    For bitY = 0 To thumbnail.Height - 1
                        thumbnail.SetPixel(bitX, bitY, test.GetPixel(bitX + ((test.Width / 2) - (TileSizeX / 2)), bitY + ((test.Height / 2) - TileSizeY) + offsetY))
                    Next
                Next
                'Dim TheImage As Image = thumbnail
                'TheImage = TheImage.GetThumbnailImage(TileSizeX, TileSizeY, Nothing, System.IntPtr.Zero)

                BuildingSmallImageLookup.Add(buildingId, thumbnail)
                BuildingFullImageLookup.Add(buildingId, Image.FromFile(fullImageUrl))

                ReDim Preserve BuildingDefs(i)
                BuildingDefs(i) = New Building(0, i * TileSizeY, buildingId, team, width, height)
            End If
        Next

        config = source.Configs.Item("DEFINE UNITS")
        For i As Integer = 0 To config.GetKeys().Length - 1
            Dim keyName As String = "Unit" + i.ToString
            If config.Get(keyName, "-1") <> "-1" Then
                Dim keyArray As String() = config.Get(keyName).Trim(IniArray.ToCharArray).Split(New Char() {IniSeparator}, StringSplitOptions.None)
                Dim unitId As String = keyArray(0)
                Dim team As Team = CType(Integer.Parse(keyArray(1)), Team)
                Dim offsetY As Integer = CInt(keyArray(2))
                Dim imageUrl As String = keyArray(3)
                Dim fullImageUrl As String = My.Application.Info.DirectoryPath + DataPath + "/../" + imageUrl

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
                            pixel = test.GetPixel(bitX + ((test.Width / 2) - (w / 2)), bitY + ((test.Height / 2) - TileSizeY) + offsetY)
                        Catch ex As Exception

                        End Try
                        thumbnail.SetPixel(bitX, bitY, pixel)
                    Next
                Next
                'Dim TheImage As Image = thumbnail
                'TheImage = TheImage.GetThumbnailImage(TileSizeX, TileSizeY, Nothing, System.IntPtr.Zero)

                UnitSmallImageLookup.Add(unitId, thumbnail)
                UnitFullImageLookup.Add(unitId, Image.FromFile(fullImageUrl))

                ReDim Preserve UnitDefs(i)
                UnitDefs(i) = New Unit(0, i * TileSizeY, unitId, team)
            End If
        Next
    End Sub

    'ASCII Lookup Array
    Public AsciiLookup As List(Of Char)

    'Tile Definitions.
    Public TileDefs() As Tile

    'Building Definitions.
    Public BuildingDefs() As Building

    'Unit Definitions.
    Public UnitDefs() As Unit

End Module
