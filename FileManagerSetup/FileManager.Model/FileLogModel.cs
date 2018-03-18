using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Model
{
    /// <summary>
    /// 文件操作日志:实体类
    /// </summary>
    [Serializable]
    public partial class FileLogModel
    {
        public FileLogModel() 	{}

		#region Model

		/// <summary>
		/// 自增ID
		/// </summary>
        public int ID;
	 
		/// <summary>
		/// 用户ID
		/// </summary>
		public int UserID;
	 
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName;

        /// <summary>
        /// 操作类型[
        /// 一键上传:ALLUPLOAD，一键同步：ALLDOWNLOAD,修改名称：RENAME，
        /// 删除：ONEDEL，下载一个：ONEDOWNLOAD，用户登录：USERLOGIN]
        /// </summary>
		public string ActionType;
		 
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark;

        /// <summary>
        /// 客户端操作IP地址
        /// </summary>
        public string Ip;

		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime AddTime;

        /// <summary>
        /// 文件id
        /// </summary>
        public int FileID;

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName;

        /// <summary>
        /// 文件版本id
        /// </summary>
        public int FileVerID;

        /// <summary>
        /// 文件版本
        /// </summary>
        public int FileVer;

        /// <summary>
        /// 操作名称
        /// </summary>
        public string ActionName;

        /// <summary>
        /// 用户中文真实名称
        /// </summary>
        public string UserRealName;

        /// <summary>
        /// 文件类型[0--文件，1--文件夹]
        /// </summary>
        public int FileType;

        /// <summary>
        /// 工程id
        /// </summary>
        public int ProjectID;

        /// <summary>
        /// 工程名称
        /// </summary>
        public string ProjectName;

        /// <summary>
        /// 工程路径
        /// </summary>
        public string ProjectPath;

        /// <summary>
        /// 操作客户端路径
        /// </summary>
        public string ClientPath;

        /// <summary>
        /// 父级目录id
        /// </summary>
        public int ParentForderId;

        /// <summary>
        /// 同用户操作日志的关联编码
        /// </summary>
        public string ActionCode;

        /// <summary>
        /// 是否已经删除
        /// </summary>
        public int IsDeleted;

		#endregion Model
    }
}
