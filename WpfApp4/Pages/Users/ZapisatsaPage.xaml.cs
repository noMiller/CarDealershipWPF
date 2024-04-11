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

namespace WpfApp4.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для ZapisatsaPage.xaml
    /// </summary>
    public partial class ZapisatsaPage : Page
    {
        public ZapisatsaPage(UsersTable currentUser)
        {
            InitializeComponent();
            try
            {


                var currentlist = AudiStoreEntities.GetContext().RepairTable.Where(c => c.ClientsTable.userid == currentUser.id).ToList();
                ZapisatsaList.ItemsSource = currentlist;
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
