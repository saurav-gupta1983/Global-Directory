
Partial Class Forms_WebUserControlCalendar
    Inherits System.Web.UI.UserControl

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Calendar.Visible = False
    'End Sub

    Protected Sub Calendar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        TextBox1.Text = Calendar1.SelectedDate.ToShortDateString()
        Dim div As System.Web.UI.Control = Page.FindControl("divCalendar")

        If TypeOf div Is HtmlGenericControl Then
            CType(div, HtmlGenericControl).Style.Add("display", "none")
        End If

    End Sub

    Public ReadOnly Property GetDate() As String
        Get
            Return TextBox1.Text
        End Get
    End Property
    'Protected Sub ButtonSelectCal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSelectCal.Click
    '    Calendar.Visible = True
    '    ButtonSelectCal.Visible = False
    '    TextBoxDate.Visible = False
    'End Sub
End Class
