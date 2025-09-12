using Acsp.Core.Lib.Abstraction;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

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

        public void ShowNotification(string message, Notification what = Notification.Info, int duration = 5000)
        {
            Window window = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive) ?? Application.Current.MainWindow;
            
            if (window != null)
            {
                ToolTip tooltip = new ToolTip
                {
                    Content = $"{(what == Notification.Error ? "CARAMBA! " : "")}{message}",
                    Background = what == Notification.Error ?  Brushes.AntiqueWhite : Brushes.White,
                    Foreground = what == Notification.Error ? Brushes.Red : Brushes.Black,
                    StaysOpen = true,
                    Placement = System.Windows.Controls.Primitives.PlacementMode.Absolute,
                    HorizontalOffset = window.Left + window.Width / 2,
                    VerticalOffset = window.Top + window.Height / 2
                };
                tooltip.IsOpen = true;

                DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(2000) };
                timer.Tick += (s, e) =>
                {
                    tooltip.IsOpen = false;
                    timer.Stop();
                };
                timer.Start();
            }
        }

        public bool Confirmation(string message, string caption)
        { 
            return MessageBoxResult.OK == MessageBox.Show(message, caption, MessageBoxButton.OKCancel, MessageBoxImage.Question);
        }
    }
}
