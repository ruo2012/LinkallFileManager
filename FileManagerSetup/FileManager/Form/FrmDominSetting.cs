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
using FileManager.Bll;

namespace FileManager
{
    public partial class FrmDominSetting : CCSkinMain
    {
        private Model.SystemConfig config;
        public FrmDominSetting()
        {
            InitializeComponent();
            InitUiData();
        }

        private void InitUiData()
        {
            // 获取配置信息
            config = BLL.SystemConfigBll.GetConfig();
            if (config != null)
            {
                skinTextBox_chemPath.SkinTxt.Text = config.Chem32Path;
                skinTextBox_dominName.SkinTxt.Text = config.Domin;
                skinTextBox_softwareName.SkinTxt.Text = config.SoftwareName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (config == null)
                {
                    MessageBox.Show("程序配置错误! 请重新设置");
                    return;
                }
                string chemPath = skinTextBox_chemPath.SkinTxt.Text;
                string domin = skinTextBox_dominName.SkinTxt.Text;
                string softwareName = skinTextBox_softwareName.SkinTxt.Text;

                if (string.IsNullOrEmpty(chemPath))
                {
                    MessageBox.Show("请选择正确的路径");
                    return;
                }

                if (string.IsNullOrEmpty(softwareName))
                {
                    MessageBox.Show("请选择正确的进程名称");
                    return;
                }

                if (string.IsNullOrEmpty(domin))
                {
                    MessageBox.Show("请填写正确的域名");
                    return;
                }
                config.Chem32Path = chemPath;
                config.Domin = domin;
                config.SoftwareName = softwareName;
                new SystemConfigBll().saveConifg(config);
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置失败发生了异常 : ", ex.Message);
                return;
            }

            MessageBox.Show("设置成功！");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void skinButton_selectPath_Click(object sender, EventArgs e)
        {
            DialogResult selectDialog = this.openFileDialog1.ShowDialog();
            if (selectDialog == System.Windows.Forms.DialogResult.OK)
            {
                this.skinTextBox_chemPath.SkinTxt.Text = this.openFileDialog1.FileName;
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            FrmSystemSetting frm = new FrmSystemSetting(0);
            frm.ShowDialog();
        }
    }
}
