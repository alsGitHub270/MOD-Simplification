Module General

    Public Sub SelectInputArea(ByRef ThisControl As Object, ByRef ThisStartSel As Byte, ByRef ThisStartLen As Byte)

        ThisControl.SelectionStart = ThisStartSel
        If TypeOf ThisControl Is MaskedTextBox Then
            CType(ThisControl, MaskedTextBox).SelectionLength = Strings.Len(CType(ThisControl, MaskedTextBox).Text)
        Else
            ThisControl.SelectionLength = ThisStartLen
        End If

    End Sub

    Public Sub WhichKeyPressed(ByRef ThisKeyCode As Integer, Optional ByRef AllowHelpScreen As Boolean = False)

        Select Case ThisKeyCode
            'Case Keys.F1
            '    If AllowHelpScreen Then
            '        HelpScreen_frm.ShowDialog()
            '    End If
            'Case Keys.F3
            '    ExitLogic(True)
            'Case Keys.PageDown
            '    Main_MDI_frm.NextForm()
            'Case Keys.PageUp
            '    Main_MDI_frm.PreviousForm()
            Case Keys.Up
                SendKeys.Send("+{TAB}")
            Case Keys.Return
                SendKeys.Send("{TAB}")
            Case Keys.Down
                SendKeys.Send("{ENTER}")
            Case Else
        End Select

    End Sub
End Module
