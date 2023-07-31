<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Upload.aspx.vb" Inherits="Forms_Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Global Directory - Upload Photo</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="PanelWrapper" runat="server" Height="200px" Width="450px" Style="left: 104px;
                position: relative; top: 32px; z-index: 101;">
                <table>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="LabelUpload" runat="server" Height="32px" Style="font-weight: bold; font-size: x-large; color: royalblue;"
                                Text="Upload your Photo" Width="450px"></asp:Label>
                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFile" runat="server" Font-Bold="True">Picture:</asp:Label>
                        </td>
                        <td>
                            <input id="filMyFile" type="file" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblInfo" runat="server" Font-Bold="True" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:300px;">
                            <asp:Image ID="imgFile" runat="server" Visible="False"  style="width: 120px; height: 120px"></asp:Image>
                        </td>
                        <td align="center">
                            <asp:Button ID="cmdSend" runat="server" Text="Upload" />&nbsp;
                            <asp:Button ID="ButtonClose" runat="server" Text="Close" />&nbsp;
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblText1" runat="server" Font-Bold="True" Visible="false">This was stored as file</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblText2" runat="server" Font-Bold="True" Visible="false">This was stored in database</asp:Label>
                        </td>
                    </tr>
                    <tr>
<%--                        <td>
                            <asp:Image ID="imgFile" runat="server" Visible="False"></asp:Image>
                        </td>
--%>                        <td>
                            <asp:Image ID="imgDB" runat="server" Visible="False"></asp:Image>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
