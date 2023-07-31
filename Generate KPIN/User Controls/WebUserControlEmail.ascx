<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlEmail.ascx.vb" Inherits="WebUserControlEmail" %>
<table style="z-index: 100; left: 0px; position: relative; top: 0px; width: 100%; height: 100%;" id="tableEmail">
    <tr>
        <td style="z-index: 100; left: -3px; position: relative; top: 0px; width: 216px">
            <asp:TextBox ID="TextBoxEmailId" runat="server" Width="216px" style="text-align: right; width: 97%; height: 100%;"></asp:TextBox></td>
        <td style="z-index: 100; left: -3px; position: relative; top: 0px; width: 5px">
            @</td>
        <td style="z-index: 100; left: -3px; position: relative; top: 0px; width: 100px">
            <asp:TextBox ID="TextBoxSite" runat="server" style="width: 90%; height: 100%"></asp:TextBox></td>
    </tr>
</table>
