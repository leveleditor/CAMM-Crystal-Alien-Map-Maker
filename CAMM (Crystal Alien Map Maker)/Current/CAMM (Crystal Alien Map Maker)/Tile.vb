Public Class Tile
    Public HasData As Boolean = False

    Public Sub New(ByVal Position As Point)
        Me.Position = Position
        Me._image = Nothing
        Me.TileId = -1
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer)
        Me.X = X
        Me.Y = Y
        Me._image = Nothing
        Me.TileId = -1
    End Sub
    Public Sub New(ByVal Location As Point, ByVal Image As Image)
        Me.Position = Location
        Me.Image = Image
        Me.TileId = -1
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image)
        Me.Position = New Point(X, Y)
        Me.Image = Image
        Me.TileId = -1
    End Sub
    Public Sub New(ByVal Location As Point, ByVal Image As Image, ByVal TileId As String)
        Me.Position = Location
        Me.Image = Image
        Me.TileId = TileId
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image, ByVal TileId As String)
        Me.Position = New Point(X, Y)
        Me.Image = Image
        Me.TileId = TileId
    End Sub

    Private i_gridX As Integer = -1
    Public Property X() As Integer
        Get
            Return i_gridX
        End Get
        Set(ByVal value As Integer)
            i_gridX = value
        End Set
    End Property

    Private i_gridY As Integer = -1
    Public Property Y() As Integer
        Get
            Return i_gridY
        End Get
        Set(ByVal value As Integer)
            i_gridY = value
        End Set
    End Property

    Public Property Position() As Point
        Get
            Return New Point(X, Y)
        End Get
        Set(ByVal value As Point)
            X = value.X
            Y = value.Y
        End Set
    End Property

    Private _image As Image
    Public Property Image() As Image
        Get
            Return _image
        End Get
        Set(ByVal value As Image)
            _image = value
            If _image Is Nothing Then
                HasData = False
            Else
                HasData = True
            End If
        End Set
    End Property

    Private str_Id As String = -1
    Public Property TileId() As String
        Get
            Return str_Id
        End Get
        Set(ByVal value As String)
            str_Id = value
        End Set
    End Property

End Class
