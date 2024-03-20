using System.Windows;

namespace BD_TochnoPoslednea
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DataSet_Click(object sender, RoutedEventArgs e)
        {
            DataSetWindow window = new DataSetWindow();
            window.Show();
        }
        private void EntityFramework_Click(object sender, RoutedEventArgs e)
        {
            EntityFrameworkWindow window = new EntityFrameworkWindow();
            window.Show();
        }
        private void DataSet2_Click(object sender, RoutedEventArgs e)
        {
            DataSetWindow2 window = new DataSetWindow2();
            window.Show();
        }
        private void EntityFramework2_Click(object sender, RoutedEventArgs e)
        {
            EntityFrameworkWindow2 window = new EntityFrameworkWindow2();
            window.Show();
        }
    }
}
