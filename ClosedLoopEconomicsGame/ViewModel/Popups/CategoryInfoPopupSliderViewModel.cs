using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedLoopEconomicsGame.Model;
using Core;

namespace ClosedLoopEconomicsGame.ViewModel.Popups
{
    public class CategoryInfoPopupSliderViewModel : ObservableObject
    {
        public ObservableCollection<string> ImagePaths
        {
            get => GetOrCreate<ObservableCollection<string>>();
            set => SetAndNotify(value);
        }

        public CategoryInfoPopupSliderViewModel(CategoryInfoModel categoryInfo, string selectedImagePath)
        {
            var paths = categoryInfo.GetImagePaths();
            ImagePaths = new ObservableCollection<string>(paths);

            if (string.IsNullOrEmpty(selectedImagePath) || !ImagePaths.Contains(selectedImagePath)) return;
            ImagePaths.Remove(selectedImagePath);
            ImagePaths.Insert(0, selectedImagePath);
        }
    }
}
