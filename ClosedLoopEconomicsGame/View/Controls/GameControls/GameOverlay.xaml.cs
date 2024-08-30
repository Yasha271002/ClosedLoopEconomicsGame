using System.Windows;
using System.Windows.Controls;

namespace ClosedLoopEconomicsGame.View.Controls.GameControls
{
    public interface IGameOverlayController
    {
        Point GetPositionOfElement(FrameworkElement element);
        Point GetPositionOfElement(FrameworkElement element, Point point);
        Point GetPositionOfElementCenter(FrameworkElement element);
    }

    public partial class GameOverlay : UserControl, IGameOverlayController
    {
        public static readonly DependencyProperty ControllerProperty = DependencyProperty.Register(
            nameof(Controller), typeof(IGameOverlayController), typeof(GameOverlay),
            new FrameworkPropertyMetadata(default(IGameOverlayController), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public IGameOverlayController Controller
        {
            get => (IGameOverlayController) GetValue(ControllerProperty);
            set => SetValue(ControllerProperty, value);
        }

        public GameOverlay()
        {
            InitializeComponent();

            this.Loaded += (_, _) =>
            {
                Controller = this;
            };
        }

        public Point GetPositionOfElement(FrameworkElement element)
        {
            return element.TranslatePoint(new Point(), this);
        }

        public Point GetPositionOfElement(FrameworkElement element, Point point)
        {
            return element.TranslatePoint(point, this);
        }

        public Point GetPositionOfElementCenter(FrameworkElement element)
        {
            var centerOfElement = new Point(
                element.ActualWidth / 2,
                element.ActualHeight / 2);

            return element.TranslatePoint(centerOfElement, this);
        }
    }
}
