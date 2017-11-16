Public Class TorqueFrm



    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        PrepareThisForm()
    End Sub

    Private Sub PrepareThisForm()
        LoadListBox()
    End Sub

    Private Sub LoadListBox()
        Me.lstEngineeringForms.Items.Clear()
        Me.lstEngineeringForms.Items.Add("Torque Data")
        Me.lstEngineeringForms.Items.Add("Torque Override(2)")
        Me.lstEngineeringForms.Items.Add("Torque Output Results")
        Me.lstEngineeringForms.Items.Add("Torque Traction Data")
        Me.lstEngineeringForms.Items.Add("Torque Motor Data/Error Messages")
        Me.lstEngineeringForms.Items.Add("Torque Power Data")

    End Sub

    Private Sub lstEngineeringForms_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lstEngineeringForms.DoubleClick
        Dim f As Form = Nothing
        Select Case Me.lstEngineeringForms.SelectedItem.ToString
            Case "Torque Data"
                f = New MN_TRQ01_frm
            Case "Torque Override(2)"
                f = New MN_TRQ02_frm
            Case "Torque Output Results"
                f = New MN_TRQ03_frm
            Case "Torque Traction Data"
                f = New MN_TRQ04_frm
            Case "Torque Motor Data/Error Messages"
                f = New MN_TRQ05_frm
            Case "Torque Power Data"
                f = New MN_TRQ06GR_frm
            Case Else
                Exit Sub
        End Select

        If Not IsNothing(f) Then
            f.TopLevel = False
            Panel1.Controls.Add(f)
            f.Show()
            f.WindowState = FormWindowState.Maximized
        End If

    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Panel1.Controls.Clear()
        Me.Close()
    End Sub
End Class