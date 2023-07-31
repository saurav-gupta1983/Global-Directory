<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Change your Password</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="PanelWrapper" runat="server" Height="200px" Width="360px" 
    style="left: 104px; position: relative; top: 32px; z-index: 101;">
       <asp:Label ID="LabelMemberLoginForm" runat="server" Height="32px" Style="z-index: 100;
            left: 0px; position: absolute; top: 0px; font-weight: bold; font-size: x-large; color: royalblue;" Text="Change your Password"
            Width="360px"></asp:Label>
            
        <table border="0" cellpadding="0" cellspacing="0" style="z-index: 104; left: 0px;
            width: 360px; position: absolute; top: 40px; height: 64px; ">
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="LabelUser" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Text="KPIN" Width="176px"></asp:Label>
                </td>
                <td style="width: 98px">
                    <asp:TextBox ID="TextBoxUser" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Width="168px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="LabelPassword" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Text="Password" Width="176px"></asp:Label>
                </td>
                <td style="width: 98px">
                    <input id="TextBoxPassword" runat="server" style="z-index: 100; left: 180px; width: 168px; relative: absolute;
                        top: 40px" type="password" name="TextBoxPassword" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="LabelNewPassword" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Text="New Password" Width="176px"></asp:Label>
                </td>
                <td style="width: 98px">
                    <input id="TextBoxNewPassword" runat="server" style="z-index: 100; left: 0px; width: 168px; position: relative;
                        top: 0px" type="password" name="TextBoxPassword" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="LabelConfirmPassword" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Text="Confirm New Password" Width="176px"></asp:Label>
                </td>
                <td style="width: 98px">
                    <input id="TextBoxConfirmPassword" runat="server" style="z-index: 100; left: 0px; width: 168px; position: relative;
                        top: 0px" type="password" name="TextBoxPassword" />
                </td>
            </tr>
        </table>
        
        <asp:Button ID="ButtonChangePassword" runat="server" Style="z-index: 101; left: 152px; position: absolute;
            top: 144px" Text="Change Password" Width="148px" />
            
        <asp:Label ID="LabelInvalidUser" runat="server" ForeColor="Red" Style="z-index: 102;
            left: 0px; position: absolute; top: 176px" Width="360px"></asp:Label>
            &nbsp;&nbsp;
            <asp:Button ID="ButtonClose" runat="server" Style="z-index: 105; left: 56px; position: absolute;
                top: 144px" Text="Close" Width="76px" />
    </asp:Panel>
    </div>
    </form>
</body>
</html>

