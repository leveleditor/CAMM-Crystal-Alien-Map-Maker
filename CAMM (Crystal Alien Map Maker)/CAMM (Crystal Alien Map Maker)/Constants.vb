Public Module Constants

#If DEBUG Then
    Public Const BuildType As String = "[Debug]"
    Public Const DataPath As String = "/../../Tile Data"
#Else
    Public Const BuildType As String = "[Stable]"
    Public Const DataPath As String = "/Tile Data"
#End If

    Public ReadOnly FullBasePath As String = My.Application.Info.DirectoryPath & DataPath
    Public ReadOnly TileDataFile As String = FullBasePath & "/Tiles.dat"

    Public Const TilesDatVersion As Integer = 6
    Public Const MapFormat As Integer = 5

    Public Const IniArray As String = "{}"
    Public Const IniSeparator As String = "|"

    Public Const TileSizeX As Integer = 96
    Public Const TileSizeY As Integer = 48

    Public Const CashPlayerDefault = 2000
    Public Const CashEnemyDefault = 20000
    Public Const IsTrainingDefault As Boolean = False
    Public Const IsConflictDefault As Boolean = False
    Public Const IsSpecialLevelDefault As Boolean = False
    Public Const IsLastSpecialLevelDefault As Boolean = False
    Public Const IsBonusLevelDefault As Boolean = True

    Public ReadOnly PenTileHover As Pen = New Pen(Pens.DarkOrange.Brush, 2)
    Public ReadOnly PenTileErase As Pen = New Pen(Pens.Red.Brush, 2)
    Public ReadOnly PenGrid As Pen = Pens.Black
    Public ReadOnly PenSelectionHover As Pen = New Pen(Pens.DarkOrange.Brush, 2)
    Public ReadOnly PenSelected As Pen = New Pen(Pens.LimeGreen.Brush, 3)

    Public Enum EditMode
        Tiles = 0
        Buildings = 1
        Units = 2
        Shroud = 3
    End Enum

    Public Enum ToolMode
        Brush = 0
        SmartBrush = 1
        Eraser = 2
    End Enum

    Public Enum Team
        Neutral = -1
        Astros = 0
        Aliens = 1
    End Enum

End Module
