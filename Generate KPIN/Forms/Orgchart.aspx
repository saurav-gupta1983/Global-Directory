<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Orgchart.aspx.vb" Inherits="Orgchart" %>

<%@ Register Src="../User Controls/Box.ascx" TagName="Box" TagPrefix="uc2" %>
<%@ Register Src="../User Controls/WebUserControlChildList.ascx" TagName="WebUserControlChildList"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Org Chart</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="0" cellspacing="0" border="0" style="vertical-align: bottom;
                text-align: center;">
                <tr>
                    <td>
                        <uc1:WebUserControlChildList ID="WebUserControlSiblingList" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
