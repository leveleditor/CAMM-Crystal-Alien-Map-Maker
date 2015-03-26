Public Class ObjectEntry

    Public Event BtnNewClicked(ByVal sender As ObjectEntry, ByVal e As System.EventArgs)
    Public Event BtnRemoveClicked(ByVal sender As ObjectEntry, ByVal e As System.EventArgs)
    Public Event BtnBrowseClicked(ByVal sender As ObjectEntry, ByVal e As System.EventArgs)
    Public Event TxtImageUrlMouseEntered(ByVal sender As ObjectEntry, ByVal e As System.EventArgs)
    Public Event TxtImageUrlMouseLeft(ByVal sender As ObjectEntry, ByVal e As System.EventArgs)

    Public Property ObjectId() As String
        Get
            Return txtObjectID.Text
        End Get
        Set(ByVal value As String)
            txtObjectID.Text = value
        End Set
    End Property

    Public Property ObjWidth() As Integer
        Get
            Return txtWidth.Text
        End Get
        Set(ByVal value As Integer)
            txtWidth.Text = value
        End Set
    End Property

    Public Property ObjHeight() As Integer
        Get
            Return txtHeight.Text
        End Get
        Set(ByVal value As Integer)
            txtHeight.Text = value
        End Set
    End Property

    Public Property Team() As Team
        Get
            Return CType(cboTeam.SelectedIndex, Team)
        End Get
        Set(ByVal value As Team)
            cboTeam.SelectedIndex = CInt(value)
        End Set
    End Property

    Public Property Angle() As Single
        Get
            Return txtAngle.Text
        End Get
        Set(ByVal value As Single)
            txtAngle.Text = value
        End Set
    End Property

    Public Property Damage() As Single
        Get
            Return txtDamage.Text
        End Get
        Set(ByVal value As Single)
            txtDamage.Text = value
        End Set
    End Property

    Public Property OffSetY() As Integer
        Get
            Return txtOffsetY.Text
        End Get
        Set(ByVal value As Integer)
            txtOffsetY.Text = value
        End Set
    End Property

    Public Property ImageUrl() As String
        Get
            Return txtImageUrl.Text
        End Get
        Set(ByVal value As String)
            txtImageUrl.Text = value
        End Set
    End Property

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        RaiseEvent BtnNewClicked(Me, e)
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        RaiseEvent BtnRemoveClicked(Me, e)
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        RaiseEvent BtnBrowseClicked(Me, e)
    End Sub

    Private Sub txtImageUrl_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTImageUrl.MouseEnter
        RaiseEvent TxtImageUrlMouseEntered(Me, e)
    End Sub

    Private Sub txtImageUrl_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTImageUrl.MouseLeave
        RaiseEvent TxtImageUrlMouseLeft(Me, e)
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.cboTeam.SelectedIndex = 0
        txtOffsetY.Text = "0"
    End Sub
    Public Sub New(ByVal objectId As String, ByVal width As Integer, ByVal height As Integer, ByVal team As Team, ByVal angle As Single, ByVal damage As Single, ByVal offsetY As Integer, ByVal imageUrl As String)
        InitializeComponent()
        Me.cboTeam.SelectedIndex = 0
        Me.ObjectId = objectId
        Me.ObjWidth = width
        Me.ObjHeight = height
        Me.Team = team
        Me.Angle = angle
        Me.Damage = damage
        Me.OffSetY = offsetY
        Me.ImageUrl = ImageUrl
    End Sub

End Class
