<%@ Page Language="VB" THEME="LabelSkin" MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="MembersInfo.aspx.vb" Inherits="MembersInfo" title="Member - Personal Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

// ]]>
</script>
    <div style="text-align: left">
<%--    <asp:Label SkinID="LabelDetails" ID="LabelDetails" runat="server" Style="left: 10px; position: absolute; top: 96px; font-weight: bold; background-color: #3366ff; text-align: right; color: aqua;"
        Text="Label" Width="920px" Height="24px"></asp:Label>
        
    <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; width: 232px;
        position: relative; top: 0px; height: 28px; z-index: 102;">
            <tr>
                <td style="width: 234px; position: absolute; height: 21px">
                    <asp:HyperLink SkinID="LabelHome" ID="HyperLinkHome" runat="server" Style="z-index: 100; left: 0px; position: absolute;
                        top: 0px" Width="220px" NavigateUrl="~/Forms/MembersInfo.aspx">Home</asp:HyperLink></td>
            </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="left: 684px; width: 232px;
        position: relative; top: 0px; height: 28px; z-index: 102;">
            <tr>
                <td style="width: 236px; position: absolute; height: 21px">
                    <asp:HyperLink ID="HyperLinkLogOut" SkinID="LabelSignOut" runat="server" Style="z-index: 100; left: 44px; position: relative;
                        top: 0px; text-align: right;" Width="192px"  NavigateUrl="~/Forms/Logout.aspx">Sign Out</asp:HyperLink></td>
            </tr>
    </table>
--%>     
<asp:Panel ID="PanelWrapper" runat="server" Style="left: 0px; position: absolute; top: 30px" Width="750px" Height="500px">
    <table border="0" cellpadding="0" cellspacing="0" style="left: 90px; width: 570px;
        position: absolute; top: 0px; height: 25px; z-index: 103;">
        <tr>
            <td style="width: 180px; height: 25px; text-align: left; vertical-align: middle;">
                  <asp:HyperLink ID="HyperLinkLinktoKPIN" runat="server" Style="position: relative; left: 0px; top: 0px; text-align: left;" NavigateUrl="~/Forms/LinktoKPIN.aspx">Link to KPIN</asp:HyperLink>
            </td>
            <td style="width: 165px; height: 25px; text-align: center; vertical-align: middle;">
                  <asp:HyperLink ID="HyperLinkReports" runat="server" Style="position: relative; left: 0px; top: 0px; text-align: centered;" NavigateUrl="~/Forms/GenerateReports.aspx">Generate Reports</asp:HyperLink>
            </td>
           <td style="width: 190px; height: 25px; text-align: center; vertical-align: middle; ">
                <asp:HyperLink ID="HyperLinkAdmin" runat="server" NavigateUrl="~/Forms/Admin.aspx"
                    Style="left: 0px; position: relative; top: 0px; text-align: centered;" Width="125px" Height="20px">Admin</asp:HyperLink>
           </td>
           <td style="width: 125px; height: 25px; text-align: right; vertical-align: middle;">
                <asp:HyperLink ID="HyperLinkChangePassword" runat="server" NavigateUrl="~/Forms/ChangePassword.aspx"
                    Style="left: 0px; position: relative; top: 0px; text-align: right;" Height="20px"  Width="125px" Target="_blank">Change Password</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="width: 180px; height: 25px; text-align: left; vertical-align: middle;">
                  <asp:HyperLink ID="HyperLinkMailList" runat="server" Style="position: relative; left: 0px; top: 0px; text-align: left;" NavigateUrl="~/Forms/InBox.aspx">View your Mail Box</asp:HyperLink>
            </td>
             <td style="width: 165px; height: 25px; text-align: center; vertical-align: middle;">
                <asp:HyperLink ID="HyperLinkSearch" runat="server" NavigateUrl="~/Forms/SearchDirectory.aspx"
                    Style="left: 0px; position: relative; top: 0px; text-align: center;" Height="20px">Search a Member</asp:HyperLink>
            </td>
             <td style="width: 190px; height: 25px; text-align: center; vertical-align: middle;">
                <asp:HyperLink ID="HyperLinkOrgChart" runat="server" NavigateUrl="~/Forms/OrgChart.aspx"
                    Style="left: 0px; position: relative; top: 0px; text-align: center;" Height="20px" Target="_blank">View Family Chart</asp:HyperLink>
            </td>
           <td style="width: 125px; height: 25px; text-align: right; vertical-align: middle;">
                <asp:HyperLink ID="HyperLinkUpload" runat="server" NavigateUrl="~/Forms/Upload.aspx"
                    Style="left: 0px; position: relative; top: 0px; text-align: right;" Height="20px"  Width="125px" Target="_blank">Upload your Photo</asp:HyperLink>
            </td>
        </tr>
     </table>    

    <table border="0" cellpadding="0" cellspacing="0" style="left: 90px; position: absolute; background-color: mediumpurple; top: 60px; width: 570px; height: 20px; text-align: left;">
        <tr>
            <td style="width: 570px; text-align: left; font-weight: bold; height: 20px; color: white;">
                &nbsp;Member Details
                </td>
        </tr>
    </table>
        
        <table border="0" cellpadding="0" cellspacing="0" style="left: 90px; width: 570px;
            position: absolute; top: 90px; height: 120px; z-index: 102;">
            <tr>
                <td style="width: 151px; height: 24px;">
                    First Name</td>
                <td style="width: 128px; height: 24px; color: red;">
                    <asp:TextBox ID="TextBoxFirstName" runat="server" Style="width: 250px; position: relative; z-index: 103; left: 0px; top: 0px;"
                        Width="216px" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 151px; height: 5px;">
                    </td>
                <td style="width: 128px; height: 5px;">
                    </td>
            </tr>
           <tr>
                <td style="width: 151px; height: 24px">
                    Middle Name</td>
                <td style="width: 128px; height: 24px; color: red;">
                    <asp:TextBox ID="TextBoxMiddleName" runat="server" Style="position: relative; width: 250px;"
                        Width="248px" Enabled="False"></asp:TextBox></td>
           </tr>
            <tr>
                <td style="width: 151px; height: 5px;">
                    </td>
                <td style="width: 128px; height: 5px;">
                    </td>
            </tr>
            <tr>
                <td style="width: 151px; height: 24px;">
                    Last Name</td>
                <td style="width: 128px; height: 24px; color: red;">
                    <asp:TextBox ID="TextBoxLastName" runat="server" Style="position: relative; width: 250px;"
                        Width="248px" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 151px; height: 5px;">
                    </td>
                <td style="width: 128px; height: 5px;">
                    </td>
            </tr>
            <tr>
                <td style="width: 151px; height: 24px;">
                    Date of Birth</td>
                <td style="width: 128px; height: 24px;">
                    <asp:TextBox ID="TextBoxDateofBirth" runat="server" Style="width: 250px; position: relative; z-index: 103; left: 0px; top: 0px;"
                        Width="216px" Enabled="False"></asp:TextBox></td>
            </tr>
         </table>           
        <asp:HyperLink ID="HyperLinkUpdateInformation" runat="server" NavigateUrl="~/Forms/FamilyDetails.aspx"
            Style="left: 90px; position: absolute; top: 230px; text-align: center;" Width="570px" Height="20px">Update your Information</asp:HyperLink>
</asp:Panel>
            </div>
</asp:Content>
