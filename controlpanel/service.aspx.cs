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
    public partial class service : System.Web.UI.Page
    {
        services obj_services = new services();
        String dir_service = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            dir_service = Server.MapPath(GlobalPath.service);
            if (!IsPostBack)
            {
                gridview();
            }
        }

        public void gridview()
        {
            try
            {
                DataTable dt = obj_services.ReturnDatatable(0, "", "", "", "", "",0, 1);
                //if (dt.Rows.Count > 0)
                //{
                    gridservices .DataSource = dt;
                    gridservices .DataBind();
                //}
            }
            catch (Exception ex) { }
        }

        protected void gridservices_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridservices.EditIndex = -1;
            gridview();
        }

        protected void gridservices_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridservices.EditIndex = e.NewEditIndex;
            gridview();
        }

        protected void gridservices_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int service_id =
                  Convert.ToInt32(gridservices.DataKeys[e.RowIndex].Value.ToString());

                TextBox title = (TextBox)gridservices.Rows[e.RowIndex].FindControl("gridtxttitle");

                FileUpload fupload = (FileUpload)gridservices.Rows[e.RowIndex].FindControl("griduploadservice");
                String image ="";
                if (fupload.HasFile)
                {
                    image = Function.addPrefix(fupload.FileName);

                    String ext = Path.GetExtension(image).ToLower();
                    if (ext == ".jpg" || ext == ".png")
                    {
                        fupload.SaveAs(dir_service + image);
                        
                    }
                   // Response.Write(image);
                    
                }


                TextBox description = (TextBox)gridservices.Rows[e.RowIndex].FindControl("gridtxtdescription");

                obj_services.ReturnVoid(service_id, title.Text,image,description.Text, "", "", 0, 4);


                gridservices.EditIndex = -1;
                gridview();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gridservices_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int service_id = Convert.ToInt32(gridservices.DataKeys[e.RowIndex].Values[0]);
            Label image = (Label)gridservices.Rows[e.RowIndex].FindControl("gridlblimage");
            string filepath = Server.MapPath(GlobalPath.service) + image.Text;
            //Response.Write(image);
            FileInfo file = new FileInfo(filepath);
            if (file.Exists)
            {
                file.Delete();
            }
            obj_services.ReturnVoid(service_id, "", "", "", "", "", 0, 5);
           
            gridview();


        }

        protected void btnaddservices_Click(object sender, EventArgs e)
        {
            try
            {

                String title = txttitleservices.Text;
                String description = txtdescriptionservices.Text;

                String image = "";
                if (serviceupload.HasFile)
                {
                    image = Function.addPrefix(serviceupload.FileName);

                    String ext = Path.GetExtension(image).ToLower();
                    if (ext == ".jpg" || ext == ".png")
                    {
                        serviceupload.SaveAs(dir_service + image);
                    }
                }

                obj_services.ReturnVoid(0, title, image, description, "", "", 0, 3);
                gridview();

            }
            catch (Exception ex) { Response.Write(ex.StackTrace); }
        }
    }
}