Module Global_Renamed
    '   Address
    Public Address As CM_ADDRS_IO.Address_TypeDec = CM_ADDRS_IO.Address_TypeDec.CreateInstance()
    Public Addresses() As CM_ADDRS_IO.Address_TypeDec = Nothing
    Public Owner_Info As CM_ADDRS_IO.Address_TypeDec = CM_ADDRS_IO.Address_TypeDec.CreateInstance()
    Public JobContact As CM_ADDRS_IO.Contacts_TypeDec = CM_ADDRS_IO.Contacts_TypeDec.CreateInstance()


    'Contract Manager
    Public gContractID As String = ""
    Public Contracts As CM_MAIN_IO.Contracts_TypeDec = CM_MAIN_IO.Contracts_TypeDec.CreateInstance()

End Module
