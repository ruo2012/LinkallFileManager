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
using FileManager.BLL;
using FileManager.Common;
using FileManager.DAL;

namespace FileManager
{
    public partial class FrmCheckFile : CCSkinMain
    {
        private string forderPath;
        private FileManager.Model.UserModel user;
        private int totalNum = 0;

        public FrmCheckFile(string forderPath,FileManager.Model.UserModel user)
        {
            this.forderPath = forderPath;
            this.user = user;
            InitializeComponent();
        }

        #region 文件上传到服务器操作检查

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
                    this.textBox1.AppendText("\r\n文件夹：" + dirPath);

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
                var file = CheckFileUploadToDb(item, curForderId, userName, projectId);
                if (file != null)
                {
                    AddFileToCache(file.ClientPath, file);
                }
                totalNum++;
                this.textBox1.AppendText("\r\n文件：" + item.FullName);
                Application.DoEvents();
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
                totalNum++;
                this.textBox1.AppendText("\r\n文件：" + item.FullName);
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

        private void FrmCheckFile_Load(object sender, EventArgs e)
        {
        }
        private void FrmCheckFile_Shown(object sender, EventArgs e)
        {
            //CheckFolderUploadToDb(this.forderPath, this.user);
        }

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
    }
}
