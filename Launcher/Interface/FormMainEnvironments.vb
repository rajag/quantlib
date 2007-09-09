
'Copyright (C) 2006, 2007 Eric Ehlers

'This file is part of QuantLib, a free-software/open-source library
'for financial quantitative analysts and developers - http://quantlib.org/

'QuantLib is free software: you can redistribute it and/or modify it
'under the terms of the QuantLib license.  You should have received a
'copy of the license along with this program; if not, please email
'<quantlib-dev@lists.sf.net>. The license is also available online at
'<http://quantlib.org/license.shtml>.

'This program is distributed in the hope that it will be useful, but WITHOUT
'ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
'FOR A PARTICULAR PURPOSE.  See the license for more details.

Partial Public Class FormMain

    Private Function inputEnvironmentName(ByVal initialValue As String) As String

        inputEnvironmentName = initialValue
        Dim invalidEntry As Boolean = True
        While invalidEntry
            inputEnvironmentName = InputBox("Edit Environment Name:", _
                "Environment Name", inputEnvironmentName)
            If Len(inputEnvironmentName) < 1 Then Exit Function
            invalidEntry = envUserconfigured_.nameInUse(inputEnvironmentName)
            If invalidEntry Then
                MsgBox("The name '" & inputEnvironmentName & "' is already in use - " _
                & "please enter a different name.")
            End If
        End While

    End Function

    ' Initialization Data Source

    Private Sub setInitSource()
        If rbExcel.Checked Then
            SelectedEnvironment.StartupActions.InitSource = "Excel"
        ElseIf rbXML.Checked Then
            SelectedEnvironment.StartupActions.InitSource = "XML"
        Else
            Throw New Exception("Unable to determine value for Data Initialization Source")
        End If
    End Sub

End Class
