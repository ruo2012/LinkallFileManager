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
    public partial class FrmLogin : CCSkinMain
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private int errorLoginCount = 0;
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.skinLabel_errorMsg.Visible = false;
            this.skinLabel_errorMsg.Text = string.Empty;

            string account = this.skinTextBox_account.SkinTxt.Text.Trim();
            string pwd = this.skinTextBox_pwd.SkinTxt.Text.Trim();
            if (string.IsNullOrEmpty(account))
            {
                MessageBoxEx.Show("账号信息不能为空！");
                return;
            }

            if (string.IsNullOrEmpty(pwd))
            {
                MessageBoxEx.Show("密码信息不能为空！");
                return;
            }

            // 域账号登录验证
            try
            {
                this.skinLabel_errorMsg.Text = string.Format("该账号：{0}，正在登录域,请等候...", account);
                Application.DoEvents();

                UserLoginForDomainBll bll = new UserLoginForDomainBll();

                // 获取配置信息
                var config = BLL.SystemConfigBll.GetConfig();

                if (this.errorLoginCount > 4)
                {
                    MessageBoxEx.Show(string.Format("该账号：{0}，连续输错密码5次,已被锁定,请联系管理员！", account));
                    this.skinLabel_errorMsg.Text = string.Format("该账号：{0}，连续输错密码5次,已被锁定,请联系管理员！", account);
                    this.skinLabel_errorMsg.Visible = true;

                    // 锁定账号

                    return;
                }

                //if (!bll.ImpersonateValidUser(account, config.Domin, pwd))
                    if (!bll.ImpersonateValidUser2(account, config.Domin, pwd))
                //if (!bll.AuthDomainUserByAdHelper(account, config.Domin, pwd))
                {
                    this.errorLoginCount += 1;
                    MessageBoxEx.Show(string.Format("该账号：{0}，登录域失败 ，账号或者密码错误！", account));
                    this.skinLabel_errorMsg.Text = string.Format("该账号：{0}，登录域失败，账号或者密码错误！", account);
                    this.skinLabel_errorMsg.Visible = true;
                    return;
                }

                try
                {
                    //new UserLoginForDomainBll().AuthDomainUserAuth();
                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(string.Format("该账号：{0}，登录域失败 ，请联系管理员处理！", account));
                this.skinLabel_errorMsg.Text = string.Format("该账号：{0}，登录域失败！", account);
                this.skinLabel_errorMsg.Visible = true;
                return;
            }

            //获取系统账号
            Model.UserModel user = Bll.SystemBll.GetUserInfo(account);

            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.RealName))
            {
                MessageBoxEx.Show(string.Format("该账号：{0}，不存在或者密码错误，请联系管理员处理！", account) + Bll.SystemBll.ManagerLinkInfo);
                this.skinLabel_errorMsg.Text = string.Format("该账号：{0}，不存在或者密码错误！", account);
                this.skinLabel_errorMsg.Visible = true;
                return;
            }

            if (user.IsLock == 1)
            {
                MessageBoxEx.Show(string.Format("该账号：{0}，已经被锁定 ，请联系管理员处理！", account) + Bll.SystemBll.ManagerLinkInfo);
                this.skinLabel_errorMsg.Text = string.Format("该账号：{0}，没有权限！", account);
                this.skinLabel_errorMsg.Visible = true;
                return;
            }

            Bll.SystemBll.UserInfo = user;

           

            // 异步日志
            SystemBll.ActionLogAsyn( 0,string.Empty,string.Empty, Model.ActionType.USERLOGIN);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void toolStripButton_systemSetting_Click(object sender, EventArgs e)
        {
            FrmDominSetting frm = new FrmDominSetting();
            frm.ShowDialog();
        }
    }
}
