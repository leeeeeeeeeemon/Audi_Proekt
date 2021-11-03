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
        public bool modelComboBoxChanged = true;
        public class Model
        {
            public string Name { get; set; }
        }

        public class Kuzov
        {
            public string name { get; set; }
        }
        public Label userBalanceLab;

        public static ObservableCollection<Auto> auto { get; set; }
        public Audi.users userLogin;
        public UserMainMenu(ref Label userName, ref Label userBalance, Audi.users user)
        {
            InitializeComponent();

            userBalanceLab = userBalance;
            userLogin = user;
            userName.Content = user.name;
            userName.Visibility = Visibility;
            userBalance.Content = "Balance: " + Convert.ToString(user.balance);

            modelComboBox.DataContext = new ObservableCollection<Model>() {
                new Model() { Name =  "Все"},
                new Model() {  Name = "A3" },
                new Model() { Name = "A4" },
                new Model() { Name =  "A5" },
                new Model() { Name =  "A6" },
                new Model() { Name =  "Q5"}
            };

            kuzovComboBox.DataContext = new ObservableCollection<Kuzov>()
            {
                new Kuzov() { name = "Все"},
                new Kuzov() { name = "Sedan"},
                new Kuzov() { name = "SportBack"},
                new Kuzov() { name = "Allroad quattro"},
                new Kuzov() { name = "SUV"}

            };
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
            from Auto in bd_connections.connection.Auto
            select new {Auto.id_auto, Auto.name  , Auto.category, Auto.engine_power, Auto.acceleration_from_0_to_100_sec____, Auto.price, Auto.characteristic };

            Auto.ItemsSource = query.ToList();

            var query2 =
            from Sale_Auto in bd_connections.connection.Sale_Auto
            where Sale_Auto.id_user == userLogin.id_user
            select new { Sale_Auto.id_auto, Sale_Auto.passport, Sale_Auto.tlephon_number };

            myBuy.ItemsSource = query2.ToList();
        }

        private void ShowCars_Click(object sender, RoutedEventArgs e)
        {
            if(userLogin.login == "lime"){
                addNewCar.Visibility = Visibility.Visible;
            }
            
            ModelSeletcLabel.Visibility = Visibility.Visible;
            ModelSeletcLabel_Copy.Visibility = Visibility.Visible;
            myBuy.Visibility = Visibility.Hidden;
            Auto.Visibility = Visibility.Visible;
            modelComboBox.Visibility = Visibility.Visible;
            kuzovComboBox.Visibility = Visibility.Visible;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           // MessageBox.Show("чЕ САМЫЙ КРУТОЙ?");
            string autoInfo = Auto.SelectedItem.ToString();
            CarBuyWindow diag = new CarBuyWindow(autoInfo, Convert.ToDecimal(userLogin.balance), Convert.ToInt32(userLogin.id_user), userLogin);
            bool dialogResult = Convert.ToBoolean(diag.ShowDialog());
            if (dialogResult)
            {

            userBalanceLab.Content = "Balance: " + Convert.ToString(userLogin.balance);
            }


        }

        private void modelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var ComboItem = (Model)modelComboBox.SelectedValue;
            if (modelComboBoxChanged)
            {
                kuzovComboBox.SelectedIndex = 0;
                modelComboBoxChanged = false;
            }
            if (ComboItem.Name != "Все")
            {
            var query =
            from Auto in bd_connections.connection.Auto
            where Auto.model == ComboItem.Name
            select new { Auto.id_auto, Auto.name, Auto.category, Auto.engine_power, Auto.acceleration_from_0_to_100_sec____, Auto.price, Auto.characteristic };

            Auto.ItemsSource = query.ToList();
            }
            else
            {
            var query =
            from Auto in bd_connections.connection.Auto
           
            select new { Auto.id_auto, Auto.name, Auto.category, Auto.engine_power, Auto.acceleration_from_0_to_100_sec____, Auto.price, Auto.characteristic };
            Auto.ItemsSource = query.ToList();
            }
                

            
        }

        private void kuzovComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ComboItem = (Kuzov)kuzovComboBox.SelectedValue;
            if (!modelComboBoxChanged)
            {
                modelComboBox.SelectedIndex = 0;
                modelComboBoxChanged = true;
            }
            
            if (ComboItem.name != "Все")
            {
                var query =
                from Auto in bd_connections.connection.Auto
                where Auto.category == ComboItem.name
                select new { Auto.id_auto, Auto.name, Auto.category, Auto.engine_power, Auto.acceleration_from_0_to_100_sec____, Auto.price, Auto.characteristic };

                Auto.ItemsSource = query.ToList();
            }
            else
            {
                var query =
                from Auto in bd_connections.connection.Auto

                select new { Auto.id_auto, Auto.name, Auto.category, Auto.engine_power, Auto.acceleration_from_0_to_100_sec____, Auto.price, Auto.characteristic };
                Auto.ItemsSource = query.ToList();
            }
        }

        private void ShowBuyCars_Click(object sender, RoutedEventArgs e)
        {
            addNewCar.Visibility = Visibility.Hidden;
            ModelSeletcLabel.Visibility = Visibility.Hidden;
            ModelSeletcLabel_Copy.Visibility = Visibility.Hidden;
            myBuy.Visibility = Visibility.Visible;
            Auto.Visibility = Visibility.Hidden;
            modelComboBox.Visibility = Visibility.Hidden;
            kuzovComboBox.Visibility = Visibility.Hidden;
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            var query =
            from Auto in bd_connections.connection.Auto
            select new { Auto.id_auto, Auto.name, Auto.category, Auto.engine_power, Auto.acceleration_from_0_to_100_sec____, Auto.price, Auto.characteristic };

            Auto.ItemsSource = query.ToList();

            var query2 =
            from Sale_Auto in bd_connections.connection.Sale_Auto
            where Sale_Auto.id_user == userLogin.id_user
            select new { Sale_Auto.id_auto, Sale_Auto.passport, Sale_Auto.tlephon_number };

            myBuy.ItemsSource = query2.ToList();
        }

        private void addBalance_Click(object sender, RoutedEventArgs e)
        {
            addBalance dilal = new addBalance(userLogin);
            bool result = Convert.ToBoolean(dilal.ShowDialog());
            if (result)
            {
                userBalanceLab.Content = "Balance: " + Convert.ToString(userLogin.balance);
            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void addNewCar_Click(object sender, RoutedEventArgs e)
        {
            AddCarWin dial = new AddCarWin();
            bool result = Convert.ToBoolean(dial.ShowDialog());
        }
    }
}
