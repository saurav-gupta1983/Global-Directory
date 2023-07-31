
Partial Class Forms_error
    Inherits System.Web.UI.Page

    Protected Sub btnError_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnError.Click
        If btnError.Text = "Hide Error" Then
            ltError.Visible = False
            btnError.Text = "Display Error"
        Else
            ltError.Visible = True
            btnError.Text = "Hide Error"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ltError.Text = Session("ErrorMessage")
            btnError.Visible = False
            ltError.Visible = False
            Session.Remove("ErrorMessage")
        End If
    End Sub
End Class
