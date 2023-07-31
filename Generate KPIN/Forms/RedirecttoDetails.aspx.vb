
Partial Class Forms_RedirecttoDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString(VAR_DETAILS) = TITLE_ContactDetails Then
            Response.Redirect("ContactDetails.aspx", False)

        ElseIf Request.QueryString(VAR_DETAILS) = TITLE_FamilyDetails Then
            Response.Redirect("FamilyDetails.aspx", False)

        ElseIf Request.QueryString(VAR_DETAILS) = TITLE_SiblingDetails Then
            Response.Redirect("SiblingDetails.aspx", False)

        ElseIf Request.QueryString(VAR_DETAILS) = TITLE_OffspringDetails Then
            Response.Redirect("OffspringDetails.aspx", False)

        ElseIf Request.QueryString(VAR_DETAILS) = TITLE_DeathDetails Then
            Response.Redirect("DeathDetails.aspx", False)

        ElseIf Request.QueryString(VAR_DETAILS) = TITLE_BirthDetails Then
            Response.Redirect("BirthDetails.aspx", False)

        ElseIf Request.QueryString(VAR_DETAILS) = TITLE_OtherDetails Then
            Response.Redirect("OtherDetails.aspx", False)

        ElseIf Request.QueryString(VAR_DETAILS) = TITLE_Pending Then
            Response.Redirect("Admin.aspx", False)
            Session(VAR_REQUESTSTATE) = TITLE_Pending

        ElseIf Request.QueryString(VAR_DETAILS) = TITLE_All Then
            Response.Redirect("Admin.aspx", False)
            Session(VAR_REQUESTSTATE) = TITLE_All

        ElseIf Request.QueryString(VAR_DETAILS) = TITLE_Admin Then
            Response.Redirect("Admin.aspx", False)
            Session(VAR_REQUESTSTATE) = TITLE_Admin
        End If
    End Sub
End Class
