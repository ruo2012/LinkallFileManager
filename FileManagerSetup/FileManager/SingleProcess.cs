using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace FileManager
{
    static public class SingleProcess
    {
        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历正在有相同名字运行的例程    
            foreach (Process process in processes)
            {
                //忽略现有的例程      
                if (process.Id != current.Id)
                {
                    //确保例程从EXE文件运行        
                    //if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    if (process.MainModule.FileName == current.MainModule.FileName)
                    {
                        //返回另一个例程实例          
                        return process;
                    }
                }
            }
            //没有其它的例程，返回Null    
            return null;
        }

        /// <summary> 
        /// 该函数设置由不同线程产生的窗口的显示状态。 (没用)
        /// </summary> 
        /// <param name="hWnd">窗口句柄</param> 
        /// <param name="cmdShow">指定窗口如何显示。查看允许值列表，请查阅ShowWlndow函数的说明部分。</param> 
        /// <returns>如果函数原来可见，返回值为非零；如果函数原来被隐藏，返回值为零。</returns> 
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        /// <summary> 
        /// 该函数将创建指定窗口的线程设置到前台，并且激活该窗口。
        /// 键盘输入转向该窗口，并为用户改各种可视的记号。系统给创建前台窗口的线程分配的权限稍高于其他线程。 
        /// (没用)
        /// </summary> 
        /// <param name="hWnd">将被激活并被调入前台的窗口句柄。</param> 
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零。</returns> 
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int WS_SHOWNORMAL = 1;

        /// <summary>
        /// 发送消息给窗体(没用)
        /// </summary> 
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_PROCESSISRUNNING = 0x0400 + 101;

        /// <summary>
        /// 查找标题为XX的第一个窗体(没用)
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// 窗体焦点
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="fAltTab"></param>
        [DllImport("user32.dll ", SetLastError = true)]
        private static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        /// <summary>
        /// 显示窗体,同  ShowWindowAsync 差不多
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        private const int SW_RESTORE = 9;

        /// <summary>
        /// 枚举窗体
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DllImport("user32")]
        private static extern int EnumWindows(CallBack x, int y);
        private delegate bool CallBack(IntPtr hwnd, int lParam);

        /// <summary>
        /// 根据窗体句柄获得其进程ID
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);




        /// <summary>
        /// 根据窗体句柄获得窗体标题
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpText"></param>
        /// <param name="nCount"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpText, int nCount);

        /// <summary>
        /// 修改位置、大小
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hWndInsertAfter"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="uFlags"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        /// <summary>
        ///     Retains the current size (ignores the cx and cy parameters).
        /// </summary>
        static uint SWP_NOSIZE = 0x0001;
        static int HWND_TOP = 0;
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out  Rect lpRect);
        /// <summary> 
        /// 根据进程，显示其主窗体
        /// </summary> 
        public static void HandleRunningInstance(Process instance)
        {

            ShowWindow(instance.MainWindowHandle, SW_RESTORE);
            SwitchToThisWindow(instance.MainWindowHandle, true);  //比SetForegroundWindow好用

            Rect windowRec;
            GetWindowRect(instance.MainWindowHandle, out windowRec);
            System.Drawing.Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;
            SetWindowPos(instance.MainWindowHandle, HWND_TOP, (rect.Width - (windowRec.Right - windowRec.Left)) / 2,
                (rect.Height - (windowRec.Bottom - windowRec.Top)) / 2, 0, 0, SWP_NOSIZE);
        }


        private static bool Report(IntPtr hwnd, int lParam)
        {
            //获得窗体标题
            StringBuilder sb = new StringBuilder(100);
            GetWindowText(hwnd, sb, sb.Capacity);

            int calcID;
            //获取进程ID   
            GetWindowThreadProcessId(hwnd, out calcID);
            for (int i = 0; i < formName.Length; i++)
            {
                //if ((sb.ToString() == formName[i]) && (pro != null) && (calcID == pro.Id)) //标题栏、进程id符合
                if ((sb.ToString().StartsWith( formName[i])) && (pro != null) && (calcID == pro.Id)) //标题栏、进程id符合
                {                    
                    ShowWindow(hwnd, SW_RESTORE);
                    SwitchToThisWindow(hwnd, true);
                  
                    Rect windowRec;
                    GetWindowRect(hwnd, out windowRec);
                    System.Drawing.Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;
                    SetWindowPos(hwnd, HWND_TOP, (rect.Width - (windowRec.Right - windowRec.Left)) / 2,
                        (rect.Height - (windowRec.Bottom - windowRec.Top)) / 2, 0, 0, SWP_NOSIZE);
                    return true;
                }
            }
            //else
            return true;


        }
        private static string[] formName;// = string.Empty;
        private static Process pro = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public static void Singling(params string[] str)
        {
            formName = str;
            Process instance = RunningInstance();
            if (instance != null)   //首先确定有无进程
            {
                pro = instance;
                if (pro.MainWindowHandle.ToInt32() != 0) //是否托盘化
                {
                    HandleRunningInstance(pro);
                }
                else
                {                  
                    CallBack myCallBack = new CallBack(Report);
                    EnumWindows(myCallBack, 0);
                }
                System.Environment.Exit(System.Environment.ExitCode);               
            }
           
        }
    }
}
