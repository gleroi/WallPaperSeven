using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WallPaperSeven.Wallpaper
{
    class TiledDrawer : IDrawer
    {
        public void Draw(System.Drawing.Graphics gs, WallpaperConfiguration conf)
        {
            Rectangle tile = new Rectangle(conf.Bounds.X, conf.Bounds.Y,
                conf.Image.Size.Width, conf.Image.Size.Height);
            int xtiles = (int)Math.Ceiling((double)conf.Bounds.Width / (double)tile.Width);
            int ytiles = (int)Math.Ceiling((double)conf.Bounds.Height / (double)tile.Height);
            for (int x = 0; x < xtiles; x++)
                for (int y = 0; y < ytiles; y++)
                {
                    tile.X = conf.Bounds.X + x * tile.Width;
                    tile.Y = conf.Bounds.Y + y * tile.Height;
                    gs.DrawImage(conf.Image, tile);
                }
        }
    }
}
