<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTileData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTileData))
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblSaved = New System.Windows.Forms.Label
        Me.openImage = New System.Windows.Forms.OpenFileDialog
        Me.editTabs = New System.Windows.Forms.TabControl
        Me.tabTerrain = New System.Windows.Forms.TabPage
        Me.pnlTerrain = New System.Windows.Forms.Panel
        Me.tabBuildings = New System.Windows.Forms.TabPage
        Me.pnlBuildings = New System.Windows.Forms.Panel
        Me.tabUnits = New System.Windows.Forms.TabPage
        Me.pnlUnits = New System.Windows.Forms.Panel
        Me.picPreview = New System.Windows.Forms.PictureBox
        Me.txtAsciiSeparator = New System.Windows.Forms.TextBox
        Me.lblAsciiSeparator = New System.Windows.Forms.Label
        Me.editTabs.SuspendLayout()
        Me.tabTerrain.SuspendLayout()
        Me.tabBuildings.SuspendLayout()
        Me.tabUnits.SuspendLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(596, 417)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(677, 417)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblSaved
        '
        Me.lblSaved.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaved.AutoSize = True
        Me.lblSaved.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblSaved.Location = New System.Drawing.Point(523, 422)
        Me.lblSaved.Name = "lblSaved"
        Me.lblSaved.Size = New System.Drawing.Size(67, 13)
        Me.lblSaved.TabIndex = 12
        Me.lblSaved.Text = "Data Saved!"
        Me.lblSaved.Visible = False
        '
        'openImage
        '
        Me.openImage.Filter = "Image Files|*.png;*.bmp;*.jpg"
        Me.openImage.Title = "Select An Image File..."
        '
        'editTabs
        '
        Me.editTabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.editTabs.Controls.Add(Me.tabTerrain)
        Me.editTabs.Controls.Add(Me.tabBuildings)
        Me.editTabs.Controls.Add(Me.tabUnits)
        Me.editTabs.Location = New System.Drawing.Point(9, 30)
        Me.editTabs.Margin = New System.Windows.Forms.Padding(0)
        Me.editTabs.Name = "editTabs"
        Me.editTabs.SelectedIndex = 0
        Me.editTabs.Size = New System.Drawing.Size(746, 384)
        Me.editTabs.TabIndex = 11
        '
        'tabTerrain
        '
        Me.tabTerrain.AutoScroll = True
        Me.tabTerrain.BackColor = System.Drawing.Color.Silver
        Me.tabTerrain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabTerrain.Controls.Add(Me.pnlTerrain)
        Me.tabTerrain.Location = New System.Drawing.Point(4, 22)
        Me.tabTerrain.Margin = New System.Windows.Forms.Padding(0)
        Me.tabTerrain.Name = "tabTerrain"
        Me.tabTerrain.Size = New System.Drawing.Size(738, 358)
        Me.tabTerrain.TabIndex = 0
        Me.tabTerrain.Text = "Edit Terrain"
        Me.tabTerrain.UseVisualStyleBackColor = True
        '
        'pnlTerrain
        '
        Me.pnlTerrain.AutoSize = True
        Me.pnlTerrain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlTerrain.Location = New System.Drawing.Point(0, 0)
        Me.pnlTerrain.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlTerrain.Name = "pnlTerrain"
        Me.pnlTerrain.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlTerrain.Size = New System.Drawing.Size(6, 6)
        Me.pnlTerrain.TabIndex = 0
        '
        'tabBuildings
        '
        Me.tabBuildings.AutoScroll = True
        Me.tabBuildings.BackColor = System.Drawing.Color.Silver
        Me.tabBuildings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabBuildings.Controls.Add(Me.pnlBuildings)
        Me.tabBuildings.Location = New System.Drawing.Point(4, 22)
        Me.tabBuildings.Margin = New System.Windows.Forms.Padding(0)
        Me.tabBuildings.Name = "tabBuildings"
        Me.tabBuildings.Size = New System.Drawing.Size(738, 358)
        Me.tabBuildings.TabIndex = 1
        Me.tabBuildings.Text = "Edit Buildings"
        Me.tabBuildings.UseVisualStyleBackColor = True
        '
        'pnlBuildings
        '
        Me.pnlBuildings.AutoSize = True
        Me.pnlBuildings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlBuildings.Location = New System.Drawing.Point(0, 0)
        Me.pnlBuildings.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBuildings.Name = "pnlBuildings"
        Me.pnlBuildings.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlBuildings.Size = New System.Drawing.Size(6, 6)
        Me.pnlBuildings.TabIndex = 1
        '
        'tabUnits
        '
        Me.tabUnits.AutoScroll = True
        Me.tabUnits.BackColor = System.Drawing.Color.Silver
        Me.tabUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabUnits.Controls.Add(Me.pnlUnits)
        Me.tabUnits.Location = New System.Drawing.Point(4, 22)
        Me.tabUnits.Margin = New System.Windows.Forms.Padding(0)
        Me.tabUnits.Name = "tabUnits"
        Me.tabUnits.Size = New System.Drawing.Size(738, 358)
        Me.tabUnits.TabIndex = 2
        Me.tabUnits.Text = "Edit Units"
        Me.tabUnits.UseVisualStyleBackColor = True
        '
        'pnlUnits
        '
        Me.pnlUnits.AutoSize = True
        Me.pnlUnits.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlUnits.Location = New System.Drawing.Point(0, 0)
        Me.pnlUnits.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlUnits.Name = "pnlUnits"
        Me.pnlUnits.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlUnits.Size = New System.Drawing.Size(6, 6)
        Me.pnlUnits.TabIndex = 2
        '
        'picPreview
        '
        Me.picPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picPreview.Location = New System.Drawing.Point(0, 404)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(96, 48)
        Me.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picPreview.TabIndex = 14
        Me.picPreview.TabStop = False
        Me.picPreview.Visible = False
        '
        'txtAsciiSeparator
        '
        Me.txtAsciiSeparator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAsciiSeparator.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAsciiSeparator.Location = New System.Drawing.Point(95, 5)
        Me.txtAsciiSeparator.Name = "txtAsciiSeparator"
        Me.txtAsciiSeparator.ReadOnly = True
        Me.txtAsciiSeparator.Size = New System.Drawing.Size(55, 22)
        Me.txtAsciiSeparator.TabIndex = 10
        Me.txtAsciiSeparator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblAsciiSeparator
        '
        Me.lblAsciiSeparator.AutoSize = True
        Me.lblAsciiSeparator.Location = New System.Drawing.Point(8, 9)
        Me.lblAsciiSeparator.Name = "lblAsciiSeparator"
        Me.lblAsciiSeparator.Size = New System.Drawing.Size(81, 13)
        Me.lblAsciiSeparator.TabIndex = 9
        Me.lblAsciiSeparator.Text = "Ascii Separator:"
        '
        'FrmTileData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(764, 452)
        Me.Controls.Add(Me.picPreview)
        Me.Controls.Add(Me.editTabs)
        Me.Controls.Add(Me.lblAsciiSeparator)
        Me.Controls.Add(Me.txtAsciiSeparator)
        Me.Controls.Add(Me.lblSaved)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTileData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tile Data Editor [Tiles.dat]"
        Me.editTabs.ResumeLayout(False)
        Me.tabTerrain.ResumeLayout(False)
        Me.tabTerrain.PerformLayout()
        Me.tabBuildings.ResumeLayout(False)
        Me.tabBuildings.PerformLayout()
        Me.tabUnits.ResumeLayout(False)
        Me.tabUnits.PerformLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblSaved As System.Windows.Forms.Label
    Friend WithEvents openImage As System.Windows.Forms.OpenFileDialog
    Friend WithEvents editTabs As System.Windows.Forms.TabControl
    Friend WithEvents tabTerrain As System.Windows.Forms.TabPage
    Friend WithEvents tabBuildings As System.Windows.Forms.TabPage
    Friend WithEvents pnlTerrain As System.Windows.Forms.Panel
    Friend WithEvents pnlBuildings As System.Windows.Forms.Panel
    Friend WithEvents picPreview As System.Windows.Forms.PictureBox
    Friend WithEvents tabUnits As System.Windows.Forms.TabPage
    Friend WithEvents pnlUnits As System.Windows.Forms.Panel
    Friend WithEvents txtAsciiSeparator As System.Windows.Forms.TextBox
    Friend WithEvents lblAsciiSeparator As System.Windows.Forms.Label
End Class
