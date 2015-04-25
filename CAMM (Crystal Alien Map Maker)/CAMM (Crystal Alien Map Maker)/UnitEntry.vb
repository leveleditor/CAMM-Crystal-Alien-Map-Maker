Public Class UnitEntry

    Public Event BtnNewClicked(sender As UnitEntry, e As EventArgs)
    Public Event BtnRemoveClicked(sender As UnitEntry, e As EventArgs)
    Public Event BtnBrowseClicked(sender As UnitEntry, e As EventArgs)
    Public Event TxtImageUrlMouseEntered(sender As UnitEntry, e As EventArgs)
    Public Event TxtImageUrlMouseLeft(sender As UnitEntry, e As EventArgs)

    Public Property UnitId As String
        Get
            Return txtObjectID.Text
        End Get
        Set(value As String)
            txtObjectID.Text = value
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

    Public Property OffSetY As Integer
        Get
            Return txtOffsetY.Text
        End Get
        Set(value As Integer)
            txtOffsetY.Text = value
        End Set
    End Property

    Public Property ImageUrl As String
        Get
            Return txtImageUrl.Text
        End Get
        Set(value As String)
            txtImageUrl.Text = value
        End Set
    End Property

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        RaiseEvent BtnNewClicked(Me, e)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        RaiseEvent BtnRemoveClicked(Me, e)
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        RaiseEvent BtnBrowseClicked(Me, e)
    End Sub

    Private Sub txtImageUrl_MouseEnter(sender As Object, e As EventArgs) Handles txtImageUrl.MouseEnter
        RaiseEvent TxtImageUrlMouseEntered(Me, e)
    End Sub

    Private Sub txtImageUrl_MouseLeave(sender As Object, e As EventArgs) Handles txtImageUrl.MouseLeave
        RaiseEvent TxtImageUrlMouseLeft(Me, e)
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.cboTeam.SelectedIndex = 0
        txtOffsetY.Text = "0"
    End Sub
    Public Sub New(unitId As String, team As Team, offsetY As Integer, imageUrl As String)
        InitializeComponent()
        Me.cboTeam.SelectedIndex = 0
        Me.UnitId = unitId
        Me.Team = team
        Me.OffSetY = offsetY
        Me.ImageUrl = imageUrl
    End Sub

End Class
