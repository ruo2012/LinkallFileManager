using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using FileManager.BLL;
using System.Runtime.Remoting.Messaging;
using FileManager.Model;

namespace FileManager
{
    public partial class FrmMain : CCSkinMain
    {
        private FrmTipUpload _frmTipUpload;
        public FrmTipUpload FrmTipUpload
        {
            get
            {
                //if (_frmTipUpload == null)
                //{
                //    _frmTipUpload = new FrmTipUpload();
                //}
                return _frmTipUpload;
            }
            set { _frmTipUpload = value; }
        }

        public System.EventHandler ShowTipUpload;

        #region MainForm_Shown
        private void MainForm_Shown(object sender, EventArgs e)
        {
            FrmTipUpload frm = new FrmTipUpload(sender as string);
            frm.ShowDialog();
        }

        #endregion

        public FrmMain()
        {
            InitializeComponent();
            ShowTipUpload += MainForm_Shown;
            #region 测试数据填充
            //DataTable dt = new DataTable();
            //dt.Columns.Add("file_type");
            //dt.Columns.Add("file_name");
            //dt.Columns.Add("file_size");
            //dt.Columns.Add("state");

            //for (int i = 0; i < 10; i++)
            //{
            //    DataRow row = dt.NewRow();
            //    row[0] = "文件";
            //    row[1] = "文件";
            //    row[2] = "10M";
            //    row[3] = "传输中";
            //    dt.Rows.Add(row);
            //}

            //this.skinDataGridView_userList.DataSource = dt;
            //this.skinDataGridView1.DataSource = dt;
            #endregion

            this.Text = string.Format("登录时间：{0} ", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        }

        #region 初始化

        /// <summary>
        /// 初始化自动更新
        /// </summary>
        public void InitAutoUpdate()
        {
            try
            {
                this.timer_autoUpload.Stop();

                //string configTimeValue = System.Configuration.ConfigurationSettings.AppSettings["AutoUpdateTime"];
                var config = BLL.SystemConfigBll.GetConfig();
                if (config == null || config.AutoUpdateInterval <= 0)
                {
                    this.timer_autoUpload.Interval = 1000 * 60 * 720;
                }
                else
                {
                    int autoUpdateInterval = config.AutoUpdateInterval;
                    if (autoUpdateInterval >= 1)
                    {
                        this.timer_autoUpload.Interval = 1000 * 60 * autoUpdateInterval;
                    }
                }
                this.timer_autoUpload.Start();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 根据权限初始化界面
        /// </summary>
        private void InitUiByAuth()
        {
            //tabPageEx2.Parent = null;
            string userRoleName = string.Empty;
            int userAuth = Bll.SystemBll.GetUserAuth(ref userRoleName);
            //普通用户只有文件管理和文件审计两个界面
            if (userAuth == 0)
            {
                if (this.skinTabControl1.TabPages.Count >= 2)
                {
                    tabPageEx3.Parent = null;
                    tabPageEx4.Parent = null;
                    skinToolStrip5.Location = new Point(skinToolStrip5.Location.X - 150, skinToolStrip5.Location.Y);

                    // 20160427 普通用户删除按钮全部不显示
                    this.toolStripButton_del.Visible = false;
                    this.ToolStripMenuItem_Del.Visible = false;
                }
            }
            else
            {
                tabPageEx3.Parent = this.skinTabControl1;
                tabPageEx4.Parent = this.skinTabControl1;
            }

            //角色名称展示
            if (!string.IsNullOrEmpty(userRoleName))
            {
                this.sl_userName.Text = string.Format("欢迎您：{0}|{1}", Bll.SystemBll.UserInfo.RealName, Bll.SystemBll.UserInfo.RoleName);
            }
            else
            {
                this.sl_userName.Text = string.Format("欢迎您：{0}", Bll.SystemBll.UserInfo.RealName);
            }

            if (Bll.SystemBll.ServerConfigInfo != null && Bll.SystemBll.ServerConfigInfo.SystemLoginType == 0)
            {
                this.toolStrip_cancellation.Visible = true;
            }
        }

        /// <summary>
        /// 普通用户禁止删除按钮
        /// </summary>
        private void InitUserDelAuth()
        {
            string userRoleName = string.Empty;
            int userAuth = Bll.SystemBll.GetUserAuth(ref userRoleName);

            //普通用户只有文件管理和文件审计两个界面
            if (userAuth == 0)
            {
                // 20160427 普通用户删除按钮全部不显示
                this.toolStripButton_del.Visible = false;
                this.ToolStripMenuItem_Del.Visible = false;
            }
            else
            {
                this.toolStripButton_del.Visible = true;
                this.ToolStripMenuItem_Del.Visible = true;
            }
        }

        /// <summary>
        /// 初始化用户信息
        /// </summary>
        private void InitUserTree()
        {
            this.treeView1.Visible = true;
            this.treeView1.BeginUpdate();

            TreeNode rootNode = this.treeView1.Nodes[0];
            rootNode.Nodes.Clear();
            ///普通用户只加载自己
            if (Bll.SystemBll.UserInfo.RoleType == 0)
            {
                TreeNode nodeItem = new TreeNode();
                nodeItem.SelectedImageIndex = 4;
                nodeItem.ImageIndex = 4;
                nodeItem.Tag = Bll.SystemBll.UserInfo;
                nodeItem.Text = Bll.SystemBll.UserInfo.RealName;
                nodeItem.ToolTipText = Bll.SystemBll.UserInfo.RealName;
                rootNode.Nodes.Add(nodeItem);

                rootNode.ExpandAll();
                this.treeView1.EndUpdate();
                return;
            }

            //获取所有用户
            BLL.ManagerBll mBll = new BLL.ManagerBll();
            List<Model.UserModel> users = mBll.GetModelList(1000, " isLock = 0 ", " RoleType desc ");

            if (users != null && users.Count > 0)
            {
                foreach (var item in users)
                {
                    TreeNode nodeItem = new TreeNode();
                    if (item.RoleType > 0)
                    {
                        nodeItem.SelectedImageIndex = 5;
                        nodeItem.ImageIndex = 5;
                    }
                    else
                    {
                        nodeItem.SelectedImageIndex = 4;
                        nodeItem.ImageIndex = 4;
                    }
                    nodeItem.Tag = item;
                    nodeItem.Text = item.RealName;
                    nodeItem.ToolTipText = item.RealName;
                    rootNode.Nodes.Add(nodeItem);
                }
            }

            rootNode.ExpandAll();
            this.treeView1.EndUpdate();
        }

        /// <summary>
        /// 初始化文件管理系统
        /// </summary>
        private void InitRootFiles(int forderId, int projectId)
        {
            //清除已经存在的文件
            this.listView1.Items.Clear();

            //开始更新  
            this.listView1.BeginUpdate();

            //开始从文件夹获取子文件夹和文件列表
            ForderBll forderBll = new ForderBll();
            var subForders = forderBll.GetSubForders(forderId, projectId);
            var subFiles = forderBll.GetSubFiles(forderId, projectId, string.Empty);
            ChangeLayout(subForders, subFiles);

            //初始化路径
            InitCurrentPath(forderId);

            // 图标添加
            FileWinexploer fWinexploer = new FileWinexploer();
            this.imageList2 = fWinexploer.GetImageCollectionByDb(forderId, this.imageList2);
            this.imageList3 = fWinexploer.GetImageCollectionByDb(forderId, this.imageList3);

            //左下文件数量提示
            this.linkLabel_fileAndForderNum.Text = string.Format("共有{0}文件夹/{1}文件", subForders.Count, subFiles.Count);

            //添加文件夹
            foreach (var forderItem in subForders)
            {
                ListViewItem item = new ListViewItem(forderItem.Title, 2);
                item.Name = forderItem.Title;
                // 添加文件夹标签
                item.Tag = forderItem;
                item.ImageKey = "folder1.ico";
                item.SubItems.Add("");
                item.SubItems.Add("文件夹");
                item.SubItems.Add(new DateTime(forderItem.Forder_Modify_Time).ToString("yyyy/MM/dd HH:mm"));
                listView1.Items.Add(item);
            }

            //循环添加文件
            foreach (var file in subFiles)
            {
                ListViewItem item = new ListViewItem(file.File_Name);
                item.Text = file.File_Name;
                item.Tag = file;
                item.ImageKey = file.File_Ext;

                //文件夹大小转换
                double len = file.File_Size;
                if (len >= 1024 * 1024)
                {
                    len = Math.Round((len / 1024.0 / 1024), 2);
                    item.SubItems.Add(len + "MB");
                }
                else
                {
                    len = Math.Round((len / 1024.0), 2);
                    item.SubItems.Add(len + "KB");
                }
                //文件大小
                this.listView1.Items.Add(item);

                //文件类型
                item.SubItems.Add("文件");

                //item.SubItems.Add(file.File_Ext);
                //文件时间
                item.SubItems.Add(new DateTime(file.File_Modify_Time).ToString("yyyy/MM/dd HH:mm"));
            }

            this.listView1.EndUpdate();
        }

        private void ChangeLayout(List<Model.ForderModel> subForders, List<Model.FileModel> subFils)
        {
            if (subForders != null && subForders.Count > 0)
            {
                var findValue = subForders.FindAll(x => ForderSpecialControl.IsSpecialForder(x.Title));
                if (findValue != null && findValue.Count > 0)
                {
                    foreach (var item in findValue)
                    {
                        foreach (var file in subFils)
                        {
                            string fileName = item.Title + ".ztlj";
                            if (file.File_Name == fileName)
                            {
                                file.File_Name = item.Title;
                            }
                        }
                        subForders.Remove(item);
                    }
                }
            }
        }

        private void ChangeLayout(List<Model.ForderModel> subForders)
        {
            if (subForders != null && subForders.Count > 0)
            {
                var findValue = subForders.FindAll(x => ForderSpecialControl.IsSpecialForder(x.Title));
                if (findValue != null && findValue.Count > 0)
                {
                    foreach (var item in findValue)
                    {
                        subForders.Remove(item);
                    }
                }
            }
        }

        private List<FileManager.Model.ForderModel> currentForders;

        private string currentTmpPath = ""; //当前路径

        /// <summary>
        /// 路径变化
        /// </summary>
        private void InitCurrentPath(int forderId)
        {
            ForderBll bll = new ForderBll();
            currentForders = bll.GetForderPath(forderId);
            if (currentForders != null && currentForders.Count > 0)
            {
                string path = string.Empty;
                foreach (var item in currentForders)
                {
                    if (string.IsNullOrEmpty(path))
                    {
                        path += "主目录\\" + item.Title;
                    }
                    else
                    {
                        path += "\\" + item.Title;
                    }
                }
                try
                {
                    this.toolStripTextBox1.Text = path;
                    this.toolStripTextBox1.ReadOnly = true;
                    currentTmpPath = path;
                }
                catch (Exception ex) 
                {

                }
            }
            else
            {
                currentTmpPath = "主目录";
            }
            this.toolStripTextBox1.Text = currentTmpPath;
        }

        /// <summary>
        /// 初始化工程信息
        /// </summary>
        /// <param name="userName"></param>
        private void InitProject(string userName)
        {
            this.skinComboBox_project.Items.Clear();
            Model.UserModel user = new BLL.ManagerBll().GetModel(userName);

            if (user == null) return;
            var projects = user.Projects;
            if (projects != null && projects.Count > 0)
            {
                foreach (var item in projects)
                {
                    this.skinComboBox_project.Items.Add(new ListItem(item.ProjectName, item));
                }
            }

            if (this.skinComboBox_project.Items.Count > 0)
            {
                this.skinComboBox_project.SelectedIndex = 0;

                ListItem item = (ListItem)this.skinComboBox_project.SelectedItem;
                this.selectProjectId = ((Model.UserProjectModel)item.Value).ID;
            }
            else
            {
                this.selectProjectId = 0;
            }
        }

        /// <summary>
        /// 初始化树形结构
        /// </summary>
        /// <param name="forderId"></param>
        private void InitProjectTree()
        {
            this.treeView_project.Visible = true;
            this.treeView_project.BeginUpdate();

            this.treeView_project.Nodes.Clear();

            //TreeNode rootNode = this.treeView_project.Nodes[0];
            //rootNode.Nodes.Clear();

            //开始从文件夹获取子文件夹和文件列表
            ForderBll forderBll = new ForderBll();
            var subForders = forderBll.GetSubForders(0, this.selectProjectId);
            ChangeLayout(subForders);
            foreach (var d in subForders)
            {
                TreeNode nodeItem = new TreeNode();
                nodeItem.SelectedImageIndex = 4;
                nodeItem.ImageIndex = 4;
                nodeItem.Tag = d.ID;
                nodeItem.Text = d.Title;
                nodeItem.ToolTipText = d.Title;
                nodeItem.Expand();
                this.treeView_project.Nodes.Add(nodeItem);
            }

            //if (subForders != null && subForders.Count > 0)
            //{
            //    var d = subForders[0];
            //    TreeNode nodeItem = new TreeNode();
            //    rootNode.SelectedImageIndex = 4;
            //    rootNode.ImageIndex = 4;
            //    rootNode.Tag = d.ID;
            //    rootNode.Text = d.Title;
            //    rootNode.ToolTipText = d.Title;
            //    //rootNode = nodeItem;
            //}
            //else
            //{
            //    rootNode.SelectedImageIndex = 4;
            //    rootNode.ImageIndex = 4;
            //    ListItem selectItem = (ListItem)this.skinComboBox_project.SelectedItem;
            //    if (string.IsNullOrEmpty(selectItem.Text))
            //    {
            //        ThrowExption("选择的项目为空!");
            //    }
            //    rootNode.Text = ((Model.UserProjectModel)selectItem.Value).ProjectName;
            //    rootNode.ToolTipText = rootNode.Text;
            //}

            foreach (TreeNode node in this.treeView_project.Nodes)
            {
                InitProjectTreeItem(node, 2);
            }
            // InitProjectTreeItem(rootNode);

            //rootNode.Expand();
            this.treeView_project.EndUpdate();
        }

        /// <summary>
        /// 更新当前节点
        /// </summary>
        /// <param name="node"></param>
        private void InitProjectTreeItem(TreeNode node, int level)
        {
            try
            {
                int nodeId = 0;
                string idStr = node.Tag == null ? string.Empty : node.Tag.ToString();
                if (int.TryParse(idStr, out nodeId))
                {
                    node.Nodes.Clear();
                    // 获取子目录

                    //开始从文件夹获取子文件夹和文件列表
                    ForderBll forderBll = new ForderBll();
                    var subForders = forderBll.GetSubForders(nodeId, this.selectProjectId);
                    if (subForders == null || subForders.Count == 0) return;
                    ChangeLayout(subForders);

                    foreach (var d in subForders)
                    {
                        TreeNode nodeItem = new TreeNode();
                        nodeItem.SelectedImageIndex = 4;
                        nodeItem.ImageIndex = 4;
                        nodeItem.Tag = d.ID;
                        nodeItem.Text = d.Title;
                        nodeItem.ToolTipText = d.Title;
                        node.Nodes.Add(nodeItem);

                        if (level > 0)
                        {
                            InitProjectTreeItem(nodeItem, --level);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 工程目录点击树形结构
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_project_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();
            //Model.ForderModel dir = listView1.SelectedItems[0].Tag as Model.ForderModel;

            int nodeId = 0;
            string idStr = e.Node.Tag == null ? string.Empty : e.Node.Tag.ToString();
            if (int.TryParse(idStr, out nodeId))
            {
                listView1.Items.Clear();
                InitRootFiles(nodeId, selectProjectId);
            }
        }

        /// <summary>
        /// 工程目录结构初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_project_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            InitProjectTreeItem(e.Node, 3); //更新当前结点
            foreach (TreeNode node in e.Node.Nodes) //更新所有子结点
            {
                InitProjectTreeItem(node, 2);
            }
        }

        #endregion

        #region 页面属性
        private string selectUserName;
        private string selectProjectName;
        private int selectProjectId;

        #endregion

        #region 用户管理相关

        /// <summary>
        /// 用户双击行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinDataGridView_userList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    EditUser();
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show(ex.Message);
                }
            }
        }

        private void AddUser()
        {
            FrmUserEdit frm = new FrmUserEdit(0, 0);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InitUserListDataGridView();

                //初始化用户管理界面
                InitManagerUserPage();

                // 初始化所选用户的目录树结构
                InitProjectTree();

                //日志操作相关
                InitLogUI();

                InitUserTree();
            }
        }

        private void EditUser()
        {
            var rows = this.skinDataGridView_userList.SelectedRows;
            if (rows == null || rows.Count == 0) return;
            DataGridViewRow row = rows[0];
            int userid = int.Parse(row.Cells[0].Value.ToString());
            string userName = row.Cells[1].Value.ToString();
            if (userid > 0)
            {
                FrmUserEdit frm = new FrmUserEdit(userid, 1);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitUserListDataGridView();
                }

                if (Bll.SystemBll.UserInfo.UserName == userName)
                {
                    InitProject(userName);
                    InitRootFiles(0, selectProjectId);
                }
            }
        }

        private void AuthUser()
        {
            var rows = this.skinDataGridView_userList.SelectedRows;
            if (rows == null || rows.Count == 0) return;
            DataGridViewRow row = rows[0];
            int userid = int.Parse(row.Cells[0].Value.ToString());
            string userName = row.Cells[1].Value.ToString();
            string realName = row.Cells[2].Value.ToString();
            int isLock = row.Cells[4].Value.ToString() == "有" ? 0 : 1; ;
            if (userid > 0)
            {
                FrmUserAuth frm = new FrmUserAuth(userid, userName, realName, isLock);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitUserListDataGridView();
                }
            }
        }

