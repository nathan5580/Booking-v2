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
    /// Logique d'interaction pour ClientsUpdate.xaml
    /// </summary>
    public partial class ClientsUpdate : Page
    {
        ClientsSet client = new ClientsSet();
        public ClientsUpdate(ClientsSet row)
        {
            InitializeComponent();
            try
            {
                client = row;
                nomTextBox.Text = client.Nom;
                prenomTextBox.Text = client.Prenom;
                dateNaissanceDatePicker.DisplayDate = client.DateNaissance;
                dateNaissanceDatePicker.Text = client.DateNaissance.ToString();
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
                using (var db = new Model.Booking())
                {
                    ClientsSet client = new ClientsSet() { Id = this.client.Id };
                    db.ClientsSet.Attach(client);

                    client.Nom = nomTextBox.Text;
                    client.Prenom = prenomTextBox.Text;
                    client.DateNaissance = dateNaissanceDatePicker.DisplayDate;
                    
                    db.SaveChanges();
                }

            ((MainWindow)Window.GetWindow(this))._mainFrame.Navigate(new Clients());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
