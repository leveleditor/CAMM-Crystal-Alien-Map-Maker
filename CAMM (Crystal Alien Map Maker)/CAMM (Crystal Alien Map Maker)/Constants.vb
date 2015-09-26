Public Module Constants

#If DEBUG Then
    Public Const BuildType As String = "[Debug]"
    Public Const DataPath As String = "/../../../CAMM_Data"
    Public Const SavePath As String = "/../../../Save Data"
#Else
    Public Const BuildType As String = "[Stable]"
    Public Const DataPath As String = "/CAMM_Data"
    Public Const SavePath As String = "/Save Data"
#End If

    Public ReadOnly FullBasePath As String = My.Application.Info.DirectoryPath + DataPath
    Public Const ConfigFileName As String = "Config.ini"
    Public Const TerrainFileName As String = "Terrain.ini"
    Public Const BuildingsFileName As String = "Buildings.ini"
    Public Const UnitsFileName As String = "Units.ini"
    Public ReadOnly ConfigFile As String = FullBasePath + "/" + ConfigFileName
    Public ReadOnly TerrainFile As String = FullBasePath + "/" + TerrainFileName
    Public ReadOnly BuildingsFile As String = FullBasePath + "/" + BuildingsFileName
    Public ReadOnly UnitsFile As String = FullBasePath + "/" + UnitsFileName
    Public ReadOnly RectangleBrushPath As String = FullBasePath + "/Brushes/Rectangle"

    Public Const ConfigFormat As Integer = 7
    Public Const TerrainFormat As Integer = 8
    Public Const BuildingsFormat As Integer = 9
    Public Const UnitsFormat As Integer = 10
    Public Const MapFormat As Integer = 6

    Public Const IniArray As String = "{}"
    Public Const IniSeparator As String = "|"

    Public Const TileSizeX As Integer = 96
    Public Const TileSizeY As Integer = 48

    'TODO: Externalize to config file.
    Public Const CashPlayerDefault = 2000
    Public Const CashEnemyDefault = 20000
    Public Const IsTrainingDefault As Boolean = False
    Public Const IsConflictDefault As Boolean = False
    Public Const IsSpecialLevelDefault As Boolean = False
    Public Const IsLastSpecialLevelDefault As Boolean = False
    Public Const IsBonusLevelDefault As Boolean = True

    'TODO: Externalize to config file.
    Public ReadOnly PenTileHover As Pen = New Pen(Pens.DarkOrange.Brush, 2)
    Public ReadOnly PenTileErase As Pen = New Pen(Pens.Red.Brush, 2)
    Public ReadOnly PenGrid As Pen = Pens.Black
    Public ReadOnly PenSelectionHover As Pen = New Pen(Pens.DarkOrange.Brush, 2)
    Public ReadOnly PenSelected As Pen = New Pen(Pens.LimeGreen.Brush, 3)

    Public Enum EditMode
        Tiles
        Buildings
        Units
        Shroud
    End Enum

    Public Enum ToolMode
        Pointer
        Brush
        SmartBrush
        RectangleBrush
        Eraser
    End Enum

    Public Enum Team
        Unknown = -1
        Astros = 0
        Aliens = 1
        Neutral = 2
    End Enum

End Module
