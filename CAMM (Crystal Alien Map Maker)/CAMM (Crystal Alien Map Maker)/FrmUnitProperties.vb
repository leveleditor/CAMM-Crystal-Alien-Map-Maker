Public Class FrmUnitProperties

    Public Property TargetUnit As Unit = Nothing

    Private Sub FrmUnitProperties_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        cboTeam.SelectedIndex = CInt(TargetUnit.Team)
        txtAngle.Value = TargetUnit.Angle
        txtDamage.Value = TargetUnit.Damage
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        TargetUnit.Team = CType(cboTeam.SelectedIndex, Team)
        TargetUnit.Angle = txtAngle.Value
        TargetUnit.Damage = txtDamage.Value

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class
