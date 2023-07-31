<%@ Import Namespace="System.Data" %>

<%@ Page Language="VB"  THEME="LabelSkin"  MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="Displaymembers.aspx.vb" Inherits="Displaymembers" title="Display Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">

<asp:Panel ID="PanelSendMessage" runat="server" Height="500px" Width="464px" style="position: relative; left: 150px; top: 70px;">
    <asp:Button ID="ButtonSendMessage" runat="server" Text="Send Message to Group" Width="176px" style="left: 128px; position: relative; top: 0px" />
         <table style="position: relative; left: 0px; top: 20px;">
            <tr>
                <td style="background-color: mediumpurple; font-weight: bold; height: 20px; color: white;">
                   <asp:Label ID="LinkKPIN" runat="server" Style="text-align: center" Text="Member List" Width="448px"></asp:Label>
               </td>
            </tr>
        </table>
<%--    <table style="z-index: 100; left: 0px; position: relative; top: 10px; padding-right: 2px; padding-left: 2px; padding-bottom: 2px; padding-top: 2px; width: 448px;" cellpadding="0" cellspacing="2" border="1">
        <tr>
            <td style="width: 200px; font-weight: bold; background-color: #f0f8ff; text-align: center;">
                Name</td>
            <td style="width: 120px; font-weight: bold; background-color: #f0f8ff; text-align: center;">
                City</td>
            <td style="width: 120px; font-weight: bold; background-color: #f0f8ff; text-align: center;">
                Country</td>
        </tr>
        <%  
            Dim MemberDataSet As DataSet
            'Dim KPIN As String
            Dim CommonObj As New CommonCode
            'KPIN = Session("KPIN")
            'Dim flag As Boolean = False
            
            'If Session("MemberInfo") Is Nothing Then
            'Dim Query As String

            'Query = "Select PINId, FirstName, MiddleName, LastName, City, Country, DateofEmail from MemberInfo MI, MailList ML where ML.KPIN = '" & _
            'KPIN & "' and ML.EmailfromKPIN = MI.KPIN"

            CommonObj.EstablishSQLConnection(Session("SearchList"), "Get")

            MemberDataSet = CommonObj.returnDataSet
            'flag = True
            'Else
            'MemberDataSet = Session("MemberInfo")
            'Session.Remove("MemberInfo")
            'End If
           
            For Each dr As DataRow In MemberDataSet.Tables(0).Rows()
         %>
        <tr>
            <%If Session("KPIN") Is Nothing Then%>
                <td style="width: 200px; height: 24px;">
                    <% =dr.Item("FirstName") & " " & dr.Item("MiddleName") & " " & dr.Item("LastName") %>
                </td>
            <%Else%>
                <td style="width: 200px; height: 24px;">
                    <a href="SendMail.aspx?PIN=<%=dr.Item("PINId")%>">
                    <%=dr.Item("FirstName") & " " & dr.Item("MiddleName") & " " & dr.Item("LastName") %>
                    </a>
                </td>
            <%End If %>
            
            <td style="width: 120px; height: 24px;">
                <%=dr.Item("City") %>
            </td>
            
            <td style="width: 120px; height: 24px;">
                <%=dr.Item("Country") %>
            </td>
        </tr>
        <%  
        Next
        %>
    </table>
--%>    
            <table style="position: relative; left: 0px; top: 18px;">
            <tr>
            <td style="width: 650px">
                <asp:GridView ID="GridViewLink" runat="server" AllowPaging="True" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" Width="448px" AutoGenerateColumns="False">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Photo">
                            <ControlStyle Height="20px" Width="20px" />
                            <ItemTemplate>
                                <a href="javascript:void(window.open('<%# Eval("PinId", "Upload.aspx?PinId={0}") %>','_blank','toolbar=no,menubar=no'))" > 
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("PinId", "Upload.aspx?PinId={0}") %>' /></a>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <a href="<%# Eval("PinId", "SendMail.aspx?PIN={0}") %>" > 
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name")%>'></asp:Label></a>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" Width="448px" AutoGenerateColumns="False">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Photo">
                            <ControlStyle Height="20px" Width="20px" />
                            <ItemTemplate>
                                <a href="javascript:void(window.open('<%# Eval("PinId", "Upload.aspx?PinId={0}") %>','_blank','toolbar=no,menubar=no'))" > 
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("PinId", "Upload.aspx?PinId={0}") %>' /></a>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
            </tr>
        </table>

    
    </asp:Panel>
    <asp:HyperLink ID="HyperLinkLogIn" runat="server" Style="z-index: 100; left: 152px; position: absolute;
                        top: 90px; text-align: center;" Width="440px" NavigateUrl="~/Forms/GlobalDirectory.aspx">Sign-In to send an email to your Friend</asp:HyperLink>
</asp:Content>

