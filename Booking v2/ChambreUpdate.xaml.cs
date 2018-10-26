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
    /// Logique d'interaction pour ChambreUpdate.xaml
    /// </summary>
    public partial class ChambreUpdate : Page
    {
        ChambresSet chambre = new ChambresSet();

        public ChambreUpdate(ChambresSet row)
        {
            InitializeComponent();
            try
            {
                using (var db = new Model.Booking())
                {
                    List<HotelsSet> hotelIds = (from hotel in db.HotelsSet select hotel).ToList();


                    foreach (var item in hotelIds)
                    {
                        comboHotelID.Items.Add(item.Id + "-" + item.Nom);
                    }
                }

                //
                chambre = row;

                if (chambre.Climatisation)
                {
                    climatisationCheckBox.IsChecked = true;
                }
                comboHotelID.SelectedItem = chambre.keyHotel;
                nomTextBox.Text = chambre.Nom;
                nbLitsTextBox.Text = chambre.NbLits.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void validateUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new Model.Booking())
                {
                    ChambresSet hereChambre = new ChambresSet();
                    hereChambre = this.chambre;

                    ChambresSet chambre = db.ChambresSet.SingleOrDefault(c => c.Id == hereChambre.Id);
                    if (chambre != null)
                    {
                        bool isClim = false;
                        if (climatisationCheckBox.IsChecked.Value)
                        {
                            isClim = true;
                        }

                        chambre.Climatisation = isClim;
                        chambre.NbLits = Int32.Parse(nbLitsTextBox.Text);
                        chambre.Nom = nomTextBox.Text;
                        db.SaveChanges();
                    }
                }

            ((MainWindow)Window.GetWindow(this))._mainFrame.Navigate(new Chambres());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal error :" + Environment.NewLine + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
