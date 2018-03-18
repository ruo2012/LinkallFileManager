using System;
using System.Data;
using System.Collections.Generic;
using  FileManager.DAL;

namespace FileManager.BLL
{
    /// <summary>
    /// 管理日志
    /// </summary>
    public partial class FileVersionBll
    {
        private readonly FileVersionDal dal;
        public FileVersionBll()
        {
            dal = new FileVersionDal("FM_");
        }

        #region 基本方法==============================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        ///// <summary>
        ///// 获取文件最新的版本
        ///// </summary>
        ///// <param name="fileName"></param>
        ///// <param name="forderId"></param>
        ///// <returns></returns>
        //public int GetFileLastVer(string fileName, int forderId)
        //{
        //    return dal.GetFileLastVer(fileName, forderId);
        //}

        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.FileVersion model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.FileVersion GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public byte[] GetContent(int id)
        {
            return dal.GetContent(id);
        }

 
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList( string strWhere, string filedOrder)
        {
            return dal.GetList( strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion
    }
}
