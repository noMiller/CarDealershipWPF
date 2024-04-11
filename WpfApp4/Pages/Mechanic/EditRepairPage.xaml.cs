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
    /// Логика взаимодействия для EditRepairPage.xaml
    /// </summary>
    public partial class EditRepairPage : Page
    {
        private RepairTable Repair;
        private UsersTable user;
        public EditRepairPage(RepairTable currentRepair, UsersTable currentuser)
        {
            InitializeComponent();

            try
            {
                this.DataContext = currentRepair;
                CommentTextBox.Text = currentRepair.Comment;
                PriceTextBox.Text = currentRepair.Price.ToString();
                StatusComboBox.ItemsSource = AppData.DB.connection.StatusTable.ToList();
                Repair = currentRepair;
                user = currentuser;
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CurrentStatus = StatusComboBox.SelectedItem as StatusTable;

                RepairTable currRepair = (RepairTable)this.DataContext;
                currRepair.id = Repair.id;
                currRepair.ClientID = Repair.ClientID;
                currRepair.Car = Repair.Car;
                currRepair.MechanicID = Repair.MechanicID;
                currRepair.Communication = Repair.Communication;
                currRepair.Comment = CommentTextBox.Text;
                currRepair.StatusID = CurrentStatus.id;
                currRepair.Price = int.Parse(PriceTextBox.Text);
                AppData.DB.connection.SaveChanges();


                MessageBox.Show("Изменения сохранены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Pages.Mechanic.MechanicMyRepairPage(user));
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
