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
using CCWin.SkinControl;
using FileManager.Properties;
using System.Threading;

namespace FileManager
{
    public partial class FrmFileTransferNew : CCSkinMain
    {
        private int actionType;
        public FrmFileTransferNew(int actionType)
        {
            InitializeComponent();
            this.actionType = actionType;
            if (actionType == 1)
            {
                this.skinLabel19.Text = "文件下载成功";
            }
            this.skinDataGridView10.AutoGenerateColumns = false;
            FrmFileUp();
        }

        private Color _baseColor = Color.FromArgb(0, 0, 64);//Color.FromArgb(0, 50, 90);
        private Color _borderColor = Color.FromArgb(64, 64, 0);
        private Color _progressBarBarColor = Color.Gold;
        private Color _progressBarBorderColor = Color.FromArgb(0, 95, 147);
        private Color _progressBarTextColor = Color.FromArgb(0, 95, 147);

        private readonly int SPEED_MAX = 3024 * 3224;
        private SkinFileTransfersItem item;
        private long totalSize;
        public void FrmFileUp()
        {
            var cacheToActionFiles = FileWinexploer.NeedAddOrMordifyFiles;
            string actionName = actionType == 0 ? "上传文件到服务器" : "下载文件到客户端本地";
            FileTransfersItemStyle style = actionType == 0 ? FileTransfersItemStyle.Send : FileTransfersItemStyle.Receive;
            if (cacheToActionFiles != null && cacheToActionFiles.Count > 0)
            {
                //item = fileTansfersContainer1.AddItem(
                //    actionName,
                //    "",
                //    Resources._14,
                //    totalSize,
                //    style);
                //item.BaseColor = _baseColor;
                //item.BorderColor = _borderColor;
                //item.ProgressBarBarColor = _progressBarBarColor;
                //item.ProgressBarBorderColor = _progressBarBorderColor;
                //item.ProgressBarTextColor = _progressBarTextColor;
                //item.CancelButtonClick += new EventHandler(item_CancelButtonClick);

                this.skinFileTransfersItem1.Text = actionName;
                this.skinFileTransfersItem1.FileName = "sssssssssss";
                this.skinFileTransfersItem1.FileSize = 0;
                this.skinFileTransfersItem1.Text = actionName;
                this.skinFileTransfersItem1.Image = Resources._14;
                this.skinFileTransfersItem1.Style = style;

                //this.skinFileTransfersItem1.BaseColor = _baseColor;
                //this.skinFileTransfersItem1.BorderColor = _borderColor;
                this.skinFileTransfersItem1.ProgressBarBarColor = _progressBarBarColor;
                this.skinFileTransfersItem1.ProgressBarBorderColor = _progressBarBorderColor;
                this.skinFileTransfersItem1.ProgressBarTextColor = _progressBarTextColor;
                this.skinFileTransfersItem1.CancelButtonClick += new EventHandler(item_CancelButtonClick);
                this.skinFileTransfersItem1.Start();
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("key");
            dt.Columns.Add("file_type");
            dt.Columns.Add("file_name");
            dt.Columns.Add("file_size");
            dt.Columns.Add("state");

            foreach (var item in cacheToActionFiles)
            {
                Model.FileModel file = item.Value;
                DataRow row = dt.NewRow();
                row[0] = file.ClientPath;
                row[1] = "文件";
                row[2] = file.File_Name;
                row[3] = file.File_Size;
                row[4] = GetActionName(file.ActionNum);
                dt.Rows.Add(row);
                totalSize += file.File_Size;
            }
            this.skinDataGridView10.DataSource = dt;
        }
        private string GetActionName(int type)
        {
            switch (type)
            {
                case -1:
                    return "出现异常";
                case 0:
                    return "不操作";
                case 1:
                    return "新增";
                case 2:
                    return "修改";
                case 10:
                    return "已完成";
                default:
                    return "已完成";
            }
        }

        /// <summary>
        /// 拒绝文件传输
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void item_RefuseButtonClick(object sender, EventArgs e)
        {
            SkinFileTransfersItem item = sender as SkinFileTransfersItem;
            MessageBox.Show(string.Format(
               "点击了 {0} - {1}，拒绝接收文件。",
               item.Text,
               item.FileName));
        }

        void item_SaveToButtonClick(object sender, EventArgs e)
        {
            SkinFileTransfersItem item = sender as SkinFileTransfersItem;
            MessageBox.Show(string.Format(
               "点击了 {0} - {1}，保存文件到...。",
               item.Text,
               item.FileName));
        }

        /// <summary>
        /// 取消文件上传、文件下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void item_CancelButtonClick(object sender, EventArgs e)
        {
            SkinFileTransfersItem item = sender as SkinFileTransfersItem;
            MessageBox.Show(string.Format(
                "取消了 {0} - {1}，取消发送文件。",
                item.Text,
                item.FileName));
        }

        public static int IsActionEnd(string key)
        {
            ///为防止程序死掉，默认都是完成状态
            if (FileWinexploer.NeedAddOrMordifyFiles == null || FileWinexploer.NeedAddOrMordifyFiles.Count == 0) return 1;
            Model.FileModel model;
            if (FileWinexploer.NeedAddOrMordifyFiles.TryGetValue(key, out model))
            {
                if (model == null) return 1;
                if(model.ActionNum == 10)
                {
                    return 1;
                }
                else if (model.ActionNum == -1)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            return 1;
        }

        public static Model.FileModel LastActionFileName()
        {
            ///为防止程序死掉，默认都是完成状态
            if (FileWinexploer.NeedAddOrMordifyFiles == null || FileWinexploer.NeedAddOrMordifyFiles.Count == 0) return null;
            foreach (var item in FileWinexploer.NeedAddOrMordifyFiles.Keys)
            {
                Model.FileModel mode = FileWinexploer.NeedAddOrMordifyFiles[item];
                if (mode != null && mode.ActionNum != 10) return mode;
            }
            return null;
        }

        /// <summary>
        /// 定时刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region 测试
            int length = SPEED_MAX;
            if (this.skinFileTransfersItem1.TotalTransfersSize + length > skinFileTransfersItem1.FileSize)
            {
                this.skinFileTransfersItem1.TotalTransfersSize = 0;
                //换新文件
                Model.FileModel fileModel = LastActionFileName();
                if (fileModel != null)
                {
                    skinFileTransfersItem1.FileName = fileModel.File_Name;
                    skinFileTransfersItem1.FileSize = fileModel.File_Size;
                }
            }
            else
            {
                this.skinFileTransfersItem1.TotalTransfersSize += length;
            }
            #endregion

            #region 刷新左侧列表
            bool thisTimeHaveFile = false;
            foreach (DataGridViewRow row in this.skinDataGridView10.Rows)
            {
                if (row.Cells[4].Value.ToString() == "已完成" || row.Cells[4].Value.ToString() == "出现异常")
                {
                    continue;
                }
                string key = row.Cells[0].Value.ToString();
                if (IsActionEnd(key) ==1)
                {
                    row.Cells[4].Value = "已完成";
                    row.Cells[4].Style.ForeColor = Color.Red;
                }
                else if (IsActionEnd(key) == -1)
                {
                    row.Cells[4].Value = "出现异常";
                    row.Cells[4].Style.ForeColor = Color.Yellow;
                }
                else
                {
                    thisTimeHaveFile = true;
                }
            }

            if (!thisTimeHaveFile)
            {

                this.skinFileTransfersItem1.Enabled = false;
                this.skinFileTransfersItem1.Visible = false;

                if (fileTansfersContainer1.Controls.Count > 0)
                {
                    SkinFileTransfersItem item = (SkinFileTransfersItem)fileTansfersContainer1.Controls[fileTansfersContainer1.Controls.Count - 1];

                    fileTansfersContainer1.RemoveItem(item);
                }

                this.fileTansfersContainer1.Visible = false;
                this.skinPictureBox1.Visible = true;
                this.skinLabel19.Visible = true;
            }

            #endregion
        }

        private void FrmFileTransferNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //取消"关闭窗口"事件
                e.Cancel = true;
        
                //if (fileTansfersContainer1.Controls.Count > 0)
                //{
                //    //SkinFileTransfersItem item = (SkinFileTransfersItem)fileTansfersContainer1.Controls[fileTansfersContainer1.Controls.Count - 1];
                //    //fileTansfersContainer1.RemoveItem(item);
                //    this.timer1.Stop();
                //    //使关闭时窗口向右下角缩小的效果
                //    this.WindowState = FormWindowState.Minimized;
                //    this.ShowInTaskbar = true;
                //    this.ShowIcon = true;
                //    this.Hide();
                //    this.timer1.Start();
                //}
                //else
                //{
                //    this.timer1.Stop();
                //    this.skinFileTransfersItem1.Enabled = false;
                //    this.skinFileTransfersItem1.Visible = false;
                //}

                try
                {
                    this.timer1.Stop();

                    Thread.Sleep(1000);
                    this.Dispose(true);
                }
                catch (Exception ex)
                {

                }
                return;
            }
        }
    }
}
