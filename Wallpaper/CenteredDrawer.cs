using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WallPaperSeven.Wallpaper
{
    class CenteredDrawer : IDrawer
    {
        public void Draw(System.Drawing.Graphics gs, WallpaperConfiguration conf)
        {
            Point screenCenter = new Point(conf.Bounds.Width / 2, conf.Bounds.Height / 2);
            Size imageSize = conf.Image.Size;
            Point imageOrigin = new Point(
                conf.Bounds.X + screenCenter.X - (imageSize.Width / 2),
                conf.Bounds.Y + screenCenter.Y - (imageSize.Height / 2));
            gs.DrawImageUnscaledAndClipped(conf.Image, new Rectangle(
                imageOrigin, conf.Image.Size));
        }
    }
}
