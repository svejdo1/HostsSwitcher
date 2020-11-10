namespace Barbar.HostsSwitcher {
  partial class FormMain {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStripShow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.quickSwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panContent = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_new = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_copy = new System.Windows.Forms.Button();
            this.button_use_as_hosts = new System.Windows.Forms.Button();
            this.lblHosts = new System.Windows.Forms.Label();
            this.lblUsing = new System.Windows.Forms.Label();
            this.listHosts = new System.Windows.Forms.ListBox();
            this.panBottom = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_viewCurrent = new System.Windows.Forms.Button();
            this.button_openFolder = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.panContent.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panBottom.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.menuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Hosts Manager";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripShow,
            this.menuStripExit,
            this.quickSwitchToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(186, 100);
            // 
            // menuStripShow
            // 
            this.menuStripShow.Name = "menuStripShow";
            this.menuStripShow.Size = new System.Drawing.Size(185, 32);
            this.menuStripShow.Text = "&Show";
            this.menuStripShow.Click += new System.EventHandler(this.menuStripShow_Click);
            // 
            // menuStripExit
            // 
            this.menuStripExit.Name = "menuStripExit";
            this.menuStripExit.Size = new System.Drawing.Size(185, 32);
            this.menuStripExit.Text = "&Exit";
            this.menuStripExit.Click += new System.EventHandler(this.menuStripExit_Click);
            // 
            // quickSwitchToolStripMenuItem
            // 
            this.quickSwitchToolStripMenuItem.Name = "quickSwitchToolStripMenuItem";
            this.quickSwitchToolStripMenuItem.Size = new System.Drawing.Size(185, 32);
            this.quickSwitchToolStripMenuItem.Text = "&Quick Switch";
            // 
            // panContent
            // 
            this.panContent.Controls.Add(this.groupBox2);
            this.panContent.Controls.Add(this.groupBox1);
            this.panContent.Controls.Add(this.listHosts);
            this.panContent.Controls.Add(this.menuStrip1);
            this.panContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panContent.Location = new System.Drawing.Point(0, 0);
            this.panContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(1046, 398);
            this.panContent.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_new);
            this.groupBox1.Controls.Add(this.button_delete);
            this.groupBox1.Controls.Add(this.button_copy);
            this.groupBox1.Controls.Add(this.button_use_as_hosts);
            this.groupBox1.Location = new System.Drawing.Point(367, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 224);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Host Profiles";
            // 
            // button_new
            // 
            this.button_new.Location = new System.Drawing.Point(16, 89);
            this.button_new.Name = "button_new";
            this.button_new.Size = new System.Drawing.Size(121, 35);
            this.button_new.TabIndex = 10;
            this.button_new.Text = "New";
            this.button_new.UseVisualStyleBackColor = true;
            this.button_new.Click += new System.EventHandler(this.button_new_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(16, 178);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(121, 35);
            this.button_delete.TabIndex = 9;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(16, 137);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(121, 35);
            this.button_copy.TabIndex = 8;
            this.button_copy.Text = "Copy";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // button_use_as_hosts
            // 
            this.button_use_as_hosts.Location = new System.Drawing.Point(16, 25);
            this.button_use_as_hosts.Name = "button_use_as_hosts";
            this.button_use_as_hosts.Size = new System.Drawing.Size(121, 35);
            this.button_use_as_hosts.TabIndex = 7;
            this.button_use_as_hosts.Text = "Set";
            this.button_use_as_hosts.UseVisualStyleBackColor = true;
            this.button_use_as_hosts.Click += new System.EventHandler(this.button_use_as_hosts_Click);
            // 
            // lblHosts
            // 
            this.lblHosts.AutoSize = true;
            this.lblHosts.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lblHosts.Location = new System.Drawing.Point(559, 70);
            this.lblHosts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHosts.Name = "lblHosts";
            this.lblHosts.Size = new System.Drawing.Size(65, 23);
            this.lblHosts.TabIndex = 5;
            this.lblHosts.Text = "hosts";
            // 
            // lblUsing
            // 
            this.lblUsing.AutoSize = true;
            this.lblUsing.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lblUsing.Location = new System.Drawing.Point(559, 31);
            this.lblUsing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsing.Name = "lblUsing";
            this.lblUsing.Size = new System.Drawing.Size(186, 23);
            this.lblUsing.TabIndex = 4;
            this.lblUsing.Text = "Currently using:";
            // 
            // listHosts
            // 
            this.listHosts.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listHosts.FormattingEnabled = true;
            this.listHosts.ItemHeight = 23;
            this.listHosts.Location = new System.Drawing.Point(18, 64);
            this.listHosts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listHosts.Name = "listHosts";
            this.listHosts.Size = new System.Drawing.Size(322, 303);
            this.listHosts.TabIndex = 2;
            this.listHosts.DoubleClick += new System.EventHandler(this.listHosts_DoubleClick);
            // 
            // panBottom
            // 
            this.panBottom.Controls.Add(this.txtLog);
            this.panBottom.Controls.Add(this.lblLog);
            this.panBottom.Controls.Add(this.lblHosts);
            this.panBottom.Controls.Add(this.lblUsing);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 407);
            this.panBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(1046, 171);
            this.panBottom.TabIndex = 5;
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtLog.Location = new System.Drawing.Point(10, 31);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(514, 119);
            this.txtLog.TabIndex = 1;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lblLog.Location = new System.Drawing.Point(6, 6);
            this.lblLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(43, 23);
            this.lblLog.TabIndex = 0;
            this.lblLog.Text = "Log";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_openFolder);
            this.groupBox2.Controls.Add(this.button_viewCurrent);
            this.groupBox2.Location = new System.Drawing.Point(367, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 124);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HOSTS";
            // 
            // button_viewCurrent
            // 
            this.button_viewCurrent.Location = new System.Drawing.Point(16, 33);
            this.button_viewCurrent.Name = "button_viewCurrent";
            this.button_viewCurrent.Size = new System.Drawing.Size(121, 35);
            this.button_viewCurrent.TabIndex = 11;
            this.button_viewCurrent.Text = "View Current";
            this.button_viewCurrent.UseVisualStyleBackColor = true;
            this.button_viewCurrent.Click += new System.EventHandler(this.button_viewCurrent_Click);
            // 
            // button_openFolder
            // 
            this.button_openFolder.Location = new System.Drawing.Point(16, 74);
            this.button_openFolder.Name = "button_openFolder";
            this.button_openFolder.Size = new System.Drawing.Size(121, 35);
            this.button_openFolder.TabIndex = 12;
            this.button_openFolder.Text = "Open Folder";
            this.button_openFolder.UseVisualStyleBackColor = true;
            this.button_openFolder.Click += new System.EventHandler(this.button_openFolder_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1046, 33);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 578);
            this.Controls.Add(this.panBottom);
            this.Controls.Add(this.panContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hosts Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.panContent.ResumeLayout(false);
            this.panContent.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panBottom.ResumeLayout(false);
            this.panBottom.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.NotifyIcon notifyIcon;
    private System.Windows.Forms.Panel panContent;
    private System.Windows.Forms.ListBox listHosts;
    private System.Windows.Forms.Panel panBottom;
    private System.Windows.Forms.Label lblLog;
    private System.Windows.Forms.TextBox txtLog;
    private System.Windows.Forms.ContextMenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem menuStripExit;
    private System.Windows.Forms.ToolStripMenuItem menuStripShow;
    private System.Windows.Forms.Label lblHosts;
    private System.Windows.Forms.Label lblUsing;
    private System.Windows.Forms.ToolStripMenuItem quickSwitchToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.Button button_use_as_hosts;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button_new;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_openFolder;
        private System.Windows.Forms.Button button_viewCurrent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

