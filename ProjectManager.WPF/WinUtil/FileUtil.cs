namespace Clio.ProjectManager.WPF.WinUtil
{
    public class FileUtil
    {
        public static string SelectFile(string mask = "*.*", string title = "Select a file")
        {
            string filePath = null;

            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = $"Files ({mask})|{mask}",
                Title = title
            };
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }
            return filePath;
        }
    }
}
