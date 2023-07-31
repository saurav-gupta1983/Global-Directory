Imports CommonCode
Imports System.Data

Partial Class MembersForm
    Inherits System.Web.UI.Page

    Dim KPIN As String = ""
    Dim VPIN As String = ""

    Dim CommonObj As New CommonCode

    Protected Sub ButtonSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSubmit.Click
        Try
            LabelPersonalDetails.Text = ""

            If ValidationMemberInfo() Then
                Exit Sub
            End If

            PanelInformation.Visible = False
            PanelSubmit.Visible = False
            PanelWarning.Visible = True

            LabelName.Text = TextBoxFirstName.Text + " " + TextBoxMiddleName.Text + " " + TextBoxLastName.Text
            LabelSex.Text = DropDownListSex.SelectedItem.Text
            LabelDOB.Text = WebUserControlDOB.GetDate().ToShortDateString()
            LabelFathersName.Text = WebUserControlFathersName.Name.Replace("-", " ")
            LabelMothersName.Text = WebUserControlMothersName.Name.Replace("-", " ")
            LabelEmailID.Text = WebUserControlEmail.AssignEmailid()

            LabelWarning.Text = MSG_VALIDATE

            'Dim DialogResult As Microsoft.VisualBasic.MsgBoxResult
            'DialogResult = CommonObj.ShowMessageBox(MSG_VALIDATE, "Question")

            'If DialogResult = MsgBoxResult.No Then
            '    Exit Sub
            'End If

            'If GenerateKPIN() Then
            '    CommonObj.ShowMessageBox(MSG_CONFIRM + KPIN)
            '    Session("KPIN") = KPIN
            '    Response.Redirect("MembersInfo.aspx", False)
            '    Dim message As String = MSG_LOGINDETAILS + KPIN + MSG_PASSWORD + Password.Value.ToString()

            '    CommonObj.SendMail(WebUserControlEmail.AssignEmailid, SiteMailAddress, MSG_WELCOME, message)
            'Else
            '    CommonObj.ShowMessageBox("Please update your information again. Sorry for incovenience.")
            'End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function ValidationMemberInfo() As Boolean
        Try
            If ValidateName(TextBoxFirstName.Text, "First Name", True) OrElse ValidateName(TextBoxMiddleName.Text, "Middle Name", True) OrElse _
            ValidateName(TextBoxLastName.Text, "Last Name", True) Then
                Return True
            End If

            If (TextBoxFirstName.Text & " " & TextBoxMiddleName.Text & " " & TextBoxLastName.Text).Length > 30 Then
                LabelPersonalDetails.Text = "Name can not have length greater than 30."
                Return True
            End If

            If WebUserControlDOB.ValidateDate() Then
                LabelPersonalDetails.Text = "Incorrect Date. Please specify correct Date of Birth"
                Return True
            End If

            If WebUserControlEmail.ValidateEmailId Then
                LabelPersonalDetails.Text = "Incorrect EmailId. Please specify correct Email Id."
                Return True
            End If

            Dim errorMessage As String = ""
            errorMessage = WebUserControlFathersName.ValidateName("Father's Name", True)
            If errorMessage <> "" Then
                LabelPersonalDetails.Text = errorMessage
                Return True
            End If

            errorMessage = WebUserControlMothersName.ValidateName("Mother's Name", True)
            If errorMessage <> "" Then
                LabelPersonalDetails.Text = errorMessage
                Return True
            End If

            If ValidatePassword() Then
                Return True
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function ValidateName(ByVal Name As String, ByVal Text As String, Optional ByVal iPersonalLabel As Boolean = False) As Boolean
        Try
            Name = Trim(Name)
            If Name = "" AndAlso Text <> "Middle Name" Then
                LabelPersonalDetails.Text = "Please specify " & Text & "."
                Return True
            End If

            If Name <> "" AndAlso Name.Length <= 2 Then
                LabelPersonalDetails.Text = "Initials not allowed. Use full name for " & Text & "."
                Return True
            End If

            For Each character As Char In Name
                If (Not Char.IsLetter(character) AndAlso Not character = " ") Then
                    LabelPersonalDetails.Text = "Use only Alphabets and space for " & Text & "."
                    Return True
                End If
            Next
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function ValidatePassword() As Boolean
        Try
            If Password.Value.Length < 8 Then
                LabelPersonalDetails.Text = "Password should be of atleast 8 characters."
                Password.Value = ""
                PasswordConf.Value = ""
                Return True
            End If

            If Password.Value <> PasswordConf.Value Then
                LabelPersonalDetails.Text = "Password should be same."
                Password.Value = ""
                PasswordConf.Value = ""
                Return True
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function GenerateKPIN() As Integer
        Dim RowNumber As Integer = 0
        Dim AgeinDays As Integer
        Try
            AgeinDays = CommonObj.CalculateAge(WebUserControlDOB.BirthDay, WebUserControlDOB.BirthMonth, WebUserControlDOB.BirthYear)

            Dim Query As String = ""

            'Query = "Select max(KPIN) from MemberInfo"
            'CommonObj.EstablishSQLConnection(Query, "Get")

            'KPIN = CType(CommonObj.returnDataSet.Tables(0).Rows(0).Item(0) + 1, String)
            If RadioButtonSimple.Checked Then
                KPIN = CommonObj.GenerateKPIN(TextBoxFirstName.Text, TextBoxLastName.Text, AgeinDays)
            Else
                Dim Name As String
                Name = Replace(TextBoxFirstName.Text + " " + TextBoxMiddleName.Text + " " + TextBoxLastName.Text, "  ", " ")
                KPIN = CommonObj.GenerateComplexKPIN(WebUserControlMothersName.LastName, Name, AgeinDays.ToString())
            End If
            VPIN = ""
            'VPIN = CType(CommonObj.GenerateVPIN, String)

            Query = "Select * From MemberInfo Where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")
            If CommonObj.returnDataSet.Tables(0).Rows.Count > 0 Then
                Exit Function
            End If

            Query = "Insert Into MemberInfo " & _
                    "(KPIN, VPIN, Password, FirstName, MiddleName, LastName, AgeDiff, LastUpdated) " & _
                    "Select '" & _
                    KPIN & "' , '" & _
                    VPIN & "' , '" & _
                    Password.Value.ToString() & "' , '" & _
                    TextBoxFirstName.Text & "' , '" & _
                    TextBoxMiddleName.Text & "' , '" & _
                    TextBoxLastName.Text & "' , '" & _
                    AgeinDays & "' , " & _
                    "GetDate()"

            CommonObj.EstablishSQLConnection(Query)

            Dim CommonObj1 As New CommonCode

            Query = "Select PinId From MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj1.EstablishSQLConnection(Query, "Get")

            Query = "Insert Into FamilyDetails(PINId, Sex, FathersName, MothersName) " & _
                    "Select '" & CommonObj1.returnDataSet.Tables(0).Rows(0).Item(0).ToString() & "', " & _
                    DropDownListSex.SelectedValue.ToString() & " , '" & _
                    WebUserControlFathersName.Name & "' , '" & _
                    WebUserControlMothersName.Name & " ' "
            CommonObj.EstablishSQLConnection(Query)

            Query = "Insert Into ContactDetails(PINId, EmailId) " & _
                    "Select '" & CommonObj1.returnDataSet.Tables(0).Rows(0).Item(0).ToString() & "', '" & _
                    WebUserControlEmail.AssignEmailid & "'"
            CommonObj.EstablishSQLConnection(Query)

            Query = "Insert Into OtherDetails(PINId) " & _
                    "Select '" & CommonObj1.returnDataSet.Tables(0).Rows(0).Item(0).ToString() & "'"
            CommonObj.EstablishSQLConnection(Query)

            Return True

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return RowNumber
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PanelInformation.Visible = True
        PanelSubmit.Visible = True
        PanelWarning.Visible = False

        Session("KPIN") = ""
    End Sub

    Protected Sub ButtonNo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ButtonNo.Click
        PanelInformation.Visible = True
        PanelSubmit.Visible = True
        PanelWarning.Visible = False

        LabelWarning.Text = ""
    End Sub

    Protected Sub ButtonYes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ButtonYes.Click
        Try
            If GenerateKPIN() Then
                Session("KPIN") = KPIN
                Session.Add("Message", KPIN)

                Dim message As String = MSG_LOGINDETAILS + KPIN + MSG_PASSWORD + Password.Value.ToString()

                CommonObj.SendMail(WebUserControlEmail.AssignEmailid, SiteMailAddress, MSG_WELCOME, message)

                Session.Add("RedirectPage", "MembersInfo.aspx")
                Response.Redirect("ShowConfirmation.aspx", False)
            Else
                CommonObj.ShowMessageBox(MSG_IncompleteTransaction)
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try

    End Sub
End Class
