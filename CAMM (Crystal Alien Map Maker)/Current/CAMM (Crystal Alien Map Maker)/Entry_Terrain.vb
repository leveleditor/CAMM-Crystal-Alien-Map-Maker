Public Class Entry_Terrain

    Public Event CMDNew_Clicked(ByVal sender As Entry_Terrain, ByVal e As System.EventArgs)
    Public Event CMDRemove_Clicked(ByVal sender As Entry_Terrain, ByVal e As System.EventArgs)
    Public Event CMDBrowse_Clicked(ByVal sender As Entry_Terrain, ByVal e As System.EventArgs)
    Public Event TXTImageUrl_MouseEntered(ByVal sender As Entry_Terrain, ByVal e As System.EventArgs)
    Public Event TXTImageUrl_MouseLeft(ByVal sender As Entry_Terrain, ByVal e As System.EventArgs)

    Public Property TerrainID() As String
        Get
            Return TXTTerrainID.Text
        End Get
        Set(ByVal value As String)
            TXTTerrainID.Text = value
        End Set
    End Property

    Public Property IsPassable() As Boolean
        Get
            Return CHKIsPassable.Checked
        End Get
        Set(ByVal value As Boolean)
            CHKIsPassable.Checked = value
        End Set
    End Property

    Public Property IsMinerals() As Boolean
        Get
            Return CHKIsMinerals.Checked
        End Get
        Set(ByVal value As Boolean)
            CHKIsMinerals.Checked = value
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
    End Sub
    Public Sub New(ByVal TerrainID As String, ByVal IsPassable As Boolean, ByVal IsMinerals As Boolean, ByVal ImageUrl As String)
        InitializeComponent()
        Me.TerrainID = TerrainID
        Me.IsPassable = IsPassable
        Me.IsMinerals = IsMinerals
        Me.ImageUrl = ImageUrl
    End Sub

End Class
