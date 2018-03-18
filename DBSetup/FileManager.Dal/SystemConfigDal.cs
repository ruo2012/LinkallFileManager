using System;
using System.Collections.Generic;
using System.Text;
using FileManager.Common;

namespace FileManager.DAL
{
    /// <summary>
    /// 数据访问类:站点配置
    /// </summary>
    public partial class SystemConfigDal
    {
        private static object lockHelper = new object();

        /// <summary>
        ///  读取站点配置文件
        /// </summary>
        public Model.SystemConfig loadConfig(string configFilePath)
        {
            return (Model.SystemConfig)SerializationHelper.Load(typeof(Model.SystemConfig), configFilePath);
        }

        /// <summary>
        /// 写入站点配置文件
        /// </summary>
        public Model.SystemConfig saveConifg(Model.SystemConfig model, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(model, configFilePath);
            }
            return model;
        }
    }
}
