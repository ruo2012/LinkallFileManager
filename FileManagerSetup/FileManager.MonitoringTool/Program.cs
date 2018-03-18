using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace FileManager.MonitoringTool
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            AlwaysRun();
            //WindowHide(System.Console.Title);
            //Console.ReadKey();
            Application.Run();
        }

        /// <summary>
        /// 一直运行
        /// </summary>
        private static void AlwaysRun()
        {
            try
            {
                StartService();
            }
            catch (Exception ex)
            {
                //发生异常再次运行
                Thread.Sleep(5000);
                AlwaysRun();
            }
        }

        /// <summary>
        /// 开启监控事件注意：引用System.Management.dll 和 using System.Management;
        /// </summary>
        static void StartService()
        {
            //初始化配置信息
            GetClientSysConfig();

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

            WriteLog(string.Format("开启监控：{0} \r\n", DateTime.Now));

            //事件注册代码【监控软件的启动】【20151029 启动事件暂时取消】
            //wCreate.EventArrived += (sender, e) =>
            //{
            //    string processName = GetInfo(e.NewEvent);
            //    //Console.WriteLine("运行：{0}", GetInfo(e.NewEvent));
            //    //WriteLog(string.Format("运行：{0} \r\n", GetInfo(e.NewEvent)));
            //    if (IsNeedSoftWare(processName))
            //    {
            //        //Process process = new Process();
            //        //process.StartInfo.FileName = @"E:\C#WINFORM_2015\私单资料准备\CSkin\bak\360安全卫士DEMO-10.30更新\360安全卫士DEMO-10.30更新\bak_5_7\58\57\FileManager\bin\Debug\FileManager.exe";
            //        //process.Start();
            //        //WriteLog(string.Format("软件开启：{0}进入 \r\n", processName));
            //        if (!IsProcessStartExist("FileManager"))
            //        {
            //            string installLocation = GetInstallLocatioPath("文件管理中心");
            //            if (!string.IsNullOrEmpty(installLocation))
            //            {
            //                //if (!installLocation.EndsWith("\\")) installLocation += "\\";
            //                //string exePath = installLocation + "FileManager.exe";

            //                //installLocation=@"E:\C#WINFORM_2015\私单资料准备\CSkin\bak\360安全卫士DEMO-10.30更新\360安全卫士DEMO-10.30更新\bak_5_7\66\65\FileManager\bin\Debug";

            //                ProcessStart(installLocation);
            //                //Console.WriteLine("安装路径：{0}", installLocation);
            //                 WriteLog(string.Format("安装路径：{0} \r\n", installLocation));
            //            }
            //        }
            //    }
            //};

            //监控软件的关闭
            wDelete.EventArrived += (sender, e) =>
            {
                string processName = GetInfo(e.NewEvent);
                if (IsNeedSoftWare(processName))
                {
                    //WriteLog(string.Format("软件关闭：{0}进入 \r\n", processName));
                    if (IsProcessExist("FileManager"))
                    {
                        string installLocation = GetInstallLocatioPath("文件管理中心");
                        if (!string.IsNullOrEmpty(installLocation))
                        {
                            ProcessEnd(processName);
                            WriteLog(string.Format("安装路径：{0} \r\n", installLocation));
                        }
                    }
                }
                //Console.WriteLine("关闭：{0}", GetInfo(e.NewEvent));
                WriteLog(string.Format("关闭：{0} \r\n", GetInfo(e.NewEvent)));
            };

            //异步开始侦听
            wCreate.Start();
            wDelete.Start();

            //Console.WriteLine("按任意键停止监控");
            //Console.ReadKey(true);
        }

        /// <summary>
        /// 输出事件对应的ManagementBaseObject（本例中的Win32_LogicalDisk实例）的信息
        /// 输出监控的软件进程名称
        /// </summary>
        /// <param name="mobj"></param>
        /// <returns></returns>
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
            info.Arguments = "TIPLOGIN";
            //启动由包含进程启动信息的进程资源

            try
            {
                System.Diagnostics.Process.Start(info);
            }
            catch (System.ComponentModel.Win32Exception we)
            {
                WriteLog(string.Format("系统异常启动进程异常：{0} \r\n", we.Message ));
                return;
            }
        }

        /// <summary>
        /// 软件关闭的事件
        /// </summary>
        /// <param name="path"></param>
        private static void ProcessEnd(string name)
        {
            ClientSendMsg("ONECLIEKUPLOAD" + "|" + name);
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
                    string curProcessName = GetProcessUserName(p.Id);
                    if (curProcessName == System.Environment.UserName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 进程是否已经存在
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        private static bool IsProcessStartExist(string processName)
        {
            Process[] myProcess = Process.GetProcesses();
            foreach (Process p in myProcess)
            {
                if (p.ProcessName == processName)
                {
                    WriteLog(string.Format("软件监控成功：{0}进入 \r\n", processName));

                    //如果是其他账号的进程，杀掉
                    string curProcessName = GetProcessUserName(p.Id);
                    if (curProcessName == System.Environment.UserName)
                    {
                        return true;
                    }
                    else
                    {
                        //WriteLog(string.Format("软件监控成功：{0}是其他账号的进程 \r\n", processName));
                        try
                        {
                            p.Kill();
                        }
                        catch (Exception ex)
                        {
                            WriteLog(string.Format("系统异常关闭进程异常：{0} \r\n", ex.Message));
                        }
                        return true;
                    }
                }
            }
            return false;
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

        private static int isNeedLog = 1;
        /// <summary>
        /// 写日志
        /// <param name="msg">日志内容</param> 
        /// </summary>
        public static void WriteLog(string msg)
        {
            try
            {
                //出现异常直接放弃
                if (isNeedLog <= 0) return;
                string dir = string.Format(@"D:\FMMonitoringService\{0}", System.Environment.UserName);
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
                isNeedLog = -1;
                //throw new IOException(exception.Message, exception);
            }
        }

        #region 监控软件与客户端通信

        //创建 1个客户端套接字 和1个负责监听服务端请求的线程  
        static Socket socketClient = null;
        static Thread threadClient = null;
        static string serverIp = "127.0.0.1"; //负责监听客户端的地址
        static string serverPort = "8978"; //负责监听客户端的端口

        /// <summary>
        /// 同客户端软件打开连接
        /// </summary>
        private static void OpenClient()
        {
            try
            {
                //定义一个套字节监听  包含3个参数(IP4寻址协议,流式连接,TCP协议)
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //需要获取文本框中的IP地址
                IPAddress ipaddress = IPAddress.Parse(serverIp);
                //将获取的ip地址和端口号绑定到网络节点endpoint上
                IPEndPoint endpoint = new IPEndPoint(ipaddress, int.Parse(serverPort));
                //这里客户端套接字连接到网络节点(服务端)用的方法是Connect 而不是Bind
                socketClient.Connect(endpoint);
                isOpen = 1;
                #region  监听服务端发来的消息[暂时删除]
                ////创建一个线程 用于监听服务端发来的消息
                //threadClient = new Thread(RecMsg);
                ////将窗体线程设置为与后台同步
                //threadClient.IsBackground = true;
                ////启动线程
                //threadClient.Start();
                #endregion
            }
            catch (Exception ex)
            {
                isOpen = -1;
            }
        }
        private static int isOpen = 0;
        /// <summary>
        /// 接收服务端发来信息的方法
        /// </summary>
        private static void RecMsg()
        {
            while (true) //持续监听服务端发来的消息
            {
                //定义一个1M的内存缓冲区 用于临时性存储接收到的信息
                byte[] arrRecMsg = new byte[1024 * 1024];
                //将客户端套接字接收到的数据存入内存缓冲区, 并获取其长度
                int length = socketClient.Receive(arrRecMsg);
                //将套接字获取到的字节数组转换为人可以看懂的字符串
                string strRecMsg = Encoding.UTF8.GetString(arrRecMsg, 0, length);
                //将发送的信息追加到聊天内容文本框中
                //txtMsg.AppendText("So-flash:" + GetCurrentTime() + "\r\n" + strRecMsg + "\r\n");
            }
        }

        /// <summary>
        /// 发送字符串信息到服务端的方法
        /// </summary>
        /// <param name="sendMsg">发送的字符串信息</param>
        private static void ClientSendMsg(string sendMsg)
        {
            //没有打开连接，则打开
            //if (socketClient == null || isOpen <= 0)
            //{
            OpenClient();
            //}

            //打开失败，取消发送消息
            if (socketClient == null || isOpen <= 0)
            {
                return;
            }

            //将输入的内容字符串转换为机器可以识别的字节数组
            byte[] arrClientSendMsg = Encoding.UTF8.GetBytes(sendMsg);

            try
            {
                //调用客户端套接字发送字节数组
                int retNum = socketClient.Send(arrClientSendMsg);
            }
            catch (Exception ex)
            {
                OpenClient();
                socketClient.Send(arrClientSendMsg);
            }
            //将发送的信息追加到聊天内容文本框中
            //txtMsg.AppendText("天之涯:" + GetCurrentTime() + "\r\n" + sendMsg + "\r\n");
        }

        /// <summary>
        /// 获取当前系统时间的方法
        /// </summary>
        /// <returns>当前时间</returns>
        private static DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }
        #endregion

        #region 获取客户端监控软件配置信息

        /// <summary>
        /// 缓存监控软件名称
        /// </summary>
        private static Dictionary<string, string> _monitorSoftwareNams;

        /// <summary>
        /// 初始化一下客户端的软件监控列表信息
        /// </summary>
        /// <param name="configPath"></param>
        private static void GetClientSysConfig()
        {
            if (_monitorSoftwareNams == null)
            {
                string installLocation = GetInstallLocatioPath("文件管理中心");
                if (!installLocation.EndsWith("\\")) installLocation = installLocation + "\\";

                string configPath = string.Format("{0}System.config", installLocation);
                if (!File.Exists(configPath))
                {
                    WriteLog("未找到系统配置文件，请联系管理员处理！");
                    return;
                }

                ClientSystemConfig.InitConfig(configPath);
                SystemConfig config = ClientSystemConfig.ClientSystemConfigCache;
                if (config != null && !string.IsNullOrEmpty(config.MonitoringSoftWareNames))
                {
                    string[] items = config.MonitoringSoftWareNames.Split('|');
                    _monitorSoftwareNams = new Dictionary<string, string>();

                    if (items != null && items.Length > 0)
                    {

                    }
                    else if (!string.IsNullOrEmpty(config.MonitoringSoftWareNames))
                    {
                        _monitorSoftwareNams.Add(config.MonitoringSoftWareNames, config.MonitoringSoftWareNames);
                        return;
                    }
                    foreach (var item in items)
                    {
                        if (string.IsNullOrEmpty(item)) continue;
                        if (!_monitorSoftwareNams.ContainsKey(item))
                        {
                            _monitorSoftwareNams.Add(item, item);
                        }
                    }
                }
                string s = string.Empty;
                foreach (var item in _monitorSoftwareNams)
                {
                    s += item + "|";
                }
                WriteLog(string.Format("_monitorSoftwareNams：{0} \r\n", s));
            }
        }

        /// <summary>
        /// 是否包含了监控的软件
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static bool IsNeedSoftWare(string name)
        {
            if (string.IsNullOrEmpty(name) || _monitorSoftwareNams == null || _monitorSoftwareNams.Count == 0) return false;
            if (_monitorSoftwareNams.ContainsKey(name)) return true;
            return false;
        }

        #endregion

        #region 隐藏窗口
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        public static void WindowHide(string consoleTitle)
        {
            IntPtr a = FindWindow("ConsoleWindowClass", consoleTitle);
            if (a != IntPtr.Zero)
                ShowWindow(a, 0);//隐藏窗口  
            else
                throw new Exception("can't hide console window");
        }
        #endregion
    }
}
