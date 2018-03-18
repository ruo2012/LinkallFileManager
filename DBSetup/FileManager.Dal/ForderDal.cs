using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using FileManager.DBUtility;

namespace FileManager.DAL
{
    /// <summary>
    /// 数据访问类:内容类别
    /// </summary>
    public partial class ForderDal
    {
        private string databaseprefix; //数据库表名前缀
        public ForderDal(string _databaseprefix)
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
            strSql.Append("select count(1) from " + databaseprefix + "Forder");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public int GetForderId(int parentId, string forderName, string userName, int projectId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from " + databaseprefix + "Forder");
            strSql.Append(" where Parent_Id=@Parent_Id and Title=@Title and Project_Id=@Project_Id and isdeleted = 0");
            SqlParameter[] parameters = {
					new SqlParameter("@Parent_Id", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,200),
					new SqlParameter("@Project_Id", SqlDbType.Int,4),
                     };
            parameters[0].Value = parentId;
            parameters[1].Value = forderName;
            parameters[2].Value = projectId;

            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
        }

        /// <summary>
        /// 返回类别名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from " + databaseprefix + "Forder");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.ForderModel model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into " + databaseprefix + "Forder(");
                        strSql.Append("[Title],[Call_Index],UserName,Project_Id,[Parent_Id],[Class_List],[Class_Layer],[Sort_Id],[Image],[Remark],ClientPath,[Forder_Modify_Time],Add_Time)");
                        strSql.Append(" values (");
                        strSql.Append("@Title,@Call_Index,@UserName,@Project_Id,@Parent_Id,@Class_List,@Class_Layer,@Sort_Id,@Image,@Remark,@ClientPath,@Forder_Modify_Time,@Add_Time)");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
					            new SqlParameter("@Title", SqlDbType.NVarChar,200),
					            new SqlParameter("@Call_Index", SqlDbType.NVarChar,200),
                                new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                                new SqlParameter("@Project_Id", SqlDbType.Int),
                                new SqlParameter("@Parent_Id", SqlDbType.Int),
					            new SqlParameter("@Class_List", SqlDbType.NVarChar,500),
					            new SqlParameter("@Class_Layer", SqlDbType.Int),
					            new SqlParameter("@Sort_Id", SqlDbType.Int),
					            new SqlParameter("@Image", SqlDbType.VarBinary),
					            new SqlParameter("@Remark", SqlDbType.NVarChar,2000),
					            new SqlParameter("@ClientPath", SqlDbType.NVarChar,2000),
					            new SqlParameter("@Forder_Modify_Time", SqlDbType.BigInt),
					            new SqlParameter("@Add_Time", SqlDbType.DateTime),
					        };
                        parameters[0].Value = model.Title;
                        parameters[1].Value = model.Call_Index;
                        parameters[2].Value = model.UserName;
                        parameters[3].Value = model.Project_Id;
                        parameters[4].Value = model.Parent_Id;
                        parameters[5].Value = model.Class_List;
                        parameters[6].Value = model.Class_Layer;
                        parameters[7].Value = model.Sort_Id;
                        parameters[8].Value = model.Image;
                        parameters[9].Value = model.Remark;
                        parameters[10].Value = model.ClientPath;
                        parameters[11].Value = model.Forder_Modify_Time;
                        parameters[12].Value = model.Add_Time;

