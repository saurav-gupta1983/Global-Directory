Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Globalization
Imports System.Net
Imports System.Net.Mail
Imports System.Web.HttpContext

Public Class CommonCode
    Inherits DataCommon

    Public Lookuptable As New Hashtable()
    Private Tits As Integer = 3

    ' ***************************************************************
    ' Method Name: ShowMessageBox
    ' Description: To show Message Box
    ' Parameter: Message, ErrorType and ButtonType
    ' Return Values: 
    ' ***************************************************************
    Public Function ShowMessageBox(ByVal Message As String, Optional ByVal ButtonType As String = "")
        Dim MessageBoxButton As MsgBoxStyle
        Try
            Select Case ButtonType
                Case "Question"
                    MessageBoxButton = MsgBoxStyle.YesNo
                Case "Critical"
                    Current.Session("ErrorMessage") = Message
                    MsgBox(Message, MsgBoxStyle.Information)
                    Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("ErrorPage"), False)
                    Return ""
                    'MessageBoxButton = MsgBoxStyle.Critical
                Case Else
                    Select Case Message
                        Case "IncompleteTransaction"
                            Return MSG_IncompleteTransaction
                        Case "DetailsUpdated"
                            Return MSG_DetailsUpdated
                        Case "DeleteRecord"
                            Return MSG_DeleteRecord
                        Case "RecordNotExists"
                            Return MSG_RecordNotExists
                        Case "PasswordSent"
                            Return MSG_PasswordSent
                        Case "RecoveringError"
                            Return MSG_RecoveringError
                        Case "MailSent"
                            Return MSG_MailSent
                        Case "MailError"
                            Return MSG_MailError
                    End Select
            End Select
        Catch ex As Exception
            Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings("ErrorPage"), False)
            Return ""
        End Try
        Return MsgBox(Message, MessageBoxButton, "Global Directory")
    End Function

    Public Sub ShowAlertMessage(ByVal Message As String, ByVal ClientPage As Page)
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder
        'sb.Append("<script language='javascript'>")
        'sb.Append("alert('Welcome website')")
        'sb.Append("</script>")
        sb.Append("<script language='javascript'>" + vbCrLf)
        sb.Append("function fn_test() {" + vbCrLf)
        sb.Append("alert('');" + vbCrLf)
        sb.Append("}" + vbCrLf)
        sb.Append("</script>" + vbCrLf)
        ClientPage.ClientScript.RegisterClientScriptBlock("String".GetType, "Test", sb.ToString())
    End Sub

    Public Function returnRowNUmber()
        Return RowNumber
    End Function

    Public Function returnDataSet() As DataSet
        Return memberDataSet
    End Function

    Public Function GenerateDatefromAge(ByVal Age As Integer)
        Try
            Return referenceDate.AddDays(Age)

        Catch ex As Exception
            ShowMessageBox(ex.Message, "Critical")
        End Try
        Return referenceDate
    End Function

    Public Function CalculateAge(ByVal Day As Integer, ByVal Month As Integer, ByVal Year As Integer)
        Dim Age As Integer
        Dim DateofBirth As New DateTime()
        Dim culture As System.Globalization.CultureInfo = New CultureInfo("en-Us", True)
        Try
            DateofBirth = DateTime.Parse(Month.ToString() & "-" & Day.ToString() & "-" & Year.ToString(), culture, DateTimeStyles.NoCurrentDateDefault)

            Age = DateofBirth.Subtract(referenceDate).Days

            'System.Globalization.CultureInfo culture = new CultureInfo("hi-IN", true);
        Catch ex As Exception
            ShowMessageBox(ex.Message, "Critical")
        End Try
        Return Age
    End Function

    Public Function GenerateKPIN(ByVal FirstName As String, ByVal LastName As String, ByVal Age As Integer) As String
        Dim KPIN As String = ""
        Dim DateofBirth As Date
        Try
            DateofBirth = GenerateDatefromAge(Age)

            KPIN = FirstName.Substring(0, 2) + DateofBirth.Day.ToString() + LastName.Substring(0, 2) + _
                    DateofBirth.Month.ToString() + DateofBirth.Year.ToString()

        Catch ex As Exception
            ShowMessageBox(ex.Message, "Critical")
        End Try
        Return KPIN
    End Function

    Public Function SendMail(ByVal mTo As String, ByVal mFrom As String, ByVal mSubject As String, ByVal mMsg As String) As Boolean
        Try
            Dim strMsg As String
            strMsg = "Message"

            mTo = "saurav_83@rediffmail.com"
            mFrom = "saurav_832000@yahoo.com"
            mSubject = "Test mail"
            mMsg = strMsg
            Dim mMailServer As String = ConfigurationManager.AppSettings.Get("MyMailServer")
            Dim mPort As Integer = ConfigurationManager.AppSettings.Get("MyMailServerPort")

            Try

                Dim message As New MailMessage(mFrom, mTo, mSubject, mMsg)

                Dim mySmtpClient As New SmtpClient(mMailServer, mPort)
                mySmtpClient.UseDefaultCredentials = True
                mySmtpClient.Send(message)

                Return True

            Catch ex As FormatException
                ShowMessageBox("Format Exception: " & ex.Message, "Critical")
            Catch ex As SmtpException
                ShowMessageBox("SMTP Exception:  " & ex.Message, "Critical")
            Catch ex As Exception
                ShowMessageBox("General Exception:  " & ex.Message, "Critical")
            End Try

        Catch ex As Exception
            ShowMessageBox(ex.Message, "Critical")
        End Try
        Return False
    End Function

    Public Sub SendMailToGroup(ByVal RequestedByKPIN As String, ByVal filterString As String, ByVal mSubject As String, ByVal mMsg As String)
        Try
            Dim mFrom As String = SiteMailAddress
            Dim Query As String
            Query = VAR_SEARCHQUERY_SEND_MAIL + Replace(filterString, "''", "'")
            EstablishSQLConnection(Query, "Get")

            Dim dataSet As Data.DataSet
            dataSet = returnDataSet()

            For Each dr As Data.DataRow In dataSet.Tables(0).Rows
                Query = "Insert Into MailList (KPIN,EmailToKPIN,DateofEmail,Subject) Select '" & _
                                    RequestedByKPIN & "' , '" & _
                                    dr.Item(0) & "' , '" & _
                                    System.DateTime.Now() & "' , '" & _
                                    mSubject & "'"
                EstablishSQLConnection(Query)

                SendMail(dr.Item(0), mFrom, mSubject, mMsg)
            Next
        Catch ex As Exception
            ShowMessageBox(ex.Message, "Critical")
        End Try

    End Sub

