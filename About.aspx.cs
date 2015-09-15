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
    public partial class About : System.Web.UI.Page
    {

        principals obj_principal = new principals();
        Advantages obj_advantage = new Advantages();
        workteam obj_workteam = new workteam();
        protected void Page_Load(object sender, EventArgs e)
        {
            principal();
            advantage();
            teamwork();
        }
        protected void principal()
        {
            try
            {
                l_principal.Text = "";
                DataTable dt = obj_principal.ReturnDatatable(0, "", "", "", "", "", 1, 1);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        String title = dt.Rows[i]["title"].ToString();
                        String url = dt.Rows[i]["url"].ToString();
                        String description = dt.Rows[i]["description"].ToString();
                        int m = i + 1;

                        l_principal.Text += "<li>" +
                                            "<div class=\"count\">"+ m +"</div>" +
                                            "<div class=\"extra_wrapper\">" +
                                            "<div class=\"col3\"><a href=\""+url+"\">"+title+" </a></div>"+description+"" +
                                            "</div>" +
                                            "</li>";
                    }
                }
            }
            catch (Exception ex) { }
        }


        protected void advantage()
        {
            try
            {
                l_advantage.Text = "";
                DataTable dt =obj_advantage.ReturnDatatable(0, "", "", "", "", 1, 1);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        String title = dt.Rows[i]["title"].ToString();
                        String url = dt.Rows[i]["url"].ToString();
                        
                        l_advantage.Text += "<li><a href=\""+url+"\">"+title+"</a></li>";
                    }
                }
            }
            catch (Exception ex) { }

        }


        protected void teamwork()
        {
            try
            {
                l_teamwork.Text = "";
                DataTable dt = obj_workteam.ReturnDatatable(0, "", "", "", "", "", 1, 1);
                if (dt.Rows.Count > 0)
                {
                    int cnt = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string image = dt.Rows[i]["image"].ToString();
                        string name = dt.Rows[i]["name"].ToString();
                        string description = dt.Rows[i]["description"].ToString();

                        if (cnt == 3)
                        {
                            l_teamwork.Text += "<div class=\"clear\"></div>" +
                                                "<div class=\"grid_2\">" +
                                                "<img src=\"uploads/workteam/" + image + "\" alt=\"\">" +
                                                "<div class=\"col3\"><a href=\"#\">" + name + "</a></div>" + description + " " +
                                                "</div>";
                            cnt = 0;
                        }
                        else
                        {
                            l_teamwork.Text += "<div class=\"grid_2\">" +
                                                "<img src=\"uploads/workteam/"+image+"\" alt=\"\">" +
                                                "<div class=\"col3\"><a href=\"#\">"+name+"</a></div>"+description+" " +
                                                "</div>";
                        }
                        cnt = cnt + 1;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


    }
}