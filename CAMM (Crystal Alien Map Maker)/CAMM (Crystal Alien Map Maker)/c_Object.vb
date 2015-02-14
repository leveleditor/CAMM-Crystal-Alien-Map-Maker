Public Class c_Object
    Public HasData As Boolean = False

    Public Sub New(ByVal Location As Point)
        Me.Location = Location
        Me.xImage = Nothing
        Me.ObjectID = ""
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer)
        Me.Location = New Point(X, Y)
        Me.xImage = Nothing
        Me.ObjectID = ""
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal Location As Point, ByVal Image As Image)
        Me.Location = Location
        Me.Image = Image
        Me.ObjectID = ""
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image)
        Me.Location = New Point(X, Y)
        Me.Image = Image
        Me.ObjectID = ""
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal Location As Point, ByVal Image As Image, ByVal ObjectID As String)
        Me.Location = Location
        Me.Image = Image
        Me.ObjectID = ObjectID
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image, ByVal ObjectID As String)
        Me.Location = New Point(X, Y)
        Me.Image = Image
        Me.ObjectID = ObjectID
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal Location As Point, ByVal Image As Image, ByVal ObjectID As String, ByVal Team As Team)
        Me.Location = Location
        Me.Image = Image
        Me.ObjectID = ObjectID
        Me.Team = Team
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image, ByVal ObjectID As String, ByVal Team As Team)
        Me.Location = New Point(X, Y)
        Me.Image = Image
        Me.ObjectID = ObjectID
        Me.Team = Team
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(ByVal Location As Point, ByVal Image As Image, ByVal ObjectID As String, ByVal Team As Team, ByVal Angle As Single, ByVal Damage As Single)
        Me.Location = Location
        Me.Image = Image
        Me.ObjectID = ObjectID
        Me.Team = Team
        Me.Angle = Angle
        Me.Damage = Damage
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image, ByVal ObjectID As String, ByVal Team As Team, ByVal Angle As Single, ByVal Damage As Single)
        Me.Location = New Point(X, Y)
        Me.Image = Image
        Me.ObjectID = ObjectID
        Me.Team = Team
        Me.Angle = Angle
        Me.Damage = Damage
    End Sub
    Public Sub New(ByVal Location As Point, ByVal Image As Image, ByVal ObjectID As String, ByVal Team As Team, ByVal Angle As Single, ByVal Damage As Single, ByVal Width As Integer, ByVal Height As Integer)
        Me.Location = Location
        Me.Image = Image
        Me.ObjectID = ObjectID
        Me.Team = Team
        Me.Angle = Angle
        Me.Damage = Damage
        Me.ObjWidth = Width
        Me.ObjHeight = Height
    End Sub
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal Image As Image, ByVal ObjectID As String, ByVal Team As Team, ByVal Angle As Single, ByVal Damage As Single, ByVal Width As Integer, ByVal Height As Integer)
        Me.Location = New Point(X, Y)
        Me.Image = Image
        Me.ObjectID = ObjectID
        Me.Team = Team
        Me.Angle = Angle
        Me.Damage = Damage
        Me.ObjWidth = Width
        Me.ObjHeight = Height
    End Sub

    Private xLocation As Point
    Public Property Location() As Point
        Get
            Return xLocation
        End Get
        Set(ByVal value As Point)
            xLocation = value
        End Set
    End Property

    Private xDrawPos As Point
    Public Property DrawPos() As Point
        Get
            Return xDrawPos
        End Get
        Set(ByVal value As Point)
            xDrawPos = value
        End Set
    End Property

    Private xImage As Image
    Public Property Image() As Image
        Get
            Return xImage
        End Get
        Set(ByVal value As Image)
            xImage = value
            If xImage Is Nothing Then
                HasData = False
            Else
                HasData = True
            End If
        End Set
    End Property

    Private xFullImage As Image
    Public Property FullImage() As Image
        Get
            Return xFullImage
        End Get
        Set(ByVal value As Image)
            xFullImage = value
        End Set
    End Property

    Private xObjectID As String
    Public Property ObjectID() As String
        Get
            Return xObjectID
        End Get
        Set(ByVal value As String)
            xObjectID = value
        End Set
    End Property

    Private xTeam As Team
    Public Property Team() As Team
        Get
            Return xTeam
        End Get
        Set(ByVal value As Team)
            xTeam = value
        End Set
    End Property

    Private xAngle As Single
    Public Property Angle() As Single
        Get
            Return xAngle
        End Get
        Set(ByVal value As Single)
            xAngle = value
        End Set
    End Property

    Private xDamage As Single
    Public Property Damage() As Single
        Get
            Return xDamage
        End Get
        Set(ByVal value As Single)
            xDamage = value
        End Set
    End Property

    Private xObjWidth As Integer
    Public Property ObjWidth() As Integer
        Get
            Return xObjWidth
        End Get
        Set(ByVal value As Integer)
            xObjWidth = value
        End Set
    End Property

    Private xObjHeight As Integer
    Public Property ObjHeight() As Integer
        Get
            Return xObjHeight
        End Get
        Set(ByVal value As Integer)
            xObjHeight = value
        End Set
    End Property

End Class
