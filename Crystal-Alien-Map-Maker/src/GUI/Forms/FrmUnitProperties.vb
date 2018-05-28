Public Class FrmUnitProperties

    Private subject As Unit

    Public Sub New(ByRef subject As Unit)
        ' This call is required by the designer.
        InitializeComponent()

        Me.subject = subject
    End Sub

    Private Sub FrmUnitProperties_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        cboTarget.Items.Clear()
        cboObj.Items.Clear()

        'TODO: Externalize to config file.
        If Not subject.IsPickup Then
            cboTarget.Items.AddRange({
                New KeyValuePair(Of String, String)("seek", """seek"""),
                New KeyValuePair(Of String, String)("roam", """roam"""),
                New KeyValuePair(Of String, String)("still", """still"""),
                New KeyValuePair(Of String, String)("guard", """guard""")
            })
            cboTarget.SelectedIndex = 0
        End If

        cboTarget.DisplayMember = "Value"
        cboTarget.ValueMember = "Key"

        'TODO: Externalize to config file.
        cboObj.Items.AddRange({
            New KeyValuePair(Of String, String)("null", "None (null)")
        })
        If subject.IsPickup Then
            cboObj.Items.AddRange({
                New KeyValuePair(Of String, String)("powerup", """powerup"""),
                New KeyValuePair(Of String, String)("special", """special""")
            })
        End If

        cboObj.DisplayMember = "Value"
        cboObj.ValueMember = "Key"
        cboObj.SelectedIndex = 0

        If subject.IsPickup Then
            cboTarget.Enabled = False
            lblObj.Text = "Item Pickup Parameters"
        Else
            cboTarget.Enabled = True
            lblObj.Text = "Monolithic property of things"
        End If

        If subject.Team >= 2 Then
            'Fallback to neutral team, but this shouldn't be used.
            cboTeam.Items.Add("Neutral (""???"")")
            cboTeam.SelectedIndex = 2
        Else
            cboTeam.SelectedIndex = CInt(subject.Team)
        End If

        txtAngle.Value = subject.Angle
        txtDamage.Value = subject.Damage
        If Not subject.IsPickup Then
            cboTarget.SelectedIndex = (From i As KeyValuePair(Of String, String) In cboTarget.Items Where i.Key = subject.AiTarget Select cboTarget.Items.IndexOf(i)).FirstOrDefault()
        End If
        If Not String.IsNullOrEmpty(subject.AiObj) Then
            Dim item As KeyValuePair(Of String, String) = (From i As KeyValuePair(Of String, String) In cboObj.Items Where i.Key = subject.AiObj Select i).FirstOrDefault()
            If item.Key Is Nothing Then
                cboObj.SelectedItem = Nothing
                cboObj.Text = subject.AiObj
            Else
                cboObj.SelectedIndex = cboObj.Items.IndexOf(item)
            End If
        End If
        chkRespawn.Checked = subject.Respawn

        lblUnitId.Text = "Unit Id: " + subject.UnitId
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If cboObj.SelectedItem Is Nothing Then
            If cboObj.Text.Contains("|") Then
                MsgBox("Invalid symbol detected: |" + vbNewLine + "Please remove that symbol and try again.")
                cboObj.Focus()
                Return
            End If
        End If

        subject.Team = CType(cboTeam.SelectedIndex, Team)
        subject.Angle = txtAngle.Value
        subject.Damage = txtDamage.Value
        If subject.IsPickup Then
            subject.AiTarget = "null"
        Else
            subject.AiTarget = cboTarget.SelectedItem.Key
        End If
        If cboObj.SelectedItem Is Nothing Then
            subject.AiObj = cboObj.Text
        Else
            subject.AiObj = cboObj.SelectedItem.Key
        End If
        subject.Respawn = chkRespawn.Checked

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
