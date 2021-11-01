﻿using System;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RDS_GP_App
{
    /// <summary>
    /// Interaction logic for authorPage.xaml
    /// </summary>
    //public static ObservableCollection<Users> Userss { get; set; }
    
    public partial class authorPage : Page
    {
        public static ObservableCollection<users> userss { get; set; }
        public authorPage()
        {
            InitializeComponent();
        }
        
        private void autho_event(object sender, RoutedEventArgs e)
        {
            userss = new ObservableCollection<users>(bd_connections.connection.users.ToList());
            var z = userss.Where(a => a.login == txt_login.Text && a.password == txt_pass.Password).FirstOrDefault();
            if (z != null)
            {
                MessageBox.Show(z.name);
            }
            else
            {
                MessageBox.Show("Incorrect");
            }
        }

        private void btn_Registration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new regPage());
        }
    }

}