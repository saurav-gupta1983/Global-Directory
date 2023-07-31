
Partial Class Forms_ShowConfirmation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LabelKPIN.Text = Session("Message")
            Session.Remove("Message")
        End If
    End Sub

    Protected Sub ButtonContinue_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ButtonContinue.Click
        Response.Redirect(Session("RedirectPage"), False)
        Session.Remove("RedirectPage")
    End Sub
End Class
