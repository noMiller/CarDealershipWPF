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

namespace WpfApp4.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminSellersListPage.xaml
    /// </summary>
    public partial class AdminSellersListPage : Page
    {
        public AdminSellersListPage()
        {
            InitializeComponent();
            SellersList.ItemsSource = AppData.DB.connection.SellersTable.ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CurrentUser = SellersList.SelectedItem as SellersTable;
                NavigationService.Navigate(CurrentUser);
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CurrentUser = SellersList.SelectedItem as SellersTable;
                DB.connection.SellersTable.Remove(CurrentUser);
                DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Admin.AdminSellersListPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Admin.ADD.AddSellersPage());
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var CurrentList = DB.connection.SellersTable.ToList();


            CurrentList = CurrentList.Where(c => c.FIO.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();


            SellersList.ItemsSource = CurrentList.ToList();
        }
    }
}
