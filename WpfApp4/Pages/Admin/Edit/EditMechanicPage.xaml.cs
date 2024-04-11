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
    /// Логика взаимодействия для EditMechanicPage.xaml
    /// </summary>
    public partial class EditMechanicPage : Page
    {
        public EditMechanicPage(MechaniсTable currentmech)
        {
            try
            {
                InitializeComponent();
                this.DataContext = currentmech;
                FIOTextBox.Text = currentmech.FIO;
                DoljnostTextBox.Text = currentmech.Doljnost;
                UserIDTextBox.Text = currentmech.UserID.ToString();
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void EditMechanicButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MechaniсTable editMech = (MechaniсTable)this.DataContext;
                editMech.FIO = FIOTextBox.Text;
                editMech.Doljnost = DoljnostTextBox.Text;
                editMech.UserID = int.Parse(UserIDTextBox.Text);
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
