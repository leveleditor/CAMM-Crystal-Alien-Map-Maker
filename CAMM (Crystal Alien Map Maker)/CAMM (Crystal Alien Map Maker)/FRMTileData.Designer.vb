<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMTileData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMTileData))
        Me.CMDSave = New System.Windows.Forms.Button
        Me.CMDClose = New System.Windows.Forms.Button
        Me.LBLSaved = New System.Windows.Forms.Label
        Me.LBLVar4 = New System.Windows.Forms.Label
        Me.TXTVar4 = New System.Windows.Forms.TextBox
        Me.TXTVar5 = New System.Windows.Forms.TextBox
        Me.LBLVar5 = New System.Windows.Forms.Label
        Me.OpenImage = New System.Windows.Forms.OpenFileDialog
        Me.EntrySections = New System.Windows.Forms.TabControl
        Me.TabTerrain = New System.Windows.Forms.TabPage
        Me.PNLTerrain = New System.Windows.Forms.Panel
        Me.TabBuildings = New System.Windows.Forms.TabPage
        Me.PNLBuildings = New System.Windows.Forms.Panel
        Me.TabUnits = New System.Windows.Forms.TabPage
        Me.PNLUnits = New System.Windows.Forms.Panel
        Me.PICPreview = New System.Windows.Forms.PictureBox
        Me.TXTVar6 = New System.Windows.Forms.TextBox
        Me.LBLVar6 = New System.Windows.Forms.Label
        Me.EntrySections.SuspendLayout()
        Me.TabTerrain.SuspendLayout()
        Me.TabBuildings.SuspendLayout()
        Me.TabUnits.SuspendLayout()
        CType(Me.PICPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CMDSave
        '
        Me.CMDSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDSave.Location = New System.Drawing.Point(596, 417)
        Me.CMDSave.Name = "CMDSave"
        Me.CMDSave.Size = New System.Drawing.Size(75, 23)
        Me.CMDSave.TabIndex = 13
        Me.CMDSave.Text = "Save"
        Me.CMDSave.UseVisualStyleBackColor = True
        '
        'CMDClose
        '
        Me.CMDClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CMDClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CMDClose.Location = New System.Drawing.Point(677, 417)
        Me.CMDClose.Name = "CMDClose"
        Me.CMDClose.Size = New System.Drawing.Size(75, 23)
        Me.CMDClose.TabIndex = 0
        Me.CMDClose.Text = "Close"
        Me.CMDClose.UseVisualStyleBackColor = True
        '
        'LBLSaved
        '
        Me.LBLSaved.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLSaved.AutoSize = True
        Me.LBLSaved.ForeColor = System.Drawing.Color.DarkGreen
        Me.LBLSaved.Location = New System.Drawing.Point(523, 422)
        Me.LBLSaved.Name = "LBLSaved"
        Me.LBLSaved.Size = New System.Drawing.Size(67, 13)
        Me.LBLSaved.TabIndex = 12
        Me.LBLSaved.Text = "Data Saved!"
        Me.LBLSaved.Visible = False
        '
        'LBLVar4
        '
        Me.LBLVar4.AutoSize = True
        Me.LBLVar4.Location = New System.Drawing.Point(156, 9)
        Me.LBLVar4.Name = "LBLVar4"
        Me.LBLVar4.Size = New System.Drawing.Size(79, 13)
        Me.LBLVar4.TabIndex = 7
        Me.LBLVar4.Text = "Array Modifiers:"
        '
        'TXTVar4
        '
        Me.TXTVar4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTVar4.Location = New System.Drawing.Point(241, 5)
        Me.TXTVar4.Name = "TXTVar4"
        Me.TXTVar4.ReadOnly = True
        Me.TXTVar4.Size = New System.Drawing.Size(55, 22)
        Me.TXTVar4.TabIndex = 8
        Me.TXTVar4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TXTVar5
        '
        Me.TXTVar5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTVar5.Location = New System.Drawing.Point(391, 5)
        Me.TXTVar5.Name = "TXTVar5"
        Me.TXTVar5.ReadOnly = True
        Me.TXTVar5.Size = New System.Drawing.Size(55, 22)
        Me.TXTVar5.TabIndex = 10
        Me.TXTVar5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LBLVar5
        '
        Me.LBLVar5.AutoSize = True
        Me.LBLVar5.Location = New System.Drawing.Point(302, 9)
        Me.LBLVar5.Name = "LBLVar5"
        Me.LBLVar5.Size = New System.Drawing.Size(83, 13)
        Me.LBLVar5.TabIndex = 9
        Me.LBLVar5.Text = "Array Separator:"
        '
        'OpenImage
        '
        Me.OpenImage.Filter = "Image Files|*.png;*.bmp;*.jpg"
        Me.OpenImage.Title = "Select An Image File..."
        '
        'EntrySections
        '
        Me.EntrySections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EntrySections.Controls.Add(Me.TabTerrain)
        Me.EntrySections.Controls.Add(Me.TabBuildings)
        Me.EntrySections.Controls.Add(Me.TabUnits)
        Me.EntrySections.Location = New System.Drawing.Point(9, 30)
        Me.EntrySections.Margin = New System.Windows.Forms.Padding(0)
        Me.EntrySections.Name = "EntrySections"
        Me.EntrySections.SelectedIndex = 0
        Me.EntrySections.Size = New System.Drawing.Size(746, 384)
        Me.EntrySections.TabIndex = 11
        '
        'TabTerrain
        '
        Me.TabTerrain.AutoScroll = True
        Me.TabTerrain.BackColor = System.Drawing.Color.Silver
        Me.TabTerrain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabTerrain.Controls.Add(Me.PNLTerrain)
        Me.TabTerrain.Location = New System.Drawing.Point(4, 22)
        Me.TabTerrain.Margin = New System.Windows.Forms.Padding(0)
        Me.TabTerrain.Name = "TabTerrain"
        Me.TabTerrain.Size = New System.Drawing.Size(738, 358)
        Me.TabTerrain.TabIndex = 0
        Me.TabTerrain.Text = "Edit Terrain"
        Me.TabTerrain.UseVisualStyleBackColor = True
        '
        'PNLTerrain
        '
        Me.PNLTerrain.AutoSize = True
        Me.PNLTerrain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PNLTerrain.Location = New System.Drawing.Point(0, 0)
        Me.PNLTerrain.Margin = New System.Windows.Forms.Padding(0)
        Me.PNLTerrain.Name = "PNLTerrain"
        Me.PNLTerrain.Padding = New System.Windows.Forms.Padding(3)
        Me.PNLTerrain.Size = New System.Drawing.Size(6, 6)
        Me.PNLTerrain.TabIndex = 0
        '
        'TabBuildings
        '
        Me.TabBuildings.AutoScroll = True
        Me.TabBuildings.BackColor = System.Drawing.Color.Silver
        Me.TabBuildings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabBuildings.Controls.Add(Me.PNLBuildings)
        Me.TabBuildings.Location = New System.Drawing.Point(4, 22)
        Me.TabBuildings.Margin = New System.Windows.Forms.Padding(0)
        Me.TabBuildings.Name = "TabBuildings"
        Me.TabBuildings.Size = New System.Drawing.Size(738, 358)
        Me.TabBuildings.TabIndex = 1
        Me.TabBuildings.Text = "Edit Buildings"
        Me.TabBuildings.UseVisualStyleBackColor = True
        '
        'PNLBuildings
        '
        Me.PNLBuildings.AutoSize = True
        Me.PNLBuildings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PNLBuildings.Location = New System.Drawing.Point(0, 0)
        Me.PNLBuildings.Margin = New System.Windows.Forms.Padding(0)
        Me.PNLBuildings.Name = "PNLBuildings"
        Me.PNLBuildings.Padding = New System.Windows.Forms.Padding(3)
        Me.PNLBuildings.Size = New System.Drawing.Size(6, 6)
        Me.PNLBuildings.TabIndex = 1
        '
        'TabUnits
        '
        Me.TabUnits.AutoScroll = True
        Me.TabUnits.BackColor = System.Drawing.Color.Silver
        Me.TabUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabUnits.Controls.Add(Me.PNLUnits)
        Me.TabUnits.Location = New System.Drawing.Point(4, 22)
        Me.TabUnits.Margin = New System.Windows.Forms.Padding(0)
        Me.TabUnits.Name = "TabUnits"
        Me.TabUnits.Size = New System.Drawing.Size(738, 358)
        Me.TabUnits.TabIndex = 2
        Me.TabUnits.Text = "Edit Units"
        Me.TabUnits.UseVisualStyleBackColor = True
        '
        'PNLUnits
        '
        Me.PNLUnits.AutoSize = True
        Me.PNLUnits.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PNLUnits.Location = New System.Drawing.Point(0, 0)
        Me.PNLUnits.Margin = New System.Windows.Forms.Padding(0)
        Me.PNLUnits.Name = "PNLUnits"
        Me.PNLUnits.Padding = New System.Windows.Forms.Padding(3)
        Me.PNLUnits.Size = New System.Drawing.Size(6, 6)
        Me.PNLUnits.TabIndex = 2
        '
        'PICPreview
        '
        Me.PICPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PICPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PICPreview.Location = New System.Drawing.Point(0, 404)
        Me.PICPreview.Name = "PICPreview"
        Me.PICPreview.Size = New System.Drawing.Size(96, 48)
        Me.PICPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PICPreview.TabIndex = 14
        Me.PICPreview.TabStop = False
        Me.PICPreview.Visible = False
        '
        'TXTVar6
        '
        Me.TXTVar6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTVar6.Location = New System.Drawing.Point(95, 5)
        Me.TXTVar6.Name = "TXTVar6"
        Me.TXTVar6.ReadOnly = True
        Me.TXTVar6.Size = New System.Drawing.Size(55, 22)
        Me.TXTVar6.TabIndex = 10
        Me.TXTVar6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LBLVar6
        '
        Me.LBLVar6.AutoSize = True
        Me.LBLVar6.Location = New System.Drawing.Point(8, 9)
        Me.LBLVar6.Name = "LBLVar6"
        Me.LBLVar6.Size = New System.Drawing.Size(81, 13)
        Me.LBLVar6.TabIndex = 9
        Me.LBLVar6.Text = "Ascii Separator:"
        '
        'FRMTileData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CMDClose
        Me.ClientSize = New System.Drawing.Size(764, 452)
        Me.Controls.Add(Me.PICPreview)
        Me.Controls.Add(Me.EntrySections)
        Me.Controls.Add(Me.LBLVar6)
        Me.Controls.Add(Me.TXTVar6)
        Me.Controls.Add(Me.LBLVar5)
        Me.Controls.Add(Me.TXTVar5)
        Me.Controls.Add(Me.TXTVar4)
        Me.Controls.Add(Me.LBLVar4)
        Me.Controls.Add(Me.LBLSaved)
        Me.Controls.Add(Me.CMDClose)
        Me.Controls.Add(Me.CMDSave)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FRMTileData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tile Data Editor [Tiles.dat]"
        Me.EntrySections.ResumeLayout(False)
        Me.TabTerrain.ResumeLayout(False)
        Me.TabTerrain.PerformLayout()
        Me.TabBuildings.ResumeLayout(False)
        Me.TabBuildings.PerformLayout()
        Me.TabUnits.ResumeLayout(False)
        Me.TabUnits.PerformLayout()
        CType(Me.PICPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CMDSave As System.Windows.Forms.Button
    Friend WithEvents CMDClose As System.Windows.Forms.Button
    Friend WithEvents LBLSaved As System.Windows.Forms.Label
    Friend WithEvents LBLVar4 As System.Windows.Forms.Label
    Friend WithEvents TXTVar4 As System.Windows.Forms.TextBox
    Friend WithEvents TXTVar5 As System.Windows.Forms.TextBox
    Friend WithEvents LBLVar5 As System.Windows.Forms.Label
    Friend WithEvents OpenImage As System.Windows.Forms.OpenFileDialog
    Friend WithEvents EntrySections As System.Windows.Forms.TabControl
    Friend WithEvents TabTerrain As System.Windows.Forms.TabPage
    Friend WithEvents TabBuildings As System.Windows.Forms.TabPage
    Friend WithEvents PNLTerrain As System.Windows.Forms.Panel
    Friend WithEvents PNLBuildings As System.Windows.Forms.Panel
    Friend WithEvents PICPreview As System.Windows.Forms.PictureBox
    Friend WithEvents TabUnits As System.Windows.Forms.TabPage
    Friend WithEvents PNLUnits As System.Windows.Forms.Panel
    Friend WithEvents TXTVar6 As System.Windows.Forms.TextBox
    Friend WithEvents LBLVar6 As System.Windows.Forms.Label
End Class
