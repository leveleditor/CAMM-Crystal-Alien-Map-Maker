<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMImportAS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMImportAS))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.LBLExample = New System.Windows.Forms.Label
        Me.TXTExample = New System.Windows.Forms.TextBox
        Me.LBLPaste = New System.Windows.Forms.Label
        Me.TXTPaste = New System.Windows.Forms.TextBox
        Me.LBLPickMap = New System.Windows.Forms.Label
        Me.CBOPickMap = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(356, 224)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Enabled = False
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'LBLExample
        '
        Me.LBLExample.AutoSize = True
        Me.LBLExample.Location = New System.Drawing.Point(12, 9)
        Me.LBLExample.Name = "LBLExample"
        Me.LBLExample.Size = New System.Drawing.Size(270, 13)
        Me.LBLExample.TabIndex = 2
        Me.LBLExample.Text = "The ActionScript code should be in the following format:"
        '
        'TXTExample
        '
        Me.TXTExample.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTExample.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTExample.Location = New System.Drawing.Point(12, 27)
        Me.TXTExample.Multiline = True
        Me.TXTExample.Name = "TXTExample"
        Me.TXTExample.ReadOnly = True
        Me.TXTExample.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.TXTExample.Size = New System.Drawing.Size(490, 86)
        Me.TXTExample.TabIndex = 3
        Me.TXTExample.Text = resources.GetString("TXTExample.Text")
        Me.TXTExample.WordWrap = False
        '
        'LBLPaste
        '
        Me.LBLPaste.AutoSize = True
        Me.LBLPaste.Location = New System.Drawing.Point(12, 116)
        Me.LBLPaste.Name = "LBLPaste"
        Me.LBLPaste.Size = New System.Drawing.Size(166, 13)
        Me.LBLPaste.TabIndex = 0
        Me.LBLPaste.Text = "Paste the ActionScript code here:"
        '
        'TXTPaste
        '
        Me.TXTPaste.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTPaste.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPaste.Location = New System.Drawing.Point(12, 132)
        Me.TXTPaste.Multiline = True
        Me.TXTPaste.Name = "TXTPaste"
        Me.TXTPaste.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TXTPaste.Size = New System.Drawing.Size(490, 86)
        Me.TXTPaste.TabIndex = 1
        Me.TXTPaste.WordWrap = False
        '
        'LBLPickMap
        '
        Me.LBLPickMap.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBLPickMap.AutoSize = True
        Me.LBLPickMap.Location = New System.Drawing.Point(12, 232)
        Me.LBLPickMap.Name = "LBLPickMap"
        Me.LBLPickMap.Size = New System.Drawing.Size(74, 13)
        Me.LBLPickMap.TabIndex = 5
        Me.LBLPickMap.Text = "Map to import:"
        '
        'CBOPickMap
        '
        Me.CBOPickMap.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CBOPickMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBOPickMap.Enabled = False
        Me.CBOPickMap.FormattingEnabled = True
        Me.CBOPickMap.Items.AddRange(New Object() {"Please select..."})
        Me.CBOPickMap.Location = New System.Drawing.Point(92, 229)
        Me.CBOPickMap.Name = "CBOPickMap"
        Me.CBOPickMap.Size = New System.Drawing.Size(121, 21)
        Me.CBOPickMap.TabIndex = 6
        '
        'FRMImportAS
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(514, 265)
        Me.Controls.Add(Me.CBOPickMap)
        Me.Controls.Add(Me.LBLPickMap)
        Me.Controls.Add(Me.TXTPaste)
        Me.Controls.Add(Me.TXTExample)
        Me.Controls.Add(Me.LBLPaste)
        Me.Controls.Add(Me.LBLExample)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(530, 303)
        Me.Name = "FRMImportAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import ActionScript Code..."
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents LBLExample As System.Windows.Forms.Label
    Friend WithEvents TXTExample As System.Windows.Forms.TextBox
    Friend WithEvents LBLPaste As System.Windows.Forms.Label
    Friend WithEvents TXTPaste As System.Windows.Forms.TextBox
    Friend WithEvents LBLPickMap As System.Windows.Forms.Label
    Friend WithEvents CBOPickMap As System.Windows.Forms.ComboBox

End Class
