namespace FileManager
{
    partial class FrmTipUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTipUpload));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinButton_cancel = new CCWin.SkinControl.SkinButton();
            this.btnOk = new CCWin.SkinControl.SkinButton();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.timShow = new System.Windows.Forms.Timer(this.components);
            this.skinPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.White;
            this.skinPanel1.Controls.Add(this.skinLabel2);
            this.skinPanel1.Controls.Add(this.skinButton_cancel);
            this.skinPanel1.Controls.Add(this.btnOk);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(4, 26);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(363, 165);
            this.skinPanel1.TabIndex = 1;
            // 
            // skinLabel2
            // 
            this.skinLabel2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.ForeColor = System.Drawing.Color.Maroon;
            this.skinLabel2.Location = new System.Drawing.Point(26, 49);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(165, 22);
            this.skinLabel2.TabIndex = 162;
            this.skinLabel2.Text = "文件到服务器，谢谢 !";
            // 
            // skinButton_cancel
            // 
            this.skinButton_cancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinButton_cancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButton_cancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_cancel.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButton_cancel.DownBack")));
            this.skinButton_cancel.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton_cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton_cancel.ForeColor = System.Drawing.Color.Black;
            this.skinButton_cancel.Location = new System.Drawing.Point(209, 97);
            this.skinButton_cancel.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton_cancel.MouseBack")));
            this.skinButton_cancel.Name = "skinButton_cancel";
            this.skinButton_cancel.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton_cancel.NormlBack")));
            this.skinButton_cancel.Size = new System.Drawing.Size(103, 39);
            this.skinButton_cancel.TabIndex = 161;
            this.skinButton_cancel.Text = "取消操作";
            this.skinButton_cancel.UseVisualStyleBackColor = false;
            this.skinButton_cancel.Click += new System.EventHandler(this.skinButton_cancel_Click);
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
            this.btnOk.Location = new System.Drawing.Point(46, 97);
            this.btnOk.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseBack")));
            this.btnOk.Name = "btnOk";
            this.btnOk.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnOk.NormlBack")));
            this.btnOk.Size = new System.Drawing.Size(103, 39);
            this.btnOk.TabIndex = 155;
            this.btnOk.Text = "一键上传";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.Maroon;
            this.skinLabel1.Location = new System.Drawing.Point(26, 18);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(314, 22);
            this.skinLabel1.TabIndex = 152;
            this.skinLabel1.Text = "Telinga文件数据管理系统提醒您:及时上传";
            // 
            // timShow
            // 
            this.timShow.Enabled = true;
            this.timShow.Interval = 60000;
            this.timShow.Tick += new System.EventHandler(this.timShow_Tick);
            // 
            // FrmTipUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.BackShade = false;
            this.CanResize = false;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 22;
            this.ClientSize = new System.Drawing.Size(371, 195);
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
            this.Name = "FrmTipUpload";
            this.Radius = 1;
            this.RestoreDownBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreDownBack")));
            this.RestoreMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreMouseBack")));
            this.RestoreNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreNormlBack")));
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "一键上传提示框";
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(13, 4);
            this.Load += new System.EventHandler(this.FrmTipUpload_Load);
            this.Shown += new System.EventHandler(this.FrmTipUpload_Shown);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinButton skinButton_cancel;
        private CCWin.SkinControl.SkinButton btnOk;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.Timer timShow;

    }
}

