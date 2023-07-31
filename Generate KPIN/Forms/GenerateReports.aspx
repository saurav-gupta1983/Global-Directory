<%@ Page Language="VB" MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false"
    CodeFile="GenerateReports.aspx.vb" Inherits="Forms_GenerateReports" Title="Global Directory - Generate Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" runat="Server">
    <asp:Panel ID="PanelWrapper" runat="server" Style="left: 0px; position: absolute;
        top: 30px" Width="750px" Height="500px">
        <table border="0" cellpadding="0" cellspacing="0" style="left: 90px; position: absolute;
            background-color: mediumpurple; top: 0px; width: 570px; height: 20px; text-align: left;">
            <tr>
                <td style="width: 570px; text-align: left; font-weight: bold; height: 20px; color: white;">
                    &nbsp;Generate Reports
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" style="left: 90px; width: 570px;
            position: absolute; top: 25px; height: 25px; z-index: 103;">
            <tr>
                <td colspan="3">
                    <b>
                        <asp:RadioButton ID="RadioButtonPopulation" runat="server" GroupName="Report" Text="Population"
                            AutoPostBack="True" /></b>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                    <asp:CheckBox ID="CheckBoxMFRatio" runat="server" Text="M/F Ratio" />
                </td>
                <td style="width: 200px">
                    <asp:CheckBox ID="CheckBoxAge" runat="server" Text="Age" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxCommunity" runat="server" Text="Community" Visible="False" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <b>
                        <asp:RadioButton ID="RadioButtonAverage" runat="server" GroupName="Report" Text="Average Salary"
                            AutoPostBack="True" /></b>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                    <asp:RadioButton ID="CheckBoxAvgSalary" runat="server" GroupName="Average" Text="Salary"
                        AutoPostBack="True" />
                </td>
                <td style="width: 200px">
                    <asp:RadioButton ID="CheckBoxAvgAge" runat="server" GroupName="Average" Text="Age"
                        AutoPostBack="True" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <b>
                        <asp:RadioButton ID="RadioButtonEducation" runat="server" GroupName="Report" Text="Education"
                            AutoPostBack="True" /></b>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 200px">
                    <asp:CheckBox ID="CheckBoxEmployed" runat="server" Text="Profession" />
                </td>
                <td style="width: 200px">
                    <asp:CheckBox ID="CheckBoxDegrees" runat="server" Text="Degree" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center" style="height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Button ID="ButtonReports" runat="server" Text="Reports" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelReports" runat="server" Style="left: 0px; position: absolute;
        top: 230px" Width="750px" Height="500px">
        <CR:CrystalReportViewer ID="CrystalReportViewerReports" runat="server" AutoDataBind="True"
            DisplayGroupTree="False" EnableParameterPrompt="False" Height="50px" Width="350px"
            DisplayToolbar="False" EnableDatabaseLogonPrompt="False" />
    </asp:Panel>
</asp:Content>
