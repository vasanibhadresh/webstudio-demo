<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="webstudio_demo.controlpanel.principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
     <h2>Add Principal</h2>
        <table>
            <tr>
                <td>title</td>
                <td>
                    <asp:TextBox ID="txttitleprincipal" runat="server"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td>url</td>
                <td><asp:TextBox ID="txturl" runat="server"></asp:TextBox></td>

            </tr>
            <tr>
                <td>
                    description
                </td>
                <td>
                   <asp:TextBox ID="txtdescription" runat="server"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td colspan ="2"><asp:Button ID="btnaddrecentwork" runat="server" Text="Add" OnClick="btnaddrecentwork_Click" ></asp:Button></td>
            </tr>
        </table>

                 <asp:GridView ID="gridprincipal" runat="server" AutoGenerateColumns="false" DataKeyNames="principal_id" OnRowCancelingEdit="gridprincipal_RowCancelingEdit" OnRowDeleting="gridprincipal_RowDeleting" OnRowEditing="gridprincipal_RowEditing" OnRowUpdating="gridprincipal_RowUpdating" >
                <Columns>
                    <asp:TemplateField HeaderText="ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="gridlblid" runat="server" Text='<%#Eval("principal_id") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Url">
                        <ItemTemplate>
                            <asp:Label ID="gridlblurl" runat="server" Text='<%#Eval("url") %>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                            <asp:TextBox ID="gridtxturl" runat="server" Text='<%#Eval("url") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="gridlbldescription" runat="server" Text='<%#Eval("description") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                          <asp:TextBox ID="gridtxtdescription" runat="server" Text='<%#Eval("description") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                         <EditItemTemplate>
                          <asp:Button ID="gridbtnupdate" runat="server" Text="Update" CommandName="Update"></asp:Button>
                             <asp:Button ID="gridbtncancel" runat="server" Text="Cancel" CommandName="Cancel"></asp:Button>
                        </EditItemTemplate>
                        <ItemTemplate>
                           <asp:Button ID="gridbtnedit" runat="server" Text="Edit" CommandName="Edit"/>
                            <asp:Button ID="gridbtndelete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?')" CausesValidation ="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </center>
    </div>
    </form>
</body>
</html>
