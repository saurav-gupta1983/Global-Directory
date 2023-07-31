<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LinkKPIN.aspx.vb" Inherits="Forms_LinkKPIN" %>

<%@ Register Src="../User Controls/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Global Directory - Search KPIN</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="PanelSearchKPIN" runat="server" Height="200px" Width="360px" 
    style="left: 104px; position: relative; top: 32px; z-index: 101;">
       <asp:Label ID="LabelSearchKPIN" runat="server" Height="32px" Style="z-index: 100;
            left: 0px; position: absolute; top: 0px; font-weight: bold; font-size: x-large; color: royalblue;" Text="Link to KPIN"
            Width="360px"></asp:Label>
            
        <table border="0" cellpadding="0" cellspacing="0" style="z-index: 104; left: 0px;
            width: 360px; position: absolute; top: 40px; height: 64px; ">
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="LabelName" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Text="Name" Width="176px"></asp:Label>
                </td>
                <td style="width: 98px">
                    <asp:TextBox ID="TextBoxName" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Width="168px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="LabelRelation" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Text="Relation" Width="176px"></asp:Label>
                </td>
                <td style="width: 98px">
                    <asp:Label ID="LabelRelationValue" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Text="Relation" Width="176px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="LabelDOB" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Text="Date of Birth" Width="176px"></asp:Label>
                </td>
                <td style="width: 98px">
                    <uc1:WebUserControl ID="WebUserControlDOB" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="LabelKPIN" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Text="KPIN" Width="176px"></asp:Label>
                </td>
                <td style="width: 98px">
                    <asp:Label ID="LabelKPINValue" runat="server" Style="z-index: 100; left: 0px; position: relative;
                        top: 0px" Text="" Width="176px"></asp:Label>
                </td>
            </tr>
        </table>
        
        <asp:Button ID="ButtonLinkKPIN" runat="server" Style="z-index: 101; left: 152px; position: absolute;
            top: 144px" Text="Link to KPIN" Width="148px" />
            
        <asp:Label ID="LabelError" runat="server" ForeColor="Red" Style="z-index: 102;
            left: 0px; position: absolute; top: 176px" Width="360px" Text="KPIN not found"></asp:Label>
            &nbsp;&nbsp;
            <asp:Button ID="ButtonClose" runat="server" Style="z-index: 105; left: 56px; position: absolute;
                top: 144px" Text="Close" Width="76px" />
    </asp:Panel>
    </div>
    </form>
</body>
</html>
