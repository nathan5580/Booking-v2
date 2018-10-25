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
            DisplayClients();
        }

        private void DisplayClients()
        {
            using (var db = new Model.Booking())
            {
                List<ClientsSet> clientsResult = (from clients in db.ClientsSet select clients).ToList();
                clientsSetDataGrid.ItemsSource = clientsResult;
            }
        }

        private void validateClient_Click(object sender, RoutedEventArgs e)
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
    }
}
