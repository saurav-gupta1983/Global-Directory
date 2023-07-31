Imports System.Data

Partial Class ConfirmInformation
    Inherits System.Web.UI.Page

    Dim CommonObj As New CommonCode
    Dim KPIN As String

    Protected Sub ButtonEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEdit.Click
        Try
            Response.Redirect("MembershipForm.aspx", False)
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Protected Sub ButtonConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonConfirm.Click
        Try
            If GenerateKPIN() <> 0 Then
                'CommonObj.ShowMessageBox("Thank you for being a member. Please record your secret KPIN safely for login " + ControlChars.NewLine + "Your User Name / KPIN: " + KPIN)
                Session.Remove("EditMemberInfo")
                Session.Add("Message", KPIN)
            Else
                Session.Add("Message", MSG_IncompleteTransaction)
                'CommonObj.ShowMessageBox("Please update your information again. Sorry for incovenience.")
            End If
            Session.Add("RedirectPage", "GlobalDirectory.aspx")
            Response.Redirect("ShowConfirmation.aspx", False)
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'Dim KPIN As String = ""
                KPIN = Request.QueryString("ConfirmKPIN")

                If KPIN <> "" Then
                    Dim Query As String = ""
                    Dim MemberDataset As New DataSet
                    Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"

                    CommonObj.EstablishSQLConnection(Query, "Get")
                    MemberDataset = CommonObj.returnDataSet
                    Session("EditMemberInfo") = MemberDataset

                    'LabelKPINInfo.Text = MemberDataset.Tables(0).Rows(0).Item("KPIN").ToString()
                    LabelNameInfo.Text = MemberDataset.Tables(0).Rows(0).Item("FirstName").ToString() & " " & _
                                        MemberDataset.Tables(0).Rows(0).Item("MiddleName").ToString() & " " & _
                                        MemberDataset.Tables(0).Rows(0).Item("LastName").ToString()
                    LabelDOBInfo.Text = CommonObj.GenerateDatefromAge(CType(MemberDataset.Tables(0).Rows(0).Item("AgeDiff"), Integer))
                    LabelNationalityInfo.Text = MemberDataset.Tables(0).Rows(0).Item("Nationality").ToString()
                    LabelFathersNameInfo.Text = MemberDataset.Tables(0).Rows(0).Item("FathersName").ToString().Replace("-", " ")
                    LabelMothersNameInfo.Text = MemberDataset.Tables(0).Rows(0).Item("MothersName").ToString().Replace("-", " ")
                    LabelSpouseNameInfo.Text = MemberDataset.Tables(0).Rows(0).Item("SpouseName").ToString().Replace("-", " ")
                    LabelPerAddInfo.Text = MemberDataset.Tables(0).Rows(0).Item("PermanentAddress").ToString().Replace("@", ", ")
                    LabelTempAddInfo.Text = MemberDataset.Tables(0).Rows(0).Item("TemporaryAddress").ToString().Replace("@", ", ")
                    LabelCountryInfo.Text = MemberDataset.Tables(0).Rows(0).Item("Country").ToString()
                    LabelMobileInfo.Text = MemberDataset.Tables(0).Rows(0).Item("MobileNo").ToString()
                    LabelResInfo.Text = MemberDataset.Tables(0).Rows(0).Item("ResidenceNo").ToString()
                    LabelEmailInfo.Text = MemberDataset.Tables(0).Rows(0).Item("EmailId").ToString()

                    'TextBoxFirstName.Text = MemberDataset.Tables(0).Rows(0).Item("FirstName").ToString()
                    'TextBoxLastName.Text = MemberDataset.Tables(0).Rows(0).Item("LastName").ToString()
                    'TextBoxMiddleName.Text = MemberDataset.Tables(0).Rows(0).Item("MiddleName").ToString()
                    'WebUserControlDOB.AssignDate = CommonObj.GenerateDatefromAge(CType(MemberDataset.Tables(0).Rows(0).Item("AgeDiff"), Integer))
                    'TextBoxNationality.Text = MemberDataset.Tables(0).Rows(0).Item("Nationality").ToString()

                    'WebUserControlFathersName.Name = MemberDataset.Tables(0).Rows(0).Item("FathersName").ToString()
                    'WebUserControlMothersName.Name = MemberDataset.Tables(0).Rows(0).Item("MothersName").ToString()
                    'WebUserControlSpouseName.Name = MemberDataset.Tables(0).Rows(0).Item("SpouseName").ToString()

                    'TextBoxPermanentAddress.Text = MemberDataset.Tables(0).Rows(0).Item("PermanentAddress").ToString()
                    'TextBoxTempAddress.Text = MemberDataset.Tables(0).Rows(0).Item("TemporaryAddress").ToString()
                    'TextBoxCountry.Text = MemberDataset.Tables(0).Rows(0).Item("Country").ToString()
                    'TextBoxMobileNo.Text = MemberDataset.Tables(0).Rows(0).Item("MobileNo").ToString()
                    'TextBoxResidenceNo.Text = MemberDataset.Tables(0).Rows(0).Item("ResidenceNo").ToString()
                    'WebUserControlEmail.AssignEmailid = MemberDataset.Tables(0).Rows(0).Item("EmailId").ToString()

                    'Session.Remove("ModifyKPIN")
                    Query = "Delete from MemberInfo where KPIN = '" & KPIN & "'"
                    CommonObj.EstablishSQLConnection(Query)
                    'Session.Remove("ConfirmKPIN")
                End If
            End If
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function GenerateKPIN() As Integer
        Dim RowNumber As Integer = 0
        Try
            Dim MemberDataset As New DataSet
            'CommonObj.EstablishSQLConnection(Query, "Get")
            MemberDataset = Session("EditMemberInfo")
            'AgeinDays = CommonObj.CalculateAge(WebUserControlDOB.BirthDay, WebUserControlDOB.BirthMonth, WebUserControlDOB.BirthYear)
            KPIN = MemberDataset.Tables(0).Rows(0).Item("KPIN").ToString()
            Dim Query As String = ""

            'Query = "Delete from MemberInfo where KPIN = '" & KPIN & "'"
            'CommonObj.EstablishSQLConnection(Query)

            'Query = "Select max(KPIN) from MemberInfo"
            'CommonObj.EstablishSQLConnection(Query, "Get")

            'KPIN = CType(CommonObj.returnDataSet.Tables(0).Rows(0).Item(0) + 1, String)

            Query = "Insert Into MemberInfo " & _
                    "(FirstName,MiddleName,LastName,AgeDiff,Nationality,FathersName,MothersName,SpouseName,Country,PermanentAddress, " & _
                    "TemporaryAddress,MobileNo,ResidenceNo,EmailId,KPIN,City,Password) " & _
                    "Select '" & _
                    MemberDataset.Tables(0).Rows(0).Item("FirstName").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("MiddleName").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("LastName").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("AgeDiff").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("Nationality").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("FathersName").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("MothersName").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("SpouseName").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("Country").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("PermanentAddress").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("TemporaryAddress").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("MobileNo").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("ResidenceNo").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("EmailId").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("KPIN").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("City").ToString() & "' , '" & _
                    MemberDataset.Tables(0).Rows(0).Item("Password").ToString() & "' "

            CommonObj.EstablishSQLConnection(Query)

            Return CommonObj.returnRowNUmber

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return RowNumber
    End Function
End Class
