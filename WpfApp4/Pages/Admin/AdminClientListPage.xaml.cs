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
    /// Логика взаимодействия для AdminClientListPage.xaml
    /// </summary>
    public partial class AdminClientListPage : Page
    {
        public AdminClientListPage()
        {
            InitializeComponent();
            ClientList.ItemsSource = DB.connection.ClientsTable.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Admin.ADD.AddClientPage());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selecteduser = ClientList.SelectedItem as ClientsTable;
                DB.connection.ClientsTable.Remove(selecteduser);
                DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Admin.AdminClientListPage());
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
                var selecteduser = ClientList.SelectedItem as ClientsTable;
                NavigationService.Navigate(new Pages.Admin.Edit.EditClientsPage(selecteduser));
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var CurrentList = DB.connection.ClientsTable.ToList();


            CurrentList = CurrentList.Where(c => c.FIO.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();


            ClientList.ItemsSource = CurrentList.ToList();
        }
    }
}
