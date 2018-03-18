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
using FileManager.Model;
using FileManager.BLL;

namespace FileManager
{
    public partial class FrmFileLogDetail : CCSkinMain
    {
        private int type;
        private Model.FileLogModel fileLog;
        private Model.ForderModel forder;
        public FrmFileLogDetail(int actionType, int type, Model.FileLogModel fileLog)
        {
            InitializeComponent();
            this.type = type;
            this.fileLog = fileLog;
            this.forder = new BLL.ForderBll().GetModel(fileLog.FileID);
            //文件夹
            if (type == 1)
            {
                this.skinRadioButton_file.Enabled = false;
                this.skinRadioButton_forder.Select();
            }
            else
            {
                this.skinRadioButton_forder.Enabled = false;
                this.skinRadioButton_file.Select();
            }

            if (fileLog.ActionType == ActionType.RENAMEFORDER.ToString())
            {
                this.skinRadioButton_file.Enabled = false;
                this.skinRadioButton_forder.Select();
            }

            InitUiView();

            ///如果是属性查看，禁止所有可修改控件
            if (actionType == 0)
            {
                //this.btnOK.Enabled = false;
                this.skinTextBox_addTime.SkinTxt.ReadOnly = true;
                this.skinTextBox_modifyTime.SkinTxt.ReadOnly = true;
                this.skinTextBox_name.SkinTxt.ReadOnly = true;
                this.skinTextBox_clientPath.SkinTxt.ReadOnly = true;
            }
        }

        /// <summary>
        /// 初始化UI
        /// </summary>
        /// <param name="file"></param>
        private void InitUiView()
        {
            this.skinTextBox_addTime.SkinTxt.Text = forder.Add_Time.ToString();
            this.skinTextBox_modifyTime.SkinTxt.Text = new DateTime(forder.Forder_Modify_Time).ToString();
            this.skinTextBox_name.SkinTxt.Text = forder.Title;
            this.skinTextBox_clientPath.SkinTxt.Text = forder.ClientPath;
            this.skinTextBox_logDetail.SkinTxt.Text = fileLog.Remark == null ? string.Empty : fileLog.Remark;
        }
    }
}
