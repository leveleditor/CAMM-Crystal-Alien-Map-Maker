Imports System.Windows.Forms

Public Class FRMExportAS

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub TXTOutput_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTOutput.Click
        TXTOutput.SelectAll()
    End Sub

    Private Sub TXTOutput_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTOutput.KeyDown
        If e.KeyCode = Keys.A And My.Computer.Keyboard.CtrlKeyDown Then
            TXTOutput.SelectAll()
        End If
    End Sub

    Private Sub CMDCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCopy.Click
        My.Computer.Clipboard.SetText(TXTOutput.Text, TextDataFormat.UnicodeText)
    End Sub

End Class
