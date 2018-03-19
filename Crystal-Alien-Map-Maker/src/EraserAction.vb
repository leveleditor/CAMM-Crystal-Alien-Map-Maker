Public Class EraserAction
    Inherits EditorAction

    Private mouseX As Integer
    Private mouseY As Integer
    Private mode As EditMode

    Private prevTile As Tile

    Public Sub New(mouseX As Integer, mouseY As Integer, mode As EditMode)
        Me.mouseX = mouseX
        Me.mouseY = mouseY
        Me.mode = mode
        prevTile = Nothing
    End Sub

    Overrides Sub InitializeContext(timeline As ActionTimeline)
        MyBase.InitializeContext(timeline)
        Select Case mode
            Case EditMode.Tiles
                prevTile = timeline.Map.GetTileAt(mouseX, mouseY)
            Case EditMode.Buildings
                Throw New NotImplementedException()
            Case EditMode.Units
                Throw New NotImplementedException()
        End Select
    End Sub

    Public Overrides Function WillMakeChanges() As Boolean
        If prevTile Is Nothing Then
            Return False
        End If

        If prevTile IsNot Nothing And mode = EditMode.Tiles Then
            If prevTile.TileId <> -1 Then
                Return True
            End If
        End If

        Return False
    End Function

    Public Overrides Sub PerformAction()
        Timeline.Map.Eraser(mouseX, mouseY, mode)
    End Sub

    Public Overrides Sub UndoAction()
        Select Case mode
            Case EditMode.Tiles
                Timeline.Map.SetTile(mouseX, mouseY, prevTile)
            Case EditMode.Buildings
                Throw New NotImplementedException()
            Case EditMode.Units
                Throw New NotImplementedException()
        End Select
    End Sub
End Class
