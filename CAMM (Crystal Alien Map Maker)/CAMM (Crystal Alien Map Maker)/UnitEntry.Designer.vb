<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnitEntry
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.btnBrowseFullImage = New System.Windows.Forms.Button()
        Me.tblControls = New System.Windows.Forms.TableLayoutPanel()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.txtFullImageUrl = New System.Windows.Forms.TextBox()
        Me.lblUnitId = New System.Windows.Forms.Label()
        Me.txtUnitId = New System.Windows.Forms.TextBox()
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.chkIsPickup = New System.Windows.Forms.CheckBox()
        Me.txtAltitude = New System.Windows.Forms.TextBox()
        Me.txtOffsetY = New System.Windows.Forms.TextBox()
        Me.lblAltitude = New System.Windows.Forms.Label()
        Me.lblOffsetY = New System.Windows.Forms.Label()
        Me.cboTeam = New System.Windows.Forms.ComboBox()
        Me.lblTeam = New System.Windows.Forms.Label()
        Me.txtShadowImageUrl = New System.Windows.Forms.TextBox()
        Me.btnBrowseShadowImage = New System.Windows.Forms.Button()
        Me.lblShadowImageUrl = New System.Windows.Forms.Label()
        Me.lblFullImageUrl = New System.Windows.Forms.Label()
        Me.tblControls.SuspendLayout()
        Me.pnlContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBrowseFullImage
        '
        Me.btnBrowseFullImage.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnBrowseFullImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBrowseFullImage.Location = New System.Drawing.Point(793, 4)
        Me.btnBrowseFullImage.Margin = New System.Windows.Forms.Padding(0)
        Me.btnBrowseFullImage.Name = "btnBrowseFullImage"
        Me.btnBrowseFullImage.Size = New System.Drawing.Size(70, 20)
        Me.btnBrowseFullImage.TabIndex = 16
        Me.btnBrowseFullImage.Text = "Browse..."
        Me.btnBrowseFullImage.UseVisualStyleBackColor = False
        '
        'tblControls
        '
        Me.tblControls.AutoSize = True
        Me.tblControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tblControls.ColumnCount = 3
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblControls.Controls.Add(Me.btnNew, 0, 0)
        Me.tblControls.Controls.Add(Me.btnRemove, 1, 0)
        Me.tblControls.Dock = System.Windows.Forms.DockStyle.Right
        Me.tblControls.Location = New System.Drawing.Point(1167, 0)
        Me.tblControls.Name = "tblControls"
        Me.tblControls.RowCount = 1
        Me.tblControls.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblControls.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tblControls.Size = New System.Drawing.Size(135, 28)
        Me.tblControls.TabIndex = 5
        '
        'btnNew
        '
        Me.btnNew.AutoSize = True
        Me.btnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnNew.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnNew.Location = New System.Drawing.Point(0, 0)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(0)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(60, 28)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "[ + ] New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.AutoSize = True
        Me.btnRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRemove.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnRemove.Location = New System.Drawing.Point(60, 0)
        Me.btnRemove.Margin = New System.Windows.Forms.Padding(0)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 28)
        Me.btnRemove.TabIndex = 1
        Me.btnRemove.Text = "[ - ] Remove"
        Me.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'txtFullImageUrl
        '
        Me.txtFullImageUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFullImageUrl.Location = New System.Drawing.Point(649, 4)
        Me.txtFullImageUrl.Margin = New System.Windows.Forms.Padding(0)
        Me.txtFullImageUrl.Name = "txtFullImageUrl"
        Me.txtFullImageUrl.Size = New System.Drawing.Size(144, 20)
        Me.txtFullImageUrl.TabIndex = 15
        '
        'lblUnitId
        '
        Me.lblUnitId.AutoSize = True
        Me.lblUnitId.Location = New System.Drawing.Point(3, 8)
        Me.lblUnitId.Name = "lblUnitId"
        Me.lblUnitId.Size = New System.Drawing.Size(38, 13)
        Me.lblUnitId.TabIndex = 0
        Me.lblUnitId.Text = "UnitId:"
        '
        'txtUnitId
        '
        Me.txtUnitId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitId.Location = New System.Drawing.Point(47, 4)
        Me.txtUnitId.Name = "txtUnitId"
        Me.txtUnitId.Size = New System.Drawing.Size(87, 20)
        Me.txtUnitId.TabIndex = 1
        '
        'pnlContainer
        '
        Me.pnlContainer.Controls.Add(Me.chkIsPickup)
        Me.pnlContainer.Controls.Add(Me.txtAltitude)
        Me.pnlContainer.Controls.Add(Me.txtOffsetY)
        Me.pnlContainer.Controls.Add(Me.lblAltitude)
        Me.pnlContainer.Controls.Add(Me.lblOffsetY)
        Me.pnlContainer.Controls.Add(Me.cboTeam)
        Me.pnlContainer.Controls.Add(Me.lblTeam)
        Me.pnlContainer.Controls.Add(Me.txtShadowImageUrl)
        Me.pnlContainer.Controls.Add(Me.txtFullImageUrl)
        Me.pnlContainer.Controls.Add(Me.btnBrowseShadowImage)
        Me.pnlContainer.Controls.Add(Me.btnBrowseFullImage)
        Me.pnlContainer.Controls.Add(Me.tblControls)
        Me.pnlContainer.Controls.Add(Me.lblUnitId)
        Me.pnlContainer.Controls.Add(Me.txtUnitId)
        Me.pnlContainer.Controls.Add(Me.lblShadowImageUrl)
        Me.pnlContainer.Controls.Add(Me.lblFullImageUrl)
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(1302, 28)
        Me.pnlContainer.TabIndex = 0
        '
        'chkIsPickup
        '
        Me.chkIsPickup.AutoSize = True
        Me.chkIsPickup.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIsPickup.Location = New System.Drawing.Point(369, 7)
        Me.chkIsPickup.Name = "chkIsPickup"
        Me.chkIsPickup.Size = New System.Drawing.Size(73, 17)
        Me.chkIsPickup.TabIndex = 17
        Me.chkIsPickup.Text = "Is Pickup:"
        Me.chkIsPickup.UseVisualStyleBackColor = True
        '
        'txtAltitude
        '
        Me.txtAltitude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAltitude.Location = New System.Drawing.Point(315, 4)
        Me.txtAltitude.MaxLength = 5
        Me.txtAltitude.Name = "txtAltitude"
        Me.txtAltitude.Size = New System.Drawing.Size(48, 20)
        Me.txtAltitude.TabIndex = 13
        '
        'txtOffsetY
        '
        Me.txtOffsetY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOffsetY.Location = New System.Drawing.Point(534, 4)
        Me.txtOffsetY.MaxLength = 5
        Me.txtOffsetY.Name = "txtOffsetY"
        Me.txtOffsetY.Size = New System.Drawing.Size(48, 20)
        Me.txtOffsetY.TabIndex = 13
        '
        'lblAltitude
        '
        Me.lblAltitude.AutoSize = True
        Me.lblAltitude.Location = New System.Drawing.Point(264, 8)
        Me.lblAltitude.Name = "lblAltitude"
        Me.lblAltitude.Size = New System.Drawing.Size(45, 13)
        Me.lblAltitude.TabIndex = 12
        Me.lblAltitude.Text = "Altitude:"
        '
        'lblOffsetY
        '
        Me.lblOffsetY.AutoSize = True
        Me.lblOffsetY.Location = New System.Drawing.Point(448, 8)
        Me.lblOffsetY.Name = "lblOffsetY"
        Me.lblOffsetY.Size = New System.Drawing.Size(80, 13)
        Me.lblOffsetY.TabIndex = 12
        Me.lblOffsetY.Text = "Image Y Offset:"
        '
        'cboTeam
        '
        Me.cboTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTeam.Items.AddRange(New Object() {"0] Astros", "1] Aliens"})
        Me.cboTeam.Location = New System.Drawing.Point(183, 3)
        Me.cboTeam.Name = "cboTeam"
        Me.cboTeam.Size = New System.Drawing.Size(75, 21)
        Me.cboTeam.TabIndex = 7
        '
        'lblTeam
        '
        Me.lblTeam.AutoSize = True
        Me.lblTeam.Location = New System.Drawing.Point(140, 8)
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Size = New System.Drawing.Size(37, 13)
        Me.lblTeam.TabIndex = 6
        Me.lblTeam.Text = "Team:"
        '
        'txtShadowImageUrl
        '
        Me.txtShadowImageUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShadowImageUrl.Location = New System.Drawing.Point(950, 4)
        Me.txtShadowImageUrl.Margin = New System.Windows.Forms.Padding(0)
        Me.txtShadowImageUrl.Name = "txtShadowImageUrl"
        Me.txtShadowImageUrl.Size = New System.Drawing.Size(144, 20)
        Me.txtShadowImageUrl.TabIndex = 15
        '
        'btnBrowseShadowImage
        '
        Me.btnBrowseShadowImage.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnBrowseShadowImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBrowseShadowImage.Location = New System.Drawing.Point(1094, 4)
        Me.btnBrowseShadowImage.Margin = New System.Windows.Forms.Padding(0)
        Me.btnBrowseShadowImage.Name = "btnBrowseShadowImage"
        Me.btnBrowseShadowImage.Size = New System.Drawing.Size(70, 20)
        Me.btnBrowseShadowImage.TabIndex = 16
        Me.btnBrowseShadowImage.Text = "Browse..."
        Me.btnBrowseShadowImage.UseVisualStyleBackColor = False
        '
        'lblShadowImageUrl
        '
        Me.lblShadowImageUrl.AutoSize = True
        Me.lblShadowImageUrl.Location = New System.Drawing.Point(866, 8)
        Me.lblShadowImageUrl.Name = "lblShadowImageUrl"
        Me.lblShadowImageUrl.Size = New System.Drawing.Size(81, 13)
        Me.lblShadowImageUrl.TabIndex = 14
        Me.lblShadowImageUrl.Text = "Shadow Image:"
        '
        'lblFullImageUrl
        '
        Me.lblFullImageUrl.AutoSize = True
        Me.lblFullImageUrl.Location = New System.Drawing.Point(588, 8)
        Me.lblFullImageUrl.Name = "lblFullImageUrl"
        Me.lblFullImageUrl.Size = New System.Drawing.Size(58, 13)
        Me.lblFullImageUrl.TabIndex = 14
        Me.lblFullImageUrl.Text = "Full Image:"
        '
        'UnitEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.pnlContainer)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UnitEntry"
        Me.Size = New System.Drawing.Size(1302, 28)
        Me.tblControls.ResumeLayout(False)
        Me.tblControls.PerformLayout()
        Me.pnlContainer.ResumeLayout(False)
        Me.pnlContainer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBrowseFullImage As System.Windows.Forms.Button
    Friend WithEvents tblControls As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents txtFullImageUrl As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitId As System.Windows.Forms.Label
    Friend WithEvents txtUnitId As System.Windows.Forms.TextBox
    Friend WithEvents pnlContainer As System.Windows.Forms.Panel
    Friend WithEvents lblFullImageUrl As System.Windows.Forms.Label
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents cboTeam As System.Windows.Forms.ComboBox
    Friend WithEvents txtOffsetY As System.Windows.Forms.TextBox
    Friend WithEvents lblOffsetY As System.Windows.Forms.Label
    Friend WithEvents chkIsPickup As System.Windows.Forms.CheckBox
    Friend WithEvents txtAltitude As System.Windows.Forms.TextBox
    Friend WithEvents lblAltitude As System.Windows.Forms.Label
    Friend WithEvents txtShadowImageUrl As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowseShadowImage As System.Windows.Forms.Button
    Friend WithEvents lblShadowImageUrl As System.Windows.Forms.Label

End Class
