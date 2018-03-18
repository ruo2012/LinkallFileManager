using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace FileManager.ServerSetup
{
    public partial class InstallDB
    {
        public InstallDB()
        {
        }

        /// <summary>
        /// 附加数据库方法
        /// </summary>
        /// <param name="strSql">连接数据库字符串，连接master系统数据库</param>
        /// <param name="dataName">数据库名字</param>
        /// <param name="strMdf">数据库文件MDF的路径</param>
        /// <param name="strLdf">数据库文件LDF的路径</param>
        /// <param name="path">安装目录</param>
        private void CreateDataBase(string strSql, string dataName, string strMdf, string strLdf, string path)
        {
            SqlConnection myConn = new SqlConnection(strSql);
            String str = null;
            try
            {
                str = " EXEC sp_attach_db @dbname='" + dataName + "',@filename1='" + strMdf + "',@filename2='" + strLdf + "'";
                SqlCommand myCommand = new SqlCommand(str, myConn);
                myConn.Open();
                myCommand.ExecuteNonQuery();
                //MessageBox.Show("数据库安装成功！点击确定继续");//需Using System.Windows.Forms
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库安装失败！" + e.Message + "\n\n" + "您可以手动附加数据");
                System.Diagnostics.Process.Start(path);//打开安装目录
            }
            finally
            {
                myConn.Close();
            }
        }

        /// <summary>
        /// 数据库检查
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dataName"></param>
        /// <param name="strMdf"></param>
        /// <param name="strLdf"></param>
        /// <param name="path"></param>
        public int CheckDataBase(string strSql, string dataName, string path)
        {
            SqlConnection myConn = new SqlConnection(strSql);
            String str = null;
            try
            {
                str = string.Format(" select count(*) from sysdatabases where name='{0}'", dataName);
                SqlCommand myCommand = new SqlCommand(str, myConn);
                myConn.Open();
                bool existed = Exists(myCommand.ExecuteScalar());
                // 需Using System.Windows.Forms
                //MessageBox.Show(!existed ? "数据库不存在，请点击安装继续！" : "数据库已经存在，请点击取消！");
                return existed ? 1 : 2;
            }
            catch (Exception e)
            {
                //MessageBox.Show("数据库测试失败！" + e.Message + "\n\n" + "您可以手动附加数据");
                //System.Diagnostics.Process.Start(path);//打开安装目录
                return -1;
            }
            finally
            {
                myConn.Close();
            }
        }

        public static bool Exists(object obj)
        {
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 数据库安装
        /// </summary>
        /// <param name="dbname"></param>
        /// <param name="server"></param>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        public bool Install(string dbname, int type, string server, string uid, string pwd)
        {
            try
            {
                //string dbname = this.Context.Parameters["dbname"];//数据库名称
                //string server = this.Context.Parameters["server"];//服务器名称
                //string uid = this.Context.Parameters["user"];//SQlServer用户名
                //string pwd = this.Context.Parameters["pwd"];//密码
                //string path = this.Context.Parameters["targetdir"];//安装目录
                string path = Path.GetFullPath("DataBase") + "/";
                string strSql = "Server=" + server + ";User Id=" + uid + ";Password=" + pwd + ";Database=master;";//连接数据库字符串
                if (uid.Length == 0 && pwd.Length == 0)
                {
                    strSql = "Server=" + server + ";Database=master;Trusted_Connection=True;";//Windows身份验证
                }
                string _dbName = type > 0 ? "FileContent" : "FileManager";//数据库名
                string strMdf = path + _dbName + ".mdf";//MDF文件路径，这里需注意文件名要与刚添加的数据库文件名一样！
                string strLdf = path + _dbName + "_log.ldf";//LDF文件路径
                //MessageBox.Show("数据库文件授权");
                
                //MessageBox.Show("数据库文件授权成功");
                //MessageBox.Show("数据库文件安装开始");
                //base.Install(stateSaver);
                //MessageBox.Show("数据库文件安装成功");
                //MessageBox.Show("数据库文件创建数据库");

                string guid = Guid.NewGuid().ToString();
                string aimPath = @"C:\telinga\Linkall\Linkall实验数据备份系统数据库\" + guid + "\\";
                if (!Directory.Exists(aimPath))
                {
                    Directory.CreateDirectory(aimPath);
                }

                string aimManagerPath = string.Format("{0}{1}.mdf", aimPath, _dbName);
                string aimContentPath = string.Format("{0}{1}_log.ldf", aimPath, _dbName);

                if (File.Exists(strMdf))
                {
                    File.Copy(strMdf, aimManagerPath);
                }

                if (File.Exists(strLdf))
                {
                    File.Copy(strLdf, aimContentPath);
                }

                SetFullControl(aimManagerPath);
                SetFullControl(aimContentPath);

                this.CreateDataBase(strSql, dbname, aimManagerPath, aimContentPath, path);//开始创建数据库
                //MessageBox.Show("数据库文件安装成功");
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("数据库安装失败！" + ex.Message + "|" + ex.StackTrace + "\n\n" + "您可以手动附加数据");
                return false;
            }
        }

        public bool InstallBySql(string dbname, int type, string server, string uid, string pwd)
        {
            try
            {
                string path = Path.GetFullPath("DataBaseSql") + "/";
                string strSql = "Server=" + server + ";User Id=" + uid + ";Password=" + pwd + ";Database=master;";//连接数据库字符串
                if (uid.Length == 0 && pwd.Length == 0)
                {
                    strSql = "Server=" + server + ";Database=master;Trusted_Connection=True;";//Windows身份验证
                }

                string _dbName = type > 0 ? "FileContent" : "FileManager";//数据库名
                string baseSqlPath = string.Format("{0}{1}.sql", path, _dbName);
                if (!File.Exists(baseSqlPath)) return false;

                string baseSqlContent = Common.Utils.ReadFile(baseSqlPath);
                string excuteSql = string.Empty;
                if (type > 0)
                {
                    excuteSql = baseSqlContent.Replace("FileContent", string.Format("{0}", dbname));
                }
                else
                {
                    excuteSql = baseSqlContent.Replace("FileManager", string.Format("{0}", dbname));
                }

                string createSql =
                    string.Format(@"
                USE [master]
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{0}')
                BEGIN
                CREATE DATABASE [{0}]
                END", dbname);

                this.CreateDataBaseBySql(strSql, createSql, dbname, path);//开始创建数据库
                //this.CreateDataBaseBySql(strSql, excuteSql, dbname, path);//开始创建数据库
                this.ExecuteNonQueryWithGo(strSql, excuteSql, dbname, path);//开始创建数据库
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void CreateDataBaseBySql(string strSql,string sqlContent, string dataName, string path)
        {
            SqlConnection myConn = new SqlConnection(strSql);
            String str = sqlContent;
            try
            {
                SqlCommand myCommand = new SqlCommand(str, myConn);
                myConn.Open();
                myCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库安装失败！" + e.Message + "\n\n" + "您可以手动附加数据");
                System.Diagnostics.Process.Start(path);//打开安装目录
            }
            finally
            {
                myConn.Close();
            }
        }

        //private static void ExecuteSQLFile(string strSql, string sqlContent, string dataName, string path)
        //{
        //    SqlConnection connecction = null;
        //    try
        //    {
        //        connecction = new SqlConnection(strSql);
        //        SqlCommand command = connecction.CreateCommand();
        //        connecction.Open();

        //        FileStream stream = new FileStream(sqlFileName, FileMode.Open);
        //        StreamReader reader = new StreamReader(stream);
        //        StringBuilder builder = new StringBuilder();
        //        String strLine = "";
        //        while ((strLine = reader.ReadLine()) != null)
        //        {

        //            if (strLine.Trim().ToUpper() != @"GO")
        //            {
        //                builder.AppendLine(strLine);
        //            }
        //            else
        //            {
        //                command.CommandText = builder.ToString();
        //                command.ExecuteNonQuery();
        //                builder.Remove(0, builder.Length);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    finally
        //    {
        //        if (connecction != null && connecction.State != ConnectionState.Closed)
        //        {
        //            connecction.Close();
        //        }
        //    }
        //}

        /// <summary>  
        /// 执行带GO的SQL，返回最后一条SQL的受影响行数  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <returns>返回最后一条SQL的受影响行数</returns>  
        public   int ExecuteNonQueryWithGo(string strSql, string sqlContent, string dataName, string path)  
        {  
            int result = 0;
            string[] arr = System.Text.RegularExpressions.Regex.Split(sqlContent, "GO");
            using (SqlConnection conn = new SqlConnection(strSql))  
            {  
                conn.Open();  
                SqlCommand cmd = new SqlCommand();  
                cmd.Connection = conn;  
                SqlTransaction tx = conn.BeginTransaction();  
                cmd.Transaction = tx;  
                try  
                {  
                    for (int n = 0; n < arr.Length; n++)  
                    {  
                        string strsql = arr[n];  
                        if (strsql.Trim().Length > 1)  
                        {  
                            cmd.CommandText = strsql;  
                            result = cmd.ExecuteNonQuery();  
                        }  
                    }  
                    tx.Commit();  
                }  
                catch (System.Data.SqlClient.SqlException E)  
                {  
                    tx.Rollback();  
                    //return -1;  
                    throw new Exception(E.Message);  
                }  
                finally   
                {  
                    if (conn.State != ConnectionState.Closed)   
                    {  
                        conn.Close();  
                        conn.Dispose();  
                    }  
                }  
            }  
            return result;  
        }  

        /// <summary>
        /// 授权
        /// </summary>
        /// <param name="path"></param>
        private static void SetFullControl(string path)
        {
            FileInfo info = new FileInfo(path);
            FileSecurity fs = info.GetAccessControl();
            fs.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            info.SetAccessControl(fs);
        }
    }
}
