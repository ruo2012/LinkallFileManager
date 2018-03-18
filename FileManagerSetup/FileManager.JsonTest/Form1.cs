using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileManager.JsonTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Common.LogHelper.WriteLog(string.Format("上传缓存：{0} \r\n", LitJson.JsonMapper.ToJson(FileWinexploer.NeedAddOrMordifyFiles)));

            var obj = LitJson.JsonMapper.ToObject<Dictionary<string, Model.FileModel>>(this.textBox1.Text.Trim());

            MessageBox.Show(obj.Count.ToString());
        }
    }
}
