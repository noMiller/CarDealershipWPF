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
    /// Логика взаимодействия для AddSellersPage.xaml
    /// </summary>
    public partial class AddSellersPage : Page
    {
        public AddSellersPage()
        {
            InitializeComponent();
        }

        private void AddSellerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SellersTable newSeller = new SellersTable();
                newSeller.FIO = FIOTextBox.Text;
                newSeller.JobTitle = JobTitle.Text;
                newSeller.UserID = int.Parse(IDAccTextBox.Text);
                AppData.DB.connection.SellersTable.Add(newSeller);
                AppData.DB.connection.SaveChanges();
                MessageBox.Show("Пользователь добавлен!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Pages.Admin.AdminSellersListPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
