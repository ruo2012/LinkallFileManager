using System;
using System.Data;
using System.Collections.Generic;
using FileManager.Common;

namespace FileManager.BLL
{
    /// <summary>
    /// 用户操作日志信息表
    /// </summary>
    public partial class UserLogBll
    {
        private readonly DAL.UserLogDal dal;
        public UserLogBll()
        {
            dal = new DAL.UserLogDal("FM_");
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
        /// 返回数据数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.UserLogModel model)
        {
            return dal.Add(model);
        }
         
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.UserLogModel GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获取IP
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public List<string> GetLogIps(int Top, string strWhere, string filedOrder)
        {
            return dal.GetLogIps(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public List<Model.UserLogModel> GetModelList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetModelList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 根据用户名返回上一次登录记录
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="top_num"></param>
        /// <param name="action_type"></param>
        /// <returns></returns>
        public Model.UserLogModel GetModel(string user_name, int top_num, string action_type)
        {
            return dal.GetModel(user_name, top_num, action_type);
        }

        /// <summary>
        /// 不需要判断条件
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="top_num"></param>
        /// <returns></returns>
        public Model.UserLogModel GetModel(string user_name, int top_num)
        {
            return dal.GetModel(user_name, top_num);
        }

        /// <summary>
        /// 删除7天前的日志数据
        /// </summary>
        /// <param name="dayCount"></param>
        /// <returns></returns>
        public int DeleteByDay(int dayCount)
        {
            return dal.DeleteByDay(dayCount);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion  Method
    }
}