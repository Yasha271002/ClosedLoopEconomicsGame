using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ClosedLoopEconomicsGame.Model;
using ClosedLoopEconomicsGame.View.Pages;
using ClosedLoopEconomicsGame.View.Popups;
using ClosedLoopEconomicsGame.ViewModel.Popups;
using RelayCommand = Core.RelayCommand;

namespace ClosedLoopEconomicsGame.Helpers
{

    public static class CommonCommands
    {
        private static Page? GetPageByType(PageTypes pageType)
        {
            return pageType switch
            {
                PageTypes.None => null,
                PageTypes.MainPage => new MainPage(),
                PageTypes.StartGamePage => new StartGamePage(),
                PageTypes.AfterGamePage => new AfterGamePage(),
                PageTypes.GamePage => new GamePage(),
                _ => null
            };
        }

        private static Page? GetPageByContent(object content)
        {
            Page? page = content switch
            {
                _ => null
            };
            return page;
        }

        public static ICommand NavigateCommand { get; } = new RelayCommand(f =>
        {
            Page? page;
            if (f is PageTypes pageType)
            {
                page = GetPageByType(pageType);
            }
            else
            {
                page = GetPageByContent(f);
            }

            if (page == null) return;
            NavigationManager.MainFrame.Navigate(page);

        });

        private static UserControl? GetPopupByType(PopupTypes popupType)
        {
            return popupType switch
            {
                _ => null
            };
        }

        public static ICommand? GoBackCommand { get; } =
            new RelayCommand(f => { NavigationManager.MainFrame.GoBack(); });

        public static ICommand? GoBackPopupCommand { get; } = new RelayCommand(f =>
        {
            NavigationManager.PopupFrame.GoBack();
        });

        public static ICommand ClosePopupCommand { get; } =
            new RelayCommand(obj => { NavigationManager.ClosePopup(); });

        public static ICommand OpenPopupCommand { get; } = new RelayCommand(obj =>
        {
            var popup = GetPopupByContent(obj);

            if (popup is null)
                return;

            NavigationManager.PopupFrame?.Navigate(popup);
            NavigationManager.Instance.IsPopupOpen = true;
        });

        public static ICommand OpenPopupByTypeCommand { get; } = new RelayCommand(obj =>
        {
            if (obj is PopupTypes popupType)
            {
                var popup = GetPopupByType(popupType);

                if (popup is null)
                    return;

                NavigationManager.PopupFrame?.Navigate(popup);
                NavigationManager.Instance.IsPopupOpen = true;
            }
        });

        private static UserControl? GetPopupByContent(object content)
        {
            return content switch
            {
                ExitGamePopupViewModel _ => new ExitGamePopup { DataContext = content },
                PopupParametersHelper parameters =>
                    new CategoryInfoPopupSlider { DataContext = new CategoryInfoPopupSliderViewModel(parameters.CategoryInfo, parameters.SelectedImagePath) },
                RecycleCircleInfoModel categoryInfo =>
                    new RecyclingCyclePopup { DataContext = new RecyclingCyclePopupViewModel(categoryInfo) },
                ResultGameModel resultGameModel => new ResultGamePopup{ DataContext = new ResultGamePopupViewModel(resultGameModel)},
                _ => null
            };
        }


    }
}