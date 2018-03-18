using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using CCWin.Win32;

namespace FileManager
{
    /// <summary>
    /// 获取系统文件图标
    /// </summary>
    public class GetSystemIcon
    {
        /// <summary>
        /// 依据文件名读取图标，若指定文件不存在，则返回空值。
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Icon GetIconByFileName(string fileName)
        {
            if (fileName == null || fileName.Equals(string.Empty)) return null;
            if (!File.Exists(fileName)) return null;

            SHFILEINFO shinfo = new SHFILEINFO();
            //Use this to get the small Icon
            Win32.SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);
            //The icon is returned in the hIcon member of the shinfo struct
            System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
            return myIcon;
        }

        /// <summary>
        /// 给出文件扩展名（.*），返回相应图标
        /// 若不以"."开头则返回文件夹的图标。
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="isLarge"></param>
        /// <returns></returns>
        public static Icon GetIconByFileType(string fileType, bool isLarge)
        {
            if (fileType == null || fileType.Equals(string.Empty)) return null;

            RegistryKey regVersion = null;
            string regFileType = null;
            string regIconString = null;
            string systemDirectory = Environment.SystemDirectory + "\\";

            if (fileType[0] == '.')
            {
                //读系统注册表中文件类型信息
                regVersion = Registry.ClassesRoot.OpenSubKey(fileType, true);
                if (regVersion != null)
                {
                    regFileType = regVersion.GetValue("") as string;
                    regVersion.Close();
                    regVersion = Registry.ClassesRoot.OpenSubKey(regFileType + @"\DefaultIcon", true);
                    if (regVersion != null)
                    {
                        regIconString = regVersion.GetValue("") as string;
                        regVersion.Close();
                    }
                }
                if (regIconString == null)
                {
                    //没有读取到文件类型注册信息，指定为未知文件类型的图标
                    regIconString = systemDirectory + "shell32.dll,0";
                }
            }
            else
            {
                //直接指定为文件夹图标
                regIconString = systemDirectory + "shell32.dll,3";
            }
            string[] fileIcon = regIconString.Split(new char[] { ',' });
            if (fileIcon.Length != 2)
            {
                //系统注册表中注册的标图不能直接提取，则返回可执行文件的通用图标
                fileIcon = new string[] { systemDirectory + "shell32.dll", "2" };
            }
            Icon resultIcon = null;
            try
            {
                //调用API方法读取图标
                int[] phiconLarge = new int[1];
                int[] phiconSmall = new int[1];
                uint count = Win32.ExtractIconEx(fileIcon[0], Int32.Parse(fileIcon[1]), phiconLarge, phiconSmall, 1);
                IntPtr IconHnd = new IntPtr(isLarge ? phiconLarge[0] : phiconSmall[0]);
                resultIcon = Icon.FromHandle(IconHnd);
            }
            catch(Exception ex)
            {

            }
            return resultIcon;
        }

        /// <summary>  
        /// 通过扩展名得到图标和描述  
        /// </summary>  
        /// <param name="ext">扩展名(如“.txt”)</param>  
        /// <param name="largeIcon">得到大图标</param>  
        /// <param name="smallIcon">得到小图标</param>  
        /// <param name="description">得到类型描述或者空字符串</param>  
        public static void GetExtsIconAndDescription(string ext, out Icon largeIcon, out Icon smallIcon, out string description)
        {
            GetDefaultIcon(out largeIcon, out smallIcon);   //得到缺省图标  
            description = "";                               //缺省类型描述  
            RegistryKey extsubkey = Registry.ClassesRoot.OpenSubKey(ext);   //从注册表中读取扩展名相应的子键  
            if (extsubkey == null) return;

            string extdefaultvalue = extsubkey.GetValue(null) as string;     //取出扩展名对应的文件类型名称  
            if (extdefaultvalue == null) return;

            if (extdefaultvalue.Equals("exefile", StringComparison.OrdinalIgnoreCase))  //扩展名类型是可执行文件  
            {
                RegistryKey exefilesubkey = Registry.ClassesRoot.OpenSubKey(extdefaultvalue);  //从注册表中读取文件类型名称的相应子键  
                if (exefilesubkey != null)
                {
                    string exefiledescription = exefilesubkey.GetValue(null) as string;   //得到exefile描述字符串  
                    if (exefiledescription != null) description = exefiledescription;
                }
                System.IntPtr exefilePhiconLarge = new IntPtr();
                System.IntPtr exefilePhiconSmall = new IntPtr();
                NativeMethods.ExtractIconExW(Path.Combine(Environment.SystemDirectory, "shell32.dll"), 2, ref exefilePhiconLarge, ref exefilePhiconSmall, 1);
                if (exefilePhiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(exefilePhiconLarge);
                if (exefilePhiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(exefilePhiconSmall);
                return;
            }

            RegistryKey typesubkey = Registry.ClassesRoot.OpenSubKey(extdefaultvalue);  //从注册表中读取文件类型名称的相应子键  
            if (typesubkey == null) return;

            string typedescription = typesubkey.GetValue(null) as string;   //得到类型描述字符串  
            if (typedescription != null) description = typedescription;

            RegistryKey defaulticonsubkey = typesubkey.OpenSubKey("DefaultIcon");  //取默认图标子键  
            if (defaulticonsubkey == null) return;

            //得到图标来源字符串  
            string defaulticon = defaulticonsubkey.GetValue(null) as string; //取出默认图标来源字符串  
            if (defaulticon == null) return;
            string[] iconstringArray = defaulticon.Split(',');
            int nIconIndex = 0; //声明并初始化图标索引  
            if (iconstringArray.Length > 1)
                if (!int.TryParse(iconstringArray[1], out nIconIndex))
                    nIconIndex = 0;     //int.TryParse转换失败，返回0  

            //得到图标  
            System.IntPtr phiconLarge = new IntPtr();
            System.IntPtr phiconSmall = new IntPtr();
            NativeMethods.ExtractIconExW(iconstringArray[0].Trim('"'), nIconIndex, ref phiconLarge, ref phiconSmall, 1);
            if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
            if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
        }

        /// <summary>  
        /// 获取缺省图标  
        /// </summary>  
        /// <param name="largeIcon"></param>  
        /// <param name="smallIcon"></param>  
        private static void GetDefaultIcon(out Icon largeIcon, out Icon smallIcon)
        {
            largeIcon = smallIcon = null;
            System.IntPtr phiconLarge = new IntPtr();
            System.IntPtr phiconSmall = new IntPtr();
            NativeMethods.ExtractIconExW(Path.Combine(Environment.SystemDirectory, "shell32.dll"), 0, ref phiconLarge, ref phiconSmall, 1);
            if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
            if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct HICON__
        {
            /// int   
            public int unused;
        }

        public partial class NativeMethods
        {
            /// Return Type: UINT->unsigned int   
            ///lpszFile: LPCWSTR->WCHAR*   
            ///nIconIndex: int   
            ///phiconLarge: HICON*   
            ///phiconSmall: HICON*   
            ///nIcons: UINT->unsigned int   
            [System.Runtime.InteropServices.DllImportAttribute("shell32.dll", EntryPoint = "ExtractIconExW", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
            public static extern uint ExtractIconExW([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lpszFile, int nIconIndex, ref System.IntPtr phiconLarge, ref System.IntPtr phiconSmall, uint nIcons);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public IntPtr iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };

    /// <summary>
    /// 定义调用的API方法
    /// </summary>
    class Win32
    {
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
        public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
        [DllImport("shell32.dll")]
        public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, int[] phiconLarge, int[] phiconSmall, uint nIcons);

    }
}
