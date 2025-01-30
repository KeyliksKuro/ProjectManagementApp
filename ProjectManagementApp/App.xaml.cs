using ProjectManagementApp.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ProjectManagementApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindowVM mainWindowVM = new MainWindowVM();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainWindowVM;
            mainWindow.Show();
        }
    }

}
