using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Model
{
    /// <summary>
    /// 文件:实体类
    /// </summary>
    [Serializable]
    public partial class FileModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FileModel() { }

        #region Model

        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID;

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName;

        /// <summary>
        /// 文件名称
        /// </summary>
        public string File_Name;

        /// <summary>
        /// 文件版本号
        /// </summary>
        public int File_LastVersion;

        /// <summary>
        /// 文件MD5编码
        /// </summary>
        public string File_Md5;

        /// <summary>
        /// 工程id
        /// </summary>
        public int Project_Id;

        /// <summary>
        /// 文件目录结构ID
        /// </summary>
        public int File_DirId;

        /// <summary>
        /// 文件类型
        /// </summary>
        public string File_Type;

        /// <summary>
        /// 文件大小（字节）
        /// </summary>
        public int File_Size;

        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string File_Ext;

        /// <summary>
        /// 文件小图标
        /// </summary>
        public byte[] File_SmallImage;

        /// <summary>
        /// 文件大图标
        /// </summary>
        public byte[] File_LargeImage;

        /// <summary>
        /// 二进制文件
        /// </summary>
        public byte[] Content;

        /// <summary>
        /// 所在客户端路径
        /// </summary>
        public string ClientPath;

        /// <summary>
        /// 文件最新修改时间【如果md5权限有问题，用最新修改时间判断文件是否重复】
        /// </summary>
        public long File_Modify_Time;

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime Add_Time;

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark;

        /// <summary>
        /// 文件路径
        /// </summary>
        public List<ForderModel> ForderPath;

        /// <summary>
        /// 文件所处文件夹信息
        /// </summary>
        public ForderModel Forder;

        /// <summary>
        /// -1,操作异常，0相等，1新增,2修改，3删除
        /// </summary>
        public int ActionNum;

    
        #endregion Model
    }
}
