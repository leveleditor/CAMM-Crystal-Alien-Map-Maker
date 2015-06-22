<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUnitProperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUnitProperties))
        Me.lblTeam = New System.Windows.Forms.Label()
        Me.cboTeam = New System.Windows.Forms.ComboBox()
        Me.tblButtons = New System.Windows.Forms.TableLayoutPanel()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtAngle = New System.Windows.Forms.NumericUpDown()
        Me.lblAngle = New System.Windows.Forms.Label()
        Me.lblDamage = New System.Windows.Forms.Label()
        Me.txtDamage = New System.Windows.Forms.NumericUpDown()
        Me.picTeam = New System.Windows.Forms.PictureBox()
        Me.tblButtons.SuspendLayout()
        CType(Me.txtAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDamage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTeam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTeam
        '
        Me.lblTeam.AutoSize = True
        Me.lblTeam.Location = New System.Drawing.Point(86, 15)
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Size = New System.Drawing.Size(34, 13)
        Me.lblTeam.TabIndex = 0
        Me.lblTeam.Text = "Team"
        '
        'cboTeam
        '
        Me.cboTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTeam.FormattingEnabled = True
        Me.cboTeam.Items.AddRange(New Object() {"Astros (""good"")", "Aliens (""evil"")", "Neutral (""???"")"})
        Me.cboTeam.Location = New System.Drawing.Point(126, 12)
        Me.cboTeam.Name = "cboTeam"
        Me.cboTeam.Size = New System.Drawing.Size(100, 21)
        Me.cboTeam.TabIndex = 4
        '
        'tblButtons
        '
        Me.tblButtons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblButtons.ColumnCount = 2
        Me.tblButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblButtons.Controls.Add(Me.btnOk, 0, 0)
        Me.tblButtons.Controls.Add(Me.btnCancel, 1, 0)
        Me.tblButtons.Location = New System.Drawing.Point(176, 258)
        Me.tblButtons.Name = "tblButtons"
        Me.tblButtons.RowCount = 1
        Me.tblButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblButtons.Size = New System.Drawing.Size(146, 29)
        Me.tblButtons.TabIndex = 11
        '
        'btnOk
        '
        Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOk.Location = New System.Drawing.Point(3, 3)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(67, 23)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(76, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(67, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'txtAngle
        '
        Me.txtAngle.DecimalPlaces = 2
        Me.txtAngle.Increment = New Decimal(New Integer() {15, 0, 0, 131072})
        Me.txtAngle.Location = New System.Drawing.Point(126, 39)
        Me.txtAngle.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtAngle.Name = "txtAngle"
        Me.txtAngle.Size = New System.Drawing.Size(100, 20)
        Me.txtAngle.TabIndex = 15
        '
        'lblAngle
        '
        Me.lblAngle.AutoSize = True
        Me.lblAngle.Location = New System.Drawing.Point(86, 41)
        Me.lblAngle.Name = "lblAngle"
        Me.lblAngle.Size = New System.Drawing.Size(34, 13)
        Me.lblAngle.TabIndex = 14
        Me.lblAngle.Text = "Angle"
        '
        'lblDamage
        '
        Me.lblDamage.AutoSize = True
        Me.lblDamage.Location = New System.Drawing.Point(73, 67)
        Me.lblDamage.Name = "lblDamage"
        Me.lblDamage.Size = New System.Drawing.Size(47, 13)
        Me.lblDamage.TabIndex = 14
        Me.lblDamage.Text = "Damage"
        '
        'txtDamage
        '
        Me.txtDamage.DecimalPlaces = 2
        Me.txtDamage.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtDamage.Location = New System.Drawing.Point(126, 65)
        Me.txtDamage.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtDamage.Name = "txtDamage"
        Me.txtDamage.Size = New System.Drawing.Size(100, 20)
        Me.txtDamage.TabIndex = 15
        '
        'picTeam
        '
        Me.picTeam.Location = New System.Drawing.Point(232, 6)
        Me.picTeam.Name = "picTeam"
        Me.picTeam.Size = New System.Drawing.Size(33, 33)
        Me.picTeam.TabIndex = 16
        Me.picTeam.TabStop = False
        '
        'FrmUnitProperties
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(334, 299)
        Me.Controls.Add(Me.picTeam)
        Me.Controls.Add(Me.txtDamage)
        Me.Controls.Add(Me.lblDamage)
        Me.Controls.Add(Me.txtAngle)
        Me.Controls.Add(Me.lblAngle)
        Me.Controls.Add(Me.tblButtons)
        Me.Controls.Add(Me.cboTeam)
        Me.Controls.Add(Me.lblTeam)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUnitProperties"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Unit Properties"
        Me.tblButtons.ResumeLayout(False)
        CType(Me.txtAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDamage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTeam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboTeam As System.Windows.Forms.ComboBox
    Friend WithEvents tblButtons As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents txtAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblAngle As System.Windows.Forms.Label
    Friend WithEvents lblDamage As System.Windows.Forms.Label
    Friend WithEvents txtDamage As System.Windows.Forms.NumericUpDown
    Friend WithEvents picTeam As System.Windows.Forms.PictureBox
End Class
