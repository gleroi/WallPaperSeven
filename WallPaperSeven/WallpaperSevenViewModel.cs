using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using WallPaperSeven.ScreenConfiguration;
using Model = WallPaperSeven.Wallpaper;
using System.Windows.Input;
using WallPaperSeven.Utils;
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
            WallPaperManager = new Model.WallpaperConfiguration();
            ScreenConfigurations = new ObservableCollection<ScreenConfigurationViewModel>();

            foreach (Model.ScreenConfiguration config in WallPaperManager.Screens)
            {
                ScreenConfigurations.Add(new ScreenConfigurationViewModel(config));
            }
        }

        public Model.WallpaperConfiguration WallPaperManager { get; set; }
        public ObservableCollection<ScreenConfigurationViewModel> ScreenConfigurations { get; set; }

        #region ApplyConfigurationCommand

        ICommand applyConfigurationCommand = null;
        public ICommand ApplyConfigurationCommand 
        {
            get
            {
                if (applyConfigurationCommand == null)
                {
                    applyConfigurationCommand = new DelegateCommand(
                        param => this.ApplyConfiguration(),
                        param => true
                    );
                }
                return applyConfigurationCommand;
            }
        }

        private void ApplyConfiguration()
        {
            WallpaperService service = new WallpaperService();
            service.Configure(WallPaperManager);
            service.Run();
        }

        #endregion

    }
}
