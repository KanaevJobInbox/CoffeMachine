using System;
using System.Windows;

using CoffeMachine.ViewModel;

namespace CoffeMachine.View
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            ViewMainWindow viewMain = new ViewMainWindow();

            MainWindow main = new MainWindow();
            main.DataContext = viewMain;
            main.Show();
        }
    }
}
