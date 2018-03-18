using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace FileManager.MonitoringTool
{
    /// <summary>
    /// 软件监控配置信息
    /// </summary>
    public class ClientSystemConfig
    {
        private static SystemConfig _clientSystemConfigCache = null;
        public static SystemConfig ClientSystemConfigCache
        {
            get 
            {
                return _clientSystemConfigCache; 
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configFilePath"></param>
        public static void InitConfig(string configFilePath)
        {
            if (File.Exists(configFilePath))
            {
                _clientSystemConfigCache = (SystemConfig)SerializationHelper.Load(typeof(SystemConfig), configFilePath);
            }
        }

        /// <summary>
        ///  读取站点配置文件
        /// </summary>
        public static SystemConfig loadConfig(string configFilePath)
        {
            return (SystemConfig)SerializationHelper.Load(typeof(SystemConfig), configFilePath);
        }
    }

    /// <summary>
    /// XML配置序列化
    /// </summary>
    public class SerializationHelper
    {
        public SerializationHelper() { }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="filename">文件路径</param>
        /// <returns></returns>
        public static object Load(Type type, string filename)
        {
            FileStream fs = null;
            try
            {
                // open the stream...
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="filename">文件路径</param>
        public static void Save(object obj, string filename)
        {
            FileStream fs = null;
            // serialize it...
            try
            {
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
    }

    /// <summary>
    /// 配置实体类
    /// </summary>
    [Serializable]
    public class SystemConfig
    {
        public SystemConfig() { }

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
        /// 是否强制登录
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
