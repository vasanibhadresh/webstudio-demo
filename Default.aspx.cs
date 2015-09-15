using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webstudio_demo.App_Code.BAL;

namespace webstudio_demo
{
    public partial class Default : System.Web.UI.Page
    {
        banner obj_banner = new banner();
        services obj_services = new services();
        recentworks obj_recentworks = new recentworks();
        testimonials obj_testimonials = new testimonials();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Banner();
                service();
                recentworks();
                testimonial();
                
            }
        }

        protected void Banner()
        {
            try
            {
                l_banner.Text = "";
                DataTable dt = obj_banner.ReturnDatatable(0, "", "", "", "", "", 1, 1);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        String image = dt.Rows[i]["image"].ToString();

                        l_banner.Text += "<div data-src=\"uploads/banner/"+image+"\"></div>";
                    }
                }
            }
            catch (Exception ex) { }
        }

        protected void service()
        {
            try
            {
                l_service.Text = "";
                DataTable dt = obj_services.ReturnDatatable(0, "", "", "", "", "", 1, 1);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        String image = dt.Rows[i]["image"].ToString();
                        String title = dt.Rows[i]["title"].ToString();
                        String description = dt.Rows[i]["description"].ToString();
                        l_service.Text += " <div class=\"grid_4\">"+
                        "<div class=\"icon\">"+
                        "<img src=\"uploads/service/"+image+"\" alt=\"\">"+
                        "<div class=\"title\">"+title+"</div>"+description+""+
                        "</div>"+
                        "</div>";
                    }
                }

            }
            catch(Exception ex)
            {

            }
        }

        protected void recentworks()
        {
            try
            {
                l_recentworks.Text = "";
                DataTable dt = obj_recentworks.ReturnDatatable(0, "", "", "", "", "", 1, 1);
                if (dt.Rows.Count > 0)
                {
                    int cnt = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string image = dt.Rows[i]["image"].ToString();
                        string url = dt.Rows[i]["imageurl"].ToString();
                        string title = dt.Rows[i]["title"].ToString();
                       
                        if (cnt == 3)
                        {
                            l_recentworks.Text += "<div class=\"clear\"></div>" +
                                "<div class=\"grid_4\"><a href=\"" + url + "\"><img src=\"uploads/recentwork/" + image + "\" alt=\"" + title + "\"></a></div>";
                            cnt = 0;
                        }
                        else
                        {
                            l_recentworks.Text += "<div class=\"grid_4\"><a href=\"" + url + "\"><img src=\"uploads/recentwork/" + image + "\" alt=\"" + title + "\"></a></div>";
                        }
                        cnt = cnt + 1;
                    }
                }
            }
            catch(Exception ex)
            {
            }

        }



        protected void testimonial()
        {
            try
            {
                l_testimonial.Text = "";
                DataTable dt = obj_testimonials.ReturnDatatable(0, "", "", "", "", "", 1, 1);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        String image = dt.Rows[i]["image"].ToString();
                        String author = dt.Rows[i]["author"].ToString();
                        String description = dt.Rows[i]["description"].ToString();
                        l_testimonial.Text += " <div class=\"grid_6\">"+
                                           " <blockquote>"+
                                            "<img src=\"uploads/testimonials/"+image+"\" alt=\"\" class=\"img_inner fleft\">"+
                                            "<div class=\"extra_wrapper\">"+
                                            "<p>"+description+"</p>"+
                                            "<span class=\"col2 upp\">"+author+"</span> - client"+
                                            "</div>"+
                                            "</blockquote>"+
                                            "</div>";
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }



    }

}