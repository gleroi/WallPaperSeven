using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using WallPaperSeven.Utils;
using System.Windows.Forms;
using System.IO;

namespace WallPaperSeven.ScreenConfiguration
{
    class ScreenConfigurationViewModel : ViewModelBase
    {
        public ScreenConfigurationViewModel(Wallpaper.ScreenConfiguration config)
        {
            ScreenConfig = config;
        }

        Wallpaper.ScreenConfiguration ScreenConfig { get; set; }

        string sourceDirectoryPath = null;
        public string SourceDirectoryPath {
            get
            {
                return sourceDirectoryPath;
            }
            set
            {
                if (sourceDirectoryPath != value)
                {
                    sourceDirectoryPath = value;
                    UpdateAvailableImages(sourceDirectoryPath);
                    OnPropertyChanged("SourceDirectoryPath");
                }
            }
        }

        private void UpdateAvailableImages(string path)
        {
            if (!Directory.Exists(path)) throw new ArgumentException("directory path does not exist");

            List<string> paths = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
                .Where(filepath => filepath.EndsWith(".png") || filepath.EndsWith(".jpg") ||
                    filepath.EndsWith(".bmp") || filepath.EndsWith(".jpeg")).ToList();
            AvailableImages = new ObservableCollection<ImageViewModel>();
            foreach (string imagePath in paths)
            {
                ImageViewModel model = new ImageViewModel();
                model.Path = imagePath;
                AvailableImages.Add(model);
            }
        }

        ObservableCollection<ImageViewModel> availableImages = null;
        public ObservableCollection<ImageViewModel> AvailableImages {
            get { return availableImages; }
            set
            {
                if (availableImages != value)
                {
                    availableImages = value;
                    OnPropertyChanged("AvailableImages");
                }
            }
        }

        ImageViewModel selectedImage = null;
        public ImageViewModel SelectedImage {
            get { return selectedImage; }
            set
            {
                if (selectedImage != value)
                {
                    selectedImage = value;
                    ScreenConfig.ImagePath = selectedImage.Path;
                    OnPropertyChanged("SelectedImage");
                }
            }
        }

        Wallpaper.Style selectedStyle;
        public Wallpaper.Style SelectedStyle {
            get { return selectedStyle; }
            set
            {
                if (selectedStyle != value)
                {
                    selectedStyle = value;
                    ScreenConfig.Style = selectedStyle;
                    OnPropertyChanged("SelectedStyle");
                }
            }
        }

        #region SearchDirectoryCommand

        ICommand searchDirectoryCommand = null;
        public ICommand SearchDirectoryCommand
        {
            get
            {
                if (searchDirectoryCommand == null)
                {
                    searchDirectoryCommand = new DelegateCommand(
                        param => this.SearchDirectory(),
                        param => true
                    );
                }
                return searchDirectoryCommand;
            }
        }

        private void SearchDirectory()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                SourceDirectoryPath = dialog.SelectedPath;
            }
        }

        #endregion
    }
}
