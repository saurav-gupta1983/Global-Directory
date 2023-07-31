<%@ Page Language="VB" THEME="LabelSkin" MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="Admin.aspx.vb" Inherits="Forms_Admin" title="Provide Access and Approve Request" %>

<%@ Register Src="../User Controls/WebUserControlCalendar.ascx" TagName="WebUserControlCalendar"
    TagPrefix="uc1" %>
<asp:Content ID="ContentAdmin" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">

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
                    <asp:HyperLink ID="HyperLinkLogOut" SkinID="LabelSignOut" runat="server" Style="z-index: 100; left: 44px; position: absolute;
                        top: 0px; text-align: right;" Width="192px"  NavigateUrl="~/Forms/Logout.aspx">Sign Out</asp:HyperLink></td>
            </tr>
    </table>
--%>    
    <asp:Panel ID="PanelMenu" runat="server" Height="200px" Width="475px" style="position: relative; left: 150px; top: 56px;">
    <table border="2" style="position: relative; left: 0px; top: 0px;">
            <tr>
                <td style="background-color: mediumpurple; font-weight: bold; height: 20px; color: white;">
                   <asp:Label ID="LabelRequest" runat="server" Style="text-align: center" Text="Administrator Roles" Width="470px"></asp:Label>
               </td>
            </tr>
    <tr style="height: 60px">
    <td>
       <table style="position: relative; left: 0px; top: 10px;">
            <tr>
                <td style="width: 100px; position: relative">
                    <asp:HyperLink ID="HyperLinkPendingRequests" runat="server" Width="232px" NavigateUrl="~/Forms/RedirecttoDetails.aspx?Details=Pending">Pending Requests</asp:HyperLink></td>
                <td style="width: 100px">
                    <asp:HyperLink ID="HyperLinkAllRequests" runat="server" Width="232px"  NavigateUrl="~/Forms/RedirecttoDetails.aspx?Details=All">All Requests</asp:HyperLink></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:HyperLink ID="HyperLinkProvideAccess" runat="server" Width="232px" NavigateUrl="~/Forms/RedirecttoDetails.aspx?Details=Administrator" Visible="True">Provide Admin access / View Family Tree</asp:HyperLink></td>
            </tr>
        </table>
        </td>
        </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="PanelBack" runat="server" Height="20px" Width="475px" style="position: relative; left: 150px; top: 80px;">
         <table style="position: relative; left: 0px; top: 0px; width: 552px;">
            <tr>
               <td style="width: 468px; text-align: center;">
                   <asp:Button ID="ButtonBack" runat="server" Text="Back" Width="56px" /></td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="PanelAdminAccess" runat="server" Height="500px" Width="475px" style="position: relative; left: 150px; top: 100px;" Visible="False">
         <table style="position: relative; left: 0px; top: 20px; width: 475px">
<%--            <tr>
                <td style="background-color: mediumpurple; font-weight: bold; height: 20px; color: white;">
                   <asp:Label ID="LabelAdminAccess" runat="server" Style="text-align: center" Text="Provide Administrator Access" Width="470px"></asp:Label>
               </td>
            </tr>
