Public Class UnitDef

    Public Sub New(unitId As String, team As Team, altitude As Integer, isPickup As Boolean, offsetY As Integer, fullImageUrl As String, shadowImageUrl As String)
        Me.UnitId = unitId
        Me.Team = team
        Me.Altitude = altitude
        Me.IsPickup = isPickup
        Me.OffsetY = offsetY
        Me.FullImageUrl = fullImageUrl
        Me.ShadowImageUrl = shadowImageUrl
    End Sub

    Public ReadOnly Property HasData As Boolean
        Get
            Return SmallImage IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property SmallImage As Image
        Get
            If Not String.IsNullOrEmpty(UnitId) Then
                Return UnitSmallImageLookup(UnitId)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Property UnitId As String

    Public Property Team As Team

    Public Property Altitude As Integer

    Public Property IsPickup As Boolean

    Public Property OffsetY As Integer

    Public Property FullImageUrl As String

    Public Property ShadowImageUrl As String

    Public Sub DrawThumbnail(g As Graphics, drawX As Integer, drawY As Integer, Optional drawButtonImage As Boolean = False)
        If drawButtonImage Then
            If Team = Team.Astros Then
                g.DrawImage(ButtonAstro, drawX, drawY, ButtonAstro.Width, ButtonAstro.Height)
            ElseIf Team = Team.Aliens Then
                g.DrawImage(ButtonAlien, drawX, drawY, ButtonAlien.Width, ButtonAlien.Height)
            Else
                g.DrawImage(ButtonNeutral, drawX, drawY, ButtonNeutral.Width, ButtonNeutral.Height)
            End If
        End If

        g.DrawImage(SmallImage, drawX, drawY, SmallImage.Width, SmallImage.Height)
        'g.DrawImage(ButtonOverlay, X, Y, ButtonOverlay.Width, ButtonOverlay.Height)
    End Sub

End Class
