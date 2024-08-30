//using System.Windows.Input;

//namespace GameControls.Views.Controls
//{
//    /// <summary>
//    /// Логика взаимодействия для GameObject.xaml
//    /// </summary>
//    public partial class GameObject : UserControl
//    {
//        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register(
//            nameof(Model), typeof(GameObjectModel), typeof(GameObject), new PropertyMetadata(default(GameObjectModel)));

//        public GameObjectModel Model
//        {
//            get => (GameObjectModel) GetValue(ModelProperty);
//            set => SetValue(ModelProperty, value);
//        }

//        public static readonly DependencyProperty XProperty = DependencyProperty.Register(
//            nameof(X), typeof(double), typeof(GameObject), new PropertyMetadata(default(double)));

//        public double X
//        {
//            get => (double) GetValue(XProperty);
//            set => SetValue(XProperty, value);
//        }

//        public static readonly DependencyProperty YProperty = DependencyProperty.Register(
//            nameof(Y), typeof(double), typeof(GameObject), new PropertyMetadata(default(double)));

//        public double Y
//        {
//            get => (double) GetValue(YProperty);
//            set => SetValue(YProperty, value);
//        }

//        public static readonly DependencyProperty SelectCommandProperty = DependencyProperty.Register(
//            nameof(SelectCommand), typeof(ICommand), typeof(GameObject), new PropertyMetadata(default(ICommand)));

//        public ICommand SelectCommand
//        {
//            get => (ICommand) GetValue(SelectCommandProperty);
//            set => SetValue(SelectCommandProperty, value);
//        }

//        public static readonly DependencyProperty AnswerCorrectnessDisplayControlProperty = DependencyProperty.Register(
//            nameof(AnswerCorrectnessDisplayControl), typeof(AnswerCorrectnessDisplayControl), typeof(GameObject), new PropertyMetadata(default(AnswerCorrectnessDisplayControl)));

//        public AnswerCorrectnessDisplayControl AnswerCorrectnessDisplayControl
//        {
//            get => (AnswerCorrectnessDisplayControl) GetValue(AnswerCorrectnessDisplayControlProperty);
//            set => SetValue(AnswerCorrectnessDisplayControlProperty, value);
//        }

//        public GameObject()
//        {
//            InitializeComponent();

//            AnswerCorrectnessDisplayControl = new AnswerCorrectnessDisplayControl();
//        }

//        public void Move(double offsetX, double offsetY, Action<GameObject>? callback = null)
//        {
//            var offsetXAnimation = GetOffsetAnimation(offsetX);
//            var offsetYAnimation = GetOffsetAnimation(offsetY);

//            Storyboard.SetTargetName(offsetXAnimation, "ObjectTranslateTransform");
//            Storyboard.SetTargetProperty(offsetXAnimation, new PropertyPath(TranslateTransform.XProperty));

//            Storyboard.SetTargetName(offsetYAnimation, "ObjectTranslateTransform");
//            Storyboard.SetTargetProperty(offsetYAnimation, new PropertyPath(TranslateTransform.YProperty));

//            var storyboard = new Storyboard();
//            storyboard.Children.Clear();
//            storyboard.Children.Add(offsetXAnimation);
//            storyboard.Children.Add(offsetYAnimation);

//            storyboard.Completed += (_, _) =>
//            {
//                callback?.Invoke(this);
//            };

//            storyboard.Begin(this);
//        }

//        public void Hide(Action<GameObject>? callback = null)
//        {
//            var hideAnimation = GetHideAnimation(0);

//            Storyboard.SetTarget(hideAnimation, this);
//            Storyboard.SetTargetProperty(hideAnimation, new PropertyPath(FrameworkElement.OpacityProperty));

//            var storyboard = new Storyboard();
//            storyboard.Children.Clear();
//            storyboard.Children.Add(hideAnimation);

//            storyboard.Completed += (_, _) =>
//            {
//                callback?.Invoke(this);
//            };

//            storyboard.Begin(this);
//        }

//        private DoubleAnimation GetOffsetAnimation(double offset)
//        {
//            return new DoubleAnimation
//            {
//                To = offset,
//                Duration = TimeSpan.FromMilliseconds(500),
//                AccelerationRatio = 0.3,
//                DecelerationRatio = 0.7
//            };
//        }

//        private DoubleAnimation GetHideAnimation(double targetOpacity)
//        {
//            return new DoubleAnimation
//            {
//                To = targetOpacity,
//                Duration = TimeSpan.FromMilliseconds(500),
//                AccelerationRatio = 0.3,
//                DecelerationRatio = 0.7
//            };
//        }

//        //private ICommand? _onSelectCommand;

//        //public ICommand OnSelectCommand => _onSelectCommand ??= new RelayCommand(obj =>
//        //{

//        //});
//    }
//}
