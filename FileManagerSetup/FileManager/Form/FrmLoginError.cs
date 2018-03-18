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
using FileManager.Bll;

namespace FileManager
{
    public partial class FrmLoginError : CCSkinMain
    {
        public FrmLoginError(string msg)
        {
            InitializeComponent();
            this.skinLabel4.Text = GetAutoLineValue(msg,25);
            this.linkLabel_userName.Text = System.Environment.UserName;
        }

        /// <summary>
        /// 根据字数限制，自动换行
        /// </summary>
        /// <param name="orgMsg"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        private string GetAutoLineValue(string orgMsg, int limit)
        {
            string newMsg = string.Empty;
            int totolNum = 0;
            if (!string.IsNullOrEmpty(orgMsg) && orgMsg.Length > limit)
            {
                for (int i = 0; i < orgMsg.Length / limit; i++)
                {
                    int newNum = totolNum + limit;
                    newMsg += orgMsg.Substring(totolNum, newNum - totolNum) + "  " + Environment.NewLine;
                    totolNum = newNum;
                }

                if (orgMsg.Length % limit > 0)
                {
                    newMsg += orgMsg.Substring(totolNum, orgMsg.Length % limit) + "  " + Environment.NewLine;
                }
            }
            else
            {
                return orgMsg;
            }

            return newMsg;
        }

        private void skinButton_sysConfigSetting_Click(object sender, EventArgs e)
        {
            FrmSystemSetting frmSysConfig = new FrmSystemSetting(0);
            frmSysConfig.ShowDialog()  ;
        }

        private void skinButton_loginSystem_Click(object sender, EventArgs e)
        {
            bool isLinkSuccess = SystemBll.SystemLinkCheck();
            if (!isLinkSuccess)
            {
                MessageBox.Show("系统的连接错误,请重新设置服务器连接地址！");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