        private void DelUser()
        {
            if (MessageBox.Show(
                "确定删除这个账号,如果删除该账号不可恢复！",
                "删除账号",
                 MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var rows = this.skinDataGridView_userList.SelectedRows;
                if (rows == null || rows.Count == 0) return;
                DataGridViewRow row = rows[0];
                int userid = int.Parse(row.Cells[0].Value.ToString());
                if (userid > 0)
                {
                    BLL.ManagerBll managerBll = new ManagerBll();
                    if (managerBll.Delete(userid))
                    {
                        InitUserListDataGridView();


                        //初始化用户管理界面
                        InitManagerUserPage();

                        // 初始化所选用户的目录树结构
                        InitProjectTree();

                        //日志操作相关
                        InitLogUI();
                    }
                }
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_addUser_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_editUser_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        /// <summary>
        /// 用户授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_authUser_Click(object sender, EventArgs e)
        {
            AuthUser();
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_delUser_Click(object sender, EventArgs e)
        {
            DelUser();
        }

        private void ToolStripMenuItem_AddUser_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void ToolStripMenuItem_EditUser_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void ToolStripMenuItem_AuthUser_Click(object sender, EventArgs e)
        {
            AuthUser();
        }

        private void ToolStripMenuItem_DelUser_Click(object sender, EventArgs e)
        {
            DelUser();
        }

        /// <summary>
        /// 样式修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinDataGridView_userList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.skinDataGridView_userList.Rows)
            {
                if (string.IsNullOrEmpty(row.Cells[4].Value.ToString()) || row.Cells[4].Value.ToString() == "无")
                {
                    row.Cells[4].Style.BackColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// 右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinDataGridView_userList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        //若行已是选中状态就不再进行设置
            //        if (this.skinDataGridView_userList.Rows[e.RowIndex].Selected == false)
            //        {
            //            this.skinDataGridView_userList.ClearSelection();
            //            this.skinDataGridView_userList.Rows[e.RowIndex].Selected = true;
            //        }
            //        //只选中一行时设置活动单元格
            //        if (this.skinDataGridView_userList.SelectedRows.Count == 1)
            //        {
            //            this.skinDataGridView_userList.CurrentCell = this.skinDataGridView_userList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //        }
            //        //弹出操作菜单
            //        this.skinContextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            //    }
            //}
        }

        /// <summary>
        /// 初始化用户管理界面
        /// </summary>
        private void InitManagerUserPage()
        {
            string userRoleName = string.Empty;
            int userAuth = Bll.SystemBll.GetUserAuth(ref userRoleName);
            //如果是管理员，初始化用户管理界面
            if (userAuth > 0)
            {
                InitUserListDataGridView();
            }
        }

        /// <summary>
        /// 初始化用户管理数据
        /// </summary>
        private void InitUserListDataGridView()
        {
            BLL.ManagerBll managerBll = new ManagerBll();
            DataSet ds = managerBll.GetList(1000, " id > 0 ", " AddTime desc, id asc");
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable orgdt = ds.Tables[0];
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("userName");
                dt.Columns.Add("userRealName");
                dt.Columns.Add("userRoleName");
                dt.Columns.Add("IsHaveAuth");
                dt.Columns.Add("userLastIp");
                dt.Columns.Add("userLastClientPath");

                if (orgdt != null && orgdt.Rows.Count > 0)
                {
                    for (int i = 0; i < orgdt.Rows.Count; i++)
                    {
                        DataRow row = dt.NewRow();
                        row[0] = orgdt.Rows[i]["id"].ToString();
                        row[1] = orgdt.Rows[i]["userName"].ToString();
                        row[2] = orgdt.Rows[i]["RealName"].ToString();
                        row[3] = orgdt.Rows[i]["RoleName"].ToString();
                        row[4] = orgdt.Rows[i]["IsLock"].ToString() == "0" ? "有" : "无";
                        var lastActionLog = Bll.SystemBll.GetUserLastLog(orgdt.Rows[i]["userName"].ToString());
                        row[5] = lastActionLog.Ip;
                        row[6] = lastActionLog.ProjectPath;
                        dt.Rows.Add(row);
                    }
                }
                this.skinDataGridView_userList.DataSource = dt;
            }


        }
        #endregion

        #region 日志操作相关

        /// <summary>
        /// 初始化日志相关界面
        /// </summary>
        private void InitLogUI()
        {
            this.dateTimePicker_end.Value = DateTime.Now.Date.AddHours(23.99);
            this.dateTimePicker_begin.Value = DateTime.Now.AddDays(-7);

            InitLogUserTree();
            InitIp();

            this.skinComboBox_operateType.SelectedIndex = 0;
            this.skinDataGridView_userLog.AutoGenerateColumns = false;
            SearchLog();
        }

        /// <summary>
        /// IP初始化
        /// </summary>
        private void InitIp()
        {
            BLL.UserLogBll logBll = new UserLogBll();
            List<string> ips = logBll.GetLogIps(1000, string.Empty, "id desc");
            this.skinComboBox_IpAddress.Items.Clear();
            this.skinComboBox_IpAddress.Items.Add("全部");
            foreach (var item in ips)
            {
                this.skinComboBox_IpAddress.Items.Add(item);
            }
            this.skinComboBox_IpAddress.SelectedIndex = 0;
        }

        /// <summary>
        /// 刷新日志
        /// </summary>
        private void SearchLog()
        {
            string strWhere = GetStrWhere();
            InitUserLogView(strWhere);
        }

        private void DelLog()
        {
            if (MessageBox.Show(
                "确定删除这条日志,如果删除该条日志不可恢复！",
                "删除日志",
                 MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var rows = this.skinDataGridView_userLog.SelectedRows;
                if (rows == null || rows.Count == 0) return;

                foreach (DataGridViewRow item in rows)
                {
                    DataGridViewRow row = item;
                    int id = int.Parse(row.Cells[0].Value.ToString());
                    if (id > 0)
                    {
                        BLL.UserLogBll userLogBll = new UserLogBll();
                        if (userLogBll.Delete(id))
                        {
                        }
                    }
                }
                RefreshLogView(GetStrWhere(), this.page, this.pageSize);
            }
        }

        /// <summary>
        /// 条件拼接
        /// </summary>
        /// <returns></returns>
        private string GetStrWhere()
        {
            string strWhere = string.Empty;
            string timeWhere = string.Format(" addtime >= '{0}' and addtime <= '{1}'  ", this.dateTimePicker_begin.Value, this.dateTimePicker_end.Value);
            string userWhere = string.Empty;

            if (this.treeView_logUserList.SelectedNode != null)
            {
                UserModel user = (UserModel)this.treeView_logUserList.SelectedNode.Tag;
                if (user != null)
                {
                    userWhere += string.Format(" and UserName='{0}'", user.UserName);
                }
            }

            if (this.skinComboBox_IpAddress.SelectedIndex > 0)
            {
                string ip = this.skinComboBox_IpAddress.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(ip))
                {
                    userWhere += string.Format(" and Ip like '%{0}%'", ip);
                }
            }

            if (this.skinComboBox_operateType.SelectedIndex > 0)
            {
                string opType = this.skinComboBox_operateType.SelectedItem.ToString();
                string opName = Bll.SystemBll.GetActionName(opType);
                if (!string.IsNullOrEmpty(opName))
                {
                    userWhere += string.Format(" and ActionType like '%{0}%'", opName);
                }
            }

            string fileNameKey = this.log_skinTextBox_FileName.SkinTxt.Text;
            if (!string.IsNullOrEmpty(fileNameKey) && fileNameKey.Trim() != "")
            {
                userWhere += string.Format(" and ClientPath like '%{0}%'", fileNameKey);
            }

            return timeWhere + userWhere;
        }

        /// <summary>
        /// 初始化用户信息
        /// </summary>
        private void InitLogUserTree()
        {
            this.treeView1.Visible = true;
            this.treeView_logUserList.BeginUpdate();
            TreeNode rootNode = this.treeView_logUserList.Nodes[0];
            rootNode.Nodes.Clear();
            ///普通用户只加载自己
            if (Bll.SystemBll.UserInfo.RoleType == 0)
            {
                TreeNode nodeItem = new TreeNode();
                nodeItem.SelectedImageIndex = 4;
                nodeItem.ImageIndex = 4;
                nodeItem.Tag = Bll.SystemBll.UserInfo;
                nodeItem.Text = Bll.SystemBll.UserInfo.RealName;
                nodeItem.ToolTipText = Bll.SystemBll.UserInfo.RealName;
                rootNode.Nodes.Add(nodeItem);

                rootNode.ExpandAll();
                this.treeView_logUserList.EndUpdate();
                return;
            }

            //获取所有用户
            BLL.ManagerBll mBll = new BLL.ManagerBll();
            List<Model.UserModel> users = mBll.GetModelList(1000, " isLock = 0 ", " RoleType desc ");

            if (users != null && users.Count > 0)
            {
                foreach (var item in users)
                {
                    TreeNode nodeItem = new TreeNode();
                    if (item.RoleType > 0)
                    {
                        nodeItem.SelectedImageIndex = 5;
                        nodeItem.ImageIndex = 5;
                    }
                    else
                    {
                        nodeItem.SelectedImageIndex = 4;
                        nodeItem.ImageIndex = 4;
                    }
                    nodeItem.Tag = item;
                    nodeItem.Text = item.RealName;
                    nodeItem.ToolTipText = item.RealName;
                    rootNode.Nodes.Add(nodeItem);
                }
            }
            rootNode.ExpandAll();
            this.treeView_logUserList.EndUpdate();
        }

        protected int totalCount;
        protected int page;
        protected int pageSize = 20;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="strWhere"></param>
        private void InitUserLogView(string strWhere)
        {
            BLL.UserLogBll userLogBLl = new UserLogBll();
            int totalCount = 0;

            this.page = 1;
            DataSet ds = userLogBLl.GetList(this.pageSize, this.page, strWhere, " addtime desc,id desc", out totalCount);
            this.totalCount = totalCount;

            //计算页数
            int pageCount = totalCount / this.pageSize;
            if (totalCount % this.pageSize > 0) pageCount += 1;

            this.skinTextBox_page.SkinTxt.Text = "1";
            this.skinLabel_recondTotal.Text = string.Format("共 {0} 条记录，每页 {1} 条，共{2}页", totalCount, pageSize, pageCount);
            this.skinDataGridView_userLog.DataSource = UserLogChange(ds.Tables[0]);
        }

        /// <summary>
        /// 根据条件刷新日志
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        private void RefreshLogView(string strWhere, int pageNum, int pageSize)
        {
            BLL.UserLogBll userLogBLl = new UserLogBll();
            int totalCount = 0;
            DataSet ds = userLogBLl.GetList(this.pageSize, this.page, strWhere, " addtime desc,id desc", out totalCount);
            this.skinDataGridView_userLog.DataSource = UserLogChange(ds.Tables[0]);
        }

        /// <summary>
        /// datatable 日志转化
        /// </summary>
        /// <param name="orgdt"></param>
        /// <returns></returns>
        private DataTable UserLogChange(DataTable orgdt)
        {
            if (orgdt == null || orgdt.Rows.Count == 0) return new DataTable();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("AddTime");
            dt.Columns.Add("ActionName");
            dt.Columns.Add("UserRealName");
            dt.Columns.Add("Ip");
            dt.Columns.Add("ProjectName");
            dt.Columns.Add("ClientPath");
            dt.Columns.Add("DetailLink");
            dt.Columns.Add("ActionCode");

            if (orgdt != null && orgdt.Rows.Count > 0)
            {
                for (int i = 0; i < orgdt.Rows.Count; i++)
                {
                    DataRow row = dt.NewRow();
                    row[0] = orgdt.Rows[i]["ID"].ToString();
                    row[1] = orgdt.Rows[i]["AddTime"].ToString();
                    row[2] = orgdt.Rows[i]["ActionName"].ToString();
                    row[3] = orgdt.Rows[i]["UserRealName"].ToString();
                    row[4] = orgdt.Rows[i]["Ip"].ToString();
                    row[5] = orgdt.Rows[i]["ProjectName"].ToString();
                    row[6] = orgdt.Rows[i]["ClientPath"].ToString();
                    string actionCode = orgdt.Rows[i]["ActionCode"].ToString();
                    if (string.IsNullOrEmpty(actionCode))
                    {
                        row[7] = string.Empty;
                    }
                    else
                    {
                        row[7] = "查看详细";
                    }
                    row[8] = orgdt.Rows[i]["ActionCode"].ToString();

                    dt.Rows.Add(row);
                }
            }

            return dt;
        }

        private void skinButton_search_Click(object sender, EventArgs e)
        {
            SearchLog();
        }

        private void toolStripButton_delSingle_Click(object sender, EventArgs e)
        {
            DelLog();
        }

        private void toolStripButton_delMuli_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
               "确定删除这个账号,如果删除该账号不可恢复！",
               "删除账号",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                BLL.UserLogBll userLogBll = new UserLogBll();
                if (userLogBll.DeleteByDay(7) > 0)
                {
                    RefreshLogView(GetStrWhere(), this.page, this.pageSize);
                }
            }
        }

        private void treeView_logUserList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();
            SearchLog();
        }

        private void skinButton_left_Click(object sender, EventArgs e)
        {
            int newPage = this.page - 1;
            if (newPage <= 0) return;
            string strWhere = GetStrWhere();
            this.page = newPage;
            this.skinTextBox_page.SkinTxt.Text = newPage.ToString();

            RefreshLogView(strWhere, newPage, this.pageSize);
        }

        private void skinButton_right_Click(object sender, EventArgs e)
        {
            int newPage = this.page + 1;
            if (newPage * pageSize - totalCount > pageSize)
            {
                return;
            }
            string strWhere = GetStrWhere();
            this.page = newPage;
            this.skinTextBox_page.SkinTxt.Text = newPage.ToString();

            RefreshLogView(strWhere, newPage, this.pageSize);
        }

        private void toolStripMenuItem_delSingle_Click(object sender, EventArgs e)
        {
            DelLog();
        }

        /// <summary>
        /// 日志右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinDataGridView_userLog_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (this.skinDataGridView_userLog.Rows[e.RowIndex].Selected == false)
                    {
                        this.skinDataGridView_userLog.ClearSelection();
                        this.skinDataGridView_userLog.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (this.skinDataGridView_userLog.SelectedRows.Count == 1)
                    {
                        this.skinDataGridView_userLog.CurrentCell = this.skinDataGridView_userLog.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    this.skinContextMenuStrip_log.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        /// <summary>
        /// 点击详细事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinDataGridView_userLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                try
                {
                    string actionCode = this.skinDataGridView_userLog.Rows[e.RowIndex].Cells[8].Value.ToString();
                    if (string.IsNullOrEmpty(actionCode))
                    {
                        return;
                    }

                    FileLogBll fileBll = new FileLogBll();
                    //Model.FileLogModel fileLogModel = fileBll.GetModel(actionCode);
                    int count = fileBll.GetCount("actionCode= '" + actionCode + "'");
                    if (count <= 0) return;
                    if (count <= 1)
                    {
                        Model.FileLogModel fileLogModel = fileBll.GetModel(actionCode);
                        if (fileLogModel == null || string.IsNullOrEmpty(fileLogModel.FileName))
                        {
                            MessageBoxEx.Show("该文件的信息异常！");
                            return;
                        }
                        if (fileLogModel.ActionType == ActionType.RENAMEFORDER.ToString())
                        {
                            FrmFileLogDetail frm = new FrmFileLogDetail(0, 1, fileLogModel);
                            frm.ShowDialog();
                        }
                        else
                        {
                            FrmFileSaveAs frm = new FrmFileSaveAs(0, 0, fileLogModel);
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        FrmFileMultiHistoryLog frm = new FrmFileMultiHistoryLog(actionCode);
                        frm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show(ex.Message);
                }
            }
        }
        #endregion

        #region 桌面事件

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                // 自动备份初始化
                InitAutoUpdate();

                //用户权限控制
                InitUiByAuth();

                //用户左侧数
                InitUserTree();

                //初始化项目
                InitProject(Bll.SystemBll.UserInfo.UserName);

                //初始化中间文件管理器
                InitRootFiles(0, selectProjectId);

                //初始化用户管理界面
                InitManagerUserPage();

                // 初始化所选用户的目录树结构
                InitProjectTree();

                //日志操作相关
                InitLogUI();


                System.Threading.Thread.Sleep(100);
                StartSoftWare(false);
            }
            catch (Exception ex)
            {
                ThrowExption(ex);
            }
        }

        /// <summary>
        /// 工程选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinComboBox_project_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem selectItem = (ListItem)this.skinComboBox_project.SelectedItem;
            if (string.IsNullOrEmpty(selectItem.Text))
            {
                ThrowExption("选择的项目为空!");
            }
            this.selectProjectId = ((Model.UserProjectModel)selectItem.Value).ID;

            InitRootFiles(0, this.selectProjectId);
            InitProjectTree();
        }

