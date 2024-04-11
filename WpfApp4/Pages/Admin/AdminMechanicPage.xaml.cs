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
    /// Логика взаимодействия для AdminMechanicPage.xaml
    /// </summary>
    public partial class AdminMechanicPage : Page
    {
        public AdminMechanicPage()
        {
            InitializeComponent();
            AdminMechanicData.ItemsSource = AppData.DB.connection.MechaniсTable.ToList();
        }

        private void AddMechanicButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Admin.ADD.AdminAddMechanicPage());
        }

        private void EditMechanicButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentmechanic = AdminMechanicData.SelectedItem as MechaniсTable;
                NavigationService.Navigate(new Pages.Admin.Edit.EditMechanicPage(currentmechanic));
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void DeleteMechanicButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentmechanic = AdminMechanicData.SelectedItem as MechaniсTable;
                DB.connection.MechaniсTable.Remove(currentmechanic);
                DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Admin.AdminMechanicPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var CurrentList = DB.connection.MechaniсTable.ToList();


            CurrentList = CurrentList.Where(c => c.FIO.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();


            AdminMechanicData.ItemsSource = CurrentList.ToList();
        }
    }
}
