using System.Windows.Controls;
using ClosedLoopEconomicsGame.Helpers;
using ClosedLoopEconomicsGame.Utilities.Logging;

namespace ClosedLoopEconomicsGame.View.Window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Logger.Add(new FileLoggingService("logs"));
            NavigationManager.MainFrame = MainFrame.NavigationService;
        }

        private void PopupFrame_OnInitialized(object? sender, EventArgs e)
        {
            if (sender is not Frame frame) return;
            NavigationManager.PopupFrame = frame.NavigationService;
        }
    }
}