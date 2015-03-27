Public Class TileEntry

    Public Event BtnNewClicked(ByVal sender As TileEntry, ByVal e As System.EventArgs)
    Public Event BtnRemoveClicked(ByVal sender As TileEntry, ByVal e As System.EventArgs)
    Public Event BtnBrowseClicked(ByVal sender As TileEntry, ByVal e As System.EventArgs)
    Public Event TxtImageUrlMouseEntered(ByVal sender As TileEntry, ByVal e As System.EventArgs)
    Public Event TxtImageUrlMouseLeft(ByVal sender As TileEntry, ByVal e As System.EventArgs)

    Public Property TerrainId() As String
        Get
            Return txtTerrainID.Text
        End Get
        Set(ByVal value As String)
            txtTerrainID.Text = value
        End Set
    End Property

    Public Property IsPassable() As Boolean
        Get
            Return chkIsPassable.Checked
        End Get
        Set(ByVal value As Boolean)
            chkIsPassable.Checked = value
        End Set
    End Property

    Public Property IsMinerals() As Boolean
        Get
            Return chkIsMinerals.Checked
        End Get
        Set(ByVal value As Boolean)
            chkIsMinerals.Checked = value
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

    Private Sub txtImageUrl_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImageUrl.MouseEnter
        RaiseEvent TxtImageUrlMouseEntered(Me, e)
    End Sub

    Private Sub txtImageUrl_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImageUrl.MouseLeave
        RaiseEvent TxtImageUrlMouseLeft(Me, e)
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal terrainId As String, ByVal isPassable As Boolean, ByVal isMinerals As Boolean, ByVal imageUrl As String)
        InitializeComponent()
        Me.TerrainId = terrainId
        Me.IsPassable = isPassable
        Me.IsMinerals = isMinerals
        Me.ImageUrl = imageUrl
    End Sub

End Class
