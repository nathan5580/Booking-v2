using Booking_v2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            try
            {
                DisplayHotels();
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
        private void DisplayHotels()
        {
            try
            {
                using (var db = new Model.Booking())
                {
                    List<HotelsSet> hotelResult = (from hotel in db.HotelsSet select hotel).ToList();
                    hotelsSetDataGrid.ItemsSource = hotelResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// add new record
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// =====================================================================================
        /// Modification : Initial : 25/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        private void validateHotel_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// delete
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
                HotelsSet row = (HotelsSet)hotelsSetDataGrid.SelectedItems[0];

                using (var db = new Model.Booking())
                {
                    if (!(from ch in db.ChambresSet where ch.keyHotel == row.Id select ch.Id).Any())
                    {
                        var hotel = new HotelsSet() { Id = row.Id };
                        db.HotelsSet.Attach(hotel);
                        db.HotelsSet.Remove(hotel);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Votre hôtel possède des chambres." + Environment.NewLine + "Supression impossible.");
                    }
                }

                DisplayHotels();
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
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                HotelsSet row = (HotelsSet)hotelsSetDataGrid.SelectedItems[0];
                ((MainWindow)Window.GetWindow(this))._mainFrame.Navigate(new HotelsUpdate(row));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Display all chambres
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// =====================================================================================
        /// Modification : Initial : 26/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new Model.Booking())
                {
                    HotelsSet row = (HotelsSet)hotelsSetDataGrid.SelectedItems[0];
                    if ((from ch in db.ChambresSet where ch.keyHotel == row.Id select ch).Any())
                    {
                        ((MainWindow)Window.GetWindow(this))._mainFrame.Navigate(new HotelChambres(row));
                    }
                    else
                    {
                        MessageBox.Show("Cet hotel n'as aucunes chambres...", "Alert", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }
    }
}
