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
        Me.Angle = Clamp(angle, 0, 1)
        Me.Damage = Clamp(damage, 0, 1)
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

    Public ReadOnly Property ShadowImage As Image
        Get
            If Not String.IsNullOrEmpty(BuildingId) Then
                Return BuildingShadowImageLookup(BuildingId)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property TeamIndicatorImage As Image
        Get
            If Team = Team.Astros Then
                Return TeamIndicatorAstro
            ElseIf Team = Team.Aliens Then
                Return TeamIndicatorAlien
            Else
                Return TeamIndicatorNeutral
            End If
        End Get
    End Property

    Public ReadOnly Property BaseplateImage As Image
        Get
            If Team = Team.Astros And BuildingW = 1 Then
                Return BaseplateAstroSmall
            ElseIf Team = Team.Aliens And BuildingW = 1 Then
                Return BaseplateAlienSmall
            ElseIf Team = Team.Astros Then
                Return BaseplateAstroWide
            ElseIf Team = Team.Aliens Then
                Return BaseplateAlienWide
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

    Public Sub DrawThumbnail(g As Graphics, Optional drawButtonImage As Boolean = False)
        If drawButtonImage Then
            If Team = Team.Astros Then
                g.DrawImage(ButtonAstro, X, Y, ButtonAstro.Width, ButtonAstro.Height)
            ElseIf Team = Team.Aliens Then
                g.DrawImage(ButtonAlien, X, Y, ButtonAlien.Width, ButtonAlien.Height)
            Else
                g.DrawImage(ButtonNeutral, X, Y, ButtonNeutral.Width, ButtonNeutral.Height)
            End If
        End If
        g.DrawImage(SmallImage, X, Y, SmallImage.Width, SmallImage.Height)
        g.DrawImage(ButtonOverlay, X, Y, ButtonOverlay.Width, ButtonOverlay.Height)
    End Sub

    Public Sub Draw(g As Graphics, Optional drawShadows As Boolean = False)
        If drawShadows Then
            DrawShadow(g)
        End If

        g.DrawImage(FullImage, DrawPos.X, DrawPos.Y, FullImage.Width, FullImage.Height)
    End Sub

    Public Sub Draw(g As Graphics, drawX As Integer, drawY As Integer, Optional drawShadows As Boolean = False)
        If drawShadows Then
            DrawShadow(g, DrawPos.X + drawX, DrawPos.Y + drawY)
        End If

        g.DrawImage(FullImage, DrawPos.X + drawX, DrawPos.Y + drawY, FullImage.Width, FullImage.Height)
    End Sub

    Public Sub DrawShadow(g As Graphics)
        g.DrawImage(ShadowImage, DrawPos.X, DrawPos.Y, ShadowImage.Width, ShadowImage.Height)
    End Sub

    Public Sub DrawShadow(g As Graphics, drawX As Integer, drawY As Integer)
        g.DrawImage(ShadowImage, drawX, drawY, ShadowImage.Width, ShadowImage.Height)
    End Sub

    Public Sub DrawBaseplate(g As Graphics)
        If BaseplateImage IsNot Nothing Then
            Dim drawPoint As Point = Location

            drawPoint.X = X - (BaseplateImage.Width / 2) + TileSizeX

            If BuildingW > 1 Then
                drawPoint.X += (BuildingW * TileSizeX) / 2
                drawPoint.X -= TileSizeX
            Else
                drawPoint.X -= TileSizeX / 2
            End If
            If BuildingH > 1 Then
                drawPoint.Y += (BuildingH * TileSizeY) - TileSizeY
            End If
            drawPoint.Y -= TileSizeY + 10

            g.DrawImage(BaseplateImage, drawPoint.X, drawPoint.Y, BaseplateImage.Width, BaseplateImage.Height)
        End If
    End Sub

    Public Sub DrawBaseplate(g As Graphics, drawX As Integer, drawY As Integer)
        If BaseplateImage IsNot Nothing Then
            Dim drawPoint As Point = Location
            If BuildingW > 1 Then
                drawPoint.X += (BuildingW * TileSizeX) / 2
                drawPoint.X -= TileSizeX
            Else
                drawPoint.X -= TileSizeX / 2
            End If
            If BuildingH > 1 Then
                drawPoint.Y += (BuildingH * TileSizeY) - TileSizeY
            End If
            drawPoint.Y -= TileSizeY + 10

            g.DrawImage(BaseplateImage, drawPoint.X + drawX, drawPoint.Y + drawY, BaseplateImage.Width, BaseplateImage.Height)
        End If
    End Sub

    Public Sub DrawTeamIndicator(g As Graphics)
        g.DrawImage(TeamIndicatorImage,
                    (X + (BuildingW * TileSizeX) * 0.5f) - CInt(TeamIndicatorImage.Width / 2),
                    (Y + (BuildingH * TileSizeY) * 0.5f) - CInt(TeamIndicatorImage.Height / 2),
                    TeamIndicatorImage.Width,
                    TeamIndicatorImage.Height)
    End Sub

End Class
