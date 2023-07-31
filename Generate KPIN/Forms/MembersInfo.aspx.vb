Imports CommonCode
Imports System.Data

Partial Class MembersInfo
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MemberDatarow As DataRow
        Dim Query As String
        Dim KPIN As String
        Try
            KPIN = Session("KPIN")

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"

            CommonObj.EstablishSQLConnection(Query, "Get")
            MemberDatarow = CommonObj.returnDataSet.Tables(0).Rows(0)

            'LabelDetails.Text = MemberDatarow.Item("FirstName") & " " & _
            '                    MemberDatarow.Item("MiddleName") & " " & _
            '                    MemberDatarow.Item("LastName") & " (" & _
            '                    KPIN & ")"

            TextBoxFirstName.Text = MemberDatarow.Item("FirstName")
            TextBoxMiddleName.Text = MemberDatarow.Item("MiddleName")
            TextBoxLastName.Text = MemberDatarow.Item("LastName")
            TextBoxDateofBirth.Text = CommonObj.GenerateDatefromAge(CType(MemberDatarow.Item("AgeDiff"), Integer))


            Query = "Select * from AdminAccess where KPIN = '" & KPIN & "' And isAdmin = 1"
            CommonObj.EstablishSQLConnection(Query, "Get")

            If CommonObj.returnDataSet.Tables(0).Rows.Count = 0 Then
                HyperLinkAdmin.Visible = False
                HyperLinkReports.Visible = False
            Else
                HyperLinkAdmin.Visible = True
                HyperLinkReports.Visible = True
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

End Class
