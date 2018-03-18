namespace FileManager
{
    partial class FrmFileProgressBar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFileProgressBar));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinLabel_success = new CCWin.SkinControl.SkinLabel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.skinLabel_fail = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_tip = new CCWin.SkinControl.SkinLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.skinProgressBar1 = new CCWin.SkinControl.SkinProgressBar();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.skinPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinPanel1.Controls.Add(this.skinLabel_success);
            this.skinPanel1.Controls.Add(this.textBox2);
            this.skinPanel1.Controls.Add(this.skinLabel_fail);
            this.skinPanel1.Controls.Add(this.skinLabel_tip);
            this.skinPanel1.Controls.Add(this.textBox1);
            this.skinPanel1.Controls.Add(this.skinProgressBar1);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(4, 26);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(782, 450);
            this.skinPanel1.TabIndex = 1;
            // 
            // skinLabel_success
            // 
            this.skinLabel_success.AutoSize = true;
            this.skinLabel_success.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_success.BorderColor = System.Drawing.Color.White;
            this.skinLabel_success.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_success.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.skinLabel_success.Location = new System.Drawing.Point(3, 106);
            this.skinLabel_success.Name = "skinLabel_success";
            this.skinLabel_success.Size = new System.Drawing.Size(92, 17);
            this.skinLabel_success.TabIndex = 7;
            this.skinLabel_success.Text = "成功上传文件：";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox2.ForeColor = System.Drawing.Color.Red;
            this.textBox2.Location = new System.Drawing.Point(0, 341);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(779, 99);
            this.textBox2.TabIndex = 6;
            // 
            // skinLabel_fail
            // 
            this.skinLabel_fail.AutoSize = true;
            this.skinLabel_fail.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_fail.BorderColor = System.Drawing.Color.White;
            this.skinLabel_fail.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_fail.ForeColor = System.Drawing.Color.Red;
            this.skinLabel_fail.Location = new System.Drawing.Point(3, 318);
            this.skinLabel_fail.Name = "skinLabel_fail";
            this.skinLabel_fail.Size = new System.Drawing.Size(104, 17);
            this.skinLabel_fail.TabIndex = 5;
            this.skinLabel_fail.Text = "未成功上传文件：";
            // 
            // skinLabel_tip
            // 
            this.skinLabel_tip.AutoSize = true;
            this.skinLabel_tip.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_tip.BorderColor = System.Drawing.Color.White;
            this.skinLabel_tip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_tip.ForeColor = System.Drawing.Color.Red;
            this.skinLabel_tip.Location = new System.Drawing.Point(337, 68);
            this.skinLabel_tip.Name = "skinLabel_tip";
            this.skinLabel_tip.Size = new System.Drawing.Size(0, 21);
            this.skinLabel_tip.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.ForeColor = System.Drawing.Color.Navy;
            this.textBox1.Location = new System.Drawing.Point(0, 126);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(779, 178);
            this.textBox1.TabIndex = 3;
            // 
            // skinProgressBar1
            // 
            this.skinProgressBar1.Back = null;
            this.skinProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.skinProgressBar1.BarBack = null;
            this.skinProgressBar1.ForeColor = System.Drawing.Color.Red;
            this.skinProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.skinProgressBar1.Name = "skinProgressBar1";
            this.skinProgressBar1.Size = new System.Drawing.Size(782, 57);
            this.skinProgressBar1.TabIndex = 2;
            this.skinProgressBar1.TrackFore = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.skinLabel1.Location = new System.Drawing.Point(3, 72);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(273, 17);
            this.skinLabel1.TabIndex = 1;
            this.skinLabel1.Text = "总共需要上传1000个文件，目前已上传500个文件";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmFileProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.BackShade = false;
            this.CanResize = false;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 22;
            this.ClientSize = new System.Drawing.Size(790, 480);
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
            this.Name = "FrmFileProgressBar";
            this.Radius = 1;
            this.RestoreDownBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreDownBack")));
            this.RestoreMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreMouseBack")));
            this.RestoreNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreNormlBack")));
            this.RoundStyle = CCWin.SkinClass.RoundStyle.None;
            this.ShowDrawIcon = false;
            this.SkinOpacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件上传下载";
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(13, 4);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFileTransferNew_FormClosing);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private System.Windows.Forms.Timer timer1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinProgressBar skinProgressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private CCWin.SkinControl.SkinLabel skinLabel_tip;
        private System.Windows.Forms.TextBox textBox2;
        private CCWin.SkinControl.SkinLabel skinLabel_fail;
        private CCWin.SkinControl.SkinLabel skinLabel_success;

    }
}

