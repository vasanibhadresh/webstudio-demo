using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webstudio_demo.App_Code.BAL;
using webstudio_demo.App_Code.PROPERTY;

namespace webstudio_demo.controlpanel
{
    public partial class banner1 : System.Web.UI.Page
    {
        banner obj_banner = new banner();
        String dir_banner = "";
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            dir_banner = Server.MapPath(GlobalPath.banner);
            if (!IsPostBack)
            {
                panneraddbanner.Visible = true;
               
                grid();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                
                String title = txttitle.Text;
                String url = txturl.Text;

                String image = "";
                if (bannerupload.HasFile)
                {
                    image = Function.addPrefix(bannerupload.FileName);
                    
                    String ext = Path.GetExtension(image).ToLower();
                    if (ext == ".jpg" || ext == ".png")
                    {
                        bannerupload.SaveAs(dir_banner + image);
                    }
                }

                obj_banner.ReturnVoid(0, title, url, image, "","" , 0, 3);
                grid();
                
            }
            catch (Exception ex) { Response.Write(ex.StackTrace);}
        }
        public void grid()
        {
            try
            {
                 dt = obj_banner.ReturnDatatable(0, "","","","","",0,1);
                if (dt.Rows.Count > 0)
                {
                    gridbanner.DataSource = dt;
                    gridbanner.DataBind();
                }
            }
            catch (Exception ex) { }
        }

        protected void gridbanner_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridbanner.EditIndex = e.NewEditIndex;
            grid();

        }

        protected void gridbanner_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            try
            {
                int slider_id =
                  Convert.ToInt32(gridbanner.DataKeys[e.RowIndex].Value.ToString());
                
                 TextBox title =
                 (TextBox)gridbanner.Rows[e.RowIndex].FindControl("gridtxttitle");
                 TextBox url = (TextBox)gridbanner.Rows[e.RowIndex].FindControl("gridtxturl");
                
                obj_banner.ReturnVoid(slider_id, title.Text, url.Text, "", "", "", 0, 4);
                
                
                gridbanner.EditIndex = -1;
                grid();

            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        protected void gridbanner_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int slider_id = Convert.ToInt32(gridbanner.DataKeys[e.RowIndex].Values[0]);
            Label image = (Label)gridbanner.Rows[e.RowIndex].FindControl("gridlblimage");
            string filepath = Server.MapPath(GlobalPath.banner) + image.Text;
            //Response.Write(image);
            FileInfo file = new FileInfo(filepath);
            if (file.Exists)
            {
                file.Delete();
            }
            obj_banner.ReturnVoid(slider_id, "", "","","","", 0, 5);
           
            grid();
        }

        protected void gridbanner_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridbanner.EditIndex = -1;
            grid();
        }

    }
}