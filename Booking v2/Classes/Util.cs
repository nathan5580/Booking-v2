using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_v2.Classes
{
    static class Util
    {
        public static int GetComboId(string str)
        {
            int id = Int32.Parse(str.Split('-')[0].Trim());
            return id;
        }
    }
}
