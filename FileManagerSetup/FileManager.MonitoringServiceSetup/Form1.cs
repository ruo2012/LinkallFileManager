using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileManager.MonitoringServiceSetup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_serviceIntall_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_tipMsg.AppendText("服务安装开始：..." + GetCurrentTime() + "\r\n");
                string installExePath = @"c:\windows\microsoft.net\framework\v2.0.50727\InstallUtil.exe";
                if (!File.Exists(installExePath))
                {
                    textBox_tipMsg.AppendText("服务安装失败：客户端未安装.net2.0或者安装路径不正确！" + GetCurrentTime() + "\r\n");
                    return;
                }
                string serviceExePath = AppDomain.CurrentDomain.BaseDirectory + "FileManager.MonitoringService.exe";
                if (!File.Exists(serviceExePath))
                {
                    textBox_tipMsg.AppendText("服务安装失败：未能找到服务程序:FileManager.MonitoringService.exe！" + GetCurrentTime() + "\r\n");
                    return;
                }
                string cmd = installExePath + "   " + serviceExePath;
                ExcuteCmd(cmd);
                textBox_tipMsg.AppendText("服务安装成功！" + GetCurrentTime() + "\r\n");
            }
            catch (Exception ex)
            {
                textBox_tipMsg.AppendText("服务安装失败：" + ex.Message + GetCurrentTime() + "\r\n");
            }
        }

        private void button_serviceUnintall_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_tipMsg.AppendText("服务卸载开始：..." + GetCurrentTime() + "\r\n");
                string installExePath = @"c:\windows\microsoft.net\framework\v2.0.50727\InstallUtil.exe";
                if (!File.Exists(installExePath))
                {
                    textBox_tipMsg.AppendText("服务卸载失败：客户端未安装.net2.0或者安装路径不正确！" + GetCurrentTime() + "\r\n");
                    return;
                }

                string serviceExePath = AppDomain.CurrentDomain.BaseDirectory + "FileManager.MonitoringService.exe";
                if (!File.Exists(serviceExePath))
                {
                    textBox_tipMsg.AppendText("服务卸载失败：未能找到服务程序:FileManager.MonitoringService.exe！" + GetCurrentTime() + "\r\n");
                    return;
                }
                string cmd = installExePath + "  /u  " + serviceExePath;
                ExcuteCmd(cmd);

                textBox_tipMsg.AppendText("服务卸载成功！" + GetCurrentTime() + "\r\n");
            }
            catch (Exception ex)
            {
                textBox_tipMsg.AppendText("服务卸载失败：" + ex.Message + GetCurrentTime() + "\r\n");
            }
        }

        private void button_serviceOpen_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_tipMsg.AppendText("服务开启开始：..." + GetCurrentTime() + "\r\n");
                string cmd = @"net start FMMonitoringService";
                ExcuteCmd(cmd);
                textBox_tipMsg.AppendText("服务开启成功！" + GetCurrentTime() + "\r\n");
            }
            catch (Exception ex)
            {
                textBox_tipMsg.AppendText("服务开启失败：" + ex.Message + GetCurrentTime() + "\r\n");
            }
        }

        private void button_serviceClose_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_tipMsg.AppendText("服务停止开始：..." + GetCurrentTime() + "\r\n");
                string cmd = @"net stop FMMonitoringService";
                ExcuteCmd(cmd);
                textBox_tipMsg.AppendText("服务停止成功！" + GetCurrentTime() + "\r\n");
            }
            catch (Exception ex)
            {
                textBox_tipMsg.AppendText("服务停止失败：" + ex.Message + GetCurrentTime() + "\r\n");
            }
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

        /// <summary>
        /// 执行Cmd命令
        /// </summary>
        public void ExcuteCmd(string c)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();

            process.StandardInput.WriteLine(c);
            process.StandardInput.AutoFlush = true;
            process.StandardInput.WriteLine("exit");

            StreamReader reader = process.StandardOutput;//截取输出流
            string output = reader.ReadLine();//每次读取一行
            while (!reader.EndOfStream)
            {
                //PrintThrendInfo(output);
                output = reader.ReadLine();
            }

            process.WaitForExit();
        }
    }
}
