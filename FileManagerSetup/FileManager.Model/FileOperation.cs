using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Model
{
    public class FileOperation
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FileOperation() { }

        #region Model

        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID;

        /// <summary>
        /// 用户ID
        /// </summary>
        public int Update_UserId;

        /// <summary>
        /// 用户名
        /// </summary>
        public string Update_UserName;

        /// <summary>
        /// 文件名称
        /// </summary>
        public string File_FullName;

        /// <summary>
        /// 文件版本号
        /// </summary>
        public int File_Version;

        /// <summary>
        /// 文件目录结构ID
        /// </summary>
        public int File_DirId;

        /// <summary>
        /// 文件类型
        /// </summary>
        public string File_Type;

        /// <summary>
        /// 文件类型
        /// </summary>
        public int IsForder;

        /// <summary>
        /// 操作类型
        /// </summary>
        public FileOperationType FileOp_Type;

        #endregion Model
    }

    public enum FileOperationType
    {
        //新增
        Add = 1,
        //相等
        Equal = 0,
        //修改
        Modify = 2,
        //上传
        Del = 3
    }
}
