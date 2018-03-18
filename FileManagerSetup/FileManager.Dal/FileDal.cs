using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FileManager.Common;
using FileManager.Model;
using FileManager.DBUtility;

namespace FileManager.DAL
{
    /// <summary>
    /// 数据访问类:文件
    /// </summary>
    public partial class FileDal
    {
        private string databaseprefix; //数据库表名前缀
        public FileDal(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法==============================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "File");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        ///根据文件名和文件md5判断是否已经上传
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileMd5"></param>
        /// <returns></returns>
        public int GetFileID(int forderID, string fileName, string fileMd5)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ID from " + databaseprefix + "File");
            strSql.Append(" where File_DirId=@forderID and File_Name=@fileName  and isDeleted =0");
            SqlParameter[] parameters = {
					new SqlParameter("@forderID", SqlDbType.Int ),
					new SqlParameter("@fileName", SqlDbType.VarChar ),
					new SqlParameter("@fileMd5", SqlDbType.VarChar ),
                                        };
            parameters[0].Value = forderID;
            parameters[1].Value = fileName;
            parameters[2].Value = fileMd5;
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
        }

        /// <summary>
        ///修改文件为删除状态
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileMd5"></param>
        /// <returns></returns>
        public int UpdateFile(int forderID, string fileName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update " + databaseprefix + "File set isdeleted = 1");
            strSql.Append(" where File_DirId=@forderID and File_Name=@fileName  ");
            SqlParameter[] parameters = {
					new SqlParameter("@forderID", SqlDbType.Int ),
					new SqlParameter("@fileName", SqlDbType.VarChar ),
            };

            parameters[0].Value = forderID;
            parameters[1].Value = fileName;
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.FileModel model)
        {
            //Update_UserId,Update_UserName,File_Name,File_LastVersion,File_Md5,File_DirId,
            //File_Type,File_Size,File_Ext,File_SmallImage,File_LargeImage,Content,Add_Time,Remark,File_Modify_Time
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "File set ");
            strSql.Append("Update_UserId=@Update_UserId,");
            strSql.Append("Update_UserName=@Update_UserName,");
            strSql.Append("File_Name=@File_Name,");
            strSql.Append("File_LastVersion=@File_LastVersion,");
            strSql.Append("File_Md5=@File_Md5,");
            strSql.Append("File_DirId=@File_DirId,");
            strSql.Append("File_Type=@File_Type,");
            strSql.Append("File_Size=@File_Size,");
            strSql.Append("File_Ext=@File_Ext,");
            strSql.Append("Add_Time=@Add_Time,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("File_Modify_Time=@File_Modify_Time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Update_UserId", SqlDbType.Int,4),
					new SqlParameter("@Update_UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@File_Name", SqlDbType.NVarChar,100),
					new SqlParameter("@File_LastVersion", SqlDbType.Int),
					new SqlParameter("@File_Md5", SqlDbType.NVarChar,100),
					new SqlParameter("@File_DirId", SqlDbType.Int),
					new SqlParameter("@File_Type", SqlDbType.NVarChar,100),
					new SqlParameter("@File_Size", SqlDbType.Int),
					new SqlParameter("@File_Ext", SqlDbType.NVarChar,100),
					new SqlParameter("@Add_Time", SqlDbType.DateTime),
					new SqlParameter("@Remark",SqlDbType.NVarChar,1000),
					new SqlParameter("@File_Modify_Time", SqlDbType.BigInt),
               };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.File_Name;
            parameters[4].Value = model.File_LastVersion;
            parameters[5].Value = model.File_Md5;
            parameters[6].Value = model.File_DirId;
            parameters[7].Value = model.File_Type;
            parameters[8].Value = model.File_Size;
            parameters[9].Value = model.File_Ext;
            parameters[10].Value = model.Add_Time;
            parameters[11].Value = model.Remark;
            parameters[12].Value = model.File_Modify_Time;

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
            strSql.Append("update " + databaseprefix + "File set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        ///// <summary>
        ///// 获取文件最新版本
        ///// </summary>
        ///// <param name="fileName"></param>
        ///// <param name="forderId"></param>
        ///// <returns></returns>
        //public Model.FileModel GetFileLastVer(string fileName, List<string> forders)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select top 1 V.Ver  from " + databaseprefix + "File F left join " + databaseprefix + "FileVersion V on F.File_Dirid = V.ID");
        //    if (!string.IsNullOrEmpty(fileName))
        //    {
        //        strSql.Append(" where file_name = @file_name and file_dirId = @file_dirId");
        //    }
        //    strSql.Append("  order by v.ver desc");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@file_name", SqlDbType.VarChar),
        //            new SqlParameter("@file_dirId", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = fileName;
        //    parameters[1].Value = forderId;

        //    return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
        //}

        /// <summary>
        /// 获取文件最新版本
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="forderId"></param>
        /// <returns></returns>
        public int GetFileLastVer(string fileName, int forderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 V.Ver  from " + databaseprefix + "File F left join " + databaseprefix + "FileVersion V on F.id = V.File_Id");
            if (!string.IsNullOrEmpty(fileName))
            {
                strSql.Append(" where file_name = @file_name and file_dirId = @file_dirId");
            }
            strSql.Append("  order by v.ver desc");
            SqlParameter[] parameters = {
					new SqlParameter("@file_name", SqlDbType.VarChar),
					new SqlParameter("@file_dirId", SqlDbType.Int,4)
            };
            parameters[0].Value = fileName;
            parameters[1].Value = forderId;

            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
        }

        /// <summary>
        /// 根据最新时间获取版本
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="forderId"></param>
        /// <param name="lastModifyTime"></param>
        /// <returns></returns>
        public int GetFileLastVer(int fileId, DateTime lastModifyTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 V.Ver  from " + databaseprefix + "File F left join " + databaseprefix + "FileVersion V on F.id = V.File_Id");
            if (fileId > 0)
            {
                strSql.Append(" where  F.id = @fileId and V.File_Modify_Time=@File_Modify_Time");
            }
            strSql.Append("  order by v.ver desc");
            SqlParameter[] parameters = {
					new SqlParameter("@fileId", SqlDbType.Int,4),
					new SqlParameter("@File_Modify_Time", SqlDbType.BigInt)
            };
            parameters[0].Value = fileId;
            parameters[1].Value = lastModifyTime.Ticks;

            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
        }

        /// <summary>
        /// 获取文件最新版本
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public Model.FileVersion GetFileLastVer(int fileId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 V.ID  from " + databaseprefix + "File F left join " + databaseprefix + "FileVersion V on F.id = V.File_Id");
            if (fileId > 0)
            {
                strSql.Append(" where  F.id = @fileId ");
            }
            strSql.Append("  order by v.ver desc");
            SqlParameter[] parameters = {
					new SqlParameter("@fileId", SqlDbType.Int,4),
            };
            parameters[0].Value = fileId;

            int verID =  Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(), parameters));

