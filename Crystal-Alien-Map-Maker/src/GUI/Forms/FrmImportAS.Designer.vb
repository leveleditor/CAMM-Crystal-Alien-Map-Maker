<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportAS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImportAS))
        Me.tblButtons = New System.Windows.Forms.TableLayoutPanel()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblExample = New System.Windows.Forms.Label()
        Me.txtExample = New System.Windows.Forms.TextBox()
        Me.lblPaste = New System.Windows.Forms.Label()
        Me.txtPaste = New System.Windows.Forms.TextBox()
        Me.lblPickMap = New System.Windows.Forms.Label()
        Me.cboPickMap = New System.Windows.Forms.ComboBox()
        Me.tblButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'tblButtons
        '
        Me.tblButtons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblButtons.ColumnCount = 2
        Me.tblButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblButtons.Controls.Add(Me.btnOk, 0, 0)
        Me.tblButtons.Controls.Add(Me.btnCancel, 1, 0)
        Me.tblButtons.Location = New System.Drawing.Point(356, 224)
        Me.tblButtons.Name = "tblButtons"
        Me.tblButtons.RowCount = 1
        Me.tblButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblButtons.Size = New System.Drawing.Size(146, 29)
        Me.tblButtons.TabIndex = 4
        '
        'btnOk
        '
        Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOk.Enabled = False
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
        'lblExample
        '
        Me.lblExample.AutoSize = True
        Me.lblExample.Location = New System.Drawing.Point(12, 9)
        Me.lblExample.Name = "lblExample"
        Me.lblExample.Size = New System.Drawing.Size(270, 13)
        Me.lblExample.TabIndex = 2
        Me.lblExample.Text = "The ActionScript code should be in the following format:"
        '
        'txtExample
        '
        Me.txtExample.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExample.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExample.Location = New System.Drawing.Point(12, 27)
        Me.txtExample.Multiline = True
        Me.txtExample.Name = "txtExample"
        Me.txtExample.ReadOnly = True
        Me.txtExample.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtExample.Size = New System.Drawing.Size(490, 86)
        Me.txtExample.TabIndex = 3
        Me.txtExample.Text = resources.GetString("txtExample.Text")
        Me.txtExample.WordWrap = False
        '
        'lblPaste
        '
        Me.lblPaste.AutoSize = True
        Me.lblPaste.Location = New System.Drawing.Point(12, 116)
        Me.lblPaste.Name = "lblPaste"
        Me.lblPaste.Size = New System.Drawing.Size(166, 13)
        Me.lblPaste.TabIndex = 0
        Me.lblPaste.Text = "Paste the ActionScript code here:"
        '
        'txtPaste
        '
        Me.txtPaste.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPaste.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaste.Location = New System.Drawing.Point(12, 132)
        Me.txtPaste.Multiline = True
        Me.txtPaste.Name = "txtPaste"
        Me.txtPaste.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPaste.Size = New System.Drawing.Size(490, 86)
        Me.txtPaste.TabIndex = 1
        Me.txtPaste.WordWrap = False
        '
        'lblPickMap
        '
        Me.lblPickMap.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPickMap.AutoSize = True
        Me.lblPickMap.Location = New System.Drawing.Point(12, 232)
        Me.lblPickMap.Name = "lblPickMap"
        Me.lblPickMap.Size = New System.Drawing.Size(74, 13)
        Me.lblPickMap.TabIndex = 5
        Me.lblPickMap.Text = "Map to import:"
        '
        'cboPickMap
        '
        Me.cboPickMap.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboPickMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPickMap.Enabled = False
        Me.cboPickMap.FormattingEnabled = True
        Me.cboPickMap.Items.AddRange(New Object() {"Please select..."})
        Me.cboPickMap.Location = New System.Drawing.Point(92, 229)
        Me.cboPickMap.Name = "cboPickMap"
        Me.cboPickMap.Size = New System.Drawing.Size(121, 21)
        Me.cboPickMap.TabIndex = 6
        '
        'FrmImportAS
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(514, 265)
        Me.Controls.Add(Me.cboPickMap)
        Me.Controls.Add(Me.lblPickMap)
        Me.Controls.Add(Me.txtPaste)
        Me.Controls.Add(Me.txtExample)
        Me.Controls.Add(Me.lblPaste)
        Me.Controls.Add(Me.lblExample)
        Me.Controls.Add(Me.tblButtons)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(530, 303)
        Me.Name = "FrmImportAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import ActionScript Code..."
        Me.tblButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tblButtons As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblExample As System.Windows.Forms.Label
    Friend WithEvents txtExample As System.Windows.Forms.TextBox
    Friend WithEvents lblPaste As System.Windows.Forms.Label
    Friend WithEvents txtPaste As System.Windows.Forms.TextBox
    Friend WithEvents lblPickMap As System.Windows.Forms.Label
    Friend WithEvents cboPickMap As System.Windows.Forms.ComboBox

End Class
