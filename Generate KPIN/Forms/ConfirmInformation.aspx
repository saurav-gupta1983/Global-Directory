<%@ Page Language="VB" MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="ConfirmInformation.aspx.vb" Inherits="ConfirmInformation" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">

<asp:Panel ID="PanelWrapper" runat="server" Height="376px" Width="470px" 
style="left: 150px; position: absolute; top: 20px; z-index: 101;">

        <asp:Label ID="LabelInfo" runat="server" Style="font-weight: bold; left: 0px; color: #ff00ff;
        position: absolute; top: 0px; text-align: center" Text="Your Information" Width="470px" Height="16px"></asp:Label>
        
    <table border="0" cellpadding="0" cellspacing="0" style="position: absolute; left: 0px; width: 470px; top: 30px;">
        <tr>
            <td style="width: 184px">
                <asp:Label ID="LabelName" runat="server" Text="Name" Width="184px" style="font-weight: bold" ></asp:Label></td>
            <td style="width: 316px; ">
                &nbsp;<asp:Label ID="LabelNameInfo" runat="server" Text="Name" Width="216px" style="font-weight: bold; color: blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="LabelDOB" runat="server" Text="Date of Birth" Width="184px" style="font-weight: bold" ></asp:Label></td>
            <td style="width: 316px; ">
                &nbsp;<asp:Label ID="LabelDOBInfo" runat="server" Text="Date of Birth" Width="216px" style="font-weight: bold; color: blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="LabelNationality" runat="server" Text="Nationality" Width="184px" style="font-weight: bold" ></asp:Label></td>
            <td style="width: 316px; ">
                &nbsp;<asp:Label ID="LabelNationalityInfo" runat="server" Text="Nationality" Width="216px" style="font-weight: bold; color: blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 184px">
            </td>
            <td style="width: 316px">
            </td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="LabelFathersName" runat="server" Text="Fathers Name" Width="184px" style="font-weight: bold" ></asp:Label></td>
            <td style="width: 316px; ">
                &nbsp;<asp:Label ID="LabelFathersNameInfo" runat="server" Text="Fathers Name" Width="216px" style="font-weight: bold; color: blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="LabelMothersName" runat="server" Text="Mothers Name" Width="184px" style="font-weight: bold" ></asp:Label></td>
            <td style="width: 316px; ">
                &nbsp;<asp:Label ID="LabelMothersNameInfo" runat="server" Text="Mothers Name" Width="216px" style="font-weight: bold; color: blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="LabelSpouseName" runat="server" Text="SpouseName" Width="184px" style="font-weight: bold" ></asp:Label></td>
            <td style="width: 316px; ">
                &nbsp;<asp:Label ID="LabelSpouseNameInfo" runat="server" Text="SpouseName" Width="216px" style="font-weight: bold; color: blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 184px">
            </td>
            <td style="width: 316px">
            </td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="LabelPerAdd" runat="server" Text="Permanent Address" Width="184px" style="font-weight: bold" ></asp:Label></td>
            <td style="width: 316px; ">
                &nbsp;<asp:Label ID="LabelPerAddInfo" runat="server" Text="Permanent Address" Width="216px" style="font-weight: bold; color: blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="LabelTempAdd" runat="server" Text="Temporary Address" Width="184px" style="font-weight: bold" ></asp:Label></td>
            <td style="width: 316px; ">
                &nbsp;<asp:Label ID="LabelTempAddInfo" runat="server" Text="Temporary Address" Width="216px" style="font-weight: bold; color: blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="LabelCountry" runat="server" Text="Country" Width="184px" style="font-weight: bold" ></asp:Label></td>
            <td style="width: 316px; ">
                &nbsp;<asp:Label ID="LabelCountryInfo" runat="server" Text="Country" Width="216px" style="font-weight: bold; color: blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="LabelMobile" runat="server" Text="Mobile No" Width="184px" style="font-weight: bold" ></asp:Label></td>
            <td style="width: 316px; ">
                &nbsp;<asp:Label ID="LabelMobileInfo" runat="server" Text="Mobile No" Width="216px" style="font-weight: bold; color: blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="LabelRes" runat="server" Text="Residence Number" Width="184px" style="font-weight: bold" ></asp:Label></td>
            <td style="width: 316px; ">
                &nbsp;<asp:Label ID="LabelResInfo" runat="server" Text="Residence Number" Width="216px" style="font-weight: bold; color: blue"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 184px">
                <asp:Label ID="LabelEmail" runat="server" Text="Email Id" Width="184px" style="font-weight: bold" ></asp:Label></td>
            <td style="width: 316px; ">
                &nbsp;<asp:Label ID="LabelEmailInfo" runat="server" Text="Email Id" Width="216px" style="font-weight: bold; color: blue"></asp:Label></td>
        </tr>
    </table>
    <asp:Label ID="LabelMessage" runat="server" Style="left: 0px; color: red; position: absolute;
        top: 320px" Text="*Verify your Information. Information once entered cannot be modified."
        Width="470px"></asp:Label>
    <asp:Button ID="ButtonConfirm" runat="server" Style="left: 104px; position: absolute;
        top: 352px" Text="Confirm" Width="96px" />
    <asp:Button ID="ButtonEdit" runat="server" Style="left: 240px; position: absolute;
        top: 352px" Text="Edit" Width="88px" />
        
</asp:Panel>
</asp:Content>

