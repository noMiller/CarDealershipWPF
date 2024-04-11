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
using WpfApp4.AppData;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            UsersTable newUser = new UsersTable();
            newUser.login = LoginTextBox.Text;
            newUser.password = PasswordTextBox.Text;
            newUser.roleid = 3;
            AppData.DB.connection.UsersTable.Add(newUser);
            AppData.DB.connection.SaveChanges();

            ClientsTable newClient = new ClientsTable();
            newClient.FIO = FIOTextBox.Text;
            newClient.userid = newUser.id;
            AppData.DB.connection.ClientsTable.Add(newClient);
            AppData.DB.connection.SaveChanges();
            MessageBox.Show("Регистрация успешна!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();

        }

        private void LogInPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
