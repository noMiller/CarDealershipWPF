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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public AddClientPage()
        {
            InitializeComponent();
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientsTable newClient = new ClientsTable();
                newClient.FIO = FIOTextBox.Text;
                newClient.userid = int.Parse(IDuserTextBox.Text);
                DB.connection.ClientsTable.Add(newClient);
                DB.connection.SaveChanges();
                MessageBox.Show("Пользователь добавлен!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Pages.Admin.AdminClientListPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
