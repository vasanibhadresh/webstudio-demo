<%@ Page Title="" Language="C#" MasterPageFile="~/front.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="webstudio_demo.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="slider_wrapper">
      <div id="camera_wrap" class="">
          <asp:Literal ID="l_banner" runat="server"></asp:Literal>
        
      </div>
</div>


    <div class="content"><div class="ic">More Website Templates @ TemplateMonster.com - September 14, 2013!</div>
  <div class="container_12">
    <div class="grid_12">
      <h2>WELCOME TO MY SITE WHERE YOU CAN FIND<span>A RANGE OF CREATIVE HIGH-QUALITY <span class="col1">DESIGNS</span> THAT CAN HELP YOUR BUSINESS 
FLOURISH.</span></h2>
<h3><span>SERVICES</span></h3>
    </div>
      <asp:Literal ID="l_service" runat="server"></asp:Literal>
    <%--<div class="grid_4">
      <div class="icon">
        <img src="App_Themes/images/icon1.png" alt="">
        <div class="title">PLANNING</div>Fusce quis fermentum nisl. Ut tempus cometum urna is sed feugiat. Cras pulvinar lorem sagi isallvestibulumnisi nec gravida maecenas sit amet eros conr, convallis.
      </div>
    </div>--%>
   <%-- <div class="grid_4">
      <div class="icon">
        <img src="App_Themes/images/icon2.png" alt="">
        <div class="title">DESIGN</div><span class="col1"><a href="http://blog.templatemonster.com/free-website-templates/" rel="dofollow"> Find here</a></span> more information about this free template designed by TemplateMonster.com.
Visit the category of premium <span class="col1"><a href="http://www.templatemonster.com/category/design-website-templates/" rel="nofollow">Design Website Templates</a></span> to get more themes of this kind. 
      </div>
    </div>
    <div class="grid_4">
      <div class="icon">
        <img src="App_Themes/images/icon3.png" alt="">
        <div class="title">DEVELOPMENT</div>Fusce quis fermentum nisl. Ut tempus cometum urna is sed feugiat. Cras pulvinar lorem sagi isallvestibulumnisi nec gravida maecenas sit amet eros conr, convallis.
      </div>
    </div>--%>
    <div class="grid_12">
      <h3><span>Recent Works</span></h3>
    </div>
    <div class="clear"></div>
    <div class="works">
        <asp:Literal ID="l_recentworks" runat="server"></asp:Literal>
      <%--<div class="grid_4"><a href="#"><img src="App_Themes/images/page1_img1.jpg" alt=""></a></div>
      <div class="grid_4"><a href="#"><img src="App_Themes/images/page1_img2.jpg" alt=""></a></div>
      <div class="grid_4"><a href="#"><img src="App_Themes/images/page1_img3.jpg" alt=""></a></div>
      <div class="clear"></div>
      <div class="grid_4"><a href="#"><img src="App_Themes/images/page1_img4.jpg" alt=""></a></div>
      <div class="grid_4"><a href="#"><img src="App_Themes/images/page1_img5.jpg" alt=""></a></div>
      <div class="grid_4"><a href="#"><img src="App_Themes/images/page1_img6.jpg" alt=""></a></div>--%>
    </div>
    <div class="clear"></div>
    <div class="grid_12">
      <h3><span>Testimonials</span></h3></div>

      <asp:Literal ID="l_testimonial" runat="server"></asp:Literal>

     <%-- <div class="grid_6">
        <blockquote>
          <img src="App_Themes/images/page1_img7.jpg" alt="" class="img_inner fleft">
          <div class="extra_wrapper">
            <p>“Lorem ipsum dolor sit amet, consecteturdiing elit. Ut sit amet lorem sit amet nunc mattisrt imperdiet ac sit amet dui.”</p>
            <span class="col2 upp">Lisa Smith  </span> - client
          </div>
        </blockquote>
      </div>
      <div class="grid_6">
        <blockquote>
          <img src="App_Themes/images/page1_img8.jpg" alt="" class="img_inner fleft">
          <div class="extra_wrapper">
            <p>“Lorem ipsum dolor sit amet, consecteturdiing elit. Ut sit amet lorem sit amet nunc mattisrt imperdiet ac sit amet dui.”</p>
            <span class="col2 upp">James Bond  </span> - client
          </div>
        </blockquote>
      </div>--%>

    
  </div>
</div>

</asp:Content>
