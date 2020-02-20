<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfigEditor))
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblSaved = New System.Windows.Forms.Label()
        Me.openImage = New System.Windows.Forms.OpenFileDialog()
        Me.editTabs = New System.Windows.Forms.TabControl()
        Me.tabTiles = New System.Windows.Forms.TabPage()
        Me.pnlTiles = New System.Windows.Forms.Panel()
        Me.tabBuildings = New System.Windows.Forms.TabPage()
        Me.pnlBuildings = New System.Windows.Forms.Panel()
        Me.tabUnits = New System.Windows.Forms.TabPage()
        Me.pnlUnits = New System.Windows.Forms.Panel()
        Me.tabConfig = New System.Windows.Forms.TabPage()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.editTabs.SuspendLayout()
        Me.tabTiles.SuspendLayout()
        Me.tabBuildings.SuspendLayout()
        Me.tabUnits.SuspendLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSaveAll
        '
        Me.btnSaveAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAll.Location = New System.Drawing.Point(596, 417)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveAll.TabIndex = 13
        Me.btnSaveAll.Text = "Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
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
        Me.editTabs.Controls.Add(Me.tabTiles)
        Me.editTabs.Controls.Add(Me.tabBuildings)
        Me.editTabs.Controls.Add(Me.tabUnits)
        Me.editTabs.Controls.Add(Me.tabConfig)
        Me.editTabs.Location = New System.Drawing.Point(9, 56)
        Me.editTabs.Margin = New System.Windows.Forms.Padding(0)
        Me.editTabs.Name = "editTabs"
        Me.editTabs.SelectedIndex = 0
        Me.editTabs.Size = New System.Drawing.Size(746, 358)
        Me.editTabs.TabIndex = 11
        '
        'tabTiles
        '
        Me.tabTiles.AutoScroll = True
        Me.tabTiles.BackColor = System.Drawing.Color.Silver
        Me.tabTiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabTiles.Controls.Add(Me.pnlTiles)
        Me.tabTiles.Location = New System.Drawing.Point(4, 22)
        Me.tabTiles.Margin = New System.Windows.Forms.Padding(0)
        Me.tabTiles.Name = "tabTiles"
        Me.tabTiles.Size = New System.Drawing.Size(738, 332)
        Me.tabTiles.TabIndex = 0
        Me.tabTiles.Text = "Edit Tiles"
        '
        'pnlTiles
        '
        Me.pnlTiles.AutoSize = True
        Me.pnlTiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlTiles.Location = New System.Drawing.Point(0, 0)
        Me.pnlTiles.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlTiles.Name = "pnlTiles"
        Me.pnlTiles.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlTiles.Size = New System.Drawing.Size(6, 6)
        Me.pnlTiles.TabIndex = 0
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
        Me.tabBuildings.Size = New System.Drawing.Size(738, 347)
        Me.tabBuildings.TabIndex = 1
        Me.tabBuildings.Text = "Edit Buildings"
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
        Me.tabUnits.Size = New System.Drawing.Size(738, 347)
        Me.tabUnits.TabIndex = 2
        Me.tabUnits.Text = "Edit Units"
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
        'tabConfig
        '
        Me.tabConfig.AutoScroll = True
        Me.tabConfig.BackColor = System.Drawing.Color.Silver
        Me.tabConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabConfig.Location = New System.Drawing.Point(4, 22)
        Me.tabConfig.Margin = New System.Windows.Forms.Padding(0)
        Me.tabConfig.Name = "tabConfig"
        Me.tabConfig.Size = New System.Drawing.Size(738, 347)
        Me.tabConfig.TabIndex = 3
        Me.tabConfig.Text = "Edit Config"
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
        'lblWarning
        '
        Me.lblWarning.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWarning.Location = New System.Drawing.Point(12, 9)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(740, 44)
        Me.lblWarning.TabIndex = 15
        Me.lblWarning.Text = resources.GetString("lblWarning.Text")
        '
        'FrmConfigEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(764, 452)
        Me.Controls.Add(Me.lblWarning)
        Me.Controls.Add(Me.picPreview)
        Me.Controls.Add(Me.editTabs)
        Me.Controls.Add(Me.lblSaved)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSaveAll)
        Me.DoubleBuffered = True
        Me.Name = "FrmConfigEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuration Editor"
        Me.editTabs.ResumeLayout(False)
        Me.tabTiles.ResumeLayout(False)
        Me.tabTiles.PerformLayout()
        Me.tabBuildings.ResumeLayout(False)
        Me.tabBuildings.PerformLayout()
        Me.tabUnits.ResumeLayout(False)
        Me.tabUnits.PerformLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblSaved As System.Windows.Forms.Label
    Friend WithEvents openImage As System.Windows.Forms.OpenFileDialog
    Friend WithEvents editTabs As System.Windows.Forms.TabControl
    Friend WithEvents tabTiles As System.Windows.Forms.TabPage
    Friend WithEvents tabBuildings As System.Windows.Forms.TabPage
    Friend WithEvents pnlTiles As System.Windows.Forms.Panel
    Friend WithEvents pnlBuildings As System.Windows.Forms.Panel
    Friend WithEvents picPreview As System.Windows.Forms.PictureBox
    Friend WithEvents tabUnits As System.Windows.Forms.TabPage
    Friend WithEvents pnlUnits As System.Windows.Forms.Panel
    Friend WithEvents tabConfig As System.Windows.Forms.TabPage
    Friend WithEvents lblWarning As Label
End Class
