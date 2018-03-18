using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Model
{
    public class Common
    {
        
    }

    /// <summary>
    /// 下拉框子项
    /// </summary>
    public struct ListItem
    {
        public string Text;
        public object Value;
        public ListItem(string text, object value)
        {
            this.Text = text;
            this.Value = value;
        }
        public override string ToString()
        {
            return Text;
        }
    }

    /// <summary>
    /// 一键上传:ALLUPLOAD，一键同步：ALLDOWNLOAD,修改名称：RENAME，
    /// 删除目录：ONEDELFORDER，删除文件：ONEDELFILE,下载单个个文件：ONEDOWNLOAD，用户登录：USERLOGIN]
    /// </summary>
    public enum ActionType
    {
        /// 一键上传:ALLUPLOAD，一键同步：ALLDOWNLOAD,修改名称：RENAME，
        /// 删除目录：ONEDELFORDER，删除文件：ONEDELFILE,下载单个个文件：ONEDOWNLOAD，用户登录：USERLOGIN],单个文件上传
        ALLUPLOAD = 0,
        ALLDOWNLOAD = 1,
        RENAME = 2,
        ONEDELFORDER = 3,
        ONEDELFILE = 4,
        ONEDOWNLOAD = 5,
        USERLOGIN = 6,
        ONEUPLOAD = 7,
        MULTIDOWNLOAD = 8,
        MULTIDELETE = 9,
        RENAMEFORDER = 10,
        ONEDOWNLOADFORDER = 11,
        OPENSOFTWARECHEM = 12,
    }
}
