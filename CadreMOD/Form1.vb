Public Class Form1

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        PrepareThisForm()
    End Sub

    Private Sub PrepareThisForm()
        LoadListBox()
    End Sub

    Private Sub LoadListBox()
        Me.lstEngineeringForms.Items.Add("Job Specs")
        Me.lstEngineeringForms.Items.Add("Override(1)")
        Me.lstEngineeringForms.Items.Add("Override(2)")
        Me.lstEngineeringForms.Items.Add("General Specs")
        Me.lstEngineeringForms.Items.Add("Weights")
        Me.lstEngineeringForms.Items.Add("Application Checks")
        Me.lstEngineeringForms.Items.Add("Application Data")
        Me.lstEngineeringForms.Items.Add("Power Data")
    End Sub

    Private Sub lstEngineeringForms_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lstEngineeringForms.DoubleClick
        Dim f As New Form
        f.TopLevel = False
        f.WindowState = FormWindowState.Maximized
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        Panel1.Controls.Add(f)
    End Sub
End Class