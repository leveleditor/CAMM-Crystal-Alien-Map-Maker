Public Class FrmMapProperties

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        Icon = My.Resources.Crystal
    End Sub

    Private Sub FrmMapProperties_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtTitle.Focus()

        txtStartCashEnemy.Maximum = Integer.MaxValue
        txtStartCashPlayer.Maximum = Integer.MaxValue
        txtStartCashEnemy.Minimum = Integer.MinValue
        txtStartCashPlayer.Minimum = Integer.MinValue

        txtTitle.Text = FrmEditor.ActiveMap.Title
        txtAuthor.Text = FrmEditor.ActiveMap.Author
        cboTeam.SelectedIndex = CInt(FrmEditor.ActiveMap.Faction)
        txtStartCashPlayer.Value = FrmEditor.ActiveMap.CashPlayer
        txtStartCashEnemy.Value = FrmEditor.ActiveMap.CashEnemy
        chkIsTraining.Checked = FrmEditor.ActiveMap.IsTraining
        rbtIsConflict.Checked = FrmEditor.ActiveMap.IsConflict
        rbtIsSpecialLevel.Checked = FrmEditor.ActiveMap.IsSpecialLevel
        rbtIsLastSpecialLevel.Checked = FrmEditor.ActiveMap.IsLastSpecialLevel
        rbtIsBonusLevel.Checked = FrmEditor.ActiveMap.IsBonusLevel
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        FrmEditor.ActiveMap.Title = txtTitle.Text
        FrmEditor.ActiveMap.Author = txtAuthor.Text
        FrmEditor.ActiveMap.Faction = CType(cboTeam.SelectedIndex, Team)
        FrmEditor.ActiveMap.CashPlayer = Integer.Parse(txtStartCashPlayer.Text)
        FrmEditor.ActiveMap.CashEnemy = Integer.Parse(txtStartCashEnemy.Text)
        FrmEditor.ActiveMap.IsTraining = chkIsTraining.Checked
        FrmEditor.ActiveMap.IsConflict = rbtIsConflict.Checked
        FrmEditor.ActiveMap.IsSpecialLevel = rbtIsSpecialLevel.Checked
        FrmEditor.ActiveMap.IsLastSpecialLevel = rbtIsLastSpecialLevel.Checked
        FrmEditor.ActiveMap.IsBonusLevel = rbtIsBonusLevel.Checked

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cboTeam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTeam.SelectedIndexChanged
        Select Case cboTeam.SelectedIndex
            Case 0
                picTeam.Image = TeamIndicatorAstro
            Case 1
                picTeam.Image = TeamIndicatorAlien
        End Select
    End Sub

End Class
