Public Class Tile

    Public Sub New(x As Integer, y As Integer)
        Me.Position = New Point(x, y)
        Me.TileId = -1
        Me.IsPassable = False
        Me.IsMinerals = False
    End Sub
    Public Sub New(x As Integer, y As Integer, tileId As Integer)
        Me.New(x, y)
        Me.TileId = tileId
    End Sub
    Public Sub New(x As Integer, y As Integer, tileId As Integer, isPassable As Boolean, isMinerals As Boolean)
        Me.New(x, y, tileId)
        Me.IsPassable = isPassable
        Me.IsMinerals = isMinerals
    End Sub

    Public ReadOnly Property HasData As Boolean
        Get
            Return Image IsNot Nothing
        End Get
    End Property

    Public Property X As Integer
        Get
            Return Position.X
        End Get
        Set(value As Integer)
            _position.X = value
        End Set
    End Property

    Public Property Y As Integer
        Get
            Return Position.Y
        End Get
        Set(value As Integer)
            _position.Y = value
        End Set
    End Property

    Private _position As Point
    Public Property Position As Point
        Get
            Return _position
        End Get
        Set(value As Point)
            _position = value
        End Set
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

    Public Sub Draw(g As Graphics)
        g.DrawImage(Image, X, Y, TileSizeX, TileSizeY)
    End Sub

End Class
