namespace FileManager
{
    partial class FrmFileTransferNew
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
            CCWin.SkinControl.SkinDataGridView skinDataGridView1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFileTransferNew));
            this.file_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinDataGridView10 = new CCWin.SkinControl.SkinDataGridView();
            this.key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.skinLabel19 = new CCWin.SkinControl.SkinLabel();
            this.fileTansfersContainer1 = new CCWin.SkinControl.SkinFileTansfersContainer();
            this.skinFileTransfersItem1 = new CCWin.SkinControl.SkinFileTransfersItem();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            skinDataGridView1 = new CCWin.SkinControl.SkinDataGridView();
            ((System.ComponentModel.ISupportInitialize)(skinDataGridView1)).BeginInit();
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView10)).BeginInit();
            this.skinPanel2.SuspendLayout();
            this.fileTansfersContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // skinDataGridView1
            // 
            skinDataGridView1.AllowUserToAddRows = false;
            skinDataGridView1.AllowUserToDeleteRows = false;
            skinDataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            skinDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            skinDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            skinDataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            skinDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            skinDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            skinDataGridView1.ColumnFont = null;
            skinDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            skinDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            skinDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            skinDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.file_type,
            this.file_name,
            this.file_size,
            this.state});
            skinDataGridView1.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            skinDataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            skinDataGridView1.EnableHeadersVisualStyles = false;
            skinDataGridView1.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            skinDataGridView1.HeadFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            skinDataGridView1.HeadSelectBackColor = System.Drawing.SystemColors.Desktop;
            skinDataGridView1.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            skinDataGridView1.Location = new System.Drawing.Point(365, 73);
            skinDataGridView1.Name = "skinDataGridView1";
            skinDataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            skinDataGridView1.RowHeadersVisible = false;
            skinDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            skinDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            skinDataGridView1.RowTemplate.Height = 23;
            skinDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            skinDataGridView1.Size = new System.Drawing.Size(294, 154);
            skinDataGridView1.TabIndex = 7;
            skinDataGridView1.TitleBack = null;
            skinDataGridView1.TitleBackColorBegin = System.Drawing.Color.White;
            skinDataGridView1.TitleBackColorEnd = System.Drawing.SystemColors.MenuHighlight;
            skinDataGridView1.Visible = false;
            // 
            // file_type
            // 
            this.file_type.DataPropertyName = "file_type";
            this.file_type.HeaderText = "文件类型";
            this.file_type.Name = "file_type";
            // 
            // file_name
            // 
            this.file_name.DataPropertyName = "file_name";
            this.file_name.HeaderText = "文件名称";
            this.file_name.Name = "file_name";
            // 
            // file_size
            // 
            this.file_size.DataPropertyName = "file_size";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.file_size.DefaultCellStyle = dataGridViewCellStyle3;
            this.file_size.HeaderText = "文件大小";
            this.file_size.Name = "file_size";
            // 
            // state
            // 
            this.state.DataPropertyName = "state";
            this.state.HeaderText = "状态";
            this.state.Name = "state";
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.White;
            this.skinPanel1.Controls.Add(this.skinDataGridView10);
            this.skinPanel1.Controls.Add(skinDataGridView1);
            this.skinPanel1.Controls.Add(this.skinPanel2);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(4, 26);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(741, 322);
            this.skinPanel1.TabIndex = 1;
            // 
            // skinDataGridView10
            // 
            this.skinDataGridView10.AllowUserToAddRows = false;
            this.skinDataGridView10.AllowUserToDeleteRows = false;
            this.skinDataGridView10.AllowUserToOrderColumns = true;
            this.skinDataGridView10.AlternatingCellBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.skinDataGridView10.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.skinDataGridView10.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.skinDataGridView10.BackgroundColor = System.Drawing.SystemColors.Window;
            this.skinDataGridView10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinDataGridView10.ColumnFont = null;
            this.skinDataGridView10.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.skinDataGridView10.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.skinDataGridView10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.skinDataGridView10.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.key,
            this.dataGridViewTextBoxColumn39,
            this.dataGridViewTextBoxColumn40,
            this.dataGridViewTextBoxColumn41,
            this.dataGridViewTextBoxColumn42});
            this.skinDataGridView10.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.skinDataGridView10.DefaultCellStyle = dataGridViewCellStyle8;
            this.skinDataGridView10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinDataGridView10.EnableHeadersVisualStyles = false;
            this.skinDataGridView10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinDataGridView10.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.skinDataGridView10.HeadFont = new System.Drawing.Font("微软雅黑", 9F);
            this.skinDataGridView10.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView10.Location = new System.Drawing.Point(348, 0);
            this.skinDataGridView10.Margin = new System.Windows.Forms.Padding(10);
            this.skinDataGridView10.MouseCellBackColor = System.Drawing.Color.White;
            this.skinDataGridView10.MultiSelect = false;
            this.skinDataGridView10.Name = "skinDataGridView10";
            this.skinDataGridView10.ReadOnly = true;
            this.skinDataGridView10.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.skinDataGridView10.RowHeadersVisible = false;
            this.skinDataGridView10.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView10.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.skinDataGridView10.RowTemplate.Height = 23;
            this.skinDataGridView10.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.skinDataGridView10.Size = new System.Drawing.Size(393, 322);
            this.skinDataGridView10.SkinGridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.skinDataGridView10.TabIndex = 11;
            this.skinDataGridView10.TitleBack = null;
            this.skinDataGridView10.TitleBackColorBegin = System.Drawing.Color.White;
            this.skinDataGridView10.TitleBackColorEnd = System.Drawing.SystemColors.Control;
            // 
            // key
            // 
            this.key.DataPropertyName = "key";
            this.key.HeaderText = "key";
            this.key.Name = "key";
            this.key.ReadOnly = true;
            this.key.Visible = false;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "file_type";
            this.dataGridViewTextBoxColumn39.HeaderText = "文件类型";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Width = 80;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "file_name";
            this.dataGridViewTextBoxColumn40.HeaderText = "文件名称";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            this.dataGridViewTextBoxColumn40.Width = 150;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "file_size";
            this.dataGridViewTextBoxColumn41.HeaderText = "文件大小";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            this.dataGridViewTextBoxColumn41.Width = 80;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.DataPropertyName = "state";
            this.dataGridViewTextBoxColumn42.HeaderText = "状态";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Width = 80;
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinPanel2.Controls.Add(this.skinLabel19);
            this.skinPanel2.Controls.Add(this.fileTansfersContainer1);
            this.skinPanel2.Controls.Add(this.skinPictureBox1);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(0, 0);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(348, 322);
            this.skinPanel2.TabIndex = 6;
            // 
            // skinLabel19
            // 
            this.skinLabel19.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel19.AutoSize = true;
            this.skinLabel19.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel19.BorderColor = System.Drawing.Color.White;
            this.skinLabel19.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.skinLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.skinLabel19.Location = new System.Drawing.Point(103, 205);
            this.skinLabel19.Name = "skinLabel19";
            this.skinLabel19.Size = new System.Drawing.Size(122, 22);
            this.skinLabel19.TabIndex = 164;
            this.skinLabel19.Text = "文件上传成功！";
            this.skinLabel19.Visible = false;
            // 
            // fileTansfersContainer1
            // 
            this.fileTansfersContainer1.AutoScroll = true;
            this.fileTansfersContainer1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileTansfersContainer1.Controls.Add(this.skinFileTransfersItem1);
            this.fileTansfersContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTansfersContainer1.Location = new System.Drawing.Point(0, 0);
            this.fileTansfersContainer1.Name = "fileTansfersContainer1";
            this.fileTansfersContainer1.Size = new System.Drawing.Size(348, 322);
            this.fileTansfersContainer1.TabIndex = 4;
            // 
            // skinFileTransfersItem1
            // 
            this.skinFileTransfersItem1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.skinFileTransfersItem1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.skinFileTransfersItem1.FileName = null;
            this.skinFileTransfersItem1.FileSize = ((long)(0));
            this.skinFileTransfersItem1.Location = new System.Drawing.Point(3, 3);
            this.skinFileTransfersItem1.Name = "skinFileTransfersItem1";
            this.skinFileTransfersItem1.ProgressBarBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.skinFileTransfersItem1.ProgressBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.skinFileTransfersItem1.Size = new System.Drawing.Size(342, 97);
            this.skinFileTransfersItem1.TabIndex = 0;
            this.skinFileTransfersItem1.Text = "上传下载中";
            this.skinFileTransfersItem1.TotalTransfersSize = ((long)(0));
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.Image = global::FileManager.Properties.Resources.success;
            this.skinPictureBox1.Location = new System.Drawing.Point(98, 60);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(127, 126);
            this.skinPictureBox1.TabIndex = 0;
            this.skinPictureBox1.TabStop = false;
            this.skinPictureBox1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmFileTransferNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.BackShade = false;
            this.CanResize = false;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 22;
            this.ClientSize = new System.Drawing.Size(749, 352);
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
            this.Name = "FrmFileTransferNew";
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
            ((System.ComponentModel.ISupportInitialize)(skinDataGridView1)).EndInit();
            this.skinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView10)).EndInit();
            this.skinPanel2.ResumeLayout(false);
            this.skinPanel2.PerformLayout();
            this.fileTansfersContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinFileTansfersContainer fileTansfersContainer1;
        private System.Windows.Forms.Timer timer1;
        private CCWin.SkinControl.SkinPanel skinPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_size;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private CCWin.SkinControl.SkinLabel skinLabel19;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
        private CCWin.SkinControl.SkinDataGridView skinDataGridView10;
        private System.Windows.Forms.DataGridViewTextBoxColumn key;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private CCWin.SkinControl.SkinFileTransfersItem skinFileTransfersItem1;

    }
}

