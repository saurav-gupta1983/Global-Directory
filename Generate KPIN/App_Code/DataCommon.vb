Imports Microsoft.VisualBasiC
Imports System.Data.SqlClient
Imports System.Data
Imports System.Globalization
Imports System.Net
Imports System.Net.Mail
Imports System.Web.HttpContext

Public Class DetailsFlag
    Public personalDetails As Boolean
    Public familyDetails As Boolean
    Public contactDetails As Boolean
End Class

Public Class DataCommon

    Protected memberDataSet As DataSet
    Protected RowNumber As Integer

    Dim ConnectionString As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")

    Public referenceDate As DateTime = DateTime.Parse("1-1-1900")

    'Public SiteMailAddress As String = "GlobalDirectory.com"

    Public Sub EstablishSQLConnection(ByVal QueryString As String, Optional ByVal Operation As String = "")
        Try

            Dim SQLConnection As New SqlConnection
            Dim SQLCommand As New SqlCommand
            Dim SQLAdapter As New SqlDataAdapter

            SQLConnection.ConnectionString = ConnectionString

            SQLCommand.Connection = SQLConnection

            SQLCommand.CommandText = QueryString
            SQLCommand.CommandType = Data.CommandType.Text
            SQLCommand.CommandTimeout = 3600

            RowNumber = 0

            If Operation = "Get" Then
                memberDataSet = New DataSet
                SQLAdapter.SelectCommand = SQLCommand
                SQLAdapter.Fill(memberDataSet, "SourceDataSetinCommonCode")
                Exit Sub
            End If

            SQLConnection.Open()
            RowNumber = SQLCommand.ExecuteNonQuery()
            SQLConnection.Close()

        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Public Function CallStoredProcedure(ByVal StoredProcedure As String, Optional ByVal SqlParams() As SqlParameter = Nothing) As DataSet
        Try
            memberDataSet = New DataSet

            Dim SQLConnection As New SqlConnection
            Dim SQLCommand As New SqlCommand
            Dim SQLAdapter As New SqlDataAdapter

            SQLConnection.ConnectionString = ConnectionString

            SQLCommand.Connection = SQLConnection

            SQLCommand.CommandText = StoredProcedure
            SQLCommand.CommandType = Data.CommandType.StoredProcedure
            SQLCommand.CommandTimeout = 3600

            'For Each SqlParameter As SqlParameter In SqlParams
            '    SQLCommand.Parameters.Add(SqlParameter)
            'Next
            For count As Integer = 0 To SqlParams.Length - 1
                If Not SqlParams(count) Is Nothing Then
                    SQLCommand.Parameters.Add(SqlParams(count))
                End If
            Next

            SQLAdapter.SelectCommand = SQLCommand
            SQLAdapter.Fill(memberDataSet, "PasswordInfo")

        Catch ex As Exception
            Throw (ex)
        End Try
        Return memberDataSet

    End Function

End Class
