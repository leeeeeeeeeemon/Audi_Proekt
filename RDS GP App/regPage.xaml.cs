using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for regPage.xaml
    /// </summary>
    public partial class regPage : Page
    {
        public Label name;
        public Label balance;
        public regPage(ref Label userNameLabel, ref Label userBalance)
        {
            InitializeComponent();
            balance = userBalance;
            name = userNameLabel;
        }

        private void ClickRegistration(object sender, RoutedEventArgs e)
        {
            if(txt_name!= null && txt_login!= null && txt_password!= null)
            { 
                var u = new users();
                u.name = txt_name.Text;
                u.login = txt_login.Text;
                u.password = txt_password.Password;
                bd_connections.connection.users.Add(u);
                bd_connections.connection.SaveChanges();
                
                MessageBox.Show("Пользователь " + u.name + " создан, можете авторизоваться");
            }
            else
            {
                MessageBox.Show("Заполните данные");
            }

        }
        
        private void ClickToAuthorisation(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new authorPage(ref name, ref balance));
        }
    }


}
