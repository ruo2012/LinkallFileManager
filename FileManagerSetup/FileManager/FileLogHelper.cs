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
    public class FileLogHelper
    {
        /// <summary>
        /// 文件操作日志
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="fileModel"></param>
        public static void FileLog(Model.FileVersion fileVerModel, Model.FileModel fileModel, ActionType logType)
        {
            if (fileVerModel == null && fileModel == null) return;
            string remark = string.Empty;

            if (logType == ActionType.RENAME)
            {
                remark = string.Format("文件：{0}重命名为：", fileModel.File_Name);
                fileModel = new BLL.FileBll().GetModel(fileModel.ID);
                remark = remark + fileModel.File_Name;
            }

            if (fileModel == null && fileVerModel != null)
            {
                fileModel = new BLL.FileBll().GetModel(fileVerModel.File_Id);
            }

            if (fileModel != null && fileVerModel == null)
            {
                FileBll fileBll = new FileBll();
                fileVerModel = fileBll.GetFileLastVer(fileModel.ID);
            }

            ActionLogAsyn(fileVerModel, fileModel, remark, string.Empty, logType);
        }

        public static void FileLog(Model.FileVersion fileVerModel, Model.FileModel fileModel, string actionCode, ActionType logType)
        {
            if (fileVerModel == null && fileModel == null) return;
            string remark = string.Empty;

            Model.UserModel UserInfo = SystemBll.UserInfo;

            if (logType == ActionType.RENAME)
            {
                remark = string.Format("{0}({1})重命名文件：{2}为==>：", UserInfo.UserName, UserInfo.RealName, fileModel.File_Name);
                fileModel = new BLL.FileBll().GetModel(fileModel.ID);
                remark = remark + fileModel.File_Name;
            }

            if (logType == ActionType.ONEDELFILE)
            {
                remark = string.Format("{0}({1})删除文件：{2}：", UserInfo.UserName, UserInfo.RealName, fileModel.File_Name);
            }

            if (fileModel == null && fileVerModel != null)
            {
                fileModel = new BLL.FileBll().GetModel(fileVerModel.File_Id);
            }

            if (fileModel != null && fileVerModel == null)
            {
                FileBll fileBll = new FileBll();
                fileVerModel = fileBll.GetFileLastVer(fileModel.ID);
            }

            ActionLogAsyn(fileVerModel, fileModel, remark, actionCode, logType);
        }
        public static void FileLogForderRename(Model.FileVersion fileVerModel, Model.FileModel fileModel, string remark, string actionCode, ActionType logType)
        {
            Model.UserModel UserInfo = SystemBll.UserInfo;
            ActionLogAsyn(fileVerModel, fileModel, remark, actionCode, logType);
        }

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
        public static void ActionLogAsyn(Model.FileVersion fileVerModel, Model.FileModel fileModel, string remark, string actionCode, ActionType action)
        {
            ActionLogHandler handler = new ActionLogHandler(ActionLog);
            Model.UserModel user = Bll.SystemBll.UserInfo;
            handler.BeginInvoke(fileVerModel, fileModel, remark, actionCode, action, IAsyncMenthod, null);
        }

        /// <summary>
        /// 上传附件委托
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public delegate void ActionLogHandler(Model.FileVersion fileVerModel, Model.FileModel fileModel, string remark, string actionCode, ActionType action);

        /// <summary>
        /// 记录用户操作日志
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="projectName"></param>
        /// <param name="clientPath"></param>
        /// <param name="action"></param>
        public static void ActionLog(Model.FileVersion fileVerModel, Model.FileModel fileModel, string remark, string actionCode, ActionType action)
        {
            // 用户信息
            Model.UserModel UserInfo = SystemBll.UserInfo;

            BLL.FileLogBll logBll = new FileLogBll();
            Model.FileLogModel logModel = new FileLogModel();
            logModel.AddTime = DateTime.Now;
            logModel.UserID = UserInfo.ID;
            logModel.UserName = UserInfo.UserName;
            logModel.UserRealName = UserInfo.RealName;
            //logModel.Ip = SystemBll.GetIP();
            logModel.Ip = SystemBll.GetComputerName();

            logModel.ProjectID = 0;
            logModel.ProjectName = string.Empty;
            logModel.ClientPath = fileVerModel.ClientPath;

            logModel.ActionType = action.ToString();
            logModel.ActionName = GetActionName(action);

            logModel.FileID = fileVerModel.File_Id > 0 ? fileVerModel.File_Id : fileModel.ID;
            logModel.FileName = fileModel.File_Name;


            logModel.FileType = 0;
            logModel.FileVer = fileVerModel.Ver;
            logModel.FileVerID = fileVerModel.ID;

            logModel.ParentForderId = fileModel.File_DirId;
            logModel.Remark = remark;
            logModel.ActionCode = actionCode;

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
                    return "文件下载";
                case ActionType.MULTIDOWNLOAD:
                    return "多个文件下载";
                case ActionType.MULTIDELETE:
                    return "多个文件删除";

                case ActionType.RENAMEFORDER:
                    return "文件夹修改名称";

                case ActionType.ONEDOWNLOADFORDER:
                    return "文件夹下载";

                case ActionType.USERLOGIN:
                    return "登录";
                case ActionType.ONEUPLOAD:
                    return "文件上传";
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
                case "文件下载":
                    return ActionType.ONEDOWNLOAD.ToString();
                case "多个文件下载":
                    return ActionType.MULTIDOWNLOAD.ToString();
                case "多个文件删除":
                    return ActionType.MULTIDELETE.ToString();

                case "文件夹修改名称":
                    return ActionType.RENAMEFORDER.ToString();

                case "文件夹下载":
                    return ActionType.ONEDOWNLOADFORDER.ToString();

                case "文件上传":
                    return ActionType.ONEUPLOAD.ToString();
                case "登录":
                    return ActionType.USERLOGIN.ToString();
                default:
                    return "特殊操作";
            }
        }
        #endregion
    }
}
