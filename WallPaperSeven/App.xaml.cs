using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace WallPaperSeven
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            WallpaperSevenWindow window = new WallpaperSevenWindow();
            window.DataContext = new WallpaperSevenViewModel();

            window.Show();
        }
    }
}
