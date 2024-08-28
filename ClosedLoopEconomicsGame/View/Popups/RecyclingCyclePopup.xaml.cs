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
using ClosedLoopEconomicsGame.Model;

namespace ClosedLoopEconomicsGame.View.Popups
{
    /// <summary>
    /// Логика взаимодействия для RecyclingCyclePopup.xaml
    /// </summary>
    public partial class RecyclingCyclePopup : UserControl
    {
        public static readonly DependencyProperty CategoryInfoModelProperty = DependencyProperty.Register(
            nameof(CategoryInfoModel), typeof(CategoryInfoModel), typeof(RecyclingCyclePopup), new PropertyMetadata(default(CategoryInfoModel)));

        public CategoryInfoModel CategoryInfoModel
        {
            get { return (CategoryInfoModel)GetValue(CategoryInfoModelProperty); }
            set { SetValue(CategoryInfoModelProperty, value); }
        }

        public RecyclingCyclePopup(CategoryInfoModel categoryInfo)
        {
            InitializeComponent();
            CategoryInfoModel = categoryInfo;
        }

        
    }
}