#Region "Generate Complex KPIN"

    Public Function GenerateComplexKPIN(ByVal MothersName As String, ByVal Name As String, ByVal DOB As String) As String
        Dim Codes As String
        Dim Codes1 As String
        Dim Codes2 As String
        Dim EncodeCodes As String
        Dim KPIN As String = ""
        Try
            createHashtable()

            'Dim DOB As String = "123456789"
            'Dim Name As String = "Saurav Gupta"
            'Dim MothersName As String = "Gupta"

            'TextBoxString.Text = ConvertASCII(DOB, True) + " " + ConvertNumbertoASCII(DOB.PadRight(10, "-").Length - DOB.Length, 4).ToString() + " "
            'TextBoxString.Text += ConvertASCII(Name) + " " + ConvertNumbertoASCII(Name.PadRight(30, "-").Length - Name.Length, 5).ToString() + " "
            'TextBoxString.Text += ConvertASCII(MothersName) + " " + ConvertNumbertoASCII(MothersName.PadRight(15, "-").Length - MothersName.Length, 5).ToString() + " "
            Codes = ConvertASCII(DOB, True) + ConvertNumbertoASCII(DOB.PadRight(10, "-").Length - DOB.Length, 4).ToString()
            Codes += ConvertASCII(Name) + ConvertNumbertoASCII(Name.PadRight(30, "-").Length - Name.Length, 5).ToString()
            Codes += ConvertASCII(MothersName) + ConvertNumbertoASCII(MothersName.PadRight(15, "-").Length - MothersName.Length, 5).ToString()

            Codes = Codes.PadLeft(Codes.Length + ((2 * Tits) - Codes.Length Mod (2 * Tits)), "0")

            Codes1 = Codes.Substring(0, Codes.Length / 2)
            Codes2 = Codes.Substring(Codes.Length / 2, Codes.Length / 2)

            EncodeCodes = ApplyXOR(Codes1, Codes2)

            For counter As Integer = 0 To EncodeCodes.Length - 1 Step Tits
                KPIN += Lookuptable(EncodeCodes.Substring(counter, Tits))
            Next

        Catch ex As Exception

        End Try
        Return KPIN
    End Function

    Private Function Decode(ByVal KPIN As String) As String
        Dim Codes As String
        Dim EncodeCodes As String = ""
        Dim Data As String = ""

        Try

            For counter As Integer = 0 To KPIN.Length - 1
                EncodeCodes += Lookuptable(KPIN.Substring(counter, 1))
            Next

            Codes = ApplyXNOR(EncodeCodes)

            Data = ExtractInfo(Codes)


        Catch ex As Exception

        End Try
        Return Data
    End Function

    Private Function ConvertASCII(ByVal Characters As String, Optional ByVal Numbers As Boolean = False)
        Dim ASCIICodes As String = ""

        Try
            Dim intCounter As Integer

            Characters = Characters.ToLower()

            'Iterate through the string.
            If Numbers = False Then
                For intCounter = 0 To Characters.Length - 1
                    If Characters(intCounter) = "-" Then
                        ASCIICodes += Cal_CharToBinary(26)
                    ElseIf Characters(intCounter) = " " Then
                        ASCIICodes += ConvertNumbertoASCII(27, 5)
                    Else
                        ASCIICodes += ConvertNumbertoASCII(Asc(Characters(intCounter)) - 65, 5)
                    End If
                Next
            Else
                ASCIICodes += Cal_CharToBinary(CInt(Characters))
            End If

        Catch ex As Exception

        End Try

        Return ASCIICodes
    End Function

    Private Function ConvertNumbertoASCII(ByVal Characters As Integer, ByVal Bits As Integer)
        Dim ASCIICodes As String = ""

        Try
            ASCIICodes = Cal_CharToBinary(Characters).PadLeft(Bits, "0")

            Return ASCIICodes.Substring(ASCIICodes.Length - Bits, Bits)

        Catch ex As Exception

        End Try

        Return ASCIICodes
    End Function

    Public Function Cal_CharToBinary(ByVal ASCIIValue As Integer) As String
        Try

            Dim BinaryArr() As String
            Dim BinaryStr As String = ""
            Dim i As Integer

            i = 0

            ReDim BinaryArr(i)
            While ASCIIValue <> 0
                ReDim Preserve BinaryArr(i)
                BinaryArr(i) = ASCIIValue Mod 2
                ASCIIValue = ASCIIValue \ 2
                i = i + 1
            End While

            If UBound(BinaryArr) >= 0 Then
                For i = 0 To UBound(BinaryArr)
                    BinaryStr = BinaryArr(i) & BinaryStr
                Next
                BinaryStr = String.Format("0", 8 - Len(BinaryStr)) & BinaryStr
            End If
            Return BinaryStr
        Catch ex As Exception

        End Try
        Return ""
    End Function

    Public Function Cal_BinaryToAsci(ByVal BinaryStr As String, ByVal Bits As Integer) As Integer
        Try

            Dim LPos As Integer
            Dim tmpVal As Integer

            LPos = 0
            tmpVal = 0

            While LPos >= 0
                LPos = InStr(LPos + 1, BinaryStr, "1")
                If LPos > 0 Then
                    tmpVal = tmpVal + (2 ^ (Bits - LPos))
                Else
                    LPos = -1
                End If
            End While

            Return tmpVal

        Catch ex As Exception

        End Try

    End Function

    Private Function ApplyXOR(ByVal Codes1 As String, ByVal Codes2 As String) As String
        Dim Coded As String = ""
        Try
            For intCounter As Integer = 0 To Codes1.Length - 1
                Coded += XOROper(Codes1(intCounter), Codes2(intCounter))
            Next

        Catch ex As Exception

        End Try
        Return Coded
    End Function

    Private Function XOROper(ByVal Codes1 As String, ByVal Codes2 As String) As String
        Dim Coded As String = ""
        Try
            If Codes1 = "0" And Codes2 = "0" Then
                Return "0"
            ElseIf Codes1 = "1" And Codes2 = "1" Then
                Return "1"
            ElseIf Codes1 = "0" And Codes2 = "1" Then
                Return "-"
            Else
                Return "+"
            End If

        Catch ex As Exception

        End Try
        Return Coded
    End Function

    Private Sub createHashtable()
        Try
            Lookuptable.Add("000", "A")
            Lookuptable.Add("001", "B")
            Lookuptable.Add("00-", "C")
            Lookuptable.Add("00+", "D")
            Lookuptable.Add("010", "E")
            Lookuptable.Add("011", "F")
            Lookuptable.Add("01-", "G")
            Lookuptable.Add("01+", "H")
            Lookuptable.Add("0-0", "I")
            Lookuptable.Add("0-1", "J")
            Lookuptable.Add("0--", "K")
            Lookuptable.Add("0-+", "L")
            Lookuptable.Add("0+0", "M")
            Lookuptable.Add("0+1", "N")
            Lookuptable.Add("0+-", "O")
            Lookuptable.Add("0++", "P")
            Lookuptable.Add("100", "Q")
            Lookuptable.Add("101", "R")
            Lookuptable.Add("10-", "S")
            Lookuptable.Add("10+", "T")
            Lookuptable.Add("110", "U")
            Lookuptable.Add("111", "V")
            Lookuptable.Add("11-", "W")
            Lookuptable.Add("11+", "X")
            Lookuptable.Add("1-0", "Y")
            Lookuptable.Add("1-1", "Z")
            Lookuptable.Add("1--", " ")
            Lookuptable.Add("1-+", "0")
            Lookuptable.Add("1+0", "1")
            Lookuptable.Add("1+1", "2")
            Lookuptable.Add("1+-", "3")
            Lookuptable.Add("1++", "4")
            Lookuptable.Add("-00", "5")
            Lookuptable.Add("-01", "6")
            Lookuptable.Add("-0-", "7")
            Lookuptable.Add("-0+", "8")
            Lookuptable.Add("-10", "9")
            Lookuptable.Add("-11", "!")
            Lookuptable.Add("-1-", "@")
            Lookuptable.Add("-1+", "#")
            Lookuptable.Add("--0", "$")
            Lookuptable.Add("--1", "%")
            Lookuptable.Add("---", "^")
            Lookuptable.Add("--+", "&")
            Lookuptable.Add("-+0", "*")
            Lookuptable.Add("-+1", "(")
            Lookuptable.Add("-+-", ")")
            Lookuptable.Add("-++", "=")
            Lookuptable.Add("+00", "`")
            Lookuptable.Add("+01", "{")
            Lookuptable.Add("+0-", "}")
            Lookuptable.Add("+0+", "[")
            Lookuptable.Add("+10", "]")
            Lookuptable.Add("+11", "\")
            Lookuptable.Add("+1-", "/")
            Lookuptable.Add("+1+", "|")
            Lookuptable.Add("+-0", "-")
            Lookuptable.Add("+-1", "+")
            Lookuptable.Add("+--", "_")
            Lookuptable.Add("+-+", "~")
            Lookuptable.Add("++0", ":")
            Lookuptable.Add("++1", ".")
            Lookuptable.Add("++-", "?")
            Lookuptable.Add("+++", ";")

            Lookuptable.Add("A", "000")
            Lookuptable.Add("B", "001")
            Lookuptable.Add("C", "00-")
            Lookuptable.Add("D", "00+")
            Lookuptable.Add("E", "010")
            Lookuptable.Add("F", "011")
            Lookuptable.Add("G", "01-")
            Lookuptable.Add("H", "01+")
            Lookuptable.Add("I", "0-0")
            Lookuptable.Add("J", "0-1")
            Lookuptable.Add("K", "0--")
            Lookuptable.Add("L", "0-+")
            Lookuptable.Add("M", "0+0")
            Lookuptable.Add("N", "0+1")
            Lookuptable.Add("O", "0+-")
            Lookuptable.Add("P", "0++")
            Lookuptable.Add("Q", "100")
            Lookuptable.Add("R", "101")
            Lookuptable.Add("S", "10-")
            Lookuptable.Add("T", "10+")
            Lookuptable.Add("U", "110")
            Lookuptable.Add("V", "111")
            Lookuptable.Add("W", "11-")
            Lookuptable.Add("X", "11+")
            Lookuptable.Add("Y", "1-0")
            Lookuptable.Add("Z", "1-1")
            Lookuptable.Add(" ", "1--")
            Lookuptable.Add("0", "1-+")
            Lookuptable.Add("1", "1+0")
            Lookuptable.Add("2", "1+1")
            Lookuptable.Add("3", "1+-")
            Lookuptable.Add("4", "1++")
            Lookuptable.Add("5", "-00")
            Lookuptable.Add("6", "-01")
            Lookuptable.Add("7", "-0-")
            Lookuptable.Add("8", "-0+")
            Lookuptable.Add("9", "-10")
            Lookuptable.Add("!", "-11")
            Lookuptable.Add("@", "-1-")
            Lookuptable.Add("#", "-1+")
            Lookuptable.Add("$", "--0")
            Lookuptable.Add("%", "--1")
            Lookuptable.Add("^", "---")
            Lookuptable.Add("&", "--+")
            Lookuptable.Add("*", "-+0")
            Lookuptable.Add("(", "-+1")
            Lookuptable.Add(")", "-+-")
            Lookuptable.Add("=", "-++")
            Lookuptable.Add("`", "+00")
            Lookuptable.Add("{", "+01")
            Lookuptable.Add("}", "+0-")
            Lookuptable.Add("[", "+0+")
            Lookuptable.Add("]", "+10")
            Lookuptable.Add("\", "+11")
            Lookuptable.Add("/", "+1-")
            Lookuptable.Add("|", "+1+")
            Lookuptable.Add("-", "+-0")
            Lookuptable.Add("+", "+-1")
            Lookuptable.Add("_", "+--")
            Lookuptable.Add("~", "+-+")
            Lookuptable.Add(":", "++0")
            Lookuptable.Add(".", "++1")
            Lookuptable.Add("?", "++-")
            Lookuptable.Add(";", "+++")

        Catch ex As Exception

        End Try
    End Sub

    Private Function ApplyXNOR(ByVal Encodes As String) As String
        Dim Coded As String = ""
        Try
            Dim Codes1 As String = ""
            Dim Codes2 As String = ""

            For intCounter As Integer = 0 To Encodes.Length - 1
                XNOROper(Codes1, Codes2, Encodes(intCounter))
            Next

            Coded = Codes1 + Codes2

        Catch ex As Exception

        End Try
        Return Coded
    End Function

    Private Sub XNOROper(ByRef Codes1 As String, ByRef Codes2 As String, ByRef Encodechar As String)
        Dim Coded As String = ""
        Try
            If Encodechar = "0" Then
                Codes1 += "0"
                Codes2 += "0"
            ElseIf Encodechar = "1" Then
                Codes1 += "1"
                Codes2 += "1"
            ElseIf Encodechar = "-" Then
                Codes1 += "0"
                Codes2 += "1"
            Else
                Codes1 += "1"
                Codes2 += "0"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function ExtractInfo(ByVal Codes As String)
        Dim Data As String = ""
        Try
            Dim temp As String
            Dim tempData As String = ""

            temp = Codes.Substring(Codes.Length - 5, 5)
            tempData = tempData.PadLeft(Cal_BinaryToAsci(temp, 5), "-")

            Codes = Codes.Substring(0, Codes.Length - 5)

            temp = Codes.Substring(Codes.Length - (15 - tempData.Length) * 5, (15 - tempData.Length) * 5)
            Codes = Codes.Substring(0, Codes.Length - (15 - tempData.Length) * 5)
            Data = tempData
            For intcounter As Integer = temp.Length To 1 Step -5
                Dim ASCII As Integer = Cal_BinaryToAsci(temp.Substring(intcounter - 5, 5), 5)
                Data = IIf(ASCII = 27, " ", Chr(ASCII + 65)) + Data
            Next

            temp = Codes.Substring(Codes.Length - 5, 5)
            tempData = tempData.PadLeft(Cal_BinaryToAsci(temp, 5), "-")
            Codes = Codes.Substring(0, Codes.Length - 5)

            temp = Codes.Substring(Codes.Length - (30 - tempData.Length) * 5, (30 - tempData.Length) * 5)
            Codes = Codes.Substring(0, Codes.Length - (30 - tempData.Length) * 5)
            Data = tempData + Data
            For intcounter As Integer = temp.Length To 1 Step -5
                Dim ASCII As Integer = Cal_BinaryToAsci(temp.Substring(intcounter - 5, 5), 5)
                Data = IIf(ASCII = 27, " ", Chr(ASCII + 65)) + Data
            Next

            temp = Codes.Substring(Codes.Length - 4, 4)
            Data = Data.PadLeft(Cal_BinaryToAsci(temp, 4) + Data.Length, "-")
            Codes = Codes.Substring(0, Codes.Length - 4)

            Data = Cal_BinaryToAsci(Codes, Codes.Length).ToString() + Data

            'temp = Codes.Substring(Codes.Length - (15 - Data.Length) * 4, (15 - Data.Length) * 5)
            'For intcounter As Integer = 0 To temp.Length Step 5
            '    Dim ASCII As Integer = Cal_BinaryToAsci(temp(intcounter), 5)
            '    Data = IIf(ASCII = 27, " ", Chr(ASCII + 65)) + Data
            'Next

            'TextBoxDecodedString.Text = Data


        Catch ex As Exception

        End Try
        Return Data
    End Function
#End Region

End Class
