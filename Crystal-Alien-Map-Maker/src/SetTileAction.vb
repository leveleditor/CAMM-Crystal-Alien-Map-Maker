Public Class SetTileAction
    Inherits EditorAction

    Private mouseX As Integer
    Private mouseY As Integer
    Private tile As Tile

    Private prevTile As Tile

    Public Sub New(mouseX As Integer, mouseY As Integer, tile As Tile)
        Me.mouseX = mouseX
        Me.mouseY = mouseY
        Me.tile = New Tile(tile.TileId, tile.IsPassable, tile.IsMinerals)
        prevTile = Nothing
    End Sub

    Overrides Sub InitializeContext(timeline As ActionTimeline)
        MyBase.InitializeContext(timeline)
        If prevTile Is Nothing Then
            prevTile = timeline.Map.GetTileAt(mouseX, mouseY)
        End If
    End Sub

    Public Overrides Function WillMakeChanges() As Boolean
        If prevTile Is Nothing Then
            Return False
        End If

        If prevTile IsNot Nothing And tile IsNot Nothing Then
            If prevTile.TileId <> tile.TileId Then
                Return True
            End If
        End If

        Return False
    End Function

    Public Overrides Sub PerformAction()
        Timeline.Map.SetTile(mouseX, mouseY, tile)
    End Sub

    Public Overrides Sub UndoAction()
        Timeline.Map.SetTile(mouseX, mouseY, prevTile)
    End Sub
End Class
