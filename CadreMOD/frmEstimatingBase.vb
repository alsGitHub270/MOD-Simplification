Public Class frmEstimatingBase
    Inherits System.Windows.Forms.Form
    Dim sv As New FarPoint.Win.Spread.SheetView()
    Dim svCollection As New System.Collections.ArrayList(10)
    Dim myDataSet As System.Data.DataSet

    Private Sub CreateDataSet()
        Dim MainGroups As DataTable
        Dim SubGroups As DataTable
        Dim Materials As DataTable
        Dim dtStr As System.Type
        Dim dtInt As System.Type
        dtStr = System.Type.GetType("System.String")
        dtInt = System.Type.GetType("System.Int32")

        myDataSet = New DataSet()
        myDataSet.EnforceConstraints = False

        MainGroups = myDataSet.Tables.Add("EstMainGroup")
        MainGroups.Columns.AddRange(New DataColumn() {New DataColumn("Main Group", dtStr), New DataColumn("id", dtInt)})
        MainGroups.Rows.Add(New Object() {"MACHINE ROOM", 0})
        MainGroups.Rows.Add(New Object() {"CAR", 1})
        MainGroups.Rows.Add(New Object() {"LANDING DOOR", 2})
        MainGroups.Rows.Add(New Object() {"HOISTWAY", 3})
        MainGroups.Rows.Add(New Object() {"FIXTURES", 4})
        MainGroups.Rows.Add(New Object() {"PIT", 5})
        MainGroups.Rows.Add(New Object() {"MISCELLANEOUS", 6})

        SubGroups = myDataSet.Tables.Add("EstSubGroup")
        SubGroups.Columns.AddRange(New DataColumn() {New DataColumn("Sub Group", dtStr), New DataColumn("Total Material Cost", dtInt), New DataColumn("Total Labor Cost", dtInt), New DataColumn("MainID", dtInt)})
        SubGroups.Rows.Add(New Object() {"Controller", 0, 0, 0})
        SubGroups.Rows.Add(New Object() {"Machine", 0, 0, 0})
        SubGroups.Rows.Add(New Object() {"Governor", 0, 0, 0})
        SubGroups.Rows.Add(New Object() {"ACUM", 0, 0, 0})
        SubGroups.Rows.Add(New Object() {"Car Items", 0, 0, 1})
        SubGroups.Rows.Add(New Object() {"Door Operator", 0, 0, 1})
        SubGroups.Rows.Add(New Object() {"Roller Guides", 0, 0, 1})
        SubGroups.Rows.Add(New Object() {"Passenger Cab", 0, 0, 1})
        SubGroups.Rows.Add(New Object() {"Freight Cab", 0, 0, 1})
        SubGroups.Rows.Add(New Object() {"Landing Door", 0, 0, 2})
        SubGroups.Rows.Add(New Object() {"Hoistway", 0, 0, 3})
        SubGroups.Rows.Add(New Object() {"Fixtures", 0, 0, 4})
        SubGroups.Rows.Add(New Object() {"Pit", 0, 0, 5})
        SubGroups.Rows.Add(New Object() {"Miscellaneous", 0, 0, 6})

        Materials = myDataSet.Tables.Add("EstMaterials")
        Materials.Columns.AddRange(New DataColumn() {New DataColumn("Material Description", dtStr), New DataColumn("Sub Group", dtStr),
                                   New DataColumn("Status", dtStr), New DataColumn("Type", dtStr), New DataColumn("Units", dtStr),
                                   New DataColumn("Order By", dtStr), New DataColumn("Qty", dtInt), New DataColumn("HQ Cost", dtInt),
                                   New DataColumn("RL Cost", dtInt), New DataColumn("BDP Hours", dtInt), New DataColumn("Special Hours", dtInt),
                                   New DataColumn("Total Hours", dtInt), New DataColumn("OT Hours", dtInt), New DataColumn("Total Material Cost", dtInt),
                                   New DataColumn("Total Labor Cost", dtInt)})
        Materials.Rows.Add(New Object() {"Controller", "Controller", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Security Package", "Controller", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Inter-Group Emergency Power", "Controller", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Drive", "Controller", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Transformer", "Controller", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Choke", "Controller", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"MTO", "Controller", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Machine Room Wiring", "Controller", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Machine Room Duct", "Controller", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})

        Materials.Rows.Add(New Object() {"Machine", "Machine", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"AC Motor", "Machine", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Motor Adapter Plate", "Machine", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Brake Switch", "Machine", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Machine Isolation", "Machine", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Sheaves", "Machine", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Sheave Guard", "Machine", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Bed Plate", "Machine", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Brake Work (for reuse, refurbish)", "Machine", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Nitro Cleaning (for reuse, refurbish)", "Machine", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Machine Refuubishment Work", "Machine", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})

        Materials.Rows.Add(New Object() {"Governor", "Governor", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Governor Encoder", "Governor", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Governor (Cwt)", "Governor", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})

        Materials.Rows.Add(New Object() {"Rope Gripper", "ACUM", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Rope Gripper Mounting Kit", "ACUM", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})

        Materials.Rows.Add(New Object() {"Car Top Maintenance Station", "Car Items", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"SALSIS / Leveling Unit", "Car Items", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"ETS / ETSL", "Car Items", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Load Weighing Device", "Car Items", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Car Duct", "Car Items", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"OKR (Car Top Box)", "Car Items", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})



        Materials.Rows.Add(New Object() {"Front Car Door Operator Package", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Front Car Door Operator", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Front Clutch", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Front Car Door Track", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Front Car Door Hanger", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Front Car Door Gate Switch", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Rear Car Door Operator Package", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Rear Car Door Operator", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Rear Clutch", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Rear Car Door Track", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Rear Car Door Hanger", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Rear Car Door Gate Switch", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Door Restrictor", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Door Detectors", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Toe Guard", "Door Operator", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})



        Materials.Rows.Add(New Object() {"Roller Guides (Car)", "Roller Guides", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Car Roller Guide Adapter Plate", "Roller Guides", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})



        Materials.Rows.Add(New Object() {"New Cab Complete", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Cab Shell", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Ceiling /  Lighting", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Emergency Light (Canopy Type)", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Cab Returns", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Cab Panels", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Car Door", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Handrails", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Car Sill", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Fan", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Emergency Exit Switch", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Cab Flooring", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Sub-flooring", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Cab Pads", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Car Top Hand Rail", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Car Platform", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Car Sling", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Isolation Pads", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Car Safety", "Passenger Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})



        Materials.Rows.Add(New Object() {"Freight Enclosure", "Freight Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Gate", "Freight Cab", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})





        Materials.Rows.Add(New Object() {"Hoistway Frame", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Door", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Door Tracks", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Nylon Track Inserts", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Door Hangers", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Door Rollers", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Interlocks and Pickups", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Door Closers", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Escutheons", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Door Gibs", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Fire Tabs", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Sight Guard", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Astragals", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Sill", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Struts", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Headers", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Door Package", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Door Tracks", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Door Hanger", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Door Interlocks / Pickups", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Door Closers", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Freight Door Package", "Landing Door", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})



        Materials.Rows.Add(New Object() {"Travelling Cable / Hoistway Wiring", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Duct", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Travel Cable Hangers", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoist Ropes", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"STMs", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Anti-twist Device", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"STM Car / Cwt Adapter", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Shackles", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Car Governor Rope", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Cwt Governor Rope", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Car Sheave and Guard", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Cwt Sheave and Guard", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Roller Guides (Cwt)", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Cwt Roller Guide Adapter Plate", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Seismic Switch", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Seismic Equipment", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Guide Rails", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Rail Brackets", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Counterweight Frame", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Counterweight Sub-Weights", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Cwt Safety", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Screening", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Limit Switch", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Fascia", "Hoistway", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})





        Materials.Rows.Add(New Object() {"Main Car Station", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Aux Car Station", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Car Traveling Lantern", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Car Position Indicator (In-Transom)", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Voice Annunciator", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hands Free Phone", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hall Stations", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hall Position Indicator", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hall Lantern", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hall PI / Lantern Combo", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Hoistway Access Switch", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"FER Switch", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Inconspicuous Risers", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Jamb Braille", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Emergency Power Panel", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Status Panel", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"LobbyVision", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Intercom System", "Fixtures", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})



        Materials.Rows.Add(New Object() {"Car Buffer", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Car Buffer Blocking", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Cwt Buffer", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Cwt Buffer Blocking", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Buffer Switch", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Governor Tension Sheave (Car)", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Governor Tension Sheave (Cwt)", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Pit Switch", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Pit Ladder", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Pit Light", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"WhisperFlex", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Sway Device", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Compensation Rope", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Compensation Sheave", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Compensation Switch", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Counterweight Guard", "Pit", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})



        Materials.Rows.Add(New Object() {"Cleaning and Painting", "Miscellaneous", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"SAIS Inspection", "Miscellaneous", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Consultant / GSA Inspection", "Miscellaneous", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Fire Service / EP Testing", "Miscellaneous", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Machine Room Special Access", "Miscellaneous", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})
        Materials.Rows.Add(New Object() {"Miscelleneous", "Miscellaneous", "", "", "01-04", "", 4, 0, 0, 0, 0, 0, 0, 0, 0})

        'Add the relations
        myDataSet.Relations.Add("EstSubGroup", MainGroups.Columns("id"), SubGroups.Columns("MainID"))
        myDataSet.Relations.Add("EstMaterials", SubGroups.Columns("Sub Group"), Materials.Columns("Sub Group"))

    End Sub

    Private Sub frmEstimatingBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fpFont As New System.Drawing.Font("Microsoft Sans Serif", 8.25)

        TabControl1.Left = 3
        TabControl1.Width = GroupBox1.Width - FpSpread1.Left - 5
        FpSpread1.ActiveSheet.ColumnHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer
        FpSpread1.ActiveSheet.RowHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer
        FpSpread1.ActiveSheet.SheetCorner.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.CornerRenderer
        FpSpread1.InterfaceRenderer = Nothing
        FpSpread1.HorizontalScrollBar.Renderer = Nothing
        FpSpread1.VerticalScrollBar.Renderer = Nothing
        FpSpread1.VisualStyles = FarPoint.Win.VisualStyles.Off
        'Init Spread
        With FpSpread1.ActiveSheet
            .Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, FpSpread1.ActiveSheet.ColumnCount - 1).Font = fpFont
            .Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, FpSpread1.ActiveSheet.ColumnCount - 1).ForeColor = Color.Black
            .ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).Font = fpFont
            .ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).BackColor = Color.DarkGray
            .ColumnHeader.Cells(0, 0, 0, FpSpread1.ActiveSheet.ColumnCount - 1).ForeColor = Color.Black
            .RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank
            .RowHeader.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, 0).BackColor = Color.DarkGray
            .RowHeader.Cells(0, 0, FpSpread1.ActiveSheet.RowCount - 1, 0).ForeColor = Color.Black
            .SheetCornerStyle.BackColor = Color.DarkGray
            .SetColumnWidth(0, 150)
            .SetColumnVisible(1, False)
            .GrayAreaBackColor = Color.White
        End With
        FpSpread1.Left = 6
        FpSpread1.Width = GroupBox1.Width - FpSpread1.Left - 20
        FpSpread1.Visible = False
        ExpandCollapseAll("Expand")
        ExpandCollapseAll("Collapse")
        FpSpread1.Visible = True
        Dim ChildSheetView1 As FarPoint.Win.Spread.SheetView = Nothing, ChildSheetView2 As FarPoint.Win.Spread.SheetView = Nothing
        For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
            ChildSheetView1 = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
            If Not ChildSheetView1 Is Nothing Then
                For jindex As Integer = 0 To ChildSheetView1.RowCount - 1
                    ChildSheetView2 = ChildSheetView1.FindChildView(jindex, 0)
                    If Not ChildSheetView2 Is Nothing Then
                        ChildSheetView2.SetColumnVisible(1, False)
                    End If
                Next jindex
            End If
        Next iIndex
        Button2.Left = FpSpread1.Left
        Button2.Top = FpSpread1.Top - Button2.Height - 10
        Button3.Left = FpSpread1.Right - Button3.Width
        Button3.Top = FpSpread1.Top - Button3.Height - 10

    End Sub

    Private Sub FpSpread1_ChildViewCreated(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChildViewCreatedEventArgs) Handles FpSpread1.ChildViewCreated

        e.SheetView.ColumnHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.ColumnHeaderRenderer
        e.SheetView.RowHeader.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.RowHeaderRenderer
        e.SheetView.SheetCorner.DefaultStyle.Renderer = New FarPoint.Win.Spread.CellType.CornerRenderer
        FpSpread1.InterfaceRenderer = Nothing
        FpSpread1.HorizontalScrollBar.Renderer = Nothing
        FpSpread1.VerticalScrollBar.Renderer = Nothing
        Dim fpFont As New System.Drawing.Font("Microsoft Sans Serif", 8.25)
        'Display child
        e.SheetView.Cells(0, 0, e.SheetView.RowCount - 1, e.SheetView.ColumnCount - 1).Font = fpFont
        e.SheetView.Cells(0, 0, e.SheetView.RowCount - 1, e.SheetView.ColumnCount - 1).ForeColor = Color.Black
        e.SheetView.ColumnHeader.Cells(0, 0, 0, e.SheetView.ColumnCount - 1).Font = fpFont
        e.SheetView.ColumnHeader.Cells(0, 0, 0, e.SheetView.ColumnCount - 1).BackColor = FpSpread1.ActiveSheet.ColumnHeader.Cells(0, 0).BackColor
        e.SheetView.ColumnHeader.Cells(0, 0, 0, e.SheetView.ColumnCount - 1).ForeColor = FpSpread1.ActiveSheet.ColumnHeader.Cells(0, 0).ForeColor
        e.SheetView.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank
        e.SheetView.RowHeader.Cells(0, 0, e.SheetView.RowCount - 1, 0).BackColor = FpSpread1.ActiveSheet.RowHeader.Cells(0, 0).BackColor
        e.SheetView.RowHeader.Cells(0, 0, e.SheetView.RowCount - 1, 0).ForeColor = FpSpread1.ActiveSheet.RowHeader.Cells(0, 0).ForeColor
        e.SheetView.SheetCornerStyle.BackColor = FpSpread1.ActiveSheet.SheetCornerStyle.BackColor
        e.SheetView.GrayAreaBackColor = Color.Gray
        e.SheetView.SetColumnWidth(1, 110)
        e.SheetView.SetColumnWidth(2, 110)
        e.SheetView.SetColumnVisible(3, False)
        svCollection.Add(e.SheetView)

    End Sub
    Private Sub _IconButton_cmd_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _IconButton_cmd_0.Click
        End
    End Sub

    Private Sub _IconButton_cmd_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _IconButton_cmd_6.Click
        CM_MAIN_frm.Show()
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ExpandCollapseAll("Expand")
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ExpandCollapseAll("Collapse")
    End Sub
    Private Sub ExpandCollapseAll(ByVal ExpandCollapseAction As String)
        Dim ChildSheetView As FarPoint.Win.Spread.SheetView = Nothing

        For iIndex As Integer = 0 To FpSpread1.ActiveSheet.RowCount - 1
            Select Case ExpandCollapseAction
                Case "Expand"
                    FpSpread1.ActiveSheet.ExpandRow(iIndex, True)
                    ChildSheetView = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
                    If Not ChildSheetView Is Nothing Then
                        For jIndex As Integer = 0 To ChildSheetView.RowCount - 1
                            ChildSheetView.ExpandRow(jIndex, True)
                        Next jIndex
                    End If
                Case "Collapse"
                    FpSpread1.ActiveSheet.ExpandRow(iIndex, False)
                    ChildSheetView = FpSpread1.ActiveSheet.FindChildView(iIndex, 0)
                    If Not ChildSheetView Is Nothing Then
                        For jIndex As Integer = 0 To ChildSheetView.RowCount - 1
                            ChildSheetView.ExpandRow(jIndex, False)
                        Next jIndex
                    End If
                Case Else
            End Select
        Next iIndex

    End Sub

End Class
