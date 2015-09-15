using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using webstudio_demo.App_Code.DAL;

namespace webstudio_demo.App_Code.BAL
{
    public class portfolios
    {



        public portfolios()
        {

        }


        #region Return DataTable Methods
        public DataTable ReturnDatatable(
            int port_id,
            string title,
            string image,
            string imageurl,
            string description,
            string mdate,
            string cdate,
            int status,
            int flag)
        {
            DataTable dt = new DataTable();
            DataAccess da = new DataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@port_id", DbType.Int32);
                param[0].Value = port_id;

                param[1] = new SqlParameter("@title", DbType.String);
                param[1].Value = title;

                param[2] = new SqlParameter("@image", DbType.String);
                param[2].Value = image;

                param[3] = new SqlParameter("@imageurl", DbType.String);
                param[3].Value = imageurl;

                param[4] = new SqlParameter("@description", DbType.String);
                param[4].Value = description;

                if (mdate == "")
                {
                    param[5] = new SqlParameter("@mdate", DbType.DateTime);
                    param[5].Value = mdate;
                }
                else
                {
                    param[5] = new SqlParameter("@mdate", DbType.DateTime);
                    param[5].Value = Convert.ToDateTime(mdate);
                }

                if (cdate == "")
                {
                    param[6] = new SqlParameter("@cdate", DbType.DateTime);
                    param[6].Value = cdate;
                }
                else
                {
                    param[6] = new SqlParameter("@cdate", DbType.DateTime);
                    param[6].Value = Convert.ToDateTime(cdate);
                }


                param[7] = new SqlParameter("@status", DbType.Int32);
                param[7].Value = status;

                param[8] = new SqlParameter("@flag", DbType.Int32);
                param[8].Value = flag;

                dt = da.GetDataTable("Ports", param);
                return dt;
            }
            catch (Exception)
            {
                return dt;
                throw;
            }
        }
        #endregion



        #region Return Void Methods
        public void ReturnVoid(
            int port_id,
            string title,
            string image,
            string imageurl,
            string description,
            string mdate,
            string cdate,
            int status,
            int flag)
        {
            DataAccess da = new DataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@port_id", DbType.Int32);
                param[0].Value = port_id;

                param[1] = new SqlParameter("@title", DbType.String);
                param[1].Value = title;

                param[2] = new SqlParameter("@image", DbType.String);
                param[2].Value = image;

                param[3] = new SqlParameter("@imageurl", DbType.String);
                param[3].Value = imageurl;

                param[4] = new SqlParameter("@description", DbType.String);
                param[4].Value = description;

                if (mdate == "")
                {
                    param[5] = new SqlParameter("@mdate", DbType.DateTime);
                    param[5].Value = mdate;
                }
                else
                {
                    param[5] = new SqlParameter("@mdate", DbType.DateTime);
                    param[5].Value = Convert.ToDateTime(mdate);
                }

                if (cdate == "")
                {
                    param[6] = new SqlParameter("@cdate", DbType.DateTime);
                    param[6].Value = cdate;
                }
                else
                {
                    param[6] = new SqlParameter("@cdate", DbType.DateTime);
                    param[6].Value = Convert.ToDateTime(cdate);
                }


                param[7] = new SqlParameter("@status", DbType.Int32);
                param[7].Value = status;

                param[8] = new SqlParameter("@flag", DbType.Int32);
                param[8].Value = flag;


                da.ExeNonQuery("Ports", param);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion





    }
}