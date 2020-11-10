
namespace Barbar.HostsSwitcher.Provider {
  public interface IHostProvider {
    string[] GetHostFiles();
    void ReplaceHosts(string fileName);
        void WriteHosts(string hostsText);
        void CopyHosts(string sourceFileName, string targetFileName);
    void DeleteHosts(string fileName);
    void LaunchEditor(string fileName);
    void OpenFolder();
  }
}
