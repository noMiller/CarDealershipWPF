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
    /// Логика взаимодействия для EditCarPage.xaml
    /// </summary>
    public partial class EditCarPage : Page
    {
        public EditCarPage(CarsTable currentcar)
        {
            try
            {
                InitializeComponent();
                TypeEngineComboBox.ItemsSource = DB.connection.TypeCarsTable.ToList();


                this.DataContext = currentcar;
                ModelTextBox.Text = currentcar.Model;
                PriceTextBox.Text = currentcar.Price.ToString();
                Description.Text = currentcar.Description;
                PhotoTextBox.Text = currentcar.Photo.ToString();
                IsActualTextBox.Text = currentcar.IsActual.ToString();
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void EditCarButton_Click(object sender, RoutedEventArgs e)
        {
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


                CarsTable editCar = (CarsTable)this.DataContext;
                editCar.Model = ModelTextBox.Text;
                int price = int.Parse(PriceTextBox.Text);
                editCar.Price = price;
                editCar.Description = Description.Text;
                editCar.Photo = PhotoTextBox.Text;
                editCar.IsActual = Actual;
                editCar.TypeID = CurrentType.id;
                DB.connection.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Pages.Admin.AdminCarListPage());
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
