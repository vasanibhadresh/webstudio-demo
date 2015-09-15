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
    public partial class workteams : System.Web.UI.Page
    {

        workteam obj_workteam = new workteam();
        String dir_workteam ="";
        protected void Page_Load(object sender, EventArgs e)
        {
            dir_workteam = Server.MapPath(GlobalPath.workteam);
            if (!IsPostBack)
            {
                gridview();
            }

        }

        public void gridview()
        {
            try
            {
                DataTable dt = obj_workteam.ReturnDatatable(0, "", "", "", "", "", 0, 1);
                //if (dt.Rows.Count > 0)
                //{
                gridworkteam.DataSource = dt;
                gridworkteam.DataBind();
                //}
            }
            catch (Exception ex) { }
        }   



        protected void btnaddworkteam_Click(object sender, EventArgs e)
        {
            try
            {

                String name = txtname.Text;
                String description = txtdescription.Text;

                String image = "";
                if (workupload.HasFile)
                {
                    image = Function.addPrefix(workupload.FileName);

                    String ext = Path.GetExtension(image).ToLower();
                    if (ext == ".jpg" || ext == ".png")
                    {
                        workupload.SaveAs(dir_workteam + image);
                    }
                }

                obj_workteam.ReturnVoid(0, name, image, description, "", "", 0, 3);
                gridview();

            }
            catch (Exception ex) { Response.Write(ex.StackTrace); }
        }

        protected void gridtestimonial_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int worker_id =
                  Convert.ToInt32(gridworkteam.DataKeys[e.RowIndex].Value.ToString());

                TextBox name = (TextBox)gridworkteam.Rows[e.RowIndex].FindControl("gridtxtname");

                FileUpload fupload = (FileUpload)gridworkteam.Rows[e.RowIndex].FindControl("griduploadworkteam");
                String image = "";
                if (fupload.HasFile)
                {
                    image = Function.addPrefix(fupload.FileName);

                    String ext = Path.GetExtension(image).ToLower();
                    if (ext == ".jpg" || ext == ".png")
                    {
                        fupload.SaveAs(dir_workteam + image);

                    }
                    // Response.Write(image);

                }


                TextBox description = (TextBox)gridworkteam.Rows[e.RowIndex].FindControl("gridtxtdescription");

                obj_workteam.ReturnVoid(worker_id, name.Text, image, description.Text, "", "", 0, 4);


                gridworkteam.EditIndex = -1;
                gridview();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gridtestimonial_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridworkteam.EditIndex = e.NewEditIndex;
            gridview();
        }

        protected void gridtestimonial_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int worker_id = Convert.ToInt32(gridworkteam.DataKeys[e.RowIndex].Values[0]);
            Label image = (Label)gridworkteam.Rows[e.RowIndex].FindControl("gridlblimage");
            string filepath = Server.MapPath(GlobalPath.workteam) + image.Text;
            //Response.Write(image);
            FileInfo file = new FileInfo(filepath);
            if (file.Exists)
            {
                file.Delete();
            }
            obj_workteam.ReturnVoid(worker_id, "", "", "", "", "", 0, 5);

            gridview();
        }

        protected void gridtestimonial_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridworkteam.EditIndex = -1;
            gridview();
        }
    }
}