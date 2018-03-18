using System;
using System.Data;
using System.Collections.Generic;
using  FileManager.DAL;

namespace FileManager.BLL
{
    /// <summary>
    /// 管理日志
    /// </summary>
    public partial class FileBll
    {
        //private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly FileDal dal;
        public FileBll()
        {
            dal = new FileDal("FM_");
        }

        #region 基本方法==============================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        public int GetFileID(int forderID,string fileName,string fileMd5)
        {
            return dal.GetFileID(forderID, fileName, fileMd5);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.FileModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="forderID"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public int UpdateFile(int forderID, string fileName)
        {
            return dal.UpdateFile(forderID, fileName);
        }

        /// <summary>
        /// 获取文件最新的版本
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="forderId"></param>
        /// <returns></returns>
        public int GetFileLastVer(string fileName, int forderId)
        {
            return dal.GetFileLastVer(fileName, forderId);
        }

        public int GetFileLastVer( int fileId,DateTime lastModifyTime)
        {
            return dal.GetFileLastVer( fileId, lastModifyTime);
        }

        public Model.FileVersion GetFileLastVer(int fileId)
        {
            return dal.GetFileLastVer(fileId);
        }

        ///// <summary>
        ///// 获取文件最新的版本
        ///// </summary>
        ///// <param name="fileName"></param>
        ///// <param name="forderId"></param>
        ///// <returns></returns>
        //public Model.FileModel GetFileLastVer(string fileName, List<string> forders)
        //{
        //    return dal.GetFileLastVer(fileName, forders);
        //}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.FileModel model)
        {
            return dal.Add(model);
        }
         
   

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.FileModel GetModel( int id)
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
        /// 文件搜索【最多显示1000个】
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public List<Model.FileModel> SearchList(int top, string strWhere, string filedOrder)
        {
            return dal.SearchList(top, strWhere, filedOrder);
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
