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
                @"C:\Users\gleroi\Pictures\Wallpapers\Fractal-flowers-1440x900.jpg"
            };
            Manager manager = new Manager();

            if (manager.Wallpapers.Count != args.Length)
                throw new ArgumentException("args : need at least " + manager.Wallpapers.Count + " paths");

            int idx = 0;
            foreach (WallpaperConfiguration conf in manager.Wallpapers)
            {
                conf.Image = Image.FromFile(args[idx]);
                conf.Style = Style.Tiled;
                idx++;
            }

            if (manager.SetWallpaper())
                Debug.WriteLine("Ok!");
            else
                Debug.WriteLine("Failed!");
        }
    }
}
