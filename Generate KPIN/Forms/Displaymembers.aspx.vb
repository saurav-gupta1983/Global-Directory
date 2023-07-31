Imports System.Data

Partial Class Displaymembers
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode
    Dim KPIN As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim SearchDataSet As DataSet
            CommonObj.EstablishSQLConnection(Session("SearchList"), "Get")

            SearchDataSet = CommonObj.returnDataSet
            GridViewLink.Visible = False
            GridView2.Visible = False

            If Session("KPIN") Is Nothing Then
                HyperLinkLogIn.Visible = True
                GridView2.DataSource = SearchDataSet
                GridView2.DataBind()
                GridView2.Visible = True
            Else
                HyperLinkLogIn.Visible = False
                GetLoginDetails()

                GridViewLink.DataSource = SearchDataSet
                GridViewLink.DataBind()
                GridViewLink.Visible = True
            End If

            Session("PreviousPage") = "SearchDirectory.aspx"


        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Sub GetLoginDetails()
        Try
            Dim Query As String = ""

            KPIN = Session("KPIN")

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

    Protected Sub ButtonSendMessage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSendMessage.Click
        Session("PreviousPage") = "SearchDirectory.aspx"
        Response.Redirect("SendMail.aspx", False)
    End Sub

End Class
