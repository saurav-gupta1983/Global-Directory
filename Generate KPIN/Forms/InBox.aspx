<%@ Page Language="VB"  THEME="LabelSkin"  MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="InBox.aspx.vb" Inherits="InBox" title="Welcome to your InBox" %>

<%--<%@ Import Namespace="System.Data" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">

    <asp:Panel ID="PanelWrapper" runat="server" Height="800px" Width="670px" 
        style="left: 50px; position: relative; top: 40px; z-index: 101;">
        <table style="z-index: 100; left: 0px; position: absolute; top: 0px; padding-right: 2px; padding-left: 2px; padding-bottom: 2px; padding-top: 2px; width: 448px;" cellpadding="0" cellspacing="2" border="1">
            <tr>
                <td style="background-color: mediumpurple; font-weight: bold; height: 20px; color: white; width: 657px;">
                   <asp:Label ID="LabelInBox" runat="server" Style="text-align: center" Text="INBOX" Width="650px"></asp:Label>
               </td>
            </tr>
            <tr>
            <td style="width: 657px">
                <asp:GridView ID="GridViewInBox" runat="server" AllowPaging="True" CellPadding="4" DataSourceID="SqlDataSourceInBox"
                    ForeColor="#333333" GridLines="None" Width="650px" AutoGenerateColumns="False" AllowSorting="True">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="DeleteMail" Text="Delete" />
                        <asp:HyperLinkField DataNavigateUrlFields="PINId" DataNavigateUrlFormatString="SendMail.aspx?PIN={0}"
                            DataTextField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="MailId" HeaderText="MailId" Visible="False" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="City" HeaderText="City" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Country" HeaderText="Country" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DateofEmail" HeaderText="Mail Recieved on" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject" HeaderText="Subject" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceInBox" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="Select PINId, FirstName + ' ' + MiddleName + ' ' + LastName Name, City, Country, DateofEmail, Subject from MemberInfo MI, MailList ML Where MI.PinId = ML.PINId">
                </asp:SqlDataSource>
            </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

