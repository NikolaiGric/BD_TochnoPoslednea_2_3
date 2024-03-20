using System.Windows;
using BD_TochnoPoslednea.Cinema_practicDataSetTableAdapters;

namespace BD_TochnoPoslednea
{           
    public partial class DataSetWindow2 : Window
    {
        MoviesTableAdapter movies = new MoviesTableAdapter();
        public DataSetWindow2()
        {
            InitializeComponent();

            AllDataGrid.ItemsSource = movies.GetFullInfo();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AllDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            AllDataGrid.Columns[1].Visibility = Visibility.Collapsed;
            AllDataGrid.Columns[2].Visibility = Visibility.Collapsed;
        }
    }
}
