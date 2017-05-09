using System;
using System.Threading;
using System.Windows.Forms;

namespace Barbar.HostsSwitcher {
  static class Program {
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      bool createdNew = false;
      Mutex mutex = null;
      try {
        mutex = new Mutex(true, "HostsSwitcher", out createdNew);
      } catch {
      }
      if (mutex == null || !createdNew) {
        MessageBox.Show("Another instance of HostsSwitcher is already running.", "Cannot start HostsSwitcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }

      try {
        Application.Run(new FormMain());
      } finally {
        mutex.Close();
      }
    }
  }
}
