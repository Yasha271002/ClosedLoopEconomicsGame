using System.Windows;
using System.Windows.Input;
using Core;

namespace ClosedLoopEconomicsGame.ViewModel.Pages
{
    public class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel(){}

        public ICommand ExitButtonCommand => GetOrCreate(new RelayCommand(f =>
        {
            Application.Current.Shutdown();
        }));
    }
}
