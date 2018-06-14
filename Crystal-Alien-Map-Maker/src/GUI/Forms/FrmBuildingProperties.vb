Public Class FrmBuildingProperties

    Private subject As Building

    Public Sub New(ByRef subject As Building)
        ' This call is required by the designer.
        InitializeComponent()

        Icon = My.Resources.Crystal
        Me.subject = subject
    End Sub

    Private Sub FrmUnitProperties_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If subject.Team >= 2 Then
            'Fallback to neutral team, but this shouldn't be used.
            cboTeam.Items.Add("Neutral (""???"")")
            cboTeam.SelectedIndex = 2
        Else
            cboTeam.SelectedIndex = CInt(subject.Team)
        End If

        txtAngle.Value = subject.Angle
        txtDamage.Value = subject.Damage

        lblUnitId.Text = "Id: " + subject.BuildingId
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        subject.Team = CType(cboTeam.SelectedIndex, Team)
        subject.Angle = txtAngle.Value
        subject.Damage = txtDamage.Value

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

    Private Sub txtAngle_ValueChanged(sender As Object, e As EventArgs) Handles txtAngle.ValueChanged
        If txtAngle.Value = 1 Then
            txtAngle.Value = 0
        End If
    End Sub
End Class
