Imports System.Data

Partial Class OffspringDetails
    Inherits System.Web.UI.Page

    Dim KPIN As String = ""
    Dim VPIN As String = ""
    Dim PinId As Integer
    Dim DataSet As New DataSet
    Dim DetailsValue As String = TITLE_OffspringDetails
    Dim CommonObj As New CommonCode
    Dim DataUpdated As String = MSG_Details_Updated
    Dim TransactionError As String = MSG_Incomplete_Transaction
    Dim RecordDeleted As String = MSG_Delete_Record
    Dim RecordNotExists As String = MSG_Record_NOT_EXIST


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            KPIN = Session("KPIN")
            LabelOffspringDetails.Text = ""

            If Not IsPostBack Then
                DropDownListDetails.SelectedIndex = DropDownListDetails.Items.IndexOf(DropDownListDetails.Items.FindByText(DetailsValue))
            End If

            Dim Query As String = ""

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            'LabelDetails.Text = CommonObj.returnDataSet.Tables(0).Rows(0).Item("FirstName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("MiddleName") & " " & _
            'CommonObj.returnDataSet.Tables(0).Rows(0).Item("LastName") & " (" & _
            'KPIN & ")"
           

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
            LabelOffspringDetails.Text = ""

            If ValidationMemberInfo() Then
                Exit Sub
            End If

            If GenerateVPIN() Then
                LabelOffspringDetails.Text = CommonObj.ShowMessageBox(DataUpdated, DetailsValue)
                Response.Redirect("RedirecttoDetails.aspx?Details=" & DropDownListDetails.SelectedValue, False)
            Else
                LabelOffspringDetails.Text = CommonObj.ShowMessageBox(TransactionError, DetailsValue)
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

            Dim errorMessage As String = ""
            errorMessage = WebUserControlName.ValidateName(" Name", True)
            If errorMessage <> "" Then
                LabelOffspringDetails.Text = errorMessage
                Return True
            End If


            If WebUserControlDateofBirth.ValidateDate() Then
                LabelOffspringDetails.Text = "Incorrect Date. Please specify correct Date of Birth"
                Return True
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Private Function ValidateName(ByVal Name As String, ByVal Text As String, Optional ByVal iPersonalLabel As Boolean = False) As Boolean
        Try
            If Trim(Name) = "" Then
                LabelOffspringDetails.Text = "Please specify " & Text & "."
                Return True
            End If
            For Each character As Char In Name
                If (Not Char.IsLetter(character) AndAlso Not character = " " AndAlso Not character = ".") Then
                    LabelOffspringDetails.Text = Text & " can have Alphabets and space only."
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

            Query = "Insert Into OffspringDetails " & _
                     "(PINId, VPIN, Name, Sex, AgeDiff) " & _
                     "Select " & _
                     PinId.ToString() & " , '" & _
                     VPIN & "' , '" & _
                    WebUserControlName.Name & "' , '" & _
                     DropDownListSex.SelectedValue & "' , '" & _
                      CommonObj.CalculateAge(WebUserControlDateofBirth.BirthDay, WebUserControlDateofBirth.BirthMonth, WebUserControlDateofBirth.BirthYear) & "' "

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
            LabelOffspringDetails.Text = ""
            Dim deleteDataRow As DataRow = Nothing
            Dim Name As String
            Dim AgeinDays As Integer
            Dim Query As String

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")

            Query = "Select * from OffspringDetails where PinId = " & PinId.ToString()
            CommonObj.EstablishSQLConnection(Query, "Get")

            If TextBoxSNo.Text <= CommonObj.returnDataSet.Tables(0).Rows.Count Then
                deleteDataRow = CommonObj.returnDataSet.Tables(0).Rows(TextBoxSNo.Text - 1)
                Name = deleteDataRow("Name")
                AgeinDays = deleteDataRow("AgeDiff")

                'Query = "Select * from FamilyDetails where PinId = " & PinId.ToString()
                'CommonObj.EstablishSQLConnection(Query, "Get")
                'FathersName = CommonObj.returnDataSet.Tables(0).Rows(0).Item("FathersName")
                'MothersName = CommonObj.returnDataSet.Tables(0).Rows(0).Item("MothersName")

                Query = "Select * from MemberInfo where KPIN = '" & CommonObj.GenerateKPIN(Name.Split("-")(0), Name.Split("-")(2), AgeinDays) & "'"
                CommonObj.EstablishSQLConnection(Query, "Get")

                If CommonObj.returnDataSet.Tables(0).Rows.Count > 0 Then
                    LabelOffspringDetails.Text = "Selected Record cannot be deleted as Record exists for it."
                Else
                    Query = "Delete from OffSpringDetails where PinId = " & PinId.ToString() & " and " & _
                    "Name = '" & Name & "'"
                    CommonObj.EstablishSQLConnection(Query)

                    Query = "Update MemberInfo " & _
                            "Set LastUpdated = " & "GetDate() " & _
                            "Where PinId = " & PinId.ToString()
                    CommonObj.EstablishSQLConnection(Query)

                    LabelOffspringDetails.Text = CommonObj.ShowMessageBox(RecordDeleted, DetailsValue)
                    Response.Redirect("RedirecttoDetails.aspx?Details=" & DropDownListDetails.SelectedValue, False)
                End If
            Else
                LabelOffspringDetails.Text = CommonObj.ShowMessageBox(RecordNotExists, DetailsValue)
            End If


        Catch ex As Exception
            CommonObj.ShowMessageBox(TransactionError)
        End Try
    End Sub
End Class
