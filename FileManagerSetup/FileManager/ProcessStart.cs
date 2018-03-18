using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.Reflection;
using System.Management;
using System.IO;

namespace FileManager
{
    public class ProcessStart
    {
        /// <summary>
        /// 启动软件
        /// </summary>
        /// <param name="path"></param>
        private static void FunProcessStart(string path)
        {
            //定义一个ProcessStartInfo实例
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            //设置启动进程的初始目录^
            info.WorkingDirectory = path;
            //设置启动进程的应用程序或文档名
            info.FileName = @"ChemMain.exe";
            //设置启动进程的参数
            info.Arguments = "";

            try
            {
                System.Diagnostics.Process.Start(info);
            }
            catch (System.ComponentModel.Win32Exception we)
            {
                throw we;
            }
        }

        /// <summary>
        /// 启动软件
        /// </summary>
        /// <param name="path"></param>
        public static void FunProcessStart(string path,string chemName)
        {
            //定义一个ProcessStartInfo实例
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            //设置启动进程的初始目录^
            info.WorkingDirectory = path;
            //设置启动进程的应用程序或文档名
            info.FileName = chemName;//"ChemMain.exe"
            //设置启动进程的参数
            info.Arguments = "";

            try
            {
                System.Diagnostics.Process.Start(info);
            }
            catch (System.ComponentModel.Win32Exception we)
            {
                throw we;
            }
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

        public static void StartProcess(string softwareName)
        {
            string installLocation = GetInstallLocatioPath(softwareName);
            if (!string.IsNullOrEmpty(installLocation))
            {
                FunProcessStart(installLocation);
            }
        }

        /// <summary>
        /// 进程是否已经存在
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public static bool IsProcessExist(string processName)
        {
            if (processName.EndsWith(".exe") || processName.ToUpper().EndsWith(".EXE"))
            {
                processName = processName.Substring(0, processName.Length - 4);
            }
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
    }
}
