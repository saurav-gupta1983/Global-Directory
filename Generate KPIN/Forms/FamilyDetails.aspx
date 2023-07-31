<%@ Page Language="VB"  THEME="LabelSkin"  MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="FamilyDetails.aspx.vb" Inherits="Forms_Family_Details" title="Member - Family Details" %>

<%@ Register Src="../User Controls/WebUserControlName.ascx" TagName="WebUserControlName" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">

<asp:Panel ID="PanelWrapper" runat="server" Height="700px" Width="570px" 
style="left: 100px; position: relative; top: 30px; z-index: 101;">

    <asp:Panel ID="PanelUpdate" runat="server" Height="80px" Width="570px" 
style="left: 0px; position: absolute; top: 0px; z-index: 101;">
    <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; width: 570px;
        position: relative; top: 0px; height: 25px; z-index: 102;" id="TABLE1">
            <tr>
                <td style="width: 100px; position: absolute; height: 33px; width: 570px;">
                    <asp:Label ID="LabelInfo" runat="server" Height="12px" Style="z-index: 100; left: 0px;
                        position: absolute; top: 0px; color: red;" Text="Please enter correct and valid information only. We need to consolidate the details of each individual and you can do your part. Select Type of Details from Drop Down List." 
                        Width="570px"></asp:Label></td>
            </tr>
    </table>
           
    <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; width: 570px;
        position: relative; top: 50px; height: 25px; z-index: 103;">
        <tr>
            <td style="width: 200px; height: 25px; text-align: right;">
                    Update your     </td>
            <td style="width: 350px; height: 25px; ">
                    <asp:DropDownList ID="DropDownListDetails" runat="server" Width="240px" AutoPostBack="True">
                        <asp:ListItem>Family Details</asp:ListItem>
                        <asp:ListItem>Contact Details</asp:ListItem>
                        <asp:ListItem>Sibling Details</asp:ListItem>
                        <asp:ListItem>Offspring Details</asp:ListItem>
                        <asp:ListItem>Deaths in family after 1989</asp:ListItem>
                        <asp:ListItem>Births in family after 1989</asp:ListItem>
                        <asp:ListItem>Other Details</asp:ListItem>
           </asp:DropDownList></td>
        </tr>
     </table>
</asp:Panel>    
     
    <asp:Panel ID="PanelFamily" runat="server" Height="200px" Width="570px" 
style="left: 0px; position: absolute; top: 100px; z-index: 101;">
        <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; position: relative; top: 0px; width: 570px; height: 24px; text-align: left;">
            <tr>
                <td style="width: 570px; text-align: left; background-color: mediumpurple; font-weight: bold; height: 20px; color: white;">
                    &nbsp;Family Details</td>
            </tr>
        </table>
     <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; width: 570px;
            position: relative; top: 10px; height: 50px; z-index: 102;">
            <tr>
                <td style="width: 146px; height: 24px; color: red;">
                    Sex</td>
                <td style="width: 128px; height: 24px; color: red;">
                    <asp:DropDownList ID="DropDownListSex" runat="server" AutoPostBack="True" Width="176px">
                        <asp:ListItem Selected="True" Value="0">Male</asp:ListItem>
                        <asp:ListItem Value="1">Female</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 146px; height: 2px;">
                    </td>
                <td style="width: 128px; height: 2px;">
                    </td>
            </tr>
            <tr>
                <td style="width: 146px; height: 24px; color: red;">
                    Marital Status</td>
                <td style="width: 128px; height: 24px; color: red;">
                    <asp:DropDownList ID="DropDownListMaritalStatus" runat="server" AutoPostBack="True" Width="176px">
                        <asp:ListItem Selected="True" Value="0">Single</asp:ListItem>
                        <asp:ListItem Value="1">Married</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 146px; height: 2px;">
                    </td>
                <td style="width: 128px; height: 2px;">
                    </td>
            </tr>

            <tr>
                <td style="width: 146px; height: 24px; color: red;">
                    Nationality</td>
                <td style="width: 128px; height: 24px; color: red;">
                    <asp:TextBox ID="TextBoxNationality" runat="server" Style="width: 250px; position: relative; z-index: 103; left: 0px; top: 0px;"
                        Width="108px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 146px; height: 20px;">
                    </td>
                <td style="width: 128px; height: 20px;">
                    </td>
            </tr>
            <tr>
                <td style="width: 146px; height: 24px;">
                    Father's Name</td>
                <td style="width: 210px; height: 80px; vertical-align: top">
                  <uc3:WebUserControlName ID="WebUserControlFathersName" runat="server" Enabled="false" />
                </td>
            </tr>
            <tr>
                <td style="width: 146px; height: 20px;">
                    </td>
                <td style="width: 128px; height: 20px;">
                    </td>
            </tr>
            <tr>
                <td style="width: 146px; height: 24px;">
                    Mother's Name</td>
                <td style="width: 210px; height: 80px; vertical-align: top">
                    <uc3:WebUserControlName ID="WebUserControlMothersName" runat="server" Enabled="false" />
                </td>
            </tr>            
         </table>
    </asp:Panel>
         
    <asp:Panel ID="PanelSpouse" runat="server" Height="16px" Style="left: 0px; position: relative;
        top: 430px" Width="570px">
        <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; width: 570px;
            position: relative; top: 0px; height: 50px; z-index: 102;">
            <tr>
                <td style="width: 119px; height: 24px; color: red;">
                    Spouse Name</td>
                <td style="width: 210px; height: 24px; vertical-align: top">
                    <uc3:WebUserControlName ID="WebUserControlSpouseName" runat="server" />
                </td>
            </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="PanelSave" runat="server" Height="50px" Width="570px" style="left: 0px; position: relative; top: 510px">
        <asp:Button ID="ButtonSave" runat="server" Style="position: absolute" Text="Save"
            Width="80px" />
     <asp:Label ID="LabelFamilyDetails" runat="server" Style="left: 88px; position: relative; top: 0px; color: red; text-align: right;" Width="480px"></asp:Label>
     </asp:Panel>
</asp:Panel>
</asp:Content>

