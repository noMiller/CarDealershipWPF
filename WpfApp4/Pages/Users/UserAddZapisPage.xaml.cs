using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace WpfApp4.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для UserAddZapisPage.xaml
    /// </summary>
    public partial class UserAddZapisPage : Page
    {
        private UsersTable user;
        private ClientsTable currentid;
        public UserAddZapisPage(UsersTable currenuser)
        {
            InitializeComponent();
            user = currenuser;
            var clientId = AppData.DB.connection.ClientsTable.Where(client => client.userid == currenuser.id).FirstOrDefault();
            currentid = clientId;

        }

        private void AddZapisButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RepairTable newzapis = new RepairTable();
                newzapis.Car = CarTextBox.Text;
                newzapis.ClientID = currentid.id;
                newzapis.Communication = CommunicationTextBox.Text;
                newzapis.StatusID = 1;
                AppData.DB.connection.RepairTable.Add(newzapis);
                AppData.DB.connection.SaveChanges();
                MessageBox.Show("Заявка принята! Ожидайте звонка администратора.", "Заявка принята!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Pages.Users.ZapisatsaPage(user));
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
