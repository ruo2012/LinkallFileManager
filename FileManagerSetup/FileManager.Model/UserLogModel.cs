using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Model
{
    /// <summary>
    /// 用户操作日志:实体类
    /// </summary>
    [Serializable]
    public partial class UserLogModel
    {
        public UserLogModel() { }

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
        /// 用户名
        /// </summary>
        public string UserRealName;
		 
		/// <summary>
		/// 操作类型[
        /// 一键上传:ALLUPLOAD，一键同步：ALLDOWNLOAD,修改名称：RENAME，
        /// 删除：ONEDEL，下载一个：ONEDOWNLOAD，用户登录：USERLOGIN]
		/// </summary>
        public string ActionType;

        public string ActionName;
		 
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark;

        /// <summary>
        /// 客户端操作IP地址
        /// </summary>
        public string Ip;

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
		/// 操作时间
		/// </summary>
		public DateTime AddTime;

        /// <summary>
        /// 同文件操作日志的关联编码
        /// </summary>
        public string ActionCode;

		#endregion Model
    }
}
