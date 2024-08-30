using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClosedLoopEconomicsGame.Helpers;
using ClosedLoopEconomicsGame.View.Controls.GameControls;
using Core;

namespace ClosedLoopEconomicsGame.ViewModel.Popups
{
    public class ExitGamePopupViewModel : ObservableObject
    {
        public ICountdownTimerController CountdownTimerController
        {
            get => GetOrCreate<ICountdownTimerController>();
            set => SetAndNotify(value);
        }

        public ExitGamePopupViewModel(ICountdownTimerController countdownTimerController)
        {
            CountdownTimerController = countdownTimerController;
        }

        public ICommand ClosePopupCommand => GetOrCreate(new RelayCommand(f =>
        {
            if (f is not string param) return;
            switch (param)
            {
                case "Выйти":
                    CountdownTimerController.Stop();
                    CommonCommands.ClosePopupCommand.Execute(null);
                    CommonCommands.NavigateCommand.Execute(PageTypes.MainPage);
                    break;
                case "Отмена":
                    CountdownTimerController.Start();
                    CommonCommands.ClosePopupCommand.Execute(null);
                    break;
            }
        }));
    }
}
