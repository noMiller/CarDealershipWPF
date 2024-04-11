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
    /// Логика взаимодействия для EditClientsPage.xaml
    /// </summary>
    public partial class EditClientsPage : Page
    {
        public EditClientsPage(ClientsTable currentclient)
        {
            try
            {
                InitializeComponent();
                this.DataContext = currentclient;
                FIOTextBox.Text = currentclient.FIO;
                IDuserTextBox.Text = currentclient.userid.ToString();
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void EditClientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientsTable editClient = (ClientsTable)this.DataContext;
                editClient.FIO = FIOTextBox.Text;
                editClient.userid = int.Parse(IDuserTextBox.Text);
                MessageBox.Show("Пользователь изменен!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Admin.AdminClientListPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
