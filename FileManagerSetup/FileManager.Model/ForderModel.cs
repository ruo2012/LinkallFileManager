using System;
using System.Collections.Generic;

namespace FileManager.Model
{
    /// <summary>
    /// 内容类别
    /// </summary>
    [Serializable]
    public partial class ForderModel
    {
        public ForderModel()
        { }

        #region Model
         
        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID;
         
        /// <summary>
        /// 类别标题
        /// </summary>
        public string Title;
         
        /// <summary>
        /// 调用别名
        /// </summary>
        public string Call_Index;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName;

        /// <summary>
        /// 工程ID
        /// </summary>
        public int Project_Id;

        /// <summary>
        /// 父类别ID
        /// </summary>
        public int Parent_Id;
         
        /// <summary>
        /// 字类别ID列表(逗号分隔开)
        /// </summary>
        public string Class_List;

        /// <summary>
        /// 类别深度
        /// </summary>
        public int Class_Layer;
       
        /// <summary>
        /// 排序数字
        /// </summary>
        public int Sort_Id;
         
        /// <summary>
        /// 图片
        /// </summary>
        public byte[] Image;
            
        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark;

        /// <summary>
        /// 文件最新修改时间【如果md5权限有问题，用最新修改时间判断文件是否重复】
        /// </summary>
        public long Forder_Modify_Time;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Add_Time;

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted;

        /// <summary>
        /// 文件夹下的文件
        /// </summary>
        public List<FileModel> Files;

        /// <summary>
        /// 文件夹下的子文件
        /// </summary>
        public List<ForderModel> SubForders;

        /// <summary>
        /// 文件夹路径
        /// </summary>
        public List<ForderModel> ForderPath;

        /// <summary>
        /// 0相等，1新增,3删除
        /// </summary>
        public int ActionNum;

        /// <summary>
        /// 客户端路径
        /// </summary>
        public string ClientPath;

        #endregion Model
    }
}