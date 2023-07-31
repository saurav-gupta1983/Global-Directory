Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class Forms_LinktoKPIN
    Inherits System.Web.UI.Page

    Dim LinkDataset As DataSet
    Dim CommonObj As New CommonCode
    Dim Details As List(Of String)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        Session("KPIN") = 3

        LinkDataset = GetData(Session("KPIN"))

        GridViewLink.DataSource = LinkDataset
        GridViewLink.DataBind()

        'Catch ex As Exception

        'End Try
    End Sub

    Private Function GetData(Optional ByVal KPIN As String = "") As DataSet
        'Try
        Dim SqlParameter As New SqlParameter
        Dim SqlParameters(1) As SqlParameter

        SqlParameter.ParameterName = "KPIN"
        SqlParameter.SqlValue = KPIN

        SqlParameters(0) = SqlParameter

        Return CommonObj.CallStoredProcedure("FamilyKPIN", SqlParameters)

        'Catch ex As Exception

        'End Try
        'Return Nothing
    End Function

    Protected Sub GridViewLink_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewLink.RowCommand
        Try
            If e.CommandName = "LinktoKPIN" Then

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
