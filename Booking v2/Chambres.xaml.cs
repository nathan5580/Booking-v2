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
    /// Logique d'interaction pour Chambres.xaml
    /// </summary>
    public partial class Chambres : Page
    {
        public Chambres()
        {
            InitializeComponent();

            //Task task = new Task(async () => await DisplayChambres());
            //task.Start();
            DisplayChambres();

            using (var db = new Model.Booking())
            {
                List<int> hotelIds = (from hotel in db.HotelsSet select hotel.Id).ToList();


                foreach (var item in hotelIds)
                {
                    comboHotelID.Items.Add(item.ToString());
                }
            }
        }

        private /*static async Task*/ void DisplayChambres()
        {
            using (var db = new Model.Booking())
            {
                List<ChambresSet> chambreResult = (from chambre in db.ChambresSet select chambre).ToList();
                
                chambresSetDataGrid.ItemsSource = chambreResult;
            }
        }

        private void validateChambre_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Model.Booking())
            {
                bool isClim = false;
                if (climatisationCheckBox.IsChecked.Value)
                {
                    isClim = true;
                }

                ChambresSet chambre = new ChambresSet();
                chambre.Nom = nomTextBox.Text;
                chambre.Climatisation = isClim;
                chambre.NbLits = Int32.Parse(nbLitsTextBox.Text);
                chambre.HotelsSetId = comboHotelID.SelectedIndex;

                db.ChambresSet.Add(chambre);
                db.SaveChanges();
            }

            DisplayChambres();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
