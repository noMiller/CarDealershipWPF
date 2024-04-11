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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUser = AppData.DB.connection.UsersTable.FirstOrDefault(u => u.login == LoginTextBox.Text && u.password == PasswordTextBox.Text);

            if (CurrentUser != null)
            {
                GlavWindow gw = new GlavWindow(CurrentUser);
                gw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogInPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignUpPageButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow su = new SignUpWindow();
            su.Show();
            this.Close();
        }
    }
}
