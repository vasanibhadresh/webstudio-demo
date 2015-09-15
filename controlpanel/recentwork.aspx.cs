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
    public partial class recentwork : System.Web.UI.Page
    {

        recentworks obj_recentwork = new recentworks();
        String dir_recentwork = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            dir_recentwork = Server.MapPath(GlobalPath.recentwork);
            if (!IsPostBack)
            {
                gridview();
            }
        }


        public void gridview()
        {
            try
            {
                DataTable dt = obj_recentwork.ReturnDatatable(0, "", "", "", "", "", 0, 1);
                //if (dt.Rows.Count > 0)
                //{
                gridrecentwork.DataSource = dt;
                gridrecentwork.DataBind();
                //}
            }
            catch (Exception ex) { }
        }

        protected void gridrecentwork_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gridrecentwork.EditIndex = e.NewEditIndex;
                gridview();
            }
            catch (Exception ex) { Response.Write(ex.StackTrace); }
        }

        protected void gridrecentwork_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rec_work_id = Convert.ToInt32(gridrecentwork.DataKeys[e.RowIndex].Values[0]);
            Label image = (Label)gridrecentwork.Rows[e.RowIndex].FindControl("gridlblimage");
            string filepath = Server.MapPath(GlobalPath.recentwork) + image.Text;
            //Response.Write(image);
            FileInfo file = new FileInfo(filepath);
            if (file.Exists)
            {
                file.Delete();
            }
            obj_recentwork.ReturnVoid(rec_work_id, "", "", "", "", "", 0, 5);

            gridview();
        }

        protected void gridrecentwork_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int rec_work_id =
                  Convert.ToInt32(gridrecentwork.DataKeys[e.RowIndex].Value.ToString());

                TextBox title = (TextBox)gridrecentwork.Rows[e.RowIndex].FindControl("gridtxttitle");

                FileUpload fupload = (FileUpload)gridrecentwork.Rows[e.RowIndex].FindControl("griduploadwork");
                String image = "";
                if (fupload.HasFile)
                {
                    image = Function.addPrefix(fupload.FileName);

                    String ext = Path.GetExtension(image).ToLower();
                    if (ext == ".jpg" || ext == ".png")
                    {
                        fupload.SaveAs(dir_recentwork + image);

                    }
                   // Response.Write(image);

                }


                TextBox imageurl = (TextBox)gridrecentwork.Rows[e.RowIndex].FindControl("gridtxtimageurl");

                obj_recentwork.ReturnVoid(rec_work_id, title.Text, image, imageurl.Text, "", "", 0, 4);


                gridrecentwork.EditIndex = -1;
                gridview();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gridrecentwork_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridrecentwork.EditIndex = -1;
            gridview();
        }

        protected void btnaddrecentwork_Click(object sender, EventArgs e)
        {

            try
            {

                String title = txttitlerecworks.Text;
                String imageurl = txtimageurl.Text;

                String image = "";
                if (recentworkupload.HasFile)
                {
                    image = Function.addPrefix(recentworkupload.FileName);

                    String ext = Path.GetExtension(image).ToLower();
                    if (ext == ".jpg" || ext == ".png")
                    {
                        recentworkupload.SaveAs(dir_recentwork + image);
                    }
                }

                obj_recentwork.ReturnVoid(0, title, image, imageurl, "", "", 0, 3);
                gridview();

            }
            catch (Exception ex) { Response.Write(ex.StackTrace); }
        }
    }
}