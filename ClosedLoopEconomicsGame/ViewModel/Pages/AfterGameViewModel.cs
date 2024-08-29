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
        public double Opacity
        {
            get => GetOrCreate(1.0);
            set => SetAndNotify(value);
        }

        public bool IsEnabled
        {
            get => GetOrCreate<bool>();
            set => SetAndNotify(value);
        }

        public Visibility Visibility
        {
            get => GetOrCreate(Visibility.Visible);
            set => SetAndNotify(value);
        }

        private ObservableCollection<RecycleCircleInfoModel> CategoryInfos
        {
            get => GetOrCreate<ObservableCollection<RecycleCircleInfoModel>>();
            set => SetAndNotify(value);
        }

        public AfterGameViewModel()
        {
            IsEnabled = true;
            var helper = new ReadJsonHelper();
            var categories = helper.ReadJsonFromFile<ObservableCollection<RecycleCircleInfoModel>>("Content/AllCategoryInfo.json");
            CategoryInfos = new ObservableCollection<RecycleCircleInfoModel>(categories);
        }

        private async void StartOpacityAnimation()
        {
            for (double i = 1.0; i >= 0.0; i -= 0.1)
            {
                Opacity = i;
                await Task.Delay(70); 
            }

            Visibility = Visibility.Hidden;
        }

        public ICommand HiddenKidCommand => GetOrCreate(new RelayCommand(f =>
        {
            IsEnabled = false;
            StartOpacityAnimation();
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
