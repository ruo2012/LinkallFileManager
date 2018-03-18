namespace FileManager
{
    partial class FrmDominSetting
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDominSetting));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinLabel_errorMsg = new CCWin.SkinControl.SkinLabel();
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinTextBox_softwareName = new CCWin.SkinControl.SkinTextBox();
            this.skinButton_selectPath = new CCWin.SkinControl.SkinButton();
            this.skinTextBox_chemPath = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinTextBox_dominName = new CCWin.SkinControl.SkinTextBox();
            this.skinButton_cancel = new CCWin.SkinControl.SkinButton();
            this.btnOk = new CCWin.SkinControl.SkinButton();
            this.BaseText = new CCWin.SkinControl.SkinWaterTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.skinPanel1.SuspendLayout();
            this.skinGroupBox2.SuspendLayout();
            this.skinTextBox_softwareName.SuspendLayout();
            this.skinTextBox_chemPath.SuspendLayout();
            this.skinTextBox_dominName.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.White;
            this.skinPanel1.Controls.Add(this.skinButton1);
            this.skinPanel1.Controls.Add(this.skinLabel_errorMsg);
            this.skinPanel1.Controls.Add(this.skinGroupBox2);
            this.skinPanel1.Controls.Add(this.skinButton_cancel);
            this.skinPanel1.Controls.Add(this.btnOk);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(4, 26);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(409, 253);
            this.skinPanel1.TabIndex = 1;
            // 
            // skinLabel_errorMsg
            // 
            this.skinLabel_errorMsg.AutoSize = true;
            this.skinLabel_errorMsg.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_errorMsg.BorderColor = System.Drawing.Color.White;
            this.skinLabel_errorMsg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_errorMsg.ForeColor = System.Drawing.Color.Red;
            this.skinLabel_errorMsg.Location = new System.Drawing.Point(18, 217);
            this.skinLabel_errorMsg.Name = "skinLabel_errorMsg";
            this.skinLabel_errorMsg.Size = new System.Drawing.Size(68, 17);
            this.skinLabel_errorMsg.TabIndex = 170;
            this.skinLabel_errorMsg.Text = "错误信息！";
            this.skinLabel_errorMsg.Visible = false;
            // 
            // skinGroupBox2
            // 
            this.skinGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.skinGroupBox2.Controls.Add(this.skinLabel3);
            this.skinGroupBox2.Controls.Add(this.skinTextBox_softwareName);
            this.skinGroupBox2.Controls.Add(this.skinButton_selectPath);
            this.skinGroupBox2.Controls.Add(this.skinTextBox_chemPath);
            this.skinGroupBox2.Controls.Add(this.skinLabel4);
            this.skinGroupBox2.Controls.Add(this.skinLabel1);
            this.skinGroupBox2.Controls.Add(this.skinTextBox_dominName);
            this.skinGroupBox2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.skinGroupBox2.Location = new System.Drawing.Point(16, 15);
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.Size = new System.Drawing.Size(379, 153);
            this.skinGroupBox2.TabIndex = 167;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.Text = "文件管理服务器配置信息";
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.Color.White;
            // 
            // skinLabel3
            // 
            this.skinLabel3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.ForeColor = System.Drawing.Color.Black;
            this.skinLabel3.Location = new System.Drawing.Point(9, 71);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(68, 17);
            this.skinLabel3.TabIndex = 149;
            this.skinLabel3.Text = "进程名称：";
            // 
            // skinTextBox_softwareName
            // 
            this.skinTextBox_softwareName.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_softwareName.DownBack = null;
            this.skinTextBox_softwareName.Icon = null;
            this.skinTextBox_softwareName.IconIsButton = false;
            this.skinTextBox_softwareName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_softwareName.Location = new System.Drawing.Point(92, 66);
            this.skinTextBox_softwareName.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_softwareName.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_softwareName.MouseBack = null;
            this.skinTextBox_softwareName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_softwareName.Name = "skinTextBox_softwareName";
            this.skinTextBox_softwareName.NormlBack = null;
            this.skinTextBox_softwareName.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_softwareName.Size = new System.Drawing.Size(212, 28);
            // 
            // skinTextBox_softwareName.BaseText
            // 
            this.skinTextBox_softwareName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_softwareName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_softwareName.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_softwareName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_softwareName.SkinTxt.Name = "BaseText";
            this.skinTextBox_softwareName.SkinTxt.Size = new System.Drawing.Size(202, 18);
            this.skinTextBox_softwareName.SkinTxt.TabIndex = 0;
            this.skinTextBox_softwareName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_softwareName.SkinTxt.WaterText = "";
            this.skinTextBox_softwareName.TabIndex = 150;
            // 
            // skinButton_selectPath
            // 
            this.skinButton_selectPath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinButton_selectPath.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButton_selectPath.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_selectPath.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButton_selectPath.DownBack")));
            this.skinButton_selectPath.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton_selectPath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton_selectPath.ForeColor = System.Drawing.Color.Black;
            this.skinButton_selectPath.Location = new System.Drawing.Point(311, 110);
            this.skinButton_selectPath.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton_selectPath.MouseBack")));
            this.skinButton_selectPath.Name = "skinButton_selectPath";
            this.skinButton_selectPath.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton_selectPath.NormlBack")));
            this.skinButton_selectPath.Size = new System.Drawing.Size(56, 24);
            this.skinButton_selectPath.TabIndex = 148;
            this.skinButton_selectPath.Text = "选择";
            this.skinButton_selectPath.UseVisualStyleBackColor = false;
            this.skinButton_selectPath.Click += new System.EventHandler(this.skinButton_selectPath_Click);
            // 
            // skinTextBox_chemPath
            // 
            this.skinTextBox_chemPath.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_chemPath.DownBack = null;
            this.skinTextBox_chemPath.Icon = null;
            this.skinTextBox_chemPath.IconIsButton = false;
            this.skinTextBox_chemPath.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_chemPath.Location = new System.Drawing.Point(93, 106);
            this.skinTextBox_chemPath.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_chemPath.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_chemPath.MouseBack = null;
            this.skinTextBox_chemPath.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_chemPath.Name = "skinTextBox_chemPath";
            this.skinTextBox_chemPath.NormlBack = null;
            this.skinTextBox_chemPath.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_chemPath.Size = new System.Drawing.Size(211, 28);
            // 
            // skinTextBox_chemPath.BaseText
            // 
            this.skinTextBox_chemPath.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_chemPath.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_chemPath.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_chemPath.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_chemPath.SkinTxt.Name = "BaseText";
            this.skinTextBox_chemPath.SkinTxt.Size = new System.Drawing.Size(201, 18);
            this.skinTextBox_chemPath.SkinTxt.TabIndex = 0;
            this.skinTextBox_chemPath.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_chemPath.SkinTxt.WaterText = "";
            this.skinTextBox_chemPath.TabIndex = 145;
            // 
            // skinLabel4
            // 
            this.skinLabel4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.ForeColor = System.Drawing.Color.Black;
            this.skinLabel4.Location = new System.Drawing.Point(9, 111);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(91, 17);
            this.skinLabel4.TabIndex = 144;
            this.skinLabel4.Text = "Chem32路径：";
            // 
            // skinLabel1
            // 
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.Black;
            this.skinLabel1.Location = new System.Drawing.Point(9, 31);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(56, 17);
            this.skinLabel1.TabIndex = 136;
            this.skinLabel1.Text = "域名称：";
            // 
            // skinTextBox_dominName
            // 
            this.skinTextBox_dominName.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_dominName.DownBack = null;
            this.skinTextBox_dominName.Icon = null;
            this.skinTextBox_dominName.IconIsButton = false;
            this.skinTextBox_dominName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_dominName.Location = new System.Drawing.Point(92, 26);
            this.skinTextBox_dominName.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_dominName.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_dominName.MouseBack = null;
            this.skinTextBox_dominName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_dominName.Name = "skinTextBox_dominName";
            this.skinTextBox_dominName.NormlBack = null;
            this.skinTextBox_dominName.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_dominName.Size = new System.Drawing.Size(212, 28);
            // 
            // skinTextBox_dominName.BaseText
            // 
            this.skinTextBox_dominName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_dominName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_dominName.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_dominName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_dominName.SkinTxt.Name = "BaseText";
            this.skinTextBox_dominName.SkinTxt.Size = new System.Drawing.Size(202, 18);
            this.skinTextBox_dominName.SkinTxt.TabIndex = 0;
            this.skinTextBox_dominName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_dominName.SkinTxt.WaterText = "";
            this.skinTextBox_dominName.TabIndex = 137;
            // 
            // skinButton_cancel
            // 
            this.skinButton_cancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinButton_cancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButton_cancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.skinButton_cancel.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButton_cancel.DownBack")));
            this.skinButton_cancel.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton_cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton_cancel.ForeColor = System.Drawing.Color.Black;
            this.skinButton_cancel.Location = new System.Drawing.Point(251, 210);
            this.skinButton_cancel.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton_cancel.MouseBack")));
            this.skinButton_cancel.Name = "skinButton_cancel";
            this.skinButton_cancel.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton_cancel.NormlBack")));
            this.skinButton_cancel.Size = new System.Drawing.Size(69, 24);
            this.skinButton_cancel.TabIndex = 138;
            this.skinButton_cancel.Text = "取消";
            this.skinButton_cancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOk.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.btnOk.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOk.DownBack = ((System.Drawing.Image)(resources.GetObject("btnOk.DownBack")));
            this.btnOk.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(326, 210);
            this.btnOk.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseBack")));
            this.btnOk.Name = "btnOk";
            this.btnOk.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnOk.NormlBack")));
            this.btnOk.Size = new System.Drawing.Size(69, 24);
            this.btnOk.TabIndex = 139;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // BaseText
            // 
            this.BaseText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BaseText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseText.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.BaseText.Location = new System.Drawing.Point(5, 5);
            this.BaseText.Name = "BaseText";
            this.BaseText.Size = new System.Drawing.Size(253, 18);
            this.BaseText.TabIndex = 0;
            this.BaseText.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.BaseText.WaterText = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButton1.DownBack")));
            this.skinButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton1.ForeColor = System.Drawing.Color.Black;
            this.skinButton1.Location = new System.Drawing.Point(16, 176);
            this.skinButton1.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton1.MouseBack")));
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton1.NormlBack")));
            this.skinButton1.Size = new System.Drawing.Size(100, 24);
            this.skinButton1.TabIndex = 171;
            this.skinButton1.Text = "数据库地址设置";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // FrmDominSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.BackShade = false;
            this.CanResize = false;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 22;
            this.ClientSize = new System.Drawing.Size(417, 283);
            this.CloseBoxSize = new System.Drawing.Size(27, 22);
            this.CloseDownBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseDownBack")));
            this.CloseMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseMouseBack")));
            this.CloseNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseNormlBack")));
            this.Controls.Add(this.skinPanel1);
            this.EffectBack = System.Drawing.Color.Black;
            this.EffectCaption = CCWin.TitleType.Title;
            this.EffectWidth = 0;
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaxDownBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxDownBack")));
            this.MaximizeBox = false;
            this.MaxMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxMouseBack")));
            this.MaxNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.MaxNormlBack")));
            this.MaxSize = new System.Drawing.Size(27, 22);
            this.MiniDownBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniDownBack")));
            this.MiniMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniMouseBack")));
            this.MiniNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniNormlBack")));
            this.MiniSize = new System.Drawing.Size(27, 22);
            this.Name = "FrmDominSetting";
            this.Radius = 1;
            this.RestoreDownBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreDownBack")));
            this.RestoreMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreMouseBack")));
            this.RestoreNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreNormlBack")));
            this.RoundStyle = CCWin.SkinClass.RoundStyle.None;
            this.ShowDrawIcon = false;
            this.SkinOpacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置";
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(13, 4);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.skinGroupBox2.ResumeLayout(false);
            this.skinGroupBox2.PerformLayout();
            this.skinTextBox_softwareName.ResumeLayout(false);
            this.skinTextBox_softwareName.PerformLayout();
            this.skinTextBox_chemPath.ResumeLayout(false);
            this.skinTextBox_chemPath.PerformLayout();
            this.skinTextBox_dominName.ResumeLayout(false);
            this.skinTextBox_dominName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinButton skinButton_cancel;
        private CCWin.SkinControl.SkinButton btnOk;
        private CCWin.SkinControl.SkinTextBox skinTextBox_dominName;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox2;
        private CCWin.SkinControl.SkinTextBox skinTextBox_chemPath;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private CCWin.SkinControl.SkinLabel skinLabel_errorMsg;
        private CCWin.SkinControl.SkinWaterTextBox BaseText;
        private CCWin.SkinControl.SkinButton skinButton_selectPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinTextBox skinTextBox_softwareName;
        private CCWin.SkinControl.SkinButton skinButton1;

    }
}

