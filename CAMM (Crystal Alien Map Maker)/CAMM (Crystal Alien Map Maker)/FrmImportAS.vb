Public Class FrmImportAS

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        'MsgBox("""" + Ascii(45) + """") '45 should be an "N" according to the tiler.php...
        'MsgBox("""" + Ascii("+").ToString + """") '"+" should be 10
        'MsgBox("""" + Ascii("?").ToString + """") '"?" should be 30
        'MsgBox("""" + Ascii(" ").ToString + """") '" " should be 0
        'MsgBox("""" + Ascii("ÿ").ToString + """") '"ÿ" should be 214

        Dim line As String = ""
        For i As Integer = 0 To txtPaste.Lines.Length - 1
            If txtPaste.Lines(i).StartsWith(cboPickMap.SelectedItem.ToString) Then
                line = txtPaste.Lines(i).Trim()
                Exit For
            End If
        Next

        line = line.Replace(cboPickMap.SelectedItem.ToString, "")
        line = line.Replace(".split("""",10000)", "")
        line = line.Trim()
        line = line.Trim(New Char() {Char.Parse(",")})
        line = line.Trim(New Char() {Char.Parse(":")})
        line = line.Trim()
        line = line.Trim(New Char() {Char.Parse("""")})

        FrmEditor.ImportAsTileData = line.Remove(0, 2)
        FrmEditor.NewMap()
        FrmEditor.ActiveMap.SetSize(AsciiLookup.IndexOf(line(0)), AsciiLookup.IndexOf(line(1)))
        FrmEditor.ActiveMap.MapTitle = cboPickMap.SelectedItem.ToString().Trim()

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtPaste.Text = ""
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GetMapNames()
        cboPickMap.Items.Clear()
        cboPickMap.Items.Add("Please select...")
        cboPickMap.SelectedIndex = 0

        Dim lines As String() = txtPaste.Lines

        For i As Integer = 0 To lines.Length - 1
            If lines(i) = "this.data = {" Then
                Continue For
            ElseIf lines(i).StartsWith("tiles") Then
                Continue For
            ElseIf lines(i) = "};" Then
                Exit For
            ElseIf lines(i).StartsWith("map") Then
                Dim name As String = ""
                For j As Integer = 0 To lines(i).Length - 1
                    If lines(i)(j) <> Char.Parse(":") Then
                        name += lines(i)(j)
                    Else
                        Exit For
                    End If
                Next
                cboPickMap.Items.Add(name)
            End If
        Next

        If cboPickMap.Items.Count > 1 Then
            cboPickMap.Enabled = True
        Else
            cboPickMap.Enabled = False
            btnOk.Enabled = False
            cboPickMap.SelectedIndex = 0
        End If
    End Sub

    Private Sub TrimText()
        Dim text As String = txtPaste.Text
        text = text.Trim()
        'text = text.Trim(New Char() {Char.Parse(" "), Char.Parse(vbTab), Char.Parse(vbLf), Char.Parse(vbCr)})
        text = text.Replace(vbTab, "")
        txtPaste.Text = text
    End Sub

    Private Sub txtPaste_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPaste.KeyDown
        If e.KeyCode = Keys.A And My.Computer.Keyboard.CtrlKeyDown Then
            txtPaste.SelectAll()
        End If
    End Sub

    Private Sub txtPaste_TextChanged(sender As Object, e As EventArgs) Handles txtPaste.TextChanged
        TrimText()
        GetMapNames()
    End Sub

    Private Sub FrmImportAS_Shown(sender As Object, e As EventArgs) Handles Me.Shown, Me.Load
        cboPickMap.SelectedIndex = 0
        'MsgBox(CBOPickMap.Items.Count.ToString)
    End Sub

    Private Sub cboPickMap_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPickMap.SelectedIndexChanged
        If cboPickMap.SelectedIndex > 0 Then
            btnOk.Enabled = True
        Else
            btnOk.Enabled = False
        End If
    End Sub
End Class
