﻿using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logique d'interaction pour Chambres.xaml
    /// </summary>
    public partial class Chambres : Page
    {
        public Chambres()
        {
            InitializeComponent();

            try
            {
                //Task task = new Task(async () => await DisplayChambres());
                //task.Start();
                DisplayChambres();

                using (var db = new Model.Booking())
                {
                    List<HotelsSet> hotelIds = (from hotel in db.HotelsSet select hotel).ToList();


                    foreach (var item in hotelIds)
                    {
                        comboHotelID.Items.Add(item.Id + "-" + item.Nom);
                    }
                }
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
        private /*static async Task*/ void DisplayChambres()
        {
            using (var db = new Model.Booking(){ Configuration = { ProxyCreationEnabled = false } })
            {
                List<ChambresSet> chambreResult = (from chambre in db.ChambresSet select chambre).ToList();
                
                chambresSetDataGrid.ItemsSource = chambreResult;
            }
        }

        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// =====================================================================================
        /// Modification : Initial : 25/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        private void validateChambre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new Model.Booking() { Configuration = { ProxyCreationEnabled = false } })
                {
                    int id = Util.GetComboId(comboHotelID.Text);

                    bool isClim = false;
                    if (climatisationCheckBox.IsChecked.Value)
                    {
                        isClim = true;
                    }

                    ChambresSet chambre = new ChambresSet();
                    chambre.Nom = nomTextBox.Text;
                    chambre.Climatisation = isClim;
                    chambre.NbLits = Int32.Parse(nbLitsTextBox.Text);
                    chambre.keyHotel = id;

                    db.ChambresSet.Add(chambre);
                    db.SaveChanges();
                }

                DisplayChambres();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// update
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
                ChambresSet row = (ChambresSet)chambresSetDataGrid.SelectedItems[0];
                ((MainWindow)Window.GetWindow(this))._mainFrame.Navigate(new ChambreUpdate(row));
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
