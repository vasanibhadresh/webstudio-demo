<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="webstudio_demo.controlpanel.Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <script src="../Scripts/jquery.lightbox_me.js"></script>
    <script type ="text/javascript">
        $(document).ready(function () {
            $('#login').click(function (e) {
                $('#login_popup').lightbox_me({
                    centered: true,
                    onLoad: function () {
                        $('#login_popup').find('input:first').focus()
                    }
                });
                e.preventDefault();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h2>Login</h2>
        <input id="login" type="button" value="Login" />
                <table id ="login_popup" style="display:none">
                    <tr>
                        <td>Username:</td>
                        <td>
                            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Password:</td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                       <td colspan ="2">
                           <asp:Button ID="btnLogin" runat="server" Text="Button" OnClick="btnLogin_Click" /></td>
                    </tr>
                </table>
    </div>
    </form>
</body>
</html>
