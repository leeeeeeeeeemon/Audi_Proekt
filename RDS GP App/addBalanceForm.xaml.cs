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
    /// Логика взаимодействия для addBalance.xaml
    /// </summary>
    public partial class addBalance : Window
    {
        public Audi.users user;
        public addBalance(Audi.users userLogin)
        {
            InitializeComponent();

            user = userLogin;
        }

        private void addValueBtn_Click(object sender, RoutedEventArgs e)
        {
            user.balance = user.balance + Convert.ToInt32(addValueTextBox.Text);
            this.DialogResult = true;
        }
    }
}