--%>
            <tr>
                <td style="height: 20px; width: 200px" align="right">
                    <asp:Label ID="KPIN" runat="server" Width="56px" >KPIN: </asp:Label>&nbsp;&nbsp;
               </td>
                <td style="height: 20px; width: 275px">
                    &nbsp;&nbsp;<asp:TextBox ID="TextBoxKPIN" runat="server" Width="200px"></asp:TextBox>
               </td>
            </tr>
            <tr>
                <td style="height: 10px; " colspan="2" align="center">
               </td>
            </tr>
            <tr>
                <td style="font-weight: bold; height: 20px; " colspan="2" align="center">
                    <asp:Button ID="ButtonTree" runat="server" Text="View Family Tree" />&nbsp;&nbsp;
                    <asp:Button ID="ButtonAccess" runat="server" Text="Provide Admin Access" />
               </td>
            </tr>
            <tr>
                <td style="height: 2px; " colspan="2" align="center">
               </td>
            </tr>
            <tr>
                <td style="font-weight: bold; height: 20px;color: Red " colspan="2" align="center">
                    <asp:Label ID="Label1" runat="server" Text="KPIN does not exist."></asp:Label>
               </td>
            </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="PanelPendingRequest" runat="server" Height="88px" Width="655px" style="position: relative; left: 60px; top: 100px;">
         <table style="position: relative; left: 0px; top: 0px;">
            <tr>
                <td style="background-color: mediumpurple; font-weight: bold; height: 20px; color: white;">
                   <asp:Label ID="LabelPending" runat="server" Style="text-align: center" Text="Pending Requests" Width="650px"></asp:Label>
               </td>
            </tr>
        </table>
        <table style="position: relative; left: 0px; top: 0px;">
            <tr>
            <td style="width: 650px">
                <asp:GridView ID="GridViewPending" runat="server" AllowPaging="True" CellPadding="4" DataSourceID="SqlDataSourcePending"
                    ForeColor="#333333" GridLines="None" Width="650px" AutoGenerateColumns="False">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="ApproveRequest" Text="Approve" />
                        <asp:ButtonField ButtonType="Button" CommandName="RejectRequest" Text="Reject" />
                        <asp:BoundField DataField="Request ID" HeaderText="Request ID" InsertVisible="False"
                            SortExpression="Request ID" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Requested KPIN" HeaderText="Requested KPIN" SortExpression="Requested KPIN" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Requestor Name" HeaderText="Requestor Name" SortExpression="Requestor Name" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Requested Date" HeaderText="Requested Date" SortExpression="Requested Date" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" Visible="False">
                            <ControlStyle Width="500px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Body" HeaderText="Body" SortExpression="Body" Visible="False">
                            <ControlStyle Width="200px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="Body" DataNavigateUrlFormatString="ShowMessageBody.aspx?Body={0}"
                            DataTextField="Subject" HeaderText="Subject" Target="_blank" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourcePending" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                SelectCommand="SELECT [RequestId] As [Request ID], [RequestedByKPIN] As [Requested KPIN], [FirstName] + ' ' + LastName As [Requestor Name], CONVERT(varchar, request.RequestedDate, 106) As [Requested Date], [Subject], [Body] FROM [RequestforPublicMessage] request, [MemberInfo] Info WHERE ([isPending] = 1) and request.RequestedByKPIN = Info.KPIN">
                </asp:SqlDataSource>
            </td>
            </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="PanelAllRequest" runat="server" Height="88px" Width="750px" style="position: relative; left: 0px; top: 100px;">
         <table style="position: relative; left: 0px; top: 0px;">
            <tr>
                <td style="background-color: mediumpurple; font-weight: bold; height: 20px; color: white; width: 750px;">
                   <asp:Label ID="LabelAllRequest" runat="server" Style="text-align: center" Text="All Requests" Width="750px"></asp:Label>
               </td>
            </tr>
        </table>
        <table style="position: relative; left: 0px; top: 0px;">
            <tr>
            <td style="width: 750px">
                <asp:GridView ID="GridViewAll" runat="server" AllowPaging="True" CellPadding="4" DataSourceID="SqlDataSourceAllRequest"
                    ForeColor="#333333" GridLines="None" Width="750px" AutoGenerateColumns="False">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Request ID" HeaderText="Request ID" InsertVisible="False"
                            SortExpression="Request ID" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Requested KPIN" HeaderText="Requested KPIN" SortExpression="Requested KPIN" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Requestor Name" HeaderText="Requestor Name" SortExpression="Requestor Name" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Requested Date" HeaderText="Requested Date" SortExpression="Requested Date" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" Visible="False">
                            <ControlStyle Width="100px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="Body" DataNavigateUrlFormatString="ShowMessageBody.aspx?Body={0}"
                            DataTextField="SUbject" HeaderText="Subject" SortExpression="Subject" Target="_blank"/>
                        <asp:BoundField DataField="Body" HeaderText="Body" SortExpression="Body" Visible="False">
                            <ControlStyle Width="200px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Approved By" HeaderText="Approved By" SortExpression="Approved By">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Approved Date" HeaderText="Approved Date" SortExpression="Approved Date">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceAllRequest" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                SelectCommand="SELECT [RequestId] As [Request ID], [RequestedByKPIN] As [Requested KPIN], [FirstName] + ' ' + LastName As [Requestor Name], CONVERT(varchar, request.RequestedDate, 106) As [Requested Date], [Subject], [Body],  (Case When isApproved = 1 Then 'Approved' When isPending = 1 Then 'Pending' Else 'Rejected' End) As [Status],&#13;&#10;[ApprovedByKPIN] As [Approved By], CONVERT(varchar, request.ApprovedDate, 106) As [Approved Date] FROM [RequestforPublicMessage] request, [MemberInfo] Info WHERE request.RequestedByKPIN = Info.KPIN&#13;&#10;Order By request.RequestedDate DESC">
                </asp:SqlDataSource>
            </td>
            </tr>
        </table>
        <table style="position: relative; left: 0px; top: 0px;">
            <tr>
                <td style="font-weight: bold; height: 20px; color: white; width: 750px;">
                    <uc1:WebUserControlCalendar ID="WebUserControlCalendarArchive" runat="server" />
                    <asp:Button ID="ButtonArchive" runat="server" Text="Archive Requests" Width="168px" style="left: 240px; position: absolute; top: 3px" /></td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

