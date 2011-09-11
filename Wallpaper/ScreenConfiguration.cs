using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WallPaperSeven.Wallpaper
{
    public enum Style : int
    {
        Centered,
        Tiled,
        Stretched
    }

    public class ScreenConfiguration
    {
        public ScreenConfiguration(Screen screen, Rectangle location)
        {
            this.screen = screen;
            this.bounds = location;
        }

        public string ImagePath { get; set; }
        public Style Style { get; set; }

        readonly Rectangle bounds;
        /// <summary>
        /// Position of the screen relatively to the virtual screen
        /// </summary>
        public Rectangle Bounds 
        {
            get { return bounds; }
        }

        readonly Screen screen = null;
        public Screen Screen
        {
            get { return screen; }
        }

    }
}
