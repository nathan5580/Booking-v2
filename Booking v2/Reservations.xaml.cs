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
using Booking_v2.Classes;
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
            try
            {
                DisplayReservations();

                using (var db = new Model.Booking())
                {
                    List<ChambresSet> chambreID = (from chambre in db.ChambresSet select chambre).ToList();


                    foreach (var item in chambreID)
                    {
                        comboChambre.Items.Add(item.Id + "-" + item.Nom);
                    }
                }

                using (var db = new Model.Booking())
                {
                    List<ClientsSet> clients = (from cli in db.ClientsSet select cli).ToList();


                    foreach (var item in clients)
                    {
                        comboClient.Items.Add(item.Id + "-" + item.Nom + "." + item.Prenom);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
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
                int idChambre = Util.GetComboId(comboChambre.Text);
                int idClient = Util.GetComboId(comboClient.Text);

                using (var db = new Model.Booking())
                {
                    ReservationSet reserv = new ReservationSet();
                    reserv.ChambresSetId = idChambre;
                    reserv.ClientsSetId = idClient;
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

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// =====================================================================================
        /// Modification : Initial : 25/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReservationSet row = (ReservationSet)reservationSetDataGrid.SelectedItems[0];

                using (var db = new Model.Booking())
                {
                    var reservation = new ReservationSet() { Id = row.Id };
                    db.ReservationSet.Attach(reservation);
                    db.ReservationSet.Remove(reservation);
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
