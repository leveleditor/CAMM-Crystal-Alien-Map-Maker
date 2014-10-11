<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Entry_Terrain
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
        Me.LBLTerrainID = New System.Windows.Forms.Label
        Me.TXTTerrainID = New System.Windows.Forms.TextBox
        Me.CHKIsPassable = New System.Windows.Forms.CheckBox
        Me.PNLContainer = New System.Windows.Forms.Panel
        Me.TXTImageUrl = New System.Windows.Forms.TextBox
        Me.CMDBrowse = New System.Windows.Forms.Button
        Me.TBLControls = New System.Windows.Forms.TableLayoutPanel
        Me.CMDNew = New System.Windows.Forms.Button
        Me.CMDRemove = New System.Windows.Forms.Button
        Me.CHKIsMinerals = New System.Windows.Forms.CheckBox
        Me.LBLImageUrl = New System.Windows.Forms.Label
        Me.PNLContainer.SuspendLayout()
        Me.TBLControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBLTerrainID
        '
        Me.LBLTerrainID.AutoSize = True
        Me.LBLTerrainID.Location = New System.Drawing.Point(3, 8)
        Me.LBLTerrainID.Name = "LBLTerrainID"
        Me.LBLTerrainID.Size = New System.Drawing.Size(54, 13)
        Me.LBLTerrainID.TabIndex = 0
        Me.LBLTerrainID.Text = "TerrainID:"
        '
        'TXTTerrainID
        '
        Me.TXTTerrainID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTTerrainID.Location = New System.Drawing.Point(63, 4)
        Me.TXTTerrainID.Name = "TXTTerrainID"
        Me.TXTTerrainID.Size = New System.Drawing.Size(87, 20)
        Me.TXTTerrainID.TabIndex = 1
        '
        'CHKIsPassable
        '
        Me.CHKIsPassable.AutoSize = True
        Me.CHKIsPassable.Location = New System.Drawing.Point(156, 7)
        Me.CHKIsPassable.Name = "CHKIsPassable"
        Me.CHKIsPassable.Size = New System.Drawing.Size(77, 17)
        Me.CHKIsPassable.TabIndex = 2
        Me.CHKIsPassable.Text = "IsPassable"
        Me.CHKIsPassable.UseVisualStyleBackColor = True
        '
        'PNLContainer
        '
        Me.PNLContainer.Controls.Add(Me.TXTImageUrl)
        Me.PNLContainer.Controls.Add(Me.CMDBrowse)
        Me.PNLContainer.Controls.Add(Me.TBLControls)
        Me.PNLContainer.Controls.Add(Me.LBLTerrainID)
        Me.PNLContainer.Controls.Add(Me.TXTTerrainID)
        Me.PNLContainer.Controls.Add(Me.CHKIsMinerals)
        Me.PNLContainer.Controls.Add(Me.LBLImageUrl)
        Me.PNLContainer.Controls.Add(Me.CHKIsPassable)
        Me.PNLContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNLContainer.Location = New System.Drawing.Point(0, 0)
        Me.PNLContainer.Name = "PNLContainer"
        Me.PNLContainer.Size = New System.Drawing.Size(707, 28)
        Me.PNLContainer.TabIndex = 0
        '
        'TXTImageUrl
        '
        Me.TXTImageUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTImageUrl.Location = New System.Drawing.Point(360, 4)
        Me.TXTImageUrl.Margin = New System.Windows.Forms.Padding(0)
        Me.TXTImageUrl.Name = "TXTImageUrl"
        Me.TXTImageUrl.Size = New System.Drawing.Size(138, 20)
        Me.TXTImageUrl.TabIndex = 5
        '
        'CMDBrowse
        '
        Me.CMDBrowse.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CMDBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMDBrowse.Location = New System.Drawing.Point(498, 4)
        Me.CMDBrowse.Margin = New System.Windows.Forms.Padding(0)
        Me.CMDBrowse.Name = "CMDBrowse"
        Me.CMDBrowse.Size = New System.Drawing.Size(70, 20)
        Me.CMDBrowse.TabIndex = 6
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
        Me.TBLControls.Location = New System.Drawing.Point(572, 0)
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
        'CHKIsMinerals
        '
        Me.CHKIsMinerals.AutoSize = True
        Me.CHKIsMinerals.Location = New System.Drawing.Point(239, 7)
        Me.CHKIsMinerals.Name = "CHKIsMinerals"
        Me.CHKIsMinerals.Size = New System.Drawing.Size(73, 17)
        Me.CHKIsMinerals.TabIndex = 3
        Me.CHKIsMinerals.Text = "IsMinerals"
        Me.CHKIsMinerals.UseVisualStyleBackColor = True
        '
        'LBLImageUrl
        '
        Me.LBLImageUrl.AutoSize = True
        Me.LBLImageUrl.Location = New System.Drawing.Point(318, 8)
        Me.LBLImageUrl.Name = "LBLImageUrl"
        Me.LBLImageUrl.Size = New System.Drawing.Size(39, 13)
        Me.LBLImageUrl.TabIndex = 4
        Me.LBLImageUrl.Text = "Image:"
        '
        'Entry_Terrain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.PNLContainer)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "Entry_Terrain"
        Me.Size = New System.Drawing.Size(707, 28)
        Me.PNLContainer.ResumeLayout(False)
        Me.PNLContainer.PerformLayout()
        Me.TBLControls.ResumeLayout(False)
        Me.TBLControls.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LBLTerrainID As System.Windows.Forms.Label
    Friend WithEvents TXTTerrainID As System.Windows.Forms.TextBox
    Friend WithEvents CHKIsPassable As System.Windows.Forms.CheckBox
    Friend WithEvents PNLContainer As System.Windows.Forms.Panel
    Friend WithEvents CHKIsMinerals As System.Windows.Forms.CheckBox
    Friend WithEvents TBLControls As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CMDBrowse As System.Windows.Forms.Button
    Friend WithEvents TXTImageUrl As System.Windows.Forms.TextBox
    Friend WithEvents LBLImageUrl As System.Windows.Forms.Label
    Friend WithEvents CMDNew As System.Windows.Forms.Button
    Friend WithEvents CMDRemove As System.Windows.Forms.Button

End Class
