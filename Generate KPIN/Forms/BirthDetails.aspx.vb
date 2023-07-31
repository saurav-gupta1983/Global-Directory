Imports System.Data

Partial Class BirthDetails
    Inherits System.Web.UI.Page

    Dim KPIN As String = ""
    Dim VPIN As String = ""
    Dim PinId As Integer
    Dim DataSet As New DataSet
    Dim DetailsValue As String = TITLE_BirthDetails
    Dim CommonObj As New CommonCode
    Dim DataUpdated As String = MSG_Details_Updated
    Dim TransactionError As String = MSG_Incomplete_Transaction
    Dim RecordDeleted As String = MSG_Delete_Record
    Dim RecordNotExists As String = MSG_Record_NOT_EXIST

    Dim NameDataTable As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            KPIN = Session("KPIN")
            LabelBirthDetails.Text = ""
            'KPIN = "3"

            Dim Query As String = ""

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            'LabelDetails.Text = CommonObj.returnDataSet.Tables(0).Rows(0).Item("FirstName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("MiddleName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("LastName") & " (" & _
            'KPIN & ")"

            PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")

            Query = "Select Replace(Name,'-',' ') As Name, 1 As isSibling, 0 As isMother From SiblingDetails Where PinId = " & PinId.ToString() & " and Sex = 0" & _
                    " Union " & _
                    "Select Replace(Name,'-',' ') As Name, 1 As isSibling, 1 As isMother From SiblingDetails Where PinId = " & PinId.ToString() & " and Sex = 1" & _
                    " Union " & _
                    "Select Replace(Name,'-',' ') As Name, 0 As isSibling, 0 As isMother From OffSpringDetails Where PinId = " & PinId.ToString() & " and Sex = 0" & _
                    " Union " & _
                    "Select Replace(Name,'-',' ') As Name, 0 As isSibling, 1 As isMother From OffSpringDetails Where PinId = " & PinId.ToString() & " and Sex = 1"
            CommonObj.EstablishSQLConnection(Query, "Get")

            NameDataTable = CommonObj.returnDataSet.Tables(0)

            If Not IsPostBack Then
                DropDownListDetails.SelectedIndex = DropDownListDetails.Items.IndexOf(DropDownListDetails.Items.FindByText(DetailsValue))

                DropDownListParentName.DataSource = NameDataTable
                DropDownListParentName.DataTextField = "Name"
                DropDownListParentName.DataValueField = "Name"
                DropDownListParentName.DataBind()
            End If


            'If Not IsPostBack Then
            '    GetContactDetails()
            'End If

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

    Protected Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Try
            LabelBirthDetails.Text = ""

            If ValidationMemberInfo() Then
                Exit Sub
            End If

            If GenerateVPIN() Then
                LabelBirthDetails.Text = CommonObj.ShowMessageBox(DataUpdated, DetailsValue)
                Response.Redirect("RedirecttoDetails.aspx?Details=" & DropDownListDetails.SelectedValue, False)
            Else
                LabelBirthDetails.Text = CommonObj.ShowMessageBox(TransactionError, DetailsValue)
            End If


        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
    End Sub

    Private Function ValidationMemberInfo() As Boolean
        Try

            Dim errorMessage As String = ""
            errorMessage = WebUserControlNameofPerson.ValidateName(" Name", True)
            If errorMessage <> "" Then
                LabelBirthDetails.Text = errorMessage
                Return True
            End If

            If WebUserControlDateofBirth.ValidateDate() Then
                LabelBirthDetails.Text = "Incorrect Date. Please specify correct Date of Birth"
                Return True
            End If


            'If ValidateName(TextBoxName.Text, "Name", True) Then
            '    Return True
            'End If

            'If ValidateAge(TextBoxAge.Text, "Age", True) Then
            '    Return True
            'End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    'Private Function ValidateName(ByVal Name As String, ByVal Text As String, Optional ByVal iPersonalLabel As Boolean = False) As Boolean
    '    Try
    '        If Trim(Name) = "" Then
    '            LabelBirthDetails.Text = "Please specify " & Text & "."
    '            Return True
    '        End If
    '        For Each character As Char In Name
    '            If (Not Char.IsLetter(character) AndAlso Not character = " " AndAlso Not character = ".") Then
    '                LabelBirthDetails.Text = Text & " can have Alphabets and space only."
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
    '            LabelBirthDetails.Text = "Please specify " & Text & "."
    '            Return True
    '        End If
    '        For Each character As Char In Name
    '            If (Not Char.IsDigit(character)) Then
    '                LabelBirthDetails.Text = Text & " can have Digits only."
    '                Return True
    '            End If
    '        Next
    '    Catch ex As Exception
    '        CommonObj.ShowMessageBox(ex.Message, "Critical")
    '    End Try
    '    Return False
    'End Function

    Private Function GenerateVPIN() As Integer
        Try
            Dim Query As String = ""

            VPIN = ""
            'VPIN = CType(CommonObj.GenerateVPIN, String)

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")

            Dim dr As DataRow = NameDataTable.Select("Name = '" & DropDownListParentName.SelectedValue & "'")(0)

            Query = "Insert Into Birthsafter1989 " & _
                     "(PINId, VPIN, Name, Sex, AgeDiff, isSibling, isMother, ParentName) " & _
                     "Select " & _
                     PinId.ToString() & " , '" & _
                     VPIN & "' , '" & _
                     WebUserControlNameofPerson.Name & "' , " & _
                     DropDownListSex.SelectedValue & " , " & _
                     CommonObj.CalculateAge(WebUserControlDateofBirth.BirthDay, WebUserControlDateofBirth.BirthMonth, WebUserControlDateofBirth.BirthYear) & " , " & _
                     dr.Item("isSibling") & " , " & _
                     dr.Item("isMother") & " , '" & _
                     DropDownListParentName.SelectedValue & "'"

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
            LabelBirthDetails.Text = ""
            Dim Query As String

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")

            Query = "Select * from Birthsafter1989 where PinId = " & PinId.ToString()
            CommonObj.EstablishSQLConnection(Query, "Get")

            If TextBoxSNo.Text <= CommonObj.returnDataSet.Tables(0).Rows.Count Then
                Query = "Delete from Birthsafter1989 where PinId = " & PinId.ToString() & " and " & _
                "Name = '" & CommonObj.returnDataSet.Tables(0).Rows(TextBoxSNo.Text - 1).Item("Name") & "'"
                CommonObj.EstablishSQLConnection(Query, "Get")

                Query = "Update MemberInfo " & _
                        "Set LastUpdated = " & "GetDate() " & _
                        "Where PinId = " & PinId.ToString()
                CommonObj.EstablishSQLConnection(Query)

                LabelBirthDetails.Text = CommonObj.ShowMessageBox(RecordDeleted, DetailsValue)
                Response.Redirect("RedirecttoDetails.aspx?Details=" & DropDownListDetails.SelectedValue, False)
            Else
                LabelBirthDetails.Text = CommonObj.ShowMessageBox(RecordNotExists, DetailsValue)
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(TransactionError)
        End Try
    End Sub
End Class
