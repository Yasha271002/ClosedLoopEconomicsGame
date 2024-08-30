using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Core;

namespace ClosedLoopEconomicsGame.View.Controls.GameControls
{
    public interface IGameObjectAreaController
    {
        void ArrangeGameObjects(Size? areaSize = null);
        Point GetPositionOfElement(FrameworkElement element);
        Point GetPositionOfElementCenter(FrameworkElement element);
        Size GetSize();
    }

    public partial class GameObjectArea : UserControl, IGameObjectAreaController
    {
        public static readonly DependencyProperty ControllerProperty = DependencyProperty.Register(
            nameof(Controller), typeof(IGameObjectAreaController), typeof(GameObjectArea),
            new FrameworkPropertyMetadata(default(IGameObjectAreaController), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public IGameObjectAreaController Controller
        {
            get => (IGameObjectAreaController) GetValue(ControllerProperty);
            set => SetValue(ControllerProperty, value);
        }

        public static readonly DependencyProperty GameObjectWidthProperty = DependencyProperty.Register(
            nameof(GameObjectWidth), typeof(double), typeof(GameObjectArea), new PropertyMetadata(200.0));

        public double GameObjectWidth
        {
            get => (double) GetValue(GameObjectWidthProperty);
            set => SetValue(GameObjectWidthProperty, value);
        }

        public static readonly DependencyProperty GameObjectHeightProperty = DependencyProperty.Register(
            nameof(GameObjectHeight), typeof(double), typeof(GameObjectArea), new PropertyMetadata(200.0));

        public double GameObjectHeight
        {
            get => (double) GetValue(GameObjectHeightProperty);
            set => SetValue(GameObjectHeightProperty, value);
        }

        public static readonly DependencyProperty GameObjectsProperty = DependencyProperty.Register(
            nameof(GameObjects), typeof(ObservableCollection<GameObject>), typeof(GameObjectArea), new PropertyMetadata(default(ObservableCollection<GameObject>)));

        public ObservableCollection<GameObject> GameObjects
        {
            get => (ObservableCollection<GameObject>) GetValue(GameObjectsProperty);
            set => SetValue(GameObjectsProperty, value);
        }

        public static readonly DependencyProperty SelectedGameObjectProperty = DependencyProperty.Register(
            nameof(SelectedGameObject), typeof(GameObject), typeof(GameObjectArea),
            new FrameworkPropertyMetadata(default(GameObject), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public GameObject SelectedGameObject
        {
            get => (GameObject) GetValue(SelectedGameObjectProperty);
            set => SetValue(SelectedGameObjectProperty, value);
        }

        public static readonly DependencyProperty ExcludedAreasProperty = DependencyProperty.Register(
            nameof(ExcludedAreas), typeof(ObservableCollection<Rect>), typeof(GameObjectArea), new PropertyMetadata(default(ObservableCollection<Rect>)));

        public ObservableCollection<Rect> ExcludedAreas
        {
            get => (ObservableCollection<Rect>) GetValue(ExcludedAreasProperty);
            set => SetValue(ExcludedAreasProperty, value);
        }

        public GameObjectArea()
        {
            ExcludedAreas = new ObservableCollection<Rect>();

            InitializeComponent();

            this.Loaded += (_, _) =>
            {
                Controller = this;

                if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                {
                    DesignBorder.Visibility = Visibility.Collapsed;
                    ExcludedAreasItemsControl.Visibility = Visibility.Collapsed;
                }
            };
        }

        private ICommand? _gameObjectSelectCommand;
        public ICommand GameObjectSelectCommand => _gameObjectSelectCommand ??= new RelayCommand(obj =>
        {
            if (obj is not GameObject gameObject)
                return;

            SelectedGameObject = gameObject;

            GameObjects.Remove(gameObject);
            GameObjects.Add(gameObject);
        });

        public Point GetPositionOfElement(FrameworkElement element)
        {
            return element.TranslatePoint(new Point(), this);
        }

        public Point GetPositionOfElementCenter(FrameworkElement element)
        {
            var centerOfElement = new Point(
                element.ActualWidth / 2,
                element.ActualHeight / 2);

            return element.TranslatePoint(centerOfElement, this);
        }

        public Size GetSize()
        {
            return new Size(this.ActualWidth, this.ActualHeight);
        }

        public void ArrangeGameObjects(Size? areaSize = null)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var gameObjectAreaSize = areaSize ?? GetSize();
            var maxX = gameObjectAreaSize.Width - GameObjectWidth;
            var maxY = gameObjectAreaSize.Height - GameObjectHeight;

            foreach (var gameObject in GameObjects)
            {
                var x = random.NextDouble() * maxX;
                var y = random.NextDouble() * maxY;
                var gameObjectRect = new Rect(x, y, GameObjectWidth, GameObjectHeight);
                var numberOfTries = 500;

                while (GameObjectIntersectsWithExcludedAreas(gameObjectRect) ||
                       GameObjectIntersectsWithOtherObjects(gameObjectRect))
                {
                    if (numberOfTries <= 0)
                        break;

                    numberOfTries--;

                    x = random.NextDouble() * maxX;
                    y = random.NextDouble() * maxY;
                    gameObjectRect = new Rect(x, y, GameObjectWidth, GameObjectHeight);
                }

                numberOfTries = 500;

                while (GameObjectIntersectsWithExcludedAreas(gameObjectRect))
                {
                    if (numberOfTries <= 0)
                        break;

                    numberOfTries--;

                    x = random.NextDouble() * maxX;
                    y = random.NextDouble() * maxY;
                    gameObjectRect = new Rect(x, y, GameObjectWidth, GameObjectHeight);
                }

                gameObject.X = Math.Max(0, x);
                gameObject.Y = Math.Max(0, y);
            }
        }

        private bool GameObjectIntersectsWithOtherObjects(Rect targetGameObjectRect)
        {
            return GameObjects
                .Select(gameObject => new Rect(gameObject.X, gameObject.Y, GameObjectWidth, GameObjectHeight))
                .Any(gameObjectRect => Intersects(gameObjectRect, targetGameObjectRect));
                //.Any(targetGameObjectRect.IntersectsWith);
        }

        private bool GameObjectIntersectsWithExcludedAreas(Rect targetGameObjectRect)
        {
            return ExcludedAreas.Any(targetGameObjectRect.IntersectsWith);
        }

        private bool Intersects(Rect firstRect, Rect secondRect)
        {
            var distance = GetDistance(GetCenter(firstRect), GetCenter(secondRect));
            var firstRectMinSize = Math.Min(firstRect.Width, firstRect.Height);
            var secondRectMinSize = Math.Min(secondRect.Width, secondRect.Height);
            var minSize = Math.Min(firstRectMinSize, secondRectMinSize);

            return distance < minSize * 0.75;
        }

        private Point GetCenter(Rect rect)
        {
            return new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
        }

        private double GetDistance(Point p1, Point p2)
        {
            var offset = p1 - p2;

            return Math.Sqrt(Math.Pow(Math.Abs(offset.X), 2) + Math.Pow(Math.Abs(offset.Y), 2));
        }
    }
}
