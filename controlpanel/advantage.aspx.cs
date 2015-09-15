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
    public partial class advantage : System.Web.UI.Page
    {
        Advantages obj_advantages = new Advantages();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridview();
            }
        }


        public void gridview()
        {
            try
            {
                DataTable dt = obj_advantages.ReturnDatatable(0, "", "", "", "", 0, 1);
                //if (dt.Rows.Count > 0)
                //{
                gridadvantage.DataSource = dt;
                gridadvantage.DataBind();
                //}
            }
            catch (Exception ex) { }
        }


        protected void btnaddadvantage_Click(object sender, EventArgs e)
        {
            try
            {

                String title = txttitleadvantage.Text;
                String url = txturl.Text;

                
                

                obj_advantages.ReturnVoid(0, title, url, "", "", 0, 3);
                gridview();

            }
            catch (Exception ex) { Response.Write(ex.StackTrace); }
        }

        protected void gridadvantage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int advantage_id = Convert.ToInt32(gridadvantage.DataKeys[e.RowIndex].Values[0]);


            obj_advantages.ReturnVoid(advantage_id, "", "", "", "", 0, 5);

            gridview();
        }

        protected void gridadvantage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int advantage_id =
                  Convert.ToInt32(gridadvantage.DataKeys[e.RowIndex].Value.ToString());

                TextBox title = (TextBox)gridadvantage.Rows[e.RowIndex].FindControl("gridtxttitle");

                


                TextBox url = (TextBox)gridadvantage.Rows[e.RowIndex].FindControl("gridtxturl");

                obj_advantages.ReturnVoid(advantage_id, title.Text, url.Text, "", "", 0, 4);


                gridadvantage.EditIndex = -1;
                gridview();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void gridadvantage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridadvantage.EditIndex = -1;
            gridview();
        }

        protected void gridadvantage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gridadvantage.EditIndex = e.NewEditIndex;
                gridview();
            }
            catch (Exception ex) { Response.Write(ex.StackTrace); }
        }
    }
}