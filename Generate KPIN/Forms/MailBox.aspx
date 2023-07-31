<%@ Import Namespace="System.Data" %>

<%@ Page Language="VB"  THEME="LabelSkin"  MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="MailBox.aspx.vb" Inherits="MailBox" title="Mail Box" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">

<asp:Panel ID="PanelWrapper" runat="server" Height="800px" Width="500px" 
style="left: 140px; position: relative; top: 30px; z-index: 101;">
    <asp:Label ID="LabelMemberList" runat="server" Style="z-index: 100; left: 0px;
        position: absolute; top: 0px; background-color: mediumpurple; font-weight: bold; font-size: medium; color: white;" Text="Member List" Width="500px" Height="24px"></asp:Label>
   <table style="z-index: 100; left: 0px; position: absolute; top: 30px; padding-right: 0px; padding-left: 0px; padding-bottom: 2px; padding-top: 2px; width: 500px;" cellpadding="1" cellspacing="1">
        <tr>
            <td style="width: 147px; font-weight: bold; background-color: #f0f8ff; text-align: center;">
                Name</td>
            <td style="width: 91px; font-weight: bold; background-color: #f0f8ff; text-align: center;">
                Country</td>
            <td style="width: 85px; font-weight: bold; background-color: #f0f8ff; text-align: center;">
                Last Mail recieved on</td>
        </tr>
        <%  
            Dim MemberDataSet As DataSet
            Dim KPIN As String
            Dim CommonObj As New CommonCode
            KPIN = Session("KPIN")
            Dim flag As Boolean = False
            
            If Session("MemberInfo") Is Nothing Then
                Dim Query As String

                Query = "Select PINId, FirstName, MiddleName, LastName, Country, DateofEmail from MemberInfo MI, MailList ML where ML.KPIN = '" & _
                KPIN & "' and ML.EmailfromKPIN = MI.KPIN"

                CommonObj.EstablishSQLConnection(Query, "Get")

                MemberDataSet = CommonObj.returnDataSet
                flag=True
            Else
                MemberDataSet = Session("MemberInfo")
                Session.Remove("MemberInfo")
            End If
           
            For Each dr As DataRow In MemberDataSet.Tables(0).Rows()
            %>
          <tr>
          <td style="width: 250px; height: 21px;">
                <a href="SendMail.aspx?PIN=<%=dr.Item("PINId")%>">
                <%=dr.Item("FirstName") & " " & dr.Item("MiddleName") & " " & dr.Item("LastName")%>
                </a>
           </td>
            <td style="width: 100px; height: 21px;">
             <%=dr.Item("Country") %>
           </td>
           <% If flag Then %>
           <td style="width: 100; height: 21px;">
             <%=dr.Item("DateofEmail") %>
           </td>
           <% End If %>
         </tr>
       
        <%  
            Next
            
            %>
    </table>
</asp:Panel>
</asp:Content>

