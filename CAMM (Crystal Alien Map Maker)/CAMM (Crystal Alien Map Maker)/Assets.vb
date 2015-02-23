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

End Module
