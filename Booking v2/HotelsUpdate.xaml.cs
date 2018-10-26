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
    /// Logique d'interaction pour HotelsUpdate.xaml
    /// </summary>
    public partial class HotelsUpdate : Page
    {
        HotelsSet hotel = new HotelsSet();
        public HotelsUpdate(HotelsSet row)
        {
            InitializeComponent();
            try
            {
                hotel = row;
                capaciteTextBox.Text = hotel.Capacite.ToString();
                localisationTextBox.Text = hotel.Localisation;
                nomTextBox.Text = hotel.Nom;
                paysTextBox.Text = hotel.Pays;
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
        private void updateHotel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HotelsSet hereHotel = new HotelsSet();
                hereHotel = this.hotel;

                using (var db = new Model.Booking())
                {
                    HotelsSet hotel = new HotelsSet(){Id = hereHotel.Id};
                    db.HotelsSet.Attach(hotel);

                    hotel.Nom = nomTextBox.Text;
                    hotel.Capacite = Int32.Parse(capaciteTextBox.Text);
                    hotel.Localisation = localisationTextBox.Text;
                    hotel.Pays = paysTextBox.Text;
                    
                    db.SaveChanges();
                }

                ((MainWindow)Window.GetWindow(this))._mainFrame.Navigate(new Hotels());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
