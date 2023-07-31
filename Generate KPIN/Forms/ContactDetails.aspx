<%@ Page Language="VB"  THEME="LabelSkin"  MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="ContactDetails.aspx.vb" Inherits="Forms_Contact_Details" title="Member - Contact Details" %>

<%@ Register Src="../User Controls/WebUserControlAddress.ascx" TagName="WebUserControlAddress" TagPrefix="uc4" %>
<%@ Register Src="../User Controls/WebUserControlEmail.ascx" TagName="WebUserControlEmail" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">

<asp:Panel ID="PanelWrapper" runat="server" Height="770px" Width="570px" 
style="left: 100px; position: relative; top: 30px; z-index: 101;">

<asp:Panel ID="PanelUpdate" runat="server" Height="80px" Width="570px" 
style="left: 0px; position: absolute; top: 0px; z-index: 101;">
    <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; width: 570px;
        position: relative; top: 0px; height: 25px; z-index: 102;" id="TABLE1">
            <tr>
                <td style="position: absolute; height: 33px; width: 570px;">
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
     
 <asp:Panel ID="PanelContact" runat="server" Height="230px" Width="570px" 
style="left: 0px; position: absolute; top: 100px; z-index: 101;">
       <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; position: absolute; top: 0px; width: 570px; height: 24px; text-align: left;">
            <tr>
                <td style="width: 570px; text-align: left; background-color: mediumpurple; font-weight: bold; height: 20px; color: white;">
                    &nbsp;Contact Details</td>
            </tr>
        </table>
          
     <table border="2" cellpadding="0" cellspacing="0" style="left: 0px; width: 570px;
            position: relative; top: 50px; height: 50px; z-index: 102;">
            <tr>
                <td style="width: 230px; height: 24px; color: red;">
                    Native Address</td>
                <td style="width: 128px; height: 24px;">
                    <uc4:WebUserControlAddress ID="WebUserControlNativeAddress" runat="server" CheckBoxVisble="false" />
                </td>
            </tr>
            <tr>
                <td style="width: 146px; height: 20px;">
                    </td>
                <td style="width: 128px; height: 20px;">
                    </td>
            </tr>
            <tr>
                <td style="width: 230px; height: 24px; color: red;">
                    Permanent Address</td>
                <td style="width: 128px; height: 24px;">
                    <uc4:WebUserControlAddress ID="WebUserControlPermanentAddress" runat="server" CheckBoxVisble="false" />
                </td>
            </tr>
            <tr>
                <td style="width: 146px; height: 20px;">
                    </td>
                <td style="width: 128px; height: 20px;">
                    </td>
            </tr>
            <tr>
                <td style="width: 230px; height: 24px; color: red;">
                    Current Address</td>
                <td style="width: 128px; height: 24px;">
                    <uc4:WebUserControlAddress ID="WebUserControlCurrentAddress" runat="server" CheckBoxVisble="false" />
                </td>
            </tr>
            <tr>
                <td style="width: 146px; height: 20px;">
                    </td>
                <td style="width: 128px; height: 20px;">
                    </td>
            </tr>
            <tr>
                <td style="width: 230px; height: 24px; color: red;">
                    Mobile No</td>
                <td style="height: 24px;">
                      <asp:TextBox ID="TextBoxMobileNo" runat="server" Style="width: 250px;" />
                  </td>
            </tr>
            <tr>
                <td style="width: 230px; height: 24px; color: red;">
                    Landline No</td>
                <td style="height: 24px;">
                      <asp:TextBox ID="TextBoxResidenceNo" runat="server" Style="width: 250px;" />
                  </td>
            </tr>
            <tr>
                <td style="width: 230px; height: 24px; color: red;">
                    Email Id</td>
                <td style="width: 350px; height: 24px;">
                    <uc2:WebUserControlEmail ID="WebUserControlEmail" runat="server" />
                  </td>
            </tr>
         </table>
    </asp:Panel>         
    
    <asp:Panel ID="PanelSave" runat="server" Height="30px" Width="568px" style="left: 0px; position: absolute; top: 700px">
        <asp:Button ID="ButtonSave" runat="server" Style="position: absolute" Text="Save"
            Width="80px" />
     <asp:Label ID="LabelContactDetails" runat="server" Style="left: 88px; position: absolute; top: 0px; color: red; text-align: right;" Width="480px"></asp:Label>
     </asp:Panel>
</asp:Panel>
</asp:Content>

