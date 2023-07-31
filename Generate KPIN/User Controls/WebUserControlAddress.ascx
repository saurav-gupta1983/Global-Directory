<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlAddress.ascx.vb" Inherits="WebUserControlAddress" %>
<table style="z-index: 100; left: 0px; position: relative; top: 0px" id="tableEmail">
    <tr>
        <td style="z-index: 100; left: -3px; position: relative; top: 0px; width: 81px">
            Street</td>
        <td style="z-index: 100; left: -3px; position: relative; top: 0px; width: 140px">
            <asp:TextBox ID="TextBoxAddress" runat="server" Width="192px"></asp:TextBox></td>
        <td style="z-index: 100; left: -3px; position: relative; top: 0px; width: 81px">
            <asp:CheckBox ID="CheckBoxSame" runat="server" Width="60px" Text="Same" AutoPostBack="True"></asp:CheckBox></td>
    </tr>
    <tr>
        <td style="z-index: 100; left: -3px; position: relative; top: 0px; width: 81px">
            City</td>
        <td style="z-index: 100; left: -3px; position: relative; top: 0px; width: 65px">
            <asp:TextBox ID="TextBoxCity" runat="server" Width="192px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="z-index: 100; left: -3px; position: relative; top: 0px; width: 81px">
            State</td>
        <td style="z-index: 100; left: -3px; position: relative; top: 0px; width: 65px">
            <asp:TextBox ID="TextBoxState" runat="server" Width="192px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="z-index: 100; left: -3px; position: relative; top: 0px; width: 81px">
            Country</td>
        <td style="z-index: 100; left: -3px; position: relative; top: 0px; width: 65px">
            <asp:TextBox ID="TextBoxCountry" runat="server" Width="192px"></asp:TextBox></td>
    </tr>
</table>