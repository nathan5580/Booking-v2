namespace Booking_MVVM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChambresSet")]
    public partial class ChambresSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChambresSet()
        {
            ReservationSet = new HashSet<ReservationSet>();
        }

        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        public bool Climatisation { get; set; }

        public int NbLits { get; set; }

        public int? Hotel_Id { get; set; }

        public int keyHotel { get; set; }

        public virtual HotelsSet HotelsSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationSet> ReservationSet { get; set; }
    }
}
