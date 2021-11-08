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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddHotel.xaml
    /// </summary>
    public partial class AddHotel : Window
    {
        public HotelList hotelListWindow;
        public AddHotel()
        {
            InitializeComponent();
        }

        private void BtnAddHotel_Click(object sender, RoutedEventArgs e)
        {
            using (demoEkzEntities db = new demoEkzEntities())
            {
                try
                {
                    string selectCountryName = Convert.ToString(((Country)CmbNameCountry.SelectedItem).Name);
                    Country foundCountry = db.Countries.FirstOrDefault(country => country.Name == selectCountryName);
                    Hotel hotel = new Hotel ()
                    {
                        Name = TxtNameHotel.Text,
                        CountOfStars = Convert.ToInt32(sldCountStars.Value),
                        Country = foundCountry,
                        CountryCode = foundCountry.Code,
                        Description = TxtDescriptionHotel.Text
                    };
                    db.Hotels.Add(hotel);
                    db.SaveChanges();
                    hotelListWindow.updateHotels();
                }
                catch
                {
                    MessageBox.Show("Введены неправильные данные", "Error");
                }
            }

            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            hotelListWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (demoEkzEntities db = new demoEkzEntities())
            {
                CmbNameCountry.ItemsSource = db.Countries.ToList();             
            }
        }

        private void CmbNameCountry_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

