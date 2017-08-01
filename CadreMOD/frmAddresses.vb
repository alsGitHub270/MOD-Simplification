Imports System.IO
Imports Newtonsoft.Json

Public Class frmAddresses

    Dim buildingOwner As New Contact
    Dim consultant As New Contact
    Dim gc As New Contact
    Dim architect As New Contact
    Dim mgmtCo As New Contact
    Dim otherContact As New Contact


    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        ' fired every time tab changes
        Dim thisClass As Contact = Nothing

        Select Case TabControl1.SelectedIndex
            Case 0
                'GetOwnerData()
                thisClass = buildingOwner
            Case 1
                'GetConsultantData()
                thisClass = consultant
            Case 2
                thisClass = gc
            Case 3
                thisClass = architect
            Case 4
                thisClass = mgmtCo
            Case 5
                thisClass = otherContact

            Case Else
                ClearData()

        End Select
        If Not IsNothing(thisClass) Then
            GetData(thisClass)
        End If
    End Sub


    Private Sub GetOwnerData()

        Try
            Me.txtCompanyName.Text = buildingOwner.companyName
            Me.txtContactName.Text = buildingOwner.contactName
            Me.txtAddress.Text = buildingOwner.address
            Me.txtAddress2.Text = buildingOwner.address2
            Me.txtCity.Text = buildingOwner.city
            Me.txtState.Text = buildingOwner.state
            Me.txtZipCode.Text = buildingOwner.zipcode
            Me.txtPhone.Text = buildingOwner.phone
            Me.txtExt.Text = buildingOwner.ext
            Me.txtFax.Text = buildingOwner.fax
            Me.txtEmail.Text = buildingOwner.email
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Getting Building Owner Data")
        End Try

    End Sub

    Private Sub PostOwnerData()

        Try
            With buildingOwner
                .companyName = Me.txtCompanyName.Text
                .contactName = Me.txtContactName.Text
                .address = Me.txtAddress.Text
                .address2 = Me.txtAddress2.Text
                .city = Me.txtCity.Text
                .state = Me.txtState.Text
                .zipcode = Me.txtZipCode.Text
                .phone = Me.txtPhone.Text
                .ext = Me.txtExt.Text
                .fax = Me.txtFax.Text
                .email = Me.txtEmail.Text
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Posting Building Owner Data")

        End Try

    End Sub

    Private Sub GetConsultantData()

        With consultant
            Me.txtCompanyName.Text = .companyName
            Me.txtContactName.Text = .contactName
            Me.txtAddress.Text = .address
            Me.txtAddress2.Text = .address2
            Me.txtCity.Text = .city
            Me.txtState.Text = .state
            Me.txtZipCode.Text = .zipcode
            Me.txtPhone.Text = .phone
            Me.txtExt.Text = .ext
            Me.txtFax.Text = .fax
            Me.txtEmail.Text = .email
        End With
    End Sub

    Private Sub PostConsultantData()
        Try
            With consultant

                .companyName = Me.txtCompanyName.Text
                .contactName = Me.txtContactName.Text
                .address = Me.txtAddress.Text
                .address2 = Me.txtAddress2.Text
                .city = Me.txtCity.Text
                .state = Me.txtState.Text
                .zipcode = Me.txtZipCode.Text
                .phone = Me.txtPhone.Text
                .ext = Me.txtExt.Text
                .fax = Me.txtFax.Text
                .email = Me.txtEmail.Text

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Posting Consultant Data")
        End Try
    End Sub

    Private Sub GetData(thisClass As Contact)

        With thisClass
            Me.txtCompanyName.Text = .companyName
            Me.txtContactName.Text = .contactName
            Me.txtAddress.Text = .address
            Me.txtAddress2.Text = .address2
            Me.txtCity.Text = .city
            Me.txtState.Text = .state
            Me.txtZipCode.Text = .zipcode
            Me.txtPhone.Text = .phone
            Me.txtExt.Text = .ext
            Me.txtFax.Text = .fax
            Me.txtEmail.Text = .email
        End With

    End Sub
    Private Sub PostData(thisClass As Contact)
        Try
            With thisClass

                .companyName = Me.txtCompanyName.Text
                .contactName = Me.txtContactName.Text
                .address = Me.txtAddress.Text
                .address2 = Me.txtAddress2.Text
                .city = Me.txtCity.Text
                .state = Me.txtState.Text
                .zipcode = Me.txtZipCode.Text
                .phone = Me.txtPhone.Text
                .ext = Me.txtExt.Text
                .fax = Me.txtFax.Text
                .email = Me.txtEmail.Text

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Posting Consultant Data")
        End Try
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



    Public Sub Save()
        Dim myList As New List(Of Contact)()
        Dim theseClasses As New Contact

        myList.Add(buildingOwner)
        myList.Add(consultant)
        myList.Add(gc)
        myList.Add(architect)
        myList.Add(mgmtCo)
        myList.Add(otherContact)
        Call theseClasses.Save(myList)


    End Sub

    Private Function Deserialize(myList As List(Of Contact))

        Dim json As String = ""
        Try
            Using sr As StreamReader = New StreamReader("C:\Temp\file.json")
                json = sr.ReadToEnd
            End Using
            myList = JsonConvert.DeserializeObject(Of List(Of Contact))(json)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Desearlizing Classes")
        End Try

        Return myList
    End Function
    Private Sub frmAddresses_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim myList As New List(Of Contact)()
        myList = Deserialize(myList)
        buildingOwner = myList(0)
        consultant = myList(1)
        gc = myList(2)
        architect = myList(3)
        GetOwnerData()

    End Sub

  
    'Private Sub tabConsultant_Leave(sender As System.Object, e As System.EventArgs) Handles tabConsultant.Leave
    '    PostConsultantData()
    'End Sub

    'Private Sub tabArchitect_Leave(sender As System.Object, e As System.EventArgs) Handles tabArchitect.Leave
    '    Stop
    '    PostData(architect)
    'End Sub

   
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Stop
        Select Case TabControl1.SelectedIndex
            Case 0
                PostData(buildingOwner)
            Case 1
                PostData(consultant)
            Case 3
                PostData(architect)
            Case Else
                ClearData()

        End Select
    End Sub
End Class