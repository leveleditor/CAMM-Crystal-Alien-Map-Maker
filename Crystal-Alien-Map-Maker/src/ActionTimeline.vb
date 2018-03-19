Public Class ActionTimeline

    Private undoStack As Stack(Of EditorAction)
    Private redoStack As Stack(Of EditorAction)
    Public Property Map As Map

    Public Sub New(map As Map)
        undoStack = New Stack(Of EditorAction)()
        redoStack = New Stack(Of EditorAction)()
        Me.Map = map
    End Sub

    Public Sub Undo()
        If undoStack.Count > 0 Then
            Dim undoAction As EditorAction = undoStack.Pop()
            undoAction.UndoAction()
            redoStack.Push(undoAction)
        End If
    End Sub

    Public Sub Redo()
        If redoStack.Count > 0 Then
            Dim redoAction As EditorAction = redoStack.Pop()
            redoAction.PerformAction()
            undoStack.Push(redoAction)
        End If
    End Sub

    Public Sub PerformAction(editorAction As EditorAction)
        editorAction.InitializeContext(Me)
        If editorAction.WillMakeChanges() Then
            editorAction.PerformAction()
            undoStack.Push(editorAction)
            redoStack.Clear()
        End If
    End Sub

End Class
