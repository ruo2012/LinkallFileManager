using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using FileManager.DBUtility;
using FileManager.Common;

namespace FileManager.DAL
{
    /// <summary>
    /// 数据访问类:用户工程信息
    /// </summary>
    public partial class UserProjectDal
    {
        private string databaseprefix; //数据库表名前缀
        public UserProjectDal(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法========================================

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "UserProject");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="projectName">项目名称</param>
        /// <param name="monitoringPath">监控客户端路径</param>
        /// <param name="userName">用户账号</param>
        /// <returns></returns>
        public int GetForderId(string projectName, string monitoringPath, string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from " + databaseprefix + "UserProject");
            strSql.Append(" where userName=@userName and (monitoringPath=@monitoringPath or projectName = @projectName)");
            SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,200),
					new SqlParameter("@monitoringPath", SqlDbType.VarChar,1000),
					new SqlParameter("@projectName", SqlDbType.VarChar,200),
                                        };
            parameters[0].Value = userName;
            parameters[1].Value = projectName;
            parameters[2].Value = monitoringPath;

            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
        }

        /// <summary>
        /// 返回工程名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ProjectName from " + databaseprefix + "UserProject");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.UserProjectModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "User set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("ProjectName=@ProjectName,");
            strSql.Append("ClientIp=@ClientIp,");
            strSql.Append("MonitoringPath=@MonitoringPath,");
            strSql.Append("MonitoringSoftwareName=@MonitoringSoftwareName,");
            strSql.Append("AddTime=@AddTime,");

            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@ProjectName", SqlDbType.NVarChar,100),
					new SqlParameter("@ClientIp", SqlDbType.NVarChar,100),
					new SqlParameter("@MonitoringPath", SqlDbType.NVarChar,1000),
					new SqlParameter("@MonitoringSoftwareName", SqlDbType.NVarChar,100),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					 
               };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.IsLock;
            parameters[3].Value = model.ProjectName;
            parameters[4].Value = model.ClientIp;
            parameters[5].Value = model.MonitoringPath;
            parameters[6].Value = model.MonitoringSoftwareName;
            parameters[7].Value = model.AddTime;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "UserProject set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.UserProjectModel> GetList(string userName)
        {
            List<Model.UserProjectModel> modelList = new List<Model.UserProjectModel>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM " + databaseprefix + "UserProject ");
            strSql.Append(string.Format(" where UserName= '{0}'", userName));
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.UserProjectModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.UserProjectModel();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["UserName"] != null && dt.Rows[n]["UserName"].ToString() != "")
                    {
                        model.UserName = dt.Rows[n]["UserName"].ToString();
                    }
                    if (dt.Rows[n]["IsLock"] != null && dt.Rows[n]["IsLock"].ToString() != "")
                    {
                        model.IsLock = int.Parse(dt.Rows[n]["IsLock"].ToString());
                    }
                    if (dt.Rows[n]["ProjectName"] != null && dt.Rows[n]["ProjectName"].ToString() != "")
                    {
                        model.ProjectName = dt.Rows[n]["ProjectName"].ToString();
                    }
                    if (dt.Rows[n]["ClientIp"] != null && dt.Rows[n]["ClientIp"].ToString() != "")
                    {
                        model.ClientIp = dt.Rows[n]["ClientIp"].ToString();
                    }
                    if (dt.Rows[n]["MonitoringPath"] != null && dt.Rows[n]["MonitoringPath"].ToString() != "")
                    {
                        model.MonitoringPath = dt.Rows[n]["MonitoringPath"].ToString();
                    }
                    if (dt.Rows[n]["MonitoringSoftwareName"] != null && dt.Rows[n]["MonitoringSoftwareName"].ToString() != "")
                    {
                        model.MonitoringSoftwareName = dt.Rows[n]["MonitoringSoftwareName"].ToString();
                    }
                    if (dt.Rows[0]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[0]["AddTime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "UserProject ");
            strSql.Append(" where class_list like '%," + id + ",%' ");
            DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.UserProjectModel GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from " + databaseprefix + "UserProject ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.UserProjectModel model = new Model.UserProjectModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }

                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsLock"] != null && ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProjectName"] != null && ds.Tables[0].Rows[0]["ProjectName"].ToString() != "")
                {
                    model.ProjectName = ds.Tables[0].Rows[0]["ProjectName"].ToString();
                }
                model.ClientIp = ds.Tables[0].Rows[0]["ClientIp"].ToString();
                model.MonitoringPath = ds.Tables[0].Rows[0]["MonitoringPath"].ToString();
                model.MonitoringSoftwareName = ds.Tables[0].Rows[0]["MonitoringSoftwareName"].ToString();

                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 查找不存在的工程并删除已删除的工程及数据
        /// </summary>
        public void DeleteList(SqlConnection conn, SqlTransaction trans, List<Model.UserProjectModel> models, string user_name)
        {
            StringBuilder idList = new StringBuilder();
            if (models != null)
            {
                foreach (Model.UserProjectModel modelt in models)
                {
                    if (modelt.ID > 0)
                    {
                        idList.Append(modelt.ID + ",");
                    }
                }
            }
            string id_list = Utils.DelLastChar(idList.ToString(), ",");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,MonitoringSoftwareName from " + databaseprefix + "UserProject where UserName=" + string.Concat("'" + user_name + "'"));
            if (!string.IsNullOrEmpty(id_list))
            {
                strSql.Append(" and id not in(" + id_list + ")");
            }
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int rows = DbHelperSQL.ExecuteSql(conn, trans, "delete from " + databaseprefix + "UserProject where id=" + dr["id"].ToString()); //删除数据库
                if (rows > 0)
                {
                    //Utils.DeleteFile(dr["original_path"].ToString()); //删除原图
                }
            }
        }

        /// <summary>
        /// 删除相册图片
        /// </summary>
        public void DeleteFile(List<Model.UserProjectModel> models)
        {
            if (models != null)
            {
                foreach (Model.UserProjectModel modelt in models)
                {
                    // Utils.DeleteFile(modelt.thumb_path);
                    //Utils.DeleteFile(modelt.original_path);
                }
            }
        }

        #endregion
    }
}