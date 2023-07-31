Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class MemberDetails

    Dim MemberName As String
    Dim ID As Integer
    Dim KPIN As String
    Dim Photo As Integer
    Dim SpouseName As String
    Dim MotherName As String
    Dim DOB As Integer
    Dim City As String

    'Dim Siblings As List(Of MemberDetails)
    'Dim Offspring As List(Of MemberDetails)

    Dim showPanelLines As Boolean
    Dim showLeftLines As Boolean
    Dim showRightLines As Boolean
    Dim showPanelBox As Boolean
    Dim showVerticalLine As Boolean

    Property Member() As String
        Get
            Return MemberName
        End Get
        Set(ByVal value As String)
            MemberName = value
        End Set
    End Property
    Property MemberCity() As String
        Get
            Return City
        End Get
        Set(ByVal value As String)
            City = value
        End Set
    End Property
    Property MemberKPIN() As String
        Get
            Return KPIN
        End Get
        Set(ByVal value As String)
            KPIN = value
        End Set
    End Property
    Property PhotoImage() As Integer
        Get
            Return Photo
        End Get
        Set(ByVal value As Integer)
            Photo = value
        End Set
    End Property
    Property Spouse() As String
        Get
            Return SpouseName
        End Get
        Set(ByVal value As String)
            SpouseName = value
        End Set
    End Property
    Property Mother() As String
        Get
            Return MotherName
        End Get
        Set(ByVal value As String)
            MotherName = value
        End Set
    End Property
    Property DateofBirth() As String
        Get
            Return DOB
        End Get
        Set(ByVal value As String)
            DOB = value
        End Set
    End Property
    Property ShowLines() As Boolean
        Get
            Return showPanelLines
        End Get
        Set(ByVal value As Boolean)
            showPanelLines = value
        End Set
    End Property
    Property ShowBox() As Boolean
        Get
            Return showPanelBox
        End Get
        Set(ByVal value As Boolean)
            showPanelBox = value
        End Set
    End Property
    Property showLeftLine() As Boolean
        Get
            Return showLeftLines
        End Get
        Set(ByVal value As Boolean)
            showLeftLines = value
        End Set
    End Property
    Property showVerticalLineBox() As Boolean
        Get
            Return showVerticalLine
        End Get
        Set(ByVal value As Boolean)
            showVerticalLine = value
        End Set
    End Property
    Property showRightLine() As Boolean
        Get
            Return showRightLines
        End Get
        Set(ByVal value As Boolean)
            showRightLines = value
        End Set
    End Property
    Property MemberID() As Integer
        Get
            Return ID
        End Get
        Set(ByVal value As Integer)
            ID = value
        End Set
    End Property

    'Property SiblingDetails() As List(Of MemberDetails)
    '    Get
    '        Return Siblings
    '    End Get
    '    Set(ByVal value As List(Of MemberDetails))
    '        Siblings = value
    '    End Set
    'End Property
    'Property OffspringDetails() As List(Of MemberDetails)
    '    Get
    '        Return Offspring
    '    End Get
    '    Set(ByVal value As List(Of MemberDetails))
    '        Offspring = value
    '    End Set
    'End Property

End Class
