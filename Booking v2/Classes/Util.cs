using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_v2.Classes
{
    static class Util
    {
        /// <summary>
        /// Gets the combo id.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        /// =====================================================================================
        /// Modification : Initial : 25/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        public static int GetComboId(string str)
        {
            int id = Int32.Parse(str.Split('-')[0].Trim());
            return id;
        }
    }
}
