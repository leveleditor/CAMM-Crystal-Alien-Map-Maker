Public Class FRMMapProperties

    Private Sub FRMMapProperties_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TXTStartCashEnemy.Maximum = Integer.MaxValue
        TXTStartCashPlayer.Maximum = Integer.MaxValue
        TXTStartCashEnemy.Minimum = Integer.MinValue
        TXTStartCashPlayer.Minimum = Integer.MinValue

        TXTMapTitle.Text = FRMEditor.ActiveMap.MapTitle
        CBOTeams.SelectedIndex = CInt(FRMEditor.ActiveMap.Faction)
        TXTStartCashPlayer.Value = FRMEditor.ActiveMap.CashPlayer
        TXTStartCashEnemy.Value = FRMEditor.ActiveMap.CashEnemy
        CHKIsTraining.Checked = FRMEditor.ActiveMap.IsTraining
        RadioButton1.Checked = FRMEditor.ActiveMap.IsConflict
        RadioButton2.Checked = FRMEditor.ActiveMap.IsSpecialLevel
        RadioButton3.Checked = FRMEditor.ActiveMap.IsLastSpecialLevel
        RadioButton4.Checked = FRMEditor.ActiveMap.IsBonusLevel
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        FRMEditor.ActiveMap.MapTitle = TXTMapTitle.Text
        FRMEditor.ActiveMap.Faction = CType(CBOTeams.SelectedIndex, Team)
        FRMEditor.ActiveMap.CashPlayer = Integer.Parse(TXTStartCashPlayer.Text)
        FRMEditor.ActiveMap.CashEnemy = Integer.Parse(TXTStartCashEnemy.Text)
        FRMEditor.ActiveMap.IsTraining = CHKIsTraining.Checked
        FRMEditor.ActiveMap.IsConflict = RadioButton1.Checked
        FRMEditor.ActiveMap.IsSpecialLevel = RadioButton2.Checked
        FRMEditor.ActiveMap.IsLastSpecialLevel = RadioButton3.Checked
        FRMEditor.ActiveMap.IsBonusLevel = RadioButton4.Checked

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
