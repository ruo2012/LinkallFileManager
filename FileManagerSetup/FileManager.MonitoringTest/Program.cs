using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace FileManager.MonitoringTest
{
    class Program
    {
        //注意：引用System.Management.dll 和 using System.Management;
        static void Main(string[] args)
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
                Console.WriteLine("运行：{0}", GetInfo(e.NewEvent));
                if (processName == "notepad.exe")
                {
                    //Process process = new Process();
                    //process.StartInfo.FileName = @"E:\C#WINFORM_2015\私单资料准备\CSkin\bak\360安全卫士DEMO-10.30更新\360安全卫士DEMO-10.30更新\bak_5_7\58\57\FileManager\bin\Debug\FileManager.exe";
                    //process.Start();
                    if (!IsProcessExist("FileManager"))
                    {
                        string installLocation = GetInstallLocatioPath("文件管理中心");
                        if (!string.IsNullOrEmpty(installLocation))
                        {
                            //if (!installLocation.EndsWith("\\")) installLocation += "\\";
                            //string exePath = installLocation + "FileManager.exe";
                            ProcessStart(installLocation);
                            Console.WriteLine("安装路径：{0}", installLocation);
                        }
                    }
                }

            };
            wDelete.EventArrived += (sender, e) =>
            {
                Console.WriteLine("关闭：{0}", GetInfo(e.NewEvent));
            };

            //异步开始侦听
            wCreate.Start();
            wDelete.Start();

            Console.WriteLine("按任意键停止监控");
            Console.ReadKey(true);
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

        #region 暂时不使用

        /// <summary>
        /// 注册表获取软件路径
        /// </summary>
        /// <param name="softwareName"></param>
        /// <returns></returns>
        private static string GetInstallLocatioPathOld(string softwareName)
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", false))
            {
                if (key != null)//判断对象存在
                {
                    foreach (string keyName in key.GetSubKeyNames())//遍历子项名称的字符串数组
                    {
                        using (RegistryKey key2 = key.OpenSubKey(keyName, false))//遍历子项节点
                        {
                            if (key2 != null)
                            {
                                string keySoftwareName = key2.GetValue("DisplayName", "").ToString();//获取软件名
                                if (keySoftwareName == softwareName)
                                {
                                    //string installLocation = key2.GetValue("InstallLocation", "").ToString();//获取安装路径
                                    string installLocation = key2.GetValue("InstallSource", "").ToString();//获取安装路径
                                    return installLocation;
                                }
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 注册表获取软件路径
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetProcessPath(string name)
        {
            string temp = null, tempType = null;
            object displayName = null, uninstallString = null, releaseType = null;
            RegistryKey currentKey = null;
            int softNum = 0;
            RegistryKey pregkey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");//获取指定路径下的键
            try
            {
                foreach (string item in pregkey.GetSubKeyNames())               //循环所有子键
                {
                    currentKey = pregkey.OpenSubKey(item);
                    displayName = currentKey.GetValue("DisplayName");           //获取显示名称
                    uninstallString = currentKey.GetValue("UninstallString");   //获取卸载字符串路径
                    releaseType = currentKey.GetValue("ReleaseType");           //发行类型,值是Security Update为安全更新,Update为更新
                    bool isSecurityUpdate = false;
                    if (releaseType != null)
                    {
                        tempType = releaseType.ToString();
                        if (tempType == "Security Update" || tempType == "Update")
                            isSecurityUpdate = true;
                    }
                    if (!isSecurityUpdate && displayName != null && uninstallString != null)
                    {
                        softNum++;
                        temp += displayName.ToString() + Environment.NewLine;
                    }
                }
            }
            catch (Exception E)
            {
            }

            pregkey.Close();
            return string.Empty;
        }

        /// <summary>
        /// windows 获取所有软件安装路径
        /// </summary>
        static void ShowAllHaveInstallSoftWare()
        {
            StringBuilder result = new StringBuilder();
            for (int index = 0; ; index++)
            {
                StringBuilder productCode = new StringBuilder(39);
                if (MsiEnumProducts(index, productCode) != 0)
                {
                    break;
                }

                foreach (string property in new string[] { "ProductName", "Publisher", "VersionString", })
                {
                    int charCount = 512;
                    StringBuilder value = new StringBuilder(charCount);

                    if (MsiGetProductInfo(productCode.ToString(), property, value, ref charCount) == 0)
                    {
                        value.Length = charCount;
                        result.AppendLine(value.ToString());
                    }
                }
                result.AppendLine();
            }
            Console.WriteLine(result.ToString());
        }

        [DllImport("msi.dll", SetLastError = true)]
        static extern int MsiEnumProducts(int iProductIndex, StringBuilder lpProductBuf);

        [DllImport("msi.dll", SetLastError = true)]
        static extern int MsiGetProductInfo(string szProduct, string szProperty, StringBuilder lpValueBuf, ref int pcchValueBuf);

        #endregion
    }
}
