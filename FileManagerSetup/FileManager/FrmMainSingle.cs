using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FileManager
{
    public class FrmMainSingle
    {
        private static FrmMain _mainForm;

        public static FrmMain MainForm
        {
            get
            {
                if (_mainForm == null)
                {
                    _mainForm = new FrmMain();
                    _mainForm.FrmTipUpload = new FrmTipUpload();
                }
                return _mainForm;
            }
            set { _mainForm = value; }
        }
    }
}
