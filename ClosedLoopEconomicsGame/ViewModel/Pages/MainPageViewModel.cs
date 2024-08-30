using System.Windows;
using System.Windows.Input;
using ClosedLoopEconomicsGame.Helpers;
using Core;

namespace ClosedLoopEconomicsGame.ViewModel.Pages
{
    public class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel(){}

        public ICommand ExitButtonCommand => GetOrCreate(new RelayCommand(f =>
        {
            ExplorerHelper.RunExplorer();
            Application.Current.Shutdown();
        }));
    }
}
