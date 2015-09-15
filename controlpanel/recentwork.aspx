<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recentwork.aspx.cs" Inherits="webstudio_demo.controlpanel.recentwork" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
     <h2>Add Recent Works</h2>
        <table>
            <tr>
                <td>title</td>
                <td>
                    <asp:TextBox ID="txttitlerecworks" runat="server"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td>Image url</td>
                <td><asp:TextBox ID="txtimageurl" runat="server"></asp:TextBox></td>

            </tr>
            <tr>
                <td>
                    image
                </td>
                <td>
                    <asp:FileUpload ID="recentworkupload" runat="server"></asp:FileUpload>
                </td>
                </tr>
            <tr>
                <td colspan ="2"><asp:Button ID="btnaddrecentwork" runat="server" Text="Add" OnClick="btnaddrecentwork_Click"></asp:Button></td>
            </tr>
        </table>

                 <asp:GridView ID="gridrecentwork" runat="server" AutoGenerateColumns="false" DataKeyNames="rec_work_id" OnRowCancelingEdit="gridrecentwork_RowCancelingEdit" OnRowDeleting="gridrecentwork_RowDeleting" OnRowEditing="gridrecentwork_RowEditing" OnRowUpdating="gridrecentwork_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="gridlblid" runat="server" Text='<%#Eval("rec_work_id") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="ImageUrl">
                        <ItemTemplate>
                            <asp:Label ID="gridlblimageurl" runat="server" Text='<%#Eval("imageurl") %>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                            <asp:TextBox ID="gridtxtimageurl" runat="server" Text='<%#Eval("imageurl") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="image">
                        <ItemTemplate>
                            <asp:Label ID="gridlblimage" runat="server" Text='<%#Eval("image") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                           <asp:FileUpload ID="griduploadwork" runat="server"></asp:FileUpload>
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
