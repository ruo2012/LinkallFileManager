using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Management;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;

namespace FileManager.MonitoringService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartService();
        }

        protected override void OnStop()
        {
        }

        //注意：引用System.Management.dll 和 using System.Management;
        static void StartService()
        {
            //创建WQL事件查询，用于实例创建
            var qCreate = new WqlEventQuery("__InstanceCreationEvent",
                TimeSpan.FromSeconds(1),  //WHTHIN = 1
                "TargetInstance ISA 'Win32_Process'");
            //创建WQL事件查询，用于实例删除
            var qDelete = new WqlEventQuery("__InstanceDeletionEvent",
                TimeSpan.FromSeconds(1),  //WHTHIN = 1
                "TargetInstance ISA 'Win32_Process'");

            //创建事件查询的侦听器（ManagementEventWatcher）
            var wCreate = new ManagementEventWatcher(qCreate);
            var wDelete = new ManagementEventWatcher(qDelete);

            //事件注册代码
            wCreate.EventArrived += (sender, e) =>
            {
                string processName = GetInfo(e.NewEvent);
                //Console.WriteLine("运行：{0}", GetInfo(e.NewEvent));
                WriteLog( string.Format("运行：{0} \r\n", GetInfo(e.NewEvent)));
                if (processName == "notepad.exe")
                {
                    //Process process = new Process();
                    //process.StartInfo.FileName = @"E:\C#WINFORM_2015\私单资料准备\CSkin\bak\360安全卫士DEMO-10.30更新\360安全卫士DEMO-10.30更新\bak_5_7\58\57\FileManager\bin\Debug\FileManager.exe";
                    //process.Start();
                    WriteLog(string.Format("软件监控：{0}进入 \r\n", processName));
                    if (!IsProcessExist("FileManager"))
                    {
                        string installLocation = GetInstallLocatioPath("文件管理中心");
                        if (!string.IsNullOrEmpty(installLocation))
                        {
                            //if (!installLocation.EndsWith("\\")) installLocation += "\\";
                            //string exePath = installLocation + "FileManager.exe";
                            ProcessStart(installLocation);
                            //Console.WriteLine("安装路径：{0}", installLocation);
                            WriteLog(string.Format("安装路径：{0} \r\n", installLocation));
                        }
                    }
                }

            };
            wDelete.EventArrived += (sender, e) =>
            {
                //Console.WriteLine("关闭：{0}", GetInfo(e.NewEvent));
                WriteLog(string.Format("关闭：{0} \r\n", GetInfo(e.NewEvent)));
            };

            //异步开始侦听
            wCreate.Start();
            wDelete.Start();

            //Console.WriteLine("按任意键停止监控");
            //Console.ReadKey(true);
        }

        //输出事件对应的ManagementBaseObject（本例中的Win32_LogicalDisk实例）的信息
        static string GetInfo(ManagementBaseObject mobj)
        {
            var instance = (ManagementBaseObject)mobj["TargetInstance"];
            //return string.Format("{0} - {1}", instance["Name"], DateTime.Now);
            return string.Format("{0}", instance["Name"]);
        }

        /// <summary>
        /// 启动软件
        /// </summary>
        /// <param name="path"></param>
        private static void ProcessStart(string path)
        {
            //定义一个ProcessStartInfo实例
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            //设置启动进程的初始目录^
            //info.WorkingDirectory = @"E:\C#WINFORM_2015\私单资料准备\CSkin\bak\360安全卫士DEMO-10.30更新\360安全卫士DEMO-10.30更新\bak_5_7\58\57\FileManager\bin\Debug";
            info.WorkingDirectory = path;
            //设置启动进程的应用程序或文档名
            info.FileName = @"FileManager.exe";
            //设置启动进程的参数
            info.Arguments = "";
            //启动由包含进程启动信息的进程资源

            try
            {
                System.Diagnostics.Process.Start(info);
            }
            catch (System.ComponentModel.Win32Exception we)
            {
                return;
            }
        }

        /// <summary>
        /// 进程是否已经存在
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 获取软件安装路径
        /// </summary>
        /// <param name="softwareName"></param>
        /// <returns></returns>
        private static string GetInstallLocatioPath(string softwareName)
        {
            //先读取64位系统
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\FileManager201505\Path", false))
            {
                if (key != null)//判断对象存在
                {
                    string installLocation = key.GetValue("Path", "").ToString();//获取安装路径
                    return installLocation;
                }
            }

            //再读取32位系统
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\FileManager201505\Path", false))
            {
                if (key != null)//判断对象存在
                {
                    string installLocation = key.GetValue("Path", "").ToString();//获取安装路径
                    return installLocation;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 写日志
        /// <param name="msg">日志内容</param> 
        /// </summary>
        public static void WriteLog(string msg)
        {
            try
            {
                string dir = @"D:\FMMonitoringService";
                if (Directory.Exists(dir)) Directory.CreateDirectory(dir);

                string str = string.Format(@"{0}\Log", dir);
                string path = string.Format(@"{0}\{1}_{2}.log", str, "Log", DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(str))
                {
                    Directory.CreateDirectory(str);
                }
                using (FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    string s = string.Concat(new object[] { "输出时间：", DateTime.Now, msg });
                    byte[] bytes = Encoding.UTF8.GetBytes(s);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            catch (IOException exception)
            {
               //throw new IOException(exception.Message, exception);
            }
        }
    }
}
