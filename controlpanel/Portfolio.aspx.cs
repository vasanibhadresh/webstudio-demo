using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webstudio_demo.App_Code.BAL;
using webstudio_demo.App_Code.PROPERTY;

namespace webstudio_demo.controlpanel
{
    public partial class Portfolio : System.Web.UI.Page
    {
        portfolios obj_portfolios = new portfolios();
        String dir_original = "";
        String dir_resize = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            dir_original = Server.MapPath(GlobalPath.original);
            dir_resize = Server.MapPath(GlobalPath.resize);
            if (!IsPostBack)
            {
                gridview();
            }
        }


        public void gridview()
        {
            try
            {
                DataTable dt = obj_portfolios.ReturnDatatable(0, "", "", "", "", "", "", 0, 1);
                //if (dt.Rows.Count > 0)
                //{
                gridport.DataSource = dt;
                gridport.DataBind();
                //}
            }
            catch (Exception ex) { }
        }




        protected void btnaddport_Click(object sender, EventArgs e)
        {
            try
            {

                String title = txttitle.Text;
                String imageurl = txtimageurl.Text;
                String description = txtdescription.Text;
                String image = "";
                //Bitmap bmpImg = null;
                String ext ="";
                string img = string.Empty;
                
                if (portupload.HasFile)
                {
                    image = Function.addPrefix(portupload.FileName);
                    System.Drawing.Bitmap bmpUploadedImage = new System.Drawing.Bitmap(portupload.PostedFile.InputStream);
                    System.Drawing.Image objFrontCoverImage = FixedSize(bmpUploadedImage, 300, 218, true);
                    ext = Path.GetExtension(image).ToLower();
                    if (ext == ".jpg" || ext == ".png")
                    {
                        portupload.SaveAs(dir_original + image);
                        //portupload.SaveAs(dir_resize + image);
                        img = dir_resize + image;
                        objFrontCoverImage.Save(dir_resize + image);
                    }
                }


                obj_portfolios.ReturnVoid(0, title, image, imageurl, description, "", "", 0, 3);
                gridview();

            }
            catch (Exception ex) { Response.Write(ex.StackTrace); }
        }





        private  Bitmap Resize_Image(Stream streamImage, int maxWidth, int maxHeight)
        {
            Bitmap originalImage = new Bitmap(streamImage);
            int newWidth = originalImage.Width;
            int newHeight = originalImage.Height;
            double aspectRatio = Convert.ToDouble(originalImage.Width) / Convert.ToDouble(originalImage.Height);

            if (aspectRatio <= 1 && originalImage.Width > maxWidth)
            {
                newWidth = maxWidth;
                newHeight = Convert.ToInt32(Math.Round(newWidth / aspectRatio));
            }
            else if (aspectRatio > 1 && originalImage.Height > maxHeight)
            {
                newHeight = maxHeight;
                newWidth = Convert.ToInt32(Math.Round(newHeight * aspectRatio));
            }
            return new Bitmap(originalImage, newWidth, newHeight);
        }






        public static System.Drawing.Image FixedSize(System.Drawing.Image image, int Width, int Height, bool needToFill)
        {
            #region
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int sourceX = 0;
            int sourceY = 0;
            double destX = 0;
            double destY = 0;

            double nScale = 0;
            double nScaleW = 0;
            double nScaleH = 0;

            nScaleW = ((double)Width / (double)sourceWidth);
            nScaleH = ((double)Height / (double)sourceHeight);
            if (!needToFill)
            {
                nScale = Math.Min(nScaleH, nScaleW);
            }
            else
            {
                nScale = Math.Max(nScaleH, nScaleW);
                destY = (Height - sourceHeight * nScale) / 2;
                destX = (Width - sourceWidth * nScale) / 2;
            }

            if (nScale > 1)
                nScale = 1;

            int destWidth = (int)Math.Round(sourceWidth * nScale);
            int destHeight = (int)Math.Round(sourceHeight * nScale);
            #endregion

            System.Drawing.Bitmap bmPhoto = null;
            try
            {
                bmPhoto = new System.Drawing.Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}",
                    destWidth, destX, destHeight, destY, Width, Height), ex);
            }
            using (System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto))
            {
                // grPhoto.InterpolationMode = _interpolationMode;
                // grPhoto.CompositingQuality = _compositingQuality;
                // grPhoto.SmoothingMode = _smoothingMode;

                Rectangle to = new System.Drawing.Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                Rectangle from = new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
                //Console.WriteLine("From: " + from.ToString());
                //Console.WriteLine("To: " + to.ToString());
                grPhoto.DrawImage(image, to, from, System.Drawing.GraphicsUnit.Pixel);

                return bmPhoto;
            }
        }






        protected void gridport_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int port_id =
                  Convert.ToInt32(gridport.DataKeys[e.RowIndex].Value.ToString());

                TextBox title = (TextBox)gridport.Rows[e.RowIndex].FindControl("gridtxttitle");

                FileUpload fupload = (FileUpload)gridport.Rows[e.RowIndex].FindControl("fileupload1");
                String image = "";
                //Bitmap bmpImg = null;
                String ext = "";
                //string img;
                if (fupload.HasFile)
                {
                   
                    image = Function.addPrefix(fupload.FileName);
                    System.Drawing.Bitmap bmpUploadedImage = new System.Drawing.Bitmap(portupload.PostedFile.InputStream);
                    System.Drawing.Image objFrontCoverImage = FixedSize(bmpUploadedImage, 300, 218, true);
                    ext = Path.GetExtension(image).ToLower();
                    if (ext == ".jpg" || ext == ".png")
                    {
                        portupload.SaveAs(dir_original + image);
                        //portupload.SaveAs(dir_resize + image);
                        //img = dir_resize + image;
                        objFrontCoverImage.Save(dir_resize + image);
                    }
                }


                TextBox imageurl = (TextBox)gridport.Rows[e.RowIndex].FindControl("gridtxtimageurl");

                TextBox description = (TextBox)gridport.Rows[e.RowIndex].FindControl("griddescription");

                obj_portfolios.ReturnVoid(port_id, title.Text, image, imageurl.Text, description.ToString(),"", "", 0, 4);


                gridport.EditIndex = -1;
                gridview();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








        protected void gridport_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gridport.EditIndex = e.NewEditIndex;
                gridview();
            }
            catch (Exception ex) { Response.Write(ex.StackTrace); }
        }

        protected void gridport_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int port_id = Convert.ToInt32(gridport.DataKeys[e.RowIndex].Values[0]);
            Label image = (Label)gridport.Rows[e.RowIndex].FindControl("gridlblimage");
            string filepath = Server.MapPath(GlobalPath.original) + image.Text;
            string filepathbit = Server.MapPath(GlobalPath.resize) + image.Text;
            //Response.Write(image);
            FileInfo file = new FileInfo(filepath);
            FileInfo filebit = new FileInfo(filepathbit);
            if (file.Exists)
            {
                file.Delete();
            }
            if (filebit.Exists)
            {
                filebit.Delete();
            }
            obj_portfolios.ReturnVoid(port_id, "", "", "", "", "", "", 0, 5);

            gridview();
        }

        protected void gridport_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridport.EditIndex = -1;
            gridview();
        }




       
    }
}