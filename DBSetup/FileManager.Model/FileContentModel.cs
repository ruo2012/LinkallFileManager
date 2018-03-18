using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Model
{
    /// <summary>
    /// 文件内容类
    /// </summary>
    [Serializable]
    public class FileContentModel
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string ID;

        /// <summary>
        /// 文件id
        /// </summary>
        public int File_ID;

        /// <summary>
        /// 文件版本ID
        /// </summary>
        public int File_VerID;

        /// <summary>
        /// 文件版本
        /// </summary>
        public string File_Ver;

        /// <summary>
        /// 文件内容
        /// </summary>
        public byte[] File_Content;

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Add_Time;

    }
}
