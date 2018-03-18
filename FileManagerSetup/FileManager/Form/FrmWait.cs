using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using FileManager.Common;
using FileManager.DAL;
using FileManager.BLL;

namespace FileManager
{
    public partial class FrmWait : CCSkinMain
    {
        private string forderPath;
        private FileManager.Model.UserModel user;

        private int type = 0;

        private int parentId = 0;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="forderPath"></param>
        /// <param name="user"></param>
        public FrmWait(string forderPath, FileManager.Model.UserModel user, int type)
        {
            this.forderPath = forderPath;
            this.user = user;
            this.type = type;

            InitializeComponent();

            if (type == 1)
            {
                this.lodding.Text = "下载中...";
                this.Text = "文件下载";
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="forderPath"></param>
        /// <param name="user"></param>
        public FrmWait(string forderPath, FileManager.Model.UserModel user, int type, int parentId)
        {
            this.forderPath = forderPath;
            this.user = user;
            this.type = type;
            this.parentId = parentId;

            InitializeComponent();

            if (type == 1 || type == 2)
            {
                this.lodding.Text = "下载中...";
                this.Text = "文件下载";
            }
        }

        #region 文件上传到服务器操作检查
        private int totalNum = 0;

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
                if (!FileWinexploer.needAddOrMordifyFiles.ContainsKey(key))
                {
                    FileWinexploer.needAddOrMordifyFiles.Add(key, file);
                }
            }
        }

        public static void AddNeedAllUploadFilesToCache(string key, Model.FileModel file)
        {
            lock (_lockToActionFile)
            {
                if (!FileWinexploer.needAllUploadFiles.ContainsKey(key))
                {
                    FileWinexploer.needAllUploadFiles.Add(key, file);
                }
            }
        }

