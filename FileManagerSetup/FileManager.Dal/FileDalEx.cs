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
    public partial class FileDalEx
    {
        private string databaseprefix; //数据库表名前缀
        public FileDalEx(string _databaseprefix)
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
        public int GetFileID(System.Data.SqlClient.SqlConnection connection, int forderID, string fileName, string fileMd5)
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
            return Convert.ToInt32(DbHelperSQLEx.GetSingle(connection,strSql.ToString(), parameters));
        }

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
        public Model.FileVersion GetFileLastVer(System.Data.SqlClient.SqlConnection connection, int fileId)
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

            int verID =  Convert.ToInt32(DbHelperSQLEx.GetSingle(connection,strSql.ToString(), parameters));

            return new FileVersionDalEx(databaseprefix).GetModel(connection,verID);
        }
        #endregion
    }
}
