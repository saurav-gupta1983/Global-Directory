Imports Microsoft.VisualBasiC
Imports System.Data.SqlClient
Imports System.Data
Imports System.Globalization
Imports System.Net
Imports System.Net.Mail

Public Module CommonModule

    Public SiteMailAddress As String = System.Configuration.ConfigurationManager.AppSettings("SiteMailAddress")
    Public archivedFileName As String = "../ArchivedFiles/" + System.Configuration.ConfigurationManager.AppSettings("ArchivedFileName")
    Public ConnectionString As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
    Public referenceDate As DateTime = DateTime.Parse("1-1-1900")

    Public MSG_VALIDATE As String = "Please verify the information entered. Once entered cannot be modified. Do you want to save Information?"
    Public MSG_CONFIRM As String = "Thank you for being a member. Please record your secret Temporary KPIN safely for login. " + _
                                            ControlChars.NewLine + "Your Permanent KPIN will be sent shortly." + ControlChars.NewLine + _
                                            ChrW(12) + ChrW(12) + " Your KPIN: "
    Public MSG_WELCOME As String = "Welcome to Global Directory"

    Public MSG_LOGINDETAILS As String = "WELCOME TO GLOBAL DIRECTORY" + ControlChars.NewLine + ControlChars.NewLine
    Public MSG_PASSWORD As String = ControlChars.NewLine + "PASSWORD: "

    Public MSG_Details_Updated As String = "DetailsUpdated"
    Public MSG_Incomplete_Transaction As String = "IncompleteTransaction"
    Public MSG_Delete_Record As String = "DeleteRecord"
    Public MSG_Record_NOT_EXIST As String = "RecordNotExists"

    Public MSG_IncompleteTransaction As String = "Please update your information again. Sorry for incovenience."
    Public MSG_DetailsUpdated As String = "Your Details are updated successfully."
    Public MSG_DeleteRecord As String = "Record has been deleted succesfully."
    Public MSG_RecordNotExists As String = "Record has been deleted succesfully."
    Public MSG_PasswordSent As String = "Password is sent to your Email Id. Thank you!!!"
    Public MSG_RecoveringError As String = "Please try to recover your Password after sometime. Sorry for the incovenience!!!"
    Public MSG_MailSent As String = "Mail is sent successfully to your Friend."
    Public MSG_MailError As String = "Please try to mail after sometime. There is some problem with Server. Sorry for inconvenience."

    Public TITLE_FamilyDetails As String = "Family Details"
    Public TITLE_BirthDetails As String = "Births in family after 1989"
    Public TITLE_DeathDetails As String = "Deaths in family after 1989"
    Public TITLE_ContactDetails As String = "Contact Details"
    Public TITLE_OffspringDetails As String = "Offspring Details"
    Public TITLE_OtherDetails As String = "Other Details"
    Public TITLE_SiblingDetails As String = "Sibling Details"

    Public TITLE_All As String = "All"
    Public TITLE_Pending As String = "Pending"
    Public TITLE_Admin As String = "Administrator"

    Public VAR_DETAILS As String = "Details"
    Public VAR_REQUESTSTATE As String = "RequestState"

    'Public VAR_SEARCHQUERY = "Select Distinct MI.PinID, FirstName, MiddleName, LastName, City, Country from FamilyDetails FD, MemberInfo MI, OtherDetails OD, PropertyDetails PD" & _
    '                            " where FD.PinID = MI.PinID And FD.PinID = OD.PinID And FD.PinID = PD.PinID And "
    Public VAR_SEARCHQUERY = "Select Distinct MI.PinID, FirstName, MiddleName, LastName, City, Country, (FirstName+' '+MiddleName+' '+LastName), KPIN As Name from MemberInfo MI" & _
                                " where "

    Public VAR_SEARCHQUERY_SEND_MAIL = "Select Distinct MI.KPIN, CD.EmailId from ContactDetails CD, FamilyDetails FD, MemberInfo MI, OtherDetails OD, PropertyDetails PD" & _
                                " where FD.PinID = MI.PinID And FD.PinID = OD.PinID And FD.PinID = PD.PinID And CD.PinId = MI.PinId And "

End Module