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
    /// 数据访问类:文件内容
    /// </summary>
    public partial class FileContentDal
    {
        private string databaseprefix; //数据库表名前缀
        public FileContentDal(string _databaseprefix)
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
            strSql.Append("select count(1) from " + databaseprefix + "DetailContent");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            return DbHelperFileContentSQL.Exists(strSql.ToString(), parameters);
        }
 
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.FileContentModel model)
        {
            //文件内容的上传
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [" + databaseprefix + "DetailContent](");
            strSql.Append("ID,File_ID,File_VerID,File_Ver,File_Content,Add_Time)");
            strSql.Append(" values (");
            strSql.Append("@ID,@File_ID,@File_VerID,@File_Ver,@File_Content,@Add_Time )");
            //strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar),
					new SqlParameter("@File_ID", SqlDbType.Int),
					new SqlParameter("@File_VerID", SqlDbType.Int),
					new SqlParameter("@File_Ver",SqlDbType.NVarChar,100),
					new SqlParameter("@File_Content",SqlDbType.VarBinary),
					new SqlParameter("@Add_Time", SqlDbType.DateTime),
					};

            parameters[0].Value = model.ID;
            parameters[1].Value = model.File_ID;
            parameters[2].Value = model.File_VerID;
            parameters[3].Value = model.File_Ver;
            parameters[4].Value = model.File_Content;
            parameters[5].Value = model.Add_Time;

            int obj = DbHelperFileContentSQL.ExecuteSql(strSql.ToString(), parameters);
            if (obj==0)
            {
                return string.Empty;
            }
            else
            {
                return model.ID;
            }
        }

        /// <summary>
        /// 获取文件内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public byte[] GetContent(string id)
        {
            id = "'" + id + "'";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 File_Content from [" + databaseprefix + "DetailContent] ");
            strSql.Append(" where id=" + id);
            

            DataSet ds = DbHelperFileContentSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return (byte[])ds.Tables[0].Rows[0]["File_Content"];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FileContentModel GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from [" + databaseprefix + "DetailContent] ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            FileContentModel model = new FileContentModel();
            DataSet ds = DbHelperFileContentSQL.Query(strSql.ToString(), parameters);
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
        /// 得到一个对象实体
        /// </summary>
        public FileContentModel GetSimpleModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from [" + databaseprefix + "DetailContent] ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            FileContentModel model = new FileContentModel();
            DataSet ds = DbHelperFileContentSQL.Query(strSql.ToString(), parameters);
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
        public Model.FileContentModel ChangeRowToFile(DataRow row)
        {
            FileContentModel model = new FileContentModel();

            if (row["id"].ToString() != "")
            {
                model.ID =  row["id"].ToString();
            }

            if (row["File_ID"].ToString() != "")
            {
                model.File_ID = int.Parse(row["File_Size"].ToString());
            }
        
            if (row["File_VerID"].ToString() != "")
            {
                model.File_VerID = int.Parse(row["File_VerID"].ToString());
            }

            if (row["File_Ver"].ToString() != "")
            {
                model.File_Ver = row["File_Ver"].ToString();
            }

            if (row["File_Content"].ToString() != "")
            {
                model.File_Content = (byte[])row["File_Content"];
            }

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
        public Model.FileContentModel ChangeSimpleRowToFile(DataRow row)
        {
            FileContentModel model = new FileContentModel();

            if (row["id"].ToString() != "")
            {
                model.ID = row["id"].ToString();
            }

            if (row["File_ID"].ToString() != "")
            {
                model.File_ID = int.Parse(row["File_Size"].ToString());
            }

            if (row["File_VerID"].ToString() != "")
            {
                model.File_VerID = int.Parse(row["File_VerID"].ToString());
            }

            if (row["File_Ver"].ToString() != "")
            {
                model.File_Ver = row["File_Ver"].ToString();
            }

            if (row["Add_Time"].ToString() != "")
            {
                model.Add_Time = DateTime.Parse(row["add_time"].ToString());
            }
            return model;
        }

        #endregion
    }
}
