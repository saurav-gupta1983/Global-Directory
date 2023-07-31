Imports System.Data

Partial Class SearchDirectory
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode
    Dim KPIN As String
    Dim Query As String

    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ButtonSearch.Click
        Try
            'If DropDownListFilterCriteria1.SelectedIndex = 0 Then
            '    LabelErrorMessage.Text = "Please specify the Filter criteria in correct order."
            'End If

            Dim DataSetList As DataSet
            DataSetList = GetListofUsers()

            If Not DataSetList Is Nothing AndAlso DataSetList.Tables.Count > 0 Then
                If DataSetList.Tables(0).Rows.Count > 0 Then
                    Session("SearchList") = Query
                    Response.Redirect("Displaymembers.aspx", False)
                Else
                    LabelErrorMessage.Text = "No Matches Found."
                End If
            End If

            'PanelSearchMember.Visible = False
            'PanelSendMessage.Visible = True
            'ButtonSearchMem.Visible = False
            'ButtonSendRequest.Visible = False

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function GetListofUsers() As DataSet
        Try
            Query = VAR_SEARCHQUERY + Replace(GetCriteria(), "''''", "'")
            LabelErrorMessage.Text = Query
            'Query = "Select Distinct PINId, FirstName, MiddleName, LastName, Country, DateofEmail from MemberInfo MI, MailList ML " & _
            '        "where ML.KPIN = MI.KPIN " & _
            '        " And FirstName = '" & TextBoxFirstName.Text & _
            '        "' OR LastName = '" & TextBoxLastName.Text & _
            '        "' OR Country = '" & TextBoxCountry.Text & "'"

            CommonObj.EstablishSQLConnection(Query, "Get")

            'Session("Filter") = GetCriteria()

            '        Session("PreviousPage") = "SearchDirectory.aspx"
            '        Response.Redirect("SendMail.aspx", False)


        Catch ex As Exception
            'CommonObj.ShowMessageBox(ex.Message, "Critical")
            LabelErrorMessage.Text = "Please specify the Filter criteria in correct order."
        End Try
        Return CommonObj.returnDataSet
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Session("KPIN") Is Nothing Then
                'Response.Redirect("GlobalDirectory.aspx", False)
                'LabelDetails.Visible = False
                'HyperLinkHome.Visible = False
                'HyperLinkLogOut.Visible = False
            Else
                KPIN = Session("KPIN")
                'LabelDetails.Visible = True
                'HyperLinkHome.Visible = True
                'HyperLinkLogOut.Visible = True
                GetLoginDetails()
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Sub GetLoginDetails()
        Try
            Dim Query As String = ""

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            'LabelDetails.Text = CommonObj.returnDataSet.Tables(0).Rows(0).Item("FirstName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("MiddleName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("LastName") & " (" & _
            'KPIN & ")"

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function GetCriteria() As String
        Dim filterString As String = ""

        If DropDownListFilterCriteria1.SelectedIndex > 0 Then
            filterString = DropDownListFilterCriteria1.SelectedValue.ToString() & " = ''''" & TextBoxFilterValue.Text & "'''' "
        End If
        If DropDownListFilterCriteria2.SelectedIndex > 0 Then
            filterString = filterString & DropDownList2.SelectedValue.ToString() & DropDownListFilterCriteria2.SelectedValue.ToString() & " = ''''" & TextBox1.Text & "'''' "
        End If
        If DropDownListFilterCriteria3.SelectedIndex > 0 Then
            filterString = filterString & DropDownList3.SelectedValue.ToString() & DropDownListFilterCriteria3.SelectedValue.ToString() & " = ''''" & TextBox2.Text & "'''' "
        End If

        Session("Filter") = filterString
        Return filterString

    End Function

    'Protected Sub ButtonSearchMem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearchMem.Click
    '    Try
    '        PanelSearchMember.Visible = True
    '        PanelSendMessage.Visible = False
    '    Catch ex As Exception
    '        CommonObj.ShowMessageBox(ex.Message, "Critical")
    '    End Try
    'End Sub

    'Protected Sub ButtonSendRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSendRequest.Click
    '    Try
    '        PanelSearchMember.Visible = False
    '        PanelSendMessage.Visible = True
    '    Catch ex As Exception
    '        CommonObj.ShowMessageBox(ex.Message, "Critical")
    '    End Try
    'End Sub

    'Protected Sub ButtonSendMessage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSendMessage.Click
    '    Try
    '        Dim filterString As String = ""

    '        If DropDownListFilterCriteria1.SelectedIndex > 0 Then
    '            filterString = DropDownListFilterCriteria1.SelectedValue.ToString() & " = ''''" & TextBoxFilterValue.Text & "'''' "
    '        End If
    '        If DropDownListFilterCriteria2.SelectedIndex > 0 Then
    '            filterString = filterString & DropDownList2.SelectedValue.ToString() & DropDownListFilterCriteria2.SelectedValue.ToString() & " = ''''" & TextBox1.Text & "'''' "
    '        End If
    '        If DropDownListFilterCriteria3.SelectedIndex > 0 Then
    '            filterString = filterString & DropDownList3.SelectedValue.ToString() & DropDownListFilterCriteria3.SelectedValue.ToString() & " = ''''" & TextBox2.Text & "'''' "
    '        End If

    '        Session("Filter") = filterString
    '        Session("PreviousPage") = "SearchDirectory.aspx"
    '        Response.Redirect("SendMail.aspx", False)
    '    Catch ex As Exception
    '        CommonObj.ShowMessageBox(ex.Message, "Critical")
    '    End Try
    'End Sub
End Class
