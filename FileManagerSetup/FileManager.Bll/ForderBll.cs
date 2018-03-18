using System;
using System.Data;
using System.Collections.Generic;
using FileManager.DAL;

namespace FileManager.BLL
{
    /// <summary>
    /// 类别业务类
    /// </summary>
    public partial class ForderBll
    {
        private readonly DAL.ForderDal dal;
        public ForderBll()
        {
            dal = new DAL.ForderDal("FM_");
        }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="forderName"></param>
        /// <returns></returns>
        public int GetForderId(int parentId, string forderName, string userName, int projectId)
        {
            return dal.GetForderId(parentId, forderName, userName, projectId);
        }

        /// <summary>
        /// 返回类别名称
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.ForderModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.ForderModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ForderModel GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 取得指定类别下的列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetChildList(int parent_id, int channel_id)
        {
            return dal.GetChildList(parent_id, channel_id);
        }

        /// <summary>
        /// 取得指定类别下的列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_name">频道名称</param>
        /// <returns></returns>
        public DataTable GetChildList(int parent_id)
        {
            return dal.GetChildList(parent_id, 0);
        }

        /// <summary>
        /// 取得所有类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetList(int parent_id)
        {
            return dal.GetList(parent_id);
        }

        /// <summary>
        /// 获取所有频道，所有分类
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllList()
        {
            return dal.GetAllList();
        }

        /// <summary>
        /// 获取所有子文件夹
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.ForderModel> GetSubForders(int id,int projectId)
        {
            return dal.GetSubForders(id, projectId);
        }

        /// <summary>
        /// 获取所有子文件
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldOrder"></param>
        /// <returns></returns>
        public List<Model.FileModel> GetSubFiles(int id, int projectId,string fieldOrder)
        {
            return dal.GetSubFiles(id,  projectId,fieldOrder);
        }

        public List<Model.ForderModel> GetForderPath(int id)
        {
            return dal.GetForderPath(id);
        }

        #region 扩展方法================================
        /// <summary>
        /// 取得父节点的ID
        /// </summary>
        public int GetParentId(int id)
        {
            return dal.GetParentId(id);
        }
        #endregion

        #endregion
    }
}