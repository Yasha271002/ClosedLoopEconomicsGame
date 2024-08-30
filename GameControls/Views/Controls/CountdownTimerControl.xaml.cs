//namespace GameControls.Views.Controls
//{
//    public interface ICountdownTimerController
//    {
//        void Start();
//        void Start(TimeSpan interval);
//        void Stop();
//    }

//    public partial class CountdownTimerControl : UserControl, ICountdownTimerController
//    {
//        public static readonly DependencyProperty ControllerProperty = DependencyProperty.Register(
//            nameof(Controller), typeof(ICountdownTimerController), typeof(CountdownTimerControl),
//            new PropertyMetadata(default(ICountdownTimerController)));

//        public ICountdownTimerController Controller
//        {
//            get => (ICountdownTimerController) GetValue(ControllerProperty);
//            set => SetValue(ControllerProperty, value);
//        }

//        public static readonly DependencyProperty IntervalProperty = DependencyProperty.Register(
//            nameof(Interval), typeof(TimeSpan), typeof(CountdownTimerControl), new PropertyMetadata(default(TimeSpan)));

//        public TimeSpan Interval
//        {
//            get => (TimeSpan) GetValue(IntervalProperty);
//            set => SetValue(IntervalProperty, value);
//        }

//        public static readonly DependencyProperty RemainingTimeProperty = DependencyProperty.Register(
//            nameof(RemainingTime), typeof(TimeSpan), typeof(CountdownTimerControl),
//            new FrameworkPropertyMetadata(TimeSpan.Zero, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

//        public TimeSpan RemainingTime
//        {
//            get => (TimeSpan) GetValue(RemainingTimeProperty);
//            set => SetValue(RemainingTimeProperty, value);
//        }

//        public static readonly DependencyProperty StartOnLoadProperty = DependencyProperty.Register(
//            nameof(StartOnLoad), typeof(bool), typeof(CountdownTimerControl), new PropertyMetadata(true));

//        public bool StartOnLoad
//        {
//            get => (bool) GetValue(StartOnLoadProperty);
//            set => SetValue(StartOnLoadProperty, value);
//        }

//        public static readonly RoutedEvent TimeIsOverEvent = EventManager.RegisterRoutedEvent(
//            nameof(TimeIsOver), RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(CountdownTimerControl));

//        public event RoutedEventHandler TimeIsOver
//        {
//            add => this.AddHandler(TimeIsOverEvent, value);
//            remove => this.RemoveHandler(TimeIsOverEvent, value);
//        }

//        private readonly DispatcherTimer _countdownTimer;
//        private TimeSpan _interval;
//        private DateTime _startTime;

//        public CountdownTimerControl()
//        {
//            InitializeComponent();

//            _countdownTimer = new DispatcherTimer(DispatcherPriority.Render);
//            _countdownTimer.Interval = TimeSpan.FromMilliseconds(100);
//            _countdownTimer.Tick += CountdownTimerOnTick;

//            this.Loaded += (_, _) =>
//            {
//                Controller = this;

//                if (StartOnLoad)
//                    Start(Interval);
//            };
//        }

//        private void CountdownTimerOnTick(object? sender, EventArgs e)
//        {
//            var elapsedTime = DateTime.Now - _startTime;
//            RemainingTime = _interval - elapsedTime;

//            if (RemainingTime > TimeSpan.Zero)
//                return;

//            Stop();
//            RaiseEvent(new RoutedEventArgs(TimeIsOverEvent, this));
//        }

//        public void Start()
//        {
//            Start(Interval);
//        }

//        public void Start(TimeSpan interval)
//        {
//            RemainingTime = interval;
//            _interval = interval;
//            _startTime = DateTime.Now;
//            _countdownTimer.Start();
//        }

//        public void Stop()
//        {
//            _countdownTimer.Stop();
//            RemainingTime = TimeSpan.Zero;
//        }
//    }
//}
