Public Class UnitEntry

    Public Event BtnNewClicked(sender As UnitEntry, e As EventArgs)
    Public Event BtnRemoveClicked(sender As UnitEntry, e As EventArgs)
    Public Event BtnBrowseFullImageClicked(sender As UnitEntry, e As EventArgs)
    Public Event BtnBrowseShadowImageClicked(sender As UnitEntry, e As EventArgs)
    Public Event TxtFullImageUrlMouseEntered(sender As UnitEntry, e As EventArgs)
    Public Event TxtFullImageUrlMouseLeft(sender As UnitEntry, e As EventArgs)
    Public Event TxtShadowImageUrlMouseEntered(sender As UnitEntry, e As EventArgs)
    Public Event TxtShadowImageUrlMouseLeft(sender As UnitEntry, e As EventArgs)

    Public Property UnitId As String
        Get
            Return txtUnitId.Text
        End Get
        Set(value As String)
            txtUnitId.Text = value
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

    Public Property Altitude As Integer
        Get
            Return CInt(txtAltitude.Text)
        End Get
        Set(value As Integer)
            txtAltitude.Text = value.ToString()
        End Set
    End Property

    Public Property IsPickup As Boolean
        Get
            Return chkIsPickup.Checked
        End Get
        Set(value As Boolean)
            chkIsPickup.Checked = value
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

    Private Sub txtFullImageUrl_MouseEnter(sender As Object, e As EventArgs) Handles txtFullImageUrl.MouseEnter
        RaiseEvent TxtFullImageUrlMouseEntered(Me, e)
    End Sub

    Private Sub txtFullImageUrl_MouseLeave(sender As Object, e As EventArgs) Handles txtFullImageUrl.MouseLeave
        RaiseEvent TxtFullImageUrlMouseLeft(Me, e)
    End Sub

    Private Sub btnBrowseShadowImage_Click(sender As Object, e As EventArgs) Handles btnBrowseShadowImage.Click
        RaiseEvent BtnBrowseShadowImageClicked(Me, e)
    End Sub

    Private Sub txtShadowImageUrl_MouseEnter(sender As Object, e As EventArgs) Handles txtShadowImageUrl.MouseEnter
        RaiseEvent TxtShadowImageUrlMouseEntered(Me, e)
    End Sub

    Private Sub txtShadowImageUrl_MouseLeave(sender As Object, e As EventArgs) Handles txtShadowImageUrl.MouseLeave
        RaiseEvent TxtShadowImageUrlMouseLeft(Me, e)
    End Sub

    Public Sub New()
        Me.New("", Team.Astros, 0, False, 0, "", "")
    End Sub
    Public Sub New(unitId As String, team As Team, altitude As Integer, isPickup As Boolean, offsetY As Integer, fullImageUrl As String, shadowImageUrl As String)
        InitializeComponent()
        Me.cboTeam.SelectedIndex = 0
        Me.UnitId = unitId
        Me.Team = team
        Me.Altitude = altitude
        Me.IsPickup = isPickup
        Me.OffsetY = offsetY
        Me.FullImageUrl = fullImageUrl
        Me.ShadowImageUrl = shadowImageUrl
    End Sub

End Class
