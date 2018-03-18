using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileManager.Form
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                ListViewItem fileItem = listView1.Items.Add("sssss" + i);
                fileItem.SubItems.Add("ssss");
                fileItem.SubItems.Add("fdsfds");
                fileItem.SubItems.Add("242342");
            }

            listView1.View = View.Details;
        }
    }
}
