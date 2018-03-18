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
    /// 数据访问类:文件版本
    /// </summary>
    public partial class FileVersionDalEx
    {
        private string databaseprefix; //数据库表名前缀
        public FileVersionDalEx(string _databaseprefix)
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
            strSql.Append("select count(1) from " + databaseprefix + "FileVersion");
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
            strSql.Append("select count(*) as H from " + databaseprefix + "FileVersion ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.FileVersion model)
        {
            string contentId = Guid.NewGuid().ToString();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "FileVersion](");
            strSql.Append("Ver,UserID,UserName,File_Id,File_Type,File_Size,File_Md5,File_Ext,File_SmallImage,File_LargeImage,Content,File_Modify_Time,IsDeleted,ActionNum,ComputerName,Ip,ClientPath,Remark,Add_Time,FileContentId)");
            strSql.Append(" values (");
            strSql.Append("@Ver,@UserID,@UserName,@File_Id,@File_Type,@File_Size,@File_Md5,@File_Ext,@File_SmallImage,@File_LargeImage,@Content,@File_Modify_Time,@IsDeleted,@ActionNum,@ComputerName,@Ip,@ClientPath,@Remark,@Add_Time,@FileContentId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Ver", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@File_Id",SqlDbType.Int),
					new SqlParameter("@File_Type",SqlDbType.NVarChar,100),
					new SqlParameter("@File_Size", SqlDbType.Int),
					new SqlParameter("@File_Md5", SqlDbType.NVarChar,100),
					new SqlParameter("@File_Ext", SqlDbType.NVarChar,200),
					new SqlParameter("@File_SmallImage", SqlDbType.VarBinary),
					new SqlParameter("@File_LargeImage", SqlDbType.VarBinary),
					new SqlParameter("@Content", SqlDbType.VarBinary),
					new SqlParameter("@File_Modify_Time", SqlDbType.BigInt),
					new SqlParameter("@IsDeleted", SqlDbType.TinyInt),
					new SqlParameter("@ActionNum", SqlDbType.TinyInt),
					new SqlParameter("@ComputerName", SqlDbType.NVarChar,200),
					new SqlParameter("@Ip", SqlDbType.NVarChar,200),
					new SqlParameter("@ClientPath", SqlDbType.NVarChar,2000),
					new SqlParameter("@Remark", SqlDbType.NVarChar,2000),
					new SqlParameter("@Add_Time", SqlDbType.DateTime),
					new SqlParameter("@FileContentId", SqlDbType.NVarChar),
					};

            parameters[0].Value = model.Ver;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.File_Id;
            parameters[4].Value = model.File_Type;
            parameters[5].Value = model.File_Size;
            parameters[6].Value = model.File_Md5;
            parameters[7].Value = model.File_Ext;
            parameters[8].Value = model.File_SmallImage;
            parameters[9].Value = model.File_LargeImage;
            parameters[10].Value = new byte[1];
            parameters[11].Value = model.File_Modify_Time;
            parameters[12].Value = model.IsDeleted;
            parameters[13].Value = model.ActionNum;
            parameters[14].Value = model.ComputerName;
            parameters[15].Value = model.Ip;
            parameters[16].Value = model.ClientPath;
            parameters[17].Value = model.Remark;
            parameters[18].Value = model.Add_Time;
            parameters[19].Value = contentId;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            int retId = Convert.ToInt32(obj);

            //文件内容的上传
            Model.FileContentModel contentModel = new FileContentModel()
            {
                ID = contentId,
                Add_Time = DateTime.Now,
                File_Content = model.Content,
                File_ID = model.File_Id,
                File_Ver = model.Ver.ToString(),
                File_VerID = retId
            };
            string fileContentId = new DAL.FileContentDal(databaseprefix).Add(contentModel);

            if (obj == null || string.IsNullOrEmpty(fileContentId))
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
        public FileVersion GetModel(System.Data.SqlClient.SqlConnection connection, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from [" + databaseprefix + "FileVersion] ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            FileVersion model = new FileVersion();
            DataSet ds = DbHelperSQLEx.Query(connection,null,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = ChangeRowToFile(ds.Tables[0].Rows[0]);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取文件内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public byte[] GetContent(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 FileContentId from [" + databaseprefix + "FileVersion] ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            string fileContentId = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));

            if (string.IsNullOrEmpty(fileContentId))
            {
                return null;
            }

            return new DAL.FileContentDal(databaseprefix).GetContent(fileContentId);
        }

        /// <summary>
        /// 转化为对象格式
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Model.FileVersion ChangeRowToFile(DataRow row)
        {
            FileVersion model = new FileVersion();

            if (row["id"].ToString() != "")
            {
                model.ID = int.Parse(row["id"].ToString());
            }

            if (row["Ver"].ToString() != "")
            {
                model.Ver = int.Parse(row["Ver"].ToString());
            }

            if (row["UserID"].ToString() != "")
            {
                model.UserID = int.Parse(row["UserID"].ToString());
            }

            if (row["UserName"].ToString() != "")
            {
                model.UserName = row["UserName"].ToString();
            }
            model.File_Type = row["File_Type"].ToString();
            if (row["File_Size"].ToString() != "")
            {
                model.File_Size = int.Parse(row["File_Size"].ToString());
            }
            model.File_Md5 = row["File_Md5"].ToString();
            model.File_Ext = row["File_Ext"].ToString();

            if (row["File_SmallImage"].ToString() != "")
            {
                model.File_SmallImage = (byte[])row["File_SmallImage"];
            }
            if (row["File_LargeImage"].ToString() != "")
            {
                model.File_LargeImage = (byte[])row["File_LargeImage"];
            }
            //if (row["Content"].ToString() != "")
            //{
            //    model.Content = (byte[])row["Content"];
            //}

            if (row["File_Modify_Time"].ToString() != "")
            {
                model.File_Modify_Time = long.Parse(row["File_Modify_Time"].ToString());
            }

            if (row["IsDeleted"].ToString() != "")
            {
                model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
            }

            if (row["ActionNum"].ToString() != "")
            {
                model.ActionNum = int.Parse(row["ActionNum"].ToString());
            }
            model.ComputerName = row["ComputerName"].ToString();
            model.Ip = row["Ip"].ToString();
            model.ClientPath = row["ClientPath"].ToString();
            model.Remark = row["Remark"].ToString();

            if (row["Add_Time"].ToString() != "")
            {
                model.Add_Time = DateTime.Parse(row["add_time"].ToString());
            }
            return model;
        }

        /// <summary>
        /// 单行转化为版本实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Model.FileVersion ChangeSimpleRowToFile(DataRow row)
        {
            FileVersion model = new FileVersion();

            if (row["id"].ToString() != "")
            {
                model.ID = int.Parse(row["id"].ToString());
            }

            if (row["Ver"].ToString() != "")
            {
                model.Ver = int.Parse(row["Ver"].ToString());
            }

            if (row["UserID"].ToString() != "")
            {
                model.UserID = int.Parse(row["UserID"].ToString());
            }

            if (row["UserName"].ToString() != "")
            {
                model.UserName = row["UserName"].ToString();
            }
            model.File_Type = row["File_Type"].ToString();
            if (row["File_Size"].ToString() != "")
            {
                model.File_Size = int.Parse(row["File_Size"].ToString());
            }
            model.File_Md5 = row["File_Md5"].ToString();
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

            if (row["File_Modify_Time"].ToString() != "")
            {
                model.File_Modify_Time = DateTime.Parse(row["File_Modify_Time"].ToString()).Ticks;
            }

            if (row["IsDeleted"].ToString() != "")
            {
                model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
            }

            if (row["ActionNum"].ToString() != "")
            {
                model.ActionNum = int.Parse(row["ActionNum"].ToString());
            }
            model.ComputerName = row["ComputerName"].ToString();
            model.Ip = row["Ip"].ToString();
            model.ClientPath = row["ClientPath"].ToString();
            model.Remark = row["Remark"].ToString();

            if (row["Add_Time"].ToString() != "")
            {
                model.Add_Time = DateTime.Parse(row["add_time"].ToString());
            }
            return model;
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
            strSql.Append(" id,user_id,user_name,action_type,remark,user_ip,add_time ");
            strSql.Append(" FROM " + databaseprefix + "FileVersion ");
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
            strSql.Append("select [ID],[Ver],[UserID],[UserName],[File_Id],[File_Type],[File_Size],[File_Ext],[File_Modify_Time],[IsDeleted],[ActionNum],ComputerName,[Ip],[ClientPath],[Remark] ,[Add_Time] ");
            strSql.Append(" FROM [" + databaseprefix + "FileVersion] ");
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
            strSql.Append("select * FROM " + databaseprefix + "FileVersion");
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
