using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FileManager.DBUtility
{
    public abstract class DbHelperSQLEx
    {
        public DbHelperSQLEx() { }

        /// <summary>
        /// 传入连接字符串
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cmd"></param>
        /// <param name="SQLString"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static object GetSingle(SqlConnection connection, SqlCommand cmd, string SQLString, params SqlParameter[] cmdParms)
        {
            try
            {
                cmd.CommandTimeout = 20;
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                object obj = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 传入连接字符串
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="SQLString"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static object GetSingle(SqlConnection connection, string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.CommandTimeout = 20;
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// 2012-2-21新增重载，执行查询语句，返回DataSet
        /// </summary>
        /// <param name="connection">SqlConnection对象</param>
        /// <param name="trans">SqlTransaction事务</param>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(SqlConnection connection, SqlTransaction trans, string SQLString, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, trans, SQLString, cmdParms);
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    trans.Rollback();
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}
