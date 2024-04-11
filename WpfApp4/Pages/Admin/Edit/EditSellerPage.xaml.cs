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
    /// Логика взаимодействия для EditSellerPage.xaml
    /// </summary>
    public partial class EditSellerPage : Page
    {
        public EditSellerPage(SellersTable currentseller)
        {
            try
            {
                InitializeComponent();
                this.DataContext = currentseller;
                FIOTextBox.Text = currentseller.FIO;
                JobTitle.Text = currentseller.JobTitle;
                IDAccTextBox.Text = currentseller.UserID.ToString();
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void EditSellerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SellersTable editseller = (SellersTable)this.DataContext;
                editseller.FIO = FIOTextBox.Text;
                editseller.JobTitle = JobTitle.Text;
                editseller.UserID = int.Parse(IDAccTextBox.Text);
                DB.connection.SaveChanges();
                MessageBox.Show("Пользователь изменен!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Pages.Admin.AdminSellersListPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
