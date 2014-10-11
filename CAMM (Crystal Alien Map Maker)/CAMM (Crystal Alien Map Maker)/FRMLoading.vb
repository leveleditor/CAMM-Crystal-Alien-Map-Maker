Public NotInheritable Class FRMLoading

    Private Sub PreLoadScreen_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    End Sub

    Dim counter As Integer = 1
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If counter = 0 Then
            Label4.Text = "..."
            counter += 1
        ElseIf counter = 1 Then
            Label4.Text = " .."
            counter += 1
        ElseIf counter = 2 Then
            Label4.Text = "  ."
            counter += 1
        ElseIf counter = 3 Then
            Label4.Text = "   "
            Dim generator As New Random
            Label4.ForeColor = Color.FromKnownColor(generator.Next(0, 167))
            counter += 1
        ElseIf counter = 4 Then
            Label4.Text = ".  "
            counter += 1
        ElseIf counter = 5 Then
            Label4.Text = ".. "
            counter = 0
        End If
        Me.Refresh()
    End Sub

    Dim counter2 As Integer = 1
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If counter2 = 0 Then
            Label3.Text = "Extracting..."
            counter2 += 1
        ElseIf counter2 = 1 Then
            Label3.Text = "Verifying..."
            counter2 += 1
        ElseIf counter2 = 2 Then
            Label3.Text = "Updating..."
            counter2 += 1
        ElseIf counter2 = 3 Then
            Label3.Text = "Loading..."
            counter2 += 1
        ElseIf counter2 = 4 Then
            FRMEditor.Show()
            Me.Close()
        End If
        Me.Refresh()
    End Sub

    Dim counter3 As Integer = 0
    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Select Case counter3
            Case 0
                Label5.Text = "Launching Shuttle..."
                counter3 += 1
            Case 1
                Label5.Text = "Landing on Mars..."
                counter3 += 1
            Case 2
                Label5.Text = "Wait..."
                counter3 += 1
            Case 3
                Label5.Text = "Wrong Planet..."
                counter3 += 1
            Case 4
                Label5.Text = "Landing on Mars for real..."
                counter3 += 1
            Case 5
                Label5.Text = "Deploying Units..."
                counter3 += 1
            Case 6
                Label5.Text = "Scanning for Crystals..."
                counter3 += 1
            Case 7
                Label5.Text = "JACKPOT!"
                counter3 += 1
            Case 8
                Label5.Text = "Mining Crystals..."
                counter3 += 1
            Case 9
                Label5.Text = "Returning to Base..."
                counter3 += 1
            Case 10
                Label5.Text = "Ordering Pizza..."
                counter3 += 1
            Case 11
                Label5.Text = "(A few days later...)"
                counter3 += 1
            Case 12
                Label5.Text = "PIZZA! MMMM..."
                counter3 += 1
            Case 13
                Label5.Text = "Okay, back to work..."
                counter3 += 1
            Case 14
                Label5.Text = "Deploying Units..."
                counter3 += 1
            Case 15
                Label5.Text = "Scanning for Crystals..."
                counter3 += 1
            Case 16
                Label5.Text = "Hold on..."
                counter3 += 1
            Case 17
                Label5.Text = "Pressing panic button..."
                counter3 += 1
            Case 18
                Label5.Text = "Avoiding Lasers..."
                counter3 += 1
            Case 19
                Label5.Text = "Returning to Base..."
                counter3 += 1
            Case 20
                Label5.Text = "Okay..."
                counter3 += 1
            Case 21
                Label5.Text = "Fine..."
                counter3 += 1
            Case 22
                Label5.Text = "Loading, Please wait..."
                counter3 = 0
                Timer3.Stop()
        End Select
    End Sub
End Class
