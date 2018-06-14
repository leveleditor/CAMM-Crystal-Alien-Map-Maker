Public Class FrmExportAS

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        Icon = My.Resources.Crystal
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtOutput_Click(sender As Object, e As EventArgs) Handles txtOutput.Click
        txtOutput.SelectAll()
    End Sub

    Private Sub txtOutput_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOutput.KeyDown
        If e.KeyCode = Keys.A And My.Computer.Keyboard.CtrlKeyDown Then
            txtOutput.SelectAll()
        End If
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        My.Computer.Clipboard.SetText(txtOutput.Text, TextDataFormat.UnicodeText)
    End Sub

End Class
