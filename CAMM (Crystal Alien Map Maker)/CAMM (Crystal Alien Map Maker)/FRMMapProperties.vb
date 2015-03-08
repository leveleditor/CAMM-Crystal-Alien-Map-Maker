Public Class FRMMapProperties

    Private Sub FRMMapProperties_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TextBox1.Maximum = Integer.MaxValue
        TextBox2.Maximum = Integer.MaxValue
        TextBox1.Minimum = Integer.MinValue
        TextBox2.Minimum = Integer.MinValue

        CBOTeams.SelectedIndex = CInt(FRMEditor.ActiveMap.Faction)
        TextBox2.Value = FRMEditor.ActiveMap.CashPlayer
        TextBox1.Value = FRMEditor.ActiveMap.CashEnemy
        CheckBox1.Checked = FRMEditor.ActiveMap.IsTraining
        RadioButton1.Checked = FRMEditor.ActiveMap.IsConflict
        RadioButton2.Checked = FRMEditor.ActiveMap.IsSpecialLevel
        RadioButton3.Checked = FRMEditor.ActiveMap.IsLastSpecialLevel
        RadioButton4.Checked = FRMEditor.ActiveMap.IsBonusLevel
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        FRMEditor.ActiveMap.Faction = CType(CBOTeams.SelectedIndex, Team)
        FRMEditor.ActiveMap.CashPlayer = Integer.Parse(TextBox2.Text)
        FRMEditor.ActiveMap.CashEnemy = Integer.Parse(TextBox1.Text)
        FRMEditor.ActiveMap.IsTraining = CheckBox1.Checked
        FRMEditor.ActiveMap.IsConflict = RadioButton1.Checked
        FRMEditor.ActiveMap.IsSpecialLevel = RadioButton2.Checked
        FRMEditor.ActiveMap.IsLastSpecialLevel = RadioButton3.Checked
        FRMEditor.ActiveMap.IsBonusLevel = RadioButton4.Checked

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
