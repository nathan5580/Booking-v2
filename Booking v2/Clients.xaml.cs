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
    /// Logique d'interaction pour Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        public Clients()
        {
            InitializeComponent();
            try
            {
                DisplayClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// refresh datagrid
        /// </summary>
        /// =====================================================================================
        /// Modification : Initial : 25/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        private void DisplayClients()
        {
            using (var db = new Model.Booking())
            {
                List<ClientsSet> clientsResult = (from clients in db.ClientsSet select clients).ToList();
                clientsSetDataGrid.ItemsSource = clientsResult;
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
        private void validateClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new Model.Booking())
                {
                    ClientsSet client = new ClientsSet();
                    client.Nom = nomTextBox.Text;
                    client.Prenom = prenomTextBox.Text;
                    client.DateNaissance = dateNaissanceDatePicker.DisplayDate;

                    db.ClientsSet.Add(client);
                    db.SaveChanges();
                }

                DisplayClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK,
                    MessageBoxImage.Information);
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
                ClientsSet row = (ClientsSet) clientsSetDataGrid.SelectedItems[0];

                using (var db = new Model.Booking())
                {
                    var client = new ClientsSet() {Id = row.Id};
                    db.ClientsSet.Attach(client);
                    db.ClientsSet.Remove(client);
                    db.SaveChanges();
                }

                DisplayClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK,
                    MessageBoxImage.Information);
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
                ClientsSet row = (ClientsSet) clientsSetDataGrid.SelectedItems[0];
                ((MainWindow) Window.GetWindow(this))._mainFrame.Navigate(new ClientsUpdate(row));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }
    }
}
