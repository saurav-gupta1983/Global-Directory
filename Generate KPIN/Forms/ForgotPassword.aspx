<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ForgotPassword.aspx.vb" Inherits="ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Forgot your Password?</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LabelForgotPwd" runat="server" Height="25px" Style="font-weight: bold;
        font-size: x-large; z-index: 100; left: 30px; position: absolute; top: 25px; color: royalblue;" Text="Forgot your Password?"
        Width="272px"></asp:Label>

        <asp:Panel ID="PanelForgotPassword" runat="server" Height="144px" Width="496px" style="position: relative; left: 0px; top: 0px;">
            <asp:Label ID="LabelUserName" runat="server" Height="25px" Style="z-index: 101; left: 24px;
                position: absolute; top: 72px; color: blue;" Text="Enter your Email Id" Width="165px"></asp:Label>
            <asp:TextBox ID="TextBoxEmailId" runat="server" Style="z-index: 102; left: 205px; position: absolute;
                top: 75px" Width="210px"></asp:TextBox>
            <asp:Button ID="ButtonSubmit" runat="server" Style="z-index: 103; left: 430px; position: absolute;
                top: 75px" Text="Submit" />
            <asp:Label ID="LabelMessage" runat="server" Height="20px" Style="z-index: 105; left: 24px;
                position: absolute; top: 104px; color: blue;" Text="We will email you the KPIN and Password. Thank you!"
                Width="464px"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="PanelClose" runat="server" Height="120px" Width="496px" style="position: relative; left: 0px; top: 40px;">
            <asp:Label ID="LabelConfirm" runat="server" Height="20px" Style="z-index: 105; left: 24px;
                position: relative; top: 16px; color: blue;"
                Width="456px"></asp:Label>
            <asp:ImageButton ID="ButtonClose" runat="server" ImageUrl="~/Images/Button_close.gif"
                Style="position: absolute; left: 152px; top: 96px;" Width="96px" Height="20px" />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
