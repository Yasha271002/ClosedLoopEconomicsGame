using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameLibrary.Views.Popups
{
    /// <summary>
    /// Логика взаимодействия для GameResultPopup.xaml
    /// </summary>
    public partial class GameResultPopup : UserControl
    {
        public static readonly DependencyProperty CorrectAnswersProperty = DependencyProperty.Register(
            nameof(CorrectAnswers), typeof(int), typeof(GameResultPopup), new PropertyMetadata(default(int)));

        public int CorrectAnswers
        {
            get => (int) GetValue(CorrectAnswersProperty);
            set => SetValue(CorrectAnswersProperty, value);
        }

        public static readonly DependencyProperty WrongAnswersProperty = DependencyProperty.Register(
            nameof(WrongAnswers), typeof(int), typeof(GameResultPopup), new PropertyMetadata(default(int)));

        public int WrongAnswers
        {
            get => (int) GetValue(WrongAnswersProperty);
            set => SetValue(WrongAnswersProperty, value);
        }

        public static readonly DependencyProperty ScoreProperty = DependencyProperty.Register(
            nameof(Score), typeof(int?), typeof(GameResultPopup), new PropertyMetadata(default(int?)));

        public int? Score
        {
            get => (int?) GetValue(ScoreProperty);
            set => SetValue(ScoreProperty, value);
        }

        public static readonly DependencyProperty BestScoreProperty = DependencyProperty.Register(
            nameof(BestScore), typeof(int?), typeof(GameResultPopup), new PropertyMetadata(default(int?)));

        public int? BestScore
        {
            get => (int?) GetValue(BestScoreProperty);
            set => SetValue(BestScoreProperty, value);
        }

        public GameResultPopup()
        {
            InitializeComponent();
        }
    }
}
