
Partial Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Buttonhome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonhome.Click
        Session.RemoveAll()
        Response.Redirect("GlobalDirectory.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.RemoveAll()
    End Sub
End Class
