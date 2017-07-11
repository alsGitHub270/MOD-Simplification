Option Strict Off
Option Explicit On
Imports System
Module CM_ADDRS_IO

    Public Const ADDRESS_TYPE_OWNER As Integer = 0
    Public Const ADDRESS_TYPE_GC As Integer = 1
    Public Const ADDRESS_TYPE_ARCHITECT As Integer = 2
    Public Const ADDRESS_TYPE_MGMT_CO As Integer = 3
    Public Const ADDRESS_TYPE_CONSULTANT As Integer = 4

    Structure Address_TypeDec
        Dim AddressID As Integer ' Primary Key
        Dim Type As Byte
        Dim Name As String
        Dim Address As String
        Dim Address2 As String
        Dim City As String
        Dim State As String
        Dim Zip As String
        Dim Phone As String
        Dim Ext As String
        Dim Fax As String
        Public Shared Function CreateInstance() As Address_TypeDec
            Dim result As New Address_TypeDec()
            result.Name = String.Empty
            result.Address = String.Empty
            result.Address2 = String.Empty
            result.City = String.Empty
            result.State = String.Empty
            result.Zip = String.Empty
            result.Phone = String.Empty
            result.Ext = String.Empty
            result.Fax = String.Empty
            Return result
        End Function
    End Structure

    Structure Contacts_TypeDec
        Dim Name As String
        Dim Tel As String
        Dim Address As String
        Dim Address2 As String
        Dim City As String
        Dim State As String
        Dim Zip As String
        Dim MissingID As String
        Public Shared Function CreateInstance() As Contacts_TypeDec
            Dim result As New Contacts_TypeDec()
            result.Name = String.Empty
            result.Tel = String.Empty
            result.Address = String.Empty
            result.Address2 = String.Empty
            result.City = String.Empty
            result.State = String.Empty
            result.Zip = String.Empty
            result.MissingID = String.Empty
            Return result
        End Function
    End Structure

    Private AddressIndex As Byte

    Public Sub ReadData(Optional ByVal TypeIndex As Byte = ADDRESS_TYPE_OWNER, Optional ByVal CurrentName As String = "")

        InitializeStruct_Address(TypeIndex)
        For AddressIndex = 1 To Addresses.GetUpperBound(0)
            If Addresses(AddressIndex).Type = TypeIndex Then
                If CurrentName.Trim.Length = 0 Then
                    Address.Type = Addresses(AddressIndex).Type
                    Address.Name = Addresses(AddressIndex).Name
                    Address.Address = Addresses(AddressIndex).Address
                    Address.Address2 = Addresses(AddressIndex).Address2
                    Address.City = Addresses(AddressIndex).City
                    Address.State = Addresses(AddressIndex).State
                    Address.Zip = Addresses(AddressIndex).Zip
                    Address.Phone = Addresses(AddressIndex).Phone
                    Address.Ext = Addresses(AddressIndex).Ext
                    Address.Fax = Addresses(AddressIndex).Fax
                    Exit Sub
                ElseIf CurrentName.Trim.ToUpper = Addresses(AddressIndex).Name.ToUpper Then
                    Address.Type = Addresses(AddressIndex).Type
                    Address.Name = Addresses(AddressIndex).Name
                    Address.Address = Addresses(AddressIndex).Address
                    Address.Address2 = Addresses(AddressIndex).Address2
                    Address.City = Addresses(AddressIndex).City
                    Address.State = Addresses(AddressIndex).State
                    Address.Zip = Addresses(AddressIndex).Zip
                    Address.Phone = Addresses(AddressIndex).Phone
                    Address.Ext = Addresses(AddressIndex).Ext
                    Address.Fax = Addresses(AddressIndex).Fax
                    Exit Sub
                End If
            End If
        Next AddressIndex

    End Sub
    Public Sub SaveData_Address()
        Dim AddressAdded As Boolean = False
        Dim iAddresses As Integer = Addresses.GetUpperBound(0)

        For AddressIndex = 1 To iAddresses
            If Addresses(AddressIndex).Name = Address.Name And Addresses(AddressIndex).Type = Address.Type Then
                Addresses(AddressIndex).Name = Address.Name
                Addresses(AddressIndex).Address = Address.Address
                Addresses(AddressIndex).Address2 = Address.Address2
                Addresses(AddressIndex).City = Address.City
                Addresses(AddressIndex).State = Address.State
                Addresses(AddressIndex).Zip = Address.Zip
                Addresses(AddressIndex).Phone = Address.Phone
                Addresses(AddressIndex).Ext = Address.Ext
                Addresses(AddressIndex).Fax = Address.Fax
                AddressAdded = True
                Exit For
            End If
        Next AddressIndex
        If Not AddressAdded Then
            iAddresses += 1
            ReDim Preserve Addresses(iAddresses)
            Addresses(AddressIndex).Type = Address.Type
            Addresses(AddressIndex).Name = Address.Name
            Addresses(AddressIndex).Address = Address.Address
            Addresses(AddressIndex).Address2 = Address.Address2
            Addresses(AddressIndex).City = Address.City
            Addresses(AddressIndex).State = Address.State
            Addresses(AddressIndex).Zip = Address.Zip
            Addresses(AddressIndex).Phone = Address.Phone
            Addresses(AddressIndex).Ext = Address.Ext
            Addresses(AddressIndex).Fax = Address.Fax
        End If

    End Sub
    Public Sub InitializeStruct_Address(ByRef TypeIndex As Byte)

        Address.Type = TypeIndex
        Address.Name = ""
        Address.Address = ""
        Address.Address2 = ""
        Address.City = ""
        Address.State = ""
        Address.Zip = ""
        Address.Phone = ""
        Address.Ext = ""
        Address.Fax = ""

    End Sub
    Public Sub Set_CurrentAddress()
        Dim i As Integer = 0
        Dim FoundOwner As Boolean = False

        If Owner_Info.Name = "" Then
            FoundOwner = False
            For i = 1 To Addresses.GetUpperBound(0)
                If Addresses(i).Type = ADDRESS_TYPE_OWNER Then
                    Owner_Info.Name = Addresses(i).Name
                    Owner_Info.Address = Addresses(i).Address
                    Owner_Info.City = Addresses(i).City
                    Owner_Info.State = Addresses(i).State
                    Owner_Info.Zip = Addresses(i).Zip
                    Owner_Info.Phone = Addresses(i).Phone
                    Owner_Info.Fax = Addresses(i).Fax
                    FoundOwner = True
                    Exit For
                End If
            Next i
            If Not FoundOwner Then
                If String.IsNullOrEmpty(Owner_Info.Name) Then
                    Owner_Info.Name = JobContact.Name
                    Owner_Info.Address = JobContact.Address
                    Owner_Info.Address2 = JobContact.Address2
                    Owner_Info.City = JobContact.City
                    Owner_Info.State = JobContact.State
                    Owner_Info.Zip = JobContact.Zip
                    Owner_Info.Phone = JobContact.Tel
                End If
                i = Addresses.GetUpperBound(0) + 1
                ReDim Preserve Addresses(i)
                Addresses(i).Type = ADDRESS_TYPE_OWNER
                Addresses(i).Name = Owner_Info.Name
                Addresses(i).Address = Owner_Info.Address
                Addresses(i).City = Owner_Info.City
                Addresses(i).State = Owner_Info.State
                Addresses(i).Zip = Owner_Info.Zip
                Addresses(i).Phone = Owner_Info.Phone
                Addresses(i).Fax = Owner_Info.Fax
            End If
        End If
        If Contracts.Consultant = CheckState.Checked Then
            If String.IsNullOrEmpty(Address.Name.Trim) Or Address.Type <> ADDRESS_TYPE_CONSULTANT Then
                ReadData(ADDRESS_TYPE_CONSULTANT)
            End If
        Else
            AddAddress4Owner()
            ReadData(ADDRESS_TYPE_OWNER)
        End If

    End Sub
    Public Sub AddAddress4Owner()
        Dim iAddresses As Integer = Addresses.GetUpperBound(0)

        For AddressIndex = 1 To iAddresses
            If Addresses(AddressIndex).Type = ADDRESS_TYPE_OWNER Then
                Exit Sub
            End If
        Next
        iAddresses += 1
        ReDim Preserve Addresses(iAddresses)
        Addresses(AddressIndex).Type = ADDRESS_TYPE_OWNER
        Addresses(AddressIndex).Name = Owner_Info.Name
        Addresses(AddressIndex).Address = Owner_Info.Address
        Addresses(AddressIndex).Address2 = ""
        Addresses(AddressIndex).City = Owner_Info.City
        Addresses(AddressIndex).State = Owner_Info.State
        Addresses(AddressIndex).Zip = Owner_Info.Zip
        Addresses(AddressIndex).Phone = Owner_Info.Phone
        Addresses(AddressIndex).Ext = ""
        Addresses(AddressIndex).Fax = Owner_Info.Fax

    End Sub
End Module