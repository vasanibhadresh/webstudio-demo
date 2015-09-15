using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webstudio_demo.App_Code.BAL;

namespace webstudio_demo.controlpanel
{
    public partial class Default1 : System.Web.UI.Page
    {
        loginInfo obj_loginInfo = new loginInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String uname = txtUsername.Text;
            String pwd = txtPassword.Text;
            DataTable dt = obj_loginInfo.ReturnDatatable(0, uname, pwd, 0, 1);
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("main.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}