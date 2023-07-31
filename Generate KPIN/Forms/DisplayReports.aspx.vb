Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Forms_DisplayReports
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureReport()
    End Sub

    Private Sub ConfigureReport()
        Try

            If Not Page.IsPostBack Then
                Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
                myConnectionInfo.DatabaseName = "GlobalDirectory"
                myConnectionInfo.ServerName = "SAURAV-PC\SQLSERVER2000"
                myConnectionInfo.UserID = "sa"
                myConnectionInfo.Password = ""

                Dim ReportPath As String = Server.MapPath("Report.rpt")

                CommonObj.ShowMessageBox(ReportPath, "")

                CrystalReportViewer1.ReportSource = ReportPath

                'Dim field1 As ParameterField = Me.CrystalReportViewer1.ParameterFieldInfo(0)
                'Dim val1 As New ParameterDiscreteValue()
                'val1.Value = "1"
                'field1.CurrentValues.Add(val1)

                'Dim field2 As ParameterField = Me.CrystalReportViewer1.ParameterFieldInfo(1)
                'Dim val2 As New ParameterDiscreteValue()
                'val1.Value = "A"
                'field1.CurrentValues.Add(val2)
                Dim paramFields As ParameterFields = New ParameterFields()

                Dim paramField As ParameterField = New ParameterField()
                paramField.ParameterFieldName = "@ReportCategory"
                'paramField.ParameterFieldName = "@Parameter1"
                Dim discreteVal1 As ParameterDiscreteValue = New ParameterDiscreteValue()
                discreteVal1.Value = "1"
                paramField.CurrentValues.Add(discreteVal1)
                paramFields.Add(paramField)

                Dim paramField2 As ParameterField = New ParameterField()
                paramField2.ParameterFieldName = "@ReportOption"
                Dim discreteVal2 As ParameterDiscreteValue = New ParameterDiscreteValue()
                discreteVal2.Value = "1"
                paramField2.CurrentValues.Add(discreteVal2)
                paramFields.Add(paramField2)

                CrystalReportViewer1.ParameterFieldInfo = paramFields

                SetDBLogonForReport(myConnectionInfo)

            End If
        Catch ex As Exception
            Throw (ex)
        End Try

    End Sub

    Private Sub SetDBLogonForReport(ByVal myConnectionInfo As ConnectionInfo)
        Try
            Dim myTableLogOnInfos As TableLogOnInfos = CrystalReportViewer1.LogOnInfo()
            For Each myTableLogOnInfo As TableLogOnInfo In myTableLogOnInfos
                myTableLogOnInfo.ConnectionInfo = myConnectionInfo
            Next
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

End Class
