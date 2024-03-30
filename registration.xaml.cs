using Microsoft.EntityFrameworkCore;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();
        }

        private void t2_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;

            var pass = Password1.Text;

            var mail = email.Text;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exists != null)
            {
                MessageBox.Show("псыж");
                return;
            }

            var user = new user { Login = login, Password = pass, Email = mail};
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Welcome to the club, buddy");

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
