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
    /// Логика взаимодействия для AddCarPage.xaml
    /// </summary>
    public partial class AddCarPage : Page
    {
        public AddCarPage()
        {
            InitializeComponent();
            TypeEngineComboBox.ItemsSource = DB.connection.TypeCarsTable.ToList();
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            CarsTable newcar = new CarsTable();
            var CurrentType = TypeEngineComboBox.SelectedItem as TypeCarsTable;

            bool Actual;
            if (IsActualTextBox.Text == "Да")
            {
                Actual = true;
            }
            else
                Actual = false;

            try
            {
                newcar.Model = ModelTextBox.Text;
                newcar.Description = DesctiptionTextBox.Text;
                int price = int.Parse(PriceTextBox.Text);
                newcar.Price = price;
                newcar.Photo = PhotoTextBox.Text;
                newcar.IsActual = Actual;
                newcar.TypeID = CurrentType.id;
                DB.connection.CarsTable.Add(newcar);
                MessageBox.Show("Вы успешно добавили автомобиль!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                DB.connection.SaveChanges();
                NavigationService.Navigate(new Pages.Admin.AdminCarListPage());
            }
            catch { }
        }
    }
}
