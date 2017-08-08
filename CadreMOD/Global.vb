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
    '   Dim dtBuildingJobInfoGroup As DataTable
    Public dtSummaryGroup As DataTable
    Public dtBaseGroup As DataTable
    Public dtAltGroup As DataTable
    Public dtContactGroup As DataTable
    Public dtBuildingInfo As DataTable


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
End Module