        private static void ClearCache()
        {
            FileWinexploer.needAllDownloadFiles.Clear();
            FileWinexploer.needAllUploadFiles.Clear();
            FileWinexploer.needAddOrMordifyFiles.Clear();
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
                    //this.textBox1.AppendText("\r\n文件夹：" + dirPath);
                    Application.DoEvents();

                    foreach (var item in rootDirInfo.GetDirectories())
                    {
                        Common.LogHelper.WriteLog(string.Format("文件夹：{0},parentId:{1},dirInfo.Name:{2},projectId:{3} \r\n", item.Name, 0, item.FullName, user.CurProject.ID));
                    }

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
            try
            {
                // 构建对象数据上传到数据库
                ForderDalEx forderDal = new ForderDalEx("FM_");
                // 上传之前判断是否已经存在
                int curForderId = forderDal.GetForderId(this.connection, parentId, dirInfo.Name, userName, projectId);
                // 20160515 添加特殊文件夹判断,如果是特殊文件夹全部上传
                SpecialForder(dirInfo, userName, parentId, projectId);

                //bool isSpecialForder = ForderSpecialControl.IsSpecialForder(dirInfo);
                //if (isSpecialForder)
                //{
                //    if (CheckSpecialForderUpload(dirInfo, parentId, userName, projectId))
                //    {
                //        // 如果特殊文件夹需要更新
                //        if (ForderSpecialControl.ZipSpecialForder(dirInfo))
                //        {
                //            string zipFile = Path.Combine(dirInfo.Parent.FullName, dirInfo.Name + ".ztlj");
                //            var file = CheckFileUploadToDb(new FileInfo(zipFile), parentId, userName, projectId);
                //            if (file != null)
                //            {
                //                AddFileToCache(file.ClientPath, file);
                //            }
                //        }
                //    }
                //}

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
                else
                {
                    //Common.LogHelper.WriteLog(string.Format("已经存在文件：{0},parentId:{1},dirInfo.Name:{2},projectId:{3} \r\n",dirInfo.Name, parentId, dirInfo.Name, projectId));
                }

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
                        var file = CheckFileUploadToDb(item, curForderId, userName, projectId);
                        if (file != null)
                        {
                            AddFileToCache(file.ClientPath, file);
                        }
                        totalNum++;
                        //this.textBox1.AppendText("\r\n文件：" + item.FullName);
                        Application.DoEvents();
                    }

                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
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
                           // Common.LogHelper.WriteLog(string.Format("文件夹：{0},parentId:{1},dirInfo.Name:{2},projectId:{3} \r\n", item.Name, curForderId, item.FullName, projectId));

                            try
                            {
                                SpecialForder(item, userName, curForderId, projectId);
                                //递归检查文件夹
                                CheckFolderUploadAllToDb(item, curForderId, userName, projectId);
                            }
                            catch (Exception ex)
                            {
                                LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
                }

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void SpecialForder(DirectoryInfo item, string userName, int curParentId, int curProjectId)
        {
            // 20160515 添加特殊文件夹判断,如果是特殊文件夹全部上传
            bool isSpecialItemForder = ForderSpecialControl.IsSpecialForder(item);
            if (isSpecialItemForder)
            {
                if (CheckSpecialForderUpload(item, curParentId, userName, curProjectId))
                {
                    // 如果特殊文件夹需要更新
                    if (ForderSpecialControl.ZipSpecialForder(item))
                    {
                        string zipFile = Path.Combine(item.Parent.FullName, item.Name + ".ztlj");
                        var file = CheckFileUploadToDb(new FileInfo(zipFile), curParentId, userName, curProjectId);
                        if (file != null)
                        {
                            AddFileToCache(file.ClientPath, file);
                        }
                    }
                }
            }
        }

        private void SpecialForder(DirectoryInfo item)
        {
            // 20160515 添加特殊文件夹判断,如果是特殊文件夹全部上传
            bool isSpecialItemForder = ForderSpecialControl.IsSpecialForder(item);
            if (isSpecialItemForder)
            {
                // 如果特殊文件夹需要更新
                if (ForderSpecialControl.ZipSpecialForder(item))
                {
                    string zipFile = Path.Combine(item.Parent.FullName, item.Name + ".ztlj");

                    var file = new Model.FileModel()
                     {
                         ActionNum = 2,
                         ClientPath = item.FullName,
                         File_Ext = item.Extension,
                         File_Size = (int)new FileInfo(zipFile).Length,
                         File_Name = item.Name,
                         File_Modify_Time = item.LastAccessTime.Ticks
                     };

                    if (file != null)
                    {
                        AddFileToCache(file.ClientPath, file);
                    }
                }
            }
        }

        /// <summary>
        /// 判断特殊文件夹中是否包含了需要更改的文件夹或者文件
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <param name="parentId"></param>
        /// <param name="userName"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        private bool CheckSpecialForderUpload(DirectoryInfo dirInfo, int parentId, string userName, int projectId)
        {
            // 构建对象数据上传到数据库
            ForderDalEx forderDal = new ForderDalEx("FM_");
            // 上传之前判断是否已经存在
            int curForderId = forderDal.GetForderId(this.connection, parentId, dirInfo.Name, userName, projectId);
            if (curForderId <= 0)
            {
                return true;
            }

            var suvDirs = dirInfo.GetDirectories();
            if (suvDirs != null && suvDirs.Length > 0)
            {
                foreach (var item in suvDirs)
                {
                    try
                    {
                        //递归检查文件夹
                        bool isNeedUpload = CheckSpecialForderUpload(item, curForderId, userName, projectId); ;
                        if (isNeedUpload)
                        {
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
                    }
                }
            }

            var files = dirInfo.GetFiles();
            //文件上传
            foreach (var item in files)
            {
                if ((item.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)   //必须进行与运算，因为默认文件是“Hidden”+归档（二进制11）。而Hidden是10.因此与运算才可以判断
                {
                    continue;
                }
                bool isNeedUpload = CheckSpecialFileUploadToDb(item, curForderId, userName, projectId);
                if (isNeedUpload)
                {
                    return true;
                }
                totalNum++;
                //this.textBox1.AppendText("\r\n文件：" + item.FullName);
                Application.DoEvents();
            }

            return false;
        }

        private bool CheckSpecialFileUploadToDb(FileInfo item, int forderId, string userName, int projectId)
        {
            string md5 = "";
            //上传文件之前判断文件是否已经存在
            FileDalEx fileDal = new FileDalEx("FM_");
            int fileID = fileDal.GetFileID(this.connection, forderId, item.Name, md5);
            FileVersionDalEx fVerDal = new FileVersionDalEx("FM_");

            //返回文件信息
            Model.FileModel file = null;
            if (fileID > 0)
            {
                //判断是否需要创建版本
                int curVer = 0;
                var lastFileVer = fileDal.GetFileLastVer(this.connection, fileID);
                if (lastFileVer != null)
                {
                    curVer = lastFileVer.Ver;
                }

                //如果文件已经存在相同文件的版本，则忽略上传
                if (curVer <= 0 || (lastFileVer != null && lastFileVer.File_Modify_Time < item.LastWriteTime.Ticks))
                {
                    return true;
                }
            }
            else
            {
                // 文件不存在
                return true;
            }

            return false;
        }

        /// <summary>
        /// 获取文件夹下所有文件为对象格式
        /// </summary>
        /// <param name="dirInfo"></param>
        /// <returns></returns>
        private List<Model.FileModel> GetAllFiles(DirectoryInfo dirInfo)
        {
            List<Model.FileModel> fileModels = new List<Model.FileModel>();
            try
            {
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
                        totalNum++;
                        //this.textBox1.AppendText("\r\n文件：" + item.FullName);
                        Application.DoEvents();

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
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
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
                            SpecialForder(item);

                            fileModels.AddRange(GetAllFiles(item));
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
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

            try
            {
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

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
            }
            return file;
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
                Application.DoEvents();

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
                    Application.DoEvents();

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

        public static void AddNeedAllDownloadFilesToCache(string key, Model.FileModel file)
        {
            lock (_lockToActionFile)
            {
                if (!FileWinexploer.needAllDownloadFiles.ContainsKey(key))
                {
                    FileWinexploer.needAllDownloadFiles.Add(key, file);
                }
            }
        }

        #endregion

        #region 基础方法
        /// <summary>
        /// 已重载.计算两个日期的时间间隔,返回的是时间间隔的日期差的绝对值.
        /// </summary>
        /// <param name="DateTime1">第一个日期和时间</param>
        /// <param name="DateTime2">第二个日期和时间</param>
        /// <returns></returns>
        private string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                dateDiff = ts.Days.ToString() + "天"
                        + ts.Hours.ToString() + "小时"
                        + ts.Minutes.ToString() + "分钟"
                        + ts.Seconds.ToString() + "秒";
            }
            catch
            {

            }
            return dateDiff;
        }

        /// <summary>
        /// 已重载.计算一个时间与当前本地日期和时间的时间间隔,返回的是时间间隔的日期差的绝对值.
        /// </summary>
        /// <param name="DateTime1">一个日期和时间</param>
        /// <returns></returns>
        private string DateDiff(DateTime DateTime1)
        {
            return this.DateDiff(DateTime1, DateTime.Now);
        }

        #endregion


        #region 文件一键下载到本地客户端检查

        /// <summary>
        /// 点击一键上传之前检查文件夹
        /// </summary>
        /// <param name="forderPath">存储路径</param>
        /// <param name="parentId">文件夹id</param>
        /// <param name="user"></param>
        public void CheckFolderDownloadFromDb_OtherUser(string forderPath, int parentId, FileManager.Model.UserModel user)
        {
            try
            {
                string dirPath = forderPath;
                ClearCache();
                if (!Directory.Exists(dirPath))
                {
                    //文件夹不存在，全部新增
                    List<Model.FileModel> fileLists = GetAllServerFiles_OtherUser(
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
                }

                //此处查询出所有文件内容
                DirectoryInfo rootDirInfo = new DirectoryInfo(dirPath);
                CheckFolderDownloadAllFromDb_OtherUser(rootDirInfo, parentId, user.UserName, user.CurProject.ID);
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
        private void CheckFolderDownloadAllFromDb_OtherUser(DirectoryInfo dirInfo, int parentId, string userName, int projectId)
        {
            //开始从文件夹获取子文件夹和文件列表
            ForderBll forderBll = new ForderBll();
            FileBll fileBll = new FileBll();
            var subFiles = forderBll.GetSubFiles(parentId, projectId, string.Empty);
            var files = subFiles;
            //文件下载
            foreach (var item in files)
            {
                Application.DoEvents();

                var verModel = fileBll.GetFileLastVer(item.ID);
                if (verModel == null || verModel.Ver <= 0) continue;
                string fileClientPath = string.Format("{0}\\{1}", dirInfo.FullName, item.File_Name);
                FileInfo clientFileInfo = new FileInfo(fileClientPath);
                item.ActionNum = 1;
                AddFileToCache(fileClientPath, item);
                AddNeedAllDownloadFilesToCache(fileClientPath, item);
            }

            var subForders = forderBll.GetSubForders(parentId, projectId);
            if (subForders != null && subForders.Count > 0)
            {
                foreach (var item in subForders)
                {
                    Application.DoEvents();

                    string forderPath = string.Format("{0}\\{1}", dirInfo.FullName, item.Title);

                    //文件夹不存在，全部新增
                    List<Model.FileModel> fileLists = GetAllServerFiles_OtherUser(item);
                    foreach (var subFileItem in fileLists)
                    {
                        AddFileToCache(subFileItem.ClientPath, subFileItem);
                        AddNeedAllUploadFilesToCache(subFileItem.ClientPath, subFileItem);
                    }
                    DirectoryInfo dirItemInfo = new DirectoryInfo(forderPath);
                    //判断文件夹操作
                    CheckFolderDownloadAllFromDb_OtherUser(dirItemInfo, item.ID, userName, projectId);
                }
            }

        }

        /// <summary>
        /// 获取文件夹下所有文件为对象格式
        /// </summary>
        /// <param name="forderInfo"></param>
        /// <returns></returns>
        private List<Model.FileModel> GetAllServerFiles_OtherUser(Model.ForderModel forderInfo)
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
                    fileModels.AddRange(GetAllServerFiles_OtherUser(item));
                }
            }
            return fileModels;
        }
        #endregion

        private void FrmWait_Shown(object sender, EventArgs e)
        {
            try
            {
                if (type == 2)
                {
                    CheckFolderDownloadFromDb_OtherUser(this.forderPath, parentId, this.user);
                }
                else if (type == 1)
                {
                    CheckFolderDownloadFromDb(this.forderPath, this.user);
                }
                else
                {
                    CheckFolderUploadToDb(this.forderPath, this.user);
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
