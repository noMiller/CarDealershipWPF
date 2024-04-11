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
    /// Логика взаимодействия для AdminCarListPage.xaml
    /// </summary>
    public partial class AdminCarListPage : Page
    {
        public AdminCarListPage()
        {
            InitializeComponent();
            CarList.ItemsSource = AppData.DB.connection.CarsTable.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Admin.ADD.AddCarPage());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var SelectedCar = CarList.SelectedItem as CarsTable;
                DB.connection.CarsTable.Remove(SelectedCar);
                DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Admin.AdminCarListPage());
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
                var SelectedCar = CarList.SelectedItem as CarsTable;
                NavigationService.Navigate(new Pages.Admin.Edit.EditCarPage(SelectedCar));
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var CurrentCar = DB.connection.CarsTable.ToList();


            CurrentCar = CurrentCar.Where(c => c.Model.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();


            CarList.ItemsSource = CurrentCar.ToList();
        }
    }
}
