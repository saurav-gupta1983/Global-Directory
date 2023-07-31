Imports CommonCode
Imports System.Data

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Dim CommonObj As New CommonCode

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MemberDatarow As DataRow
        Dim Query As String
        Dim KPIN As String
        Try
            KPIN = Session("KPIN")
            If KPIN = "" Then
                LabelHi.Visible = False
                PanelOptions.Visible = False
                HyperLinkLogout.Visible = False
            Else

                Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"

                CommonObj.EstablishSQLConnection(Query, "Get")
                MemberDatarow = CommonObj.returnDataSet.Tables(0).Rows(0)

                LabelHi.Text = "Hi " + MemberDatarow.Item("FirstName") & " " & _
                                    MemberDatarow.Item("MiddleName") & " " & _
                                    MemberDatarow.Item("LastName") & " (" & _
                                    KPIN & ")"
            End If
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try

    End Sub
End Class

