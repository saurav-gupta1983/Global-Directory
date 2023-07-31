<%@ Page Language="VB" MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false"
    CodeFile="MembersForm.aspx.vb" Inherits="MembersForm" Title="Member Details" %>

<%@ Register Src="../User Controls/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc1" %>
<%@ Register Src="../User Controls/WebUserControlEmail.ascx" TagName="WebUserControlEmail"
    TagPrefix="uc2" %>
<%@ Register Src="../User Controls/WebUserControlName.ascx" TagName="WebUserControlName"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

// ]]>
    </script>

    <div style="text-align: left">
        <asp:Panel ID="PanelWrapper" runat="server" Style="left: 0px; position: absolute;
            top: 0px" Width="750px" Height="750px">
            <asp:Panel ID="PanelInformation" runat="server" Style="left: 0px; position: absolute;
                top: 0px" Width="750px" Height="600px">
                <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; width: 570px;
                    position: absolute; top: 25px; height: 25px; z-index: 102;">
                    <tr>
                        <td style="width: 100px; position: absolute; height: 33px">
                            <asp:Label ID="LabelInfo" runat="server" Height="12px" Style="z-index: 100; left: 0px;
                                position: relative; top: 0px; color: red;" Text="Please enter correct and valid information only. We need to consolidate the details of each individual and you can do your part."
                                Width="570px"></asp:Label></td>
                    </tr>
                </table>
                <asp:Label ID="LabelDate" runat="server" Height="15px" Style="left: 360px; position: absolute;
                    top: 80px; text-align: right;" Width="304px"></asp:Label>
                &nbsp;
                <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; position: absolute;
                    top: 100px; width: 570px; height: 24px; text-align: left;">
                    <tr>
                        <td style="width: 570px; text-align: left; background-color: mediumpurple; font-weight: bold;
                            height: 20px; color: white;">
                            &nbsp;Member Details
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; width: 570px;
                    position: absolute; top: 130px; height: 120px; z-index: 102;">
                    <tr>
                        <td style="width: 256px; height: 24px; color: red;">
                            Sex</td>
                        <td style="width: 128px; height: 24px; color: red;">
                            <asp:DropDownList ID="DropDownListSex" runat="server" AutoPostBack="False" Width="112px">
                                <asp:ListItem Selected="True" Value="0">Male</asp:ListItem>
                                <asp:ListItem Value="1">Female</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 256px; height: 24px; color: red;">
                            First Name</td>
                        <td style="width: 128px; height: 24px; color: red;">
                            <asp:TextBox ID="TextBoxFirstName" runat="server" Style="width: 250px; position: absolute;"
                                Width="216px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 256px; height: 24px">
                            Middle Name(if applicable)</td>
                        <td style="width: 128px; height: 24px; color: red;">
                            <asp:TextBox ID="TextBoxMiddleName" runat="server" Style="position: absolute; width: 250px;"
                                Width="248px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 256px; height: 24px; color: red;">
                            Last Name</td>
                        <td style="width: 128px; height: 24px; color: red;">
                            <asp:TextBox ID="TextBoxLastName" runat="server" Style="position: absolute; width: 250px;"
                                Width="248px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 13px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 256px; height: 24px; color: red;">
                            Date of Birth</td>
                        <td style="width: 128px; height: 24px;">
                            <uc1:WebUserControl ID="WebUserControlDOB" runat="server" Visible="true"></uc1:WebUserControl>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; width: 570px;
                    position: absolute; top: 270px; height: 24px; z-index: 102;">
                    <tr>
                        <td style="width: 275px; height: 24px; color: red;">
                            Email Id</td>
                        <td style="width: 400px; height: 24px;">
                            <uc2:WebUserControlEmail ID="WebUserControlEmail" runat="server" />
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; width: 570px;
                    position: absolute; top: 330px; height: 55px;">
                    <tr>
                        <td style="height: 24px; color: red; width: 164px;">
                            Password</td>
                        <td style="height: 24px; width: 237px;">
                            <input id="Password" runat="server" style="position: absolute; width: 248px;" type="password" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 7px; width: 164px;">
                        </td>
                        <td style="height: 7px; width: 237px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 24px; color: red; width: 164px;">
                            Confirm Password</td>
                        <td style="height: 24px; width: 237px;">
                            <input id="PasswordConf" runat="server" style="position: absolute; width: 248px;"
                                type="password" />
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; position: absolute;
                    top: 420px; width: 570px; height: 24px; text-align: left;">
                    <tr>
                        <td style="width: 570px; text-align: left; background-color: mediumpurple; font-weight: bold;
                            height: 20px; color: white;">
                            &nbsp;Family Details</td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; width: 570px;
                    position: absolute; top: 450px; height: 180px; z-index: 102;">
                    <tr>
                        <td style="width: 149px; height: 60px; color: red;">
                            Father's Name</td>
                        <td style="width: 210px; height: 24px;">
                            <uc3:WebUserControlName ID="WebUserControlFathersName" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 149px; height: 20px;">
                        </td>
                        <td style="width: 128px; height: 20px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 149px; height: 60px; color: red;">
                            Mother's Name</td>
                        <td style="width: 210px; height: 24px;">
                            <uc3:WebUserControlName ID="WebUserControlMothersName" runat="server" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="PanelSubmit" runat="server" Height="50px" Width="570px" Style="left: 100px;
                position: absolute; top: 680px">
                <asp:Button ID="ButtonSubmit" runat="server" Style="position: absolute;" Text="Submit"
                    Width="80px" />
                <asp:Label ID="LabelPersonalDetails" runat="server" Style="position: absolute; color: red;
                    text-align: right; left: 88px; top: 0px; vertical-align: middle;" Width="480px"
                    Height="24px"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="PanelWarning" runat="server" Height="210px" Width="570px" Style="left: 100px;
                position: absolute; top: 30px">
                <table border="1" cellpadding="0" cellspacing="0" style="left: 0px; width: 570px;
                    position: absolute; top: 0px;">
                    <tr style="height: 20px;">
                        <td style="color: black;">
                            Name</td>
                        <td style="color: blue;">
                            <asp:Label ID="LabelName" runat="server"></asp:Label></td>
                    </tr>
                    <tr style="height: 20px;">
                        <td style="color: black;">
                            Sex</td>
                        <td style="color: blue;">
                            <asp:Label ID="LabelSex" runat="server"></asp:Label></td>
                    </tr>
                    <tr style="height: 20px;">
                        <td style="color: black;">
                            Date of Birth</td>
                        <td style="color: blue;">
                            <asp:Label ID="LabelDOB" runat="server"></asp:Label></td>
                    </tr>
                    <tr style="height: 20px;">
                        <td style="color: black;">
                            Email ID</td>
                        <td style="color: blue;">
                            <asp:Label ID="LabelEmailID" runat="server"></asp:Label></td>
                    </tr>
                    <tr style="height: 20px;">
                        <td style="color: black;">
                            Father's Name</td>
                        <td style="color: blue;">
                            <asp:Label ID="LabelFathersName" runat="server"></asp:Label></td>
                    </tr>
                    <tr style="height: 20px;">
                        <td style="color: black;">
                            Mother's Name</td>
                        <td style="color: blue;">
                            <asp:Label ID="LabelMothersName" runat="server"></asp:Label></td>
                    </tr>
                    <tr style="height: 20px;">
                        <td style="color: black;">
                            Would like to have KPIN?</td>
                        <td style="color: blue;">
                            <asp:RadioButton ID="RadioButtonSimple" runat="server" GroupName="Complexity" Text="Simple" Checked=true />
                            <asp:RadioButton ID="RadioButtonComplex" runat="server" GroupName="Complexity" Text="Complex" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="LabelWarning" runat="server" Style="left: 0px; position: absolute;
                    top: 170px; color: red; text-align: left;" Width="568px" Height="24px"></asp:Label>
                <asp:ImageButton ID="ButtonNo" runat="server" ImageUrl="~/Images/Button_No.gif" Style="position: absolute;
                    left: 192px; top: 210px;" Width="40" Height="20px" />
                <asp:ImageButton ID="ButtonYes" runat="server" ImageUrl="~/Images/Button_Yes.gif"
                    Style="position: absolute; left: 272px; top: 210px;" Width="40px" Height="20px" />
            </asp:Panel>
        </asp:Panel>
    </div>
</asp:Content>
