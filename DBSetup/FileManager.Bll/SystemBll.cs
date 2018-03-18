using System;
using System.Collections.Generic;
using System.Text;
using FileManager.BLL;
using FileManager.DBUtility;
using FileManager.Common;
using System.Diagnostics;
using FileManager.Model;
using System.Net;
using System.Runtime.Remoting.Messaging;

namespace FileManager.Bll
{
    /// <summary>
    /// 系统业务类
    /// </summary>
    public class SystemBll
    {
        #region 本地缓存

        /// <summary>
        /// 系统根目录
        /// </summary>
        private static string _rootForderPath = System.Environment.CurrentDirectory;

        /// <summary>
        /// 系统根目录
        /// </summary>
        public static string RootForderPath
        {
            get { return SystemBll._rootForderPath; }
        }

        /// <summary>
        /// 本地账号IP
        /// </summary>
        private static string currentUserIp = null;

        /// <summary>
        /// 本地账号IP
        /// </summary>
        public static string CurrentUserIp
        {
            get
            {
                if (currentUserIp == null)
                {
                    currentUserIp = GetIP();
                }
                return currentUserIp;
            }
            set { SystemBll.currentUserIp = value; }
        }

        /// <summary>
        /// 当前计算机名称
        /// </summary>
        private static string currentComputerName;

        /// <summary>
        /// 当前计算机名称
        /// </summary>
        public static string CurrentComputerName
        {
            get
            {
                if (currentComputerName == null)
                {
                    currentComputerName = GetComputerName();
                }
                return currentComputerName;
            }
            set { SystemBll.currentComputerName = value; }
        }

        /// <summary>
        //当前系统账号
        /// </summary>
        private static string currentUserName = System.Environment.UserName;

        /// <summary>
        //当前系统账号
        /// </summary>
        public static string CurrentUserName
        {
            get { return SystemBll.currentUserName; }
            set { SystemBll.currentUserName = value; }
        }

        /// <summary>
        /// 当前域账号
        /// </summary>
        private static string currentDominName = System.Environment.UserDomainName;

        /// <summary>
        /// 用户登陆信息
        /// </summary>
        private static Model.UserModel _userInfo = null;

        /// <summary>
        /// 用户登陆信息
        /// </summary>
        public static Model.UserModel UserInfo
        {
            get
            {
                if (_userInfo == null)
                {
                    throw new CustomException("无法获取到用户信息，请联系管理员处理！");
                }
                return SystemBll._userInfo;
            }
            set { SystemBll._userInfo = value; }
        }

        /// <summary>
        /// 系统信息
        /// </summary>
        private static Model.ServerSysConfig _serverConfigInfo = null;

        /// <summary>
        /// 系统配置信息
        /// </summary>
        public static Model.ServerSysConfig ServerConfigInfo
        {
            get
            {
                if (_serverConfigInfo != null)
                {
                    return SystemBll._serverConfigInfo;
                }
                _serverConfigInfo = new ServerSysConfigBll().GetModel(1);
                if (_serverConfigInfo == null)
                {
                    throw new CustomException("服务器系统配置文件信息不正确，请联系管理员处理！");
                }

                return SystemBll._serverConfigInfo;
            }
            set { SystemBll._serverConfigInfo = value; }
        }

        private static Model.ForderModel _rootForder = null;
        public static object _lockSlim = new object();

        /// <summary>
        /// 当前系统的所有文件结构[后面上传同步时，可做对比]
        /// </summary>
        public static void InitCurrentFiles()
        {
            BLL.ForderBll forderBll = new ForderBll();
            lock (_lockSlim)
            {
                if (_rootForder == null)
                {
                    _rootForder = new Model.ForderModel()
                    {
                        Title = "主目录"
                    };
                    _rootForder.SubForders = new List<Model.ForderModel>();
                    _rootForder.Files = new List<Model.FileModel>();
                }
                GetAllForders(_rootForder, 0);
                //List<Model.ForderModel> rootForders = forderBll.GetSubForders(0);
                //List<Model.FileModel> rootFiles = forderBll.GetSubFiles(0, string.Empty);
                //_rootForder.Files.AddRange(rootFiles);

                //if (rootForders != null)
                //{
                //    foreach (var item in rootForders)
                //    {
                //        GetAllForders(item);
                //    }
                //}
            }
        }

