
Partial Class WebUserControlEmail
    Inherits System.Web.UI.UserControl

    Dim CommonObj As New CommonCode

    Property EmailId() As String
        Get
            Return TextBoxEmailId.Text
        End Get
        Set(ByVal value As String)
            TextBoxEmailId.Text = value
        End Set
    End Property

    Property SiteName() As String
        Get
            Return TextBoxSite.Text
        End Get
        Set(ByVal value As String)
            TextBoxSite.Text = value
        End Set
    End Property

    Property Enabled() As Boolean
        Get
            Return TextBoxEmailId.Enabled
        End Get
        Set(ByVal value As Boolean)
            TextBoxEmailId.Enabled = value
            TextBoxSite.Enabled = value
        End Set
    End Property

    Property AssignEmailid() As String
        Get
            Return Trim(TextBoxEmailId.Text) & "@" & Trim(TextBoxSite.Text)
        End Get
        Set(ByVal value As String)
            If value.ToString() <> "" Then
                TextBoxEmailId.Text = value.ToString().Split("@")(0)
                TextBoxSite.Text = value.ToString().Split("@")(1)
            End If
        End Set
    End Property

    Public Function ValidateEmailId() As Boolean
        Dim Email, Site As String
        Email = Trim(EmailId())
        Site = Trim(SiteName())
        Try
            If Email = "" Or Site = "" Then
                Return True
            End If
            For Each character As Char In Email
                If (Not character = "." AndAlso Not character = "_" AndAlso Not Char.IsLetter(character) AndAlso Not Char.IsDigit(character)) Then
                    Return True
                End If
            Next
            For Each character As Char In Site
                If (Not character = "." AndAlso Not Char.IsLetter(character)) Then
                    Return True
                End If
            Next
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

End Class
