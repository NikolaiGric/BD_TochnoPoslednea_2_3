using System.Linq;
using System.Windows;

namespace BD_TochnoPoslednea
{ 
    public partial class EntityFrameworkWindow2 : Window
    {
        private Cinema_practicEntities context = new Cinema_practicEntities();
        public EntityFrameworkWindow2()
        {
            InitializeComponent();
            AllDataGrid.ItemsSource = context.Movies.ToList();
        }
    }
}
