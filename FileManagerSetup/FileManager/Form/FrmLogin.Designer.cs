namespace FileManager
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.skinLabel_errorMsg = new CCWin.SkinControl.SkinLabel();
            this.skinTextBox_pwd = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinTextBox_account = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.buttonLogin = new CCWin.SkinControl.SkinButton();
            this.checkBoxRememberPwd = new CCWin.SkinControl.SkinCheckBox();
            this.checkBoxAutoLogin = new CCWin.SkinControl.SkinCheckBox();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.skinToolStrip5 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripButton_systemSetting = new System.Windows.Forms.ToolStripButton();
            this.skinPanel1.SuspendLayout();
            this.skinPanel2.SuspendLayout();
            this.skinTextBox_pwd.SuspendLayout();
            this.skinTextBox_account.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.skinToolStrip5.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.White;
            this.skinPanel1.Controls.Add(this.skinPanel2);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(7, 47);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(621, 315);
            this.skinPanel1.TabIndex = 1;
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.BackgroundImage = global::FileManager.Properties.Resources.login2_3;
            this.skinPanel2.Controls.Add(this.skinLabel_errorMsg);
            this.skinPanel2.Controls.Add(this.skinTextBox_pwd);
            this.skinPanel2.Controls.Add(this.skinLabel2);
            this.skinPanel2.Controls.Add(this.skinTextBox_account);
            this.skinPanel2.Controls.Add(this.skinLabel1);
            this.skinPanel2.Controls.Add(this.buttonLogin);
            this.skinPanel2.Controls.Add(this.checkBoxRememberPwd);
            this.skinPanel2.Controls.Add(this.checkBoxAutoLogin);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(0, 0);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(621, 315);
            this.skinPanel2.TabIndex = 0;
            // 
            // skinLabel_errorMsg
            // 
            this.skinLabel_errorMsg.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel_errorMsg.AutoSize = true;
            this.skinLabel_errorMsg.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_errorMsg.BorderColor = System.Drawing.Color.Red;
            this.skinLabel_errorMsg.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinLabel_errorMsg.ForeColor = System.Drawing.Color.Red;
            this.skinLabel_errorMsg.Location = new System.Drawing.Point(339, 201);
            this.skinLabel_errorMsg.Name = "skinLabel_errorMsg";
            this.skinLabel_errorMsg.Size = new System.Drawing.Size(189, 17);
            this.skinLabel_errorMsg.TabIndex = 181;
            this.skinLabel_errorMsg.Text = "*  出错啦，请输入账号密码登录！";
            this.skinLabel_errorMsg.Visible = false;
            // 
            // skinTextBox_pwd
            // 
            this.skinTextBox_pwd.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_pwd.DownBack = null;
            this.skinTextBox_pwd.Icon = null;
            this.skinTextBox_pwd.IconIsButton = false;
            this.skinTextBox_pwd.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_pwd.Location = new System.Drawing.Point(396, 113);
            this.skinTextBox_pwd.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_pwd.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_pwd.MouseBack = null;
            this.skinTextBox_pwd.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_pwd.Name = "skinTextBox_pwd";
            this.skinTextBox_pwd.NormlBack = null;
            this.skinTextBox_pwd.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_pwd.Size = new System.Drawing.Size(189, 28);
            // 
            // skinTextBox_pwd.BaseText
            // 
            this.skinTextBox_pwd.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_pwd.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_pwd.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_pwd.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_pwd.SkinTxt.Name = "BaseText";
            this.skinTextBox_pwd.SkinTxt.PasswordChar = '*';
            this.skinTextBox_pwd.SkinTxt.Size = new System.Drawing.Size(179, 18);
            this.skinTextBox_pwd.SkinTxt.TabIndex = 0;
            this.skinTextBox_pwd.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_pwd.SkinTxt.WaterText = "";
            this.skinTextBox_pwd.TabIndex = 140;
            // 
            // skinLabel2
            // 
            this.skinLabel2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.ForeColor = System.Drawing.Color.Black;
            this.skinLabel2.Location = new System.Drawing.Point(339, 118);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(44, 17);
            this.skinLabel2.TabIndex = 139;
            this.skinLabel2.Text = "密码：";
            // 
            // skinTextBox_account
            // 
            this.skinTextBox_account.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_account.DownBack = null;
            this.skinTextBox_account.Icon = null;
            this.skinTextBox_account.IconIsButton = false;
            this.skinTextBox_account.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_account.Location = new System.Drawing.Point(396, 72);
            this.skinTextBox_account.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_account.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_account.MouseBack = null;
            this.skinTextBox_account.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_account.Name = "skinTextBox_account";
            this.skinTextBox_account.NormlBack = null;
            this.skinTextBox_account.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_account.Size = new System.Drawing.Size(189, 28);
            // 
            // skinTextBox_account.BaseText
            // 
            this.skinTextBox_account.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_account.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_account.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_account.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_account.SkinTxt.Name = "BaseText";
            this.skinTextBox_account.SkinTxt.Size = new System.Drawing.Size(179, 18);
            this.skinTextBox_account.SkinTxt.TabIndex = 0;
            this.skinTextBox_account.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_account.SkinTxt.WaterText = "";
            this.skinTextBox_account.TabIndex = 138;
            // 
            // skinLabel1
            // 
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.Black;
            this.skinLabel1.Location = new System.Drawing.Point(339, 77);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(44, 17);
            this.skinLabel1.TabIndex = 137;
            this.skinLabel1.Text = "账号：";
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonLogin.BackRectangle = new System.Drawing.Rectangle(50, 23, 50, 23);
            this.buttonLogin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(118)))), ((int)(((byte)(156)))));
            this.buttonLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.buttonLogin.Create = true;
            this.buttonLogin.DownBack = global::FileManager.Properties.Resources.button_login_down;
            this.buttonLogin.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.buttonLogin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.buttonLogin.ForeColor = System.Drawing.Color.Black;
            this.buttonLogin.Location = new System.Drawing.Point(385, 228);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLogin.MouseBack = global::FileManager.Properties.Resources.button_login_hover;
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.NormlBack = global::FileManager.Properties.Resources.button_login_normal;
            this.buttonLogin.Palace = true;
            this.buttonLogin.Size = new System.Drawing.Size(185, 49);
            this.buttonLogin.TabIndex = 133;
            this.buttonLogin.Text = "登        录";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // checkBoxRememberPwd
            // 
            this.checkBoxRememberPwd.AutoSize = true;
            this.checkBoxRememberPwd.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxRememberPwd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checkBoxRememberPwd.DefaultCheckButtonWidth = 15;
            this.checkBoxRememberPwd.DownBack = null;
            this.checkBoxRememberPwd.Enabled = false;
            this.checkBoxRememberPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxRememberPwd.ForeColor = System.Drawing.Color.Black;
            this.checkBoxRememberPwd.LightEffect = false;
            this.checkBoxRememberPwd.Location = new System.Drawing.Point(342, 164);
            this.checkBoxRememberPwd.MouseBack = null;
            this.checkBoxRememberPwd.Name = "checkBoxRememberPwd";
            this.checkBoxRememberPwd.NormlBack = ((System.Drawing.Image)(resources.GetObject("checkBoxRememberPwd.NormlBack")));
            this.checkBoxRememberPwd.SelectedDownBack = null;
            this.checkBoxRememberPwd.SelectedMouseBack = null;
            this.checkBoxRememberPwd.SelectedNormlBack = null;
            this.checkBoxRememberPwd.Size = new System.Drawing.Size(75, 21);
            this.checkBoxRememberPwd.TabIndex = 131;
            this.checkBoxRememberPwd.Text = "记住密码";
            this.checkBoxRememberPwd.UseVisualStyleBackColor = false;
            this.checkBoxRememberPwd.Visible = false;
            // 
            // checkBoxAutoLogin
            // 
            this.checkBoxAutoLogin.AutoSize = true;
            this.checkBoxAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxAutoLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checkBoxAutoLogin.DefaultCheckButtonWidth = 15;
            this.checkBoxAutoLogin.DownBack = null;
            this.checkBoxAutoLogin.Enabled = false;
            this.checkBoxAutoLogin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.checkBoxAutoLogin.ForeColor = System.Drawing.Color.Black;
            this.checkBoxAutoLogin.LightEffect = false;
            this.checkBoxAutoLogin.Location = new System.Drawing.Point(423, 164);
            this.checkBoxAutoLogin.MouseBack = null;
            this.checkBoxAutoLogin.Name = "checkBoxAutoLogin";
            this.checkBoxAutoLogin.NormlBack = ((System.Drawing.Image)(resources.GetObject("checkBoxAutoLogin.NormlBack")));
            this.checkBoxAutoLogin.SelectedDownBack = null;
            this.checkBoxAutoLogin.SelectedMouseBack = null;
            this.checkBoxAutoLogin.SelectedNormlBack = null;
            this.checkBoxAutoLogin.Size = new System.Drawing.Size(75, 21);
            this.checkBoxAutoLogin.TabIndex = 132;
            this.checkBoxAutoLogin.Text = "自动登录";
            this.checkBoxAutoLogin.UseVisualStyleBackColor = false;
            this.checkBoxAutoLogin.Visible = false;
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("skinPictureBox1.Image")));
            this.skinPictureBox1.Location = new System.Drawing.Point(12, 13);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(151, 28);
            this.skinPictureBox1.TabIndex = 2;
            this.skinPictureBox1.TabStop = false;
            // 
            // skinToolStrip5
            // 
            this.skinToolStrip5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinToolStrip5.Arrow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.skinToolStrip5.AutoSize = false;
            this.skinToolStrip5.Back = System.Drawing.Color.White;
            this.skinToolStrip5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.skinToolStrip5.BackRadius = 4;
            this.skinToolStrip5.BackRectangle = new System.Drawing.Rectangle(5, 5, 5, 5);
            this.skinToolStrip5.Base = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.skinToolStrip5.BaseFore = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.skinToolStrip5.BaseForeAnamorphosis = false;
            this.skinToolStrip5.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip5.BaseForeAnamorphosisColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.skinToolStrip5.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.skinToolStrip5.BaseHoverFore = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.skinToolStrip5.BaseItemAnamorphosis = true;
            this.skinToolStrip5.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.skinToolStrip5.BaseItemBorderShow = true;
            this.skinToolStrip5.BaseItemDown = null;
            this.skinToolStrip5.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skinToolStrip5.BaseItemMouse = null;
            this.skinToolStrip5.BaseItemNorml = null;
            this.skinToolStrip5.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip5.BaseItemRadius = 2;
            this.skinToolStrip5.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip5.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skinToolStrip5.BindTabControl = null;
            this.skinToolStrip5.Dock = System.Windows.Forms.DockStyle.None;
            this.skinToolStrip5.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip5.Fore = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.skinToolStrip5.GripMargin = new System.Windows.Forms.Padding(0);
            this.skinToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip5.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip5.ItemAnamorphosis = false;
            this.skinToolStrip5.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.skinToolStrip5.ItemBorderShow = false;
            this.skinToolStrip5.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.skinToolStrip5.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.skinToolStrip5.ItemRadius = 3;
            this.skinToolStrip5.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_systemSetting});
            this.skinToolStrip5.Location = new System.Drawing.Point(508, 1);
            this.skinToolStrip5.Name = "skinToolStrip5";
            this.skinToolStrip5.Padding = new System.Windows.Forms.Padding(0);
            this.skinToolStrip5.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip5.Size = new System.Drawing.Size(63, 26);
            this.skinToolStrip5.SkinAllColor = true;
            this.skinToolStrip5.TabIndex = 172;
            this.skinToolStrip5.Text = "skinToolStrip5";
            this.skinToolStrip5.TitleAnamorphosis = false;
            this.skinToolStrip5.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.skinToolStrip5.TitleRadius = 4;
            this.skinToolStrip5.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripButton_systemSetting
            // 
            this.toolStripButton_systemSetting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_systemSetting.AutoSize = false;
            this.toolStripButton_systemSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_systemSetting.Image = global::FileManager.Properties.Resources.icon_setting1;
            this.toolStripButton_systemSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_systemSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_systemSetting.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton_systemSetting.Name = "toolStripButton_systemSetting";
            this.toolStripButton_systemSetting.Size = new System.Drawing.Size(24, 23);
            this.toolStripButton_systemSetting.Text = "系统设置";
            this.toolStripButton_systemSetting.ToolTipText = "系统设置";
            this.toolStripButton_systemSetting.Click += new System.EventHandler(this.toolStripButton_systemSetting_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.BackShade = false;
            this.CanResize = false;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 22;
            this.ClientSize = new System.Drawing.Size(635, 369);
            this.CloseBoxSize = new System.Drawing.Size(27, 22);
            this.CloseDownBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseDownBack")));
            this.CloseMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseMouseBack")));
            this.CloseNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseNormlBack")));
            this.Controls.Add(this.skinToolStrip5);
            this.Controls.Add(this.skinPictureBox1);
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
            this.Name = "FrmLogin";
            this.Radius = 1;
            this.RestoreDownBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreDownBack")));
            this.RestoreMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreMouseBack")));
            this.RestoreNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreNormlBack")));
            this.RoundStyle = CCWin.SkinClass.RoundStyle.None;
            this.ShowDrawIcon = false;
            this.SkinOpacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(13, 4);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel2.ResumeLayout(false);
            this.skinPanel2.PerformLayout();
            this.skinTextBox_pwd.ResumeLayout(false);
            this.skinTextBox_pwd.PerformLayout();
            this.skinTextBox_account.ResumeLayout(false);
            this.skinTextBox_account.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.skinToolStrip5.ResumeLayout(false);
            this.skinToolStrip5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinPanel skinPanel2;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip5;
        private System.Windows.Forms.ToolStripButton toolStripButton_systemSetting;
        private CCWin.SkinControl.SkinButton buttonLogin;
        private CCWin.SkinControl.SkinCheckBox checkBoxRememberPwd;
        private CCWin.SkinControl.SkinCheckBox checkBoxAutoLogin;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinTextBox skinTextBox_pwd;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinTextBox skinTextBox_account;
        private CCWin.SkinControl.SkinLabel skinLabel_errorMsg;

    }
}

