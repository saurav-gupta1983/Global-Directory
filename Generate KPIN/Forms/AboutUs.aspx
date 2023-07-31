<%@ Page Language="VB" MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false"
    CodeFile="AboutUs.aspx.vb" Inherits="AboutUs" Title="About Us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" runat="Server">
    <asp:Panel ID="PanelOwners" runat="server" Height="100px" Width="464px" Style="position: relative;
        left: 150px; top: 30px;">
        <asp:Label ID="LabelMemberList" runat="server" Style="z-index: 100; left: 0px; position: relative;
            top: 0px; background-color: mediumpurple; font-weight: bold; font-size: medium;
            color: white; text-align: center;" Text="Owners" Width="464px" Height="24px"></asp:Label>
        <table>
            <tr>
                <td>
                    Dr. Rajesh Bhat
                </td>
            </tr>
            <tr>
                <td>
                    Computer Services Centre
                </td>
            </tr>
            <tr>
                <td>
                    Contact No. : +91-9268776331
                </td>
            </tr>
            <tr>
                <td>
                    Email ID &nbsp; &nbsp; &nbsp; : <a href=mailto:dr.rajesh.bhat@gmail.com>dr.rajesh.bhat@gmail.com</a>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelAdministrator" runat="server" Height="200px" Width="464px" Style="position: relative;
        left: 150px; top: 50px;">
        <asp:Label ID="LabelAdmin" runat="server" Style="z-index: 100; left: 0px; position: relative;
            top: 0px; background-color: mediumpurple; font-weight: bold; font-size: medium;
            color: white; text-align: center;" Text="Administrator" Width="464px" Height="24px"></asp:Label>
        <table>
            <tr>
                <td>
                    Mr. Saurav Gupta
                </td>
            </tr>
            <tr>
                <td>
                    Entry No.: 2005JCA2425
                </td>
            </tr>
            <tr>
                <td>
                    Contact No. : +91-9818943993
                </td>
            </tr>
            <tr>
                <td>
                    Email ID &nbsp; &nbsp; &nbsp; : <a href=mailto:saurav.gupta1983@gmail.com>saurav.gupta1983@gmail.com</a>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

