<%@ Page Language="VB" Theme="LabelSkin" MasterPageFile="~/Forms/MasterPage.master"
    AutoEventWireup="false" CodeFile="OtherDetails.aspx.vb" Inherits="OtherDetails"
    Title="Member - Other Details" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Src="../User Controls/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderforPages" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; width: 570px;
        position: relative; top: 25px; height: 25px; z-index: 102;">
        <tr>
            <td style="width: 100px; position: relative; height: 33px">
                <asp:Label ID="LabelInfo" runat="server" Height="12px" Style="z-index: 100; left: 0px;
                    position: relative; top: 0px; color: red;" Text="Please enter correct and valid information only. We need to consolidate the details of each individual and you can do your part. Select Type of Details from Drop Down List."
                    Width="568px"></asp:Label></td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; width: 570px;
        position: relative; top: 30px; height: 25px; z-index: 103;">
        <tr>
            <td style="width: 200px; height: 25px; text-align: right;">
                Update your
            </td>
            <td style="width: 350px; height: 25px;">
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
    <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; position: relative;
        top: 40px; width: 570px; height: 24px; text-align: left;">
        <tr>
            <td style="width: 570px; text-align: left; background-color: mediumpurple; font-weight: bold;
                height: 20px; color: white;">
                &nbsp;Migration Details (if applicable)</td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; width: 570px;
        position: relative; top: 50px; height: 50px; z-index: 102;">
        <tr>
            <td style="width: 201px; height: 24px; color: red;">
                Date of Migration</td>
            <td style="width: 128px; height: 24px;">
                <uc1:WebUserControl ID="WebUserControlDateofMigration" runat="server" Visible="true">
                </uc1:WebUserControl>
            </td>
        </tr>
        <tr>
            <td style="width: 201px; height: 2px;">
            </td>
            <td style="width: 128px; height: 2px;">
            </td>
        </tr>
        <tr>
            <td style="width: 201px; height: 24px; color: red;">
                Reason of Migration</td>
            <td style="width: 128px; height: 24px; color: red;">
                <asp:TextBox ID="TextBoxReasonofMigration" runat="server" Style="width: 250px; position: relative;
                    z-index: 103; left: 0px; top: 0px;" Width="216px"></asp:TextBox></td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; position: relative;
        top: 60px; width: 570px; height: 24px; text-align: left;">
        <tr>
            <td style="width: 570px; text-align: left; background-color: mediumpurple; font-weight: bold;
                height: 20px; color: white;">
                &nbsp;Educational Details
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; width: 570px;
        position: relative; top: 70px; height: 60px; z-index: 102;">
        <tr>
            <td style="width: 283px; height: 24px; color: red;">
                Highest Degree</td>
            <td style="width: 128px; height: 24px; color: red;">
                <asp:DropDownList ID="DropDownListDegree" runat="server" Width="256px" AutoPostBack="False">
                </asp:DropDownList>
                Specify: 
                <asp:TextBox ID="TextBoxDegree" runat="server" Style="width: 250px; position: relative;
                    z-index: 103; left: 0px; top: 0px;" Width="216px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 283px; height: 2px;">
            </td>
            <td style="width: 128px; height: 2px;">
            </td>
        </tr>
        <tr>
            <td style="width: 283px; height: 24px; color: red;">
                Passing Board/University</td>
            <td style="width: 128px; height: 24px; color: red;">
                <asp:TextBox ID="TextBoxBoard" runat="server" Style="width: 250px; position: relative;
                    z-index: 103; left: 0px; top: 0px;" Width="216px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 283px; height: 2px;">
            </td>
            <td style="width: 128px; height: 2px;">
            </td>
        </tr>
        <tr>
            <td style="width: 283px; height: 24px; color: red;">
                Year of Passing</td>
            <td style="width: 128px; height: 24px; color: red;">
                <asp:TextBox ID="TextBoxYear" runat="server" Style="width: 250px; position: relative;
                    z-index: 103; left: 0px; top: 0px;" Width="216px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 283px; height: 2px;">
            </td>
            <td style="width: 128px; height: 2px;">
            </td>
        </tr>
        <tr>
            <td style="width: 283px; height: 24px; color: red;">
                Employment Status</td>
            <td style="width: 128px; height: 24px; color: red;">
                <asp:DropDownList ID="DropDownListEmploymentStatus" runat="server" AutoPostBack="True"
                    Width="176px">
                    <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 157px; height: 24px; color: red;">
                            <asp:Panel ID="PanelEmployeed" runat="server" Height="50px" Style="left: 0px; position: relative;
                                top: 16px" Width="570px">
                                <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; position: relative;
                                    top: 0px; width: 570px; height: 24px; text-align: left;">
                                    <tr>
                                        <td style="width: 570px; text-align: left; background-color: mediumpurple; font-weight: bold;
                                            height: 20px; color: white;">
                                            &nbsp;Professional Details
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; width: 570px;
                                    position: relative; top: 20px; height: 50px; z-index: 102;">
                                    <tr>
                                        <td style="width: 157px; height: 24px; color: red;">
                                            Profession</td>
                                        <td style="width: 128px; height: 24px; color: red;">
                                            <asp:DropDownList ID="DropDownListProfession" runat="server" Width="256px" AutoPostBack="False">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>Business</asp:ListItem>
                                                <asp:ListItem>Government Employee</asp:ListItem>
                                                <asp:ListItem>Private Employee</asp:ListItem>
                                                <asp:ListItem>Professional</asp:ListItem>
                                                <asp:ListItem>Self-Employed</asp:ListItem>
                                                <asp:ListItem>Engineer</asp:ListItem>
                                                <asp:ListItem>Doctor</asp:ListItem>
                                                <asp:ListItem>Others</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 157px; height: 2px;">
                                        </td>
                                        <td style="width: 128px; height: 2px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 157px; height: 24px; color: red;">
                                            Current Employer/ Company Name</td>
                                        <td style="width: 128px; height: 24px; color: red;">
                                            <asp:TextBox ID="TextBoxCompany" runat="server" Style="width: 250px; position: relative;
                                                z-index: 103; left: 0px; top: 0px;" Width="216px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 157px; height: 2px;">
                                        </td>
                                        <td style="width: 128px; height: 2px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 157px; height: 24px; color: red;">
                                            Years of Experience</td>
                                        <td style="width: 128px; height: 24px; color: red;">
                                            <asp:TextBox ID="TextBoxExperience" runat="server" Style="width: 250px; position: relative;
                                                z-index: 103; left: 0px; top: 0px;" Width="216px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 157px; height: 2px;">
                                        </td>
                                        <td style="width: 128px; height: 2px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 157px; height: 24px; color: red;">
                                            Annual Income (Rs.)</td>
                                        <td style="width: 128px; height: 24px; color: red;">
                                            <asp:TextBox ID="TextBoxAnnualIncome" runat="server" Style="width: 250px; position: relative;
                                                z-index: 103; left: 0px; top: 0px;" Width="216px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 146px; height: 20px;">
                                        </td>
                                        <td style="width: 128px; height: 20px;">
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Panel ID="PanelOtherDetailsSave" runat="server" Height="50px" Width="568px"
        Style="left: 100px; position: relative; top: 200px">
        <asp:Button ID="ButtonSave" runat="server" Style="position: absolute" Text="Save"
            Width="80px" />
        <asp:Label ID="LabelOtherDetails" runat="server" Style="left: 88px; position: relative;
            top: 0px; color: red; text-align: right;" Width="480px"></asp:Label>
    </asp:Panel>
    <table border="0" cellpadding="0" cellspacing="0" style="left: 100px; position: relative;
        top: 210px; width: 570px; height: 24px; text-align: left; z-index: 101; background-color: mediumpurple;">
        <tr>
            <td style="width: 570px; text-align: left; font-weight: bold; height: 20px; color: white;">
                &nbsp;Property Details
            </td>
        </tr>
    </table>
    <table border="1" cellpadding="0" cellspacing="2" style="left: 100px; width: 570px;
        position: relative; top: 220px; height: 50px; z-index: 104; background-color: #f0f8ff;">
        <tr>
            <td style="width: 100px; height: 24px; text-align: center; font-weight: bold; color: Red;">
                Property Type</td>
            <td style="width: 200px; height: 24px; text-align: center; font-weight: bold; color: Red;">
                Property Specifications</td>
            <td style="width: 140px; height: 24px; text-align: center; font-weight: bold; color: Red;">
                Property Identification</td>
            <td style="width: 80px; height: 24px; text-align: center; font-weight: bold; color: Red;">
                Property Cost (Rs.)</td>
        </tr>
        <tr>
            <td style="width: 100px; height: 20px;">
            </td>
            <td style="width: 200px; height: 20px;">
            </td>
            <td style="width: 140px; height: 20px;">
            </td>
            <td style="width: 80px; height: 20px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 24px;">
                <asp:DropDownList ID="DropDownListType" runat="server" Width="100px" AutoPostBack="False">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Agricultural</asp:ListItem>
                    <asp:ListItem>Residential</asp:ListItem>
                    <asp:ListItem>Commercial</asp:ListItem>
                    <asp:ListItem>Movable</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 200px; height: 24px;">
                <asp:TextBox ID="TextBoxSpecification" runat="server" Style="position: relative;
                    z-index: 103; left: 0px; top: 0px;" Width="200px"></asp:TextBox></td>
            <td style="width: 140px; height: 24px;">
                <asp:TextBox ID="TextBoxIdentification" runat="server" Style="position: relative;
                    z-index: 103; left: 0px; top: 0px;" Width="140px"></asp:TextBox></td>
            <td style="width: 80px; height: 24px;">
                <asp:TextBox ID="TextBoxCost" runat="server" Style="position: relative; z-index: 103;
                    left: 0px; top: 0px;" Width="80px"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Panel ID="PanelSave" runat="server" Height="70px" Width="570px" Style="left: 100px;
        position: relative; top: 240px; z-index: 101;">
        <asp:Button ID="ButtonPropertySave" runat="server" Style="position: absolute; z-index: 100;"
            Text="Save Property Details" Width="152px" />
        <asp:Button ID="ButtonDelete" runat="server" Style="position: absolute; top: 44px;
            z-index: 101; left: 0px;" Text="Delete Property Details" Width="152px" />
        <asp:Label ID="LabelPropertyDetails" runat="server" Style="left: 152px; position: relative;
            top: 0px; color: red; text-align: right; z-index: 102;" Width="416px"></asp:Label>
        <asp:Label ID="LabelSNo" runat="server" Style="z-index: 103; left: 156px; position: absolute;
            top: 48px; text-align: right" Text="Enter Record No. to delete record" Width="256px"></asp:Label>
        <asp:TextBox ID="TextBoxSNo" runat="server" Style="z-index: 105; left: 424px; position: absolute;
            top: 48px" Width="136px"></asp:TextBox>
    </asp:Panel>
    <asp:Panel ID="PanelExistingData" runat="server" Height="50px" Width="570px" Style="left: 100px;
        position: relative; top: 160px; z-index: 102;">
        <%
            Dim Query As String = ""
            Dim CommonObj As New CommonCode
            Dim count As Integer = 1
            'Dim KPIN As String = "3"
            Dim KPIN As String = Session("KPIN")
            Dim PinId As Integer
            Dim PropertyDataTable As DataTable
                        
            Query = "Select * from MemberInfo where KPIN = '" & KPIN & "'"
            CommonObj.EstablishSQLConnection(Query, "Get")

            PinId = CommonObj.returnDataSet.Tables(0).Rows(0).Item("PinId")

            Query = "Select * from PropertyDetails where PinId = " & PinId.ToString()
            CommonObj.EstablishSQLConnection(Query, "Get")
              
            PropertyDataTable = CommonObj.returnDataSet.Tables(0)
            If PropertyDataTable.Rows.Count > 0 Then

        %>
        <table border="0" cellpadding="0" cellspacing="0" style="left: 0px; position: relative;
            top: 100px; width: 570px; height: 24px; text-align: left; z-index: 101; background-color: mediumpurple;">
            <tr>
                <td style="width: 570px; text-align: left; color: white; font-weight: bold; height: 18px;">
                    &nbsp;Existing Records - Property Details</td>
            </tr>
        </table>
        <table border="1" cellpadding="0" cellspacing="2" style="left: 0px; width: 570px;
            background-color: #f0f8ff; position: relative; top: 105px; height: 50px; z-index: 104;">
            <tr>
                <td style="width: 80px; height: 24px; text-align: center; font-weight: bold;">
                    Record No.</td>
                <td style="width: 100px; height: 24px; text-align: center; font-weight: bold;">
                    Property Type</td>
                <td style="width: 170px; height: 24px; text-align: center; font-weight: bold;">
                    Property Specifications</td>
                <td style="width: 120px; height: 24px; text-align: center; font-weight: bold;">
                    Property Identification</td>
                <td style="width: 100px; height: 24px; text-align: center; font-weight: bold;">
                    Property Cost (Rs.)</td>
            </tr>
            <% 
                For Each dr As DataRow In PropertyDataTable.Rows
            %>
            <tr>
                <td style="width: 80px; height: 5px;">
                </td>
                <td style="width: 100px; height: 5px;">
                </td>
                <td style="width: 170px; height: 5px;">
                </td>
                <td style="width: 120px; height: 5px;">
                </td>
                <td style="width: 100px; height: 5px;">
                </td>
            </tr>
            <tr>
                <td style="width: 80px; height: 25px; text-align: center;">
                    <%=count%>
                </td>
                <td style="width: 100px; height: 25px; text-align: center;">
                    <%=dr.Item("Type")%>
                </td>
                <td style="width: 170px; height: 25px; text-align: center;">
                    <%=dr.Item("Specification")%>
                </td>
                <td style="width: 120px; height: 25px; text-align: center;">
                    <%=dr.Item("Identification")%>
                </td>
                <td style="width: 100px; height: 25px; text-align: center;">
                    <%=dr.Item("Cost")%>
                </td>
            </tr>
            <%
                count = count + 1
            Next
            %>
        </table>
        <% End If%>
    </asp:Panel>
</asp:Content>
