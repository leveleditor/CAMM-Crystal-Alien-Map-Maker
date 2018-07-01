Public Class BuildingEditMode
    Inherits EditMode

    'The currently active selection.
    Public ReadOnly ActiveBuilding As Building

    Public Sub New(editor As FrmEditor)
        MyBase.New(editor)
        ActiveToolMode = ToolMode.Brush
        ActiveBuilding = New Building(0, 0)
    End Sub

    Public Overrides ReadOnly Property ShowContextMenu As Boolean
        Get
            Return ActiveToolMode = ToolMode.Pointer
        End Get
    End Property

    Public Overrides Sub PerformMouseAction(mouseX As Integer, mouseY As Integer, mouseXNoSnap As Integer, mouseYNoSnap As Integer, initialAction As Boolean, isMouseDown As Boolean)
        If ActiveToolMode = ToolMode.Pointer Then
            Editor.ActiveMap.ClosestBuilding = Editor.ActiveMap.GetBuildingAt(mouseX, mouseY)
        End If

        If initialAction Or isMouseDown Then
            If ActiveToolMode = ToolMode.Pointer Then
                If initialAction Then
                    Editor.ActiveMap.SelectedBuilding = Editor.ActiveMap.ClosestBuilding
                Else
                    If Editor.ActiveMap.SelectedBuilding IsNot Nothing Then
                        Dim newPos As Point = New Point(
                            Clamp(mouseX, 0, Editor.ActiveMap.SizeX * TileSizeX - TileSizeX),
                            Clamp(mouseY, 0, Editor.ActiveMap.SizeY * TileSizeY - TileSizeY)
                        )
                        If Editor.ActiveMap.GetBuildingAt(newPos.X, newPos.Y) Is Nothing Then
                            Editor.ActiveMap.SelectedBuilding.Location = newPos
                        End If
                    End If
                End If
            ElseIf ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                Editor.ActiveMap.EraseBuildings(mouseX, mouseY)
            ElseIf ActiveToolMode = ToolMode.Brush And ActiveBuilding.BuildingId <> "" Then
                Editor.ActiveMap.SetBuilding(mouseX, mouseY, ActiveBuilding)
            End If
        End If
    End Sub

    Public Overrides Sub PerformMouseRelease(mouseX As Integer, mouseY As Integer, mouseXNoSnap As Integer, mouseYNoSnap As Integer)
        'Nothing to do.
    End Sub

    Public Overrides Sub Draw(g As Graphics, mouseX As Integer, mouseY As Integer, mouseXNoSnap As Integer, mouseYNoSnap As Integer, isMouseDown As Boolean)
        If Editor.IsMouseInBounds() Then
            If ActiveToolMode = ToolMode.Pointer Then
                If Editor.ActiveMap.ClosestBuilding IsNot Nothing Then
                    g.FillRectangle(BrushBuildingSelectionHover, mouseX, mouseY, Editor.ActiveMap.ClosestBuilding.BuildingW * TileSizeX + 1, Editor.ActiveMap.ClosestBuilding.BuildingH * TileSizeY + 1)
                End If
            ElseIf ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                g.DrawRectangle(PenTileErase, mouseX - (PenTileHover.Width / 2), mouseY - (PenTileHover.Width / 2), TileSizeX + PenTileHover.Width + 1, TileSizeY + PenTileHover.Width + 1)
            ElseIf ActiveToolMode = ToolMode.Brush And ActiveBuilding.BuildingId <> "" Then
                g.FillRectangle(BrushBuildingPlacement, mouseX, mouseY, ActiveBuilding.BuildingW * TileSizeX + 1, ActiveBuilding.BuildingH * TileSizeY + 1)
            End If
        End If

        If ActiveToolMode = ToolMode.Pointer Then
            If Editor.ActiveMap.SelectedBuilding IsNot Nothing Then
                If Editor.DrawTeamIndicators Then
                    Editor.ActiveMap.SelectedBuilding.DrawTeamIndicator(g)
                End If
                g.FillRectangle(BrushBuildingSelected, Editor.ActiveMap.SelectedBuilding.X, Editor.ActiveMap.SelectedBuilding.Y, Editor.ActiveMap.SelectedBuilding.BuildingW * TileSizeX + 1, Editor.ActiveMap.SelectedBuilding.BuildingH * TileSizeY + 1)
                'g.DrawString(Editor.ActiveMap.SelectedBuilding.BuildingId, New Font(FontFamily.GenericMonospace, 12, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.GreenYellow, Editor.ActiveMap.SelectedBuilding.X, Editor.ActiveMap.SelectedBuilding.Y)
            End If
        End If
    End Sub

End Class
