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
    Public ADOConnectionOptionDataBase As New ADODB.Connection
    Public ADOConnectionMessageDataBase As New ADODB.Connection
    Public ADOConnectionHapDatabase As New ADODB.Connection
    Public ADOCatalogRPTdata As ADOX.Catalog = Nothing
    Public ADOCatalogHapDatabase As ADOX.Catalog = Nothing
    Public _ADOCatalogOptionDataBase As ADOX.Catalog = Nothing

    Public dsCadre As DataSet
    Public dtSummaryGroup As DataTable
    Public dtBaseGroup As DataTable
    Public dtAltGroup As DataTable
    Public dtContactGroup As DataTable
    Public dtBuildingInfo As DataTable

    Public BookingType As Integer
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

    'Public OpportunityID As String = ""
    Public UserRoleCRM, UserRole, UserRoleOFF, UserLevel As String
    Private PartnerNum As String = ""

    ' Cadre MOD Access Level
    Public FULL_ACCESS As Boolean
    Public SHELL_ACCESS As Boolean
    Public ENG_ACCESS As Boolean
    Public SID_ACCESS As Boolean
    Public HYDRO_ONLY_ACCESS As Boolean

    'Mod Related Veriables
    Public ENABLE_BOOKING_BTN As Boolean

    Public DataChangedByProgram As Boolean
    


    Public Property ADOCatalogOptionDataBase() As ADOX.Catalog
        Get
            If _ADOCatalogOptionDataBase Is Nothing Then
                _ADOCatalogOptionDataBase = New ADOX.Catalog()
            End If
            Return _ADOCatalogOptionDataBase
        End Get
        Set(ByVal Value As ADOX.Catalog)
            _ADOCatalogOptionDataBase = Value
        End Set
    End Property
    Public ADOCatalogMessageDataBase As ADOX.Catalog = Nothing
    Public MachineType As String = String.Empty
    Public CurrentUnits As String = String.Empty
    Public EstimateLevel As String = String.Empty

    Structure All_LocalCodeDepTYP
        Dim CanadaJob As Boolean
        Dim PuertoRicoJob As Boolean
        Dim MODJob As Boolean
    End Structure
    Public All_LocalCodeDep As New All_LocalCodeDepTYP()
End Module
