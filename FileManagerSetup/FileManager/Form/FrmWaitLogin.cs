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
using FileManager.Common;
using FileManager.DAL;
using FileManager.BLL;

namespace FileManager
{
    public partial class FrmWaitLogin : CCSkinMain
    {
        private string forderPath;
        private FileManager.Model.UserModel user;
        private int type = 0;
        private int parentId = 0;
    }
}