        /// <summary>
        /// 文件管理系统点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            //Open();
            if (this.listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            //看选中的是类型是什么
            string typeName = listView1.SelectedItems[0].SubItems[2].Text;
            if (typeName == "文件夹" || typeName == "本地磁盘")
            {
                Model.ForderModel dir = listView1.SelectedItems[0].Tag as Model.ForderModel;
                listView1.Items.Clear();
                InitRootFiles(dir.ID, selectProjectId);
            }
            else  //应用程序或者文件
            {
                //MessageBox.Show("文件暂时不能打开");
                OpenClient();
            }
        }

        /// <summary>
        /// 向上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_parent_Click(object sender, EventArgs e)
        {
            if (currentTmpPath == "" || currentForders == null || currentForders.Count == 0) return;

            if (currentForders.Count == 1)
            {
                currentForders = new List<Model.ForderModel>();
                InitRootFiles(0, selectProjectId);
            }
            else
            {
                currentForders.RemoveAt(currentForders.Count - 1);
                ChangeCurrentPath();
                InitRootFiles(currentForders[currentForders.Count - 1].ID, selectProjectId);
            }
        }

        /// <summary>
        /// 一键上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_oneClickUpload_Click(object sender, EventArgs e)
        {
            try
            {
                // 自动备份检查
                if (FileAutoUpload.AutoUpload == "UPLOADING")
                {
                    MessageBox.Show("正在自动备份中，请稍后再试！");
                    return;
                }

                //string dirPath = @"E:\C#WINFORM_2015\私单资料准备\FileManager_TestUpload";
                ListItem selectItem = (ListItem)this.skinComboBox_project.SelectedItem;
                Model.UserProjectModel curProject = (Model.UserProjectModel)selectItem.Value;
                if (curProject == null || string.IsNullOrEmpty(curProject.MonitoringPath))
                {
                    MessageBox.Show("服务器配置路径不正确，请联系管理员处理！");
                    return;
                }

                //监控绑定路径
                string dirPath = curProject.MonitoringPath;
                if (!Directory.Exists(dirPath))
                {
                    MessageBox.Show("服务器配置路径不正确，请联系管理员处理！");
                    return;
                }

                //此处查询出所有文件内容
                DirectoryInfo rootDirInfo = new DirectoryInfo(dirPath);
                FileWinexploer upload = new FileWinexploer();
                //Action<object> action = ( obj) => upload.FolderUploadToDb(dirPath, new FileManager.Model.UserModel());
                //action.BeginInvoke(dirPath, ar => action.EndInvoke(ar), null);

                //upload.FolderUploadToDb(dirPath, new FileManager.Model.UserModel());
                //InitRootFiles(0);

                //this.linkLabel1.Text = string.Format("正在传输的文件({0})", upload.GetAllFileNum(rootDirInfo));


                // 提示是否上传|取消|上传差异
                string tip = FileWinexploer.ConstructUploadTip();
                FrmMessageBox messageBox = new FrmMessageBox(tip, 0);
                var result = messageBox.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                //上传之前开启文件受影响检查
                Model.UserModel user = Bll.SystemBll.UserInfo;
                user.CurProject = curProject;
                //upload.CheckFolderUploadToDb(dirPath, user);

                // 替换检查界面[8.5wjh]
                FrmWait frmCheckFile = new FrmWait(dirPath, user, 0);

                //frmCheckFile.Show();
                //frmCheckFile.CheckFolderUploadToDb(dirPath, user);
                DialogResult frmCheckFileResult = frmCheckFile.ShowDialog();
                if (frmCheckFileResult != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                Common.LogHelper.WriteLog(string.Format("上传缓存：{0} \r\n", LitJson.JsonMapper.ToJson(FileWinexploer.NeedAddOrMordifyFiles)));

                if (FileWinexploer.NeedAddOrMordifyFiles == null || FileWinexploer.NeedAddOrMordifyFiles.Count == 0)
                {
                    //MessageBox.Show("没有可更新文件，不需要操作！");
                    MessageBox.Show("上传完成！");
                    return;
                }
                else
                {
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        FileWinexploer.SetUploadCache();
                    }

                    //动态上传进度
                    //FrmFileTransferNew frmTransfer = new FrmFileTransferNew(0);

                    // 0909 上传王君海修改
                    FrmFileProgressBar frmTransfer = new FrmFileProgressBar(0);

                    //if (MessageBox.Show(
                    // string.Format("此次上传文件数量为:{0},是否继续上传！", FileWinexploer.NeedAddOrMordifyFiles.Count),
                    //  "一键上传文件",
                    //   MessageBoxButtons.OKCancel) == DialogResult.OK)
                    //{
                    //开启自动刷新界面
                    timerToUpdateUi.Interval = 4000;
                    timerToUpdateUi.Tick += timerToUpdateUi_Tick;
                    timerToUpdateUi.Start();

                    //检查通过开始异步上传
                    FolderUploadHandler handler = new FolderUploadHandler(upload.FolderUploadToDb);
                    handler.BeginInvoke(dirPath, user, IAsyncMenthod, null);

                    ///异步日志
                    ActionLog(string.Empty, ActionType.ALLUPLOAD);

                    frmTransfer.Show();

                    System.Threading.Thread.Sleep(400);
                    Common.LogHelper.WriteLog(string.Format("时间：{0},记录日志：{1}\r\n", DateTime.Now.ToString(), "上传完毕成功！"));

                    // 上传完成需要刷新当前展示的文件结构
                    this.RefreshCurWin();

                    Common.LogHelper.WriteLog(string.Format("时间：{0},记录日志：{1}\r\n", DateTime.Now.ToString(), "主页刷新成功！"));
                    // 上传完成需要刷新目录树
                    InitProjectTree();
                    Common.LogHelper.WriteLog(string.Format("时间：{0},记录日志：{1}\r\n", DateTime.Now.ToString(), "刷新目录树成功！"));

                    // }
                }
            }
            catch (Exception ex)
            {
                Common.LogHelper.WriteLog(string.Format("时间：{0},记录错误日志：{1}\r\n", DateTime.Now.ToString(), ex.Message + "\r\n" + ex.StackTrace));
                ThrowExption(ex);
            }
        }


