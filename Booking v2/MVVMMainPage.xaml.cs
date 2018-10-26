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
using System.Windows.Shapes;

namespace Booking_v2
{
    /// <summary>
    /// Logique d'interaction pour MVVMMainPage.xaml
    /// </summary>
    public partial class MVVMMainPage : Window
    {
        public MVVMMainPage()
        {
            InitializeComponent();
        }

        public string ButtonContent
        {
            get
            {
                return "Click Me";
            }
        }
    }
}
