
Partial Class MailBox
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode
    Dim KPIN As String

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
            CommonObj.ShowMessageBox(ex.ToString(), "Critical")
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
            CommonObj.ShowMessageBox(ex.ToString(), "Critical")
        End Try
    End Sub

End Class
