using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace WallPaperSeven.Wallpaper
{
    /// <summary>
    /// Manage the association of wallpaper <-> screen.
    /// Build the overall image.
    /// <remarks>This method suppose that screens are organized horizontally</remarks>
    /// </summary>
    public class WallpaperConfiguration
    {
        public WallpaperConfiguration()
        {
            Initialize();
        }

        public List<ScreenConfiguration> Screens { get; set; }
        public Rectangle VirtualScreenBounds { get; set; }

        /// <summary>
        /// Initialize the wallpapers instance with the available screens
        /// </summary>
        private void Initialize()
        {
            List<Screen> screens = new List<Screen>(Screen.AllScreens);
            
            // get virtual screen size
            List<Rectangle> screenSizes = screens.ConvertAll(screen => screen.Bounds);
            VirtualScreenBounds = new Rectangle(0, 0,
                screenSizes.Sum(size => size.Width),
                screenSizes.Max(size => size.Height));

            Screens = new List<ScreenConfiguration>();
            int xpos = 0;
            foreach (Screen screen in screens)
            {
                Screens.Add(new ScreenConfiguration(screen,
                    new Rectangle(xpos, 0, screen.Bounds.Width, screen.Bounds.Height)));
                xpos += screen.Bounds.Width;
            }
        }
        
    }
}
