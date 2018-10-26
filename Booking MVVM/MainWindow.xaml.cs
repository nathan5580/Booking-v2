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

namespace Booking_MVVM
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StudentViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            Booking_MVVM.ViewModel.StudentViewModel studentViewModelObject =
                new Booking_MVVM.ViewModel.StudentViewModel();
            studentViewModelObject.LoadStudents();

            StudentViewControl.DataContext = studentViewModelObject;
        }

        private void HotelsViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            Booking_MVVM.ViewModel.HotelsViewModel hotelViewModelObject =
                new Booking_MVVM.ViewModel.HotelsViewModel();
            hotelViewModelObject.LoadHotels();

            HotelViewControl.DataContext = hotelViewModelObject;
        }
    }
}
