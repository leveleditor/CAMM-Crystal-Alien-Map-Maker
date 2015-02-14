Public Class Entry_Object

    Public Event CMDNew_Clicked(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
    Public Event CMDRemove_Clicked(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
    Public Event CMDBrowse_Clicked(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
    Public Event TXTImageUrl_MouseEntered(ByVal sender As Entry_Object, ByVal e As System.EventArgs)
    Public Event TXTImageUrl_MouseLeft(ByVal sender As Entry_Object, ByVal e As System.EventArgs)

    Public Property ObjectID() As String
        Get
            Return TXTObjectID.Text
        End Get
        Set(ByVal value As String)
            TXTObjectID.Text = value
        End Set
    End Property

    Public Property ObjWidth() As Integer
        Get
            Return TXTWidth.Text
        End Get
        Set(ByVal value As Integer)
            TXTWidth.Text = value
        End Set
    End Property

    Public Property ObjHeight() As Integer
        Get
            Return TXTHeight.Text
        End Get
        Set(ByVal value As Integer)
            TXTHeight.Text = value
        End Set
    End Property

    Public Property Team() As Team
        Get
            Return CType(CBOTeam.SelectedIndex, Team)
        End Get
        Set(ByVal value As Team)
            CBOTeam.SelectedIndex = CInt(value)
        End Set
    End Property

    Public Property Angle() As Single
        Get
            Return TXTAngle.Text
        End Get
        Set(ByVal value As Single)
            TXTAngle.Text = value
        End Set
    End Property

    Public Property Damage() As Single
        Get
            Return TXTDamage.Text
        End Get
        Set(ByVal value As Single)
            TXTDamage.Text = value
        End Set
    End Property

    Public Property OffSetY() As Integer
        Get
            Return TXTOffsetY.Text
        End Get
        Set(ByVal value As Integer)
            TXTOffsetY.Text = value
        End Set
    End Property

    Public Property ImageUrl() As String
        Get
            Return TXTImageUrl.Text
        End Get
        Set(ByVal value As String)
            TXTImageUrl.Text = value
        End Set
    End Property

    Private Sub CMDNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDNew.Click
        RaiseEvent CMDNew_Clicked(Me, e)
    End Sub

    Private Sub CMDRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDRemove.Click
        RaiseEvent CMDRemove_Clicked(Me, e)
    End Sub

    Private Sub CMDBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBrowse.Click
        RaiseEvent CMDBrowse_Clicked(Me, e)
    End Sub

    Private Sub TXTImageUrl_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTImageUrl.MouseEnter
        RaiseEvent TXTImageUrl_MouseEntered(Me, e)
    End Sub

    Private Sub TXTImageUrl_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTImageUrl.MouseLeave
        RaiseEvent TXTImageUrl_MouseLeft(Me, e)
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.CBOTeam.SelectedIndex = 0
        TXTOffsetY.Text = "0"
    End Sub
    Public Sub New(ByVal ObjectID As String, ByVal Width As Integer, ByVal Height As Integer, ByVal Team As Team, ByVal Angle As Single, ByVal Damage As Single, ByVal OffsetY As Integer, ByVal ImageUrl As String)
        InitializeComponent()
        Me.CBOTeam.SelectedIndex = 0
        Me.ObjectID = ObjectID
        Me.ObjWidth = Width
        Me.ObjHeight = Height
        Me.Team = Team
        Me.Angle = Angle
        Me.Damage = Damage
        Me.OffSetY = OffsetY
        Me.ImageUrl = ImageUrl
    End Sub

End Class
