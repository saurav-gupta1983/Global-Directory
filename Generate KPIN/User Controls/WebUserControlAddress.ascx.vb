
Partial Class WebUserControlAddress
    Inherits System.Web.UI.UserControl

    Dim errorMessage As String = ""
    Dim FullAddress As String = ""

    Public Property Street() As String
        Get
            Return Trim(TextBoxAddress.Text)
        End Get
        Set(ByVal value As String)
            TextBoxAddress.Text = value
        End Set
    End Property

    Public Property City() As String
        Get
            Return Trim(TextBoxCity.Text)
        End Get
        Set(ByVal value As String)
            TextBoxCity.Text = value
        End Set
    End Property

    Public Property State() As String
        Get
            Return Trim(TextBoxState.Text)
        End Get
        Set(ByVal value As String)
            TextBoxState.Text = value
        End Set
    End Property

    Public Property Country() As String
        Get
            Return Trim(TextBoxCountry.Text)
        End Get
        Set(ByVal value As String)
            TextBoxCountry.Text = value
        End Set
    End Property

    Public Property Address() As String
        Get
            Return Street() & "@" & City() & "@" & State() & "@" & Country()
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                TextBoxAddress.Text = value.Split("@")(0)
                TextBoxCity.Text = value.Split("@")(1)
                TextBoxState.Text = value.Split("@")(2)
                TextBoxCountry.Text = value.Split("@")(3)
            End If
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return TextBoxAddress.Enabled
        End Get
        Set(ByVal value As Boolean)
            TextBoxAddress.Enabled = value
            TextBoxCity.Enabled = value
            TextBoxState.Enabled = value
            TextBoxCountry.Enabled = value
        End Set
    End Property

    Public Property Visble() As Boolean
        Get
            Return TextBoxAddress.Visible
        End Get
        Set(ByVal value As Boolean)
            TextBoxAddress.Visible = value
            TextBoxCity.Visible = value
            TextBoxState.Visible = value
            TextBoxCountry.Visible = value
        End Set
    End Property

    Public Property CheckBoxVisble() As Boolean
        Get
            Return CheckBoxSame.Visible
        End Get
        Set(ByVal value As Boolean)
            CheckBoxSame.Visible = value
        End Set
    End Property

    Public Property CheckBoxStatus() As Boolean
        Get
            Return CheckBoxSame.Checked
        End Get
        Set(ByVal value As Boolean)
            CheckBoxSame.Checked = value
        End Set
    End Property

    Public Function ValidateAddress(ByVal ComponentName As String) As String
        If CheckBoxSame.Checked = True Then
            Return ""
        End If
        errorMessage = ""
        errorMessage = ValidateStreet(Street(), "Address")
        If errorMessage <> "" Then
            Return errorMessage & " for " & ComponentName & "."
        End If
        errorMessage = Validate(City(), "City")
        If errorMessage <> "" Then
            Return errorMessage & " for " & ComponentName & "."
        End If
        errorMessage = Validate(State(), "State")
        If errorMessage <> "" Then
            Return errorMessage & " for " & ComponentName & "."
        End If
        errorMessage = Validate(Country(), "Country")
        If errorMessage <> "" Then
            Return errorMessage & " for " & ComponentName & "."
        End If
        If Street.Length() + City.Length() + State.Length() + Country.Length() + 3 > 70 Then
            Return ComponentName & " can not have length greater than 70."
        End If
        Return ""
    End Function

    Private Function Validate(ByVal Name As String, ByVal Text As String) As String
        Try
            If Name = "" Then
                Return "Please specify " & Text
            End If
            For Each character As Char In Name
                If (Not Char.IsLetter(character) AndAlso Not character = " ") Then
                    Return Text & " can have Alphabets and space only"
                End If
            Next
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Private Function ValidateStreet(ByVal Name As String, ByVal Text As String) As String
        Try
            If Trim(Name) = "" Then
                Return "Please specify " & Text
            End If
            For Each character As Char In Name
                If (Not Char.IsLetter(character) AndAlso Not Char.IsDigit(character) AndAlso Not character = " " AndAlso Not character = "-" _
                AndAlso Not character = "/" AndAlso Not character = "\") AndAlso Not character = "," Then
                    Return Text & " allows Alphabets, space and (-), (/), (\), (,)."
                End If
            Next
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Protected Sub CheckBoxSame_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxSame.CheckedChanged
        Try
            If CheckBoxSame.Checked Then
                FullAddress = Address()
                TextBoxAddress.Text = ""
                TextBoxCity.Text = ""
                TextBoxState.Text = ""
                TextBoxCountry.Text = ""
            Else
                Address = FullAddress
                FullAddress = ""
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
