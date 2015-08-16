Public Class BuildingEntry

    Public Event BtnNewClicked(sender As BuildingEntry, e As EventArgs)
    Public Event BtnRemoveClicked(sender As BuildingEntry, e As EventArgs)
    Public Event BtnBrowseFullImageClicked(sender As BuildingEntry, e As EventArgs)
    Public Event BtnBrowseShadowImageClicked(sender As BuildingEntry, e As EventArgs)
    Public Event TxtFullImageUrlMouseEntered(sender As BuildingEntry, e As EventArgs)
    Public Event TxtFullImageUrlMouseLeft(sender As BuildingEntry, e As EventArgs)
    Public Event TxtShadowImageUrlMouseEntered(sender As BuildingEntry, e As EventArgs)
    Public Event TxtShadowImageUrlMouseLeft(sender As BuildingEntry, e As EventArgs)

    Public Property BuildingId As String
        Get
            Return txtBuildingId.Text
        End Get
        Set(value As String)
            txtBuildingId.Text = value
        End Set
    End Property

    Public Property BuildingW As Integer
        Get
            Return txtWidth.Text
        End Get
        Set(value As Integer)
            txtWidth.Text = value
        End Set
    End Property

    Public Property BuildingH As Integer
        Get
            Return txtHeight.Text
        End Get
        Set(value As Integer)
            txtHeight.Text = value
        End Set
    End Property

    Public Property Team As Team
        Get
            Return CType(cboTeam.SelectedIndex, Team)
        End Get
        Set(value As Team)
            cboTeam.SelectedIndex = CInt(value)
        End Set
    End Property

    Public Property OffsetY As Integer
        Get
            Return txtOffsetY.Text
        End Get
        Set(value As Integer)
            txtOffsetY.Text = value
        End Set
    End Property

    Public Property FullImageUrl As String
        Get
            Return txtFullImageUrl.Text
        End Get
        Set(value As String)
            txtFullImageUrl.Text = value
        End Set
    End Property

    Public Property ShadowImageUrl As String
        Get
            Return txtShadowImageUrl.Text
        End Get
        Set(value As String)
            txtShadowImageUrl.Text = value
        End Set
    End Property

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        RaiseEvent BtnNewClicked(Me, e)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        RaiseEvent BtnRemoveClicked(Me, e)
    End Sub

    Private Sub btnBrowseFullImage_Click(sender As Object, e As EventArgs) Handles btnBrowseFullImage.Click
        RaiseEvent BtnBrowseFullImageClicked(Me, e)
    End Sub

    Private Sub btnBrowseShadowImage_Click(sender As Object, e As EventArgs) Handles btnBrowseShadowImage.Click
        RaiseEvent BtnBrowseShadowImageClicked(Me, e)
    End Sub

    Private Sub txtFullImageUrl_MouseEnter(sender As Object, e As EventArgs) Handles txtFullImageUrl.MouseEnter
        RaiseEvent TxtFullImageUrlMouseEntered(Me, e)
    End Sub

    Private Sub txtFullImageUrl_MouseLeave(sender As Object, e As EventArgs) Handles txtFullImageUrl.MouseLeave
        RaiseEvent TxtFullImageUrlMouseLeft(Me, e)
    End Sub

    Private Sub txtShadowImageUrl_MouseEnter(sender As Object, e As EventArgs) Handles txtShadowImageUrl.MouseEnter
        RaiseEvent TxtShadowImageUrlMouseEntered(Me, e)
    End Sub

    Private Sub txtShadowImageUrl_MouseLeave(sender As Object, e As EventArgs) Handles txtShadowImageUrl.MouseLeave
        RaiseEvent TxtShadowImageUrlMouseLeft(Me, e)
    End Sub

    Public Sub New()
        Me.New("", 1, 1, Team.Astros, 0, "", "")
    End Sub
    Public Sub New(buildingId As String, width As Integer, height As Integer, team As Team, offsetY As Integer, fullImageUrl As String, shadowImageUrl As String)
        InitializeComponent()
        Me.cboTeam.SelectedIndex = 0
        Me.BuildingId = buildingId
        Me.BuildingW = width
        Me.BuildingH = height
        Me.Team = team
        Me.OffsetY = offsetY
        Me.FullImageUrl = fullImageUrl
        Me.ShadowImageUrl = shadowImageUrl
    End Sub

End Class
