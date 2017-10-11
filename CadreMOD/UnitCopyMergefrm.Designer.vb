<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnitCopyMerge_frm
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
        Me.Cancel_cmd = New System.Windows.Forms.Button()
        Me.CopyMerge_cmd = New System.Windows.Forms.Button()
        Me.Units_lbl = New System.Windows.Forms.Label()
        Me.To_lbl = New System.Windows.Forms.Label()
        Me.From_lbl = New System.Windows.Forms.Label()
        Me.UnitsFrom_lbl = New System.Windows.Forms.Label()
        Me.UnitsTo_cmb = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Cancel_cmd
        '
        Me.Cancel_cmd.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel_cmd.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel_cmd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cancel_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_cmd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel_cmd.Location = New System.Drawing.Point(2, 87)
        Me.Cancel_cmd.MaximumSize = New System.Drawing.Size(89, 25)
        Me.Cancel_cmd.MinimumSize = New System.Drawing.Size(89, 25)
        Me.Cancel_cmd.Name = "Cancel_cmd"
        Me.Cancel_cmd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel_cmd.Size = New System.Drawing.Size(89, 25)
        Me.Cancel_cmd.TabIndex = 9
        Me.Cancel_cmd.Text = "&Cancel"
        Me.Cancel_cmd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Cancel_cmd.UseVisualStyleBackColor = False
        '
        'CopyMerge_cmd
        '
        Me.CopyMerge_cmd.BackColor = System.Drawing.SystemColors.Control
        Me.CopyMerge_cmd.Cursor = System.Windows.Forms.Cursors.Default
        Me.CopyMerge_cmd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CopyMerge_cmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyMerge_cmd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CopyMerge_cmd.Location = New System.Drawing.Point(133, 87)
        Me.CopyMerge_cmd.Name = "CopyMerge_cmd"
        Me.CopyMerge_cmd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CopyMerge_cmd.Size = New System.Drawing.Size(89, 25)
        Me.CopyMerge_cmd.TabIndex = 8
        Me.CopyMerge_cmd.Text = "&Copy"
        Me.CopyMerge_cmd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CopyMerge_cmd.UseVisualStyleBackColor = False
        '
        'Units_lbl
        '
        Me.Units_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.Units_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.Units_lbl.Enabled = False
        Me.Units_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Units_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Units_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Units_lbl.Location = New System.Drawing.Point(90, 4)
        Me.Units_lbl.Name = "Units_lbl"
        Me.Units_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Units_lbl.Size = New System.Drawing.Size(100, 21)
        Me.Units_lbl.TabIndex = 15
        Me.Units_lbl.Text = "Units"
        Me.Units_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'To_lbl
        '
        Me.To_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.To_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.To_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.To_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.To_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.To_lbl.Location = New System.Drawing.Point(6, 56)
        Me.To_lbl.Name = "To_lbl"
        Me.To_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.To_lbl.Size = New System.Drawing.Size(65, 21)
        Me.To_lbl.TabIndex = 14
        Me.To_lbl.Text = "To:"
        Me.To_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'From_lbl
        '
        Me.From_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.From_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.From_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.From_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.From_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.From_lbl.Location = New System.Drawing.Point(6, 28)
        Me.From_lbl.Name = "From_lbl"
        Me.From_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.From_lbl.Size = New System.Drawing.Size(65, 21)
        Me.From_lbl.TabIndex = 13
        Me.From_lbl.Text = "From:"
        Me.From_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UnitsFrom_lbl
        '
        Me.UnitsFrom_lbl.BackColor = System.Drawing.SystemColors.Control
        Me.UnitsFrom_lbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.UnitsFrom_lbl.Enabled = False
        Me.UnitsFrom_lbl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.UnitsFrom_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnitsFrom_lbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UnitsFrom_lbl.Location = New System.Drawing.Point(90, 28)
        Me.UnitsFrom_lbl.Name = "UnitsFrom_lbl"
        Me.UnitsFrom_lbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UnitsFrom_lbl.Size = New System.Drawing.Size(100, 21)
        Me.UnitsFrom_lbl.TabIndex = 16
        '
        'UnitsTo_cmb
        '
        Me.UnitsTo_cmb.BackColor = System.Drawing.SystemColors.Window
        Me.UnitsTo_cmb.Cursor = System.Windows.Forms.Cursors.Default
        Me.UnitsTo_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UnitsTo_cmb.Enabled = False
        Me.UnitsTo_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnitsTo_cmb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.UnitsTo_cmb.Location = New System.Drawing.Point(90, 56)
        Me.UnitsTo_cmb.Name = "UnitsTo_cmb"
        Me.UnitsTo_cmb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UnitsTo_cmb.Size = New System.Drawing.Size(100, 24)
        Me.UnitsTo_cmb.TabIndex = 17
        '
        'UnitCopyMerge_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(226, 117)
        Me.ControlBox = False
        Me.Controls.Add(Me.UnitsTo_cmb)
        Me.Controls.Add(Me.UnitsFrom_lbl)
        Me.Controls.Add(Me.Units_lbl)
        Me.Controls.Add(Me.To_lbl)
        Me.Controls.Add(Me.From_lbl)
        Me.Controls.Add(Me.Cancel_cmd)
        Me.Controls.Add(Me.CopyMerge_cmd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "UnitCopyMerge_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copy"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents Cancel_cmd As System.Windows.Forms.Button
    Private WithEvents CopyMerge_cmd As System.Windows.Forms.Button
    Public WithEvents Units_lbl As System.Windows.Forms.Label
    Public WithEvents To_lbl As System.Windows.Forms.Label
    Public WithEvents From_lbl As System.Windows.Forms.Label
    Public WithEvents UnitsFrom_lbl As System.Windows.Forms.Label
    Public WithEvents UnitsTo_cmb As System.Windows.Forms.ComboBox
End Class
