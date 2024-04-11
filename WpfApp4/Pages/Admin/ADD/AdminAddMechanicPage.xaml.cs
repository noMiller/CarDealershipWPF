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
    /// Логика взаимодействия для AdminAddMechanicPage.xaml
    /// </summary>
    public partial class AdminAddMechanicPage : Page
    {
        public AdminAddMechanicPage()
        {
            InitializeComponent();
        }

        private void AddMechanicButton_Click(object sender, RoutedEventArgs e)
        {
            MechaniсTable newmech = new MechaniсTable();

            try
            {


                newmech.FIO = FIOTextBox.Text;
                newmech.Doljnost = DoljnostTextBox.Text;
                newmech.UserID = int.Parse(UserIDTextBox.Text);

                DB.connection.MechaniсTable.Add(newmech);
                DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Admin.AdminMechanicPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
