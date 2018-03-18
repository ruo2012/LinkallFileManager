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
		/// 操作类型[上传，修改，删除，下载]
		/// </summary>
		public int ActionType;
		 
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
		 
		#endregion Model
    }
}
