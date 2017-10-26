Module CM_MAIN_IO
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
        Dim OpportunityToOfferDate As String
        Dim ProposedDate As String
        Dim OpportunityClosedDate As String
        Dim LCName As String
        Dim District As String
        Dim Region As String
        Dim Territory As String
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
            result.OpportunityToOfferDate = String.Empty
            result.ProposedDate = String.Empty
            result.OpportunityClosedDate = String.Empty
            result.LCName = String.Empty
            result.District = String.Empty
            result.Region = String.Empty
            result.Territory = String.Empty
            Return result
        End Function
    End Structure
End Module
