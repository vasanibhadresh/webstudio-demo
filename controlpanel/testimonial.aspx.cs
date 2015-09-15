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
    public partial class testimonial : System.Web.UI.Page
    {
        testimonials obj_testimonials = new testimonials();
        string dir_testimonial = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            dir_testimonial = Server.MapPath(GlobalPath.testimonial);
            if (!IsPostBack)
            {
                gridview();
            }
        }



        public void gridview()
        {
            try
            {
                DataTable dt = obj_testimonials.ReturnDatatable(0, "", "", "", "", "", 0, 1);
                //if (dt.Rows.Count > 0)
                //{
                gridtestimonial.DataSource = dt;
                gridtestimonial.DataBind();
                //}
            }
            catch (Exception ex) { }
        }


        protected void btnaddtestimonial_Click(object sender, EventArgs e)
        {
            try
            {

                String author = txttitleauthor.Text;
                String description = txtdescription.Text;

                String image = "";
                if (testimonialupload.HasFile)
                {
                    image = Function.addPrefix(testimonialupload.FileName);

                    String ext = Path.GetExtension(image).ToLower();
                    if (ext == ".jpg" || ext == ".png")
                    {
                        testimonialupload.SaveAs(dir_testimonial + image);
                    }
                }

                obj_testimonials.ReturnVoid(0, author, image, description, "", "", 0, 3);
                gridview();

            }
            catch (Exception ex) { Response.Write(ex.StackTrace); }
        }

        protected void gridtestimonial_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridtestimonial.EditIndex = -1;
            gridview();
        }

        protected void gridtestimonial_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int testimonial_id = Convert.ToInt32(gridtestimonial.DataKeys[e.RowIndex].Values[0]);
            Label image = (Label)gridtestimonial.Rows[e.RowIndex].FindControl("gridlblimage");
            string filepath = Server.MapPath(GlobalPath.testimonial) + image.Text;
            //Response.Write(image);
            FileInfo file = new FileInfo(filepath);
            if (file.Exists)
            {
                file.Delete();
            }
            obj_testimonials.ReturnVoid(testimonial_id, "", "", "", "", "", 0, 5);

            gridview();
        }

        protected void gridtestimonial_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridtestimonial.EditIndex = e.NewEditIndex;
            gridview();
        }

        protected void gridtestimonial_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int testimonial_id =
                  Convert.ToInt32(gridtestimonial.DataKeys[e.RowIndex].Value.ToString());

                TextBox author = (TextBox)gridtestimonial.Rows[e.RowIndex].FindControl("gridtxtauthor");

                FileUpload fupload = (FileUpload)gridtestimonial.Rows[e.RowIndex].FindControl("griduploadtestimonial");
                String image = "";
                if (fupload.HasFile)
                {
                    image = Function.addPrefix(fupload.FileName);

                    String ext = Path.GetExtension(image).ToLower();
                    if (ext == ".jpg" || ext == ".png")
                    {
                        fupload.SaveAs(dir_testimonial + image);

                    }
                    // Response.Write(image);

                }


                TextBox description = (TextBox)gridtestimonial.Rows[e.RowIndex].FindControl("gridtxtdescription");

                obj_testimonials.ReturnVoid(testimonial_id, author.Text, image, description.Text, "", "", 0, 4);


                gridtestimonial.EditIndex = -1;
                gridview();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}