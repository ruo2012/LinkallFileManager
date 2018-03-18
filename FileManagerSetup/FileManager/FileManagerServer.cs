using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Windows.Forms;

namespace FileManager
{
    class FileManagerServer
    {
        static Thread threadWatch = null; //负责监听客户端的线程
        static Socket socketWatch = null; //负责监听客户端的套接字
        static string serverIp = "127.0.0.1"; //负责监听客户端的地址
        static string serverPort = "8978"; //负责监听客户端的端口
        public static void OpenServer()
        {
            //定义一个套接字用于监听客户端发来的信息  包含3个参数(IP4寻址协议,流式连接,TCP协议)
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //服务端发送信息 需要1个IP地址和端口号
            IPAddress ipaddress = IPAddress.Parse(serverIp); //获取文本框输入的IP地址
            //将IP地址和端口号绑定到网络节点endpoint上 
            IPEndPoint endpoint = new IPEndPoint(ipaddress, int.Parse(serverPort)); //获取文本框上输入的端口号
            //监听绑定的网络节点
            socketWatch.Bind(endpoint);
            //将套接字的监听队列长度限制为20
            socketWatch.Listen(20);
            //创建一个监听线程 
            threadWatch = new Thread(WatchConnecting);
            //将窗体线程设置为与后台同步
            threadWatch.IsBackground = true;
            //启动线程
            threadWatch.Start();
            //txtMsg.AppendText("开始监听客户端传来的信息!" + "\r\n");
        }

        //创建一个负责和客户端通信的套接字 
        static Socket socConnection = null;

        /// <summary>
        /// 监听客户端发来的请求
        /// </summary>
        private static void WatchConnecting()
        {
            while (true)  //持续不断监听客户端发来的请求
            {
                socConnection = socketWatch.Accept();
                // ("客户端连接成功" + "\r\n");
                //创建一个通信线程 
                ParameterizedThreadStart pts = new ParameterizedThreadStart(ServerRecMsg);
                Thread thr = new Thread(pts);
                thr.IsBackground = true;
                //启动线程
                thr.Start(socConnection);
            }
        }

        /// <summary>
        /// 发送信息到客户端的方法
        /// </summary>
        /// <param name="sendMsg">发送的字符串信息</param>
        private static void ServerSendMsg(string sendMsg)
        {
            //将输入的字符串转换成 机器可以识别的字节数组
            byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendMsg);
            //向客户端发送字节数组信息
            socConnection.Send(arrSendMsg);
            //将发送的字符串信息附加到文本框txtMsg上
            //txtMsg.AppendText("So-flash:" + GetCurrentTime() + "\r\n" + sendMsg + "\r\n");
        }

        /// <summary>
        /// 接收客户端发来的信息 
        /// </summary>
        /// <param name="socketClientPara">客户端套接字对象</param>
        private static void ServerRecMsg(object socketClientPara)
        {
            Socket socketServer = socketClientPara as Socket;
            while (true)
            {
                //创建一个内存缓冲区 其大小为1024*1024字节  即1M
                byte[] arrServerRecMsg = new byte[1024 * 1024];
                //将接收到的信息存入到内存缓冲区,并返回其字节数组的长度
                int length = socketServer.Receive(arrServerRecMsg);
                //将机器接受到的字节数组转换为人可以读懂的字符串
                string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);
                //将发送的字符串信息附加到文本框txtMsg上  
                //txtMsg.AppendText("天之涯:" + GetCurrentTime() + "\r\n" + strSRecMsg + "\r\n");

                //MessageBox.Show(strSRecMsg);
                if (strSRecMsg.StartsWith("ONECLIEKUPLOAD") && strSRecMsg.IndexOf("|") > 0)
                {
                    try
                    {
                        string softWareName = strSRecMsg.Split('|')[1];
                        if (CheckProject(softWareName))
                        {
                            FormShow(softWareName);
                        }

                        //Thread threadShow = new Thread(new ParameterizedThreadStart(FormShow));
                        ////将窗体线程设置为与后台同步
                        //threadShow.IsBackground = false;
                        ////启动线程
                        //threadShow.Start(softWareName);

                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        private static void FormShow(object obj)
        {
            try
            {
                //MessageBox.Show("xxxxxxxxxxxxxxxxxxxx");
                //开启上传提示
                //FrmTipUpload f = new FrmTipUpload("notepad.exe");
                //f.Activate();
                ////FrmMainSingle.MainForm.Show();
                //if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{
                //    //动态上传进度
                //    FrmFileTransferNew frmTransfer = new FrmFileTransferNew(0);

                //    //frmTransfer.FormClosing+= new System.Windows.Forms.FormClosingEventHandler(frmTransfer_FormClosing);
                //    frmTransfer.Activate();
                //    //if (frmTransfer.IsHandleCreated)
                //    frmTransfer.ShowDialog();
                //}

               //FrmMainSingle.MainForm.ShowTipUpload("notepad.exe", new EventArgs());

                FrmMainSingle.MainForm.FrmTipUpload = new FrmTipUpload();
                FrmMainSingle.MainForm.FrmTipUpload.SoftwareName = obj.ToString();
                Thread.Sleep(100);
                if (FrmMainSingle.MainForm.FrmTipUpload.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ////动态上传进度
                    //FrmFileTransferNew frmTransfer = new FrmFileTransferNew(0);
                    //frmTransfer.Activate();
                    //frmTransfer.ShowDialog();

                    FrmFileProgressBar frmTransfer = new FrmFileProgressBar(0);
                    frmTransfer.Activate();
                    frmTransfer.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        public static bool CheckProject(string softwareName)
        {
            Model.UserProjectModel curProject = null;
            Model.UserModel user = Bll.SystemBll.UserInfo;
            if (user == null || user.Projects == null || user.Projects.Count == 0)
            {
                MessageBox.Show("账号信息不正确，请联系管理员处理！");
                return false;
            }

            foreach (var item in user.Projects)
            {
                if (item.MonitoringSoftwareName == softwareName)
                {
                    curProject = item;
                    break ;
                }
            }

            if (curProject == null)
            {
                //MessageBox.Show("工程信息绑定不正确，请联系管理员处理！");
                return false;
            }
            return true;
        }

        //发送信息到客户端
        private static void btnSendMsg_Click(object sender, EventArgs e)
        {
            //调用 ServerSendMsg方法  发送信息到客户端
            //ServerSendMsg(txtSendMsg.Text.Trim());
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

        public static System.Windows.Forms.FormClosingEventHandler frmTransfer_FormClosing { get; set; }
    }
}
