using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using FileManager.Common;
using FileManager.DAL;
using FileManager.BLL;

namespace FileManager
{
    public partial class FrmWait : CCSkinMain
    {
        private string forderPath;
        private FileManager.Model.UserModel user;

        private string dbname;
        private int type;
        private string server;
        private string uid;
        private string pwd;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="forderPath"></param>
        /// <param name="user"></param>
        public FrmWait(string forderPath, FileManager.Model.UserModel user, int type)
        {
            this.forderPath = forderPath;
            this.user = user;
            this.type = type;

            InitializeComponent();

            if (type == 1)
            {
                this.lodding.Text = "安装中...";
                this.Text = "服务端安装";
            }
        }
        public FrmWait(string dbname, int type, string server, string uid, string pwd)
        {
            this.dbname = dbname;
            this.type = type;
            this.server = server;
            this.uid = uid;
            this.pwd = pwd;

            InitializeComponent();

            if (type == 0)
            {
                this.lodding.Text = "数据库FileManager安装中...";
                this.Text = "数据库FileManager安装中...";
            }
            else
            {
                this.lodding.Text = "数据库FileContent安装中...";
                this.Text = "数据库FileContent安装中...";
            }
        }

        private void FrmWait_Shown(object sender, EventArgs e)
        {
            try
            {
                bool ret = false;
                if (type == 1)
                {
                    //CheckFolderDownloadFromDb(this.forderPath, this.user);

                    // 开始安装
                    FileManager.ServerSetup.InstallDB install = new ServerSetup.InstallDB();
                    ret = install.InstallBySql(dbname, type, server, uid, pwd);
                }
                else
                {
                    //CheckFolderUploadToDb(this.forderPath, this.user);
                    // 开始安装
                    FileManager.ServerSetup.InstallDB install = new ServerSetup.InstallDB();
                    ret = install.InstallBySql(dbname, type, server, uid, pwd);
                }
                this.DialogResult = ret ? System.Windows.Forms.DialogResult.OK : System.Windows.Forms.DialogResult.No;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
