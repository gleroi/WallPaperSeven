using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WallPaperSeven.Wallpaper
{
    class StretchedDrawer : IDrawer
    {
        public void Draw(System.Drawing.Graphics gs, ScreenConfiguration conf)
        {
            using (Image image = Image.FromFile(conf.ImagePath))
                gs.DrawImage(image, conf.Bounds);
        }
    }
}
