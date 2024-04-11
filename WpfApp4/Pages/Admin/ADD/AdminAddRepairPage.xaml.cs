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
    /// Логика взаимодействия для AdminAddRepairPage.xaml
    /// </summary>
    public partial class AdminAddRepairPage : Page
    {
        public AdminAddRepairPage()
        {
            InitializeComponent();
            MechanicCombo.ItemsSource = DB.connection.MechaniсTable.ToList();
        }

        private void AddRepairButton_Click(object sender, RoutedEventArgs e)
        {
            var CurrentMechanic = MechanicCombo.SelectedItem as MechaniсTable;

            try
            {
                RepairTable newrepair = new RepairTable();
                newrepair.ClientID = int.Parse(ClientIDTextBox.Text);
                newrepair.Car = CarTextBox.Text;
                newrepair.MechanicID = CurrentMechanic.ID;
                newrepair.Communication = CommunicationTextBox.Text;
                newrepair.Comment = CommentTextBox.Text;
                newrepair.StatusID = 2;
                newrepair.Price = int.Parse(PriceTextBox.Text);

                DB.connection.RepairTable.Add(newrepair);
                DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Admin.AdminRepairPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
