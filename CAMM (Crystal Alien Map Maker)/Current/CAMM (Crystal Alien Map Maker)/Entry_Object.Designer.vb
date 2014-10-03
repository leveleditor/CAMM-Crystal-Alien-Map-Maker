<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Entry_Object
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
        Me.CMDBrowse = New System.Windows.Forms.Button
        Me.TBLControls = New System.Windows.Forms.TableLayoutPanel
        Me.CMDNew = New System.Windows.Forms.Button
        Me.CMDRemove = New System.Windows.Forms.Button
        Me.TXTImageUrl = New System.Windows.Forms.TextBox
        Me.LBLObjectID = New System.Windows.Forms.Label
        Me.TXTObjectID = New System.Windows.Forms.TextBox
        Me.PNLContainer = New System.Windows.Forms.Panel
        Me.TXTOffsetY = New System.Windows.Forms.TextBox
        Me.LBLOffsetY = New System.Windows.Forms.Label
        Me.CBOTeam = New System.Windows.Forms.ComboBox
        Me.LBLAngle = New System.Windows.Forms.Label
        Me.TXTAngle = New System.Windows.Forms.TextBox
        Me.LBLDamage = New System.Windows.Forms.Label
        Me.TXTDamage = New System.Windows.Forms.TextBox
        Me.LBLTeam = New System.Windows.Forms.Label
        Me.LBLHeight = New System.Windows.Forms.Label
        Me.TXTHeight = New System.Windows.Forms.TextBox
        Me.LBLWidth = New System.Windows.Forms.Label
        Me.TXTWidth = New System.Windows.Forms.TextBox
        Me.LBLImageUrl = New System.Windows.Forms.Label
        Me.TBLControls.SuspendLayout()
        Me.PNLContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'CMDBrowse
        '
        Me.CMDBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDBrowse.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CMDBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMDBrowse.Location = New System.Drawing.Point(962, 4)
        Me.CMDBrowse.Margin = New System.Windows.Forms.Padding(0)
        Me.CMDBrowse.Name = "CMDBrowse"
        Me.CMDBrowse.Size = New System.Drawing.Size(70, 20)
        Me.CMDBrowse.TabIndex = 16
        Me.CMDBrowse.Text = "Browse..."
        Me.CMDBrowse.UseVisualStyleBackColor = False
        '
        'TBLControls
        '
        Me.TBLControls.AutoSize = True
        Me.TBLControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TBLControls.ColumnCount = 3
        Me.TBLControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TBLControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TBLControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TBLControls.Controls.Add(Me.CMDNew, 0, 0)
        Me.TBLControls.Controls.Add(Me.CMDRemove, 1, 0)
        Me.TBLControls.Dock = System.Windows.Forms.DockStyle.Right
        Me.TBLControls.Location = New System.Drawing.Point(1035, 0)
        Me.TBLControls.Name = "TBLControls"
        Me.TBLControls.RowCount = 1
        Me.TBLControls.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TBLControls.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TBLControls.Size = New System.Drawing.Size(135, 28)
        Me.TBLControls.TabIndex = 5
        '
        'CMDNew
        '
        Me.CMDNew.AutoSize = True
        Me.CMDNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CMDNew.Dock = System.Windows.Forms.DockStyle.Left
        Me.CMDNew.Location = New System.Drawing.Point(0, 0)
        Me.CMDNew.Margin = New System.Windows.Forms.Padding(0)
        Me.CMDNew.Name = "CMDNew"
        Me.CMDNew.Size = New System.Drawing.Size(60, 28)
        Me.CMDNew.TabIndex = 0
        Me.CMDNew.Text = "[ + ] New"
        Me.CMDNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMDNew.UseVisualStyleBackColor = True
        '
        'CMDRemove
        '
        Me.CMDRemove.AutoSize = True
        Me.CMDRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CMDRemove.Dock = System.Windows.Forms.DockStyle.Left
        Me.CMDRemove.Location = New System.Drawing.Point(60, 0)
        Me.CMDRemove.Margin = New System.Windows.Forms.Padding(0)
        Me.CMDRemove.Name = "CMDRemove"
        Me.CMDRemove.Size = New System.Drawing.Size(75, 28)
        Me.CMDRemove.TabIndex = 1
        Me.CMDRemove.Text = "[ - ] Remove"
        Me.CMDRemove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMDRemove.UseVisualStyleBackColor = True
        '
        'TXTImageUrl
        '
        Me.TXTImageUrl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTImageUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTImageUrl.Location = New System.Drawing.Point(824, 4)
        Me.TXTImageUrl.Margin = New System.Windows.Forms.Padding(0)
        Me.TXTImageUrl.Name = "TXTImageUrl"
        Me.TXTImageUrl.Size = New System.Drawing.Size(138, 20)
        Me.TXTImageUrl.TabIndex = 15
        '
        'LBLObjectID
        '
        Me.LBLObjectID.AutoSize = True
        Me.LBLObjectID.Location = New System.Drawing.Point(3, 8)
        Me.LBLObjectID.Name = "LBLObjectID"
        Me.LBLObjectID.Size = New System.Drawing.Size(52, 13)
        Me.LBLObjectID.TabIndex = 0
        Me.LBLObjectID.Text = "ObjectID:"
        '
        'TXTObjectID
        '
        Me.TXTObjectID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTObjectID.Location = New System.Drawing.Point(61, 4)
        Me.TXTObjectID.Name = "TXTObjectID"
        Me.TXTObjectID.Size = New System.Drawing.Size(87, 20)
        Me.TXTObjectID.TabIndex = 1
        '
        'PNLContainer
        '
        Me.PNLContainer.Controls.Add(Me.TXTOffsetY)
        Me.PNLContainer.Controls.Add(Me.LBLOffsetY)
        Me.PNLContainer.Controls.Add(Me.CBOTeam)
        Me.PNLContainer.Controls.Add(Me.LBLAngle)
        Me.PNLContainer.Controls.Add(Me.TXTAngle)
        Me.PNLContainer.Controls.Add(Me.LBLDamage)
        Me.PNLContainer.Controls.Add(Me.TXTDamage)
        Me.PNLContainer.Controls.Add(Me.LBLTeam)
        Me.PNLContainer.Controls.Add(Me.LBLHeight)
        Me.PNLContainer.Controls.Add(Me.TXTHeight)
        Me.PNLContainer.Controls.Add(Me.LBLWidth)
        Me.PNLContainer.Controls.Add(Me.TXTWidth)
        Me.PNLContainer.Controls.Add(Me.TXTImageUrl)
        Me.PNLContainer.Controls.Add(Me.CMDBrowse)
        Me.PNLContainer.Controls.Add(Me.TBLControls)
        Me.PNLContainer.Controls.Add(Me.LBLObjectID)
        Me.PNLContainer.Controls.Add(Me.TXTObjectID)
        Me.PNLContainer.Controls.Add(Me.LBLImageUrl)
        Me.PNLContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNLContainer.Location = New System.Drawing.Point(0, 0)
        Me.PNLContainer.Name = "PNLContainer"
        Me.PNLContainer.Size = New System.Drawing.Size(1170, 28)
        Me.PNLContainer.TabIndex = 0
        '
        'TXTOffsetY
        '
        Me.TXTOffsetY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTOffsetY.Location = New System.Drawing.Point(728, 4)
        Me.TXTOffsetY.MaxLength = 5
        Me.TXTOffsetY.Name = "TXTOffsetY"
        Me.TXTOffsetY.Size = New System.Drawing.Size(48, 20)
        Me.TXTOffsetY.TabIndex = 13
        '
        'LBLOffsetY
        '
        Me.LBLOffsetY.AutoSize = True
        Me.LBLOffsetY.Location = New System.Drawing.Point(642, 8)
        Me.LBLOffsetY.Name = "LBLOffsetY"
        Me.LBLOffsetY.Size = New System.Drawing.Size(80, 13)
        Me.LBLOffsetY.TabIndex = 12
        Me.LBLOffsetY.Text = "Image Y Offset:"
        '
        'CBOTeam
        '
        Me.CBOTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBOTeam.Items.AddRange(New Object() {"0] Astros", "1] Aliens"})
        Me.CBOTeam.Location = New System.Drawing.Point(350, 3)
        Me.CBOTeam.Name = "CBOTeam"
        Me.CBOTeam.Size = New System.Drawing.Size(75, 21)
        Me.CBOTeam.TabIndex = 7
        '
        'LBLAngle
        '
        Me.LBLAngle.AutoSize = True
        Me.LBLAngle.Location = New System.Drawing.Point(431, 8)
        Me.LBLAngle.Name = "LBLAngle"
        Me.LBLAngle.Size = New System.Drawing.Size(37, 13)
        Me.LBLAngle.TabIndex = 8
        Me.LBLAngle.Text = "Angle:"
        '
        'TXTAngle
        '
        Me.TXTAngle.AutoCompleteCustomSource.AddRange(New String() {"0", "0.25", "0.50", "0.75"})
        Me.TXTAngle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TXTAngle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TXTAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTAngle.Location = New System.Drawing.Point(474, 4)
        Me.TXTAngle.Name = "TXTAngle"
        Me.TXTAngle.Size = New System.Drawing.Size(50, 20)
        Me.TXTAngle.TabIndex = 9
        '
        'LBLDamage
        '
        Me.LBLDamage.AutoSize = True
        Me.LBLDamage.Location = New System.Drawing.Point(530, 8)
        Me.LBLDamage.Name = "LBLDamage"
        Me.LBLDamage.Size = New System.Drawing.Size(50, 13)
        Me.LBLDamage.TabIndex = 10
        Me.LBLDamage.Text = "Damage:"
        '
        'TXTDamage
        '
        Me.TXTDamage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTDamage.Location = New System.Drawing.Point(586, 4)
        Me.TXTDamage.Name = "TXTDamage"
        Me.TXTDamage.Size = New System.Drawing.Size(50, 20)
        Me.TXTDamage.TabIndex = 11
        '
        'LBLTeam
        '
        Me.LBLTeam.AutoSize = True
        Me.LBLTeam.Location = New System.Drawing.Point(307, 8)
        Me.LBLTeam.Name = "LBLTeam"
        Me.LBLTeam.Size = New System.Drawing.Size(37, 13)
        Me.LBLTeam.TabIndex = 6
        Me.LBLTeam.Text = "Team:"
        '
        'LBLHeight
        '
        Me.LBLHeight.AutoSize = True
        Me.LBLHeight.Location = New System.Drawing.Point(229, 8)
        Me.LBLHeight.Name = "LBLHeight"
        Me.LBLHeight.Size = New System.Drawing.Size(41, 13)
        Me.LBLHeight.TabIndex = 4
        Me.LBLHeight.Text = "Height:"
        '
        'TXTHeight
        '
        Me.TXTHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTHeight.Location = New System.Drawing.Point(276, 4)
        Me.TXTHeight.MaxLength = 2
        Me.TXTHeight.Name = "TXTHeight"
        Me.TXTHeight.Size = New System.Drawing.Size(25, 20)
        Me.TXTHeight.TabIndex = 5
        Me.TXTHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LBLWidth
        '
        Me.LBLWidth.AutoSize = True
        Me.LBLWidth.Location = New System.Drawing.Point(154, 8)
        Me.LBLWidth.Name = "LBLWidth"
        Me.LBLWidth.Size = New System.Drawing.Size(38, 13)
        Me.LBLWidth.TabIndex = 2
        Me.LBLWidth.Text = "Width:"
        '
        'TXTWidth
        '
        Me.TXTWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTWidth.Location = New System.Drawing.Point(198, 4)
        Me.TXTWidth.MaxLength = 2
        Me.TXTWidth.Name = "TXTWidth"
        Me.TXTWidth.Size = New System.Drawing.Size(25, 20)
        Me.TXTWidth.TabIndex = 3
        Me.TXTWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LBLImageUrl
        '
        Me.LBLImageUrl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLImageUrl.AutoSize = True
        Me.LBLImageUrl.Location = New System.Drawing.Point(782, 8)
        Me.LBLImageUrl.Name = "LBLImageUrl"
        Me.LBLImageUrl.Size = New System.Drawing.Size(39, 13)
        Me.LBLImageUrl.TabIndex = 14
        Me.LBLImageUrl.Text = "Image:"
        '
        'Entry_Object
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.PNLContainer)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "Entry_Object"
        Me.Size = New System.Drawing.Size(1170, 28)
        Me.TBLControls.ResumeLayout(False)
        Me.TBLControls.PerformLayout()
        Me.PNLContainer.ResumeLayout(False)
        Me.PNLContainer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CMDBrowse As System.Windows.Forms.Button
    Friend WithEvents TBLControls As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CMDNew As System.Windows.Forms.Button
    Friend WithEvents CMDRemove As System.Windows.Forms.Button
    Friend WithEvents TXTImageUrl As System.Windows.Forms.TextBox
    Friend WithEvents LBLObjectID As System.Windows.Forms.Label
    Friend WithEvents TXTObjectID As System.Windows.Forms.TextBox
    Friend WithEvents PNLContainer As System.Windows.Forms.Panel
    Friend WithEvents LBLImageUrl As System.Windows.Forms.Label
    Friend WithEvents LBLWidth As System.Windows.Forms.Label
    Friend WithEvents TXTWidth As System.Windows.Forms.TextBox
    Friend WithEvents LBLHeight As System.Windows.Forms.Label
    Friend WithEvents TXTHeight As System.Windows.Forms.TextBox
    Friend WithEvents LBLAngle As System.Windows.Forms.Label
    Friend WithEvents TXTAngle As System.Windows.Forms.TextBox
    Friend WithEvents LBLDamage As System.Windows.Forms.Label
    Friend WithEvents TXTDamage As System.Windows.Forms.TextBox
    Friend WithEvents LBLTeam As System.Windows.Forms.Label
    Friend WithEvents CBOTeam As System.Windows.Forms.ComboBox
    Friend WithEvents TXTOffsetY As System.Windows.Forms.TextBox
    Friend WithEvents LBLOffsetY As System.Windows.Forms.Label

End Class
