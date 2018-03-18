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

namespace FileManager
{
    public partial class FrmFileRename : CCSkinMain
    {
        private int type;
        private Model.FileModel file ;
        private Model.ForderModel forder ;
        public FrmFileRename(int type,Model.FileModel file,Model.ForderModel forder)
        {
            InitializeComponent();
            this.type = type;
            this.file = file;
            this.forder = forder;
            if (type == 1)
            {
                this.skinRadioButton_file.Enabled = false;
                this.skinRadioButton_forder.Select();
                this.skinTextBox_oldName.SkinTxt.Text = forder.Title;
            }
            else
            {
                this.skinRadioButton_forder.Enabled = false;
                this.skinRadioButton_file.Select();
                this.skinTextBox_oldName.SkinTxt.Text = file.File_Name;
            }
            this.skinTextBox_oldName.SkinTxt.ReadOnly = true;
        }

        /// <summary>
        /// 确定修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string newName = this.skinTextBox_newName.SkinTxt.Text.Trim();
                string oldName = this.skinTextBox_oldName.SkinTxt.Text;

                if (string.IsNullOrEmpty(newName))
                {
                    MessageBoxEx.Show("名称不能为空！");
                    return;
                }

                if (newName == oldName)
                {
                    MessageBoxEx.Show("名称不能和旧名称一样！");
                    return;
                }

                if (this.type == 1)
                {
                    BLL.ForderBll bll = new BLL.ForderBll();
                    bll.UpdateField(this.forder.ID, string.Format(" Title = '{0}' " , newName));
                }
                else
                {
                    BLL.FileBll bll = new BLL.FileBll();
                    bll.UpdateField(this.file.ID, string.Format( " File_Name ='{0}' " , newName));
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ee)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                MessageBoxEx.Show("修改失败！" + ee.Message);
            }
        }
    }
}
