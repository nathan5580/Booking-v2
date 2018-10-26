using Booking_v2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Booking_v2
{
    /// <summary>
    /// Logique d'interaction pour HotelChambres.xaml
    /// </summary>
    public partial class HotelChambres : Page
    {
        public HotelChambres(HotelsSet row)
        {
            InitializeComponent();
            try
            {
                DisplayChambres(row.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// refresh datagrid
        /// </summary>
        /// =====================================================================================
        /// Modification : Initial : 25/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        private /*static async Task*/ void DisplayChambres(int? hotelId = null)
        {
            if (hotelId != null)
            {
                using (var db = new Model.Booking() { Configuration = { ProxyCreationEnabled = false } })
                {
                    List<ChambresSet> chambreResult = (from chambre in db.ChambresSet where chambre.keyHotel == hotelId select chambre).ToList();

                    chambresSetDataGrid.ItemsSource = chambreResult;
                }
            }
            else
            {
                using (var db = new Model.Booking() { Configuration = { ProxyCreationEnabled = false } })
                {
                    List<ChambresSet> chambreResult = (from chambre in db.ChambresSet select chambre).ToList();

                    chambresSetDataGrid.ItemsSource = chambreResult;
                }
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
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChambresSet row = (ChambresSet)chambresSetDataGrid.SelectedItems[0];
                ((MainWindow)Window.GetWindow(this))._mainFrame.Navigate(new ChambreUpdate(row));
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
        /// Modification : Initial : 26/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ChambresSet row = (ChambresSet)chambresSetDataGrid.SelectedItems[0];

                using (var db = new Model.Booking())
                {
                    var chambre = new ChambresSet() { Id = row.Id };
                    db.ChambresSet.Attach(chambre);
                    db.ChambresSet.Remove(chambre);
                    db.SaveChanges();
                }

                DisplayChambres();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
