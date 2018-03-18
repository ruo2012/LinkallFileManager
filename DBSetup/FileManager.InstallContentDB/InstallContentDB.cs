using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data.SqlClient;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace FileManager.InstallContentDB
{
    [RunInstaller(true)]
    public partial class InstallContentDB : System.Configuration.Install.Installer
    {
        public InstallContentDB()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 附加数据库方法
        /// </summary>
        /// <param name="strSql">连接数据库字符串，连接master系统数据库</param>
        /// <param name="DataName">数据库名字</param>
        /// <param name="strMdf">数据库文件MDF的路径</param>
        /// <param name="strLdf">数据库文件LDF的路径</param>
        /// <param name="path">安装目录</param>
        private void CreateDataBase(string strSql, string DataName, string strMdf, string strLdf, string path)
        {
            SqlConnection myConn = new SqlConnection(strSql);
            String str = null;
            try
            {
                str = " EXEC sp_attach_db @dbname='" + DataName + "',@filename1='" + strMdf + "',@filename2='" + strLdf + "'";
                SqlCommand myCommand = new SqlCommand(str, myConn);
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("数据库安装成功！点击确定继续");//需Using System.Windows.Forms
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

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            try
            {
                string dbname = this.Context.Parameters["dbname"];//数据库名称
                string server = this.Context.Parameters["server"];//服务器名称
                string uid = this.Context.Parameters["user"];//SQlServer用户名
                string pwd = this.Context.Parameters["pwd"];//密码
                string path = this.Context.Parameters["targetdir"];//安装目录
                string strSql = "Server=" + server + ";User Id=" + uid + ";Password=" + pwd + ";Database=master;";//连接数据库字符串
                if (uid.Length == 0 && pwd.Length == 0)
                {
                    strSql = "Server=" + server + ";Database=master;Trusted_Connection=True;";//Windows身份验证
                }
                string DataName = "SCDB81";//数据库名
                if (dbname != null)
                {
                    DataName = dbname;
                }
                string strMdf = path + DataName + ".mdf";//MDF文件路径，这里需注意文件名要与刚添加的数据库文件名一样！
                string strLdf = path + DataName + ".ldf";//LDF文件路径
                //MessageBox.Show("数据库文件授权");
                //SetFullControl(strMdf);
                //SetFullControl(strLdf);
                //MessageBox.Show("数据库文件授权成功");
                MessageBox.Show("数据库文件安装开始");

                base.Install(stateSaver);
                MessageBox.Show("数据库文件安装成功");
                MessageBox.Show("数据库文件创建数据库");

                this.CreateDataBase(strSql, DataName, strMdf, strLdf, path);//开始创建数据库
                MessageBox.Show("数据库文件创建数据库成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库安装失败！" + ex.Message + "|" + ex.StackTrace + "\n\n" + "您可以手动附加数据");
            }
        }

        private static void SetFullControl(string path)
        {
            FileInfo info = new FileInfo(path);
            FileSecurity fs = info.GetAccessControl();
            fs.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            info.SetAccessControl(fs);
        }
    }
}
