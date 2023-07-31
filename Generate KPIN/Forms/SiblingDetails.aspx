<%@ Page Language="VB"  THEME="LabelSkin"  MasterPageFile="~/Forms/MasterPage.master" AutoEventWireup="false" CodeFile="SiblingDetails.aspx.vb" Inherits="SiblingDetails" title="Member - Sibling Details" %>

<%@ Import Namespace = "System.Data"  %>

<%@ Register Src="../User Controls/WebUserControl.ascx" TagName="WebUserControlDate" TagPrefix="uc1" %>
<%@ Register Src="../User Controls/WebUserControlName.ascx" TagName="WebUserControlName" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" Runat="Server">
             
<asp:Panel ID="PanelWrapper" runat="server" Height="800px" Width="620px" 
style="left: 80px; position: relative; top: 30px; z-index: 101;">

    <asp:Panel ID="PanelUpdate" runat="server" Height="80px" Width="620px" 
style="left: 0px; position: absolute; top: 0px; z-index: 101;">
    <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; width: 620px;
        position: relative; top: 0px; height: 25px; z-index: 102;" id="TABLE1">
            <tr>
                <td style="width: 100px; position: absolute; height: 33px; width: 620px;">
                    <asp:Label ID="LabelInfo" runat="server" Height="12px" Style="z-index: 100; left: 0px;
                        position: absolute; top: 0px; color: red;" Text="Please enter correct and valid information only. We need to consolidate the details of each individual and you can do your part. Select Type of Details from Drop Down List." 
                        Width="570px"></asp:Label></td>
            </tr>
    </table>
           
    <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; width: 620px;
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
     
    <asp:Panel ID="PanelSiblings" runat="server" Height="200px" Width="620px" 
