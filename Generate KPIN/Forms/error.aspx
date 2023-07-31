<%@ Page Language="VB" MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="error.aspx.vb" Inherits="Forms_error" title="Generate KPIN - Error Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">
	<table>
		<tr>
			<td style="COLOR: #c50000">An unexpected error has occurred, please try again and if problem persists, contact <a href=mailto:sysadm@globaldirectoy.com>System Administrator</a> for further assistance.</td>
		</tr>
        <tr>
			<td>
				<asp:Button id="btnError" runat="server" Text="Display Error" onclick="btnError_Click"></asp:Button>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Literal id="ltError" runat="server"></asp:Literal>
			</td>
		</tr>
		<tr>
		    <td><br /></td>
		</tr>
		<tr>
			<td style="COLOR: #c50000">We apologize for the inconvenience!!!
			</td>
		</tr>
	</table>
</asp:Content>

