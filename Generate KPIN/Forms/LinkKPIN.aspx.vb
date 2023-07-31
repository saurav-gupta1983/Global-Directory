Imports System.Data
Imports System.Data.SqlClient

Partial Class Forms_LinkKPIN
    Inherits System.Web.UI.Page

    Dim KPIN As String
    Dim RelationPinId As Integer
    Dim RelationDataset As DataRow
    Dim CommonObj As New CommonCode

    Protected Sub ButtonClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Response.Write("<script language='javascript'> { window.close();}</script>")
    End Sub

    Protected Sub ButtonLinkKPIN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonLinkKPIN.Click
        'Dim Query As String
        'Query = "Select * from MemberInfo where Name = '" & TextBoxName.Text & "' And DOB = '" & 

        'CommonObj.EstablishSQLConnection(Query, "Get")
        ''MemberDatarow = CommonObj.returnDataSet.Tables(0).Rows(0)

        ''Return CommonObj.CallStoredProcedure("FamilyKPIN", SqlParameters)
        LabelError.Visible = False
        LabelKPINValue.Text = ""

        Dim KPINDataset As New DataSet
        KPINDataset = GetData()

        'Response.Write(KPINDataset.Tables(0).Rows(0).Item(0))

        If KPINDataset.Tables(0).Rows.Count > 0 AndAlso KPINDataset.Tables(0).Rows(0).Item(0) <> "" Then
            LabelKPINValue.Text = KPINDataset.Tables(0).Rows(0).Item(0).ToString()
        Else
            LabelError.Visible = True
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            TextBoxName.Text = Request.QueryString("Name")
            LabelRelationValue.Text = Request.QueryString("Relation")

            If Request.QueryString("DOB") <> "" Then
                WebUserControlDOB.AssignDate = DateTime.Parse(Request.QueryString("DOB"))
            Else
                WebUserControlDOB.AssignDate = DateTime.Parse("01-01-1900")
            End If
        End If

        LabelError.Visible = False
        LabelKPINValue.Text = ""

    End Sub

    Private Function GetData(Optional ByVal KPIN As String = "") As DataSet
        Dim SqlParameters(4) As SqlParameter

        Dim SqlParameter1 As New SqlParameter
        SqlParameter1.ParameterName = "@KPIN"
        SqlParameter1.SqlValue = Session("KPIN")
        SqlParameters(0) = SqlParameter1

        Dim SqlParameter2 As New SqlParameter
        SqlParameter2.ParameterName = "@Age"
        SqlParameter2.SqlValue = CommonObj.CalculateAge(WebUserControlDOB.BirthDay, WebUserControlDOB.BirthMonth, WebUserControlDOB.BirthYear)
        SqlParameters(1) = SqlParameter2

        Dim SqlParameter3 As New SqlParameter
        SqlParameter3.ParameterName = "@Name"
        SqlParameter3.SqlValue = TextBoxName.Text
        SqlParameters(2) = SqlParameter3

        Dim SqlParameter4 As New SqlParameter
        SqlParameter4.ParameterName = "@Relation"
        SqlParameter4.SqlValue = LabelRelationValue.Text
        SqlParameters(3) = SqlParameter4

        'Response.Write(SqlParameter1.SqlValue.ToString() & SqlParameter2.SqlValue.ToString() & SqlParameter3.SqlValue.ToString() & SqlParameter2.SqlValue.ToString())

        Return CommonObj.CallStoredProcedure("LinkKPIN", SqlParameters)

    End Function

End Class
