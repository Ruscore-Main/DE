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
    /// Логика взаимодействия для UpdateDeleteHotel.xaml
    /// </summary>
    
    public partial class UpdateDeleteHotel : Window
    {
        public HotelList hotelListForm;
        public Hotel currentHotel;
        public int indexCountry = 0;
        public UpdateDeleteHotel()
        {
            InitializeComponent();
        }

        // Сохранение изменений
        private void BtnSaveHotel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (demoEkzEntities db = new demoEkzEntities())
                {
                    Hotel foundHotel = db.Hotels.FirstOrDefault(el => el.Id == currentHotel.Id);
                    foundHotel.Name = TxtNameHotel.Text;
                    foundHotel.Description = TxtDescriptionHotel.Text;
                    foundHotel.CountOfStars = Convert.ToInt32(SldCountStars.Value);
                    Country selectedCountry = ((Country)CmbNameCountry.SelectedItem);
                    Country foundCountry = db.Countries.FirstOrDefault(el => el.Code == selectedCountry.Code);
                    foundHotel.Country = foundCountry;
                    db.SaveChanges();
                }
                hotelListForm.updateHotels();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Неправильно введены данные");
            }
        }

        // Удаление отеля
        private void BtnDeleteHotel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(currentHotel.Name, "Хотите удалить отель?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                using (demoEkzEntities db = new demoEkzEntities())
                {
                    Hotel foundHotel = db.Hotels.FirstOrDefault(el => el.Id == currentHotel.Id);
                    db.Hotels.Remove(foundHotel);
                    db.SaveChanges();
                }
                hotelListForm.updateHotels();
                this.Close();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            hotelListForm.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (demoEkzEntities db = new demoEkzEntities())
            {
                List<Country> countriesList = db.Countries.ToList();
                CmbNameCountry.ItemsSource = countriesList;
                for (int i = 0; i < countriesList.Count; i++)
                {
                    if (currentHotel.Country.Code == countriesList[i].Code)
                    {
                        indexCountry = i;
                        break;
                    }
                }
            }
            TxtNameHotel.Text = currentHotel.Name;
            TxtDescriptionHotel.Text = currentHotel.Description != null ? currentHotel.Description : "";
            SldCountStars.Value = currentHotel.CountOfStars;
            CmbNameCountry.SelectedIndex = indexCountry;
        }

    }
}
