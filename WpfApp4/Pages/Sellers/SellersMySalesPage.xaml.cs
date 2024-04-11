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

namespace WpfApp4.Pages.Sellers
{
    /// <summary>
    /// Логика взаимодействия для SellersMySalesPage.xaml
    /// </summary>
    public partial class SellersMySalesPage : Page
    {
        public SellersMySalesPage(UsersTable CurrentUser)
        {
            InitializeComponent();
            MySales.ItemsSource = AppData.DB.connection.SalesTable.Where(s => s.SellersTable.UserID == CurrentUser.id).ToList();

        }
    }
}
