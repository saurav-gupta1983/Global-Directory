
Partial Class Forms_ShowMessageBody
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LabelBody.Text = Request.QueryString("Body")
        'Response.Redirect("javascript:var intwidth;var intheight;intwidth=prompt('Enter the width for the browser.','');intheight=prompt('Enter the height for" & _
        '        "thebrowser.','');intwidth=parseInt(intwidth);intheight=parseInt(intheight);if(intwidth>0&&intheight>0)" & _
        '"{window.resizeTo(intwidth,intheight);}else{alert('Please specify a widthand height.');}")
        Response.Write("<script>window.resizeTo(600, 400);</script>")
    End Sub

    'Protected Sub ButtonClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
    '    Response.Write("<script>window.close();</script>")
    'End Sub
End Class
