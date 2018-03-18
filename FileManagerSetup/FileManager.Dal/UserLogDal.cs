using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FileManager.DBUtility;
using FileManager.Common;
using System.Collections.Generic;

namespace FileManager.DAL
{
    /// <summary>
    /// 数据访问类:用户操作日志
    /// </summary>
    public partial class UserLogDal
    {
        private string databaseprefix; //数据库表名前缀
        public UserLogDal(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "UserLog");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回数据数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from " + databaseprefix + "UserLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.UserLogModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "UserLog(");
            strSql.Append("[UserID],[UserName],[UserRealName],[ActionType],ActionName,[Remark],[Ip],[ProjectID],[ProjectName],[ProjectPath],[ClientPath],[AddTime],[ActionCode])");
            strSql.Append(" values (");
            strSql.Append("@UserID,@UserName,@UserRealName,@ActionType,@ActionName,@Remark,@Ip,@ProjectID,@ProjectName,@ProjectPath,@ClientPath,@AddTime,@ActionCode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@UserRealName", SqlDbType.NVarChar,100),
					new SqlParameter("@ActionType", SqlDbType.NVarChar,100),
					new SqlParameter("@ActionName", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,1000),
					new SqlParameter("@Ip", SqlDbType.NVarChar,200),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@ProjectName", SqlDbType.NVarChar,100),
					new SqlParameter("@ProjectPath", SqlDbType.NVarChar,2000),
					new SqlParameter("@ClientPath", SqlDbType.NVarChar,2000),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@ActionCode", SqlDbType.NVarChar),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)
                 };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserRealName;
            parameters[3].Value = model.ActionType;
            parameters[4].Value = model.ActionName;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.Ip;
            parameters[7].Value = model.ProjectID;
            parameters[8].Value = model.ProjectName;
            parameters[9].Value = model.ProjectPath;
            parameters[10].Value = model.ClientPath;
            parameters[11].Value = model.AddTime;
            parameters[12].Value = model.ActionCode;
            parameters[13].Value = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            int obj =(int)parameters[13].Value;
           
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "UserLog ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

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
        /// 得到一个对象实体
        /// </summary>
        public Model.UserLogModel GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from " + databaseprefix + "UserLog ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.UserLogModel model = new Model.UserLogModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = GetModelByDataRow(ds.Tables[0].Rows[0]);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取指定数量的IP
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public List<string> GetLogIps(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append("   distinct  top " + Top.ToString());
            }
            strSql.Append("  IP ");
            strSql.Append(" FROM " + databaseprefix + "UserLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            //strSql.Append(" order by " + filedOrder);
            DataSet ds =  DbHelperSQL.Query(strSql.ToString());

            List<string> ips = new List<string>();
            if (ds != null && ds.Tables != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        string ipItem = item["ip"].ToString();
                        ips.Add(ipItem);
                    }
                }
            }
            return ips;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM " + databaseprefix + "UserLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
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
            List<Model.UserLogModel> modelList = new List<Model.UserLogModel>();
            DataSet ds = GetList(Top,strWhere,filedOrder);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    modelList.Add(GetModelByDataRow(item));
                }
            }
            return modelList;
        }

        /// <summary>
        /// 转化为model
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Model.UserLogModel GetModelByDataRow(DataRow item)
        {
            Model.UserLogModel model = new Model.UserLogModel();
            //[UserID],[UserName],[UserRealName],[ActionType],[Remark],[Ip],[ProjectID],[ProjectName],[ProjectPath],[ClientPath],[AddTime]
            if (item["id"].ToString() != "")
            {
                model.ID = int.Parse(item["id"].ToString());
            }
            if (item["UserID"].ToString() != "")
            {
                model.UserID = int.Parse(item["UserID"].ToString());
            }
            if (item["UserName"].ToString() != "")
            {
                model.UserName =  item["UserName"].ToString();
            }
            model.UserRealName = item["UserRealName"].ToString();
            model.ActionType = item["ActionType"].ToString();
            model.ActionName = item["ActionName"].ToString();
            model.Remark = item["Remark"].ToString();
            model.Ip = item["Ip"].ToString();
            model.ProjectID = int.Parse(item["ProjectID"].ToString());
            model.ProjectName = item["ProjectName"].ToString();
            model.ProjectPath = item["ProjectPath"].ToString();
            model.ClientPath = item["ClientPath"].ToString();
            model.ActionCode = item["ActionCode"].ToString();
            
            if (item["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(item["AddTime"].ToString());
            }
            return model;
        }

        /// <summary>
        /// 根据用户名返回上一次登录记录
        /// </summary>
        public Model.UserLogModel GetModel(string user_name, int top_num, string action_type)
        {
            int rows = GetCount("UserName='" + user_name + "'");
            if (top_num == 1)
            {
                rows = 2;
            }
            if (rows > 1)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 id from (select top " + top_num + " id from " + databaseprefix
                    + "manager_log where UserName=@user_name and ActionType=@action_type order by id desc) as T ");
                strSql.Append(" order by id asc");
                SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                    new SqlParameter("@action_type", SqlDbType.NVarChar,100)};
                parameters[0].Value = user_name;
                parameters[1].Value = action_type;

                object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
                if (obj != null)
                {
                    return GetModel(Convert.ToInt32(obj));
                }
            }
            return null;
        }

        /// <summary>
        /// 根据用户名返回上一次登录记录
        /// </summary>
        public Model.UserLogModel GetModel(string user_name, int top_num)
        {
            int rows = GetCount("UserName='" + user_name + "'");
            if (top_num == 1)
            {
                rows = 2;
            }
            if (rows > 1)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 id from (select top " + top_num + " id from " + databaseprefix
                    + "UserLog where UserName=@user_name  order by id desc) as T ");
                strSql.Append(" order by id asc");
                SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100) };
                parameters[0].Value = user_name;

                object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
                if (obj != null)
                {
                    return GetModel(Convert.ToInt32(obj));
                }
            }
            return null;
        }


        /// <summary>
        /// 删除7天前的日志数据
        /// </summary>
        public int DeleteByDay(int dayCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "UserLog ");
            strSql.Append(" where DATEDIFF(day, AddTime, getdate()) > " + dayCount);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "UserLog");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method
    }
}