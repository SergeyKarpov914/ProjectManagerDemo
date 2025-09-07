using Acsp.Core.Lib.Abstraction;

namespace Clio.ProjectManager.WPF.WinUtil
{
    public class WinAccess : IWinAccess
    {
        public string SelectFile(string mask = "*.*")
        {
            string filePath = null;

            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = $"Files ({mask})|{mask}",
                Title = "Select a file"
            };
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }
            return filePath;
        }
    }
}
