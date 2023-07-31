<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlName.ascx.vb" Inherits="WebUserControlName" %>
<asp:Panel ID="PanelName" runat="server" Height="50px" Style="z-index: 101; left: 0px;
    position: relative; top: 0px" Width="125px">
<table style="z-index: 100; left: 0px; position: relative; top: 0px" id="tableName">
    <tr>
        <td style="width: 100px; ">
            First</td>
        <td style="width: 140px">
            <asp:TextBox ID="TextBoxFirstName" runat="server" Style="z-index: 100; left: 0px; position: relative;
                top: 0px" Width="140px"></asp:TextBox>
        </td>
        <td style="width: 5px; color: Red; ">
            </td>
    </tr>
    <tr>
        <td style="width: 100px">
            Middle</td>
        <td style="width: 140px">
            <asp:TextBox ID="TextBoxMiddleName" runat="server" Style="z-index: 100; left: 0px; position: relative;
                top: 0px" Width="140px"></asp:TextBox>
        </td>
     </tr>
     <tr>
         <td style="width: 100px">
            Last</td>
        <td style="width: 140px">
            <asp:TextBox ID="TextBoxLastName" runat="server" Style="z-index: 100; left: 0px; position: relative;
                top: 0px" Width="140px"></asp:TextBox>
        </td>
    </tr>
</table>
</asp:Panel>
