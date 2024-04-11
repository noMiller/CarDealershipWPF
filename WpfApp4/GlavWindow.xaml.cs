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
using System.Windows.Shapes;
using WpfApp4.AppData;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для GlavWindow.xaml
    /// </summary>
    public partial class GlavWindow : Window
    {
        public UsersTable user;
        public GlavWindow(UsersTable CurrentUser)
        {
            InitializeComponent();
            user = CurrentUser;

            switch (CurrentUser.roleid) 
            {
                case 1:
                    AdminPanel.Visibility = Visibility.Visible;
                    break;
                case 2:
                    SellersPanel.Visibility = Visibility.Visible;
                    break;
                case 3:
                    ClientPanel.Visibility = Visibility.Visible;
                    break;
                case 1002:
                    MechanicPanel.Visibility = Visibility.Visible;
                    break;

            }
        }

        private void UserCarListButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Users.UserCarListPage());
        }

        private void UserSalesListButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Users.UserMySalesPage(user));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainFrame.GoBack();
            }
            catch
            {

            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {  
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();

        }

        private void SellerCarListPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Sellers.SellersCarListPage());
           
        }

        private void SellerMySales_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Sellers.SellersMySalesPage(user));
        }

        private void AdminCarListButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Admin.AdminCarListPage());
        }

        private void AdminSalesListButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Admin.AdminSalesListButton());
        }

        private void AdminUserListButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.AdminAccountListPage());
        }

        private void AdminClientsListButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Admin.AdminClientListPage());
        }

        private void AdminSellersListButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Admin.AdminSellersListPage());
        }

        private void AddMySalesButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Sellers.SellersAddSalesPage(user));
        }

        private void UserZapisiButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Users.ZapisatsaPage(user));
        }

        private void UserAddZapisButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Users.UserAddZapisPage(user));
        }

        private void RepairListButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Mechanic.MechanicMyRepairPage(user));
        }

        private void AdminMechanicListButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Admin.AdminMechanicPage());
        }

        private void AdminRepairListButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Admin.AdminRepairPage());
        }

        private void AdminRoleListButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Admin.AdminRolesPage());
        }

        private void AdminTypeCarButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.AdminTypeCarPage());
        }

        private void AdminStatusButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Admin.AdminStatusPage());
        }
    }
}
