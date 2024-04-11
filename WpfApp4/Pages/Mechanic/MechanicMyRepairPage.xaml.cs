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

namespace WpfApp4.Pages.Mechanic
{
    /// <summary>
    /// Логика взаимодействия для MechanicMyRepairPage.xaml
    /// </summary>
    public partial class MechanicMyRepairPage : Page
    {
        private UsersTable currentuser;

        public MechanicMyRepairPage(UsersTable user)
        {
            InitializeComponent();
            try
            {
                MyRepairData.ItemsSource = AppData.DB.connection.RepairTable.Where(m => m.MechaniсTable.UserID == user.id).ToList();
                currentuser = user;
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void EditRepairButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CurrentRepair = MyRepairData.SelectedItem as RepairTable;
                NavigationService.Navigate(new Pages.Mechanic.EditRepairPage(CurrentRepair, currentuser));
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
