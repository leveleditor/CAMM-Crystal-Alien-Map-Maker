Public MustInherit Class EditMode

    Protected Editor As FrmEditor

    Public ActiveToolMode As ToolMode

    Public Sub New(editor As FrmEditor)
        Me.Editor = editor
    End Sub

    Public MustOverride ReadOnly Property ShowContextMenu As Boolean

    Public MustOverride Sub PerformMouseAction(mouseX As Integer, mouseY As Integer, mouseXNoSnap As Integer, mouseYNoSnap As Integer, initialAction As Boolean, isMouseDown As Boolean)
    Public MustOverride Sub PerformMouseRelease(mouseX As Integer, mouseY As Integer, mouseXNoSnap As Integer, mouseYNoSnap As Integer)
    Public MustOverride Sub Draw(g As Graphics, mouseX As Integer, mouseY As Integer, mouseXNoSnap As Integer, mouseYNoSnap As Integer, isMouseDown As Boolean)

End Class
