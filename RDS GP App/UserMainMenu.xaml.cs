using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Audi
{
    /// <summary>
    /// Логика взаимодействия для UserMainMenu.xaml
    /// </summary>
    public partial class UserMainMenu : Page
    {
        public static ObservableCollection<Auto> auto { get; set; }
        public UserMainMenu()
        {
            InitializeComponent();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
            from Auto in bd_connections.connection.Auto
            orderby Auto.price
            select new { Auto.name  , Auto.category, Auto.engine_power, Auto.acceleration_from_0_to_100_sec____, Auto.characteristic, Auto.price };

            Auto.ItemsSource = query.ToList();
        }
    }
}
