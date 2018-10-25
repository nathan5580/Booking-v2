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
using Booking_v2.Model;

namespace Booking_v2
{
    /// <summary>
    /// Logique d'interaction pour Hotels.xaml
    /// </summary>
    public partial class Hotels : Page
    {
        public Hotels()
        {
            InitializeComponent();
            DisplayHotels();
        }

        private void DisplayHotels()
        {
            using (var db = new Model.Booking())
            {
                List<HotelsSet> hotelResult = (from hotel in db.HotelsSet select hotel).ToList();
                hotelsSetDataGrid.ItemsSource = hotelResult;
            }
        }

        private void validateHotel_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Model.Booking())
            {
                HotelsSet hotel = new HotelsSet();
                hotel.Nom = nomTextBox.Text;
                hotel.Capacite = Int32.Parse(capaciteTextBox.Text);
                hotel.Localisation = localisationTextBox.Text;
                hotel.Pays = paysTextBox.Text;

                db.HotelsSet.Add(hotel);
                db.SaveChanges();
            }

            DisplayHotels();
        }
    }
}
