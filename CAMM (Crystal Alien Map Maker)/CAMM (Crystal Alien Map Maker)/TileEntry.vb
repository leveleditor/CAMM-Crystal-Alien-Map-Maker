Public Class TileEntry

    Public Event BtnNewClicked(sender As TileEntry, e As System.EventArgs)
    Public Event BtnRemoveClicked(sender As TileEntry, e As System.EventArgs)
    Public Event BtnBrowseClicked(sender As TileEntry, e As System.EventArgs)
    Public Event TxtImageUrlMouseEntered(sender As TileEntry, e As System.EventArgs)
    Public Event TxtImageUrlMouseLeft(sender As TileEntry, e As System.EventArgs)

    Public Property TerrainId As String
        Get
            Return txtTerrainID.Text
        End Get
        Set(value As String)
            txtTerrainID.Text = value
        End Set
    End Property

    Public Property IsPassable As Boolean
        Get
            Return chkIsPassable.Checked
        End Get
        Set(value As Boolean)
            chkIsPassable.Checked = value
        End Set
    End Property

    Public Property IsMinerals As Boolean
        Get
            Return chkIsMinerals.Checked
        End Get
        Set(value As Boolean)
            chkIsMinerals.Checked = value
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

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        RaiseEvent BtnNewClicked(Me, e)
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        RaiseEvent BtnRemoveClicked(Me, e)
    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        RaiseEvent BtnBrowseClicked(Me, e)
    End Sub

    Private Sub txtImageUrl_MouseEnter(sender As Object, e As System.EventArgs) Handles txtImageUrl.MouseEnter
        RaiseEvent TxtImageUrlMouseEntered(Me, e)
    End Sub

    Private Sub txtImageUrl_MouseLeave(sender As Object, e As System.EventArgs) Handles txtImageUrl.MouseLeave
        RaiseEvent TxtImageUrlMouseLeft(Me, e)
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(terrainId As String, isPassable As Boolean, isMinerals As Boolean, imageUrl As String)
        InitializeComponent()
        Me.TerrainId = terrainId
        Me.IsPassable = isPassable
        Me.IsMinerals = isMinerals
        Me.ImageUrl = imageUrl
    End Sub

End Class
