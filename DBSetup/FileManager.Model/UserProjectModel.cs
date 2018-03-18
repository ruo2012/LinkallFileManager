using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Model
{
    /// <summary>
    /// 用户项目工程检测表:实体类
    /// </summary>
    [Serializable]
    public partial class UserProjectModel
    {
        public UserProjectModel() { }

        #region Model
        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName;

        /// <summary>
        /// 是否锁定
        /// </summary>
        public int IsLock;

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName;

        /// <summary>
        /// 客户端IP地址
        /// </summary>
        public string ClientIp;

        /// <summary>
        /// 服务器配置客户端的监控路径
        /// </summary>
        public string MonitoringPath;

        /// <summary>
        /// 监控软件名称
        /// </summary>
        public string MonitoringSoftwareName;

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime;
      
        #endregion Model
    }
}
