<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlChildList.ascx.vb"
    Inherits="WebUserControlChildList" %>
<%@ Register Src="Box.ascx" TagName="Box" TagPrefix="uc1" %>
<asp:Panel ID="PanelChildList" runat="server">
    <table cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td colspan="4">
            </td>
            <td style="vertical-align: bottom; text-align: center;">
                <uc1:Box ID="ParentBox" runat="server"></uc1:Box>
            </td>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
           <td style="vertical-align: bottom; text-align: center;">
                <img src="../Images/verticalline.gif" style="width: 2px; height: 50px; margin-top: 0px; margin-bottom: 0px; padding-bottom: 0px; vertical-align: bottom; padding-top: 0px;" alt="" id="SiblingLine"
                    runat="server" />
            </td>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td style="width: 300px">
                <uc1:Box ID="Sibling1" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Sibling2" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Sibling3" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Sibling4" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Sibling5" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Sibling6" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Sibling7" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Sibling8" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Sibling9" runat="server"></uc1:Box>
            </td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
           <td style="vertical-align: bottom; text-align: center;">
                <img src="../Images/verticalline.gif" style="width: 2px; height: 50px" alt="" id="ChildLine"
                    runat="server" />
            </td>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td style="width: 300px">
                <uc1:Box ID="Child1" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Child2" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Child3" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Child4" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Child5" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Child6" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Child7" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Child8" runat="server"></uc1:Box>
            </td>
            <td style="width: 300px">
                <uc1:Box ID="Child9" runat="server"></uc1:Box>
            </td>
        </tr>
    </table>
</asp:Panel>
