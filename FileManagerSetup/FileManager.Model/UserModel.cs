using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Model
{
    /// <summary>
    /// 用户信息表:实体类
    /// </summary>
    [Serializable]
    public partial class UserModel
    {
        public UserModel()   { }

        #region Model
        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID;
         
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId;
        
        /// <summary>
        /// 管理员类型1一般管理员，2超级管理员，0普通用户
        /// </summary>
        public int RoleType;

        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName;
         
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password;
     
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string RealName;
        
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email;

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel;

        /// <summary>
        /// 是否锁定
        /// </summary>
        public int IsLock;

        /// <summary>
        /// 客户端IP地址
        /// </summary>
        public string ClientIp;

        /// <summary>
        /// 服务器配置客户端的监控路径
        /// </summary>
        public string ClientPath;

        /// <summary>
        /// 用户监控列表
        /// </summary>
        public List<UserProjectModel> Projects;

        /// <summary>
        /// 用户当前选择的项目
        /// </summary>
        public UserProjectModel CurProject;

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime;
      
        #endregion Model
    }
}
