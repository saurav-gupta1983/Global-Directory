Imports System.Data

Partial Class Forms_Contact_Details
    Inherits System.Web.UI.Page

    Dim KPIN As String = ""
    Dim VPIN As String = ""
    Dim PinId As Integer
    Dim DataSet As New DataSet
    Dim DetailsValue As String = TITLE_ContactDetails
    Dim CommonObj As New CommonCode
    Dim DataUpdated As String = MSG_Details_Updated
    Dim TransactionError As String = MSG_Incomplete_Transaction


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            KPIN = Session("KPIN")
            LabelContactDetails.Text = ""
            'KPIN = "8"

            If Not IsPostBack Then
                GetContactDetails()
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Sub GetContactDetails()
        Try
            Dim Query As String = ""
            Dim DetailsDatarow As DataRow

            DropDownListDetails.SelectedIndex = DropDownListDetails.Items.IndexOf(DropDownListDetails.Items.FindByText(DetailsValue))

            DetailsDatarow = GetContactDetailsbyRow()

            If Not DetailsDatarow Is Nothing Then
                WebUserControlNativeAddress.Address = DetailsDatarow.Item("NativeAddress")
                WebUserControlPermanentAddress.Address = DetailsDatarow.Item("PermanentAddress")
                WebUserControlCurrentAddress.Address = DetailsDatarow.Item("CurrentAddress")
                TextBoxMobileNo.Text = DetailsDatarow.Item("MobileNo")
                TextBoxResidenceNo.Text = DetailsDatarow.Item("ResidenceNo")
                WebUserControlEmail.AssignEmailid = DetailsDatarow.Item("EmailId")
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function GetContactDetailsbyRow() As DataRow
        Try
            Dim Query As String = ""

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            'LabelDetails.Text = CommonObj.returnDataSet.Tables(0).Rows(0).Item("FirstName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("MiddleName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("LastName") & " (" & _
            'KPIN & ")"

            If CommonObj.returnDataSet.Tables(0).Rows.Count > 0 Then
                PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")
            End If


            Query = "Select * from ContactDetails where PinId = " & PinId.ToString()
            CommonObj.EstablishSQLConnection(Query, "Get")

            If CommonObj.returnDataSet.Tables(0).Rows.Count > 0 Then
                Return CommonObj.returnDataSet.Tables(0).Rows(0)
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return Nothing
    End Function

    Protected Sub DropDownListDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDetails.SelectedIndexChanged
        Try
            Response.Redirect("RedirecttoDetails.aspx?Details=" & DropDownListDetails.SelectedValue, False)
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Try
            LabelContactDetails.Text = ""

            If ValidationMemberInfo() Then
                Exit Sub
            End If

            If GenerateVPIN() Then
                LabelContactDetails.Text = CommonObj.ShowMessageBox(DataUpdated, DetailsValue)
            Else
                LabelContactDetails.Text = CommonObj.ShowMessageBox(TransactionError, DetailsValue)
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function ValidationMemberInfo() As Boolean
        Try
            Dim errorMessage As String = ""
            errorMessage = WebUserControlNativeAddress.ValidateAddress("Native Address")
            If errorMessage <> "" Then
                LabelContactDetails.Text = errorMessage
                Return True
            End If

            errorMessage = WebUserControlPermanentAddress.ValidateAddress("Permanent Address")
            If errorMessage <> "" Then
                LabelContactDetails.Text = errorMessage
                Return True
            End If

            errorMessage = WebUserControlCurrentAddress.ValidateAddress("Current Address")
            If errorMessage <> "" Then
                LabelContactDetails.Text = errorMessage
                Return True
            End If

            If ValidateContactNumber(Trim(TextBoxMobileNo.Text), "Mobile No.") OrElse ValidateContactNumber(Trim(TextBoxResidenceNo.Text), "Residence No.") Then
                Return True
            End If

            If WebUserControlEmail.ValidateEmailId Then
                LabelContactDetails.Text = "Incorrect EmailId. Please specify correct Email Id."
                Return True
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function ValidateContactNumber(ByVal Name As String, ByVal Text As String) As Boolean
        Try
            If Trim(Name) = "" Then
                LabelContactDetails.Text = "Please specify " & Text & "."
                Return True
            End If
            For Each character As Char In Name
                If (Not Char.IsDigit(character) AndAlso Not character = "-") Then
                    LabelContactDetails.Text = Text & " can have Digits only."
                    Return True
                End If
            Next
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function GenerateVPIN() As Integer
        Try
            Dim Query As String = ""

            VPIN = ""
            'VPIN = CType(CommonObj.GenerateVPIN, String)

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")

            Query = "Update ContactDetails " & _
                    "Set VPIN = '" & VPIN.ToString() & "' , " & _
                    "NativeAddress = '" & WebUserControlNativeAddress.Address & "' , " & _
                    "PermanentAddress = '" & WebUserControlPermanentAddress.Address & "' , " & _
                    "CurrentAddress = '" & WebUserControlCurrentAddress.Address & "' , " & _
                    "MobileNo = '" & TextBoxMobileNo.Text & "' , " & _
                    "ResidenceNo = '" & TextBoxResidenceNo.Text & "' , " & _
                    "EmailId = '" & WebUserControlEmail.AssignEmailid & "' " & _
                    "Where PinId = " & PinId.ToString()

            CommonObj.EstablishSQLConnection(Query)

            Query = "Update MemberInfo " & _
                    "Set City = '" & WebUserControlCurrentAddress.City & "' , " & _
                    "Country = '" & WebUserControlCurrentAddress.Country & "' , " & _
                    "LastUpdated = " & "GetDate() " & _
                    "Where PinId = " & PinId.ToString()

            CommonObj.EstablishSQLConnection(Query)

            Return True

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

End Class
