<%@ Page Title="" Language="C#" MasterPageFile="~/front.Master" AutoEventWireup="true" CodeBehind="Portfolios.aspx.cs" Inherits="webstudio_demo.Portfolios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="App_Themes/css/touchTouch.css">
     <script src="App_Themes/js/touchTouch.jquery.js"></script>
    <script>
        $(function () {
            // Initialize the gallery
           // $('.port a.gal').touchTouch();
        });
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">
        <div class="ic">More Website Templates @ TemplateMonster.com - September 14, 2013!</div>
        <div class="container_12">
            <div class="grid_12">
                <h3><span>Our Portfolio</span></h3>
            </div>
            <div class="clear"></div>
            <div class="port">

                <asp:Literal ID="l_portfolio" runat="server"></asp:Literal>

            </div>
        </div>
    </div>
</asp:Content>
