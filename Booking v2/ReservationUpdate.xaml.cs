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
    /// Logique d'interaction pour ReservationUpdate.xaml
    /// </summary>
    public partial class ReservationUpdate : Page
    {
        private ReservationSet reservation = new ReservationSet();
        public ReservationUpdate(ReservationSet row)
        {
            InitializeComponent();
            try
            {
                reservation = row;
                dateDebutDatePicker.Text = row.dateDebut.ToString();
                dateFinDatePicker.Text = row.dateFin.ToString();
                keyChambreTextBox.Text = row.keyChambre.ToString();
                keyClientTextBox.Text = row.keyClient.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// =====================================================================================
        /// Modification : Initial : 26/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReservationSet hereReservation = new ReservationSet();
                hereReservation = this.reservation;

                //int idChambre = Util.GetComboId(comboChambre.Text);
                //int idClient = Util.GetComboId(comboClient.Text);

                using (var db = new Model.Booking())
                {
                    ReservationSet reservation = new ReservationSet() { Id = hereReservation.Id };
                    db.ReservationSet.Attach(reservation);

                    //reservation.keyChambre = idChambre;
                    //reservation.keyClient = idClient;
                    reservation.dateDebut = dateDebutDatePicker.DisplayDate.Date;
                    reservation.dateFin = dateFinDatePicker.DisplayDate.Date;
                    
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
