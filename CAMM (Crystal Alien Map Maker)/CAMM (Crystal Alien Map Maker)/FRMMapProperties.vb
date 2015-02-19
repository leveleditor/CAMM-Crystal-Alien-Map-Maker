Public Class FRMMapProperties

    Private Sub FRMMapProperties_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TextBox1.Maximum = Integer.MaxValue
        TextBox2.Maximum = Integer.MaxValue
        TextBox1.Minimum = Integer.MinValue
        TextBox2.Minimum = Integer.MinValue

        CBOTeams.SelectedIndex = CInt(FRMEditor.ActiveLevel.Team)
        TextBox2.Value = FRMEditor.ActiveLevel.CashPlayer
        TextBox1.Value = FRMEditor.ActiveLevel.CashEnemy
        CheckBox1.Checked = FRMEditor.ActiveLevel.isTraining
        RadioButton1.Checked = FRMEditor.ActiveLevel.isConflict
        RadioButton2.Checked = FRMEditor.ActiveLevel.isSpecialLevel
        RadioButton3.Checked = FRMEditor.ActiveLevel.isLastSpecialLevel
        RadioButton4.Checked = FRMEditor.ActiveLevel.isBonusLevel
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        FRMEditor.ActiveLevel.Team = CType(CBOTeams.SelectedIndex, Team)
        FRMEditor.ActiveLevel.CashPlayer = Integer.Parse(TextBox2.Text)
        FRMEditor.ActiveLevel.CashEnemy = Integer.Parse(TextBox1.Text)
        FRMEditor.ActiveLevel.isTraining = CheckBox1.Checked
        FRMEditor.ActiveLevel.isConflict = RadioButton1.Checked
        FRMEditor.ActiveLevel.isSpecialLevel = RadioButton2.Checked
        FRMEditor.ActiveLevel.isLastSpecialLevel = RadioButton3.Checked
        FRMEditor.ActiveLevel.isBonusLevel = RadioButton4.Checked

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
