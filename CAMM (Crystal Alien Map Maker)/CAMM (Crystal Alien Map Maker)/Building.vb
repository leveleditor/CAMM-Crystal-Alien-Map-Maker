Public Class Building

    Public Sub New(x As Integer, y As Integer)
        Me.Location = New Point(x, y)
        Me.BuildingId = ""
        Me.Team = Team.Astros
        Me.Angle = 0.0
        Me.Damage = 0.0
    End Sub
    Public Sub New(x As Integer, y As Integer, buildingId As String)
        Me.New(x, y)
        Me.BuildingId = buildingId
    End Sub
    Public Sub New(x As Integer, y As Integer, buildingId As String, team As Team)
        Me.New(x, y, buildingId)
        Me.Team = team
    End Sub
    Public Sub New(x As Integer, y As Integer, buildingId As String, team As Team, width As Integer, height As Integer)
        Me.New(x, y, buildingId, team)
        Me.BuildingW = width
        Me.BuildingH = height
    End Sub
    Public Sub New(x As Integer, y As Integer, buildingId As String, team As Team, width As Integer, height As Integer, angle As Single, damage As Single)
        Me.New(x, y, buildingId, team, width, height)
        Me.Angle = angle
        Me.Damage = damage
    End Sub

    Public ReadOnly Property HasData As Boolean
        Get
            Return SmallImage IsNot Nothing
        End Get
    End Property

    Public Property X As Integer
        Get
            Return Location.X
        End Get
        Set(value As Integer)
            _location.X = value
        End Set
    End Property

    Public Property Y As Integer
        Get
            Return Location.Y
        End Get
        Set(value As Integer)
            _location.Y = value
        End Set
    End Property

    Private _location As Point
    Public Property Location As Point
        Get
            Return _location
        End Get
        Set(value As Point)
            _location = value
        End Set
    End Property

    Public ReadOnly Property DrawPos As Point
        Get
            If Me.FullImage IsNot Nothing Then
                Dim dx As Integer = Me.Location.X
                Dim dy As Integer = Me.Location.Y

                dx -= (Me.FullImage.Width - (Me.BuildingW * TileSizeX)) / 2
                dy -= (Me.FullImage.Height - (Me.BuildingH * TileSizeY)) / 2

                Return New Point(dx, dy)
            Else
                Return Me.Location
            End If
        End Get
    End Property

    Public ReadOnly Property SmallImage As Image
        Get
            If Not String.IsNullOrEmpty(BuildingId) Then
                Return BuildingSmallImageLookup(BuildingId)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property FullImage As Image
        Get
            If Not String.IsNullOrEmpty(BuildingId) Then
                Return BuildingFullImageLookup(BuildingId)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Property BuildingId As String

    Public Property Team As Team

    Public Property Angle As Single

    Public Property Damage As Single

    Public Property BuildingW As Integer

    Public Property BuildingH As Integer

End Class
