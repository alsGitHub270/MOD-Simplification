Option Strict Off
Option Explicit On

Imports Microsoft.VisualBasic

Imports System
Imports System.Windows.Forms
Partial Friend Class CM_ADDRS_frm
    Inherits System.Windows.Forms.Form
    Private Sub CM_ADDRS_frm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        
        ' PrepareThisForm()

    End Sub

    Const ACTION_TYPE_USE_FOR_CURRENT_JOB As Integer = 0
    Const ACTION_TYPE_UNLOADME As Integer = 1
    Const ACTION_TYPE_ADD_ADDRESS As Integer = 2
    Const ACTION_TYPE_DELETE_ADDRESS As Integer = 3
    Const ACTION_TYPE_CLEAR_FORM As Integer = 4

    Private AddressDataChanged As Boolean
    Private BypassTest As Boolean
    Private AddressIndex As Byte
    Public InitializeAddressFields As Boolean
    Public CurrentType As Integer
    Private Consultants() As String
    Public FromCM As Boolean

    Structure Contracts_TypeDec
        Dim ContractsID As Integer ' Primary Key
        <VBFixedString(11), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=11)> _
        Dim EstimateNum As String
        Dim SalesOffice As String
        Dim InstallingOffice As String
        Dim ServiceOffice As String
        Dim JobName As String
        Dim SAPContactNumber As String
        Dim JobAddress As String
        Dim JobAddress2 As String
        Dim JobCity As String
        Dim JobState As String
        Dim JobZip As String
        Dim JobPhone As String
        Dim JobFax As String
        Dim SalesRepName As String
        Dim SalesRepPhone As String
        Dim SalesRepAddress1 As String
        Dim SalesRepAddress2 As String
        Dim SalesRepCity As String
        Dim SalesRepState As String
        Dim SalesRepZip As String
        Dim SalesRepFax As String
        Dim SalesRepTitle As String
        Dim SalesRepOffice As String
        Dim SalesRepMgrName As String
        Dim SalesRepEmail As String
        Dim SchindlerAddress1 As String
        Dim SchindlerAddress2 As String
        Dim SchindlerCity As String
        Dim SchindlerState As String
        Dim SchindlerZip As String
        Dim Estimator As String
        Dim Status As String
        Dim CRM_Status As String
        Dim ProbabilityOfSale As String
        Dim ProposalNum As String
        Dim EstimateDate As String
        Dim Company As String
        Dim AgentFor As String
        Dim CurrentMaintenance As String
        Dim ContractNumber As String
        Dim Pricing_Type As String
        Dim NationalAccount As Boolean
        Dim SpecificationExists As Byte
        Dim RegionCode As String
        Dim EmployeeType As String
        Dim DateRevised As String
        Dim OfficeRating As String
        Dim DistrictCode As String
        Dim BuildingType As String
        Dim IsCampus As Boolean
        Dim ContractType As String
        Dim PreBidPrice As Single
        Dim NumberSimultaneousTeams As Byte
        Dim JobHighRiskFactor As Integer
        Dim RMMFactorAdder As Integer
        Dim JobClassification As String
        Dim Country As String
        Dim MaxPercentSpecial As Single
        Dim MaxPercentSpecialStatus As String
        Dim SystemStatus As String
        Dim EngReviewStatus As String
        Dim Reader As Object
        Dim ReaderGlobal As Object
        Dim Consultant As Byte
        Dim BidType As String
        Dim MajorProject As Byte
        Dim CurrentMaintenanceProvider As String
        Dim CustomerTier As String
        Dim PricingTerritory As String
        Dim Area As String
        Dim ManagerEscalationRequired As String
        Dim CentralEscalationRequired As String
        Dim HXPress_Total As Single
        Dim FMM200_Total As Single                        '6400 Products
        Dim Destination_Total As Single
        Dim OtherMidRise_Total As Single
        Dim OtherHighRise_Total As Single
        Dim POHLowRise_Total As Single
        Dim POHMidRise_Total As Single
        Dim POHHighRise_Total As Single
        Dim Incentive_Total As Single
        Public Shared Function CreateInstance() As Contracts_TypeDec
            Dim result As New Contracts_TypeDec()
            result.EstimateNum = ""
            result.SalesOffice = String.Empty
            result.InstallingOffice = String.Empty
            result.ServiceOffice = String.Empty
            result.JobName = String.Empty
            result.JobAddress = String.Empty
            result.JobAddress2 = String.Empty
            result.JobCity = String.Empty
            result.JobState = String.Empty
            result.JobZip = String.Empty
            result.JobPhone = String.Empty
            result.JobFax = String.Empty
            result.SalesRepName = String.Empty
            result.SalesRepPhone = String.Empty
            result.SalesRepFax = String.Empty
            result.SalesRepTitle = String.Empty
            result.SalesRepOffice = String.Empty
            result.SalesRepMgrName = String.Empty
            result.SalesRepEmail = String.Empty
            result.SchindlerAddress1 = String.Empty
            result.SchindlerAddress2 = String.Empty
            result.SchindlerCity = String.Empty
            result.SchindlerState = String.Empty
            result.SchindlerZip = String.Empty
            result.Estimator = String.Empty
            result.Status = String.Empty
            result.ProbabilityOfSale = String.Empty
            result.ProposalNum = String.Empty
            result.EstimateDate = String.Empty
            result.Company = String.Empty
            result.AgentFor = String.Empty
            result.CurrentMaintenance = String.Empty
            result.ContractNumber = String.Empty
            result.Pricing_Type = String.Empty
            result.RegionCode = String.Empty
            result.EmployeeType = String.Empty
            result.DateRevised = String.Empty
            result.OfficeRating = String.Empty
            result.DistrictCode = String.Empty
            result.BuildingType = String.Empty
            result.ContractType = String.Empty
            result.JobClassification = String.Empty
            result.Country = String.Empty
            result.MaxPercentSpecialStatus = String.Empty
            result.SystemStatus = String.Empty
            result.EngReviewStatus = String.Empty
            result.Reader = String.Empty
            result.ReaderGlobal = String.Empty
            result.Consultant = CheckState.Unchecked
            result.BidType = String.Empty
            result.MajorProject = CheckState.Unchecked
            result.CurrentMaintenanceProvider = String.Empty
            result.CustomerTier = String.Empty
            result.PricingTerritory = String.Empty
            result.Area = String.Empty
            result.ManagerEscalationRequired = String.Empty
            result.CentralEscalationRequired = String.Empty
            Return result
        End Function
    End Structure

    Private Sub FormsAfterMatch()
        Me.Finalize()
    End Sub
    Private Sub InitializeAddress()

        BypassTest = True
        Name_cmb.Text = ""
        Address_txt.Text = ""
        Address2_txt.Text = ""
        City_txt.Text = ""
        State_txt.Text = ""
        Zip_txt.Text = ""
        Phone_txt.Text = ""
        Ext_txt.Text = ""
        Fax_txt.Text = ""
        BypassTest = False

    End Sub
    Public Sub Fields2Type()

        Address.Type = Type_cmb.SelectedIndex
        Address.Name = Strings.Left(Name_cmb.Text, 30)
        Address.Address = Address_txt.Text
        Address.Address2 = Address2_txt.Text
        Address.City = City_txt.Text
        Address.State = State_txt.Text
        Address.Zip = Zip_txt.Text
        Address.Phone = Phone_txt.Text
        Address.Ext = Ext_txt.Text
        Address.Fax = Fax_txt.Text

    End Sub
    Public Function Validate_Renamed() As Integer
        Dim result As Integer = MsgBoxStyle.OkOnly

        If String.IsNullOrEmpty(Name_cmb.Text.Trim) Then
            Interaction.MsgBox("Name cannot Be Blank", System.Windows.Forms.DialogResult.Yes, "Name Missing")
            Name_cmb.Focus()
            Return MsgBoxStyle.Critical
        ElseIf Name_cmb.Text.Trim = TYPE_NAME_HERE Then
            Interaction.MsgBox("Name must be entered", System.Windows.Forms.DialogResult.Yes, "Name Missing")
            Name_cmb.Focus()
            Return MsgBoxStyle.Critical
        End If
        If String.IsNullOrEmpty(Address_txt.Text.Trim) And String.IsNullOrEmpty(Address2_txt.Text.Trim) Then
            Interaction.MsgBox("Address cannot Be Blank", System.Windows.Forms.DialogResult.Yes, "Address Missing")
            Address_txt.Focus()
            Return MsgBoxStyle.Critical
        End If
        If String.IsNullOrEmpty(City_txt.Text.Trim) Then
            Interaction.MsgBox("City cannot Be Blank", System.Windows.Forms.DialogResult.Yes, "City Missing")
            City_txt.Focus()
            Return MsgBoxStyle.Critical
        End If
        If String.IsNullOrEmpty(State_txt.Text.Trim) Then
            Interaction.MsgBox("State cannot Be Blank", System.Windows.Forms.DialogResult.Yes, "State Missing")
            State_txt.Focus()
            Return MsgBoxStyle.Critical
        End If

        Return result

    End Function
    Private Sub UseForCurrentJob()

        If Contracts.Consultant = CheckState.Checked Then
            If Type_cmb.SelectedIndex <> ADDRESS_TYPE_CONSULTANT Then
                Interaction.MsgBox("Consultant must be selected for this job", System.Windows.Forms.DialogResult.OK, "Must use Consultant")
                Type_cmb.Focus()
                FindAddress()
                Exit Sub
            End If
        ElseIf Type_cmb.SelectedIndex <> ADDRESS_TYPE_OWNER Then
            Interaction.MsgBox("Owner must be selected for this job", System.Windows.Forms.DialogResult.OK, "Must use Owner")
            Type_cmb.Focus()
            FindAddress()
            Exit Sub
        End If
        Fields2Type()
        If Validate_Renamed() = MsgBoxStyle.Critical Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        CM_ADDRS_IO.SaveData_Address()
        Load_ListBoxes()
        Set_Address_Dependents()
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub AddAddress()

        Fields2Type()
        If Validate_Renamed() = MsgBoxStyle.Critical Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        CM_ADDRS_IO.SaveData_Address()
        Load_ListBoxes()
        CM_ADDRS_IO.ReadData(Type_cmb.SelectedIndex)
        Set_Address_Dependents()
        Set_CurrentAddress()
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub DeleteData_Address()
        Dim TempIndex As Byte

        Me.Cursor = Cursors.WaitCursor
        For Me.AddressIndex = 1 To Addresses.GetUpperBound(0)
            If Addresses(AddressIndex).Name.ToUpper() = Name_cmb.Text.ToUpper() And Addresses(AddressIndex).Type = Type_cmb.SelectedIndex Then
                TempIndex = AddressIndex
                Exit For
            End If
        Next AddressIndex
        For Me.AddressIndex = TempIndex + 1 To Addresses.GetUpperBound(0)
            Addresses(AddressIndex).Type = Addresses(AddressIndex - 1).Type
            Addresses(AddressIndex).Name = Addresses(AddressIndex - 1).Name
            Addresses(AddressIndex).Address = Addresses(AddressIndex - 1).Address
            Addresses(AddressIndex).Address2 = Addresses(AddressIndex - 1).Address2
            Addresses(AddressIndex).City = Addresses(AddressIndex - 1).City
            Addresses(AddressIndex).State = Addresses(AddressIndex - 1).State
            Addresses(AddressIndex).Zip = Addresses(AddressIndex - 1).Zip
            Addresses(AddressIndex).Phone = Addresses(AddressIndex - 1).Phone
            Addresses(AddressIndex).Ext = Addresses(AddressIndex - 1).Ext
            Addresses(AddressIndex).Fax = Addresses(AddressIndex - 1).Fax
        Next AddressIndex
        ReDim Preserve Addresses(Addresses.GetUpperBound(0) - 1)
        InitializeAddress()
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub ActionLogic(ByRef ThisAction As Integer)

        Select Case ThisAction
            Case ACTION_TYPE_USE_FOR_CURRENT_JOB
                UseForCurrentJob()
            Case ACTION_TYPE_UNLOADME
                Me.Dispose()
                CM_MAIN_frm.Cursor = Cursors.Default
            Case ACTION_TYPE_ADD_ADDRESS
                AddAddress()
            Case ACTION_TYPE_DELETE_ADDRESS
                DeleteData_Address()
            Case ACTION_TYPE_CLEAR_FORM
                InitializeAddress()
            Case Else
        End Select

    End Sub
    Private Sub FindAddress()

        Me.Cursor = Cursors.WaitCursor
        If Type_cmb.SelectedIndex = ADDRESS_TYPE_CONSULTANT And Not String.IsNullOrEmpty(Address.Name.Trim) Then
            CM_ADDRS_IO.ReadData(Type_cmb.SelectedIndex, Address.Name)
        Else
            CM_ADDRS_IO.ReadData(Type_cmb.SelectedIndex)
        End If
        Type2Fields()
        Set_Address_Dependents()
        Set_CurrentAddress()
        AddressDataChanged = False
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub Set_Address_Dependents()
        Dim ControlNotEmpty As Boolean = False

        Select Case Type_cmb.SelectedIndex
            Case ADDRESS_TYPE_OWNER
                Name_lbl.Text = "Owner"
            Case ADDRESS_TYPE_GC
                Name_lbl.Text = "GC:"
            Case ADDRESS_TYPE_ARCHITECT
                Name_lbl.Text = "Architect:"
            Case ADDRESS_TYPE_MGMT_CO
                Name_lbl.Text = "Mgmt. Co:"
            Case ADDRESS_TYPE_CONSULTANT
                Name_lbl.Text = "Consultant:"
            Case Else
        End Select
        For Each cntrl As Control In Me.Controls
            If TypeOf [cntrl] Is ComboBox Or TypeOf [cntrl] Is TextBox Then
                If [cntrl].Name <> "Type_cmb" Then
                    If [cntrl].Text.Trim().Length > 0 Then
                        ControlNotEmpty = True
                    End If
                End If
            End If
        Next cntrl
        If ControlNotEmpty Then
            Action_btn(ACTION_TYPE_ADD_ADDRESS).Text = "Save Address"
        Else
            Action_btn(ACTION_TYPE_ADD_ADDRESS).Text = "Add Address"
        End If
        If Addresses.GetUpperBound(0) = 0 Then
            Action_btn(ACTION_TYPE_DELETE_ADDRESS).Enabled = False
        Else
            Action_btn(ACTION_TYPE_DELETE_ADDRESS).Enabled = True
        End If

    End Sub
    Private Sub Type2Fields()

        isInitializingComponent = True
        Type_cmb.SelectedIndex = Address.Type
        Name_cmb.Text = Address.Name
        Address_txt.Text = Address.Address
        Address2_txt.Text = Address.Address2
        City_txt.Text = Address.City
        State_txt.Text = Address.State
        Zip_txt.Text = Address.Zip
        Phone_txt.Text = Address.Phone
        Ext_txt.Text = Address.Ext
        Fax_txt.Text = Address.Fax
        isInitializingComponent = False

    End Sub
    Private Sub PrepareThisForm()
        Dim UseTop As Integer = 0
        Dim UseLeft As Integer = 0
        Dim UseWidth As Integer = 0
        Dim UseForm As Form = Nothing

        If FromCM Then
            UseForm = Application.OpenForms("CM_MAIN_frm")
            UseTop = UseForm.Height - Me.Height - 35
            UseLeft = UseForm.Left + 10
            UseWidth = UseForm.Width - 22
        Else
            UseForm = Application.OpenForms("Main_MDI_frm")
            UseTop = UseForm.Height - Me.Height - 25
            UseLeft = UseForm.Left + 5
            UseWidth = UseForm.Width - 11
        End If
        Me.Location = New Point(UseLeft, UseTop)
        Me.Width = UseWidth
        Me.Text = tCM_TITLE & " (" & tCM_ADDRESS_TITLE & ")"
        Type_cmb.Items.Clear()
        Type_cmb.Items.Add("Owner")
        Type_cmb.Items.Add("GC")
        Type_cmb.Items.Add("Architect")
        Type_cmb.Items.Add("Mgmt. Co")
        Type_cmb.Items.Add("Consultant")
        If InitializeAddressFields Then
            If Contracts.Consultant = CheckState.Checked Then
                Type_cmb.SelectedIndex = ADDRESS_TYPE_CONSULTANT
            Else
                Type_cmb.SelectedIndex = ADDRESS_TYPE_OWNER
            End If
            CurrentType = Type_cmb.SelectedIndex
        Else
            Type_cmb.SelectedIndex = CurrentType
        End If
        AddAddress4Owner()
        Load_ListBoxes()
        If InitializeAddressFields Then
            FindAddress()
            InitializeAddressFields = False
        End If
        Set_Address_Dependents()
        AddressDataChanged = False

    End Sub
    Private Sub Action_btn_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles _Action_btn_1.Click, _Action_btn_0.Click, _Action_btn_4.Click, _Action_btn_2.Click, _Action_btn_3.Click
        Dim Index As Integer = Array.IndexOf(Action_btn, eventSender)

        ActionLogic(Index)
    End Sub
    Private isInitializingComponent As Boolean
    Private Sub Address_txt_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Address_txt.TextChanged

        If isInitializingComponent Then
            Exit Sub
        End If
        If Not BypassTest Then
            AddressDataChanged = True
        End If

    End Sub
    Private Sub Address_txt_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Address_txt.Enter
        'SelectInputArea(Address_txt, 0, Strings.Len(Address_txt.Text))
    End Sub
    Private Sub Address2_txt_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Address2_txt.TextChanged

        If isInitializingComponent Then
            Exit Sub
        End If
        If BypassTest Then
            Exit Sub
        Else
            AddressDataChanged = True
        End If

    End Sub
    Private Sub Address2_txt_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Address2_txt.Enter
        '     SelectInputArea(Address2_txt, 0, Strings.Len(Address2_txt.Text))
    End Sub
    Private Sub City_txt_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles City_txt.TextChanged

        If isInitializingComponent Then
            Exit Sub
        End If
        If BypassTest Then
            Exit Sub
        Else
            AddressDataChanged = True
        End If

    End Sub
    Private Sub City_txt_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles City_txt.Enter
        SelectInputArea(City_txt, 0, Strings.Len(City_txt.Text))
    End Sub
    Private Sub Ext_txt_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Ext_txt.TextChanged

        If BypassTest Then
            Exit Sub
        Else
            AddressDataChanged = True
        End If

    End Sub
    Private Sub Ext_txt_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Ext_txt.Enter
        SelectInputArea(Ext_txt, 0, Strings.Len(Ext_txt.Text))
    End Sub
    Private Sub Fax_txt_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Fax_txt.TextChanged

        If BypassTest Then
            Exit Sub
        Else
            AddressDataChanged = True
        End If

    End Sub
    Private Sub Fax_txt_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Fax_txt.Enter
        SelectInputArea(Fax_txt, 0, Strings.Len(Fax_txt.Text))
    End Sub
    Private Sub CM_ADDRS_frm_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Integer = eventArgs.KeyCode
        Dim Shift As Integer = IIf(eventArgs.Shift, 1, 0)
        Dim CtrlDown As Integer = (Shift And eventArgs.Control) > 0

        If eventArgs.KeyCode = Keys.S And CtrlDown Then
            KeyCode = 0
            ActionLogic(ACTION_TYPE_USE_FOR_CURRENT_JOB)
            Me.Cursor = Cursors.Default
        End If

    End Sub
    Private Sub CM_ADDRS_frm_KeyPress(ByVal eventSender As Object, ByVal eventArgs As KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Integer = Strings.Asc(eventArgs.KeyChar)

        If KeyAscii = 19 Then
            KeyAscii = 0
        End If
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        eventArgs.KeyChar = Convert.ToChar(KeyAscii)

    End Sub
    Private Sub CM_ADDRS_frm_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Load
        '  PrepareThisForm()
    End Sub
    Private Sub CM_ADDRS_frm_Closed(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles MyBase.Closed
        FormsAfterMatch()
    End Sub
    Private Sub Name_cmb_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Name_cmb.DropDownClosed
        Dim SelectedName As String = String.Empty

        If Name_cmb.SelectedIndex = -1 Then
            Exit Sub
        Else
            SelectedName = Name_cmb.Items(Name_cmb.SelectedIndex)
        End If
        Me.Cursor = Cursors.WaitCursor
        InitializeAddress()
        For Me.AddressIndex = 1 To Addresses.GetUpperBound(0)
            If Addresses(AddressIndex).Name.ToUpper() = SelectedName.ToUpper() Then
                Name_cmb.Text = Addresses(AddressIndex).Name
                Address_txt.Text = Addresses(AddressIndex).Address
                Address2_txt.Text = Addresses(AddressIndex).Address2
                City_txt.Text = Addresses(AddressIndex).City
                State_txt.Text = Addresses(AddressIndex).State
                Zip_txt.Text = Addresses(AddressIndex).Zip
                Phone_txt.Text = Addresses(AddressIndex).Phone
                Ext_txt.Text = Addresses(AddressIndex).Ext
                Fax_txt.Text = Addresses(AddressIndex).Fax
                Exit For
            End If
        Next AddressIndex
        AddressDataChanged = True
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub Name_cmb_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Name_cmb.TextChanged

        If isInitializingComponent Then
            Exit Sub
        End If
        If BypassTest Then
            Exit Sub
        Else
            AddressDataChanged = True
        End If

    End Sub
    Private Sub Name_cmb_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Name_cmb.Enter
        SelectInputArea(Name_cmb, 0, Strings.Len(Name_cmb.Text))
    End Sub
    Private Sub Name_cmb_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles Name_cmb.KeyDown
        WhichKeyPressed(eventArgs.KeyCode)
    End Sub
    Private Sub Phone_txt_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Phone_txt.TextChanged

        If BypassTest Then
            Exit Sub
        Else
            AddressDataChanged = True
        End If

    End Sub
    Private Sub Phone_txt_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Phone_txt.Enter
        SelectInputArea(Phone_txt, 0, Strings.Len(Phone_txt.Text))
    End Sub
    Private Sub State_txt_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles State_txt.TextChanged

        If BypassTest Then
            Exit Sub
        Else
            AddressDataChanged = True
        End If

    End Sub
    Private Sub State_txt_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles State_txt.Enter
        SelectInputArea(State_txt, 0, Strings.Len(State_txt.Text))
    End Sub
    Private Sub Type_cmb_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Type_cmb.DropDownClosed
        AddressDataChanged = True
        FindAddress()
    End Sub
    Private Sub Type_cmb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Type_cmb.SelectedIndexChanged

        If isInitializingComponent Then
            Exit Sub
        End If
        AddressDataChanged = True

    End Sub
    Private Sub Type_cmb_KeyDown(ByVal eventSender As Object, ByVal eventArgs As KeyEventArgs) Handles Type_cmb.KeyDown
        WhichKeyPressed(eventArgs.KeyCode)
    End Sub
    Private Sub Zip_txt_TextChanged(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Zip_txt.TextChanged
        If Not BypassTest Then
            AddressDataChanged = True
        End If
    End Sub
    Private Sub Zip_txt_Enter(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Zip_txt.Enter
        SelectInputArea(Zip_txt, 0, Strings.Len(Zip_txt.Text))
    End Sub
    Private Sub Load_ListBoxes()
        Dim FoundConsultant As Boolean = False
        Dim NewIndex As Integer = 0

        Erase Consultants
        ReDim Consultants(23)
        Consultants(1) = "Architectural Elevator"
        Consultants(2) = "Atlantic Consulting Corp."
        Consultants(3) = "Barbre Consulting Inc."
        Consultants(4) = "BOCA"
        Consultants(5) = "CMH Consultants"
        Consultants(6) = "Duncan Consulting"
        Consultants(7) = "Edgett Williams"
        Consultants(8) = "Greg Davis & Assoc."
        Consultants(9) = "GVK"
        Consultants(10) = "HKA"
        Consultants(11) = "Jenkins & Huntington"
        Consultants(12) = "Joseph Neto & Assoc."
        Consultants(13) = "Landmark"
        Consultants(14) = "Lerch Bates"
        Consultants(15) = "Michael Blades & Assoc."
        Consultants(16) = "National"
        Consultants(17) = "Persohn Hahn"
        Consultants(18) = "Scott Elevator Consultants"
        Consultants(19) = "Sterling Elevator Consultants"
        Consultants(20) = "Syska & Hennessey"
        Consultants(21) = "Van Deusen & Assoc."
        Consultants(22) = "VSA Consulting"
        Consultants(23) = "VTX"
        For iIndex As Integer = 1 To Addresses.GetUpperBound(0)
            If Addresses(iIndex).Type = ADDRESS_TYPE_CONSULTANT Then
                FoundConsultant = False
                For jIndex As Integer = 1 To Consultants.GetUpperBound(0)
                    If Consultants(jIndex).ToUpper = Addresses(iIndex).Name.ToUpper Then
                        FoundConsultant = True
                    End If
                Next
                If Not FoundConsultant Then
                    NewIndex = Consultants.GetUpperBound(0) + 1
                    ReDim Preserve Consultants(NewIndex)
                    Consultants(NewIndex) = Addresses(iIndex).Name
                End If
            End If
        Next iIndex
        Array.Sort(Consultants)
        NewIndex = Consultants.GetUpperBound(0) + 1
        ReDim Preserve Consultants(NewIndex)
        Consultants(NewIndex) = TYPE_NAME_HERE
        Name_cmb.Items.Clear()
        If Type_cmb.SelectedIndex = ADDRESS_TYPE_CONSULTANT Then
            For iIndex As Integer = 1 To Consultants.GetUpperBound(0)
                Name_cmb.Items.Add(Consultants(iIndex))
            Next iIndex
        Else
            For Me.AddressIndex = 1 To Addresses.GetUpperBound(0)
                Name_cmb.Items.Add(Addresses(AddressIndex).Name)
            Next AddressIndex
        End If

    End Sub
End Class