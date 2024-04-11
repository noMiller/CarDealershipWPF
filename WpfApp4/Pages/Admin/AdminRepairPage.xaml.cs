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
    /// Логика взаимодействия для AdminRepairPage.xaml
    /// </summary>
    public partial class AdminRepairPage : Page
    {
        public AdminRepairPage()
        {
            InitializeComponent();
            AdminRepairData.ItemsSource = AppData.DB.connection.RepairTable.ToList();
        }

        private void AddRepairButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Admin.ADD.AdminAddRepairPage());
        }

        private void EditRepairButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentrepair = AdminRepairData.SelectedItem as RepairTable;
                NavigationService.Navigate(new Pages.Admin.Edit.AdminEditRepairPage(currentrepair));
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteRepairButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentrepair = AdminRepairData.SelectedItem as RepairTable;
                DB.connection.RepairTable.Remove(currentrepair);
                DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Admin.AdminRepairPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var CurrentList = DB.connection.RepairTable.ToList();


            CurrentList = CurrentList.Where(c => c.ClientsTable.FIO.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();


            AdminRepairData.ItemsSource = CurrentList.ToList();
        }
    }
}
