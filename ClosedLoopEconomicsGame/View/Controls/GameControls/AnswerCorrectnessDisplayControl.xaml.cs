using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ClosedLoopEconomicsGame.View.Controls.GameControls
{
    /// <summary>
    /// Логика взаимодействия для AnswerCorrectnessDisplayControl.xaml
    /// </summary>
    public partial class AnswerCorrectnessDisplayControl : UserControl
    {
        public static readonly DependencyProperty IsCorrectProperty = DependencyProperty.Register(
            nameof(IsCorrect), typeof(bool), typeof(AnswerCorrectnessDisplayControl), new PropertyMetadata(default(bool)));

        public bool IsCorrect
        {
            get => (bool) GetValue(IsCorrectProperty);
            set => SetValue(IsCorrectProperty, value);
        }

        public AnswerCorrectnessDisplayControl()
        {
            InitializeComponent();
        }

        public void ShowCorrectAnswer(Action<AnswerCorrectnessDisplayControl>? callback = null)
        {
            IsCorrect = true;
            StartScaleAnimation(1, callback);
        }

        public void ShowWrongAnswer(Action<AnswerCorrectnessDisplayControl>? callback = null)
        {
            IsCorrect = false;
            StartScaleAnimation(1, callback);
        }

        public void HideAnswer(Action<AnswerCorrectnessDisplayControl>? callback = null)
        {
            StartScaleAnimation(0, callback);
        }

        private void StartScaleAnimation(double targetScale, Action<AnswerCorrectnessDisplayControl>? callback = null)
        {
            var scaleXAnimation = GetScaleAnimation(targetScale);
            var scaleYAnimation = GetScaleAnimation(targetScale);

            Storyboard.SetTargetName(scaleXAnimation, "AnswerScaleTransform");
            Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath(ScaleTransform.ScaleXProperty));

            Storyboard.SetTargetName(scaleYAnimation, "AnswerScaleTransform");
            Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath(ScaleTransform.ScaleYProperty));

            var storyboard = new Storyboard();
            storyboard.Children.Clear();
            storyboard.Children.Add(scaleXAnimation);
            storyboard.Children.Add(scaleYAnimation);

            storyboard.Completed += (_, _) =>
            {
                callback?.Invoke(this);
            };

            storyboard.Begin(this);
        }

        private DoubleAnimation GetScaleAnimation(double targetScale)
        {
            return new DoubleAnimation
            {
                To = targetScale,
                Duration = TimeSpan.FromMilliseconds(400),
                EasingFunction = new BackEase()
            };
        }
    }
}
