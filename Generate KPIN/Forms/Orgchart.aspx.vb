
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class Orgchart
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode
    Dim OrgDataset As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim KPIN As String

            KPIN = Request.QueryString("KPIN")

            If (KPIN = "") Then
                GetData(Session("KPIN"))
            Else
                GetData(KPIN)
            End If

            FillControlData()

        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub GetData(Optional ByVal KPIN As String = "")
        Try
            Dim SqlParameter As New SqlParameter
            Dim SqlParameters(1) As SqlParameter

            SqlParameter.ParameterName = "@KPIN"
            SqlParameter.SqlValue = KPIN

            SqlParameters(0) = SqlParameter

            OrgDataset = CommonObj.CallStoredProcedure("Orgchart", SqlParameters)

        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub FillControlData()
        Try
            Dim datatable As DataTable
            datatable = OrgDataset.Tables(0)

            WebUserControlSiblingList.Member = datatable
            WebUserControlSiblingList.Bind()
        Catch ex As Exception
            Throw (ex)

        End Try
    End Sub

End Class
