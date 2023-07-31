Imports System.Data

Partial Class Forms_Family_Details
    Inherits System.Web.UI.Page

    Dim KPIN As String = ""
    Dim VPIN As String = ""
    Dim PinId As Integer
    Dim DataSet As New DataSet
    Dim DetailsValue As String = TITLE_FamilyDetails
    Dim CommonObj As New CommonCode
    Dim DataUpdated As String = MSG_Details_Updated
    Dim TransactionError As String = MSG_Incomplete_Transaction

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            KPIN = Session("KPIN")
            LabelFamilyDetails.Text = ""
            'KPIN = "8"

            If Not IsPostBack Then
                GetFamilyDetails()
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Sub GetFamilyDetails()
        Try
            Dim Query As String = ""
            Dim DetailsDatarow As DataRow

            DropDownListDetails.SelectedIndex = DropDownListDetails.Items.IndexOf(DropDownListDetails.Items.FindByText(DetailsValue))

            DetailsDatarow = GetFamilyDetailsbyRow()

            If Not DetailsDatarow Is Nothing Then
                DropDownListMaritalStatus.SelectedIndex = DropDownListMaritalStatus.Items.IndexOf(DropDownListMaritalStatus.Items.FindByValue(DetailsDatarow.Item("MaritalStatus")))
                DropDownListSex.SelectedIndex = DropDownListSex.Items.IndexOf(DropDownListSex.Items.FindByValue(DetailsDatarow.Item("Sex")))
                TextBoxNationality.Text = DetailsDatarow.Item("Nationality")
                WebUserControlFathersName.Name = DetailsDatarow.Item("FathersName")
                WebUserControlMothersName.Name = DetailsDatarow.Item("MothersName")
                PositionSpousePanel()
                WebUserControlSpouseName.Name = DetailsDatarow.Item("SpouseName")
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function GetFamilyDetailsbyRow() As DataRow
        Try
            Dim Query As String = ""

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            'LabelDetails.Text = CommonObj.returnDataSet.Tables(0).Rows(0).Item("FirstName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("MiddleName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("LastName") & " (" & _
            'KPIN & ")"

            PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")

            Query = "Select * from FamilyDetails where PinId = " & PinId.ToString()
            CommonObj.EstablishSQLConnection(Query, "Get")

            Return CommonObj.returnDataSet.Tables(0).Rows(0)

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

    Protected Sub DropDownListMaritalStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListMaritalStatus.SelectedIndexChanged
        Try
            PositionSpousePanel()
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Sub PositionSpousePanel()
        Try
            If DropDownListMaritalStatus.SelectedValue = 0 Then
                PanelSpouse.Visible = False
                WebUserControlSpouseName.Name = "--"
            Else
                PanelSpouse.Visible = True
            End If
            LabelFamilyDetails.Text = ""

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Try
            LabelFamilyDetails.Text = ""

            If ValidationMemberInfo() Then
                Exit Sub
            End If

            If GenerateVPIN() Then
                LabelFamilyDetails.Text = CommonObj.ShowMessageBox(DataUpdated, DetailsValue)
            Else
                LabelFamilyDetails.Text = CommonObj.ShowMessageBox(TransactionError, DetailsValue)
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function ValidationMemberInfo() As Boolean
        Try
            If ValidateCountry(TextBoxNationality.Text, "Nationality", True) Then
                Return True
            End If

            Dim errorMessage As String = ""
            'errorMessage = WebUserControlFathersName.ValidateName("Father's Name", True)
            'If errorMessage <> "" Then
            '    LabelFamilyDetails.Text = errorMessage
            '    Return True
            'End If
            'errorMessage = WebUserControlMothersName.ValidateName("Mother's Name", True)
            'If errorMessage <> "" Then
            '    LabelFamilyDetails.Text = errorMessage
            '    Return True
            'End If

            If PanelSpouse.Visible Then
                errorMessage = WebUserControlSpouseName.ValidateName("Spouse Name", True)
                If errorMessage <> "" Then
                    LabelFamilyDetails.Text = errorMessage
                    Return True
                End If
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function ValidateCountry(ByVal Name As String, ByVal Text As String, Optional ByVal iPersonalLabel As Boolean = False) As Boolean
        Try
            If Trim(Name) = "" Then
                LabelFamilyDetails.Text = "Please specify " & Text & "."
                Return True
            End If
            For Each character As Char In Name
                If (Not Char.IsLetter(character) AndAlso Not character = " ") Then
                    LabelFamilyDetails.Text = Text & " can have Alphabets and space only."
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

            Query = "Update FamilyDetails " & _
                    "Set VPIN = '" & VPIN.ToString() & "' , " & _
                    "Sex = '" & DropDownListSex.SelectedValue.ToString() & "' , " & _
                    "MaritalStatus = '" & DropDownListMaritalStatus.SelectedValue.ToString() & "' , " & _
                    "Nationality = '" & TextBoxNationality.Text & "' , " & _
                    "FathersName = '" & WebUserControlFathersName.Name & "' , " & _
                    "MothersName = '" & WebUserControlMothersName.Name & "' , " & _
                    "SpouseName = '" & WebUserControlSpouseName.Name & "' " & _
                    "Where PinId = " & PinId.ToString()

            CommonObj.EstablishSQLConnection(Query)

            Query = "Update MemberInfo " & _
                    "Set LastUpdated = " & "GetDate() " & _
                    "Where PinId = " & PinId.ToString()

            CommonObj.EstablishSQLConnection(Query)

            Return True

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

End Class
