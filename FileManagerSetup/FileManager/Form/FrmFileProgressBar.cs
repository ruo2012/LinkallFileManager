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
    public partial class FrmFileProgressBar : CCSkinMain
    {
        private int actionType;
        public FrmFileProgressBar(int actionType)
        {
            InitializeComponent();
            this.actionType = actionType;
            FrmFileUp();
        }

        private SkinFileTransfersItem item;
        private long totalSize;
        public void FrmFileUp()
        {
            var cacheToActionFiles = FileWinexploer.NeedAddOrMordifyFiles;
            string actionName = actionType == 0 ? "上传文件到服务器" : "下载文件到客户端本地";
            FileTransfersItemStyle style = actionType == 0 ? FileTransfersItemStyle.Send : FileTransfersItemStyle.Receive;

            if (cacheToActionFiles != null && cacheToActionFiles.Count > 0)
            {
                this.skinProgressBar1.Maximum = cacheToActionFiles.Count;
            }
        }

        public static int IsActionEnd(string key)
        {
            ///为防止程序死掉，默认都是完成状态
            if (FileWinexploer.NeedAddOrMordifyFiles == null || FileWinexploer.NeedAddOrMordifyFiles.Count == 0) return 1;
            Model.FileModel model;
            if (FileWinexploer.NeedAddOrMordifyFiles.TryGetValue(key, out model))
            {
                if (model == null) return 1;
                if (model.ActionNum == 10)
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
        /// 临时存储
        /// </summary>
        private Dictionary<string, Model.FileModel> DoneAddOrMordifyFiles = new Dictionary<string, Model.FileModel>();
        private Dictionary<string, string> DoneNotSuccessFiles = new Dictionary<string, string>();

        /// <summary>
        /// 获取目前新增的文件集合
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Model.FileModel> GetAddFiles()
        {
            Dictionary<string, Model.FileModel> retDics = new Dictionary<string, Model.FileModel>();
            if (FileWinexploer.NeedAddOrMordifyFiles == null || FileWinexploer.NeedAddOrMordifyFiles.Count == 0)
            {
                return retDics;
            }

            foreach (var item in FileWinexploer.NeedAddOrMordifyFiles.Keys)
            {
                if (string.IsNullOrEmpty(item)) continue;

                Model.FileModel mode = FileWinexploer.NeedAddOrMordifyFiles[item];
                if (DoneAddOrMordifyFiles.ContainsKey(item))
                {
                    continue;
                }
                if (mode == null || mode.ActionNum != 10)
                {
                    continue;
                }
                DoneAddOrMordifyFiles.Add(item, mode);
                retDics.Add(item, mode);
            }
            return retDics;
        }

        /// <summary>
        /// 获取目前新增的文件集合
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetNotSuccessFiles()
        {
            Dictionary<string, string> retDics = new Dictionary<string, string>();
            if (FileWinexploer.NotSuccessFiles == null || FileWinexploer.NotSuccessFiles.Count == 0)
            {
                return retDics;
            }

            foreach (string item in FileWinexploer.NotSuccessFiles.Keys)
            {
                if (string.IsNullOrEmpty(item)) continue;

                if (DoneNotSuccessFiles.ContainsKey(item))
                {
                    continue;
                }
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                DoneNotSuccessFiles.Add(item, item);
                retDics.Add(item, item);
            }
            return retDics;
        }

        /// <summary>
        /// 定时刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            int addCount = GetNotEndCount();
            int totalCount = FileWinexploer.NeedAddOrMordifyFiles.Count;

            // 更新已经上传的文件
            var addItems = GetAddFiles();
            if (addItems.Count > 0)
            {
                foreach (var item in addItems.Keys)
                {
                    Model.FileModel mode = addItems[item];

                    if (!FileWinexploer.NotSuccessFiles.ContainsKey(item))
                    {
                        this.textBox1.AppendText(string.Format("\r\n文件{0}成功：客户端路径{1}", actionType == 1 ? "下载" : "上传", item));
                        Application.DoEvents();
                    }
                }
            }

            if (addCount > 0)
            {
                this.skinProgressBar1.Value = FileWinexploer.NeedAddOrMordifyFiles.Count - addCount;
                this.skinLabel1.Text = string.Format("总共需要{2}{0}个文件，目前已{2}{1}个文件;！", totalCount, this.skinProgressBar1.Value, actionType == 1 ? "下载" : "上传");
                Application.DoEvents();
            }
            else
            {
                this.skinProgressBar1.Value = FileWinexploer.NeedAddOrMordifyFiles.Count - addCount;
                this.skinLabel1.Text = string.Format("总共需要{2}{0}个文件，目前已{2}{1}个文件;已经完成！", totalCount, this.skinProgressBar1.Value, actionType == 1 ? "下载" : "上传");
                Application.DoEvents();

                this.skinLabel_tip.Visible = true;
                this.skinLabel_tip.Text = string.Format("恭喜您，{0}完成！", actionType == 1 ? "下载" : "上传");
                Application.DoEvents();

                timer1.Stop();
            }

            // 更新已经上传的文件
            var addNotSuccessItems = GetNotSuccessFiles();
            if (addNotSuccessItems.Count > 0)
            {
                foreach (var item in addNotSuccessItems.Keys)
                {
                    this.textBox2.AppendText(string.Format("\r\n文件{0}没有成功：客户端路径{1}", actionType == 1 ? "下载" : "上传", item));
                    Application.DoEvents();
                }
            }

            this.skinLabel_success.Text = string.Format("成功{1}文件：{0}个", (this.skinProgressBar1.Value - DoneNotSuccessFiles.Count).ToString(), actionType == 1 ? "下载" : "上传");
            this.skinLabel_fail.Text = string.Format("未成功{1}文件：{0}个", DoneNotSuccessFiles.Count, actionType == 1 ? "下载" : "上传");
            Application.DoEvents();
        }

        private void FrmFileTransferNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //取消"关闭窗口"事件
                e.Cancel = true;
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

        /// <summary>
        /// 获取未完成数量
        /// </summary>
        /// <returns></returns>
        private int GetNotEndCount()
        {
            int totalCount = 0;
            if (FileWinexploer.NeedAddOrMordifyFiles != null && FileWinexploer.NeedAddOrMordifyFiles.Count > 0)
            {
                foreach (var item in FileWinexploer.NeedAddOrMordifyFiles.Keys)
                {
                    Model.FileModel mode = FileWinexploer.NeedAddOrMordifyFiles[item];
                    if (mode != null && mode.ActionNum != 10)
                    {
                        totalCount++;
                    }
                }
            }
            return totalCount;
        }
    }
}
