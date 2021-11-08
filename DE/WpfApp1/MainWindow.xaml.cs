using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Открывает окно со списком туров/списка отелей
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tag = Convert.ToString(((Button)sender).Tag);
            // Окно со списком туров
            if (tag == "tourList")
            {
                TourList tourListWindow = new TourList() { mainWindow = this };
                tourListWindow.Show();
            }
            else
            {
                HotelList hotelList = new HotelList() { mainWindow = this };
                hotelList.Show();
            }
            this.Hide();

        }
    }
}
