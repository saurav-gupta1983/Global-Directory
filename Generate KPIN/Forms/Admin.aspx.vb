Imports System.Data

Partial Class Forms_Admin
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SqlDataSourcePending.ConnectionString = ConnectionString
            SqlDataSourceAllRequest.ConnectionString = ConnectionString

            PanelBack.Visible = True
            PanelMenu.Visible = False

            If Session(VAR_REQUESTSTATE) = TITLE_Pending Then
                PanelAdminAccess.Visible = False
                PanelAllRequest.Visible = False
                PanelPendingRequest.Visible = True
            ElseIf Session(VAR_REQUESTSTATE) = TITLE_All Then
                PanelAdminAccess.Visible = False
                PanelAllRequest.Visible = True
                PanelPendingRequest.Visible = False
            ElseIf Session(VAR_REQUESTSTATE) = TITLE_Admin Then
                PanelAdminAccess.Visible = True
                PanelAllRequest.Visible = False
                PanelPendingRequest.Visible = False
                Label1.Visible = False
                TextBoxKPIN.Text = ""
            Else
                PanelAdminAccess.Visible = False
                PanelAllRequest.Visible = False
                PanelPendingRequest.Visible = False
                PanelMenu.Visible = True
                PanelBack.Visible = False
            End If

            Session.Remove(VAR_REQUESTSTATE)
        End If
    End Sub

    Protected Sub GridViewPending_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewPending.RowCommand
        Dim Query As String = ""
        Try
            'Dim dataRow As GridViewRow
            'Dim gridView As System.Web.UI.WebControls.GridView = e.CommandSource
            'dataRow = gridView.Rows(e.CommandArgument)

            Dim dataRow As Data.DataRow
            Query = "SELECT [RequestId] As [Request ID], [RequestedByKPIN] As [Requested KPIN], [FirstName] + ' ' + LastName As [Requestor Name], CONVERT(varchar, request.RequestedDate, 106) As [Requested Date], [Subject], [Body] FROM [RequestforPublicMessage] request, [MemberInfo] Info WHERE ([isPending] = 1) and request.RequestedByKPIN = Info.KPIN"

            CommonObj.EstablishSQLConnection(Query, "Get")
            dataRow = CommonObj.returnDataSet.Tables(0).Rows(e.CommandArgument)

            If e.CommandName = "ApproveRequest" Then
                Query = "Update RequestforPublicMessage " & _
                        "Set isPending = 0, " & _
                        "isApproved = 1," & _
                        "ApprovedByKPIN = " & Session("KPIN") & ", " & _
                        "ApprovedDate = " & "GetDate() " & _
                        "Where RequestId = " & dataRow.Item("RequestId").ToString()

                CommonObj.EstablishSQLConnection(Query)

                CommonObj.SendMailToGroup(dataRow.Item("RequestedByKPIN"), Session("Filter"), dataRow.Item("Subject"), dataRow.Item("Body"))

                'Query = "Select RequestedByKPIN, Subject, Body, Filter From RequestforPublicMessage " & _
                '        "Where RequestId = " & dataRow.Cells(2).Text.ToString()

                'CommonObj.EstablishSQLConnection(Query, "Get")

                'If CommonObj.SendMail("GlobalDirectory.com", SiteMailAddress, CommonObj.returnDataSet.Tables(0).Rows(0).Item("Subject"), CommonObj.returnDataSet.Tables(0).Rows(0).Item("Body")) Then
                '    LabelDetails.Text = CommonObj.ShowMessageBox("MailSent")
                'Else
                '    LabelDetails.Text = CommonObj.ShowMessageBox("MailError")
                'End If

            ElseIf e.CommandName = "RejectRequest" Then
                Query = "Update RequestforPublicMessage " & _
                        "Set isPending = 0, " & _
                        "isApproved = 0," & _
                        "ApprovedByKPIN = " & Session("KPIN") & ", " & _
                        "ApprovedDate = " & "GetDate() " & _
                        "Where RequestId = " & dataRow.Item("RequestId").ToString()

                CommonObj.EstablishSQLConnection(Query)
            End If

            Response.Redirect("RedirecttoDetails.aspx?Details=Pending", False)
        Catch ex As Exception
            'LabelPending.Text = ex.Message.ToString() & " " & Query
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    'Protected Sub GridViewPending_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewPending.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim Body As String = e.Row.Cells(7).Text
    '        Dim gridHyperLink As HyperLink = e.Row.Cells(8).FindControl("gridHyperLink")

    '        If Not gridHyperLink Is Nothing Then
    '            Dim windowUrl As String = "ShowMessageBody.aspx?Body = " & Body
    '            gridHyperLink.Attributes.Add("onclick", "window.open('" + windowUrl + "', 'popup_' + new Date().getTime(), 'left=0,top=0');")
    '        End If
    '    End If
    'End Sub

    'Protected Sub ButtonArchive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonArchive.Click

    'End Sub

    'Private Sub ArchivedFiles()
    '    Dim connectionString As String = ""
    '    Dim commandImportString As String = ""
    '    Dim commandValidateString As String = ""
    '    Dim commandForImport As OleDb.OleDbCommand
    '    Dim fileStreamObjToRead As System.IO.FileStream
    '    Dim SheetName As String
    '    Dim TopStr As String
    '    Dim NoofLines As Integer
    '    'Dim rowCount As Integer
    '    Dim ExportDataset As DataSet

    '    SheetName = "Sheet1"

    '    If Not System.IO.Directory.Exists("../ArchivedFiles") Then
    '        System.IO.Directory.CreateDirectory("../ArchivedFiles")
    '    End If

    '    If System.IO.File.Exists(archivedFileName) Then
    '        Try
    '            fileStreamObjToRead = System.IO.File.OpenRead(archivedFileName)
    '        Catch ex As IO.IOException
    '            fileStreamObjToRead = Nothing
    '        End Try

    '        If fileStreamObjToRead.CanRead() Then
    '            fileStreamObjToRead.Close()
    '            fileStreamObjToRead = Nothing
    '            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + archivedFileName + ";Extended Properties='Excel 8.0;'"
    '            commandImportString = "[" + SheetName + "$]"
    '            commandValidateString = "select Top 1 * from " + commandImportString

    '            Try
    '                NoofLines = getNoofLinesinExcel(archivedFileName, SheetName)
    '                TopStr = "TOP " & CStr(NoofLines) & " "
    '            Catch ex As Exception
    '                'MessageBox.Show("Sheet Name: " + SheetName + " not found")
    '                'Me.Close()
    '                'Return Nothing
    '            End Try

    '            connForImport = New System.Data.OleDb.OleDbConnection(connectionString)
    '            connForImport.Open()
    '            commandForImport = connForImport.CreateCommand()
    '            Try
    '                If validateFiletoImport(connForImport, commandForImport, commandValidateString) Then
    '                    ExportDataset = readFiletoDummyDataSet(connForImport, commandForImport, commandImportString, TopStr)
    '                    Return ExportDataset
    '                End If
    '            Catch ex As Exception
    '                'MessageBox.Show(ex.ToString())
    '            End Try
    '        End If
    '    End If

    'End Sub

    'Private Function getNoofLinesinExcel(ByVal FileNameandPath As String, ByVal sheetName As String) As Long
    '    Try

    '        Dim Exapp As New Excel.Application
    '        Dim ExWrkBook As Excel.Workbook = Nothing
    '        Dim LinesinExcel As Long

    '        Exapp = New Excel.ApplicationClass

    '        Try
    '            ExWrkBook = Exapp.Workbooks.Open(FileNameandPath)

    '            LinesinExcel = (ExWrkBook.Worksheets.Item(sheetName).Range("A1").End(-4121).Row) - 1

    '            Return LinesinExcel

    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            ExWrkBook.Close()
    '            ExWrkBook = Nothing

    '            Exapp.Quit()
    '            Exapp = Nothing

    '            GC.Collect()
    '        End Try
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Protected Sub ButtonArchive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonArchive.Click
        Dim Query As String = ""
        Try
            Query = "Insert Into ArchivedRequests " & _
                    "Select RequestId, RequestedByKPIN, RequestedDate, Subject, Body, isApproved, ApprovedByKPIN, ApprovedDate " & _
                    "From RequestforPublicMessage " & _
                    "where isPending = 0 " & _
                    "And ApprovedDate <= '" & WebUserControlCalendarArchive.GetDate() & "'"

            CommonObj.EstablishSQLConnection(Query)

            Query = "Delete From RequestforPublicMessage " & _
                    "where isPending = 0 " & _
                    "And ApprovedDate <= '" & WebUserControlCalendarArchive.GetDate() & "'"

            CommonObj.EstablishSQLConnection(Query)

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Protected Sub ButtonBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonBack.Click
        Response.Redirect("Admin.aspx", False)
    End Sub

    Protected Sub ButtonTree_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonTree.Click
        If Confirm() Then
            Dim URL As String = "Orgchart.aspx?KPIN=" + TextBoxKPIN.Text
            Response.Write("<script>window.open(""" + URL + """);</script>")
        End If
    End Sub

    Protected Sub ButtonAccess_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAccess.Click
        If Confirm() Then
            Dim Query As String
            Query = "Insert Into AdminAccess(KPIN,isAdmin) Values('" + TextBoxKPIN.Text + "',1)"
            CommonObj.EstablishSQLConnection(Query)

            Label1.Text = "Access is provided."
        End If
    End Sub

    Private Function Confirm() As Boolean
        TextBoxKPIN.Text = Trim(TextBoxKPIN.Text)
        Label1.Visible = False

        Dim Query As String
        Query = "SELECT * From MemberInfo WHERE KPIN = '" + TextBoxKPIN.Text + "'"
        CommonObj.EstablishSQLConnection(Query, "Get")

        If CommonObj.returnDataSet.Tables(0).Rows.Count > 0 Then
            Return True
        End If
        Label1.Visible = True
        Label1.Text = "KPIN does not exist."
        Return False
    End Function
End Class
