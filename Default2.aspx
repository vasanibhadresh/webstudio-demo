<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function checkDate(sender, args) {
            if (sender._selectedDate < new Date()) {
                alert("You cannot select a day earlier than today!");
               
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format));
                
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Timer ID="timer1" runat="server" ontick="timer1_Tick" Interval="1000">
        </asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="timer1"/>
        </Triggers>
        </asp:UpdatePanel>

        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox1"
            MaximumValue="9999/12/28"></asp:RangeValidator>
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox1" Format="dd-MM-yyyy" OnClientDateSelectionChanged="checkDate">
        </asp:CalendarExtender>
        <asp:DropDownList ID="ddl" runat="server">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        
    </div>
    </form>
</body>
</html>
