using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using webstudio_demo.App_Code.DAL;

namespace webstudio_demo.App_Code.BAL
{
    public class recentworks
    {

        public recentworks()
        {

        }

        #region Return DataTable Methods
        public DataTable ReturnDatatable(
            int rec_work_id,
            string title,
            string image,
            string imageurl,
            string mdate,
            string cdate,
            int status,
            int flag)
        {
            DataTable dt = new DataTable();
            DataAccess da = new DataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@rec_work_id", DbType.Int32);
                param[0].Value = rec_work_id;

                param[1] = new SqlParameter("@title", DbType.String);
                param[1].Value = title;

                param[2] = new SqlParameter("@image", DbType.String);
                param[2].Value = image;

                param[3] = new SqlParameter("@imageurl", DbType.String);
                param[3].Value = imageurl;

                if (mdate == "")
                {
                    param[4] = new SqlParameter("@mdate", DbType.DateTime);
                    param[4].Value = mdate;
                }
                else
                {
                    param[4] = new SqlParameter("@mdate", DbType.DateTime);
                    param[4].Value = Convert.ToDateTime(mdate);
                }

                if (cdate == "")
                {
                    param[5] = new SqlParameter("@cdate", DbType.DateTime);
                    param[5].Value = cdate;
                }
                else
                {
                    param[5] = new SqlParameter("@cdate", DbType.DateTime);
                    param[5].Value = Convert.ToDateTime(cdate);
                }


                param[6] = new SqlParameter("@status", DbType.Int32);
                param[6].Value = status;

                param[7] = new SqlParameter("@flag", DbType.Int32);
                param[7].Value = flag;

                dt = da.GetDataTable("Recent_works", param);
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
            int rec_work_id,
            string title,
            string image,
            string imageurl,
            string mdate,
            string cdate,
            int status,
            int flag)
        {
            DataAccess da = new DataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@rec_work_id", DbType.Int32);
                param[0].Value = rec_work_id;

                param[1] = new SqlParameter("@title", DbType.String);
                param[1].Value = title;

                param[2] = new SqlParameter("@image", DbType.String);
                param[2].Value = image;

                param[3] = new SqlParameter("@imageurl", DbType.String);
                param[3].Value = imageurl;

                if (mdate == "")
                {
                    param[4] = new SqlParameter("@mdate", DbType.DateTime);
                    param[4].Value = mdate;
                }
                else
                {
                    param[4] = new SqlParameter("@mdate", DbType.DateTime);
                    param[4].Value = Convert.ToDateTime(mdate);
                }

                if (cdate == "")
                {
                    param[5] = new SqlParameter("@cdate", DbType.DateTime);
                    param[5].Value = cdate;
                }
                else
                {
                    param[5] = new SqlParameter("@cdate", DbType.DateTime);
                    param[5].Value = Convert.ToDateTime(cdate);
                }


                param[6] = new SqlParameter("@status", DbType.Int32);
                param[6].Value = status;

                param[7] = new SqlParameter("@flag", DbType.Int32);
                param[7].Value = flag;


                da.ExeNonQuery("Recent_works", param);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}