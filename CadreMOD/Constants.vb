Module Constants
    ' Contract Manager
    Public Const tCM_TITLE As String = "MOD Estimating"
    Public Const tCM_ADDRESS_TITLE As String = "Address"
    Public DEFAULT_C1 As Single = 0.2


    Public Const ImageFileLocation As String = "C:\Users\adolfsal\Documents\Visual Studio 2010\Projects\Mod Simplification\CadreMOD"
    Public Const MOVE_FIRST As Integer = 0
    Public Const MOVE_NEXT As Integer = 1
    Public Const MOVE_PREVIOUS As Integer = 2
    Public Const MOVE_LAST As Integer = 3
    Public Const FIND_FIRST As Integer = 4
    Public Const FIND_NEXT As Integer = 5
    Public Const FIND_PREV As Integer = 6
    Public Const FIND_LAST As Integer = 7
    Public Const SEEK_ME As Integer = 8
    Public Const FILTER_ME As Integer = 9
    Public Const OPEN_RECORD As Integer = 10
    Public Const ADD_RECORD As Integer = 11
    Public Const UPDATE_RECORD As Integer = 12
    Public Const DELETE_RECORD As Integer = 13
    Public Const SET_RECORDSET As Integer = 14
    Public Const RECORD_NOT_FOUND As Integer = 15
    Public Const DUPLICATE_RECORD_FOUND As Integer = 16
    Public Const END_OF_RECORD As Integer = 17
    Public Const CLOSE_RECORD As Integer = 18
    Public Const REQUERY_ME As Integer = 19
    Public Const UPDATE_PITDRAW As Integer = 20
    Public Const NON_CRITICAL_ERROR As Integer = 21
    Public Const CRITICAL_ERROR As Integer = 22
    Public Const OPTION_DATABASE_NAME As String = "OPTIONS.accdb"
    Public Const BUILDING_CODE_TABLE_QUERY_NAME As String = "BUILDING_CODE_TABLE_SQL"
    Public Const BUILDING_CODE_ONLY_QUERY_NAME As String = "BUILDING_CODE_ONLY_SQL"
    Public Const ENTRY_VALID As Integer = 0
    Public Const ENTRY_NOT_AN_INTEGER As Integer = 1
    Public Const ENTRY_NOT_A_NUMBER As Integer = 2
    Public Const ENTRY_NOT_IN_THE_LIST As Integer = 3
    Public Const ENTRY_NOT_A_DATE As Integer = 4
    Public Const ENTRY_NOT_IN_THE_NUMBER_RANGE As Integer = 5
    Public Const ENTRY_NOT_BLANK As Integer = 6
    Public Const ENTRY_HAS_TOO_MANY_DECIMALS As Integer = 7
    Public Const GROUP_SETUP_QRY As String = "GROUP_SETUP_QRY"
    Public Const HYDRO_TYPE As String = "Hydro"
    Public Const GEARED_TYPE As String = "Geared"
    Public Const GEARLESS_TYPE As String = "Gearless"
    Public Const AC_TYPE As String = "AC"
    Public Const AC_REGEN_TYPE As String = "AC Regen"
    Public Const DC_TYPE As String = "DC"
    Public Const SEC As String = "Schindler"
    Public Const EPCO As String = "EPCO"
    Public Const Gettysburg As String = "Gettysburg"
    Public Const EECO As String = "EECO"
    Public Const WESTINGHOUSE As String = "Westinghouse"
    Public Const GAL As String = "GAL"
    Public Const OTIS As String = "Otis"
    Public Const AMERICAN As String = "AMERICAN"
    Public Const ARMOR As String = "Armor"
    Public Const ATLANTIC As String = "ATLANTIC"
    Public Const BULL As String = "Bull"
    Public Const CJ_ANDERSON As String = "CJ Anderson"
    Public Const DOVER As String = "Dover"
    Public Const ECI As String = "ECI"
    Public Const ELSCO As String = "Elsco"
    Public Const ELECTRON_DRUM As String = "Electron Drum"
    Public Const ELEVATOR_CO_OF_AMERICA As String = "Elevator Co. of America"
    Public Const EXISTING As String = "Existing"
    Public Const GIZAVES_ELEVATOR As String = "Gizaves Elevator"
    Public Const GRAVES As String = "Graves"
    Public Const GTE As String = "GTE"
    Public Const GTMCLAUTHLIN As String = "G.T. McLauthlin"
    Public Const HAUGHTON As String = "Haughton"
    Public Const HOLLISTERWHITNEY As String = "Hollister-Whitney"
    Public Const ILLINOIS As String = "Illinois"
    Public Const IMPERIAL As String = "Imperial"
    Public Const INNOVATION As String = "Innovation"
    Public Const K_AND_H As String = "K & H"
    Public Const KEYSTONEHINDLEY As String = "KEYSTONE & HINDLEY"
    Public Const KIMBELLBROS As String = "KIMBELL BROS"
    Public Const MAC As String = "MAC"
    Public Const MAD As String = "MAD"
    Public Const MARINE_ENGINE As String = "Marine Engine"
    Public Const MARSHALLBROS As String = "MARSHALL BROS"
    Public Const MCE As String = "MCE"
    Public Const MOLINE_MONTGOMERY As String = "Moline/Montgomery"
    Public Const MONITOR As String = "Monitor"
    Public Const MONTGOMERY As String = "Montgomery"
    Public Const OHIO_ELEVATOR As String = "Ohio Elevator"
    Public Const GURNEY As String = "GURNEY"
    Public Const OTHER As String = "Other"
    Public Const PACIFIC_ELEVATOR As String = "Pacific Elevator"
    Public Const PITTENGINEERING As String = "PITT ENGINEERING"
    Public Const REEDY As String = "Reedy"
    Public Const RELIANCE As String = "RELIANCE"
    Public Const RENOLD As String = "RENOLD"
    Public Const SELCOM As String = "Selcom"
    Public Const SPENCERGEARED As String = "SPENCER GEARED"
    Public Const VAN_EMON As String = "Van Emon"
    Public Const VILLARES As String = "Villares"
    Public Const WARNERDRUM As String = "WARNER DRUM"
    Public Const TYPE_NAME_HERE As String = "<Type Name Here>"
    Public Const MAXTON As String = "Maxton"
    Public Const MIN_BLDG_FLRS As Integer = 2
    Public Const MAX_BLDG_FLRS As Integer = 126
    Public Const MAX_NUM_UNITS As Integer = 8
    Public Const DOORTYPE_1SSS As String = "1SSS (T1)"
    Public Const DOORTYPE_2SSS As String = "2SSS (T2)"
    Public Const DOORTYPE_1SCO As String = "1SCO (C2)"
    Public Const DOORTYPE_2SCO As String = "2SCO (C4)"
    Public Const DOORTYPE_FREIGHTMANUAL As String = "Freight-Manual"
    Public Const DOORTYPE_FREIGHTPOWER As String = "Freight-Power"
    Public Const DOORTYPE_SWING As String = "Swing"
    Public Const FINISH_4SS As String = "#4 Stainless Steel"
    Public Const FINISH_4BZ As String = "#4 Bronze"
    Public Const FINISH_8SS As String = "#8 Stainless Steel"
    Public Const FINISH_8BZ As String = "#8 Bronze"
    Public Const FINISH_PRIMER As String = "Primer"
    Public Const FINISH_BE As String = "Baked Enamel"
    Public Const FINISH_AL As String = "Aluminum"
    Public Const FINISH_BZ As String = "Bronze"
    Public Const FINISH_NS As String = "Nickle-Silver"
    Public Const FINISH_BBE As String = "Black Baked Enamel"
    Public Const FINISH_PLASTIC As String = "Plastic"
    Public Const FINISH_PAINTED As String = "Painted"
    Public Const FINISH_SS As String = "Stainless Steel"
    Public Const FINISH_WHITE As String = "White"
    Public Const FINISH_BLACK As String = "Black"
    Public Const FINISH_SILVER As String = "Silver"
    Public Const FINISH_CHROME As String = "Chrome"
    Public Const FINISH_GLASS As String = "Glass"


    ' Operational Constants
    Public Const APPLICATION_INI_FILE_NAME As String = "CadreMO.INI"

    ' From CRM.vb
    Public Const Status_OpportunityInProgress As String = "2 - Opp In Progress"
    Public Const Status_OpportunityOnHold As String = "2 - Opp On Hold"
    Public Const Status_OpportunityLost As String = "2 - Opp Lost"
    Public Const Status_OpportunityCancelled As String = "2 - Opp Cancelled"
    Public Const Status_OfferInProgress As String = "3 - Offer In Progress"
    Public Const Status_OfferCancelled As String = "3 - Offer(s) Cancelled"
    Public Const Status_OfferSubmitted As String = "4 - Offer Submitted"
    Public Const Status_OfferOnHold As String = "4 - Offer On Hold"
    Public Const Status_OfferWon As String = "4 - Offer Won"
    Public Const Status_OfferLost As String = "4 - Offer Lost"

    Public Const NOTES_BOOKING_DATABASE As String = "cdreup.nsf"
    Public Const NOTES_BOOKING_DATABASE_TEST As String = "testCdreup.nsf"

    'Bid Types
    Public Const BID_TYPE_CAPITAL_PLAN As String = "Capital Plan"
    Public Const BID_TYPE_FIRM_BID As String = "Firm Bid"

    Public Const USER_DIRECTOR As String = "YGNSLSPDRZNA" ' C CRM WebClient Business Role   Sales Director
    Public Const USER_MANAGER As String = "YGNSLSPMGZNA" ' C CRM WebClient Business Role   Sales Manager
    Public Const USER_SALES As String = "YGNSLSPROZNA" ' C CRM WebClient Business Role   Sales Professional
    Public Const USER_ENGINEER As String = "YGNSLSENGZNA" ' C CRM WebClient Business Role   Engineer

    Public Const USER_QM_SALES As String = "YGC_SALPRO"
    Public Const USER_QM_DIRECTOR As String = "YGC_SALDIR"
    Public Const USER_QM_MANAGER As String = "YGC_SALMAN"

End Module
