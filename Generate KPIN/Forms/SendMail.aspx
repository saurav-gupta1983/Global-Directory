<%@ Import Namespace="System.Data" %>

<%@ Page Language="VB"  THEME="LabelSkin"  MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="SendMail.aspx.vb" Inherits="SendMail" title="Send Email" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">
 
   <asp:Panel ID="PanelShowDetails" runat="server" Height="1px" Width="440px" style="position: relative; left: 140px; top: 32px;">
    <table style="z-index: 100; left: 0px; position: relative; top: 20px; padding-right: 2px; padding-left: 2px; padding-bottom: 2px; padding-top: 2px;">
        <%  
            Dim MemberDataSet As DataSet
            Dim CommonObj As New CommonCode
            
            If Session("KPIN") Is Nothing Then
                TextBoxFROM.Enabled = True
            Else
                TextBoxFROM.Text = Session("KPIN")
            End If
            
            Dim Query As String

            Query = "Select * from MemberInfo where PINId = '" & Request.QueryString("PIN") & "'"

            CommonObj.EstablishSQLConnection(Query, "Get")

            MemberDataSet = CommonObj.returnDataSet
            
            TextBoxTO.Text = MemberDataSet.Tables(0).Rows(0).Item("FirstName")
            
            Dim dr As DataRow = MemberDataSet.Tables(0).Rows(0)
            %>
        <tr>
            <td style="width: 100px; font-weight: bold; background-color: mediumpurple; color: white;">
                Name</td>
            <td style="width: 182px; ">
                <%=dr.Item("FirstName") & " " & dr.Item("MiddleName") & " " & dr.Item("LastName")%></td>
        </tr>
          <tr>
            <td style="width: 100px; font-weight: bold; background-color: mediumpurple; color: white;">
                Country</td>
            <td style="width: 182px; ">
                <%=dr.Item("Country")%></td>
        </tr>
    </table>
    </asp:Panel>
    
    <asp:Label ID="LabelSendEmail" runat="server" Style="z-index: 100; left: 140px; color: blue;
        position: relative; top: 100px" Text="Send an Email to a Friend" Width="448px"></asp:Label>
    <table style="z-index: 100; left: 140px; position: relative; top: 110px; width: 455px; height: 20px;">
        <tr>
            <td style="width: 33px; height: 24px; color: red;">
                To:</td>
            <td style="width: 149px; height: 24px;">
                <asp:TextBox ID="TextBoxTO" runat="server" Style="z-index: 100; left: 135px; position: absolute;
                    top: 5px" Width="305px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 33px; color: red; height: 21px;">
                From:</td>
            <td style="width: 149px; height: 24px;">
                <asp:TextBox ID="TextBoxFROM" runat="server" Style="z-index: 100; left: 135px; position: absolute;
                    top: 30px" Width="305px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 33px; color: red; height: 21px;">
                Subject:</td>
            <td style="width: 149px; height: 21px;">
                <asp:TextBox ID="TextBoxSubject" runat="server" Style="z-index: 100; left: 135px; position: absolute;
                    top: 58px" Width="305px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 33px; height: 102px; color: red;">
                Message:</td>
            <td style="width: 149px; height: 102px;">
                <asp:TextBox ID="TextBoxMessage" runat="server" Height="90px" Style="z-index: 100; left: 135px;
                    position: absolute; top: 83px" Width="305px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Button ID="ButtonSend" runat="server" Style="z-index: 102; left: 140px; position: relative;
        top: 130px" Text="Send Email" Width="140px" />
    <asp:Button ID="ButtonGoBack" runat="server" Style="z-index: 102; left: 140px; position: relative;
        top: 130px" Text="Back" Width="104px" />
    <asp:Label ID="LabelMessage" runat="server" Style="z-index: 100; left: -102px; color: red;
        position: relative; top: 140px" Text="" Width="448px"></asp:Label>

</asp:Content>

