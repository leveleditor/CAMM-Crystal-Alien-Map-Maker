Public Module Assets

    Public Sub LoadAssets()
        Background = Image.FromFile(FullBasePath + "/Other Data/Background.png")
        ButtonNeutral = Image.FromFile(FullBasePath + "/Other Data/ButtonNeutralUnderlay.png")
        ButtonAstro = Image.FromFile(FullBasePath + "/Other Data/ButtonAstroUnderlay.png")
        ButtonAlien = Image.FromFile(FullBasePath + "/Other Data/ButtonAlienUnderlay.png")
        ButtonOverlay = Image.FromFile(FullBasePath + "/Other Data/ButtonOverlay.png")
        BaseplateAstroWide = Image.FromFile(FullBasePath + "/Other Data/AstroBaseplateAlphaWide.png")
        BaseplateAlienWide = Image.FromFile(FullBasePath + "/Other Data/AlienBaseplateAlphaWide.png")
        BaseplateAstroSmall = Image.FromFile(FullBasePath + "/Other Data/AstroBaseplateAlphaSmall.png")
        BaseplateAlienSmall = Image.FromFile(FullBasePath + "/Other Data/AlienBaseplateAlphaSmall.png")
        TeamIndicatorAstro = Image.FromFile(FullBasePath + "/Other Data/AstroTeamIndicatorIcon.png")
        TeamIndicatorAlien = Image.FromFile(FullBasePath + "/Other Data/AlienTeamIndicatorIcon.png")
        TeamIndicatorNeutral = Image.FromFile(FullBasePath + "/Other Data/NeutralTeamIndicatorIcon.png")
        UnitSelectionHover = Image.FromFile(FullBasePath + "/Other Data/UnitSelectionHover.png")
        UnitSelectionClick = Image.FromFile(FullBasePath + "/Other Data/UnitSelectionClick.png")

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
