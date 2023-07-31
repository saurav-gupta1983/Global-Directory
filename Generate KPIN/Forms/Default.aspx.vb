
Partial Class Forms_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Redirect("GlobalDirectory.aspx", False)
    End Sub
End Class
