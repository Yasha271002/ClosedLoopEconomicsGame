//using System.Windows.Input;

//namespace GameControls.Views.Controls
//{
//    /// <summary>
//    /// Логика взаимодействия для GameObjectContainer.xaml
//    /// </summary>
//    public partial class GameObjectContainer : UserControl
//    {
//        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
//            nameof(ImageSource), typeof(ImageSource), typeof(GameObjectContainer), new PropertyMetadata(default(ImageSource)));

//        public ImageSource ImageSource
//        {
//            get => (ImageSource) GetValue(ImageSourceProperty);
//            set => SetValue(ImageSourceProperty, value);
//        }

//        public static readonly DependencyProperty CategoryNameProperty = DependencyProperty.Register(
//            nameof(CategoryName), typeof(string), typeof(GameObjectContainer), new PropertyMetadata(default(string)));

//        public string CategoryName
//        {
//            get => (string) GetValue(CategoryNameProperty);
//            set => SetValue(CategoryNameProperty, value);
//        }

//        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
//            nameof(Command), typeof(ICommand), typeof(GameObjectContainer), new PropertyMetadata(default(ICommand)));

//        public ICommand Command
//        {
//            get => (ICommand) GetValue(CommandProperty);
//            set => SetValue(CommandProperty, value);
//        }

//        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
//            nameof(CommandParameter), typeof(object), typeof(GameObjectContainer), new PropertyMetadata(default(object)));

//        public object CommandParameter
//        {
//            get => (object) GetValue(CommandParameterProperty);
//            set => SetValue(CommandParameterProperty, value);
//        }

//        public static readonly DependencyProperty AnswerCorrectnessDisplayControlProperty = DependencyProperty.Register(
//            nameof(AnswerCorrectnessDisplayControl), typeof(AnswerCorrectnessDisplayControl), typeof(GameObjectContainer), new PropertyMetadata(default(AnswerCorrectnessDisplayControl)));

//        public AnswerCorrectnessDisplayControl AnswerCorrectnessDisplayControl
//        {
//            get => (AnswerCorrectnessDisplayControl) GetValue(AnswerCorrectnessDisplayControlProperty);
//            set => SetValue(AnswerCorrectnessDisplayControlProperty, value);
//        }

//        public GameObjectContainer()
//        {
//            InitializeComponent();

//            AnswerCorrectnessDisplayControl = new AnswerCorrectnessDisplayControl();

//            this.Loaded += (_, _) =>
//            {
//                if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
//                    DesignBorder.Visibility = Visibility.Collapsed;
//            };
//        }
//    }
//}
