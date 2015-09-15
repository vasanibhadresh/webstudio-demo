using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using webstudio_demo.App_Code.DAL;

namespace webstudio_demo.App_Code.BAL
{
    public class Advantages
    {
        public Advantages()
        {

        }

        #region Return DataTable Methods
        public DataTable ReturnDatatable(
            int advantage_id,
            string title,
            string url,
            string mdate,
            string cdate,
            int status,
            int flag)
        {
            DataTable dt = new DataTable();
            DataAccess da = new DataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@advantage_id", DbType.Int32);
                param[0].Value = advantage_id;

                param[1] = new SqlParameter("@title", DbType.String);
                param[1].Value = title;

                param[2] = new SqlParameter("@url", DbType.String);
                param[2].Value = url;

               

                if (mdate == "")
                {
                    param[3] = new SqlParameter("@mdate", DbType.DateTime);
                    param[3].Value = mdate;
                }
                else
                {
                    param[3] = new SqlParameter("@mdate", DbType.DateTime);
                    param[3].Value = Convert.ToDateTime(mdate);
                }

                if (cdate == "")
                {
                    param[4] = new SqlParameter("@cdate", DbType.DateTime);
                    param[4].Value = cdate;
                }
                else
                {
                    param[4] = new SqlParameter("@cdate", DbType.DateTime);
                    param[4].Value = Convert.ToDateTime(cdate);
                }


                param[5] = new SqlParameter("@status", DbType.Int32);
                param[5].Value = status;

                param[6] = new SqlParameter("@flag", DbType.Int32);
                param[6].Value = flag;

                dt = da.GetDataTable("Advantages", param);
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
            int advantage_id,
            string title,
            string url,
            string mdate,
            string cdate,
            int status,
            int flag)
        {
            DataAccess da = new DataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@advantage_id", DbType.Int32);
                param[0].Value = advantage_id;

                param[1] = new SqlParameter("@title", DbType.String);
                param[1].Value = title;

                param[2] = new SqlParameter("@url", DbType.String);
                param[2].Value = url;



                if (mdate == "")
                {
                    param[3] = new SqlParameter("@mdate", DbType.DateTime);
                    param[3].Value = mdate;
                }
                else
                {
                    param[3] = new SqlParameter("@mdate", DbType.DateTime);
                    param[3].Value = Convert.ToDateTime(mdate);
                }

                if (cdate == "")
                {
                    param[4] = new SqlParameter("@cdate", DbType.DateTime);
                    param[4].Value = cdate;
                }
                else
                {
                    param[4] = new SqlParameter("@cdate", DbType.DateTime);
                    param[4].Value = Convert.ToDateTime(cdate);
                }


                param[5] = new SqlParameter("@status", DbType.Int32);
                param[5].Value = status;

                param[6] = new SqlParameter("@flag", DbType.Int32);
                param[6].Value = flag;


                da.ExeNonQuery("Advantages", param);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion



    }
}