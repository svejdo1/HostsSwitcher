
namespace Barbar.HostsSwitcher.Provider {
  public interface IHostProvider {
    string[] GetHostFiles();
    void ReplaceHosts(string fileName);
    void CopyHosts(string sourceFileName, string targetFileName);
    void DeleteHosts(string fileName);
    void LaunchEditor(string fileName);
    void OpenFolder();
  }
}