        #endregion

        #region 文件对比操作【本地缓存服务器文件信息做动态监控】
        /// <summary>
        /// 初始化各个文件夹
        /// </summary>
        /// <param name="parentForder"></param>
        private static void GetAllForders(Model.ForderModel parentForder, int projectId)
        {
            if (parentForder == null) return;

            parentForder.SubForders = new List<Model.ForderModel>();
            parentForder.Files = new List<Model.FileModel>();
            BLL.ForderBll forderBll = new ForderBll();

            List<Model.FileModel> rootFiles = forderBll.GetSubFiles(parentForder.ID, projectId, string.Empty);
            parentForder.Files.AddRange(rootFiles);

            List<Model.ForderModel> rootForders = forderBll.GetSubForders(parentForder.ID, projectId);
            if (rootForders != null)
            {
                foreach (var item in rootForders)
                {
                    GetAllForders(item, 0);
                }
            }
        }

        /// <summary>
        /// 文件对比
        /// </summary>
        /// <param name="file"></param>
        /// <param name="forders"></param>
        /// <returns>0相等，1新增,2修改，3删除</returns>
        private static int FileCompare(Model.FileModel file, List<string> forders)
        {
            if (_rootForder == null)
            {
                InitCurrentFiles();
            }
            bool isDelete;
            bool isExist;
            Model.ForderModel fo = GetForderFiles(forders);
            foreach (var item in fo.Files)
            {
                if (item.File_Name == file.File_Name)
                {
                    isExist = true;
                    if (item.File_Modify_Time == file.File_Modify_Time)
                    {
                        //名称和文件修改时间一样，相等
                        return 0;
                    }
                    else
                    {
                        return 2;
                    }
                }
            }

            //默认不存在，新增
            return 1;
        }

        /// <summary>
        /// 文件列表对比
        /// </summary>
        /// <param name="orgFiles"></param>
        /// <param name="aimFile"></param>
        private static void FileCompare(List<Model.FileModel> orgFiles, List<Model.FileModel> aimFile)
        {
            if (orgFiles == null) orgFiles = new List<Model.FileModel>();
            if (aimFile == null) aimFile = new List<Model.FileModel>();

            //需要修改的文件
            var exitFiles = orgFiles.FindAll(x => aimFile.Exists(y => y.File_Name == x.File_Name && y.File_Modify_Time != x.File_Modify_Time));
            if (exitFiles != null)
            {
                foreach (var item in exitFiles)
                {
                    item.ActionNum = 2;
                }
            }
            //需要新增
            exitFiles = orgFiles.FindAll(x => !aimFile.Exists(y => y.File_Name == x.File_Name));
            if (exitFiles != null)
            {
                foreach (var item in exitFiles)
                {
                    item.ActionNum = 1;
                }
            }

            //需要删除
            exitFiles = aimFile.FindAll(x => !orgFiles.Exists(y => y.File_Name == x.File_Name));
            if (exitFiles != null)
            {
                foreach (var item in exitFiles)
                {
                    orgFiles.Add(new Model.FileModel()
                    {
                        ID = item.ID,
                        ClientPath = "FileId_" + item.ID,
                        ActionNum = 3,
                    });
                }
            }
        }

        /// <summary>
        /// 文件夹对比
        /// </summary>
        /// <param name="orgForder"></param>
        /// <param name="aimForder"></param>
        /// <returns></returns>
        public static void FileCompare(Model.ForderModel orgForder, Model.ForderModel aimForder)
        {
            var aimSubForder = aimForder.SubForders ?? new List<Model.ForderModel>();
            var orgSubForder = orgForder.SubForders ?? new List<Model.ForderModel>();

            //文件对比
            FileCompare(orgForder.Files, aimForder.Files);

            //文件夹新增
            var exitFiles = orgSubForder.FindAll(x => aimSubForder.Exists(y => y.Title != x.Title));
            if (exitFiles != null)
            {
                foreach (var item in exitFiles)
                {
                    item.ActionNum = 1;
                    ModifyForderFiles(item, 1);
                }
            }
            //文件夹删除
            exitFiles = aimSubForder.FindAll(x => orgSubForder.Exists(y => y.Title != x.Title));
            if (exitFiles != null)
            {
                foreach (var item in exitFiles)
                {
                    item.ActionNum = 3;
                    ModifyForderFiles(item, 3);
                }
            }

            //文件夹相等
            exitFiles = aimSubForder.FindAll(x => orgSubForder.Exists(y => y.Title == x.Title));
            if (exitFiles != null)
            {
                foreach (var item in exitFiles)
                {
                    //递归再次对比
                    FileCompare(item, aimSubForder.Find(x => item.Title == x.Title));
                }
            }
        }

