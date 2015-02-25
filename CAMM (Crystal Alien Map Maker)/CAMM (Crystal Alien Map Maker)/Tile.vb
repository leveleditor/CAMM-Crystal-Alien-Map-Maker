Public Class Tile

    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        Me.Position = New Point(x, y)
        Me.TileId = -1
        Me.IsPassable = False
        Me.IsMinerals = False
    End Sub
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal tileId As Integer)
        Me.New(x, y)
        Me.TileId = tileId
    End Sub
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal tileId As Integer, ByVal isPassable As Boolean, ByVal isMinerals As Boolean)
        Me.New(x, y, tileId)
        Me.IsPassable = isPassable
        Me.IsMinerals = isMinerals
    End Sub

    Public ReadOnly Property HasData() As Boolean
        Get
            Return Image IsNot Nothing
        End Get
    End Property

    Public Property X() As Integer
        Get
            Return Position.X
        End Get
        Set(ByVal value As Integer)
            _position.X = value
        End Set
    End Property

    Public Property Y() As Integer
        Get
            Return Position.Y
        End Get
        Set(ByVal value As Integer)
            _position.Y = value
        End Set
    End Property

    Private _position As Point
    Public Property Position() As Point
        Get
            Return _position
        End Get
        Set(ByVal value As Point)
            _position = value
        End Set
    End Property

    Public ReadOnly Property Image() As Image
        Get
            If TileId <> -1 Then
                Return TileImageLookup(TileId)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _tileId As Integer
    Public Property TileId() As Integer
        Get
            Return _tileId
        End Get
        Set(ByVal value As Integer)
            _tileId = value
        End Set
    End Property

    Private _isPassable As Boolean
    Public Property IsPassable() As Boolean
        Get
            Return _isPassable
        End Get
        Set(ByVal value As Boolean)
            _isPassable = value
        End Set
    End Property

    Private _isMinerals As Boolean
    Public Property IsMinerals() As Boolean
        Get
            Return _isMinerals
        End Get
        Set(ByVal value As Boolean)
            _isMinerals = value
        End Set
    End Property

End Class