style="left: 0px; position: absolute; top: 100px; z-index: 101;">
        <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; position: absolute; top: 0px; width: 620px; height: 24px; text-align: left; z-index: 101; background-color: mediumpurple; ">
            <tr>
                <td style="width: 620px; text-align: left;  font-weight: bold; height: 20px; color: white;">
                    &nbsp;Sibling Details
                </td>
            </tr>
        </table>
       
     <table border="1" cellpadding="0" cellspacing="2" style="left: 0px; width: 620px;
            position: absolute; top: 30px; height: 50px; z-index: 104; background-color: #f0f8ff;">
            <tr>
                <td style="width: 200px; height: 24px; text-align: center; font-weight: bold; color: Red;">
                    Name</td>
                <td style="width: 60px; height: 24px; text-align: center; font-weight: bold; color: Red;">
                    Sex</td>
                <td style="width: 311px; height: 24px; text-align: center; font-weight: bold; color: Red;">
                    Date of Birth</td>
             </tr>
              <tr>
                <td style="width: 200px; height: 20px;">
                    </td>
                <td style="width: 60px; height: 20px;">
                    </td>
                <td style="width: 311px; height: 20px;">
                    </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 80px; vertical-align: top">
                    <uc3:WebUserControlName ID="WebUserControlName" runat="server" Visible="true" >
                    </uc3:WebUserControlName>
                    </td>
                 <td style="width: 60px; height: 24px;">
                    <asp:DropDownList ID="DropDownListSex" runat="server" AutoPostBack="True" Width="60px">
                        <asp:ListItem Selected="True" Value="0">Male</asp:ListItem>
                        <asp:ListItem Value="1">Female</asp:ListItem>
                    </asp:DropDownList></td>
                 <td style="width: 311px; height: 24px;">
                    <uc1:WebUserControlDate ID="WebUserControlDateofBirth" runat="server" Visible="true" >
                    </uc1:WebUserControlDate>
                </td>
          </tr>
         </table>
         
    </asp:Panel>
    <asp:Panel ID="PanelSave" runat="server" Height="70px" Width="620px" style="left: 0px; position: absolute; top: 320px; z-index: 101;">
        <asp:Button ID="ButtonSave" runat="server" Style="position: absolute; z-index: 100;" Text="Save"
            Width="80px" />
        <asp:Button ID="ButtonDelete" runat="server" Style="position: absolute; top: 44px; z-index: 101; left: 0px;" Text="Delete"
            Width="80px" />
     <asp:Label ID="LabelSiblingDetails" runat="server" Style="left: 88px; position: absolute; top: 0px; color: red; text-align: right; z-index: 102;" Width="528px"></asp:Label>
        <asp:Label ID="LabelSNo" runat="server" Style="z-index: 103; left: 100px; position: absolute;
            top: 48px; text-align: right" Text="Enter Record No. to delete record" Width="228px"></asp:Label>
        <asp:TextBox ID="TextBoxSNo" runat="server" Style="z-index: 105; left: 336px; position: absolute;
            top: 44px" Width="136px"></asp:TextBox>
    </asp:Panel>
        
    <asp:Panel ID="PanelExistingData" runat="server" Height="50px" Width="620px" style="left: 0px; position: absolute; top: 420px; z-index: 102;">
        <%
            Dim Query As String = ""
            Dim CommonObj As New CommonCode
            Dim count As Integer = 1
            Dim KPIN As String 
            Dim PinId As Integer
            Dim DOB As String = ""

            KPIN = Session("KPIN")

            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")

            Query = "Select * from SiblingDetails where PinId = " & PinId.ToString()
            CommonObj.EstablishSQLConnection(Query, "Get")
              
            If CommonObj.returnDataSet.Tables(0).Rows.Count > 0 Then

        %>
        <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; position: relative; top: 0px; width: 620px; height: 24px; text-align: left; z-index: 101; background-color: mediumpurple;">
            <tr>
                <td style="width: 620px; text-align: left; color: white; font-weight: bold; height: 18px;">
                    &nbsp;Existing Sibling Details</td>
            </tr>
        </table>
     
    <table border="1" cellpadding="0" cellspacing="2" style="left: 0px; width: 620px; background-color: #f0f8ff;
            position: relative; top: 5px; height: 50px; z-index: 104;">
             <tr>
                <td style="width: 100px; height: 24px; text-align: center; font-weight: bold; ">
                    Record No.</td>
                <td style="width: 300px; height: 24px; text-align: center; font-weight: bold; ">
                    Name</td>
                <td style="width: 100px; height: 24px; text-align: center; font-weight: bold; ">
                    Sex</td>
                <td style="width: 120px; height: 24px; text-align: center; font-weight: bold; ">
                    Date of Birth</td>
             </tr>
              <tr>
                <td style="width: 100px; height: 5px;">
                    </td>
                <td style="width: 300px; height: 5px;">
                    </td>
                <td style="width: 100px; height: 5px;">
                    </td>
                <td style="width: 120px; height: 5px;">
                    </td>
            </tr>
            <% 
                For Each dr As DataRow In CommonObj.returnDataSet.Tables(0).Rows
                    Dim DateofBirth As Date
                    DateofBirth = CommonObj.GenerateDatefromAge(CType(dr.Item("AgeDiff"), Integer))
                    DOB = DateofBirth.Day.ToString & "-" & DateofBirth.Month.ToString & "-" & DateofBirth.Year.ToString
                %>
           <tr>
                <td style="width: 100px; height: 25px;  text-align: center; ">
                    <%=count%></td>
                <td style="width: 300px; height: 25px; text-align: center; ">
                    <%=dr.Item("Name").Replace("-", " ")%></td>
                <td style="width: 100px; height: 25px; text-align: center; ">
                    <%If dr.Item("Sex") = True Then %>Female 
                    <%Else %>Male
                    <% End If%></td>
                <td style="width: 120px; height: 25px; text-align: center; ">
                    <%=DOB%></td>
           </tr>            
           <tr>
                <td style="width: 100px; height: 5px;">
                    </td>
                <td style="width: 300px; height: 5px;">
                    </td>
                <td style="width: 100px; height: 5px;">
                    </td>
                <td style="width: 120px; height: 5px;">
                    </td>
            </tr>
            
            <%
                Count = Count + 1
            Next
            %>
         
         </table>
         <% End If%>
    </asp:Panel>
</asp:Panel>
</asp:Content>

