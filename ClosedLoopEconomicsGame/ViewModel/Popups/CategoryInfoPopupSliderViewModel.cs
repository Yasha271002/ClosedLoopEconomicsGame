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
        public ObservableCollection<string> ImagePath
        {
            get => GetOrCreate<ObservableCollection<string>>();
            set => SetAndNotify(value);
        }

        public CategoryInfoPopupSliderViewModel(CategoryInfoModel categoryInfo)
        {
            ImagePath = new ObservableCollection<string>();
            ImagePath.Clear();

            ImagePath.Add(categoryInfo.TopImagePath!);
            ImagePath.Add(categoryInfo.LeftImagePath!);
            ImagePath.Add(categoryInfo.RightImagePath!);
            ImagePath.Add(categoryInfo.BottomImagePath!);
        }

        
    }
}
