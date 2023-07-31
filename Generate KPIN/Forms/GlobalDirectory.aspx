<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GlobalDirectory.aspx.vb" Inherits="GlobalDirectory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Global Directory</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="PanelGlobalDirectory" runat="server" Height="272px" Style="left: 200px; position: absolute;
            top: 128px" Width="544px">
            <asp:Label ID="LabelGlobalDir" runat="server" BorderColor="Red" Height="40px"
            Style="font-size: xx-large; z-index: 105; left: 0px; position: absolute; top: 40px; color: #2525aa;" Text="Global Directory" Width="320px"></asp:Label>    &nbsp;&nbsp;&nbsp;
            <asp:Image ID="ImageLogo" runat="server" Height="104px" ImageUrl="~/Images/Directoy_logo.gif"
                Style="left: 0px; position: absolute; top: 96px" Width="104px" />
                
           <asp:Label ID="LabelMemberLoginForm" runat="server" Height="32px" Style="z-index: 100;
            left: 240px; position: absolute; top: 88px; background-color: whitesmoke; font-weight: bold; color: mediumblue;" Text="Member Log in"
            Width="300px"></asp:Label>
            &nbsp;&nbsp;
        <table border="0" cellpadding="0" cellspacing="0" style="z-index: 108; left: 240px;
        width: 300px; position: absolute; top: 112px; height: 64px; background-color: whitesmoke;">
        <tr>
            <td style="width: 36px; ">
                <asp:Label ID="LabelUser" runat="server" Style="z-index: 100; left: 0px; position: absolute;
                    top: 10px; font-weight: bold;" Text="  KPIN" Width="96px"></asp:Label>
            </td>
            <td style="width: 67px; ">
                <asp:TextBox ID="TextBoxUser" runat="server" Style="z-index: 100; left: 112px; position: absolute;
                    top: 8px" Width="168px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 36px">
                <asp:Label ID="LabelPassword" runat="server" Style="z-index: 100; left: 0px; position: absolute;
                    top: 42px; font-weight: bold;" Text="  Password" Width="96px"></asp:Label>
            </td>
            <td style="width: 67px">
                &nbsp;
                <input id="TextBoxPassword" runat="server" style="z-index: 100; left: 112px; width: 168px; position: absolute;
                    top: 40px" type="password" name="TextBoxPassword" />
            </td>
        </tr>
    </table>
    <asp:Label ID="LabelInvalidUser" runat="server" ForeColor="Red" Style="z-index: 102;
        left: 240px; position: absolute; top: 216px" Text="*Invalid KPIN or Password"
        Visible="False" Width="296px"></asp:Label>
    <table style="z-index: 109; left: 240px; position: absolute; top: 240px">
        <tr>
            <td style="width: 63px; height: 21px;">
                Are you a</td>
            <td style="width: 80px; height: 21px;">
                <strong>New User ?</strong></td>
            <td style="width: 100px; height: 21px;">
                <asp:HyperLink ID="HyperLinkSignUp" runat="server" NavigateUrl="~/Forms/MembersForm.aspx" Style="z-index: 100; left: 155px;
                    position: absolute; top: 3px; font-weight: bold;" Width="100px">Sign Up</asp:HyperLink>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="z-index: 108; left: 240px;
        width: 300px; position: absolute; top: 176px; background-color: whitesmoke; height: 40px">
    <tr>
        <td style="width: 73px">
            <asp:ImageButton ID="ButtonGo" runat="server" Height="24px" ImageUrl="~/Images/button_logon.gif"
            Style="left: 0px; position: absolute; top: 10px" Width="64px" />
        </td>
        <td style="width: 126px">
            <asp:HyperLink ID="HyperLinkForgetPwd" target="_blank" runat="server" Height="20px" Style="z-index: 103;
            left: 200px; position: absolute; top: 10px; text-align: right" Width="96px" NavigateUrl="~/Forms/ForgotPassword.aspx">Are you Stuck?</asp:HyperLink>
        </td>
        <td>
            <asp:HyperLink ID="HyperLinkSearch" runat="server" Height="20px" Style="z-index: 104;
            left: 72px; position: absolute; top: 10px; text-align: center" Width="128px" NavigateUrl="~/Forms/SearchDirectory.aspx">Search a Member</asp:HyperLink>
        </td>
    </tr>
    </table>
            <asp:Label ID="LabelMessage" runat="server" Height="56px" Style="font-weight: bold; z-index: 100;
                left: 0px; color: royalblue; position: absolute; top: 208px; background-color: white"
                Text="Our Directory help you find your buddies and acts as a repository of your personal details"
                Width="232px"></asp:Label>
    </asp:Panel>
    </div>
    </form>
</body>
</html>

