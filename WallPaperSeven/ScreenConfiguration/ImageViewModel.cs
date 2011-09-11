using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using WallPaperSeven.Utils;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WallPaperSeven.ScreenConfiguration
{
    class ImageViewModel : ViewModelBase
    {
        string path = null;
        public string Path {
            get { return path; }
            set
            {
                if (path != value)
                {
                    path = value;
                    UpdateImageProperties(path);
                    OnPropertyChanged("Path");
                }
            }
        }

        private void UpdateImageProperties(string path)
        {
            Filename = System.IO.Path.GetFileName(path);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(path, UriKind.Absolute);
            image.DecodePixelHeight = 100;
            image.EndInit();
            Image = image;
        }

        string filename = null;
        public string Filename {
            get { return filename; }
            set
            {
                if (filename != value)
                {
                    filename = value;
                    OnPropertyChanged("Filename");
                }
            }
        }

        ImageSource image = null;
        public ImageSource Image
        {
            get { return image; }
            set
            {
                if (image != value)
                {
                    image = value;
                    OnPropertyChanged("Image");
                }
            }
        }
    }
}
