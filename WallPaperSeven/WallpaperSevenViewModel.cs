using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using WallPaperSeven.ScreenConfiguration;
using WallPaperSeven.Wallpaper;

namespace WallPaperSeven
{
    class WallpaperSevenViewModel
    {
        public WallpaperSevenViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            WallPaperManager = new Manager();
            ScreenConfigurations = new ObservableCollection<ScreenConfigurationViewModel>();

            foreach (WallpaperConfiguration config in WallPaperManager.Wallpapers)
            {
                ScreenConfigurations.Add(new ScreenConfigurationViewModel());
            }
        }

        public Manager WallPaperManager { get; set; }
        public ObservableCollection<ScreenConfigurationViewModel> ScreenConfigurations { get; set; }

    }
}
