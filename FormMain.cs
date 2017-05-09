using System;
using System.Globalization;
using System.Windows.Forms;
using Barbar.HostsSwitcher.Provider;

namespace Barbar.HostsSwitcher {
  public partial class FormMain : Form {
    private readonly IHostProvider m_HostsProvider;

    public FormMain() {
      InitializeComponent();

      m_HostsProvider = new HostProvider();
      quickSwitchToolStripMenuItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(quickSwitchToolStripMenuItem_DropDownItemClicked);
      foreach (var host in m_HostsProvider.GetHostFiles()) {
        listHosts.Items.Add(host);
        quickSwitchToolStripMenuItem.DropDownItems.Add(host);
      }

      Text = string.Format("Hosts Switcher - v.{0}", typeof(FormMain).Assembly.GetName().Version);
    }

    private void quickSwitchToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
      var clicked = e.ClickedItem.Text;
      if (!string.IsNullOrEmpty(clicked)) {
        UseAsHosts(clicked);
      }
    }

    private void RefreshList() {
      var selectedItem = (string)listHosts.SelectedItem;
      bool setSelected = false;

      listHosts.Items.Clear();
      foreach (var host in m_HostsProvider.GetHostFiles()) {
        if (!string.IsNullOrEmpty(selectedItem) && string.Compare(host, selectedItem, StringComparison.OrdinalIgnoreCase) == 0) {
          setSelected = true;
        }

        listHosts.Items.Add(host);
      }

      if (setSelected) {
        listHosts.SelectedItem = selectedItem;
      }
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
      if (e.CloseReason == CloseReason.UserClosing) {
        e.Cancel = true;
        this.Visible = false;
      }
    }

    private void notifyIcon_MouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        WindowState = FormWindowState.Normal;
        this.Visible = true;
        this.Focus();
      }
    }

    private void LogInfo(string format, params object[] args) {
      txtLog.Text += string.Format(CultureInfo.InvariantCulture, format, args);
      txtLog.SelectionStart = txtLog.Text.Length;
      txtLog.ScrollToCaret();
    }

    private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
      if (e.ClickedItem == btnExit) {
        Application.Exit();
      }
      if (e.ClickedItem == btnUseAsHosts && listHosts.SelectedItem != null) {
        UseAsHosts((string)listHosts.SelectedItem);
      }
      if (e.ClickedItem == btnCopy && listHosts.SelectedItem != null) {
        var formCopy = new FormCopy(string.Format("Copy {0} to which file ?", listHosts.SelectedItem));
        var result = formCopy.ShowDialog(this);
        if (result == DialogResult.OK && !string.IsNullOrEmpty(formCopy.FileName)) {
          m_HostsProvider.CopyHosts((string)listHosts.SelectedItem, formCopy.FileName);
          LogInfo("Copied {0} to {1}\r\n", listHosts.SelectedItem, formCopy.FileName);
          RefreshList();
        }
      }
      if (e.ClickedItem == btnDelete && listHosts.SelectedItem != null) {
        if (MessageBox.Show(string.Format("Really delete {0} ?", listHosts.SelectedItem), string.Empty, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
          m_HostsProvider.DeleteHosts((string)listHosts.SelectedItem);
          LogInfo("Deleted {0}\r\n", listHosts.SelectedItem);
          RefreshList();
        }
      }
      if (e.ClickedItem == btnViewEdit && listHosts.SelectedItem != null) {
        m_HostsProvider.LaunchEditor((string)listHosts.SelectedItem);
      }
      if (e.ClickedItem == btnOpenFolder) {
        m_HostsProvider.OpenFolder();
      }
    }

    private void UseAsHosts(string selectedItem) {
      m_HostsProvider.ReplaceHosts(selectedItem);
      lblHosts.Text = selectedItem;
      LogInfo("Copied {0} to hosts\r\n", selectedItem);
    }

    private void menuStripExit_Click(object sender, EventArgs e) {
      Application.Exit();
    }

    private void menuStripShow_Click(object sender, EventArgs e) {
      WindowState = FormWindowState.Normal;
      this.Visible = true;
      this.Focus();
    }

    private void listHosts_DoubleClick(object sender, EventArgs e) {
      if (listHosts.SelectedItem != null) {
        m_HostsProvider.ReplaceHosts((string)listHosts.SelectedItem);
        lblHosts.Text = (string)listHosts.SelectedItem;
        LogInfo("Copied {0} to hosts\r\n", listHosts.SelectedItem);
      }
    }
  }
}
