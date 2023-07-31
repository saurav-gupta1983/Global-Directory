<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ShowMessageBody.aspx.vb" Inherits="Forms_ShowMessageBody" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Message</title>
</head>
<body>
    <form id="form1" runat="server" target="_blank">
    <div>
        <asp:Panel ID="Panel1" runat="server" Height="200px" Width="500px">
            <asp:Label ID="LabelMessage" runat="server" Style="font-weight: bold; left: 0px;
                font-family: Arial, 4; position: relative; top: 30px; text-align: center; font-size: x-large; color: royalblue;" Text="Message"
                Width="100%"></asp:Label>
            <asp:Label ID="LabelBody" runat="server" Height="72px" Style="left: 0px; position: relative;
                top: 56px; text-align: left; color: blue;" Text="Label" Width="100%"></asp:Label>
            <asp:Button ID="ButtonClose" runat="server" Style="left: 232px; position: relative;
                top: 72px" Text="Close" Visible="False" />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
