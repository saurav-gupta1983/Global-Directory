Imports CommonCode

Partial Class GlobalDirectory
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode

    Protected Sub ButtonGo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ButtonGo.Click
        Try
            LabelInvalidUser.Visible = False
            If ValidateUser() Then
                Session("KPIN") = CommonObj.returnDataSet.Tables(0).Rows(0).Item("KPIN")
                Response.Redirect("MembersInfo.aspx", False)
            Else
                LabelInvalidUser.Visible = True
            End If
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function ValidateUser() As Boolean
        Try
            Dim Query As String

            'Dim MessageObj As New MessageBox
            'MessageObj.Show("TEST MESSAGE")
            'CommonObj.ShowAlertMessage("", Me.Page)

            Query = "Select * from MemberInfo where KPIN = '" & TextBoxUser.Text & "' and Password = '" & TextBoxPassword.Value & "'"

            CommonObj.EstablishSQLConnection(Query, "Get")

            If Not CommonObj.returnDataSet Is Nothing AndAlso CommonObj.returnDataSet.Tables(0).rows.count > 0 Then
                Return True
            End If

            Return False

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function
End Class
