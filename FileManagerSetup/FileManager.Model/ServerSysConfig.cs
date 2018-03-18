using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Model
{
    /// <summary>
    /// 系统配置项［保持有一条数据，只做修改］
    /// </summary>
    public class ServerSysConfig
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID;

        /// <summary>
        /// 系统维护管理员账号
        /// </summary>
        public string ManagerEmail;

        /// <summary>
        /// 系统维护管理员电话
        /// </summary>
        public string ManagerTel;

        /// <summary>
        /// 系统登录设置【由服务器控制 0：需要密码登录,1：不需要密码使用系统账号直接登录，2：使用域账号登录】
        /// </summary>
        public int SystemLoginType;
    }
}
