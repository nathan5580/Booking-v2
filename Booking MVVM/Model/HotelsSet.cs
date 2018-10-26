using System.ComponentModel;

namespace Booking_MVVM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotelsSet")]
    public partial class HotelsSet
    {
        private string _nom;
        private int _capacite;
        private string _localisation;
        private string _pays;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelsSet()
        {
            ChambresSet = new HashSet<ChambresSet>();
        }

        public int Id { get; set; }

        [Required]
        public string Nom
        {
            get { return _nom; }
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    RaisePropertyChanged("Nom");
                }
            }
        }

        public int Capacite
        {
            get { return _capacite; }
            set
            {
                if (_capacite != value)
                {
                    _capacite = value;
                    RaisePropertyChanged("Capacite");
                }
            }
        }

        public string Localisation
        {
            get { return _localisation; }
            set
            {
                if (_localisation != value)
                {
                    _localisation = value;
                    RaisePropertyChanged("Localisation");
                }
            }
        }

        public string Pays
        {
            get { return _pays; }
            set
            {
                if (_pays != value)
                {
                    _pays = value;
                    RaisePropertyChanged("Pays");
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChambresSet> ChambresSet { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
