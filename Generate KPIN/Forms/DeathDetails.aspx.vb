Imports System.Data

Partial Class DeathDetails
    Inherits System.Web.UI.Page

    Dim KPIN As String = ""
    Dim VPIN As String = ""
    Dim PinId As Integer
    Dim DataSet As New DataSet
    Dim DetailsValue As String = TITLE_DeathDetails
    Dim CommonObj As New CommonCode
    Dim DataUpdated As String = MSG_Details_Updated
    Dim TransactionError As String = MSG_Incomplete_Transaction
    Dim RecordDeleted As String = MSG_Delete_Record
    Dim RecordNotExists As String = MSG_Record_NOT_EXIST

    Dim FamilyDetailsDataTable As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            KPIN = Session("KPIN")
            LabelDeathDetails.Text = ""

            Dim Query As String = ""

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            ''LabelDetails.Text = CommonObj.returnDataSet.Tables(0).Rows(0).Item("FirstName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("MiddleName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("LastName") & " (" & _
            'KPIN & ")"

            PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")

            Query = "Select '' As Name, 0 Sex, '' As Relation " & _
                    " Union All " & _
                    " Select Replace(FathersName,'-',' ') As Name, 0 As Sex, 'Father' As Relation from FamilyDetails Where PinId = " & PinId.ToString() & _
                    " Union All " & _
                    "Select Replace(MothersName,'-',' ') As Name, 1 As Sex, 'Mother' As Relation from FamilyDetails Where PinId = " & PinId.ToString() & _
                    " Union All " & _
                    "Select Replace(Name,'-',' '), Sex, (Case Sex When 0 Then 'Brother' Else 'Sister' End) As Relation from SiblingDetails Where PinId = " & PinId.ToString() & _
                    " Union All " & _
                    "Select Replace(Name,'-',' '), Sex, (Case Sex When 0 Then 'Son' Else 'Daughter' End) As Relation from OffSpringDetails Where PinId = " & PinId.ToString() & _
                    " Union All " & _
                    "Select 'Others' As Name, 0 Sex, 'Others' As Relation "
            CommonObj.EstablishSQLConnection(Query, "Get")

            FamilyDetailsDataTable = CommonObj.returnDataSet.Tables(0)

            If Not IsPostBack Then
                DropDownListDetails.SelectedIndex = DropDownListDetails.Items.IndexOf(DropDownListDetails.Items.FindByText(DetailsValue))

                DropDownListName.DataSource = FamilyDetailsDataTable
                DropDownListName.DataTextField = "Name"
                DropDownListName.DataValueField = "Name"
                DropDownListName.DataBind()

                ResetComponents()
                ButtonSave.Enabled = False
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Protected Sub DropDownListDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListDetails.SelectedIndexChanged
        Try
            Response.Redirect("RedirecttoDetails.aspx?Details=" & DropDownListDetails.SelectedValue, False)
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Protected Sub DropDownListName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListName.SelectedIndexChanged
        Try
            If DropDownListName.SelectedValue = "" Then
                ResetComponents()
                ButtonSave.Enabled = False
            ElseIf DropDownListName.SelectedValue = "Others" Then
                ResetComponents("True")
                ButtonSave.Enabled = True
            Else
                ResetComponents()

                Dim dr As DataRow

                dr = FamilyDetailsDataTable.Select("Name = '" & DropDownListName.SelectedValue & "'")(0)
                TextBoxRelation.Text = dr.Item("Relation")
                DropDownListSex.SelectedIndex = DropDownListSex.Items.IndexOf(DropDownListSex.Items.FindByValue(dr.Item("Sex")))
                WebUserControlDateofDeath.Enabled = True
                TextBoxReason.Enabled = True
                ButtonSave.Enabled = True
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Try
            LabelDeathDetails.Text = ""

            If ValidationMemberInfo() Then
                Exit Sub
            End If

            If GenerateVPIN() Then
                LabelDeathDetails.Text = CommonObj.ShowMessageBox(DataUpdated, DetailsValue)
                Response.Redirect("RedirecttoDetails.aspx?Details=" & DropDownListDetails.SelectedValue, False)
            Else
                LabelDeathDetails.Text = CommonObj.ShowMessageBox(TransactionError, DetailsValue)
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function ValidationMemberInfo() As Boolean
        Try
            'If ValidateName(TextBoxName.Text, "Name", True) Then
            '    Return True
            'End If

            'If ValidateAge(TextBoxAge.Text, "Age", True) Then
            '    Return True
            'End If
            If DropDownListName.SelectedValue = "Others" Then
                Dim errorMessage As String = ""
                errorMessage = WebUserControlNameofPerson.ValidateName(" Name", True)
                If errorMessage <> "" Then
                    LabelDeathDetails.Text = errorMessage
                    Return True
                End If

                If ValidateReasons(TextBoxRelation.Text, "Relation", True) Then
                    Return True
                End If
            End If

            If WebUserControlDateofDeath.ValidateDate() Then
                LabelDeathDetails.Text = "Incorrect Date. Please specify correct Date of Birth"
                Return True
            End If

            If ValidateReasons(TextBoxReason.Text, "Reason of Death", True) Then
                Return True
            End If


        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    'Private Function ValidateName(ByVal Name As String, ByVal Text As String, Optional ByVal iPersonalLabel As Boolean = False) As Boolean
    '    Try
    '        If Trim(Name) = "" Then
    '            LabelDeathDetails.Text = "Please specify " & Text & "."
    '            Return True
    '        End If
    '        For Each character As Char In Name
    '            If (Not Char.IsLetter(character) AndAlso Not character = " " AndAlso Not character = ".") Then
    '                LabelDeathDetails.Text = Text & " can have Alphabets and space only."
    '                Return True
    '            End If
    '        Next
    '    Catch ex As Exception
    '        CommonObj.ShowMessageBox(ex.Message, "Critical")
    '    End Try
    '    Return False
    'End Function

    'Private Function ValidateAge(ByVal Name As String, ByVal Text As String, Optional ByVal iPersonalLabel As Boolean = False) As Boolean
    '    Try
    '        If Trim(Name) = "" Then
    '            LabelDeathDetails.Text = "Please specify " & Text & "."
    '            Return True
    '        End If
    '        For Each character As Char In Name
    '            If (Not Char.IsDigit(character)) Then
    '                LabelDeathDetails.Text = Text & " can have Digits only."
    '                Return True
    '            End If
    '        Next
    '    Catch ex As Exception
    '        CommonObj.ShowMessageBox(ex.Message, "Critical")
    '    End Try
    '    Return False
    'End Function

    Private Function ValidateReasons(ByVal Name As String, ByVal Text As String, Optional ByVal iPersonalLabel As Boolean = False) As Boolean
        Try
            If Trim(Name) = "" Then
                LabelDeathDetails.Text = "Please specify " & Text & "."
                Return True
            End If
            'For Each character As Char In Name
            '    If (Not Char.IsLetter(character) AndAlso Not Char.IsDigit(character) AndAlso Not character = " " AndAlso Not character = ".") Then
            '        LabelDeathDetails.Text = Text & " can have Alphabets, Digits and space only."
            '        Return True
            '    End If
            'Next
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

            Query = "Insert Into Deathsafter1989 " & _
                     "(PINId, VPIN, Name, Sex, AgeDiff, Reasons, Relation) " & _
                     "Select " & _
                     PinId.ToString() & " , '" & _
                     VPIN & "' , '" & _
                     IIf(DropDownListName.SelectedValue = "Others", WebUserControlNameofPerson.Name, DropDownListName.SelectedValue.Replace(" ", "-")) & "' , '" & _
                     DropDownListSex.SelectedValue & "' , '" & _
                     CommonObj.CalculateAge(WebUserControlDateofDeath.BirthDay, WebUserControlDateofDeath.BirthMonth, WebUserControlDateofDeath.BirthYear) & "' , '" & _
                     TextBoxReason.Text & "' , '" & _
                     TextBoxRelation.Text & "'"

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
            LabelDeathDetails.Text = ""
            Dim Query As String

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")

            Query = "Select * from Deathsafter1989 where PinId = " & PinId.ToString()
            CommonObj.EstablishSQLConnection(Query, "Get")

            If TextBoxSNo.Text <= CommonObj.returnDataSet.Tables(0).Rows.Count Then
                Query = "Delete from Deathsafter1989 where PinId = " & PinId.ToString() & " and " & _
                "Name = '" & CommonObj.returnDataSet.Tables(0).Rows(TextBoxSNo.Text - 1).Item("Name") & "'"
                CommonObj.EstablishSQLConnection(Query, "Get")

                Query = "Update MemberInfo " & _
                        "Set LastUpdated = " & "GetDate() " & _
                        "Where PinId = " & PinId.ToString()
                CommonObj.EstablishSQLConnection(Query)

                LabelDeathDetails.Text = CommonObj.ShowMessageBox(RecordDeleted, DetailsValue)
                Response.Redirect("RedirecttoDetails.aspx?Details=" & DropDownListDetails.SelectedValue, False)
            Else
                LabelDeathDetails.Text = CommonObj.ShowMessageBox(RecordNotExists, DetailsValue)
            End If


        Catch ex As Exception
            CommonObj.ShowMessageBox(TransactionError)
        End Try
    End Sub

    Private Sub ResetComponents(Optional ByVal isEnable As Boolean = False)
        TextBoxRelation.Text = ""
        TextBoxRelation.Enabled = isEnable
        WebUserControlNameofPerson.Name = "--"
        WebUserControlNameofPerson.Enabled = isEnable
        WebUserControlNameofPerson.Visible = isEnable
        DropDownListSex.SelectedIndex = DropDownListSex.Items.IndexOf(DropDownListSex.Items.FindByValue(0))
        DropDownListSex.Enabled = isEnable
        WebUserControlDateofDeath.AssignDate = CommonObj.referenceDate
        WebUserControlDateofDeath.Enabled = isEnable
        TextBoxReason.Text = ""
        TextBoxReason.Enabled = isEnable
        LabelDeathDetails.Text = ""
    End Sub

End Class
