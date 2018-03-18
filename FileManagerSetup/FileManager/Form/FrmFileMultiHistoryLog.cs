using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using FileManager.BLL;

namespace FileManager
{
    /// <summary>
    /// 单个文件日志记录
    /// </summary>
    public partial class FrmFileMultiHistoryLog : CCSkinMain
    {
        private string code;
        /// <summary>
        /// 文件信息
        /// </summary>
        /// <param name="file"></param>
        public FrmFileMultiHistoryLog( string code)
        {
            InitializeComponent();
            this.code = code;
            InitData();
        }
        
        /// <summary>
        /// 数据初始化
        /// </summary>
        private void InitData()
        {
            BLL.FileLogBll fLogBll = new BLL.FileLogBll();
            DataSet ds = fLogBll.GetAllInfoList(1000, " fl.IsDeleted = 0 and fl.actionCode = '" + code + "'", " fl.AddTime desc, fl.id asc");
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable orgdt = ds.Tables[0];
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("FileName");
                dt.Columns.Add("file_user_name");
                dt.Columns.Add("file_user_realname");
                dt.Columns.Add("file_version");
                dt.Columns.Add("ActionName");
                dt.Columns.Add("file_modifyTime");
                dt.Columns.Add("file_userName");
                dt.Columns.Add("ComputerName");
                dt.Columns.Add("file_userIp");
                dt.Columns.Add("file_size");
                dt.Columns.Add("downLink");
                dt.Columns.Add("saveas");
                dt.Columns.Add("File_ID");
                dt.Columns.Add("ClientPath");
                dt.Columns.Add("remark");

                if (orgdt != null && orgdt.Rows.Count > 0)
                {
                    Model.UserModel user = Bll.SystemBll.UserInfo;
                    for (int i = 0; i < orgdt.Rows.Count; i++)
                    {
                        DataRow row = dt.NewRow();
                        row[0] = orgdt.Rows[i]["FileVerID"].ToString();
                        row[1] = orgdt.Rows[i]["FileName"].ToString();

                        string userName = orgdt.Rows[i]["file_user_name"].ToString();
                        string userRealName = orgdt.Rows[i]["file_user_realname"].ToString();

                        if (string.IsNullOrEmpty(userName))
                        {
                            row[2] = user.UserName;
                            row[3] = user.RealName;
                        }
                        else
                        {
                            row[2] = userName;
                            row[3] = userRealName;
                        }

                        row[4] = orgdt.Rows[i]["FileVer"].ToString();
                        row[5] = orgdt.Rows[i]["ActionName"].ToString();
                        row[6] =  orgdt.Rows[i]["AddTime"].ToString();
                        row[7] = orgdt.Rows[i]["UserName"].ToString();
                        row[8] = string.Empty;
                        row[9] = orgdt.Rows[i]["Ip"].ToString();
                        row[10] = string.Empty;
                        row[11] = "下载到本地";
                        row[12] = "另存为";
                        row[13] = orgdt.Rows[i]["FileID"];
                        row[14] = orgdt.Rows[i]["ClientPath"];
                        row[15] = orgdt.Rows[i]["remark"];

                        dt.Rows.Add(row);
                    }
                }
                this.skinDataGridView_history.DataSource = dt;
            }
        }

        /// <summary>
        /// 版本历史记录单元格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinDataGridView_history_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 80)
            {
                try
                {
                    #region 文件下载和同步处理
                    int fileID = int.Parse(this.skinDataGridView_history.Rows[e.RowIndex].Cells[10].Value.ToString());
                    int verID = int.Parse(this.skinDataGridView_history.Rows[e.RowIndex].Cells[0].Value.ToString());
                    FileBll fileBll = new FileBll();
                    Model.FileModel fileModel = fileBll.GetModel(fileID);

                    if (fileModel == null || string.IsNullOrEmpty(fileModel.File_Name))
                    {
                        MessageBoxEx.Show("该文件的信息异常！");
                        return;
                    }

                    FileVersionBll verBll = new FileVersionBll();
                    var content = verBll.GetContent(verID);
                    var fileVer = verBll.GetModel(verID);

                    //同步
                    if (e.ColumnIndex == 8)
                    {
                        if (string.IsNullOrEmpty(fileModel.ClientPath))
                        {
                            MessageBoxEx.Show("该文件的客户端路径不正确！");
                            return;
                        }

                        FileWinexploer.CreateFile(content, fileModel.ClientPath, fileVer.File_Modify_Time);
                        MessageBoxEx.Show("同步到客户端成功！");
                        return;
                    }

                    //另存为
                    if (e.ColumnIndex ==9)
                    {
                        //获取文件信息
                        this.saveFileDialog1.Filter = string.Format("*{0}|*.*", fileModel.File_Ext); ;
                        this.saveFileDialog1.ShowDialog();
                        string fileSavePath = this.saveFileDialog1.FileName;

                        if (string.IsNullOrEmpty(fileSavePath))
                        {
                            return;
                        }

                        //文件存放路径
                        string newPath  = fileSavePath.EndsWith( fileModel.File_Ext)?fileSavePath: fileSavePath + fileModel.File_Ext;
                        FileWinexploer.CreateFile(content, newPath,fileVer.File_Modify_Time);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show(ex.Message);
                }
            }
        }
    }
}
