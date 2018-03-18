namespace FileManager
{
    partial class FrmFileMultiHistoryLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFileMultiHistoryLog));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinDataGridView_history = new CCWin.SkinControl.SkinDataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileCreateUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileCreateUserRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_userIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComputerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.SaveAs = new System.Windows.Forms.DataGridViewLinkColumn();
            this.File_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView_history)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.White;
            this.skinPanel1.Controls.Add(this.skinDataGridView_history);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(4, 26);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(1028, 342);
            this.skinPanel1.TabIndex = 1;
            // 
            // skinDataGridView_history
            // 
            this.skinDataGridView_history.AllowUserToAddRows = false;
            this.skinDataGridView_history.AllowUserToDeleteRows = false;
            this.skinDataGridView_history.AllowUserToOrderColumns = true;
            this.skinDataGridView_history.AlternatingCellBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.skinDataGridView_history.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.skinDataGridView_history.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.skinDataGridView_history.BackgroundColor = System.Drawing.SystemColors.Window;
            this.skinDataGridView_history.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinDataGridView_history.ColumnFont = null;
            this.skinDataGridView_history.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.skinDataGridView_history.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.skinDataGridView_history.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.skinDataGridView_history.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.FileName,
            this.FileCreateUserName,
            this.FileCreateUserRealName,
            this.ActionName,
            this.dataGridViewTextBoxColumn39,
            this.dataGridViewTextBoxColumn40,
            this.dataGridViewTextBoxColumn41,
            this.file_userIp,
            this.remark,
            this.ComputerName,
            this.dataGridViewTextBoxColumn42,
            this.Column1,
            this.SaveAs,
            this.File_ID,
            this.ClientPath});
            this.skinDataGridView_history.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.skinDataGridView_history.DefaultCellStyle = dataGridViewCellStyle3;
            this.skinDataGridView_history.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinDataGridView_history.EnableHeadersVisualStyles = false;
            this.skinDataGridView_history.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinDataGridView_history.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.skinDataGridView_history.HeadFont = new System.Drawing.Font("微软雅黑", 9F);
            this.skinDataGridView_history.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView_history.Location = new System.Drawing.Point(0, 0);
            this.skinDataGridView_history.Margin = new System.Windows.Forms.Padding(10);
            this.skinDataGridView_history.MouseCellBackColor = System.Drawing.Color.White;
            this.skinDataGridView_history.MultiSelect = false;
            this.skinDataGridView_history.Name = "skinDataGridView_history";
            this.skinDataGridView_history.ReadOnly = true;
            this.skinDataGridView_history.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.skinDataGridView_history.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView_history.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.skinDataGridView_history.RowTemplate.Height = 23;
            this.skinDataGridView_history.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.skinDataGridView_history.Size = new System.Drawing.Size(1028, 342);
            this.skinDataGridView_history.SkinGridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.skinDataGridView_history.TabIndex = 11;
            this.skinDataGridView_history.TitleBack = null;
            this.skinDataGridView_history.TitleBackColorBegin = System.Drawing.Color.White;
            this.skinDataGridView_history.TitleBackColorEnd = System.Drawing.SystemColors.Control;
            this.skinDataGridView_history.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.skinDataGridView_history_CellContentClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "文件名称";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 150;
            // 
            // FileCreateUserName
            // 
            this.FileCreateUserName.DataPropertyName = "file_user_name";
            this.FileCreateUserName.HeaderText = "创建者账号";
            this.FileCreateUserName.Name = "FileCreateUserName";
            this.FileCreateUserName.ReadOnly = true;
            this.FileCreateUserName.Width = 70;
            // 
            // FileCreateUserRealName
            // 
            this.FileCreateUserRealName.DataPropertyName = "file_user_realname";
            this.FileCreateUserRealName.HeaderText = "创建者姓名";
            this.FileCreateUserRealName.Name = "FileCreateUserRealName";
            this.FileCreateUserRealName.ReadOnly = true;
            this.FileCreateUserRealName.Width = 70;
            // 
            // ActionName
            // 
            this.ActionName.DataPropertyName = "ActionName";
            this.ActionName.HeaderText = "操作名称";
            this.ActionName.Name = "ActionName";
            this.ActionName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "file_version";
            this.dataGridViewTextBoxColumn39.FillWeight = 50F;
            this.dataGridViewTextBoxColumn39.HeaderText = "版本号";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Width = 68;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "file_modifyTime";
            this.dataGridViewTextBoxColumn40.HeaderText = "修改时间";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            this.dataGridViewTextBoxColumn40.Width = 120;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "file_userName";
            this.dataGridViewTextBoxColumn41.HeaderText = "操作人";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            // 
            // file_userIp
            // 
            this.file_userIp.DataPropertyName = "file_userIp";
            this.file_userIp.HeaderText = "操作IP";
            this.file_userIp.Name = "file_userIp";
            this.file_userIp.ReadOnly = true;
            this.file_userIp.Width = 80;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.Width = 220;
            // 
            // ComputerName
            // 
            this.ComputerName.DataPropertyName = "ComputerName";
            this.ComputerName.HeaderText = "计算机名";
            this.ComputerName.Name = "ComputerName";
            this.ComputerName.ReadOnly = true;
            this.ComputerName.Visible = false;
            this.ComputerName.Width = 80;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.DataPropertyName = "file_size";
            this.dataGridViewTextBoxColumn42.FillWeight = 70F;
            this.dataGridViewTextBoxColumn42.HeaderText = "大小";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Visible = false;
            this.dataGridViewTextBoxColumn42.Width = 70;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "downLink";
            this.Column1.FillWeight = 80F;
            this.Column1.HeaderText = "下载";
            this.Column1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Text = "下载";
            this.Column1.Visible = false;
            this.Column1.Width = 80;
            // 
            // SaveAs
            // 
            this.SaveAs.DataPropertyName = "SaveAs";
            this.SaveAs.FillWeight = 70F;
            this.SaveAs.HeaderText = "另存为";
            this.SaveAs.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.ReadOnly = true;
            this.SaveAs.Text = "另存为";
            this.SaveAs.ToolTipText = "另存为";
            this.SaveAs.Visible = false;
            this.SaveAs.Width = 70;
            // 
            // File_ID
            // 
            this.File_ID.DataPropertyName = "File_ID";
            this.File_ID.HeaderText = "File_ID";
            this.File_ID.Name = "File_ID";
            this.File_ID.ReadOnly = true;
            this.File_ID.Visible = false;
            // 
            // ClientPath
            // 
            this.ClientPath.DataPropertyName = "ClientPath";
            this.ClientPath.HeaderText = "ClientPath";
            this.ClientPath.Name = "ClientPath";
            this.ClientPath.ReadOnly = true;
            this.ClientPath.Visible = false;
            // 
            // FrmFileMultiHistoryLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.BackShade = false;
            this.CanResize = false;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 22;
            this.ClientSize = new System.Drawing.Size(1036, 372);
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
            this.Name = "FrmFileMultiHistoryLog";
            this.Radius = 1;
            this.RestoreDownBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreDownBack")));
            this.RestoreMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreMouseBack")));
            this.RestoreNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreNormlBack")));
            this.RoundStyle = CCWin.SkinClass.RoundStyle.None;
            this.ShowDrawIcon = false;
            this.SkinOpacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件版本历史记录";
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(13, 4);
            this.skinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView_history)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinDataGridView skinDataGridView_history;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileCreateUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileCreateUserRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_userIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComputerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.DataGridViewLinkColumn Column1;
        private System.Windows.Forms.DataGridViewLinkColumn SaveAs;
        private System.Windows.Forms.DataGridViewTextBoxColumn File_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientPath;

    }
}

