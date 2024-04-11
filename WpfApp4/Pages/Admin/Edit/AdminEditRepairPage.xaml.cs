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
    /// Логика взаимодействия для AdminEditRepairPage.xaml
    /// </summary>
    public partial class AdminEditRepairPage : Page
    {
        public AdminEditRepairPage(RepairTable editrepair)
        {
            InitializeComponent();
            try
            {
                this.DataContext = editrepair;
                StatusCombo.ItemsSource = DB.connection.StatusTable.ToList();
                MechanicCombo.ItemsSource = DB.connection.MechaniсTable.ToList();

                ClientIDTextBox.Text = editrepair.ClientID.ToString();
                CarTextBox.Text = editrepair.Car;
                CommunicationTextBox.Text = editrepair.Communication;
                CommentTextBox.Text = editrepair.Comment;
                PriceTextBox.Text = editrepair.Price.ToString();
            }
            catch
            {

            }
            
        }

        private void EditRepairButton_Click(object sender, RoutedEventArgs e)
        {
            var CurrentStatus = StatusCombo.SelectedItem as StatusTable;
            var CurrentMechanic = MechanicCombo.SelectedItem as MechaniсTable;

            try
            {
                RepairTable currRepair = (RepairTable)this.DataContext;
                currRepair.StatusID = CurrentStatus.id;
                currRepair.MechanicID = CurrentMechanic.ID;
                currRepair.ClientID = int.Parse(ClientIDTextBox.Text);
                currRepair.Car = CarTextBox.Text;
                currRepair.Communication = CommunicationTextBox.Text;
                currRepair.Comment = CommentTextBox.Text;
                currRepair.Price = int.Parse(PriceTextBox.Text);

                DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Admin.AdminRepairPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error );
            }

        }
    }
}
