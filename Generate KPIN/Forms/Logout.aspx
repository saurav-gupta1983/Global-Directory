<%@ Page Language="VB" MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="Logout.aspx.vb" Inherits="Logout" title="Global Directory - Logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">
<asp:Panel ID="PanelConfirmMessage" runat="server" Height="70px" Style="left: 150px; position: absolute;
        top: 100px" Width="570px">
    <asp:Label ID="LabelLogout" runat="server" Height="24px" Style="font-weight: bold;
        font-size: medium; z-index: 100; left: 0px; position: absolute; top: 0px;
        text-align: center" Text="You have been logged out successfully." Width="568px"></asp:Label>
    <asp:Button ID="Buttonhome" runat="server" Style="left: 224px; position: absolute;
        top: 40px" Text="Go to Home" Width="100px" />
</asp:Panel>
</asp:Content>

