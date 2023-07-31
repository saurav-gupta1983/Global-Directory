<%@ Page Language="VB"  THEME="LabelSkin"  MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="SearchDirectory.aspx.vb" Inherits="SearchDirectory" title="Search Directory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">

<%--    <asp:Panel ID="PanelSelectButton" runat="server" Height="25px" width="464" style="position: relative; left: 240px; top: 48px;">
    <table style="z-index: 101; left: 0px; position: absolute; top: 0px; height: 25px;">
        <tr>
            <td style="width: 20px; ">
                <asp:Button ID="ButtonSearchMem" runat="server" Text="Search a Member" /></td>
            <td style="width: 20px; ">
                <asp:Button ID="ButtonSendRequest" runat="server" Text="Send Message to Group" /></td>
        </tr>
    </table>
    </asp:Panel>
    
    <asp:Panel ID="PanelSearchMember" runat="server" Height="344px" Width="464px" style="position: relative; left: 240px; top: 50px;">
    <table style="z-index: 101; left: 0px; position: absolute; top: 0px; width: 464px; height: 189px;">
        <tr>
            <td style="width: 66px; background-color: #0099ff;">
                <asp:Label ID="LabelSearch" runat="server" Style="font-weight: bold; z-index: 100;
                    left: 0px; position: relative; top: 0px" Text="Search a Member" Width="448px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 66px; height: 59px; background-color: #ffccff;">
                <asp:Label ID="LabelDesc" runat="server" Height="48px" Style="z-index: 100; left: 4px;
                    position: relative; top: 0px" Text="Are you trying to get in touch with a friend, but do not know his e-mail? Look up your friend in GlobalDirectory.com directory and send him/her an e-mail."
                    Width="456px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 66px; height: 33px;">
                <asp:Label ID="LabelFirst" runat="server" Style="z-index: 100; left: 0px; position: relative;
                    top: 12px" Text="First Name" Width="196px" Height="20px"></asp:Label>
                <asp:TextBox ID="TextBoxFirstName" runat="server" Style="z-index: 100; left: 196px; position: relative;
                    top: -10px" Width="256px"></asp:TextBox>
            </td>
        </tr>
       <tr>
            <td style="width: 66px; height: 21px">
                <asp:Label ID="LabelLastName" runat="server" Style="z-index: 100; left: 0px; position: relative;
                    top: 12px" Text="Last Name" Width="196px" Height="20px"></asp:Label>
                <asp:TextBox ID="TextBoxLastName" runat="server" Style="z-index: 100; left: 196px; position: relative;
                    top: -10px" Width="256px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 66px; height: 21px">
                <asp:Label ID="LabelCity" runat="server" Style="z-index: 100; left: 0px; position: relative;
                    top: 12px" Text="City" Width="196px" Height="20px"></asp:Label>
                <asp:TextBox ID="TextBoxCity" runat="server" Style="z-index: 100; left: 196px; position: relative;
                    top: -10px" Width="256px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 66px; height: 21px">
                <asp:Label ID="LabelCountry" runat="server" Style="z-index: 100; left: 0px; position: relative;
                    top: 12px" Text="Country" Width="196px" Height="20px"></asp:Label>
                <asp:TextBox ID="TextBoxCountry" runat="server" Style="z-index: 100; left: 196px; position: relative;
                    top: -10px" Width="256px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 66px; height: 28px">
                <asp:Button ID="ButtonSearch" runat="server" Style="z-index: 100; left: 184px; position: relative;
                    top: 0px" Text="Search" />
            </td>
        </tr>
         <tr>
            <td style="width: 66px; height: 28px">
                <asp:Label ID="LabelErrorMessage" runat="server" Style="z-index: 100;
                 left: 0px; color: red; position: relative; top: 0px" Width="460px"></asp:Label>
            </td>
        </tr>
    </table>
    </asp:Panel>
