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
    /// Логика взаимодействия для AdminSalesListButton.xaml
    /// </summary>
    public partial class AdminSalesListButton : Page
    {
        public AdminSalesListButton()
        {
            InitializeComponent();
            SalesList.ItemsSource = AppData.DB.connection.SalesTable.ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CurrentSales = SalesList.SelectedItem as SalesTable;
                NavigationService.Navigate(new Pages.Admin.Edit.EditSalesPage(CurrentSales));
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
                var CurrentSales = SalesList.SelectedItem as SalesTable;
                DB.connection.SalesTable.Remove(CurrentSales);
                DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Admin.AdminSalesListButton());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Admin.ADD.AddSalesPage());
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var CurrentList = DB.connection.SalesTable.ToList();


            CurrentList = CurrentList.Where(c => c.ClientsTable.FIO.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();


            SalesList.ItemsSource = CurrentList.ToList();
        }
    }
}
