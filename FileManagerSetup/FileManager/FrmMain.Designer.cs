namespace FileManager
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            CCWin.SkinControl.Animation animation1 = new CCWin.SkinControl.Animation();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("主目录");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("测试管理员");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("测试员工");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("系统用户", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("测试管理员");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("测试员工");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("系统用户", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            CCWin.CmSysButton cmSysButton1 = new CCWin.CmSysButton();
            CCWin.CmSysButton cmSysButton2 = new CCWin.CmSysButton();
            CCWin.CmSysButton cmSysButton3 = new CCWin.CmSysButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.skinTabControl1 = new CCWin.SkinControl.SkinTabControl();
            this.tabPageEx1 = new CCWin.SkinControl.SkinTabPage();
            this.linkLabel_UploadMsg = new System.Windows.Forms.LinkLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBox_project = new CCWin.SkinControl.SkinComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel_fileAndForderNum = new System.Windows.Forms.LinkLabel();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel4 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel6 = new CCWin.SkinControl.SkinPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView_project = new System.Windows.Forms.TreeView();
            this.imageList4 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_openClientForder = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_OpenClient = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_View = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_LargeIco = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_SmallIco = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ListView = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_DetailView = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Del = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_OpenServerFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DownFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_historyLog = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_History = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_EidtProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ViewProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.skinPanel5 = new CCWin.SkinControl.SkinPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel3 = new CCWin.SkinControl.SkinPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_parent = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_root = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox_searchContent = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_searchFile = new System.Windows.Forms.ToolStripButton();
            this.skinButton12 = new CCWin.SkinControl.SkinButton();
            this.skinLabel8 = new CCWin.SkinControl.SkinLabel();
            this.skinPictureBox3 = new CCWin.SkinControl.SkinPictureBox();
            this.skinToolStrip2 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripButton_oneClickUpload = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_oneClickDownload = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_rename = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_properryView = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_history = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_del = new System.Windows.Forms.ToolStripButton();
            this.skinLabel19 = new CCWin.SkinControl.SkinLabel();
            this.tabPageEx3 = new CCWin.SkinControl.SkinTabPage();
            this.skinPanel13 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel14 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel15 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel16 = new CCWin.SkinControl.SkinPanel();
            this.skinDataGridView_userList = new CCWin.SkinControl.SkinDataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsHaveAuth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.skinPanel17 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel18 = new CCWin.SkinControl.SkinPanel();
            this.skinToolStrip3 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripButton_addUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_editUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_authUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_delUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.tabPageEx4 = new CCWin.SkinControl.SkinTabPage();
            this.skinButton_right = new CCWin.SkinControl.SkinButton();
            this.skinButton_left = new CCWin.SkinControl.SkinButton();
            this.skinTextBox_page = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel_recondTotal = new CCWin.SkinControl.SkinLabel();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.dateTimePicker_begin = new System.Windows.Forms.DateTimePicker();
            this.skinPanel19 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel20 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel21 = new CCWin.SkinControl.SkinPanel();
            this.skinPanel22 = new CCWin.SkinControl.SkinPanel();
            this.treeView_logUserList = new System.Windows.Forms.TreeView();
            this.skinDataGridView_userLog = new CCWin.SkinControl.SkinDataGridView();
            this.LogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ActionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinPanel23 = new CCWin.SkinControl.SkinPanel();
            this.log_skinTextBox_FileName = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBox_IpAddress = new CCWin.SkinControl.SkinComboBox();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBox_operateType = new CCWin.SkinControl.SkinComboBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinButton_search = new CCWin.SkinControl.SkinButton();
            this.skinToolStrip4 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripButton_delSingle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_delMuli = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton17 = new System.Windows.Forms.ToolStripButton();
            this.skinContextMenuStrip1 = new CCWin.SkinControl.SkinContextMenuStrip();
            this.ToolStripMenuItem_AddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_EditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_AuthUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_DelUser = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.sl_userName = new CCWin.SkinControl.SkinLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.skinContextMenuStrip_State = new CCWin.SkinControl.SkinContextMenuStrip();
            this.toolStrip_userInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_dominSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_autoSaveSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_cancellation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_systemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.skinContextMenuStrip_log = new CCWin.SkinControl.SkinContextMenuStrip();
            this.toolStripMenuItem_delSingle = new System.Windows.Forms.ToolStripMenuItem();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer_autoUpload = new System.Windows.Forms.Timer(this.components);
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.skinToolStrip5 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.skinTabControl1.SuspendLayout();
            this.tabPageEx1.SuspendLayout();
            this.skinPanel1.SuspendLayout();
            this.skinPanel4.SuspendLayout();
            this.skinPanel6.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.skinPanel5.SuspendLayout();
            this.skinPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox3)).BeginInit();
            this.skinToolStrip2.SuspendLayout();
            this.tabPageEx3.SuspendLayout();
            this.skinPanel13.SuspendLayout();
            this.skinPanel14.SuspendLayout();
            this.skinPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView_userList)).BeginInit();
            this.skinPanel17.SuspendLayout();
            this.skinToolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.tabPageEx4.SuspendLayout();
            this.skinTextBox_page.SuspendLayout();
            this.skinPanel19.SuspendLayout();
            this.skinPanel20.SuspendLayout();
            this.skinPanel21.SuspendLayout();
            this.skinPanel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView_userLog)).BeginInit();
            this.skinPanel23.SuspendLayout();
            this.log_skinTextBox_FileName.SuspendLayout();
            this.skinToolStrip4.SuspendLayout();
            this.skinContextMenuStrip1.SuspendLayout();
            this.skinContextMenuStrip_State.SuspendLayout();
            this.skinContextMenuStrip_log.SuspendLayout();
            this.skinToolStrip5.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "hover_360MobileMgr1.png");
            this.imageList.Images.SetKeyName(1, "ico_AdvTools.png");
            this.imageList.Images.SetKeyName(2, "ico_diannaomenzhen.png");
            this.imageList.Images.SetKeyName(3, "ico_dsmain.png");
            this.imageList.Images.SetKeyName(4, "ico_Examine.png");
            this.imageList.Images.SetKeyName(5, "ico_expert.png");
            this.imageList.Images.SetKeyName(6, "ico_rescue.png");
            this.imageList.Images.SetKeyName(7, "ico_softmgr.png");
            this.imageList.Images.SetKeyName(8, "ico_SpeedupOpt.png");
            this.imageList.Images.SetKeyName(9, "ico_SysRepair.png");
            this.imageList.Images.SetKeyName(10, "ico_TraceCleaner.png");
            this.imageList.Images.SetKeyName(11, "ico_VulRepair.png");
            this.imageList.Images.SetKeyName(12, "BigBackup.png");
            this.imageList.Images.SetKeyName(13, "BigLock.png");
            this.imageList.Images.SetKeyName(14, "BigNet.png");
            this.imageList.Images.SetKeyName(15, "cesu_bg.png");
            this.imageList.Images.SetKeyName(16, "MyDisk.png");
            this.imageList.Images.SetKeyName(17, "file_management.png");
            this.imageList.Images.SetKeyName(18, "logsearch.png");
            this.imageList.Images.SetKeyName(19, "user_management.png");
            this.imageList.Images.SetKeyName(20, "file_management.png");
            this.imageList.Images.SetKeyName(21, "logsearch.png");
            this.imageList.Images.SetKeyName(22, "user_management.png");
            // 
            // skinTabControl1
            // 
            this.skinTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.skinTabControl1.Animation = animation1;
            this.skinTabControl1.AnimatorType = CCWin.SkinControl.AnimationType.Transparent;
            this.skinTabControl1.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.skinTabControl1.Controls.Add(this.tabPageEx1);
            this.skinTabControl1.Controls.Add(this.tabPageEx3);
            this.skinTabControl1.Controls.Add(this.tabPageEx4);
            this.skinTabControl1.HeadBack = null;
            this.skinTabControl1.ImageList = this.imageList;
            this.skinTabControl1.ImgSize = new System.Drawing.Size(48, 48);
            this.skinTabControl1.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.skinTabControl1.ItemSize = new System.Drawing.Size(80, 75);
            this.skinTabControl1.Location = new System.Drawing.Point(1, 25);
            this.skinTabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.skinTabControl1.Name = "skinTabControl1";
            this.skinTabControl1.Padding = new System.Drawing.Point(0, 0);
            this.skinTabControl1.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageArrowDown")));
            this.skinTabControl1.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageArrowHover")));
            this.skinTabControl1.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageCloseHover")));
            this.skinTabControl1.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageCloseNormal")));
            this.skinTabControl1.PageDown = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageDown")));
            this.skinTabControl1.PageHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageHover")));
            this.skinTabControl1.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Top;
            this.skinTabControl1.PageNorml = null;
            this.skinTabControl1.PageTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.skinTabControl1.SelectedIndex = 0;
            this.skinTabControl1.Size = new System.Drawing.Size(898, 574);
            this.skinTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.skinTabControl1.TabIndex = 140;
            // 
            // tabPageEx1
            // 
            this.tabPageEx1.BackColor = System.Drawing.Color.White;
            this.tabPageEx1.Controls.Add(this.linkLabel_UploadMsg);
            this.tabPageEx1.Controls.Add(this.skinLabel2);
            this.tabPageEx1.Controls.Add(this.skinComboBox_project);
            this.tabPageEx1.Controls.Add(this.linkLabel1);
            this.tabPageEx1.Controls.Add(this.linkLabel_fileAndForderNum);
            this.tabPageEx1.Controls.Add(this.skinPanel1);
            this.tabPageEx1.Controls.Add(this.skinButton12);
            this.tabPageEx1.Controls.Add(this.skinLabel8);
            this.tabPageEx1.Controls.Add(this.skinPictureBox3);
            this.tabPageEx1.Controls.Add(this.skinToolStrip2);
            this.tabPageEx1.Controls.Add(this.skinLabel19);
            this.tabPageEx1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageEx1.ForeColor = System.Drawing.Color.White;
            this.tabPageEx1.ImageIndex = 20;
            this.tabPageEx1.Location = new System.Drawing.Point(0, 75);
            this.tabPageEx1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageEx1.Name = "tabPageEx1";
            this.tabPageEx1.Size = new System.Drawing.Size(898, 499);
            this.tabPageEx1.TabIndex = 0;
            this.tabPageEx1.Text = "文件管理";
            // 
            // linkLabel_UploadMsg
            // 
            this.linkLabel_UploadMsg.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.linkLabel_UploadMsg.AutoSize = true;
            this.linkLabel_UploadMsg.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel_UploadMsg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel_UploadMsg.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel_UploadMsg.LinkColor = System.Drawing.Color.Red;
            this.linkLabel_UploadMsg.Location = new System.Drawing.Point(314, 477);
            this.linkLabel_UploadMsg.Name = "linkLabel_UploadMsg";
            this.linkLabel_UploadMsg.Size = new System.Drawing.Size(98, 17);
            this.linkLabel_UploadMsg.TabIndex = 181;
            this.linkLabel_UploadMsg.TabStop = true;
            this.linkLabel_UploadMsg.Text = "正在自动备份中..";
            this.linkLabel_UploadMsg.Visible = false;
            this.linkLabel_UploadMsg.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(148)))), ((int)(((byte)(229)))));
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinLabel2.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(148)))), ((int)(((byte)(229)))));
            this.skinLabel2.Location = new System.Drawing.Point(554, 11);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(68, 17);
            this.skinLabel2.TabIndex = 180;
            this.skinLabel2.Text = "当前工程：";
            // 
            // skinComboBox_project
            // 
            this.skinComboBox_project.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_project.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_project.FormattingEnabled = true;
            this.skinComboBox_project.Location = new System.Drawing.Point(622, 8);
            this.skinComboBox_project.Name = "skinComboBox_project";
            this.skinComboBox_project.Size = new System.Drawing.Size(128, 24);
            this.skinComboBox_project.TabIndex = 179;
            this.skinComboBox_project.WaterText = "顶顶顶";
            this.skinComboBox_project.SelectedIndexChanged += new System.EventHandler(this.skinComboBox_project_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Teal;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.linkLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(148)))), ((int)(((byte)(229)))));
            this.linkLabel1.Location = new System.Drawing.Point(777, 11);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 17);
            this.linkLabel1.TabIndex = 143;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(148)))), ((int)(((byte)(229)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel_fileAndForderNum
            // 
            this.linkLabel_fileAndForderNum.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.linkLabel_fileAndForderNum.AutoSize = true;
            this.linkLabel_fileAndForderNum.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel_fileAndForderNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel_fileAndForderNum.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel_fileAndForderNum.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(148)))), ((int)(((byte)(229)))));
            this.linkLabel_fileAndForderNum.Location = new System.Drawing.Point(6, 476);
            this.linkLabel_fileAndForderNum.Name = "linkLabel_fileAndForderNum";
            this.linkLabel_fileAndForderNum.Size = new System.Drawing.Size(139, 17);
            this.linkLabel_fileAndForderNum.TabIndex = 178;
            this.linkLabel_fileAndForderNum.TabStop = true;
            this.linkLabel_fileAndForderNum.Text = "共有300文件夹/300文件";
            this.linkLabel_fileAndForderNum.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(148)))), ((int)(((byte)(229)))));
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.skinPanel4);
            this.skinPanel1.Controls.Add(this.skinPanel2);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(0, 42);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(898, 428);
            this.skinPanel1.TabIndex = 177;
            // 
            // skinPanel4
            // 
            this.skinPanel4.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel4.Controls.Add(this.skinPanel6);
            this.skinPanel4.Controls.Add(this.skinPanel5);
            this.skinPanel4.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel4.DownBack = null;
            this.skinPanel4.Location = new System.Drawing.Point(0, 28);
            this.skinPanel4.MouseBack = null;
            this.skinPanel4.Name = "skinPanel4";
            this.skinPanel4.NormlBack = null;
            this.skinPanel4.Size = new System.Drawing.Size(898, 400);
            this.skinPanel4.TabIndex = 1;
            // 
            // skinPanel6
            // 
            this.skinPanel6.AutoScroll = true;
            this.skinPanel6.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel6.Controls.Add(this.splitContainer1);
            this.skinPanel6.Controls.Add(this.splitter1);
            this.skinPanel6.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.skinPanel6.DownBack = null;
            this.skinPanel6.Location = new System.Drawing.Point(156, 0);
            this.skinPanel6.MouseBack = null;
            this.skinPanel6.Name = "skinPanel6";
            this.skinPanel6.NormlBack = null;
            this.skinPanel6.Size = new System.Drawing.Size(742, 400);
            this.skinPanel6.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer1.Location = new System.Drawing.Point(3, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView_project);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(739, 400);
            this.splitContainer1.SplitterDistance = 154;
            this.splitContainer1.TabIndex = 9;
            // 
            // treeView_project
            // 
            this.treeView_project.AllowDrop = true;
            this.treeView_project.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.treeView_project.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_project.ImageIndex = 4;
            this.treeView_project.ImageList = this.imageList4;
            this.treeView_project.Location = new System.Drawing.Point(0, 0);
            this.treeView_project.Name = "treeView_project";
            treeNode1.Checked = true;
            treeNode1.ImageIndex = 4;
            treeNode1.Name = "tRoot";
            treeNode1.NodeFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode1.SelectedImageKey = "49.png";
            treeNode1.Tag = "0";
            treeNode1.Text = "主目录";
            treeNode1.ToolTipText = "主目录";
            this.treeView_project.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView_project.SelectedImageIndex = 4;
            this.treeView_project.Size = new System.Drawing.Size(154, 400);
            this.treeView_project.TabIndex = 8;
            this.treeView_project.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_project_BeforeExpand);
            this.treeView_project.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_project_AfterSelect);
            // 
            // imageList4
            // 
            this.imageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4.ImageStream")));
            this.imageList4.TransparentColor = System.Drawing.SystemColors.Control;
            this.imageList4.Images.SetKeyName(0, "driver.ico");
            this.imageList4.Images.SetKeyName(1, "cdrom.ico");
            this.imageList4.Images.SetKeyName(2, "folder1.ico");
            this.imageList4.Images.SetKeyName(3, "folder2.ico");
            this.imageList4.Images.SetKeyName(4, "Folder_32x32.png");
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.LargeImageList = this.imageList3;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(581, 400);
            this.listView1.SmallImageList = this.imageList2;
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 240;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "大小";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "类型";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "修改日期";
            this.columnHeader4.Width = 155;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_openClientForder,
            this.ToolStripMenuItem_OpenClient,
            this.ToolStripMenuItem_View,
            this.ToolStripMenuItem_Refresh,
            this.toolStripMenuItem3,
            this.ToolStripMenuItem_Rename,
            this.ToolStripMenuItem_Del,
            this.toolStripMenuItem4,
            this.toolStripMenuItem_OpenServerFile,
            this.toolStripMenuItem_DownFile,
            this.toolStripMenuItem_historyLog,
            this.ToolStripMenuItem_History,
            this.toolStripMenuItem1,
            this.ToolStripMenuItem_EidtProperty,
            this.ToolStripMenuItem_ViewProperty});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 286);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem_openClientForder
            // 
            this.toolStripMenuItem_openClientForder.Name = "toolStripMenuItem_openClientForder";
            this.toolStripMenuItem_openClientForder.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem_openClientForder.Text = "打开本地文件夹";
            this.toolStripMenuItem_openClientForder.Visible = false;
            this.toolStripMenuItem_openClientForder.Click += new System.EventHandler(this.toolStripMenuItem_openClientForder_Click);
            // 
            // ToolStripMenuItem_OpenClient
            // 
            this.ToolStripMenuItem_OpenClient.Name = "ToolStripMenuItem_OpenClient";
            this.ToolStripMenuItem_OpenClient.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem_OpenClient.Text = "本地打开";
            this.ToolStripMenuItem_OpenClient.Click += new System.EventHandler(this.ToolStripMenuItem_OpenClient_Click);
            // 
            // ToolStripMenuItem_View
            // 
            this.ToolStripMenuItem_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_LargeIco,
            this.ToolStripMenuItem_SmallIco,
            this.ToolStripMenuItem_ListView,
            this.ToolStripMenuItem_DetailView});
            this.ToolStripMenuItem_View.Name = "ToolStripMenuItem_View";
            this.ToolStripMenuItem_View.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem_View.Text = "查看类别";
            this.ToolStripMenuItem_View.Visible = false;
            // 
            // ToolStripMenuItem_LargeIco
            // 
            this.ToolStripMenuItem_LargeIco.Name = "ToolStripMenuItem_LargeIco";
            this.ToolStripMenuItem_LargeIco.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_LargeIco.Text = "大图标";
            this.ToolStripMenuItem_LargeIco.Click += new System.EventHandler(this.ToolStripMenuItem_LargeIco_Click);
            // 
            // ToolStripMenuItem_SmallIco
            // 
            this.ToolStripMenuItem_SmallIco.Enabled = false;
            this.ToolStripMenuItem_SmallIco.Name = "ToolStripMenuItem_SmallIco";
            this.ToolStripMenuItem_SmallIco.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_SmallIco.Text = "小图标";
            this.ToolStripMenuItem_SmallIco.Visible = false;
            this.ToolStripMenuItem_SmallIco.Click += new System.EventHandler(this.ToolStripMenuItem_SmallIco_Click);
            // 
            // ToolStripMenuItem_ListView
            // 
            this.ToolStripMenuItem_ListView.Enabled = false;
            this.ToolStripMenuItem_ListView.Name = "ToolStripMenuItem_ListView";
            this.ToolStripMenuItem_ListView.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_ListView.Text = "列表";
            this.ToolStripMenuItem_ListView.Visible = false;
            this.ToolStripMenuItem_ListView.Click += new System.EventHandler(this.ToolStripMenuItem_ListView_Click);
            // 
            // ToolStripMenuItem_DetailView
            // 
            this.ToolStripMenuItem_DetailView.Checked = true;
            this.ToolStripMenuItem_DetailView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_DetailView.Name = "ToolStripMenuItem_DetailView";
            this.ToolStripMenuItem_DetailView.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_DetailView.Text = "详细信息";
            this.ToolStripMenuItem_DetailView.Click += new System.EventHandler(this.ToolStripMenuItem_DetailView_Click);
            // 
            // ToolStripMenuItem_Refresh
            // 
            this.ToolStripMenuItem_Refresh.Name = "ToolStripMenuItem_Refresh";
            this.ToolStripMenuItem_Refresh.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem_Refresh.Text = "刷新";
            this.ToolStripMenuItem_Refresh.Visible = false;
            this.ToolStripMenuItem_Refresh.Click += new System.EventHandler(this.ToolStripMenuItem_Refresh_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(157, 6);
            this.toolStripMenuItem3.Visible = false;
            // 
            // ToolStripMenuItem_Rename
            // 
            this.ToolStripMenuItem_Rename.Image = global::FileManager.Properties.Resources.RenameLarge;
            this.ToolStripMenuItem_Rename.Name = "ToolStripMenuItem_Rename";
            this.ToolStripMenuItem_Rename.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem_Rename.Text = "重命名";
            this.ToolStripMenuItem_Rename.Click += new System.EventHandler(this.toolStripMenuItem_Rename_Click);
            // 
            // ToolStripMenuItem_Del
            // 
            this.ToolStripMenuItem_Del.Image = global::FileManager.Properties.Resources.DeleteLarge1;
            this.ToolStripMenuItem_Del.Name = "ToolStripMenuItem_Del";
            this.ToolStripMenuItem_Del.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem_Del.Text = "删除";
            this.ToolStripMenuItem_Del.Click += new System.EventHandler(this.ToolStripMenuItem_Del_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripMenuItem_OpenServerFile
            // 
            this.toolStripMenuItem_OpenServerFile.Name = "toolStripMenuItem_OpenServerFile";
            this.toolStripMenuItem_OpenServerFile.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem_OpenServerFile.Text = "预览";
            this.toolStripMenuItem_OpenServerFile.Click += new System.EventHandler(this.toolStripMenuItem_OpenServerFile_Click);
            // 
            // toolStripMenuItem_DownFile
            // 
            this.toolStripMenuItem_DownFile.Name = "toolStripMenuItem_DownFile";
            this.toolStripMenuItem_DownFile.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem_DownFile.Text = "下载";
            this.toolStripMenuItem_DownFile.Click += new System.EventHandler(this.toolStripMenuItem_DownFile_Click);
            // 
            // toolStripMenuItem_historyLog
            // 
            this.toolStripMenuItem_historyLog.Name = "toolStripMenuItem_historyLog";
            this.toolStripMenuItem_historyLog.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem_historyLog.Text = "操作日志";
            this.toolStripMenuItem_historyLog.Click += new System.EventHandler(this.toolStripMenuItem_historyLog_Click);
            // 
            // ToolStripMenuItem_History
            // 
            this.ToolStripMenuItem_History.Name = "ToolStripMenuItem_History";
            this.ToolStripMenuItem_History.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem_History.Text = "历史版本";
            this.ToolStripMenuItem_History.Click += new System.EventHandler(this.toolStripMenuItem_History_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // ToolStripMenuItem_EidtProperty
            // 
            this.ToolStripMenuItem_EidtProperty.Name = "ToolStripMenuItem_EidtProperty";
            this.ToolStripMenuItem_EidtProperty.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem_EidtProperty.Text = "编辑属性";
            this.ToolStripMenuItem_EidtProperty.Visible = false;
            this.ToolStripMenuItem_EidtProperty.Click += new System.EventHandler(this.ToolStripMenuItem_EidtProperty_Click);
            // 
            // ToolStripMenuItem_ViewProperty
            // 
            this.ToolStripMenuItem_ViewProperty.Name = "ToolStripMenuItem_ViewProperty";
            this.ToolStripMenuItem_ViewProperty.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItem_ViewProperty.Text = "属性查看";
            this.ToolStripMenuItem_ViewProperty.Click += new System.EventHandler(this.ToolStripMenuItem_ViewProperty_Click);
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.SystemColors.Control;
            this.imageList3.Images.SetKeyName(0, "driver.ico");
            this.imageList3.Images.SetKeyName(1, "cdrom.ico");
            this.imageList3.Images.SetKeyName(2, "folder1.ico");
            this.imageList3.Images.SetKeyName(3, "folder.ico");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.SystemColors.Control;
            this.imageList2.Images.SetKeyName(0, "driver.ico");
            this.imageList2.Images.SetKeyName(1, "cdrom.ico");
            this.imageList2.Images.SetKeyName(2, "folder1.ico");
            this.imageList2.Images.SetKeyName(3, "folder.ico");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 400);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // skinPanel5
            // 
            this.skinPanel5.AutoScroll = true;
            this.skinPanel5.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel5.Controls.Add(this.treeView1);
            this.skinPanel5.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.skinPanel5.DownBack = null;
            this.skinPanel5.Location = new System.Drawing.Point(0, 0);
            this.skinPanel5.MouseBack = null;
            this.skinPanel5.Name = "skinPanel5";
            this.skinPanel5.NormlBack = null;
            this.skinPanel5.Size = new System.Drawing.Size(159, 400);
            this.skinPanel5.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 2;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode2.ImageIndex = 5;
            treeNode2.Name = "tTestNode001";
            treeNode2.SelectedImageKey = "5471.gif";
            treeNode2.Text = "测试管理员";
            treeNode2.ToolTipText = "测试管理员";
            treeNode3.ImageIndex = 4;
            treeNode3.Name = "tTestNode002";
            treeNode3.SelectedImageKey = "1291DB96250-5E01.png";
            treeNode3.Text = "测试员工";
            treeNode3.ToolTipText = "测试员工";
            treeNode4.ImageIndex = 2;
            treeNode4.Name = "tRoot";
            treeNode4.NodeFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode4.SelectedImageKey = "49.png";
            treeNode4.Text = "系统用户";
            treeNode4.ToolTipText = "系统用户";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeView1.SelectedImageIndex = 2;
            this.treeView1.Size = new System.Drawing.Size(159, 400);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Go.bmp");
            this.imageList1.Images.SetKeyName(1, "up1.png");
            this.imageList1.Images.SetKeyName(2, "49.png");
            this.imageList1.Images.SetKeyName(3, "61dee5a4a9e7a9bae4be9de784b6e5be88e8939d652135.jpg");
            this.imageList1.Images.SetKeyName(4, "1291DB96250-5E01.png");
            this.imageList1.Images.SetKeyName(5, "5471.gif");
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.skinPanel3);
            this.skinPanel2.Controls.Add(this.toolStrip1);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(0, 0);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(898, 28);
            this.skinPanel2.TabIndex = 0;
            // 
            // skinPanel3
            // 
            this.skinPanel3.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel3.DownBack = null;
            this.skinPanel3.Location = new System.Drawing.Point(-3, 28);
            this.skinPanel3.MouseBack = null;
            this.skinPanel3.Name = "skinPanel3";
            this.skinPanel3.NormlBack = null;
            this.skinPanel3.Size = new System.Drawing.Size(898, 399);
            this.skinPanel3.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripButton_parent,
            this.toolStripButton_root,
            this.toolStripButton_refresh,
            this.toolStripTextBox_searchContent,
            this.toolStripButton_searchFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(898, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripLabel1.LinkColor = System.Drawing.Color.Blue;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 25);
            this.toolStripLabel1.Text = "路径";
            this.toolStripLabel1.ToolTipText = "路径";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.BackColor = System.Drawing.Color.White;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(440, 25);
            // 
            // toolStripButton_parent
            // 
            this.toolStripButton_parent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_parent.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_parent.Image")));
            this.toolStripButton_parent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_parent.Name = "toolStripButton_parent";
            this.toolStripButton_parent.Size = new System.Drawing.Size(23, 25);
            this.toolStripButton_parent.Text = "向上一级";
            this.toolStripButton_parent.Click += new System.EventHandler(this.toolStripButton_parent_Click);
            // 
            // toolStripButton_root
            // 
            this.toolStripButton_root.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_root.Image = global::FileManager.Properties.Resources.app_icon_401;
            this.toolStripButton_root.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_root.Name = "toolStripButton_root";
            this.toolStripButton_root.Size = new System.Drawing.Size(23, 25);
            this.toolStripButton_root.Text = "根目录";
            this.toolStripButton_root.Click += new System.EventHandler(this.toolStripButton_root_Click);
            // 
            // toolStripButton_refresh
            // 
            this.toolStripButton_refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_refresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_refresh.Image")));
            this.toolStripButton_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_refresh.Name = "toolStripButton_refresh";
            this.toolStripButton_refresh.Size = new System.Drawing.Size(23, 25);
            this.toolStripButton_refresh.Text = "刷新目录";
            this.toolStripButton_refresh.Click += new System.EventHandler(this.toolStripButton_refresh_Click);
            // 
            // toolStripTextBox_searchContent
            // 
            this.toolStripTextBox_searchContent.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.toolStripTextBox_searchContent.Name = "toolStripTextBox_searchContent";
            this.toolStripTextBox_searchContent.Size = new System.Drawing.Size(250, 28);
            this.toolStripTextBox_searchContent.Text = "搜索文件  ";
            this.toolStripTextBox_searchContent.Click += new System.EventHandler(this.toolStripTextBox_searchContent_Click);
            // 
            // toolStripButton_searchFile
            // 
            this.toolStripButton_searchFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_searchFile.Image = global::FileManager.Properties.Resources.search_icon_hover;
            this.toolStripButton_searchFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_searchFile.Name = "toolStripButton_searchFile";
            this.toolStripButton_searchFile.Size = new System.Drawing.Size(23, 25);
            this.toolStripButton_searchFile.Text = "toolStripButton1";
            this.toolStripButton_searchFile.ToolTipText = "搜索文件";
            this.toolStripButton_searchFile.Click += new System.EventHandler(this.toolStripButton_searchFile_Click);
            // 
            // skinButton12
            // 
            this.skinButton12.BackColor = System.Drawing.Color.Transparent;
            this.skinButton12.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton12.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButton12.DownBack")));
            this.skinButton12.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton12.Location = new System.Drawing.Point(872, 476);
            this.skinButton12.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton12.MouseBack")));
            this.skinButton12.Name = "skinButton12";
            this.skinButton12.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton12.NormlBack")));
            this.skinButton12.Size = new System.Drawing.Size(12, 12);
            this.skinButton12.TabIndex = 176;
            this.skinButton12.UseVisualStyleBackColor = false;
            // 
            // skinLabel8
            // 
            this.skinLabel8.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel8.AutoSize = true;
            this.skinLabel8.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel8.BorderColor = System.Drawing.Color.White;
            this.skinLabel8.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.skinLabel8.ForeColor = System.Drawing.Color.Black;
            this.skinLabel8.Location = new System.Drawing.Point(677, 475);
            this.skinLabel8.Name = "skinLabel8";
            this.skinLabel8.Size = new System.Drawing.Size(198, 16);
            this.skinLabel8.TabIndex = 175;
            this.skinLabel8.Text = "成功连接至数据管理中心      1.2.0.0001";
            // 
            // skinPictureBox3
            // 
            this.skinPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("skinPictureBox3.Image")));
            this.skinPictureBox3.Location = new System.Drawing.Point(659, 477);
            this.skinPictureBox3.Name = "skinPictureBox3";
            this.skinPictureBox3.Size = new System.Drawing.Size(17, 12);
            this.skinPictureBox3.TabIndex = 174;
            this.skinPictureBox3.TabStop = false;
            // 
            // skinToolStrip2
            // 
            this.skinToolStrip2.Arrow = System.Drawing.Color.White;
            this.skinToolStrip2.AutoSize = false;
            this.skinToolStrip2.Back = System.Drawing.Color.Transparent;
            this.skinToolStrip2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinToolStrip2.BackRadius = 4;
            this.skinToolStrip2.BackRectangle = new System.Drawing.Rectangle(5, 5, 5, 5);
            this.skinToolStrip2.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip2.BaseFore = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.skinToolStrip2.BaseForeAnamorphosis = false;
            this.skinToolStrip2.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip2.BaseForeAnamorphosisColor = System.Drawing.Color.Black;
            this.skinToolStrip2.BaseForeOffset = new System.Drawing.Point(3, 6);
            this.skinToolStrip2.BaseHoverFore = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.skinToolStrip2.BaseItemAnamorphosis = false;
            this.skinToolStrip2.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.skinToolStrip2.BaseItemBorderShow = false;
            this.skinToolStrip2.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip2.BaseItemDown")));
            this.skinToolStrip2.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skinToolStrip2.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip2.BaseItemMouse")));
            this.skinToolStrip2.BaseItemNorml = null;
            this.skinToolStrip2.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip2.BaseItemRadius = 2;
            this.skinToolStrip2.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip2.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skinToolStrip2.BindTabControl = null;
            this.skinToolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.skinToolStrip2.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip2.Fore = System.Drawing.Color.Black;
            this.skinToolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
            this.skinToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip2.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.skinToolStrip2.ItemAnamorphosis = false;
            this.skinToolStrip2.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip2.ItemBorderShow = false;
            this.skinToolStrip2.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip2.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip2.ItemRadius = 1;
            this.skinToolStrip2.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_oneClickUpload,
            this.toolStripButton_oneClickDownload,
            this.toolStripButton_rename,
            this.toolStripButton_properryView,
            this.toolStripButton_history,
            this.toolStripButton_del});
            this.skinToolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.skinToolStrip2.Location = new System.Drawing.Point(3, 2);
            this.skinToolStrip2.Name = "skinToolStrip2";
            this.skinToolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.skinToolStrip2.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip2.Size = new System.Drawing.Size(895, 37);
            this.skinToolStrip2.SkinAllColor = true;
            this.skinToolStrip2.TabIndex = 173;
            this.skinToolStrip2.Text = "今天";
            this.skinToolStrip2.TitleAnamorphosis = false;
            this.skinToolStrip2.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip2.TitleRadius = 4;
            this.skinToolStrip2.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // toolStripButton_oneClickUpload
            // 
            this.toolStripButton_oneClickUpload.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_oneClickUpload.ForeColor = System.Drawing.Color.White;
            this.toolStripButton_oneClickUpload.Image = global::FileManager.Properties.Resources.icon_upload;
            this.toolStripButton_oneClickUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton_oneClickUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_oneClickUpload.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton_oneClickUpload.MergeIndex = 0;
            this.toolStripButton_oneClickUpload.Name = "toolStripButton_oneClickUpload";
            this.toolStripButton_oneClickUpload.Size = new System.Drawing.Size(92, 36);
            this.toolStripButton_oneClickUpload.Text = "数据备份";
            this.toolStripButton_oneClickUpload.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton_oneClickUpload.ToolTipText = "一键上传";
            this.toolStripButton_oneClickUpload.Click += new System.EventHandler(this.toolStripButton_oneClickUpload_Click);
            // 
            // toolStripButton_oneClickDownload
            // 
            this.toolStripButton_oneClickDownload.AutoToolTip = false;
            this.toolStripButton_oneClickDownload.ForeColor = System.Drawing.Color.White;
            this.toolStripButton_oneClickDownload.Image = global::FileManager.Properties.Resources.icon_download;
            this.toolStripButton_oneClickDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton_oneClickDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_oneClickDownload.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton_oneClickDownload.MergeIndex = 0;
            this.toolStripButton_oneClickDownload.Name = "toolStripButton_oneClickDownload";
            this.toolStripButton_oneClickDownload.Size = new System.Drawing.Size(92, 36);
            this.toolStripButton_oneClickDownload.Text = "数据恢复";
            this.toolStripButton_oneClickDownload.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton_oneClickDownload.Click += new System.EventHandler(this.toolStripButton_oneClickDownload_Click);
            // 
            // toolStripButton_rename
            // 
            this.toolStripButton_rename.AutoToolTip = false;
            this.toolStripButton_rename.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripButton_rename.ForeColor = System.Drawing.Color.White;
            this.toolStripButton_rename.Image = global::FileManager.Properties.Resources.icon_editname;
            this.toolStripButton_rename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_rename.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton_rename.MergeIndex = 0;
            this.toolStripButton_rename.Name = "toolStripButton_rename";
            this.toolStripButton_rename.Size = new System.Drawing.Size(104, 36);
            this.toolStripButton_rename.Text = "文件重命名";
            this.toolStripButton_rename.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton_rename.Click += new System.EventHandler(this.toolStripButton_rename_Click);
            // 
            // toolStripButton_properryView
            // 
            this.toolStripButton_properryView.AutoSize = false;
            this.toolStripButton_properryView.AutoToolTip = false;
            this.toolStripButton_properryView.ForeColor = System.Drawing.Color.White;
            this.toolStripButton_properryView.Image = global::FileManager.Properties.Resources.icon_check;
            this.toolStripButton_properryView.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton_properryView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_properryView.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton_properryView.MergeIndex = 0;
            this.toolStripButton_properryView.Name = "toolStripButton_properryView";
            this.toolStripButton_properryView.Size = new System.Drawing.Size(92, 36);
            this.toolStripButton_properryView.Text = "查看属性";
            this.toolStripButton_properryView.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton_properryView.Click += new System.EventHandler(this.toolStripButton_properryView_Click);
            // 
            // toolStripButton_history
            // 
            this.toolStripButton_history.AutoToolTip = false;
            this.toolStripButton_history.ForeColor = System.Drawing.Color.White;
            this.toolStripButton_history.Image = global::FileManager.Properties.Resources.icon_history;
            this.toolStripButton_history.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton_history.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_history.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton_history.MergeIndex = 0;
            this.toolStripButton_history.Name = "toolStripButton_history";
            this.toolStripButton_history.Size = new System.Drawing.Size(92, 36);
            this.toolStripButton_history.Text = "历史版本";
            this.toolStripButton_history.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton_history.Click += new System.EventHandler(this.toolStripButton_history_Click);
            // 
            // toolStripButton_del
            // 
            this.toolStripButton_del.AutoToolTip = false;
            this.toolStripButton_del.ForeColor = System.Drawing.Color.White;
            this.toolStripButton_del.Image = global::FileManager.Properties.Resources.icon_delete;
            this.toolStripButton_del.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_del.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton_del.MergeIndex = 0;
            this.toolStripButton_del.Name = "toolStripButton_del";
            this.toolStripButton_del.Size = new System.Drawing.Size(68, 36);
            this.toolStripButton_del.Text = "删除";
            this.toolStripButton_del.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton_del.Click += new System.EventHandler(this.toolStripButton_del_Click);
            // 
            // skinLabel19
            // 
            this.skinLabel19.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel19.AutoSize = true;
            this.skinLabel19.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel19.BorderColor = System.Drawing.Color.White;
            this.skinLabel19.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.skinLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.skinLabel19.Location = new System.Drawing.Point(282, 173);
            this.skinLabel19.Name = "skinLabel19";
            this.skinLabel19.Size = new System.Drawing.Size(362, 22);
            this.skinLabel19.TabIndex = 163;
            this.skinLabel19.Text = "上次电脑体检良好，请继续保持每天体检的习惯！";
            this.skinLabel19.Visible = false;
            // 
            // tabPageEx3
            // 
            this.tabPageEx3.BackColor = System.Drawing.Color.White;
            this.tabPageEx3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPageEx3.Controls.Add(this.skinPanel13);
            this.tabPageEx3.Controls.Add(this.skinToolStrip3);
            this.tabPageEx3.Controls.Add(this.pictureBox6);
            this.tabPageEx3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.tabPageEx3.ForeColor = System.Drawing.Color.White;
            this.tabPageEx3.ImageIndex = 22;
            this.tabPageEx3.Location = new System.Drawing.Point(0, 75);
            this.tabPageEx3.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageEx3.Name = "tabPageEx3";
            this.tabPageEx3.Size = new System.Drawing.Size(898, 499);
            this.tabPageEx3.TabIndex = 2;
            this.tabPageEx3.Text = "用户管理";
            // 
            // skinPanel13
            // 
            this.skinPanel13.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel13.Controls.Add(this.skinPanel14);
            this.skinPanel13.Controls.Add(this.skinPanel17);
            this.skinPanel13.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel13.DownBack = null;
            this.skinPanel13.Location = new System.Drawing.Point(-3, 42);
            this.skinPanel13.MouseBack = null;
            this.skinPanel13.Name = "skinPanel13";
            this.skinPanel13.NormlBack = null;
            this.skinPanel13.Size = new System.Drawing.Size(898, 428);
            this.skinPanel13.TabIndex = 181;
            // 
            // skinPanel14
            // 
            this.skinPanel14.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel14.Controls.Add(this.skinPanel15);
            this.skinPanel14.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel14.DownBack = null;
            this.skinPanel14.Location = new System.Drawing.Point(0, 0);
            this.skinPanel14.MouseBack = null;
            this.skinPanel14.Name = "skinPanel14";
            this.skinPanel14.NormlBack = null;
            this.skinPanel14.Size = new System.Drawing.Size(898, 428);
            this.skinPanel14.TabIndex = 1;
            // 
            // skinPanel15
            // 
            this.skinPanel15.AutoScroll = true;
            this.skinPanel15.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel15.Controls.Add(this.skinPanel16);
            this.skinPanel15.Controls.Add(this.skinDataGridView_userList);
            this.skinPanel15.Controls.Add(this.splitter3);
            this.skinPanel15.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel15.DownBack = null;
            this.skinPanel15.Location = new System.Drawing.Point(0, 0);
            this.skinPanel15.MouseBack = null;
            this.skinPanel15.Name = "skinPanel15";
            this.skinPanel15.NormlBack = null;
            this.skinPanel15.Size = new System.Drawing.Size(898, 428);
            this.skinPanel15.TabIndex = 7;
            // 
            // skinPanel16
            // 
            this.skinPanel16.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinPanel16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinPanel16.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.skinPanel16.DownBack = null;
            this.skinPanel16.Location = new System.Drawing.Point(3, 0);
            this.skinPanel16.MouseBack = null;
            this.skinPanel16.Name = "skinPanel16";
            this.skinPanel16.NormlBack = null;
            this.skinPanel16.Size = new System.Drawing.Size(159, 428);
            this.skinPanel16.TabIndex = 11;
            // 
            // skinDataGridView_userList
            // 
            this.skinDataGridView_userList.AllowUserToAddRows = false;
            this.skinDataGridView_userList.AllowUserToOrderColumns = true;
            this.skinDataGridView_userList.AlternatingCellBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.skinDataGridView_userList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.skinDataGridView_userList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.skinDataGridView_userList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.skinDataGridView_userList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinDataGridView_userList.ColumnFont = null;
            this.skinDataGridView_userList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.skinDataGridView_userList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.skinDataGridView_userList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.skinDataGridView_userList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.dataGridViewTextBoxColumn39,
            this.dataGridViewTextBoxColumn40,
            this.Column3,
            this.IsHaveAuth,
            this.dataGridViewTextBoxColumn41,
            this.dataGridViewTextBoxColumn42});
            this.skinDataGridView_userList.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.skinDataGridView_userList.DefaultCellStyle = dataGridViewCellStyle3;
            this.skinDataGridView_userList.EnableHeadersVisualStyles = false;
            this.skinDataGridView_userList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinDataGridView_userList.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.skinDataGridView_userList.HeadFont = new System.Drawing.Font("微软雅黑", 9F);
            this.skinDataGridView_userList.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView_userList.Location = new System.Drawing.Point(162, 0);
            this.skinDataGridView_userList.Margin = new System.Windows.Forms.Padding(10);
            this.skinDataGridView_userList.MouseCellBackColor = System.Drawing.Color.White;
            this.skinDataGridView_userList.MultiSelect = false;
            this.skinDataGridView_userList.Name = "skinDataGridView_userList";
            this.skinDataGridView_userList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.skinDataGridView_userList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView_userList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.skinDataGridView_userList.RowTemplate.Height = 23;
            this.skinDataGridView_userList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.skinDataGridView_userList.Size = new System.Drawing.Size(736, 428);
            this.skinDataGridView_userList.SkinGridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.skinDataGridView_userList.TabIndex = 10;
            this.skinDataGridView_userList.TitleBack = null;
            this.skinDataGridView_userList.TitleBackColorBegin = System.Drawing.Color.White;
            this.skinDataGridView_userList.TitleBackColorEnd = System.Drawing.SystemColors.Control;
            this.skinDataGridView_userList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.skinDataGridView_userList_CellDoubleClick);
            this.skinDataGridView_userList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.skinDataGridView_userList_CellMouseClick);
            this.skinDataGridView_userList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.skinDataGridView_userList_DataBindingComplete);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 50;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "userName";
            this.dataGridViewTextBoxColumn39.HeaderText = "账号";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.Width = 80;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "userRealName";
            this.dataGridViewTextBoxColumn40.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "userRoleName";
            this.Column3.HeaderText = "角色";
            this.Column3.Name = "Column3";
            // 
            // IsHaveAuth
            // 
            this.IsHaveAuth.DataPropertyName = "IsHaveAuth";
            this.IsHaveAuth.HeaderText = "权限";
            this.IsHaveAuth.Name = "IsHaveAuth";
            this.IsHaveAuth.Width = 60;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "userLastIp";
            this.dataGridViewTextBoxColumn41.HeaderText = "账号近期登录IP";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.Width = 80;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.DataPropertyName = "userLastClientPath";
            this.dataGridViewTextBoxColumn42.HeaderText = "账号近期使用地址";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.Width = 260;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(0, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 428);
            this.splitter3.TabIndex = 6;
            this.splitter3.TabStop = false;
            // 
            // skinPanel17
            // 
            this.skinPanel17.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel17.Controls.Add(this.skinPanel18);
            this.skinPanel17.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel17.DownBack = null;
            this.skinPanel17.Location = new System.Drawing.Point(0, 0);
            this.skinPanel17.MouseBack = null;
            this.skinPanel17.Name = "skinPanel17";
            this.skinPanel17.NormlBack = null;
            this.skinPanel17.Size = new System.Drawing.Size(898, 28);
            this.skinPanel17.TabIndex = 0;
            // 
            // skinPanel18
            // 
            this.skinPanel18.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel18.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel18.DownBack = null;
            this.skinPanel18.Location = new System.Drawing.Point(-3, 28);
            this.skinPanel18.MouseBack = null;
            this.skinPanel18.Name = "skinPanel18";
            this.skinPanel18.NormlBack = null;
            this.skinPanel18.Size = new System.Drawing.Size(898, 399);
            this.skinPanel18.TabIndex = 1;
            // 
            // skinToolStrip3
            // 
            this.skinToolStrip3.Arrow = System.Drawing.Color.White;
            this.skinToolStrip3.AutoSize = false;
            this.skinToolStrip3.Back = System.Drawing.Color.Transparent;
            this.skinToolStrip3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinToolStrip3.BackRadius = 4;
            this.skinToolStrip3.BackRectangle = new System.Drawing.Rectangle(5, 5, 5, 5);
            this.skinToolStrip3.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip3.BaseFore = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.skinToolStrip3.BaseForeAnamorphosis = false;
            this.skinToolStrip3.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip3.BaseForeAnamorphosisColor = System.Drawing.Color.Black;
            this.skinToolStrip3.BaseForeOffset = new System.Drawing.Point(3, 6);
            this.skinToolStrip3.BaseHoverFore = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.skinToolStrip3.BaseItemAnamorphosis = false;
            this.skinToolStrip3.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.skinToolStrip3.BaseItemBorderShow = false;
            this.skinToolStrip3.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip3.BaseItemDown")));
            this.skinToolStrip3.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skinToolStrip3.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip3.BaseItemMouse")));
            this.skinToolStrip3.BaseItemNorml = null;
            this.skinToolStrip3.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip3.BaseItemRadius = 2;
            this.skinToolStrip3.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip3.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skinToolStrip3.BindTabControl = null;
            this.skinToolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.skinToolStrip3.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip3.Fore = System.Drawing.Color.Black;
            this.skinToolStrip3.GripMargin = new System.Windows.Forms.Padding(0);
            this.skinToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip3.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip3.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.skinToolStrip3.ItemAnamorphosis = false;
            this.skinToolStrip3.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.ItemBorderShow = false;
            this.skinToolStrip3.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.ItemRadius = 1;
            this.skinToolStrip3.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_addUser,
            this.toolStripButton_editUser,
            this.toolStripButton_authUser,
            this.toolStripButton_delUser,
            this.toolStripButton16});
            this.skinToolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.skinToolStrip3.Location = new System.Drawing.Point(0, 2);
            this.skinToolStrip3.Name = "skinToolStrip3";
            this.skinToolStrip3.Padding = new System.Windows.Forms.Padding(0);
            this.skinToolStrip3.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip3.Size = new System.Drawing.Size(895, 37);
            this.skinToolStrip3.SkinAllColor = true;
            this.skinToolStrip3.TabIndex = 180;
            this.skinToolStrip3.Text = "今天";
            this.skinToolStrip3.TitleAnamorphosis = false;
            this.skinToolStrip3.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip3.TitleRadius = 4;
            this.skinToolStrip3.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // toolStripButton_addUser
            // 
            this.toolStripButton_addUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_addUser.ForeColor = System.Drawing.Color.White;
            this.toolStripButton_addUser.Image = global::FileManager.Properties.Resources.icon_adduser;
            this.toolStripButton_addUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton_addUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_addUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_addUser.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton_addUser.MergeIndex = 0;
            this.toolStripButton_addUser.Name = "toolStripButton_addUser";
            this.toolStripButton_addUser.Size = new System.Drawing.Size(92, 36);
            this.toolStripButton_addUser.Text = "添加用户";
            this.toolStripButton_addUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton_addUser.ToolTipText = "一键上传";
            this.toolStripButton_addUser.Click += new System.EventHandler(this.toolStripButton_addUser_Click);
            // 
            // toolStripButton_editUser
            // 
            this.toolStripButton_editUser.AutoToolTip = false;
            this.toolStripButton_editUser.ForeColor = System.Drawing.Color.White;
            this.toolStripButton_editUser.Image = global::FileManager.Properties.Resources.icon_useredit;
            this.toolStripButton_editUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton_editUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_editUser.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton_editUser.MergeIndex = 0;
            this.toolStripButton_editUser.Name = "toolStripButton_editUser";
            this.toolStripButton_editUser.Size = new System.Drawing.Size(92, 36);
            this.toolStripButton_editUser.Text = "编辑用户";
            this.toolStripButton_editUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton_editUser.Click += new System.EventHandler(this.toolStripButton_editUser_Click);
            // 
            // toolStripButton_authUser
            // 
            this.toolStripButton_authUser.AutoToolTip = false;
            this.toolStripButton_authUser.ForeColor = System.Drawing.Color.White;
            this.toolStripButton_authUser.Image = global::FileManager.Properties.Resources.icon_authority;
            this.toolStripButton_authUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_authUser.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton_authUser.MergeIndex = 0;
            this.toolStripButton_authUser.Name = "toolStripButton_authUser";
            this.toolStripButton_authUser.Size = new System.Drawing.Size(92, 36);
            this.toolStripButton_authUser.Text = "用户授权";
            this.toolStripButton_authUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton_authUser.Click += new System.EventHandler(this.toolStripButton_authUser_Click);
            // 
            // toolStripButton_delUser
            // 
            this.toolStripButton_delUser.AutoSize = false;
            this.toolStripButton_delUser.AutoToolTip = false;
            this.toolStripButton_delUser.ForeColor = System.Drawing.Color.White;
            this.toolStripButton_delUser.Image = global::FileManager.Properties.Resources.icon_deluser;
            this.toolStripButton_delUser.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton_delUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_delUser.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton_delUser.MergeIndex = 0;
            this.toolStripButton_delUser.Name = "toolStripButton_delUser";
            this.toolStripButton_delUser.Size = new System.Drawing.Size(92, 36);
            this.toolStripButton_delUser.Text = "删除用户";
            this.toolStripButton_delUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton_delUser.Click += new System.EventHandler(this.toolStripButton_delUser_Click);
            // 
            // toolStripButton16
            // 
            this.toolStripButton16.AutoToolTip = false;
            this.toolStripButton16.ForeColor = System.Drawing.Color.White;
            this.toolStripButton16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton16.Image")));
            this.toolStripButton16.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton16.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton16.MergeIndex = 0;
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.Size = new System.Drawing.Size(68, 36);
            this.toolStripButton16.Text = "删除";
            this.toolStripButton16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton16.Visible = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(-32768, 14);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(40, 40);
            this.pictureBox6.TabIndex = 6;
            this.pictureBox6.TabStop = false;
            // 
            // tabPageEx4
            // 
            this.tabPageEx4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageEx4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPageEx4.Controls.Add(this.skinButton_right);
            this.tabPageEx4.Controls.Add(this.skinButton_left);
            this.tabPageEx4.Controls.Add(this.skinTextBox_page);
            this.tabPageEx4.Controls.Add(this.skinLabel_recondTotal);
            this.tabPageEx4.Controls.Add(this.dateTimePicker_end);
            this.tabPageEx4.Controls.Add(this.linkLabel3);
            this.tabPageEx4.Controls.Add(this.dateTimePicker_begin);
            this.tabPageEx4.Controls.Add(this.skinPanel19);
            this.tabPageEx4.Controls.Add(this.skinToolStrip4);
            this.tabPageEx4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageEx4.ForeColor = System.Drawing.Color.White;
            this.tabPageEx4.ImageIndex = 21;
            this.tabPageEx4.Location = new System.Drawing.Point(0, 75);
            this.tabPageEx4.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageEx4.Name = "tabPageEx4";
            this.tabPageEx4.Size = new System.Drawing.Size(898, 499);
            this.tabPageEx4.TabIndex = 3;
            this.tabPageEx4.Text = "日志查询";
            // 
            // skinButton_right
            // 
            this.skinButton_right.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_right.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_right.DownBack = null;
            this.skinButton_right.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.skinButton_right.ForeColor = System.Drawing.Color.Black;
            this.skinButton_right.Location = new System.Drawing.Point(838, 471);
            this.skinButton_right.MouseBack = null;
            this.skinButton_right.Name = "skinButton_right";
            this.skinButton_right.NormlBack = null;
            this.skinButton_right.Size = new System.Drawing.Size(45, 23);
            this.skinButton_right.TabIndex = 191;
            this.skinButton_right.Text = ">>";
            this.skinButton_right.UseVisualStyleBackColor = false;
            this.skinButton_right.Click += new System.EventHandler(this.skinButton_right_Click);
            // 
            // skinButton_left
            // 
            this.skinButton_left.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_left.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_left.DownBack = null;
            this.skinButton_left.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.skinButton_left.ForeColor = System.Drawing.Color.Black;
            this.skinButton_left.Location = new System.Drawing.Point(724, 471);
            this.skinButton_left.MouseBack = null;
            this.skinButton_left.Name = "skinButton_left";
            this.skinButton_left.NormlBack = null;
            this.skinButton_left.Size = new System.Drawing.Size(45, 23);
            this.skinButton_left.TabIndex = 190;
            this.skinButton_left.Text = "<<";
            this.skinButton_left.UseVisualStyleBackColor = false;
            this.skinButton_left.Click += new System.EventHandler(this.skinButton_left_Click);
            // 
            // skinTextBox_page
            // 
            this.skinTextBox_page.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_page.DownBack = null;
            this.skinTextBox_page.Icon = null;
            this.skinTextBox_page.IconIsButton = false;
            this.skinTextBox_page.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_page.Location = new System.Drawing.Point(780, 469);
            this.skinTextBox_page.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_page.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_page.MouseBack = null;
            this.skinTextBox_page.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_page.Name = "skinTextBox_page";
            this.skinTextBox_page.NormlBack = null;
            this.skinTextBox_page.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_page.Size = new System.Drawing.Size(50, 28);
            // 
            // skinTextBox_page.BaseText
            // 
            this.skinTextBox_page.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_page.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_page.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_page.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_page.SkinTxt.Name = "BaseText";
            this.skinTextBox_page.SkinTxt.Size = new System.Drawing.Size(40, 18);
            this.skinTextBox_page.SkinTxt.TabIndex = 0;
            this.skinTextBox_page.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_page.SkinTxt.WaterText = "";
            this.skinTextBox_page.TabIndex = 189;
            // 
            // skinLabel_recondTotal
            // 
            this.skinLabel_recondTotal.AutoSize = true;
            this.skinLabel_recondTotal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinLabel_recondTotal.BorderColor = System.Drawing.Color.White;
            this.skinLabel_recondTotal.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_recondTotal.ForeColor = System.Drawing.Color.Black;
            this.skinLabel_recondTotal.Location = new System.Drawing.Point(506, 474);
            this.skinLabel_recondTotal.Name = "skinLabel_recondTotal";
            this.skinLabel_recondTotal.Size = new System.Drawing.Size(191, 17);
            this.skinLabel_recondTotal.TabIndex = 188;
            this.skinLabel_recondTotal.Text = "共 71 条记录，每页 30 条，共3页";
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(194, 9);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(156, 23);
            this.dateTimePicker_end.TabIndex = 186;
            // 
            // linkLabel3
            // 
            this.linkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel3.LinkColor = System.Drawing.Color.Gray;
            this.linkLabel3.Location = new System.Drawing.Point(168, 14);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(20, 17);
            this.linkLabel3.TabIndex = 185;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "到";
            this.linkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(148)))), ((int)(((byte)(229)))));
            // 
            // dateTimePicker_begin
            // 
            this.dateTimePicker_begin.Location = new System.Drawing.Point(6, 9);
            this.dateTimePicker_begin.Name = "dateTimePicker_begin";
            this.dateTimePicker_begin.Size = new System.Drawing.Size(156, 23);
            this.dateTimePicker_begin.TabIndex = 184;
            // 
            // skinPanel19
            // 
            this.skinPanel19.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel19.Controls.Add(this.skinPanel20);
            this.skinPanel19.Controls.Add(this.skinPanel23);
            this.skinPanel19.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel19.DownBack = null;
            this.skinPanel19.Location = new System.Drawing.Point(0, 38);
            this.skinPanel19.MouseBack = null;
            this.skinPanel19.Name = "skinPanel19";
            this.skinPanel19.NormlBack = null;
            this.skinPanel19.Size = new System.Drawing.Size(898, 427);
            this.skinPanel19.TabIndex = 183;
            // 
            // skinPanel20
            // 
            this.skinPanel20.BackColor = System.Drawing.Color.White;
            this.skinPanel20.Controls.Add(this.skinPanel21);
            this.skinPanel20.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel20.DownBack = null;
            this.skinPanel20.Location = new System.Drawing.Point(0, 39);
            this.skinPanel20.MouseBack = null;
            this.skinPanel20.Name = "skinPanel20";
            this.skinPanel20.NormlBack = null;
            this.skinPanel20.Size = new System.Drawing.Size(898, 418);
            this.skinPanel20.TabIndex = 1;
            // 
            // skinPanel21
            // 
            this.skinPanel21.AutoScroll = true;
            this.skinPanel21.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinPanel21.Controls.Add(this.skinPanel22);
            this.skinPanel21.Controls.Add(this.skinDataGridView_userLog);
            this.skinPanel21.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel21.DownBack = null;
            this.skinPanel21.Location = new System.Drawing.Point(0, 0);
            this.skinPanel21.MouseBack = null;
            this.skinPanel21.Name = "skinPanel21";
            this.skinPanel21.NormlBack = null;
            this.skinPanel21.Size = new System.Drawing.Size(898, 418);
            this.skinPanel21.TabIndex = 7;
            // 
            // skinPanel22
            // 
            this.skinPanel22.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinPanel22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinPanel22.Controls.Add(this.treeView_logUserList);
            this.skinPanel22.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel22.DownBack = null;
            this.skinPanel22.Location = new System.Drawing.Point(0, 0);
            this.skinPanel22.MouseBack = null;
            this.skinPanel22.Name = "skinPanel22";
            this.skinPanel22.NormlBack = null;
            this.skinPanel22.Size = new System.Drawing.Size(162, 388);
            this.skinPanel22.TabIndex = 11;
            // 
            // treeView_logUserList
            // 
            this.treeView_logUserList.AllowDrop = true;
            this.treeView_logUserList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.treeView_logUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_logUserList.ImageIndex = 2;
            this.treeView_logUserList.ImageList = this.imageList1;
            this.treeView_logUserList.Location = new System.Drawing.Point(0, 0);
            this.treeView_logUserList.Name = "treeView_logUserList";
            treeNode5.ImageIndex = 5;
            treeNode5.Name = "tTestNode001";
            treeNode5.SelectedImageKey = "5471.gif";
            treeNode5.Text = "测试管理员";
            treeNode5.ToolTipText = "测试管理员";
            treeNode6.ImageIndex = 4;
            treeNode6.Name = "tTestNode002";
            treeNode6.SelectedImageKey = "1291DB96250-5E01.png";
            treeNode6.Text = "测试员工";
            treeNode6.ToolTipText = "测试员工";
            treeNode7.ImageIndex = 2;
            treeNode7.Name = "tRoot";
            treeNode7.NodeFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode7.SelectedImageKey = "49.png";
            treeNode7.Text = "系统用户";
            treeNode7.ToolTipText = "系统用户";
            this.treeView_logUserList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeView_logUserList.SelectedImageIndex = 2;
            this.treeView_logUserList.Size = new System.Drawing.Size(158, 384);
            this.treeView_logUserList.TabIndex = 1;
            this.treeView_logUserList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_logUserList_AfterSelect);
            // 
            // skinDataGridView_userLog
            // 
            this.skinDataGridView_userLog.AllowUserToAddRows = false;
            this.skinDataGridView_userLog.AllowUserToOrderColumns = true;
            this.skinDataGridView_userLog.AlternatingCellBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.skinDataGridView_userLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.skinDataGridView_userLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.skinDataGridView_userLog.BackgroundColor = System.Drawing.SystemColors.Window;
            this.skinDataGridView_userLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinDataGridView_userLog.ColumnFont = null;
            this.skinDataGridView_userLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.skinDataGridView_userLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.skinDataGridView_userLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.skinDataGridView_userLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LogID,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.Column1,
            this.dataGridViewTextBoxColumn8,
            this.Column2,
            this.DetailLink,
            this.ActionCode});
            this.skinDataGridView_userLog.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.skinDataGridView_userLog.DefaultCellStyle = dataGridViewCellStyle7;
            this.skinDataGridView_userLog.EnableHeadersVisualStyles = false;
            this.skinDataGridView_userLog.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinDataGridView_userLog.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.skinDataGridView_userLog.HeadFont = new System.Drawing.Font("微软雅黑", 9F);
            this.skinDataGridView_userLog.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView_userLog.Location = new System.Drawing.Point(159, 0);
            this.skinDataGridView_userLog.Margin = new System.Windows.Forms.Padding(10);
            this.skinDataGridView_userLog.MouseCellBackColor = System.Drawing.Color.White;
            this.skinDataGridView_userLog.MultiSelect = false;
            this.skinDataGridView_userLog.Name = "skinDataGridView_userLog";
            this.skinDataGridView_userLog.ReadOnly = true;
            this.skinDataGridView_userLog.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.skinDataGridView_userLog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView_userLog.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.skinDataGridView_userLog.RowTemplate.Height = 23;
            this.skinDataGridView_userLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.skinDataGridView_userLog.Size = new System.Drawing.Size(739, 388);
            this.skinDataGridView_userLog.SkinGridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.skinDataGridView_userLog.TabIndex = 10;
            this.skinDataGridView_userLog.TitleBack = null;
            this.skinDataGridView_userLog.TitleBackColorBegin = System.Drawing.Color.White;
            this.skinDataGridView_userLog.TitleBackColorEnd = System.Drawing.SystemColors.Control;
            this.skinDataGridView_userLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.skinDataGridView_userLog_CellContentClick);
            this.skinDataGridView_userLog.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.skinDataGridView_userLog_CellMouseClick);
            // 
            // LogID
            // 
            this.LogID.DataPropertyName = "ID";
            this.LogID.HeaderText = "LogID";
            this.LogID.Name = "LogID";
            this.LogID.ReadOnly = true;
            this.LogID.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "AddTime";
            this.dataGridViewTextBoxColumn5.HeaderText = "操作时间";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ActionName";
            this.dataGridViewTextBoxColumn6.HeaderText = "操作类型";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "UserRealName";
            this.dataGridViewTextBoxColumn7.HeaderText = "操作人";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Ip";
            this.Column1.HeaderText = "操作电脑";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ProjectName";
            this.dataGridViewTextBoxColumn8.HeaderText = "工程名称";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ClientPath";
            this.Column2.HeaderText = "操作客户端地址";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 140;
            // 
            // DetailLink
            // 
            this.DetailLink.DataPropertyName = "DetailLink";
            this.DetailLink.HeaderText = "详细";
            this.DetailLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DetailLink.Name = "DetailLink";
            this.DetailLink.ReadOnly = true;
            this.DetailLink.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DetailLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DetailLink.Text = "";
            this.DetailLink.Width = 80;
            // 
            // ActionCode
            // 
            this.ActionCode.DataPropertyName = "ActionCode";
            this.ActionCode.HeaderText = "ActionCode";
            this.ActionCode.Name = "ActionCode";
            this.ActionCode.ReadOnly = true;
            this.ActionCode.Visible = false;
            // 
            // skinPanel23
            // 
            this.skinPanel23.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel23.Controls.Add(this.log_skinTextBox_FileName);
            this.skinPanel23.Controls.Add(this.skinLabel5);
            this.skinPanel23.Controls.Add(this.skinComboBox_IpAddress);
            this.skinPanel23.Controls.Add(this.skinLabel3);
            this.skinPanel23.Controls.Add(this.skinComboBox_operateType);
            this.skinPanel23.Controls.Add(this.skinLabel1);
            this.skinPanel23.Controls.Add(this.skinButton_search);
            this.skinPanel23.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel23.DownBack = null;
            this.skinPanel23.Location = new System.Drawing.Point(0, -4);
            this.skinPanel23.MouseBack = null;
            this.skinPanel23.Name = "skinPanel23";
            this.skinPanel23.NormlBack = null;
            this.skinPanel23.Size = new System.Drawing.Size(898, 45);
            this.skinPanel23.TabIndex = 0;
            // 
            // log_skinTextBox_FileName
            // 
            this.log_skinTextBox_FileName.BackColor = System.Drawing.Color.Transparent;
            this.log_skinTextBox_FileName.DownBack = null;
            this.log_skinTextBox_FileName.Icon = null;
            this.log_skinTextBox_FileName.IconIsButton = false;
            this.log_skinTextBox_FileName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.log_skinTextBox_FileName.Location = new System.Drawing.Point(522, 6);
            this.log_skinTextBox_FileName.Margin = new System.Windows.Forms.Padding(0);
            this.log_skinTextBox_FileName.MinimumSize = new System.Drawing.Size(28, 28);
            this.log_skinTextBox_FileName.MouseBack = null;
            this.log_skinTextBox_FileName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.log_skinTextBox_FileName.Name = "log_skinTextBox_FileName";
            this.log_skinTextBox_FileName.NormlBack = null;
            this.log_skinTextBox_FileName.Padding = new System.Windows.Forms.Padding(5);
            this.log_skinTextBox_FileName.Size = new System.Drawing.Size(122, 28);
            // 
            // log_skinTextBox_FileName.BaseText
            // 
            this.log_skinTextBox_FileName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.log_skinTextBox_FileName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log_skinTextBox_FileName.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.log_skinTextBox_FileName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.log_skinTextBox_FileName.SkinTxt.Name = "BaseText";
            this.log_skinTextBox_FileName.SkinTxt.Size = new System.Drawing.Size(112, 18);
            this.log_skinTextBox_FileName.SkinTxt.TabIndex = 0;
            this.log_skinTextBox_FileName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.log_skinTextBox_FileName.SkinTxt.WaterText = "";
            this.log_skinTextBox_FileName.TabIndex = 189;
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.skinLabel5.Location = new System.Drawing.Point(457, 13);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(56, 17);
            this.skinLabel5.TabIndex = 188;
            this.skinLabel5.Text = "文件名称";
            // 
            // skinComboBox_IpAddress
            // 
            this.skinComboBox_IpAddress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_IpAddress.FormattingEnabled = true;
            this.skinComboBox_IpAddress.Location = new System.Drawing.Point(293, 9);
            this.skinComboBox_IpAddress.Name = "skinComboBox_IpAddress";
            this.skinComboBox_IpAddress.Size = new System.Drawing.Size(131, 24);
            this.skinComboBox_IpAddress.TabIndex = 3;
            this.skinComboBox_IpAddress.WaterText = "";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.skinLabel3.Location = new System.Drawing.Point(237, 12);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(43, 17);
            this.skinLabel3.TabIndex = 2;
            this.skinLabel3.Text = "IP地址";
            // 
            // skinComboBox_operateType
            // 
            this.skinComboBox_operateType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_operateType.FormattingEnabled = true;
            this.skinComboBox_operateType.Items.AddRange(new object[] {
            "全部",
            "一键上传",
            "一键下载",
            "修改名称",
            "删除目录",
            "删除文件",
            "多个文件下载",
            "多个文件删除",
            "用户登录",
            "打开软件CHEM"});
            this.skinComboBox_operateType.Location = new System.Drawing.Point(76, 9);
            this.skinComboBox_operateType.Name = "skinComboBox_operateType";
            this.skinComboBox_operateType.Size = new System.Drawing.Size(131, 24);
            this.skinComboBox_operateType.TabIndex = 1;
            this.skinComboBox_operateType.WaterText = "";
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.skinLabel1.Location = new System.Drawing.Point(9, 12);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(56, 17);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "操作类型";
            // 
            // skinButton_search
            // 
            this.skinButton_search.BackColor = System.Drawing.Color.Black;
            this.skinButton_search.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_search.DownBack = null;
            this.skinButton_search.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.skinButton_search.ForeColor = System.Drawing.Color.Teal;
            this.skinButton_search.Location = new System.Drawing.Point(658, 9);
            this.skinButton_search.MouseBack = null;
            this.skinButton_search.Name = "skinButton_search";
            this.skinButton_search.NormlBack = null;
            this.skinButton_search.Size = new System.Drawing.Size(75, 23);
            this.skinButton_search.TabIndex = 187;
            this.skinButton_search.Text = "查询";
            this.skinButton_search.UseVisualStyleBackColor = false;
            this.skinButton_search.Click += new System.EventHandler(this.skinButton_search_Click);
            // 
            // skinToolStrip4
            // 
            this.skinToolStrip4.Arrow = System.Drawing.Color.White;
            this.skinToolStrip4.AutoSize = false;
            this.skinToolStrip4.Back = System.Drawing.Color.Transparent;
            this.skinToolStrip4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinToolStrip4.BackRadius = 4;
            this.skinToolStrip4.BackRectangle = new System.Drawing.Rectangle(5, 5, 5, 5);
            this.skinToolStrip4.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip4.BaseFore = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.skinToolStrip4.BaseForeAnamorphosis = false;
            this.skinToolStrip4.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip4.BaseForeAnamorphosisColor = System.Drawing.Color.Black;
            this.skinToolStrip4.BaseForeOffset = new System.Drawing.Point(3, 6);
            this.skinToolStrip4.BaseHoverFore = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.skinToolStrip4.BaseItemAnamorphosis = false;
            this.skinToolStrip4.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.skinToolStrip4.BaseItemBorderShow = false;
            this.skinToolStrip4.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip4.BaseItemDown")));
            this.skinToolStrip4.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skinToolStrip4.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip4.BaseItemMouse")));
            this.skinToolStrip4.BaseItemNorml = null;
            this.skinToolStrip4.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip4.BaseItemRadius = 2;
            this.skinToolStrip4.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip4.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skinToolStrip4.BindTabControl = null;
            this.skinToolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.skinToolStrip4.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip4.Fore = System.Drawing.Color.Black;
            this.skinToolStrip4.GripMargin = new System.Windows.Forms.Padding(0);
            this.skinToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip4.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip4.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.skinToolStrip4.ItemAnamorphosis = false;
            this.skinToolStrip4.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip4.ItemBorderShow = false;
            this.skinToolStrip4.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip4.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip4.ItemRadius = 1;
            this.skinToolStrip4.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_delSingle,
            this.toolStripButton_delMuli,
            this.toolStripButton17});
            this.skinToolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.skinToolStrip4.Location = new System.Drawing.Point(653, 1);
            this.skinToolStrip4.Name = "skinToolStrip4";
            this.skinToolStrip4.Padding = new System.Windows.Forms.Padding(0);
            this.skinToolStrip4.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip4.Size = new System.Drawing.Size(233, 35);
            this.skinToolStrip4.SkinAllColor = true;
            this.skinToolStrip4.TabIndex = 182;
            this.skinToolStrip4.Text = "今天";
            this.skinToolStrip4.TitleAnamorphosis = false;
            this.skinToolStrip4.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip4.TitleRadius = 4;
            this.skinToolStrip4.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip4.Visible = false;
            // 
            // toolStripButton_delSingle
            // 
            this.toolStripButton_delSingle.AutoSize = false;
            this.toolStripButton_delSingle.AutoToolTip = false;
            this.toolStripButton_delSingle.ForeColor = System.Drawing.Color.White;
            this.toolStripButton_delSingle.Image = global::FileManager.Properties.Resources.icon_dellog;
            this.toolStripButton_delSingle.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton_delSingle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_delSingle.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton_delSingle.MergeIndex = 0;
            this.toolStripButton_delSingle.Name = "toolStripButton_delSingle";
            this.toolStripButton_delSingle.Size = new System.Drawing.Size(92, 36);
            this.toolStripButton_delSingle.Text = "删除日志";
            this.toolStripButton_delSingle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton_delSingle.Click += new System.EventHandler(this.toolStripButton_delSingle_Click);
            // 
            // toolStripButton_delMuli
            // 
            this.toolStripButton_delMuli.AutoToolTip = false;
            this.toolStripButton_delMuli.ForeColor = System.Drawing.Color.White;
            this.toolStripButton_delMuli.Image = global::FileManager.Properties.Resources.icon_delweeklog;
            this.toolStripButton_delMuli.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_delMuli.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton_delMuli.MergeIndex = 0;
            this.toolStripButton_delMuli.Name = "toolStripButton_delMuli";
            this.toolStripButton_delMuli.Size = new System.Drawing.Size(123, 36);
            this.toolStripButton_delMuli.Text = "删除7天前日志";
            this.toolStripButton_delMuli.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton_delMuli.Click += new System.EventHandler(this.toolStripButton_delMuli_Click);
            // 
            // toolStripButton17
            // 
            this.toolStripButton17.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton17.ForeColor = System.Drawing.Color.White;
            this.toolStripButton17.Image = global::FileManager.Properties.Resources.Group1;
            this.toolStripButton17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton17.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton17.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton17.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton17.MergeIndex = 0;
            this.toolStripButton17.Name = "toolStripButton17";
            this.toolStripButton17.Size = new System.Drawing.Size(92, 36);
            this.toolStripButton17.Text = "添加用户";
            this.toolStripButton17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton17.ToolTipText = "一键上传";
            this.toolStripButton17.Visible = false;
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
            this.ToolStripMenuItem_AddUser,
            this.ToolStripMenuItem_EditUser,
            this.ToolStripMenuItem_AuthUser,
            this.ToolStripMenuItem_DelUser});
            this.skinContextMenuStrip1.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip1.Name = "skinContextMenuStrip1";
            this.skinContextMenuStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            this.skinContextMenuStrip1.SkinAllColor = true;
            this.skinContextMenuStrip1.TitleAnamorphosis = true;
            this.skinContextMenuStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinContextMenuStrip1.TitleRadius = 4;
            this.skinContextMenuStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // ToolStripMenuItem_AddUser
            // 
            this.ToolStripMenuItem_AddUser.Name = "ToolStripMenuItem_AddUser";
            this.ToolStripMenuItem_AddUser.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_AddUser.Text = "添加用户";
            this.ToolStripMenuItem_AddUser.Click += new System.EventHandler(this.ToolStripMenuItem_AddUser_Click);
            // 
            // ToolStripMenuItem_EditUser
            // 
            this.ToolStripMenuItem_EditUser.Name = "ToolStripMenuItem_EditUser";
            this.ToolStripMenuItem_EditUser.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_EditUser.Text = "编辑用户";
            this.ToolStripMenuItem_EditUser.Click += new System.EventHandler(this.ToolStripMenuItem_EditUser_Click);
            // 
            // ToolStripMenuItem_AuthUser
            // 
            this.ToolStripMenuItem_AuthUser.Name = "ToolStripMenuItem_AuthUser";
            this.ToolStripMenuItem_AuthUser.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_AuthUser.Text = "用户授权";
            this.ToolStripMenuItem_AuthUser.Click += new System.EventHandler(this.ToolStripMenuItem_AuthUser_Click);
            // 
            // ToolStripMenuItem_DelUser
            // 
            this.ToolStripMenuItem_DelUser.Name = "ToolStripMenuItem_DelUser";
            this.ToolStripMenuItem_DelUser.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_DelUser.Text = "删除用户";
            this.ToolStripMenuItem_DelUser.Click += new System.EventHandler(this.ToolStripMenuItem_DelUser_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(148)))), ((int)(((byte)(229)))));
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.Red;
            this.linkLabel2.Location = new System.Drawing.Point(726, 4);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(32, 17);
            this.linkLabel2.TabIndex = 179;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "注销";
            this.linkLabel2.Visible = false;
            this.linkLabel2.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(148)))), ((int)(((byte)(229)))));
            // 
            // sl_userName
            // 
            this.sl_userName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.sl_userName.AutoSize = true;
            this.sl_userName.BackColor = System.Drawing.Color.Transparent;
            this.sl_userName.BorderColor = System.Drawing.Color.White;
            this.sl_userName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.sl_userName.ForeColor = System.Drawing.Color.White;
            this.sl_userName.Location = new System.Drawing.Point(613, 3);
            this.sl_userName.Name = "sl_userName";
            this.sl_userName.Size = new System.Drawing.Size(56, 17);
            this.sl_userName.TabIndex = 180;
            this.sl_userName.Text = "欢迎您：";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.skinContextMenuStrip_State;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "文件管理客户端";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // skinContextMenuStrip_State
            // 
            this.skinContextMenuStrip_State.Arrow = System.Drawing.Color.Black;
            this.skinContextMenuStrip_State.Back = System.Drawing.Color.White;
            this.skinContextMenuStrip_State.BackRadius = 4;
            this.skinContextMenuStrip_State.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.skinContextMenuStrip_State.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStrip_State.Fore = System.Drawing.Color.Black;
            this.skinContextMenuStrip_State.HoverFore = System.Drawing.Color.White;
            this.skinContextMenuStrip_State.ItemAnamorphosis = false;
            this.skinContextMenuStrip_State.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_State.ItemBorderShow = false;
            this.skinContextMenuStrip_State.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_State.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_State.ItemRadius = 4;
            this.skinContextMenuStrip_State.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinContextMenuStrip_State.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_userInfo,
            this.toolStrip_dominSetting,
            this.toolStrip_autoSaveSetting,
            this.toolStrip_cancellation,
            this.toolStrip_systemSetting,
            this.toolStrip_exit});
            this.skinContextMenuStrip_State.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStrip_State.Name = "MenuState";
            this.skinContextMenuStrip_State.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_State.Size = new System.Drawing.Size(149, 136);
            this.skinContextMenuStrip_State.SkinAllColor = true;
            this.skinContextMenuStrip_State.TitleAnamorphosis = false;
            this.skinContextMenuStrip_State.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinContextMenuStrip_State.TitleRadius = 4;
            this.skinContextMenuStrip_State.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStrip_userInfo
            // 
            this.toolStrip_userInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStrip_userInfo.Name = "toolStrip_userInfo";
            this.toolStrip_userInfo.Size = new System.Drawing.Size(148, 22);
            this.toolStrip_userInfo.Tag = "2";
            this.toolStrip_userInfo.Text = "个人资料";
            this.toolStrip_userInfo.ToolTipText = "个人资料";
            this.toolStrip_userInfo.Click += new System.EventHandler(this.toolStrip_userInfo_Click);
            // 
            // toolStrip_dominSetting
            // 
            this.toolStrip_dominSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStrip_dominSetting.Name = "toolStrip_dominSetting";
            this.toolStrip_dominSetting.Size = new System.Drawing.Size(148, 22);
            this.toolStrip_dominSetting.Tag = "2";
            this.toolStrip_dominSetting.Text = "域名地址设置";
            this.toolStrip_dominSetting.ToolTipText = "域名地址设置";
            this.toolStrip_dominSetting.Click += new System.EventHandler(this.toolStrip_dominSetting_Click);
            // 
            // toolStrip_autoSaveSetting
            // 
            this.toolStrip_autoSaveSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStrip_autoSaveSetting.Name = "toolStrip_autoSaveSetting";
            this.toolStrip_autoSaveSetting.Size = new System.Drawing.Size(148, 22);
            this.toolStrip_autoSaveSetting.Tag = "2";
            this.toolStrip_autoSaveSetting.Text = "自动备份设置";
            this.toolStrip_autoSaveSetting.ToolTipText = "自动备份设置";
            this.toolStrip_autoSaveSetting.Click += new System.EventHandler(this.toolStrip_autoSaveSetting_Click);
            // 
            // toolStrip_cancellation
            // 
            this.toolStrip_cancellation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStrip_cancellation.Name = "toolStrip_cancellation";
            this.toolStrip_cancellation.Size = new System.Drawing.Size(148, 22);
            this.toolStrip_cancellation.Tag = "3";
            this.toolStrip_cancellation.Text = "注销";
            this.toolStrip_cancellation.ToolTipText = "注销账号，退出到登录界面";
            this.toolStrip_cancellation.Visible = false;
            this.toolStrip_cancellation.Click += new System.EventHandler(this.toolStrip_cancellation_Click);
            // 
            // toolStrip_systemSetting
            // 
            this.toolStrip_systemSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStrip_systemSetting.Name = "toolStrip_systemSetting";
            this.toolStrip_systemSetting.Size = new System.Drawing.Size(148, 22);
            this.toolStrip_systemSetting.Tag = "4";
            this.toolStrip_systemSetting.Text = "系统设置";
            this.toolStrip_systemSetting.ToolTipText = "系统设置";
            this.toolStrip_systemSetting.Click += new System.EventHandler(this.toolStrip_systemSetting_Click);
            // 
            // toolStrip_exit
            // 
            this.toolStrip_exit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStrip_exit.Name = "toolStrip_exit";
            this.toolStrip_exit.Size = new System.Drawing.Size(148, 22);
            this.toolStrip_exit.Tag = "5";
            this.toolStrip_exit.Text = "退出";
            this.toolStrip_exit.ToolTipText = "退出";
            this.toolStrip_exit.Click += new System.EventHandler(this.toolStrip_exit_Click);
            // 
            // skinContextMenuStrip_log
            // 
            this.skinContextMenuStrip_log.Arrow = System.Drawing.Color.Black;
            this.skinContextMenuStrip_log.Back = System.Drawing.Color.White;
            this.skinContextMenuStrip_log.BackRadius = 4;
            this.skinContextMenuStrip_log.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.skinContextMenuStrip_log.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStrip_log.Fore = System.Drawing.Color.Black;
            this.skinContextMenuStrip_log.HoverFore = System.Drawing.Color.White;
            this.skinContextMenuStrip_log.ItemAnamorphosis = true;
            this.skinContextMenuStrip_log.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_log.ItemBorderShow = true;
            this.skinContextMenuStrip_log.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_log.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_log.ItemRadius = 4;
            this.skinContextMenuStrip_log.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_log.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_delSingle});
            this.skinContextMenuStrip_log.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_log.Name = "skinContextMenuStrip_log";
            this.skinContextMenuStrip_log.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_log.Size = new System.Drawing.Size(125, 26);
            this.skinContextMenuStrip_log.SkinAllColor = true;
            this.skinContextMenuStrip_log.TitleAnamorphosis = true;
            this.skinContextMenuStrip_log.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinContextMenuStrip_log.TitleRadius = 4;
            this.skinContextMenuStrip_log.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripMenuItem_delSingle
            // 
            this.toolStripMenuItem_delSingle.Name = "toolStripMenuItem_delSingle";
            this.toolStripMenuItem_delSingle.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_delSingle.Text = "删除日志";
            this.toolStripMenuItem_delSingle.Visible = false;
            this.toolStripMenuItem_delSingle.Click += new System.EventHandler(this.toolStripMenuItem_delSingle_Click);
            // 
            // skinLabel4
            // 
            this.skinLabel4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Relievo;
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.skinLabel4.Location = new System.Drawing.Point(731, 40);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(151, 20);
            this.skinLabel4.TabIndex = 182;
            this.skinLabel4.Text = "LinkAll 实验备份系统";
            // 
            // timer_autoUpload
            // 
            this.timer_autoUpload.Enabled = true;
            this.timer_autoUpload.Interval = 43200000;
            this.timer_autoUpload.Tick += new System.EventHandler(this.timer_autoUpload_Tick);
            // 
            // skinLabel6
            // 
            this.skinLabel6.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.ForeColor = System.Drawing.Color.White;
            this.skinLabel6.Location = new System.Drawing.Point(723, 72);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(187, 17);
            this.skinLabel6.TabIndex = 183;
            this.skinLabel6.Text = "联系热线：897195703@qq.com";
            // 
            // skinToolStrip5
            // 
            this.skinToolStrip5.Arrow = System.Drawing.Color.White;
            this.skinToolStrip5.AutoSize = false;
            this.skinToolStrip5.Back = System.Drawing.Color.Transparent;
            this.skinToolStrip5.BackColor = System.Drawing.Color.Transparent;
            this.skinToolStrip5.BackRadius = 4;
            this.skinToolStrip5.BackRectangle = new System.Drawing.Rectangle(5, 5, 5, 5);
            this.skinToolStrip5.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip5.BaseFore = System.Drawing.Color.LightGray;
            this.skinToolStrip5.BaseForeAnamorphosis = false;
            this.skinToolStrip5.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip5.BaseForeAnamorphosisColor = System.Drawing.Color.Black;
            this.skinToolStrip5.BaseForeOffset = new System.Drawing.Point(3, 6);
            this.skinToolStrip5.BaseHoverFore = System.Drawing.Color.White;
            this.skinToolStrip5.BaseItemAnamorphosis = false;
            this.skinToolStrip5.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.skinToolStrip5.BaseItemBorderShow = false;
            this.skinToolStrip5.BaseItemDown = null;
            this.skinToolStrip5.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skinToolStrip5.BaseItemMouse = null;
            this.skinToolStrip5.BaseItemNorml = null;
            this.skinToolStrip5.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip5.BaseItemRadius = 2;
            this.skinToolStrip5.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip5.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skinToolStrip5.BindTabControl = null;
            this.skinToolStrip5.Dock = System.Windows.Forms.DockStyle.None;
            this.skinToolStrip5.DropDownImageSeparator = System.Drawing.Color.Transparent;
            this.skinToolStrip5.Fore = System.Drawing.Color.Transparent;
            this.skinToolStrip5.GripMargin = new System.Windows.Forms.Padding(0);
            this.skinToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip5.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip5.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.skinToolStrip5.ItemAnamorphosis = false;
            this.skinToolStrip5.ItemBorder = System.Drawing.Color.Silver;
            this.skinToolStrip5.ItemBorderShow = false;
            this.skinToolStrip5.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip5.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip5.ItemRadius = 1;
            this.skinToolStrip5.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.skinToolStrip5.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.skinToolStrip5.Location = new System.Drawing.Point(272, 61);
            this.skinToolStrip5.Name = "skinToolStrip5";
            this.skinToolStrip5.Padding = new System.Windows.Forms.Padding(0);
            this.skinToolStrip5.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip5.Size = new System.Drawing.Size(222, 37);
            this.skinToolStrip5.SkinAllColor = true;
            this.skinToolStrip5.TabIndex = 184;
            this.skinToolStrip5.Text = "今天";
            this.skinToolStrip5.TitleAnamorphosis = false;
            this.skinToolStrip5.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.skinToolStrip5.TitleRadius = 4;
            this.skinToolStrip5.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = global::FileManager.Properties.Resources.icon_history;
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Indigo;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton1.MergeIndex = 0;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(129, 36);
            this.toolStripButton1.Text = "点击开启软件";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolStripButton1.ToolTipText = "开启软件";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.BackShade = false;
            this.CanResize = false;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionHeight = 22;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.CloseBoxSize = new System.Drawing.Size(27, 22);
            this.CloseDownBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseDownBack")));
            this.CloseMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseMouseBack")));
            this.CloseNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseNormlBack")));
            this.Controls.Add(this.skinToolStrip5);
            this.Controls.Add(this.skinLabel6);
            this.Controls.Add(this.skinLabel4);
            this.Controls.Add(this.sl_userName);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.skinTabControl1);
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
            this.Name = "FrmMain";
            this.Radius = 1;
            this.RestoreDownBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreDownBack")));
            this.RestoreMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreMouseBack")));
            this.RestoreNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.RestoreNormlBack")));
            this.RoundStyle = CCWin.SkinClass.RoundStyle.None;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            cmSysButton1.Bounds = new System.Drawing.Rectangle(813, 0, 27, 22);
            cmSysButton1.BoxState = CCWin.ControlBoxState.Normal;
            cmSysButton1.Location = new System.Drawing.Point(813, 0);
            cmSysButton1.Name = "SysTool";
            cmSysButton1.OwnerForm = this;
            cmSysButton1.Size = new System.Drawing.Size(27, 22);
            cmSysButton1.SysButtonDown = ((System.Drawing.Image)(resources.GetObject("cmSysButton1.SysButtonDown")));
            cmSysButton1.SysButtonMouse = ((System.Drawing.Image)(resources.GetObject("cmSysButton1.SysButtonMouse")));
            cmSysButton1.SysButtonNorml = ((System.Drawing.Image)(resources.GetObject("cmSysButton1.SysButtonNorml")));
            cmSysButton1.ToolTip = "主菜单";
            cmSysButton2.Bounds = new System.Drawing.Rectangle(786, 0, 27, 22);
            cmSysButton2.BoxState = CCWin.ControlBoxState.Normal;
            cmSysButton2.Location = new System.Drawing.Point(786, 0);
            cmSysButton2.Name = "SysMsg";
            cmSysButton2.OwnerForm = this;
            cmSysButton2.Size = new System.Drawing.Size(27, 22);
            cmSysButton2.SysButtonDown = ((System.Drawing.Image)(resources.GetObject("cmSysButton2.SysButtonDown")));
            cmSysButton2.SysButtonMouse = ((System.Drawing.Image)(resources.GetObject("cmSysButton2.SysButtonMouse")));
            cmSysButton2.SysButtonNorml = ((System.Drawing.Image)(resources.GetObject("cmSysButton2.SysButtonNorml")));
            cmSysButton2.ToolTip = "反馈意见";
            cmSysButton2.Visibale = false;
            cmSysButton3.Bounds = new System.Drawing.Rectangle(813, 0, 27, 22);
            cmSysButton3.BoxState = CCWin.ControlBoxState.Normal;
            cmSysButton3.Location = new System.Drawing.Point(813, 0);
            cmSysButton3.Name = "SysSkin";
            cmSysButton3.OwnerForm = this;
            cmSysButton3.Size = new System.Drawing.Size(27, 22);
            cmSysButton3.SysButtonDown = ((System.Drawing.Image)(resources.GetObject("cmSysButton3.SysButtonDown")));
            cmSysButton3.SysButtonMouse = ((System.Drawing.Image)(resources.GetObject("cmSysButton3.SysButtonMouse")));
            cmSysButton3.SysButtonNorml = ((System.Drawing.Image)(resources.GetObject("cmSysButton3.SysButtonNorml")));
            cmSysButton3.ToolTip = "换肤";
            cmSysButton3.Visibale = false;
            this.SysButtonItems.AddRange(new CCWin.CmSysButton[] {
            cmSysButton1,
            cmSysButton2,
            cmSysButton3});
            this.Text = "登录时间：2015-07-26 21:00:12 ";
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(13, 4);
            this.SysBottomClick += new CCWin.CCSkinMain.SysBottomEventHandler(this.FrmMain_SysBottomClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.skinTabControl1.ResumeLayout(false);
            this.tabPageEx1.ResumeLayout(false);
            this.tabPageEx1.PerformLayout();
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel4.ResumeLayout(false);
            this.skinPanel6.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.skinPanel5.ResumeLayout(false);
            this.skinPanel2.ResumeLayout(false);
            this.skinPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox3)).EndInit();
            this.skinToolStrip2.ResumeLayout(false);
            this.skinToolStrip2.PerformLayout();
            this.tabPageEx3.ResumeLayout(false);
            this.skinPanel13.ResumeLayout(false);
            this.skinPanel14.ResumeLayout(false);
            this.skinPanel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView_userList)).EndInit();
            this.skinPanel17.ResumeLayout(false);
            this.skinToolStrip3.ResumeLayout(false);
            this.skinToolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.tabPageEx4.ResumeLayout(false);
            this.tabPageEx4.PerformLayout();
            this.skinTextBox_page.ResumeLayout(false);
            this.skinTextBox_page.PerformLayout();
            this.skinPanel19.ResumeLayout(false);
            this.skinPanel20.ResumeLayout(false);
            this.skinPanel21.ResumeLayout(false);
            this.skinPanel22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView_userLog)).EndInit();
            this.skinPanel23.ResumeLayout(false);
            this.skinPanel23.PerformLayout();
            this.log_skinTextBox_FileName.ResumeLayout(false);
            this.log_skinTextBox_FileName.PerformLayout();
            this.skinToolStrip4.ResumeLayout(false);
            this.skinToolStrip4.PerformLayout();
            this.skinContextMenuStrip1.ResumeLayout(false);
            this.skinContextMenuStrip_State.ResumeLayout(false);
            this.skinContextMenuStrip_log.ResumeLayout(false);
            this.skinToolStrip5.ResumeLayout(false);
            this.skinToolStrip5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private CCWin.SkinControl.SkinTabControl skinTabControl1;
        private CCWin.SkinControl.SkinTabPage tabPageEx1;
        private CCWin.SkinControl.SkinButton skinButton12;
        private CCWin.SkinControl.SkinLabel skinLabel8;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox3;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_oneClickUpload;
        private System.Windows.Forms.ToolStripButton toolStripButton_oneClickDownload;
        private System.Windows.Forms.ToolStripButton toolStripButton_rename;
        private System.Windows.Forms.ToolStripButton toolStripButton_properryView;
        private System.Windows.Forms.ToolStripButton toolStripButton_history;
        private CCWin.SkinControl.SkinLabel skinLabel19;
        private CCWin.SkinControl.SkinTabPage tabPageEx3;
        private System.Windows.Forms.PictureBox pictureBox6;
        private CCWin.SkinControl.SkinTabPage tabPageEx4;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinPanel skinPanel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton_parent;
        private System.Windows.Forms.ToolStripButton toolStripButton_root;
        private System.Windows.Forms.ToolStripButton toolStripButton_refresh;
        private CCWin.SkinControl.SkinPanel skinPanel4;
        private CCWin.SkinControl.SkinPanel skinPanel6;
        private CCWin.SkinControl.SkinPanel skinPanel5;
        private CCWin.SkinControl.SkinPanel skinPanel3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_OpenClient;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_View;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_LargeIco;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SmallIco;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ListView;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DetailView;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_EidtProperty;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Del;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ViewProperty;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_searchContent;
        private System.Windows.Forms.ToolStripButton toolStripButton_searchFile;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.LinkLabel linkLabel_fileAndForderNum;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private CCWin.SkinControl.SkinPanel skinPanel13;
        private CCWin.SkinControl.SkinPanel skinPanel14;
        private CCWin.SkinControl.SkinPanel skinPanel15;
        private System.Windows.Forms.Splitter splitter3;
        private CCWin.SkinControl.SkinPanel skinPanel17;
        private CCWin.SkinControl.SkinPanel skinPanel18;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton_addUser;
        private System.Windows.Forms.ToolStripButton toolStripButton_editUser;
        private System.Windows.Forms.ToolStripButton toolStripButton_authUser;
        private System.Windows.Forms.ToolStripButton toolStripButton_delUser;
        private System.Windows.Forms.ToolStripButton toolStripButton16;
        private CCWin.SkinControl.SkinDataGridView skinDataGridView_userList;
        private CCWin.SkinControl.SkinPanel skinPanel16;
        private System.Windows.Forms.DateTimePicker dateTimePicker_begin;
        private CCWin.SkinControl.SkinPanel skinPanel19;
        private CCWin.SkinControl.SkinPanel skinPanel20;
        private CCWin.SkinControl.SkinPanel skinPanel21;
        private CCWin.SkinControl.SkinPanel skinPanel22;
        private CCWin.SkinControl.SkinDataGridView skinDataGridView_userLog;
        private CCWin.SkinControl.SkinPanel skinPanel23;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButton17;
        private System.Windows.Forms.ToolStripButton toolStripButton_delMuli;
        private System.Windows.Forms.ToolStripButton toolStripButton_delSingle;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private CCWin.SkinControl.SkinLabel sl_userName;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private CCWin.SkinControl.SkinButton skinButton_search;
        private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_AddUser;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_EditUser;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DelUser;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStrip_State;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_userInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_cancellation;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_systemSetting;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_exit;
        private CCWin.SkinControl.SkinButton skinButton_right;
        private CCWin.SkinControl.SkinButton skinButton_left;
        private CCWin.SkinControl.SkinTextBox skinTextBox_page;
        private CCWin.SkinControl.SkinLabel skinLabel_recondTotal;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinComboBox skinComboBox_project;
        private System.Windows.Forms.ToolStripButton toolStripButton_del;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Rename;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_History;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_AuthUser;
        private System.Windows.Forms.TreeView treeView_logUserList;
        private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStrip_log;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_delSingle;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_openClientForder;
        private CCWin.SkinControl.SkinComboBox skinComboBox_IpAddress;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinComboBox skinComboBox_operateType;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.TreeView treeView_project;
        private System.Windows.Forms.ImageList imageList4;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_OpenServerFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DownFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_historyLog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsHaveAuth;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CCWin.SkinControl.SkinTextBox log_skinTextBox_FileName;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timer_autoUpload;
        private System.Windows.Forms.LinkLabel linkLabel_UploadMsg;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_autoSaveSetting;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip5;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_dominSetting;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewLinkColumn DetailLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionCode;

    }
}

