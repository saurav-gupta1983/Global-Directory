
Partial Class LoginCreated
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("Msg") = "True" Then
            LabelDataSaved.Text = "Member is created succesfully."
        End If
        If Request.QueryString("Msg") = "False" Then
            LabelDataSaved.Visible = "Error while creating a new Member. Please re-enter information"
        End If
        If Request.QueryString("Msg") = "EditTrue" Then
            LabelDataSaved.Text = "Member Information is updated succesfully."
        End If
        If Request.QueryString("Msg") = "EditFalse" Then
            LabelDataSaved.Visible = "Error while updating Member Information. Please re-enter information."
        End If
    End Sub

End Class
