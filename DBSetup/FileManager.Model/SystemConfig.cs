using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Model
{
    /// <summary>
    /// 配置实体类
    /// </summary>
    [Serializable]
    public class SystemConfig
    {
        public SystemConfig()  { }

        private string _dbName = string.Empty;
        private string _dbUser = string.Empty;
        private string _dbPassword = string.Empty;
        private string _dbAddress = string.Empty;
        private string _isLogin = string.Empty;

        private string _dbFileContentName = string.Empty;
        private string _dbFileContentUser = string.Empty;
        private string _dbFileContentPassword = string.Empty;
        private string _dbFileContentAddress = string.Empty;
        private string _monitoringSoftWareNames = string.Empty;

       

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DbName
        {
            get { return _dbName; }
            set { _dbName = value; }
        }

        /// <summary>
        /// 数据库账号
        /// </summary>
        public string DbUser
        {
            get { return _dbUser; }
            set { _dbUser = value; }
        }

        /// <summary>
        /// 数据库密码
        /// </summary>
        public string DbPassword
        {
            get { return _dbPassword; }
            set { _dbPassword = value; }
        }

        /// <summary>
        /// 数据库地址
        /// </summary>
        public string DbAddress
        {
            get { return _dbAddress; }
            set { _dbAddress = value; }
        }

        /// <summary>
        /// 是否强制登陆
        /// </summary>
        public string IsLogin
        {
            get { return _isLogin; }
            set { _isLogin = value; }
        }

        /// <summary>
        ///文件内容库名称
        /// </summary>
        public string DbFileContentName
        {
            get { return _dbFileContentName; }
            set { _dbFileContentName = value; }
        }

        /// <summary>
        /// 文件内容账号
        /// </summary>
        public string DbFileContentUser
        {
            get { return _dbFileContentUser; }
            set { _dbFileContentUser = value; }
        }

        /// <summary>
        /// 文件内容密码
        /// </summary>
        public string DbFileContentPassword
        {
            get { return _dbFileContentPassword; }
            set { _dbFileContentPassword = value; }
        }

        /// <summary>
        /// 文件内容服务器地址
        /// </summary>
        public string DbFileContentAddress
        {
            get { return _dbFileContentAddress; }
            set { _dbFileContentAddress = value; }
        }

        /// <summary>
        /// 监控软件名称列表
        /// </summary>
        public string MonitoringSoftWareNames
        {
            get { return _monitoringSoftWareNames; }
            set { _monitoringSoftWareNames = value; }
        }
    }
}
