using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClosedLoopEconomicsGame.Helpers;
using ClosedLoopEconomicsGame.Model;
using Core;

namespace ClosedLoopEconomicsGame.ViewModel.Popups
{
    public class ResultGamePopupViewModel : ObservableObject
    {
        public ResultGameModel ResultGameModel
        {
            get => GetOrCreate<ResultGameModel>();
            set => SetAndNotify(value);
        }

        public ResultGamePopupViewModel(ResultGameModel resultGameModel)
        {
            ResultGameModel = resultGameModel;
        }

        public ICommand ClosePopupCommand => GetOrCreate(new RelayCommand(f =>
        {
            CommonCommands.ClosePopupCommand.Execute(null);
            CommonCommands.NavigateCommand.Execute(ResultGameModel.Replay == true
                ? PageTypes.StartGamePage
                : PageTypes.AfterGamePage);
        }));
    }
}
