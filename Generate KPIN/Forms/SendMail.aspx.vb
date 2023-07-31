Imports System.Net.Mail
Imports System.Net.Mail.SmtpClient

Partial Class SendMail
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode

    Dim KPIN As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Session("KPIN") Is Nothing Then
                'Response.Redirect("GlobalDirectory.aspx", False)
                'LabelDetails.Visible = False
                'HyperLinkHome.Visible = False
                'HyperLinkLogOut.Visible = False
            Else
                KPIN = Session("KPIN")
                'LabelDetails.Visible = True
                'HyperLinkHome.Visible = True
                'HyperLinkLogOut.Visible = True
                If Request.QueryString("PIN") Is Nothing Then
                    PanelShowDetails.Visible = False
                    Session("GroupMessage") = "Yes"
                    LabelSendEmail.Text = "Send an Email to Group"
                    TextBoxFROM.Text = Session("KPIN")
                    TextBoxTO.Text = "Group ( " & Replace(Session("Filter"), "'", "") & " )"
                Else
                    GetLoginDetails()
                End If
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Sub GetLoginDetails()
        Try
            Dim Query As String = ""

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            'LabelDetails.Text = CommonObj.returnDataSet.Tables(0).Rows(0).Item("FirstName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("MiddleName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("LastName") & " (" & _
            'KPIN & ")"

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Protected Sub ButtonSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSend.Click
        Try
            'Dim mail As New MailMessage
            'Dim SmtpMail As New SmtpClient

            'If TextBoxFROM.Text = "" Then
            '    CommonObj.ShowMessageBox("Specify your Mail Id or KPIN")
            '    Exit Sub
            'End If

            'SmtpMail.Host = "smtp.mail.yahoo.com"
            'SmtpMail.Send(TextBoxFROM.Text, TextBoxTO.Text, TextBoxSubject.Text, TextBoxMessage.Text)
            If Session("GroupMessage") = "Yes" Then
                Dim Query As String
                Dim isPending As Integer, isApproved As Integer

                Query = "Select * from AdminAccess where KPIN = '" & Session("KPIN") & "'"
                CommonObj.EstablishSQLConnection(Query, "Get")
                If CommonObj.returnDataSet.Tables(0).Rows.Count > 0 Then
                    isPending = 0
                    isApproved = 1
                Else
                    isPending = 1
                    isApproved = 0
                End If

                Query = "Insert Into RequestforPublicMessage(RequestedByKPIN,RequestedDate,Subject,Body,isPending, isApproved, Filter) " & _
                        "Select '" & _
                        Session("KPIN") & "' , '" & _
                        System.DateTime.Now() & "' , '" & _
                        TextBoxSubject.Text & "' , '" & _
                        TextBoxMessage.Text & "' , " & isPending & " , " & isApproved & " , '" & _
                        Session("Filter") & "'"

                CommonObj.EstablishSQLConnection(Query)
                Session.Remove("GroupMessage")
            Else
                If CommonObj.SendMail(TextBoxTO.Text, SiteMailAddress, TextBoxSubject.Text, TextBoxMessage.Text) Then
                    LabelMessage.Text = CommonObj.ShowMessageBox("MailSent")
                Else
                    LabelMessage.Text = CommonObj.ShowMessageBox("MailError")
                End If

                InsertMailInfo()
            End If
            'InsertMailInfo()
            'Response.Redirect(Session("PreviousPage"), False)
            TextBoxTO.Text = ""
            TextBoxSubject.Text = ""
            TextBoxMessage.Text = ""

            Response.Redirect(Session("PreviousPage"), False)
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Sub InsertMailInfo()
        Dim Query As String
        Try
            Query = "Select KPIN from MemberInfo where PINId = '" & Request.QueryString("PIN") & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            Query = "Insert Into MailList (KPIN,EmailToKPIN,DateofEmail,Subject) Select '" & _
                    Session("KPIN") & "' , '" & _
                    CommonObj.returnDataSet.Tables(0).Rows(0).Item(0) & "' , '" & _
                    System.DateTime.Now() & "' , '" & _
                    TextBoxSubject.Text & "'"

            CommonObj.EstablishSQLConnection(Query)

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Protected Sub ButtonGoBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGoBack.Click
        Response.Redirect(Session("PreviousPage"), False)
    End Sub
End Class
