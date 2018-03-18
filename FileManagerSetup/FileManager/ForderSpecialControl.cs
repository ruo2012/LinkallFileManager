using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;
using System.Threading;
using FileManager.Common;

namespace FileManager
{
    public class ForderSpecialControl
    {
        /// <summary>
        /// 对于.D  .M  的文件夹如”MGA:沃氏物.M”，”201604080000014.D”文件夹，以整个文件夹的形式进行备份。文件夹中有任意文件修改，对整个文件夹进行备份。之前版本作为历史版本存储
        /// </summary>
        private static List<string> specialChar = new List<string>() { "M", "D" };

        /// <summary>
        /// 是否特殊文件夹
        /// </summary>
        /// <param name="forderPath"></param>
        /// <returns></returns>
        public static bool IsSpecialForder(DirectoryInfo dirInfo)
        {
            if (dirInfo.Exists)
            {
                string dirName = dirInfo.Name;
                if (dirName.ToUpper().EndsWith(".M") || dirName.ToUpper().EndsWith(".D"))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsSpecialForder(string dirName)
        {
            if (dirName.ToUpper().EndsWith(".M") || dirName.ToUpper().EndsWith(".D"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 压缩特殊文件夹
        /// </summary>
        /// <param name="forderPath"></param>
        /// <returns></returns>
        public static bool ZipSpecialForder(DirectoryInfo dirInfo)
        {
            if (dirInfo.Exists)
            {
                string zipFile = Path.Combine(dirInfo.Parent.FullName, dirInfo.Name + ".ztlj");
                FileInfo file = new FileInfo(zipFile);
                if (file.Exists)
                {
                    file.Delete();
                }

                Thread.Sleep(100);

                try
                {
                    ZipFloClass Zc = new ZipFloClass();
                    Zc.ZipFile(dirInfo.FullName, zipFile);
                    return true;
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
                    return false;
                }
            }

            return false;
        }
    }

    public class ZipFloClass
    {
        public void ZipFile(string strFile, string strZip)
        {
            if (strFile[strFile.Length - 1] != Path.DirectorySeparatorChar)
                strFile += Path.DirectorySeparatorChar;
            ZipOutputStream s = new ZipOutputStream(File.Create(strZip));
            s.SetLevel(6); // 0 - store only to 9 - means best compression
            zip(strFile, s, strFile);
            s.Finish();
            s.Close();
        }

        private void zip(string strFile, ZipOutputStream s, string staticFile)
        {
            if (strFile[strFile.Length - 1] != Path.DirectorySeparatorChar) strFile += Path.DirectorySeparatorChar;
            Crc32 crc = new Crc32();
            string[] filenames = Directory.GetFileSystemEntries(strFile);
            foreach (string file in filenames)
            {

                if (Directory.Exists(file))
                {
                    zip(file, s, staticFile);
                }

                else // 否则直接压缩文件
                {
                    //打开压缩文件
                    FileStream fs = File.OpenRead(file);

                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    string tempfile = file.Substring(staticFile.LastIndexOf("\\") + 1);
                    ZipEntry entry = new ZipEntry(tempfile);

                    entry.DateTime = DateTime.Now;
                    entry.Size = fs.Length;
                    fs.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    s.PutNextEntry(entry);

                    s.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }

    public class UnZipFloClass
    {
        public string unZipFile(string TargetFile, string fileDir)
        {
            string rootFile = " ";
            try
            {
                //读取压缩文件(zip文件),准备解压缩
                ZipInputStream s = new ZipInputStream(File.OpenRead(TargetFile.Trim()));
                ZipEntry theEntry;
                string path = fileDir;
                //解压出来的文件保存的路径

                string rootDir = " ";
                //根目录下的第一个子文件夹的名称
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    rootDir = Path.GetDirectoryName(theEntry.Name);
                    //得到根目录下的第一级子文件夹的名称
                    if (rootDir.IndexOf("\\") >= 0)
                    {
                        rootDir = rootDir.Substring(0, rootDir.IndexOf("\\") + 1);
                    }
                    string dir = Path.GetDirectoryName(theEntry.Name);
                    //根目录下的第一级子文件夹的下的文件夹的名称
                    string fileName = Path.GetFileName(theEntry.Name);
                    //根目录下的文件名称
                    if (dir != " ")
                    //创建根目录下的子文件夹,不限制级别
                    {
                        if (!Directory.Exists(fileDir + "\\" + dir))
                        {
                            path = fileDir + "\\" + dir;
                            //在指定的路径创建文件夹
                            Directory.CreateDirectory(path);
                        }
                    }
                    else if (dir == " " && fileName != "")
                    //根目录下的文件
                    {
                        path = fileDir;
                        rootFile = fileName;
                    }
                    else if (dir != " " && fileName != "")
                    //根目录下的第一级子文件夹下的文件
                    {
                        if (dir.IndexOf("\\") > 0)
                        //指定文件保存的路径
                        {
                            path = fileDir + "\\" + dir;
                        }
                    }

                    if (dir == rootDir)
                    //判断是不是需要保存在根目录下的文件
                    {
                        path = fileDir + "\\" + rootDir;
                    }

                    //以下为解压缩zip文件的基本步骤
                    //基本思路就是遍历压缩文件里的所有文件,创建一个相同的文件。
                    if (fileName != String.Empty)
                    {
                        FileStream streamWriter = File.Create(path + "\\" + fileName);

                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }

                        streamWriter.Close();
                    }
                }
                s.Close();

                return rootFile;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
                return "1; " + ex.Message;
            }
        }

        public static void UnzipFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (file.Exists && file.Extension.ToLower() == ".ztlj")
                {
                    string forderName = file.Name.Substring(0, file.Name.Length - 5);
                    string forderPath = Path.Combine(file.Directory.FullName, forderName);
                    if (Directory.Exists(forderPath))
                    {
                        Directory.Delete(forderPath, true);
                    }

                    Directory.CreateDirectory(forderPath);
                    UnZipFloClass unzip = new UnZipFloClass();
                    unzip.unZipFile(filePath, forderPath);

                    System.Threading.Thread.Sleep(100);
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                FileManager.Common.LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
            }
        }
    }
}
