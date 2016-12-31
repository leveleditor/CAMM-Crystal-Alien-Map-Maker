<Serializable>
Public Structure ConfigData
    Public Format As Integer

    Public TileAscii As List(Of Char)

    Public Tiles As List(Of TileDefData)
    Public Buildings As List(Of BuildingDefData)
    Public Units As List(Of UnitDefData)
End Structure
