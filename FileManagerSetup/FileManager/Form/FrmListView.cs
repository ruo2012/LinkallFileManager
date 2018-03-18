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
    public partial class FrmListView : CCSkinMain
    {
        public FrmListView()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                ListViewItem fileItem = listView1.Items.Add("sssss"+i);
                fileItem.SubItems.Add("sss˭˭˭ˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮˮs");
                fileItem.SubItems.Add("fdsfds");
                fileItem.SubItems.Add("242342");
            }

            listView1.View = View.Details;

        }
    }
}
