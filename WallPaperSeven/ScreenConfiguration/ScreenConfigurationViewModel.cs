using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace WallPaperSeven.ScreenConfiguration
{
    class ScreenConfigurationViewModel
    {
        public string SourceDirectoryPath { get; set; }
        public ObservableCollection<ImageViewModel> AvailableImages { get; set; }
        public ImageViewModel SelectedImage { get; set; }
        public List<Wallpaper.Style> AvailableStyles { get; set; }
        public Wallpaper.Style SelectedStyle { get; set; }

        public ICommand SearchDirectoryCommand { get; set; }
    }
}
