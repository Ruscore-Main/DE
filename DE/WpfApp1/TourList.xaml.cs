using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Drawing;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для TourList.xaml
    /// </summary>
    public partial class TourList : Window
    {
        public MainWindow mainWindow;
        public Dictionary<string, string> searchValues = new Dictionary<string, string>();
        public bool isLoaded = false;
        public TourList()
        {
            InitializeComponent();
            using (demoEkzEntities db = new demoEkzEntities())
            {
                var data = db.Tours;
                ObservableCollection<string> list = new ObservableCollection<string>();
                list.Add("Все типы");
                foreach (Type type in db.Types)
                {
                    list.Add(type.Name.Replace("\n", string.Empty));
                }
                comboBoxSearch.ItemsSource = list;
                comboBoxSearch.SelectedIndex = 0;
                ShowTours(data);

            }
        }

        private BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        public void ShowTours(IQueryable<Tour> tours)
        {
            if (!isLoaded)
            {
                isLoaded = true;
                searchValues.Add("textBox", "");
                searchValues.Add("tourTypes", "Все типы");
                searchValues.Add("onlyActual", "False");
            }
            // Очистка всех карточек для фильтрации в реальном времени
            else wrapPanel.Children.Clear();

            // генерация карточек   
            foreach (var tour in tours)
            {
                WrapPanel card = new WrapPanel()
                {
                    Height = 260,
                    Width = 220
                };

                Label title = new Label()
                {
                    Content = tour.Name,
                    Width = 220,
                    FontSize = 13,
                    HorizontalContentAlignment = HorizontalAlignment.Center
                };

                card.Children.Add(title);

                Image img = new Image() { Width=200, Height=140, Stretch=Stretch.Fill };
                BitmapImage bitmap;
                try
                {
                    if (tour.ImagePreview != null)
                    {
                        bitmap = LoadImage(tour.ImagePreview);
                    }
                    else
                    {
                        var uri = new Uri(@"file://C:\Users\oobit\OneDrive\Рабочий стол\ДЭ\picture.png");
                        bitmap = new BitmapImage(uri);
                    }
                       
                }
                catch
                {
                    var uri = new Uri(@"file://C:\Users\oobit\OneDrive\Рабочий стол\ДЭ\picture.png");
                    bitmap = new BitmapImage(uri);
                }
                img.Source = bitmap;


                card.Children.Add(img);

                Label price = new Label()
                {
                    Content = $"{tour.Price} руб.",
                    Width = 200,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    FontWeight = FontWeights.Bold
                };
                card.Children.Add(price);

                Label isActual = new Label()
                {
                    Content = tour.IsActual ? "Актуален" : "Не актуален",
                    Foreground = tour.IsActual ? Brushes.Green : Brushes.Red,
                    Width = 100,
                    FontWeight = FontWeights.Bold
                };
                card.Children.Add(isActual);

                Label ticketCount = new Label()
                {
                    Content = $"Билетов: {tour.TicketCount}",
                    Width = 120,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.Bold
                };
                card.Children.Add(ticketCount);


                wrapPanel.Children.Add(card);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.Show();
        }

        // Если произошло любое изменение в поиске
        private void allChanges ()
        {
            // Фильтрация по заданным параметрам в реальном времени
            using (demoEkzEntities db = new demoEkzEntities())
            {
                bool checkedCB = searchValues["onlyActual"] == "True";
                var data = db.Tours.Where(el => checkedCB ? el.IsActual  : true);
                if (searchValues["textBox"] != "")
                {
                    data = data.Where(el => el.Name.ToLower().Contains(textBoxSearch.Text.ToLower()));
                }
                if (searchValues["tourTypes"] != "Все типы")
                {
                    string currentType = searchValues["tourTypes"];
                    data = data.Where(el => el.Types.Where(type => type.Name.Contains(currentType)).Count() > 0);
                }
                ShowTours(data);
            }
        }

        // Если произошло изменение в поиске по содержанию
        private void ChangedSearch(object sender, TextChangedEventArgs e)
        {
            if (isLoaded)
            {
                searchValues["textBox"] = textBoxSearch.Text;
                allChanges();
            }
        }

        // Если произошло изменение в актуальности тура
        private void checkBoxSearch_Checked(object sender, RoutedEventArgs e)
        {
            if (isLoaded)
            {
                searchValues["onlyActual"] = $"{checkBoxSearch.IsChecked}";
                allChanges();
            }
        }

        // Если произошло изменение в типе тура
        private void comboBoxSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded)
            {
                searchValues["tourTypes"] = Convert.ToString(comboBoxSearch.SelectedItem);
                allChanges();
            }
        }
    }
}



