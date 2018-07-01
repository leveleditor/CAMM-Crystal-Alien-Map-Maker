Public Class TileEditMode
    Inherits EditMode

    'The currently active selection.
    Public ReadOnly ActiveTile As Tile

    'Starting point for the rectangle brush selection.
    Private rectSelectStartX As Integer
    Private rectSelectStartY As Integer

    Public Sub New(editor As FrmEditor)
        MyBase.New(editor)
        ActiveToolMode = ToolMode.Brush
        ActiveTile = New Tile()
        rectSelectStartX = -1
        rectSelectStartY = -1
    End Sub

    Public Overrides ReadOnly Property ShowContextMenu As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides Sub PerformMouseAction(mouseX As Integer, mouseY As Integer, mouseXNoSnap As Integer, mouseYNoSnap As Integer, initialAction As Boolean, isMouseDown As Boolean)
        If initialAction Or isMouseDown Then
            If ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Or (ActiveTile.TileId = -1 And ActiveToolMode = ToolMode.Brush) Then
                Editor.ActiveMap.EraseTile(mouseX, mouseY)
            ElseIf ActiveToolMode = ToolMode.RectangleBrush Then
                If initialAction Then
                    rectSelectStartX = mouseX
                    rectSelectStartY = mouseY
                End If
            ElseIf ActiveToolMode = ToolMode.SmartBrush Then
                Editor.ActiveMap.SetTileSmart(mouseX, mouseY)
            ElseIf ActiveToolMode = ToolMode.Brush Then
                Editor.ActiveMap.SetTile(mouseX, mouseY, ActiveTile)
            End If
        End If
    End Sub

    Public Overrides Sub PerformMouseRelease(mouseX As Integer, mouseY As Integer, mouseXNoSnap As Integer, mouseYNoSnap As Integer)
        If ActiveToolMode = ToolMode.RectangleBrush And Not My.Computer.Keyboard.CtrlKeyDown And rectSelectStartX <> -1 And rectSelectStartY <> -1 Then
            Dim startx, starty, endx, endy As Single
            startx = rectSelectStartX
            starty = rectSelectStartY
            endx = mouseX
            endy = mouseY
            Dim rect As Rectangle = New Rectangle(
                Math.Min(startx, endx),
                Math.Min(starty, endy),
                Math.Abs(endx - startx),
                Math.Abs(endy - starty)
            )
            'Fill the selected rectangle with the data from the selected brush preset.
            Editor.ActiveMap.SetTileRectangle(rect.X, rect.Y, rect.Right, rect.Bottom, Editor.SelectedRectangleBrushPreset)

            'Reset starting point for rectangle brush selection.
            rectSelectStartX = -1
            rectSelectStartY = -1
        End If
    End Sub

    Public Overrides Sub Draw(g As Graphics, mouseX As Integer, mouseY As Integer, mouseXNoSnap As Integer, mouseYNoSnap As Integer, isMouseDown As Boolean)
        If Editor.IsMouseInBounds() Then
            If ActiveToolMode = ToolMode.Pointer Then
                'Nothing to do.
            ElseIf ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Or (ActiveTile.TileId = -1 And ActiveToolMode = ToolMode.Brush) Then
                g.DrawRectangle(PenTileErase, mouseX - (PenTileHover.Width / 2), mouseY - (PenTileHover.Width / 2), TileSizeX + PenTileHover.Width + 1, TileSizeY + PenTileHover.Width + 1)
            ElseIf ActiveToolMode = ToolMode.RectangleBrush And rectSelectStartX <> -1 And rectSelectStartY <> -1 Then
                Dim startx, starty, endx, endy As Single
                If rectSelectStartX <= mouseX Then
                    startx = rectSelectStartX
                    endx = mouseX + TileSizeX
                Else
                    startx = rectSelectStartX + TileSizeX
                    endx = mouseX
                End If
                If rectSelectStartY <= mouseY Then
                    starty = rectSelectStartY
                    endy = mouseY + TileSizeY
                Else
                    starty = rectSelectStartY + TileSizeY
                    endy = mouseY
                End If
                Dim rect As Rectangle = New Rectangle(
                            Math.Min(startx, endx),
                            Math.Min(starty, endy),
                            Math.Abs(endx - startx),
                            Math.Abs(endy - starty)
                        )
                Dim o1, o2 As Single
                o1 = (PenTileHover.Width / 2)
                o2 = PenTileHover.Width
                g.DrawRectangle(PenTileHover, rect.X - o1, rect.Y - o1, rect.Width + PenTileHover.Width + 1, rect.Height + PenTileHover.Width + 1)
                g.DrawRectangle(PenTileHover, rect.X + o2, rect.Y + o2, rect.Width - PenTileHover.Width - 1, rect.Height - PenTileHover.Width - 1)
            Else
                g.DrawRectangle(PenTileHover, mouseX - (PenTileHover.Width / 2), mouseY - (PenTileHover.Width / 2), TileSizeX + PenTileHover.Width + 1, TileSizeY + PenTileHover.Width + 1)
            End If
        End If
    End Sub

End Class
