using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FileManager.BLL;
using Microsoft.Win32;
using System.Data;
using FileManager.Common;
using FileManager.DAL;

namespace FileManager
{
    public class FileWinexploer
    {
        #region 对外接口
        /// <summary>
        /// 通过扩展名得到描述
        /// </summary>
        /// <param name="ext">扩展名，如.jpg</param>
        /// <param name="description">返回描述</param>
        public void GetExtsDescription(string ext, out string description)
        {
            description = "";

            //从注册表中读取扩展名相应的子键  
            RegistryKey extsubkey = Registry.ClassesRoot.OpenSubKey(ext);
            if (extsubkey == null)  //没有找到
            {
                //如果没有找到，那就是这种类型
                description = ext.ToUpper().Substring(1) + "文件";
                return;
            }

            //取出扩展名对应的文件类型名称  
            string extdefaultvalue = extsubkey.GetValue(null) as string;
            if (extdefaultvalue == null)
            {
                return;
            }

            //扩展名类型是可执行文件
            if (extdefaultvalue.Equals("exefile", StringComparison.InvariantCultureIgnoreCase))
            {
                //从注册表中读取文件类型名称的相应子键  
                RegistryKey exefilesubkey = Registry.ClassesRoot.OpenSubKey(extdefaultvalue);
                if (exefilesubkey != null)  //如果不为空
                {
                    string exefiledescription = exefilesubkey.GetValue(null) as string;   //得到exefile描述字符串  
                    if (exefiledescription != null)
                    {
                        description = exefiledescription;
                    }
                }
                return;
            }

            //从注册表中读取文件类型名称的相应子键  
            RegistryKey typesubkey = Registry.ClassesRoot.OpenSubKey(extdefaultvalue);
            if (typesubkey == null)
            {
                return;
            }

            //得到类型描述字符串  
            string typedescription = typesubkey.GetValue(null) as string;
            if (typedescription != null)
            {
                description = typedescription;
            }
        }

        private string tempImgFilePath;

        #region 暂时删除
        ///// <summary>
        ///// 根据文件名称得到图片：包括文件和文件夹
        ///// </summary>
        ///// <param name="fileName">Name of an existing File or Directory</param>
        ///// <returns>图片的索引</returns>
        //private Byte[] GetIcon(string fileName)
        //{
        //    SHFILEINFO shinfo = new SHFILEINFO();
        //    FileInfo info = new FileInfo(fileName);
        //    string ext = info.Extension; //文件的后缀名 .jpg

        //    if (string.IsNullOrEmpty(ext)) //文件夹 或者没有相关联的后缀名
        //    {
        //        if ((info.Attributes & FileAttributes.Directory) != 0) //文件夹
        //        {
        //            ext = "5EEB255733234c4dBECF9A128E896A1E"; // for directories
        //        }
        //        else
        //        {
        //            ext = "F9EB930C78D2477c80A51945D505E9C4"; // for files without extension
        //        }
        //    }
        //    else  //文件
        //    {
        //        //如果是exe文件或者快捷方式
        //        if (ext.Equals(".exe", StringComparison.InvariantCultureIgnoreCase) ||
        //            ext.Equals(".lnk", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            ext = info.Name;
        //        }
        //    }

        //    //看是否存在于imageList中
        //    if (_smallImageList.Images.ContainsKey(ext))
        //    {
        //        return GetFileImg(_smallImageList.Images[ext], ref tempImgFilePath);
        //    }
        //    else  //如果不存在就添加
        //    {
        //        SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);

        //        Icon smallIcon;
        //        try
        //        {
        //            smallIcon = Icon.FromHandle(shinfo.hIcon);
        //        }
        //        catch (ArgumentException ex)
        //        {
        //            throw new ArgumentException(String.Format("File \"{0}\" doesn not exist!", fileName), ex);
        //        }
        //        _smallImageList.Images.Add(ext, smallIcon); //添加小图标

        //        //大图标
        //        SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);

        //        Icon largeIcon = Icon.FromHandle(shinfo.hIcon);
        //        _largeImageList.Images.Add(ext, largeIcon);

        //        //return _smallImageList.Images.Count - 1;
        //        return ImageToBytes(largeIcon);
        //    }
        //}
        #endregion

        /// <summary>
        /// 根据文件路径返回文件ico
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Byte[] GetIcon(string fileName)
        {
            Icon largeIcon = GetSystemIcon.GetIconByFileName(fileName);
            return ImageToBytes(largeIcon);
        }
        #endregion

        #region 文件上传到服务器操作

        /// <summary>
        /// 点击一键上传文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FolderUploadToDb(string forderPath, FileManager.Model.UserModel user)
        {
            try
            {
                //string dirPath = @"E:\C#WINFORM_2015\私单资料准备\FileManager_TestUpload";
                string dirPath = forderPath;
                if (!Directory.Exists(dirPath))
                {
                    MessageBox.Show("服务器配置路径不正确，请联系管理员处理！");
                    return;
                }

                notSuccessFiles.Clear();
                //此处查询出所有文件内容
                DirectoryInfo rootDirInfo = new DirectoryInfo(dirPath);
                FolderUploadAllToDb(rootDirInfo, 0, user.UserName, user.CurProject.ID);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
                throw ex;
            }
        }

