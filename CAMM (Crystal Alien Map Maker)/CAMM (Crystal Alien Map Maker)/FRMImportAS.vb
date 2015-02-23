Public Class FRMImportAS

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'MsgBox("""" + Ascii(45) + """") '45 should be an "N" according to the tiler.php...
        'MsgBox("""" + Ascii("+").ToString + """") '"+" should be 10
        'MsgBox("""" + Ascii("?").ToString + """") '"?" should be 30
        'MsgBox("""" + Ascii(" ").ToString + """") '" " should be 0
        'MsgBox("""" + Ascii("ÿ").ToString + """") '"ÿ" should be 214

        Dim line As String = ""
        For i As Integer = 0 To TXTPaste.Lines.Length - 1
            If TXTPaste.Lines(i).StartsWith(CBOPickMap.SelectedItem.ToString) Then
                line = TXTPaste.Lines(i).Trim()
                Exit For
            End If
        Next

        line = line.Replace(CBOPickMap.SelectedItem.ToString, "")
        line = line.Replace(".split("""",10000)", "")
        line = line.Trim()
        line = line.Trim(New Char() {Char.Parse(",")})
        line = line.Trim(New Char() {Char.Parse(":")})
        line = line.Trim()
        line = line.Trim(New Char() {Char.Parse("""")})

        FRMEditor.ImportASTileData = line.Remove(0, 2)
        FRMEditor.NewMap()
        FRMEditor.ActiveMap.SetSize(Ascii(line(0)), Ascii(line(1)))
        FRMEditor.ActiveMap.MapTitle = CBOPickMap.SelectedItem.ToString().Trim()

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        TXTPaste.Text = ""
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Sub GetMapNames()
        CBOPickMap.Items.Clear()
        CBOPickMap.Items.Add("Please select...")
        CBOPickMap.SelectedIndex = 0

        Dim lines As String() = TXTPaste.Lines

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
                CBOPickMap.Items.Add(name)
            End If
        Next

        If CBOPickMap.Items.Count > 1 Then
            CBOPickMap.Enabled = True
        Else
            CBOPickMap.Enabled = False
            OK_Button.Enabled = False
            CBOPickMap.SelectedIndex = 0
        End If
    End Sub

    Sub TrimText()
        Dim text As String = TXTPaste.Text
        text = text.Trim()
        'text = text.Trim(New Char() {Char.Parse(" "), Char.Parse(vbTab), Char.Parse(vbLf), Char.Parse(vbCr)})
        text = text.Replace(vbTab, "")
        TXTPaste.Text = text
    End Sub

    Private Sub TXTPaste_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTPaste.KeyDown
        If e.KeyCode = Keys.A And My.Computer.Keyboard.CtrlKeyDown Then
            TXTPaste.SelectAll()
        End If
    End Sub

    Private Sub TXTPaste_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPaste.TextChanged
        TrimText()
        GetMapNames()
    End Sub

    Private Sub FRMImportAS_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown, Me.Load
        CBOPickMap.SelectedIndex = 0
        'MsgBox(CBOPickMap.Items.Count.ToString)
    End Sub

    Private Sub CBOPickMap_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBOPickMap.SelectedIndexChanged
        If CBOPickMap.SelectedIndex > 0 Then
            OK_Button.Enabled = True
        Else
            OK_Button.Enabled = False
        End If
    End Sub

    Function Ascii(ByVal index As Integer) As String
        If index > 213 Then
            Return "INVALID"
        End If
        Return FRMEditor.Ascii(index)
    End Function
    Function Ascii(ByVal character As Char) As Integer
        Return Array.IndexOf(FRMEditor.Ascii, character.ToString)
    End Function
    Function Ascii(ByVal character As String) As Integer
        Return Array.IndexOf(FRMEditor.Ascii, character)
    End Function

End Class
