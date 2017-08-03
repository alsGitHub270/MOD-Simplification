Imports System.IO
Imports Newtonsoft.Json

Public Class Contact

    Public Property contactType As String
    Public Property companyName As String
    Public Property contactName As String
    Public Property address As String
    Public Property address2 As String
    Public Property city As String
    Public Property state As String
    Public Property zipcode As String
    Public Property phone As String
    Public Property ext As String
    Public Property fax As String
    Public Property email As String

    Public Sub New()

    End Sub

   


    'Public Sub Save(myList As List(Of Contact))
    '    Serialize(myList)
    'End Sub

    'Private Sub Serialize(myList As List(Of Contact))
    '    Dim json As String = ""


    '    Try
    '        json = JsonConvert.SerializeObject(myList, Formatting.Indented)

    '        Using sw As StreamWriter = New StreamWriter("C:\Temp\file.json")
    '            sw.Write(json)
    '        End Using

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error Writing Building Owner to json file")
    '    End Try

    'End Sub
End Class
