<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlCalendar.ascx.vb" Inherits="Forms_WebUserControlCalendar" %>
<%--<asp:Panel ID="Panel1" runat="server" Height="200px" Style="position: relative; left: 0px; top: 0px;" Width="216px">
    <asp:TextBox ID="TextBoxDate" runat="server" Style="position: relative" Width="220px"></asp:TextBox>
    <asp:Calendar ID="Calendar" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
        BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
        ForeColor="#663399" Height="200px" ShowGridLines="True" Style="position: relative; left: 0px; top: -22px;"
        Width="220px">
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <SelectorStyle BackColor="#FFCC66" />
        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#CC9966" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
    </asp:Calendar>
    <asp:Button ID="ButtonSelectCal" runat="server" Style="left: 200px; position: relative;
        top: 0px" Text="..." /></asp:Panel>--%>

<asp:TextBox id="TextBox1" runat="server" Width="200px"></asp:TextBox>
  <INPUT type="button" value="..." onclick="OnClick()"/><br>
<div id="divCalendar" style="DISPLAY: none; POSITION: absolute">
  <asp:Calendar id="Calendar1" runat="server" BorderWidth="2px"
                BackColor="White" Width="200px"
    ForeColor="Black" Height="180px" Font-Size="8pt"
                      Font-Names="Verdana" BorderColor="#999999"
    BorderStyle="Outset" DayNameFormat="FirstLetter" CellPadding="4">
    <TodayDayStyle ForeColor="Black" BackColor="#CCCCCC">
      </TodayDayStyle>
    <SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
    <NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
    <DayHeaderStyle Font-Size="7pt" Font-Bold="True"
                    BackColor="#CCCCCC"></DayHeaderStyle>
    <SelectedDayStyle Font-Bold="True" ForeColor="White"
                      BackColor="#666666"></SelectedDayStyle>
    <TitleStyle Font-Bold="True" BorderColor="Black"
                BackColor="#999999"></TitleStyle>
    <WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>
    <OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
  </asp:Calendar>
</div>
<script>
function OnClick()
{
  if( divCalendar.style.display == "none")
    divCalendar.style.display = "";
  else
    divCalendar.style.display = "none";
}
</script>
