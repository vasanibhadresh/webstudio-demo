using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webstudio_demo.controlpanel
{
    public partial class main1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnaddbanner_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/controlpanel/banner.aspx");
        }

        protected void btnaddservice_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/controlpanel/service.aspx");
        }

        protected void btnaddrecentworks_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/controlpanel/recentwork.aspx");
        }

        protected void btnaddtestimonials_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/controlpanel/testimonial.aspx");
        }

        protected void btnaddprincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/controlpanel/principal.aspx");
        }

        protected void btnaddadvantage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/controlpanel/advantage.aspx");
        }

        protected void btnaddmission_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/controlpanel/mission.aspx");
        }

        protected void btnaddteamwork_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/controlpanel/workteams.aspx");
        }

        protected void btnaddportfolio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/controlpanel/Portfolio.aspx");
        }
    }
}