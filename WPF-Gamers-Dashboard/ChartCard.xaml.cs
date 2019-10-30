using System.Windows.Controls;
using LiveCharts;
using System.Windows;

namespace WPF_Gamers_Dashboard
{
    /// <summary>
    /// Interaction logic for ChartCard.xaml
    /// </summary>
    public partial class ChartCard : UserControl
    {
        public ChartCard()
        {
            InitializeComponent();
            ChartGrid.DataContext = this;
        }

        public SeriesCollection CardChartData
        {
            get { return null; }
            set { SetValue(ChartSeriesData, value); }
        }

        public static readonly DependencyProperty ChartSeriesData =
         DependencyProperty.Register(
             "CardChartData",       // XAML/PropertyName
             typeof(SeriesCollection),     // the property's value type
             typeof(ChartCard), // Bound to this custom control
             new PropertyMetadata(null)
         );

        public string CardTitle
        {
            set { SetValue(TitleText, value); }
        }

        public static readonly DependencyProperty TitleText =
            DependencyProperty.Register(
                "CardTitle",       // XAML/PropertyName
                typeof(string),     // the property's value type
                typeof(ChartCard), // Bound to this custom control
                new PropertyMetadata(null)
            );
    }
}
