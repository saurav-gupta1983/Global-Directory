<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Box.ascx.vb" Inherits="Box" %>
<asp:Panel ID="PanelBox" runat="server">
    <table cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td style="text-align: center;">
                <asp:Panel ID="PanelLines" runat="server" style="height:52px;">
                    <table style="width: 100%; height:52px; vertical-align: text-bottom; text-align: left;" cellspacing="0"
                        cellpadding="0" border="0">
                        <tr style="height: 2px; ">
                            <td style="width: 50%; height: 2px;  vertical-align: bottom; ">
                                <img src="../Images/verticalline.gif" style="width: 100%; height: 2px; vertical-align: bottom;" alt="" id="LeftLine"
                                    runat="server" />
                            </td>
                            <td style="width: 2px; height: 20px; ">
                                <img src="../Images/verticalline.gif" style="width: 2px; height: 20px; vertical-align: bottom;" alt="" id="VerticalLineBox"
                                    runat="server" />
                            </td>
                            <td style="width: 50%; height: 2px; vertical-align: bottom; ">
                                <img src="../Images/verticalline.gif" style="width: 100%; height: 2px; vertical-align: bottom;" alt="" id="RightLine"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 100%; height: 50px; vertical-align: top; text-align: center;">
                                <img src="../Images/verticalline.gif" style="width: 2px; height: 50px" alt="" id="VerticalLine"
                                    runat="server" />
                          </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="width: 10px">
                        </td>
                        <td style="width: 250px; height: 300px; vertical-align: middle; text-align: center;
                            border-right: cornflowerblue thin solid; border-top: cornflowerblue thin solid;
                            border-left: cornflowerblue thin solid; border-bottom: cornflowerblue thin solid;
                            background-color: #ccffff;">
                            <table style="text-align: left; vertical-align: middle;">
                                <tr>
                                    <td colspan="3" style="text-align: center; vertical-align: middle;">
                                        <asp:HyperLink ID="MemberLink" runat="server" Text="Member" >Member</asp:HyperLink>
                                        <asp:Label ID="MemberLabel" runat="server" Text="Member" >Member</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="vertical-align: middle; text-align:center">
                                          <img src="../Images/verticalline.gif" style="width: 120px; height: 120px" alt=""
                                            id="Photo" runat="server" />

<%--                                       <asp:Image ID="Photo" runat="server" Visible="False" Width="10px" Height="120px"></asp:Image>
--%>                                   </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; vertical-align: middle; width: 50px;  ">
                                        &nbsp;KPIN
                                    </td>
                                    <td>
                                        :</td>
                                    <td style="text-align: left; vertical-align: middle;">
                                        &nbsp;<asp:Label ID="KPIN" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; vertical-align: middle; width: 50px;  ">
                                        &nbsp;Spouse
                                    </td>
                                    <td>
                                        :</td>
                                    <td style="text-align: left; vertical-align: middle;">
                                        &nbsp;<asp:Label ID="SpouseName" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; vertical-align: middle; width: 50px;  ">
                                        &nbsp;Mother
                                    </td>
                                    <td>
                                        :</td>
                                    <td style="text-align: left; vertical-align: middle;">
                                        &nbsp;<asp:Label ID="MotherName" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; vertical-align: middle; width: 50px;  ">
                                        &nbsp;DOB
                                    </td>
                                    <td>
                                        :</td>
                                    <td style="text-align: left; vertical-align: middle;">
                                        &nbsp;<asp:Label ID="DOB" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; vertical-align: middle; width: 50px;  ">
                                        &nbsp;City
                                    </td>
                                    <td>
                                        :</td>
                                    <td style="text-align: left; vertical-align: middle;">
                                        &nbsp;<asp:Label ID="LabelCity" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
