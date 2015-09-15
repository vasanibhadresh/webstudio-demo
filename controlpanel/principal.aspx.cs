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
    public partial class principal : System.Web.UI.Page
    {

        principals Obj_principal = new principals();
        String dir_principal = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            dir_principal = Server.MapPath(GlobalPath.principal);
            if (!IsPostBack)
            {
                gridview();
            }
        }


        public void gridview()
        {
            try
            {
                DataTable dt = Obj_principal.ReturnDatatable(0,"","","","","",0,1);
                //if (dt.Rows.Count > 0)
                //{
                gridprincipal.DataSource = dt;
                gridprincipal.DataBind();
                //}
            }
            catch (Exception ex) { }
        }




        protected void gridprincipal_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridprincipal.EditIndex = -1;
            gridview();
        }

        protected void gridprincipal_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int principal_id = Convert.ToInt32(gridprincipal.DataKeys[e.RowIndex].Values[0]);
            Label url = (Label)gridprincipal.Rows[e.RowIndex].FindControl("gridlblimage");
            string filepath = Server.MapPath(GlobalPath.principal) + url.Text;
            //Response.Write(image);
            FileInfo file = new FileInfo(filepath);
            if (file.Exists)
            {
                file.Delete();
            }
            Obj_principal.ReturnVoid(principal_id, "", "", "", "", "", 0, 5);

            gridview();
        }

        protected void gridprincipal_RowEditing(object sender, GridViewEditEventArgs e)
        {

            try
            {
                gridprincipal.EditIndex = e.NewEditIndex;
                gridview();
            }
            catch (Exception ex) { Response.Write(ex.StackTrace); }
        }

        protected void gridprincipal_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int principal_id =
                  Convert.ToInt32(gridprincipal.DataKeys[e.RowIndex].Value.ToString());

                TextBox title = (TextBox)gridprincipal.Rows[e.RowIndex].FindControl("gridtxttitle");

                //FileUpload fupload = (FileUpload)gridrecentwork.Rows[e.RowIndex].FindControl("griduploadwork");
                //String image = "";
                //if (fupload.HasFile)
                //{
                //    image = Function.addPrefix(fupload.FileName);

                //    String ext = Path.GetExtension(image).ToLower();
                //    if (ext == ".jpg" || ext == ".png")
                //    {
                //        fupload.SaveAs(dir_recentwork + image);

                //    }
                //    // Response.Write(image);

                //}


                TextBox url = (TextBox)gridprincipal.Rows[e.RowIndex].FindControl("gridtxturl");
                TextBox description = (TextBox)gridprincipal.Rows[e.RowIndex].FindControl("gridtxtdescription");
                Obj_principal.ReturnVoid(principal_id, title.Text, url.Text, description.Text, "", "", 0, 4);


                gridprincipal.EditIndex = -1;
                gridview();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnaddrecentwork_Click(object sender, EventArgs e)
        {

            try
            {

                String title = txttitleprincipal.Text;
                String url = txturl.Text;
                String description = txtdescription.Text;


                //String image = "";
                //if (recentworkupload.HasFile)
                //{
                //    image = Function.addPrefix(recentworkupload.FileName);

                //    String ext = Path.GetExtension(image).ToLower();
                //    if (ext == ".jpg" || ext == ".png")
                //    {
                //        recentworkupload.SaveAs(dir_recentwork + image);
                //    }
                //}

                Obj_principal.ReturnVoid(0, title, url, description, "", "", 0, 3);
                gridview();

            }
            catch (Exception ex) { Response.Write(ex.StackTrace); }
        }
    }
}