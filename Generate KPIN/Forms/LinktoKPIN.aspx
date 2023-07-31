<%@ Page Language="VB" MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="LinktoKPIN.aspx.vb" Inherits="Forms_LinktoKPIN" title="Global Directory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">
    <asp:Panel ID="PanelPendingRequest" runat="server" Height="500px" Width="655px" style="position: relative; left: 60px; top: 100px;">
         <table style="position: relative; left: 0px; top: 0px;">
            <tr>
                <td style="background-color: mediumpurple; font-weight: bold; height: 20px; color: white;">
                   <asp:Label ID="LinkKPIN" runat="server" Style="text-align: center" Text="Link to KPIN" Width="650px"></asp:Label>
               </td>
            </tr>
        </table>
        <table style="position: relative; left: 0px; top: 0px;">
            <tr>
            <td style="width: 650px">
                <asp:GridView ID="GridViewLink" runat="server" AllowPaging="True" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" Width="650px" AutoGenerateColumns="False">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DateofBirth" HeaderText="Date of Birth (MM/DD/YYYY)" SortExpression="DateofBirth" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Relation" HeaderText="Relation" SortExpression="Relation" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="KPIN" HeaderText="KPIN" SortExpression="KPIN" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="DOB,Name,Relation" DataNavigateUrlFormatString="LinkKPIN.aspx?DOB={0}&Name={1}&Relation={2}"
                            Target="_blank" HeaderText="Link to KPIN" Text="Link to KPIN" />
                    </Columns>
                </asp:GridView>
            </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

