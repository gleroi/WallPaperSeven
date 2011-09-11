using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using WallPaperSeven.Wallpaper;
using System.Diagnostics;

namespace WallpaperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[2] {
                //@"C:\Users\gleroi\Pictures\Wallpapers\abyss___chaotica_rendered_by_kr0mat1k-d31el6e.jpg",
                @"C:\Users\gleroi\Pictures\Wallpapers\abyss___chaotica_rendered_by_kr0mat1k-d31el6e.jpg",
                @"C:\Users\gleroi\Pictures\Wallpapers\fractal_19-wallpaper-1440x900.jpg"
            };
            WallpaperConfiguration configuration = new WallpaperConfiguration();

            if (configuration.Screens.Count != args.Length)
                throw new ArgumentException("args : need at least " + configuration.Screens.Count + " paths");

            int idx = 0;
            foreach (ScreenConfiguration conf in configuration.Screens)
            {
                conf.ImagePath = args[idx];
                conf.Style = Style.Tiled;
                idx++;
            }

            WallpaperService service = new WallpaperService();
            service.Configure(configuration);
            service.Run();
        }
    }
}
