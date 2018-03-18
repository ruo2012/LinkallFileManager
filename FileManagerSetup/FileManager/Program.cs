
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FileManager.BLL;
using FileManager.Common;
using FileManager.Bll;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Management;
using System.Text;

namespace FileManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            SingleProcess.Singling("登录时间：");
            #region 开启新的实例
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //是否直接最小化【0：否，1：是】
            int loginType = 0;
            //带参数运行
            if (args.Length > 0)
            {
                //带提示框登录
                if (args[0] == "TIPLOGIN")
                {
                    FrmTipLogin frmLoingTip = new FrmTipLogin();
                    if (frmLoingTip.ShowDialog() == DialogResult.Retry)
                    {
                        loginType = 1;
                    }
                }
            }

            try
            {
                //系统检查
                SystemBll.SystemCheck();

                //数据库连接检查
                bool isLinkSuccess = SystemBll.SystemLinkCheckSys();
                if (!isLinkSuccess)
                {
                    FrmLoginError frmLoginError = new FrmLoginError("");
                    if (frmLoginError.ShowDialog() != DialogResult.OK)
                    {
                        Application.Exit();
                    }
                }

                //需要密码登录控制【服务器控制】
                if (SystemBll.ServerConfigInfo.SystemLoginType == 0)
                {
                    FrmLogin loginForm = new FrmLogin();
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        ///登录不成功退出
                        Application.Exit();
                        return;
                    }
                }

                //FrmMain mainForm = new FrmMain();
                FrmMain mainForm = FrmMainSingle.MainForm;
                //如果是登录到缩小按钮
                if (loginType == 1)
                {
                    mainForm.WindowState = FormWindowState.Minimized;
                    mainForm.notifyIcon1.Visible = true;
                    mainForm.Hide();
                }


                //自动登录
                if (SystemBll.ServerConfigInfo.SystemLoginType == 1)
                {
                    SystemBll.AutoLogin();
                }

                //开启端口接受监控消息
                FileManagerServer.OpenServer();
                Application.Run(mainForm);
            }
            catch (CustomException cex)
            {
                if (cex.Message != null && cex.Message.IndexOf("通常每个套接字地址") > -1)
                {
                    //string errorMsgDes = "您已打开文件管理系统，不能打开两个应用!";
                    string errorMsgDes = "您已经打开实验数据备份系统，请从右下角的托盘中打开!";
                    //异常界面展示
                    //FrmError errorMsg = new FrmError(errorMsgDes);

                    FrmFriendTip errorMsg = new FrmFriendTip(errorMsgDes);
                    errorMsg.ShowDialog();
                }
                else
                {
                    //异常界面展示
                    FrmError errorMsg = new FrmError(cex.Message);
                    errorMsg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                //异常界面展示
                if (ex.Message != null && ex.Message.IndexOf("通常每个套接字地址") > -1)
                {
                    //string errorMsgDes = "您已打开文件管理系统，不能打开两个应用!";
                    string errorMsgDes = "您已经打开实验数据备份系统，请从右下角的托盘中打开!";
                    //异常界面展示
                    FrmFriendTip errorMsg = new FrmFriendTip(errorMsgDes);
                    //FrmError errorMsg = new FrmError(errorMsgDes);
                    errorMsg.ShowDialog();
                }
                else
                {
                    //异常界面展示
                    FrmError errorMsg = new FrmError(ex.Message);
                    errorMsg.ShowDialog();
                    try
                    {
                        LogHelper.WriteLog(LogType.Error, ex.Message + "\r\n" + ex.StackTrace);
                    }
                    catch
                    {
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// 当前账号只能运行一个程序
        /// </summary>
        /// <returns></returns>
        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            //[] processes = Process.GetProcessesByName(current.ProcessName);
            Process[] processes = Process.GetProcessesByName(Application.ProductName);
            //遍历与当前进程名称相同的进程列表  
            foreach (Process process in processes)
            {
                //如果实例已经存在则忽略当前进程  
                if (process.Id != current.Id)
                {
                    ////保证要打开的进程同已经存在的进程来自同一文件路径
                    //if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    //{
                    //    //返回已经存在的进程
                    //    return process;
                    //}

                    string processName = GetProcessUserName(process.Id);
                    if (processName == Bll.SystemBll.CurrentUserName)
                    {
                        return process;
                    }
                }
                else
                {
                    return process;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据进程id获取当前账号登录名
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        private static string GetProcessUserName(int pID)
        {
            string text1 = null;
            SelectQuery query1 = new SelectQuery("Select * from Win32_Process WHERE processID=" + pID);
            ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(query1);
            try
            {
                foreach (ManagementObject disk in searcher1.Get())
                {
                    ManagementBaseObject inPar = null;
                    ManagementBaseObject outPar = null;

                    inPar = disk.GetMethodParameters("GetOwner");
                    outPar = disk.InvokeMethod("GetOwner", inPar, null);

                    text1 = outPar["User"].ToString();
                    break;
                }
            }
            catch
            {
                text1 = "SYSTEM";
            }
            return text1;
        }

        #region  确保程序只运行一个实例

        private static void HandleRunningInstance(Process instance)
        {
            MessageBox.Show("已经在运行！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowWindowAsync(instance.MainWindowHandle, 1);  //调用api函数，正常显示窗口
            SetForegroundWindow(instance.MainWindowHandle); //将窗口放置最前端
        }
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);


        #endregion

    }
}
