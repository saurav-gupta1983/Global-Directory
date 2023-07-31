Imports System.Net.Mail
Imports System.Net.Mail.SmtpClient

Partial Class ChangePassword
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode

    Protected Sub ButtonChangePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonChangePassword.Click
        Try
            LabelInvalidUser.Text = ""
            If ValidateUser() AndAlso ValidatePassword() AndAlso SavePassword() Then
                SavePassword()
                CommonObj.ShowMessageBox("Password is reset successfully.")
                Response.Write("<script>window.close();</script>")
                'Else
                '    LabelInvalidUser.Visible = True
            End If
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function ValidateUser() As Boolean
        Try
            Dim Query As String

            Query = "Select * from MemberInfo where KPIN = '" & TextBoxUser.Text & "' and Password = '" & TextBoxPassword.Value & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            If Not CommonObj.returnDataSet Is Nothing AndAlso CommonObj.returnDataSet.Tables(0).Rows.Count > 0 Then
                Return True
            End If

            LabelInvalidUser.Text = "Invalid KPIN. Please specify correct Username/KPIN"
            Return False

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function ValidatePassword() As Boolean
        Try
            If TextBoxNewPassword.Value.Length < 8 Then
                LabelInvalidUser.Text = "Password should be of atleast 8 characters."
                TextBoxNewPassword.Value = ""
                TextBoxConfirmPassword.Value = ""
                Return False
            End If

            If TextBoxNewPassword.Value <> TextBoxConfirmPassword.Value Then
                LabelInvalidUser.Text = "Password should be same."
                TextBoxNewPassword.Value = ""
                TextBoxConfirmPassword.Value = ""
                Return False
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return True
    End Function

    Private Function SavePassword() As Boolean
        Dim Query As String
        Try
            Query = "Update MemberInfo Set " & _
                    "Password = '" & Trim(TextBoxNewPassword.Value) & "' " & _
                    "Where KPIN = '" & TextBoxUser.Text & "'"

            CommonObj.EstablishSQLConnection(Query)

            Return True

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
            Return False
        End Try
    End Function

    Protected Sub ButtonClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Response.Write("<script language='javascript'> { window.close();}</script>")
    End Sub
End Class
