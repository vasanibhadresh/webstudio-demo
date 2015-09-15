using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace webstudio_demo.App_Code.DAL
{
    public class DataAccess
    {
        public DataAccess()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Variables.
        public string connString = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        #endregion

        #region OpenConnection.
        // Open SQL Connection...
        public SqlConnection OpenConnection()
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            try
            {
                Conn.Open();
                return Conn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region CloseConnection
        // Close SQL Connection...
        public void CloseConnection()
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            try
            {
                Conn.Close();
                Conn.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region GetDataTable
        public DataTable GetDataTable(string procName, params SqlParameter[] procParams)
        {
            DataTable dt = new DataTable();
            try
            {
                //Create a connection string.
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    //Write path of stored procedure you created in SQL Server           
                    SqlCommand cmd = new SqlCommand(procName, conn);

                    //Write Command Type as here it is in form of stored procedure 
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Add parameters
                    if (procParams != null)
                    {
                        foreach (SqlParameter p in procParams)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    /*sqlComm.Parameters.AddWithValue("@Start", StartTime);
                    sqlComm.Parameters.AddWithValue("@Finish", StartTime);
                    sqlComm.Parameters.AddWithValue("@TimeRange", TimeRange);*/

                    //Create SQL data adapter
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    //Fill dataset

                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region GetScalarData
        public string GetScalarData(string procName, SqlParameter[] procParams)
        {
            string retValue = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Add parameters
                        if (procParams != null)
                        {
                            foreach (SqlParameter p in procParams)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        //sqlCommand.Parameters.Add(new SqlParameter("@Id", this.ID));
                        //sqlCommand.Parameters.Add(new SqlParameter("@State", 1 /* active */));

                        retValue = (string)Convert.ToString(cmd.ExecuteScalar());
                        return retValue;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region ExeNonQuery
        public void ExeNonQuery(string procName, SqlParameter[] procParams)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Add parameters
                        if (procParams != null)
                        {
                            foreach (SqlParameter p in procParams)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        //sqlCommand.Parameters.Add(new SqlParameter("@Id", this.ID));
                        //sqlCommand.Parameters.Add(new SqlParameter("@State", 1 /* active */));
                        cmd.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {


            }
        }
        #endregion
    }
}