Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.Sql

Partial Class Forms_Upload
    Inherits System.Web.UI.Page

    Protected Overloads Overrides Sub OnInit(ByVal e As EventArgs)
        InitializeComponent()
        MyBase.OnInit(e)
    End Sub

    Private Sub InitializeComponent()
        AddHandler Me.Load, AddressOf Me.Page_Load
        AddHandler Me.cmdSend.Click, AddressOf Me.cmdSend_Click
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Check if FileID was passed to this page as a parameter 
        If Request.QueryString("PinId") IsNot Nothing Then
            ' Get the file out of database and return it to requesting client 
            ShowTheFile(Convert.ToInt32(Request.QueryString("PinId")))

        End If
    End Sub

    ' Processes click on our cmdSend button 
    Private Sub cmdSend_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Check to see if file was uploaded 
        If filMyFile.PostedFile IsNot Nothing Then
            ' Get a reference to PostedFile object 
            Dim myFile As HttpPostedFile = filMyFile.PostedFile

            ' Get size of uploaded file 
            Dim nFileLen As Integer = myFile.ContentLength

            ' make sure the size of the file is > 0 
            If nFileLen > 0 Then
                ' Allocate a buffer for reading of the file 
                Dim myData As Byte() = New Byte(nFileLen - 1) {}

                ' Read uploaded file from the Stream 
                myFile.InputStream.Read(myData, 0, nFileLen)

                ' Create a name for the file to store 
                Dim strFilename As String = Path.GetFileName(myFile.FileName)

                ' Write data into a file 
                'WriteToFile(Server.MapPath(strFilename), myData)

                ' Store it in database 
                Dim nFileID As Integer = WriteToDB(strFilename, myFile.ContentType, myData)

                ' Set label's text 
                lblInfo.Text = ("Filename: " & strFilename & "<br>" & "Size: ") + nFileLen.ToString() & "<p>"


                ' Set URL of the the object to point to the file we've just saved 
                imgFile.ImageUrl = strFilename
                imgFile.ToolTip = "This file was stored to as file."
                lblText1.Text = imgFile.ImageUrl

                ' Set URL of the the object to point to the this script with ID of the file 
                ' that will retreive file out the database 
                imgDB.ImageUrl = (GetMyName() & "?PinId=") + nFileID.ToString()
                imgDB.ToolTip = "This file was stored in database."
                lblText2.Text = imgDB.ImageUrl

                ' show the images and text 
                imgFile.Visible = True
                'imgDB.Visible = True
                lblText1.Visible = True
                'lblText2.Visible = True
            End If
        End If
    End Sub

    ' Writes file to current folder 
    Private Sub WriteToFile(ByVal strPath As String, ByRef Buffer As Byte())
        ' Create a file 
        Dim newFile As New FileStream(strPath, FileMode.Create)

        ' Write data to the file 
        newFile.Write(Buffer, 0, Buffer.Length)

        ' Close file 
        newFile.Close()
    End Sub

    '' Generates database connection string 
    'Private Function GetConnectionString() As String
    '    'Return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath(MDBFILE) & ";"
    '    Return System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
    'End Function

    ' Writes file to the database 
    Private Function WriteToDB(ByVal strName As String, ByVal strType As String, ByRef Buffer As Byte()) As Integer
        Dim Query As String
        Dim CommonObj As New CommonCode
        Dim PinId As Integer

        'Session("KPIN") = 3

        Query = "Select PinId from MemberInfo where KPIN = '" & Session("KPIN") & "'"
        CommonObj.EstablishSQLConnection(Query, "Get")
        PinId = CommonObj.returnDataSet.Tables(0).Rows(0)(0)

        'Response.Write(PinId.ToString())

        Query = "Delete from Images where PinId = '" & PinId & "'"
        CommonObj.EstablishSQLConnection(Query, "Get")

        Dim nFileID As Integer = 0

        ' Create connection 
        'Dim dbConn As New OleDbConnection(GetConnectionString())
        Dim dbConn As New SqlConnection(ConnectionString)

        ' Create Adapter 
        Dim dbAdapt As New SqlDataAdapter("SELECT * FROM Images", dbConn)

        ' We need this to get an ID back from the database 
        dbAdapt.MissingSchemaAction = MissingSchemaAction.AddWithKey

        ' Create and initialize CommandBuilder 
        '        Dim dbCB As New OleDbCommandBuilder(dbAdapt)
        Dim dbCB As New SqlCommandBuilder(dbAdapt)

        ' Open Connection 
        dbConn.Open()

        ' New DataSet 
        Dim dbSet As New DataSet()

        ' Populate DataSet with data 
        dbAdapt.Fill(dbSet, "Images")

        ' Get reference to our table 
        Dim dbTable As DataTable = dbSet.Tables("Images")

        ' Create new row 
        Dim dbRow As DataRow = dbTable.NewRow()

        ' Store data in the row 
        dbRow("FileName") = strName
        dbRow("FileSize") = Buffer.Length
        dbRow("ContentType") = strType
        dbRow("FileData") = Buffer
        dbRow("PinId") = PinId

        ' Add row back to table 
        dbTable.Rows.Add(dbRow)

        ' Update data source 
        dbAdapt.Update(dbSet, "Images")

        ' Get newFileID 
        If Not dbRow.IsNull("PinId") Then
            nFileID = CInt(dbRow("PinId"))
        End If

        ' Close connection 
        dbConn.Close()

        ' Return FileID 
        Return nFileID
    End Function

    ' Read file out of the database and returns it to client 
    Private Sub ShowTheFile(ByVal FileID As Integer)
        ' Define SQL select statement 
        Try

            Dim SQL As String = "SELECT FileSize, FileData, ContentType FROM Images WHERE PinId = " & FileID.ToString()

            ' Create Connection object 
            'Dim dbConn As New OleDbConnection(GetConnectionString())
            Dim dbConn As New SqlConnection(ConnectionString)

            ' Create Command Object 
            'Dim dbComm As New OleDbCommand(SQL, dbConn)
            Dim dbComm As New SqlCommand(SQL, dbConn)

            ' Open Connection 
            dbConn.Open()

            ' Execute command and receive DataReader 
            Dim dbRead As SqlDataReader = dbComm.ExecuteReader()

            ' Read row 
            dbRead.Read()

            ' Clear Response buffer 
            Response.Clear()

            ' Set ContentType to the ContentType of our file 
            Response.ContentType = DirectCast(dbRead("ContentType"), String)

            ' Write data out of database into Output Stream 
            Response.OutputStream.Write(DirectCast(dbRead("FileData"), Byte()), 0, CInt(dbRead("FileSize")))

            ' Close database connection 
            dbConn.Close()

            ' End the page 
            Response.[End]()
        Catch ex As Exception
            Response.[End]()
        End Try
    End Sub

    ' Reads the name of current web page 
    Private Function GetMyName() As String
        ' Get the script name 
        Dim strScript As String = Request.ServerVariables("SCRIPT_NAME")

        ' Get position of last slash 
        Dim nPos As Integer = strScript.LastIndexOf("/")

        ' Get everything after slash 
        If nPos > -1 Then
            strScript = strScript.Substring(nPos + 1)
        End If

        Return strScript
    End Function

    Protected Sub ButtonClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Response.Write("<script language='javascript'> { window.close();}</script>")
    End Sub

End Class
