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
using WpfApp4.AppData;

namespace WpfApp4.Pages.Admin.ADD
{
    /// <summary>
    /// Логика взаимодействия для AddAccountPage.xaml
    /// </summary>
    public partial class AddAccountPage : Page
    {
        public AddAccountPage()
        {
            InitializeComponent();
            RoleComboBox.ItemsSource = AppData.DB.connection.RolesTable.ToList();
        }

        private void AddAccButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsersTable newUser = new UsersTable();
                newUser.login = LoginTextBox.Text;
                newUser.password = PasswordTextBox.Text;
                var currentrole = RoleComboBox.SelectedItem as RolesTable;
                newUser.roleid = currentrole.id;
                AppData.DB.connection.UsersTable.Add(newUser);
                AppData.DB.connection.SaveChanges();
                MessageBox.Show("Аккаунт добавлен!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Pages.AdminAccountListPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        }
}
