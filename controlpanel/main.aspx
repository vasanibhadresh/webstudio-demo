<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="webstudio_demo.controlpanel.main1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnaddbanner" runat="server" Text="Manage Banner" OnClick="btnaddbanner_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnaddservice" runat="server" Text="Manage Services" OnClick="btnaddservice_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnaddrecentworks" runat="server" Text="Manage Recent Works" OnClick="btnaddrecentworks_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnaddtestimonials" runat="server" Text="Manage Testimonials" OnClick="btnaddtestimonials_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnaddprincipal" runat="server" Text="Manage Principals" OnClick="btnaddprincipal_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnaddadvantage" runat="server" Text="Manage Advantages" OnClick="btnaddadvantage_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnaddmission" runat="server" Text="Manage Mission" OnClick="btnaddmission_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnaddteamwork" runat="server" Text="Manage Teamwork" OnClick="btnaddteamwork_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnaddportfolio" runat="server" Text="Manage Portfolio" OnClick="btnaddportfolio_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
