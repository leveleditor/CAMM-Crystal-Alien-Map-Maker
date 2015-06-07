<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMapProperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMapProperties))
        Me.lblTeam = New System.Windows.Forms.Label()
        Me.lblStartCashPlayer = New System.Windows.Forms.Label()
        Me.lblStartCashEnemy = New System.Windows.Forms.Label()
        Me.lblLevelFlags = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtStartCashPlayer = New System.Windows.Forms.NumericUpDown()
        Me.cboTeam = New System.Windows.Forms.ComboBox()
        Me.txtStartCashEnemy = New System.Windows.Forms.NumericUpDown()
        Me.chkIsTraining = New System.Windows.Forms.CheckBox()
        Me.rbtIsConflict = New System.Windows.Forms.RadioButton()
        Me.rbtIsSpecialLevel = New System.Windows.Forms.RadioButton()
        Me.rbtIsLastSpecialLevel = New System.Windows.Forms.RadioButton()
        Me.rbtIsBonusLevel = New System.Windows.Forms.RadioButton()
        Me.tblButtons = New System.Windows.Forms.TableLayoutPanel()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.lblAuthor = New System.Windows.Forms.Label()
        CType(Me.txtStartCashPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStartCashEnemy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTeam
        '
        Me.lblTeam.AutoSize = True
        Me.lblTeam.Location = New System.Drawing.Point(86, 67)
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Size = New System.Drawing.Size(34, 13)
        Me.lblTeam.TabIndex = 0
        Me.lblTeam.Text = "Team"
        '
        'lblStartCashPlayer
        '
        Me.lblStartCashPlayer.AutoSize = True
        Me.lblStartCashPlayer.Location = New System.Drawing.Point(12, 94)
        Me.lblStartCashPlayer.Name = "lblStartCashPlayer"
        Me.lblStartCashPlayer.Size = New System.Drawing.Size(108, 13)
        Me.lblStartCashPlayer.TabIndex = 1
        Me.lblStartCashPlayer.Text = "Starting Cash (Player)"
        '
        'lblStartCashEnemy
        '
        Me.lblStartCashEnemy.AutoSize = True
        Me.lblStartCashEnemy.Location = New System.Drawing.Point(9, 120)
        Me.lblStartCashEnemy.Name = "lblStartCashEnemy"
        Me.lblStartCashEnemy.Size = New System.Drawing.Size(111, 13)
        Me.lblStartCashEnemy.TabIndex = 1
        Me.lblStartCashEnemy.Text = "Starting Cash (Enemy)"
        '
        'lblLevelFlags
        '
        Me.lblLevelFlags.AutoSize = True
        Me.lblLevelFlags.Location = New System.Drawing.Point(59, 144)
        Me.lblLevelFlags.Name = "lblLevelFlags"
        Me.lblLevelFlags.Size = New System.Drawing.Size(61, 13)
        Me.lblLevelFlags.TabIndex = 6
        Me.lblLevelFlags.Text = "Level Flags"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(93, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(27, 13)
        Me.lblTitle.TabIndex = 13
        Me.lblTitle.Text = "Title"
        '
        'txtStartCashPlayer
        '
        Me.txtStartCashPlayer.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txtStartCashPlayer.Location = New System.Drawing.Point(126, 91)
        Me.txtStartCashPlayer.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.txtStartCashPlayer.Minimum = New Decimal(New Integer() {2147483647, 0, 0, -2147483648})
        Me.txtStartCashPlayer.Name = "txtStartCashPlayer"
        Me.txtStartCashPlayer.Size = New System.Drawing.Size(100, 20)
        Me.txtStartCashPlayer.TabIndex = 3
        '
        'cboTeam
        '
        Me.cboTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTeam.FormattingEnabled = True
        Me.cboTeam.Items.AddRange(New Object() {"Astros (""good"")", "Aliens (""evil"")"})
        Me.cboTeam.Location = New System.Drawing.Point(126, 64)
        Me.cboTeam.Name = "cboTeam"
        Me.cboTeam.Size = New System.Drawing.Size(100, 21)
        Me.cboTeam.TabIndex = 4
        '
        'txtStartCashEnemy
        '
        Me.txtStartCashEnemy.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txtStartCashEnemy.Location = New System.Drawing.Point(126, 117)
        Me.txtStartCashEnemy.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.txtStartCashEnemy.Minimum = New Decimal(New Integer() {2147483647, 0, 0, -2147483648})
        Me.txtStartCashEnemy.Name = "txtStartCashEnemy"
        Me.txtStartCashEnemy.Size = New System.Drawing.Size(100, 20)
        Me.txtStartCashEnemy.TabIndex = 3
        '
        'chkIsTraining
        '
        Me.chkIsTraining.AutoSize = True
        Me.chkIsTraining.Location = New System.Drawing.Point(126, 143)
        Me.chkIsTraining.Name = "chkIsTraining"
        Me.chkIsTraining.Size = New System.Drawing.Size(71, 17)
        Me.chkIsTraining.TabIndex = 5
        Me.chkIsTraining.Text = "isTraining"
        Me.chkIsTraining.UseVisualStyleBackColor = True
        '
        'rbtIsConflict
        '
        Me.rbtIsConflict.AutoSize = True
        Me.rbtIsConflict.Location = New System.Drawing.Point(126, 166)
        Me.rbtIsConflict.Name = "rbtIsConflict"
        Me.rbtIsConflict.Size = New System.Drawing.Size(67, 17)
        Me.rbtIsConflict.TabIndex = 7
        Me.rbtIsConflict.TabStop = True
        Me.rbtIsConflict.Text = "isConflict"
        Me.rbtIsConflict.UseVisualStyleBackColor = True
        '
        'rbtIsSpecialLevel
        '
        Me.rbtIsSpecialLevel.AutoSize = True
        Me.rbtIsSpecialLevel.Location = New System.Drawing.Point(126, 189)
        Me.rbtIsSpecialLevel.Name = "rbtIsSpecialLevel"
        Me.rbtIsSpecialLevel.Size = New System.Drawing.Size(93, 17)
        Me.rbtIsSpecialLevel.TabIndex = 8
        Me.rbtIsSpecialLevel.TabStop = True
        Me.rbtIsSpecialLevel.Text = "isSpecialLevel"
        Me.rbtIsSpecialLevel.UseVisualStyleBackColor = True
        '
        'rbtIsLastSpecialLevel
        '
        Me.rbtIsLastSpecialLevel.AutoSize = True
        Me.rbtIsLastSpecialLevel.Location = New System.Drawing.Point(126, 212)
        Me.rbtIsLastSpecialLevel.Name = "rbtIsLastSpecialLevel"
        Me.rbtIsLastSpecialLevel.Size = New System.Drawing.Size(113, 17)
        Me.rbtIsLastSpecialLevel.TabIndex = 9
        Me.rbtIsLastSpecialLevel.TabStop = True
        Me.rbtIsLastSpecialLevel.Text = "isLastSpecialLevel"
        Me.rbtIsLastSpecialLevel.UseVisualStyleBackColor = True
        '
        'rbtIsBonusLevel
        '
        Me.rbtIsBonusLevel.AutoSize = True
        Me.rbtIsBonusLevel.Location = New System.Drawing.Point(126, 235)
        Me.rbtIsBonusLevel.Name = "rbtIsBonusLevel"
        Me.rbtIsBonusLevel.Size = New System.Drawing.Size(88, 17)
        Me.rbtIsBonusLevel.TabIndex = 10
        Me.rbtIsBonusLevel.TabStop = True
        Me.rbtIsBonusLevel.Text = "isBonusLevel"
        Me.rbtIsBonusLevel.UseVisualStyleBackColor = True
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
        'txtTitle
        '
        Me.txtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTitle.Location = New System.Drawing.Point(126, 12)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(196, 20)
        Me.txtTitle.TabIndex = 12
        '
        'txtAuthor
        '
        Me.txtAuthor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAuthor.Location = New System.Drawing.Point(126, 38)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(196, 20)
        Me.txtAuthor.TabIndex = 12
        '
        'lblAuthor
        '
        Me.lblAuthor.AutoSize = True
        Me.lblAuthor.Location = New System.Drawing.Point(82, 40)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(38, 13)
        Me.lblAuthor.TabIndex = 13
        Me.lblAuthor.Text = "Author"
        '
        'FrmMapProperties
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(334, 299)
        Me.Controls.Add(Me.lblAuthor)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txtAuthor)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.tblButtons)
        Me.Controls.Add(Me.rbtIsBonusLevel)
        Me.Controls.Add(Me.rbtIsLastSpecialLevel)
        Me.Controls.Add(Me.rbtIsSpecialLevel)
        Me.Controls.Add(Me.rbtIsConflict)
        Me.Controls.Add(Me.lblLevelFlags)
        Me.Controls.Add(Me.chkIsTraining)
        Me.Controls.Add(Me.cboTeam)
        Me.Controls.Add(Me.txtStartCashEnemy)
        Me.Controls.Add(Me.lblStartCashEnemy)
        Me.Controls.Add(Me.txtStartCashPlayer)
        Me.Controls.Add(Me.lblStartCashPlayer)
        Me.Controls.Add(Me.lblTeam)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMapProperties"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Map Properties"
        CType(Me.txtStartCashPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStartCashEnemy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtStartCashPlayer As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboTeam As System.Windows.Forms.ComboBox
    Friend WithEvents txtStartCashEnemy As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkIsTraining As System.Windows.Forms.CheckBox
    Friend WithEvents rbtIsConflict As System.Windows.Forms.RadioButton
    Friend WithEvents rbtIsSpecialLevel As System.Windows.Forms.RadioButton
    Friend WithEvents rbtIsLastSpecialLevel As System.Windows.Forms.RadioButton
    Friend WithEvents rbtIsBonusLevel As System.Windows.Forms.RadioButton
    Friend WithEvents tblButtons As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents lblStartCashPlayer As System.Windows.Forms.Label
    Friend WithEvents lblStartCashEnemy As System.Windows.Forms.Label
    Friend WithEvents lblLevelFlags As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtAuthor As System.Windows.Forms.TextBox
    Friend WithEvents lblAuthor As System.Windows.Forms.Label
End Class
