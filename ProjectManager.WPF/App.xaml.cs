using Acsp.Core.Lib.Data;
using Acsp.Core.Lib.Extension;
using Clio.ProjectManagerModel.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Configuration;
using System.IO;
using System.Windows;


namespace Clio.ProjectManagerDemo.WPF
{
    public partial class App : Application
    {
        private IHost? _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                        .ConfigureAppConfiguration((context, config) =>
                        {
                            config.SetBasePath(Directory.GetCurrentDirectory());
                            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                        })
                        .ConfigureServices((context, services) =>
                        {
                            services.Configure<Connection>(context.Configuration.GetSection("SqlConnection"));
                            typeof(MainWindow).RegisterCascading(services, () => services.AddSingleton<MainWindow>());
                        })
                        .Build();
        }

        protected override async void OnStartup(StartupEventArgs e) // to override OnStartup remove StartupUri="MainWindow.xaml" from app.xaml
        {
            await _host!.StartAsync();

            ProjectManagerViewModel dataContext = _host.Services.GetRequiredService<ProjectManagerViewModel>();
            MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();

            mainWindow.DataContext = dataContext;
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host!.StopAsync(TimeSpan.FromSeconds(5));
            _host!.Dispose();
            base.OnExit(e);
        }
    }
}
