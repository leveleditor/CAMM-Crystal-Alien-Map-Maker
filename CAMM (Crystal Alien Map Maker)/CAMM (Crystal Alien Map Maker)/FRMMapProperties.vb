Public Class FRMMapProperties

    Private Sub FRMMapProperties_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TextBox1.Maximum = Integer.MaxValue
        TextBox2.Maximum = Integer.MaxValue
        TextBox1.Minimum = Integer.MinValue
        TextBox2.Minimum = Integer.MinValue

        CBOTeams.SelectedIndex = FRMEditor.LevelTeam
        TextBox2.Value = FRMEditor.LevelCashPlayer
        TextBox1.Value = FRMEditor.LevelCashEnemy
        CheckBox1.Checked = FRMEditor.LevelFlags.isTraining
        RadioButton1.Checked = FRMEditor.LevelFlags.isConflict
        RadioButton2.Checked = FRMEditor.LevelFlags.isSpecialLevel
        RadioButton3.Checked = FRMEditor.LevelFlags.isLastSpecialLevel
        RadioButton4.Checked = FRMEditor.LevelFlags.isBonusLevel
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        FRMEditor.LevelTeam = CBOTeams.SelectedIndex
        FRMEditor.LevelCashPlayer = Integer.Parse(TextBox2.Text)
        FRMEditor.LevelCashEnemy = Integer.Parse(TextBox1.Text)
        FRMEditor.LevelFlags.isTraining = CheckBox1.Checked
        FRMEditor.LevelFlags.isConflict = RadioButton1.Checked
        FRMEditor.LevelFlags.isSpecialLevel = RadioButton2.Checked
        FRMEditor.LevelFlags.isLastSpecialLevel = RadioButton3.Checked
        FRMEditor.LevelFlags.isBonusLevel = RadioButton4.Checked

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class