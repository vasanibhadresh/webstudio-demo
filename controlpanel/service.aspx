<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="service.aspx.cs" Inherits="webstudio_demo.controlpanel.service" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
            <center>
                
        <h2>Add Services</h2>
        <table>
            <tr>
                <td>title</td>
                <td>
                    <asp:TextBox ID="txttitleservices" runat="server"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td>Descrip</td>
                <td><asp:TextBox ID="txtdescriptionservices" runat="server"></asp:TextBox></td>

            </tr>
            <tr>
                <td>
                    image
                </td>
                <td>
                    <asp:FileUpload ID="serviceupload" runat="server"></asp:FileUpload>
                </td>
                </tr>
            <tr>
                <td colspan ="2"><asp:Button ID="btnaddservices" runat="server" Text="Add services" OnClick="btnaddservices_Click"></asp:Button></td>
            </tr>
        </table>
            
                    <asp:GridView ID="gridservices" runat="server" AutoGenerateColumns="false" DataKeyNames="service_id" OnRowCancelingEdit="gridservices_RowCancelingEdit" OnRowDeleting="gridservices_RowDeleting" OnRowEditing="gridservices_RowEditing" OnRowUpdating="gridservices_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="gridlblid" runat="server" Text='<%#Eval("service_id") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="description">
                        <ItemTemplate>
                            <asp:Label ID="gridlbldescription" runat="server" Text='<%#Eval("description") %>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                            <asp:TextBox ID="gridtxtdescription" runat="server" Text='<%#Eval("description") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="image">
                        <ItemTemplate>
                            <asp:Label ID="gridlblimage" runat="server" Text='<%#Eval("image") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                           <asp:FileUpload ID="griduploadservice" runat="server"></asp:FileUpload>
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
            
        </div>
   
    </form>
</body>
</html>
