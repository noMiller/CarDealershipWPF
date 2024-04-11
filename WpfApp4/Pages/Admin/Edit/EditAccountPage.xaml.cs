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

namespace WpfApp4.Pages.Admin.Edit
{
    /// <summary>
    /// Логика взаимодействия для EditAccountPage.xaml
    /// </summary>
    public partial class EditAccountPage : Page
    {
        public EditAccountPage(UsersTable SelectedUser)
        {
            try
            {
                InitializeComponent();
                RoleComboBox.ItemsSource = AppData.DB.connection.RolesTable.ToList();
                this.DataContext = SelectedUser;
                LoginTextBox.Text = SelectedUser.login;
                PasswordTextBox.Text = SelectedUser.password;
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditAccButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsersTable editUser = (UsersTable)this.DataContext;
                editUser.login = LoginTextBox.Text;
                editUser.password = PasswordTextBox.Text;
                var CurrentRole = RoleComboBox.SelectedItem as RolesTable;
                editUser.roleid = CurrentRole.id;
                AppData.DB.connection.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Pages.AdminAccountListPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
