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
using LiveCharts;
using LiveCharts.Wpf;

namespace Booking_v2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Chart
            try
            {
                SeriesCollection = new SeriesCollection();

                //adding series will update and animate the chart automatically
                using (var db = new Model.Booking())
                {
                    SeriesCollection.Add(new RowSeries
                    {
                        Title = "Today",
                        Values = new ChartValues<double>
                        {
                            (from h in db.HotelsSet select h.Id).Count(), (from c in db.ClientsSet select c.Id).Count(),
                            (from c in db.ChambresSet select c.Id).Count(),
                            (from r in db.ReservationSet select r.Id).Count()
                        }
                    });
                }


                Labels = new[] {"Hotels", "Clients", "Chambres", "Reservations"};
                Formatter = value => value.ToString("N");

                DataContext = this;
            }
            catch
            {
                Console.Write("Internal error");
            }
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private void hotelButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Hotels());
        }

        private void clientButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Clients());
        }

        private void chambreButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Chambres());
        }

        private void reservationButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Reservations());
        }
    }
}
