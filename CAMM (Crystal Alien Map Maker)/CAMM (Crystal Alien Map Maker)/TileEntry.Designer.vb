<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TileEntry
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
        Me.lblTileId = New System.Windows.Forms.Label()
        Me.txtTileId = New System.Windows.Forms.TextBox()
        Me.chkIsPassable = New System.Windows.Forms.CheckBox()
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.txtImageUrl = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.tblControls = New System.Windows.Forms.TableLayoutPanel()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.chkIsMinerals = New System.Windows.Forms.CheckBox()
        Me.lblImageUrl = New System.Windows.Forms.Label()
        Me.pnlContainer.SuspendLayout()
        Me.tblControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTileId
        '
        Me.lblTileId.AutoSize = True
        Me.lblTileId.Location = New System.Drawing.Point(3, 8)
        Me.lblTileId.Name = "lblTileId"
        Me.lblTileId.Size = New System.Drawing.Size(36, 13)
        Me.lblTileId.TabIndex = 0
        Me.lblTileId.Text = "TileId:"
        '
        'txtTileId
        '
        Me.txtTileId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTileId.Location = New System.Drawing.Point(45, 4)
        Me.txtTileId.Name = "txtTileId"
        Me.txtTileId.Size = New System.Drawing.Size(87, 20)
        Me.txtTileId.TabIndex = 1
        '
        'chkIsPassable
        '
        Me.chkIsPassable.AutoSize = True
        Me.chkIsPassable.Location = New System.Drawing.Point(138, 7)
        Me.chkIsPassable.Name = "chkIsPassable"
        Me.chkIsPassable.Size = New System.Drawing.Size(77, 17)
        Me.chkIsPassable.TabIndex = 2
        Me.chkIsPassable.Text = "IsPassable"
        Me.chkIsPassable.UseVisualStyleBackColor = True
        '
        'pnlContainer
        '
        Me.pnlContainer.Controls.Add(Me.txtImageUrl)
        Me.pnlContainer.Controls.Add(Me.btnBrowse)
        Me.pnlContainer.Controls.Add(Me.tblControls)
        Me.pnlContainer.Controls.Add(Me.lblTileId)
        Me.pnlContainer.Controls.Add(Me.txtTileId)
        Me.pnlContainer.Controls.Add(Me.chkIsMinerals)
        Me.pnlContainer.Controls.Add(Me.lblImageUrl)
        Me.pnlContainer.Controls.Add(Me.chkIsPassable)
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(689, 28)
        Me.pnlContainer.TabIndex = 0
        '
        'txtImageUrl
        '
        Me.txtImageUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImageUrl.Location = New System.Drawing.Point(342, 4)
        Me.txtImageUrl.Margin = New System.Windows.Forms.Padding(0)
        Me.txtImageUrl.Name = "txtImageUrl"
        Me.txtImageUrl.Size = New System.Drawing.Size(138, 20)
        Me.txtImageUrl.TabIndex = 5
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBrowse.Location = New System.Drawing.Point(480, 4)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(0)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(70, 20)
        Me.btnBrowse.TabIndex = 6
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = False
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
        Me.tblControls.Location = New System.Drawing.Point(554, 0)
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
        'chkIsMinerals
        '
        Me.chkIsMinerals.AutoSize = True
        Me.chkIsMinerals.Location = New System.Drawing.Point(221, 7)
        Me.chkIsMinerals.Name = "chkIsMinerals"
        Me.chkIsMinerals.Size = New System.Drawing.Size(73, 17)
        Me.chkIsMinerals.TabIndex = 3
        Me.chkIsMinerals.Text = "IsMinerals"
        Me.chkIsMinerals.UseVisualStyleBackColor = True
        '
        'lblImageUrl
        '
        Me.lblImageUrl.AutoSize = True
        Me.lblImageUrl.Location = New System.Drawing.Point(300, 8)
        Me.lblImageUrl.Name = "lblImageUrl"
        Me.lblImageUrl.Size = New System.Drawing.Size(39, 13)
        Me.lblImageUrl.TabIndex = 4
        Me.lblImageUrl.Text = "Image:"
        '
        'TileEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.pnlContainer)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "TileEntry"
        Me.Size = New System.Drawing.Size(689, 28)
        Me.pnlContainer.ResumeLayout(False)
        Me.pnlContainer.PerformLayout()
        Me.tblControls.ResumeLayout(False)
        Me.tblControls.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTileId As System.Windows.Forms.Label
    Friend WithEvents txtTileId As System.Windows.Forms.TextBox
    Friend WithEvents chkIsPassable As System.Windows.Forms.CheckBox
    Friend WithEvents pnlContainer As System.Windows.Forms.Panel
    Friend WithEvents chkIsMinerals As System.Windows.Forms.CheckBox
    Friend WithEvents tblControls As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtImageUrl As System.Windows.Forms.TextBox
    Friend WithEvents lblImageUrl As System.Windows.Forms.Label
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button

End Class
