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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnUseAsHosts = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnViewEdit = new System.Windows.Forms.ToolStripButton();
            this.btnOpenFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStripShow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panContent = new System.Windows.Forms.Panel();
            this.lblHosts = new System.Windows.Forms.Label();
            this.lblUsing = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listHosts = new System.Windows.Forms.ListBox();
            this.panBottom = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.quickSwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panContent.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUseAsHosts,
            this.btnCopy,
            this.btnDelete,
            this.btnViewEdit,
            this.btnOpenFolder,
            this.toolStripSeparator1,
            this.btnExit});
            this.toolStrip.Location = new System.Drawing.Point(3, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(111, 152);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // btnUseAsHosts
            // 
            this.btnUseAsHosts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUseAsHosts.Image = ((System.Drawing.Image)(resources.GetObject("btnUseAsHosts.Image")));
            this.btnUseAsHosts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUseAsHosts.Name = "btnUseAsHosts";
            this.btnUseAsHosts.Size = new System.Drawing.Size(109, 17);
            this.btnUseAsHosts.Text = "&Use as HOSTS";
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(109, 17);
            this.btnCopy.Text = "&Copy";
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(109, 17);
            this.btnDelete.Text = "&Delete";
            // 
            // btnViewEdit
            // 
            this.btnViewEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnViewEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnViewEdit.Image")));
            this.btnViewEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewEdit.Name = "btnViewEdit";
            this.btnViewEdit.Size = new System.Drawing.Size(109, 17);
            this.btnViewEdit.Text = "&View/Edit";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFolder.Image")));
            this.btnOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(109, 17);
            this.btnOpenFolder.Text = "&Open Folder";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 17);
            this.btnExit.Text = "&Exit";
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
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripShow,
            this.menuStripExit,
            this.quickSwitchToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(153, 92);
            // 
            // menuStripShow
            // 
            this.menuStripShow.Name = "menuStripShow";
            this.menuStripShow.Size = new System.Drawing.Size(152, 22);
            this.menuStripShow.Text = "&Show";
            this.menuStripShow.Click += new System.EventHandler(this.menuStripShow_Click);
            // 
            // menuStripExit
            // 
            this.menuStripExit.Name = "menuStripExit";
            this.menuStripExit.Size = new System.Drawing.Size(152, 22);
            this.menuStripExit.Text = "&Exit";
            this.menuStripExit.Click += new System.EventHandler(this.menuStripExit_Click);
            // 
            // panContent
            // 
            this.panContent.Controls.Add(this.lblHosts);
            this.panContent.Controls.Add(this.lblUsing);
            this.panContent.Controls.Add(this.panel1);
            this.panContent.Controls.Add(this.listHosts);
            this.panContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panContent.Location = new System.Drawing.Point(0, 0);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(361, 259);
            this.panContent.TabIndex = 4;
            // 
            // lblHosts
            // 
            this.lblHosts.AutoSize = true;
            this.lblHosts.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lblHosts.Location = new System.Drawing.Point(240, 195);
            this.lblHosts.Name = "lblHosts";
            this.lblHosts.Size = new System.Drawing.Size(42, 15);
            this.lblHosts.TabIndex = 5;
            this.lblHosts.Text = "hosts";
            // 
            // lblUsing
            // 
            this.lblUsing.AutoSize = true;
            this.lblUsing.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lblUsing.Location = new System.Drawing.Point(240, 171);
            this.lblUsing.Name = "lblUsing";
            this.lblUsing.Size = new System.Drawing.Size(119, 15);
            this.lblUsing.TabIndex = 4;
            this.lblUsing.Text = "Currently using:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip);
            this.panel1.Location = new System.Drawing.Point(237, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(114, 152);
            this.panel1.TabIndex = 3;
            // 
            // listHosts
            // 
            this.listHosts.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listHosts.FormattingEnabled = true;
            this.listHosts.ItemHeight = 15;
            this.listHosts.Location = new System.Drawing.Point(12, 12);
            this.listHosts.Name = "listHosts";
            this.listHosts.Size = new System.Drawing.Size(216, 229);
            this.listHosts.TabIndex = 2;
            this.listHosts.DoubleClick += new System.EventHandler(this.listHosts_DoubleClick);
            // 
            // panBottom
            // 
            this.panBottom.Controls.Add(this.txtLog);
            this.panBottom.Controls.Add(this.lblLog);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 265);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(361, 111);
            this.panBottom.TabIndex = 5;
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtLog.Location = new System.Drawing.Point(7, 20);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(344, 79);
            this.txtLog.TabIndex = 1;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lblLog.Location = new System.Drawing.Point(4, 4);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(28, 15);
            this.lblLog.TabIndex = 0;
            this.lblLog.Text = "Log";
            // 
            // quickSwitchToolStripMenuItem
            // 
            this.quickSwitchToolStripMenuItem.Name = "quickSwitchToolStripMenuItem";
            this.quickSwitchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quickSwitchToolStripMenuItem.Text = "&Quick Switch";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 376);
            this.Controls.Add(this.panBottom);
            this.Controls.Add(this.panContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hosts Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.panContent.ResumeLayout(false);
            this.panContent.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panBottom.ResumeLayout(false);
            this.panBottom.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripButton btnUseAsHosts;
    private System.Windows.Forms.ToolStripButton btnCopy;
    private System.Windows.Forms.ToolStripButton btnDelete;
    private System.Windows.Forms.ToolStripButton btnViewEdit;
    private System.Windows.Forms.ToolStripButton btnOpenFolder;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton btnExit;
    private System.Windows.Forms.NotifyIcon notifyIcon;
    private System.Windows.Forms.Panel panContent;
    private System.Windows.Forms.ListBox listHosts;
    private System.Windows.Forms.Panel panBottom;
    private System.Windows.Forms.Label lblLog;
    private System.Windows.Forms.TextBox txtLog;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ContextMenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem menuStripExit;
    private System.Windows.Forms.ToolStripMenuItem menuStripShow;
    private System.Windows.Forms.Label lblHosts;
    private System.Windows.Forms.Label lblUsing;
    private System.Windows.Forms.ToolStripMenuItem quickSwitchToolStripMenuItem;
  }
}

