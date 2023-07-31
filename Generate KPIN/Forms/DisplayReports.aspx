<%@ Page Language="VB" MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false"
    CodeFile="DisplayReports.aspx.vb" Inherits="Forms_DisplayReports" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" runat="Server">
    <asp:Panel ID="PanelWrapper" runat="server" Style="left: 0px; position: absolute;
        top: 30px" Width="750px" Height="500px">
        <table border="0" cellpadding="0" cellspacing="0" style="left: 90px; position: absolute;
            background-color: mediumpurple; top: 0px; width: 570px; height: 20px; text-align: left;">
            <tr>
                <td>
                    <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"
                        displaygrouptree="False" displaytoolbar="False" enabledatabaselogonprompt="False"
                        enableparameterprompt="False" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
