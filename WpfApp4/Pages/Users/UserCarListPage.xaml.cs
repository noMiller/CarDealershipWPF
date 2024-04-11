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
using WpfApp4.Pages.Users;

namespace WpfApp4.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для UserCarListPage.xaml
    /// </summary>
    public partial class UserCarListPage : Page
    {
        public UserCarListPage()
        {
            InitializeComponent();
            var currentlist = AudiStoreEntities.GetContext().CarsTable.ToList();
            TypeEngineComboBox.ItemsSource = DB.connection.TypeCarsTable.ToList();
            
            
            CarList.ItemsSource = currentlist;
            // Model1.Context.tt > Model1.Context.cs
            //        private static AudiStoreEntities _context;


            //        public static AudiStoreEntities GetContext()
            //{
            //    if (_context == null)
            //        _context = new AudiStoreEntities();
            //    return _context;
            //}



            //Model1.tt > CarsTable.cs
        //public string ActualText  
        //{
        //    get
        //    {
        //       return (bool)(IsActual) ? "В наличии" : "Нет в наличии";
        //    }
        //}
        

    }
        
        private void UpdateList()
        {
            var CurrentCar = AudiStoreEntities.GetContext().CarsTable.ToList();


             CurrentCar = CurrentCar.Where(c => c.Model.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();


                CarList.ItemsSource = CurrentCar.ToList();

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        private void TypeEngineComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var CurrSort = TypeEngineComboBox.SelectedItem as TypeCarsTable;
            var currentlist = AudiStoreEntities.GetContext().CarsTable.Where(c => c.TypeID == CurrSort.id).ToList();
            CarList.ItemsSource = currentlist;

        }
    }
}
