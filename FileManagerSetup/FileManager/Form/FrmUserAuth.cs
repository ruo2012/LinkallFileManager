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
    public partial class FrmUserAuth : CCSkinMain
    {
        private int userId;
        private string userName;
        private string userRealName;
        private int isLock;
        public FrmUserAuth(int userId, string userName, string userRealName, int isLock)
        {
            InitializeComponent();

            this.userId = userId;
            this.userName = userName;
            this.userRealName = userRealName;
            this.isLock = isLock;

            this.linkLabel_userName.Text = userName;
            this.linkLabel_realName.Text = userRealName;
            this.skinRadioButton_lock.Checked = isLock == 1;
            this.skinRadioButton_unLock.Checked = isLock == 0;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            isLock = this.skinRadioButton_lock.Checked ? 1 : 0;
            BLL.ManagerBll managerBll = new BLL.ManagerBll();
            managerBll.UpdateField(userId, " IsLock = " + isLock);
        }
    }
}
