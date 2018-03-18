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
    public partial class FrmDownLoadSelect : CCSkinMain
    {
        public FrmDownLoadSelect()
        {
            InitializeComponent();

            //下载提示
            //if (type == 1)
            //{
            //    this.skinButton1.Text = "下载最新文件";
            //    this.skinButton2.Text = "下载所有文件";
            //    this.skinButton3.Text = "取消下载";
            //}
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Retry;
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
