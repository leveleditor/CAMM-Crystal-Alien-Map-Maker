<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAbout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.bgTimer = New System.Windows.Forms.Timer(Me.components)
        Me.closeButton = New System.Windows.Forms.Button()
        Me.pauseTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'bgTimer
        '
        Me.bgTimer.Interval = 42
        '
        'closeButton
        '
        Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeButton.AutoSize = True
        Me.closeButton.BackColor = System.Drawing.Color.WhiteSmoke
        Me.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.Orange
        Me.closeButton.FlatAppearance.BorderSize = 2
        Me.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro
        Me.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeButton.Location = New System.Drawing.Point(651, 306)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(87, 27)
        Me.closeButton.TabIndex = 0
        Me.closeButton.Text = "&Close"
        Me.closeButton.UseVisualStyleBackColor = False
        '
        'pauseTimer
        '
        Me.pauseTimer.Enabled = True
        Me.pauseTimer.Interval = 3000
        '
        'FrmAbout
        '
        Me.AcceptButton = Me.closeButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.closeButton
        Me.ClientSize = New System.Drawing.Size(752, 345)
        Me.Controls.Add(Me.closeButton)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bgTimer As Timer
    Friend WithEvents closeButton As Button
    Friend WithEvents pauseTimer As Timer
End Class
