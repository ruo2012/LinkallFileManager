using System;
using System.Data;
using System.Collections.Generic;
using FileManager.Common;

namespace FileManager.BLL
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public partial class ServerSysConfigBll
    {
        private readonly DAL.ServerSysConfigDal dal;
        public ServerSysConfigBll()
        {
            dal = new DAL.ServerSysConfigDal("FM_");
        }

        #region 基本方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.ServerSysConfig model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据的字段
        /// </summary>
        /// <param name="id"></param>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ServerSysConfig GetModel(int id)
        {
            return dal.GetModel(id);
        }

        #endregion  Method
    }
}