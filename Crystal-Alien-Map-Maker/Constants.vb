Public Module Constants

#If DEBUG Then
    Public Const BuildType As String = "[Debug]"
    Public Const DataDir As String = "/../../../CAMM_Data"
    Public Const SaveDir As String = "/../../../Maps"
#Else
    Public Const BuildType As String = "[Stable]"
    Public Const DataDir As String = "/CAMM_Data"
    Public Const SaveDir As String = "/Maps"
#End If

    Public ReadOnly AppPath As String = My.Application.Info.DirectoryPath
    Public ReadOnly DataPath As String = AppPath + DataDir
    Public ReadOnly SavePath As String = AppPath + SaveDir
    Public Const ConfigFileName As String = "Config.ini"
    Public Const TerrainFileName As String = "Terrain.ini"
    Public Const BuildingsFileName As String = "Buildings.ini"
    Public Const UnitsFileName As String = "Units.ini"
    Public ReadOnly ConfigFile As String = DataPath + "/" + ConfigFileName
    Public ReadOnly TerrainFile As String = DataPath + "/" + TerrainFileName
    Public ReadOnly BuildingsFile As String = DataPath + "/" + BuildingsFileName
    Public ReadOnly UnitsFile As String = DataPath + "/" + UnitsFileName
    Public ReadOnly RectangleBrushPath As String = DataPath + "/Brushes/Rectangle"
    Public ReadOnly DefaultMapsPath As String = DataPath + "/Default_Maps"

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
    Public ReadOnly BrushBuildingPlacement As SolidBrush = New SolidBrush(Color.FromArgb(128, 0, 255, 0))

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
