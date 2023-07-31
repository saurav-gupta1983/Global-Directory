
Partial Class InBox
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode
    Dim KPIN As String
    Dim Query As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            KPIN = Session("KPIN")

            Query = "Select MailId, PINId, IsNUll(FirstName,'') + ' ' + IsNUll(MiddleName,'') + ' ' + IsNUll(LastName,'') Name, City, Country, CONVERT(varchar, DateofEmail, 106) DateofEmail, Subject from MemberInfo MI, MailList ML where ML.EmailToKPIN = '" & _
            KPIN & "' and ML.KPIN = MI.KPIN Order By MailId"

            SqlDataSourceInBox.ConnectionString = ConnectionString
            SqlDataSourceInBox.SelectCommand = Query

            GetLoginDetails()
            Session("PreviousPage") = "InBox.aspx"
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

    Protected Sub GridViewInBox_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewInBox.RowCommand
        Try
            'Dim dataRow As GridViewRow
            'Dim gridView As System.Web.UI.WebControls.GridView = e.CommandSource
            'dataRow = gridView.Rows(e.CommandArgument)

            Dim DataSet As New Data.DataSet
            CommonObj.EstablishSQLConnection(Query, "Get")

            DataSet = CommonObj.returnDataSet()

            If e.CommandName = "DeleteMail" Then
                Query = "Delete From MailList " & _
                        "Where MailId = " & DataSet.Tables(0).Rows(e.CommandArgument).Item(2)

                CommonObj.EstablishSQLConnection(Query)
            End If

            Response.Redirect(Session("PreviousPage"), False)
        Catch ex As Exception
            'LabelPending.Text = ex.Message.ToString() & " " & Query
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

End Class
