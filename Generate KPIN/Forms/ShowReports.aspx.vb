Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Forms_ShowReports
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode
    Dim ReportOptions As String
    Dim ReportCategory As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ReportCategory = Request.QueryString("ReportCategory")
        ReportOptions = Request.QueryString("ReportOptions")
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

                Dim ReportPath As String = ""

                If ReportCategory = "P" Then
                    ReportPath = Server.MapPath("Report.rpt")
                End If
                If ReportCategory = "A" Then
                    ReportPath = Server.MapPath("Report_Average.rpt")
                End If
                If ReportCategory = "E" Then
                    ReportPath = Server.MapPath("Report_Education.rpt")
                End If

                'CommonObj.ShowMessageBox(ReportOptions & ReportCategory, "")

                CrystalReportViewer1.ReportSource = ReportPath

                Dim paramFields As ParameterFields = New ParameterFields()

                Dim paramField As ParameterField = New ParameterField()
                paramField.ParameterFieldName = "@ReportCategory"
                Dim discreteVal1 As ParameterDiscreteValue = New ParameterDiscreteValue()
                discreteVal1.Value = ReportCategory
                paramField.CurrentValues.Add(discreteVal1)
                paramFields.Add(paramField)

                Dim paramField2 As ParameterField = New ParameterField()
                paramField2.ParameterFieldName = "@ReportOption"
                Dim discreteVal2 As ParameterDiscreteValue = New ParameterDiscreteValue()
                discreteVal2.Value = ReportOptions
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
