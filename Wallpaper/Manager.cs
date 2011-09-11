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
    public class Manager
    {
        public Manager()
        {
            Initialize();
        }

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

            Wallpapers = new List<WallpaperConfiguration>();
            int xpos = 0;
            foreach (Screen screen in screens)
            {
                Wallpapers.Add(new WallpaperConfiguration(screen,
                    new Rectangle(xpos, 0, screen.Bounds.Width, screen.Bounds.Height)));
                xpos += screen.Bounds.Width;
            }

            Drawers = new Dictionary<Style, IDrawer>()
            {
                { Style.Centered, new CenteredDrawer() },
                { Style.Stretched, new StretchedDrawer() },
                { Style.Tiled, new TiledDrawer() }
            };
        }

        Dictionary<Style, IDrawer> Drawers { get; set; }

        public List<WallpaperConfiguration> Wallpapers { get; set; }
        public Rectangle VirtualScreenBounds { get; set; }


        /// <summary>
        /// Set the wallpaper depending on the configurations in the property <c>Wallpapers</c>
        /// </summary>
        /// <returns>return true if the wallpaper has been set</returns>
        public bool SetWallpaper()
        {
            try
            {
                string generatedPath = GenerateWallpaper();
                // set the wallpaper
                WallpaperHelper.Set(generatedPath, Style.Tiled);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error while setting wallpaper :" + ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Combine image of WallpaperConfiguration into one big image.
        /// 
        /// </summary>
        /// <returns></returns>
        public string GenerateWallpaper()
        {
            string path = Path.GetTempFileName();

            // create an image for virtual screen
            Image image = new Bitmap(VirtualScreenBounds.Width, VirtualScreenBounds.Height);
            Graphics gs = Graphics.FromImage(image);

            // generate an image based on the described configuration
            foreach (WallpaperConfiguration wallConf in Wallpapers)
            {
                // draw image
                IDrawer drawer = Drawers[wallConf.Style];
                drawer.Draw(gs, wallConf);
                gs.Flush();
            }
            image.Save(path, ImageFormat.Jpeg);

            // clean up
            image.Dispose();
            gs.Dispose();

            return path;
        }
    }
}