                        object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters); //带事务
                        model.ID = Convert.ToInt32(obj);

                        if (model.Parent_Id > 0)
                        {
                            Model.ForderModel model2 = GetModel(conn, trans, model.Parent_Id); //带事务
                            model.Class_List = model2.Class_List + model.ID + ",";
                            model.Class_Layer = model2.Class_Layer + 1;
                        }
                        else
                        {
                            model.Class_List = "," + model.ID + ",";
                            model.Class_Layer = 1;
                        }
                        //修改节点列表和深度
                        DbHelperSQL.ExecuteSql(conn, trans, "update " + databaseprefix + "Forder set class_list='" + model.Class_List + "', class_layer=" + model.Class_Layer + " where id=" + model.ID); //带事务
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }
            return model.ID;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Forder set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.ForderModel model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //先判断选中的父节点是否被包含
                        if (IsContainNode(model.ID, model.Parent_Id))
                        {
                            //查找旧数据
                            Model.ForderModel oldModel = GetModel(model.ID);
                            //查找旧父节点数据
                            string class_list = "," + model.Parent_Id + ",";
                            int class_layer = 1;
                            if (oldModel.Parent_Id > 0)
                            {
                                Model.ForderModel oldParentModel = GetModel(conn, trans, oldModel.Parent_Id); //带事务
                                class_list = oldParentModel.Class_List + model.Parent_Id + ",";
                                class_layer = oldParentModel.Class_Layer + 1;
                            }
                            //先提升选中的父节点
                            DbHelperSQL.ExecuteSql(conn, trans, "update " + databaseprefix + "Forder set parent_id=" + oldModel.Parent_Id + ",class_list='" + class_list + "', class_layer=" + class_layer + " where id=" + model.Parent_Id); //带事务
                            UpdateChilds(conn, trans, model.Parent_Id); //带事务
                        }
                        //更新子节点
                        if (model.Parent_Id > 0)
                        {
                            Model.ForderModel model2 = GetModel(conn, trans, model.Parent_Id); //带事务
                            model.Class_List = model2.Class_List + model.ID + ",";
                            model.Class_Layer = model2.Class_Layer + 1;
                        }
                        else
                        {
                            model.Class_List = "," + model.ID + ",";
                            model.Class_Layer = 1;
                        }

                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update " + databaseprefix + "Forder set ");
                        strSql.Append("title=@title,");
                        strSql.Append("call_index=@call_index,");
                        strSql.Append("UserName=@UserName,");
                        strSql.Append("parent_id=@parent_id,");
                        strSql.Append("class_list=@class_list,");
                        strSql.Append("class_layer=@class_layer,");
                        strSql.Append("Image=@Image,");
                        strSql.Append("remark=@remark,");
                        strSql.Append("Forder_Modify_Time=@Forder_Modify_Time,");
                        strSql.Append("Add_Time=@Add_Time");

                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					            new SqlParameter("@Title", SqlDbType.NVarChar,100),
                                new SqlParameter("@Call_Index", SqlDbType.NVarChar,50),
                                new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					            new SqlParameter("@parent_id", SqlDbType.Int,4),
					            new SqlParameter("@class_list", SqlDbType.NVarChar,500),
					            new SqlParameter("@class_layer", SqlDbType.Int,4),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
					            new SqlParameter("@Image", SqlDbType.VarBinary),
					            new SqlParameter("@remark", SqlDbType.NText),
					            new SqlParameter("@Forder_Modify_Time", SqlDbType.BigInt),
					            new SqlParameter("@Add_Time", SqlDbType.DateTime),
					            new SqlParameter("@id", SqlDbType.Int,4)};

                        parameters[0].Value = model.Title;
                        parameters[1].Value = model.Call_Index;
                        parameters[2].Value = model.UserName;
                        parameters[3].Value = model.Parent_Id;
                        parameters[4].Value = model.Class_List;
                        parameters[5].Value = model.Class_Layer;
                        parameters[6].Value = model.Sort_Id;
                        parameters[7].Value = model.Image;
                        parameters[8].Value = model.Remark;
                        parameters[9].Value = model.Forder_Modify_Time;
                        parameters[10].Value = model.Add_Time;

                        parameters[11].Value = model.ID;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //更新子节点
                        UpdateChilds(conn, trans, model.ID);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "Forder ");
            strSql.Append(" where class_list like '%," + id + ",%' ");
            DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 将文件夹下所有数据设置为已删除状态
        /// </summary>
        public void DeleteAllFile(string userName, int projectId)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update " + databaseprefix + "Forder set ");
                        strSql.Append("IsDeleted=@IsDeleted,");
                        strSql.Append(" where UserName=@UserName and ProjectId=@ProjectId");
                        SqlParameter[] parameters = {
					            new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                                new SqlParameter("@ProjectId", SqlDbType.Int,50),
					             };

                        parameters[0].Value = userName;
                        parameters[1].Value = projectId;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("update " + databaseprefix + "File set ");
                        strSql2.Append("IsDeleted=@IsDeleted,");
                        strSql2.Append(" where UserName=@UserName and Project_Id=@Project_Id");
                        SqlParameter[] parameters2 = {
					            new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                                new SqlParameter("@Project_Id", SqlDbType.Int,50),
					     };

                        parameters[0].Value = userName;
                        parameters[1].Value = projectId;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return;
                    }
                }
            }
            return;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ForderModel GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from " + databaseprefix + "Forder ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.ForderModel model = new Model.ForderModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }

                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["call_index"] != null && ds.Tables[0].Rows[0]["call_index"].ToString() != "")
                {
                    model.Call_Index = ds.Tables[0].Rows[0]["call_index"].ToString();
                }
                if (ds.Tables[0].Rows[0]["parent_id"] != null && ds.Tables[0].Rows[0]["parent_id"].ToString() != "")
                {
                    model.Parent_Id = int.Parse(ds.Tables[0].Rows[0]["parent_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["class_list"] != null && ds.Tables[0].Rows[0]["class_list"].ToString() != "")
                {
                    model.Class_List = ds.Tables[0].Rows[0]["class_list"].ToString();
                }
                if (ds.Tables[0].Rows[0]["class_layer"] != null && ds.Tables[0].Rows[0]["class_layer"].ToString() != "")
                {
                    model.Class_Layer = int.Parse(ds.Tables[0].Rows[0]["class_layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"] != null && ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.Sort_Id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }

                if (ds.Tables[0].Rows[0]["Image"] != null && ds.Tables[0].Rows[0]["Image"].ToString() != "")
                {
                    model.Image = (byte[])ds.Tables[0].Rows[0]["Image"];
                }
                if (ds.Tables[0].Rows[0]["remark"] != null && ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Forder_Modify_Time"] != null && ds.Tables[0].Rows[0]["Forder_Modify_Time"].ToString() != "")
                {
                    model.Forder_Modify_Time =long.Parse( ds.Tables[0].Rows[0]["Forder_Modify_Time"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体(重载，带事务)
        /// </summary>
        public Model.ForderModel GetModel(SqlConnection conn, SqlTransaction trans, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from " + databaseprefix + "Forder ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.ForderModel model = new Model.ForderModel();
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }

                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["call_index"] != null && ds.Tables[0].Rows[0]["call_index"].ToString() != "")
                {
                    model.Call_Index = ds.Tables[0].Rows[0]["call_index"].ToString();
                }
                if (ds.Tables[0].Rows[0]["parent_id"] != null && ds.Tables[0].Rows[0]["parent_id"].ToString() != "")
                {
                    model.Parent_Id = int.Parse(ds.Tables[0].Rows[0]["parent_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["class_list"] != null && ds.Tables[0].Rows[0]["class_list"].ToString() != "")
                {
                    model.Class_List = ds.Tables[0].Rows[0]["class_list"].ToString();
                }
                if (ds.Tables[0].Rows[0]["class_layer"] != null && ds.Tables[0].Rows[0]["class_layer"].ToString() != "")
                {
                    model.Class_Layer = int.Parse(ds.Tables[0].Rows[0]["class_layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"] != null && ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.Sort_Id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }

                if (ds.Tables[0].Rows[0]["Image"] != null && ds.Tables[0].Rows[0]["Image"].ToString() != "")
                {
                    model.Image = (byte[])ds.Tables[0].Rows[0]["Image"];
                }
                if (ds.Tables[0].Rows[0]["remark"] != null && ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Forder_Modify_Time"] != null && ds.Tables[0].Rows[0]["Forder_Modify_Time"].ToString() != "")
                {
                    model.Forder_Modify_Time = long.Parse(ds.Tables[0].Rows[0]["Forder_Modify_Time"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得指定类别下的列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetChildList(int parent_id, int channel_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + databaseprefix + "Forder");
            strSql.Append(" where     parent_id=" + parent_id + " order by sort_id asc,id desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }

        /// <summary>
        /// 取得所有类别列表
        /// </summary>
        /// <param name="parent_id">父ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        public DataTable GetList(int parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from " + databaseprefix + "Forder");
            strSql.Append(" order by sort_id asc,id desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable oldData = ds.Tables[0] as DataTable;
            if (oldData == null)
            {
                return null;
            }
            //复制结构
            DataTable newData = oldData.Clone();
            //调用迭代组合成DAGATABLE
            GetChilds(oldData, newData, parent_id);
            return newData;
        }

        /// <summary>
        /// 获取所有频道，所有分类
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from " + databaseprefix + "Forder");
            strSql.Append(" order by sort_id asc,id desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            return ds.Tables[0];
        }

        /// <summary>
        /// 获取文件夹下的所有子文件夹
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.ForderModel> GetSubForders(int id, int projectId)
        {
            List<Model.ForderModel> subForders = new List<Model.ForderModel>();
            //if (id <= 0) return subForders;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from " + databaseprefix + "Forder  where  IsDeleted=0 and  Parent_Id = " + id + " and Project_Id =" + projectId);
            strSql.Append(" order by sort_id asc,id desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable dt = ds.Tables[0];

            foreach (DataRow item in dt.Rows)
            {
                subForders.Add(ChangeRowToForder(item));
            }

            return subForders;
        }

        /// <summary>
        /// 转化为对象格式
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Model.ForderModel ChangeRowToForder(DataRow row)
        {
            Model.ForderModel model = new Model.ForderModel();
            if (row["id"] != null && row["id"].ToString() != "")
            {
                model.ID = int.Parse(row["id"].ToString());
            }

            if (row["title"] != null && row["title"].ToString() != "")
            {
                model.Title = row["title"].ToString();
            }
            if (row["call_index"] != null && row["call_index"].ToString() != "")
            {
                model.Call_Index = row["call_index"].ToString();
            }
            if (row["UserName"] != null && row["UserName"].ToString() != "")
            {
                model.UserName = row["UserName"].ToString();
            }
            if (row["parent_id"] != null && row["parent_id"].ToString() != "")
            {
                model.Parent_Id = int.Parse(row["parent_id"].ToString());
            }
            if (row["class_list"] != null && row["class_list"].ToString() != "")
            {
                model.Class_List = row["class_list"].ToString();
            }
            if (row["class_layer"] != null && row["class_layer"].ToString() != "")
            {
                model.Class_Layer = int.Parse(row["class_layer"].ToString());
            }
            if (row["sort_id"] != null && row["sort_id"].ToString() != "")
            {
                model.Sort_Id = int.Parse(row["sort_id"].ToString());
            }

            if (row["Image"] != null && row["Image"].ToString() != "")
            {
                model.Image = (byte[])row["Image"];
            }
            if (row["remark"] != null && row["remark"].ToString() != "")
            {
                model.Remark = row["remark"].ToString();
            }
            if (row["ClientPath"] != null && row["ClientPath"].ToString() != "")
            {
                model.ClientPath = row["ClientPath"].ToString();
            }
            if (row["Forder_Modify_Time"] != null && row["Forder_Modify_Time"].ToString() != "")
            {
                model.Forder_Modify_Time = long.Parse(row["Forder_Modify_Time"].ToString());
            }
            if (row["Add_Time"] != null && row["Add_Time"].ToString() != "")
            {
                model.Add_Time = DateTime.Parse(row["Add_Time"].ToString());
            }

            return model;
        }

        /// <summary>
        /// 获取文件夹下的所有子文件
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldOrder"></param>
        /// <returns></returns>
        public List<Model.FileModel> GetSubFiles(int id,int projectId, string fieldOrder)
        {
            List<Model.FileModel> files = new List<Model.FileModel>();
            FileDal fileDal = new FileDal(this.databaseprefix);
            DataSet ds = fileDal.GetList(string.Format(" IsDeleted=0 and  File_DirId ={0} ", id), fieldOrder);
            DataTable dt = ds.Tables[0];

            foreach (DataRow item in dt.Rows)
            {
                files.Add(fileDal.ChangeSimpleRowToFile(item));
            }

            return files;
        }

        /// <summary>
        /// 获取路径
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.ForderModel> GetForderPath(int id)
        {
            List<Model.ForderModel> subForders = new List<Model.ForderModel>();
            if (id <= 0) return subForders;
            Model.ForderModel mainForder = GetModel(id);

            if (mainForder == null || string.IsNullOrEmpty(mainForder.Class_List)) return subForders;
            string[] ids = mainForder.Class_List.Split(',');

            foreach (var item in ids)
            {
                int fid = 0;
                if (string.IsNullOrEmpty(item)) continue;
                if (!int.TryParse(item, out fid)) continue;
                subForders.Add(GetModel(fid));
            }
            return subForders;


            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select  top 1000 * from " + databaseprefix + "Forder ");
            //strSql.Append(" where parent_id=@id");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@id", SqlDbType.Int,4)};
            //parameters[0].Value = id;

            //Model.ForderModel model = new Model.ForderModel();
            //DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow item in ds.Tables[0].Rows)
            //    {
            //        subForders.Add(ChangeRowToForder(item));
            //    }

            //    return subForders;
            //}
            //else
            //{
            //    return null;
            //}
        }

        #region 扩展方法================================
        public int GetParentId(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 parent_id from " + databaseprefix + "Forder");
            strSql.Append(" where id=" + id);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        #endregion

        #region 私有方法================================
        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable oldData, DataTable newData, int parent_id)
        {
            DataRow[] dr = oldData.Select("parent_id=" + parent_id);
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                row["id"] = int.Parse(dr[i]["id"].ToString());
                row["title"] = dr[i]["title"].ToString();
                row["call_index"] = dr[i]["call_index"].ToString();
                row["parent_id"] = int.Parse(dr[i]["parent_id"].ToString());
                row["class_list"] = dr[i]["class_list"].ToString();
                row["class_layer"] = int.Parse(dr[i]["class_layer"].ToString());
                row["sort_id"] = int.Parse(dr[i]["sort_id"].ToString());
                row["Image"] = dr[i]["Image"].ToString();
                row["remark"] = dr[i]["remark"].ToString();

                //调用自身迭代
                this.GetChilds(oldData, newData, int.Parse(dr[i]["id"].ToString()));
            }
        }

        /// <summary>
        /// 修改子节点的ID列表及深度（自身迭代）
        /// </summary>
        /// <param name="parent_id"></param>
        private void UpdateChilds(SqlConnection conn, SqlTransaction trans, int parent_id)
        {
            //查找父节点信息
            Model.ForderModel model = GetModel(conn, trans, parent_id);
            if (model != null)
            {
                //查找子节点
                string strSql = "select id from " + databaseprefix + "Forder where parent_id=" + parent_id;
                DataSet ds = DbHelperSQL.Query(conn, trans, strSql); //带事务
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //修改子节点的ID列表及深度
                    int id = int.Parse(dr["id"].ToString());
                    string class_list = model.Class_List + id + ",";
                    int class_layer = model.Class_Layer + 1;
                    DbHelperSQL.ExecuteSql(conn, trans, "update " + databaseprefix + "Forder set class_list='" + class_list + "', class_layer=" + class_layer + " where id=" + id); //带事务

                    //调用自身迭代
                    this.UpdateChilds(conn, trans, id); //带事务
                }
            }
        }

        /// <summary>
        /// 验证节点是否被包含
        /// </summary>
        /// <param name="id">待查询的节点</param>
        /// <param name="parent_id">父节点</param>
        /// <returns></returns>
        private bool IsContainNode(int id, int parent_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "Forder ");
            strSql.Append(" where class_list like '%," + id + ",%' and id=" + parent_id);
            return DbHelperSQL.Exists(strSql.ToString());
        }

        #endregion

        #endregion
    }
}