        #region 文件管理模块相关界面按钮事件

        /// <summary>
        /// 一键下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_oneClickDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.skinComboBox_project.SelectedItem == null)
                {
                    MessageBox.Show("没有查询到工程信息，请联系管理员处理！");
                    return;
                }

                //工程信息
                ListItem selectItem = (ListItem)this.skinComboBox_project.SelectedItem;

                Model.UserProjectModel curProject = (Model.UserProjectModel)selectItem.Value;
                if (curProject == null || string.IsNullOrEmpty(curProject.MonitoringPath))
                {
                    MessageBox.Show("用户工程配置路径不正确，请联系管理员处理！");
                    return;
                }

                //监控绑定路径
                string dirPath = curProject.MonitoringPath;
                if (!Directory.Exists(dirPath))
                {
                    //不存在则新建一个文件夹
                    Directory.CreateDirectory(dirPath);
                }

                // 下载之前提示
                string tip = FileWinexploer.ConstructDownLoadTip();
                FrmMessageBox messageBox = new FrmMessageBox(tip, 1);
                var result = messageBox.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                //此处查询出所有文件内容
                DirectoryInfo rootDirInfo = new DirectoryInfo(dirPath);
                FileWinexploer download = new FileWinexploer();

                //上传之前开启文件受影响检查
                Model.UserModel user = Bll.SystemBll.UserInfo;
                user.CurProject = curProject;
                //download.CheckFolderDownloadFromDb(rootDirInfo.Parent.FullName, user);

