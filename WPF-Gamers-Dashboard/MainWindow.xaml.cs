using MahApps.Metro.Controls;
using LiveCharts;
using System;
using LiveCharts.Wpf;
using System.Windows;
using System.IO;

namespace WPF_Gamers_Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public SeriesCollection ChartSeries;
        public string[] Labels;


        public MainWindow()
        {
            InitializeComponent();
            DisplayChart();
        
        }

      
        public void DisplayChart()
        {
            ChartSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<int> {3,9,2,7},
                    Title="Small",
                    LineSmoothness=0
                },
                new LineSeries
                {
                    Values = new ChartValues<int> {5,11,4,9},
                    Title="Big",
                    LineSmoothness=.5,
                }
            };

            Labels = new[] { "Jan", "Feb", "Mar", "Apr" };

            ChartControl.CardChartData = ChartSeries;

            ChartSeries.Add(new LineSeries
            {
                Values = new ChartValues<int> { 1, -7, -1, 5 },
                Title = "Medium",
                LineSmoothness = 1,
                PointGeometry = DefaultGeometries.Square,
                PointGeometrySize = 15
            });

            ChartSeries[0].Values.Add(0);
            ChartSeries[1].Values.Add(10);
            ChartSeries[2].Values.Add(12);
        }

        private void searchPageMenu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            searchPage winAdd = new searchPage();
            winAdd.Show();
            winAdd.Owner = this;
            this.Hide();
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //MessageBox.Show("Folder Path : {0}", Environment.GetFolderPath(Environment.SpecialFolder.System));
        }
    }
}
