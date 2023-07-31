Imports Microsoft.VisualBasic

Public Class MessageBox

    Private m_executingPages As Hashtable = New Hashtable()

    Public Event MethodUnload()

    Public Sub New()
    End Sub

    Public Sub Show(ByVal sMessage As String)

        ' If this is the first time a page has called this method then
        If (Not m_executingPages.Contains(HttpContext.Current.Handler)) Then

            ' Attempt to cast HttpHandler as a Page.
            Dim executingPage As System.Web.UI.Page = CType(HttpContext.Current.Handler, System.Web.UI.Page)

            If Not (executingPage Is Nothing) Then

                ' Create a Queue to hold one or more messages.
                Dim messageQueue As Queue = New Queue()

                ' Add our message to the Queue
                messageQueue.Enqueue(sMessage)

                ' Add our message queue to the hash table. Use our page reference
                ' (IHttpHandler) as the key.
                m_executingPages.Add(HttpContext.Current.Handler, messageQueue)

                ' Wire up Unload event so that we can inject 
                ' some JavaScript for the alerts.
                'executingPage.Unload += New EventHandler(ExecutingPage_Unload)
                ExecutingPage_Unload()

            End If
        Else
            ' If were here then the method has allready been 
            ' called from the executing Page.
            ' We have allready created a message queue and stored a
            ' reference to it in our hastable.
            Dim queue As Queue = m_executingPages(HttpContext.Current.Handler)

            ' Add our message to the Queue
            Queue.Enqueue(sMessage)
        End If

    End Sub


    ' Our page has finished rendering so lets output the
    ' JavaScript to produce the alert's
    'Private Sub ExecutingPage_Unload(ByVal sender As Object, ByVal e As EventArgs)
    Private Sub ExecutingPage_Unload()
        ' Get our message queue from the hashtable
        Dim queue As Queue = m_executingPages(HttpContext.Current.Handler)

        If Not (queue Is Nothing) Then

            Dim sb As StringBuilder = New StringBuilder()

            ' How many messages have been registered?
            Dim iMsgCount As Integer = queue.Count

            ' Use StringBuilder to build up our client slide JavaScript.
            sb.Append("<script language='javascript'>")

            ' Loop round registered messages
            Dim sMsg As String

            While (iMsgCount > 0)
                sMsg = CType(queue.Dequeue(), String)
                sMsg = sMsg.Replace("\n", "\\n")
                sMsg = sMsg.Replace("\", "'")
                sb.Append("alert( " + sMsg + " ) ")

                iMsgCount = iMsgCount - 1
            End While

            ' Close our JS
            sb.Append("</script>")

            ' Were done, so remove our page reference from the hashtable
            m_executingPages.Remove(HttpContext.Current.Handler)

            ' Write the JavaScript to the end of the response stream.
            HttpContext.Current.Response.Write(sb.ToString())
        End If
    End Sub
End Class
