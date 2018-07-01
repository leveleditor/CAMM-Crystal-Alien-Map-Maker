Public Class UnitEditMode
    Inherits EditMode

    'The currently active selection.
    Public ReadOnly ActiveUnit As Unit

    Public Sub New(editor As FrmEditor)
        MyBase.New(editor)
        ActiveToolMode = ToolMode.Brush
        ActiveUnit = New Unit(0, 0)
    End Sub

    Public Overrides ReadOnly Property ShowContextMenu As Boolean
        Get
            Return ActiveToolMode = ToolMode.Pointer
        End Get
    End Property

    Public Overrides Sub PerformMouseAction(mouseX As Integer, mouseY As Integer, mouseXNoSnap As Integer, mouseYNoSnap As Integer, initialAction As Boolean, isMouseDown As Boolean)
        If ActiveToolMode = ToolMode.Pointer Then
            Editor.ActiveMap.ClosestUnit = Editor.ActiveMap.GetClosestUnit(mouseXNoSnap, mouseYNoSnap, 30)
        End If

        If initialAction Or isMouseDown Then
            If ActiveToolMode = ToolMode.Pointer Then
                If initialAction Then
                    Editor.ActiveMap.SelectedUnit = Editor.ActiveMap.ClosestUnit
                Else
                    If Editor.ActiveMap.SelectedUnit IsNot Nothing Then
                        Dim newPos As Point = New Point(
                            Clamp(mouseXNoSnap, 0, Editor.ActiveMap.SizeX * TileSizeX),
                            Clamp(mouseYNoSnap, Editor.ActiveMap.SelectedUnit.Altitude, Editor.ActiveMap.SizeY * TileSizeY)
                        )
                        If Editor.ActiveMap.GetClosestUnit(newPos.X, newPos.Y - Editor.ActiveMap.SelectedUnit.Altitude, 0) Is Nothing Then
                            Editor.ActiveMap.SelectedUnit.Position = newPos
                        End If
                    End If
                End If
            ElseIf ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                Editor.ActiveMap.EraseUnits(mouseXNoSnap, mouseYNoSnap)
            ElseIf ActiveToolMode = ToolMode.Brush And ActiveUnit.UnitId <> "" Then
                'No click & drag for units, just imagine the spam...
                If initialAction Then
                    If mouseYNoSnap - ActiveUnit.Altitude > 0 Then
                        Editor.ActiveMap.SetUnit(mouseXNoSnap, mouseYNoSnap, ActiveUnit)
                    End If
                End If
            End If
        End If
    End Sub

    Public Overrides Sub PerformMouseRelease(mouseX As Integer, mouseY As Integer, mouseXNoSnap As Integer, mouseYNoSnap As Integer)
        'Nothing to do.
    End Sub

    Public Overrides Sub Draw(g As Graphics, mouseX As Integer, mouseY As Integer, mouseXNoSnap As Integer, mouseYNoSnap As Integer, isMouseDown As Boolean)
        If Editor.IsMouseInBounds() Then
            If ActiveToolMode = ToolMode.Pointer Then
                If Editor.ActiveMap.ClosestUnit IsNot Nothing Then
                    If Editor.DrawTeamIndicators Then
                        Editor.ActiveMap.ClosestUnit.DrawTeamIndicator(g)
                    End If
                    g.DrawImage(UnitSelectionHover, Editor.ActiveMap.ClosestUnit.X - CInt(UnitSelectionHover.Width / 2), Editor.ActiveMap.ClosestUnit.Y - Editor.ActiveMap.ClosestUnit.Altitude - CInt(UnitSelectionHover.Height / 2), UnitSelectionHover.Width, UnitSelectionHover.Height)
                End If
            ElseIf ActiveToolMode = ToolMode.Eraser Or My.Computer.Keyboard.CtrlKeyDown Then
                g.DrawEllipse(PenTileErase, mouseXNoSnap - 30, mouseYNoSnap - 30, 60, 60)
            ElseIf ActiveToolMode = ToolMode.Brush And ActiveUnit.UnitId <> "" And Not isMouseDown Then
                If mouseYNoSnap - ActiveUnit.Altitude > 0 Then
                    ActiveUnit.Draw(g, mouseXNoSnap, mouseYNoSnap, Editor.DrawShadows)
                Else
                    g.DrawLine(New Pen(Color.Red, 2), mouseXNoSnap - 5, mouseYNoSnap - 5, mouseXNoSnap + 5, mouseYNoSnap + 5)
                    g.DrawLine(New Pen(Color.Red, 2), mouseXNoSnap + 5, mouseYNoSnap - 5, mouseXNoSnap - 5, mouseYNoSnap + 5)
                End If
            End If
        End If

        If ActiveToolMode = ToolMode.Pointer Then
            If Editor.ActiveMap.SelectedUnit IsNot Nothing Then
                If Editor.DrawTeamIndicators Then
                    Editor.ActiveMap.SelectedUnit.DrawTeamIndicator(g)
                End If
                g.DrawImage(UnitSelectionClick, Editor.ActiveMap.SelectedUnit.X - CInt(UnitSelectionHover.Width / 2), Editor.ActiveMap.SelectedUnit.Y - Editor.ActiveMap.SelectedUnit.Altitude - CInt(UnitSelectionHover.Height / 2), UnitSelectionHover.Width, UnitSelectionHover.Height)
                'g.DrawString(Editor.ActiveMap.SelectedUnit.UnitId, New Font(FontFamily.GenericMonospace, 12, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.GreenYellow, Editor.ActiveMap.SelectedUnit.X + 10, Editor.ActiveMap.SelectedUnit.Y - Editor.ActiveMap.SelectedUnit.Altitude - 10)
            End If
        End If
    End Sub

End Class
