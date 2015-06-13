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

    Private Sub cboTeam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTeam.SelectedIndexChanged
        Select Case cboTeam.SelectedIndex
            Case 0
                picTeam.Image = TeamIndicatorAstro
            Case 1
                picTeam.Image = TeamIndicatorAlien
            Case 2
                picTeam.Image = TeamIndicatorNeutral
        End Select
    End Sub

End Class
