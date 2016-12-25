<Serializable>
Public Structure MapData
    Public Format As Integer

    Public Title, Author As String
    Public Width, Height As Integer
    Public Team As Integer
    Public CashPlayer, CashEnemy As Integer
    Public IsTraining, IsConflict, IsSpecialLevel, IsLastSpecialLevel, IsBonusLevel As Boolean
    Public IsFinal As Boolean

    Public Tiles As List(Of Integer)
    Public Buildings As List(Of BuildingData)
    Public Units As List(Of UnitData)
End Structure
