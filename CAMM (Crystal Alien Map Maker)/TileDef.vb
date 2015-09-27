Public Class TileDef

    Public Sub New(tileId As Integer, isPassable As Boolean, isMinerals As Boolean, imageUrl As String)
        Me.TileId = tileId
        Me.IsPassable = isPassable
        Me.IsMinerals = isMinerals
        Me.ImageUrl = imageUrl
    End Sub

    Public ReadOnly Property HasData As Boolean
        Get
            Return Image IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property Image As Image
        Get
            If TileId <> -1 Then
                Return TileImageLookup(TileId)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Property TileId As Integer

    Public Property IsPassable As Boolean

    Public Property IsMinerals As Boolean

    Public Property ImageUrl As String

    Public Sub Draw(g As Graphics, drawX As Integer, drawY As Integer)
        g.DrawImage(Image, drawX, drawY, TileSizeX, TileSizeY)
    End Sub

End Class
