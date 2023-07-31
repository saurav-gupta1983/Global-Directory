Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Box
    Inherits System.Web.UI.UserControl

    Dim MemberName As String
    Dim MemberID As String
    Dim data As MemberDetails

    Property Member() As MemberDetails
        Get
            Return data
        End Get
        Set(ByVal value As MemberDetails)
            data = value
        End Set
    End Property

    Public Sub Bind()
        Dim CommonObj As New CommonCode

        PanelBox.Visible = data.ShowBox
        PanelLines.Visible = data.ShowLines
        RightLine.Visible = data.showRightLine
        LeftLine.Visible = data.showLeftLine
        VerticalLineBox.Visible = data.showVerticalLineBox

        If data.ShowBox Then
            If data.MemberID = 0 Then
                MemberLabel.Visible = True
                MemberLink.Visible = False
                MemberLabel.Text = data.Member.Replace("--", " ").Replace("-", " ")
            Else
                MemberLabel.Visible = False
                MemberLink.Visible = True
                MemberLink.Text = data.Member.Replace("--", " ").Replace("-", " ")
                MemberLink.NavigateUrl = "../Forms/Orgchart.aspx?KPIN=" & data.MemberKPIN
                If data.PhotoImage = 1 Then
                    Photo.Src = ("../Forms/Upload.aspx" & "?PinId=") + data.MemberID.ToString()
                End If
            End If

            KPIN.Text = data.MemberKPIN.Replace("--", " ").Replace("-", " ")
            MotherName.Text = data.Mother.Replace("--", " ").Replace("-", " ")

            If data.DateofBirth <> 0 Then
                DOB.Text = CommonObj.GenerateDatefromAge(data.DateofBirth)
            End If

            If data.Spouse <> "" Then
                SpouseName.Text = data.Spouse.Replace("--", " ").Replace("-", " ")
            End If

            LabelCity.Text = data.MemberCity

        End If
    End Sub

End Class
