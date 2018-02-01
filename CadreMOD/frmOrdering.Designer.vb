<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdering
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
        Me.sprOrdering = New FarPoint.Win.Spread.FpSpread()
        Me.fpSprOrdering = New FarPoint.Win.Spread.SheetView()
        CType(Me.sprOrdering, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fpSprOrdering, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sprOrdering
        '
        Me.sprOrdering.AccessibleDescription = "BillOfMaterials_spr, Sheet1, Row 0, Column 0, "
        Me.sprOrdering.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sprOrdering.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sprOrdering.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.sprOrdering.Location = New System.Drawing.Point(25, 12)
        Me.sprOrdering.Name = "sprOrdering"
        Me.sprOrdering.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.fpSprOrdering})
        Me.sprOrdering.Size = New System.Drawing.Size(912, 452)
        Me.sprOrdering.TabIndex = 65
        Me.sprOrdering.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'fpSprOrdering
        '
        Me.fpSprOrdering.Reset()
        Me.fpSprOrdering.SheetName = "Sheet1"
        '
        'frmOrdering
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 495)
        Me.Controls.Add(Me.sprOrdering)
        Me.Name = "frmOrdering"
        Me.Text = "frmOrdering"
        CType(Me.sprOrdering, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fpSprOrdering, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sprOrdering As FarPoint.Win.Spread.FpSpread
    Friend WithEvents fpSprOrdering As FarPoint.Win.Spread.SheetView
End Class
