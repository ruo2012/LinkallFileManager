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
using CCWin.Win32;
using System.Runtime.Remoting.Messaging;
using FileManager.Model;

namespace FileManager
{
    public partial class FrmTipUpload : CCSkinMain
    {
        private string softwareName;

        public string SoftwareName
        {
            get { return softwareName; }
            set { softwareName = value; }
        }
        private Model.UserProjectModel curProject;
        public FrmTipUpload(string softwareName)
        {
            InitializeComponent();
            this.softwareName = softwareName;
        }

        public FrmTipUpload()
        {
            InitializeComponent();
            this.softwareName = string.Empty;
        }

        public const int AW_SLIDE = 262144;
        public const int AW_VER_NEGATIVE = 8;

        //窗口加载时
        private void FrmTipUpload_Load(object sender, EventArgs e)
        {
            //初始化窗口出现位置
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            this.PointToScreen(p);
            this.Location = p;
            this.Visible = true;
            NativeMethods.AnimateWindow(this.Handle, 130, AW_SLIDE + AW_VER_NEGATIVE);//开始窗体动画
        }

        //倒计时6秒关闭弹出窗
        private void timShow_Tick(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

                Model.UserProjectModel curProject = null;
                Model.UserModel user = Bll.SystemBll.UserInfo;
                if (user == null || user.Projects == null || user.Projects.Count == 0)
                {
                    MessageBox.Show("账号信息不正确，请联系管理员处理！");
                    return;
                }

                foreach (var item in user.Projects)
                {
                    if (item.MonitoringSoftwareName == softwareName)
                    {
                        curProject = item;
                        break;
                    }
                }

                if (curProject == null)
                {
                    MessageBox.Show("工程信息绑定不正确，请联系管理员处理！");
                    return;
                    //curProject = user.Projects[0];
                }

                if (curProject == null || string.IsNullOrEmpty(curProject.MonitoringPath))
                {
                    MessageBox.Show("服务器配置路径不正确，请联系管理员处理！");
                    return;
                }

                //监控绑定路径
                string dirPath = curProject.MonitoringPath;
                if (!Directory.Exists(dirPath))
                {
                    MessageBox.Show("服务器配置路径不正确，请联系管理员处理！");
                    return;
                }

                //此处查询出所有文件内容
                DirectoryInfo rootDirInfo = new DirectoryInfo(dirPath);
                FileWinexploer upload = new FileWinexploer();
               
                //上传之前开启文件受影响检查
                user.CurProject = curProject;
                this.curProject = curProject;

                #region 20151104修改上传动画效果&初次上传大量文件卡死现象--删除
                //upload.CheckFolderUploadToDb(dirPath, user);
                //if (FileWinexploer.NeedAddOrMordifyFiles == null || FileWinexploer.NeedAddOrMordifyFiles.Count == 0)
                //{
                //    MessageBox.Show("没有可更新文件，不需要操作！");
                //    return;
                //}
                //else
                //{
                //    if (MessageBox.Show(
                //     string.Format("此次上传文件数量为:{0},是否继续上传！", FileWinexploer.NeedAddOrMordifyFiles.Count),
                //      "一键上传文件",
                //       MessageBoxButtons.OKCancel) == DialogResult.OK)
                //    {
                //        //检查通过开始异步上传
                //        FolderUploadHandler handler = new FolderUploadHandler(upload.FolderUploadToDb);
                //        handler.BeginInvoke(dirPath, user, IAsyncMenthod, null);

                //        ///异步日志
                //        ActionLog(string.Empty, ActionType.ALLUPLOAD);

                //        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //        return;

                //        //动态上传进度
                //        FrmFileTransferNew frmTransfer = new FrmFileTransferNew(0);
                //        frmTransfer.Show();
                //    }
                //}
                #endregion

                #region 20151104修改上传动画效果&初次上传大量文件卡死现象--修改

                // 提示是否上传|取消|上传差异
                string tip = FileWinexploer.ConstructUploadTip();
                FrmMessageBox messageBox = new FrmMessageBox(tip, 0);
                var result = messageBox.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                // 替换检查界面[8.5wjh]
                FrmWait frmCheckFile = new FrmWait(dirPath, user, 0);
                DialogResult frmCheckFileResult = frmCheckFile.ShowDialog();
                if (frmCheckFileResult != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                if (FileWinexploer.NeedAddOrMordifyFiles == null || FileWinexploer.NeedAddOrMordifyFiles.Count == 0)
                {
                    MessageBox.Show("上传完成！");
                    return;
                }
                else
                {
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        FileWinexploer.SetUploadCache();
                    }

                    // 0909 上传王君海修改
                    //FrmFileProgressBar frmTransfer = new FrmFileProgressBar(0);
 
                    //检查通过开始异步上传
                    FolderUploadHandler handler = new FolderUploadHandler(upload.FolderUploadToDb);
                    handler.BeginInvoke(dirPath, user, IAsyncMenthod, null);

                    ///异步日志
                    ActionLog(string.Empty, ActionType.ALLUPLOAD);

                    //frmTransfer.Activate();
                    //frmTransfer.Show();
                }
                #endregion

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 上传附件委托
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public delegate void FolderUploadHandler(string a, FileManager.Model.UserModel b);

        /// <summary>
        /// 异步回调
        /// </summary>
        /// <param name="result"></param>
        void IAsyncMenthod(IAsyncResult result)
        {
            FolderUploadHandler handler = (FolderUploadHandler)((AsyncResult)result).AsyncDelegate;
            handler.EndInvoke(result);
        }

        /// <summary>
        /// 操作日志记录
        /// </summary>
        /// <param name="clientPath"></param>
        /// <param name="action"></param>
        private void ActionLog(string clientPath, ActionType action)
        {
            if (curProject == null) return;

            if (string.IsNullOrEmpty(clientPath)) clientPath = curProject.MonitoringPath;

            Bll.SystemBll.ActionLogAsyn(curProject.ID, curProject.ProjectName, clientPath, action);
        }

        private void skinButton_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTipUpload_Shown(object sender, EventArgs e)
        {

        }
    }
}
