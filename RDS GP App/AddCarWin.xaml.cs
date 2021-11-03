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
using System.Windows.Shapes;

namespace Audi
{
    /// <summary>
    /// Логика взаимодействия для AddCarWin.xaml
    /// </summary>
    public partial class AddCarWin : Window
    {
        public AddCarWin()
        {
            InitializeComponent();
        }

        private void addCarButton_Click(object sender, RoutedEventArgs e)
        {
            var u = new Auto();
            u.model = modelTextBox.Text;
            u.name = nameTextBox.Text;
            u.category = CategoryBox.Text;
            u.engine_power = Convert.ToInt32(EngineBox.Text);
            u.acceleration_from_0_to_100_sec____ = from0Box.Text;
            u.price = Convert.ToDecimal(priceBox.Text);
            u.characteristic = infoBox.Text;
            bd_connections.connection.Auto.Add(u);
            bd_connections.connection.SaveChanges();
            this.DialogResult = true;
        }
    }
}
