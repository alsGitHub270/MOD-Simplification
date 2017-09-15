Option Strict Off
Option Explicit On
Imports System
Module ExpensesPerDay_mod
	Public Structure SubcontractedLaborCost_TypeDec
		Dim Description As String
		Dim Cost As Single
		Public Shared Function CreateInstance() As SubcontractedLaborCost_TypeDec
			Dim result As New SubcontractedLaborCost_TypeDec()
			result.Description = String.Empty
			Return result
		End Function
	End Structure
	Public Structure SubcontractedLaborCostTotal_TypeDec
		<Microsoft.VisualBasic.VBFixedArray(4)> _
		Dim LaborCost() As SubcontractedLaborCost_TypeDec
		Dim TotalCost As Single
		Public Shared Function CreateInstance() As SubcontractedLaborCostTotal_TypeDec
			Dim result As New SubcontractedLaborCostTotal_TypeDec()
            ReDim result.LaborCost(5)
			Return result
		End Function
	End Structure
	Public SubcontractedLaborCost As SubcontractedLaborCostTotal_TypeDec = SubcontractedLaborCostTotal_TypeDec.CreateInstance()
End Module