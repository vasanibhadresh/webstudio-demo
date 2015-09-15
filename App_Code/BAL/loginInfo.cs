using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using webstudio_demo.App_Code.DAL;

namespace webstudio_demo.App_Code.BAL
{
    public class loginInfo
    {
        
        #region Constructor
        public loginInfo()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }
        #endregion

        #region Return DataTable Methods
        public DataTable ReturnDatatable(
            int id,
            string userName,
            string passWord,
            int status,
            int flag)
        {
            DataTable dt = new DataTable();
            DataAccess da = new DataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@id", DbType.Int32);
                param[0].Value = id;

                param[1] = new SqlParameter("@userName", DbType.String);
                param[1].Value = userName;

                param[2] = new SqlParameter("@passWord", DbType.String);
                param[2].Value = passWord;

                param[3] = new SqlParameter("@status", DbType.Int32);
                param[3].Value = status;

                param[4] = new SqlParameter("@flag", DbType.Int32);
                param[4].Value = flag;

                dt = da.GetDataTable("Login", param);
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
            int id,
            string userName,
            string passWord,
            int status,
            int flag)
        {
            DataAccess da = new DataAccess();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@id", DbType.Int32);
                param[0].Value = id;

                param[1] = new SqlParameter("@userName", DbType.String);
                param[1].Value = userName;

                param[2] = new SqlParameter("@passWord", DbType.String);
                param[2].Value = passWord;

                param[3] = new SqlParameter("@status", DbType.Int32);
                param[3].Value = status;

                param[4] = new SqlParameter("@flag", DbType.Int32);
                param[4].Value = flag;

                da.ExeNonQuery("Login", param);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}