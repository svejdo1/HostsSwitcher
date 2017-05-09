using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Barbar.HostsSwitcher.Provider {
  internal class HostProvider : IHostProvider {
    private readonly List<string> m_ExcludeList = new List<string>() {
      "lmhosts.sam",
      "networks",
      "protocol",
      "services"
    };
    private readonly string m_Directory = Path.Combine(Path.Combine(Environment.SystemDirectory, "Drivers"), "etc");

    public string[] GetHostFiles() {
      
      List<string> result = new List<string>();
      foreach (var file in Directory.GetFiles(m_Directory)) {
        var fileName = Path.GetFileName(file);
        if (m_ExcludeList.Contains(fileName.ToLowerInvariant()))
          continue;

        result.Add(fileName);
      }
      return result.ToArray();
    }

    public void ReplaceHosts(string fileName) {
      if (string.Compare(fileName, "hosts", StringComparison.OrdinalIgnoreCase) == 0) {
        return;
      }

      File.Copy(Path.Combine(m_Directory, fileName), Path.Combine(m_Directory, "hosts"), true);
    }
    
    public void CopyHosts(string sourceFileName, string targetFileName) {
      File.Copy(Path.Combine(m_Directory, sourceFileName), Path.Combine(m_Directory, targetFileName), true);
    }
    
    public void DeleteHosts(string fileName) {
      File.Delete(Path.Combine(m_Directory, fileName));  
    }
    
    public void LaunchEditor(string fileName) {
      Process.Start("notepad", @"""" + Path.Combine(m_Directory, fileName) + @"""");
    }
    
    public void OpenFolder() {
      Process.Start("explorer", @"""" + m_Directory + @"""");
    }
  }
}
