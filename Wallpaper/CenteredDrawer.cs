using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WallPaperSeven.Wallpaper
{
    class CenteredDrawer : IDrawer
    {
        public void Draw(System.Drawing.Graphics gs, ScreenConfiguration conf)
        {
            using (Image image = Image.FromFile(conf.ImagePath))
            {
                Point screenCenter = new Point(conf.Bounds.Width / 2, conf.Bounds.Height / 2);
                Size imageSize = image.Size;
                Point imageOrigin = new Point(
                    conf.Bounds.X + screenCenter.X - (imageSize.Width / 2),
                    conf.Bounds.Y + screenCenter.Y - (imageSize.Height / 2));
                gs.DrawImageUnscaledAndClipped(image, new Rectangle(
                    imageOrigin, image.Size));
            }
        }
    }
}
