Public Class FrmMapProperties

    Private Sub FrmMapProperties_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        txtStartCashEnemy.Maximum = Integer.MaxValue
        txtStartCashPlayer.Maximum = Integer.MaxValue
        txtStartCashEnemy.Minimum = Integer.MinValue
        txtStartCashPlayer.Minimum = Integer.MinValue

        txtMapTitle.Text = FrmEditor.ActiveMap.MapTitle
        cboTeam.SelectedIndex = CInt(FrmEditor.ActiveMap.Faction)
        txtStartCashPlayer.Value = FrmEditor.ActiveMap.CashPlayer
        txtStartCashEnemy.Value = FrmEditor.ActiveMap.CashEnemy
        chkIsTraining.Checked = FrmEditor.ActiveMap.IsTraining
        rbtIsConflict.Checked = FrmEditor.ActiveMap.IsConflict
        rbtIsSpecialLevel.Checked = FrmEditor.ActiveMap.IsSpecialLevel
        rbtIsLastSpecialLevel.Checked = FrmEditor.ActiveMap.IsLastSpecialLevel
        rbtIsBonusLevel.Checked = FrmEditor.ActiveMap.IsBonusLevel
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        FrmEditor.ActiveMap.MapTitle = txtMapTitle.Text
        FrmEditor.ActiveMap.Faction = CType(cboTeam.SelectedIndex, Team)
        FrmEditor.ActiveMap.CashPlayer = Integer.Parse(txtStartCashPlayer.Text)
        FrmEditor.ActiveMap.CashEnemy = Integer.Parse(txtStartCashEnemy.Text)
        FrmEditor.ActiveMap.IsTraining = chkIsTraining.Checked
        FrmEditor.ActiveMap.IsConflict = rbtIsConflict.Checked
        FrmEditor.ActiveMap.IsSpecialLevel = rbtIsSpecialLevel.Checked
        FrmEditor.ActiveMap.IsLastSpecialLevel = rbtIsLastSpecialLevel.Checked
        FrmEditor.ActiveMap.IsBonusLevel = rbtIsBonusLevel.Checked

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
