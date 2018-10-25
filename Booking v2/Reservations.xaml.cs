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
    /// Logique d'interaction pour Reservations.xaml
    /// </summary>
    public partial class Reservations : Page
    {
        public Reservations()
        {
            InitializeComponent();
            DisplayReservations();

            using (var db = new Model.Booking())
            {
                List<int> chambreID = (from chambre in db.ChambresSet select chambre.Id).ToList();


                foreach (var item in chambreID)
                {
                    comboChambre.Items.Add(item.ToString());
                }
            }

            using (var db = new Model.Booking())
            {
                List<int> clients = (from cli in db.ClientsSet select cli.Id).ToList();


                foreach (var item in clients)
                {
                    comboClient.Items.Add(item.ToString());
                }
            }
        }

        private void DisplayReservations()
        {
            using (var db = new Model.Booking())
            {
                List<ReservationSet> reservationsResult = (from reserv in db.ReservationSet select reserv).ToList();
                reservationSetDataGrid.ItemsSource = reservationsResult;
            }
        }

        private void validateReservation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new Model.Booking())
                {
                    ReservationSet reserv = new ReservationSet();
                    reserv.ChambresSetId = comboChambre.SelectedIndex;
                    reserv.ClientsSetId = comboClient.SelectedIndex;
                    reserv.dateDebut = dateDebutDatePicker.DisplayDate.Date;
                    reserv.dateFin = dateFinDatePicker.DisplayDate.Date;

                    db.ReservationSet.Add(reserv);
                    db.SaveChanges();
                }

                DisplayReservations();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
