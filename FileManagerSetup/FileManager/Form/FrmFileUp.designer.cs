namespace FileManager
{
    partial class FrmFileUp
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.fileTansfersContainer1 = new CCWin.SkinControl.SkinFileTansfersContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fileTansfersContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(316, 347);
            this.panel2.TabIndex = 3;
            // 
            // fileTansfersContainer1
            // 
            this.fileTansfersContainer1.AutoScroll = true;
            this.fileTansfersContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fileTansfersContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTansfersContainer1.Location = new System.Drawing.Point(2, 2);
            this.fileTansfersContainer1.Name = "fileTansfersContainer1";
            this.fileTansfersContainer1.Size = new System.Drawing.Size(312, 343);
            this.fileTansfersContainer1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.propertyGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(316, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(195, 347);
            this.panel3.TabIndex = 2;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(195, 347);
            this.propertyGrid1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmFileUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 347);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "FrmFileUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "(测试案例1)控件扩展美化系列（文件传输信息显示控件)";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Timer timer1;
        private CCWin.SkinControl.SkinFileTansfersContainer fileTansfersContainer1;








    }
}

