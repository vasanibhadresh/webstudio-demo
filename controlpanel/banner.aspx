<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="banner.aspx.cs" Inherits="webstudio_demo.controlpanel.banner1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="panneraddbanner" runat="server">
                <center>
        <h2>Add Banner</h2>
        <table>
            <tr>
                <td>title</td>
                <td>
                    <asp:TextBox ID="txttitle" runat="server"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td>url:</td>
                <td><asp:TextBox ID="txturl" runat="server"></asp:TextBox></td>

            </tr>
            <tr>
                <td>
                    image
                </td>
                <td>
                    <asp:FileUpload ID="bannerupload" runat="server"></asp:FileUpload>
                </td>
                </tr>
            <tr>
                <td colspan ="2"><asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /></td>
            </tr>
        </table>
       
            </asp:Panel>
            </center>

            <center>        
                    <asp:GridView ID="gridbanner" runat="server" AutoGenerateColumns="false" DataKeyNames="slider_id" OnRowCancelingEdit="gridbanner_RowCancelingEdit" OnRowDeleting="gridbanner_RowDeleting" OnRowEditing="gridbanner_RowEditing" OnRowUpdating="gridbanner_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="gridlblid" runat="server" Text='<%#Eval("slider_id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title">
                        <ItemTemplate>
                            <asp:Label ID="gridlbltitle" runat="server" Text='<%#Eval("title") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="gridtxttitle" runat="server" Text='<%#Eval("title") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="url">
                        <ItemTemplate>
                            <asp:Label ID="gridlblurl" runat="server" Text='<%#Eval("url") %>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                            <asp:TextBox ID="gridtxturl" runat="server" Text='<%#Eval("url") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="image" Visible ="false">
                        <ItemTemplate>
                            <asp:Label ID="gridlblimage" runat="server" Text='<%#Eval("image") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="gridtxtimage" runat="server" Text='<%#Eval("image") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                         <EditItemTemplate>
                           <asp:Button ID="gridbtnupdate" runat="server" Text="Update" CommandName="Update"></asp:Button>
                             <asp:Button ID="gridbtncancel" runat="server" Text="Cancel" CommandName="Cancel"></asp:Button>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="gridbtnedit" runat="server" Text="Edit" CommandName="Edit" />
                            <asp:Button ID="gridbtndelete" runat="server" Text="Delete" CommandName="Delete"  OnClientClick="return confirm('Are you sure you want to delete this record?')" CausesValidation="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                </center>

            <asp:Panel ID="Panel1" runat="server">


            </asp:Panel>

            
        </div>
    </form>
</body>
</html>
