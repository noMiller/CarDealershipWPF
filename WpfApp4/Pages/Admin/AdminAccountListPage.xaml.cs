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

namespace WpfApp4.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminAccountListPage.xaml
    /// </summary>
    public partial class AdminAccountListPage : Page
    {
        public AdminAccountListPage()
        {
            InitializeComponent();
            AcoountData.ItemsSource = AppData.DB.connection.UsersTable.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Admin.ADD.AddAccountPage());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CurrentUser = AcoountData.SelectedItem as UsersTable;
                DB.connection.UsersTable.Remove(CurrentUser);
                DB.connection.SaveChanges();
                MessageBox.Show("Пользователь удален!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Pages.AdminAccountListPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CurrentUser = AcoountData.SelectedItem as UsersTable;
                NavigationService.Navigate(new Pages.Admin.Edit.EditAccountPage(CurrentUser));
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var CurrentAcc = DB.connection.UsersTable.ToList();


            CurrentAcc = CurrentAcc.Where(c => c.login.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();


            AcoountData.ItemsSource = CurrentAcc.ToList();
        }
    }
}
