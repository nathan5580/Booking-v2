using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking_MVVM.Model;

namespace Booking_MVVM.ViewModel
{
    class HotelsViewModel
    {
        public ObservableCollection<HotelsSet> Hotels
        {
            get;
            set;
        }

        public void LoadHotels()
        {
            ObservableCollection<HotelsSet> hotels = new ObservableCollection<HotelsSet>();

            using (var db = new Booking())
            {
                var list = (from h in db.HotelsSet select h).ToList();
                foreach (var item in list)
                {
                    hotels.Add(item);
                }
            }

            Hotels = hotels;
        }
    }
}
