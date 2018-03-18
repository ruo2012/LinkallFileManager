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

namespace FileManager
{
    public partial class FrmFileProperty : CCSkinMain
    {
        private int type;
        private Model.FileModel file;
        public FrmFileProperty(int actionType, int type, Model.FileModel file)
        {
            InitializeComponent();
            this.type = type;
            this.file = file;
            //文件夹
            if (type == 1)
            {
                this.skinRadioButton_file.Enabled = false;
                this.skinRadioButton_forder.Select();
                this.skinTextBox_size.Visible = false;
            }
            else
            {
                this.skinRadioButton_forder.Enabled = false;
                this.skinRadioButton_file.Select();
            }

            //初始化人员信息
            InitCreateUser();
            InitUiView();

            ///如果是属性查看，禁止所有可修改控件
            if (actionType == 0)
            {
                this.btnOK.Enabled = false;
                this.skinTextBox_addTime.SkinTxt.ReadOnly = true;
                this.skinTextBox_modifyTime.SkinTxt.ReadOnly = true;
                this.skinTextBox_name.SkinTxt.ReadOnly = true;
                this.skinComboBox_createUser.Enabled = false;
                this.skinTextBox_clientPath.SkinTxt.ReadOnly = true;
            }
        }

        /// <summary>
        /// 初始化人员
        /// </summary>
        private void InitCreateUser()
        {
            //获取所有用户
            BLL.ManagerBll mBll = new BLL.ManagerBll();
            List<Model.UserModel> users = mBll.GetModelList(1000, " isLock = 0 ", " RoleType desc ");

            if (users != null && users.Count > 0)
            {
                bool isHaveUser = false;
                foreach (var item in users)
                {
                    string showText = string.Format("{0}({1})", item.UserName, item.RealName);
                    this.skinComboBox_createUser.Items.Add(new ListItem(showText, item));
                    if (this.file != null && !string.IsNullOrEmpty(this.file.UserName) && item.UserName == this.file.UserName)
                    {
                        this.skinComboBox_createUser.SelectedItem = new ListItem(showText, item);
                        isHaveUser = true;
                    }
                }
                if (!isHaveUser)
                {
                    this.skinComboBox_createUser.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// 初始化UI
        /// </summary>
        /// <param name="file"></param>
        private void InitUiView()
        {
            this.skinTextBox_addTime.SkinTxt.Text = file.Add_Time.ToString();
            this.skinTextBox_modifyTime.SkinTxt.Text = new DateTime(file.File_Modify_Time).ToString();
            this.skinTextBox_name.SkinTxt.Text = file.File_Name;
            this.skinTextBox_size.SkinTxt.Text = file.File_Size.ToString();
            this.skinTextBox_clientPath.SkinTxt.Text = file.ClientPath;
            this.skinTextBox_lastVer.SkinTxt.Text = file.File_LastVersion.ToString();
        }

        /// <summary>
        /// 修改属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string addTimeStr = this.skinTextBox_addTime.SkinTxt.Text.Trim();
                string modifyTimeStr = this.skinTextBox_modifyTime.SkinTxt.Text.Trim();
                string name = this.skinTextBox_name.SkinTxt.Text.Trim();
                ListItem selectItem = (ListItem)this.skinComboBox_createUser.SelectedItem;

                Model.UserModel createUser = (Model.UserModel)selectItem.Value;

                DateTime addTime = DateTime.Now;
                DateTime modifyTime = DateTime.Now;

                if (createUser == null || string.IsNullOrEmpty(createUser.UserName))
                {
                    MessageBoxEx.Show("所选用户信息不正确！");
                    return;
                }

                if (string.IsNullOrEmpty(name))
                {
                    MessageBoxEx.Show("名称不能为空！");
                    return;
                }

                if (string.IsNullOrEmpty(addTimeStr) || !DateTime.TryParse(addTimeStr, out addTime))
                {
                    MessageBoxEx.Show("添加时间不正确！");
                    return;
                }

                if (string.IsNullOrEmpty(modifyTimeStr) || !DateTime.TryParse(modifyTimeStr, out modifyTime))
                {
                    MessageBoxEx.Show("修改时间不正确！");
                    return;
                }

                this.file.Add_Time = addTime;
                this.file.File_Modify_Time = modifyTime.Ticks;
                this.file.File_Name = name;
                this.file.UserId = createUser.ID;
                this.file.UserName = createUser.UserName;

                BLL.FileBll bll = new BLL.FileBll();
                //string updateValue = string.Format(" name = {0},modifyTime = {1} ,createUser = {2} , addTime={3}");
                //bll.UpdateField(this.file.ID, updateValue);
                bool ret = bll.Update(file);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                MessageBoxEx.Show("修改成功！");
            }
            catch (Exception ee)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                MessageBoxEx.Show("修改失败！" + ee.Message);
            }
        }
    }
}
