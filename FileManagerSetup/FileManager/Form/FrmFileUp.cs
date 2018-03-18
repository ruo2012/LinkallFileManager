using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using CCWin.SkinControl;
using FileManager.Properties;
using CCWin;

namespace FileManager
{
    public partial class FrmFileUp : CCSkinMain
    {
        private Random _random;
        private Color _baseColor = Color.DarkGoldenrod;
        private Color _borderColor = Color.FromArgb(64, 64, 0);
        private Color _progressBarBarColor = Color.Gold;
        private Color _progressBarBorderColor = Color.Olive;
        private Color _progressBarTextColor = Color.Olive;

        public FrmFileUp()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = fileTansfersContainer1;
            _random = new Random();
            SkinFileTransfersItem item;
            item = fileTansfersContainer1.AddItem(
                "发送文件",
                "123.rar",
                Resources._14,
                1024 * 1024 * 20,
                 FileTransfersItemStyle.Send);
            item.BaseColor = _baseColor;
            item.BorderColor = _borderColor;
            item.ProgressBarBarColor = _progressBarBarColor;
            item.ProgressBarBorderColor = _progressBarBorderColor;
            item.ProgressBarTextColor = _progressBarTextColor;
            item.CancelButtonClick += new EventHandler(item_CancelButtonClick);
            item.Start();

            item = fileTansfersContainer1.AddItem(
                "接收文件",
                "456.rar",
                Resources._14,
                1024 * 1024 * 10,
                 FileTransfersItemStyle.Receive);
            item.CancelButtonClick += new EventHandler(item_CancelButtonClick);
            item.Start();

            item = fileTansfersContainer1.AddItem(
               "接收文件",
               "789.rar",
               Resources._14 ,
               1024 * 1024 * 15,
                FileTransfersItemStyle.ReadyReceive);
            item.SaveButtonClick += new EventHandler(item_SaveButtonClick);
            item.SaveToButtonClick += new EventHandler(item_SaveToButtonClick);
            item.RefuseButtonClick += new EventHandler(item_RefuseButtonClick);
            item.Start();
        }

        void item_RefuseButtonClick(object sender, EventArgs e)
        {
            SkinFileTransfersItem item = sender as SkinFileTransfersItem;
            MessageBox.Show(string.Format(
               "点击了 {0} - {1}，拒绝接收文件。",
               item.Text,
               item.FileName));
        }

        void item_SaveToButtonClick(object sender, EventArgs e)
        {
            SkinFileTransfersItem item = sender as SkinFileTransfersItem;
            MessageBox.Show(string.Format(
               "点击了 {0} - {1}，保存文件到...。",
               item.Text,
               item.FileName));
        }

        void item_SaveButtonClick(object sender, EventArgs e)
        {
            SkinFileTransfersItem item = sender as SkinFileTransfersItem;
            MessageBox.Show(string.Format(
               "点击了 {0} - {1}，保存文件。",
               item.Text,
               item.FileName));
        }

        void item_CancelButtonClick(object sender, EventArgs e)
        {
            SkinFileTransfersItem item = sender as SkinFileTransfersItem;
            MessageBox.Show(string.Format(
                "点击了 {0} - {1}，取消发送文件。",
                item.Text,
                item.FileName));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int length = _random.Next(80, 150) * 1024;
            foreach (SkinFileTransfersItem item in fileTansfersContainer1.Controls)
            {
                if (item.TotalTransfersSize + length >
                    item.FileSize)
                {
                    item.TotalTransfersSize = 0;
                }
                else
                {
                    item.TotalTransfersSize += length;
                }
            }
        }
    }
}