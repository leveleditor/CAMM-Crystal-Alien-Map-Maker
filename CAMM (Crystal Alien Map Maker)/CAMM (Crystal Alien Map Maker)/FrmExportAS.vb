Imports System.Windows.Forms

Public Class FrmExportAS

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtOutput_Click(sender As Object, e As System.EventArgs) Handles txtOutput.Click
        txtOutput.SelectAll()
    End Sub

    Private Sub txtOutput_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtOutput.KeyDown
        If e.KeyCode = Keys.A And My.Computer.Keyboard.CtrlKeyDown Then
            txtOutput.SelectAll()
        End If
    End Sub

    Private Sub btnCopy_Click(sender As System.Object, e As System.EventArgs) Handles btnCopy.Click
        My.Computer.Clipboard.SetText(txtOutput.Text, TextDataFormat.UnicodeText)
    End Sub

End Class
