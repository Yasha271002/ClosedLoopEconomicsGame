using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using ClosedLoopEconomicsGame.Helpers;
using ClosedLoopEconomicsGame.Helpers.GameHelpers;
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
            this.Loaded += (_, _) =>
            {
                Logger.Add(new FileLoggingService("logs"));

                SoundHelper.Load();
                ContentManager.LoadContent();

                NavigationManager.MainFrame = MainFrame.NavigationService;
            };
        }

        private void PopupFrame_OnInitialized(object? sender, EventArgs e)
        {
            if (sender is not Frame frame) return;
            NavigationManager.PopupFrame = frame.NavigationService;
        }

        
    }
}