        /// <summary>
        /// 递归上传文件夹和文件
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <param name="parentId"></param>
        /// <param name="user"></param>
        private void FolderUploadAllToDb(DirectoryInfo dirInfo, int parentId, string userName, int projectId)
        {
            //文件夹单个上传
            int curForderId = ForderUploadToDb(dirInfo, parentId, userName, projectId);

            try
            {
                var files = dirInfo.GetFiles();
                //文件上传
                foreach (var item in files)
                {
                    if ((item.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)   //必须进行与运算，因为默认文件是“Hidden”+归档（二进制11）。而Hidden是10.因此与运算才可以判断
                    {
                        continue;
                    }
                    //判断文件夹操作
                    Model.FileModel fCache;
                    if (needAddOrMordifyFiles.TryGetValue(item.FullName, out fCache))
                    {
                        int retResult = FileUploadToDb(item, curForderId, userName, projectId);

                        //修改为完成状态
                        fCache.ActionNum = retResult > 0 ? 10 : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
                notSuccessFiles.Add("子文件集合：" + dirInfo.FullName, dirInfo.FullName);
            }

            try
            {
                var suvDirs = dirInfo.GetDirectories();
                if (suvDirs != null && suvDirs.Length > 0)
                {
                    foreach (var item in suvDirs)
                    {
                        if ((item.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)   //必须进行与运算，因为默认文件是“Hidden”+归档（二进制11）。而Hidden是10.因此与运算才可以判断
                        {
                            continue;
                        }
                        //判断文件夹操作
                        //Model.ForderModel  fo = currentForders[item.FullName];
                        FolderUploadAllToDb(item, curForderId, userName, projectId);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
                notSuccessFiles.Add("子文件夹：" + dirInfo.FullName, dirInfo.FullName);
            }
        }

        /// <summary>
        /// 单个文件夹上传
        /// </summary>
        /// <param name="item"></param>
        private int ForderUploadToDb(DirectoryInfo item, int parentId, string userName, int projectId)
        {
            ///构建对象数据上传到数据库
            ForderBll forderBll = new ForderBll();

            ///上传之前判断是否已经存在
            int retId = forderBll.GetForderId(parentId, item.Name, userName, projectId);
            if (retId > 0)
            {
                //文件夹已经存在，修改文件为未删除状态
                forderBll.UpdateField(retId, " isdeleted = 0");
                return retId;
            }

            FileManager.Model.ForderModel forderModel = new FileManager.Model.ForderModel();
            forderModel.Add_Time = DateTime.Now;
            forderModel.Title = item.Name;
            forderModel.Call_Index = "";
            forderModel.Parent_Id = parentId;
            forderModel.Forder_Modify_Time = item.LastAccessTime.Ticks;
            forderModel.Project_Id = projectId;
            forderModel.ClientPath = item.FullName;
            forderModel.UserName = userName;

            return forderBll.Add(forderModel);
        }

        /// <summary>
        /// 单个文件上传
        /// </summary>
        /// <param name="item"></param>
        private int FileUploadToDb(FileInfo item, int forderId, string userName, int projectId)
        {
            try
            {
                //string md5 = GetMD5HashFromFile(item.FullName);
                string md5 = "";

                //上传文件之前判断文件是否已经存在
                FileBll fileBll = new FileBll();
                int fileID = fileBll.GetFileID(forderId, item.Name, md5);
                FileVersionBll fVerBll = new FileVersionBll();

                //读取数据流为二进制
                byte[] verbytes = null;
                //FileStream streamVer = item.OpenRead();
                //byte[] verbytes = new byte[item.Length];
                //streamVer.Read(verbytes, 0, (int)item.Length);
                //streamVer.Close();

                using (FileStream streamVer = item.OpenRead())
                {
                    verbytes = new byte[item.Length];
                    streamVer.Read(verbytes, 0, (int)item.Length);
                    streamVer.Close();
                }

                // 文件大小判断
                if (verbytes == null || verbytes.Length > 100 * 1024 * 1024)
                {
                    notSuccessFiles.Add(item.FullName, item.FullName);
                    return 1;
                }

                FileManager.Model.FileModel fileModel = new FileManager.Model.FileModel();

                // 用户信息
                Model.UserModel UserInfo = FileManager.Bll.SystemBll.UserInfo;
                //文件信息不存在，则新建一个
                if (fileID <= 0)
                {
                    // 构建对象数据上传到数据库
                    fileModel.Add_Time = DateTime.Now;
                    fileModel.File_Name = item.Name;
                    fileModel.File_Type = "file";
                    fileModel.File_DirId = forderId;
                    fileModel.File_LastVersion = CreateFileVer(item.Name, forderId);
                    fileModel.UserId = UserInfo.ID;
                    fileModel.UserName = UserInfo.UserName;
                    fileModel.File_Modify_Time = item.LastAccessTime.Ticks;
                    fileModel.File_Size = verbytes.Length;
                    fileModel.Project_Id = projectId;
                    fileModel.File_Ext = item.Extension;
                    fileModel.ClientPath = item.FullName;
                    fileID = fileBll.Add(fileModel);
                    fileModel.ID = fileID;
                }

                ///构建版本对象数据上传到数据库
                FileManager.Model.FileVersion fileVerModel = new FileManager.Model.FileVersion();
                fileVerModel.Add_Time = item.LastAccessTime;
                fileVerModel.File_Modify_Time = item.LastWriteTime.Ticks;
                fileVerModel.Content = verbytes;
                fileVerModel.File_Md5 = md5;
                fileVerModel.File_SmallImage = null;
                fileVerModel.File_Type = "file";
                fileVerModel.UserID = UserInfo.ID;
                fileVerModel.UserName = UserInfo.UserName;
                fileVerModel.File_Size = verbytes.Length;
                fileVerModel.File_Ext = item.Extension;
                fileVerModel.ClientPath = item.FullName;
                fileVerModel.UserName = userName;
                fileVerModel.Ip = Bll.SystemBll.CurrentUserIp;
                fileVerModel.ComputerName = Bll.SystemBll.CurrentComputerName;

                if (fileID > 0)
                {
                    //判断是否需要创建版本
                    int curVer = fileBll.GetFileLastVer(fileID, item.LastWriteTime);

                    //如果文件已经存在相同文件的版本，则忽略上传
                    if (curVer > 0) return fileID;

                    //获取文件版本
                    int fileVer = CreateFileVer(item.Name, forderId);
                    fileVerModel.Ver = fileVer;
                    fileVerModel.ActionNum = 2;
                    fileVerModel.File_Id = fileID;
                    //创建版本
                    int retVer = fVerBll.Add(fileVerModel);

                    fileVerModel.Ver = fileVer;
                    fileVerModel.ID = retVer;
                    // 异步日志
                    FileLogHelper.FileLog(fileVerModel, fileModel, Model.ActionType.ONEUPLOAD);

                    //文件如果存在，首先修改文件为非删除状态修改文件最新时间和最新版本
                    fileBll.UpdateFile(fileID, string.Format(" isdeleted = 0,File_LastVersion ={0},File_Modify_Time='{1}' ", fileVer, item.LastAccessTime.ToString()));
                }
                else
                {
                    //文件不存在，创建版本 
                    fileVerModel.Ver = 1;
                    fileVerModel.ActionNum = 1;
                    fileVerModel.File_Id = fileID;

                    //创建版本
                    int retVer = fVerBll.Add(fileVerModel);

                    fileVerModel.Ver = retVer;
                    // 异步日志
                    FileLogHelper.FileLog(fileVerModel, fileModel, Model.ActionType.ONEUPLOAD);

                    //文件如果存在，首先修改文件为非删除状态修改文件最新时间和最新版本
                    fileBll.UpdateFile(fileID, string.Format(" isdeleted = 0,File_LastVersion ={0},File_Modify_Time='{1}' ", 1, item.LastAccessTime.ToString()));
                }

                if (item.Exists && item.Extension.ToLower() == ".ztlj")
                {
                    item.Delete();
                }

                return fileID;
            }
            catch (Exception ex)
            {
                notSuccessFiles.Add(item.FullName, item.FullName);
                LogHelper.WriteLog("上传文件出现异常", ex);
                return  1;
            }
            finally
            {
            }
        }

        /// <summary>
        /// 创建新文件版本
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="forderId"></param>
        /// <returns></returns>
        private int CreateFileVer(string fileName, int forderId)
        {
            FileBll fileBll = new FileBll();
            int newVer = fileBll.GetFileLastVer(fileName, forderId) + 1;

            ///创建文件上传日志
            return newVer;
        }

        #endregion

        #region 文件对比信息缓存

        /// <summary>
        /// 上传文件缓存
        /// </summary>
        public static Dictionary<string, string> notSuccessFiles = new Dictionary<string, string>();

        /// <summary>
        /// 上传文件缓存
        /// </summary>
        public static Dictionary<string, string> NotSuccessFiles
        {
            get { return FileWinexploer.notSuccessFiles; }
        }


        /// <summary>
        /// 上传文件缓存
        /// </summary>
        public static Dictionary<string, Model.FileModel> needAddOrMordifyFiles = new Dictionary<string, Model.FileModel>();

        /// <summary>
        /// 上传文件缓存
        /// </summary>
        public static Dictionary<string, Model.FileModel> NeedAddOrMordifyFiles
        {
            get { return FileWinexploer.needAddOrMordifyFiles; }
        }

        public static Dictionary<string, Model.FileModel> needAllUploadFiles = new Dictionary<string, Model.FileModel>();

        /// <summary>
        /// 本地最新文件【上传】
        /// </summary>
        public static Dictionary<string, Model.FileModel> NeedAllUploadFiles
        {
            get { return FileWinexploer.needAllUploadFiles; }
        }
        public static Dictionary<string, Model.FileModel> needAllDownloadFiles = new Dictionary<string, Model.FileModel>();

        /// <summary>
        /// 服务器最新文件【下载】
        /// </summary>
        public static Dictionary<string, Model.FileModel> NeedAllDownloadFiles
        {
            get { return FileWinexploer.needAllDownloadFiles; }
        }

        private static void ClearCache()
        {
            needAllDownloadFiles.Clear();
            needAllUploadFiles.Clear();
            needAddOrMordifyFiles.Clear();
        }
        #endregion

        #region 文件上传到服务器操作检查

        /// <summary>
        /// 获取缓存数量
        /// </summary>
        /// <returns></returns>
        public static int GetLeftToActionNum()
        {
            int retNum = 0;
            if (needAddOrMordifyFiles == null || needAddOrMordifyFiles.Count == 0) return retNum;

            foreach (var item in needAddOrMordifyFiles)
            {
                if (item.Value.ActionNum != 10)
                {
                    retNum += 1;
                }
            }
            return retNum;
        }

        /// <summary>
        /// 缓存锁
        /// </summary>
        private static object _lockToActionFile = new object();

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="file"></param>
        public static void AddFileToCache(string key, Model.FileModel file)
        {
            lock (_lockToActionFile)
            {
                if (!needAddOrMordifyFiles.ContainsKey(key))
                {
                    needAddOrMordifyFiles.Add(key, file);
                }
            }
        }

        public static void AddNeedAllUploadFilesToCache(string key, Model.FileModel file)
        {
            lock (_lockToActionFile)
            {
                if (!needAllUploadFiles.ContainsKey(key))
                {
                    needAllUploadFiles.Add(key, file);
                }
            }
        }

        public static void AddNeedAllDownloadFilesToCache(string key, Model.FileModel file)
        {
            lock (_lockToActionFile)
            {
                if (!needAllDownloadFiles.ContainsKey(key))
                {
                    needAllDownloadFiles.Add(key, file);
                }
            }
        }

        /// <summary>
        /// 数据库连接
        /// </summary>
        private System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection();

        /// <summary>
        /// 数据库执行命令
        /// </summary>
        private System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

        /// <summary>
        /// 点击一键上传之前检查文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckFolderUploadToDb(string forderPath, FileManager.Model.UserModel user)
        {
            try
            {
                string dirPath = forderPath;
                if (!Directory.Exists(dirPath))
                {
                    MessageBox.Show("服务器配置路径不正确，请联系管理员处理！");
                    return;
                }

                //needAddOrMordifyFiles.Clear();
                ClearCache();

                // 获取配置信息
                Model.SystemConfig config = SystemConfigBll.GetConfig();

                // 设置数据库连接
                string conn = string.Format("server={0};uid={1};pwd={2};database={3};", config.DbAddress, config.DbUser, config.DbPassword, config.DbName);
                // 打开连接
                using (connection = new System.Data.SqlClient.SqlConnection(conn))
                {
                    // 此处查询出所有文件内容
                    DirectoryInfo rootDirInfo = new DirectoryInfo(dirPath);
                    CheckFolderUploadAllToDb(rootDirInfo, 0, user.UserName, user.CurProject.ID);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 递归检查文件夹和文件
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <param name="parentId"></param>
        /// <param name="user"></param>
        private void CheckFolderUploadAllToDb(DirectoryInfo dirInfo, int parentId, string userName, int projectId)
        {
            // 构建对象数据上传到数据库
            ForderDalEx forderDal = new ForderDalEx("FM_");
            // 上传之前判断是否已经存在
            int curForderId = forderDal.GetForderId(this.connection, parentId, dirInfo.Name, userName, projectId);

            if (curForderId < 0)
            {
                //文件夹不存在，全部新增
                List<Model.FileModel> fileLists = GetAllFiles(dirInfo);
                foreach (var item in fileLists)
                {
                    AddFileToCache(item.ClientPath, item);
                    AddNeedAllUploadFilesToCache(item.ClientPath, item);
                }
                return;
            }

            var files = dirInfo.GetFiles();
            //文件上传
            foreach (var item in files)
            {
                if ((item.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)   //必须进行与运算，因为默认文件是“Hidden”+归档（二进制11）。而Hidden是10.因此与运算才可以判断
                {
                    continue;
                }
                var file = CheckFileUploadToDb(item, curForderId, userName, projectId);
                if (file != null)
                {
                    AddFileToCache(file.ClientPath, file);
                }
            }
            var suvDirs = dirInfo.GetDirectories();
            if (suvDirs != null && suvDirs.Length > 0)
            {
                foreach (var item in suvDirs)
                {
                    //递归检查文件夹
                    CheckFolderUploadAllToDb(item, curForderId, userName, projectId);
                }
            }
        }

        /// <summary>
        /// 获取文件夹下所有文件为对象格式
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <returns></returns>
        private List<Model.FileModel> GetAllFiles(DirectoryInfo dirInfo)
        {
            List<Model.FileModel> fileModels = new List<Model.FileModel>();
            var files = dirInfo.GetFiles();
            //文件上传
            foreach (var item in files)
            {
                if ((item.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)   //必须进行与运算，因为默认文件是“Hidden”+归档（二进制11）。而Hidden是10.因此与运算才可以判断
                {
                    continue;
                }
                Model.FileModel f = new Model.FileModel()
                {
                    ActionNum = 1,
                    ClientPath = item.FullName,
                    File_Ext = item.Extension,
                    File_Size = (int)item.Length,
                    File_Name = item.Name,
                    File_Modify_Time = item.LastAccessTime.Ticks
                };
                fileModels.Add(f);
            }
            var suvDirs = dirInfo.GetDirectories();
            if (suvDirs != null && suvDirs.Length > 0)
            {
                foreach (var item in suvDirs)
                {
                    fileModels.AddRange(GetAllFiles(item));
                }
            }
            return fileModels;
        }

        /// <summary>
        /// 单个文件检查
        /// </summary>
        /// <param name="item"></param>
        private Model.FileModel CheckFileUploadToDb(FileInfo item, int forderId, string userName, int projectId)
        {
            //string md5 = GetMD5HashFromFile(item.FullName);
            string md5 = "";

            //上传文件之前判断文件是否已经存在
            FileDalEx fileDal = new FileDalEx("FM_");
            int fileID = fileDal.GetFileID(this.connection, forderId, item.Name, md5);
            //int fileID = 1;
            FileVersionDalEx fVerDal = new FileVersionDalEx("FM_");

            //返回文件信息
            Model.FileModel file = null;
            //文件信息不存在，则新建一个
            if (fileID > 0)
            {
                //判断是否需要创建版本
                //int curVer = fileBll.GetFileLastVer(fileID, item.LastWriteTime);
                int curVer = 0;
                var lastFileVer = fileDal.GetFileLastVer(this.connection, fileID);
                if (lastFileVer != null)
                {
                    curVer = lastFileVer.Ver;
                }

                //如果文件已经存在相同文件的版本，则忽略上传
                if (curVer <= 0 || (lastFileVer != null && lastFileVer.File_Modify_Time < item.LastWriteTime.Ticks))
                {
                    file = new Model.FileModel()
                    {
                        ActionNum = 2,
                        ClientPath = item.FullName,
                        File_Ext = item.Extension,
                        File_Size = (int)item.Length,
                        File_Name = item.Name,
                        File_Modify_Time = item.LastAccessTime.Ticks
                    };
                    AddNeedAllUploadFilesToCache(item.FullName, file);
                }
            }
            //文件信息不存在，则新建一个
            else
            {
                file = new Model.FileModel()
                {
                    ActionNum = 1,
                    ClientPath = item.FullName,
                    File_Ext = item.Extension,
                    File_Size = (int)item.Length,
                    File_Name = item.Name,
                    File_Modify_Time = item.LastAccessTime.Ticks
                };

                AddNeedAllUploadFilesToCache(item.FullName, file);
            }
            return file;
        }

        #endregion

        #region 文件一键下载到本地客户端
        /// <summary>
        /// 点击一键下载文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FolderDownloadFromDb(string forderPath, FileManager.Model.UserModel user)
        {
            try
            {
                string dirPath = forderPath;
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                //此处查询出所有文件内容
                DirectoryInfo rootDirInfo = new DirectoryInfo(dirPath);
                FolderDownloadAllFormDb(rootDirInfo, 0, user.UserName, user.CurProject.ID);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 递归下载文件夹和文件
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <param name="parentId"></param>
        /// <param name="user"></param>
        private void FolderDownloadAllFormDb(DirectoryInfo dirInfo, int parentId, string userName, int projectId)
        {
            //开始从文件夹获取子文件夹和文件列表
            ForderBll forderBll = new ForderBll();
            var subFiles = forderBll.GetSubFiles(parentId, projectId, string.Empty);
            var files = subFiles;
            //文件上传
            foreach (var item in files)
            {
                //判断文件夹操作
                Model.FileModel fCache;
                string fileClientPath = string.Format("{0}\\{1}", dirInfo.FullName, item.File_Name);
                if (needAddOrMordifyFiles.TryGetValue(fileClientPath, out fCache))
                {
                    FileDownloadFromDb(item, fileClientPath, userName, projectId);
                    //修改为完成状态
                    fCache.ActionNum = 10;
                }
            }

            var subForders = forderBll.GetSubForders(parentId, projectId);
            if (subForders != null && subForders.Count > 0)
            {
                foreach (var item in subForders)
                {
                    string forderPath = string.Format("{0}\\{1}", dirInfo.FullName, item.Title);

                    if (!Directory.Exists(forderPath))
                    {
                        Directory.CreateDirectory(forderPath);
                    }
                    DirectoryInfo dirItemInfo = new DirectoryInfo(forderPath);

                    //判断文件夹操作
                    FolderDownloadAllFormDb(dirItemInfo, item.ID, userName, projectId);
                }
            }
        }

        /// <summary>
        /// 下载文件到客户端
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fileClientPath"></param>
        /// <param name="userName"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        private int FileDownloadFromDb(Model.FileModel item, string fileClientPath, string userName, int projectId)
        {
            try
            {
                //上传文件之前判断文件是否已经存在
                FileBll fileBll = new FileBll();
                var verModel = fileBll.GetFileLastVer(item.ID);
                if (verModel == null || verModel.Ver <= 0) return -1;

                //string md5 = GetMD5HashFromFile(item.FullName);
                string md5 = "";
                FileInfo clientFileInfo = new FileInfo(fileClientPath);
                if (clientFileInfo.Exists && clientFileInfo.LastAccessTime.Ticks == item.File_Modify_Time)
                {
                    return -1;
                }

                //需要修改文件也先删除文件
                if (clientFileInfo.Exists) clientFileInfo.Delete();

                FileVersionBll fVerBll = new FileVersionBll();
                var content = fVerBll.GetContent(verModel.ID);
                FileWinexploer.CreateFile(content, fileClientPath, verModel.File_Modify_Time);
                UnZipFloClass.UnzipFile(fileClientPath);

                // 异步日志
                FileLogHelper.FileLog(verModel, item, Model.ActionType.ONEDOWNLOAD);

                return 1;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
                return -1;
            }
        }

        #endregion

        #region 文件一键下载到本地客户端检查

        /// <summary>
        /// 点击一键上传之前检查文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckFolderDownloadFromDb(string forderPath, FileManager.Model.UserModel user)
        {
            try
            {
                string dirPath = forderPath;

                //needAddOrMordifyFiles.Clear();
                ClearCache();
                if (!Directory.Exists(dirPath))
                {
                    //文件夹不存在，全部新增
                    List<Model.FileModel> fileLists = GetAllServerFiles(
                    new Model.ForderModel()
                    {
                        ID = 0,
                        Project_Id = user.CurProject.ID
                    });

                    foreach (var item in fileLists)
                    {
                        AddFileToCache(item.ClientPath, item);
                        AddNeedAllDownloadFilesToCache(item.ClientPath, item);
                    }

                    //Directory.CreateDirectory(dirPath);
                }

                //此处查询出所有文件内容
                DirectoryInfo rootDirInfo = new DirectoryInfo(dirPath);
                CheckFolderDownloadAllFromDb(rootDirInfo, 0, user.UserName, user.CurProject.ID);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 递归检查文件夹和文件
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <param name="parentId"></param>
        /// <param name="user"></param>
        private void CheckFolderDownloadAllFromDb(DirectoryInfo dirInfo, int parentId, string userName, int projectId)
        {
            //开始从文件夹获取子文件夹和文件列表
            ForderBll forderBll = new ForderBll();
            FileBll fileBll = new FileBll();
            var subFiles = forderBll.GetSubFiles(parentId, projectId, string.Empty);
            var files = subFiles;
            //文件下载
            foreach (var item in files)
            {
                var verModel = fileBll.GetFileLastVer(item.ID);
                if (verModel == null || verModel.Ver <= 0) continue;
                string fileClientPath = string.Format("{0}\\{1}", dirInfo.FullName, item.File_Name);
                FileInfo clientFileInfo = new FileInfo(fileClientPath);

                if (clientFileInfo.Exists)
                {
                    if (clientFileInfo.LastAccessTime.Ticks == verModel.File_Modify_Time)
                    {
                        continue;
                    }
                }

                //if (clientFileInfo.Exists && clientFileInfo.LastAccessTime.Ticks == item.File_Modify_Time)
                //{
                //    continue;
                //}

                if (clientFileInfo.Exists)
                {
                    item.ActionNum = 2;
                    if (verModel.File_Modify_Time == clientFileInfo.LastWriteTime.Ticks)
                    {
                        continue;
                    }

                    AddFileToCache(fileClientPath, item);
                    //服务器文件最新
                    if (verModel.File_Modify_Time > clientFileInfo.LastWriteTime.Ticks)
                    {
                        AddNeedAllDownloadFilesToCache(fileClientPath, item);
                    }
                }
                else
                {
                    item.ActionNum = 1;
                    AddFileToCache(fileClientPath, item);
                    AddNeedAllDownloadFilesToCache(fileClientPath, item);
                }
            }

            var subForders = forderBll.GetSubForders(parentId, projectId);
            if (subForders != null && subForders.Count > 0)
            {
                foreach (var item in subForders)
                {
                    string forderPath = string.Format("{0}\\{1}", dirInfo.FullName, item.Title);

                    if (!Directory.Exists(forderPath))
                    {
                        //文件夹不存在，全部新增
                        List<Model.FileModel> fileLists = GetAllServerFiles(item);
                        foreach (var subFileItem in fileLists)
                        {
                            AddFileToCache(subFileItem.ClientPath, subFileItem);
                            AddNeedAllUploadFilesToCache(subFileItem.ClientPath, subFileItem);
                        }

                        //Directory.CreateDirectory(forderPath);
                    }
                    DirectoryInfo dirItemInfo = new DirectoryInfo(forderPath);
                    //判断文件夹操作
                    CheckFolderDownloadAllFromDb(dirItemInfo, item.ID, userName, projectId);
                }
            }

        }

        /// <summary>
        /// 获取文件夹下所有文件为对象格式
        /// </summary>
        /// <param name="forderInfo"></param>
        /// <returns></returns>
        private List<Model.FileModel> GetAllServerFiles(Model.ForderModel forderInfo)
        {
            List<Model.FileModel> fileModels = new List<Model.FileModel>();
            ForderBll forderBll = new ForderBll();
            var subFiles = forderBll.GetSubFiles(forderInfo.ID, forderInfo.Project_Id, string.Empty);
            fileModels.AddRange(subFiles);

            var suvDirs = forderBll.GetSubForders(forderInfo.ID, forderInfo.Project_Id);
            if (suvDirs != null && suvDirs.Count > 0)
            {
                foreach (var item in suvDirs)
                {
                    fileModels.AddRange(GetAllServerFiles(item));
                }
            }
            return fileModels;
        }
        #endregion

        #region 当前文件夹同服务器对比---暂时删除【支持删除文件】
        //private static Dictionary<string, Model.ForderModel> currentForders = new Dictionary<string, Model.ForderModel>();
        //private static Dictionary<string, Model.FileModel> currentFiles = new Dictionary<string, Model.FileModel>();

        ///// <summary>
        ///// 文件增量更新对比
        ///// </summary>
        //public void CompareFiles(DirectoryInfo dirInfo)
        //{
        //    Model.ForderModel curRoot = new Model.ForderModel()
        //    {
        //        Title = "主目录",
        //        Files = new List<Model.FileModel>(),
        //        SubForders = new List<Model.ForderModel>()
        //    };

        //    //初始化当前目录的文件
        //    int total = GetAllFileNum(dirInfo, curRoot);

        //    //文件对比，修改对象中的操作信息
        //    Bll.SystemBll.FileCompare(curRoot);
        //    total = GetCurRootFile(curRoot);
        //}

        ///// <summary>
        ///// 当前文件夹信息获取列表
        ///// </summary>
        ///// <param name="dirInfo"></param>
        ///// <returns></returns>
        //public int GetCurRootFile(Model.ForderModel curRoot)
        //{
        //    int totalNum = 0;
        //    var files = curRoot.Files;
        //    totalNum += files.Count;

        //    if (files != null && files.Count > 0)
        //    {
        //        foreach (var item in files)
        //        {
        //            currentFiles.Add(item.ClientPath, item);
        //        }
        //    }
        //    var suvDirs = curRoot.SubForders;
        //    if (suvDirs != null && suvDirs.Count > 0)
        //    {
        //        foreach (var item in suvDirs)
        //        {
        //            currentForders.Add(item.ClientPath, item);
        //            totalNum += GetCurRootFile(item);
        //        }
        //    }

        //    return totalNum;
        //}

        ///// <summary>
        ///// 文件对比信息
        ///// </summary>
        ///// <param name="dirInfo"></param>
        ///// <returns></returns>
        //public int GetAllFileNum(DirectoryInfo dirInfo, Model.ForderModel curRoot)
        //{
        //    int totalNum = 0;
        //    var files = dirInfo.GetFiles();
        //    totalNum += files.Length;

        //    if (files != null && files.Length > 0)
        //    {
        //        foreach (var item in files)
        //        {
        //            ///构建对象数据上传到数据库
        //            FileManager.Model.FileModel fileModel = new FileManager.Model.FileModel();
        //            fileModel.File_Modify_Time = item.LastAccessTime.Ticks;
        //            fileModel.File_Name = item.Name;

        //            fileModel.File_Type = "file";
        //            fileModel.ClientPath = item.FullName;
        //            //currentFiles.Add(item.FullName, fileModel);
        //            curRoot.Files.Add(fileModel);
        //        }
        //    }

        //    var suvDirs = dirInfo.GetDirectories();
        //    if (suvDirs != null && suvDirs.Length > 0)
        //    {
        //        foreach (var item in suvDirs)
        //        {
        //            FileManager.Model.ForderModel forderModel = new FileManager.Model.ForderModel();
        //            forderModel.Title = item.Name;
        //            forderModel.ClientPath = item.FullName;
        //            forderModel.SubForders = new List<Model.ForderModel>();
        //            forderModel.Files = new List<Model.FileModel>();

        //            //currentForders.Add(item.FullName, forderModel);
        //            totalNum += GetAllFileNum(item, forderModel);
        //            curRoot.SubForders.Add(forderModel);
        //        }
        //    }

        //    return totalNum;
        //}

        ///// <summary>
        ///// 文件对比信息
        ///// </summary>
        ///// <param name="dirInfo"></param>
        ///// <returns></returns>
        //public int GetAllFileNum(DirectoryInfo dirInfo)
        //{
        //    int totalNum = 0;
        //    var files = dirInfo.GetFiles();
        //    totalNum += files.Length;

        //    var suvDirs = dirInfo.GetDirectories();
        //    if (suvDirs != null && suvDirs.Length > 0)
        //    {
        //        foreach (var item in suvDirs)
        //        {
        //            totalNum += GetAllFileNum(item);
        //        }
        //    }

        //    return totalNum;
        //}
        #endregion

        #region 图标文件和二进制的转换

        /// <summary>
        /// 获取文件的md5值
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }

        /// <summary>
        /// 获取文件的ico图标二进制【返回临时文件路径】
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private byte[] GetFileImg(Image fileImage, ref string tempFilePath)
        {
            if (fileImage == null)
            {
                return null;
            }
            string guid = Guid.NewGuid().ToString();

            //临时存储图标的目录
            string tempForderPath = string.Format("{0}/Temp/Bmp", Bll.SystemBll.RootForderPath);
            if (!Directory.Exists(tempForderPath)) Directory.CreateDirectory(tempForderPath);

            tempFilePath = string.Format("tempForderPath\\{0}.bmp", guid);
            fileImage.Save(tempFilePath);
            FileInfo item = new FileInfo(tempFilePath);

            byte[] bytes;
            //读取数据流为二进制
            using (FileStream stream = item.OpenRead())
            {
                bytes = new byte[item.Length];
                stream.Read(bytes, 0, (int)item.Length);
                stream.Close();
            }

            return bytes;
        }

        /// <summary>
        /// image转化为二进制
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imageFormat"></param>
        /// <returns></returns>
        private byte[] ImageToBytes(Image image, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            MemoryStream msStream = new MemoryStream();
            image.Save(msStream, imageFormat);
            byte[] byData = new byte[msStream.Length];
            msStream.Position = 0;

            msStream.Read(byData, 0, byData.Length);
            msStream.Close();

            return byData;
        }

        /// <summary>
        /// ICO转化为二进制
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imageFormat"></param>
        /// <returns></returns>
        private byte[] ImageToBytes(Icon image)
        {
            MemoryStream msStream = new MemoryStream();
            image.Save(msStream);
            byte[] byData = new byte[msStream.Length];
            msStream.Position = 0;

            msStream.Read(byData, 0, byData.Length);
            msStream.Close();

            return byData;
        }

        /// <summary>
        /// 二进制转化为图片
        /// </summary>
        /// <param name="streamByte"></param>
        /// <returns></returns>
        private System.Drawing.Image ReturnImage(byte[] streamByte)
        {
            MemoryStream ms = new MemoryStream(streamByte);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            return img;
        }

        //private System.Drawing.Icon ReturnImage(byte[] streamByte)
        //{
        //    Stream ms = new MemoryStream(streamByte);
        //    System.Drawing.Icon img =Icon.FromHandle(iconBm.GetHicon()
        //    return img;
        //}

        private System.Drawing.Bitmap ReturnBitmap(byte[] streamByte)
        {
            MemoryStream ms = new MemoryStream(streamByte);
            System.Drawing.Bitmap img = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream((Stream)ms);
            return img;
        }

        /// <summary>
        /// 二进制转化为文件
        /// </summary>
        /// <param name="streamByte"></param>
        /// <param name="filePath"></param>
        public static void CreateFile(byte[] streamByte, string filePath, long ticks)
        {
            if (streamByte == null) return;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                fs.Write(streamByte, 0, streamByte.Length);
                fs.Close();
            }

            try
            {
                FileInfo file = new FileInfo(filePath);
                file.LastWriteTime = new DateTime(ticks);
            }
            catch (Exception ex)
            {

            }
            return;
        }
        #endregion

        #region 文件图标数据库获取

        /// <summary>
        /// 数据库获取文件的ico图标集合
        /// </summary>
        /// <returns></returns>
        public ImageList GetImageCollectionByDb(int forderId)
        {
            FileBll fileBll = new FileBll();
            string strWhere = string.Format(" File_DirId = {0}  ", forderId);
            DataTable dt = fileBll.GetList(strWhere, " id desc ").Tables[0];

            ImageList images = new ImageList();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Image img = ReturnImage((byte[])item["File_SmallImage"]);
                    images.Images.Add(item["File_Name"].ToString(), img);
                }
            }
            return images;
        }

        /// <summary>
        /// 获取文件ico的图标
        /// </summary>
        /// <param name="forderId"></param>
        /// <param name="images"></param>
        /// <returns></returns>
        public ImageList GetImageCollectionByDb(int forderId, ImageList images)
        {
            FileBll fileBll = new FileBll();
            string strWhere = string.Format(" File_DirId = {0}  ", forderId);
            DataTable dt = fileBll.GetList(strWhere, " id desc ").Tables[0];

            ImageList newImageList = new ImageList();
            if (images.Images != null && images.Images.Count > 0)
            {
                for (int i = 4; i < images.Images.Count; i++)
                {
                    images.Images.RemoveAt(i);
                }
            }

            if (images == null) images = new ImageList();
            if (dt != null && dt.Rows.Count > 0)
            {
                Dictionary<string, Icon> icos = new Dictionary<string, Icon>();
                foreach (DataRow item in dt.Rows)
                {
                    //Image img = ReturnImage((byte[])item["File_SmallImage"]);
                    ////img.Save(@"D:\用户目录\Desktop\1\"+ Guid.NewGuid() + ".ico");
                    //Icon ico = ConvertBitmap2Ico(ReturnBitmap((byte[])item["File_SmallImage"]), new Size(160,160));
                    //images.Images.Add(item["File_Name"].ToString(),ico );
                    //Icon ico =    GetSystemIcon.GetIconByFileType(item["File_Ext"].ToString(), true);

                    //采用获取本地系统文件实现
                    string desc = string.Empty;

                    string key = item["File_Ext"].ToString();
                    if (!icos.ContainsKey(key))
                    {
                        Icon largeIco;
                        Icon smallIco;
                        GetSystemIcon.GetExtsIconAndDescription(item["File_Ext"].ToString(), out largeIco, out smallIco, out desc);
                        if (largeIco != null)
                        {
                            images.Images.Add(item["File_Ext"].ToString(), largeIco);
                            icos.Add(item["File_Ext"].ToString(), largeIco);
                        }
                    }
                }
            }
            return images;
        }

        /// <summary>
        /// 根据条件搜索文件
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="images"></param>
        /// <returns></returns>
        public ImageList GetImageCollectionByDb(string strWhere, ImageList images)
        {
            FileBll fileBll = new FileBll();
            //DataTable dt = fileBll.GetList(1000,strWhere, " id desc ").Tables[0];

            var subFiles = fileBll.SearchList(1000, strWhere, string.Empty);

            ImageList newImageList = new ImageList();
            if (images.Images != null && images.Images.Count > 0)
            {
                for (int i = 4; i < images.Images.Count; i++)
                {
                    images.Images.RemoveAt(i);
                }
            }

            if (images == null) images = new ImageList();
            if (subFiles != null && subFiles.Count > 0)
            {
                Dictionary<string, Icon> icos = new Dictionary<string, Icon>();
                foreach (var item in subFiles)
                {
                    //采用获取本地系统文件实现
                    string desc = string.Empty;
                    string key = item.File_Ext;

                    if (string.IsNullOrEmpty(key)) continue;
                    if (!icos.ContainsKey(key))
                    {
                        Icon largeIco;
                        Icon smallIco;
                        GetSystemIcon.GetExtsIconAndDescription(key, out largeIco, out smallIco, out desc);
                        if (largeIco != null)
                        {
                            images.Images.Add(key, largeIco);
                            icos.Add(key, largeIco);
                        }
                    }
                }
            }
            return images;
        }

        private Icon BitmapToIcon(Bitmap obm, bool preserve, int size)
        {
            Bitmap bm;
            // if not preserving aspect
            if (!preserve)        // if not preserving aspect
                bm = new Bitmap(obm, size, size);  //   rescale from original bitmap

            // if preserving aspect drop excess significance in least significant direction
            else          // if preserving aspect
            {
                Rectangle rc = new Rectangle(0, 0, size, size);
                if (obm.Width >= obm.Height)   //   if width least significant
                {          //     rescale with width based on max icon height
                    bm = new Bitmap(obm, (size * obm.Width) / obm.Height, size);
                    rc.X = (bm.Width - size) / 2;  //     chop off excess width significance
                    if (rc.X < 0) rc.X = 0;
                }
                else         //   if height least significant
                {          //     rescale with height based on max icon width
                    bm = new Bitmap(obm, size, (size * obm.Height) / obm.Width);
                    rc.Y = (bm.Height - size) / 2; //     chop off excess height significance
                    if (rc.Y < 0) rc.Y = 0;
                }
                bm = bm.Clone(rc, bm.PixelFormat);  //   bitmap for icon rectangle
            }

            // create icon from bitmap
            Icon icon = Icon.FromHandle(bm.GetHicon()); // create icon from bitmap
            bm.Dispose();        // dispose of bitmap
            return icon;        // return icon
        }

        /// <summary>
        /// 实现bitmap到ico的转换
        /// </summary>
        /// <param name="bitmap">原图</param>
        /// <returns>转换后的指定大小的图标</returns>
        private Icon ConvertBitmap2Ico(Bitmap bitmap, Size size)
        {
            Bitmap icoBitmap = new Bitmap(bitmap, size);//创建制定大小的原位图

            //获得原位图的图标句柄
            IntPtr hIco = icoBitmap.GetHicon();
            //从图标的指定WINDOWS句柄创建Icon
            Icon icon = Icon.FromHandle(hIco);

            return icon;
        }
        #endregion

        #region 上传下载提示和缓存的更新
        /// <summary>
        /// 构造上传的提示
        /// </summary>
        /// <returns></returns>
        public static string ConstructUploadTip()
        {
            int allNotEqualCount = NeedAddOrMordifyFiles.Count;
            int clientNewCount = NeedAllUploadFiles.Count;
            int serverNewCount = Math.Abs(allNotEqualCount - clientNewCount);

            //return string.Format("总共差异文件：{0}个，其中服务器最新：{1}个，本地最新：{2}个 ", allNotEqualCount, serverNewCount, clientNewCount);

            return string.Empty;
        }

        /// <summary>
        /// 构造下载的提示
        /// </summary>
        /// <returns></returns>
        public static string ConstructDownLoadTip()
        {
            int allNotEqualCount = NeedAddOrMordifyFiles.Count;
            int serverNewCount = NeedAllDownloadFiles.Count;
            int clientNewCount = Math.Abs(allNotEqualCount - serverNewCount);

            return string.Format("总共差异文件：{0}个，其中服务器最新：{1}个，本地最新：{2}个 ", allNotEqualCount, serverNewCount, clientNewCount);
        }

        /// <summary>
        /// 上传缓存更新
        /// </summary>
        public static void SetUploadCache()
        {
            needAddOrMordifyFiles.Clear();
            foreach (var item in NeedAllUploadFiles)
            {
                needAddOrMordifyFiles.Add(item.Key, item.Value);
            }
        }

        /// <summary>
        /// 下载缓存更新
        /// </summary>
        public static void SetDownLoadCache()
        {
            needAddOrMordifyFiles.Clear();
            foreach (var item in NeedAllDownloadFiles)
            {
                needAddOrMordifyFiles.Add(item.Key, item.Value);
            }
        }
        #endregion

        
        #region 文件一键下载到本地指定路径
        /// <summary>
        /// 点击一键下载文件夹
        /// </summary>
        /// <param name="forderPath">下载路径</param>
        /// <param name="parentId">文件夹id</param>
        /// <param name="user"></param>
        public void FolderDownloadFromDb_OtherUser(string forderPath, int parentId,string code, FileManager.Model.UserModel user)
        {
            try
            {
                string dirPath = forderPath;
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                //此处查询出所有文件内容
                DirectoryInfo rootDirInfo = new DirectoryInfo(dirPath);
                FolderDownloadAllFormDb_OtherUser(rootDirInfo, parentId, user.UserName, user.CurProject.ID,code);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 递归下载文件夹和文件
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <param name="parentId"></param>
        /// <param name="user"></param>
        private void FolderDownloadAllFormDb_OtherUser(DirectoryInfo dirInfo, int parentId, string userName, int projectId,string code)
        {
            //开始从文件夹获取子文件夹和文件列表
            ForderBll forderBll = new ForderBll();
            var subFiles = forderBll.GetSubFiles(parentId, projectId, string.Empty);
            var files = subFiles;

            //文件上传
            foreach (var item in files)
            {
                //判断文件夹操作
                Model.FileModel fCache;
                string fileClientPath = string.Format("{0}\\{1}", dirInfo.FullName, item.File_Name);
                if (needAddOrMordifyFiles.TryGetValue(fileClientPath, out fCache))
                {
                    FileDownloadFromDb_OtherUser(item, fileClientPath, userName, projectId,code);
                    //修改为完成状态
                    fCache.ActionNum = 10;
                }
            }

            var subForders = forderBll.GetSubForders(parentId, projectId);
            if (subForders != null && subForders.Count > 0)
            {
                foreach (var item in subForders)
                {
                    string forderPath = string.Format("{0}\\{1}", dirInfo.FullName, item.Title);

                    if (!Directory.Exists(forderPath))
                    {
                        Directory.CreateDirectory(forderPath);
                    }
                    DirectoryInfo dirItemInfo = new DirectoryInfo(forderPath);

                    //判断文件夹操作
                    FolderDownloadAllFormDb_OtherUser(dirItemInfo, item.ID, userName, projectId,code);
                }
            }
        }

        /// <summary>
        /// 下载文件到客户端
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fileClientPath"></param>
        /// <param name="userName"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        private int FileDownloadFromDb_OtherUser(Model.FileModel item, string fileClientPath, string userName, int projectId,string code)
        {
            try
            {
                //上传文件之前判断文件是否已经存在
                FileBll fileBll = new FileBll();
                var verModel = fileBll.GetFileLastVer(item.ID);
                if (verModel == null || verModel.Ver <= 0) return -1;

                //string md5 = GetMD5HashFromFile(item.FullName);
                string md5 = "";
                FileInfo clientFileInfo = new FileInfo(fileClientPath);
                if (clientFileInfo.Exists && clientFileInfo.LastAccessTime.Ticks == item.File_Modify_Time)
                {
                    return -1;
                }

                //需要修改文件也先删除文件
                if (clientFileInfo.Exists) clientFileInfo.Delete();

                FileVersionBll fVerBll = new FileVersionBll();
                var content = fVerBll.GetContent(verModel.ID);
                FileWinexploer.CreateFile(content, fileClientPath, verModel.File_Modify_Time);

                UnZipFloClass.UnzipFile(fileClientPath);

                // 异步日志
                FileLogHelper.FileLog(verModel, item,code ,Model.ActionType.ONEDOWNLOAD);

                return 1;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
                return -1;
            }
        }

        #endregion
    }
}
