
Partial Class WebUserControlName
    Inherits System.Web.UI.UserControl

    Dim errorMessage As String = ""

    Public Property FirstName() As String
        Get
            Return Trim(TextBoxFirstName.Text)
        End Get
        Set(ByVal value As String)
            TextBoxFirstName.Text = value
        End Set
    End Property

    Public Property MiddleName() As String
        Get
            Return Trim(TextBoxMiddleName.Text)
        End Get
        Set(ByVal value As String)
            TextBoxMiddleName.Text = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return Trim(TextBoxLastName.Text)
        End Get
        Set(ByVal value As String)
            TextBoxLastName.Text = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return FirstName() & "-" & MiddleName() & "-" & LastName()
        End Get
        Set(ByVal value As String)
            If value.ToString() <> "" Then
                TextBoxFirstName.Text = value.Split("-")(0)
                TextBoxMiddleName.Text = value.Split("-")(1)
                TextBoxLastName.Text = value.Split("-")(2)
            End If
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return TextBoxFirstName.Enabled
        End Get
        Set(ByVal value As Boolean)
            TextBoxFirstName.Enabled = value
            TextBoxMiddleName.Enabled = value
            TextBoxLastName.Enabled = value
        End Set
    End Property

    Public Property Visble() As Boolean
        Get
            Return PanelName.Visible
        End Get
        Set(ByVal value As Boolean)
            PanelName.Visible = False
        End Set
    End Property

    Public Function ValidateName(ByVal ComponentName As String, Optional ByVal Mandatory As Boolean = True) As String
        errorMessage = ""
        errorMessage = Validate(FirstName(), Mandatory, "First Name")
        If errorMessage <> "" Then
            Return errorMessage & ComponentName.Replace(" Name", " First Name") & "."
        End If
        errorMessage = Validate(MiddleName(), Mandatory, "Middle Name")
        If errorMessage <> "" Then
            Return errorMessage & ComponentName.Replace(" Name", " Middle Name") & "."
        End If
        errorMessage = Validate(LastName(), Mandatory, "Last Name")
        If errorMessage <> "" Then
            Return errorMessage & ComponentName.Replace(" Name", " Last Name") & "."
        End If
        If Name().Length > 30 Then
            Return ComponentName & " can not have length greater than 30."
        End If
        Return ""
    End Function

    Private Function Validate(ByVal Name As String, ByVal Mandatory As Boolean, Optional ByVal Text As String = "") As String
        If Mandatory = True AndAlso Name = "" AndAlso Text <> "Middle Name" Then
            Return "Please specify "
        End If

        If Name <> "" AndAlso Name.Length <= 2 Then
            Return "Initials not allowed. Use full name for "
        End If
        For Each character As Char In Name
            If (Not Char.IsLetter(character) AndAlso Not character = " ") Then
                Return "Use only Alphabets and space for "
            End If
        Next
        Return ""
    End Function

End Class
