using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ClosedLoopEconomicsGame.Helpers;
using ClosedLoopEconomicsGame.Model;
using Core;

namespace ClosedLoopEconomicsGame.ViewModel.Pages
{
    public class AfterGameViewModel : ObservableObject
    {
        public bool IsClicked
        {
            get => GetOrCreate<bool>();
            set => SetAndNotify(value);
        }

        private ObservableCollection<RecycleCircleInfoModel> CategoryInfos
        {
            get => GetOrCreate<ObservableCollection<RecycleCircleInfoModel>>();
            set => SetAndNotify(value);
        }

        public AfterGameViewModel()
        {
            IsClicked = true;
            var helper = new ReadJsonHelper();
            var categories = helper.ReadJsonFromFile<ObservableCollection<RecycleCircleInfoModel>>("Content/AllCategoryInfo.json");
            CategoryInfos = new ObservableCollection<RecycleCircleInfoModel>(categories);
        }

        public ICommand HideContentCommand => GetOrCreate(new RelayCommand(f =>
        {
            IsClicked = false;
        }));

        public ICommand OpenCategoryInfoCommand => GetOrCreate(new RelayCommand(f =>
        {
            if (f is not string category) return;

            var selectedCategoryInfo = CategoryInfos.FirstOrDefault(c => c.CategoryName == category);

            if (selectedCategoryInfo == null) return;
            CommonCommands.OpenPopupCommand.Execute(selectedCategoryInfo);
        }));
    }
}
