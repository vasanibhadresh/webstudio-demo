﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="workteams.aspx.cs" Inherits="webstudio_demo.controlpanel.workteams" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
         <h2>Add Teamwork</h2>
            <table>
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td>
                        <asp:TextBox ID="txtdescription" runat="server"></asp:TextBox></td>

                </tr>
                <tr>
                    <td>image
                    </td>
                    <td>
                        <asp:FileUpload ID="workupload" runat="server"></asp:FileUpload>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnaddworkteam" runat="server" Text="Add Teamwork" OnClick="btnaddworkteam_Click"></asp:Button></td>
                </tr>
            </table>



            <asp:GridView ID="gridworkteam" runat="server" AutoGenerateColumns="false" DataKeyNames="worker_id" OnRowCancelingEdit="gridtestimonial_RowCancelingEdit" OnRowDeleting="gridtestimonial_RowDeleting" OnRowEditing="gridtestimonial_RowEditing" OnRowUpdating="gridtestimonial_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="gridlblid" runat="server" Text='<%#Eval("worker_id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="gridlblname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="gridtxtname" runat="server" Text='<%#Eval("name") %>'></asp:TextBox>
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
                            <asp:FileUpload ID="griduploadworkteam" runat="server"></asp:FileUpload>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:Button ID="gridbtnupdate" runat="server" Text="Update" CommandName="Update"></asp:Button>
                            <asp:Button ID="gridbtncancel" runat="server" Text="Cancel" CommandName="Cancel"></asp:Button>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="gridbtnedit" runat="server" Text="Edit" CommandName="Edit" />
                            <asp:Button ID="gridbtndelete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?')" CausesValidation="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </center>

    </div>
    </form>
</body>
</html>
