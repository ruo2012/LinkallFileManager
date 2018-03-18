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
    public partial class FrmAutoSaveSetting : CCSkinMain
    {
        private Model.SystemConfig config;
        public FrmAutoSaveSetting()
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
                int autoUpdateInterval = config.AutoUpdateInterval;
                skinTextBox_setValue.SkinTxt.Text = autoUpdateInterval.ToString();
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
                string setValue = skinTextBox_setValue.SkinTxt.Text;
                int autoSaveSetValue = 0;
                if (string.IsNullOrEmpty(setValue))
                {
                    MessageBox.Show("请添加正确数字");
                    return;
                }
                if (!int.TryParse(setValue, out autoSaveSetValue) || autoSaveSetValue <= 0)
                {
                    MessageBox.Show("请添加整形数字");
                    return;
                }

                if (autoSaveSetValue < 120)
                {
                    MessageBox.Show("请添加120以上数字");
                    return;
                }
                config.AutoUpdateInterval = autoSaveSetValue;

                new SystemConfigBll().saveConifg(config);

                // 关掉timer,重启
                FrmMain mainForm = FrmMainSingle.MainForm;

                if (mainForm != null)
                {
                    mainForm.InitAutoUpdate();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("设置失败发生了异常 : ", ex.Message);
                return;
            }

            MessageBox.Show("设置成功！");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