        /// <summary>
        /// 递归修改文件夹
        /// </summary>
        /// <param name="orgForder"></param>
        /// <param name="action"></param>
        public static void ModifyForderFiles(Model.ForderModel orgForder, int action)
        {
            if (orgForder == null || orgForder.SubForders == null || orgForder.SubForders.Count == 0) return;

            foreach (var item in orgForder.SubForders)
            {
                item.ActionNum = action;
                ModifyForderFiles(item, action);
            }
            foreach (var item in orgForder.Files)
            {
                item.ActionNum = action;
            }
        }

        public static void FileCompare(Model.ForderModel orgForder)
        {
            if (_rootForder == null) InitCurrentFiles();
            var aimSubForder = _rootForder.SubForders;
            var orgSubForder = orgForder.SubForders;

            //不处理的文件
            var exitFiles = orgSubForder.FindAll(x => aimSubForder.Exists(y => y.Title != x.Title));
            if (exitFiles != null)
            {
                foreach (var item in exitFiles)
                {
                    item.ActionNum = 1;
                }
            }
            exitFiles = aimSubForder.FindAll(x => orgSubForder.Exists(y => y.Title != x.Title));
            if (exitFiles != null)
            {
                foreach (var item in exitFiles)
                {
                    orgSubForder.Add(new Model.ForderModel()
                    {
                        ID = item.ID,
                        ClientPath = "ForderId_" + item.ID,
                        ActionNum = 3,
                    });
                }
            }
        }

        /// <summary>
        /// 根据相对路径找到最后一个路径
        /// </summary>
        /// <param name="forders"></param>
        /// <returns></returns>
        private static Model.ForderModel GetForderFiles(List<string> forders)
        {
            if (forders == null || forders.Count == 0) return _rootForder;

            if (_rootForder.SubForders == null || _rootForder.SubForders.Count == 0)
            {
                throw new CustomException("初始化的基础文件夹出错！");
            }
            return GetForderFiles(forders, 0, _rootForder);
        }

        /// <summary>
        /// 根据路径获取文件夹信息
        /// </summary>
        /// <param name="forders">路径</param>
        /// <param name="num">层次</param>
        /// <param name="forder">对应服务器目录</param>
        /// <returns></returns>
        private static Model.ForderModel GetForderFiles(List<string> forders, int num, Model.ForderModel forder)
        {
            //指定文件夹不存在
            if (forder == null || forder.SubForders == null || forder.SubForders.Count == 0)
            {
                return null;
            }
            foreach (var forderItem in _rootForder.SubForders)
            {
                if (forders[num] == forderItem.Title)
                {
                    return GetForderFiles(forders, ++num, forderItem);
                }
            }
            //没有对应文件夹
            return null;
        }

        public static void ModifyForder()
        {
        }

        public static void ModifyFile()
        {
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 管理员信息
        /// </summary>
        public static string ManagerLinkInfo
        {
            get
            {
                if (string.IsNullOrEmpty(_serverConfigInfo.ManagerEmail) || string.IsNullOrEmpty(_serverConfigInfo.ManagerTel))
                {
                    return string.Empty;
                }

                return string.Format("可以联系管理员,邮箱：{0},电话：{1}", _serverConfigInfo.ManagerEmail, _serverConfigInfo.ManagerTel);
            }
        }

        /// <summary>
        /// 初始化账号信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password">如果没有密码，为空即可</param>
        /// <returns></returns>
        public static Model.UserModel GetUserInfo(string userName, string password)
        {
            //if (SystemBll._userInfo == null)
            //{
            //判断登陆方式
            switch (ServerConfigInfo.SystemLoginType)
            {
                case 0:
                    _userInfo = new ManagerBll().GetModel(userName, password);
                    break;
                case 1:
                    _userInfo = new ManagerBll().GetModel(userName);

                    break;
                case 2:
                    throw new CustomException("暂时不支持域账号，请联系管理员处理！");
                default:
                    break;
            }
            //}

            return _userInfo;
        }

        /// <summary>
        /// 自动登陆
        /// </summary>
        public static void AutoLogin()
        {
            //获取系统账号
            Model.UserModel user = GetUserInfo(currentUserName, string.Empty);

            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.RealName))
            {
                throw new CustomException(string.Format("该账号：{0}，没有权限，请联系管理员处理！", SystemBll.currentUserName) + ManagerLinkInfo);
            }

