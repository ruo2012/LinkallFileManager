using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CCWin.Win32;
using CCWin.Win32.Const;
using System.Diagnostics;
using System.Configuration;
using Microsoft.Win32;

namespace GG2014
{
    public partial class BaseForm : CCSkinMain
    {
        public BaseForm()
        {
            InitializeComponent();            
        }

        #region UseCustomIcon
        private bool useCustomIcon = false;
        /// <summary>
        /// 是否使用自己的图标。
        /// </summary>
        public bool UseCustomIcon
        {
            get { return useCustomIcon; }
            set { useCustomIcon = value; }
        } 
        #endregion

        #region UseCustomBackImage
        private bool useCustomBackImage = false;
        /// <summary>
        /// 是否使用自己的背景图片
        /// </summary>
        public bool UseCustomBackImage
        {
            get { return useCustomBackImage; }
            set { useCustomBackImage = value; }
        } 
        #endregion

        private void OrayForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (!this.useCustomIcon)
                {
                    //this.Icon = GlobalResourceManager.Icon64;
                }

                if (!this.useCustomBackImage)
                {
                    //this.Back = GlobalResourceManager.MainBackImage;
                }                
            }           
        }
         
    }
}
