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
    /// Логика взаимодействия для AddSalesPage.xaml
    /// </summary>
    public partial class AddSalesPage : Page
    {
        public AddSalesPage()
        {
            InitializeComponent();
            ClientComboBox.ItemsSource = AppData.DB.connection.ClientsTable.ToList();
            SellerComboBox.ItemsSource = AppData.DB.connection.SellersTable.ToList();
            CarComboBox.ItemsSource = AppData.DB.connection.CarsTable.ToList();
        }

        private void AddSalesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CurrentClient = ClientComboBox.SelectedItem as ClientsTable;
                var CurrentSeller = SellerComboBox.SelectedItem as SellersTable;
                var CurrentCar = CarComboBox.SelectedItem as CarsTable;


                SalesTable newSales = new SalesTable();
                newSales.ClientsTable = CurrentClient;
                newSales.SellersTable = CurrentSeller;
                newSales.CarsTable = CurrentCar;
                newSales.CurrentPrice = int.Parse(CurrentPriceTextBox.Text);
                AppData.DB.connection.SalesTable.Add(newSales);
                AppData.DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Admin.AdminSalesListButton());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
