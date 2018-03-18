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
    public partial class FrmFileHistoryRecord : CCSkinMain
    {
        private Model.FileModel file;

        public FrmFileHistoryRecord(Model.FileModel file)
        {
            InitializeComponent();
            this.file = file;
            InitData();
        }
        
        /// <summary>
        /// 数据初始化
        /// </summary>
        private void InitData()
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("file_version");
            //dt.Columns.Add("file_modifyTime");
            //dt.Columns.Add("file_userName");
            //dt.Columns.Add("file_size");
            //dt.Columns.Add("downLink");

            //for (int i = 0; i < 10; i++)
            //{
            //    DataRow row = dt.NewRow();
            //    row[0] = "1.0";
            //    row[1] = "2015-02-02";
            //    row[2] = "王君海";
            //    row[3] = "20M";
            //    row[4] = "下载";
            //    dt.Rows.Add(row);
            //}

            BLL.FileVersionBll verBll = new BLL.FileVersionBll();
            DataSet ds = verBll.GetList(" isdeleted = 0 and File_Id = " + file.ID, " ver desc, id asc");
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable orgdt = ds.Tables[0];
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("file_version");
                dt.Columns.Add("file_modifyTime");
                dt.Columns.Add("file_userName");
                dt.Columns.Add("ComputerName");
                dt.Columns.Add("file_userIp");
                dt.Columns.Add("file_size");
                dt.Columns.Add("downLink");
                dt.Columns.Add("saveas");
                dt.Columns.Add("File_ID");
                dt.Columns.Add("ClientPath");

                if (orgdt != null && orgdt.Rows.Count > 0)
                {
                    for (int i = 0; i < orgdt.Rows.Count; i++)
                    {
                        DataRow row = dt.NewRow();
                        row[0] = orgdt.Rows[i]["id"].ToString();
                        row[1] = orgdt.Rows[i]["Ver"].ToString();
                        row[2] = new DateTime(long.Parse(orgdt.Rows[i]["File_Modify_Time"].ToString())).ToString();
                        row[3] = orgdt.Rows[i]["UserName"].ToString();
                        row[4] = orgdt.Rows[i]["ComputerName"].ToString();
                        row[5] = orgdt.Rows[i]["Ip"].ToString();
                        row[6] = Bll.SystemBll.ChangeFileSize( orgdt.Rows[i]["File_Size"].ToString());
                        row[7] = "下载到本地";
                        row[8] = "另存为";
                        row[9] = orgdt.Rows[i]["File_ID"];
                        row[10] = orgdt.Rows[i]["ClientPath"];

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
            if (e.ColumnIndex >= 7)
            {
                try
                {
                    #region 文件下载和同步处理
                    int fileID = int.Parse(this.skinDataGridView_history.Rows[e.RowIndex].Cells[9].Value.ToString());
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
                    if (e.ColumnIndex == 7)
                    {
                        if (string.IsNullOrEmpty(fileModel.ClientPath))
                        {
                            MessageBoxEx.Show("该文件的客户端路径不正确！");
                            return;
                        }

                        FileWinexploer.CreateFile(content, fileModel.ClientPath, fileVer.File_Modify_Time);
                        //同步到本地
                        //LinkLabel linkLabel = new LinkLabel();
                        //linkLabel.Text = "测试";
                        //this.skinDataGridView_history.Rows[e.RowIndex].Cells[e.ColumnIndex] = linkLabel;
                        UnzipFile(fileModel.ClientPath);

                        MessageBoxEx.Show("同步到客户端成功！");
                        return;
                    }

                    //另存为
                    if (e.ColumnIndex ==8)
                    {
                        //获取文件信息
                        this.saveFileDialog1.Filter = string.Format("*{0}|*.*", fileModel.File_Ext); ;
                        this.saveFileDialog1.ShowDialog();
                        string fileSavePath = this.saveFileDialog1.FileName;

                        if (string.IsNullOrEmpty(fileSavePath))
                        {
                            //MessageBoxEx.Show("必须填写一个正确的路径！");
                            return;
                        }

                        //文件存放路径
                        string newPath  = fileSavePath.EndsWith( fileModel.File_Ext)?fileSavePath: fileSavePath + fileModel.File_Ext;
                        FileWinexploer.CreateFile(content, newPath,fileVer.File_Modify_Time);
                        UnzipFile(newPath);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show(ex.Message);
                }
            }
        }

        private void UnzipFile(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            if(file.Exists && file.Extension.ToLower()==".ztlj")
            {
                string forderName = file.Name.Substring(0, file.Name.Length - 5);
                string forderPath =Path.Combine( file.Directory.FullName,forderName) ;
                if (Directory.Exists(forderPath))
                {
                    Directory.Delete(forderPath,true);
                }

                Directory.CreateDirectory(forderPath);
                UnZipFloClass unzip = new UnZipFloClass();
                unzip.unZipFile(filePath, forderPath);
            }
        }
    }
}
