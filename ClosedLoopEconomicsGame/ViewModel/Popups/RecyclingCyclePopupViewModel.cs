using ClosedLoopEconomicsGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClosedLoopEconomicsGame.Helpers;
using Core;

namespace ClosedLoopEconomicsGame.ViewModel.Popups
{
    public class RecyclingCyclePopupViewModel:ObservableObject
    {
        public RecycleCircleInfoModel CircleInfoModel
        {
            get => GetOrCreate<RecycleCircleInfoModel>();
            set => SetAndNotify(value);
        }

        public RecyclingCyclePopupViewModel(RecycleCircleInfoModel circleInfoModel)
        {
            CircleInfoModel = circleInfoModel;
        }

        public ICommand OpenInfoPopupCommand => GetOrCreate(new RelayCommand(f =>
        {
            var categoryModel = CircleInfoModel.Category;
            CommonCommands.OpenPopupCommand.Execute(categoryModel);
        }));
    }
}
