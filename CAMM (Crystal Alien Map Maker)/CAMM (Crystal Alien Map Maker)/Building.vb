Public Class Building

    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        Me.Location = New Point(x, y)
        Me.Image = Nothing
        Me.BuildingId = ""
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal image As Image)
        Me.New(x, y)
        Me.Image = image
    End Sub
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal image As Image, ByVal buildingId As String)
        Me.New(x, y, image)
        Me.BuildingId = buildingId
    End Sub
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal image As Image, ByVal buildingId As String, ByVal team As Team)
        Me.New(x, y, image, buildingId)
        Me.Team = team
    End Sub
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal image As Image, ByVal buildingId As String, ByVal team As Team, ByVal angle As Single, ByVal damage As Single)
        Me.New(x, y, image, buildingId, team)
        Me.Angle = angle
        Me.Damage = damage
    End Sub
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal image As Image, ByVal buildingId As String, ByVal team As Team, ByVal angle As Single, ByVal damage As Single, ByVal width As Integer, ByVal height As Integer)
        Me.New(x, y, image, buildingId, team, angle, damage)
        Me.BuildingW = width
        Me.BuildingH = height
    End Sub

    Public ReadOnly Property HasData() As Boolean
        Get
            Return Image IsNot Nothing
        End Get
    End Property

    Private _location As Point
    Public Property Location() As Point
        Get
            Return _location
        End Get
        Set(ByVal value As Point)
            _location = value
        End Set
    End Property

    Private _drawPos As Point
    Public Property DrawPos() As Point
        Get
            Return _drawPos
        End Get
        Set(ByVal value As Point)
            _drawPos = value
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

    Private _fullImage As Image
    Public Property FullImage() As Image
        Get
            Return _fullImage
        End Get
        Set(ByVal value As Image)
            _fullImage = value
        End Set
    End Property

    Private _buildingId As String
    Public Property BuildingId() As String
        Get
            Return _buildingId
        End Get
        Set(ByVal value As String)
            _buildingId = value
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

    Private _buildingW As Integer
    Public Property BuildingW() As Integer
        Get
            Return _buildingW
        End Get
        Set(ByVal value As Integer)
            _buildingW = value
        End Set
    End Property

    Private _buildingH As Integer
    Public Property BuildingH() As Integer
        Get
            Return _buildingH
        End Get
        Set(ByVal value As Integer)
            _buildingH = value
        End Set
    End Property

End Class
