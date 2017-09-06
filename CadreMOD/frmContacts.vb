Imports System.IO
Imports System.Linq
Imports Newtonsoft.Json
Imports System.Collections.Generic


Public Class frmContacts

    Dim BuildingOwner As New Contact
    Dim Consultant As New Contact
    Dim GC As New Contact
    Dim Architect As New Contact
    Dim MgmtCo As New Contact
    Dim OtherContact As New Contact

    Dim contactUpdated As Boolean = False

    Public Sub New()
        InitializeComponent()

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        ' fired every time tab changes
        Dim thisClass As Contact = Nothing

        Select Case TabControl1.SelectedIndex
            Case 0
                thisClass = BuildingOwner
            Case 1
                thisClass = Consultant
            Case 2
                thisClass = GC
            Case 3
                thisClass = Architect
            Case 4
                thisClass = MgmtCo
            Case 5
                thisClass = OtherContact
        End Select

        If Not IsNothing(thisClass) Then
            GetData(thisClass)
        End If

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

    Private Sub PostData(thisContactType As String, thisClass As Contact)

        contactUpdated = True

        ' if the current class as .contactType as Nothing, this is a new entry

        Try
            With thisClass
                If IsNothing(.contactType) Then
                    .contactType = thisContactType
                End If

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

    Private Sub frmContacts_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        contactUpdated = False
    End Sub

    Private Sub frmAddresses_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If contactUpdated Then
            ' add each class to a list
            Try
                Dim myList As New List(Of Contact)()

                myList.Add(BuildingOwner)
                myList.Add(Consultant)
                myList.Add(GC)
                myList.Add(Architect)
                myList.Add(MgmtCo)
                myList.Add(OtherContact)

                For Each item In myList
                    Dim contactRow() As Data.DataRow
                    contactRow = dtContactGroup.Select("contactType = '" & item.contactType & "'")

                    If Not IsNothing(item.contactType) Then
                        If contactRow.Count = 0 Then
                            Dim row As DataRow = dtContactGroup.NewRow
                            row("contactType") = item.contactType
                            row("companyName") = item.companyName
                            row("contactName") = item.contactName
                            row("address") = item.address
                            row("address2") = item.address2
                            row("city") = item.city
                            row("state") = item.state
                            row("zipcode") = item.zipcode
                            row("phone") = item.phone
                            row("ext") = item.ext
                            row("fax") = item.fax
                            row("email") = item.email
                            dtContactGroup.Rows.Add(row)
                        Else
                            contactRow(0).Item("contactType") = item.contactType
                            contactRow(0).Item("companyName") = item.companyName
                            contactRow(0).Item("contactName") = item.contactName
                            contactRow(0).Item("address") = item.address
                            contactRow(0).Item("address2") = item.address2
                            contactRow(0).Item("city") = item.city
                            contactRow(0).Item("state") = item.state
                            contactRow(0).Item("zipcode") = item.zipcode
                            contactRow(0).Item("phone") = item.phone
                            contactRow(0).Item("ext") = item.ext
                            contactRow(0).Item("fax") = item.fax
                            contactRow(0).Item("email") = item.email

                        End If
                    End If

                Next

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error updating dataset during formClosing")
            End Try

            ' Write the changes back to the datatable iteraing thru the list


        End If
    End Sub



    'Public Sub Save()
    '    Dim myList As New List(Of Contact)()
    '    Dim theseClasses As New Contact

    '    myList.Add(buildingOwner)
    '    myList.Add(consultant)
    '    myList.Add(gc)
    '    myList.Add(architect)
    '    myList.Add(mgmtCo)
    '    myList.Add(otherContact)
    '    Call theseClasses.Save(myList)


    'End Sub

    Private Sub frmAddresses_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        ' Load the classes  from the dataset

        For Each row In dtContactGroup.Rows
            BuildClass(row)
        Next
        TabControl1.SelectedIndex = 0
        GetData(BuildingOwner)
    End Sub






    Private Sub BuildClass(row As Object)

        Dim contact As New Contact
        Try

            With contact
                .contactType = row("contactType")
                .companyName = row("companyName")
                .contactName = row("contactName")
                .address = row("address")
                .address2 = row("address2")
                .city = row("city")
                .state = row("state")
                .zipcode = row("zipcode")
                .phone = row("phone")
                .ext = row("ext")
                .fax = row("fax")
                .email = row("email")
            End With

            Select Case row("contactType")
                Case "owner"
                    BuildingOwner = contact
                    BuildingOwner.contactType = "owner"
                Case "consultant"
                    Consultant = contact
                    Consultant.contactType = "consultant"
                Case "gc"
                    GC = contact
                    GC.contactType = "gc"
                Case "architect"
                    Architect = contact
                    Architect.contactType = "architect"
                Case "mgmtCo"
                    MgmtCo = contact
                    MgmtCo.contactType = "mgmtCo"
                Case "other"
                    OtherContact = contact
                    OtherContact.contactType = "otherContact"
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Building the Class")
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim thisClass As New Contact
        Dim thisContactType As String = String.Empty
        Select Case TabControl1.SelectedIndex
            Case 0
                thisClass = BuildingOwner
                thisContactType = "owner"
            Case 1
                thisClass = Consultant
                thisContactType = "consultant"
            Case 2
                thisClass = GC
                thisContactType = "gc"
            Case 3
                thisClass = Architect
                thisContactType = "architect"
            Case 4
                thisClass = MgmtCo
                thisContactType = "mgmtCo"
            Case 5
                thisClass = OtherContact
                thisContactType = "other"
        End Select
        PostData(thisContactType, thisClass)
    End Sub
End Class