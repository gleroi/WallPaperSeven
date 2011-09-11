using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;

namespace WallPaperSeven.Wallpaper
{
    class WallpaperServiceException : Exception
    {
        public WallpaperServiceException()
        { }

        public WallpaperServiceException(string msg)
            : base(msg)
        { }

        public WallpaperServiceException(string msg, Exception inner)
            : base(msg, inner)
        { }
    }

    public class WallpaperService
    {
        public WallpaperService()
        {
            Initialize();
        }

        WallpaperConfiguration Configuration { get; set; }
        Dictionary<Style, IDrawer> Drawers { get; set; }

        public void Initialize() 
        {
            Drawers = new Dictionary<Style, IDrawer>()
            {
                { Style.Centered, new CenteredDrawer() },
                { Style.Stretched, new StretchedDrawer() },
                { Style.Tiled, new TiledDrawer() }
            };
        }

        public void Configure(WallpaperConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Run()
        {
            if (Configuration == null) throw new WallpaperServiceException("Configuration is null. Call Wallpaper.Configure()");

            SetWallpaper();
        }

        public void Stop()
        {

        }

        /// <summary>
        /// Set the wallpaper depending on the configurations in the property <c>Wallpapers</c>
        /// </summary>
        /// <returns>return true if the wallpaper has been set</returns>
        protected bool SetWallpaper()
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
        protected string GenerateWallpaper()
        {
            string path = Path.GetTempFileName();

            // create an image for virtual screen
            Image image = new Bitmap(Configuration.VirtualScreenBounds.Width, 
                Configuration.VirtualScreenBounds.Height);
            Graphics gs = Graphics.FromImage(image);

            // generate an image based on the described configuration
            foreach (ScreenConfiguration wallConf in Configuration.Screens)
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
