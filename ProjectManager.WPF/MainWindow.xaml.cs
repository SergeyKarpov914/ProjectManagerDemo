using Acsp.Core.Lib.Extension;
using Acsp.Core.Lib.Master;
using Clio.ProjectManagerModel.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Clio.ProjectManagerDemo.WPF
{
    public sealed class MainWindowDependencies : DependencyMaster
    {
        protected override void cascadeDependencies(IServiceCollection container)
        {
            typeof(ProjectManagerViewModel).RegisterCascading(container, () => container.AddSingleton<ProjectManagerViewModel>());
        }
    }

    public partial class MainWindow : Window
    {
        public static DependencyMaster CascadeDependencies()
        {
            return new MainWindowDependencies();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            navigationDrawer.ToggleDrawer();
        }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            Contents = new List<Model>();

            Contents.Add(new Model() { Name = "Home" });
            Contents.Add(new Model() { Name = "Profile" });
            Contents.Add(new Model() { Name = "Inbox" });
            Contents.Add(new Model() { Name = "Outbox" });
            Contents.Add(new Model() { Name = "Sent" });
            Contents.Add(new Model() { Name = "Trash" });
            Contents.Add(new Model() { Name = "Sign Out" });
        }

        public List<Model> Contents { get; set; }
    }

    public class Model
    {
        public string Name { get; set; }
    }
}