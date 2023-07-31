Imports System.Net.Mail
Imports System.Net.Mail.SmtpClient

Partial Class ForgotPassword
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode

    Protected Sub ButtonSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSubmit.Click
        Try
            If TextBoxEmailId.Text = "" Then
                'CommonObj.ShowMessageBox("Please specify KPIN.")
                Exit Sub
            End If

            'Dim SmtpMail As New SmtpClient

            'SmtpMail.Host = "smtp.mail.yahoo.com"
            'SmtpMail.Send("Global Directory.com", "KPIN", "Forgot your Password?", "Your Password is " & GetPassword())

            If CommonObj.SendMail("KPIN", SiteMailAddress, "Forgot your KPIN/Password?", GetPassword()) Then
                LabelConfirm.Text = CommonObj.ShowMessageBox("PasswordSent")
            Else
                LabelConfirm.Text = CommonObj.ShowMessageBox("RecoveringError")
            End If

            PanelForgotPassword.Visible = False
            PanelClose.Visible = True

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Public Function GetPassword() As String
        Dim Query As String
        Dim KPIN As String
        Try
            KPIN = TextBoxEmailId.Text

            Query = "Select KPIN, Password from MemberInfo MI, ContactDetails CD where EmailId = '" & _
                    Trim(TextBoxEmailId.Text) & "'" & _
                    " and CD.PinId = MI.PinId"

            CommonObj.EstablishSQLConnection(Query, "Get")

            If CommonObj.returnDataSet.Tables(0).Rows.Count > 0 Then
                Return "KPIN = " & CommonObj.returnDataSet.Tables(0).Rows(0).Item(0) & ControlChars.NewLine & _
                        "Password = " & CommonObj.returnDataSet.Tables(0).Rows(0).Item(1)
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return ""
    End Function

    Protected Sub ButtonClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ButtonClose.Click
        Response.Write("<script>window.close();</script>")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PanelForgotPassword.Visible = True
        PanelClose.Visible = False
    End Sub
End Class
