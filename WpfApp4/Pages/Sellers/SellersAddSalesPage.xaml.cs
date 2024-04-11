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

namespace WpfApp4.Pages.Sellers
{
    /// <summary>
    /// Логика взаимодействия для SellersAddSalesPage.xaml
    /// </summary>
    public partial class SellersAddSalesPage : Page
    {
        private UsersTable seller;
        public SellersAddSalesPage(UsersTable currentuser)
        {
            InitializeComponent();
            try
            {
                ClientsComboBox.ItemsSource = AppData.DB.connection.ClientsTable.ToList();
                CarsComboBox.ItemsSource = AppData.DB.connection.CarsTable.ToList();
                SellerComboBox.ItemsSource = AppData.DB.connection.SellersTable.ToList();
                seller = currentuser;
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddSalesPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentClient = ClientsComboBox.SelectedItem as ClientsTable;
                var currentSeller = SellerComboBox.SelectedItem as SellersTable;
                var currentCar = CarsComboBox.SelectedItem as CarsTable;

                SalesTable newSales = new SalesTable();

                newSales.SellersID = currentSeller.id;
                newSales.ClientID = currentClient.id;
                newSales.CarID = currentCar.id;
                newSales.CurrentPrice = int.Parse(CurrentPrice.Text);
                AppData.DB.connection.SalesTable.Add(newSales);
                AppData.DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Sellers.SellersMySalesPage(seller));
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
