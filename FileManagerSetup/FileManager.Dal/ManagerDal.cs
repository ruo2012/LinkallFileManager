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
    /// 数据访问类:管理员
    /// </summary>
    public partial class ManagerDal
    {
        private string databaseprefix; //数据库表名前缀
        public ManagerDal(string _databaseprefix)
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
            strSql.Append("select count(1) from " + databaseprefix + "User");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool TestDbLink(int id, string conn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "User");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), conn, parameters);
        }

        /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        public bool Exists(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "User");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据用户名取得Salt
        /// </summary>
        public string GetSalt(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 salt from " + databaseprefix + "User");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            string salt = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(salt))
            {
                return "";
            }
            return salt;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.UserModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "User(");
            strSql.Append("RoleId,RoleType,RoleName,UserName,Password,RealName,Email,Tel,IsLock,ClientIp,ClientPath,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@RoleId,@RoleType,@RoleName,@UserName,@Password,@RealName,@Email,@Tel,@IsLock,@ClientIp,@ClientPath,@AddTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleId", SqlDbType.Int,4),
					new SqlParameter("@RoleType", SqlDbType.NVarChar,100),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,100),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Password", SqlDbType.NVarChar,100),
					new SqlParameter("@RealName", SqlDbType.NVarChar,200),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Tel", SqlDbType.NVarChar,100),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@ClientIp", SqlDbType.NVarChar,100),
					new SqlParameter("@ClientPath", SqlDbType.NVarChar,500),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)
                 };
            parameters[0].Value = model.RoleId;
            parameters[1].Value = model.RoleType;
            parameters[2].Value = model.RoleName;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.Password;
            parameters[5].Value = model.RealName;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.Tel;
            parameters[8].Value = model.IsLock;
            parameters[9].Value = model.ClientIp;
            parameters[10].Value = model.ClientPath;
            parameters[11].Value = model.AddTime;
            parameters[12].Value = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //账号监控工程信息
            if (model.Projects != null)
            {
                StringBuilder strSql3;
                foreach (Model.UserProjectModel modelt in model.Projects)
                {
                    strSql3 = new StringBuilder();
                    strSql3.Append("insert into " + databaseprefix + "UserProject(");
                    strSql3.Append("UserName,IsLock,ProjectName,ClientIp,MonitoringPath,MonitoringSoftwareName,AddTime)");
                    strSql3.Append(" values (");
                    strSql3.Append("@UserName,@IsLock,@ProjectName,@ClientIp,@MonitoringPath,@MonitoringSoftwareName,@AddTime)");
                    SqlParameter[] parameters3 = {
					    new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					    new SqlParameter("@IsLock", SqlDbType.TinyInt),
					    new SqlParameter("@ProjectName", SqlDbType.NVarChar,100),
					    new SqlParameter("@ClientIp", SqlDbType.NVarChar,100),
					    new SqlParameter("@MonitoringPath", SqlDbType.NVarChar,1000),
					    new SqlParameter("@MonitoringSoftwareName", SqlDbType.NVarChar,100),
					    new SqlParameter("@AddTime", SqlDbType.DateTime),
                             };
                    parameters3[0].Value = model.UserName;
                    parameters3[1].Value = modelt.IsLock;
                    parameters3[2].Value = modelt.ProjectName;
                    parameters3[3].Value = modelt.ClientIp;
                    parameters3[4].Value = modelt.MonitoringPath;
                    parameters3[5].Value = modelt.MonitoringSoftwareName;
                    parameters3[6].Value = modelt.AddTime;
                    cmd = new CommandInfo(strSql3.ToString(), parameters3);
                    sqllist.Add(cmd);
                }
            }

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            int obj = (int)parameters[12].Value;
            //object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.UserModel model)
        {
            //RoleId,RoleType,RoleName,UserName,Password,RealName,Email,Tel,IsLock,ClientIp,ClientPath,AddTime
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        #region  基本信息修改
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update " + databaseprefix + "User set ");
                        strSql.Append("RoleId=@RoleId,");
                        strSql.Append("RoleType=@RoleType,");
                        strSql.Append("RoleName=@RoleName,");
                        strSql.Append("UserName=@UserName,");
                        strSql.Append("Password=@Password,");
                        strSql.Append("RealName=@RealName,");
                        strSql.Append("Email=@Email,");
                        strSql.Append("Tel=@Tel,");
                        strSql.Append("IsLock=@IsLock,");
                        strSql.Append("ClientIp=@ClientIp,");
                        strSql.Append("ClientPath=@ClientPath,");
                        strSql.Append("AddTime=@AddTime");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					        new SqlParameter("@id", SqlDbType.Int,4),
					        new SqlParameter("@RoleId", SqlDbType.Int,4),
					        new SqlParameter("@RoleType", SqlDbType.Int,4),
					        new SqlParameter("@RoleName", SqlDbType.NVarChar,100),
					        new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					        new SqlParameter("@Password", SqlDbType.NVarChar,100),
					        new SqlParameter("@RealName", SqlDbType.NVarChar,100),
					        new SqlParameter("@Email", SqlDbType.NVarChar,100),
					        new SqlParameter("@Tel", SqlDbType.NVarChar,100),
					        new SqlParameter("@IsLock", SqlDbType.Int,4),
					        new SqlParameter("@ClientIp",SqlDbType.NVarChar,100),
					        new SqlParameter("@ClientPath", SqlDbType.NVarChar,500),
					        new SqlParameter("@AddTime", SqlDbType.DateTime),
                         };
                        parameters[0].Value = model.ID;
                        parameters[1].Value = model.RoleId;
                        parameters[2].Value = model.RoleType;
                        parameters[3].Value = model.RoleName;
                        parameters[4].Value = model.UserName;
                        parameters[5].Value = model.Password;
                        parameters[6].Value = model.RealName;
                        parameters[7].Value = model.Email;
                        parameters[8].Value = model.Tel;
                        parameters[9].Value = model.IsLock;
                        parameters[10].Value = model.ClientIp;
                        parameters[11].Value = model.ClientPath;
                        parameters[12].Value = model.AddTime;
                        //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                        #endregion

                        #region 用户工程信息修改
                        //删除已删除的工程
                        new UserProjectDal(databaseprefix).DeleteList(conn, trans, model.Projects, model.UserName);
                        //添加/修改工程
                        if (model.Projects != null)
                        {
                            StringBuilder strSql3;
                            foreach (Model.UserProjectModel modelt in model.Projects)
                            {
                                strSql3 = new StringBuilder();
                                if (modelt.ID > 0)
                                {
                                    strSql3.Append("update " + databaseprefix + "UserProject set ");
                                    strSql3.Append("UserName=@UserName,");
                                    strSql3.Append("IsLock=@IsLock,");
                                    strSql3.Append("ProjectName=@ProjectName,");
                                    strSql3.Append("ClientIp=@ClientIp,");
                                    strSql3.Append("MonitoringPath=@MonitoringPath,");
                                    strSql3.Append("MonitoringSoftwareName=@MonitoringSoftwareName,");
                                    strSql3.Append("AddTime=@AddTime");
                                    strSql3.Append(" where id=@id");
                                    SqlParameter[] parameters3 = {
					                        new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					                        new SqlParameter("@IsLock", SqlDbType.TinyInt),
					                        new SqlParameter("@ProjectName", SqlDbType.NVarChar,100),
					                        new SqlParameter("@ClientIp", SqlDbType.NVarChar,100),
                                            new SqlParameter("@MonitoringPath", SqlDbType.NVarChar,2000),
                                            new SqlParameter("@MonitoringSoftwareName", SqlDbType.NVarChar,100),
                                            new SqlParameter("@AddTime", SqlDbType.DateTime),
                                            new SqlParameter("@id", SqlDbType.Int),
                                         };
                                    parameters3[0].Value = model.UserName;
                                    parameters3[1].Value = modelt.IsLock;
                                    parameters3[2].Value = modelt.ProjectName;
                                    parameters3[3].Value = modelt.ClientIp;
                                    parameters3[4].Value = modelt.MonitoringPath;
                                    parameters3[5].Value = modelt.MonitoringSoftwareName;
                                    parameters3[6].Value = modelt.AddTime;
                                    parameters3[7].Value = modelt.ID;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);
                                }
                                else
                                {
                                    strSql3.Append("insert into " + databaseprefix + "UserProject(");
                                    strSql3.Append("UserName,IsLock,ProjectName,ClientIp,MonitoringPath,MonitoringSoftwareName,AddTime)");
                                    strSql3.Append(" values (");
                                    strSql3.Append("@UserName,@IsLock,@ProjectName,@ClientIp,@MonitoringPath,@MonitoringSoftwareName,@AddTime)");
                                    SqlParameter[] parameters3 = {
					                        new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					                        new SqlParameter("@IsLock", SqlDbType.TinyInt),
					                        new SqlParameter("@ProjectName", SqlDbType.NVarChar,100),
					                        new SqlParameter("@ClientIp", SqlDbType.NVarChar,100),
                                            new SqlParameter("@MonitoringPath", SqlDbType.NVarChar,2000),
                                            new SqlParameter("@MonitoringSoftwareName", SqlDbType.NVarChar,100),
                                            new SqlParameter("@AddTime", SqlDbType.DateTime)
                                   };
                                    parameters3[0].Value = model.UserName;
                                    parameters3[1].Value = modelt.IsLock;
                                    parameters3[2].Value = modelt.ProjectName;
                                    parameters3[3].Value = modelt.ClientIp;
                                    parameters3[4].Value = modelt.MonitoringPath;
                                    parameters3[5].Value = modelt.MonitoringSoftwareName;
                                    parameters3[6].Value = modelt.AddTime;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);
                                }
                            }
                        }

                        #endregion
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "User set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "User ");
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
        public Model.UserModel GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from " + databaseprefix + "User ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.UserModel model = new Model.UserModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //RoleId,RoleType,RoleName,UserName,Password,RealName,Email,Tel,IsLock,ClientIp,ClientPath,AddTime
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleId"].ToString() != "")
                {
                    model.RoleId = int.Parse(ds.Tables[0].Rows[0]["RoleId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleType"].ToString() != "")
                {
                    model.RoleType = int.Parse(ds.Tables[0].Rows[0]["RoleType"].ToString());
                }
                model.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                model.ClientIp = ds.Tables[0].Rows[0]["ClientIp"].ToString();
                if (ds.Tables[0].Rows[0]["ClientPath"].ToString() != "")
                {
                    model.ClientPath = ds.Tables[0].Rows[0]["ClientPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }

                //账户工程信息
                model.Projects = new UserProjectDal(databaseprefix).GetList(model.UserName);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户名返回一个实体
        /// </summary>
        public Model.UserModel GetModel(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from " + databaseprefix + "User");
            strSql.Append(" where UserName=@UserName and islock=0");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                     　};
            parameters[0].Value = user_name;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                int id = Convert.ToInt32(obj);
                Model.UserModel model = GetModel(id);
                //账户工程信息
                model.Projects = new UserProjectDal(databaseprefix).GetList(model.UserName);
                return model;
            }
            return null;
        }

        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.UserModel GetModel(string user_name, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from " + databaseprefix + "User");
            strSql.Append(" where UserName=@UserName and password=@password and IsLock=0");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@password", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            parameters[1].Value = password;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
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
            strSql.Append(" FROM " + databaseprefix + "User ");
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
        public List<Model.UserModel> GetModelList(int Top, string strWhere, string filedOrder)
        {
            List<Model.UserModel> modelList = new List<Model.UserModel>();
            DataSet ds = GetList(Top, strWhere, filedOrder);
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
        private Model.UserModel GetModelByDataRow(DataRow item)
        {
            Model.UserModel model = new Model.UserModel();

            if (item["id"].ToString() != "")
            {
                model.ID = int.Parse(item["id"].ToString());
            }
            if (item["RoleId"].ToString() != "")
            {
                model.RoleId = int.Parse(item["RoleId"].ToString());
            }
            if (item["RoleType"].ToString() != "")
            {
                model.RoleType = int.Parse(item["RoleType"].ToString());
            }
            model.RoleName = item["RoleName"].ToString();
            model.UserName = item["UserName"].ToString();
            model.Password = item["Password"].ToString();
            model.RealName = item["RealName"].ToString();
            model.Email = item["Email"].ToString();
            model.Tel = item["Tel"].ToString();
            model.IsLock = int.Parse(item["IsLock"].ToString());
            model.ClientIp = item["ClientIp"].ToString();
            if (item["ClientPath"].ToString() != "")
            {
                model.ClientPath = item["ClientPath"].ToString();
            }
            if (item["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(item["AddTime"].ToString());
            }
            return model;
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "User");
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