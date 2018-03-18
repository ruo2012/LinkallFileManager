using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using FileManager.Common;

namespace FileManager.BLL
{
    public partial class SystemConfigBll
    {
        private readonly DAL.SystemConfigDal dal = new DAL.SystemConfigDal();
        private static Model.SystemConfig _config;

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <returns></returns>
        public static Model.SystemConfig GetConfig()
        {
            if (_config != null) return _config;
            _config = new SystemConfigBll().loadConfig();
            return _config;
        }

        /// <summary>
        ///  读取用户配置文件
        /// </summary>
        public Model.SystemConfig loadConfig()
        {
            string path = string.Format("{0}/System.config", System.Environment.CurrentDirectory);
            if (!File.Exists(path))
            {
                throw new CustomException("未找到系统配置文件，请联系管理员处理！");
            }
            Model.SystemConfig model = dal.loadConfig(path);

            if (string.IsNullOrEmpty(model.DbUser) || string.IsNullOrEmpty(model.DbPassword) || string.IsNullOrEmpty(model.DbAddress))
            {
                throw new CustomException("系统配置文件信息不正确，请联系管理员处理！");
            }

            return model;
        }

        /// <summary>
        ///  保存用户配置文件
        /// </summary>
        public Model.SystemConfig saveConifg(Model.SystemConfig model)
        {
            string path = string.Format("{0}/System.config", System.Environment.CurrentDirectory);

            if (!File.Exists(path))
            {
                throw new CustomException("未找到系统配置文件，请联系管理员处理！");
            }
            return dal.saveConifg(model, path);
        }
    }
}
