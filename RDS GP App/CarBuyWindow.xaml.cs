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
using System.Windows.Shapes;

namespace Audi
{
    /// <summary>
    /// Логика взаимодействия для CarBuyWindow.xaml
    /// </summary>
    public partial class CarBuyWindow : Window
    {
        public string nameCar;
        public string Category;
        public int Power;
        public string from0to100;
        public decimal price;
        public string info;
        public decimal userBalance;
        public int user_id;
        public int cur_id;
        public CarBuyWindow(string autoInfo, decimal userBalance, int userId)
        {
            InitializeComponent();

            user_id = userId;
            
            string[] subs = autoInfo.Split('=', ',');

            cur_id = Convert.ToInt32(subs[1]);
            nameCar = subs[3];
            Category = subs[5];
            Power = Convert.ToInt32(subs[7]);
            from0to100 = subs[9];
            price = Convert.ToDecimal(subs[11] + "," + subs[12]);

            

            nameCarTextBlock.Text = subs[3];
            //CategoryTextBlock.Text = subs[3];
            PowerTextBlock.Text = subs[7];
            from0to100TextBlock.Text = subs[9];
            priceTextBlock.Text = subs[11] + "," + subs[12];

            string[] charSplit = autoInfo.Split('=');
            string[] charSecondSplit = charSplit[7].Split('.');
            info = charSecondSplit[0];


            autoInfotextBlock.Text = info;

        }

        private void buyCarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                var u = new Sale_Auto();
                u.id_user = user_id;
                u.id_auto = cur_id;
                u.passport = passportDanniTextBox.Text;
                u.tlephon_number = Convert.ToString(numberTextBox.Text);
                
                bd_connections.connection.Sale_Auto.Add(u);
                bd_connections.connection.SaveChanges();
                MessageBox.Show("Поздравляем с успешной покупкой");
            }
        }
    }
}
