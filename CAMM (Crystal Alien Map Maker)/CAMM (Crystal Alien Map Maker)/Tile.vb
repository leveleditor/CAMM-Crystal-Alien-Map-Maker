Public Class Tile

    Public Sub New(ByVal X As Integer, ByVal Y As Integer)
        Me.Position = New Point(X, Y)
        Me.Image = Nothing
        Me.TileId = -1
        Me.IsPassable = False
        Me.IsMinerals = False
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image)
        Me.New(X, Y)
        Me.Image = Image
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image, ByVal TileId As String)
        Me.New(X, Y, Image)
        Me.TileId = TileId
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image, ByVal TileId As String, ByVal IsPassable As Boolean, ByVal IsMinerals As Boolean)
        Me.New(X, Y, Image, TileId)
        Me.IsPassable = IsPassable
        Me.IsMinerals = IsMinerals
    End Sub

    Public ReadOnly Property HasData() As Boolean
        Get
            Dim value As Boolean = False
            If Image IsNot Nothing Then
                value = True
            End If
            Return value
        End Get
    End Property

    Public Property X() As Integer
        Get
            Return Position.X
        End Get
        Set(ByVal value As Integer)
            pt_Position.X = value
        End Set
    End Property

    Public Property Y() As Integer
        Get
            Return Position.Y
        End Get
        Set(ByVal value As Integer)
            pt_Position.Y = value
        End Set
    End Property

    Private pt_Position As Point
    Public Property Position() As Point
        Get
            Return pt_Position
        End Get
        Set(ByVal value As Point)
            pt_Position = value
        End Set
    End Property

    Private _image As Image
    Public Property Image() As Image
        Get
            Return _image
        End Get
        Set(ByVal value As Image)
            _image = value
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

    Private b_IsPassable As Boolean = False
    Public Property IsPassable() As Boolean
        Get
            Return b_IsPassable
        End Get
        Set(ByVal value As Boolean)
            b_IsPassable = value
        End Set
    End Property

    Private b_IsMinerals As Boolean = False
    Public Property IsMinerals() As Boolean
        Get
            Return b_IsMinerals
        End Get
        Set(ByVal value As Boolean)
            b_IsMinerals = value
        End Set
    End Property

End Class
