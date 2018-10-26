namespace Booking_MVVM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientsSet")]
    public partial class ClientsSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientsSet()
        {
            ReservationSet = new HashSet<ReservationSet>();
        }

        public int Id { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public string Nom { get; set; }

        public DateTime DateNaissance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationSet> ReservationSet { get; set; }
    }
}
