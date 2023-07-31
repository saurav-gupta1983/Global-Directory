<%@ Page Language="VB"   THEME="LabelSkin" MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="ShowConfirmation.aspx.vb" Inherits="Forms_ShowConfirmation" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">
<%--    <asp:Label SkinID="LabelDetails" ID="LabelDetails" runat="server" Style="left: 10px; position: absolute; top: 96px; font-weight: bold; background-color: #3366ff; text-align: right; z-index: 100; color: aqua;"
        Text="" Width="920px" Height="24px"></asp:Label>
--%>    

<asp:Panel ID="PanelConfirmMessage" runat="server" Height="200px" Style="left: 100px; position: absolute;
        top: 10px" Width="570px">
        <asp:Label ID="LabelInfo" runat="server" Style="font-weight: normal; left: 0px; color: blue;
            position: absolute; top: 30px; text-align: center" Text="Thank you for being a member" Width="100%" Height="24px"></asp:Label>
        <asp:Label ID="LabelKPINMsg" runat="server" Height="24px" Style="font-weight: normal; left: 0px;
            color: blue; position: absolute; top: 70px; text-align: center" Text="Your KPIN"
            Width="100%"></asp:Label>
        <asp:Label ID="LabelKPIN" runat="server" Height="24px" Style="font-weight: bold; left: 0px;
            color: blue; position: absolute; top: 95px; text-align: center" Text="Your Information"
            Width="100%"></asp:Label>
        <asp:Label ID="LabelSafe" runat="server" Height="24px" Style="font-weight: normal; left: 0px;
            color: blue; position: absolute; top: 135px; text-align: center" Text="Please record your secret KPIN safely for login."
            Width="100%"></asp:Label>
        <asp:ImageButton ID="ButtonContinue" runat="server" Height="24px" ImageUrl="~/Images/button_continue.gif"
            Style="left: 256px; position: absolute; top: 175px" Width="64px" />
    </asp:Panel>
</asp:Content>


