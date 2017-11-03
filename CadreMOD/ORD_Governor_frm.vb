Public Class ORD_Governor_frm

    Private Sub SetGovImage(ByVal FromControl As String)

        Gov_img.SizeMode = PictureBoxSizeMode.AutoSize
        Select Case FromControl
            Case "NewGov"
                Gov_img.Image = Image.FromFile(ImageFileLocation & "NewGovernor.png")
            Case "ExistingGov"
                Gov_img.Image = Image.FromFile(ImageFileLocation & "ExistingGovernor.png")
            Case "GovMounting"
                Gov_img.Image = Image.FromFile(ImageFileLocation & "GovernorMounting.png")
            Case "GovMinimumClearances"
                Gov_img.Image = Image.FromFile(ImageFileLocation & "GovernorMachineRoomClearances.png")
            Case "GovTensionSheave"
                Gov_img.Image = Image.FromFile(ImageFileLocation & "GovernorTensionSheavePit.png")
            Case Else
                Gov_img.Image = Nothing
        End Select

    End Sub
    Private Sub ResetGovImage()
        Gov_img.Image = Nothing
    End Sub
    Private Sub CarGovernorNewModel_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorNewModel_cmb.GotFocus
        SetGovImage("NewGov")
    End Sub
    Private Sub CarGovernorNewModel_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorNewModel_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernorExistingVendor_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorExistingVendor_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CarGovernorExistingVendor_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorExistingVendor_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernorExistingModel_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorExistingModel_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CarGovernorExistingModel_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorExistingModel_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovCableSize_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovCableSize_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CarGovCableSize_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovCableSize_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernorPullthrough_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorPullthrough_txt.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CarGovernorPullthrough_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorPullthrough_txt.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernor1Hand_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernor1Hand_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CarGovernor1Hand_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernor1Hand_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernorMounting_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorMounting_cmb.GotFocus
        SetGovImage("GovMounting")
    End Sub
    Private Sub CarGovernorMounting_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorMounting_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarMeetsMinimumClearances_chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarMeetsMinimumClearances_chk.GotFocus
        SetGovImage("GovMinimumClearances")
    End Sub
    Private Sub CarMeetsMinimumClearances_chk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarMeetsMinimumClearances_chk.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernor1TensionSheaveA_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernor1TensionSheaveA_txt.GotFocus
        SetGovImage("GovTensionSheave")
    End Sub
    Private Sub CarGovernor1TensionSheaveA_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernor1TensionSheaveA_txt.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernor1TensionSheaveB_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernor1TensionSheaveB_txt.GotFocus
        SetGovImage("GovTensionSheave")
    End Sub
    Private Sub CarGovernor1TensionSheaveB_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernor1TensionSheaveB_txt.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CarGovernorExistingSheaveDiameter_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorExistingSheaveDiameter_cmb.GotFocus
        SetGovImage("GovTensionSheave")
    End Sub
    Private Sub CarGovernorExistingSheaveDiameter_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CarGovernorExistingSheaveDiameter_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernorNewModel_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorNewModel_cmb.GotFocus
        SetGovImage("NewGov")
    End Sub
    Private Sub CwtGovernorNewModel_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorNewModel_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernorExistingVendor_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorExistingVendor_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CwtGovernorExistingVendor_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorExistingVendor_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernorExistingModel_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorExistingModel_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CwtGovernorExistingModel_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorExistingModel_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovCableSize_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovCableSize_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CwtGovCableSize_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovCableSize_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernorPullthrough_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorPullthrough_txt.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CwtGovernorPullthrough_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorPullthrough_txt.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernor1Hand_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernor1Hand_cmb.GotFocus
        SetGovImage("ExistingGov")
    End Sub
    Private Sub CwtGovernor1Hand_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernor1Hand_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernorMounting_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorMounting_cmb.GotFocus
        SetGovImage("GovMounting")
    End Sub
    Private Sub CwtGovernorMounting_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorMounting_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtMeetsMinimumClearances_chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtMeetsMinimumClearances_chk.GotFocus
        SetGovImage("GovMinimumClearances")
    End Sub
    Private Sub CwtMeetsMinimumClearances_chk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtMeetsMinimumClearances_chk.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernor1TensionSheaveA_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernor1TensionSheaveA_txt.GotFocus
        SetGovImage("GovTensionSheave")
    End Sub
    Private Sub CwtGovernor1TensionSheaveA_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernor1TensionSheaveA_txt.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernor1TensionSheaveB_txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernor1TensionSheaveB_txt.GotFocus
        SetGovImage("GovTensionSheave")
    End Sub
    Private Sub CwtGovernor1TensionSheaveB_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernor1TensionSheaveB_txt.LostFocus
        ResetGovImage()
    End Sub
    Private Sub CwtGovernorExistingSheaveDiameter_cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorExistingSheaveDiameter_cmb.GotFocus
        SetGovImage("GovTensionSheave")
    End Sub
    Private Sub CwtGovernorExistingSheaveDiameter_cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CwtGovernorExistingSheaveDiameter_cmb.LostFocus
        ResetGovImage()
    End Sub
    Private Sub ORD_Governor_frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PrepareThisForm()
    End Sub
    Private Sub PrepareThisForm()
        Load_ListBoxes()
    End Sub
    Private Sub Load_ListBoxes()

        CarGovernorNewModel_cmb.Items.Clear()
        If Conversion.Val(GetValue(TABLENAME_GENERALINFO, "SpeedNew_cmb")) > 800 Then
            CarGovernorNewModel_cmb.Items.Add("GB 32")
            CarGovernorNewModel_cmb.Items.Add("GB 42")
        Else
            CarGovernorNewModel_cmb.Items.Add("HW202")
            CarGovernorNewModel_cmb.Items.Add("HW207")
            CarGovernorNewModel_cmb.Items.Add("HW210")
        End If

        CarGovernorExistingVendor_cmb.Items.Clear()
        CarGovernorExistingVendor_cmb.Items.Add(WESTINGHOUSE)
        CarGovernorExistingVendor_cmb.Items.Add(HAUGHTON)
        CarGovernorExistingVendor_cmb.Items.Add(HOLLISTERWHITNEY)
        CarGovernorExistingVendor_cmb.Items.Add(VILLARES)
        CarGovernorExistingVendor_cmb.Items.Add(OTHER)

        CarGovernorExistingModel_cmb.Items.Clear()
        Select Case CarGovernorExistingVendor_cmb.Text
            Case WESTINGHOUSE
                CarGovernorExistingModel_cmb.Items.Add("B5")
                CarGovernorExistingModel_cmb.Items.Add("B22")
                CarGovernorExistingModel_cmb.Items.Add("W5")
            Case HAUGHTON
                CarGovernorExistingModel_cmb.Items.Add("16 Series")
                CarGovernorExistingModel_cmb.Items.Add("12I")
            Case HOLLISTERWHITNEY
                CarGovernorExistingModel_cmb.Items.Add("HW201")
                CarGovernorExistingModel_cmb.Items.Add("HW205")
                CarGovernorExistingModel_cmb.Items.Add("HW206")
                CarGovernorExistingModel_cmb.Items.Add("HW208")
                CarGovernorExistingModel_cmb.Items.Add("HW209")
            Case VILLARES
                CarGovernorExistingModel_cmb.Items.Add("B5")
                CarGovernorExistingModel_cmb.Items.Add("B22")
            Case Else
        End Select
        CarGovernorExistingModel_cmb.Items.Add(OTHER)

        CarGovCableSize_cmb.Items.Clear()
        CarGovCableSize_cmb.Items.Add("3/8")
        CarGovCableSize_cmb.Items.Add("1/2")

        CarGovernor1Hand_cmb.Items.Clear()
        CarGovernor1Hand_cmb.Items.Add("Left Hand")
        CarGovernor1Hand_cmb.Items.Add("Right Hand")

        CarGovernorMounting_cmb.Items.Clear()
        CarGovernorMounting_cmb.Items.Add("Slab")
        CarGovernorMounting_cmb.Items.Add("Rail")

        CarGovernorExistingSheaveDiameter_cmb.Items.Clear()
        If CarGovernorExistingModel_cmb.Text = "B22" Then
            CarGovernorExistingSheaveDiameter_cmb.Items.Add("22.00")
        Else
            CarGovernorExistingSheaveDiameter_cmb.Items.Add("12.00")
            CarGovernorExistingSheaveDiameter_cmb.Items.Add("16.00")
            CarGovernorExistingSheaveDiameter_cmb.Items.Add("Other")
        End If

        CwtGovernorNewModel_cmb.Items.Clear()
        If Conversion.Val(GetValue(TABLENAME_GENERALINFO, "SpeedNew_cmb")) > 800 Then
            CwtGovernorNewModel_cmb.Items.Add("GB 32")
            CwtGovernorNewModel_cmb.Items.Add("GB 42")
        Else
            CwtGovernorNewModel_cmb.Items.Add("HW202")
            CwtGovernorNewModel_cmb.Items.Add("HW207")
            CwtGovernorNewModel_cmb.Items.Add("HW210")
        End If

        CwtGovernorExistingVendor_cmb.Items.Clear()
        CwtGovernorExistingVendor_cmb.Items.Add(WESTINGHOUSE)
        CwtGovernorExistingVendor_cmb.Items.Add(HAUGHTON)
        CwtGovernorExistingVendor_cmb.Items.Add(HOLLISTERWHITNEY)
        CwtGovernorExistingVendor_cmb.Items.Add(VILLARES)
        CwtGovernorExistingVendor_cmb.Items.Add(OTHER)

        CwtGovernorExistingModel_cmb.Items.Clear()
        Select Case CwtGovernorExistingVendor_cmb.Text
            Case WESTINGHOUSE
                CwtGovernorExistingModel_cmb.Items.Add("B5")
                CwtGovernorExistingModel_cmb.Items.Add("B22")
                CwtGovernorExistingModel_cmb.Items.Add("W5")
            Case HAUGHTON
                CwtGovernorExistingModel_cmb.Items.Add("16 Series")
                CwtGovernorExistingModel_cmb.Items.Add("12I")
            Case HOLLISTERWHITNEY
                CwtGovernorExistingModel_cmb.Items.Add("HW201")
                CwtGovernorExistingModel_cmb.Items.Add("HW205")
                CwtGovernorExistingModel_cmb.Items.Add("HW206")
                CwtGovernorExistingModel_cmb.Items.Add("HW208")
                CwtGovernorExistingModel_cmb.Items.Add("HW209")
            Case VILLARES
                CwtGovernorExistingModel_cmb.Items.Add("B5")
                CwtGovernorExistingModel_cmb.Items.Add("B22")
            Case Else
        End Select
        CwtGovernorExistingModel_cmb.Items.Add(OTHER)

        CwtGovCableSize_cmb.Items.Clear()
        CwtGovCableSize_cmb.Items.Add("3/8")
        CwtGovCableSize_cmb.Items.Add("1/2")

        CwtGovernor1Hand_cmb.Items.Clear()
        CwtGovernor1Hand_cmb.Items.Add("Left Hand")
        CwtGovernor1Hand_cmb.Items.Add("Right Hand")

        CwtGovernorMounting_cmb.Items.Clear()
        CwtGovernorMounting_cmb.Items.Add("Slab")
        CwtGovernorMounting_cmb.Items.Add("Rail")

        CwtGovernorExistingSheaveDiameter_cmb.Items.Clear()
        CwtGovernorExistingSheaveDiameter_cmb.Items.Add("12.00")
        CwtGovernorExistingSheaveDiameter_cmb.Items.Add("16.00")
        CwtGovernorExistingSheaveDiameter_cmb.Items.Add("Other")

    End Sub
End Class