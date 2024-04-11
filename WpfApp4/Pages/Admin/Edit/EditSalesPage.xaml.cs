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
    /// Логика взаимодействия для EditSalesPage.xaml
    /// </summary>
    public partial class EditSalesPage : Page
    {
        public EditSalesPage(SalesTable currentsales)
        {
            InitializeComponent();
            try
            {
                this.DataContext = currentsales;
                CurrentPriceTextBox.Text = currentsales.CurrentPrice.ToString();

                ClientComboBox.ItemsSource = AppData.DB.connection.ClientsTable.ToList();
                SellerComboBox.ItemsSource = AppData.DB.connection.SellersTable.ToList();
                CarComboBox.ItemsSource = AppData.DB.connection.CarsTable.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void EditSalesButton_Click(object sender, RoutedEventArgs e)
        {
            try{
                var CurrentClient = ClientComboBox.SelectedItem as ClientsTable;
                var CurrentSeller = SellerComboBox.SelectedItem as SellersTable;
                var CurrentCar = CarComboBox.SelectedItem as CarsTable;

                SalesTable edituser = (SalesTable)this.DataContext;
                edituser.ClientID = CurrentClient.id;
                edituser.SellersID = CurrentSeller.id;
                edituser.CarID = CurrentCar.id;
                edituser.CurrentPrice = int.Parse(CurrentPriceTextBox.Text);
                DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Admin.AdminSalesListButton());
            }
                        catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
