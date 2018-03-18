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
    public partial class FrmFriendTip : CCSkinMain
    {
        public FrmFriendTip(string msg)
        {
            InitializeComponent();
            this.skinLabel4.Text = GetAutoLineValue(msg,25);
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
    }
}
