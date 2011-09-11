using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WallPaperSeven.Wallpaper
{
    class TiledDrawer : IDrawer
    {
        public void Draw(System.Drawing.Graphics gs, ScreenConfiguration conf)
        {
            using (Image image = Image.FromFile(conf.ImagePath))
            {
                Rectangle tile = new Rectangle(conf.Bounds.X, conf.Bounds.Y,
                    image.Size.Width, image.Size.Height);
                int xtiles = (int)Math.Ceiling((double)conf.Bounds.Width / (double)tile.Width);
                int ytiles = (int)Math.Ceiling((double)conf.Bounds.Height / (double)tile.Height);
                for (int x = 0; x < xtiles; x++)
                    for (int y = 0; y < ytiles; y++)
                    {
                        tile.Width = image.Size.Width;
                        tile.Height = image.Size.Height;
                        tile.X = conf.Bounds.X + x * tile.Width;
                        tile.Y = conf.Bounds.Y + y * tile.Height;

                        // if the tile a part of the tile is out of the screen, clip it
                        int xclip = (tile.X + tile.Width) - (conf.Bounds.X + conf.Bounds.Width);
                        if (xclip > 0)
                            tile.Width -= xclip;
                        int yclip = (tile.Y + tile.Height) - (conf.Bounds.Y + conf.Bounds.Height);
                        if (yclip > 0)
                            tile.Height -= yclip;

                        gs.DrawImageUnscaledAndClipped(image, tile);
                    }
            }
        }
    }
}
