using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для HotelList.xaml
    /// </summary>
    public partial class HotelList : Window
    {
        class HotelInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int CountOfStars { get; set; }
            public string CountryName { get; set; }
            public int ToursCount { get; set; }

        }

        public MainWindow mainWindow;
        private int _countPageHotel = 10;
        private int _pageCount = 0;
        private int _currentPage = 1;
        private List<HotelInfo> hotelList = new List<HotelInfo>();
        public HotelList()
        {
            InitializeComponent();
        }

        private int CountPages()
        {
            using (demoEkzEntities db = new demoEkzEntities())
            {
                return Convert.ToInt32(Math.Ceiling(db.Hotels.Count() / Convert.ToDouble(_countPageHotel)));
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            using (demoEkzEntities db = new demoEkzEntities())
            {
                _pageCount = CountPages();
                foreach (Hotel hotel in db.Hotels)
                {
                    hotelList.Add(new HotelInfo() { Id = hotel.Id, Name = hotel.Name, CountOfStars = hotel.CountOfStars, CountryName = hotel.Country.Name, ToursCount = hotel.Tours.Count() });
                }
            }
            pageCountLabel.Content = $"Общее количество страниц: {_pageCount}";
            btnFirst.IsEnabled = false;
            btnPrev.IsEnabled = false;
            ShowHotels();
        }

        // Обновление таблицы
        public void updateHotels ()
        {
            hotelList.Clear();
            using (demoEkzEntities db = new demoEkzEntities())
            {
                _pageCount = CountPages();
                foreach (Hotel hotel in db.Hotels)
                {
                    hotelList.Add(new HotelInfo() { Id = hotel.Id, Name = hotel.Name, CountOfStars = hotel.CountOfStars, CountryName = hotel.Country.Name, ToursCount = hotel.Tours.Count() });
                }
            }
            ShowHotels();
        }


        // Вывод данных в таблицу
        public void ShowHotels ()
        {
            hotelTable.Items.Clear();
            int startInterval = (_currentPage-1) * _countPageHotel;
            for (int i = startInterval; i < startInterval+_countPageHotel; i++)
            {
                try
                {
                    hotelTable.Items.Add(hotelList[i]);
                }
                catch
                {
                    break;
                }
            }
        }

        // Открытие формы редактирования/Удаления
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (demoEkzEntities db = new demoEkzEntities())
            {
                HotelInfo selectedHotel = (HotelInfo)hotelTable.SelectedItem;
                Hotel foundHotel = db.Hotels.FirstOrDefault(hotel => hotel.Id == selectedHotel.Id);
                UpdateDeleteHotel updateDeleteHotelForm = new UpdateDeleteHotel() { hotelListForm = this, currentHotel = foundHotel };
                this.Hide();
                updateDeleteHotelForm.Show();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded && ((TextBox)sender).Text != "")
            {
                try
                {
                   _countPageHotel = Convert.ToInt32(((TextBox)sender).Text);
                    if (_countPageHotel <= hotelList.Count && _countPageHotel < 100)
                    {
                        _pageCount = CountPages();
                        _currentPage = 1;
                        currentPageLabel.Content = "Текущая страница: 1";
                        pageCountLabel.Content = $"Общее количество страниц: {_pageCount}";
                        btnFirst.IsEnabled = false;
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = true;
                        btnLast.IsEnabled = true;
                        ShowHotels();
                    }
                    else
                    {
                        MessageBox.Show("Неправильно указано количество элементов на странице");
                    }
                }
                catch
                {
                    MessageBox.Show("Неправильно указано количество элементов на странице");
                }
            }
        }

        // Переход на следующую страницу
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage >= _pageCount-1)
            {
                _currentPage++;
                currentPageLabel.Content = $"Текущая страница: {_currentPage}";
                ShowHotels();
                ((Button)sender).IsEnabled = false;
                btnLast.IsEnabled = false;
            }
            else
            {
                _currentPage++;
                currentPageLabel.Content = $"Текущая страница: {_currentPage}";
                ShowHotels();
            }
            btnFirst.IsEnabled = true;
            btnPrev.IsEnabled = true;
        }

        // Переход на предыдущую страницу
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage <= 2)
            {
                _currentPage--;
                currentPageLabel.Content = $"Текущая страница: {_currentPage}";
                ShowHotels();
                ((Button)sender).IsEnabled = false;
                btnFirst.IsEnabled = false;
            }
            else
            {
                _currentPage--;
                currentPageLabel.Content = $"Текущая страница: {_currentPage}";
                ShowHotels();
            }
            btnLast.IsEnabled = true;
            btnNext.IsEnabled = true;
        }


        // Переход на первую страницу
        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            currentPageLabel.Content = $"Текущая страница: {_currentPage}";
            btnFirst.IsEnabled = false;
            btnPrev.IsEnabled = false;
            btnNext.IsEnabled = true;
            btnLast.IsEnabled = true;
            ShowHotels();
        }

        // Переход на последню страницу
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = CountPages();
            currentPageLabel.Content = $"Текущая страница: {_currentPage}";
            btnFirst.IsEnabled = true;
            btnPrev.IsEnabled = true;
            btnNext.IsEnabled = false;
            btnLast.IsEnabled = false;
            ShowHotels();
        }

        // Добавление 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddHotel addHotel = new AddHotel() { hotelListWindow = this };
            addHotel.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.Show();
        }
    }
}
