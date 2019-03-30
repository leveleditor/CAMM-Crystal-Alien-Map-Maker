Imports System.IO

Public Module Assets

    Public Sub LoadAssets()
        Background = LoadImageAsset(DataPath + "/Backgrounds/Mars.png")
        ButtonNeutral = LoadImageAsset(DataPath + "/UI/Buttons/NeutralBackground.png")
        ButtonAstro = LoadImageAsset(DataPath + "/UI/Buttons/AstroBackground.png")
        ButtonAlien = LoadImageAsset(DataPath + "/UI/Buttons/AlienBackground.png")
        ButtonOverlay = LoadImageAsset(DataPath + "/UI/Buttons/Overlay.png")
        ButtonPlay = LoadImageAsset(DataPath + "/UI/Buttons/Play.png")
        BaseplateAstroWide = LoadImageAsset(DataPath + "/Baseplates/Astro2x2.png")
        BaseplateAlienWide = LoadImageAsset(DataPath + "/Baseplates/Alien2x2.png")
        BaseplateAstroSmall = LoadImageAsset(DataPath + "/Baseplates/Astro1x2.png")
        BaseplateAlienSmall = LoadImageAsset(DataPath + "/Baseplates/Alien1x2.png")
        TeamIndicatorAstro = LoadImageAsset(DataPath + "/UI/Indicators/AstroTeam.png")
        TeamIndicatorAlien = LoadImageAsset(DataPath + "/UI/Indicators/AlienTeam.png")
        TeamIndicatorNeutral = LoadImageAsset(DataPath + "/UI/Indicators/NeutralTeam.png")
        UnitSelectionHover = LoadImageAsset(DataPath + "/UI/Overlays/UnitSelectionHover.png")
        UnitSelectionClick = LoadImageAsset(DataPath + "/UI/Overlays/UnitSelectionClick.png")

        TileImageLookup = New Dictionary(Of Integer, Image)()
        BuildingSmallImageLookup = New Dictionary(Of String, Image)()
        BuildingFullImageLookup = New Dictionary(Of String, Image)()
        BuildingShadowImageLookup = New Dictionary(Of String, Image)()
        UnitSmallImageLookup = New Dictionary(Of String, Image)()
        UnitFullImageLookup = New Dictionary(Of String, Image)()
        UnitShadowImageLookup = New Dictionary(Of String, Image)()
    End Sub

    Private Function LoadImageAsset(fileName As String) As Image
        Try
            Return Image.FromFile(fileName)
        Catch ex As FileNotFoundException
            MsgBox("Error: Required asset file is missing: " + ex.FileName + vbNewLine + "Program cannot continue. Exiting...")
            Environment.Exit(1)
        Catch ex As ArgumentException
            MsgBox("Error: Required asset file is invalid: " + fileName + vbNewLine + "Program cannot continue. Exiting...")
            Environment.Exit(1)
        End Try
        Return Nothing
    End Function

    'Terrain background image.
    Public Background As Image

    'Button graphics.
    Public ButtonNeutral As Image
    Public ButtonAstro As Image
    Public ButtonAlien As Image
    Public ButtonOverlay As Image
    Public ButtonPlay As Image

    'Building baseplate graphics.
    Public BaseplateAstroWide As Image
    Public BaseplateAlienWide As Image
    Public BaseplateAstroSmall As Image
    Public BaseplateAlienSmall As Image

    'Team Indicator Icon graphics.
    Public TeamIndicatorAlien As Image
    Public TeamIndicatorAstro As Image
    Public TeamIndicatorNeutral As Image

    'Unit selection graphics.
    Public UnitSelectionHover As Image
    Public UnitSelectionClick As Image

    'Lookup for Tile Image graphics.
    Public TileImageLookup As Dictionary(Of Integer, Image)

    'Lookup for Building SmallImage graphics.
    Public BuildingSmallImageLookup As Dictionary(Of String, Image)

    'Lookup for Building FullImage graphics.
    Public BuildingFullImageLookup As Dictionary(Of String, Image)

    'Lookup for Building Shadow graphics.
    Public BuildingShadowImageLookup As Dictionary(Of String, Image)

    'Lookup for Unit SmallImage graphics.
    Public UnitSmallImageLookup As Dictionary(Of String, Image)

    'Lookup for Unit FullImage graphics.
    Public UnitFullImageLookup As Dictionary(Of String, Image)

    'Lookup for Unit Shadow graphics.
    Public UnitShadowImageLookup As Dictionary(Of String, Image)

End Module
