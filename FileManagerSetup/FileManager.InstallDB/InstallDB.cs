using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data.SqlClient;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace FileManager.InstallDB
{
    [RunInstaller(true)]
    public partial class InstallDB : System.Configuration.Install.Installer
    {
        public InstallDB()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            try
            {
                string path = this.Context.Parameters["targetdir"];//安装目录
                if (!path.EndsWith("\\"))
                {
                    path = path + "\\";
                }

                string aimFilePath = string.Format("{0}FMMonitorService\\FileManager.MonitoringTool.exe", path);
                if (File.Exists(aimFilePath))
                {
                    if (!ProcessStart(aimFilePath))
                    {
                        //MessageBox.Show("程序启动异常！");
                        MessageBox.Show("程序自动启动失败，请重启计算！");
                    }
                }
                else
                {
                    //MessageBox.Show(aimFilePath);
                    //MessageBox.Show("目录不存在！");
                }

                //MessageBox.Show("开始删除快捷房事 ！");

                // 设置文件夹的权限
                SetFolderAuth(path);

                // 删除快捷方式
                DelChem32Link();

                base.Install(stateSaver);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("程序异常！" + ex.Message + ex.StackTrace);
                MessageBox.Show("程序自动启动失败，请重启计算！");
            }
        }

        private static void SetFolderAuth(string path)
        {
            string configFilePath = string.Format("{0}System.config", path);
            string logFilePath = string.Format("{0}Log", path);
            SetFolderFullControl(path);
            SetFullControl(configFilePath);
            SetFolderFullControl(logFilePath);
        }

        /// <summary>
        /// 删除快捷方式
        /// </summary>
        /// <returns></returns>
        private static bool DelChem32Link()
        {
            string linkName = "CHEM32";

            //获取软件快捷方式在桌面上的路径
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //返回桌面上*.lnk文件的集合
            string[] items = Directory.GetFiles(path, "*.lnk", SearchOption.TopDirectoryOnly);
            //遍历集合中的每个文件，如果名称包括“AutoCAD”则将其快捷方式删除。
            foreach (string item in items)
            {
                //MessageBox.Show(item);
                if (!string.IsNullOrEmpty(item) &&(item == linkName ||  item.ToUpper().Contains(linkName)))
                {
                    File.Delete(item);
                }
            }

            return true;
        }


        /// <summary>
        /// 启动软件
        /// </summary>
        /// <param name="path"></param>
        private static bool ProcessStart(string path)
        {
            ////定义一个ProcessStartInfo实例
            //System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            ////设置启动进程的初始目录^
            //info.WorkingDirectory = path;
            ////设置启动进程的应用程序或文档名
            //info.FileName = @"FileManager.MonitoringTool.exe";
            ////设置启动进程的参数
            //info.Arguments = string.Empty;
            ////启动由包含进程启动信息的进程资源

            try
            {
                //System.Diagnostics.Process.Start(info);
                System.Diagnostics.Process.Start(path); //打开文件
                return true;
            }
            catch (System.ComponentModel.Win32Exception we)
            {
                //MessageBox.Show("进程异常！" + we.Message + we.StackTrace);
                return false;
            }
        }

        private static void SetFullControl(string path)
        {
            FileInfo info = new FileInfo(path);
            if (!info.Exists)
            {
                return;
            }

            FileSecurity fs = info.GetAccessControl();
            fs.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            fs.AddAccessRule(new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow));
            info.SetAccessControl(fs);
        }

        private static void SetFolderFullControl(string path)
        {
            ////给Excel文件所在目录添加"Everyone,Users"用户组的完全控制权限  
            //DirectoryInfo di = new DirectoryInfo(path);
            //System.Security.AccessControl.DirectorySecurity dirSecurity = di.GetAccessControl();
            //dirSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            //dirSecurity.AddAccessRule(new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow));
            //di.SetAccessControl(dirSecurity);

            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists) return;

            DirectorySecurity ds = dir.GetAccessControl(AccessControlSections.All);
            //继承设置
            bool ok;
            InheritanceFlags iflag = new InheritanceFlags();
            iflag = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
            FileSystemAccessRule arules = new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, iflag, PropagationFlags.None, AccessControlType.Allow);
            ds.ModifyAccessRule(AccessControlModification.Add, arules, out ok);
            dir.SetAccessControl(ds);
        }
    }
}
