using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var pass2 = Password2.Text;

            var mail = email.Text;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);

            if (login.Length == 0)
            {
                LoginBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Укажите логин");
                return;
            }
            else if (login.Length < 6)
            {
                LoginBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Логин должен состоять из 6 символов");
                return;
            }

            if (mail.Length == 0)
            {
                email.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Укажите почту");
                return;
            } else if (!Regex.IsMatch(mail, @"[@]")) {

                email.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Некоректная почта");
                return;

            }
            if (pass.Length == 0)
            {

                Password1.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Укажите пароль");
                return;
            }
            else if (pass.Length < 6)
            {
                Password1.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Пароль должен содержать не менее 6 символов!");
                return;
            }
            else if (!Regex.IsMatch(pass, @"[!?*&$^%()_+]"))
            {
                Password1.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("В пароли должен хотя бы состоять один символ! ");
                return;
            }
            else if (pass != pass2)
            {
                Password1.BorderBrush = new SolidColorBrush(Colors.Red);
                Password2.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            if (user_exists != null)
            {
                MessageBox.Show("псыж");
                return;
            }

            var user = new user { Login = login, Password = pass, Email = mail};
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрировались!");

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
