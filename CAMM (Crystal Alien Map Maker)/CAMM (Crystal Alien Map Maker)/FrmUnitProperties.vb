Public Class FrmUnitProperties

    Public Property Subject As Unit = Nothing

    Private Sub FrmUnitProperties_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        cboTarget.Items.Clear()
        cboObj.Items.Clear()

        'TODO: Externalize to config file.
        If Not Subject.IsPickup Then
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
        If Subject.IsPickup Then
            cboObj.Items.AddRange({
                New KeyValuePair(Of String, String)("powerup", """powerup"""),
                New KeyValuePair(Of String, String)("special", """special""")
            })
        End If

        cboObj.DisplayMember = "Value"
        cboObj.ValueMember = "Key"
        cboObj.SelectedIndex = 0

        If Subject.IsPickup Then
            cboTarget.Enabled = False
            lblObj.Text = "Item Pickup Parameters"
        Else
            cboTarget.Enabled = True
            lblObj.Text = "Monolithic property of things"
        End If

        cboTeam.SelectedIndex = CInt(Subject.Team)
        txtAngle.Value = Subject.Angle
        txtDamage.Value = Subject.Damage
        If Not Subject.IsPickup Then
            cboTarget.SelectedIndex = (From i As KeyValuePair(Of String, String) In cboTarget.Items Where i.Key = Subject.AiTarget Select cboTarget.Items.IndexOf(i)).FirstOrDefault()
        End If
        If Not String.IsNullOrEmpty(Subject.AiObj) Then
            Dim item As KeyValuePair(Of String, String) = (From i As KeyValuePair(Of String, String) In cboObj.Items Where i.Key = Subject.AiObj Select i).FirstOrDefault()
            If item.Key Is Nothing Then
                cboObj.SelectedItem = Nothing
                cboObj.Text = Subject.AiObj
            Else
                cboObj.SelectedIndex = cboObj.Items.IndexOf(item)
            End If
        End If
        chkRespawn.Checked = Subject.Respawn

#If DEBUG Then
        lblUnitId.Text = Subject.UnitId
        lblUnitId.Visible = True
#End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If cboObj.SelectedItem Is Nothing Then
            If cboObj.Text.Contains("|") Then
                MsgBox("Invalid symbol detected: |" + vbNewLine + "Please remove that symbol and try again.")
                cboObj.Focus()
                Return
            End If
        End If

        Subject.Team = CType(cboTeam.SelectedIndex, Team)
        Subject.Angle = txtAngle.Value
        Subject.Damage = txtDamage.Value
        If Subject.IsPickup Then
            Subject.AiTarget = "null"
        Else
            Subject.AiTarget = cboTarget.SelectedItem.Key
        End If
        If cboObj.SelectedItem Is Nothing Then
            Subject.AiObj = cboObj.Text
        Else
            Subject.AiObj = cboObj.SelectedItem.Key
        End If
        Subject.Respawn = chkRespawn.Checked

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
