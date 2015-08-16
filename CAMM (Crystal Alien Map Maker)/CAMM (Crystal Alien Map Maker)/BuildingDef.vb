Public Class BuildingDef

    Public Sub New(buildingId As String, width As Integer, height As Integer, team As Team, offsetY As Integer, fullImageUrl As String, shadowImageUrl As String)
        Me.BuildingId = buildingId
        Me.BuildingW = width
        Me.BuildingH = height
        Me.Team = team
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
            If Not String.IsNullOrEmpty(BuildingId) Then
                Return BuildingSmallImageLookup(BuildingId)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Property BuildingId As String

    Public Property BuildingW As Integer

    Public Property BuildingH As Integer

    Public Property Team As Team

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
        g.DrawImage(ButtonOverlay, drawX, drawY, ButtonOverlay.Width, ButtonOverlay.Height)
    End Sub

End Class
