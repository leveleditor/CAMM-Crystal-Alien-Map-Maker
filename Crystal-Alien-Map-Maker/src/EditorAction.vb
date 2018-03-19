Public MustInherit Class EditorAction

    Protected Timeline As ActionTimeline

    Public Overridable Sub InitializeContext(timeline As ActionTimeline)
        Me.Timeline = timeline
    End Sub

    MustOverride Function WillMakeChanges() As Boolean

    MustOverride Sub PerformAction()

    MustOverride Sub UndoAction()

End Class
