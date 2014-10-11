<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMExportAS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMExportAS))
        Me.OK_Button = New System.Windows.Forms.Button
        Me.LBLOutput = New System.Windows.Forms.Label
        Me.TXTOutput = New System.Windows.Forms.TextBox
        Me.CMDCopy = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(435, 156)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 3
        Me.OK_Button.Text = "OK"
        '
        'LBLOutput
        '
        Me.LBLOutput.AutoSize = True
        Me.LBLOutput.Location = New System.Drawing.Point(12, 9)
        Me.LBLOutput.Name = "LBLOutput"
        Me.LBLOutput.Size = New System.Drawing.Size(197, 13)
        Me.LBLOutput.TabIndex = 0
        Me.LBLOutput.Text = "Here is your exported ActionScript code:"
        '
        'TXTOutput
        '
        Me.TXTOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTOutput.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOutput.Location = New System.Drawing.Point(12, 25)
        Me.TXTOutput.Multiline = True
        Me.TXTOutput.Name = "TXTOutput"
        Me.TXTOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TXTOutput.Size = New System.Drawing.Size(490, 125)
        Me.TXTOutput.TabIndex = 1
        Me.TXTOutput.WordWrap = False
        '
        'CMDCopy
        '
        Me.CMDCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CMDCopy.AutoSize = True
        Me.CMDCopy.Location = New System.Drawing.Point(12, 156)
        Me.CMDCopy.Name = "CMDCopy"
        Me.CMDCopy.Size = New System.Drawing.Size(99, 23)
        Me.CMDCopy.TabIndex = 2
        Me.CMDCopy.Text = "&Copy to clipboard"
        Me.CMDCopy.UseVisualStyleBackColor = True
        '
        'FRMExportAS
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 191)
        Me.Controls.Add(Me.CMDCopy)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.TXTOutput)
        Me.Controls.Add(Me.LBLOutput)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRMExportAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export ActionScript Code"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents LBLOutput As System.Windows.Forms.Label
    Friend WithEvents CMDCopy As System.Windows.Forms.Button
    Public WithEvents TXTOutput As System.Windows.Forms.TextBox

End Class