            return new FileVersionDal(databaseprefix).GetModel(verID);
        }

        /// <summary>
        /// 返回数据数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from " + databaseprefix + "File ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(FileModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "File](");
            strSql.Append("Update_UserId,Update_UserName,File_Name,File_LastVersion,File_Md5,Project_Id,File_DirId,File_Type,File_Size,File_Ext,File_SmallImage,File_LargeImage,Content,ClientPath,Add_Time,Remark,File_Modify_Time)");
            strSql.Append(" values (");
            strSql.Append("@Update_UserId,@Update_UserName,@File_Name,@File_LastVersion,@File_Md5,@Project_Id,@File_DirId,@File_Type,@File_Size,@File_Ext,@File_SmallImage,@File_LargeImage,@Content,@ClientPath,@Add_Time,@Remark,@File_Modify_Time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Update_UserId", SqlDbType.Int,4),
					new SqlParameter("@Update_UserName", SqlDbType.NVarChar,200),
					new SqlParameter("@File_Name", SqlDbType.NVarChar,200),
					new SqlParameter("@File_LastVersion", SqlDbType.Int),
					new SqlParameter("@File_Md5", SqlDbType.NVarChar,200),
					new SqlParameter("@Project_Id", SqlDbType.Int),
					new SqlParameter("@File_DirId", SqlDbType.Int),
					new SqlParameter("@File_Type", SqlDbType.NVarChar,200),
					new SqlParameter("@File_Size", SqlDbType.Int),
					new SqlParameter("@File_Ext", SqlDbType.NVarChar,200),
					new SqlParameter("@File_SmallImage", SqlDbType.VarBinary),
					new SqlParameter("@File_LargeImage", SqlDbType.VarBinary),
					new SqlParameter("@Content", SqlDbType.VarBinary),
					new SqlParameter("@ClientPath", SqlDbType.NVarChar,2000),
					new SqlParameter("@Add_Time", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,2000),
					new SqlParameter("@File_Modify_Time", SqlDbType.BigInt),
					};

            parameters[0].Value = model.UserId;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.File_Name;
            parameters[3].Value = model.File_LastVersion;
            parameters[4].Value = model.File_Md5;
            parameters[5].Value = model.Project_Id;
            parameters[6].Value = model.File_DirId;
            parameters[7].Value = model.File_Type;
            parameters[8].Value = model.File_Size;
            parameters[9].Value = model.File_Ext;
            parameters[10].Value = model.File_SmallImage;
            parameters[11].Value = model.File_LargeImage;
            parameters[12].Value = model.Content;
            parameters[13].Value = model.ClientPath;
            parameters[14].Value = model.Add_Time;
            parameters[15].Value = model.Remark;
            parameters[16].Value = model.File_Modify_Time;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 得到一个对象实体
        /// </summary>
        public FileModel GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,Update_UserId,Update_UserName,File_Name,File_LastVersion,File_Md5,Project_Id,File_DirId,File_Type,File_Size,File_Ext,File_SmallImage,File_LargeImage,ClientPath,Add_Time,Remark,File_Modify_Time from [" + databaseprefix + "File] ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            FileModel model = new FileModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = ChangeSimpleRowToFile(ds.Tables[0].Rows[0]);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 转化为对象格式
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Model.FileModel ChangeRowToFile(DataRow row)
        {
            FileModel model = new FileModel();

            if (row["id"].ToString() != "")
            {
                model.ID = int.Parse(row["id"].ToString());
            }

            if (row["Update_UserId"].ToString() != "")
            {
                model.UserId = int.Parse(row["Update_UserId"].ToString());
            }
            model.UserName = row["Update_UserName"].ToString();

            if (row["File_LastVersion"].ToString() != "")
            {
                model.File_LastVersion = int.Parse(row["File_LastVersion"].ToString());
            }
            model.File_Md5 = row["File_Md5"].ToString();
            model.File_Name = row["File_Name"].ToString();

            if (row["Project_Id"].ToString() != "")
            {
                model.Project_Id = int.Parse(row["Project_Id"].ToString());
            }
            if (row["File_DirId"].ToString() != "")
            {
                model.File_DirId = int.Parse(row["File_DirId"].ToString());
            }
            model.File_Type = row["File_Type"].ToString();
            if (row["File_Size"].ToString() != "")
            {
                model.File_Size = int.Parse(row["File_Size"].ToString());
            }
            model.File_Ext = row["File_Ext"].ToString();

            if (row["File_SmallImage"].ToString() != "")
            {
                model.File_SmallImage = (byte[])row["File_SmallImage"];
            }
            if (row["File_LargeImage"].ToString() != "")
            {
                model.File_LargeImage = (byte[])row["File_LargeImage"];
            }
            if (row["Content"].ToString() != "")
            {
                model.Content = (byte[])row["Content"];
            }
            if (row["Add_Time"].ToString() != "")
            {
                model.Add_Time = DateTime.Parse(row["add_time"].ToString());
            }
            model.Remark = row["Remark"].ToString();
            return model;
        }

        public Model.FileModel ChangeSimpleRowToFile(DataRow row)
        {
            FileModel model = new FileModel();

            if (row["id"].ToString() != "")
            {
                model.ID = int.Parse(row["id"].ToString());
            }

            if (row["Update_UserId"].ToString() != "")
            {
                model.UserId = int.Parse(row["Update_UserId"].ToString());
            }
            model.UserName = row["Update_UserName"].ToString();

            if (row["File_LastVersion"].ToString() != "")
            {
                model.File_LastVersion = int.Parse(row["File_LastVersion"].ToString());
            }
            model.File_Md5 = row["File_Md5"].ToString();
            model.File_Name = row["File_Name"].ToString();

            if (row["Project_Id"].ToString() != "")
            {
                model.Project_Id = int.Parse(row["Project_Id"].ToString());
            }
            if (row["File_DirId"].ToString() != "")
            {
                model.File_DirId = int.Parse(row["File_DirId"].ToString());
            }
            model.File_Type = row["File_Type"].ToString();
            if (row["File_Size"].ToString() != "")
            {
                model.File_Size = int.Parse(row["File_Size"].ToString());
            }
            model.File_Ext = row["File_Ext"].ToString();
            model.ClientPath = row["ClientPath"].ToString();
            if (row["File_Modify_Time"].ToString() != "")
            {
                model.File_Modify_Time = long.Parse(row["File_Modify_Time"].ToString());
            }
            if (row["Add_Time"].ToString() != "")
            {
                model.Add_Time = DateTime.Parse(row["add_time"].ToString());
            }
            model.Remark = row["Remark"].ToString();
            return model;
        }

        /// <summary>
        /// 根据用户名返回上一次登录记录
        /// </summary>
        public FileModel GetModel(string user_name, int top_num, string action_type)
        {
            int rows = GetCount("user_name='" + user_name + "'");
            if (top_num == 1)
            {
                rows = 2;
            }
            if (rows > 1)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 id from (select top " + top_num + " id from " + databaseprefix + "File where user_name=@user_name and action_type=@action_type order by id desc) as T ");
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

        ///// <summary>
        ///// 删除7天前的日志数据
        ///// </summary>
        public int Delete(int dayCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "File ");
            strSql.Append(" where DATEDIFF(day, add_time, getdate()) > " + dayCount);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 文件搜索【最多显示1000个】
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public List<Model.FileModel> SearchList(int Top, string strWhere, string filedOrder)
        {
            List<Model.FileModel> files = new List<FileModel>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append("  F.[ID], F.[Update_UserId], F.[Update_UserName], F.[File_Name], F.[File_LastVersion], F.[File_Md5],F.Project_Id, F.[File_DirId], F.[File_Type], F.[File_Size], F.[File_Ext], F.[File_SmallImage], F.[File_LargeImage], F.ClientPath, F.[Add_Time], F.[IsDeleted], F.[Remark], F.[File_Modify_Time] ");
            strSql.Append(" FROM " + databaseprefix + "File F join  " + databaseprefix + "Forder Fo on F.File_DirId = Fo.ID  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrEmpty(filedOrder))
            {
                strSql.Append(" order by " + filedOrder);
            }
            else
            {
                strSql.Append(" order by Add_Time desc,id desc");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        files.Add(ChangeSimpleRowToFile(item));
                    }
                }
            }
            return files;
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
            strSql.Append("  [ID],[Update_UserId],[Update_UserName],[File_Name],[File_LastVersion],[File_Md5],Project_Id,[File_DirId],[File_Type],[File_Size],[File_Ext],[File_SmallImage],[File_LargeImage],ClientPath,[Add_Time],[IsDeleted],[Remark],[File_Modify_Time] ");
            strSql.Append(" FROM " + databaseprefix + "File ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取满足条件所有数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID],[Update_UserId],[Update_UserName],[File_Name],[File_LastVersion],[File_Md5],Project_Id,[File_DirId],[File_Type],[File_Size],[File_Ext],[File_SmallImage],[File_LargeImage],ClientPath,[Add_Time],[IsDeleted],[Remark],[File_Modify_Time] ");
            strSql.Append(" FROM [" + databaseprefix + "File] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            if (!string.IsNullOrEmpty(filedOrder))
            {
                strSql.Append(" order by " + filedOrder);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "File");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion
    }
}
