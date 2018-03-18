using System;
using System.Collections.Generic;

namespace FileManager.Model
{
    /// <summary>
    /// 管理角色:实体类[暂时不用]
    /// </summary>
    [Serializable]
    public partial class UserRoleModel
    {
        public UserRoleModel()  { }

        #region Model

        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID;

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName;

        /// <summary>
        /// 角色类型
        /// </summary>
        public int RoleType;
      
        /// <summary>
        /// 是否系统默认0否1是
        /// </summary>
        public int IsSys;
         
        #endregion Model
    }
}