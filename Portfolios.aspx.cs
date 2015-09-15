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
    public partial class Portfolios : System.Web.UI.Page
    {
        
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            portfo();
           
        }


        protected void portfo()
        {
            try
            {
                l_portfolio.Text = "";
                DataTable dt = obj_portfolio.ReturnDatatable(0, "", "","", "", "", "", 1, 1);
                if (dt.Rows.Count > 0)
                {
                    int cnt = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string image = dt.Rows[i]["image"].ToString();
                        string title = dt.Rows[i]["title"].ToString();
                        string description = dt.Rows[i]["description"].ToString();
                        string imageurl = dt.Rows[i]["imageurl"].ToString();
                        if (cnt == 3)
                        {
                            l_portfolio.Text += "<div class=\"clear\"></div>" +
                                                "<div class=\"grid_4\">"+
                                                "<a href=\"uploads/orig_port/"+image+"\" class=\"gal\"><img src=\"uploads/resize_port/"+image+"\" alt=\"\"></a>"+
                                                "<div class=\"text1 col1\">"+title+" </div>"+
                                                ""+description+"<br>"+
                                                "<a href=\""+imageurl+"\">Go to Site</a>"+
                                                "</div>";
                            cnt = 0;
                        }
                        else
                        {
                            l_portfolio.Text += "<div class=\"grid_4\">" +
                                                "<a href=\"uploads/orig_port/" + image + "\" class=\"gal\"><img src=\"uploads/resize_port/" + image + "\" alt=\"\"></a>" +
                                                "<div class=\"text1 col1\">" + title + " </div>" +
                                                "" + description + "<br>" +
                                                "<a href=\"" + imageurl + "\">Go to Site</a>" +
                                                "</div>";
                        }
                        cnt = cnt + 1;
                    }
                }
            }
            catch (Exception ex) { }
        }


    }
}