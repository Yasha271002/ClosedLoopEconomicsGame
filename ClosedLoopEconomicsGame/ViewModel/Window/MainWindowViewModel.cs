using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ClosedLoopEconomicsGame.Helpers;
using System.Windows.Threading;
using Core;

namespace ClosedLoopEconomicsGame.ViewModel.Window
{
    public class MainWindowViewModel : ObservableObject
    {
        private BaseInactivityHelper _inactivity = new BaseInactivityHelper(120);
        DispatcherTimer _timer = new DispatcherTimer();
        private int _sec = 0;


        public MainWindowViewModel()
        {
            _inactivity.OnInactivity += InactivityOnOnInactivity;
            ExplorerHelper.KillExplorer();
        }

        private void InactivityOnOnInactivity(int inactivitytime)
        {
            if (NavigationManager.Instance.IsPopupOpen)
                CommonCommands.ClosePopupCommand.Execute(null);
            CommonCommands.NavigateCommand.Execute(PageTypes.MainPage);
        }

        private void Timer(object sender, EventArgs eventArgs)
        {
            _sec++;
            if (_sec >= 7)
            {
                ExplorerHelper.RunExplorer();
                Application.Current.Shutdown();
            }
        }

        public ICommand StartTimer => GetOrCreate(new RelayCommand(f =>
        {
            _timer?.Stop();
            _sec = 0;
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer;
            _timer.Start();
        }));
        
        public ICommand StopTimer => GetOrCreate(new RelayCommand(f =>
        {
            _timer.Tick -= Timer;
            _timer.Stop();
            _sec = 0;
        }));
    }
}
