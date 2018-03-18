using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Model
{
    /// <summary>
    /// 文件版本号
    /// </summary>
    public class FileVersion
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID;

        /// <summary>
        /// 版本号[采用自增int]
        /// </summary>
        public int Ver;

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName;

        /// <summary>
        /// 文件ID
        /// </summary>
        public int File_Id;

        /// <summary>
        /// 文件类型
        /// </summary>
        public string File_Md5;

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
        /// 文件内容ID
        /// </summary>
        public string FileContentId;

        /// <summary>
        /// 文件最新修改时间【如果md5权限有问题，用最新修改时间判断文件是否重复】
        /// </summary>
        public long File_Modify_Time;
      
        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDeleted;

        /// <summary>
        /// 0相等，1新增,2修改，3删除
        /// </summary>
        public int ActionNum;

        /// <summary>
        /// 操作类型[上传，修改，删除，下载]
        /// </summary>
        public int ActionType;

        /// <summary>
        /// 计算机名称
        /// </summary>
        public string ComputerName;

        /// <summary>
        /// 客户端操作IP地址
        /// </summary>
        public string Ip;

        /// <summary>
        /// 所在客户端路径
        /// </summary>
        public string ClientPath;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark;

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime Add_Time;

        ///// <summary>
        ///// 版本操作日志
        ///// </summary>
        //public FileLogModel Log;
    }
}
