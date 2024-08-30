using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MainComponents.Commands;
using MainComponents.Helpers;

namespace GameLibrary.Helpers
{
    public static class CommonCommands
    {
        public static ICommand CloseAppCommand { get; } = new RelayCommand(obj =>
        {
            Application.Current.Shutdown();
        });

        public static ICommand NavigateCommand { get; } = new RelayCommand(obj =>
        {
            if (obj is not PageProvider pageProvider)
                return;

            NavigationManager.MainFrame.Navigate(pageProvider.GetPage());
        });
    }
}
