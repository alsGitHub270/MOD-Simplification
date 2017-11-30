<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLaborRates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLaborRates))
        Me.dgvLaborRatios = New System.Windows.Forms.DataGridView()
        Me.lblLocalOffice = New System.Windows.Forms.Label()
        Me.dgvOverTime = New System.Windows.Forms.DataGridView()
        Me.btnExit = New System.Windows.Forms.Button()
        CType(Me.dgvLaborRatios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOverTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvLaborRatios
        '
        Me.dgvLaborRatios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLaborRatios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLaborRatios.Location = New System.Drawing.Point(32, 53)
        Me.dgvLaborRatios.Name = "dgvLaborRatios"
        Me.dgvLaborRatios.Size = New System.Drawing.Size(509, 261)
        Me.dgvLaborRatios.TabIndex = 66
        '
        'lblLocalOffice
        '
        Me.lblLocalOffice.AutoSize = True
        Me.lblLocalOffice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalOffice.Location = New System.Drawing.Point(29, 13)
        Me.lblLocalOffice.Name = "lblLocalOffice"
        Me.lblLocalOffice.Size = New System.Drawing.Size(87, 15)
        Me.lblLocalOffice.TabIndex = 74
        Me.lblLocalOffice.Text = "Local Office:"
        '
        'dgvOverTime
        '
        Me.dgvOverTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOverTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOverTime.Location = New System.Drawing.Point(32, 338)
        Me.dgvOverTime.Name = "dgvOverTime"
        Me.dgvOverTime.Size = New System.Drawing.Size(509, 286)
        Me.dgvOverTime.TabIndex = 75
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(508, 1)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(46, 46)
        Me.btnExit.TabIndex = 76
        Me.btnExit.TabStop = False
        Me.btnExit.Tag = "Exit System"
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'frmLaborRates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 636)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.dgvOverTime)
        Me.Controls.Add(Me.lblLocalOffice)
        Me.Controls.Add(Me.dgvLaborRatios)
        Me.Name = "frmLaborRates"
        Me.Text = "Labor Rates"
        CType(Me.dgvLaborRatios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOverTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvLaborRatios As System.Windows.Forms.DataGridView
    Friend WithEvents lblLocalOffice As System.Windows.Forms.Label
    Friend WithEvents dgvOverTime As System.Windows.Forms.DataGridView
    Private WithEvents btnExit As System.Windows.Forms.Button
End Class
