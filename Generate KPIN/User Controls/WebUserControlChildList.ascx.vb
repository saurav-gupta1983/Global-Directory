Imports System.Data

Partial Class WebUserControlChildList
    Inherits System.Web.UI.UserControl

    Dim MemberName As String
    Dim MemberID As String
    Dim data As DataTable
    Dim CommonObj As New CommonCode

    Property Member() As DataTable
        Get
            Return data
        End Get
        Set(ByVal value As DataTable)
            data = value
        End Set
    End Property

    Public Sub Bind()
        Try
            Dim Member As New MemberDetails
            CreateMemberDetailsObj(Member, data.Select("Levels=1")(0))

            ParentBox.Member = Member
            ParentBox.Bind()

            SetBoxProperties(data.Select("Levels=2"), "Sibling")
            If data.Select("Levels=3").Length = 0 Then
                ChildLine.Visible = False
            End If
            SetBoxProperties(data.Select("Levels=3"), "Child")

        Catch ex As Exception
            Throw (ex)

        End Try
    End Sub

    Public Sub SetBoxProperties(ByVal Box() As DataRow, ByVal FindBox As String)
        If Box.Length = 1 Then
            If FindBox = "Sibling" Then
                SiblingLine.Visible = False
            Else
                ChildLine.Visible = False
            End If
        End If

        Dim selectBox As Integer = System.Math.Ceiling(5 - (Box.Length() / 2))
        Dim Record As Integer = 0

        For Count As Integer = 1 To 9
            Dim Child As Box
            Child = PanelChildList.FindControl(FindBox & Count.ToString())

            Dim Member As New MemberDetails
            If Count = selectBox And Record < Box.Length Then
                CreateMemberDetailsObj(Member, Box(Record))
                If (Record = 0) Then
                    Member.showLeftLine = False
                End If
                If (Record + 1 = Box.Length) Then
                    Member.showRightLine = False
                End If
                If Count = 5 Then
                    Member.showVerticalLineBox = True
                End If
                Record += 1
                selectBox += 1
            Else
                Member.ShowBox = False
            End If

            Child.Member = Member
            Child.Bind()

        Next

    End Sub

    Private Sub CreateMemberDetailsObj(ByRef Member As MemberDetails, ByVal DataRow As DataRow)
        Try
            Member.DateofBirth = DataRow("DateofBirth")
            Member.Member = DataRow("MemberName")
            Member.MemberID = DataRow("PinId")
            Member.MemberKPIN = DataRow("KPIN")
            Member.Mother = DataRow("MotherName")
            Member.PhotoImage = DataRow("Photo")
            Member.Spouse = DataRow("SpouseName")
            Member.MemberCity = DataRow("City")

            If DataRow("Levels") = 1 Then
                Member.ShowBox = True
            Else
                Member.ShowLines = True
                Member.ShowBox = True
                Member.showLeftLine = True
                Member.showRightLine = True
            End If

        Catch ex As Exception
            CommonObj.ShowMessageBox(ex.Message.ToString(), "Critical")
        End Try
    End Sub

End Class
