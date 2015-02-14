Public Class Unit
    Public HasData As Boolean = False

    Public Sub New(ByVal Position As Point)
        Me.Position = Position
        Me._Image = Nothing
        Me.UnitId = ""
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer)
        Me.Position = New Point(X, Y)
        Me._Image = Nothing
        Me.UnitId = ""
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal Position As Point, ByVal Image As Image)
        Me.Position = Position
        Me.Image = Image
        Me.UnitId = ""
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image)
        Me.Position = New Point(X, Y)
        Me.Image = Image
        Me.UnitId = ""
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal Position As Point, ByVal Image As Image, ByVal ObjectID As String)
        Me.Position = Position
        Me.Image = Image
        Me.UnitId = ObjectID
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image, ByVal ObjectID As String)
        Me.Position = New Point(X, Y)
        Me.Image = Image
        Me.UnitId = ObjectID
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal Position As Point, ByVal Image As Image, ByVal ObjectID As String, ByVal Team As Team)
        Me.Position = Position
        Me.Image = Image
        Me.UnitId = ObjectID
        Me.Team = Team
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image, ByVal ObjectID As String, ByVal Team As Team)
        Me.Position = New Point(X, Y)
        Me.Image = Image
        Me.UnitId = ObjectID
        Me.Team = Team
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal Position As Point, ByVal Image As Image, ByVal ObjectID As String, ByVal Team As Team, ByVal Angle As Single, ByVal Damage As Single)
        Me.Position = Position
        Me.Image = Image
        Me.UnitId = ObjectID
        Me.Team = Team
        Me.Angle = Angle
        Me.Damage = Damage
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image, ByVal ObjectID As String, ByVal Team As Team, ByVal Angle As Single, ByVal Damage As Single)
        Me.Position = New Point(X, Y)
        Me.Image = Image
        Me.UnitId = ObjectID
        Me.Team = Team
        Me.Angle = Angle
        Me.Damage = Damage
    End Sub

    'Private i_gridX As Integer = -1
    'Public Property GridX() As Integer
    '    Get
    '        Return i_gridX
    '    End Get
    '    Set(ByVal value As Integer)
    '        i_gridX = value
    '    End Set
    'End Property

    'Private i_gridY As Integer = -1
    'Public Property GridY() As Integer
    '    Get
    '        Return i_gridY
    '    End Get
    '    Set(ByVal value As Integer)
    '        i_gridY = value
    '    End Set
    'End Property

    'Public Property GridSpace() As Point
    '    Get
    '        Return New Point(X, Y)
    '    End Get
    '    Set(ByVal value As Point)
    '        X = value.X
    '        Y = value.Y
    '    End Set
    'End Property

    Private i_X As Integer = -1
    Public Property X() As Integer
        Get
            Return i_X
        End Get
        Set(ByVal value As Integer)
            i_X = value
        End Set
    End Property

    Private i_Y As Integer = -1
    Public Property Y() As Integer
        Get
            Return i_Y
        End Get
        Set(ByVal value As Integer)
            i_Y = value
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

    Private _Image As Image
    Public Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            _Image = value
            If _Image Is Nothing Then
                HasData = False
            Else
                HasData = True
            End If
        End Set
    End Property

    Private _FullImage As Image
    Public Property FullImage() As Image
        Get
            Return _FullImage
        End Get
        Set(ByVal value As Image)
            _FullImage = value
        End Set
    End Property

    Private id As String
    Public Property UnitId() As String
        Get
            Return id
        End Get
        Set(ByVal value As String)
            id = value
        End Set
    End Property

    Private i_Team As Team
    Public Property Team() As Team
        Get
            Return i_Team
        End Get
        Set(ByVal value As Team)
            i_Team = value
        End Set
    End Property

    Private f_Angle As Single
    Public Property Angle() As Single
        Get
            Return f_Angle
        End Get
        Set(ByVal value As Single)
            f_Angle = value
        End Set
    End Property

    Private f_Damage As Single
    Public Property Damage() As Single
        Get
            Return f_Damage
        End Get
        Set(ByVal value As Single)
            f_Damage = value
        End Set
    End Property

End Class
