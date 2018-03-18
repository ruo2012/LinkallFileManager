using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Management;

namespace FileManager.MonitoringToolSetup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //文件名
        string name = "FileManager.MonitoringTool.exe";
        //注册表名称
        string regName = "FMMonitorService";
        //进程名称
        string processName = "FileManager.MonitoringTool";

        #region 桌面事件
        private void button_serviceIntall_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_tipMsg.AppendText("监控安装开始：..." + GetCurrentTime() + "\r\n");

                //关闭进程
                if (!ProcessKill(processName))
                {
                    textBox_tipMsg.AppendText("监控安装失败：进程无法关闭！" + GetCurrentTime() + "\r\n");
                    return;
                }

                //寻找文件路径
                string path = GetFileForder();
                string filePath = string.Format("{0}\\{1}", path, name);
                //当前服务路径
                // string curFilePath = string.Format("{0}\\FMMonitorService", System.Environment.CurrentDirectory);
                string curFilePath = string.Format("{0}\\FMMonitorService",  System.AppDomain.CurrentDomain.BaseDirectory);
                if (!Directory.Exists(curFilePath))
                {
                    textBox_tipMsg.AppendText("监控安装失败：未能找到服务程序:FMMonitorService目录！" + GetCurrentTime() + "\r\n");
                    return;
                }

                if (!MoveForder(curFilePath, path))
                {
                    textBox_tipMsg.AppendText("监控安装失败：程序文件拷贝异常！" + GetCurrentTime() + "\r\n");
                    return;
                }

                //添加注册表
                SetRegistryApp(regName, filePath);
                textBox_tipMsg.AppendText("监控安装成功！" + GetCurrentTime() + "\r\n");
            }
            catch (Exception ex)
            {
                textBox_tipMsg.AppendText("监控安装失败：" + ex.Message + GetCurrentTime() + "\r\n");
            }
        }

        private void button_serviceUnintall_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_tipMsg.AppendText("监控卸载开始：..." + GetCurrentTime() + "\r\n");

                //关闭进程
                if (!ProcessKill(processName))
                {
                    textBox_tipMsg.AppendText("监控卸载失败：进程无法关闭！" + GetCurrentTime() + "\r\n");
                    return;
                }

                //寻找文件路径
                string path = GetFileForder();
                string filePath = string.Format("{0}\\{1}", path, name);
                if (Directory.Exists(path))
                {
                    DirectoryInfo dir = new DirectoryInfo(path);
                    if (dir.Exists)
                    {
                        FileInfo[] files = dir.GetFiles();
                        foreach (var item in files)
                        {
                            item.Delete();
                        }
                    }


                    Directory.Delete(path);
                }

                //删除注册表
                DeleteRegisterApp(regName);
                textBox_tipMsg.AppendText("监控卸载成功！" + GetCurrentTime() + "\r\n");
            }
            catch (Exception ex)
            {
                textBox_tipMsg.AppendText("监控卸载失败：" + ex.Message + GetCurrentTime() + "\r\n");
            }
        }

        private void button_serviceOpen_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_tipMsg.AppendText("监控启动开始：..." + GetCurrentTime() + "\r\n");

                //寻找文件路径
                string path = GetFileForder();
                string filePath = string.Format("{0}\\{1}", path, name);

                if (!Directory.Exists(path) || !File.Exists(filePath))
                {
                    textBox_tipMsg.AppendText("监控启动失败：程序文件不存在！" + GetCurrentTime() + "\r\n");
                    return;
                }

                //开启进程
                if (!ProcessStart(this.name, path))
                {
                    textBox_tipMsg.AppendText("监控启动失败：进程无法开启！" + GetCurrentTime() + "\r\n");
                    return;
                }

                textBox_tipMsg.AppendText("监控启动成功！" + GetCurrentTime() + "\r\n");
            }
            catch (Exception ex)
            {
                textBox_tipMsg.AppendText("监控启动失败：" + ex.Message + GetCurrentTime() + "\r\n");
            }
        }

        private void button_serviceClose_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_tipMsg.AppendText("监控关闭开始：..." + GetCurrentTime() + "\r\n");

                //寻找文件路径
                string path = GetFileForder();
                string filePath = string.Format("{0}\\{1}", path, name);

                //关闭
                if (!ProcessKill(processName))
                {
                    textBox_tipMsg.AppendText("监控关闭失败：进程无法开启！" + GetCurrentTime() + "\r\n");
                    return;
                }

                textBox_tipMsg.AppendText("监控关闭成功！" + GetCurrentTime() + "\r\n");
            }
            catch (Exception ex)
            {
                textBox_tipMsg.AppendText("监控关闭失败：" + ex.Message + GetCurrentTime() + "\r\n");
            }
        }

        private static bool IsProcessExist(string processName)
        {
            Process[] myProcess = Process.GetProcesses();
            foreach (Process p in myProcess)
            {
                if (p.ProcessName == processName)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 公共方法
        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        private static bool ProcessKill(string processName)
        {
            try
            {
                Process[] myProcess = Process.GetProcesses();
                foreach (Process p in myProcess)
                {
                    if (p.ProcessName == processName)
                    {
                        p.Kill();
                            
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 启动软件
        /// </summary>
        /// <param name="path"></param>
        private static bool ProcessStart(string name,string path)
        {
            //定义一个ProcessStartInfo实例
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            //设置启动进程的初始目录^
            info.WorkingDirectory = path;
            //设置启动进程的应用程序或文档名
            info.FileName = name;
            //设置启动进程的参数
            info.Arguments = "";
            //启动由包含进程启动信息的进程资源

            try
            {
                info.CreateNoWindow = true;
                System.Diagnostics.Process.Start(info);
                return true;
            }
            catch (System.ComponentModel.Win32Exception we)
            {
                return false;
            }
        }

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

        /// <summary>
        /// 文件移动
        /// </summary>
        /// <param name="orgForder"></param>
        /// <param name="aimForder"></param>
        /// <returns></returns>
        private bool MoveForder(string orgForder, string aimForder)
        {
            try
            {
                aimForder = aimForder.EndsWith("\\") ? aimForder : aimForder + "\\";
                if (!Directory.Exists(aimForder))
                {
                    Directory.CreateDirectory(aimForder);
                }

                DirectoryInfo dir = new DirectoryInfo(orgForder);
                if (dir.Exists)
                {
                    FileInfo[] files = dir.GetFiles();
                    foreach (var item in files)
                    {
                        string aimFile = aimForder + item.Name;
                        item.CopyTo(aimFile, true);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 文件路径
        /// </summary>
        /// <returns></returns>
        private string GetFileForder()
        {
            string path1 = @"C:\Program Files\FMMonitorService";
            if (!Directory.Exists(path1))
            {
                Directory.CreateDirectory(path1);
            }
            return path1;
        }

        /// <summary>
        /// 获取当前系统时间的方法
        /// </summary>
        /// <returns>当前时间</returns>
        private DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }

        #endregion

        #region 将程序添加到启动项
        /// <summary>  
        /// 注册表操作，将程序添加到启动项  
        /// </summary>  
        public static void SetRegistryApp(string name, string path)
        {
            try
            {
                if (CheckExistRegisterApp(name)) return ;

                Microsoft.Win32.RegistryKey Reg;
                Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (Reg == null)
                {
                    Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                Reg.SetValue(name, path);
                Reg.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 将程序从启动项中删除
        /// <summary>  
        /// 注册表操作，删除注册表中启动项  
        /// </summary>  
        public static bool DeleteRegisterApp(string name)
        {
            try
            {
                if (!CheckExistRegisterApp(name)) return true;

                Microsoft.Win32.RegistryKey Reg;
                Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (Reg == null)
                {
                    Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                Reg.DeleteValue(name, false);
                Reg.Close();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        #endregion

        /// <summary>  
        ///     检查当前程序是否在启动项中  
        /// </summary>  
        /// <returns></returns>  
        public static bool CheckExistRegisterApp(string name)
        {
            bool bResult = false;

            try
            {
                Microsoft.Win32.RegistryKey Reg;
                Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (Reg == null)
                {
                    Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                }

                foreach (string s in Reg.GetValueNames())
                {
                    if (s.Equals(name))
                    {
                        bResult = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return bResult;
        }

        #region 自动创建windows的计划任务
        /// <summary>
        /// 创建windows计划任务
        /// </summary>
        /// <param name="taskName">任务名称</param>
        /// <param name="stateTime">执行时间</param>
        public static void CreateTask(string taskName, DateTime stateTime)
        {
            try
            {
                // 计划任务服务
                TaskService ts = new TaskService();

                // 创建一个计划任务
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "DTU执行未执行过的任务";  //任务描述
                td.RegistrationInfo.Author = "EcpDtu";            //任务作者

                //时间执行时间
                TimeTrigger tt = new TimeTrigger();
                tt.StartBoundary = DateTime.Now.AddSeconds(5);//stateTime.AddHours(4); //开始时间
                tt.EndBoundary = DateTime.Now.AddSeconds(10);//stateTime.AddHours(8);   //结束执行时间
                td.Triggers.Add(tt);                      //将触发器添加到任务中

                //创建一个执行操作
                var exe = new ExecAction("RunTask.exe", null, System.Configuration.ConfigurationSettings.AppSettings["RunTask_path"]);
                //添加执行操作到计划任务的操作中
                td.Actions.Add(exe);

                //注册计划任务
                ts.RootFolder.RegisterTaskDefinition(taskName, td);
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建计划任务错误_CreateTask(string name)" + ex.Message);
            }
        }

        /// <summary>
        /// 查询计划任务
        /// </summary>
        /// <param name="taskName"></param>
        public static void RetrieveTestTask(string taskName)
        {
            // 计划任务服务
            TaskService ts = new TaskService();
            Task t = ts.GetTask(taskName);
            if (t != null)
            {
                Console.WriteLine("Task Name={0}", t.Name);
                Console.WriteLine("Task Execution Time={0}", t.LastRunTime);
                Console.WriteLine("Task Last Run Result={0}", t.LastTaskResult);
                Console.WriteLine("Task Next Execution Time={0}", t.NextRunTime);
            }
        }

        /// <summary>
        /// 删除计划任务
        /// </summary>
        public static void DeleteTestTask(string taskName)
        {
            // 计划任务服务
            TaskService ts = new TaskService();
            ts.RootFolder.DeleteTask(taskName);
        }

        /// <summary>
        /// 确定 按钮 事件(是否设置为开机自动启动）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, EventArgs e)
        {

            //获取程序执行路径..
            string starupPath = Application.ExecutablePath;
            //class Micosoft.Win32.RegistryKey. 表示Window注册表中项级节点,此类是注册表装.
            RegistryKey loca = Registry.LocalMachine;
            RegistryKey run = loca.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");

            try
            {
                //SetValue:存储值的名称
                run.SetValue("qidong", starupPath);
                /// MessageBox.Show("已启用开机运行!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loca.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void Del()
        {
            //获取程序执行路径..
            string starupPath = Application.ExecutablePath;
            //class Micosoft.Win32.RegistryKey. 表示Window注册表中项级节点,此类是注册表装.
            RegistryKey loca = Registry.LocalMachine;
            RegistryKey run = loca.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");

            try
            {
                //SetValue:存储值的名称
                run.DeleteValue("qidong");
                MessageBox.Show("已停止开机运行!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loca.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
