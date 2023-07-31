Imports System.Data

Partial Class OtherDetails
    Inherits System.Web.UI.Page

    Dim KPIN As String = ""
    Dim VPIN As String = ""
    Dim PinId As Integer
    Dim DataSet As New DataSet
    Dim DetailsValue As String = TITLE_OtherDetails
    Dim CommonObj As New CommonCode
    Dim DataUpdated As String = MSG_Details_Updated
    Dim TransactionError As String = MSG_Incomplete_Transaction
    Dim RecordDeleted As String = MSG_Delete_Record
    Dim RecordNotExists As String = MSG_Record_NOT_EXIST

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            KPIN = Session("KPIN")
            LabelOtherDetails.Text = ""
            'KPIN = "3"

            If Not IsPostBack Then
                GetOtherDetails()
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Sub GetOtherDetails()
        Try
            Dim Query As String = ""
            Dim DetailsDatarow As DataRow

            DropDownListDetails.SelectedIndex = DropDownListDetails.Items.IndexOf(DropDownListDetails.Items.FindByText(DetailsValue))

            PopulateProfessionDropDown()
            PopulateDegreeDropDown()
            DetailsDatarow = GetOtherDetailsbyRow()

            If Not DetailsDatarow Is Nothing Then
                WebUserControlDateofMigration.AssignDate = CommonObj.GenerateDatefromAge(CType(DetailsDatarow.Item("DateofMigrationDiff"), Integer))
                TextBoxReasonofMigration.Text = DetailsDatarow.Item("ReasonofMigration").ToString()
                TextBoxDegree.Text = DetailsDatarow.Item("Education").ToString()
                TextBoxBoard.Text = DetailsDatarow.Item("Board").ToString()
                TextBoxYear.Text = DetailsDatarow.Item("Year").ToString()
                DropDownListEmploymentStatus.SelectedIndex = DropDownListEmploymentStatus.Items.IndexOf(DropDownListEmploymentStatus.Items.FindByValue(DetailsDatarow.Item("EmploymentStatus")))
                DropDownListProfession.SelectedIndex = DropDownListProfession.Items.IndexOf(DropDownListProfession.Items.FindByValue(DetailsDatarow.Item("Profession").ToString()))
                DropDownListDegree.SelectedIndex = DropDownListDegree.Items.IndexOf(DropDownListDegree.Items.FindByValue(DetailsDatarow.Item("Degree").ToString()))
                TextBoxCompany.Text = DetailsDatarow.Item("CurrentEmployer").ToString()
                TextBoxExperience.Text = DetailsDatarow.Item("YrsofExp").ToString()
                TextBoxAnnualIncome.Text = DetailsDatarow.Item("AnnualIncome").ToString()
                PositionEmployeePanel()
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Sub PopulateProfessionDropDown()
        Dim Query As String = ""

        Query = "Select Data from MasterData where ID = 1"
        CommonObj.EstablishSQLConnection(Query, "Get")

        DropDownListProfession.DataSource = CommonObj.returnDataSet.Tables(0)
        DropDownListProfession.DataTextField = "Data"
        DropDownListProfession.DataValueField = "Data"
        DropDownListProfession.DataBind()

    End Sub

    Private Sub PopulateDegreeDropDown()
        Dim Query As String = ""

        Query = "Select Data from MasterData where ID = 2"
        CommonObj.EstablishSQLConnection(Query, "Get")

        DropDownListDegree.DataSource = CommonObj.returnDataSet.Tables(0)
        DropDownListDegree.DataTextField = "Data"
        DropDownListDegree.DataValueField = "Data"
        DropDownListDegree.DataBind()

    End Sub

    Private Function GetOtherDetailsbyRow() As DataRow
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

            Query = "Select * from OtherDetails where PinId = " & PinId.ToString()
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

    Protected Sub DropDownListEmploymentStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListEmploymentStatus.SelectedIndexChanged
        Try
            PositionEmployeePanel()
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Sub PositionEmployeePanel()
        Try
            If DropDownListEmploymentStatus.SelectedValue = 0 Then
                PanelEmployeed.Visible = False
                'TextBoxProfession.Text = ""
                TextBoxCompany.Text = ""
                TextBoxExperience.Text = ""
                TextBoxAnnualIncome.Text = ""
            Else
                PanelEmployeed.Visible = True
            End If
            LabelOtherDetails.Text = ""

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Try
            LabelOtherDetails.Text = ""

            If ValidationMemberInfo() Then
                Exit Sub
            End If

            If GenerateVPIN() Then
                LabelOtherDetails.Text = CommonObj.ShowMessageBox(DataUpdated, DetailsValue)
            Else
                LabelOtherDetails.Text = CommonObj.ShowMessageBox(TransactionError, DetailsValue)
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function ValidationMemberInfo() As Boolean
        Try
            If Trim(TextBoxReasonofMigration.Text) <> "" Then
                If WebUserControlDateofMigration.ValidateDate() Then
                    LabelOtherDetails.Text = "Incorrect Date. Please specify correct Date of Migration."
                    Return True
                End If

                If ValidateEducation(TextBoxReasonofMigration.Text, "Reason of Migration", True) Then
                    Return True
                End If
            End If

            If ValidateEducation(TextBoxDegree.Text, "Highest Degree", True) OrElse ValidateEducation(TextBoxBoard.Text, "Board/Unversity", True) Then
                Return True
            End If

            If ValidateNumericValue(TextBoxYear.Text, "Year of Passing", True) Then
                Return True
            End If

            If DropDownListEmploymentStatus.SelectedValue = 1 Then
                'If ValidateEducation(TextBoxProfession.Text, "Profession", True) OrElse ValidateEducation(TextBoxCompany.Text, "Company", True) Then
                If ValidateEducation(TextBoxCompany.Text, "Company", True) Then
                    Return True
                End If

                If ValidateNumericValue(TextBoxExperience.Text, "Years of Eperience", True) OrElse ValidateNumericValue(TextBoxAnnualIncome.Text, "Annual Income", True) Then
                    Return True
                End If
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function ValidateEducation(ByVal Name As String, ByVal Text As String, Optional ByVal iPersonalLabel As Boolean = False) As Boolean
        Try
            If Trim(Name) = "" Then
                LabelOtherDetails.Text = "Please specify " & Text & "."
                Return True
            End If
            For Each character As Char In Name
                If (Not Char.IsLetter(character) AndAlso Not character = " " AndAlso Not character = ".") AndAlso Not character = "(" AndAlso Not character = ")" Then
                    LabelOtherDetails.Text = Text & " can have Alphabets, space, (.) and Round brackets."
                    Return True
                End If
            Next
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function ValidateNumericValue(ByVal Name As String, ByVal Text As String, Optional ByVal iPersonalLabel As Boolean = False) As Boolean
        Try
            If Trim(Name) = "" Then
                LabelOtherDetails.Text = "Please specify " & Text & "."
                Return True
            End If
            For Each character As Char In Name
                If (Not Char.IsDigit(character)) Then
                    LabelOtherDetails.Text = Text & " is a numeric Field."
                    Return True
                End If
            Next
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function GenerateVPIN() As Integer
        Dim Query As String = ""
        Dim MigrationDateinDays As Integer
        Try
            MigrationDateinDays = CommonObj.CalculateAge(WebUserControlDateofMigration.BirthDay, WebUserControlDateofMigration.BirthMonth, WebUserControlDateofMigration.BirthYear)

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")

            VPIN = ""
            'VPIN = CType(CommonObj.GenerateVPIN, String)

            Query = "Update OtherDetails " & _
                    "Set VPIN = '" & VPIN & "' , " & _
                    " EmploymentStatus = " & DropDownListEmploymentStatus.SelectedValue.ToString() & " , " & _
                    " Education = '" & TextBoxDegree.Text.ToString() & "' , " & _
                    " Degree = '" & DropDownListDegree.SelectedValue.ToString() & "' , " & _
                    " Board = '" & TextBoxBoard.Text.ToString() & "' , " & _
                    " Year = " & TextBoxYear.Text.ToString() & " , " & _
                    " DateofMigrationDiff = " & MigrationDateinDays.ToString() & " , " & _
                    " ReasonofMigration = '" & TextBoxReasonofMigration.Text.ToString() & "' "

            If DropDownListEmploymentStatus.SelectedValue <> 0 Then
                Query = Query & " , " & _
                        " Profession = '" & DropDownListProfession.SelectedValue.ToString() & "' , " & _
                        " CurrentEmployer = '" & TextBoxCompany.Text.ToString() & "' , " & _
                        " YrsOfExp = " & TextBoxExperience.Text.ToString() & " , " & _
                        " AnnualIncome = " & TextBoxAnnualIncome.Text.ToString() & " "
            Else
                Query = Query & " , " & _
                        " Profession = '' , " & _
                        " CurrentEmployer = '' , " & _
                        " YrsOfExp = 0 , " & _
                        " AnnualIncome = 0 "
            End If
            Query = Query & " Where PinId = " & PinId.ToString()

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

    Protected Sub ButtonPropertySave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPropertySave.Click
        Try
            LabelPropertyDetails.Text = ""

            If ValidationMemberPropertyDetails() Then
                Exit Sub
            End If

            If GenerateVPINforProperty() Then
                LabelPropertyDetails.Text = CommonObj.ShowMessageBox(DataUpdated, DetailsValue)
                Response.Redirect("RedirecttoDetails.aspx?Details=" & DropDownListDetails.SelectedValue, False)
            Else
                LabelPropertyDetails.Text = CommonObj.ShowMessageBox(TransactionError, DetailsValue)
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function ValidationMemberPropertyDetails() As Boolean
        Try
            If ValidatePropertyDetails(DropDownListType.SelectedValue, "Property Type", True) Then
                Return True
            End If

            If ValidateSpecifications(TextBoxSpecification.Text, "Property Specification", True) Then
                Return True
            End If

            If ValidateSpecifications(TextBoxIdentification.Text, "Property Identification", True) Then
                Return True
            End If

            If ValidateCost(TextBoxCost.Text, "Property Cost", True) Then
                Return True
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function ValidatePropertyDetails(ByVal Name As String, ByVal Text As String, Optional ByVal iPersonalLabel As Boolean = False) As Boolean
        Try
            If Trim(Name) = "" Then
                LabelPropertyDetails.Text = "Please specify " & Text & "."
                Return True
            End If
            For Each character As Char In Name
                If (Not Char.IsLetter(character) AndAlso Not character = " " AndAlso Not character = ".") Then
                    LabelPropertyDetails.Text = Text & " can have Alphabets and space only."
                    Return True
                End If
            Next
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function ValidateSpecifications(ByVal Name As String, ByVal Text As String, Optional ByVal iPersonalLabel As Boolean = False) As Boolean
        Try
            If Trim(Name) = "" Then
                LabelPropertyDetails.Text = "Please specify " & Text & "."
                Return True
            End If
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function ValidateCost(ByVal Name As String, ByVal Text As String, Optional ByVal iPersonalLabel As Boolean = False) As Boolean
        Try
            If Trim(Name) = "" Then
                LabelPropertyDetails.Text = "Please specify " & Text & "."
                Return True
            End If
            For Each character As Char In Name
                If (Not Char.IsDigit(character)) Then
                    LabelPropertyDetails.Text = Text & " can have Digits only."
                    Return True
                End If
            Next
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function GenerateVPINforProperty() As Integer
        Try
            Dim Query As String = ""

            VPIN = ""
            'VPIN = CType(CommonObj.GenerateVPIN, String)

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")

            Query = "Insert Into PropertyDetails " & _
                     "(PINId, VPIN, Type, Specification, Identification, Cost) " & _
                     "Select " & _
                     PinId.ToString() & " , '" & _
                     VPIN & "' , '" & _
                     DropDownListType.SelectedValue & "' , '" & _
                     TextBoxSpecification.Text & "' , '" & _
                     TextBoxIdentification.Text & "' , " & _
                     TextBoxCost.Text & ""

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

    Protected Sub ButtonDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
        Try
            LabelPropertyDetails.Text = ""
            Dim Query As String

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")

            Query = "Select * from PropertyDetails where PinId = " & PinId.ToString()
            CommonObj.EstablishSQLConnection(Query, "Get")

            If TextBoxSNo.Text <= CommonObj.returnDataSet.Tables(0).Rows.Count Then
                Query = "Delete from PropertyDetails where PinId = " & PinId.ToString() & " and " & _
                "Identification = '" & CommonObj.returnDataSet.Tables(0).Rows(TextBoxSNo.Text - 1).Item("Identification") & "'"
                CommonObj.EstablishSQLConnection(Query, "Get")

                Query = "Update MemberInfo " & _
                        "Set LastUpdated = " & "GetDate() " & _
                        "Where PinId = " & PinId.ToString()
                CommonObj.EstablishSQLConnection(Query)

                LabelPropertyDetails.Text = CommonObj.ShowMessageBox(RecordDeleted, DetailsValue)
                Response.Redirect("RedirecttoDetails.aspx?Details=" & DropDownListDetails.SelectedValue, False)
            Else
                LabelPropertyDetails.Text = CommonObj.ShowMessageBox(RecordNotExists, DetailsValue)
            End If


        Catch ex As Exception
            CommonObj.ShowMessageBox(TransactionError)
        End Try
    End Sub

End Class
