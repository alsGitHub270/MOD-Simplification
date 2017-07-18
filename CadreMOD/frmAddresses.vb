Public Class frmAddresses

   
    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        ' fired every time tab changes
        Select Case TabControl1.SelectedIndex
            Case 0
                GetOwnerData()
            Case 1
                GetConsultantData()
            Case Else
                ClearData()

        End Select
    End Sub

    Private Sub TabControl1_TabIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.TabIndexChanged
        GetOwnerData()
    End Sub

    Private Sub GetOwnerData()
        Me.txtCompanyName.Text = "Queen Consolidated Enterprises"
        Me.txtContactName.Text = "Oliver Queen"
        Me.txtAddress.Text = "123 Broad Street"
        Me.txtAddress2.Text = ""
        Me.txtCity.Text = "Starling City"
        Me.txtState.Text = "AA"
        Me.txtZipCode.Text = "00000-0000"
        Me.txtPhone.Text = "(123)456-7890"
        Me.txtExt.Text = "99999"
        Me.txtFax.Text = "(123)987-4321"
        Me.txtEmail.Text = "oliver.queen@queenconsolidated.com"
    End Sub

    Private Sub GetConsultantData()
        Me.txtCompanyName.Text = "Sam Axe Consulting, Ltd."
        Me.txtContactName.Text = "Sam Axe"
        Me.txtAddress.Text = "32 Burn Notice Plaza"
        Me.txtAddress2.Text = "Suite 86"
        Me.txtCity.Text = "Miami"
        Me.txtState.Text = "FL"
        Me.txtZipCode.Text = "33130"
        Me.txtPhone.Text = "(305)343-1928"
        Me.txtExt.Text = ""
        Me.txtFax.Text = "(305)343-3547"
        Me.txtEmail.Text = "sam@burned.com"
    End Sub

    Private Sub ClearData()
        Me.txtCompanyName.Text = ""
        Me.txtContactName.Text = ""
        Me.txtAddress.Text = ""
        Me.txtAddress2.Text = ""
        Me.txtCity.Text = ""
        Me.txtState.Text = ""
        Me.txtZipCode.Text = ""
        Me.txtPhone.Text = ""
        Me.txtExt.Text = ""
        Me.txtFax.Text = ""
        Me.txtEmail.Text = ""
    End Sub

End Class