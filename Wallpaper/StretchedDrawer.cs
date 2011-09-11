using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WallPaperSeven.Wallpaper
{
    class StretchedDrawer : IDrawer
    {
        public void Draw(System.Drawing.Graphics gs, WallpaperConfiguration conf)
        {
            gs.DrawImage(conf.Image, conf.Bounds);
        }
    }
}