                // 替换检查界面[8.5wjh]
                FrmWait frmCheckFile = new FrmWait(rootDirInfo.Parent.FullName, user, 1);
                DialogResult frmCheckFileResult = frmCheckFile.ShowDialog();
                if (frmCheckFileResult != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                Common.LogHelper.WriteLog(string.Format("上传缓存：{0} \r\n", LitJson.JsonMapper.ToJson(FileWinexploer.NeedAddOrMordifyFiles)));
                if (FileWinexploer.NeedAddOrMordifyFiles == null || FileWinexploer.NeedAddOrMordifyFiles.Count == 0)
                {
                    //MessageBox.Show("服务器文件同本地文件无差异，不需要操作！");
                    MessageBox.Show("下载完成！");
                    return;
                }
                else
                {
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        FileWinexploer.SetDownLoadCache();
                    }

                    //if (MessageBox.Show(
                    // string.Format("此次下载差异文件数量为:{0},是否继续下载！", FileWinexploer.NeedAddOrMordifyFiles.Count),
                    //  "一键下载所有文件",
                    //   MessageBoxButtons.OKCancel) == DialogResult.OK)
                    //{
                    //开启自动刷新界面【下载不需要定时刷新界面】
                    //timerToUpdateUi.Interval = 1000;
                    //timerToUpdateUi.Tick += timerToUpdateUi_Tick;
                    //timerToUpdateUi.Start();

                    actionType = 1;
                    //检查通过开始异步上传
                    FolderDownloadHandler handler = new FolderDownloadHandler(download.FolderDownloadFromDb);
                    handler.BeginInvoke(rootDirInfo.Parent.FullName, user, IAsyncDownloadMenthod, null);

                    ///异步日志
                    ActionLog(string.Empty, ActionType.ALLDOWNLOAD);

                    //动态下载进度
                    //FrmFileTransferNew frmTransfer = new FrmFileTransferNew(1);

                    // 0909 上传王君海修改
                    FrmFileProgressBar frmTransfer = new FrmFileProgressBar(1);

                    frmTransfer.Show();
                    //}
                }
            }
            catch (Exception ex)
            {
                ThrowExption(ex);
            }
        }
        #endregion

        /// <summary>
        /// 根节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_root_Click(object sender, EventArgs e)
        {
            InitRootFiles(0, selectProjectId);
        }

        /// <summary>
        /// 刷新本地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_refresh_Click(object sender, EventArgs e)
        {
            if (currentForders != null && currentForders.Count > 0)
            {
                InitRootFiles(currentForders[currentForders.Count - 1].ID, selectProjectId);
            }
            else
            {
                InitRootFiles(0, selectProjectId);
            }
        }

        #endregion

        #region 公共方法
        /// <summary>
        /// 改变路径
        /// </summary>
        private void ChangeCurrentPath()
        {
            string path = string.Empty;
            if (currentForders != null && currentForders.Count > 0)
            {
                foreach (var item in currentForders)
                {
                    if (string.IsNullOrEmpty(path))
                    {
                        path += "主目录\\" + item.Title;
                    }
                    else
                    {
                        path += "\\" + item.Title;
                    }
                }
            }
            else
            {
                path += "主目录";
            }
            this.toolStripTextBox1.Text = path;
        }

        /// <summary>
        /// 动态更新UI timer
        /// </summary>
        private Timer timerToUpdateUi = new Timer();

        int i = 0;
        /// <summary>
        /// timer更新主界面UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerToUpdateUi_Tick(object sender, EventArgs e)
        {
            //this.linkLabel_fileAndForderNum.Text = "上传文件：" + i;
            this.linkLabel1.Text = string.Format("正在传输的文件({0})", FileWinexploer.GetLeftToActionNum());

            try
            {
                if (currentForders != null && currentForders.Count > 0)
                {

                    InitRootFiles(currentForders[currentForders.Count - 1].ID, selectProjectId);

                }
                else
                {
                    InitRootFiles(0, selectProjectId);
                }
            }
            catch (Exception ex)
            {
                FileManager.Common.LogHelper.WriteLog(ex.Message, ex);
            }
            i++;
        }

        /// <summary>
        /// 异步回调
        /// </summary>
        /// <param name="result"></param>
        void IAsyncMenthod(IAsyncResult result)
        {
            //AsyncResult 是IAsyncResult接口的一个实现类，引用空间：System.Runtime.Remoting.Messaging
            //AsyncDelegate 属性可以强制转换为用户定义的委托的实际类。
            FolderUploadHandler handler = (FolderUploadHandler)((AsyncResult)result).AsyncDelegate;
            //InitRootFiles(0);
            handler.EndInvoke(result);
            actionType = -1;
            timerToUpdateUi.Stop();

            SetText(string.Format("正在传输的文件({0})", FileWinexploer.GetLeftToActionNum()));
        }

        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetText(string text)
        {
            if (this.linkLabel1.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
            {
                while (!this.linkLabel1.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.linkLabel1.Disposing || this.linkLabel1.IsDisposed)
                        return;
                }
                SetTextCallback d = new SetTextCallback(SetText);
                this.linkLabel1.Invoke(d, new object[] { text });
            }
            else
            {
                this.linkLabel1.Text = text;
            }
        }
        // 将text更新的界面控件的委托类型
        delegate void SetTextCallback(string text);

        /// <summary>
        /// 上传附件委托
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public delegate void FolderUploadHandler(string a, FileManager.Model.UserModel b);

        /// <summary>
        /// 下载附件委托
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public delegate void FolderDownloadHandler(string a, FileManager.Model.UserModel b);

        /// <summary>
        /// 下载附件委托[文件夹]
        /// </summary>
        /// <param name="a"></param>
        /// <param name="parentId">制定文件夹</param>
        /// <param name="b"></param>
        public delegate void FolderDownloadHandler_OtherUser(string a, int parentId, string code, FileManager.Model.UserModel b);

        /// <summary>
        /// 异步回调
        /// </summary>
        /// <param name="result"></param>
        void IAsyncDownloadMenthod(IAsyncResult result)
        {
            //AsyncResult 是IAsyncResult接口的一个实现类，引用空间：System.Runtime.Remoting.Messaging
            //AsyncDelegate 属性可以强制转换为用户定义的委托的实际类。
            FolderDownloadHandler handler = (FolderDownloadHandler)((AsyncResult)result).AsyncDelegate;
            //InitRootFiles(0);
            handler.EndInvoke(result);
            actionType = -1;

            SetText(string.Format("正在传输的文件({0})", FileWinexploer.GetLeftToActionNum()));
            timerToUpdateUi.Stop();
        }


        /// <summary>
        /// 异步回调
        /// </summary>
        /// <param name="result"></param>
        void IAsyncDownloadMenthod_OtherUser(IAsyncResult result)
        {
            //AsyncResult 是IAsyncResult接口的一个实现类，引用空间：System.Runtime.Remoting.Messaging
            //AsyncDelegate 属性可以强制转换为用户定义的委托的实际类。
            FolderDownloadHandler_OtherUser handler = (FolderDownloadHandler_OtherUser)((AsyncResult)result).AsyncDelegate;
            handler.EndInvoke(result);
        }

        /// <summary>
        /// 跑出异常界面
        /// </summary>
        /// <param name="ex"></param>
        private void ThrowExption(Exception ex)
        {
            try
            {
                //异常界面展示
                FrmError errorMsg = new FrmError(ex.Message);
                errorMsg.ShowDialog();
                return;
            }
            catch (Exception exx)
            {
                MessageBox.Show("出现错误 ： " + exx.Message);
            }
        }

        /// <summary>
        /// 只提示业务异常
        /// </summary>
        /// <param name="msg"></param>
        private void ThrowExption(string msg)
        {
            //异常界面展示
            FrmError errorMsg = new FrmError(msg);
            errorMsg.ShowDialog();
            return;
        }

        #endregion

        #region 托盘事件

        /// <summary>
        /// 关闭后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //取消"关闭窗口"事件
                e.Cancel = true;
                //使关闭时窗口向右下角缩小的效果
                this.WindowState = FormWindowState.Minimized;
                this.notifyIcon1.Visible = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// 托盘退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "是否确定退出,请检查是否有正在上传或者下载的动作！",
                "确定退出",
                 MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                System.Environment.Exit(0);
            }
        }

        /// <summary>
        /// 托盘双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
            {
                this.WindowState = FormWindowState.Minimized;
                this.notifyIcon1.Visible = true;
                this.Hide();
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
                this.RefreshCurWin();
            }
        }

        /// <summary>
        /// 展示主界面
        /// </summary>
        public void ShowMainForm()
        {
            if (this.Visible)
            {
                this.WindowState = FormWindowState.Minimized;
                this.notifyIcon1.Visible = true;
                this.Hide();
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        #endregion

        /// <summary>
        /// 用户选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();
            TreeNode selectNode = e.Node;
            if (selectNode.Name == "tRoot") return;
            //ListUpdate(e.Node.FullPath);
            Model.UserModel user = (Model.UserModel)e.Node.Tag;

            if (user == null || string.IsNullOrEmpty(user.UserName))
            {
                ThrowExption("所选用户信息有错误，请联系管理员修改！");
                return;
            }

            InitProject(user.UserName);
            InitProjectTree();
            InitRootFiles(0, selectProjectId);
        }

        #region 其他
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            toolStripTextBox1.Width = this.Width - 112;
        }

        #endregion

        #region 搜索相关
        private void toolStripTextBox_searchContent_Click(object sender, EventArgs e)
        {
            // 当点击文本框，清空文本框内容
            this.toolStripTextBox_searchContent.Text = "";
            // 恢复文本框字体颜色黑色
            this.toolStripTextBox_searchContent.ForeColor = Color.Black;
            // 恢复文本框字体为标准
            this.toolStripTextBox_searchContent.Font = new Font(this.Font, FontStyle.Regular);
            // 去掉已注册的单击事件（这里值得注意）
            this.toolStripTextBox_searchContent.Click -= new System.EventHandler(this.toolStripTextBox_searchContent_Click);
        }

        private void toolStripButton_searchFile_Click(object sender, EventArgs e)
        {
            //清除已经存在的文件
            this.listView1.Items.Clear();

            string strWhere = string.Empty;
            string keyContent = this.toolStripTextBox_searchContent.Text;
            if (string.IsNullOrEmpty(keyContent) || keyContent == "搜索文件  ")
            {
                MessageBox.Show("请输入关键词！");
                this.toolStripTextBox_searchContent.Focus();
                return;
            }
            else
            {
                #region 待删除
                //if (keyContent.IndexOf("*") > -1)
                //{
                //    string[] keys = keyContent.Split('*');

                //    foreach (var item in keys)
                //    {
                //        if (string.IsNullOrEmpty(item)) continue;

                //    }
                //}
                //else
                //{
                //    strWhere = string.Format(" like '%{0}%'",keyContent);
                //}

                #endregion
                strWhere = string.Format(" F.File_Name like '%" + keyContent + "%' and Fo.Project_Id =" + selectProjectId);
            }

            //文件列表
            FileBll fileBll = new FileBll();
            var subFiles = fileBll.SearchList(1000, strWhere, string.Empty);

            // 图标添加
            FileWinexploer fWinexploer = new FileWinexploer();

            if (subFiles != null && subFiles.Count > 0)
            {
                //开始更新  
                this.listView1.BeginUpdate();

                try
                {
                    this.imageList2 = fWinexploer.GetImageCollectionByDb(strWhere, this.imageList2);
                    this.imageList3 = fWinexploer.GetImageCollectionByDb(strWhere, this.imageList3);

                    //左下文件数量提示
                    this.linkLabel_fileAndForderNum.Text = string.Format("共有{0}文件夹/{1}文件", 0, subFiles.Count);

                    //循环添加文件
                    foreach (var file in subFiles)
                    {
                        ListViewItem item = new ListViewItem(file.File_Name);
                        item.Text = file.File_Name;
                        item.Tag = file;
                        item.ImageKey = file.File_Ext;

                        //文件夹大小转换
                        double len = file.File_Size;
                        if (len >= 1024 * 1024)
                        {
                            len = Math.Round((len / 1024.0 / 1024), 2);
                            item.SubItems.Add(len + "MB");
                        }
                        else
                        {
                            len = Math.Round((len / 1024.0), 2);
                            item.SubItems.Add(len + "KB");
                        }
                        //文件大小
                        this.listView1.Items.Add(item);

                        //文件类型
                        item.SubItems.Add("文件");

                        //item.SubItems.Add(file.File_Ext);
                        //文件时间
                        item.SubItems.Add(new DateTime(file.File_Modify_Time).ToString("yyyy/MM/dd HH:mm"));
                    }
                }
                catch (Exception ex)
                {
                    ThrowExption(ex);
                }
                finally
                {
                    this.listView1.EndUpdate();
                }
            }
        }

        #endregion

        #region 自定义系统按钮事件

        private int actionType = -1;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmFileTransferNew frmProperty = new FrmFileTransferNew(actionType);
            //frmProperty.Show();
            frmProperty.Show();
        }

        //自定义系统按钮事件
        private void FrmMain_SysBottomClick(object sender, CCWin.SkinControl.SysButtonEventArgs e)
        {
            //获得弹出坐标
            Point l = PointToScreen(e.SysButton.Location);
            l.Y += e.SysButton.Size.Height + 1;
            //如果是皮肤菜单
            if (e.SysButton.Name == "SysSkin")
            {
                MessageBox.Show("还没有皮肤可供选择！");
            }
            else if (e.SysButton.Name == "SysTool")
            {
                //如果是设置菜单
                skinContextMenuStrip_State.Show(l);
            }
        }
        #endregion

        #region 属性框中右键按钮事件

        /// <summary>
        /// 系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_systemSetting_Click(object sender, EventArgs e)
        {
            FrmSystemSetting frm = new FrmSystemSetting(0);
            frm.ShowDialog();
        }

        #endregion

        #region 主界面菜单事件

        /// <summary>
        /// 文件或者文件夹的名称修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_rename_Click(object sender, EventArgs e)
        {
            ReName();
        }

        /// <summary>
        /// 删除文件或者文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_del_Click(object sender, EventArgs e)
        {
            Del();
        }

        /// <summary>
        /// 文件和文件夹属性查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_properryView_Click(object sender, EventArgs e)
        {
            PropertyEditView(0);
        }

        /// <summary>
        /// 文件历史记录查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_history_Click(object sender, EventArgs e)
        {
            Histoty();
        }

        #endregion

        #region  事件实现

        /// <summary>
        /// 修改名称
        /// </summary>
        private void ReName()
        {
            if (listView1.SelectedItems.Count == 0) return;

            if (listView1.SelectedItems.Count == 0) //无对象选中时
            {
                return;
            }
            else    //有对象选中时
            {
                string newPath = listView1.SelectedItems[0].Name;
                string typeName = listView1.SelectedItems[0].SubItems[2].Text;
                int type = typeName == "文件夹" ? 1 : 0;

                Model.FileModel file = null;
                Model.ForderModel forder = null;
                if (type == 1)
                {
                    forder = (Model.ForderModel)listView1.SelectedItems[0].Tag;
                }
                else
                {
                    file = (Model.FileModel)listView1.SelectedItems[0].Tag;
                }

                FrmFileRename frm = new FrmFileRename(type, file, forder);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RefreshCurWin();
                }

                // 关联编码
                string actionCode = Guid.NewGuid().ToString();
                if (type == 0)
                {
                    ActionLog(string.Empty, actionCode, ActionType.RENAME);
                    // 异步日志
                    FileLogHelper.FileLog(null, file, actionCode, Model.ActionType.RENAME);
                }
                else
                {
                    Model.FileModel fileModel = new FileModel()
                    {
                        Add_Time = forder.Add_Time,
                        ClientPath = forder.ClientPath,
                        ID = forder.ID,
                        File_Name = forder.Title,
                        Project_Id = forder.Project_Id
                    };

                    Model.FileVersion ver = new FileVersion()
                    {
                        File_Id = fileModel.ID,
                    };

                    string remark = string.Format("文件夹：{0}重命名为：", fileModel.File_Name);
                    var forderModel = new BLL.ForderBll().GetModel(fileModel.ID);
                    remark = remark + forderModel.Title;

                    ActionLog(string.Empty, actionCode, ActionType.RENAMEFORDER);

                    // 异步日志
                    FileLogHelper.FileLogForderRename(ver, fileModel, remark, actionCode, Model.ActionType.RENAMEFORDER);
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void Del()
        {
            //if (MessageBox.Show(
            //    "确定删除这个文件,如果删除该文件不可恢复！",
            //    "删除文件",
            //     MessageBoxButtons.OKCancel) == DialogResult.OK)
            //{
            //    DelFileOrForder();
            //    ActionLog(string.Empty, ActionType.ONEDEL);
            //}
            DelFileOrForder();
        }

        /// <summary>
        /// 操作日志记录
        /// </summary>
        /// <param name="clientPath"></param>
        /// <param name="action"></param>
        private void ActionLog(string clientPath, ActionType action)
        {
            if (this.skinComboBox_project.SelectedItem == null) return;
            ListItem selectItem = (ListItem)this.skinComboBox_project.SelectedItem;
            if (selectItem.Value == null) return;

            Model.UserProjectModel curProject = (Model.UserProjectModel)selectItem.Value;
            if (curProject == null) return;

            if (string.IsNullOrEmpty(clientPath)) clientPath = curProject.MonitoringPath;

            Bll.SystemBll.ActionLogAsyn(curProject.ID, curProject.ProjectName, clientPath, action);
        }

        /// <summary>
        /// 添加编码的日志记录
        /// </summary>
        /// <param name="clientPath"></param>
        /// <param name="actionCode"></param>
        /// <param name="action"></param>
        private void ActionLog(string clientPath, string actionCode, ActionType action)
        {
            if (this.skinComboBox_project.SelectedItem == null) return;
            ListItem selectItem = (ListItem)this.skinComboBox_project.SelectedItem;
            if (selectItem.Value == null) return;

            Model.UserProjectModel curProject = (Model.UserProjectModel)selectItem.Value;
            if (curProject == null) return;

            if (string.IsNullOrEmpty(clientPath)) clientPath = curProject.MonitoringPath;

            Bll.SystemBll.ActionLogAsyn(curProject.ID, curProject.ProjectName, clientPath, actionCode, action);
        }

        /// <summary>
        /// 当前文件夹刷新
        /// </summary>
        private void RefreshCurWin()
        {
            try
            {
                if (currentForders != null && currentForders.Count > 0)
                {
                    InitRootFiles(currentForders[currentForders.Count - 1].ID, selectProjectId);
                }
                else
                {
                    InitRootFiles(0, selectProjectId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 文件或者文件夹删除
        /// </summary>
        private void DelFileOrForder()
        {
            //if (listView1.SelectedItems.Count == 0) return;

            if (listView1.SelectedItems.Count == 0) //无对象选中时
            {
                MessageBox.Show("请选择一个文件或者文件夹！");
                return;
            }
            else if (listView1.SelectedItems.Count > 1)  //有对象选中时
            {
                try
                {
                    // 只有管理员才有权限做删除
                    if (MessageBox.Show(
                    "确定删除这个文件,如果删除该文件不可恢复！",
                    "删除文件",
                     MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        List<Model.FileModel> files = new List<FileModel>();
                        foreach (ListViewItem item in listView1.SelectedItems)
                        {
                            string typeName = item.SubItems[2].Text;
                            if (typeName == "文件夹")
                            {
                                MessageBox.Show("不支持包含文件夹的多文件下载！");
                                return;
                            }
                            else
                            {
                                var fileModel = (Model.FileModel)item.Tag;
                                if (fileModel != null)
                                {
                                    files.Add(fileModel);
                                }
                            }
                        }

                        // 开始删除
                        MultiDelete(files);
                    }
                }
                catch (Exception ee)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    MessageBoxEx.Show("删除失败！" + ee.Message);
                }
                RefreshCurWin();
            }
            else if (listView1.SelectedItems.Count == 1)  //有对象选中时
            {
                try
                {
                    // 只有管理员才有权限做删除

                    if (MessageBox.Show(
                    "确定删除这个文件,如果删除该文件不可恢复！",
                    "删除文件",
                     MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        string typeName = listView1.SelectedItems[0].SubItems[2].Text;
                        int type = typeName == "文件夹" ? 1 : 0;

                        Model.FileModel file = null;
                        Model.ForderModel forder = null;

                        #region 删除文件或者文件夹
                        if (type == 1)
                        {
                            forder = (Model.ForderModel)listView1.SelectedItems[0].Tag;
                            // 工程目录不允许删除
                            if (forder.Parent_Id == 0)
                            {
                                MessageBox.Show("工程目录是不允许删除的！");
                                return;
                            }

                            // 判断是否有子文件或者子目录
                            //开始从文件夹获取子文件夹和文件列表
                            ForderBll forderBll = new ForderBll();
                            var subForders = forderBll.GetSubForders(forder.ID, this.selectProjectId);
                            if (subForders != null && subForders.Count > 0)
                            {
                                MessageBox.Show("该目录包含子目录，请删除子目录,再删除该目录！");
                                return;
                            }
                            var subFiles = forderBll.GetSubFiles(forder.ID, this.selectProjectId, string.Empty);
                            if (subFiles != null && subFiles.Count > 0)
                            {
                                MessageBox.Show("该目录包含子文件，请删除子文件,再删除该目录！");
                                return;
                            }

                            BLL.ForderBll bll = new BLL.ForderBll();
                            bll.UpdateField(forder.ID, string.Format(" IsDeleted = 1 "));

                            ActionLog(string.Empty, ActionType.ONEDELFORDER);
                        }
                        else
                        {
                            foreach (ListViewItem item in listView1.SelectedItems)
                            {
                                int selectType = item.SubItems[2].Text == "文件夹" ? 1 : 0;

                                // 如果选择了文件夹，忽略
                                if (selectType == 1) continue;

                                file = (Model.FileModel)item.Tag;

                                BLL.FileBll bll = new BLL.FileBll();
                                bll.UpdateField(file.ID, string.Format(" IsDeleted = 1 "));

                                // 关联编码
                                string actionCode = Guid.NewGuid().ToString();
                                ActionLog(string.Empty, actionCode, ActionType.ONEDELFILE);
                                if (type == 0)
                                {
                                    // 异步日志
                                    FileLogHelper.FileLog(null, file, actionCode, Model.ActionType.ONEDELFILE);
                                }
                            }
                        }

                        #endregion
                    }
                }
                catch (Exception ee)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    MessageBoxEx.Show("删除失败！" + ee.Message);
                }
                RefreshCurWin();
            }
        }

        /// <summary>
        /// 属性操作
        /// </summary>
        /// <param name="actionType"></param>
        private void PropertyEditView(int actionType)
        {
            if (listView1.SelectedItems.Count == 0) return;

            if (listView1.SelectedItems.Count == 0) //无对象选中时
            {
                MessageBox.Show("请选择一个文件或者文件夹！");
                return;
            }
            else    //有对象选中时
            {
                string newPath = listView1.SelectedItems[0].Name;
                string typeName = listView1.SelectedItems[0].SubItems[2].Text;
                int type = typeName == "文件夹" ? 1 : 0;

                Model.FileModel file = null;
                Model.ForderModel forder = null;
                if (type == 1)
                {
                    forder = (Model.ForderModel)listView1.SelectedItems[0].Tag;
                    FrmForderProperty frm = new FrmForderProperty(actionType, type, forder);
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        RefreshCurWin();
                    }
                }
                else
                {
                    file = (Model.FileModel)listView1.SelectedItems[0].Tag;
                    FrmFileProperty frm = new FrmFileProperty(actionType, type, file);
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        RefreshCurWin();
                    }
                }
            }
        }

        /// <summary>
        /// 历史记录查看
        /// </summary>
        private void Histoty()
        {
            if (listView1.SelectedItems.Count == 0) return;

            if (listView1.SelectedItems.Count == 0) //无对象选中时
            {
                MessageBox.Show("请选择一个文件！");
                return;
            }
            else    //有对象选中时
            {
                string newPath = listView1.SelectedItems[0].Name;
                string typeName = listView1.SelectedItems[0].SubItems[2].Text;
                int type = typeName == "文件夹" ? 1 : 0;

                Model.FileModel file = null;
                Model.ForderModel forder = null;
                if (type == 1)
                {
                    return;
                }
                else
                {
                    file = (Model.FileModel)listView1.SelectedItems[0].Tag;
                    FrmFileHistoryRecord frm = new FrmFileHistoryRecord(file);

                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        RefreshCurWin();
                    }
                }
            }
        }

        /// <summary>
        /// 历史日志查看
        /// </summary>
        private void HistotyLog()
        {
            if (listView1.SelectedItems.Count == 0) return;

            if (listView1.SelectedItems.Count == 0) //无对象选中时
            {
                MessageBox.Show("请选择一个文件！");
                return;
            }
            else    //有对象选中时
            {
                string newPath = listView1.SelectedItems[0].Name;
                string typeName = listView1.SelectedItems[0].SubItems[2].Text;
                int type = typeName == "文件夹" ? 1 : 0;

                Model.FileModel file = null;
                Model.ForderModel forder = null;
                if (type == 1)
                {
                    return;
                }
                else
                {
                    file = (Model.FileModel)listView1.SelectedItems[0].Tag;
                    FrmFileHistoryLog frm = new FrmFileHistoryLog(file);

                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //RefreshCurWin();
                    }
                }
            }
        }

        /// <summary>
        /// 打开文件夹或文件
        /// </summary>
        private void OpenClient()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string newPath = listView1.SelectedItems[0].Name;
                string typeName = listView1.SelectedItems[0].SubItems[2].Text;
                int type = typeName == "文件夹" ? 1 : 0;

                Model.FileModel file = null;
                Model.ForderModel forder = null;
                if (type == 1)
                {
                    forder = (Model.ForderModel)listView1.SelectedItems[0].Tag;
                    newPath = forder.ClientPath;
                }
                else
                {
                    file = (Model.FileModel)listView1.SelectedItems[0].Tag;
                    newPath = file.ClientPath;
                }

                if (string.IsNullOrEmpty(newPath))
                {
                    MessageBox.Show("服务器没有存储本地文件（夹）路径！");
                    return;
                }
                try
                {
                    Process.Start(newPath); //打开文件
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 打开本地文件夹
        /// </summary>
        private void OpenClientForder()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string newPath = listView1.SelectedItems[0].Name;
                string typeName = listView1.SelectedItems[0].SubItems[2].Text;
                int type = typeName == "文件夹" ? 1 : 0;

                Model.FileModel file = null;
                Model.ForderModel forder = null;
                if (type == 1)
                {
                    forder = (Model.ForderModel)listView1.SelectedItems[0].Tag;
                    newPath = forder.ClientPath;
                }
                else
                {
                    file = (Model.FileModel)listView1.SelectedItems[0].Tag;
                    newPath = file.ClientPath;
                }

                if (string.IsNullOrEmpty(newPath))
                {
                    MessageBox.Show("服务器没有存储本地文件（夹）路径！");
                    return;
                }
                try
                {
                    string parentForder = string.Empty;
                    if (type == 1)
                    {
                        DirectoryInfo dir = new DirectoryInfo(newPath);
                        if (dir.Exists) parentForder = dir.Parent.FullName;
                    }
                    else
                    {
                        FileInfo fi = new FileInfo(newPath);
                        if (fi.Exists) parentForder = fi.DirectoryName;
                    }

                    if (!Directory.Exists(parentForder))
                    {
                        if (string.IsNullOrEmpty(newPath))
                        {
                            MessageBox.Show("服务器没有存储本地文件（夹）路径！");
                            return;
                        }
                    }

                    Process.Start(parentForder); //打开文件
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 单个文件下载，可以从服务器同步文件也可以选择另存为
        /// </summary>
        private void OneDownLoadFile()
        {
            if (listView1.SelectedItems.Count == 0) return;

            if (listView1.SelectedItems.Count == 0) //无对象选中时
            {
                MessageBox.Show("请选择一个文件！");
                return;
            }
            else if (listView1.SelectedItems.Count > 1)   //有对象选中时
            {
                // 检查是否包含文件夹
                List<Model.FileModel> files = new List<FileModel>();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    string typeName = item.SubItems[2].Text;
                    if (typeName == "文件夹")
                    {
                        MessageBox.Show("不支持包含文件夹的多文件下载！");
                        return;
                    }
                    else
                    {
                        var fileModel = (Model.FileModel)item.Tag;
                        if (fileModel != null)
                        {
                            files.Add(fileModel);
                        }
                    }
                }
                // 开始下载
                MultiDownLoad(files, string.Empty);
            }
            else if (listView1.SelectedItems.Count == 1)   //有对象选中时
            {
                string newPath = listView1.SelectedItems[0].Name;
                string typeName = listView1.SelectedItems[0].SubItems[2].Text;
                int type = typeName == "文件夹" ? 1 : 0;

                Model.FileModel fileModel = null;
                Model.ForderModel forder = null;
                if (type == 1)
                {
                    //MessageBox.Show("只支持单个文件下载！");
                    //return;

                    // 文件夹下载
                    //BLL.ForderBll forderBll = new ForderBll();
                    //forder = (Model.ForderModel)listView1.SelectedItems[0].Tag;
                    //var subFiles = forderBll.GetSubFiles(forder.ID, forder.Project_Id, string.Empty);
                    //MultiDownLoad(subFiles, forder.Title);


                    // 文件夹下载支持内部子文件夹且显示进度
                    forder = (Model.ForderModel)listView1.SelectedItems[0].Tag;
                    ForderDownLoad(forder);
                }
                else
                {
                    #region 单个文件下载
                    fileModel = (Model.FileModel)listView1.SelectedItems[0].Tag;

                    FrmDownLoadSelect messageBox = new FrmDownLoadSelect();
                    var result = messageBox.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return;
                    }

                    if (fileModel == null || string.IsNullOrEmpty(fileModel.File_Name))
                    {
                        MessageBoxEx.Show("该文件的信息异常！");
                        return;
                    }

                    FileVersionBll verBll = new FileVersionBll();
                    var fileVer = new BLL.FileBll().GetFileLastVer(fileModel.ID);
                    var content = verBll.GetContent(fileVer.ID);

                    // 错误提示
                    if (content == null)
                    {
                        MessageBoxEx.Show("该文件的信息异常！");
                        return;
                    }

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        // 校验是否是自己账号，如果不是自己账号，异常提示
                        //Model.UserModel user = (Model.UserModel)this.treeView1.SelectedNode.Tag;
                        Model.UserModel user = GetCurUser();
                        if (user != null && user.ID > 0 && user.ID != Bll.SystemBll.UserInfo.ID)
                        {
                            MessageBoxEx.Show("对不起,您选择的文件不是您的,请选择另存为！");
                            return;
                        }

                        FileInfo file = new FileInfo(fileModel.ClientPath);
                        if (string.IsNullOrEmpty(fileModel.ClientPath) || !File.Exists(fileModel.ClientPath))
                        {
                            if (!file.Exists && file.Extension.ToLower() == ".ztlj")
                            {
                                // fileModel.ClientPath = string.Format("{0}.ztlj", fileModel.ClientPath);
                            }
                            else
                            {
                                MessageBoxEx.Show("该文件的客户端路径不正确！");
                                return;
                            }
                        }

                        FileWinexploer.CreateFile(content, fileModel.ClientPath, fileVer.File_Modify_Time);

                        UnZipFloClass.UnzipFile(fileModel.ClientPath);

                        MessageBoxEx.Show("同步到客户端成功！");
                        //return;
                    }
                    else
                    {
                        //获取文件信息
                        this.saveFileDialog1.Filter = string.Format("*{0}|*.*", fileModel.File_Ext); ;
                        this.saveFileDialog1.ShowDialog();
                        string fileSavePath = this.saveFileDialog1.FileName;

                        if (string.IsNullOrEmpty(fileSavePath))
                        {
                            return;
                        }

                        //文件存放路径
                        string newPathSave = fileSavePath.EndsWith(fileModel.File_Ext) ? fileSavePath : fileSavePath + fileModel.File_Ext;
                        FileWinexploer.CreateFile(content, newPathSave, fileVer.File_Modify_Time);
                        UnZipFloClass.UnzipFile(newPathSave);
                    }

                    // 关联编码
                    string actionCode = Guid.NewGuid().ToString();
                    ActionLog(string.Empty, actionCode, ActionType.ONEDOWNLOAD);
                    if (type == 0)
                    {
                        // 异步日志
                        FileLogHelper.FileLog(fileVer, fileModel, actionCode, Model.ActionType.ONEDOWNLOAD);
                    }

                    // 异步日志
                    // FileLogHelper.FileLog(fileVer, fileModel, Model.ActionType.ONEDOWNLOAD);
                    #endregion
                }
            }
        }



        /// <summary>
        /// 支持文件夹下载
        /// </summary>
        /// <param name="forder"></param>
        private void ForderDownLoad(Model.ForderModel forder)
        {
            try
            {
                if (this.skinComboBox_project.SelectedItem == null)
                {
                    MessageBox.Show("没有查询到工程信息，请联系管理员处理！");
                    return;
                }

                //工程信息
                ListItem selectItem = (ListItem)this.skinComboBox_project.SelectedItem;

                Model.UserProjectModel curProject = (Model.UserProjectModel)selectItem.Value;
                if (curProject == null || string.IsNullOrEmpty(curProject.MonitoringPath))
                {
                    MessageBox.Show("用户工程配置路径不正确，请联系管理员处理！");
                    return;
                }

                this.folderBrowserDialog1.ShowDialog();
                string forderSavePath = this.folderBrowserDialog1.SelectedPath;

                if (string.IsNullOrEmpty(forderSavePath))
                {
                    return;
                }

                if (!Directory.Exists(forderSavePath))
                {
                    Directory.CreateDirectory(forderSavePath);
                }

                if (!forderSavePath.EndsWith("/"))
                {
                    forderSavePath = forderSavePath + "/";
                }

                if (!string.IsNullOrEmpty(forder.Title))
                {
                    forderSavePath = forderSavePath + forder.Title + "/";
                    if (!Directory.Exists(forderSavePath))
                    {
                        Directory.CreateDirectory(forderSavePath);
                    }
                }

                //此处查询出所有文件内容
                DirectoryInfo rootDirInfo = new DirectoryInfo(forderSavePath);
                FileWinexploer download = new FileWinexploer();

                //上传之前开启文件受影响检查
                Model.UserModel user = Bll.SystemBll.UserInfo;
                user.CurProject = curProject;

                // 替换检查界面[8.5wjh]
                FrmWait frmCheckFile = new FrmWait(forderSavePath, user, 2, forder.ID);
                DialogResult frmCheckFileResult = frmCheckFile.ShowDialog();
                if (frmCheckFileResult != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                if (FileWinexploer.NeedAddOrMordifyFiles == null || FileWinexploer.NeedAddOrMordifyFiles.Count == 0)
                {
                    MessageBox.Show("下载完成！");
                    return;
                }
                else
                {
                    // 关联编码
                    string actionCode = Guid.NewGuid().ToString();

                    FileWinexploer.SetDownLoadCache();
                    actionType = 1;
                    //检查通过开始异步上传
                    FolderDownloadHandler_OtherUser handler = new FolderDownloadHandler_OtherUser(download.FolderDownloadFromDb_OtherUser);
                    handler.BeginInvoke(forderSavePath, forder.ID, actionCode, user, IAsyncDownloadMenthod_OtherUser, null);


                    // 异步日志
                    ActionLog(string.Empty, actionCode, ActionType.ONEDOWNLOADFORDER);

                    // 0909 上传王君海修改
                    FrmFileProgressBar frmTransfer = new FrmFileProgressBar(1);
                    frmTransfer.Show();
                }
            }
            catch (Exception ex)
            {
                ThrowExption(ex);
            }
        }

        /// <summary>
        /// 多个文件下载
        /// </summary>
        /// <param name="files"></param>
        private void MultiDownLoad(List<Model.FileModel> files, string forderName)
        {
            if (files == null || files.Count == 0) return;

            this.folderBrowserDialog1.ShowDialog();
            string forderSavePath = this.folderBrowserDialog1.SelectedPath;

            if (string.IsNullOrEmpty(forderSavePath))
            {
                return;
            }

            if (!Directory.Exists(forderSavePath))
            {
                Directory.CreateDirectory(forderSavePath);
            }

            if (!forderSavePath.EndsWith("/"))
            {
                forderSavePath = forderSavePath + "/";
            }

            if (!string.IsNullOrEmpty(forderName))
            {
                forderSavePath = forderSavePath + forderName + "/";
                if (!Directory.Exists(forderSavePath))
                {
                    Directory.CreateDirectory(forderSavePath);
                }
            }

            // 关联编码
            string actionCode = Guid.NewGuid().ToString();
            FileVersionBll verBll = new FileVersionBll();
            foreach (var fileModel in files)
            {
                try
                {
                    var fileVer = new BLL.FileBll().GetFileLastVer(fileModel.ID);
                    var content = verBll.GetContent(fileVer.ID);
                    //文件存放路径
                    string newPathSave = forderSavePath + fileModel.File_Name;

                    FileWinexploer.CreateFile(content, ChangePath(newPathSave), fileVer.File_Modify_Time);
                    // UnzipFile1(ChangePath(newPathSave));
                    UnZipFloClass.UnzipFile(ChangePath(newPathSave));

                    // 异步日志
                    FileLogHelper.FileLog(fileVer, fileModel, actionCode, Model.ActionType.ONEDOWNLOAD);
                }
                catch (Exception e)
                {
                }
            }
            ActionLog(string.Empty, actionCode, ActionType.MULTIDOWNLOAD);
            MessageBox.Show("下载成功！");
        }

        private string ChangePath(string path)
        {
            FileInfo file = new FileInfo(path);
            if (ForderSpecialControl.IsSpecialForder(file.Name))
            {
                return path + ".ztlj";
            }

            return path;
        }

        public  void UnzipFile1(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (ForderSpecialControl.IsSpecialForder(file.Name))
                {
                    string forderPath = Path.Combine(file.Directory.FullName, file.Name);
                    if (Directory.Exists(forderPath))
                    {
                        Directory.Delete(forderPath, true);
                    }

                    Directory.CreateDirectory(forderPath);
                    UnZipFloClass unzip = new UnZipFloClass();
                    unzip.unZipFile(filePath, forderPath);

                    System.Threading.Thread.Sleep(100);
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                FileManager.Common.LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
            }
        }


        private void SginleDownLoad(List<Model.FileModel> files, string forderName)
        {
            if (files == null || files.Count == 0) return;

            this.folderBrowserDialog1.ShowDialog();
            string forderSavePath = this.folderBrowserDialog1.SelectedPath;

            if (string.IsNullOrEmpty(forderSavePath))
            {
                return;
            }

            if (!Directory.Exists(forderSavePath))
            {
                Directory.CreateDirectory(forderSavePath);
            }

            if (!forderSavePath.EndsWith("/"))
            {
                forderSavePath = forderSavePath + "/";
            }

            if (!string.IsNullOrEmpty(forderName))
            {
                forderSavePath = forderSavePath + forderName + "/";
                if (!Directory.Exists(forderSavePath))
                {
                    Directory.CreateDirectory(forderSavePath);
                }
            }

            // 关联编码
            string actionCode = Guid.NewGuid().ToString();
            FileVersionBll verBll = new FileVersionBll();
            foreach (var fileModel in files)
            {
                try
                {
                    var fileVer = new BLL.FileBll().GetFileLastVer(fileModel.ID);
                    var content = verBll.GetContent(fileVer.ID);
                    //文件存放路径
                    string newPathSave = forderSavePath + fileModel.File_Name;
                    FileWinexploer.CreateFile(content, newPathSave, fileVer.File_Modify_Time);

                    // 异步日志
                    FileLogHelper.FileLog(fileVer, fileModel, actionCode, Model.ActionType.ONEDOWNLOAD);
                }
                catch (Exception e)
                {
                }
            }
            ActionLog(string.Empty, actionCode, ActionType.ONEDOWNLOAD);
            MessageBox.Show("下载成功！");
        }


        /// <summary>
        /// 多个文件下载
        /// </summary>
        /// <param name="files"></param>
        private void MultiDelete(List<Model.FileModel> files)
        {
            if (files == null || files.Count == 0) return;
            // 关联编码
            string actionCode = Guid.NewGuid().ToString();
            FileBll bll = new FileBll();
            foreach (var fileModel in files)
            {
                try
                {
                    bll.UpdateField(fileModel.ID, string.Format(" IsDeleted = 1 "));
                    // 异步日志
                    FileLogHelper.FileLog(null, fileModel, actionCode, Model.ActionType.ONEDELFILE);
                }
                catch (Exception ex)
                {

                }
            }

            ActionLog(string.Empty, actionCode, ActionType.MULTIDELETE);
            MessageBox.Show("删除成功！");
        }

        private void OpenServerFile()
        {
            if (listView1.SelectedItems.Count == 0) return;

            if (listView1.SelectedItems.Count == 0) //无对象选中时
            {
                MessageBox.Show("请选择一个文件！");
                return;
            }
            else    //有对象选中时
            {
                string newPath = listView1.SelectedItems[0].Name;
                string typeName = listView1.SelectedItems[0].SubItems[2].Text;
                int type = typeName == "文件夹" ? 1 : 0;

                Model.FileModel fileModel = null;
                Model.ForderModel forder = null;
                if (type == 1)
                {
                    MessageBox.Show("只支持单个文件下载！");
                    return;
                }
                else
                {
                    fileModel = (Model.FileModel)listView1.SelectedItems[0].Tag;
                    if (fileModel == null || string.IsNullOrEmpty(fileModel.File_Name))
                    {
                        MessageBoxEx.Show("该文件的信息异常！");
                        return;
                    }
                    string tmpDir = FileTmpFileHelper.GetTmpDir();
                    if (string.IsNullOrEmpty(tmpDir))
                    {
                        MessageBoxEx.Show("无法打开服务器文件！");
                        return;
                    }

                    FileVersionBll verBll = new FileVersionBll();
                    var fileVer = new BLL.FileBll().GetFileLastVer(fileModel.ID);

                    int length = fileVer.File_Size;


                    //Model.UserModel user = (Model.UserModel)this.treeView1.SelectedNode.Tag;
                    Model.UserModel user = GetCurUser();
                    if (user != null && user.ID > 0 && user.ID != Bll.SystemBll.UserInfo.ID)
                    {
                        SginleDownLoad(new List<FileModel>() { fileModel }, string.Empty);
                        return;
                    }

                    if (length <= 5000000)
                    {

                        var content = verBll.GetContent(fileVer.ID);
                        string tmpPath = string.Format("{0}/{1}", tmpDir, fileModel.File_Name);

                        FileWinexploer.CreateFile(content, tmpPath, fileVer.File_Modify_Time);
                        //MessageBoxEx.Show("同步到客户端成功！");

                        System.Threading.Thread.Sleep(200);
                        if (File.Exists(tmpPath))
                        {
                            try
                            {
                                Process.Start(tmpPath); //打开文件
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBoxEx.Show("服务器文件无法打开！");
                        }
                    }
                    else
                    {
                        SginleDownLoad(new List<FileModel>() { fileModel }, string.Empty);
                    }

                    return;
                }
            }
        }
        #endregion

        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        private Model.UserModel GetCurUser()
        {
            Model.UserModel user = null;
            if (this.treeView1.SelectedNode != null && this.treeView1.SelectedNode.Tag != null)
            {
                user = (Model.UserModel)this.treeView1.SelectedNode.Tag;
                return user;
            }

            user = Bll.SystemBll.UserInfo;
            return user;
        }

        #region  右键菜单事件

        private void ClearCheck()
        {
            ToolStripMenuItem_LargeIco.Checked = false;
            ToolStripMenuItem_SmallIco.Checked = false;
            ToolStripMenuItem_DetailView.Checked = false;
            ToolStripMenuItem_ListView.Checked = false;
        }

        /// <summary>
        /// 打开本地文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_openClientForder_Click(object sender, EventArgs e)
        {
            OpenClientForder();
        }

        /// <summary>
        /// 本地文件打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_OpenClient_Click(object sender, EventArgs e)
        {
            OpenClient();
        }

        /// <summary>
        /// 大图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_LargeIco_Click(object sender, EventArgs e)
        {
            ClearCheck();
            ToolStripMenuItem_LargeIco.Checked = true;
            listView1.View = View.LargeIcon;
        }

        /// <summary>
        /// 小图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_SmallIco_Click(object sender, EventArgs e)
        {
            ClearCheck();
            ToolStripMenuItem_SmallIco.Checked = true;
            listView1.View = View.SmallIcon;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_ListView_Click(object sender, EventArgs e)
        {
            ClearCheck();
            ToolStripMenuItem_ListView.Checked = true;
            listView1.View = View.List;
        }

        /// <summary>
        /// 详细展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_DetailView_Click(object sender, EventArgs e)
        {
            ClearCheck();
            ToolStripMenuItem_DetailView.Checked = true;
            listView1.View = View.Details;
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Refresh_Click(object sender, EventArgs e)
        {
            RefreshCurWin();
        }

        /// <summary>
        /// 修改名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_Rename_Click(object sender, EventArgs e)
        {
            ReName();
        }

        /// <summary>
        /// 文件删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Del();
        }

        /// <summary>
        /// 文件历史版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_History_Click(object sender, EventArgs e)
        {
            Histoty();
        }

        /// <summary>
        /// 编辑属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_EidtProperty_Click(object sender, EventArgs e)
        {
            PropertyEditView(1);
        }

        /// <summary>
        /// 属性查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_ViewProperty_Click(object sender, EventArgs e)
        {
            PropertyEditView(0);
        }

        /// <summary>
        /// 右键菜单显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Point point = listView1.PointToClient(Cursor.Position);
            //获得鼠标坐标处的ListViewItem
            ListViewItem item = listView1.GetItemAt(point.X, point.Y);
            //当前位置没有ListViewItem
            if (item == null)
            {
                this.ToolStripMenuItem_OpenClient.Visible = false;
                this.ToolStripMenuItem_View.Visible = true;
                this.ToolStripMenuItem_Refresh.Visible = true;
                this.ToolStripMenuItem_EidtProperty.Visible = false;
                this.ToolStripMenuItem_Del.Visible = false;
                this.ToolStripMenuItem_ViewProperty.Visible = false;
                this.ToolStripMenuItem_History.Visible = false;
                this.ToolStripMenuItem_Rename.Visible = false;
                this.toolStripMenuItem3.Visible = false;
                this.toolStripMenuItem4.Visible = false;
                this.toolStripMenuItem1.Visible = false;
                this.toolStripMenuItem1.Visible = false;
                this.toolStripMenuItem_openClientForder.Visible = false;

                this.toolStripMenuItem_OpenServerFile.Visible = false;
                this.toolStripMenuItem_DownFile.Visible = false;
                this.toolStripMenuItem_historyLog.Visible = false;
            }
            //有
            else
            {
                // 本地文件夹打开 本地打开类别查看 刷新  编辑属性  禁止查看
                this.toolStripMenuItem_openClientForder.Visible = false;
                this.ToolStripMenuItem_OpenClient.Visible = false;
                this.ToolStripMenuItem_View.Visible = false;
                this.ToolStripMenuItem_Refresh.Visible = false;
                this.ToolStripMenuItem_EidtProperty.Visible = false;
                this.toolStripMenuItem3.Visible = false;

                //this.ToolStripMenuItem_Del.Visible = true;
                InitUserDelAuth();

                this.ToolStripMenuItem_ViewProperty.Visible = true;
                this.ToolStripMenuItem_History.Visible = true;
                this.ToolStripMenuItem_Rename.Visible = true;

                this.toolStripMenuItem4.Visible = true;
                this.toolStripMenuItem1.Visible = true;

                this.toolStripMenuItem_OpenServerFile.Visible = true;
                this.toolStripMenuItem_DownFile.Visible = true;
                this.toolStripMenuItem_historyLog.Visible = true;
            }
        }

        /// <summary>
        /// 历史日志查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_historyLog_Click(object sender, EventArgs e)
        {
            HistotyLog();
        }

        /// <summary>
        /// 单个文件下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_DownFile_Click(object sender, EventArgs e)
        {
            OneDownLoadFile();
        }

        /// <summary>
        /// 服务器文件打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_OpenServerFile_Click(object sender, EventArgs e)
        {
            OpenServerFile();
        }
        #endregion

        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_userInfo_Click(object sender, EventArgs e)
        {
            FrmAccountInfo frm = new FrmAccountInfo("");
            frm.ShowDialog();

            //FrmMainSingle.MainForm.FrmTipUpload.ShowDialog();
            //return;
        }

        private void toolStrip_cancellation_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin loginForm = new FrmLogin();
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                loginForm.Close();

                ///登录不成功退出
                this.Close();

                Application.Exit();
            }
            else
            {
                try
                {
                    //用户权限控制
                    InitUiByAuth();

                    //用户左侧数
                    InitUserTree();

                    //初始化项目
                    InitProject(Bll.SystemBll.UserInfo.UserName);

                    //初始化中间文件管理器
                    InitRootFiles(0, selectProjectId);

                    //初始化用户管理界面
                    InitManagerUserPage();

                    // 初始化所选用户的目录树结构
                    InitProjectTree();

                    //日志操作相关
                    InitLogUI();

                    this.Visible = true;
                }
                catch (Exception ex)
                {
                    ThrowExption(ex);
                }
            }
        }

        #region 自动上传文件

        /// <summary>
        /// 定时器自动备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_autoUpload_Tick(object sender, EventArgs e)
        {
            //if (MessageBox.Show(
            //       "是否自动备份！",
            //       "自动备份",
            //        MessageBoxButtons.OKCancel) == DialogResult.OK)
            //{

            //}
            //else
            //{
            //    return;
            //}
            AutoUpload();
        }

        /// <summary>
        /// 自动更新方法
        /// </summary>
        private void AutoUpload()
        {
            try
            {
                if (FileAutoUpload.AutoUpload == "UPLOADING")
                {
                    return;
                }

                // 备份状态标识
                FileAutoUpload.SetAutoUploadSign("UPLOADING");

                this.linkLabel_UploadMsg.Visible = true;
                SetAutoUpdateText("自动备份中..：" + DateTime.Now.ToString());

                ListItem selectItem = (ListItem)this.skinComboBox_project.SelectedItem;
                Model.UserProjectModel curProject = (Model.UserProjectModel)selectItem.Value;
                if (curProject == null || string.IsNullOrEmpty(curProject.MonitoringPath))
                {
                    //MessageBox.Show("服务器配置路径不正确，请联系管理员处理！");
                    return;
                }

                //监控绑定路径
                string dirPath = curProject.MonitoringPath;
                if (!Directory.Exists(dirPath))
                {
                    //MessageBox.Show("服务器配置路径不正确，请联系管理员处理！");
                    return;
                }

                //此处查询出所有文件内容
                DirectoryInfo rootDirInfo = new DirectoryInfo(dirPath);
                FileWinexploer upload = new FileWinexploer();

                //上传之前开启文件受影响检查
                Model.UserModel user = Bll.SystemBll.UserInfo;
                user.CurProject = curProject;
                upload.CheckFolderUploadToDb(dirPath, user);

                //检查通过开始异步上传
                FolderUploadHandler handler = new FolderUploadHandler(upload.FolderUploadToDb);
                handler.BeginInvoke(dirPath, user, IAsyncAutoUploadMenthod, null);

                ///异步日志
                ActionLog(string.Empty, ActionType.ALLUPLOAD);

                // 上传完成需要刷新当前展示的文件结构
                this.RefreshCurWin();

                // 上传完成需要刷新目录树
                InitProjectTree();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                //FileAutoUpload.SetAutoUploadSign("END");
            }
        }

        /// <summary>
        /// 异步回调
        /// </summary>
        /// <param name="result"></param>
        void IAsyncAutoUploadMenthod(IAsyncResult result)
        {
            //AsyncResult 是IAsyncResult接口的一个实现类，引用空间：System.Runtime.Remoting.Messaging
            //AsyncDelegate 属性可以强制转换为用户定义的委托的实际类。
            FolderUploadHandler handler = (FolderUploadHandler)((AsyncResult)result).AsyncDelegate;
            handler.EndInvoke(result);
            //timerToUpdateUi.Stop();
            FileAutoUpload.SetAutoUploadSign("END");

            SetAutoUpdateText("自动备份结束：" + DateTime.Now.ToString());
        }

        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetAutoUpdateText(string text)
        {
            //如果调用控件的线程和创建创建控件的线程不是同一个则为True
            if (this.linkLabel_UploadMsg.InvokeRequired)
            {
                while (!this.linkLabel_UploadMsg.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.linkLabel_UploadMsg.Disposing || this.linkLabel_UploadMsg.IsDisposed)
                    {
                        return;
                    }
                }
                SetTextCallback d = new SetTextCallback(SetAutoUpdateText);
                this.linkLabel_UploadMsg.Invoke(d, new object[] { text });
            }
            else
            {
                this.linkLabel_UploadMsg.Text = text;
            }
        }

        /// <summary>
        /// 将text更新的界面控件的委托类型
        /// </summary>
        /// <param name="text"></param>
        delegate void SetAutoUpdateTextCallback(string text);

        #endregion

        /// <summary>
        /// 自动备份设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_autoSaveSetting_Click(object sender, EventArgs e)
        {
            FrmAutoSaveSetting frm = new FrmAutoSaveSetting();
            frm.ShowDialog();
        }

        /// <summary>
        /// 域名地址设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_dominSetting_Click(object sender, EventArgs e)
        {
            FrmDominSetting frm = new FrmDominSetting();
            frm.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // 获取配置信息
            //    var config = BLL.SystemConfigBll.GetConfig();
            //    if (config != null && !string.IsNullOrEmpty(config.Chem32Path))
            //    {
            //        System.Diagnostics.Process.Start(config.Chem32Path);
            //    }
            //    else
            //    {
            //        //异常界面展示
            //        FrmError errorMsg = new FrmError("路径配置异常,请设置！");
            //        errorMsg.ShowDialog();
            //        return;
            //    }
            //    //ProcessStart.StartProcess("ChemMain.exe");
            //}
            //catch (Exception ex)
            //{
            //    ThrowExption(ex);
            //}

            StartSoftWare(true);
        }

        private void StartSoftWare(bool isNeedShowError)
        {
            try
            {
                // 获取配置信息
                var config = BLL.SystemConfigBll.GetConfig();
                if (config != null && !string.IsNullOrEmpty(config.Chem32Path))
                {
                    if (!string.IsNullOrEmpty(config.SoftwareName))
                    {
                        if (ProcessStart.IsProcessExist(config.SoftwareName))
                        {
                            if (isNeedShowError)
                            {
                                MessageBox.Show("程序已经运行！");
                            }
                            return;
                        }
                        else
                        {
                            System.Diagnostics.Process.Start(config.Chem32Path);
                            //ProcessStart.FunProcessStart(config.Chem32Path, "ChemMain.exe");
                        }
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(config.Chem32Path);
                        //ProcessStart.FunProcessStart(config.Chem32Path, "ChemMain.exe");
                    }
                }
                else
                {
                    if (isNeedShowError)
                    {//异常界面展示
                        FrmError errorMsg = new FrmError("路径配置异常,请设置！");
                        errorMsg.ShowDialog();
                    }
                    return;
                }
                //ProcessStart.StartProcess("ChemMain.exe");

                // 异步日志
                FileManager.Bll.SystemBll.ActionLogAsyn(0, string.Empty, string.Empty, Model.ActionType.OPENSOFTWARECHEM);
            }
            catch (Exception ex)
            {
                if (isNeedShowError)
                {
                    ThrowExption(ex);
                }
            }
        }
    }
}

