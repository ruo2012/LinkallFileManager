using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;
using FileManager.BLL;
using FileManager.Model;
using FileManager.Bll;
using System.IO;

namespace FileManager
{
    public class FileTmpFileHelper
    {
        /// <summary>
        /// 获取临时文件夹
        /// </summary>
        /// <returns></returns>
        public static string GetTmpDir()
        {
            //string path = string.Format("{0}/Tmp", System.Environment.CurrentDirectory);
            string path = string.Format("{0}/Tmp",  System.AppDomain.CurrentDomain.BaseDirectory);
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    DirectoryInfo baseDirInfo = new DirectoryInfo(path);
                    var subDirs = baseDirInfo.GetDirectories();
                    foreach (var item in subDirs)
                    {

                        try
                        {
                            if (item.LastWriteTime < DateTime.Now.AddDays(-1))
                            {
                                item.Delete(true);
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

                string guid = Guid.NewGuid().ToString();
                string newPath = string.Format("{0}/{1}", path, guid);
                Directory.CreateDirectory(newPath);

                return newPath;
            }
            catch (Exception ex)
            {
                return path;
            }
        }
    }
}
