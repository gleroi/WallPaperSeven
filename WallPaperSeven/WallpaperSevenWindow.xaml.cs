using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace WallPaperSeven
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WallpaperSevenWindow : Window
    {
        public WallpaperSevenWindow()
        {
            InitializeComponent();

            SystemTrayIcon = new NotifyIcon();
            SystemTrayIcon.Icon = new System.Drawing.Icon(WallPaperSeven.Properties.Resources.app_icon, 32, 32);
            SystemTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(SystemTrayIcon_MouseDoubleClick);
        }

        void SystemTrayIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            WindowState = System.Windows.WindowState.Normal;
        }

        public NotifyIcon SystemTrayIcon { get; set; }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                SystemTrayIcon.BalloonTipTitle = "Minimize Sucessful";
                SystemTrayIcon.BalloonTipText = "Minimized the app ";
                SystemTrayIcon.ShowBalloonTip(400);
                SystemTrayIcon.Visible = true;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                SystemTrayIcon.Visible = false;
                this.ShowInTaskbar = true;
            }
        }

    }
}