--%>    
   <asp:Panel ID="PanelSendMessage" runat="server" Height="500px" Width="464px" style="position: relative; left: 140px; top: 50px;">
       <table style="z-index: 101; left: 0px; position: relative; top: 0px; width: 460px; height: 20px;">
            <tr>
                <td style="width: 189px; background-color: #0099ff;">
                    <asp:Label ID="LabelSearchMem" runat="server" Style="font-weight: bold; z-index: 100;
                        left: 0px; position: relative; top: 0px" Text="Search a Member" Width="456px"></asp:Label>
                </td>
            </tr>
       </table>
       <table style="z-index: 101; left: 0px; position: relative; top: 0px; width: 456px; height: 20px;">
            <tr>
                <td style="width: 170px; height: 60px; background-color: #ffccff;">
                    <asp:Label ID="LabelSendDesc" runat="server" Height="50px" Style="z-index: 100; left: 4px;
                        position: relative; top: 0px" Text="Are you trying to get in touch with a friend, but do not know his e-mail? Look up your friend in GlobalDirectory.com directory and send him/her an e-mail."
                        Width="456px"></asp:Label>
                </td>
            </tr>
        </table>
       <table style="z-index: 101; left: 0px; position: relative; top: 0px; width: 464px; height: 20px;">
            <tr>
                <td style="width: 155px; height: 20px; background-color: #ffccff;">
                    <asp:Label ID="LabelFilterCriteria" runat="server" Height="20px" Style="z-index: 100; left: 4px;
                        position: relative; top: 0px; text-align: center; font-weight: bold;" Text="Filter Criteria"
                        Width="140px"></asp:Label>
                </td>
                <td style="width: 155px; height: 20px; background-color: #ffccff;">
                    <asp:Label ID="LabelValue" runat="server" Height="20px" Style="z-index: 100; left: 4px;
                        position: relative; top: 0px; text-align: center; font-weight: bold;" Text="Filter Value"
                        Width="140px"></asp:Label>
                </td>
                <td style="width: 155px; height: 20px; background-color: #ffccff;">
                    <asp:Label ID="LabelConcatenate" runat="server" Height="20px" Style="z-index: 100; left: 4px;
                        position: relative; top: 0px; text-align: center; font-weight: bold;" Text=""
                        Width="140px"></asp:Label>
                </td>
            </tr>
        </table>
       <table style="z-index: 101; left: 0px; position: relative; top: 0px; width: 464px; height: 20px;">
            <tr>
                <td style="width: 155px; height: 20px; ">
                    <asp:DropDownList ID="DropDownListFilterCriteria1" runat="server" style="width: 145px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="FirstName">First Name</asp:ListItem>
                        <asp:ListItem Value="LastName">Last Name</asp:ListItem>
<%--                        <asp:ListItem Value="Sex">Sex (M/F)</asp:ListItem>
                        <asp:ListItem Value="MaritalStatus">Marital Status (Single/Married)</asp:ListItem>
--%>                        <asp:ListItem Value="City">City</asp:ListItem>
                        <asp:ListItem Value="Country">Country</asp:ListItem>
<%--                        <asp:ListItem Value="AnnualIncome">Salary</asp:ListItem>
                        <asp:ListItem Value="YrsofExp">Years of Experience</asp:ListItem>
                        <asp:ListItem Value="Type">Property Type</asp:ListItem>
--%>                    </asp:DropDownList>
                </td>
                <td style="width: 155px; height: 20px; ">
                    <asp:TextBox ID="TextBoxFilterValue" runat="server" Style="Width: 150px"></asp:TextBox>
                </td>
                <td style="width: 155px; height: 20px; ">
                    <asp:DropDownList ID="DropDownList2" runat="server" style="width: 145px">
                        <asp:ListItem Value=" AND ">AND</asp:ListItem>
                        <asp:ListItem Value=" OR ">OR</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 155px; height: 20px; ">
                    <asp:DropDownList ID="DropDownListFilterCriteria2" runat="server" style="width: 145px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="FirstName">First Name</asp:ListItem>
                        <asp:ListItem Value="LastName">Last Name</asp:ListItem>
                        <asp:ListItem>City</asp:ListItem>
                        <asp:ListItem>Country</asp:ListItem>
                        <asp:ListItem>Salary</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 155px; height: 20px; ">
                    <asp:TextBox ID="TextBox1" runat="server" Style="Width: 150px"></asp:TextBox>
                </td>
                <td style="width: 155px; height: 20px; ">
                    <asp:DropDownList ID="DropDownList3" runat="server" style="width: 145px">
                        <asp:ListItem Value=" AND ">AND</asp:ListItem>
                        <asp:ListItem Value=" OR ">OR</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 155px; height: 20px; ">
                    <asp:DropDownList ID="DropDownListFilterCriteria3" runat="server" style="width: 145px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="FirstName">First Name</asp:ListItem>
                        <asp:ListItem Value="LastName">Last Name</asp:ListItem>
                        <asp:ListItem Value="City">City</asp:ListItem>
                        <asp:ListItem Value="Country">Country</asp:ListItem>
<%--                        <asp:ListItem Value="Salary">Salary</asp:ListItem>
--%>                    </asp:DropDownList>
                </td>
                <td style="width: 155px; height: 20px; ">
                    <asp:TextBox ID="TextBox2" runat="server" Style="Width: 150px"></asp:TextBox>
                </td>
                <td style="width: 155px; height: 20px; ">
<%--                    <asp:DropDownList ID="DropDownList5" runat="server" style="width: 145px">
                    </asp:DropDownList>--%>   
             </td>
            </tr>
        </table>
        <table style="z-index: 101; left: 0px; position: relative; top: 0px; width: 464px; height: 20px;">
        <tr>
            <td></td>
            <td style="width: 66px; height: 28px">
               <asp:ImageButton ID="ButtonSearch" runat="server" Height="24px" ImageUrl="~/Images/Button_Search.gif"
                    Style="left: 0px; position: relative; top: 0px" Width="104px" />
            </td>
            <td></td>
        </tr>
        </table>
        <table style="z-index: 101; left: 0px; position: relative; top: 0px; width: 464px; height: 20px;">
         <tr>
            <td style="width: 66px; height: 28px">
                <asp:Label ID="LabelErrorMessage" runat="server" Style="z-index: 100;
                 left: 0px; color: red; position: relative; top: 0px" Width="460px"></asp:Label>
            </td>
        </tr>
        </table>
    </asp:Panel>
</asp:Content>

