using System;
using System.Data;
using System.Collections.Generic;
using FileManager.Common;

namespace FileManager.BLL
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public partial class ManagerBll
    {
        private readonly DAL.ManagerDal dal;
        public ManagerBll()
        {
            dal = new DAL.ManagerDal("FM_");
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
        /// 数据库测试
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool TestDbLink(int id,string conn)
        {
            return dal.TestDbLink(id, conn);
        }

        /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        public bool Exists(string user_name)
        {
            return dal.Exists(user_name);
        }

        /// <summary>
        /// 根据用户名取得Salt
        /// </summary>
        public string GetSalt(string user_name)
        {
            return dal.GetSalt(user_name);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.UserModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.UserModel model)
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.UserModel GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.UserModel GetModel(string user_name, string password)
        {
            return dal.GetModel(user_name, password);
        }

        /// <summary>
        /// 根据用户名返回一个实体
        /// </summary>
        public Model.UserModel GetModel(string user_name )
        {
            return dal.GetModel(user_name);
        }

        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.UserModel GetModel(string user_name, string password, bool is_encrypt)
        {
            //检查一下是否需要加密
            if (is_encrypt)
            {
                //先取得该用户的密钥
                string salt = "FM_123456";
                //把明文进行加密重新赋值
                password = DESEncrypt.Encrypt(password, salt);
            }
            return dal.GetModel(user_name, password);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public List<Model.UserModel> GetModelList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetModelList(Top, strWhere, filedOrder);
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