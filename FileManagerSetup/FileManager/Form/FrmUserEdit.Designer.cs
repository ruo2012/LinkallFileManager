namespace FileManager
{
    partial class FrmUserEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinButton_del = new CCWin.SkinControl.SkinButton();
            this.skinButton_edit = new CCWin.SkinControl.SkinButton();
            this.skinButton_add = new CCWin.SkinControl.SkinButton();
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.skinDataGridView_projects = new CCWin.SkinControl.SkinDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonitoringSoftwareName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonitoringPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBox_role = new CCWin.SkinControl.SkinComboBox();
            this.skinTextBox_userName = new CCWin.SkinControl.SkinTextBox();
            this.skinRadioButton_lock = new CCWin.SkinControl.SkinRadioButton();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinRadioButton_unLock = new CCWin.SkinControl.SkinRadioButton();
            this.skinTextBox_realName = new CCWin.SkinControl.SkinTextBox();
            this.skinTextBox_addTime = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinButton_cancel = new CCWin.SkinControl.SkinButton();
            this.btn_ok = new CCWin.SkinControl.SkinButton();
            this.skinContextMenuStrip1 = new CCWin.SkinControl.SkinContextMenuStrip();
            this.ToolStripMenuItem_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Del = new System.Windows.Forms.ToolStripMenuItem();
            this.skinPanel1.SuspendLayout();
            this.skinGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView_projects)).BeginInit();
            this.skinGroupBox1.SuspendLayout();
            this.skinTextBox_userName.SuspendLayout();
            this.skinTextBox_realName.SuspendLayout();
            this.skinTextBox_addTime.SuspendLayout();
            this.skinContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.White;
            this.skinPanel1.Controls.Add(this.skinButton_del);
            this.skinPanel1.Controls.Add(this.skinButton_edit);
            this.skinPanel1.Controls.Add(this.skinButton_add);
            this.skinPanel1.Controls.Add(this.skinGroupBox2);
            this.skinPanel1.Controls.Add(this.skinGroupBox1);
            this.skinPanel1.Controls.Add(this.skinButton_cancel);
            this.skinPanel1.Controls.Add(this.btn_ok);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(4, 26);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(760, 324);
            this.skinPanel1.TabIndex = 1;
            // 
            // skinButton_del
            // 
            this.skinButton_del.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinButton_del.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButton_del.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_del.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButton_del.DownBack")));
            this.skinButton_del.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton_del.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton_del.ForeColor = System.Drawing.Color.Black;
            this.skinButton_del.Location = new System.Drawing.Point(540, 247);
            this.skinButton_del.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton_del.MouseBack")));
            this.skinButton_del.Name = "skinButton_del";
            this.skinButton_del.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton_del.NormlBack")));
            this.skinButton_del.Size = new System.Drawing.Size(69, 24);
            this.skinButton_del.TabIndex = 169;
            this.skinButton_del.Text = "删除";
            this.skinButton_del.UseVisualStyleBackColor = false;
            this.skinButton_del.Click += new System.EventHandler(this.skinButton_del_Click);
            // 
            // skinButton_edit
            // 
            this.skinButton_edit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinButton_edit.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButton_edit.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_edit.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButton_edit.DownBack")));
            this.skinButton_edit.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton_edit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton_edit.ForeColor = System.Drawing.Color.Black;
            this.skinButton_edit.Location = new System.Drawing.Point(462, 247);
            this.skinButton_edit.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton_edit.MouseBack")));
            this.skinButton_edit.Name = "skinButton_edit";
            this.skinButton_edit.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton_edit.NormlBack")));
            this.skinButton_edit.Size = new System.Drawing.Size(69, 24);
            this.skinButton_edit.TabIndex = 168;
            this.skinButton_edit.Text = "编辑";
            this.skinButton_edit.UseVisualStyleBackColor = false;
            this.skinButton_edit.Click += new System.EventHandler(this.skinButton_edit_Click);
            // 
            // skinButton_add
            // 
            this.skinButton_add.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinButton_add.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButton_add.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_add.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButton_add.DownBack")));
            this.skinButton_add.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton_add.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton_add.ForeColor = System.Drawing.Color.Black;
            this.skinButton_add.Location = new System.Drawing.Point(382, 247);
            this.skinButton_add.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton_add.MouseBack")));
            this.skinButton_add.Name = "skinButton_add";
            this.skinButton_add.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton_add.NormlBack")));
            this.skinButton_add.Size = new System.Drawing.Size(69, 24);
            this.skinButton_add.TabIndex = 167;
            this.skinButton_add.Text = "添加工程";
            this.skinButton_add.UseVisualStyleBackColor = true;
            this.skinButton_add.Click += new System.EventHandler(this.skinButton_add_Click);
            // 
            // skinGroupBox2
            // 
            this.skinGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.skinGroupBox2.Controls.Add(this.skinDataGridView_projects);
            this.skinGroupBox2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.skinGroupBox2.Location = new System.Drawing.Point(375, 13);
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.Size = new System.Drawing.Size(374, 229);
            this.skinGroupBox2.TabIndex = 166;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.Text = "用户工程监控信息";
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.Color.White;
            // 
            // skinDataGridView_projects
            // 
            this.skinDataGridView_projects.AllowUserToAddRows = false;
            this.skinDataGridView_projects.AllowUserToOrderColumns = true;
            this.skinDataGridView_projects.AlternatingCellBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.skinDataGridView_projects.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.skinDataGridView_projects.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.skinDataGridView_projects.BackgroundColor = System.Drawing.SystemColors.Window;
            this.skinDataGridView_projects.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinDataGridView_projects.ColumnFont = null;
            this.skinDataGridView_projects.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.skinDataGridView_projects.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.skinDataGridView_projects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.skinDataGridView_projects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ProjectName,
            this.MonitoringSoftwareName,
            this.MonitoringPath,
            this.AddTime,
            this.ClientIp,
            this.IsLock,
            this.UserName});
            this.skinDataGridView_projects.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.skinDataGridView_projects.DefaultCellStyle = dataGridViewCellStyle3;
            this.skinDataGridView_projects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinDataGridView_projects.EnableHeadersVisualStyles = false;
            this.skinDataGridView_projects.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinDataGridView_projects.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.skinDataGridView_projects.HeadFont = new System.Drawing.Font("微软雅黑", 9F);
            this.skinDataGridView_projects.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView_projects.Location = new System.Drawing.Point(3, 17);
            this.skinDataGridView_projects.Margin = new System.Windows.Forms.Padding(10);
            this.skinDataGridView_projects.MouseCellBackColor = System.Drawing.Color.White;
            this.skinDataGridView_projects.MultiSelect = false;
            this.skinDataGridView_projects.Name = "skinDataGridView_projects";
            this.skinDataGridView_projects.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.skinDataGridView_projects.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView_projects.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.skinDataGridView_projects.RowTemplate.Height = 23;
            this.skinDataGridView_projects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.skinDataGridView_projects.Size = new System.Drawing.Size(368, 209);
            this.skinDataGridView_projects.SkinGridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.skinDataGridView_projects.TabIndex = 170;
            this.skinDataGridView_projects.TitleBack = null;
            this.skinDataGridView_projects.TitleBackColorBegin = System.Drawing.Color.White;
            this.skinDataGridView_projects.TitleBackColorEnd = System.Drawing.SystemColors.Control;
            this.skinDataGridView_projects.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.skinDataGridView_projects_CellDoubleClick);
            this.skinDataGridView_projects.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.skinDataGridView_projects_CellMouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // ProjectName
            // 
            this.ProjectName.DataPropertyName = "ProjectName";
            this.ProjectName.HeaderText = "工程名";
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Width = 80;
            // 
            // MonitoringSoftwareName
            // 
            this.MonitoringSoftwareName.DataPropertyName = "MonitoringSoftwareName";
            this.MonitoringSoftwareName.HeaderText = "监控软件";
            this.MonitoringSoftwareName.Name = "MonitoringSoftwareName";
            // 
            // MonitoringPath
            // 
            this.MonitoringPath.DataPropertyName = "MonitoringPath";
            this.MonitoringPath.HeaderText = "客户端路径";
            this.MonitoringPath.Name = "MonitoringPath";
            this.MonitoringPath.Width = 140;
            // 
            // AddTime
            // 
            this.AddTime.HeaderText = "AddTime";
            this.AddTime.Name = "AddTime";
            this.AddTime.Visible = false;
            // 
            // ClientIp
            // 
            this.ClientIp.HeaderText = "ClientIp";
            this.ClientIp.Name = "ClientIp";
            this.ClientIp.Visible = false;
            // 
            // IsLock
            // 
            this.IsLock.HeaderText = "IsLock";
            this.IsLock.Name = "IsLock";
            this.IsLock.Visible = false;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.Visible = false;
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.skinGroupBox1.Controls.Add(this.skinLabel1);
            this.skinGroupBox1.Controls.Add(this.skinComboBox_role);
            this.skinGroupBox1.Controls.Add(this.skinTextBox_userName);
            this.skinGroupBox1.Controls.Add(this.skinRadioButton_lock);
            this.skinGroupBox1.Controls.Add(this.skinLabel2);
            this.skinGroupBox1.Controls.Add(this.skinRadioButton_unLock);
            this.skinGroupBox1.Controls.Add(this.skinTextBox_realName);
            this.skinGroupBox1.Controls.Add(this.skinTextBox_addTime);
            this.skinGroupBox1.Controls.Add(this.skinLabel6);
            this.skinGroupBox1.Controls.Add(this.skinLabel4);
            this.skinGroupBox1.Controls.Add(this.skinLabel5);
            this.skinGroupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.skinGroupBox1.Location = new System.Drawing.Point(11, 13);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.Size = new System.Drawing.Size(358, 229);
            this.skinGroupBox1.TabIndex = 165;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "用户基本信息";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.White;
            // 
            // skinLabel1
            // 
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.Black;
            this.skinLabel1.Location = new System.Drawing.Point(11, 35);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(68, 17);
            this.skinLabel1.TabIndex = 136;
            this.skinLabel1.Text = "账      号：";
            // 
            // skinComboBox_role
            // 
            this.skinComboBox_role.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_role.FormattingEnabled = true;
            this.skinComboBox_role.Items.AddRange(new object[] {
            "普通用户",
            "管理员"});
            this.skinComboBox_role.Location = new System.Drawing.Point(82, 142);
            this.skinComboBox_role.Name = "skinComboBox_role";
            this.skinComboBox_role.Size = new System.Drawing.Size(263, 22);
            this.skinComboBox_role.TabIndex = 164;
            this.skinComboBox_role.WaterText = "";
            // 
            // skinTextBox_userName
            // 
            this.skinTextBox_userName.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_userName.DownBack = null;
            this.skinTextBox_userName.Icon = null;
            this.skinTextBox_userName.IconIsButton = false;
            this.skinTextBox_userName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_userName.Location = new System.Drawing.Point(82, 30);
            this.skinTextBox_userName.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_userName.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_userName.MouseBack = null;
            this.skinTextBox_userName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_userName.Name = "skinTextBox_userName";
            this.skinTextBox_userName.NormlBack = null;
            this.skinTextBox_userName.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_userName.Size = new System.Drawing.Size(263, 28);
            // 
            // skinTextBox_userName.BaseText
            // 
            this.skinTextBox_userName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_userName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_userName.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_userName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_userName.SkinTxt.Name = "BaseText";
            this.skinTextBox_userName.SkinTxt.Size = new System.Drawing.Size(253, 18);
            this.skinTextBox_userName.SkinTxt.TabIndex = 0;
            this.skinTextBox_userName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_userName.SkinTxt.WaterText = "";
            this.skinTextBox_userName.TabIndex = 137;
            // 
            // skinRadioButton_lock
            // 
            this.skinRadioButton_lock.AutoSize = true;
            this.skinRadioButton_lock.BackColor = System.Drawing.Color.Transparent;
            this.skinRadioButton_lock.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinRadioButton_lock.DownBack = null;
            this.skinRadioButton_lock.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinRadioButton_lock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.skinRadioButton_lock.Location = new System.Drawing.Point(185, 110);
            this.skinRadioButton_lock.MouseBack = null;
            this.skinRadioButton_lock.Name = "skinRadioButton_lock";
            this.skinRadioButton_lock.NormlBack = null;
            this.skinRadioButton_lock.SelectedDownBack = null;
            this.skinRadioButton_lock.SelectedMouseBack = null;
            this.skinRadioButton_lock.SelectedNormlBack = null;
            this.skinRadioButton_lock.Size = new System.Drawing.Size(62, 21);
            this.skinRadioButton_lock.TabIndex = 163;
            this.skinRadioButton_lock.Text = "不启用";
            this.skinRadioButton_lock.UseVisualStyleBackColor = false;
            // 
            // skinLabel2
            // 
            this.skinLabel2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.ForeColor = System.Drawing.Color.Black;
            this.skinLabel2.Location = new System.Drawing.Point(10, 72);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(68, 17);
            this.skinLabel2.TabIndex = 141;
            this.skinLabel2.Text = "姓      名：";
            // 
            // skinRadioButton_unLock
            // 
            this.skinRadioButton_unLock.AutoSize = true;
            this.skinRadioButton_unLock.BackColor = System.Drawing.Color.Transparent;
            this.skinRadioButton_unLock.Checked = true;
            this.skinRadioButton_unLock.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinRadioButton_unLock.DownBack = null;
            this.skinRadioButton_unLock.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinRadioButton_unLock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.skinRadioButton_unLock.Location = new System.Drawing.Point(85, 110);
            this.skinRadioButton_unLock.MouseBack = null;
            this.skinRadioButton_unLock.Name = "skinRadioButton_unLock";
            this.skinRadioButton_unLock.NormlBack = null;
            this.skinRadioButton_unLock.SelectedDownBack = null;
            this.skinRadioButton_unLock.SelectedMouseBack = null;
            this.skinRadioButton_unLock.SelectedNormlBack = null;
            this.skinRadioButton_unLock.Size = new System.Drawing.Size(50, 21);
            this.skinRadioButton_unLock.TabIndex = 162;
            this.skinRadioButton_unLock.TabStop = true;
            this.skinRadioButton_unLock.Text = "启用";
            this.skinRadioButton_unLock.UseVisualStyleBackColor = false;
            // 
            // skinTextBox_realName
            // 
            this.skinTextBox_realName.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_realName.DownBack = null;
            this.skinTextBox_realName.Icon = null;
            this.skinTextBox_realName.IconIsButton = false;
            this.skinTextBox_realName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_realName.Location = new System.Drawing.Point(82, 67);
            this.skinTextBox_realName.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_realName.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_realName.MouseBack = null;
            this.skinTextBox_realName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_realName.Name = "skinTextBox_realName";
            this.skinTextBox_realName.NormlBack = null;
            this.skinTextBox_realName.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_realName.Size = new System.Drawing.Size(263, 28);
            // 
            // skinTextBox_realName.BaseText
            // 
            this.skinTextBox_realName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_realName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_realName.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_realName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_realName.SkinTxt.Name = "BaseText";
            this.skinTextBox_realName.SkinTxt.Size = new System.Drawing.Size(253, 18);
            this.skinTextBox_realName.SkinTxt.TabIndex = 0;
            this.skinTextBox_realName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_realName.SkinTxt.WaterText = "";
            this.skinTextBox_realName.TabIndex = 143;
            // 
            // skinTextBox_addTime
            // 
            this.skinTextBox_addTime.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_addTime.DownBack = null;
            this.skinTextBox_addTime.Icon = null;
            this.skinTextBox_addTime.IconIsButton = false;
            this.skinTextBox_addTime.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_addTime.Location = new System.Drawing.Point(82, 181);
            this.skinTextBox_addTime.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_addTime.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_addTime.MouseBack = null;
            this.skinTextBox_addTime.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_addTime.Name = "skinTextBox_addTime";
            this.skinTextBox_addTime.NormlBack = null;
            this.skinTextBox_addTime.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_addTime.Size = new System.Drawing.Size(263, 28);
            // 
            // skinTextBox_addTime.BaseText
            // 
            this.skinTextBox_addTime.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_addTime.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_addTime.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_addTime.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_addTime.SkinTxt.Name = "BaseText";
            this.skinTextBox_addTime.SkinTxt.Size = new System.Drawing.Size(253, 18);
            this.skinTextBox_addTime.SkinTxt.TabIndex = 0;
            this.skinTextBox_addTime.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_addTime.SkinTxt.WaterText = "";
            this.skinTextBox_addTime.TabIndex = 148;
            // 
            // skinLabel6
            // 
            this.skinLabel6.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.ForeColor = System.Drawing.Color.Black;
            this.skinLabel6.Location = new System.Drawing.Point(11, 110);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(68, 17);
            this.skinLabel6.TabIndex = 144;
            this.skinLabel6.Text = "是否启用：";
            // 
            // skinLabel4
            // 
            this.skinLabel4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.ForeColor = System.Drawing.Color.Black;
            this.skinLabel4.Location = new System.Drawing.Point(10, 186);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(68, 17);
            this.skinLabel4.TabIndex = 146;
            this.skinLabel4.Text = "添加时间：";
            // 
            // skinLabel5
            // 
            this.skinLabel5.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.ForeColor = System.Drawing.Color.Black;
            this.skinLabel5.Location = new System.Drawing.Point(10, 145);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(68, 17);
            this.skinLabel5.TabIndex = 147;
            this.skinLabel5.Text = "角      色：";
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
            this.skinButton_cancel.Location = new System.Drawing.Point(602, 290);
            this.skinButton_cancel.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton_cancel.MouseBack")));
            this.skinButton_cancel.Name = "skinButton_cancel";
            this.skinButton_cancel.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton_cancel.NormlBack")));
            this.skinButton_cancel.Size = new System.Drawing.Size(69, 24);
            this.skinButton_cancel.TabIndex = 138;
            this.skinButton_cancel.Text = "取消";
            this.skinButton_cancel.UseVisualStyleBackColor = false;
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ok.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.btn_ok.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_ok.DownBack = ((System.Drawing.Image)(resources.GetObject("btn_ok.DownBack")));
            this.btn_ok.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_ok.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.ForeColor = System.Drawing.Color.Black;
            this.btn_ok.Location = new System.Drawing.Point(677, 290);
            this.btn_ok.MouseBack = ((System.Drawing.Image)(resources.GetObject("btn_ok.MouseBack")));
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.NormlBack = ((System.Drawing.Image)(resources.GetObject("btn_ok.NormlBack")));
            this.btn_ok.Size = new System.Drawing.Size(69, 24);
            this.btn_ok.TabIndex = 139;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // skinContextMenuStrip1
            // 
            this.skinContextMenuStrip1.Arrow = System.Drawing.Color.Black;
            this.skinContextMenuStrip1.Back = System.Drawing.Color.White;
            this.skinContextMenuStrip1.BackRadius = 4;
            this.skinContextMenuStrip1.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.skinContextMenuStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStrip1.Fore = System.Drawing.Color.Black;
            this.skinContextMenuStrip1.HoverFore = System.Drawing.Color.White;
            this.skinContextMenuStrip1.ItemAnamorphosis = true;
            this.skinContextMenuStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip1.ItemBorderShow = true;
            this.skinContextMenuStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip1.ItemRadius = 4;
            this.skinContextMenuStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Add,
            this.ToolStripMenuItem_Edit,
            this.ToolStripMenuItem_Del});
            this.skinContextMenuStrip1.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip1.Name = "skinContextMenuStrip1";
            this.skinContextMenuStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            this.skinContextMenuStrip1.SkinAllColor = true;
            this.skinContextMenuStrip1.TitleAnamorphosis = true;
            this.skinContextMenuStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinContextMenuStrip1.TitleRadius = 4;
            this.skinContextMenuStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // ToolStripMenuItem_Add
            // 
            this.ToolStripMenuItem_Add.Name = "ToolStripMenuItem_Add";
            this.ToolStripMenuItem_Add.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_Add.Text = "添加工程";
            this.ToolStripMenuItem_Add.Click += new System.EventHandler(this.ToolStripMenuItem_Add_Click);
            // 
            // ToolStripMenuItem_Edit
            // 
            this.ToolStripMenuItem_Edit.Name = "ToolStripMenuItem_Edit";
            this.ToolStripMenuItem_Edit.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_Edit.Text = "编辑工程";
            this.ToolStripMenuItem_Edit.Click += new System.EventHandler(this.ToolStripMenuItem_Edit_Click);
            // 
            // ToolStripMenuItem_Del
            // 
            this.ToolStripMenuItem_Del.Name = "ToolStripMenuItem_Del";
            this.ToolStripMenuItem_Del.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_Del.Text = "删除工程";
            this.ToolStripMenuItem_Del.Click += new System.EventHandler(this.ToolStripMenuItem_Del_Click);
            // 
            // FrmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(57)))), ((int)(((byte)(134)))));
            this.BackShade = false;
            this.CanResize = false;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 22;
            this.ClientSize = new System.Drawing.Size(768, 354);
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
            this.Name = "FrmUserEdit";
            this.Radius = 1;
            this.RestoreDownBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreDownBack")));
            this.RestoreMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreMouseBack")));
            this.RestoreNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreNormlBack")));
            this.RoundStyle = CCWin.SkinClass.RoundStyle.None;
            this.ShowDrawIcon = false;
            this.SkinOpacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑用户信息";
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(13, 4);
            this.skinPanel1.ResumeLayout(false);
            this.skinGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView_projects)).EndInit();
            this.skinGroupBox1.ResumeLayout(false);
            this.skinGroupBox1.PerformLayout();
            this.skinTextBox_userName.ResumeLayout(false);
            this.skinTextBox_userName.PerformLayout();
            this.skinTextBox_realName.ResumeLayout(false);
            this.skinTextBox_realName.PerformLayout();
            this.skinTextBox_addTime.ResumeLayout(false);
            this.skinTextBox_addTime.PerformLayout();
            this.skinContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinTextBox skinTextBox_addTime;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private CCWin.SkinControl.SkinTextBox skinTextBox_realName;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinButton skinButton_cancel;
        private CCWin.SkinControl.SkinButton btn_ok;
        private CCWin.SkinControl.SkinTextBox skinTextBox_userName;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinComboBox skinComboBox_role;
        private CCWin.SkinControl.SkinRadioButton skinRadioButton_lock;
        private CCWin.SkinControl.SkinRadioButton skinRadioButton_unLock;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox2;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private CCWin.SkinControl.SkinButton skinButton_add;
        private CCWin.SkinControl.SkinButton skinButton_del;
        private CCWin.SkinControl.SkinButton skinButton_edit;
        private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Add;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Del;
        private CCWin.SkinControl.SkinDataGridView skinDataGridView_projects;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonitoringSoftwareName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonitoringPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsLock;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;

    }
}