            if (user.IsLock == 1)
            {
                throw new CustomException(string.Format("该账号：{0}，已经被锁定 ，请联系管理员处理！", SystemBll.currentUserName) + ManagerLinkInfo);
            }
        }

        /// <summary>
        /// 系统检查
        /// </summary>
        public static void SystemCheck()
        {
            // 获取配置信息
            Model.SystemConfig config = SystemConfigBll.GetConfig();

            // 设置数据库连接
            string conn = string.Format("server={0};uid={1};pwd={2};database={3};", config.DbAddress, config.DbUser, config.DbPassword, config.DbName);
            DbHelperSQL.SetConnectionString(conn);

            string fileContentConn = string.Format("server={0};uid={1};pwd={2};database={3};", config.DbFileContentAddress, config.DbFileContentUser, config.DbFileContentPassword, config.DbFileContentName);
            DbHelperFileContentSQL.SetConnectionString(fileContentConn);
        }

        /// <summary>
        /// 服务器连接检查
        /// </summary>
        /// <returns></returns>
        public static bool SystemLinkCheck()
        {
            try
            {
                SystemCheck();
                ManagerBll bll = new ManagerBll();
                bll.Exists(0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 服务器连接检查
        /// </summary>
        /// <returns></returns>
        public static bool SystemLinkCheckSys()
        {
            try
            {
                // 获取配置信息
                Model.SystemConfig config = SystemConfigBll.GetConfig();

                // 设置数据库连接
                string conn = string.Format("server={0};uid={1};pwd={2};database={3};Connect Timeout=3", config.DbAddress, config.DbUser, config.DbPassword, config.DbName);
                return SystemBll.SystemLinkCheck(conn);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 服务器连接检查
        /// </summary>
        /// <returns></returns>
        public static bool SystemLinkCheck(string conn)
        {
            try
            {
                ManagerBll bll = new ManagerBll();
                bll.TestDbLink(0, conn);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <returns></returns>
        public static int GetUserAuth(ref string roleName)
        {
            if (_userInfo == null || string.IsNullOrEmpty(_userInfo.UserName) || string.IsNullOrEmpty(_userInfo.RealName))
            {
                throw new CustomException("账号信息无法获取，请联系管理员处理！" + ManagerLinkInfo);
            }

            roleName = _userInfo.RoleName;
            return _userInfo.RoleId;
        }

        /// <summary>
        /// 用户权限校验
        /// </summary>
        public static void AuthCheck(int authType)
        {

        }

        /// <summary>
        /// 获取用户最近的操作记录
        /// </summary>
        /// <returns></returns>
        public static Model.UserLogModel GetUserLastLog(string userName)
        {
            UserLogBll logBll = new UserLogBll();
            return logBll.GetModel(userName, 1) ?? new Model.UserLogModel();
        }

        #endregion

        #region 用户操作日志记录

        /// <summary>
        /// 异步记录用户操作日志
        /// </summary>
        /// <param name="result"></param>
        private static void IAsyncMenthod(IAsyncResult result)
        {
            ActionLogHandler handler = (ActionLogHandler)((AsyncResult)result).AsyncDelegate;
            handler.EndInvoke(result);
        }

        /// <summary>
        /// 异步记录用户操作日志
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="projectName"></param>
        /// <param name="clientPath"></param>
        /// <param name="action"></param>
        public static void ActionLogAsyn(int projectId, string projectName, string clientPath, ActionType action)
        {
            ActionLogHandler handler = new ActionLogHandler(ActionLog);
            Model.UserModel user = Bll.SystemBll.UserInfo;
            handler.BeginInvoke(projectId, projectName, clientPath, action, IAsyncMenthod, null);
        }

        /// <summary>
        /// 上传附件委托
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public delegate void ActionLogHandler(int projectId, string projectName, string clientPath, ActionType action);

        /// <summary>
        /// 记录用户操作日志
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="projectName"></param>
        /// <param name="clientPath"></param>
        /// <param name="action"></param>
        public static void ActionLog(int projectId, string projectName, string clientPath, ActionType action)
        {
            BLL.UserLogBll logBll = new UserLogBll();
            Model.UserLogModel logModel = new UserLogModel();
            logModel.AddTime = DateTime.Now;
            logModel.UserID = UserInfo.ID;
            logModel.UserName = UserInfo.UserName;
            logModel.UserRealName = UserInfo.RealName;
            logModel.Ip = GetIP();

            logModel.ProjectID = projectId;
            logModel.ProjectName = projectName;
            logModel.ClientPath = clientPath;
            logModel.ActionType = action.ToString();
            logModel.ActionName = GetActionName(action);
            logBll.Add(logModel);
        }

        /// <summary>
        /// 用户操作转化
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string GetActionName(ActionType action)
        {
            switch (action)
            {
                case ActionType.ALLUPLOAD:
                    return "一键上传";
                case ActionType.ALLDOWNLOAD:
                    return "一键下载";
                case ActionType.RENAME:
                    return "修改名称";
                case ActionType.ONEDELFILE:
                    return "删除文件";
                case ActionType.ONEDELFORDER:
                    return "删除目录";
                case ActionType.ONEDOWNLOAD:
                    return "下载";
                case ActionType.USERLOGIN:
                    return "登陆";
                default:
                    return "特殊操作";
            }
        }

        /// <summary>
        /// 中文操作名获取操作类型
        /// </summary>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public static string GetActionName(string actionName)
        {
            switch (actionName)
            {
                case "一键上传":
                    return ActionType.ALLUPLOAD.ToString();
                case "一键下载":
                    return ActionType.ALLDOWNLOAD.ToString();
                case "修改名称":
                    return ActionType.RENAME.ToString();
                case "删除文件":
                    return ActionType.ONEDELFILE.ToString();
                case "删除目录":
                    return ActionType.ONEDELFORDER.ToString();
                case "单个文件下载":
                    return ActionType.ONEDOWNLOAD.ToString();
                case "登陆":
                    return ActionType.USERLOGIN.ToString();
                default:
                    return "特殊操作";
            }
        }
        #endregion

        #region 公共基础方法

        /// <summary>
        /// 获取用户IP
        /// </summary>
        /// <returns></returns>
        private static string GetIP()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName()); ;
                IPAddress ipaddress = ipHost.AddressList[ipHost.AddressList.Length - 1];
                string ips = ipaddress.ToString();
                return ips;
            }
            catch (Exception ex)
            {
                return "未知IP";
            }
        }

        /// <summary>
        /// 获取用户IP
        /// </summary>
        /// <returns></returns>
        public static string GetComputerName()
        {
            try
            {
                return Dns.GetHostName();
            }
            catch (Exception ex)
            {
                return "未知计算机名";
            }
        }

        /// <summary>
        /// 文件大小转换
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string ChangeFileSize(int size)
        {
            //文件夹大小转换
            double len = size;
            if (len >= 1024 * 1024)
            {
                len = Math.Round((len / 1024.0 / 1024), 2);
                return len + "MB";
            }
            else
            {
                len = Math.Round((len / 1024.0), 2);
                return len + "KB";
            }
        }

        /// <summary>
        /// 文件大小转换
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string ChangeFileSize(string sizeStr)
        {
            int size = 0;
            if (!int.TryParse(sizeStr, out size))
            {
                return "未知";
            }

            //文件夹大小转换
            double len = size;
            if (len >= 1024 * 1024)
            {
                len = Math.Round((len / 1024.0 / 1024), 2);
                return len + "MB";
            }
            else
            {
                len = Math.Round((len / 1024.0), 2);
                return len + "KB";
            }
        }

        #endregion
    }
}

