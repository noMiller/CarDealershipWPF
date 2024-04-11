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
    /// Логика взаимодействия для UserMySalesPage.xaml
    /// </summary>
    public partial class UserMySalesPage : Page
    {
        public UserMySalesPage(UsersTable currentUser)
        {
            InitializeComponent();
            //MySales.ItemsSource = AppData.DB.connection.SalesTable.Where(c => c.ClientsTable.userid == currentUser.id).ToList();
            var currentlist = AudiStoreEntities.GetContext().SalesTable.Where(c => c.ClientsTable.userid == currentUser.id).ToList();
            MySalesList.ItemsSource = currentlist;
        }
    }
}
