using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WallPaperSeven.Wallpaper
{
    interface IDrawer
    {
        /// <summary>
        /// Draw the wallpaper using the config info and a position on the associated screen
        /// </summary>
        /// <param name="gs"></param>
        /// <param name="conf"></param>
        void Draw(Graphics gs, ScreenConfiguration conf);
    }
}
