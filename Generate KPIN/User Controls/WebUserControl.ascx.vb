Imports System.Web.UI
Imports System.Globalization

Partial Class WebUserControl
    Inherits System.Web.UI.UserControl

    Dim Style As CssStyleCollection
    Dim CommonObj As New CommonCode

    Property BirthDay() As Integer
        Get
            Return DropDownListDate.Text
        End Get
        Set(ByVal value As Integer)
            DropDownListDate.SelectedIndex = DropDownListDate.Items.IndexOf(DropDownListDate.Items.FindByValue(value))
        End Set
    End Property

    Property BirthMonth() As Integer
        Get
            Return DropDownListMonth.SelectedValue
        End Get
        Set(ByVal value As Integer)
            'DropDownListMonth.SelectedIndex = value - 1
            DropDownListMonth.SelectedIndex = DropDownListMonth.Items.IndexOf(DropDownListMonth.Items.FindByValue(value))
        End Set
    End Property

    Property BirthYear() As Integer
        Get
            Return DropDownListYear.Text
        End Get
        Set(ByVal value As Integer)
            DropDownListYear.SelectedIndex = DropDownListYear.Items.IndexOf(DropDownListYear.Items.FindByValue(value))
        End Set
    End Property

    Property Enabled() As Boolean
        Get
            Return DropDownListYear.Enabled
        End Get
        Set(ByVal value As Boolean)
            DropDownListYear.Enabled = value
            DropDownListMonth.Enabled = value
            DropDownListDate.Enabled = value
            LabelDate.Enabled = value
            LabelMonth.Enabled = value
            LabelYear.Enabled = value
        End Set
    End Property

    Property AssignDate() As DateTime
        Get
            Return System.DateTime.Now()
        End Get
        Set(ByVal value As DateTime)
            BirthDay = value.Day
            BirthMonth = value.Month
            BirthYear = value.Year
        End Set
    End Property

    Public Function ValidateDate() As Boolean
        Dim Month, Year, Day As Integer
        Day = BirthDay
        Month = BirthMonth
        Year = BirthYear
        Try
            If Month = 2 Then
                If Year Mod 4 = 0 Then
                    If Day > 29 Then
                        Return True
                    End If
                Else
                    If Day > 28 Then
                        Return True
                    End If
                End If
            ElseIf Month = 4 OrElse Month = 6 OrElse Month = 9 OrElse Month = 11 Then
                If Day > 30 Then
                    Return True
                End If
            Else
                If Day > 31 Then
                    Return True
                End If
            End If
        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Public Function GetDate() As DateTime
        Dim culture As CultureInfo = New CultureInfo("en-Us", True)

        Return DateTime.Parse(BirthMonth.ToString() & "-" & BirthDay.ToString() & "-" & BirthYear.ToString(), Culture, DateTimeStyles.NoCurrentDateDefault)
    End Function
End Class
