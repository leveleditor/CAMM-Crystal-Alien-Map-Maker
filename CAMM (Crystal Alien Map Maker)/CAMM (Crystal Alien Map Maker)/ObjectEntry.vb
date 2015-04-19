Public Class ObjectEntry

    Public Event BtnNewClicked(sender As ObjectEntry, e As EventArgs)
    Public Event BtnRemoveClicked(sender As ObjectEntry, e As EventArgs)
    Public Event BtnBrowseClicked(sender As ObjectEntry, e As EventArgs)
    Public Event TxtImageUrlMouseEntered(sender As ObjectEntry, e As EventArgs)
    Public Event TxtImageUrlMouseLeft(sender As ObjectEntry, e As EventArgs)

    Public Property ObjectId As String
        Get
            Return txtObjectID.Text
        End Get
        Set(value As String)
            txtObjectID.Text = value
        End Set
    End Property

    Public Property ObjWidth As Integer
        Get
            Return txtWidth.Text
        End Get
        Set(value As Integer)
            txtWidth.Text = value
        End Set
    End Property

    Public Property ObjHeight As Integer
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

    Public Property Angle As Single
        Get
            Return txtAngle.Text
        End Get
        Set(value As Single)
            txtAngle.Text = value
        End Set
    End Property

    Public Property Damage As Single
        Get
            Return txtDamage.Text
        End Get
        Set(value As Single)
            txtDamage.Text = value
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
    Public Sub New(objectId As String, width As Integer, height As Integer, team As Team, angle As Single, damage As Single, offsetY As Integer, imageUrl As String)
        InitializeComponent()
        Me.cboTeam.SelectedIndex = 0
        Me.ObjectId = objectId
        Me.ObjWidth = width
        Me.ObjHeight = height
        Me.Team = team
        Me.Angle = angle
        Me.Damage = damage
        Me.OffSetY = offsetY
        Me.ImageUrl = imageUrl
    End Sub

End Class
