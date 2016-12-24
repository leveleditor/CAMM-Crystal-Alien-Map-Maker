Public Module Assets

    Public Sub LoadAssets()
        Background = Image.FromFile(DataPath + "/Backgrounds/Mars.png")
        ButtonNeutral = Image.FromFile(DataPath + "/UI/Buttons/NeutralBackground.png")
        ButtonAstro = Image.FromFile(DataPath + "/UI/Buttons/AstroBackground.png")
        ButtonAlien = Image.FromFile(DataPath + "/UI/Buttons/AlienBackground.png")
        ButtonOverlay = Image.FromFile(DataPath + "/UI/Buttons/Overlay.png")
        BaseplateAstroWide = Image.FromFile(DataPath + "/Baseplates/Astro2x2.png")
        BaseplateAlienWide = Image.FromFile(DataPath + "/Baseplates/Alien2x2.png")
        BaseplateAstroSmall = Image.FromFile(DataPath + "/Baseplates/Astro1x2.png")
        BaseplateAlienSmall = Image.FromFile(DataPath + "/Baseplates/Alien1x2.png")
        TeamIndicatorAstro = Image.FromFile(DataPath + "/UI/Indicators/AstroTeam.png")
        TeamIndicatorAlien = Image.FromFile(DataPath + "/UI/Indicators/AlienTeam.png")
        TeamIndicatorNeutral = Image.FromFile(DataPath + "/UI/Indicators/NeutralTeam.png")
        UnitSelectionHover = Image.FromFile(DataPath + "/UI/Overlays/UnitSelectionHover.png")
        UnitSelectionClick = Image.FromFile(DataPath + "/UI/Overlays/UnitSelectionClick.png")

        TileImageLookup = New Dictionary(Of Integer, Image)()
        BuildingSmallImageLookup = New Dictionary(Of String, Image)()
        BuildingFullImageLookup = New Dictionary(Of String, Image)()
        BuildingShadowImageLookup = New Dictionary(Of String, Image)()
        UnitSmallImageLookup = New Dictionary(Of String, Image)()
        UnitFullImageLookup = New Dictionary(Of String, Image)()
        UnitShadowImageLookup = New Dictionary(Of String, Image)()
    End Sub

    'Terrain background image.
    Public Background As Image

    'Button graphics.
    Public ButtonNeutral As Image
    Public ButtonAstro As Image
    Public ButtonAlien As Image
    Public ButtonOverlay As Image

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
