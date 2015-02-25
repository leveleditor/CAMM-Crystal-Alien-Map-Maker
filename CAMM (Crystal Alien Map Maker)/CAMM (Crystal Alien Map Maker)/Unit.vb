Public Class Unit

    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        Me.Position = New Point(x, y)
        Me.SmallImage = Nothing
        Me.UnitId = ""
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal image As Image)
        Me.New(x, y)
        Me.SmallImage = image
    End Sub
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal image As Image, ByVal unitId As String)
        Me.New(x, y, image)
        Me.UnitId = unitId
    End Sub
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal image As Image, ByVal unitId As String, ByVal team As Team)
        Me.New(x, y, image, unitId)
        Me.Team = team
    End Sub
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal image As Image, ByVal unitId As String, ByVal team As Team, ByVal angle As Single, ByVal damage As Single)
        Me.New(x, y, image, unitId, team)
        Me.Angle = angle
        Me.Damage = damage
    End Sub

    Public ReadOnly Property HasData() As Boolean
        Get
            Return SmallImage IsNot Nothing
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

    Private _smallImage As Image
    Public Property SmallImage() As Image
        Get
            Return _smallImage
        End Get
        Set(ByVal value As Image)
            _smallImage = value
        End Set
    End Property

    Private _fullImage As Image
    Public Property FullImage() As Image
        Get
            Return _fullImage
        End Get
        Set(ByVal value As Image)
            _fullImage = value
        End Set
    End Property

    Private _unitId As String
    Public Property UnitId() As String
        Get
            Return _unitId
        End Get
        Set(ByVal value As String)
            _unitId = value
        End Set
    End Property

    Private _team As Team
    Public Property Team() As Team
        Get
            Return _team
        End Get
        Set(ByVal value As Team)
            _team = value
        End Set
    End Property

    Private _angle As Single
    Public Property Angle() As Single
        Get
            Return _angle
        End Get
        Set(ByVal value As Single)
            _angle = value
        End Set
    End Property

    Private _damage As Single
    Public Property Damage() As Single
        Get
            Return _damage
        End Get
        Set(ByVal value As Single)
            _damage = value
        End Set
    End Property

End Class
