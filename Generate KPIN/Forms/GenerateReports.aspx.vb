Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Configuration
Imports System.Web

Partial Class Forms_GenerateReports
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode
    Dim OrgDataSet As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                RadioButtonPopulation.Checked = True
                EnableDisableCheckboxes()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EnableDisableCheckboxes()
        CheckBoxAge.Enabled = RadioButtonPopulation.Checked
        CheckBoxCommunity.Enabled = RadioButtonPopulation.Checked
        CheckBoxMFRatio.Enabled = RadioButtonPopulation.Checked
        CheckBoxAge.Checked = False
        CheckBoxCommunity.Checked = False
        CheckBoxMFRatio.Checked = False

        CheckBoxAvgAge.Enabled = RadioButtonAverage.Checked
        CheckBoxAvgSalary.Enabled = RadioButtonAverage.Checked
        CheckBoxAvgAge.Checked = False
        CheckBoxAvgSalary.Checked = False

        CheckBoxEmployed.Enabled = RadioButtonEducation.Checked
        CheckBoxDegrees.Enabled = RadioButtonEducation.Checked
        CheckBoxEmployed.Checked = False
        CheckBoxDegrees.Checked = False

    End Sub

    Protected Sub RadioButtonPopulation_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonPopulation.CheckedChanged
        EnableDisableCheckboxes()
    End Sub

    Protected Sub RadioButtonAverage_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonAverage.CheckedChanged
        EnableDisableCheckboxes()
    End Sub

    Protected Sub RadioButtonEducation_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonEducation.CheckedChanged
        EnableDisableCheckboxes()
    End Sub

    Protected Sub ButtonReports_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonReports.Click
        Dim ReportCategory As String = ""
        Dim ReportOptions As String = ""
        Try
            'Response.Write(Server.MapPath("Report.rpt"))
            If RadioButtonPopulation.Checked Then
                ReportCategory = "P"
                ReportOptions = PopulationSelectedOptions()
            ElseIf RadioButtonAverage.Checked Then
                ReportCategory = "A"
                ReportOptions = AverageSelectedOptions()
            ElseIf RadioButtonEducation.Checked Then
                ReportCategory = "E"
                ReportOptions = EducationSelectedOptions()
            End If

            'GenerateReport(ReportCategory, ReportOptions)

            'Response.Redirect("showReports.aspx", False)

            If ReportCategory = "A" And ReportOptions = "" Then
                Exit Sub
            End If

            Dim URL As String = "showReports.aspx?ReportCategory=" + ReportCategory + "&ReportOptions=" + ReportOptions
            Response.Write("<script>window.open(""" + URL + """);</script>")

            'ConfigureReport()

        Catch ex As Exception

        End Try
    End Sub

    Private Function PopulationSelectedOptions() As String
        Dim Options As String = ""

        If CheckBoxAge.Checked Then
            Options += "A"
        End If

        If CheckBoxMFRatio.Checked Then
            Options += "R"
        End If

        Return Options

    End Function

    Private Function AverageSelectedOptions() As String
        Dim Options As String = ""

        If CheckBoxAvgSalary.Checked Then
            Options = "S"
        End If
        If CheckBoxAvgAge.Checked Then
            Options = "A"
        End If

        Return Options

    End Function

    Private Function EducationSelectedOptions() As String
        Dim Options As String = ""

        If CheckBoxEmployed.Checked Then
            Options += "1"
        End If
        If CheckBoxDegrees.Checked Then
            Options += "2"
        End If

        Return Options

    End Function


    'Private Function GetData(ByVal ReportCategory As String, ByVal ReportOptions As String)
    '    Dim SqlParameter As New SqlParameter
    '    Dim SqlParameters(2) As SqlParameter

    '    SqlParameter.ParameterName = "ReportCategory"
    '    SqlParameter.SqlValue = ReportCategory
    '    SqlParameters(0) = SqlParameter

    '    SqlParameter.ParameterName = "ReportOptions"
    '    SqlParameter.SqlValue = ReportOptions
    '    SqlParameters(1) = SqlParameter

    '    Return CommonObj.CallStoredProcedure("Reports", SqlParameters)

    'End Function

    'Private Sub GenerateReport(ByVal ReportCategory As String, ByVal ReportOptions As String)
    '    Dim ReportDataSet As New DataSet

    '    Try

    '        'ReportDataSet = GetData(ReportCategory, ReportOptions)
    '        '    Response.Write(ReportDataSet.Tables(0).Rows.Count.ToString())
    '    'Response.Write(ReportOptions)
    '    ''Response.Write(Server.MapPath("Report.rpt"))
    '    'Response.End()

    '    'Dim myConn As SqlConnection = New SqlConnection(ConnectionString)
    '    'Dim MyCommand As New SqlCommand()
    '    'MyCommand.Connection = myConn
    '    'MyCommand.CommandText = "Reports"
    '    'MyCommand.CommandType = Data.CommandType.Text
    '    'Dim myDa As New OleDbDataAdapter
    '    'myDa.SelectCommand = MyCommand
    '    'Dim myDS As New DataSet1()
    '    'myDa.Fill(myDS, "DAILYBALANCES")

    '        'Dim Rpt As New ReportDocument
    '        '    Rpt.Load(Server.MapPath("Report.rpt"))

    '        'Dim myparams As New ParameterFields
    '        'Dim myparam As New ParameterField

    '        'Dim mydiscvalue As New ParameterDiscreteValue
    '        'mydiscvalue.Value = ReportCategory
    '        'myparam.CurrentValues.Add(mydiscvalue)
    '        'myparams.Add(myparam)

    '        'Dim mydiscvalue2 As New ParameterDiscreteValue
    '        'mydiscvalue2.Value = ReportOptions

    '        'myparams.Add(myparam)

    '        '    CrystalReportViewerReports.ParameterFieldInfo = myparams


    '        '    Rpt.SetDataSource(ReportDataSet.Tables(0))
    '        'Rpt.PrintOptions.PaperOrientation = PaperOrientation.Portrait
    '        'Rpt.PrintOptions.PaperSize = PaperSize.PaperA4

    '        'Me.CrystalReportViewerReports.ReportSource = Rpt

    '        Dim ReportPath As String = Server.MapPath("Report.rpt")

    '        CrystalReportViewerReports.ReportSource = ReportPath

    '        Dim field1 As ParameterField = Me.CrystalReportViewerReports.ParameterFieldInfo(0)
    '        Dim field2 As ParameterField = Me.CrystalReportViewerReports.ParameterFieldInfo(1)
    '        Dim val1 As New ParameterDiscreteValue()
    '        Dim val2 As New ParameterDiscreteValue()
    '        val1.Value = "P"
    '        val1.Value = "A"
    '        field1.CurrentValues.Add(val1)
    '        field2.CurrentValues.Add(val2)

    '        'SetDBLogonForReport()

    '    Catch ex As Exception
    '        Throw (ex)
    '    End Try
    'End Sub

    ''Private Sub SetDBLogonForReport()
    ''    Dim myTableLogOnInfos As TableLogOnInfos = CrystalReportViewerReports.LogOnInfo()

    ''    Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
    ''    myConnectionInfo.DatabaseName = "GlobalDirectory"
    ''    myConnectionInfo.ServerName = "SAURAV-PC\SQLSERVER2000"
    ''    myConnectionInfo.UserID = "sa"
    ''    myConnectionInfo.Password = ""

    ''    For Each myTableLogOnInfo As TableLogOnInfo In myTableLogOnInfos
    ''        myTableLogOnInfo.ConnectionInfo = myConnectionInfo
    ''    Next
    ''End Sub
    'Private Sub SetDBLogonForReport(ByVal myConnectionInfo As ConnectionInfo)
    '    Try
    '        Dim myTableLogOnInfos As TableLogOnInfos = CrystalReportViewerReports.LogOnInfo()
    '        For Each myTableLogOnInfo As TableLogOnInfo In myTableLogOnInfos
    '            myTableLogOnInfo.ConnectionInfo = myConnectionInfo
    '        Next
    '    Catch ex As Exception
    '        Throw (ex)
    '    End Try
    'End Sub

    'Private Sub ConfigureReport()
    '    Try
    '        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
    '        myConnectionInfo.DatabaseName = "GlobalDirectory"
    '        myConnectionInfo.ServerName = "SAURAV-PC\SQLSERVER2000"
    '        myConnectionInfo.UserID = "sa"
    '        myConnectionInfo.Password = ""

    '        Dim ReportPath As String = Server.MapPath("Report.rpt")

    '        CommonObj.ShowMessageBox(ReportPath, "")

    '        CrystalReportViewerReports.ReportSource = ReportPath

    '        'Dim field1 As ParameterField = Me.CrystalReportViewer1.ParameterFieldInfo(0)
    '        'Dim val1 As New ParameterDiscreteValue()
    '        'val1.Value = "1"
    '        'field1.CurrentValues.Add(val1)

    '        'Dim field2 As ParameterField = Me.CrystalReportViewer1.ParameterFieldInfo(1)
    '        'Dim val2 As New ParameterDiscreteValue()
    '        'val1.Value = "A"
    '        'field1.CurrentValues.Add(val2)
    '        Dim paramFields As ParameterFields = New ParameterFields()

    '        Dim paramField As ParameterField = New ParameterField()
    '        paramField.ParameterFieldName = "@ReportCategory"
    '        'paramField.ParameterFieldName = "@Parameter1"
    '        Dim discreteVal1 As ParameterDiscreteValue = New ParameterDiscreteValue()
    '        discreteVal1.Value = "1"
    '        paramField.CurrentValues.Add(discreteVal1)
    '        paramFields.Add(paramField)

    '        Dim paramField2 As ParameterField = New ParameterField()
    '        paramField2.ParameterFieldName = "@ReportOption"
    '        Dim discreteVal2 As ParameterDiscreteValue = New ParameterDiscreteValue()
    '        discreteVal2.Value = "1"
    '        paramField2.CurrentValues.Add(discreteVal2)
    '        paramFields.Add(paramField2)

    '        CrystalReportViewerReports.ParameterFieldInfo = paramFields

    '        SetDBLogonForReport(myConnectionInfo)

    '    Catch ex As Exception
    '        Throw (ex)
    '    End Try

    'End Sub

End Class
