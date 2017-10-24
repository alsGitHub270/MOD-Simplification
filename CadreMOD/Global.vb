Module Global_Renamed
    '   Address
    Public Address As CM_ADDRS_IO.Address_TypeDec = CM_ADDRS_IO.Address_TypeDec.CreateInstance()
    Public Addresses() As CM_ADDRS_IO.Address_TypeDec = Nothing
    Public Owner_Info As CM_ADDRS_IO.Address_TypeDec = CM_ADDRS_IO.Address_TypeDec.CreateInstance()
    Public JobContact As CM_ADDRS_IO.Contacts_TypeDec = CM_ADDRS_IO.Contacts_TypeDec.CreateInstance()


    'Contract Manager
    Public gContractID As String = ""
    Public Contracts As CM_MAIN_IO.Contracts_TypeDec = CM_MAIN_IO.Contracts_TypeDec.CreateInstance()

    Public ADOConnection As New ADODB.Connection
    Public ADOConnectionRPTDataDB As New ADODB.Connection
    Public ADOConnectionMODDataDataBase As New ADODB.Connection
    Public ADOConnectionMessageDataBase As New ADODB.Connection
    Public ADOConnectionHapDatabase As New ADODB.Connection
    Public ADOCatalogRPTdata As ADOX.Catalog = Nothing
    Public ADOCatalogHapDatabase As ADOX.Catalog = Nothing
    Public _ADOCatalogMODDataDataBase As ADOX.Catalog = Nothing
    Public ADOCatalogMessageDataBase As ADOX.Catalog = Nothing

    Public dsCadre As DataSet
    Public dtSummaryGroup As DataTable
    Public dtBaseGroup As DataTable
    Public dtAltGroup As DataTable
    Public dtContactGroup As DataTable
    Public dtBuildingInfo As DataTable
    Public dtLaborRates As DataTable

    Public BookingType As Integer
    Public DefaultTaxCode As String = ""
    Public AttachBookingFile As Boolean

    '  Paths
    Public tPathName As String = ""
    Public EstimatePath As String = ""
    Public SAPPath As String = ""
    Public SystemDatabaseName As String = ""
    Public ReportsPath As String = ""
    Public ArchivePath As String = ""
    Public DebugPath As String = ""
    Public PathPDF As String = ""
    Public HAPDatabasePath As String = ""
    Public EPCOPath As String = ""
    Public SpecAndDataPath As String = ""
    Public SuptPath As String = ""

    Public EstimateModified As Boolean

    Public gsCommand As String = ""
    Public OpportunityID As String = String.Empty
    Public UserRole As String


    ' Cadre MOD Access Level
    Public FULL_ACCESS As Boolean
    Public SHELL_ACCESS As Boolean
    Public ENG_ACCESS As Boolean
    Public SID_ACCESS As Boolean
    Public HYDRO_ONLY_ACCESS As Boolean

    'Mod Related Veriables

    Public ENABLE_BOOKING_BTN As Boolean

    Public DataChangedByProgram As Boolean
    
    Public All_LocalCodeDep As New All_LocalCodeDepTYP()


    Public TaxRate As Single = -999.99


    Public Property ADOCatalogMODDataDataBase() As ADOX.Catalog
        Get
            If _ADOCatalogMODDataDataBase Is Nothing Then
                _ADOCatalogMODDataDataBase = New ADOX.Catalog()
            End If
            Return _ADOCatalogMODDataDataBase
        End Get
        Set(ByVal Value As ADOX.Catalog)
            _ADOCatalogMODDataDataBase = Value
        End Set
    End Property


    Public CalledToRunReconfig As Boolean
    Public CarProductCode As Integer

    'Public GONumbers() As CM_MAIN_IO.GONumbers_TypeDec = Nothing
    Public CurrentGOSelection As Byte
    '  Public CM_GridStatus As New CM_MAIN_IO.CM_GridStatus_TypeDec()

    Public Structure tagCostGridType_Data
        Dim MenuIndex As Byte
        Dim FormsName As String
        <Microsoft.VisualBasic.VBFixedArray(9)> _
        Dim Col() As String
        <Microsoft.VisualBasic.VBFixedArray(9)> _
        Dim RunCol() As String
        Dim ReferenceNumber As String
        Dim FCG As Byte
        Dim PriceNotFound As Boolean
        Dim CheckProductCode As Boolean
        Dim ComponentName As String
        Dim ComponentIncludedWith As String
        Dim EngineeringHrs As Single
        Dim RunEngineeringHrs As Single
        Dim BDPLocation As String
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=1)> _
        Dim AutomatedComponent As String
        Dim Quotable As Boolean
        Dim OptionName As String
        Public Shared Function CreateInstance() As tagCostGridType_Data
            Dim result As New tagCostGridType_Data()
            result.FormsName = String.Empty
            ReDim result.Col(9)
            ReDim result.RunCol(9)
            result.ReferenceNumber = String.Empty
            result.ComponentName = String.Empty
            result.ComponentIncludedWith = String.Empty
            result.AutomatedComponent = ""
            result.BDPLocation = String.Empty
            result.OptionName = String.Empty
            Return result
        End Function
    End Structure
    Public CostGridType_Data() As tagCostGridType_Data = Nothing


    Structure All_LocalCodeDepTYP
        Dim CanadaJob As Boolean
        Dim PuertoRicoJob As Boolean
        Dim MODJob As Boolean
    End Structure

    '  Paths
    Public Structure CRM_typ
        Dim SalesRepName As String
        Dim SalesOffice As String
        Dim NameValue As String
        Dim Street As String
        Dim City1 As String
        Dim City2 As String
        Dim State As String
        Dim Country As String
        Dim PostalCode As String
        Dim TaxType As String
        Public Shared Function CreateInstance() As CRM_typ
            Dim result As New CRM_typ()
            result.SalesRepName = String.Empty
            result.SalesOffice = String.Empty
            result.NameValue = String.Empty
            result.Street = String.Empty
            result.City1 = String.Empty
            result.City2 = String.Empty
            result.State = String.Empty
            result.Country = String.Empty
            result.PostalCode = String.Empty
            result.TaxType = String.Empty
            Return result
        End Function
    End Structure
    Public ProjectData As CRM_typ = CRM_typ.CreateInstance()

    Public Structure CurrentGOData_Type
        Dim Type As String
        Dim Bank As String
        Dim Alt As String
        Dim Units As String
        Dim MachineType As String
        Dim CurrentUnits As String
        Dim EstimateLevel As String
        Public Shared Function CreateInstance() As CurrentGOData_Type
            Dim result As New CurrentGOData_Type()
            result.Type = String.Empty
            result.Bank = String.Empty
            result.Alt = String.Empty
            result.Units = String.Empty
            result.MachineType = String.Empty
            result.CurrentUnits = String.Empty
            result.EstimateLevel = String.Empty
            Return result
        End Function
    End Structure
    Public CurrentGOData_Typ As CurrentGOData_Type = CurrentGOData_Type.CreateInstance()
    Public UnitsInEstimate() As String = Nothing
End Module
